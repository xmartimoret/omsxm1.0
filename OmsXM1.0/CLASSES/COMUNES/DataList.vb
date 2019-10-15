Public Class DataList
    Public Property rows As List(Of ListViewItem)
    Public Property columns As List(Of ColumnHeader)
    Public Sub New()
        _rows = New List(Of ListViewItem)
        _columns = New List(Of ColumnHeader)
    End Sub
    Public Sub New(pColumns As List(Of ColumnHeader))
        _rows = New List(Of ListViewItem)
        _columns = pColumns
    End Sub
    Public Sub New(pRows As List(Of ListViewItem), pColumns As List(Of ColumnHeader))
        _rows = pRows
        _columns = pColumns
    End Sub
    Public Function getArrayColumns() As ColumnHeader()
        Dim c As ColumnHeader, i As Integer = 0, cs As ColumnHeader()
        ReDim cs(_columns.Count - 1)
        For Each c In _columns
            cs(i) = c
            i = +1
        Next
        c = Nothing
        Return cs
    End Function
End Class
