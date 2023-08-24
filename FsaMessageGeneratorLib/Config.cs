using FsaMessageDomain;

namespace FsaMessageGeneratorLib
{
    public record class Config(
        string FgisApplicationPath,
        string FgisProtocolPath, 
        string FsaMessagePath, 
        ApprovedEmployee[] Employees
    );
}
