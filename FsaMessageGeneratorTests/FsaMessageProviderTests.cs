using FsaMessageGeneratorLib;
using Moq;

namespace FsaMessageGeneratorTests
{
    public class FsaMessageProviderTests
    {
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void FsaMessageGenerator_CreatesMessageWithCorrectRecords(int count)
        {
            var appRecordsProvider = GetFgisApplicationRecordsProvider(count);
            var protocolRecordsProvider = GetFgisProtocolRecordsProvider(count);
            var generator = new FsaMessageProvider(appRecordsProvider,
                protocolRecordsProvider, SamplesProvider.GetApprovedEmployee());
            var message = generator.CreateMessage();
            var expected = SamplesProvider.GetFsaMessage(count);

            Assert.Equal(expected.SaveMethod, message.SaveMethod);
            Assert.Equal(expected.VerificationData.VerificationRecords, message.VerificationData.VerificationRecords);
        }

        [Theory]
        [InlineData(0, 1)]
        [InlineData(1, 0)]
        [InlineData(1, 2)]
        [InlineData(2, 1)]
        public void FsaMessageGenerator_ThrowsRecordsMismatch(int appCount, int protocolCount)
        {
            var appRecordsProvider = GetFgisApplicationRecordsProvider(appCount);
            var protocolRecordsProvider = GetFgisProtocolRecordsProvider(protocolCount);
            var generator = new FsaMessageProvider(appRecordsProvider,
                protocolRecordsProvider, SamplesProvider.GetApprovedEmployee());
            
            Assert.Throws<RecordsMismatchException>(() => generator.CreateMessage());
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
    }
}
