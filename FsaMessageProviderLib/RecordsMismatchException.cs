using System.Runtime.Serialization;

namespace FsaMessageProviderLib
{
    [Serializable]
    public class RecordsMismatchException : ApplicationException
    {
        public RecordsMismatchException()
        {
        }

        public RecordsMismatchException(string? message) : base(message)
        {
        }

        public RecordsMismatchException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected RecordsMismatchException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
