Option Explicit On
Public Class SubcompteProveidor
    Inherits ComparadorOrdre
    Public Property codiSubcompte As Long
    Public Property nomProveidor As String
    Public Property assentaments As Collection
    Public Property assentaments401 As Collection
    Private _ordre As String
    Public Property euroDebe As Long
    Public Property euroHaber As Long
    Private Sub Class_Initialize()
        _assentaments = New Collection
        _assentaments401 = New Collection
    End Sub
    Public Overrides Property ordre() As String
        Get
            If _ordre <> "" Then
                Return _ordre
            Else
                Return _codiSubcompte
            End If
        End Get
        Set(value As String)
            _ordre = value
        End Set
    End Property
    Public ReadOnly Property calcularDebe() As Long
        Get
            Dim a As Assentament
            _euroDebe = 0
            For Each a In _assentaments
                _euroDebe = _euroDebe + a.deure
            Next a
            Return _euroDebe
            a = Nothing
        End Get
    End Property

    Public ReadOnly Property calcularHaber() As Long
        Get
            Dim a As Assentament
            _euroHaber = 0
            For Each a In _assentaments
                _euroHaber = _euroHaber + a.haver
            Next a
            calcularHaber = _euroHaber
            a = Nothing
        End Get
    End Property

    Public ReadOnly Property euroDebe401() As Long
        Get
            Dim a As Assentament
            euroDebe401 = 0
            For Each a In _assentaments401
                euroDebe401 = euroDebe401 + a.deure
            Next a
            a = Nothing
        End Get
    End Property

    Public ReadOnly Property euroHaber401() As Long
        Get
            Dim a As Assentament
            euroHaber401 = 0
            For Each a In _assentaments401
                euroHaber401 = euroHaber401 + a.haver
            Next a
            a = Nothing
        End Get
    End Property

    Public ReadOnly Property saldo() As Double
        Get
            Return Math.Round((_euroDebe - _euroHaber) / 100, 2)
        End Get
    End Property
    Public ReadOnly Property saldo401() As Double
        Get
            Return Math.Round((euroDebe401 - euroHaber401) / 100, 2)
        End Get
    End Property

    Public Overrides Function toString() As String
        Return _codiSubcompte & " - " & _nomProveidor
    End Function

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
        _assentaments = Nothing
        _assentaments401 = Nothing
    End Sub
End Class
