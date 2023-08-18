using FsaMessageDomain;
using System.Xml.Serialization;

namespace FsaMessageGeneratorLib
{
    public class FsaMessageXmlWriter
    {
        readonly FsaMessage _fsaMessage;
        readonly string _path;
        
        public FsaMessageXmlWriter(FsaMessage fsaMessage, string path)
        {
            _fsaMessage = fsaMessage;
            _path = path;
        }

        public void Write()
        {
            using (var stream = new FileStream(_path, FileMode.Create))
            {
                var serializer = new XmlSerializer(typeof(FsaMessage));
                var writer = new FullEndElementXmlTextWriter(stream);

                var namespaces = new XmlSerializerNamespaces();
                namespaces.Add("xsi", "http://www.w3.org/2001/XMLSchema-instance");

                serializer.Serialize(writer, _fsaMessage, namespaces);
            }
        }
    }
}
