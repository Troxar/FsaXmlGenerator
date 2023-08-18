namespace FsaMessageGeneratorLib
{
    public class RecordsMismatchException : ApplicationException
    {
        internal RecordsMismatchException() { }

        internal RecordsMismatchException(string? message) : base(message) { }

        public RecordsMismatchException(string? message, Exception? innerException)
            : base(message, innerException) { }
    }
}
