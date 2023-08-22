using System.Text;
using System.Xml;

namespace FsaMessageGeneratorLib
{
    internal class FullEndElementXmlTextWriter : XmlTextWriter
    {
        public FullEndElementXmlTextWriter(Stream stream) 
            : base(stream, Encoding.UTF8) 
        {

        }

        public override void WriteEndElement()
        {
            base.WriteFullEndElement();
        }
    }
}
