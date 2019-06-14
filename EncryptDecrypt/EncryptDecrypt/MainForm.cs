using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FOSS.Nova.Common.DataAccess.SettingsAccessors.InstrumentSettings;
using FOSS.Nova.Common.Encryption;

namespace EncryptDecrypt
{
  public partial class MainForm : Form
  {
    private string fileName;

    private string destinationfolder;

    private DataFileHelper helper;

    public MainForm()
    {
      InitializeComponent();
    }

    private void btnBrowse_Click(object sender, EventArgs e)
    {
      OpenFileDialog dialog = new OpenFileDialog();
      if (dialog.ShowDialog() != DialogResult.Cancel)
      {
        fileName = dialog.FileName;
        lblSelectedFile.Text = fileName;
        btnDecryptAndSave.Enabled = true;
      }
    }

    private void btnDecryptAndSave_Click(object sender, EventArgs e)
    {
      rtbResult.Clear();

      //Decrypt a single encrypted file
      if (rbSingleFile.Checked)
      {
        SaveFileDialog dialog = new SaveFileDialog();
        dialog.Filter = "Xml files|*.xml";

        if (dialog.ShowDialog() != DialogResult.Cancel)
        {
          if (DecryptionHelper.DecryptSingleFile(dialog.FileName, fileName))
          {
            rtbResult.AppendText($"{fileName} was successfully decrypted and saved as {dialog.FileName}.");
          }
        }
      }
      //Decrypt Blackbox files from MilkoStream.
      else if (rbBlackBox.Checked)
      {
        SaveFileDialog dialog = new SaveFileDialog();
        dialog.Filter = "Text files|*.txt";
        if (dialog.ShowDialog() != DialogResult.Cancel)
        {
          DecrompressionHelper.Decompress(dialog.FileName, fileName);
        }
      }
      //Decrypt a sample export file from Mosaic
      else if (rbSampleExportFile.Checked)
      {
        helper = new DataFileHelper(fileName);
        destinationfolder = Path.Combine(Path.GetDirectoryName(fileName), "DecryptedRawFiles");
        DecryptSamplesFromDataFile();
        DecryptSettingsFilesFromDataFile(false);
      }
      //Decrypt a selftest that is exported from Mosaic
      else
      {
        helper = new DataFileHelper(fileName, true);
        destinationfolder = Path.Combine(Path.GetDirectoryName(fileName), "DecryptedRawFiles");
        DecryptSelfTestFromDataFile();
        DecryptSettingsFilesFromDataFile(true);
      }
    }

    private void DecryptSelfTestFromDataFile()
    {
      List<SelfTestContent> selfTests = helper.GetSelfTests();

      if (!Directory.Exists(destinationfolder))
      {
        Directory.CreateDirectory(destinationfolder);
      }

      foreach (var selfTest in selfTests)
      {
        foreach (var rawDataContent in selfTest.RawDataContents)
        {
          string decryptedFileName = $"{selfTest}_{rawDataContent}.xml";
          string decryptedFilePathName = Path.Combine(destinationfolder, decryptedFileName);
          string readFileName = Path.Combine(Path.GetDirectoryName(fileName), rawDataContent.DataFileName);
          
          bool copyFile = new[] {"NOISE", "SensorList", "STRAY_LIGHT", "PEAKBANDWIDTH", "PEAKBANDWIDTHREPEATABILITY", "PEAKPOSITION", "PEAKPOSITIONREPEATABILITY" }.Contains(rawDataContent.Identification);

          if (copyFile)
          {
            CopyFile(readFileName, decryptedFilePathName, decryptedFileName);
          }
          else if (DecryptionHelper.DecryptSingleFile(decryptedFilePathName, readFileName))
          {
            rtbResult.AppendText($"{decryptedFileName}.xml succesfully decrypted.\n");
          }
        }
      }
    }

    private void DecryptSamplesFromDataFile()
    {
      List<SampleContent> samples = helper.GetSamples();

      if (!Directory.Exists(destinationfolder))
      {
        Directory.CreateDirectory(destinationfolder);
      }

      int sampleNumber = 0;

      foreach (var sample in samples)
      {
        sampleNumber++;

        foreach (var sampleRawDataContent in sample.RawDataContents)
        {
          string extention = sampleRawDataContent.Identification.Equals("JpegPicture") ? "jpeg" : "xml";
          string decryptedFileName = $"{sample}_{sampleRawDataContent}.{extention}";
          string decryptedFilePathName = Path.Combine(destinationfolder, decryptedFileName);
          string readFileName = Path.Combine(Path.GetDirectoryName(fileName), sampleRawDataContent.DataFileName);
          
          if (new[] { "JpegPicture", "ForeignObjectData" }.Contains(sampleRawDataContent.Identification))
          {
            CopyFile(readFileName, decryptedFilePathName, decryptedFileName);
          }
          else if (sampleRawDataContent.Identification.Equals("ABS_SCAN"))
          {
            DecrompressionHelper.Decompress(decryptedFilePathName, readFileName);
          }
          else if (DecryptionHelper.DecryptSingleFile(decryptedFilePathName, readFileName))
          {
            rtbResult.AppendText($"{decryptedFileName}.xml succesfully decrypted.\n");
          }
        }
      }
    }

    private void DecryptSettingsFilesFromDataFile(bool isSelfTest)
    {
      var settingFiles = helper.SettingsFileList(isSelfTest);

      foreach (var settingFile in settingFiles)
      {
        string readFileName = Path.Combine(Path.GetDirectoryName(fileName), settingFile.Item1, settingFile.Item2);
        string decryptedFileName = Path.Combine(destinationfolder, settingFile.Item2 + ".xml");

        if (File.Exists(readFileName))
        {
          if (DecryptionHelper.DecryptSingleFile(decryptedFileName, readFileName))
          {
            rtbResult.AppendText($"{settingFile} was successfully decrypted.\n");
          }
        }
      }
    }


    private void CopyFile(string readFileName, string decryptedFilePathName, string decryptedFileName)
    {
      File.Copy(readFileName, decryptedFilePathName, true);
      rtbResult.AppendText($"{decryptedFileName} was copied\n");
    }
  }
}
