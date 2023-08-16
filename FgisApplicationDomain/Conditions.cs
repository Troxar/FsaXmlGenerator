using System.Xml.Serialization;

namespace FgisApplicationDomain
{
    public record class Conditions
    {
        [XmlElement("temperature")]
        public string Temperature { get; init; }

        [XmlElement("pressure")]
        public string Pressure { get; init; }

        [XmlElement("hymidity")]
        public string Humidity { get; init; }
    }
}
