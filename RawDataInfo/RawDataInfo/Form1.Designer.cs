namespace RawDataInfo
{
  partial class Form1
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
      this.browseButton = new System.Windows.Forms.Button();
      this.Savebutton = new System.Windows.Forms.Button();
      this.dataGrid = new System.Windows.Forms.DataGridView();
      ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
      this.SuspendLayout();
      // 
      // browseButton
      // 
      this.browseButton.Location = new System.Drawing.Point(713, 376);
      this.browseButton.Name = "browseButton";
      this.browseButton.Size = new System.Drawing.Size(75, 23);
      this.browseButton.TabIndex = 0;
      this.browseButton.Text = "Browse";
      this.browseButton.UseVisualStyleBackColor = true;
      this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
      // 
      // Savebutton
      // 
      this.Savebutton.Location = new System.Drawing.Point(713, 406);
      this.Savebutton.Name = "Savebutton";
      this.Savebutton.Size = new System.Drawing.Size(75, 23);
      this.Savebutton.TabIndex = 1;
      this.Savebutton.Text = "Save csv";
      this.Savebutton.UseVisualStyleBackColor = true;
      this.Savebutton.Click += new System.EventHandler(this.Savebutton_Click);
      // 
      // dataGrid
      // 
      this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGrid.Location = new System.Drawing.Point(44, 12);
      this.dataGrid.Name = "dataGrid";
      this.dataGrid.Size = new System.Drawing.Size(646, 426);
      this.dataGrid.TabIndex = 2;
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 450);
      this.Controls.Add(this.dataGrid);
      this.Controls.Add(this.Savebutton);
      this.Controls.Add(this.browseButton);
      this.Name = "Form1";
      this.Text = "MeatMasterII Rawdata Viewer";
      ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button browseButton;
    private System.Windows.Forms.Button Savebutton;
    private System.Windows.Forms.DataGridView dataGrid;
  }
}

