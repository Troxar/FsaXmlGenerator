using System.Xml.Serialization;

namespace FgisProtocolDomain
{
    public record class AppProcessed
    {
        [XmlElement("record")]
        public FgisProtocolRecord[] ProtocolRecords { get; init; }
    }
}