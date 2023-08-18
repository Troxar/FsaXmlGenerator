using System.Xml.Serialization;

namespace FsaMessageDomain
{
    public record class EmployeeName
    {
        [XmlElement("Last")]
        public string Last { get; init; }

        [XmlElement("First")]
        public string First { get; init; }
    }
}
