Option Explicit On
Public Class AssentamentTransitoria
    Public Property fecha As Date
    Public Property fechaExtorn As Date
    Public Property concepte As String
    Public Property concepteExtorn As String
    Public Property document As String
    Private _nomFitxer As String
    Private _nomFitxerExtorn As String
    Public Property ruta As String
    Public Property assentaments As Collection
    Public Property assentamentsExtorn As Collection
    Public Property subcteSaldoDeure As String
    Public Property subcteSaldoHaver As String
    Public Property isUnFitxer As Boolean
    Public Sub New()
        _assentaments = New Collection
        _assentamentsExtorn = New Collection
        _IsUnFitxer = False
    End Sub


    Public Property nomFitxerExtorn() As String
        Get
            Return _nomFitxerExtorn
        End Get
        Set(value As String)
            If LCase(Right(value, 4)) <> ".dbf" Then
                _nomFitxerExtorn = value & ".dbf"
            Else
                _nomFitxerExtorn = value
            End If
        End Set
    End Property


    Public Property nomFitxer() As String
        Get
            Return _nomFitxer
        End Get
        Set(value As String)
            If Right(value, 4) <> ".dbf" Then
                _nomFitxer = value & ".dbf"
            Else
                _nomFitxer = value
            End If
        End Set
    End Property

    Public ReadOnly Property pathFitxer() As String
        Get
            Return CONFIG.setFolder(_ruta) & _nomFitxer
        End Get
    End Property

    Public ReadOnly Property pathFitxerExtorn() As String
        Get
            Return CONFIG.setFolder(_ruta) & _nomFitxerExtorn
        End Get
    End Property
    Public ReadOnly Property saldoCompres() As Double
        Get
            Dim a As Assentament
            saldoCompres = 0
            For Each a In _assentaments
                If Left(a.subcompteAssentament, 1) = "6" Then
                    saldoCompres = saldoCompres + a.saldo
                End If
            Next a
        End Get
    End Property
    Public ReadOnly Property saldoVendes() As Double
        Get
            Dim a As Assentament
            saldoVendes = 0
            For Each a In _assentaments
                If Left(a.subcompteAssentament, 1) = "7" Then
                    saldoVendes = saldoVendes + a.saldo
                End If
            Next a
        End Get
    End Property

    Public ReadOnly Property saldoCompresExtorn() As Double
        Get
            Dim a As Assentament
            For Each a In _assentamentsExtorn
                If Left(a.subcompteAssentament, 1) = "6" Then
                    saldoCompresExtorn = saldoCompresExtorn + a.saldo
                End If
            Next a
            saldoCompresExtorn = saldoCompresExtorn * -1
        End Get
    End Property
    Public ReadOnly Property saldoVendesExtorn() As Double
        Get
            Dim a As Assentament
            For Each a In _assentamentsExtorn
                If Left(a.subcompteAssentament, 1) = "7" Then
                    saldoVendesExtorn = saldoVendesExtorn + a.saldo
                End If
            Next a
            saldoVendesExtorn = saldoVendesExtorn * -1
        End Get
    End Property
    Protected Overrides Sub Finalize()
        MyBase.Finalize()
        _assentaments = Nothing
        _assentamentsExtorn = Nothing
    End Sub
End Class
