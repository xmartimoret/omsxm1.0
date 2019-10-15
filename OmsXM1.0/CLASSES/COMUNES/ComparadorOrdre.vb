Public Class ComparadorOrdre : Implements IComparable
    Public Overridable Property ordre As String
    Public Overridable Property id As Integer = -1
    Public Overrides Function GetHashCode() As Integer
        Return _id
    End Function
    Public Overrides Function Equals(obj As Object) As Boolean
        If obj Is Nothing OrElse Not Me.GetType() Is obj.GetType Then Return False
        If _id = obj.id Then
            Return True
        End If
        Return False
    End Function
    Public Function CompareTo(obj As Object) As Integer Implements IComparable.CompareTo
        If obj Is Nothing OrElse Not Me.GetType Is obj.GetType Then Return -1
        If IsNumeric(_ordre) And IsNumeric(obj.ordre) Then
            If Val(_ordre) < Val(obj.ordre) Then
                Return -1
            ElseIf val(_ordre) > val(obj.ordre) Then
                Return 1
            Else
                Return 0
            End If
        Else
            Return StrComp(_ordre, obj.ordre, CompareMethod.Text)
        End If
    End Function
End Class
