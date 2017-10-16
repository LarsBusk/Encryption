using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EncryptDecrypt
{
  public class DataFileHelper
  {
    private XNamespace ns = "http://foss.dk/Mosaic/Export";

    private XDocument data;

    private XElement sampleGroups;

    public DataFileHelper(string dataFileName)
    {
      data = XDocument.Load(dataFileName);
      sampleGroups = data.Element(ns + "Instruments").Element(ns + "Instrument").Element(ns + "SampleGroups");
    }

    public List<SampleContent> GetSamples()
    {
      List<SampleContent> samples = new List<SampleContent>();

      var sampleElements = sampleGroups.Elements(ns + "SampleGroup").Elements(ns + "SampleList").Elements(ns + "Sample");
      int sampleNumber = 0;

      foreach (var sampleElement in sampleElements)
      {
        sampleNumber++;
        SampleContent sampleContent = new SampleContent(sampleNumber);
        var rawDataElements = sampleElement.Element(ns + "RawValueList").Elements(ns + "RawValue");

        foreach (var rawDataElement in rawDataElements)
        {
          sampleContent.AddRawData(GetRawData(rawDataElement));
        }

        samples.Add(sampleContent);

        var subSampliList = sampleElement.Element(ns + "SubSampleList");

        if (subSampliList != null)
        {
          var subSamples = subSampliList.Elements(ns + "SubSample");
          int subSampleNumber = 0;

          foreach (var subSample in subSamples)
          {
            subSampleNumber++;
            SampleContent subSampleContent = new SampleContent(sampleNumber, true , subSampleNumber);
            var subSampleRawDatas = subSample.Elements(ns + "RawValueList").Elements(ns + "RawValue");

            foreach (var subSampleRawData in subSampleRawDatas)
            {
              subSampleContent.AddRawData(GetRawData(subSampleRawData));
            }

            samples.Add(subSampleContent);
          }
        }
      }

      return samples;
    }

    public List<Tuple<string, string>> SettingsFileList()
    {
      var settings = sampleGroups.Elements(ns + "SampleGroup").Elements(ns + "InstrumentExtensionList")
        .Elements(ns + "InstrumentExtension")
        .Elements(ns + "SettingGroup").Elements(ns + "Setting")
        .Where(s => s.Attribute("DataType").Value.Equals("File"));
      List<Tuple<string,string>> files = new List<Tuple<string, string>>();

      foreach (var setting in settings)
      {
        if (setting.Element(ns + "FileReference") != null)
        {
          var fileName = new Tuple<string, string>(
            setting.Element(ns + "FileReference").Attribute("PathName").Value,
            setting.Element(ns + "FileReference").Attribute("FileName").Value);


          if (!files.Contains(fileName))
          {
            files.Add(fileName);
          }
        }
      }

      return files;
    }

    private RawDataContent GetRawData(XElement rawDataElement)
    {
      return new RawDataContent(rawDataElement.Attribute("Identification").Value,
        rawDataElement.Element(ns + "RawDataFile").Attribute("FileName").Value,
        rawDataElement.Element(ns + "RawDataFile").Attribute("PathName").Value,
        false);
    }
  }
}
