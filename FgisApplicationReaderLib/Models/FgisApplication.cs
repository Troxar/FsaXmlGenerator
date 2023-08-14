using System.Xml.Serialization;
using XmlStreamReaderLib;

namespace FgisApplicationReaderLib.Models
{
    [XmlRoot("application", Namespace = "urn://fgis-arshin.gost.ru/module-verifications/import/2020-06-19")]
    public record class FgisApplication : IRecords<FgisRecord>
    {
        [XmlElement("result")]
        public FgisRecord[] FgisRecords { get; init; }

        public IEnumerable<FgisRecord> Records => FgisRecords;
    }
}
