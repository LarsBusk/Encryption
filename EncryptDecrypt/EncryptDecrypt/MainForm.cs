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

      if (rbSingleFile.Checked)
      {
        SaveFileDialog dialog = new SaveFileDialog();
        dialog.Filter = "Xml files|*.xml";

        if (dialog.ShowDialog() != DialogResult.Cancel)
        {
          if (DecryptSingleFile(dialog.FileName, fileName))
          {
            rtbResult.AppendText($"{fileName} was successfully decrypted and saved as {dialog.FileName}.");
          }
        }
      }
      else if (rbBlackBox.Checked)
      {
        SaveFileDialog dialog = new SaveFileDialog();
        dialog.Filter = "Text files|*.txt";
        if (dialog.ShowDialog() != DialogResult.Cancel)
        {
          Decompress(dialog.FileName, fileName);
        }
      }
      else
      {
        helper = new DataFileHelper(fileName);
        destinationfolder = Path.Combine(Path.GetDirectoryName(fileName), "DecryptedRawFiles");
        DecryptSamplesFromDataFile();
        DecryptSettingsFilesFromDataFile();
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

          if (sampleRawDataContent.Identification.Equals("JpegPicture") ||
              sampleRawDataContent.Identification.Equals("ForeignObjectData"))
          {
            File.Copy(readFileName, decryptedFilePathName, true);
            rtbResult.AppendText($"{decryptedFileName} was copied\n");
          }
          else if (sampleRawDataContent.Identification.Equals("ABS_SCAN"))
          {
            Decompress(decryptedFilePathName, readFileName);
          }
          else if (DecryptSingleFile(decryptedFilePathName, readFileName))
          {
            rtbResult.AppendText($"{decryptedFileName}.xml succesfully decrypted.\n");
          }
        }
      }
    }

    private void DecryptSettingsFilesFromDataFile()
    {
      var settingFiles = helper.SettingsFileList();

      foreach (var settingFile in settingFiles)
      {
        string readFileName = Path.Combine(Path.GetDirectoryName(fileName), settingFile.Item1, settingFile.Item2);
        string decryptedFileName = Path.Combine(destinationfolder, settingFile.Item2 + ".xml");

        if (File.Exists(readFileName))
        {
          if (DecryptSingleFile(decryptedFileName, readFileName))
          {
            rtbResult.AppendText($"{settingFile} was successfully decrypted.\n");
          }
        }
      }
    }

    private bool DecryptSingleFile(string decryptedFileName, string readFileName)
    {
      byte[] encBytes = File.ReadAllBytes(readFileName);
      byte[] decBytes = DecryptionHelper.DecryptFile(encBytes);
      if (decBytes != null)
      {
        File.WriteAllBytes(decryptedFileName, decBytes);
        return true;
      }

      return false;
    }

    private bool DecryptBlackBoxFile(string decryptedFileName, string readFileName)
    {
      byte[] encBytes = File.ReadAllBytes(readFileName);
      byte[] decBytes = DecryptionHelper.DecryptBlackBoxData(encBytes);

      if (decBytes != null)
      {
        File.WriteAllBytes(decryptedFileName, decBytes);
        return true;
      }

      return false;
    }

    private void Decompress(string decryptedFileName, string readFileName)
    {
      var floats = DecrompressionHelper.Decompress(readFileName);

      StringBuilder builder = new StringBuilder();

      foreach (var f in floats)
      {
        builder.Append(f.ToString());
        builder.Append(";");
      }

      string[] writeStrings = new[] {builder.ToString()};

      File.WriteAllLines(decryptedFileName, writeStrings);
    }
  }
}
