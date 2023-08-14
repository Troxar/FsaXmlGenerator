using System.Xml.Serialization;

namespace XmlStreamReaderLib
{
    public class XmlStreamReader<TRoot, TRecord> : IDisposable
        where TRoot: class, IRecords<TRecord>
    {
        readonly Stream _stream;

        public XmlStreamReader(Stream stream)
        {
            _stream = stream;
        }

        public void Dispose()
        {
            _stream.Dispose();
        }

        public IEnumerable<TRecord> Records()
        {
            var serializer = new XmlSerializer(typeof(TRoot));
            var app = serializer.Deserialize(_stream) as TRoot;
            return app?.Records ?? Enumerable.Empty<TRecord>();
        }
    }
}
