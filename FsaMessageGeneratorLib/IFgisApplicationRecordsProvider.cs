using FgisApplicationDomain;

namespace FsaMessageGeneratorLib
{
    public interface IFgisApplicationRecordsProvider
    {
        IEnumerable<FgisRecord> Records { get; }
    }
}
