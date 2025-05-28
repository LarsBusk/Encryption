using AsymmetricDecryption;
using EncryptDecrypt.Containers;
using EncryptDecrypt.Events;
using FOSS.Nova.Common.Encryption;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace EncryptDecrypt.Helpers
{
    public class DecryptionHelper
    {
        public event EventHandler<DecryptStatusEventArgs> DecryptStatus;
        public readonly string DestinationFolder;

        private static DataFileHelper helper;
        
        private readonly string fileName;

        public DecryptionHelper(string fileName)
        {
            this.DestinationFolder =  Path.Combine(Path.GetDirectoryName(fileName),
                $"{Path.GetFileNameWithoutExtension(fileName)}_DecryptedRawFiles"); 
            
            this.fileName = fileName;
        }

        public bool DecryptSingleFile(string decryptedFileName, string readFileName)
        {
            byte[] encBytes = File.ReadAllBytes(readFileName);
            byte[] decBytes = DecryptData(encBytes);
            if (decBytes is null) return false;

            File.WriteAllBytes(decryptedFileName, decBytes);
            return true;
        }

        public void DecryptSamplesFromDataFile()
        {
            helper = new DataFileHelper(fileName);
            List<SampleContent> samples = helper.GetSamples();

            if (!Directory.Exists(DestinationFolder))
                Directory.CreateDirectory(DestinationFolder);
            
            var rawDataContents = new List<RawDataContent>();

            foreach (var sampleContent in samples)
            {
                rawDataContents.AddRange(sampleContent.GetRawData());
            }

            foreach (var rawDataContent in rawDataContents)
            {
                string extention = rawDataContent.Identification.Equals("JpegPicture") ? "jpeg" : "xml";
                string decryptedFileName = $"{rawDataContent}.{extention}";
                string decryptedFilePathName = Path.Combine(DestinationFolder, decryptedFileName);
                string readFileName =
                    Path.Combine(Path.GetDirectoryName(fileName), rawDataContent.DataFileName);

                DecryptStatus.Invoke(this, new DecryptStatusEventArgs($"Processing {readFileName}.\n"));

                if (new[] { "JpegPicture", "ForeignObjectData" }.Contains(rawDataContent.Identification))
                {
                    CopyFile(readFileName, decryptedFilePathName, decryptedFileName);
                }
                else if (rawDataContent.Identification.Equals("ABS_SCAN"))
                {
                    DecrompressionHelper.Decompress(decryptedFilePathName, readFileName);
                }
                else if (DecryptSingleFile(decryptedFilePathName, readFileName))
                {
                    DecryptStatus.Invoke(this,
                        new DecryptStatusEventArgs($"{readFileName} was succesfully decrypted, saved as{decryptedFileName}.xml.\n"));
                }
            }
        }

        public void DecryptSettingsFilesFromDataFile()
        {
            helper = new DataFileHelper(fileName);
            var settingFiles = helper.SettingsFileList();

            foreach (var settingFile in settingFiles)
            {
                string readFileName =
                    Path.Combine(Path.GetDirectoryName(fileName), settingFile.Item1, settingFile.Item2);
                string decryptedFileName = Path.Combine(DestinationFolder, settingFile.Item2 + ".xml");

                if (File.Exists(readFileName))
                {
                    if (DecryptSingleFile(decryptedFileName, readFileName))
                    {
                        DecryptStatus.Invoke(this, new DecryptStatusEventArgs($"{settingFile} was successfully decrypted.\n"));
                    }
                }
            }
        }

        public void DecryptSelfTestFromDataFile()
        {
            helper = new DataFileHelper(fileName);
            List<SelfTestContent> selfTests = helper.GetSelfTests();

            if (!Directory.Exists(DestinationFolder))
            {
                Directory.CreateDirectory(DestinationFolder);
            }

            foreach (var selfTest in selfTests)
            {
                foreach (var rawDataContent in selfTest.RawDataContents)
                {
                    string decryptedFileName = $"{selfTest}_{rawDataContent}.xml";
                    string decryptedFilePathName = Path.Combine(DestinationFolder, decryptedFileName);
                    string readFileName = Path.Combine(Path.GetDirectoryName(fileName), rawDataContent.DataFileName);

                    bool copyFile =
                        new[]
                        {
                            "NOISE", "SensorList", "STRAY_LIGHT", "PEAKBANDWIDTH", "PEAKBANDWIDTHREPEATABILITY",
                            "PEAKPOSITION", "PEAKPOSITIONREPEATABILITY"
                        }.Contains(rawDataContent.Identification);

                    if (copyFile)
                    {
                        CopyFile(readFileName, decryptedFilePathName, decryptedFileName);
                    }
                    else if (DecryptSingleFile(decryptedFilePathName, readFileName))
                    {
                        DecryptStatus.Invoke(this, new DecryptStatusEventArgs($"{decryptedFileName}.xml succesfully decrypted.\n"));
                    }
                }
            }
        }

        private static byte[] DecryptData(byte[] encryptedData)
        {
            if (encryptedData is null) return null;
            
            try
            {
                XDocument xd;

                using (var stream = new MemoryStream(encryptedData))
                {
                    using (XmlReader xmlReader = XmlReader.Create(stream))
                    {
                        xd = XDocument.Load(xmlReader);
                    }
                }

                XElement root = xd.Root;

                if (root == null)
                {
                    return null;
                }

                var crVersion = (int?)root.Attribute("CrVersion");

                if (!crVersion.HasValue)
                {
                    return null;
                }

                switch (crVersion.Value)
                {
                    case (int)CryptoVersion.CrV0AsymRaw1:
                        return Asymmetric.Decrypt(encryptedData);
                    case (int)CryptoVersion.CrV1SymRaw1:
                    case (int)CryptoVersion.CrV4SymRaw2:
                    case (int)CryptoVersion.CrV5SymRaw3:
                        return EncryptionSymmHelper.Decrypt(encryptedData);
                    case (int)CryptoVersion.CrV2SymSettings1:
                    case (int)CryptoVersion.CrV6SymSettings2:
                        return EncryptionSettingsHelper.Decrypt(encryptedData);
                    case (int)CryptoVersion.CrV3AsymRaw2:
                        return Asymmetric.Decrypt(encryptedData);
                    default:
                        return null;
                }
            }
            catch (Exception e)
            {
                string message = $"Decryption failed \n {e.Message} \n {e.InnerException}";
                MessageBox.Show(message, "Decryption failed");
            }

            return null;
        }

        public static bool DecryptBlackBoxFile(string decryptedFileName, string readFileName)
        {
            byte[] encryptedBytes = File.ReadAllBytes(readFileName);
            byte[] decryptedBytes = Asymmetric.Decrypt(encryptedBytes);

            if (decryptedBytes is null) return false;

            File.WriteAllBytes(decryptedFileName, decryptedBytes);
            return true;
        }

        private void CopyFile(string readFileName, string decryptedFilePathName, string decryptedFileName)
        {
            File.Copy(readFileName, decryptedFilePathName, true);
            DecryptStatus.Invoke(this, new DecryptStatusEventArgs($"{decryptedFileName} was copied\n"));
        }
    }
}