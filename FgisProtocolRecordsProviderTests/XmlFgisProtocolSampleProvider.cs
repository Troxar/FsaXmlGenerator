using FgisProtocolDomain;

namespace FgisProtocolRecordsProviderTests
{
    internal static class XmlFgisProtocolSampleProvider
    {
        static string protocolTemplate = File.ReadAllText(Path.Combine("Xml", "FgisProtocol.xml"));
        static string protocolRecord = File.ReadAllText(Path.Combine("Xml", "FgisProtocolRecord.xml"));

        internal static string GetXmlSample(int count)
        {
            var marker = "@record";

            int idx = protocolTemplate.IndexOf(marker);
            if (idx == -1)
                throw new FormatException($"Marker {marker} not found");

            var sample = protocolTemplate;
            for (int i = 0; i < count; i++)
                sample = sample.Insert(idx, protocolRecord);

            sample = sample.Replace(marker, string.Empty);
            return sample;
        }

        internal static FgisProtocol GetFgisProtocolSample(int count)
        {
            var success = new Success
            {
                GlobalId = 264874789,
                CertNum = "С-ГГИ/17-07-2023/264874789"
            };
            var record = new FgisProtocolRecord
            {
                Success = success
            };
            var records = Enumerable.Repeat(record, count).ToArray();
            var appProcessed = new AppProcessed { ProtocolRecords = records };
            var protocol = new FgisProtocol
            {
                StartProcessingString = "2023-07-27T08:01:51+03:00",
                FinishProcessingString = "2023-07-27T08:02:06+03:00",
                AppProcessed = appProcessed
            };
            return protocol;
        }
    }
}
