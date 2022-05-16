Option Explicit On
' todo. 15/01/2018 estic aquí, cal implementar  el saldo transitoria, per subcpompteGrup, subgrup, projecte i centre.

''' <summary>
''' Classe associativa que serveix  per adjuntar subcomptes a un subgrup comptable
''' </summary>
Public Class SubcompteGrup : Implements IComparable
    Public Property idSubcompte As Integer
    Public Property idSubGrup As Integer
    Public Property idGrup As Integer
    Public Property codiSubcompte As Long
    Public Property nomSubcompte As String
    Public Property codiGrup As String
    Public Property esDespesaVariable As Boolean
    Public Property esDespesaCompra As Boolean
    Public Property valors As List(Of ValorMes)
    Public Property assentaments As List(Of Assentament)
    Public Property transitories As List(Of Transitoria)
    Public Property valorsBudget As List(Of ValorMes)
    Public Property valorDeure As Double
    Public Property valorHaver As Double
    Public Property valorSaldo As Double
    Public Property subcomptesProveidor As List(Of Subcompte)
    Private _toStringSubcompte As String = ""
    Private _ordre As String

    Public Sub New()
        _valors = New List(Of ValorMes)
        _assentaments = New List(Of Assentament)
        _transitories = New List(Of Transitoria)
        _valorsBudget = New List(Of ValorMes)
    End Sub
    Public Sub New(pIdSubGrup As Integer, pIdGrup As Integer, pIdSubcta As Integer, pCodiSubcompte As String, pCodiSubgrup As String, pEsCompra As Boolean, pEsVariable As Boolean, pNomSubcompte As String)
        _valors = New List(Of ValorMes)
        _assentaments = New List(Of Assentament)
        _transitories = New List(Of Transitoria)
        _valorsBudget = New List(Of ValorMes)
        _idSubGrup = pIdSubGrup
        _idGrup = pIdGrup
        _idSubcompte = pIdSubcta
        _codiSubcompte = pCodiSubcompte
        _codiGrup = pCodiSubgrup
        _esDespesaCompra = pEsCompra
        _esDespesaVariable = pEsVariable
        _nomSubcompte = pNomSubcompte

    End Sub

    Public Property ordre() As String
        Get
            If _ordre = "" Then
                ordre = _codiSubcompte
            Else
                ordre = _ordre
            End If
        End Get
        Set(value As String)
            _ordre = value
        End Set

    End Property

    Public ReadOnly Property id() As String
        Get
            Return "G" & _idSubGrup & "S" & _idSubcompte
        End Get
    End Property
    Public Property toStringSubcompte As String
        Get
            If _toStringSubcompte = "" Then
                Return _codiSubcompte & " - " & _nomSubcompte
            Else
                Return _toStringSubcompte
            End If
        End Get
        Set(value As String)
            _toStringSubcompte = value
        End Set
    End Property
    Public ReadOnly Property deure() As Double
        Get
            Dim e As New EnterLlarg, a As Assentament
            For Each a In _assentaments
                e.valorLong = a.deure
            Next a
            deure = e.valordecimal
            e = Nothing
        End Get
    End Property
    Public ReadOnly Property haver() As Double
        Get
            Dim e As New EnterLlarg, a As Assentament
            For Each a In _assentaments
                e.valorLong = a.haver
            Next a
            haver = e.valordecimal
            e = Nothing
        End Get
    End Property
    Public ReadOnly Property saldoTransitoria(mes As Integer, isValorAbsolut As Boolean, Optional tipusSaldo As Integer = 1) As Double
        Get
            Dim e As New EnterLlarg, t As Transitoria

            For Each t In _transitories
                If isValorAbsolut Then
                    If t.mes <= mes Then e.valordecimal = t.valorAS
                Else
                    If t.mes = mes Then e.valordecimal = t.valorAS
                End If
            Next
            If tipusSaldo <> 0 Then
                saldoTransitoria = e.valordecimal * tipusSaldo
            Else
                saldoTransitoria = e.valordecimal
            End If
            e = Nothing
        End Get
    End Property
    Public ReadOnly Property saldoPretancament(mes As Integer, Optional tipusSaldo As Integer = 1) As Double
        Get
            saldoPretancament = saldoTransitoria(mes, False, tipusSaldo) + saldo(mes, False, tipusSaldo)
        End Get
    End Property
    Public ReadOnly Property saldoTransitoria(idProjecte As Integer, mes As Integer, isValorAbsolut As Boolean, Optional tipusSaldo As Integer = 1) As Double
        Get
            Dim e As New EnterLlarg, t As Transitoria

            For Each t In _transitories
                If t.idProjecte = idProjecte Then
                    If isValorAbsolut Then
                        If t.mes <= mes Then e.valordecimal = t.valorAS
                    Else
                        If t.mes = mes Then e.valordecimal = t.valorAS
                    End If
                End If
            Next
            If tipusSaldo <> 0 Then
                saldoTransitoria = e.valordecimal * tipusSaldo
            Else
                saldoTransitoria = e.valordecimal
            End If

            e = Nothing
        End Get
    End Property
    Public ReadOnly Property saldo(mes As Integer, isValorAbsolut As Boolean, Optional tipusSaldo As Integer = 1) As Double
        Get
            Dim e As New EnterLlarg, a As Assentament

            For Each a In _assentaments
                If isValorAbsolut Then
                    If Month(a.dataAssentament) <= mes Then e.valorLong = a.saldo
                Else
                    If Month(a.dataAssentament) = mes Then e.valorLong = a.saldo
                End If
            Next a
            If tipusSaldo <> 0 Then
                saldo = e.valordecimal * tipusSaldo
            Else
                saldo = e.valordecimal
            End If
            e = Nothing
        End Get
    End Property
    Public ReadOnly Property saldo(departament As String, clau As String, mes As Integer, isValorAbsolut As Boolean, Optional tipusSaldo As Integer = 0) As Double
        Get
            Dim e As New EnterLlarg, a As Assentament

            For Each a In _assentaments
                If a.departamentAssentament = departament And a.clave = clau Then
                    If isValorAbsolut Then
                        If Month(a.dataAssentament) <= mes Then e.valorLong = a.saldo
                    Else
                        If Month(a.dataAssentament) = mes Then e.valorLong = a.saldo
                    End If
                End If
            Next a
            If tipusSaldo <> 0 Then
                saldo = e.valordecimal * tipusSaldo
            Else
                saldo = e.valordecimal
            End If
            e = Nothing
        End Get
    End Property
    Public Function saldoAssentaments(p As String, Optional contra As String = "-1") As Double
        Dim e As EnterLlarg, a As Assentament
        e = New EnterLlarg
        For Each a In _assentaments
            If contra = -1 Then
                If Left(a.subcompteAssentament, Len(p)) = p Then e.valorLong = a.saldo
            Else
                If a.contrapartida <> "" Then
                    If Left(a.contrapartida, Len(contra)) = contra Then
                        If Left(a.subcompteAssentament, Len(p)) = p Then
                            e.valorLong = a.saldo
                        End If
                    End If
                End If
            End If
        Next a
        saldoAssentaments = e.valordecimal
        e = Nothing
    End Function

    Public ReadOnly Property numAssentaments(mes As Integer) As Integer
        Get
            Dim a As Assentament
            numAssentaments = 0
            For Each a In _assentaments
                If Month(a.dataAssentament) = mes Then numAssentaments = +1
            Next a
            a = Nothing
        End Get
    End Property
    Public ReadOnly Property copy() As SubcompteGrup
        Get
            copy = New SubcompteGrup
            copy.idGrup = _idGrup
            copy.idSubGrup = _idSubGrup
            copy.idSubcompte = _idSubcompte
            copy.ordre = _ordre
            copy.codiSubcompte = _codiSubcompte
            copy.nomSubcompte = _nomSubcompte
            copy.codiGrup = _codiGrup
            copy.toStringSubcompte = _toStringSubcompte
            copy.esDespesaCompra = _esDespesaCompra
            copy.esDespesaVariable = _esDespesaVariable
        End Get
    End Property
    Public ReadOnly Property toStringAssentaments(m As Integer, Optional tipusSaldo As Integer = 0) As String
        Get
            Dim a As Assentament, t As Integer
            toStringAssentaments = ""
            t = 1
            If tipusSaldo <> 0 Then t = tipusSaldo
            For Each a In _assentaments
                If m = Month(a.dataAssentament) Then
                    toStringAssentaments = toStringAssentaments & CONFIG.getEspais(a.numero, 5, False) & " ... " & a.subcompteAssentament & " ... " & a.dataAssentament & " ... " & a.contrapartida & " ... " & CONFIG.getEspais(Left(a.concepte, 15), 20, True) & " ... " & a.departamentAssentament & a.clave & " ... " & CONFIG.getEspais(Format(System.Math.Round((a.saldo * t) / 100, 2), "#,##0.00"), 15, False) & Chr(10)
                End If
            Next a

            a = Nothing
        End Get
    End Property
    Protected Overrides Sub Finalize()
        _valors = Nothing
        _assentaments = Nothing
        _transitories = Nothing
        MyBase.Finalize()
    End Sub

    Public Function CompareTo(obj As Object) As Integer Implements IComparable.CompareTo
        If obj Is Nothing OrElse Not Me.GetType Is obj.GetType Then Return -1
        If IsNumeric(_ordre) And IsNumeric(obj.ordre) Then
            If _ordre < obj.ordre Then
                Return -1
            ElseIf _ordre > obj.ordre Then
                Return 1
            Else
                Return 0
            End If
        Else
            Return StrComp(_ordre, obj.ordre)
        End If
    End Function
    Public Overridable Function isFilter(textFiltre As String, Optional opcionalP1 As String = "", Optional opcionalP2 As String = "") As Boolean
        isFilter = False
        If Len(textFiltre) = 0 Then
            isFilter = True
        Else
            If InStr(1, Me.nomSubcompte, textFiltre, vbTextCompare) > 0 Or
               InStr(1, Me.codiSubcompte, textFiltre, vbTextCompare) > 0 Or
               (opcionalP1 <> "" And InStr(1, opcionalP1, textFiltre, vbTextCompare) > 0) Or
               (opcionalP2 <> "" And InStr(1, opcionalP2, textFiltre, vbTextCompare) > 0) Then
                isFilter = True
            End If
        End If
    End Function
    Public Overrides Function ToString() As String
        Return _codiSubcompte & " - " & _nomSubcompte
    End Function
End Class
