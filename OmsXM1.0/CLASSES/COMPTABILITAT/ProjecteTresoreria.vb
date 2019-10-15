Option Explicit On
Public Class ProjecteTresoreria
    Private _ordre As String = ""
    Public Property idProjecte As Integer
    Public Property importsTresoreria As List(Of Tresoreria)
    Public Property codiProjecte As String
    Public Property nomProjecte As String
    Public Property codiCentre As String
    Public Sub New()
        _importsTresoreria = New List(Of Tresoreria)
    End Sub
    Public ReadOnly Property id As Integer
        Get
            Return _idProjecte
        End Get
    End Property
    Public Property ordre() As String
        Get
            If _ordre <> "" Then
                Return _ordre
            Else
                Return _codiProjecte
            End If
        End Get
        Set(value As String)
            _ordre = value
        End Set

    End Property
    Public Overrides Function toString() As String
        Return _codiProjecte & "-" & _nomProjecte
    End Function

    Public ReadOnly Property totalBase(esCobro As Boolean, dataInicial As Date, dataFinal As Date) As Double
        Get
            Dim t As Tresoreria, valor As EnterLlarg
            valor = New EnterLlarg
            For Each t In _importsTresoreria
                If t.esIngres = esCobro Then
                    If t.dataVenciment >= dataInicial And t.dataVenciment <= dataFinal Then valor.valordecimal = t.base
                End If
            Next t
            totalBase = valor.valordecimal
            valor = Nothing
            t = Nothing
        End Get
    End Property

    Public ReadOnly Property totalIva(esCobro As Boolean, dataInicial As Date, dataFinal As Date) As Double
        Get
            Dim t As Tresoreria, valor As EnterLlarg
            valor = New EnterLlarg
            For Each t In _importsTresoreria
                If t.esIngres = esCobro Then
                    If t.dataVenciment >= dataInicial And t.dataVenciment <= dataFinal Then valor.valordecimal = t.iva
                End If
            Next t
            totalIva = valor.valordecimal
            valor = Nothing
            t = Nothing
        End Get
    End Property


    Public ReadOnly Property totalImports(esCobro As Boolean, dataInicial As Date, dataFinal As Date) As Double
        Get
            Dim t As Tresoreria, valor As EnterLlarg
            valor = New EnterLlarg
            For Each t In _importsTresoreria
                If t.esIngres = esCobro Then
                    If t.dataVenciment >= dataInicial And t.dataVenciment <= dataFinal Then valor.valordecimal = t.total
                End If
            Next t
            totalImports = valor.valordecimal
            valor = Nothing
            t = Nothing
        End Get
    End Property


    Public ReadOnly Property numeroRegistres(esCobro As Boolean, dataInicial As Date, dataFinal As Date) As Integer
        Get
            Dim t As Tresoreria
            numeroRegistres = 0
            For Each t In _importsTresoreria
                If t.esIngres = esCobro Then
                    If t.dataVenciment >= dataInicial And t.dataVenciment <= dataFinal Then numeroRegistres = numeroRegistres + 1
                End If
            Next t
            t = Nothing
        End Get
    End Property
    Protected Overrides Sub Finalize()
        MyBase.Finalize()
        _importsTresoreria = Nothing
    End Sub
End Class
