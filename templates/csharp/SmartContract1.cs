using System.ComponentModel;

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
    public static object Main(string method, object[] args)
    {
        if (method == "putValue") 
        {
            return PutValue(args[0] as byte[]);
        } 
        else if (method == "getValue")
        {
            return GetValue();
        }
        else if (method == "contractMigrate")
        {
            return ContractMigrate(
                (byte[]) args[0],
                (byte[]) args[1],
                (byte) args[2],
                (byte) args[3],
                (string) args[4],
                (string) args[5],
                (string) args[6],
                (string) args[7],
                (string) args[8]);
        }
        else 
        {
            return false;
        }
    }

    [DisplayName("putValue")]
    public static byte[] PutValue(byte[] obj)
    {
        Storage.Put(Storage.CurrentContext, "StoredData", obj);
        return obj;
    }

    [DisplayName("getValue")]
    public static byte[] GetValue()
    {
        return Storage.Get(Storage.CurrentContext, "StoredData");
    }

    [DisplayName("contractMigrate")]
    public static bool ContractMigrate(
        byte[] script, 
        byte[] parameterList, 
        byte returnType, 
        byte propertyState, 
        string name, 
        string version, 
        string author, 
        string email, 
        string description)
    {
        //
        // TODO: Only allow administrators to call contractMigrate
        //
        // if (!IsAdministrator) 
        // {
        //     return false;   
        // }
        //
        
        Contract.Migrate(script, parameterList, returnType, (ContractPropertyState) propertyState, name, version, author, email, description);
        return true;
    }
}
