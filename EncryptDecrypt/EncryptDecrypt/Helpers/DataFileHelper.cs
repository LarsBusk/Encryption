using EncryptDecrypt.Containers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace EncryptDecrypt.Helpers
{
    /// <summary>
    /// Class that gets information about rawdata from samples and subsamples and settings files
    /// from a data export file. The data must be in a subfolder.
    /// </summary>
    public class DataFileHelper
    {
        private readonly XNamespace ns = "http://foss.dk/Mosaic/Export";

        private readonly XElement sampleGroups;

        private readonly XElement selfTests;

        public DataFileHelper(string dataFileName)
        {
            var data = XDocument.Load(dataFileName);
            sampleGroups = data.Root.Element(ns + "Instrument").Element(ns + "SampleGroups");
            selfTests = data.Root.Element(ns + "Instrument").Element(ns + "SelfTests");
        }

        /// <summary>
        /// Gets rawdata from samples and subsamples.
        /// </summary>
        /// <returns>A list of sample contents</returns>
        public List<SampleContent> GetSamples()
        {
            var samples = new List<SampleContent>();

            var sampleElements = sampleGroups.Elements(ns + "SampleGroup").Elements(ns + "SampleList")
                .Elements(ns + "Sample");
            int sampleNumber = 0;

            foreach (var sampleElement in sampleElements)
            {
                sampleNumber++;
                SampleContent sampleContent = new SampleContent(sampleNumber);
                sampleContent.RawDataContents.AddRange(GetRawDataContents(sampleElement, sampleContent.ToString()));
                sampleContent.SubSampleList.AddRange(GetSubSamples(sampleElement, sampleContent.ToString()));
                samples.Add(sampleContent);
            }

            return samples;
        }

        public List<SelfTestContent> GetSelfTests()
        {
            List<SelfTestContent> selfTestElements = new List<SelfTestContent>();

            var selfTestSteps = selfTests.Elements(ns + "SelfTest").Elements(ns + "SelfTestSteps")
                .Elements(ns + "SelfTestStep");

            foreach (var selfTestStep in selfTestSteps)
            {
                SelfTestContent step = new SelfTestContent(selfTestStep.Attribute("Name").Value,
                    selfTestStep.Attribute("Status").Value, selfTestStep.Attribute("StepNumber").Value);

                var selfTestResults = selfTestStep.Elements(ns + "SelfTestResults").Elements(ns + "SelfTestResult");
                int selfTestResultNumber = 0;

                foreach (var selfTestResult in selfTestResults)
                {
                    step.AddRawData(GetRawData(selfTestResult, "", selfTestResultNumber));
                    selfTestResultNumber++;
                }

                selfTestElements.Add(step);
            }

            return selfTestElements;
        }

        /// <summary>
        /// Gets a list of files with settings.
        /// </summary>
        /// <returns></returns>
        public List<Tuple<string, string>> SettingsFileList()
        {
            var group = selfTests ?? sampleGroups;
            string settingGroup = selfTests != null ? "SelfTest" : "SampleGroup";

            var settings = group.Elements(ns + settingGroup).Elements(ns + "InstrumentExtensionList")
                .Elements(ns + "InstrumentExtension")
                .Elements(ns + "SettingGroup").Elements(ns + "Setting")
                .Where(s => s.Attribute("DataType").Value.Equals("File"));

            List<Tuple<string, string>> files = new List<Tuple<string, string>>();

            foreach (var setting in settings)
            {
                if (setting.Element(ns + "FileReference") != null)
                {
                    var fileName = new Tuple<string, string>(
                        setting.Element(ns + "FileReference").Attribute("PathName").Value,
                        setting.Element(ns + "FileReference").Attribute("FileName").Value);


                    if (!files.Contains(fileName) & !fileName.Item2.EndsWith("rpt"))
                    {
                        files.Add(fileName);
                    }
                }
            }

            return files;
        }

        private List<SubSampleContent> GetSubSamples(XElement parent, string parentName)
        {
            var subSamplesContents = new List<SubSampleContent>();
            var subSampleList = parent.Element(ns + "SubSampleList");

            if (subSampleList is null) return null;

            var subSampleElements = subSampleList.Elements(ns + "SubSample").ToList();

            for (int i = 0; i < subSampleElements.Count(); i++)
            {
                var subSample = new SubSampleContent(i, parentName);
                subSample.RawDataContents.AddRange(GetRawDataContents(subSampleElements[i], subSample.ToString()));
                subSample.SubSampleList.AddRange(GetSubSamples(subSampleElements[i], subSample.ToString()));
                subSamplesContents.Add(subSample);
            }

            return subSamplesContents;
        }

        private List<RawDataContent> GetRawDataContents(XElement parent, string parentName)
        {
            var rawDataList = parent.Element(ns + "RawValueList");
            var rawList = new List<RawDataContent>();

            if (rawDataList is null) return null;
            
            var rawValueElements = rawDataList.Elements(ns + "RawValue").ToList();

            for (var i = 0; i < rawValueElements.Count(); i++)
            {
                rawList.Add(GetRawData(rawValueElements[i], parentName, i));
            }

            return rawList;
        }

        private RawDataContent GetRawData(XElement rawDataElement, string parentName, int rawDataNumber = 0)
        {
            return new RawDataContent(rawDataElement.Attribute("Identification").Value,
                rawDataElement.Element(ns + "RawDataFile").Attribute("FileName").Value,
                rawDataElement.Element(ns + "RawDataFile").Attribute("PathName").Value,
                parentName,
                rawDataNumber);
        }
    }
}
