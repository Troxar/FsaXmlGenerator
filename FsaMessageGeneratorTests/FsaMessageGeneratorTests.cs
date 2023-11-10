using FsaMessageDomain;
using FsaMessageGeneratorLib;
using System.Text.RegularExpressions;

namespace FsaMessageGeneratorTests
{
    public class FsaMessageGeneratorTests
    {
        [Fact]
        public void FsaMessageGenerator_CreatesMessage()
        {
            var config = new Config(
                FgisApplicationPath: Path.Combine("Xml", "FgisApplication.xml"),
                FgisProtocolPath: Path.Combine("Xml", "FgisProtocol.xml"),
                FsaMessagePath: Path.GetTempFileName(),
                Employees: new[] {
                    new ApprovedEmployee {
                        Name = new EmployeeName { Last = "LastName", First = "FirstName" },
                        Snils = "9999"
                    }
                });
            var generator = new FsaMessageGenerator(config);
            generator.CreateMessage();

            var expectedPath = Path.Combine("Xml", "FsaMessage.xml");
            var expected = RemoveSpecialCharacters(File.ReadAllText(expectedPath));
            var actual = RemoveSpecialCharacters(File.ReadAllText(config.FsaMessagePath));

            Assert.Equal(expected, actual);
        }

        string RemoveSpecialCharacters(string line) => new Regex("[\n\r\t ]").Replace(line, string.Empty);
    }
}
