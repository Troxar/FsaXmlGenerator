using Contracts;
using FgisApplicationDomain;
using FgisProtocolDomain;
using FsaMessageDomain;

namespace FsaMessageProviderLib
{
    public class FsaMessageProvider : IFsaMessageProvider
    {
        readonly IFgisApplicationRecordsProvider _appRecordsProvider;
        readonly IFgisProtocolRecordsProvider _protocolRecordsProvider;
        readonly ApprovedEmployee[] _employees;

        public FsaMessageProvider(IFgisApplicationRecordsProvider appRecordsProvider,
            IFgisProtocolRecordsProvider protocolRecordsProvider,
            ApprovedEmployee[] employees)
        {
            _appRecordsProvider = appRecordsProvider;
            _protocolRecordsProvider = protocolRecordsProvider;
            _employees = employees;
        }

        public FsaMessage CreateMessage()
        {
            if (_appRecordsProvider.Records.Count() != _protocolRecordsProvider.Records.Count())
                throw new RecordsMismatchException("Counts of application and protocol records are not equal");

            var vrfRecords = _appRecordsProvider.Records
                .Zip(_protocolRecordsProvider.Records, CreateVerificationRecord)
                .ToArray();
            var fsaMessage = new FsaMessage
            {
                VerificationData = new VerificationData { VerificationRecords = vrfRecords },
                SaveMethod = 1
            };

            return fsaMessage;
        }

        FsaVerificationRecord CreateVerificationRecord(FgisRecord appRecord, FgisProtocolRecord protocolRecord)
        {
            return new FsaVerificationRecord
                {
                    NumberVerification = protocolRecord.Success.GlobalId,
                    DateVerificationString = appRecord.VrfDateString,
                    TypeMeasuringInstrument = appRecord.MiInfo.SingleMi.Modification,
                    ApprovedEmployee = GetApprovedEmployee(appRecord.Metrologist),
                    ResultVerification = 1
                };
        }

        internal ApprovedEmployee GetApprovedEmployee(string fullName)
        {
            var pieces = fullName.Split(' ');
            if (pieces.Length < 2)
                throw new FormatException(fullName);

            var employee =_employees.FirstOrDefault(e => e.Name.Last == pieces[0] && e.Name.First == pieces[1]);
            if (employee is null)
                throw new EmployeeNotFoundException($"{pieces[0]} {pieces[1]}");

            return employee;
        }
    }
}
