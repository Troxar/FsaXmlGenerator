using FgisProtocolDomain;

namespace FgisProtocolRecordsProvider
{
    public interface IFgisProtocolRecordsProvider
    {
        IEnumerable<FgisProtocolRecord> Records { get; }
    }
}
