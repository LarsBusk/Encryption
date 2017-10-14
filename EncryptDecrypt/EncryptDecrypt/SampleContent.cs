using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptDecrypt
{
  public class SampleContent
  {
    public int SampleNumber { get; set; }
    public bool IsSubSample { get; set; }
    public int SubSampleNumber { get; set; }
    public List<RawDataContent> RawDataContents { get; private set; }

    public SampleContent(int sampleNumber,bool isSubSample = false, int subSampleNumber = 0)
    {
      RawDataContents = new List<RawDataContent>();

      this.SampleNumber = sampleNumber;
      this.IsSubSample = isSubSample;
      this.SubSampleNumber = subSampleNumber;
    }

    public void AddRawData(RawDataContent rawDataContent)
    {
      if (RawDataContents.Any(r => r.Identification.Equals(rawDataContent.Identification)))
      {
        rawDataContent.RawDataNumber++;
      }

      RawDataContents.Add(rawDataContent);
    }

    public override string ToString()
    {
      return this.IsSubSample ? $"Sample_{SampleNumber}_SubSample" : $"Sample_{SampleNumber}";
    }
  }
}
