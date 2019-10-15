Public MustInherit Class LVSubObjects
    Private dades As DataList
    Private idActual As Integer = -1
    Private mSortingColumn As ColumnHeader
    Friend Property idParent As Integer
    Friend Property titol As String
    Friend Property orderColumn As Integer = 0
    Friend Property columnsSize As Integer()
    Public Sub New()
        InitializeComponent()
        Me.lstData.Columns.Clear()
    End Sub
    Public MustOverride Function afegir(id As Integer) As Boolean
    Public MustOverride Function modificar(id As Integer) As Boolean
    Public MustOverride Function eliminar(id As Integer) As Boolean
    Public MustOverride Function filtrar(id As Integer) As DataList
    Private Sub setLanguage()
        tTip1.SetToolTip(cmdAfegir, IDIOMA.getString("cmdAfegir"))
        tTip1.SetToolTip(cmdModificar, IDIOMA.getString("cmdModificar"))
        tTip1.SetToolTip(cmdEliminar, IDIOMA.getString("cmdEliminar"))
        tTip1.SetToolTip(cmdActualitzar, IDIOMA.getString("cmdActualitzar"))
        tTip1.SetToolTip(cmdImprimir, IDIOMA.getString("cmdImprimir"))
    End Sub
    Private Sub validateControls()

        Me.cmdAfegir.Enabled = True
        Me.cmdModificar.Visible = True
        Me.cmdEliminar.Visible = True
        If idActual > -1 Then
            Me.cmdModificar.Enabled = True
            Me.cmdEliminar.Enabled = True
        Else
            Me.cmdModificar.Enabled = False
            Me.cmdEliminar.Enabled = False
        End If
    End Sub
    Private Sub setDataColumns()
        For Each c As ColumnHeader In dades.columns
            Me.lstData.Columns.Add(c)
        Next
        If Me.lstData.Columns.Count > 0 Then Call ordenar(orderColumn)
    End Sub
    Private Sub setData()
        dades = filtrar(idParent)
        Call setDataRows()
    End Sub
    Private Sub setDataRows()
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

        Call validateControls()
    End Sub

    Private Sub cmdAfegir_Click(sender As Object, e As EventArgs) Handles cmdAfegir.Click
        If afegir(idParent) Then Call setData()
    End Sub
    Private Sub cmdModificar_Click(sender As Object, e As EventArgs) Handles cmdModificar.Click
        If modificar(idActual) Then Call setData()
    End Sub
    Private Sub cmdEliminar_Click(sender As Object, e As EventArgs) Handles cmdEliminar.Click
        Try
            If eliminar(idActual) Then
                idActual = -1
                Call setData()
                Call validateControls()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, IDIOMA.getString("abort"))
        End Try
    End Sub

    Private Sub lstData_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstData.SelectedIndexChanged

        If lstData.SelectedItems.Count > 0 Then
            idActual = Val(lstData.SelectedItems(0).Text)
        End If
        Call validateControls()
    End Sub
    Private Sub lstData_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lstData.MouseDoubleClick
        If lstData.SelectedItems.Count > 0 Then
            idActual = Val(lstData.SelectedItems(0).Text)
            If modificar(idActual) Then Call setData()
        End If
        Call validateControls()
    End Sub

    Private Sub lstData_ColumnClick(sender As Object, e As ColumnClickEventArgs) Handles lstData.ColumnClick
        Call ordenar(e.Column)
    End Sub
    Private Sub ordenar(c As Integer)
        Dim new_sorting_column As ColumnHeader = lstData.Columns(c)
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
            ListViewComparer(c, sort_order)
        ' Sort.
        lstData.Sort()
    End Sub
    Public Sub escollir(id As Integer)
        Dim i As Integer
        For i = 0 To Me.lstData.Items.Count - 1
            If Me.lstData.Items(i).SubItems(1).Text = id Then
                Me.lstData.Items(i).Selected = True
                Me.lstData.Select()
                Me.lstData.EnsureVisible(i)
                Return
            End If
        Next
    End Sub
End Class
