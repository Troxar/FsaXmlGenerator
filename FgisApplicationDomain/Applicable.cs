using System.Xml.Serialization;

namespace FgisApplicationDomain
{
    public record class Applicable
    {
        [XmlElement("signPass")]
        public bool SignPass { get; init; }

        [XmlElement("signMi")]
        public bool SignMi { get; init; }
    }
}
