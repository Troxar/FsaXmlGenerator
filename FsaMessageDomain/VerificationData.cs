using System.Xml.Serialization;

namespace FsaMessageDomain
{
    public record class VerificationData
    {
        [XmlElement("VerificationMeasuringInstrument")]
        public FsaVerificationRecord[] VerificationRecords { get; init; }
    }
}
