using System.Collections.Generic;

namespace EncryptDecrypt.Containers
{
    public class SubSampleContent
    {
        public List<RawDataContent> RawDataContents { get; private set; }
        public List<SubSampleContent> SubSampleList { get; private set; }

        public int SubSampleNumber;
        public string ParentName;

        public SubSampleContent(int subSampleNumber, string parentName)
        {
            RawDataContents = new List<RawDataContent>();
            SubSampleList = new List<SubSampleContent>();
            SubSampleNumber = subSampleNumber;
            ParentName = parentName;
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
            return $"{ParentName}_SubSample_{SubSampleNumber}_";
        }
    }
}
