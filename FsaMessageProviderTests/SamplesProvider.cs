using FgisApplicationDomain;
using FgisProtocolDomain;
using FsaMessageDomain;

namespace FsaMessageProviderTests
{
    internal static class SamplesProvider
    {
        const int GlobalId = 123456789;
        const string VrfDateString = "2023-07-17+07:00";
        const string Modification = "AB1-Cd";

        static string fsaTemplate = File.ReadAllText(Path.Combine("Xml", "FsaMessage.xml"));
        static string fsaRecord = File.ReadAllText(Path.Combine("Xml", "FsaRecord.xml"));

        static FgisRecord GetFgisRecord()
        {
            var singleMi = new SingleMi
            {
                MiTypeNumber = "12345-67",
                ManufactureNum = "987654321A09",
                ManufactureYear = 2023,
                Modification = Modification
            };
            var miInfo = new MiInfo { SingleMi = singleMi };
            var applicable = new Applicable
            {
                SignPass = false,
                SignMi = true
            };
            var mieta = new Mieta { Number = "12345.67.8A.90123456" };
            var means = new Means { Mieta = mieta };
            var conditions = new Conditions
            {
                Temperature = "23°C",
                Pressure = "744 mm",
                Humidity = "67%"
            };
            var record = new FgisRecord
            {
                MiInfo = miInfo,
                SignCipher = "EFG",
                MiOwner = "BigTech, Inc.",
                VrfDateString = VrfDateString,
                ValidDateString = "2025-07-16+07:00",
                Type = 1,
                Calibration = false,
                Applicable = applicable,
                DocTitle = "HI1234-56 (JKL 7890-1234)",
                Metrologist = "LastName FirstName",
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
                CertNum = "A-BCD/12-34-2023/456789012"
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
                    Last = "LastName",
                    First = "FirstName"
                },
                Snils = "5555"
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
