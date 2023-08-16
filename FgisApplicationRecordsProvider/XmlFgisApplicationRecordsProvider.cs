using FgisApplicationDomain;
using System.Xml.Serialization;

namespace FgisApplicationRecordsProvider
{
    public class XmlFgisApplicationRecordsProvider : IFgisApplicationRecordsProvider
    {
        readonly string _path;

        public XmlFgisApplicationRecordsProvider(string path)
        {
            _path = path;
        }

        public IEnumerable<FgisRecord> Records
        {
            get
            {
                using (var stream = new FileStream(_path, FileMode.Open))
                {
                    var serializer = new XmlSerializer(typeof(FgisApplication));
                    var app = serializer.Deserialize(stream) as FgisApplication;
                    return app?.FgisRecords ?? Enumerable.Empty<FgisRecord>();
                }
            }
        }
    }
}
