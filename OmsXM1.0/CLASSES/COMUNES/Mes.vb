Public Class Mes : Implements IComparable
    Public Property num As Integer
    Public Property nom As String
    Public Property anyo As Integer
    Public Sub New()

    End Sub
    Public Sub New(pNum As Integer, pNom As String)
        _num = pNum
        _nom = pNom
    End Sub
    Public Sub New(pNum As Integer, pNom As String, pAny As Integer)
        _num = pNum
        _nom = pNom
        _anyo = pAny
    End Sub
    Public Function CompareTo(obj As Object) As Integer Implements IComparable.CompareTo
        If obj Is Nothing OrElse Not Me.GetType Is obj.GetType Then Return -1
        If IsNumeric(_num) And IsNumeric(obj.num) Then
            If Val(_num) < Val(obj.num) Then
                Return -1
            ElseIf Val(_num) > Val(obj.num) Then
                Return 1
            Else
                Return 0
            End If
        Else
            Return 0
        End If
    End Function
    Public Overrides Function ToString() As String
        If _anyo = 0 Then
            Return _nom
        Else
            Return _nom & " " & _anyo
        End If
    End Function
End Class
