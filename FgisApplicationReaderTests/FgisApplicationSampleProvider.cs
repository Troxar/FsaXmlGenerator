namespace FgisApplicationReaderTests
{
    internal static class FgisApplicationSampleProvider
    {
        static string fgisTemplate = File.ReadAllText(Path.Combine("Xml", "FgisTemplate.xml"));
        static string fgisRecord = File.ReadAllText(Path.Combine("Xml", "FgisRecord.xml"));

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
