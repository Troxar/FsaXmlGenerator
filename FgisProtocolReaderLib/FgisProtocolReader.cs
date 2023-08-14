using FgisProtocolReaderLib.Models;
using XmlStreamReaderLib;

namespace FgisProtocolReaderLib
{
    public class FgisProtocolReader
    {
        readonly string _path;

        public FgisProtocolReader(string path)
        {
            _path = CheckFileExists(path);
        }

        string CheckFileExists(string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException(path);
            return path;
        }

        public IEnumerable<ProtocolRecord> Records()
        {
            using (var stream = new FileStream(_path, FileMode.Open))
            using (var reader = new XmlStreamReader<Protocol, ProtocolRecord>(stream))
            {
                return reader.Records();
            }
        }
    }
}
