Option Explicit On

Public Class SelectSubcomptes
    Inherits LVObjects

    Friend Property subcomptes As List(Of Subcompte)
    Friend Property nomes67 As Boolean
    Private idGrup As Integer = 0
    Public Sub New(pAccio As Integer, pMultiselect As Boolean, parentForm As Boolean, Optional pTitol As String = "", Optional pOrdre As Integer = 0)
        Me.accio = pAccio
        Me.multiselect = pMultiselect
        Me.isForm = parentForm
        Me.titol = pTitol
        nomes67 = False
        Me.orderColumn = 1

        _subcomptes = New List(Of Subcompte)
    End Sub
    Public Sub New(pAccio As Integer, pMultiselect As Boolean, parentForm As Boolean, pIdGrupComptable As Integer, Optional pTitol As String = "", Optional pOrdre As Integer = 0)
        Me.accio = pAccio
        Me.multiselect = pMultiselect
        Me.isForm = parentForm
        Me.titol = pTitol
        Me.orderColumn = 1
        nomes67 = False

        _subcomptes = New List(Of Subcompte)
    End Sub
    Public Sub New(pAccio As Integer, pMultiselect As Boolean, parentForm As Boolean, pIdGrupComptable As Integer, pNomes67 As Boolean, Optional pTitol As String = "", Optional pOrdre As Integer = 0)
        idGrup = pIdGrupComptable
        Me.accio = pAccio
        Me.multiselect = pMultiselect
        Me.isForm = parentForm
        Me.titol = pTitol
        Me.orderColumn = 1
        nomes67 = pNomes67
        _subcomptes = New List(Of Subcompte)
    End Sub
    Public Overrides Function afegir(id As Integer) As Integer
        Dim s As Subcompte
        s = DSubcompte.getSubcompte(New Subcompte)
        Return save(s)
        Return False
    End Function

    Public Overrides Function eliminar(id As Integer) As Boolean
        Dim s As Subcompte
        s = ModelSubcompte.getObject(id)
        If s.id > -1 Then
            If MISSATGES.CONFIRM_REMOVE_SUBCOMPTE(s.ToString) Then
                Return ModelSubcompte.remove(s)
            End If
        End If
        Return False
    End Function

    Public Overrides Function filtrar(txt As String) As DataList
        If idGrup <= 0 Then
            Return ModelSubcompte.getDataList(ModelSubcompte.getObjects(nomes67, txt))
        Else
            Return ModelSubcompte.getDataList(ModelSubcompte.getObjectsNoSelect(nomes67, idGrup, txt))
        End If
    End Function

    Public Overrides Function modificar(id As Integer) As Integer
        Dim s As Subcompte
        s = DSubcompte.getSubcompte(ModelSubcompte.getObject(id))
        Return save(s)
        Return False
    End Function

    Public Overrides Function seleccionar(ids As List(Of Integer)) As Boolean
        Dim i As Integer
        subcomptes = New List(Of Subcompte)
        If ids.Count >= 0 Then
            For Each i In ids
                subcomptes.Add(ModelSubcompte.getObject(i))
            Next
            Return True
        End If
        Return False
    End Function
    Private Function save(obj As Subcompte) As Integer
        If Not obj Is Nothing Then
            If Not ModelSubcompte.exist(obj) Then
                Return ModelSubcompte.save(obj)
            Else
                Throw New ExcepcioSql(ExcepcioSql.ERR_EXIST_CODI_REGISTRE)
            End If
        End If
        Return False
    End Function
    Protected Overrides Sub Finalize()
        MyBase.Finalize()
        subcomptes = Nothing
    End Sub
    Public Overrides Function filtrar(idParent As Integer, txt As String) As DataList
        Return Nothing
    End Function

    Public Overrides Function getRow(id As Integer) As ListViewItem
        Return ModelSubcompte.getListViewItem(id)
    End Function
    Public Overrides Sub imprimir(pdf As Boolean, filtre As String)
        Call ERRORS.EN_CONSTRUCCIO()
    End Sub
    Public Overrides Sub actualitzar(id As List(Of Integer))

    End Sub
    Public Overrides Sub toolTipText(id As Integer)

    End Sub
    Public Overrides Sub guardarCopia(id As Integer)
        Call ERRORS.EN_CONSTRUCCIO()
    End Sub
End Class
