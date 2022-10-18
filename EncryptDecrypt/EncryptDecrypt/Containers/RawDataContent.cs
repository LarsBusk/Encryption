using System.IO;

namespace EncryptDecrypt.Containers
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

    public string ParentName;

    public RawDataContent(string identification, string dataFileName, string pathName, string parentName, int rawDataNumber = 0)
    {
      this.Identification = identification;
      this.DataFileName = Path.Combine(pathName, dataFileName);
      this.PathName = pathName;
      this.RawDataNumber = rawDataNumber;
      this.ParentName = parentName;
    }

    public void Decrypt()
    {
        
    }

    public override string ToString()
    {
      return $"{ParentName}_{Identification}_{RawDataNumber}";
    }
  }
}
