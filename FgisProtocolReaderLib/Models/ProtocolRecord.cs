using System.Xml.Serialization;

namespace FgisProtocolReaderLib.Models
{
    public record class ProtocolRecord
    {
        [XmlAttribute("corrId")]
        public int CorrId { get; init; }

        [XmlElement("success")]
        public Success Success { get; init; }
    }
}
