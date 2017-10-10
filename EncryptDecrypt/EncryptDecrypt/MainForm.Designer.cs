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
      this.richTextBox1 = new System.Windows.Forms.RichTextBox();
      this.btnDecryptAndSave = new System.Windows.Forms.Button();
      this.btnBrowse = new System.Windows.Forms.Button();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.btnBrowseEnc = new System.Windows.Forms.Button();
      this.btnEncryptAndSave = new System.Windows.Forms.Button();
      this.cbEncryptionVersion = new System.Windows.Forms.ComboBox();
      this.label1 = new System.Windows.Forms.Label();
      this.groupBox1.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.SuspendLayout();
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.lblSelectedFile);
      this.groupBox1.Controls.Add(this.richTextBox1);
      this.groupBox1.Controls.Add(this.btnDecryptAndSave);
      this.groupBox1.Controls.Add(this.btnBrowse);
      this.groupBox1.Location = new System.Drawing.Point(23, 15);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(360, 346);
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
      this.lblSelectedFile.Click += new System.EventHandler(this.label1_Click);
      // 
      // richTextBox1
      // 
      this.richTextBox1.Location = new System.Drawing.Point(16, 57);
      this.richTextBox1.Name = "richTextBox1";
      this.richTextBox1.Size = new System.Drawing.Size(253, 282);
      this.richTextBox1.TabIndex = 2;
      this.richTextBox1.Text = "";
      // 
      // btnDecryptAndSave
      // 
      this.btnDecryptAndSave.Location = new System.Drawing.Point(279, 317);
      this.btnDecryptAndSave.Name = "btnDecryptAndSave";
      this.btnDecryptAndSave.Size = new System.Drawing.Size(75, 23);
      this.btnDecryptAndSave.TabIndex = 1;
      this.btnDecryptAndSave.Text = "Save As..";
      this.btnDecryptAndSave.UseVisualStyleBackColor = true;
      this.btnDecryptAndSave.Click += new System.EventHandler(this.btnDecryptAndSave_Click);
      // 
      // btnBrowse
      // 
      this.btnBrowse.Location = new System.Drawing.Point(279, 288);
      this.btnBrowse.Name = "btnBrowse";
      this.btnBrowse.Size = new System.Drawing.Size(75, 23);
      this.btnBrowse.TabIndex = 0;
      this.btnBrowse.Text = "Browse";
      this.btnBrowse.UseVisualStyleBackColor = true;
      this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
      // 
      // groupBox2
      // 
      this.groupBox2.Controls.Add(this.label1);
      this.groupBox2.Controls.Add(this.cbEncryptionVersion);
      this.groupBox2.Controls.Add(this.btnEncryptAndSave);
      this.groupBox2.Controls.Add(this.btnBrowseEnc);
      this.groupBox2.Location = new System.Drawing.Point(399, 15);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new System.Drawing.Size(361, 346);
      this.groupBox2.TabIndex = 1;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Encrypt";
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
      // btnEncryptAndSave
      // 
      this.btnEncryptAndSave.Location = new System.Drawing.Point(280, 316);
      this.btnEncryptAndSave.Name = "btnEncryptAndSave";
      this.btnEncryptAndSave.Size = new System.Drawing.Size(75, 23);
      this.btnEncryptAndSave.TabIndex = 1;
      this.btnEncryptAndSave.Text = "Save As..";
      this.btnEncryptAndSave.UseVisualStyleBackColor = true;
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
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(231, 244);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(94, 13);
      this.label1.TabIndex = 3;
      this.label1.Text = "Encryption version";
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(781, 376);
      this.Controls.Add(this.groupBox2);
      this.Controls.Add(this.groupBox1);
      this.Name = "MainForm";
      this.Text = "Nova Encrypt Decryptinator";
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.Label lblSelectedFile;
    private System.Windows.Forms.RichTextBox richTextBox1;
    private System.Windows.Forms.Button btnDecryptAndSave;
    private System.Windows.Forms.Button btnBrowse;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.ComboBox cbEncryptionVersion;
    private System.Windows.Forms.Button btnEncryptAndSave;
    private System.Windows.Forms.Button btnBrowseEnc;
  }
}
