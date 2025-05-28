using System.Collections.Generic;

namespace EncryptDecrypt.Containers
{
    public class SampleContent
    {
        public int SampleNumber;
        public List<RawDataContent> RawDataContents { get; private set; }

        public List<SubSampleContent> SubSampleList;

        public SampleContent(int sampleNumber)
        {
            RawDataContents = new List<RawDataContent>();
            SubSampleList = new List<SubSampleContent>();

            this.SampleNumber = sampleNumber;
        }


        public List<RawDataContent> GetRawData()
        {
            var rawData = new List<RawDataContent>();

            rawData.AddRange(this.RawDataContents);

            foreach (var subSampleContent in SubSampleList)
            {
                rawData.AddRange(subSampleContent.GetRawData());
            }

            return rawData;
        }

        public override string ToString()
        {
            return SampleNumber < 10 ? $"Sample_0{SampleNumber}_" : $"Sample_{SampleNumber}_";
        }
    }
}
