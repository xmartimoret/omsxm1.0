Option Explicit On
Public MustInherit Class LVSubObjects2
    Private dades As DataList
    Private idActual As String = "-1" ' estic aqui cal veure pq no puc guardar com string i pq no refresca.
    Private mSortingColumn As ColumnHeader
    Private captionAfegir As String
    Private captionModificar As String
    Private CaptionEliminar As String
    Private numElements As Integer
    Friend Property idParent As Integer
    Friend Property titol As String
    Friend Property orderColumn As Integer = 0
    Private objects As List(Of Object)
    Public Sub New()
        InitializeComponent()
        Me.lstData.Columns.Clear()
        captionAfegir = IDIOMA.getString("cmdAfegir")
        captionModificar = IDIOMA.getString("cmdModificar")
        CaptionEliminar = IDIOMA.getString("cmdEliminar")
        numElements = 0
    End Sub
    Public Sub New(pIScmdAfegir As Boolean, pIScmdModificar As Boolean, pIScmdEliminar As Boolean, Optional pCaptionAfegir As String = "", Optional pCaptionModificar As String = "", Optional pCaptionEliminar As String = "", Optional pMultiselect As Boolean = False)
        InitializeComponent()
        Me.lstData.Columns.Clear()
        Me.lstData.MultiSelect = pMultiselect
        Me.cmdAfegir.Visible = pIScmdAfegir
        Me.cmdModificar.Visible = pIScmdModificar
        Me.cmdEliminar.Visible = pIScmdEliminar
        captionAfegir = IDIOMA.getString("cmdAfegir")
        captionModificar = IDIOMA.getString("cmdModificar")
        CaptionEliminar = IDIOMA.getString("cmdEliminar")
        If pCaptionAfegir <> "" Then captionAfegir = pCaptionAfegir
        If pCaptionModificar <> "" Then captionModificar = pCaptionModificar
        If pCaptionEliminar <> "" Then CaptionEliminar = pCaptionEliminar
        numElements = 0
    End Sub
    Public MustOverride Function seleccionar(id As String) As Boolean
    Public MustOverride Function afegir(id As String, idParent As String) As Boolean
    Public MustOverride Function modificar(id As String) As Boolean
    Public MustOverride Function eliminar(ids As List(Of String)) As Boolean
    Public MustOverride Function filtrar(id As String) As DataList
    Public MustOverride Function canviarOrdre(id1 As String, id2 As String) As Boolean
    Private Sub setLanguage()
        Me.cmdAfegir.Text = captionAfegir
        Me.cmdModificar.Text = captionModificar
        Me.cmdEliminar.Text = CaptionEliminar
        Me.lblOrdre.Text = IDIOMA.getString("ordre")
    End Sub
    Private Sub validateControls()
        Dim indexData As Integer
        indexData = getSelectedIndex()
        Me.cmdAfegir.Enabled = True
        Me.cmdEliminar.Enabled = True
        If indexData <> "-1" Then
            Me.cmdModificar.Enabled = True
            Me.cmdEliminar.Enabled = True
        Else
            Me.cmdModificar.Enabled = False
            Me.cmdEliminar.Enabled = False
        End If
        If indexData = -1 Then
            cmdAnterior.Enabled() = False
            cmdSeguent.Enabled() = False
        ElseIf lstData.Items.Count = 1 Then
            cmdAnterior.Enabled() = False
            cmdSeguent.Enabled() = False
        ElseIf indexData = 0 Then
            cmdAnterior.Enabled() = False
            cmdSeguent.Enabled() = True
        ElseIf indexdata = lstData.Items.Count - 1 Then
            cmdAnterior.Enabled() = True
            cmdSeguent.Enabled() = False
        Else
            cmdAnterior.Enabled() = True
            cmdSeguent.Enabled() = True
        End If
    End Sub
    Private Sub setDataColumns()
        For Each c As ColumnHeader In dades.columns
            Me.lstData.Columns.Add(c)
        Next
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
                Call escollir(idActual)
                Me.lblCount.Text = dades.rows.Count & " registres."
            End If
        End If
        numElements = dades.rows.Count
    End Sub
    Private Sub listViewXM_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call setLanguage()

        Me.lblTitol.Text = titol
        Call setData()
        Call validateControls()
    End Sub

    Private Sub cmdAfegir_Click(sender As Object, e As EventArgs) Handles cmdAfegir.Click
        Try
            If afegir(idActual, idParent) Then
                Call setData()
                Call validateControls()
            End If
        Catch ex As ExcepcioSql
            Call ERRORS.ERR_EXCEPTION_SQL(ex.Message)
        End Try

    End Sub
    Private Sub cmdModificar_Click(sender As Object, e As EventArgs) Handles cmdModificar.Click
        If modificar(idActual) Then
            Call setData()
            Call validateControls()
        End If
    End Sub
    Private Sub cmdEliminar_Click(sender As Object, e As EventArgs) Handles cmdEliminar.Click
        Try

            If eliminar(getSelectedsIndex) Then
                Call setData()
                Call validateControls()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, IDIOMA.getString("abort"))
        End Try
    End Sub

    Private Sub lstData_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstData.SelectedIndexChanged
        If lstData.SelectedItems.Count > 0 Then
            If seleccionar((lstData.SelectedItems(0).Text)) Then
                idActual = (lstData.SelectedItems(0).Text)
            End If
        End If
        Call validateControls()
    End Sub

    Private Sub lstData_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lstData.MouseDoubleClick
        If modificar(idActual) Then Call setData()
        Call validateControls()
    End Sub

    'Private Sub lstData_ColumnClick(sender As Object, e As ColumnClickEventArgs) Handles lstData.ColumnClick
    '    If lstData.Columns.Count >= e.Column Then Call sorted(e.Column)
    'End Sub

    Private Sub sorted(c As Integer)
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
    Private Sub txtFiltrar_TextChanged(sender As Object, e As EventArgs)
        Call setData()
        idActual = 0
        Call setDataRows()
    End Sub
    Public Sub escollir(id As String)
        Dim i As Integer
        For i = 0 To Me.lstData.Items.Count - 1
            If Me.lstData.Items(i).Text = id Then
                Me.lstData.Items(i).Selected = True
                Me.lstData.Select()
                Me.lstData.EnsureVisible(i)
                Return
            End If
        Next
    End Sub
    Private Function getSelectedIndex() As String
        Dim i As Integer
        For i = 0 To lstData.Items.Count - 1
            If lstData.Items(i).Text = idActual Then
                Return i
            End If
        Next
        Return -1
    End Function
    Private Function getSelectedId() As String
        Dim i As Integer
        For i = 0 To lstData.Items.Count - 1
            If lstData.Items(i).Text = idActual Then
                Return lstData.Items(i).Text
            End If
        Next
        Return Nothing
    End Function

    Private Function getNextSelectedId() As String
        Dim i As Integer
        For i = 0 To lstData.Items.Count - 1
            If lstData.Items(i).Text = idActual Then
                Return lstData.Items(i + 1).Text
            End If
        Next
        Return Nothing
    End Function
    Private Function getPreSelectedId() As String
        Dim i As Integer
        For i = 0 To lstData.Items.Count - 1
            If lstData.Items(i).Text = idActual Then
                Return lstData.Items(i - 1).Text
            End If
        Next
        Return Nothing
    End Function
    Private Function getSelectedsIndex() As List(Of String)
        Dim i As Integer
        getSelectedsIndex = New List(Of String)
        For i = 0 To lstData.Items.Count - 1
            If lstData.Items(i).Selected Then
                getSelectedsIndex.Add(lstData.Items(i).Text)
            End If
        Next
    End Function

    Private Sub cmdAnterior_Click(sender As Object, e As EventArgs) Handles cmdAnterior.Click
        If canviarOrdre(getSelectedId, getPreSelectedId) Then
            Call setData()
            Call validateControls()
        End If
    End Sub

    Private Sub cmdSeguent_Click(sender As Object, e As EventArgs) Handles cmdSeguent.Click
        If canviarOrdre(getSelectedId, getNextSelectedId) Then
            Call setData()
            Call validateControls()
        End If
    End Sub

End Class

