using System.Xml.Serialization;

namespace FgisApplicationDomain
{
    public record class FgisRecord
    {
        [XmlElement("miInfo")]
        public MiInfo MiInfo { get; init; }

        [XmlElement("signCipher")]
        public string SignCipher { get; init; }

        [XmlElement("miOwner")]
        public string MiOwner { get; init; }

        [XmlIgnore]
        public DateTime VrfDate { get; private set; }

        [XmlElement("vrfDate")]
        public string VrfDateString
        {
            get { return VrfDate.ToString("yyyy-MM-ddzzz"); } 
            set { VrfDate = DateTime.Parse(value); } 
        }

        [XmlIgnore]
        public DateTime ValidDate { get; private set; }

        [XmlElement("validDate")]
        public string ValidDateString
        {
            get { return ValidDate.ToString("yyyy-MM-ddzzz"); }
            set { ValidDate = DateTime.Parse(value); }
        }

        [XmlElement("type")]
        public int Type { get; init; }

        [XmlElement("calibration")]
        public bool Calibration { get; init; }

        [XmlElement("applicable")]
        public Applicable Applicable { get; init; }

        [XmlElement("docTitle")]
        public string DocTitle { get; init; }

        [XmlElement("metrologist")]
        public string Metrologist { get; init; }

        [XmlElement("means")]
        public Means Means { get; init; }

        [XmlElement("conditions")]
        public Conditions Conditions { get; init; }

        [XmlElement("structure")]
        public string Structure { get; init; }
    }
}
