using FsaMessageDomain;

namespace FsaMessageGeneratorLib
{
    record class Config(
        string FgisApplicationPath,
        string FgisProtocolPath, 
        string FsaMessagePath, 
        ApprovedEmployee[] Employees
    );
}
