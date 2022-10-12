using System;
using System.IO;

namespace EncryptDecrypt.DataDetails
{
    public class ProFossScanDetail :IDataDetails
  {
    public DateTime ScanDateTime;
    public string DetectorType;
    public double PcbTemperature;
    public string ScanType;
    public int IntegrationTime;
    public string DetectorConfiguration;

    public string FileName
    {
      get => Path.GetFileName(this.fileName);

      set => this.fileName = value;
    }

    private string fileName;

    public ProFossScanDetail(DateTime scanDateTime, string detectorType, double pcbTemperature, string scanType,
      int integrationTime, string fileName, string detectorConfiguration)
    {
      this.ScanDateTime = scanDateTime;
      this.DetectorType = detectorType;
      this.PcbTemperature = pcbTemperature;
      this.ScanType = scanType;
      this.IntegrationTime = integrationTime;
      this.FileName = fileName;
      this.DetectorConfiguration = detectorConfiguration;
    }

    public string Header()
    {
      return "FileName;ScanDateTime;DetectorType;DetectorConfiguration;PcbTemperature;ScanType;IntegrationTime";
    }

    public override string ToString()
    {
      return $"{FileName};{ScanDateTime};{DetectorType};{DetectorConfiguration}{PcbTemperature};{ScanType};{IntegrationTime}";
    }
  }
}
