Public MustInherit Class LVObjectsCopiar
    Private dades As DataList
    Private idActual As Integer = -1
    Private mSortingColumn As ColumnHeader
    Friend Property accio As Integer
    Friend Property multiselect As Boolean
    Friend Property isForm As Boolean
    Friend Property titol As String
    Friend Property orderColumn As Integer = 0
    Friend Property idParent As Integer = 0
    Friend Property columnsSize As Integer()
    Private objects As List(Of Object)
    Friend Event dblClick()
    Friend Event updateData()

    Public Sub New()
        InitializeComponent()
        Me.ContextMenuStrip = mnuContextual

        Me.lstData.Columns.Clear()

    End Sub
    Public MustOverride Function seleccionar(id As Integer, estat As Integer) As Boolean
    Public MustOverride Function copiar() As Integer
    Public MustOverride Function eliminar() As Boolean
    Public MustOverride Function filtrar(txt As String) As DataList
    Public MustOverride Function mostrar() As Boolean
    Public MustOverride Sub imprimir(pdf As Boolean, dades As List(Of List(Of String)), filtre As String)

    Private Sub setLanguage()
        Me.lblFiltrar.Text = IDIOMA.getString("filtrarPer")
        tTip1.SetToolTip(cmdCancelar, IDIOMA.getString("cmdSortir"))
        tTip1.SetToolTip(cmdEliminar, IDIOMA.getString("cmdEliminar"))
        tTip1.SetToolTip(cmdCopiar, IDIOMA.getString("cmdCopiar"))

        mnuMostrar.Text = IDIOMA.getString("cmdMostrar")
        mnoCopiar.Text = IDIOMA.getString("cmdCopiar")
        mnuEliminar.Text = IDIOMA.getString("cmdEliminar")
        mnuImprimir.Text = IDIOMA.getString("cmdImprimir")
    End Sub
    Private Sub validateControls()

        If idActual > 0 Then
            Me.cmdMostrar.Enabled = True
            Me.cmdCopiar.Enabled = True
            Me.cmdEliminar.Enabled = True


            Me.mnuEliminar.Enabled = True
            Me.mnoCopiar.Enabled = True
            Me.mnuImprimir.Enabled = True
            Me.mnuMostrar.Enabled = True
        Else
            Me.cmdMostrar.Enabled = False
            Me.cmdCopiar.Enabled = False
            Me.cmdEliminar.Enabled = False


            Me.mnuEliminar.Enabled = False
            Me.mnoCopiar.Enabled = False
            Me.mnuImprimir.Enabled = False
            Me.mnuMostrar.Enabled = False
        End If
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
                Me.lblCount.Text = dades.rows.Count & " " & IDIOMA.getString("registres") & "."
                RaiseEvent updateData()
            End If
        End If
    End Sub
    Private Sub removeRow(id As Integer)
        Dim r As ListViewItem
        For Each r In lstData.Items
            If r.Text = id Then
                r.Remove()
                Exit For
            End If
        Next
        r = Nothing
    End Sub
    Private Sub listViewXM_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call setLanguage()
        Me.lstData.MultiSelect = multiselect
        Me.lblTitol.Text = titol
        Call setData()
        Call validateControls()
    End Sub
    Private Sub txtFiltrar_TextChanged(sender As Object, e As EventArgs) Handles txtFiltrar.TextChanged
        Call setData()
        Call validateControls()
    End Sub
    Private Sub cmdCopiar_Click(sender As Object, e As EventArgs) Handles cmdCopiar.Click
        If lstData.SelectedItems.Count > 0 Then
            Call copiar()
        End If
        Call validateControls()
    End Sub
    Private Sub cmdEliminar_Click(sender As Object, e As EventArgs) Handles cmdEliminar.Click
        Try
            If eliminar() Then
                Call removeRow(idActual)
                idActual = 0
                Call validateControls()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, IDIOMA.getString("abort"))
        End Try
        Call validateControls()
    End Sub

    Private Sub lstData_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstData.SelectedIndexChanged
        If lstData.SelectedItems.Count > 0 Then
            idActual = Val(lstData.SelectedItems(0).Text)
            Call seleccionar(idActual, Val(lstData.SelectedItems(0).SubItems(1).Text))
        End If
        Call validateControls()
    End Sub
    Private Sub lstData_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lstData.MouseDoubleClick
        If lstData.SelectedItems.Count > 0 Then
            Call mostrar()
        End If
        Call validateControls()
    End Sub
    Private Sub lstData_ColumnClick(sender As Object, e As ColumnClickEventArgs) Handles lstData.ColumnClick
        Call ordenar(e.Column)
        Call validateControls()
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
    Private Sub cmdCancelar_Click(sender As Object, e As EventArgs) Handles cmdCancelar.Click
        If isForm Then
            Me.Parent.Parent.Dispose()
        Else
            Me.Dispose()
        End If
    End Sub

    Private Function isSelected() As Boolean
        Dim i As Integer
        For i = 0 To lstData.Items.Count - 1
            If Not lstData.Items(i).Selected Then Return False
        Next
        Return True
    End Function
    Private Sub setSelected()
        For i As Integer = 0 To lstData.Items.Count - 1
            If Val(lstData.Items(i).SubItems(0).Text) = idActual Then
                lstData.Items(i).Selected = True
                Me.lstData.Select()
                Me.lstData.EnsureVisible(i)
                Exit For
            End If
        Next
    End Sub

    Private Sub mnuEliminar_Click(sender As Object, e As EventArgs) Handles mnuEliminar.Click
        If cmdEliminar.Enabled Then Call cmdEliminar_Click(sender, e)
    End Sub

    Private Sub cmdMostrar_Click(sender As Object, e As EventArgs) Handles cmdMostrar.Click
        If lstData.SelectedItems.Count > 0 Then
            Call mostrar()
        End If
        Call validateControls()
    End Sub

    Private Sub mnuMostrar_Click(sender As Object, e As EventArgs) Handles mnuMostrar.Click
        If lstData.SelectedItems.Count > 0 Then
            Call mostrar()
        End If
        Call validateControls()
    End Sub

    Private Sub mnoCopiar_Click(sender As Object, e As EventArgs) Handles mnoCopiar.Click
        If lstData.SelectedItems.Count > 0 Then
            Call copiar()
        End If
        Call validateControls()
    End Sub

    Private Sub cmdImprimirExcel_Click(sender As Object, e As EventArgs) Handles cmdImprimirExcel.Click
        'Call imprimir(False, dades, txtFiltrar.Text)
        Call imprimir(False, getlistData, txtFiltrar.Text)
    End Sub

    Private Sub cmdImprimirPDF_Click(sender As Object, e As EventArgs) Handles cmdImprimirPDF.Click
        Call imprimir(True, getListData, txtFiltrar.Text)
    End Sub
    Private Function getListData() As List(Of List(Of String))
        Dim i As Integer, j As Integer, r As List(Of String), d As List(Of List(Of String))
        d = New List(Of List(Of String))
        For i = 0 To lstData.Items.Count - 1
            r = New List(Of String)
            For j = 0 To lstData.Items(i).SubItems.Count - 1
                r.Add(lstData.Items(i).SubItems(j).Text)
            Next j
            d.Add(r)
        Next i
        Return d
    End Function
End Class
