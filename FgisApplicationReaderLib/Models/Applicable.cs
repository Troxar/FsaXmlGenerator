using System.Xml.Serialization;

namespace FgisApplicationReaderLib.Models
{
    public record class Applicable
    {
        [XmlElement("signPass")]
        public bool SignPass { get; init; }

        [XmlElement("signMi")]
        public bool SignMi { get; init; }
    }
}
