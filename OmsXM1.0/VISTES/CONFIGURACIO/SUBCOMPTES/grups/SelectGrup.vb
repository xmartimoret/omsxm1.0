

Public Class SelectGrup
    Inherits LVObjects

    Friend Property grups As List(Of Grup)
    Friend Property dialegResult As Integer = 0
    Public Sub New(pAccio As Integer, pMultiselect As Boolean, parentForm As Boolean, Optional pTitol As String = "")
        Me.accio = pAccio
        Me.multiselect = pMultiselect
        Me.isForm = parentForm
        Me.titol = pTitol
        _grups = New List(Of Grup)
    End Sub
    Public Overrides Function afegir(id As Integer) As Integer
        Dim g As Grup
        g = DGrup.getGrup(New Grup)
        If g IsNot Nothing Then
            Return save(g)
        End If
        Return False
    End Function
    Public Overrides Function eliminar(id As Integer) As Boolean
        Dim g As Grup
        g = ModelGrup.getObject(id)
        If g IsNot Nothing Then
            If MISSATGES.CONFIRM_REMOVE_SUBCOMPTE(g.ToString) Then
                _dialegResult = 1
                Return ModelGrup.remove(g)
            End If
        End If
        Return False
    End Function
    Public Overrides Function filtrar(txt As String) As DataList
        Return ModelGrup.getDataList(ModelGrup.getObjects(txt))
    End Function

    Public Overrides Function modificar(id As Integer) As Integer
        Dim g As Grup
        g = DGrup.getGrup(ModelGrup.getObject(id))
        If g IsNot Nothing Then Return save(g)
        Return False
    End Function

    Public Overrides Function seleccionar(ids As List(Of Integer)) As Boolean
        Dim i As Integer
        _grups = New List(Of Grup)
        If ids.Count >= 0 Then
            For Each i In ids
                _grups.Add(ModelGrup.getObject(i))
            Next
            Return True
        End If
        Return False
    End Function
    Private Function save(obj As Grup) As Integer
        If Not obj Is Nothing Then
            If Not ModelGrup.exist(obj) Then
                _dialegResult = 1
                Return ModelGrup.save(obj)
            Else
                Throw New ExcepcioSql(ExcepcioSql.ERR_EXIST_CODI_REGISTRE)
            End If
        End If
        Return False
    End Function

    Protected Overrides Sub Finalize()
        MyBase.Finalize()

    End Sub

    Public Overrides Function filtrar(idParent As Integer, txt As String) As DataList
        Return Nothing
    End Function

    Public Overrides Function getRow(id As Integer) As ListViewItem
        Return ModelGrup.getListViewItem(id)
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
