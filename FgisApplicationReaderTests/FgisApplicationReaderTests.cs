using FgisApplicationReaderLib;

namespace FgisApplicationReaderTests
{
    public class FgisApplicationReaderTests
    {
        [Fact]
        public void FgisApplicationReader_NoRecords()
        {
            var sample = FgisApplicationSampleProvider.GetSample(0);
            var path = Path.GetTempFileName();
            File.WriteAllText(path, sample);

            var cut = new FgisApplicationReader(path);
            Assert.Empty(cut.Records());
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void FgisApplicationReader_Records(int count)
        {
            var sample = FgisApplicationSampleProvider.GetSample(count);
            var path = Path.GetTempFileName();
            File.WriteAllText(path, sample);

            var cut = new FgisApplicationReader(path);
            Assert.Equal(count, cut.Records().Count());
        }
    }
}
