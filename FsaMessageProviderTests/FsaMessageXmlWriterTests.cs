using FsaMessageGeneratorLib;
using System.Text.RegularExpressions;

namespace FsaMessageProviderTests
{
    public class FsaMessageXmlWriterTests
    {
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void FsaMessageXmlWriter_CorrectFile(int count)
        {
            var message = SamplesProvider.GetFsaMessage(count);
            var path = Path.GetTempFileName();
            FsaMessageXmlWriter.Write(message, path);

            var expected = RemoveSpecialCharacters(SamplesProvider.GetFsaMessageXml(count));
            var actual = RemoveSpecialCharacters(File.ReadAllText(path));

            Assert.Equal(expected, actual);
        }

        string RemoveSpecialCharacters(string line) => new Regex("[\n\r\t ]").Replace(line, string.Empty);
    }
}
