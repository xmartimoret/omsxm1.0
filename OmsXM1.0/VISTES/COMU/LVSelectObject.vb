Public MustInherit Class LVSelectObject
    Private dades As DataList
    Private idActual As Integer = -1
    Private mSortingColumn As ColumnHeader
    Friend Property titol As String
    Friend Property orderColumn As Integer = 0
    Public Sub New()
        InitializeComponent()
        Me.lstData.Columns.Clear()
    End Sub

    Public MustOverride Function seleccionar(id As Integer) As Boolean
    Public MustOverride Function modificar(id As Integer) As Integer
    Public MustOverride Function filtrar(txt As String) As DataList
    Private Sub setLanguage()
        Me.lblFiltrar.Text = IDIOMA.getString("filtrarPer")
    End Sub

    Private Sub setDataColumns()
        For Each c As ColumnHeader In dades.columns
            Me.lstData.Columns.Add(c)
        Next
        If lstData.Columns.Count > orderColumn Then Call ordenar(orderColumn)
    End Sub
    Private Sub setData()
        dades = filtrar(Me.txtFiltrar.Text)
        Me.lstData.Items.Clear()
        If dades IsNot Nothing Then
            If dades.columns.Count > 0 Then
                If lstData.Columns.Count = 0 Then Call setDataColumns()
                Me.lstData.Items.AddRange(dades.rows.ToArray)
                Me.lblCount.Text = dades.rows.Count & " registres."
            End If
        End If

    End Sub
    Private Sub listViewXM_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call setLanguage()
        Me.lstData.MultiSelect = False
        Me.lblTitol.Text = titol
        Call setData()
    End Sub
    Private Sub txtFiltrar_TextChanged(sender As Object, e As EventArgs) Handles txtFiltrar.TextChanged
        Call setData()
    End Sub

    Private Sub lstData_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstData.SelectedIndexChanged
        If lstData.SelectedItems.Count > 0 Then
            idActual = Val(lstData.SelectedItems(0).Text)
            Call seleccionar(idActual)
        End If

    End Sub

    Private Sub lstData_ColumnClick(sender As Object, e As ColumnClickEventArgs) Handles lstData.ColumnClick
        Call ordenar(e.Column)
    End Sub
    Private Sub ordenar(e As Integer)
        Dim new_sorting_column As ColumnHeader = lstData.Columns(e)
        ' Figure out the new sorting order.
        Dim sort_order As System.Windows.Forms.SortOrder
        sort_order = SortOrder.Ascending
        If mSortingColumn Is Nothing Then
            ' New column. Sort ascending.
            sort_order = SortOrder.Ascending
        Else
            ' See if this is the same column.
            If new_sorting_column.Equals(mSortingColumn) Then
                ' Same column. Switch the sort order.
                If mSortingColumn.Text.StartsWith("↑ ") Then
                    sort_order = SortOrder.Descending
                Else
                    sort_order = SortOrder.Ascending
                End If
            Else
                ' New column. Sort ascending.
                sort_order = SortOrder.Ascending
            End If

            ' Remove the old sort indicator.
            mSortingColumn.Text =
                mSortingColumn.Text.Substring(2)
        End If

        ' Display the new sort order.
        mSortingColumn = new_sorting_column
        If sort_order = SortOrder.Ascending Then
            mSortingColumn.Text = "↑ " & mSortingColumn.Text
        Else
            mSortingColumn.Text = "↓ " & mSortingColumn.Text
        End If

        ' Create a comparer.
        lstData.ListViewItemSorter = New _
            ListViewComparer(e, sort_order)
        ' Sort.
        lstData.Sort()
    End Sub
    Private Function isSelected() As Boolean
        Dim i As Integer
        For i = 0 To lstData.Items.Count - 1
            If Not lstData.Items(i).Selected Then Return False
        Next
        Return True
    End Function

    Private Sub lstData_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lstData.MouseDoubleClick
        If lstData.SelectedItems.Count > 0 Then
            idActual = Val(lstData.SelectedItems(0).Text)
            Call modificar(idActual)

        End If
    End Sub

End Class
