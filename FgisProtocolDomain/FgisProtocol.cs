using System.Xml.Serialization;

namespace FgisProtocolDomain
{
    [XmlRoot("protocol", Namespace = "urn://fgis-arshin.gost.ru/module-verifications/protocol/2020-06-19")]
    public record class FgisProtocol
    {
        [XmlIgnore]
        public DateTime StartProcessing { get; private set; }

        [XmlElement("startProcessing")]
        public string StartProcessingString
        {
            get { return StartProcessing.ToString("yyyy-MM-ddzzz"); }
            set { StartProcessing = DateTime.Parse(value); }
        }

        [XmlIgnore]
        public DateTime FinishProcessing { get; private set; }

        [XmlElement("finishProcessing")]
        public string FinishProcessingString
        {
            get { return FinishProcessing.ToString("yyyy-MM-ddzzz"); }
            set { FinishProcessing = DateTime.Parse(value); }
        }

        [XmlElement("appProcessed")]
        public AppProcessed AppProcessed { get; init; }
    }
}
