Imports System

Imports Neo.SmartContract.Framework
Imports Neo.SmartContract.Framework.Services.Neo

' <Assembly: ContractTitle("optional contract title")>
' <Assembly: ContractDescription("optional contract description")>
' <Assembly: ContractVersion("optional contract version")>
' <Assembly: ContractAuthor("optional contract author")>
' <Assembly: ContractEmail("optional contract email")>
<Assembly: Features(ContractPropertyState.HasStorage)>


Public Class SmartContract1 : Inherits SmartContract

    Public Shared Function Main(method As String, args As Object()) As Byte()
        If String.Equals(method, "PutValue") Then
            Main = PutValue(args(0))
        ElseIf String.Equals(method, "GetValue") Then
            Main = GetValue()
        Else
            Throw new NotImplementedException()
        End If
    End Function

    Public Shared Function PutValue(obj As Byte()) As Byte()
        Storage.Put(Storage.CurrentContext, "StoredData", obj)
        PutValue = obj
    End Function

    Public Shared Function GetValue() As Byte()
        GetValue = Storage.Get(Storage.CurrentContext, "StoredData")
    End Function

End Class
