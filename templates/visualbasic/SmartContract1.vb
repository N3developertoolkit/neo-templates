Imports System.ComponentModel

Imports Neo.SmartContract.Framework
Imports Neo.SmartContract.Framework.Services.Neo

' <Assembly: ContractTitle("optional contract title")>
' <Assembly: ContractDescription("optional contract description")>
' <Assembly: ContractVersion("optional contract version")>
' <Assembly: ContractAuthor("optional contract author")>
' <Assembly: ContractEmail("optional contract email")>
<Assembly: Features(ContractPropertyState.HasStorage)>

Public Class SmartContract1 : Inherits SmartContract

    Public Shared Function Main(method As String, args As Object()) As Object
        If String.Equals(method, "putValue") Then
            Main = PutValue(args(0))
        ElseIf String.Equals(method, "getValue") Then
            Main = GetValue()
        'ElseIf String.Equals(method, "contractMigrate") Then
        '    Main = ContractMigrate(args(0), args(1), args(2), args(3), args(4), args(5), args(6), args(7), args(8))
        Else
            Main = false
        End If
    End Function

    <DisplayName("putValue")>
    Public Shared Function PutValue(obj As Byte()) As Byte()
        Storage.Put(Storage.CurrentContext, "StoredData", obj)
        PutValue = obj
    End Function

    <DisplayName("getValue")>
    Public Shared Function GetValue() As Byte()
        GetValue = Storage.Get(Storage.CurrentContext, "StoredData")
    End Function

    '<DisplayName("contractMigrate")>
    'Public Shared Function ContractMigrate(
    '    script As Byte(), 
    '    parameterList As Byte(), 
    '    returnType As Byte, 
    '    propertyState As ContractPropertyState, 
    '    name As String, 
    '    version As String, 
    '    author As String, 
    '    email As String, 
    '    description As String)
    '    
    '    '
    '    ' TODO: Only allow administrators to call contractMigrate
    '    '
    '    ' If Not IsAdministrator Then
    '    '     ContractMigrate = False
    '    ' End If
    '    '
    '
    '    Contract.Migrate(script, parameterList, returnType, propertyState, name, version, author, email, description)
    '    ContractMigrate = True
    'End Function

End Class
