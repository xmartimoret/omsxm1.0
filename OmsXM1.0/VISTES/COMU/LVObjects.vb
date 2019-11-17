Public MustInherit Class LVObjects
    Private dades As DataList
    Private idsActual As List(Of Integer)
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
    Friend Event doubleClick()

    Public Sub New()
        InitializeComponent()
        Me.ContextMenuStrip = mnuContextual

        idsActual = New List(Of Integer)
        Me.lstData.Columns.Clear()

    End Sub

    Public MustOverride Function seleccionar(ids As List(Of Integer)) As Boolean
    Public MustOverride Function afegir(id As Integer) As Integer
    Public MustOverride Function modificar(id As Integer) As Integer
    Public MustOverride Function eliminar(id As Integer) As Boolean
    Public MustOverride Function filtrar(txt As String) As DataList
    Public MustOverride Function filtrar(idParent As Integer, txt As String) As DataList
    Private Sub setLanguage()
        Me.lblFiltrar.Text = IDIOMA.getString("filtrarPer")
        If accio = 0 Then
            tTip1.SetToolTip(cmdAfegir, IDIOMA.getString("cmdSeleccionar"))
        Else
            tTip1.SetToolTip(cmdAfegir, IDIOMA.getString("cmdAfegir"))
        End If
        tTip1.SetToolTip(cmdCancelar, IDIOMA.getString("cmdSortir"))
        tTip1.SetToolTip(cmdModificar, IDIOMA.getString("cmdModificar"))
        tTip1.SetToolTip(cmdEliminar, IDIOMA.getString("cmdEliminar"))
        tTip1.SetToolTip(cmdActualitzar, IDIOMA.getString("cmdActualitzar"))
        tTip1.SetToolTip(cmdImprimir, IDIOMA.getString("cmdImprimir"))
    End Sub
    Private Sub validateControls()
        If accio = 0 Then
            If idsActual.Count > 0 Or idActual > -1 Then
                Me.cmdAfegir.Enabled = True
            Else
                Me.cmdAfegir.Enabled = False
            End If
            Me.cmdModificar.Visible = False
            Me.cmdEliminar.Visible = False
            Me.cmdImprimir.Visible = False
        ElseIf accio = 1 Then
            Me.cmdAfegir.Enabled = True
            Me.cmdModificar.Visible = True
            Me.cmdEliminar.Visible = True
            Me.cmdImprimir.Visible = True
            If idsActual.Count > 0 Or idActual > 0 Then
                Me.cmdModificar.Enabled = True
                Me.cmdEliminar.Enabled = True
                Me.cmdImprimir.Enabled = True
            Else
                Me.cmdModificar.Enabled = False
                Me.cmdEliminar.Enabled = False
                Me.cmdImprimir.Enabled = True
            End If
        End If
        If multiselect Then
            If isSelected() Then
                multiselect = False
                xecTots.Checked = True
                multiselect = True
            Else
                xecTots.Checked = False
            End If
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
                Me.lblCount.Text = dades.rows.Count & " registres."
            End If
        End If

    End Sub
    Private Sub listViewXM_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call setLanguage()
        Me.lstData.MultiSelect = multiselect
        Me.lblTitol.Text = titol
        If multiselect Then
            xecTots.Visible = True
        Else
            xecTots.Visible = False
        End If
        Call setData()
        Call validateControls()

    End Sub
    Private Sub txtFiltrar_TextChanged(sender As Object, e As EventArgs) Handles txtFiltrar.TextChanged
        idsActual = New List(Of Integer)
        Call setData()
        Call validateControls()
    End Sub
    Private Sub cmdAfegir_Click(sender As Object, e As EventArgs) Handles cmdAfegir.Click
        Dim id As Integer
        If accio = 0 Then
            If seleccionar(idsActual) Then
                If isForm Then
                    Me.Parent.Parent.Dispose()
                Else
                    Me.Parent.Dispose()
                End If
                RaiseEvent doubleClick()
            End If
        Else
            Try
                id = afegir(idActual)
                If id > 0 Then
                    idActual = id
                    Call setData()
                    Call setSelected()
                    Call validateControls()
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, IDIOMA.getString("abort"))
            End Try

        End If
        Call validateControls()
    End Sub
    Private Sub cmdModificar_Click(sender As Object, e As EventArgs) Handles cmdModificar.Click
        Dim id As Integer
        id = modificar(idActual)
        If id > 0 Then
            idActual = id
            Call setData()
            Call setSelected()
        End If
        Call validateControls()
    End Sub
    Private Sub cmdEliminar_Click(sender As Object, e As EventArgs) Handles cmdEliminar.Click
        Try
            If eliminar(idActual) Then
                Call setData()
                idsActual = New List(Of Integer)
                idActual = 0

                Call validateControls()

            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, IDIOMA.getString("abort"))
        End Try
        Call validateControls()
    End Sub

    Private Sub lstData_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstData.SelectedIndexChanged
        Dim i As Integer, ids As List(Of Integer)
        If lstData.SelectedItems.Count > 0 Then
            If lstData.MultiSelect Then
                idsActual = New List(Of Integer)
                For i = 0 To lstData.Items.Count - 1
                    If lstData.Items(i).Selected Then
                        idsActual.Add(Val(lstData.Items(i).Text))
                    End If
                Next
                Call seleccionar(idsActual)
                idActual = Val(lstData.SelectedItems(0).Text)
            Else
                ids = New List(Of Integer)
                idActual = Val(lstData.SelectedItems(0).Text)
                ids.Add(idActual)
                Call seleccionar(ids)
                'Call setSelected()
            End If
        Else
            idsActual = New List(Of Integer)
            idActual = -1
        End If
        ids = Nothing
        Call validateControls()
    End Sub
    Private Sub lstData_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lstData.MouseDoubleClick
        If lstData.SelectedItems.Count > 0 Then
            idActual = Val(lstData.SelectedItems(0).Text)
            If accio = 0 Then
                Call seleccionar(idsActual)
                If isForm Then
                    Me.Parent.Parent.Dispose()
                Else
                    Me.Parent.Dispose()
                End If
                RaiseEvent doubleClick()
            Else
                Try
                    If modificar(idActual) Then Call setData() : Call setSelected()
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical, IDIOMA.getString("abort"))
                End Try

            End If
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

    Private Sub xecTots_CheckedChanged(sender As Object, e As EventArgs) Handles xecTots.CheckedChanged
        If multiselect Then
            If xecTots.Checked Then
                For i As Integer = 0 To lstData.Items.Count - 1
                    lstData.Items(i).Selected = True
                Next
            End If
            lstData.Select()
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

    Private Sub lstData_KeyDown(sender As Object, e As KeyEventArgs) Handles lstData.KeyDown
        If e.KeyValue = Keys.Enter Then
            If lstData.SelectedItems.Count > 0 Then
                idActual = Val(lstData.SelectedItems(0).Text)
                If accio = 0 Then
                    Call seleccionar(idsActual)
                Else
                    Try
                        If modificar(idActual) Then Call setData() : Call setSelected()
                    Catch ex As Exception
                        MsgBox(ex.Message, MsgBoxStyle.Critical, IDIOMA.getString("abort"))
                    End Try

                End If
            End If
            Call validateControls()
        End If
    End Sub

    Private Sub lblTitol_Click(sender As Object, e As EventArgs) Handles lblTitol.Click

    End Sub

    Private Sub mnoAfegir_Click(sender As Object, e As EventArgs) Handles mnoAfegir.Click
        If cmdAfegir.Enabled Then Call cmdAfegir_Click(sender, e)
    End Sub

    Private Sub mnoModificar_Click(sender As Object, e As EventArgs) Handles mnoModificar.Click
        If cmdModificar.Enabled Then Call cmdModificar_Click(sender, e)
    End Sub

    Private Sub mnuEliminar_Click(sender As Object, e As EventArgs) Handles mnuEliminar.Click
        If cmdEliminar.Enabled Then Call cmdEliminar_Click(sender, e)
    End Sub

    Private Sub mnuSortir_Click(sender As Object, e As EventArgs) Handles mnuSortir.Click
        If cmdCancelar.Enabled Then Call cmdCancelar_Click(sender, e)
    End Sub

    Private Sub mnuContextual_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles mnuContextual.Opening

    End Sub




    'Private Sub lstData_ColumnWidthChanged(sender As Object, e As ColumnWidthChangedEventArgs) Handles lstData.ColumnWidthChanged
    '    Dim i As Integer
    '    ReDim _columnsSize(lstData.Columns.Count)
    '    For i = 0 To lstData.Columns.Count - 1
    '        _columnsSize(i) = CInt(lstData.Columns(i).Width)
    '    Next
    'End Sub
End Class
















