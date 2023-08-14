using System.Xml.Serialization;
using XmlStreamReaderLib;

namespace FgisProtocolReaderLib.Models
{
    [XmlRoot("protocol", Namespace = "urn://fgis-arshin.gost.ru/module-verifications/protocol/2020-06-19")]
    public record class Protocol : IRecords<ProtocolRecord>
    {
        [XmlElement("startProcessing")]
        public DateTime StartProcessing { get; init; }

        [XmlElement("finishProcessing")]
        public DateTime FinishProcessing { get; init; }

        [XmlElement("appProcessed")]
        public ProtocolRecord[] ProtocolRecords { get; init; }

        public IEnumerable<ProtocolRecord> Records => ProtocolRecords;
    }
}
