Option Explicit On
Public Class Transitoria
    Public Property mes As Integer
    Public Property anyo As Integer
    Public Property idEmpresa As Integer
    Public Property idProjecte As Integer
    Public Property codiYellowSheet As String
    Public Property idSubcompte As Integer
    Public Property valorAS As Double
    Public Property valorAAnterior As Double
    Public Property valorAActual As Double
    Public Property valorSAnterior As Double
    Public Property valorSActual As Double
    Public Property ordre As String
    Public Sub New()

    End Sub
    Public Sub New(pMes As Integer, pAnyo As Integer, pIdempresa As Integer, pIdProjecte As Integer,
                   pCodiYellowSheet As String, pIdSubcompte As Integer, pValorAS As Double,
                   pValorAAnterior As Double, pValorAActual As Double, pValorSAnterior As Double,
                   pValorSActual As Double)
        _mes = pMes
        _anyo = pAnyo
        _idEmpresa = pIdempresa
        _idProjecte = pIdProjecte
        _codiYellowSheet = pCodiYellowSheet
        _idSubcompte = pIdSubcompte
        _valorAS = pValorAS
        _valorAAnterior = pValorAAnterior
        _valorAActual = pValorAActual
        _valorSAnterior = pValorSAnterior
        _valorSActual = pValorSActual
    End Sub
    Public ReadOnly Property id() As String
        Get
            Return _anyo & _mes & "P" & _idProjecte & "S" & _idSubcompte
        End Get
    End Property



    Public ReadOnly Property codiAcrualsAny() As String
        Get
            Return "A" & Right(_anyo, 2)
        End Get
    End Property

    Public ReadOnly Property codiSafetiesAny() As String
        Get
            Return "S" & Right(_anyo, 2)
        End Get
    End Property


    Public ReadOnly Property codiAcrualsAnyAnterior() As String
        Get
            Return "A" & Right(_anyo - 1, 2)
        End Get

    End Property

    Public ReadOnly Property codiSafetiesAnyAnterior() As String
        Get
            Return "S" & Right(_anyo - 1, 2)
        End Get

    End Property
    Public ReadOnly Property codiAcrualsSafetiesAny() As String
        Get
            Return "AS" & Right(_anyo, 2) & Right(_anyo - 1, 2)
        End Get

    End Property
    Public ReadOnly Property isCode(codi As String) As Boolean
        Get
            If codi = codiAcrualsAny Or codi = codiSafetiesAny Or codi = codiAcrualsAnyAnterior Or codi = codiSafetiesAnyAnterior Or codi = codiAcrualsSafetiesAny Then
                isCode = True
            Else
                isCode = False
            End If
        End Get
    End Property




End Class
