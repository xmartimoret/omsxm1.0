Option Explicit On

Public Class SelectContacteProveidor
    Inherits LVSubObjects
    Friend Property contactes As List(Of ProveidorCont)
    Friend Property nomProveidor As String

    Public Sub New(pIdProveidor As Integer, pNomProveidor As String, Optional pTitol As String = "", Optional pOrdre As Integer = 0)
        Me.idParent = pIdProveidor
        _nomProveidor = pNomProveidor
        Me.titol = pTitol
        Me.orderColumn = pOrdre
        _contactes = New List(Of ProveidorCont)
    End Sub
    Public Overrides Function afegir(id As Integer) As Boolean
        Return save(DProveidorContacte.getProveidor(New ProveidorCont(id)))
    End Function
    Public Overrides Function eliminar(id As Integer) As Boolean
        Dim d As ProveidorCont
        d = ModelProveidorContacte.getObject(id)
        If d IsNot Nothing Then
            If MISSATGES.CONFIRM_REMOVE_CONTACTE_PROVEIDOR(d.ToString) Then
                Return ModelProveidorContacte.remove(d)
            End If
        End If
        Return False
    End Function

    Public Overrides Function modificar(id As Integer) As Boolean
        Return save(DProveidorContacte.getProveidor(ModelProveidorContacte.getObject(id)))
    End Function


    Private Function save(obj As ProveidorCont) As Integer
        If Not obj Is Nothing Then

            Return ModelProveidorContacte.save(obj)

        End If
        Return False
    End Function
    Protected Overrides Sub Finalize()
        MyBase.Finalize()
        contactes = Nothing
    End Sub
    Public Overrides Function filtrar(id As Integer) As DataList
        Return ModelProveidorContacte.getDataList(ModelProveidorContacte.getObjects(id))
    End Function
End Class


