using FgisApplicationDomain;

namespace FgisApplicationRecordsProvider
{
    public interface IFgisApplicationRecordsProvider
    {
        IEnumerable<FgisRecord> Records { get; }
    }
}
