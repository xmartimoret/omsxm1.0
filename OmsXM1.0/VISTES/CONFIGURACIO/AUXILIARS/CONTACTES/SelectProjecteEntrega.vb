Option Explicit On
Public Class SelectProjecteEntrega
    Inherits LVSubObjects
    Friend Property llocsEntrega As List(Of projecteEntrega)
    Friend Property nomProjecte As String
    Public Sub New(pIdProjecte As Integer, pNomProjecte As String, Optional pTitol As String = "", Optional pOrdre As Integer = 0)
        Me.idParent = pIdProjecte
        _nomProjecte = pNomProjecte
        Me.titol = pTitol
        Me.orderColumn = pOrdre
        _llocsEntrega = New List(Of projecteEntrega)
    End Sub
    Public Overrides Function afegir(id As Integer) As Boolean
        Dim llocsEntrega As List(Of LlocEntrega), c As LlocEntrega, result As Boolean
        llocsEntrega = DAuxiliars.getEntregues()
        For Each c In llocsEntrega
            If Not ModelProjecteEntrega.exist(id, c.id) Then
                result = save(New projecteEntrega(id, c.id))
            End If
        Next
        Return result
    End Function
    Public Overrides Function eliminar(id As Integer) As Boolean
        Dim d As projecteEntrega
        d = ModelProjecteEntrega.getObject(Me.idParent, id)

        If d IsNot Nothing Then
            If MISSATGES.CONFIRM_REMOVE_PROJECTE_ENTREGA() Then
                Return ModelProjecteEntrega.remove(d)
            End If
        End If
        Return False
    End Function

    Public Overrides Function modificar(id As Integer) As Boolean
        Dim c As LlocEntrega, result As Boolean
        c = ModelLlocEntrega.getObject(id)
        c = DLlocEntrega.getLlocEntrega(c)
        If c IsNot Nothing Then
            If ModelLlocEntrega.save(c) Then
                result = True
            End If
        End If
        Return result
    End Function


    Private Function save(obj As projecteEntrega) As Integer
        If Not obj Is Nothing Then
            Return ModelProjecteEntrega.save(obj)
        End If
        Return False
    End Function
    Protected Overrides Sub Finalize()
        MyBase.Finalize()
        llocsEntrega = Nothing
    End Sub
    Public Overrides Function filtrar(id As Integer) As DataList
        Return ModelProjecteEntrega.getDataList(ModelProjecteEntrega.getObjects(id))
    End Function
End Class

