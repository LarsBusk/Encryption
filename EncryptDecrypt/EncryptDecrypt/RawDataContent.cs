using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptDecrypt
{
  /// <summary>
  /// Class to contain the values of the RawValue element in the exported xml file
  /// </summary>
  public class RawDataContent
  {
    public string Identification { get; }

    public string DataFileName { get; }

    public string PathName { get; }

    public int RawDataNumber { get; set; }

    public RawDataContent(string identification, string dataFileName, string pathName, int rawDataNumber = 0)
    {
      this.Identification = identification;
      this.DataFileName = Path.Combine(pathName, dataFileName);
      this.PathName = pathName;
      this.RawDataNumber = rawDataNumber;
    }

    public override string ToString()
    {
      return $"{Identification}_{RawDataNumber}";
    }
  }
}
