using FgisApplicationDomain;

namespace FgisApplicationRecordsProviderTests
{
    internal static class XmlFgisApplicationSampleProvider
    {
        static string fgisTemplate = File.ReadAllText(Path.Combine("Xml", "FgisApplication.xml"));
        static string fgisRecord = File.ReadAllText(Path.Combine("Xml", "FgisRecord.xml"));

        internal static string GetXmlSample(int count)
        {
            var marker = "@record";

            int idx = fgisTemplate.IndexOf(marker);
            if (idx == -1)
                throw new FormatException($"Marker {marker} not found");

            var sample = fgisTemplate;
            for (int i = 0; i < count; i++)
                sample = sample.Insert(idx, fgisRecord);

            sample = sample.Replace(marker, string.Empty);
            return sample;
        }

        internal static FgisApplication GetFgisApplicationSample(int count)
        {
            var singleMi = new SingleMi
            {
                MiTypeNumber = "60168-15",
                ManufactureNum = "735101123A42",
                ManufactureYear = 2023,
                Modification = "МП3-Уф"
            };
            var miInfo = new MiInfo { SingleMi = singleMi };
            var applicable = new Applicable
            {
                SignPass = false,
                SignMi = true
            };
            var mieta = new Mieta { Number = "16026.97.2Р.00190012" };
            var means = new Means { Mieta = mieta };
            var conditions = new Conditions
            {
                Temperature = "23°C",
                Pressure = "744 мм рт ст",
                Humidity = "67%"
            };
            var record = new FgisRecord
            {
                MiInfo = miInfo,
                SignCipher = "ГГИ",
                MiOwner = "АО \"ПО Физтех\"",
                VrfDateString = "2023-07-17+07:00",
                ValidDateString = "2025-07-16+07:00",
                Type = 1,
                Calibration = false,
                Applicable = applicable,
                DocTitle = "МИ2124-90 (СТБ 8056-2015)",
                Metrologist = "Мартюшев Роман Владимирович",
                Means = means,
                Conditions = conditions,
                Structure = "-"
            };
            var records = Enumerable.Repeat(record, count).ToArray();
            var app = new FgisApplication { FgisRecords = records };
            return app;
        }
    }
}
