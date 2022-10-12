using EncryptDecrypt.DataDetails;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace EncryptDecrypt.Helpers
{
    public class XmlHelper
  {
    public static string DestinationFolder;

    public static void WriteToCsvFile(string instrument)
    {
      string fileName = instrument == "MM2" ? "RawDataDetails.csv" : "ScanDetails.csv";
      string csvFileName = Path.Combine(DestinationFolder, fileName);

      List<string> builder = new List<string>();

      List<IDataDetails> detailsList = instrument == "MM2" ? ImageDetailsList() : ProFossScanDetails();

      if (detailsList.Count == 0)
        return;
      
      builder.Add(detailsList[0].Header());

      foreach (var imageDetails in detailsList)
      {
        builder.Add(imageDetails.ToString());
      }

      File.WriteAllLines(csvFileName, builder);
    }

    private static IDataDetails ReadImageDetails(string imageFile)
    {
      XDocument imageDoc = XDocument.Load(imageFile);
      CultureInfo xmlCulture = new CultureInfo("en-US");
      XElement rawScanElement = imageDoc.Root;

      return new Mm2ImageDetails(imageFile,double.Parse(rawScanElement.Attribute("EncoderPosition").Value, xmlCulture),
        int.Parse(rawScanElement.Attribute("DroppedLines").Value),
        int.Parse(rawScanElement.Attribute("FlashCount").Value),
        int.Parse(rawScanElement.Attribute("ReplacedPixels").Value),
        int.Parse(rawScanElement.Attribute("NominalSpeed").Value),
        double.Parse(rawScanElement.Attribute("MeanSpeed").Value, xmlCulture),
        double.Parse(rawScanElement.Attribute("StdDevSpeed").Value, xmlCulture),
        double.Parse(rawScanElement.Attribute("CameraTemperature").Value, xmlCulture),
        double.Parse(rawScanElement.Attribute("XrayVoltage").Value, xmlCulture),
        double.Parse(rawScanElement.Attribute("XrayVoltageSet").Value, xmlCulture),
        double.Parse(rawScanElement.Attribute("XrayCurrent").Value, xmlCulture),
        double.Parse(rawScanElement.Attribute("XrayCurrentSet").Value, xmlCulture),
        double.Parse(rawScanElement.Attribute("XrayTemperature").Value, xmlCulture),
        rawScanElement.Attribute("CameraSerialNumber").Value,
        int.Parse(rawScanElement.Attribute("NumberOfImagePixels").Value),
        int.Parse(rawScanElement.Attribute("NumberOfNorminalDarkPixels").Value),
        int.Parse(rawScanElement.Attribute("NumberOfNorminalAirPixels").Value));
    }

    private static IDataDetails ReadScanDetails(string scanFile)
    {
      XNamespace ns = "http://foss.dk/PDL/FOSS/Bifrost/Types";
      XDocument scanDoc = XDocument.Load(scanFile);
      CultureInfo xmlCulture = new CultureInfo("en-US");
      XElement resultsElement = scanDoc.Root;

      XElement scanElement =
        resultsElement.Elements("Result").First(r => r.Element(ns + "Datatype").Value.Equals("DDA_SCAN"));

      XElement sensorElement =
        resultsElement.Elements("Result").First(r => r.Element(ns + "Datatype").Value.Equals("SENSOR"));

      DateTime scanDateTime = UnixTimeStampToDateTime(Double.Parse(scanElement.Attribute("Time").Value));

      string detType = scanElement.Element(ns + "DatatypeUnion0").Element(ns + "Scan").Attribute("DetectorType").Value;

      double pcbTemp = double.Parse(sensorElement.Element(ns + "DatatypeUnion0").Element(ns + "Data").Element(ns + "Sensors")
        .Element(ns + "SensorData").Attribute("Value").Value, xmlCulture);

      string scanType = scanElement.Element(ns + "DatatypeUnion0").Attribute("Scan_type").Value;

      int intTime = int.Parse(scanElement.Element(ns + "DatatypeUnion0").Element(ns + "Scan").Attribute("IntegrationTime")
        .Value);

      string detectorConfiguration = scanElement.Element(ns + "DatatypeUnion0").Element(ns + "Scan")
        .Attribute("DetectorConfiguration").Value;

      return new ProFossScanDetail(scanDateTime, detType, pcbTemp, scanType, intTime, scanFile, detectorConfiguration);
    }

    private static List<IDataDetails> ImageDetailsList()
    {
      string[] sampleFiles = Directory.GetFiles(DestinationFolder, "*_SCAN*");
      List<IDataDetails> imageDetailesList = new List<IDataDetails>();

      foreach (var sampleFile in sampleFiles)
      {
        imageDetailesList.Add(ReadImageDetails(sampleFile));
      }

      return imageDetailesList;
    }

    private static List<IDataDetails> ProFossScanDetails()
    {
      string[] scanFiles = Directory.GetFiles(DestinationFolder)
        .Where(f => f.Contains("REFERENCE") | f.Contains("SAMPLE")).ToArray();
      List<IDataDetails> scanDetailsList = new List<IDataDetails>();

      foreach (var scanFile in scanFiles)
      {
        scanDetailsList.Add(ReadScanDetails(scanFile));
      }

      return scanDetailsList;
    }

    private static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
    {
      // Unix timestamp is seconds past epoch
      DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
      dateTime = dateTime.AddSeconds(unixTimeStamp);
      return dateTime;
    }
  }
}
