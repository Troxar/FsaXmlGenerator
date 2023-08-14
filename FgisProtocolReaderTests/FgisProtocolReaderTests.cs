using FgisProtocolReaderLib;

namespace FgisProtocolReaderTests
{
    public class FgisProtocolReaderTests
    {
        [Fact]
        public void FgisProtocolReader_NoRecords()
        {
            var sample = FgisProtocolSampleProvider.GetSample(0);
            var path = Path.GetTempFileName();
            File.WriteAllText(path, sample);

            var cut = new FgisProtocolReader(path);
            Assert.Empty(cut.Records());
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void FgisProtocolReader_Records(int count)
        {
            var sample = FgisProtocolSampleProvider.GetSample(count);
            var path = Path.GetTempFileName();
            File.WriteAllText(path, sample);

            var cut = new FgisProtocolReader(path);
            Assert.Equal(count, cut.Records().Count());
        }
    }
}
