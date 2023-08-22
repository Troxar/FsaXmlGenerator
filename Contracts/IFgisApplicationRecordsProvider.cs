using FgisApplicationDomain;

namespace Contracts
{
    public interface IFgisApplicationRecordsProvider
    {
        IEnumerable<FgisRecord> Records { get; }
    }
}
