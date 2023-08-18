using FgisApplicationDomain;
using FgisProtocolDomain;
using FsaMessageDomain;

namespace FsaMessageGeneratorLib
{
    public class FsaMessageProvider
    {
        readonly IFgisApplicationRecordsProvider _appRecordsProvider;
        readonly IFgisProtocolRecordsProvider _protocolRecordsProvider;
        readonly ApprovedEmployee _approvedEmployee;

        public FsaMessageProvider(IFgisApplicationRecordsProvider appRecordsProvider,
            IFgisProtocolRecordsProvider protocolRecordsProvider,
            ApprovedEmployee approvedEmployee)
        {
            _appRecordsProvider = appRecordsProvider;
            _protocolRecordsProvider = protocolRecordsProvider;
            _approvedEmployee = approvedEmployee;
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
                    ApprovedEmployee = _approvedEmployee,
                    ResultVerification = 1
                };
        }
    }
}
