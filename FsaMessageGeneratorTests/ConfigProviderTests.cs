using FsaMessageDomain;
using FsaMessageGeneratorLib;

namespace FsaMessageGeneratorTests
{
    public class ConfigProviderTests
    {
        [Fact]
        public void FsaMessageGenerator_CanGetConfig()
        {
            var configPath = Path.Combine("Json", "config.json");
            var config = ConfigProvider.GetConfig(configPath);

            Assert.NotNull(config);
            Assert.Equal("app_path", config!.FgisApplicationPath);
            Assert.Equal("protocol_path", config!.FgisProtocolPath);
            Assert.Equal("message_path", config!.FsaMessagePath);
            Assert.Single(config!.Employees);
            Assert.Equal(new ApprovedEmployee
            {
                Name = new EmployeeName { Last = "last_name", First = "first_name" },
                Snils = "snils_number"
            }, config.Employees.First());
        }
    }
}
