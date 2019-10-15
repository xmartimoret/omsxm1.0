Option Explicit On
Public Class Tresoreria
    Inherits ComparadorOrdre

    Public Property idProjecte As Integer
    Private _ordre As String = ""
    Public Property concepte As String
    Public Property tipus As String
    Public Property base As Double
    Public Property esIngres As Boolean
    Public Property tipusIva As Integer = 21
    Public Property dataEmisio As Date
    Public Property dataVenciment As Date
    Public Sub New()

    End Sub
    Public Sub New(pId As Integer, pIdProjecte As Integer, pConcepte As String, pIngres As Boolean, pTipus As String, pBase As Double, pIva As Integer, pDataEM As Date, pDataVen As Date)
        Me.id = pId
        _idProjecte = pIdProjecte
        _concepte = pConcepte
        _esIngres = pIngres
        _tipusIva = pIva
        _base = pBase
        _dataEmisio = pDataEM
        _dataVenciment = pDataVen
    End Sub

    Public Overrides Property ordre() As String
        Get
            If _ordre = "" Then
                Return _dataVenciment
            Else
                Return _ordre
            End If
        End Get
        Set(value As String)
            _ordre = value
        End Set

    End Property
    Public ReadOnly Property iva() As Double
        Get
            Return Math.Round(_base * _tipusIva / 100, 2)
        End Get
    End Property

    Public ReadOnly Property total() As Double
        Get
            Return Math.Round(_base + iva, 2)
        End Get
    End Property
End Class
