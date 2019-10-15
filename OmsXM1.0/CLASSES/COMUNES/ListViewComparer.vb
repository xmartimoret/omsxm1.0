Public Class ListViewComparer
    Implements IComparer
    Private nColumn As Integer
    Private msortOrder As SortOrder
    Public Sub New(ByVal column_number As Integer, ByVal _
        sort_order As SortOrder)
        nColumn = column_number
        msortOrder = sort_order
    End Sub
    Public Function Compare(x As Object, y As Object) As Integer Implements IComparer.Compare
        Dim item_x As ListViewItem = DirectCast(x, ListViewItem)
        Dim item_y As ListViewItem = DirectCast(y, ListViewItem)
        ' Get the sub-item values.
        Dim string_x As String
        If item_x.SubItems.Count <= nColumn Then
            string_x = ""
        Else
            string_x = item_x.SubItems(nColumn).Text
        End If

        Dim string_y As String
        If item_y.SubItems.Count <= nColumn Then
            string_y = ""
        Else
            string_y = item_y.SubItems(nColumn).Text
        End If

        ' Compare them.
        If msortOrder = SortOrder.Ascending Then
            If IsNumeric(string_x) And IsNumeric(string_y) _
                Then
                Return Val(string_x).CompareTo(Val(string_y))
            ElseIf IsDate(string_x) And IsDate(string_y) _
                Then
                Return DateTime.Parse(string_x).CompareTo(DateTime.Parse(string_y))
            Else
                Return String.Compare(string_x, string_y)
            End If
        Else
            If IsNumeric(string_x) And IsNumeric(string_y) _
                Then
                Return Val(string_y).CompareTo(Val(string_x))
            ElseIf IsDate(string_x) And IsDate(string_y) _
                Then
                Return DateTime.Parse(string_y).CompareTo(DateTime.Parse(string_x))
            Else
                Return String.Compare(string_y, string_x)
            End If
        End If
    End Function
End Class

