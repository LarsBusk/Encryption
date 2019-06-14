using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptDecrypt
{
  public class SelfTestContent
  { 
    public string Type { get; set; }

    public string Result { get; set; }

    public string StepNumber { get; set; }

    public List<RawDataContent> RawDataContents { get; private set; }

    public SelfTestContent(string type, string result, string stepNumber)
    {
      this.Type = type;
      this.Result = result;
      this.StepNumber = stepNumber;
      this.RawDataContents = new List<RawDataContent>();
    }

    public void AddRawData(RawDataContent rawData)
    {
      this.RawDataContents.Add(rawData);
    }

    public override string ToString()
    {
      return $"{Type}_{StepNumber}_{Result}";
    }
  }
}
