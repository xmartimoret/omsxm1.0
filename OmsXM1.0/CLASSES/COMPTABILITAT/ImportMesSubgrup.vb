Option Explicit On
Public Class ImportMesSubgrup : Implements IComparable
    Public Property mes As Integer
    Public Property anyo As Integer
    Public Property valor As Double
    Public Property idCentre As Integer
    Public Property idSubgrup As Integer
    Public Property codiGrup As String
    Public Property isPretancament As Boolean
    Public Property tipusDades As String
    Public Sub New()

    End Sub
    Public Sub New(pAnyo As Integer, pMes As Integer, pidCentre As Integer, pIdSubgrup As Integer, pValor As Double, pTipusDades As String, pCodiGrup As String)
        _anyo = pAnyo
        _mes = pMes
        _idCentre = pidCentre
        _idSubgrup = pIdSubgrup
        _valor = pValor
        _tipusDades = pTipusDades
        _codiGrup = pCodiGrup
    End Sub
    Public ReadOnly Property ordre() As Integer
        Get
            If _mes < 10 Then
                ordre = CInt(_anyo & "0" & _mes)
            Else
                ordre = CInt(_anyo & _mes)
            End If
        End Get
    End Property
    Public Function CompareTo(obj As Object) As Integer Implements IComparable.CompareTo
        If obj Is Nothing OrElse Not Me.GetType Is obj.GetType Then Return -1
        If ordre < obj.ordre Then
            Return -1
        ElseIf ordre > obj.ordre Then
            Return 1
        Else
            Return 0
        End If
    End Function
End Class
