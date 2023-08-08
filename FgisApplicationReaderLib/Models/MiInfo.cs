using System.Xml.Serialization;

namespace FgisApplicationReaderLib.Models
{
    public record class MiInfo
    {
        [XmlElement("singleMI")]
        public SingleMi SingleMi { get; init; }
    }
}
