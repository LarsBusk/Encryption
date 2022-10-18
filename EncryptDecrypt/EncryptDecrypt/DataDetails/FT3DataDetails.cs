using System.IO;

namespace EncryptDecrypt.DataDetails
{
    public class FT3DataDetails : IDataDetails
    {
        public string FileName
        {
            get => Path.GetFileName(this.fileName);

            set => this.fileName = value;
        }

        public string DetectorType;
        public string DetectorConfiguration;
        public int Gain;
        public int ScanTime;
        public int SumOf;

        private string fileName;

        public FT3DataDetails(string fileName, string detectorType, string detectorConfiguration, int gain, int scanTime, int sumOf)
        {
            this.FileName = fileName;
            this.DetectorType = detectorType;
            this.DetectorConfiguration = detectorConfiguration;
            this.Gain = gain;
            this.ScanTime = scanTime;
            this.SumOf = sumOf;
        }

        public override string ToString()
        {
            return $"{fileName};{DetectorType};{DetectorConfiguration};{Gain};{ScanTime};{SumOf}";
        }

        string IDataDetails.Header()
        {
            return "FileName;DetectorType;DetectorConfiguration;Gain;ScanTime;SumOf";
        }
    }
}
