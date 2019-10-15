Option Explicit On
Public Class SelectLlocEntrega
    Inherits LVObjects
    Friend Property LlocEntregas As List(Of LlocEntrega)
    Friend Event selectObject(p As LlocEntrega)
    Public Sub New(pAccio As Integer, pMultiselect As Boolean, parentForm As Boolean, Optional pTitol As String = "", Optional pOrdre As Integer = 0)
        Me.accio = pAccio
        Me.multiselect = pMultiselect
        Me.isForm = parentForm
        Me.titol = pTitol
        Me.orderColumn = 1
        LlocEntregas = New List(Of LlocEntrega)
    End Sub
    Public Overrides Function afegir(id As Integer) As Integer
        Return save(DLlocEntrega.getLlocEntrega(New LlocEntrega))
    End Function
    Public Overrides Function eliminar(id As Integer) As Boolean
        Dim d As LlocEntrega
        d = ModelLlocEntrega.getObject(id)
        If d IsNot Nothing Then
            If MISSATGES.CONFIRM_REMOVE_LLOC_ENTREGA(d.ToString) Then
                Return ModelLlocEntrega.remove(d)
            End If
        End If
        Return False
    End Function

    Public Overrides Function filtrar(txt As String) As DataList
        Return ModelLlocEntrega.getDataList(ModelLlocEntrega.getObjects(txt))
    End Function

    Public Overrides Function modificar(id As Integer) As Integer
        Return save(DLlocEntrega.getLlocEntrega(ModelLlocEntrega.getObject(id)))
    End Function

    Public Overrides Function seleccionar(ids As List(Of Integer)) As Boolean
        Dim i As Integer, j As Integer
        LlocEntregas = New List(Of LlocEntrega)
        j = 0
        If ids.Count >= 0 Then
            For Each i In ids
                LlocEntregas.Add(ModelLlocEntrega.getObject(i))
            Next
            RaiseEvent selectObject(LlocEntregas.Item(0))
            Return True
        End If
        Return False
    End Function
    Private Function save(obj As LlocEntrega) As Integer
        If Not obj Is Nothing Then
            If Not ModelLlocEntrega.exist(obj) Then
                RaiseEvent selectObject(obj)
                Return ModelLlocEntrega.save(obj)
            Else
                Throw New ExcepcioSql(ExcepcioSql.ERR_EXIST_NOM_REGISTRE)
            End If
        End If
        Return False
    End Function
    Protected Overrides Sub Finalize()
        MyBase.Finalize()
        LlocEntregas = Nothing
    End Sub

    Public Overrides Function filtrar(idParent As Integer, txt As String) As DataList
        Return Nothing
    End Function
End Class

