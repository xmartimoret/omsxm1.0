Option Explicit On

Public Class SelectClient
    Inherits LVSubObjects2
    Friend Event selectObject(ByVal c As Client)
    Public Sub New(pAccio As Integer, pMultiselect As Boolean, parentForm As Boolean, pIDClient As Integer, Optional pTitol As String = "", Optional pOrdre As Integer = 0)
        MyBase.New(True, True, True, "", "", "", False)
        Me.idParent = pIDClient
        Me.titol = pTitol
        Me.orderColumn = pOrdre

    End Sub

    Public Overrides Function afegir(id As String, idParent As String) As Boolean
        Dim c As Client
        c = DClient.getClient(New Client)
        If c IsNot Nothing Then Return save(c)
        Return False
    End Function

    Public Overrides Function eliminar(ids As List(Of String)) As Boolean
        Dim c As Client, result As Boolean, str As String
        result = False
        For Each str In ids
            If IsNumeric(str) Then
                c = ModelClient.getObject(CInt(str))
                If c IsNot Nothing Then
                    If MISSATGES.CONFIRM_REMOVE_CLIENT(c.ToString) Then
                        If Not result Then
                            result = modelclient.remove(c)
                        Else
                            Call ModelClient.remove(c)
                        End If
                    End If
                End If
            End If
        Next
        c = Nothing
        Return result
    End Function


    Public Overrides Function modificar(id As String) As Boolean
        Dim c As Client
        c = ModelClient.getObject(id)
        c = DClient.getClient(c)
        If c IsNot Nothing Then Return save(c)
        Return False
    End Function

    Private Function save(obj As Client) As Boolean
        Dim saved As Boolean
        If Not obj Is Nothing Then
            If Not ModelClient.exist(obj) Then
                saved = ModelClient.save(obj)
                If saved Then RaiseEvent selectObject(obj)
            Else
                Throw New ExcepcioSql(ExcepcioSql.ERR_EXIST_CODI_REGISTRE)
            End If
        End If
        Return saved
    End Function
    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
    Public Overrides Function filtrar(id As String) As DataList
        Return ModelClient.getDataList(ModelClient.getObjects(""))
    End Function
    Public Overrides Function seleccionar(id As String) As Boolean
        Dim c As Client
        c = ModelClient.getObject(id)
        If c IsNot Nothing Then
            RaiseEvent selectObject(c)
            Return True
        End If
        Return False
    End Function
    Public Overrides Function canviarOrdre(id1 As String, id2 As String) As Boolean
        Dim obj1 As Client, obj2 As Client
        obj1 = ModelClient.getObject(id1)
        obj2 = ModelClient.getObject(id2)
        If obj1 IsNot Nothing And obj2 IsNot Nothing Then
            Call ModelClient.changeOrder(obj1, obj2)
            obj1 = Nothing
            obj2 = Nothing
            Return True
        End If
        Return False
    End Function
End Class
