using FgisApplicationReaderLib.Models;
using System.Xml.Serialization;

namespace FgisApplicationReaderLib
{
    internal class FgisApplicationStreamReader : IDisposable
    {
        readonly Stream _stream;

        internal FgisApplicationStreamReader(Stream stream)
        {
            _stream = stream;
        }

        public void Dispose()
        {
            _stream.Dispose();
        }

        internal IEnumerable<FgisRecord> Records()
        {
            var serializer = new XmlSerializer(typeof(FgisApplication));
            var app = serializer.Deserialize(_stream) as FgisApplication;
            return app?.FgisRecords?.AsEnumerable() ?? Enumerable.Empty<FgisRecord>();
        }
    }
}
