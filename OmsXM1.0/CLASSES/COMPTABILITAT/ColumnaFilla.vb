Option Explicit On
Public Class ColumnaFilla : Implements IComparable

    Public Property idFilla As Integer
    Public Property idColumna As Integer
    Public Sub New()
        idFilla = -1
        idColumna = -1
    End Sub
    Public Sub New(pIdFilla As Integer, pIdColumna As Integer)
        idFilla = pIdFilla
        idColumna = pIdColumna
    End Sub
    Public ReadOnly Property id() As String
        Get
            Return "C" & _idColumna & "F" & _idFilla
        End Get
    End Property
    Public ReadOnly Property ordre() As String
        Get
            Return "C" & _idColumna & "F" & _idFilla
        End Get
    End Property
    Public Overrides Function gethashcode() As Integer
        Return 10 & _idColumna & 20 & _idFilla
    End Function

    Public Function CompareTo(obj As Object) As Integer Implements IComparable.CompareTo
        If obj Is Nothing OrElse Not Me.GetType Is obj.GetType Then Return -1
        Return StrComp(ordre, obj.ordre, CompareMethod.Text)
    End Function
End Class
