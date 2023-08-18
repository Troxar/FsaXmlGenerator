using FgisApplicationDomain;
using FgisProtocolDomain;
using FsaMessageDomain;

namespace FsaMessageGeneratorTests
{
    internal static class SamplesProvider
    {
        const int GlobalId = 264874789;
        const string VrfDateString = "2023-07-17+07:00";
        const string Modification = "МП3-Уф";

        static string fsaTemplate = File.ReadAllText(Path.Combine("Xml", "FsaMessage.xml"));
        static string fsaRecord = File.ReadAllText(Path.Combine("Xml", "FsaRecord.xml"));

        static FgisRecord GetFgisRecord()
        {
            var singleMi = new SingleMi
            {
                MiTypeNumber = "60168-15",
                ManufactureNum = "735101123A42",
                ManufactureYear = 2023,
                Modification = Modification
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
                VrfDateString = VrfDateString,
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
            return record;
        }

        internal static FgisApplication GetFgisApplication(int count)
        {
            var record = GetFgisRecord();
            var records = Enumerable.Repeat(record, count).ToArray();
            var app = new FgisApplication { FgisRecords = records };
            return app;
        }

        static FgisProtocolRecord GetFgisProtocolRecord()
        {
            var success = new Success
            {
                GlobalId = GlobalId,
                CertNum = "С-ГГИ/17-07-2023/264874789"
            };
            var record = new FgisProtocolRecord
            {
                Success = success
            };
            return record;
        }

        internal static FgisProtocol GetFgisProtocol(int count)
        {
            var record = GetFgisProtocolRecord();
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

        static FsaVerificationRecord GetFsaVerificationRecord()
        {
            var record = new FsaVerificationRecord
            {
                NumberVerification = GlobalId,
                DateVerificationString = VrfDateString,
                TypeMeasuringInstrument = Modification,
                ApprovedEmployee = GetApprovedEmployee(),
                ResultVerification = 1
            };
            return record;
        }

        internal static FsaMessage GetFsaMessage(int count)
        {
            var record = GetFsaVerificationRecord();
            var records = Enumerable.Repeat(record, count).ToArray();
            var message = new FsaMessage
            {
                VerificationData = new VerificationData { VerificationRecords = records },
                SaveMethod = 1
            };
            return message;
        }

        internal static ApprovedEmployee GetApprovedEmployee()
        {
            var employee = new ApprovedEmployee
            {
                Name = new EmployeeName
                {
                    Last = "Большакова",
                    First = "Елена"
                },
                Snils = "03216971234"
            };
            return employee;
        }

        internal static string GetFsaMessageXml(int count)
        {
            var marker = "@record";

            int idx = fsaTemplate.IndexOf(marker);
            if (idx == -1)
                throw new FormatException($"Marker {marker} not found");

            var sample = fsaTemplate;
            for (int i = 0; i < count; i++)
                sample = sample.Insert(idx, fsaRecord);

            sample = sample.Replace(marker, string.Empty);
            return sample;
        }
    }
}
