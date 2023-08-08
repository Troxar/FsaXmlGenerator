using System.Xml.Serialization;

namespace FgisApplicationReaderLib.Models
{
    public record class SingleMi
    {
        [XmlElement("mitypeNumber")]
        public string MiTypeNumber { get; init; }

        [XmlElement("manufactureNum")]
        public string ManufactureNum { get; init; }

        [XmlElement("manufactureYear")]
        public int ManufactureYear { get; init; }

        [XmlElement("modification")]
        public string Modification { get; init; }
    }
}
