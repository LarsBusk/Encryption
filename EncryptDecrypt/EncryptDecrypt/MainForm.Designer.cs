﻿namespace EncryptDecrypt
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
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.lblSelectedFile = new System.Windows.Forms.Label();
      this.rtbResult = new System.Windows.Forms.RichTextBox();
      this.btnDecryptAndSave = new System.Windows.Forms.Button();
      this.btnBrowse = new System.Windows.Forms.Button();
      this.rbSampleExport = new System.Windows.Forms.GroupBox();
      this.label1 = new System.Windows.Forms.Label();
      this.cbEncryptionVersion = new System.Windows.Forms.ComboBox();
      this.btnEncryptAndSave = new System.Windows.Forms.Button();
      this.btnBrowseEnc = new System.Windows.Forms.Button();
      this.groupBox3 = new System.Windows.Forms.GroupBox();
      this.rbSingleFile = new System.Windows.Forms.RadioButton();
      this.radioButton2 = new System.Windows.Forms.RadioButton();
      this.groupBox1.SuspendLayout();
      this.rbSampleExport.SuspendLayout();
      this.groupBox3.SuspendLayout();
      this.SuspendLayout();
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.groupBox3);
      this.groupBox1.Controls.Add(this.lblSelectedFile);
      this.groupBox1.Controls.Add(this.rtbResult);
      this.groupBox1.Controls.Add(this.btnDecryptAndSave);
      this.groupBox1.Controls.Add(this.btnBrowse);
      this.groupBox1.Location = new System.Drawing.Point(23, 15);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(452, 346);
      this.groupBox1.TabIndex = 0;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Decrypt";
      // 
      // lblSelectedFile
      // 
      this.lblSelectedFile.AutoSize = true;
      this.lblSelectedFile.Location = new System.Drawing.Point(22, 32);
      this.lblSelectedFile.Name = "lblSelectedFile";
      this.lblSelectedFile.Size = new System.Drawing.Size(23, 13);
      this.lblSelectedFile.TabIndex = 3;
      this.lblSelectedFile.Text = "File";
      // 
      // rtbResult
      // 
      this.rtbResult.Location = new System.Drawing.Point(16, 57);
      this.rtbResult.Name = "rtbResult";
      this.rtbResult.Size = new System.Drawing.Size(253, 282);
      this.rtbResult.TabIndex = 2;
      this.rtbResult.Text = "";
      // 
      // btnDecryptAndSave
      // 
      this.btnDecryptAndSave.Enabled = false;
      this.btnDecryptAndSave.Location = new System.Drawing.Point(279, 317);
      this.btnDecryptAndSave.Name = "btnDecryptAndSave";
      this.btnDecryptAndSave.Size = new System.Drawing.Size(109, 23);
      this.btnDecryptAndSave.TabIndex = 1;
      this.btnDecryptAndSave.Text = "Decrypt and save";
      this.btnDecryptAndSave.UseVisualStyleBackColor = true;
      this.btnDecryptAndSave.Click += new System.EventHandler(this.btnDecryptAndSave_Click);
      // 
      // btnBrowse
      // 
      this.btnBrowse.Location = new System.Drawing.Point(279, 288);
      this.btnBrowse.Name = "btnBrowse";
      this.btnBrowse.Size = new System.Drawing.Size(109, 23);
      this.btnBrowse.TabIndex = 0;
      this.btnBrowse.Text = "Browse";
      this.btnBrowse.UseVisualStyleBackColor = true;
      this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
      // 
      // rbSampleExport
      // 
      this.rbSampleExport.Controls.Add(this.label1);
      this.rbSampleExport.Controls.Add(this.cbEncryptionVersion);
      this.rbSampleExport.Controls.Add(this.btnEncryptAndSave);
      this.rbSampleExport.Controls.Add(this.btnBrowseEnc);
      this.rbSampleExport.Location = new System.Drawing.Point(481, 18);
      this.rbSampleExport.Name = "rbSampleExport";
      this.rbSampleExport.Size = new System.Drawing.Size(361, 346);
      this.rbSampleExport.TabIndex = 1;
      this.rbSampleExport.TabStop = false;
      this.rbSampleExport.Text = "Encrypt";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(231, 244);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(94, 13);
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
      this.cbEncryptionVersion.Location = new System.Drawing.Point(234, 260);
      this.cbEncryptionVersion.Name = "cbEncryptionVersion";
      this.cbEncryptionVersion.Size = new System.Drawing.Size(121, 21);
      this.cbEncryptionVersion.TabIndex = 2;
      // 
      // btnEncryptAndSave
      // 
      this.btnEncryptAndSave.Location = new System.Drawing.Point(280, 316);
      this.btnEncryptAndSave.Name = "btnEncryptAndSave";
      this.btnEncryptAndSave.Size = new System.Drawing.Size(75, 23);
      this.btnEncryptAndSave.TabIndex = 1;
      this.btnEncryptAndSave.Text = "Save As..";
      this.btnEncryptAndSave.UseVisualStyleBackColor = true;
      // 
      // btnBrowseEnc
      // 
      this.btnBrowseEnc.Location = new System.Drawing.Point(280, 287);
      this.btnBrowseEnc.Name = "btnBrowseEnc";
      this.btnBrowseEnc.Size = new System.Drawing.Size(75, 23);
      this.btnBrowseEnc.TabIndex = 0;
      this.btnBrowseEnc.Text = "Browse";
      this.btnBrowseEnc.UseVisualStyleBackColor = true;
      // 
      // groupBox3
      // 
      this.groupBox3.Controls.Add(this.radioButton2);
      this.groupBox3.Controls.Add(this.rbSingleFile);
      this.groupBox3.Location = new System.Drawing.Point(283, 131);
      this.groupBox3.Name = "groupBox3";
      this.groupBox3.Size = new System.Drawing.Size(163, 87);
      this.groupBox3.TabIndex = 4;
      this.groupBox3.TabStop = false;
      this.groupBox3.Text = "Filetype";
      // 
      // rbSingleFile
      // 
      this.rbSingleFile.AutoSize = true;
      this.rbSingleFile.Location = new System.Drawing.Point(14, 29);
      this.rbSingleFile.Name = "rbSingleFile";
      this.rbSingleFile.Size = new System.Drawing.Size(114, 17);
      this.rbSingleFile.TabIndex = 0;
      this.rbSingleFile.Text = "Single raw data file";
      this.rbSingleFile.UseVisualStyleBackColor = true;
      // 
      // radioButton2
      // 
      this.radioButton2.AutoSize = true;
      this.radioButton2.Checked = true;
      this.radioButton2.Location = new System.Drawing.Point(14, 52);
      this.radioButton2.Name = "radioButton2";
      this.radioButton2.Size = new System.Drawing.Size(108, 17);
      this.radioButton2.TabIndex = 1;
      this.radioButton2.TabStop = true;
      this.radioButton2.Text = "Sample export file";
      this.radioButton2.UseVisualStyleBackColor = true;
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(854, 376);
      this.Controls.Add(this.rbSampleExport);
      this.Controls.Add(this.groupBox1);
      this.Name = "MainForm";
      this.Text = "Nova Encrypt Decryptinator";
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.rbSampleExport.ResumeLayout(false);
      this.rbSampleExport.PerformLayout();
      this.groupBox3.ResumeLayout(false);
      this.groupBox3.PerformLayout();
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
    private System.Windows.Forms.RadioButton radioButton2;
    private System.Windows.Forms.RadioButton rbSingleFile;
  }
}

