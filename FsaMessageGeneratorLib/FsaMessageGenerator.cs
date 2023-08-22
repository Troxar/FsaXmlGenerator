using FgisApplicationRecordsProvider;
using FgisProtocolRecordsProvider;
using FsaMessageDomain;
using FsaMessageProviderLib;
using Newtonsoft.Json;

namespace FsaMessageGeneratorLib
{
    public class FsaMessageGenerator
    {
        readonly string _fgisApplicationPath;
        readonly string _fgisProtocolPath;
        readonly string _fsaMessagePath;
        readonly ApprovedEmployee[] _employees;

        public FsaMessageGenerator(string configPath = "config.json")
        {
            var config = ReadConfig(configPath);
            _fgisApplicationPath = config.FgisApplicationPath;
            _fgisProtocolPath = config.FgisProtocolPath;
            _fsaMessagePath = config.FsaMessagePath;
            _employees = config.Employees;
        }

        public FsaMessageGenerator(string fgisApplicationPath, string fgisProtocolPath, string fsaMessagePath, ApprovedEmployee[] employees)
        {
            _fgisApplicationPath = fgisApplicationPath;
            _fgisProtocolPath = fgisProtocolPath;
            _fsaMessagePath = fsaMessagePath;
            _employees = employees;
        }

        public void CreateMessage()
        {
            var appRecordsProvider = new XmlFgisApplicationRecordsProvider(_fgisApplicationPath);
            var protocolRecordsProvider = new XmlFgisProtocolRecordsProvider(_fgisProtocolPath);
            var messageProvider = new FsaMessageProvider(appRecordsProvider, protocolRecordsProvider, _employees);
            var message = messageProvider.CreateMessage();
            FsaMessageXmlWriter.Write(message, _fsaMessagePath);
        }

        internal static Config ReadConfig(string path)
        {
            using (var reader = new StreamReader(path))
            {
                return JsonConvert.DeserializeObject<Config>(reader.ReadToEnd());
            }
        }
    }
}
