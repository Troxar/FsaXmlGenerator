using FgisApplicationRecordsProvider;
using FgisProtocolRecordsProvider;

namespace FsaMessageGeneratorLib
{
    public class FsaMessageGenerator
    {
        readonly string _appRecordsPath;
        readonly string _protocolPath;

        public FsaMessageGenerator(string appRecordsPath, string protocolPath)
        {
            _appRecordsPath = appRecordsPath;
            _protocolPath = protocolPath;
        }

        public void Generate()
        {
            IFgisApplicationRecordsProvider appRecordsProvider = new XmlFgisApplicationRecordsProvider(_appRecordsPath);
            IFgisProtocolRecordsProvider protocolProvider = new XmlFgisProtocolRecordsProvider(_protocolPath);
        }
    }
}