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
            var applicationPath = Path.Combine("Xml", "FgisApplication.xml");
            var protocolPath = Path.Combine("Xml", "FgisProtocol.xml");
            var expectedPath = Path.Combine("Xml", "FsaMessage.xml");
            var actualPath = Path.GetTempFileName();
            var generator = new FsaMessageGenerator(
                applicationPath,
                protocolPath,
                actualPath,
                new[] { 
                    new ApprovedEmployee { 
                        Name = new EmployeeName { Last = "Мартюшев", First = "Роман" }, 
                        Snils = "9999" 
                    }
                });
            generator.CreateMessage();

            var expected = RemoveSpecialCharacters(File.ReadAllText(expectedPath));
            var actual = RemoveSpecialCharacters(File.ReadAllText(actualPath));

            Assert.Equal(expected, actual);
        }

        string RemoveSpecialCharacters(string line) => new Regex("[\n\r\t ]").Replace(line, string.Empty);

        [Fact]
        public void FsaMessageGenerator_CanReadConfig()
        {
            var configPath = Path.Combine("Json", "config.json");
            var config = FsaMessageGenerator.ReadConfig(configPath);

            Assert.NotNull(config);
            Assert.Equal("app_path", config.FgisApplicationPath);
            Assert.Equal("protocol_path", config.FgisProtocolPath);
            Assert.Equal("message_path", config.FsaMessagePath);
            Assert.Single(config.Employees);
            Assert.Equal(new ApprovedEmployee
            {
                Name = new EmployeeName { Last = "last_name", First = "first_name" },
                Snils = "snils_number"
            }, config.Employees.First());
        }
    }
}
