using System.Xml.Serialization;

namespace FgisApplicationReaderLib.Models
{
    public record class Mieta
    {
        [XmlElement("number")]
        public string Number { get; init; }
    }
}
