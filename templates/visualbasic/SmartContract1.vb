Imports Neo.SmartContract.Framework
Imports Neo.SmartContract.Framework.Services.Neo

' <Assembly: ContractTitle("optional contract title")>
' <Assembly: ContractDescription("optional contract description")>
' <Assembly: ContractVersion("optional contract version")>
' <Assembly: ContractAuthor("optional contract author")>
' <Assembly: ContractEmail("optional contract email")>
<Assembly: Features(ContractPropertyState.HasStorage)>


Public Class SmartContract1 : Inherits SmartContract
    Public Shared Sub Main()
        Storage.Put(Storage.CurrentContext, "Hello", "World")
    End Sub
End Class
