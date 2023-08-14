namespace FgisProtocolReaderTests
{
    internal static class FgisProtocolSampleProvider
    {
        static string fgisTemplate = File.ReadAllText(Path.Combine("Xml", "ProtocolTemplate.xml"));
        static string fgisRecord = File.ReadAllText(Path.Combine("Xml", "ProtocolRecord.xml"));

        internal static string GetSample(int count)
        {
            var marker = "@body";

            int idx = fgisTemplate.IndexOf(marker);
            if (idx == -1)
                throw new FormatException($"Marker {marker} not found");

            var sample = fgisTemplate;
            for (int i = 0; i < count; i++)
                sample = sample.Insert(idx, fgisRecord);

            sample = sample.Replace(marker, string.Empty);
            return sample;
        }
    }
}
