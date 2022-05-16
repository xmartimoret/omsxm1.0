Option Explicit On

Public Class SelectContacteProveidorSub
    Inherits LVSubObjects
    Friend Property contactes As List(Of ProveidorCont)
    Friend Property nomProveidor As String
    Friend Event updateObject()
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
            If ModelComanda.existObject(id, New ProveidorCont) Then
                If MISSATGES.CONFIRM_NO_REMOVE_DOWN_OBJECT(UCase(IDIOMA.getString("elContacteProveidor"))) Then
                    d.actiu = False
                    Call ModelProveidorContacte.save(d)
                End If
            ElseIf ModelComandaEnEdicio.existObject(id, New ProveidorCont) Then
                If MISSATGES.CONFIRM_NO_REMOVE_DOWN_OBJECT(UCase(IDIOMA.getString("elContacteProveidor"))) Then
                    d.actiu = False
                    Call ModelProveidorContacte.save(d)
                End If
            ElseIf MISSATGES.CONFIRM_REMOVE_CONTACTE_PROVEIDOR(d.toString) Then
                Return ModelProveidorContacte.remove(d)
            End If
        End If
        Return False
    End Function

    Public Overrides Function modificar(id As Integer) As Boolean
        Return save(DProveidorContacte.getProveidor(ModelProveidorContacte.getObject(id)))
    End Function


    Private Function save(obj As ProveidorCont) As Integer
        Dim i As Integer
        If Not obj Is Nothing Then
            i = ModelProveidorContacte.save(obj)
            If i > 0 Then RaiseEvent updateObject()
            Return i
        End If
        Return -1
    End Function
    Protected Overrides Sub Finalize()
        MyBase.Finalize()
        contactes = Nothing
    End Sub
    Public Overrides Function filtrar(id As Integer) As DataList
        Return ModelProveidorContacte.getDataList(ModelProveidorContacte.getObjects(id))
    End Function
End Class


