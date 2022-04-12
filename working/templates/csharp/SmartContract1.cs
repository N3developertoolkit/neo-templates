using System;
using System.ComponentModel;
using Neo;
using Neo.SmartContract.Framework;
using Neo.SmartContract.Framework.Attributes;
using Neo.SmartContract.Framework.Native;
using Neo.SmartContract.Framework.Services;

public class SmartContract1 : SmartContract
{
    const byte Prefix_ContractOwner = 0xFF;

    public static void Main()
    {
        Storage.Put(Storage.CurrentContext, "Hello", "World");
    }

    [DisplayName("_deploy")]
    public void Deploy(object data, bool update)
    {
        if (update) return;

        var tx = (Transaction)Runtime.ScriptContainer;
        var key = new byte[] { Prefix_ContractOwner };
        Storage.Put(Storage.CurrentContext, key, tx.Sender);
    }

    public static void Update(ByteString nefFile, string manifest)
    {
        if (!ValidateContractOwner())
        {
            throw new Exception("Only the contract owner can update the contract");
        }
        ContractManagement.Update(nefFile, manifest, null);
    }

    static bool ValidateContractOwner()
    {
        var key = new byte[] { Prefix_ContractOwner };
        var contractOwner = (UInt160)Storage.Get(Storage.CurrentContext, key);
        var tx = (Transaction)Runtime.ScriptContainer;
        return contractOwner.Equals(tx.Sender) && Runtime.CheckWitness(contractOwner);
    }
}
