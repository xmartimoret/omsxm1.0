Option Explicit On
Public Class ProjecteColumna : Implements IComparable
    Public Property idProjecte As Integer
    Public Property idColumna As Integer
    Public Sub New()

    End Sub
    Public Sub New(pIdProjecte As Integer, pIdColumna As Integer)
        _idProjecte = pIdProjecte
        _idColumna = pIdColumna
    End Sub
    Public ReadOnly Property id() As String
        Get
            Return "C" & _idColumna & "P" & _idProjecte
        End Get
    End Property

    Public Function CompareTo(obj As Object) As Integer Implements IComparable.CompareTo
        If obj Is Nothing OrElse Not Me.GetType Is obj.GetType Then Return -1
        Return StrComp(id, obj.id)
    End Function
End Class
