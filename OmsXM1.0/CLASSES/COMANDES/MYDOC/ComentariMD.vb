Public Class ComentariMD : Implements IComparable
    Public Property id As Integer
    Public Property dataIni As Date
    Public Property loginUsuari As String = ""
    Public Property idRecurs As Integer
    Public Property comentari As String
    Public Sub New()
        _id = -1
        _dataIni = Now
    End Sub
    Public Sub New(pID As Long, pIdUsuari As String, pDataIni As Date)
        _id = pID
        _loginUsuari = pIdUsuari
        _dataIni = pDataIni
    End Sub
    Public Sub New(pID As Long, pIdUsuari As String, pDataIni As Date, pIdRecurs As Integer)
        _id = pID
        _loginUsuari = pIdUsuari
        _dataIni = pDataIni
        _idRecurs = pIdRecurs
    End Sub
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
        If IsDate(_dataIni) And IsDate(obj.dataIni) Then
            If _dataIni < obj.dataIni Then
                Return -1
            ElseIf _dataIni > obj.dataini Then
                Return 1
            Else
                Return 0
            End If
        Else
            Return 0
        End If
    End Function
End Class
