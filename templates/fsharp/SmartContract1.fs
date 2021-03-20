module SmartContract1

open Neo.SmartContract.Framework;
open Neo.SmartContract.Framework.Services.Neo;

//[<assembly: ContractTitle("optional contract title")>]
//[<assembly: ContractDescription("optional contract description")>]
//[<assembly: ContractVersion("optional contract version")>]
//[<assembly: ContractAuthor("optional contract author")>]
//[<assembly: ContractEmail("optional contract email")>]
[<assembly: Features(ContractPropertyState.HasStorage)>]
do ()

type SmartContract1() =
    inherit SmartContract()

    static member Main () =
        Storage.Put(Storage.CurrentContext, "Hello", "World")
        ()