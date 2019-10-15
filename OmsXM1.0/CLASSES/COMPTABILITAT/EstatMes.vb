Option Explicit On
Public Class EstatMes : Implements IComparable
    Public Property mes As Integer
    Public Property anyo As Integer
    Public Property idEmpresa As Integer
    Public Property estat As Boolean
    Public Property estatTransitoria As Boolean
    Public Sub New()

    End Sub
    Public Sub New(pMes As Integer, pAny As Integer, pIDEmpresa As Integer, pEstat As Boolean, pTransitoria As Boolean)
        _mes = pMes
        _anyo = pAny
        _idEmpresa = pIDEmpresa
        _estat = pEstat
        _estatTransitoria = pTransitoria
    End Sub
    Public ReadOnly Property id() As String
        Get
            Return "M" & _mes & "A" & _anyo & "E" & _idEmpresa
        End Get
    End Property
    Public ReadOnly Property ordre() As String
        Get
            If _mes < 10 Then
                ordre = "" & _anyo & "0" & _mes
            Else
                ordre = "" & _anyo & _mes
            End If
        End Get
    End Property

    Public Function CompareTo(obj As Object) As Integer Implements IComparable.CompareTo
        If obj Is Nothing OrElse Not Me.GetType Is obj.GetType Then Return -1
        If IsNumeric(ordre) And IsNumeric(obj.ordre) Then
            If ordre < obj.ordre Then
                Return -1
            ElseIf ordre > obj.ordre Then
                Return 1
            Else
                Return 0
            End If
        Else
            Return StrComp(ordre, obj.ordre)
        End If
    End Function
End Class
