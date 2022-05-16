Option Explicit On

Public Class SelectProveidorAnotacio
    Inherits LVSubObjects
    Friend Property anotacions As List(Of proveidorAnotacio)
    Friend Property nomProveidor As String
    Friend Event updateObject()
    Public Sub New(pIdProveidor As Integer, pNomProveidor As String, Optional pTitol As String = "", Optional pOrdre As Integer = 0)
        Me.idParent = pIdProveidor
        _nomProveidor = pNomProveidor
        Me.titol = pTitol
        Me.orderColumn = pOrdre
        _anotacions = New List(Of proveidorAnotacio)
    End Sub
    Public Overrides Function afegir(id As Integer) As Boolean
        Return save(DProveidorAnotacio.getAnotacio(New proveidorAnotacio(id)))
    End Function
    Public Overrides Function eliminar(id As Integer) As Boolean
        Dim d As proveidorAnotacio
        d = ModelProveidorAnotacio.getObject(id)
        If d IsNot Nothing Then
            If MISSATGES.CONFIRM_REMOVE_ANOTACIO_PROVEIDOR() Then
                Return ModelProveidorAnotacio.remove(d)
            End If
        End If
        Return False
    End Function

    Public Overrides Function modificar(id As Integer) As Boolean
        Return save(DProveidorAnotacio.getAnotacio(ModelProveidorAnotacio.getObject(id)))
    End Function


    Private Function save(obj As proveidorAnotacio) As Integer
        Dim i As Integer
        If Not obj Is Nothing Then
            i = ModelProveidorAnotacio.save(obj)
            If i > 0 Then RaiseEvent updateObject()
            Return i
        End If
        Return False
    End Function
    Protected Overrides Sub Finalize()
        MyBase.Finalize()
        _anotacions = Nothing
    End Sub
    Public Overrides Function filtrar(id As Integer) As DataList
        Return ModelProveidorAnotacio.getDataList(ModelProveidorAnotacio.getObjects(id))
    End Function
End Class


