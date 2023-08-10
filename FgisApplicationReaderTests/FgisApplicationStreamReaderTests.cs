using FgisApplicationReaderLib;

namespace FgisApplicationReaderTests
{
    public class FgisApplicationStreamReaderTests
    {
        [Fact]
        public void FgisApplicationStreamReader_ExceptionOnEmptyStream()
        {
            using (var stream = new MemoryStream())
            using (var writer = new StreamWriter(stream))
            using (var cut = new FgisApplicationStreamReader(stream))
            {
                Assert.Throws<InvalidOperationException>(() => cut.Records());
            }
        }

        [Fact]
        public void FgisApplicationStreamReader_NoRecords()
        {
            using (var stream = new MemoryStream())
            using (var writer = new StreamWriter(stream))
            using (var cut = new FgisApplicationStreamReader(stream))
            {
                writer.Write(FgisApplicationSampleProvider.GetSample(0));
                writer.Flush();
                stream.Position = 0;

                var records = cut.Records();
                Assert.Empty(records);
            }
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void FgisApplicationStreamReader_RecordsFromStream(int count)
        {
            using (var stream = new MemoryStream())
            using (var writer = new StreamWriter(stream))
            using (var cut = new FgisApplicationStreamReader(stream))
            {
                writer.Write(FgisApplicationSampleProvider.GetSample(count));
                writer.Flush();
                stream.Position = 0;

                var records = cut.Records();
                Assert.Equal(count, records.Count());
            }
        }
    }
}
