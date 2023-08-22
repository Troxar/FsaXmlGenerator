using FsaMessageDomain;

namespace Contracts
{
    public interface IFsaMessageProvider
    {
        FsaMessage CreateMessage();
    }
}
