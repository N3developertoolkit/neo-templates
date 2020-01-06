using Neo.SmartContract.Framework;
using Neo.SmartContract.Framework.Services.Neo;

// [assembly: ContractTitle("optional contract title")]
// [assembly: ContractDescription("optional contract description")]
// [assembly: ContractVersion("optional contract version")]
// [assembly: ContractAuthor("optional contract author")]
// [assembly: ContractEmail("optional contract email")]
[assembly: Features(ContractPropertyState.HasStorage)]

public class SmartContract1 : SmartContract
{
    public static void Main()
    {
        Storage.Put(Storage.CurrentContext, "Hello", "World");
    }
}
