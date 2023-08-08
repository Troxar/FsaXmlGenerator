using System.Xml.Serialization;

namespace FgisApplicationReaderLib.Models
{
    [XmlRoot("application")]
    public record class FgisApplication
    {
        [XmlElement("result")]
        public FgisRecord[] FgisRecords { get; init; }
    }
}
