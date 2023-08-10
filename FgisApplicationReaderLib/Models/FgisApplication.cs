using System.Xml.Serialization;

namespace FgisApplicationReaderLib.Models
{
    [XmlRoot("application", Namespace = "urn://fgis-arshin.gost.ru/module-verifications/import/2020-06-19")]
    public record class FgisApplication
    {
        [XmlElement("result")]
        public FgisRecord[] FgisRecords { get; init; }
    }
}
