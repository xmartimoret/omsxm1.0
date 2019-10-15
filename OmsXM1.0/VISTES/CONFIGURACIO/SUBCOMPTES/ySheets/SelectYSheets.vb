Public Class SelectYSheets
    Inherits LVObjects
    Friend Property ysheets As List(Of YSheet)

    Public Sub New(pAccio As Integer, pMultiselect As Boolean, parentForm As Boolean, Optional pTitol As String = "", Optional pOrdre As Integer = 0)
        Me.accio = pAccio
        Me.multiselect = pMultiselect
        Me.isForm = parentForm
        Me.titol = pTitol
        Me.orderColumn = 1
        _ysheets = New List(Of YSheet)
    End Sub
    Public Sub New(pAccio As Integer, pMultiselect As Boolean, parentForm As Boolean, pIdGrupComptable As Integer, Optional pTitol As String = "", Optional pOrdre As Integer = 0)
        Me.accio = pAccio
        Me.multiselect = pMultiselect
        Me.isForm = parentForm
        Me.titol = pTitol
        Me.orderColumn = 1
        _ysheets = New List(Of YSheet)
    End Sub
    Public Overrides Function afegir(id As Integer) As Integer
        Dim y As YSheet
        y = DYsheet.getYsheet(New YSheet)
        Return save(y)
        Return False
    End Function

    Public Overrides Function eliminar(id As Integer) As Boolean
        Dim y As YSheet
        y = ModelYSheet.getObject(id)
        If y.id > -1 Then
            If MISSATGES.CONFIRM_REMOVE_SUBCOMPTE(y.ToString) Then
                Return ModelYSheet.remove(y)
            End If
        End If
        Return False
    End Function

    Public Overrides Function filtrar(txt As String) As DataList
        Return ModelYSheet.getDataList(ModelYSheet.getObjects(txt))
    End Function

    Public Overrides Function modificar(id As Integer) As Integer
        Dim y As YSheet
        y = DYsheet.getYsheet(ModelYSheet.getObject(id))
        Return save(y)
        Return False
    End Function

    Public Overrides Function seleccionar(ids As List(Of Integer)) As Boolean
        Dim i As Integer
        ysheets = New List(Of YSheet)
        If ids.Count >= 0 Then
            For Each i In ids
                ysheets.Add(ModelYSheet.getObject(i))
            Next
            Return True
        End If
        Return False
    End Function
    Private Function save(obj As YSheet) As Integer
        If Not obj Is Nothing Then
            If Not ModelYSheet.exist(obj) Then
                Return ModelYSheet.save(obj)
            Else
                Throw New ExcepcioSql(ExcepcioSql.ERR_EXIST_CODI_REGISTRE)
            End If
        End If
        Return False
    End Function
    Protected Overrides Sub Finalize()
        MyBase.Finalize()
        ysheets = Nothing
    End Sub
    Public Overrides Function filtrar(idParent As Integer, txt As String) As DataList
        Return Nothing
    End Function
End Class
