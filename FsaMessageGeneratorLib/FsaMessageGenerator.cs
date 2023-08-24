using FgisApplicationRecordsProvider;
using FgisProtocolRecordsProvider;
using FsaMessageProviderLib;

namespace FsaMessageGeneratorLib
{
    public class FsaMessageGenerator
    {
        readonly Config _config;

        public FsaMessageGenerator(Config config)
        {
            _config = config;
        }

        public void CreateMessage()
        {
            var appRecordsProvider = new XmlFgisApplicationRecordsProvider(_config.FgisApplicationPath);
            var protocolRecordsProvider = new XmlFgisProtocolRecordsProvider(_config.FgisProtocolPath);
            var messageProvider = new FsaMessageProvider(appRecordsProvider, protocolRecordsProvider, _config.Employees);
            var message = messageProvider.CreateMessage();
            FsaMessageXmlWriter.Write(message, _config.FsaMessagePath);
        }
    }
}
