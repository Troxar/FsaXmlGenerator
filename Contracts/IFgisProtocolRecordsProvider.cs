using FgisProtocolDomain;

namespace Contracts
{
    public interface IFgisProtocolRecordsProvider
    {
        IEnumerable<FgisProtocolRecord> Records { get; }
    }
}
