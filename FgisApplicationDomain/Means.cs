using System.Xml.Serialization;

namespace FgisApplicationDomain
{
    public record class Means
    {
        [XmlElement("mieta")]
        public Mieta Mieta { get; init; }
    }
}
