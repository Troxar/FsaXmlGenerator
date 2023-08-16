using System.Xml.Serialization;

namespace FgisProtocolDomain
{
    public record class FgisProtocolRecord
    {
        [XmlElement("success")]
        public Success Success { get; init; }
    }
}
