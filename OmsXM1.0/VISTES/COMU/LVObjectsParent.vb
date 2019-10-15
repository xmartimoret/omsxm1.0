Public MustInherit Class LVObjectsParent
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
    Private objects As List(Of Object)
    Public Sub New()
        InitializeComponent()
        idsActual = New List(Of Integer)
        Me.lstData.Columns.Clear()
    End Sub
    Public MustOverride Function seleccionar(ids As List(Of Integer)) As Boolean
    Public MustOverride Function afegir(id As Integer) As Boolean
    Public MustOverride Function modificar(id As Integer) As Boolean
    Public MustOverride Function eliminar(id As Integer) As Boolean
    Public MustOverride Function filtrar(idParent As Integer, txt As String) As DataList
    Private Sub setLanguage()
        Me.lblFiltrar.Text = IDIOMA.getString("filtrarPer")
        If accio = 0 Then
            Me.cmdAfegir.Text = IDIOMA.getString("cmdSeleccionar")
        Else
            Me.cmdAfegir.Text = IDIOMA.getString("cmdAfegir")
        End If
        Me.cmdCancelar.Text = IDIOMA.getString("cmdCancelar")
        Me.cmdModificar.Text = IDIOMA.getString("cmdModificar")
        Me.cmdEliminar.Text = IDIOMA.getString("cmdEliminar")
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
        ElseIf accio = 1 Then
            Me.cmdAfegir.Enabled = True
            Me.cmdModificar.Visible = True
            Me.cmdEliminar.Visible = True
            If idsActual.Count > 0 Or idActual > -1 Then
                Me.cmdModificar.Enabled = True
                Me.cmdEliminar.Enabled = True
            Else
                Me.cmdModificar.Enabled = False
                Me.cmdEliminar.Enabled = False
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
        dades = filtrar(idParent, Me.txtFiltrar.Text)
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
    End Sub
    Private Sub cmdAfegir_Click(sender As Object, e As EventArgs) Handles cmdAfegir.Click
        If accio = 0 Then
            If seleccionar(idsActual) Then
                If isForm Then
                    Me.Parent.Parent.Dispose()
                Else
                    Me.Parent.Dispose()
                End If
            End If
        Else
            Try
                If afegir(idActual) Then
                    Call setData()
                    Call validateControls()
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, IDIOMA.getString("abort"))
            End Try

        End If
    End Sub
    Private Sub cmdModificar_Click(sender As Object, e As EventArgs) Handles cmdModificar.Click
        Try
            If modificar(idActual) Then
                Call setData()
                Call validateControls()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, IDIOMA.getString("abort"))
        End Try

    End Sub
    Private Sub cmdEliminar_Click(sender As Object, e As EventArgs) Handles cmdEliminar.Click
        Try
            If eliminar(idActual) Then
                Call setData()
                Call validateControls()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, IDIOMA.getString("abort"))
        End Try
    End Sub

    Private Sub lstData_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstData.SelectedIndexChanged
        Dim i As Integer
        If lstData.SelectedItems.Count > 0 Then
            If lstData.MultiSelect Then
                idsActual = New List(Of Integer)
                For i = 0 To lstData.Items.Count - 1
                    If lstData.Items(i).Selected Then
                        idsActual.Add(Val(lstData.Items(i).Text))
                    End If
                Next
                idActual = Val(lstData.SelectedItems(0).Text)
            Else
                idActual = Val(lstData.SelectedItems(0).Text)
            End If
        End If
        Call validateControls()
    End Sub
    Private Sub lstData_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lstData.MouseDoubleClick
        If lstData.SelectedItems.Count > 0 Then
            idActual = Val(lstData.SelectedItems(0).Text)
            If accio = 0 Then
                Call seleccionar(idsActual)
            Else
                Try
                    If modificar(idActual) Then Call setData()
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical, IDIOMA.getString("abort"))
                End Try

            End If
        End If
        Call validateControls()
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
End Class
