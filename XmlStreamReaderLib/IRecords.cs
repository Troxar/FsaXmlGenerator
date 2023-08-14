namespace XmlStreamReaderLib
{
    public interface IRecords<TRecord>
    {
        IEnumerable<TRecord> Records { get; }
    }
}
