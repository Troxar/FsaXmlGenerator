using System.Xml.Serialization;

namespace FsaMessageDomain
{
    [XmlRoot("Message")]
    public record class FsaMessage
    {
        [XmlElement("VerificationMeasuringInstrumentData")]
        public VerificationData VerificationData { get; init; }

        [XmlElement("SaveMethod")]
        public int SaveMethod { get; init; }
    }
}
