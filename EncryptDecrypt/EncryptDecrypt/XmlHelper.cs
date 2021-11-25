using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EncryptDecrypt
{
  public class XmlHelper
  {
    public static string DestinationFolder;

    public static void WriteToCsvFile()
    {
      string csvFileName = Path.Combine(DestinationFolder, "RawDataDetails.csv");

      List<string> builder = new List<string>();

      var detailsList = ImageDetailsList();

      if (detailsList.Count == 0)
        return;
      
      builder.Add(detailsList[0].Header());

      foreach (var imageDetails in detailsList)
      {
        builder.Add(imageDetails.ToString());
      }

      File.WriteAllLines(csvFileName, builder);
    }

    private static ImageDetails ReadImageDetails(string imageFile)
    {
      XDocument imageDoc = XDocument.Load(imageFile);
      CultureInfo xmlCulture = new CultureInfo("en-US");
      XElement rawScanElement = imageDoc.Root;

      return new ImageDetails(double.Parse(rawScanElement.Attribute("EncoderPosition").Value, xmlCulture),
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

    private static List<ImageDetails> ImageDetailsList()
    {
      string[] sampleFiles = Directory.GetFiles(DestinationFolder, "*SAMPLE_SCAN*");
      List<ImageDetails> imageDetailesList = new List<ImageDetails>();

      foreach (var sampleFile in sampleFiles)
      {
        imageDetailesList.Add(ReadImageDetails(sampleFile));
      }

      return imageDetailesList;
    }
  }
}
