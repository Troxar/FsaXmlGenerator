using System.Xml.Serialization;

namespace FsaMessageDomain
{
    public record class ApprovedEmployee
    {
        [XmlElement("Name")]
        public EmployeeName Name { get; init; }

        [XmlElement("SNILS")]
        public string Snils { get; init; }
    }
}
