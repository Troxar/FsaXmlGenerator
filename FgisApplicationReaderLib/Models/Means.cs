using System.Xml.Serialization;

namespace FgisApplicationReaderLib.Models
{
    public record class Means
    {
        [XmlElement("mieta")]
        public Mieta Mieta { get; init; }
    }
}
