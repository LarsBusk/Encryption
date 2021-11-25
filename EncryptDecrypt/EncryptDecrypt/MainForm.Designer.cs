namespace EncryptDecrypt
{
  partial class MainForm
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.groupBox3 = new System.Windows.Forms.GroupBox();
      this.rbSelfTestFile = new System.Windows.Forms.RadioButton();
      this.rbBlackBox = new System.Windows.Forms.RadioButton();
      this.rbSampleExportFile = new System.Windows.Forms.RadioButton();
      this.rbSingleFile = new System.Windows.Forms.RadioButton();
      this.lblSelectedFile = new System.Windows.Forms.Label();
      this.rtbResult = new System.Windows.Forms.RichTextBox();
      this.btnDecryptAndSave = new System.Windows.Forms.Button();
      this.btnBrowse = new System.Windows.Forms.Button();
      this.rbSampleExport = new System.Windows.Forms.GroupBox();
      this.label1 = new System.Windows.Forms.Label();
      this.cbEncryptionVersion = new System.Windows.Forms.ComboBox();
      this.btnEncryptAndSave = new System.Windows.Forms.Button();
      this.btnBrowseEnc = new System.Windows.Forms.Button();
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      this.groupBox1.SuspendLayout();
      this.groupBox3.SuspendLayout();
      this.rbSampleExport.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      this.SuspendLayout();
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.groupBox3);
      this.groupBox1.Controls.Add(this.lblSelectedFile);
      this.groupBox1.Controls.Add(this.rtbResult);
      this.groupBox1.Controls.Add(this.btnDecryptAndSave);
      this.groupBox1.Controls.Add(this.btnBrowse);
      this.groupBox1.Location = new System.Drawing.Point(31, 18);
      this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.groupBox1.Size = new System.Drawing.Size(603, 426);
      this.groupBox1.TabIndex = 0;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Decrypt";
      // 
      // groupBox3
      // 
      this.groupBox3.Controls.Add(this.rbSelfTestFile);
      this.groupBox3.Controls.Add(this.rbBlackBox);
      this.groupBox3.Controls.Add(this.rbSampleExportFile);
      this.groupBox3.Controls.Add(this.rbSingleFile);
      this.groupBox3.Location = new System.Drawing.Point(377, 161);
      this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.groupBox3.Name = "groupBox3";
      this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.groupBox3.Size = new System.Drawing.Size(217, 159);
      this.groupBox3.TabIndex = 4;
      this.groupBox3.TabStop = false;
      this.groupBox3.Text = "Filetype";
      // 
      // rbSelfTestFile
      // 
      this.rbSelfTestFile.AutoSize = true;
      this.rbSelfTestFile.Location = new System.Drawing.Point(20, 121);
      this.rbSelfTestFile.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.rbSelfTestFile.Name = "rbSelfTestFile";
      this.rbSelfTestFile.Size = new System.Drawing.Size(141, 21);
      this.rbSelfTestFile.TabIndex = 3;
      this.rbSelfTestFile.TabStop = true;
      this.rbSelfTestFile.Text = "Selftest export file";
      this.rbSelfTestFile.UseVisualStyleBackColor = true;
      // 
      // rbBlackBox
      // 
      this.rbBlackBox.AutoSize = true;
      this.rbBlackBox.Location = new System.Drawing.Point(19, 92);
      this.rbBlackBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.rbBlackBox.Name = "rbBlackBox";
      this.rbBlackBox.Size = new System.Drawing.Size(108, 21);
      this.rbBlackBox.TabIndex = 2;
      this.rbBlackBox.TabStop = true;
      this.rbBlackBox.Text = "BlackBox file";
      this.rbBlackBox.UseVisualStyleBackColor = true;
      // 
      // rbSampleExportFile
      // 
      this.rbSampleExportFile.AutoSize = true;
      this.rbSampleExportFile.Checked = true;
      this.rbSampleExportFile.Location = new System.Drawing.Point(19, 64);
      this.rbSampleExportFile.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.rbSampleExportFile.Name = "rbSampleExportFile";
      this.rbSampleExportFile.Size = new System.Drawing.Size(141, 21);
      this.rbSampleExportFile.TabIndex = 1;
      this.rbSampleExportFile.TabStop = true;
      this.rbSampleExportFile.Text = "Sample export file";
      this.rbSampleExportFile.UseVisualStyleBackColor = true;
      // 
      // rbSingleFile
      // 
      this.rbSingleFile.AutoSize = true;
      this.rbSingleFile.Location = new System.Drawing.Point(19, 36);
      this.rbSingleFile.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.rbSingleFile.Name = "rbSingleFile";
      this.rbSingleFile.Size = new System.Drawing.Size(148, 21);
      this.rbSingleFile.TabIndex = 0;
      this.rbSingleFile.Text = "Single raw data file";
      this.rbSingleFile.UseVisualStyleBackColor = true;
      // 
      // lblSelectedFile
      // 
      this.lblSelectedFile.AutoSize = true;
      this.lblSelectedFile.Location = new System.Drawing.Point(29, 39);
      this.lblSelectedFile.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.lblSelectedFile.Name = "lblSelectedFile";
      this.lblSelectedFile.Size = new System.Drawing.Size(30, 17);
      this.lblSelectedFile.TabIndex = 3;
      this.lblSelectedFile.Text = "File";
      // 
      // rtbResult
      // 
      this.rtbResult.Location = new System.Drawing.Point(21, 70);
      this.rtbResult.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.rtbResult.Name = "rtbResult";
      this.rtbResult.Size = new System.Drawing.Size(336, 346);
      this.rtbResult.TabIndex = 2;
      this.rtbResult.Text = "";
      // 
      // btnDecryptAndSave
      // 
      this.btnDecryptAndSave.Enabled = false;
      this.btnDecryptAndSave.Location = new System.Drawing.Point(372, 390);
      this.btnDecryptAndSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.btnDecryptAndSave.Name = "btnDecryptAndSave";
      this.btnDecryptAndSave.Size = new System.Drawing.Size(145, 28);
      this.btnDecryptAndSave.TabIndex = 1;
      this.btnDecryptAndSave.Text = "Decrypt and save";
      this.btnDecryptAndSave.UseVisualStyleBackColor = true;
      this.btnDecryptAndSave.Click += new System.EventHandler(this.btnDecryptAndSave_Click);
      // 
      // btnBrowse
      // 
      this.btnBrowse.Location = new System.Drawing.Point(372, 354);
      this.btnBrowse.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.btnBrowse.Name = "btnBrowse";
      this.btnBrowse.Size = new System.Drawing.Size(145, 28);
      this.btnBrowse.TabIndex = 0;
      this.btnBrowse.Text = "Browse";
      this.btnBrowse.UseVisualStyleBackColor = true;
      this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
      // 
      // rbSampleExport
      // 
      this.rbSampleExport.Controls.Add(this.pictureBox1);
      this.rbSampleExport.Controls.Add(this.label1);
      this.rbSampleExport.Controls.Add(this.cbEncryptionVersion);
      this.rbSampleExport.Controls.Add(this.btnEncryptAndSave);
      this.rbSampleExport.Controls.Add(this.btnBrowseEnc);
      this.rbSampleExport.Location = new System.Drawing.Point(641, 22);
      this.rbSampleExport.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.rbSampleExport.Name = "rbSampleExport";
      this.rbSampleExport.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.rbSampleExport.Size = new System.Drawing.Size(481, 426);
      this.rbSampleExport.TabIndex = 1;
      this.rbSampleExport.TabStop = false;
      this.rbSampleExport.Text = "Encrypt";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(308, 300);
      this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(125, 17);
      this.label1.TabIndex = 3;
      this.label1.Text = "Encryption version";
      // 
      // cbEncryptionVersion
      // 
      this.cbEncryptionVersion.FormattingEnabled = true;
      this.cbEncryptionVersion.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6"});
      this.cbEncryptionVersion.Location = new System.Drawing.Point(312, 320);
      this.cbEncryptionVersion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.cbEncryptionVersion.Name = "cbEncryptionVersion";
      this.cbEncryptionVersion.Size = new System.Drawing.Size(160, 24);
      this.cbEncryptionVersion.TabIndex = 2;
      // 
      // btnEncryptAndSave
      // 
      this.btnEncryptAndSave.Location = new System.Drawing.Point(373, 389);
      this.btnEncryptAndSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.btnEncryptAndSave.Name = "btnEncryptAndSave";
      this.btnEncryptAndSave.Size = new System.Drawing.Size(100, 28);
      this.btnEncryptAndSave.TabIndex = 1;
      this.btnEncryptAndSave.Text = "Save As..";
      this.btnEncryptAndSave.UseVisualStyleBackColor = true;
      // 
      // btnBrowseEnc
      // 
      this.btnBrowseEnc.Location = new System.Drawing.Point(373, 353);
      this.btnBrowseEnc.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.btnBrowseEnc.Name = "btnBrowseEnc";
      this.btnBrowseEnc.Size = new System.Drawing.Size(100, 28);
      this.btnBrowseEnc.TabIndex = 0;
      this.btnBrowseEnc.Text = "Browse";
      this.btnBrowseEnc.UseVisualStyleBackColor = true;
      this.btnBrowseEnc.Click += new System.EventHandler(this.btnBrowseEnc_Click);
      // 
      // pictureBox1
      // 
      this.pictureBox1.Image = global::EncryptDecrypt.Properties.Resources.Enigma;
      this.pictureBox1.Location = new System.Drawing.Point(106, 13);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(366, 275);
      this.pictureBox1.TabIndex = 4;
      this.pictureBox1.TabStop = false;
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1139, 463);
      this.Controls.Add(this.rbSampleExport);
      this.Controls.Add(this.groupBox1);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.Name = "MainForm";
      this.Text = "Nova Encrypt Decryptinator";
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.groupBox3.ResumeLayout(false);
      this.groupBox3.PerformLayout();
      this.rbSampleExport.ResumeLayout(false);
      this.rbSampleExport.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.Label lblSelectedFile;
    private System.Windows.Forms.RichTextBox rtbResult;
    private System.Windows.Forms.Button btnDecryptAndSave;
    private System.Windows.Forms.Button btnBrowse;
    private System.Windows.Forms.GroupBox rbSampleExport;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.ComboBox cbEncryptionVersion;
    private System.Windows.Forms.Button btnEncryptAndSave;
    private System.Windows.Forms.Button btnBrowseEnc;
    private System.Windows.Forms.GroupBox groupBox3;
    private System.Windows.Forms.RadioButton rbSampleExportFile;
    private System.Windows.Forms.RadioButton rbSingleFile;
    private System.Windows.Forms.RadioButton rbBlackBox;
    private System.Windows.Forms.RadioButton rbSelfTestFile;
    private System.Windows.Forms.PictureBox pictureBox1;
  }
}

