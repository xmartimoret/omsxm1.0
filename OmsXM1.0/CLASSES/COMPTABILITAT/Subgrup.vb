Option Explicit On
Public Class Subgrup
    Inherits Base
    Private _subcomptes As List(Of SubcompteGrup)
    Public Property idGrup As Integer
    Public Property esDespesaVariable As Boolean
    Public Property esDespesaCompra As Boolean
    Public Property actualitzat As Boolean
    Public Property tipusCodi As Integer
    Public Property saldoPretancament As Double
    Public Property importsBudget As List(Of ImportMesSubgrup)
    Public Property importsDetall As List(Of ImportMesSubgrup)
    Public Sub New()
        _subcomptes = New List(Of SubcompteGrup)
        _importsBudget = New List(Of ImportMesSubgrup)
        _importsDetall = New List(Of ImportMesSubgrup)
        _actualitzat = False
        _tipusCodi = 1
        _saldoPretancament = 0
    End Sub
    Public Sub New(pId As Integer, pIdGrup As Integer, pCodi As String, pNom As String, pNotes As String, pOrdre As String, pTipusCodi As Integer, pEsvariable As Boolean, pEsCompra As Boolean)
        _subcomptes = New List(Of SubcompteGrup)
        _importsBudget = New List(Of ImportMesSubgrup)
        _importsDetall = New List(Of ImportMesSubgrup)
        _actualitzat = False
        _tipusCodi = 1
        _saldoPretancament = 0
        Me.id = pId
        _idGrup = pIdGrup
        Me.codi = pCodi
        Me.nom = pNom
        Me.notes = pNotes
        Me.ordre = pOrdre
        _tipusCodi = pTipusCodi
        _esDespesaVariable = pEsvariable
        _esDespesaCompra = pEsCompra
    End Sub
    Public Sub New(pId As Integer, pIdGrup As Integer, pCodi As String, pNom As String, pNotes As String, pOrdre As String, pTipusCodi As Integer, pEsvariable As Boolean, pEsCompra As Boolean, pSubcomptes As List(Of SubcompteGrup))
        _subcomptes = pSubcomptes
        _importsBudget = New List(Of ImportMesSubgrup)
        _importsDetall = New List(Of ImportMesSubgrup)
        _actualitzat = False
        _tipusCodi = 1
        _saldoPretancament = 0
        Me.id = pId
        _idGrup = pIdGrup
        Me.codi = pCodi
        Me.nom = pNom
        Me.notes = pNotes
        Me.ordre = pOrdre
        _tipusCodi = pTipusCodi
        _esDespesaVariable = pEsvariable
        _esDespesaCompra = pEsCompra
    End Sub
    Public Property subcomptes() As List(Of SubcompteGrup)
        Get
            subcomptes = _subcomptes
        End Get
        Set(value As List(Of SubcompteGrup))
            _subcomptes = value
            _actualitzat = True
        End Set

    End Property

    Public ReadOnly Property intDespesaVariable() As Integer
        Get
            If _esDespesaVariable Then
                intDespesaVariable = 1
            Else
                intDespesaVariable = 0
            End If
        End Get
    End Property
    Public ReadOnly Property intDespesaCompra() As Integer
        Get
            If _esDespesaCompra Then
                intDespesaCompra = 1
            Else
                intDespesaCompra = 0
            End If
        End Get
    End Property
    Public ReadOnly Property saldo(mes As Integer, isValorAbsolut As Boolean, Optional tipusSaldo As Integer = 1) As Double
        Get
            Dim e As EnterLlarg, s As SubcompteGrup, a As Assentament
            e = New EnterLlarg
            For Each s In _subcomptes
                e.valordecimal = s.saldo(mes, isValorAbsolut, tipusSaldo)
            Next s
            saldo = e.valordecimal
            e = Nothing
            s = Nothing
            a = Nothing
        End Get
    End Property
    Public ReadOnly Property saldoTransitoria(mes As Integer, isValorAbsolut As Boolean, Optional tipusSaldo As Integer = 1) As Double
        Get
            Dim e As EnterLlarg, s As SubcompteGrup, a As Assentament
            e = New EnterLlarg
            For Each s In _subcomptes
                e.valordecimal = s.saldoTransitoria(mes, isValorAbsolut, tipusSaldo)
            Next s
            saldoTransitoria = e.valordecimal
            e = Nothing
            s = Nothing
            a = Nothing
        End Get
    End Property
    Public ReadOnly Property saldoPretancament(mes As Integer, Optional tipusSaldo As Integer = 1) As Double
        Get
            Dim e As EnterLlarg, s As SubcompteGrup, a As Assentament
            e = New EnterLlarg
            For Each s In _subcomptes
                e.valordecimal = s.saldoPretancament(mes, tipusSaldo)
            Next s
            saldoPretancament = e.valordecimal
            e = Nothing
            s = Nothing
            a = Nothing
        End Get
    End Property
    Public ReadOnly Property saldoTransitoria(idSubcompte As Integer, mes As Integer, isValorAbsolut As Boolean, Optional tipusSaldo As Integer = 1) As Double
        Get
            Dim e As EnterLlarg, s As SubcompteGrup
            e = New EnterLlarg
            For Each s In _subcomptes
                If s.idSubcompte = idSubcompte Then
                    e.valordecimal = s.saldoTransitoria(mes, isValorAbsolut, tipusSaldo)
                End If
            Next s
            saldoTransitoria = e.valordecimal
            e = Nothing
            s = Nothing
        End Get
    End Property
    Public ReadOnly Property saldoTransitoria(idSubcompte As Integer, idProjecte As Integer, mes As Integer, isValorAbsolut As Boolean, Optional tipusSaldo As Integer = 1) As Double
        Get
            Dim s As SubcompteGrup, e As EnterLlarg
            e = New EnterLlarg
            saldoTransitoria = 0
            For Each s In _subcomptes
                If s.idSubcompte = idSubcompte Then
                    e.valordecimal = s.saldoTransitoria(idProjecte, mes, isValorAbsolut, tipusSaldo)
                End If
            Next s
            saldoTransitoria = e.valordecimal
            s = Nothing
        End Get
    End Property
    Public ReadOnly Property saldoBudget(m As Integer, isvalorAbsolut As Boolean) As Double
        Get
            Dim e As EnterLlarg, ims As ImportMesSubgrup
            e = New EnterLlarg
            For Each ims In _importsBudget
                If isvalorAbsolut Then
                    If ims.mes <= m Then
                        e.valordecimal = ims.valor
                    End If
                Else
                    If ims.mes = m Then
                        e.valordecimal = ims.valor
                    End If
                End If
            Next ims
            saldoBudget = e.valordecimal
            e = Nothing
            ims = Nothing
        End Get
    End Property
    Public ReadOnly Property saldoDetall(m As Integer) As Double
        Get
            Dim e As EnterLlarg, ims As ImportMesSubgrup
            e = New EnterLlarg
            For Each ims In _importsDetall
                If ims.mes = m Then
                    e.valordecimal = ims.valor
                End If
            Next ims
            saldoDetall = e.valordecimal
            e = Nothing
            ims = Nothing
        End Get
    End Property


    Public ReadOnly Property saldoTransitoria(m As Integer) As Double
        Get
            Dim e As EnterLlarg, t As Transitoria, s As SubcompteGrup
            e = New EnterLlarg
            For Each s In _subcomptes
                For Each t In s.transitories
                    If t.mes = m Then
                        e.valordecimal = t.valorAS
                    End If
                Next
            Next
            saldoTransitoria = e.valordecimal
            e = Nothing
            s = Nothing
            t = Nothing
        End Get
    End Property
    Public ReadOnly Property saldoTransitoria() As Double
        Get
            Dim e As EnterLlarg, t As Transitoria, s As SubcompteGrup
            e = New EnterLlarg
            For Each s In _subcomptes
                For Each t In s.transitories
                    e.valordecimal = t.valorAS
                Next
            Next
            saldoTransitoria = e.valordecimal
            e = Nothing
            s = Nothing
            t = Nothing
        End Get
    End Property
    Public ReadOnly Property saldoTransitoria(m As Integer, codiSubcompte As String) As Double
        Get
            Dim e As EnterLlarg, t As Transitoria, s As SubcompteGrup
            e = New EnterLlarg
            For Each s In _subcomptes
                If s.codiSubcompte = codiSubcompte Then
                    For Each t In s.transitories
                        If t.mes = m Then
                            e.valordecimal = t.valorAS
                        End If
                    Next
                End If
            Next
            saldoTransitoria = e.valordecimal
            e = Nothing
            s = Nothing
            t = Nothing
        End Get
    End Property


    Public ReadOnly Property copy As Subgrup
        Get
            copy = New Subgrup
            copy.id = Me.id
            copy.codi = Me.codi
            copy.nom = Me.nom
            copy.ordre = Me.ordre
            copy.actualitzat = _actualitzat
            copy.esDespesaCompra = _esDespesaCompra
            copy.esDespesaVariable = _esDespesaVariable
            copy.idGrup = _idGrup
            copy.notes = Me.notes
            copy.subcomptes = _subcomptes
        End Get
    End Property
    Public Function toStringSubcomptes() As String
        Dim s As SubcompteGrup, t As String
        t = Me.ToString & vbCrLf
        For Each s In _subcomptes
            t = t & s.toStringSubcompte & vbCrLf
        Next
        s = Nothing
        Return t
    End Function
    Protected Overrides Sub Finalize()
        _subcomptes = Nothing
        _importsBudget = Nothing
        _importsDetall = Nothing
        MyBase.Finalize()
    End Sub
End Class
