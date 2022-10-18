using FOSS.Nova.Common.Encryption;
using System;
using System.IO;
using System.Windows.Forms;
using EncryptDecrypt.Containers;
using EncryptDecrypt.Events;
using EncryptDecrypt.Helpers;

namespace EncryptDecrypt
{
    public partial class MainForm : Form
    {
        private string fileName;
        private byte[] encryptedData;

        private delegate void AppendToRichTextBoxDelegate(string text);

        public MainForm()
        {
            InitializeComponent();

            foreach (var cryptoVersionContent in GetCryptoVersionContents())
            {
                cbEncryptionVersion.Items.Add(cryptoVersionContent);
            }

            cbEncryptionVersion.SelectedItem = cbEncryptionVersion.Items[0];
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            if (dialog.ShowDialog().Equals(DialogResult.Cancel)) return;

            fileName = dialog.FileName;
            lblSelectedFile.Text = fileName;
            btnDecryptAndSave.Enabled = true;
        }

        private void btnDecryptAndSave_Click(object sender, EventArgs e)
        {
            rtbResult.Clear();

            //Decrypt Blackbox files from MilkoStream.
            if (rbBlackBox.Checked)
            {
                var dialog = new SaveFileDialog();
                dialog.Filter = "Text files|*.txt";
                if (dialog.ShowDialog().Equals(DialogResult.Cancel)) return;

                DecrompressionHelper.Decompress(dialog.FileName, fileName);
                return;
            }

            DecryptionHelper decryptionHelper = new DecryptionHelper(fileName);
            decryptionHelper.DecryptStatus += DecryptionHelper_DecryptStatus;

            //Decrypt a single encrypted file
            if (rbSingleFile.Checked)
            {
                var dialog = new SaveFileDialog();
                dialog.Filter = "Xml files|*.xml";

                if (dialog.ShowDialog().Equals(DialogResult.Cancel)) return;

                if (decryptionHelper.DecryptSingleFile(dialog.FileName, fileName))
                    AppendToRichTextBox($"{fileName} was successfully decrypted and saved as {dialog.FileName}.");
            }

            //Decrypt a sample export file from Mosaic
            else if (rbSampleExportFile.Checked)
            {
                decryptionHelper.DecryptSamplesFromDataFile();
                decryptionHelper.DecryptSettingsFilesFromDataFile();

                if (instrumentComboBox.Text != "Other")
                {
                    XmlHelper.DestinationFolder = decryptionHelper.DestinationFolder;
                    XmlHelper.WriteToCsvFile(instrumentComboBox.Text);
                }
            }
            //Decrypt a selftest that is exported from Mosaic
            else
            {
                decryptionHelper.DecryptSelfTestFromDataFile();
                decryptionHelper.DecryptSettingsFilesFromDataFile();
            }
        }

        private void DecryptionHelper_DecryptStatus(object sender, DecryptStatusEventArgs e)
        {
            AppendToRichTextBox(e.Message);
        }

        private void btnBrowseEnc_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            CryptoVersion crVersion = ((CryptoVersionContent)cbEncryptionVersion.SelectedItem).CryptoVersion;

            if (dialog.ShowDialog().Equals(DialogResult.Cancel)) return;

            var data = File.ReadAllBytes(dialog.FileName);
            encryptedData = Helpers.EncryptionHelper.EncryptData(data, crVersion);

            btnEncryptAndSave.Enabled = true;
        }

        private void btnEncryptAndSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "xml files|*.xml";

            if (dialog.ShowDialog() != DialogResult.Cancel)
                File.WriteAllBytes(dialog.FileName, encryptedData);
        }

        private CryptoVersionContent[] GetCryptoVersionContents()
        {
            return new CryptoVersionContent[]
            {
                new CryptoVersionContent(CryptoVersion.CrV0AsymRaw1, "0"),
                new CryptoVersionContent(CryptoVersion.CrV3AsymRaw2, "3"),
                new CryptoVersionContent(CryptoVersion.CrV6SymSettings2, "6")
            };
        }

        private void AppendToRichTextBox(string text)
        {
            if (rtbResult.InvokeRequired)
            {
                AppendToRichTextBoxDelegate d = AppendToRichTextBox;
                this.Invoke(d, new object[] { text });
                return;
            }

            rtbResult.AppendText($"{text}\n");
            rtbResult.ScrollToCaret();
        }
    }
}
