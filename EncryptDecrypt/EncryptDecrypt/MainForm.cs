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
using FOSS.Nova.Common.Encryption;

namespace EncryptDecrypt
{
  public partial class MainForm : Form
  {
    private string fileName;

    public MainForm()
    {
      InitializeComponent();
    }

    private void label1_Click(object sender, EventArgs e)
    {

    }

    private void btnBrowse_Click(object sender, EventArgs e)
    {
      OpenFileDialog dialog = new OpenFileDialog();
      if (dialog.ShowDialog() != DialogResult.Cancel)
      {
        fileName = dialog.FileName;
        lblSelectedFile.Text = fileName;
      }
    }

    private void btnDecryptAndSave_Click(object sender, EventArgs e)
    {
      SaveFileDialog dialog = new SaveFileDialog();
      dialog.Filter = "Xml files|*.xml";

      if (dialog.ShowDialog() != DialogResult.Cancel)
      {
        byte[] encBytes = File.ReadAllBytes(fileName);
        byte[] decBytes = DecryptionHelper.DecryptFile(encBytes);
        File.WriteAllBytes(dialog.FileName, decBytes);
      }
    }
  }
}
