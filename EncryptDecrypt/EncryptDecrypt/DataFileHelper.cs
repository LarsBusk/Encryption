using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EncryptDecrypt
{
  public class DataFileHelper
  {
    public List<SampleContent> GetSamples(string dataFileName)
    {
      List<SampleContent> samples = new List<SampleContent>();

      XDocument data = XDocument.Load(dataFileName);
      XNamespace ns = "http://foss.dk/Mosaic/Export";

      XElement sampleGroups = data.Element(ns + "Instruments").Element(ns + "Instrument").Element(ns + "SampleGroups");

      var sampleElements = sampleGroups.Elements(ns + "SampleGroup").Elements(ns + "SampleList").Elements(ns + "Sample");
      int sampleNumber = 0;
      foreach (var sampleElement in sampleElements)
      {
        sampleNumber++;
        SampleContent sampleContent = new SampleContent(sampleNumber);

        var rawDataElements = sampleElement.Element(ns + "RawValueList").Elements(ns + "RawValue");

        foreach (var rawDataElement in rawDataElements)
        {
          RawDataContent rawDataContent = new RawDataContent(rawDataElement.Attribute("Identification").Value,
            rawDataElement.Element(ns + "RawDataFile").Attribute("FileName").Value,
            rawDataElement.Element(ns + "RawDataFile").Attribute("PathName").Value,
            false);

          sampleContent.AddRawData(rawDataContent);
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
              RawDataContent subSamplerawDataContent = new RawDataContent(subSampleRawData.Attribute("Identification").Value,
                subSampleRawData.Element(ns + "RawDataFile").Attribute("FileName").Value,
                subSampleRawData.Element(ns + "RawDataFile").Attribute("PathName").Value,
                false);
              subSampleContent.AddRawData(subSamplerawDataContent);
            }

            samples.Add(subSampleContent);
          }
        }
      }

      return samples;
    }
  }
}
