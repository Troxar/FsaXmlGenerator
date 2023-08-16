using System.Xml.Serialization;

namespace FgisApplicationDomain
{
    public record class Mieta
    {
        [XmlElement("number")]
        public string Number { get; init; }
    }
}
