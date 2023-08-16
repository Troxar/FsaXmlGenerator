using System.Xml.Serialization;

namespace FgisProtocolDomain
{
    public record class Success
    {
        [XmlElement("globalID")]
        public int GlobalId { get; init; }

        [XmlElement("certNum")]
        public string CertNum { get; init; }
    }
}
