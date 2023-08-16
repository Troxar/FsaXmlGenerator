using FgisApplicationRecordsProvider;

namespace FgisApplicationRecordsProviderTests
{
    public class XmlFgisApplicationRecordsProviderTests
    {
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void XmlFgisApplicationRecordsProvider_CorrectRecords(int count)
        {
            var sampleXml = XmlFgisApplicationSampleProvider.GetXmlSample(count);
            var sampleApp = XmlFgisApplicationSampleProvider.GetFgisApplicationSample(count);
            var path = Path.GetTempFileName();
            File.WriteAllText(path, sampleXml);

            var provider = new XmlFgisApplicationRecordsProvider(path);
            Assert.Equal(sampleApp.FgisRecords, provider.Records);
        }
    }
}
