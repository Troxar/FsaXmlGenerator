using FgisProtocolDomain;
using System.Xml.Serialization;

namespace FgisProtocolRecordsProvider
{
    public class XmlFgisProtocolRecordsProvider : IFgisProtocolRecordsProvider
    {
        readonly string _path;

        public XmlFgisProtocolRecordsProvider(string path)
        {
            _path = path;
        }

        public IEnumerable<FgisProtocolRecord> Records
        {
            get
            {
                using (var stream = new FileStream(_path, FileMode.Open))
                {
                    var serializer = new XmlSerializer(typeof(FgisProtocol));
                    var protocol = serializer.Deserialize(stream) as FgisProtocol;
                    return protocol?.AppProcessed.ProtocolRecords ?? Enumerable.Empty<FgisProtocolRecord>();
                }
            }
        }
    }
}
