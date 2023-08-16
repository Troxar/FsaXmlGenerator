using FgisProtocolRecordsProvider;

namespace FgisProtocolRecordsProviderTests
{
    public class XmlFgisProtocolRecordsProviderTests
    {
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void XmlFgisProtocolRecordsProvider_CorrectRecords(int count)
        {
            var sampleXml = XmlFgisProtocolSampleProvider.GetXmlSample(count);
            var sampleApp = XmlFgisProtocolSampleProvider.GetFgisProtocolSample(count);
            var path = Path.GetTempFileName();
            File.WriteAllText(path, sampleXml);

            var provider = new XmlFgisProtocolRecordsProvider(path);
            Assert.Equal(sampleApp.AppProcessed.ProtocolRecords, provider.Records);
        }
    }
}
