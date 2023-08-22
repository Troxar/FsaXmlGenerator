using FsaMessageDomain;
using System.Xml.Serialization;

namespace FsaMessageGeneratorLib
{
    public static class FsaMessageXmlWriter
    {
        public static void Write(FsaMessage message, string path)
        {
            using (var stream = new FileStream(path, FileMode.Create))
            {
                var serializer = new XmlSerializer(typeof(FsaMessage));
                var writer = new FullEndElementXmlTextWriter(stream);

                var namespaces = new XmlSerializerNamespaces();
                namespaces.Add("xsi", "http://www.w3.org/2001/XMLSchema-instance");

                serializer.Serialize(writer, message, namespaces);
            }
        }
    }
}
