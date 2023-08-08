using FgisApplicationReaderLib;

namespace FgisApplicationStreamReaderTests
{
    public class FgisApplicationStreamReaderTests
    {
        static string fgisTemplate = File.ReadAllText(Path.Combine("Xml", "FgisTemplate.xml"));
        static string fgisRecord = File.ReadAllText(Path.Combine("Xml", "FgisRecord.xml"));

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
                writer.Write(GetSample(0));
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
                writer.Write(GetSample(count));
                writer.Flush();
                stream.Position = 0;

                var records = cut.Records();
                Assert.Equal(count, records.Count());
            }
        }

        string GetSample(int count)
        {
            var marker = "@body";
            
            int idx = fgisTemplate.IndexOf(marker);
            if (idx == -1)
                throw new FormatException($"Marker {marker} not found");

            var sample = fgisTemplate;
            for (int i = 0; i < count; i++)
                sample = sample.Insert(idx, fgisRecord);

            sample = sample.Replace(marker, string.Empty);
            sample = sample.Replace("gost:", string.Empty);

            return sample;
        }
    }
}