Option Explicit On
Public Class SelectContactes
    Inherits LVObjects
    Friend Property contactes As List(Of Contacte)
    Friend Event selectObject(p As Contacte)
    Public Sub New(pAccio As Integer, pMultiselect As Boolean, parentForm As Boolean, Optional pTitol As String = "", Optional pOrdre As Integer = 0)
        Me.accio = pAccio
        Me.multiselect = pMultiselect
        Me.isForm = parentForm
        Me.titol = pTitol
        Me.orderColumn = 0
        contactes = New List(Of Contacte)
    End Sub
    Public Overrides Function afegir(id As Integer) As Integer
        Return save(DContacte.getContacte(New Contacte))
    End Function
    Public Overrides Function eliminar(id As Integer) As Boolean
        Dim d As Contacte
        d = ModelContacte.getObject(id)
        If d IsNot Nothing Then
            If MISSATGES.CONFIRM_REMOVE_CONTACTE(d.ToString) Then
                Return ModelContacte.remove(d)
            End If
        End If
        Return False
    End Function

    Public Overrides Function filtrar(txt As String) As DataList
        Return ModelContacte.getDataList(ModelContacte.getObjects(txt))
    End Function

    Public Overrides Function modificar(id As Integer) As Integer
        Return save(DContacte.getContacte(ModelContacte.getObject(id)))
    End Function

    Public Overrides Function seleccionar(ids As List(Of Integer)) As Boolean
        Dim i As Integer, j As Integer
        contactes = New List(Of Contacte)
        j = 0
        If ids.Count >= 0 Then
            For Each i In ids
                contactes.Add(ModelContacte.getObject(i))
            Next
            RaiseEvent selectObject(contactes.Item(0))
            Return True
        End If
        Return False
    End Function
    Private Function save(obj As Contacte) As Integer
        If Not obj Is Nothing Then
            If Not ModelContacte.exist(obj) Then
                RaiseEvent selectObject(obj)
                Return ModelContacte.save(obj)
            Else
                Throw New ExcepcioSql(ExcepcioSql.ERR_EXIST_NOM_REGISTRE)
            End If
        End If
        Return False
    End Function
    Protected Overrides Sub Finalize()
        MyBase.Finalize()
        contactes = Nothing
    End Sub

    Public Overrides Function filtrar(idParent As Integer, txt As String) As DataList
        Return Nothing
    End Function
End Class

