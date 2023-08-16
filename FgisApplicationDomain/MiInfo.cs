using System.Xml.Serialization;

namespace FgisApplicationDomain
{
    public record class MiInfo
    {
        [XmlElement("singleMI")]
        public SingleMi SingleMi { get; init; }
    }
}
