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
    }

    private List<RawDataStuff> ReadData(string folderName)
    {
      List<RawDataStuff> rawDataStuffs = new List<RawDataStuff>();

      string[] dataFiles = Directory.GetFiles(folderName).Where(f => f.Contains("SAMPLE_SCAN")).ToArray();
      
      foreach (var dataFile in dataFiles)
      {
        XDocument rawData = XDocument.Load(dataFile);

        XNamespace ns = "http://foss.dk/PDL/FOSS/Bifrost/Types";
        CultureInfo culture = new CultureInfo("en-US");
        XElement xRayRawData = rawData.Element(ns + "XRAY_RawScan");

        RawDataStuff stuff = new RawDataStuff(
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

    private void SaveCsv(string fileName)
    {
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

      if (!dialog.ShowDialog().Equals(DialogResult.Cancel))
      {
        SaveCsv(dialog.FileName);
      }
    }
  }
}
