Option Explicit On
Public Class SelectLlocEntrega
    Inherits LVObjects
    Friend Property LlocEntregues As List(Of LlocEntrega)
    Private Property llocsActuals As List(Of LlocEntrega)
    Friend Event selectObject(p As LlocEntrega)
    Public Sub New(pAccio As Integer, pMultiselect As Boolean, parentForm As Boolean, Optional pTitol As String = "", Optional pOrdre As Integer = 0)
        Me.accio = pAccio
        Me.multiselect = pMultiselect
        Me.isForm = parentForm
        Me.titol = pTitol
        Me.orderColumn = 1
        LlocEntregues = New List(Of LlocEntrega)
    End Sub
    Public Overrides Function afegir(id As Integer) As Integer
        Return save(DLlocEntrega.getLlocEntrega(New LlocEntrega))
    End Function
    Public Overrides Function eliminar(id As Integer) As Boolean
        Dim d As LlocEntrega
        d = ModelLlocEntrega.getObject(id)
        If d IsNot Nothing Then
            If ModelComanda.existObject(id, New LlocEntrega) Then
                If MISSATGES.CONFIRM_NO_REMOVE_DOWN_OBJECT(UCase(IDIOMA.getString("llocEntrega"))) Then
                    d.actiu = False
                    Call ModelLlocEntrega.save(d)
                End If
            ElseIf ModelComandaenedicio.existObject(id, New LlocEntrega) Then
                If MISSATGES.CONFIRM_NO_REMOVE_DOWN_OBJECT(UCase(IDIOMA.getString("llocEntrega"))) Then
                    d.actiu = False
                    Call ModelLlocEntrega.save(d)
                End If
            ElseIf MISSATGES.CONFIRM_REMOVE_LLOC_ENTREGA(d.toString) Then
                Return ModelLlocEntrega.remove(d)
            End If
        End If
        Return False
    End Function

    Public Overrides Function filtrar(txt As String) As DataList
        llocsActuals = ModelLlocEntrega.getObjects(txt)
        Return ModelLlocEntrega.getDataList(llocsActuals)
    End Function

    Public Overrides Function modificar(id As Integer) As Integer
        Return save(DLlocEntrega.getLlocEntrega(ModelLlocEntrega.getObject(id)))
    End Function

    Public Overrides Function seleccionar(ids As List(Of Integer)) As Boolean
        Dim i As Integer, j As Integer
        LlocEntregues = New List(Of LlocEntrega)
        j = 0
        If ids.Count >= 0 Then
            For Each i In ids
                LlocEntregues.Add(ModelLlocEntrega.getObject(i))
            Next
            RaiseEvent selectObject(LlocEntregues.Item(0))
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
        LlocEntregues = Nothing
    End Sub

    Public Overrides Function filtrar(idParent As Integer, txt As String) As DataList
        Return Nothing
    End Function

    Public Overrides Function getRow(id As Integer) As ListViewItem
        Return ModelLlocEntrega.getListViewItem(id)
    End Function
    Public Overrides Sub imprimir(pdf As Boolean, filtre As String)
        Call modulInfoLlocEntrega.execute(llocsActuals, pdf, filtre)
    End Sub
    Public Overrides Sub actualitzar(id As List(Of Integer))

    End Sub
    Public Overrides Sub toolTipText(id As Integer)

    End Sub
    Public Overrides Sub guardarCopia(id As Integer)
        Call ERRORS.EN_CONSTRUCCIO()
    End Sub
End Class

