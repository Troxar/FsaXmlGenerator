using System.Xml.Serialization;

namespace FgisApplicationReaderLib.Models
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
