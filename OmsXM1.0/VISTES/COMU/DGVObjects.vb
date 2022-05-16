Public MustInherit Class DGVObjects
    Private _isRowCaption As Boolean
    Private groupFiles As Integer
    Public MustOverride Function getColumns() As List(Of CodiDescripcio)
    Public MustOverride Function getRows() As List(Of List(Of CodiDescripcio))
    Public MustOverride Sub setData(c As String, f As String)
    Public MustOverride Sub resetData()
    Public Sub New(pIsRowCaption As Boolean)
        InitializeComponent()
        _isRowCaption = pIsRowCaption
    End Sub
    Public Sub New(pIsRowCaption As Boolean, pGroupFiles As Integer)
        InitializeComponent()
        _isRowCaption = pIsRowCaption
        groupFiles = pGroupFiles
    End Sub
    Friend Sub setColumnRow()
        Dim c As CodiDescripcio, d As DataGridViewColumn, cella As DataGridViewCell, cella1 As DataGridViewCell
        Dim f As List(Of CodiDescripcio), r As DataGridViewRow
        Me.dgvData.Columns.Clear()
        Me.dgvData.Rows.Clear()
        cella = New DataGridViewTextBoxCell()
        cella1 = New DataGridViewTextBoxCell()

        cella.Style.BackColor = SystemColors.Info
        cella.Style.Font = New Font("arial", 9, FontStyle.Bold)
        cella.Style.Alignment = DataGridViewContentAlignment.MiddleLeft

        cella1.Style.Font = New Font("tahoma", 8, FontStyle.Regular)
        cella1.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        cella1.Style.Format = "#,##0.00;(#,##0.00)"

        If _isRowCaption Then
            d = New DataGridViewColumn
            d.CellTemplate = cella
            d.HeaderCell.Style.BackColor = SystemColors.Info
            Me.dgvData.Columns.Add(d)
        End If
        For Each c In getColumns()
            d = New DataGridViewColumn
            d.HeaderText = UCase(c.codi)
            d.ToolTipText = c.descripcio
            d.HeaderCell.Style.BackColor = SystemColors.Info
            d.CellTemplate = cella1
            Me.dgvData.Columns.Add(d)
        Next
        Me.dgvData.Columns(0).Frozen = True
        Me.dgvData.Rows.Clear()
        r = Nothing
        For Each f In getRows()
            r = New DataGridViewRow
            r.CreateCells(dgvData)
            Me.dgvData.Rows.Add(r)
        Next

        If cella IsNot Nothing Then cella.Dispose()
        If cella1 IsNot Nothing Then cella1.Dispose()
        c = Nothing
        If r IsNot Nothing Then r.Dispose()
    End Sub
    Friend Sub setData()
        Dim f As List(Of CodiDescripcio), j As Integer, i As Integer, c As CodiDescripcio, d As Integer, loadColor As Boolean
        i = 0
        For Each f In getRows()
            j = 0
            If d = groupFiles Then
                d = 0
                loadColor = Not loadColor
            End If
            For Each c In f

                If IsNumeric(c.codi) Then
                    dgvData.Rows(i).Cells(j).Value = CDbl(c.codi)
                    If c.codi < 0 Then
                        dgvData.Rows(i).Cells(j).Style.ForeColor = Color.Red
                    Else
                        dgvData.Rows(i).Cells(j).Style.ForeColor = Color.Black
                    End If
                    If groupFiles > 0 Then

                        If d = groupFiles - 1 Then
                            dgvData.Rows(i).Cells(j).Style.BackColor = SystemColors.Info
                        End If
                    End If
                Else
                    dgvData.Rows(i).Cells(j).Value = c.codi
                    dgvData.Rows(i).Cells(j).ToolTipText = c.descripcio
                    dgvData.Rows(i).Cells(j).Style.ForeColor = Color.Black
                End If


                j = j + 1
            Next
            d = d + 1
            i = i + 1
        Next
    End Sub


    Private Sub dgvData_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvData.CellEnter
        If e.ColumnIndex > -1 And e.RowIndex > -1 Then
            Call setData(dgvData.Columns(e.ColumnIndex).HeaderText, dgvData.Rows(e.RowIndex).Cells(0).Value)
        Else
            Call resetData()
        End If
    End Sub


End Class
