using FgisProtocolDomain;

namespace FsaMessageGeneratorLib
{
    public interface IFgisProtocolRecordsProvider
    {
        IEnumerable<FgisProtocolRecord> Records { get; }
    }
}
