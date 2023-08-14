using System.Xml.Serialization;
using XmlStreamReaderLib;

namespace XmlStreamReaderTests
{
    public class XmlStreamReaderTests
    {
        [Fact]
        public void XmlStreamReader_ContainerHasNoRecords()
        {
            var path = Path.Combine("Xml", "EmptyContainer.xml");
            using (var stream = new FileStream(path, FileMode.Open))
            using (var reader = new XmlStreamReader<Root, Record>(stream))
            {
                Assert.Empty(reader.Records());
            }
        }

        [Fact]
        public void XmlStreamReader_ContainerContainsRecords()
        {
            var path = Path.Combine("Xml", "FilledContainer.xml");
            using (var stream = new FileStream(path, FileMode.Open))
            using (var reader = new XmlStreamReader<Root, Record>(stream))
            {
                var records = reader.Records().ToArray();
                Assert.Equal(2, records.Length);
                Assert.Equal("1", records[0].Id);
                Assert.Equal("222", records[1].Id);
            }
        }

        [XmlRoot("container")]
        public record class Root : IRecords<Record>
        {
            [XmlElement("item")]
            public Record[] Records { get; init; }

            IEnumerable<Record> IRecords<Record>.Records => Records;
        }

        public record class Record
        {
            [XmlElement("id")]
            public string Id { get; init; }
        }
    }
}
