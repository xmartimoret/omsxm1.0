Option Explicit On
Public Class ValorMes
    Public Property any As Integer
    Public Property mes As Integer
    Public _valor As Double
    Public Property idSubcompte As Integer
    Public Property idSubgrup As Integer
    Public Property codiSubcompte As Long
    Public Property idProjecte As Integer
    Public Property idEmpresa As Integer
    Public Property actualitzat As Boolean
    Public Sub New()

    End Sub
    Public Sub New(pAny As Integer, pMes As Integer, pIdProjecte As Integer, pIdSubcompte As Integer, pIdEmpresa As Integer, pIdSubgrup As Integer, pValor As Double)
        _any = pAny
        _mes = pMes
        _valor = pValor
        _idSubcompte = pIdSubcompte
        _idSubgrup = pIdSubgrup
        _idProjecte = pIdProjecte
        _idEmpresa = pIdEmpresa

    End Sub
    Public ReadOnly Property id() As String
        Get
            Dim tempMes As String
            If _mes < 10 Then
                tempMes = "0" & _mes
            Else
                tempMes = _mes
            End If
            If _idSubgrup > 0 Then
                id = _any & tempMes & "SG" & _idSubgrup & "P" & _idProjecte
            Else
                id = _any & tempMes & "S" & _idSubcompte & "P" & _idProjecte
            End If
        End Get
    End Property
    Public ReadOnly Property ordre As String
        Get
            Return id
        End Get
    End Property
    Public Property valor() As Double
        Get
            valor = Math.Round(_valor, 2)
        End Get
        Set(value As Double)
            _valor = value
        End Set
    End Property

End Class
