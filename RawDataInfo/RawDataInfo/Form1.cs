using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace RawDataInfo
{
  public partial class Form1 : Form
  {
    private List<RawDataStuff> rawDataStuffs;
    public Form1()
    {
      InitializeComponent();
    }

    private void browseButton_Click(object sender, EventArgs e)
    {
      FolderBrowserDialog dialog = new FolderBrowserDialog();

      if (!dialog.ShowDialog().Equals(DialogResult.Cancel))
      {
        rawDataStuffs = ReadData(dialog.SelectedPath);
      }

      UpdateDataGrid();
    }

    private List<RawDataStuff> ReadData(string folderName)
    {
      List<RawDataStuff> rawDataStuffs = new List<RawDataStuff>();

      string[] dataFiles = Directory.GetFiles(folderName).Where(f => f.Contains("_SCAN")).ToArray();
      
      foreach (var dataFile in dataFiles)
      {
        XNamespace ns = "http://foss.dk/PDL/FOSS/Bifrost/Types";
        CultureInfo culture = new CultureInfo("en-US");

        XDocument rawData = XDocument.Load(dataFile);
        XElement xRayRawData = rawData.Element(ns + "XRAY_RawScan");

        RawDataStuff stuff = new RawDataStuff(
          Path.GetFileNameWithoutExtension(dataFile),
          int.Parse(xRayRawData.Attribute("DroppedLines").Value),
          int.Parse(xRayRawData.Attribute("FlashCount").Value),
          int.Parse(xRayRawData.Attribute("ReplacedPixels").Value),
          double.Parse(xRayRawData.Attribute("CameraTemperature").Value, culture),
          double.Parse(xRayRawData.Attribute("XrayTemperature").Value, culture),
          double.Parse(xRayRawData.Attribute("MeanSpeed").Value, culture),
          double.Parse(xRayRawData.Attribute("StdDevSpeed").Value, culture)
          );

        rawDataStuffs.Add(stuff);
      }

      return rawDataStuffs;
    }

    private void UpdateDataGrid()
    {
      string[] columnHeaders = rawDataStuffs[0].ColumnHeaders;

      dataGrid.ColumnCount = columnHeaders.Length;

      for (int i = 0; i < columnHeaders.Length; i++)
      
      {
        DataGridViewColumn column = new DataGridViewColumn();
        column.HeaderText = columnHeaders[i];
        dataGrid.Columns[i].Name = columnHeaders[i];
      }

      foreach (var rawDataStuff in rawDataStuffs)
      {
        dataGrid.Rows.Add(rawDataStuff.ToString().Split(';'));
      }
    }

    private void SaveCsv(string fileName)
    {
      if (rawDataStuffs.Count < 1)
      {
        MessageBox.Show("No raw data to save", "Rawdata", MessageBoxButtons.OK);
        return;
      }

      List<string> lines = new List<string>();
      lines.Add(rawDataStuffs[0].Header);

      foreach (var rawDataStuff in rawDataStuffs)
      {
        lines.Add(rawDataStuff.ToString());
      }

      File.WriteAllLines(fileName, lines);
    }

    private void Savebutton_Click(object sender, EventArgs e)
    {
      SaveFileDialog dialog = new SaveFileDialog();
      dialog.Filter = "Csv files (*.csv)|*.csv";

      if (!dialog.ShowDialog().Equals(DialogResult.Cancel))
      {
        SaveCsv(dialog.FileName);
      }
    }
  }
}
