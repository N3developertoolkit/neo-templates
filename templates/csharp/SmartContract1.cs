using System;

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
        if (method == "PutValue") 
        {
            return PutValue(args[0] as byte[]);
        } 
        else if (method == "GetValue")
        {
            return GetValue();
        }
        else 
        {
            throw new NotImplementedException();
        }
    }

    public static byte[] PutValue(byte[] obj)
    {
        Storage.Put(Storage.CurrentContext, "StoredData", obj);
        return obj;
    }

    public static byte[] GetValue()
    {
        return Storage.Get(Storage.CurrentContext, "StoredData");
    }
}
