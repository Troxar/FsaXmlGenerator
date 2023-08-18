using System.Xml.Serialization;

namespace FsaMessageDomain
{
    public record class FsaVerificationRecord
    {
        [XmlElement("NumberVerification")]
        public int NumberVerification { get; init; }

        [XmlIgnore]
        public DateTime DateVerification { get; private set; }

        [XmlElement("DateVerification")]
        public string DateVerificationString
        {
            get { return DateVerification.ToString("yyyy-MM-dd"); }
            set { DateVerification = DateTime.Parse(value); }
        }

        [XmlElement("TypeMeasuringInstrument")]
        public string TypeMeasuringInstrument { get; init; }

        [XmlElement("ApprovedEmployee")]
        public ApprovedEmployee ApprovedEmployee { get; init; }

        [XmlElement("ResultVerification")]
        public int ResultVerification { get; init; }
    }
}
