Public Class SeccioGrup : Implements IComparable
    Public Property idSeccio As Integer
    Public Property idGrup As Integer
    Private _ordre As String
    Public Sub New()

    End Sub
    Public Sub New(pIdseccio As Integer, pIdGrup As Integer)
        _idSeccio = pIdseccio
        _idGrup = pIdGrup
    End Sub
    Public Overrides Function GetHashCode() As Integer
        Return id
    End Function
    Public Overrides Function Equals(obj As Object) As Boolean
        If obj Is Nothing OrElse Not Me.GetType() Is obj.GetType Then Return False
        If id = obj.id Then
            Return True
        End If
        Return False
    End Function
    Public Property ordre() As String
        Get
            If _ordre = "" Then
                ordre = _idGrup
            Else
                ordre = _ordre
            End If
        End Get
        Set(value As String)
            _ordre = value
        End Set
    End Property
    Public ReadOnly Property id() As String
        Get
            Return "'G" & _idGrup & "S" & _idSeccio
        End Get
    End Property
    Public Function CompareTo(obj As Object) As Integer Implements IComparable.CompareTo
        If obj Is Nothing OrElse Not Me.GetType Is obj.GetType Then Return -1
        If IsNumeric(_ordre) And IsNumeric(obj.ordre) Then
            If _ordre < obj.ordre Then
                Return -1
            ElseIf _ordre > obj.ordre Then
                Return 1
            Else
                Return 0
            End If
        Else
            Return StrComp(_ordre, obj.ordre)
        End If
    End Function
End Class
