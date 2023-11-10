using Contracts;
using FsaMessageDomain;
using FsaMessageProviderLib;
using Moq;

namespace FsaMessageProviderTests
{
    public class FsaMessageProviderTests
    {
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void FsaMessageProvider_CreatesMessageWithCorrectRecords(int count)
        {
            var appRecordsProvider = GetFgisApplicationRecordsProvider(count);
            var protocolRecordsProvider = GetFgisProtocolRecordsProvider(count);
            var provider = new FsaMessageProvider(appRecordsProvider,
                protocolRecordsProvider, new[] { SamplesProvider.GetApprovedEmployee() });
            var message = provider.CreateMessage();
            var expected = SamplesProvider.GetFsaMessage(count);

            Assert.Equal(expected.SaveMethod, message.SaveMethod);
            Assert.Equal(expected.VerificationData.VerificationRecords, message.VerificationData.VerificationRecords);
        }

        [Theory]
        [InlineData(0, 1)]
        [InlineData(1, 0)]
        [InlineData(1, 2)]
        [InlineData(2, 1)]
        public void FsaMessageProvider_ThrowsRecordsMismatch(int appCount, int protocolCount)
        {
            var appRecordsProvider = GetFgisApplicationRecordsProvider(appCount);
            var protocolRecordsProvider = GetFgisProtocolRecordsProvider(protocolCount);
            var provider = new FsaMessageProvider(appRecordsProvider,
                protocolRecordsProvider, new[] { SamplesProvider.GetApprovedEmployee() });

            Assert.Throws<RecordsMismatchException>(() => provider.CreateMessage());
        }

        IFgisApplicationRecordsProvider GetFgisApplicationRecordsProvider(int count)
        {
            var mock = new Mock<IFgisApplicationRecordsProvider>();
            mock.Setup(x => x.Records).Returns(SamplesProvider.GetFgisApplication(count).FgisRecords);
            return mock.Object;
        }

        IFgisProtocolRecordsProvider GetFgisProtocolRecordsProvider(int count)
        {
            var mock = new Mock<IFgisProtocolRecordsProvider>();
            mock.Setup(x => x.Records).Returns(SamplesProvider.GetFgisProtocol(count).AppProcessed.ProtocolRecords);
            return mock.Object;
        }

        [Theory]
        [InlineData("")]
        [InlineData("LastName1")]
        public void GetApprovedEmployee_ThrowsFormatException(string fullName)
        {
            var appRecordsProvider = GetFgisApplicationRecordsProvider(0);
            var protocolRecordsProvider = GetFgisProtocolRecordsProvider(0);
            var provider = new FsaMessageProvider(appRecordsProvider,
                protocolRecordsProvider, GetEmployees());

            Assert.Throws<FormatException>(() => provider.GetApprovedEmployee(fullName));
        }

        [Theory]
        [InlineData("FistName2 LastName2")]
        [InlineData("LastName3 FirstName1")]
        public void GetApprovedEmployee_ThrowsEmployeeNotFoundException(string fullName)
        {
            var appRecordsProvider = GetFgisApplicationRecordsProvider(0);
            var protocolRecordsProvider = GetFgisProtocolRecordsProvider(0);
            var provider = new FsaMessageProvider(appRecordsProvider,
                protocolRecordsProvider, GetEmployees());

            Assert.Throws<EmployeeNotFoundException>(() => provider.GetApprovedEmployee(fullName));
        }

        [Theory]
        [InlineData("LastName1 FirstName1")]
        [InlineData("LastName3 FirstName3")]
        [InlineData("LastName3 FirstName3 MiddleName3")]
        public void GetApprovedEmployee_ReturnsEmployee(string fullName)
        {
            var appRecordsProvider = GetFgisApplicationRecordsProvider(0);
            var protocolRecordsProvider = GetFgisProtocolRecordsProvider(0);
            var provider = new FsaMessageProvider(appRecordsProvider,
                protocolRecordsProvider, GetEmployees());
            var employee = provider.GetApprovedEmployee(fullName);

            var pieces = fullName.Split(' ');
            Assert.Equal(employee.Name.Last, pieces[0]);
            Assert.Equal(employee.Name.First, pieces[1]);
        }

        ApprovedEmployee[] GetEmployees()
        {
            return new[]
                {
                new ApprovedEmployee {
                        Name = new EmployeeName { Last = "LastName1", First = "FirstName1" },
                        Snils = "5555"
                    },
                new ApprovedEmployee {
                        Name = new EmployeeName { Last = "LastName2", First = "FirstName2" },
                        Snils = "9999"
                    },
                new ApprovedEmployee {
                        Name = new EmployeeName { Last = "LastName3", First = "FirstName3" },
                        Snils = "2222"
                    },
                };
        }
    }
}
