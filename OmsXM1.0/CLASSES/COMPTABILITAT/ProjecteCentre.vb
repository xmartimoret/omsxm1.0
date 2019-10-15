Option Explicit On
Public Class ProjecteCentre : Implements IComparable
    Public Property idProjecte As Integer
    Public Property codiProjecte As String
    Public Property codiCentre As String
    Public Property idCentre As Integer
    Private _ordre As String
    Public Property importsSubcomptes As List(Of ValorMes)
    Public Property importsBudgets As List(Of ValorMes)
    Public Property subGrups As List(Of Subgrup)
    Public Property participacio As Integer
    Public Property nomProjecte As String
    Public Sub New()
        _subGrups = ModelSubgrup.copyObjects
        _importsSubcomptes = New List(Of ValorMes)
        _importsBudgets = New List(Of ValorMes)
    End Sub
    Public Sub New(pIdProjecte As Integer, pIdCentre As Integer, pOrdre As String, pParticipacio As Integer, pCodiCentre As String, pCodiProjecte As String, pNomProjecte As String)
        _subGrups = ModelSubgrup.copyObjects
        _importsSubcomptes = New List(Of ValorMes)
        _importsBudgets = New List(Of ValorMes)
        _idProjecte = pIdProjecte
        _idCentre = pIdCentre
        _ordre = pOrdre
        _participacio = pParticipacio
        _codiCentre = pCodiCentre
        _codiProjecte = pCodiProjecte
        _nomProjecte = pNomProjecte
    End Sub
    Public Sub New(pIdProjecte As Integer, pIdCentre As Integer, pOrdre As String, pParticipacio As Integer, pCodiCentre As String, pCodiProjecte As String, pNomProjecte As String, pSubgrups As List(Of Subgrup))
        _subGrups = New List(Of Subgrup)
        _importsSubcomptes = New List(Of ValorMes)
        _importsBudgets = New List(Of ValorMes)
        _idProjecte = pIdProjecte
        _idCentre = pIdCentre
        _ordre = pOrdre
        _participacio = pParticipacio
        _codiCentre = pCodiCentre
        _codiProjecte = pCodiProjecte
        _nomProjecte = pNomProjecte
        _subGrups = pSubgrups
    End Sub
    Public Property ordre As String
        Get
            If _ordre = "" Then

                Return _idProjecte
            Else
                Return _ordre
            End If
        End Get
        Set(value As String)
            _ordre = value
        End Set
    End Property
    Public ReadOnly Property clau As String
        Get
            Return Right(_codiProjecte, 6)
        End Get
    End Property
    Public ReadOnly Property departa As String
        Get
            Return Left(_codiProjecte, 3)
        End Get
    End Property

    Public ReadOnly Property id() As String
        Get
            Return "P" & _idCentre & "E" & _idProjecte
        End Get
    End Property
    Public ReadOnly Property importGrupMesAny(idGrup As Integer, m As Integer, a As Integer) As Double
        Get
            Dim temp As EnterLlarg, sg As Subgrup, s As SubcompteGrup, vm As ValorMes
            temp = New EnterLlarg
            For Each sg In subGrups
                If sg.id = idGrup Then
                    For Each s In sg.subcomptes
                        For Each vm In s.valors
                            If vm.any = a And vm.mes = m Then
                                temp.valordecimal = vm.valor * (_participacio / 100)
                            End If
                        Next vm
                    Next s
                End If
            Next sg
            importGrupMesAny = temp.valordecimal
            temp = Nothing
            sg = Nothing
            s = Nothing
            vm = Nothing
        End Get
    End Property
    Private Sub setSubcomptes()
        Dim sg As Subgrup, s As SubcompteGrup, vm As ValorMes

        For Each sg In _subGrups
            For Each s In sg.subcomptes
                For Each vm In _importsSubcomptes
                    If vm.idSubcompte = s.idSubcompte Then
                        s.valors.Add(vm)
                    End If
                Next vm
            Next s
        Next sg
        sg = Nothing
        s = Nothing
        vm = Nothing
    End Sub
    Public ReadOnly Property saldo(mes As Integer, isValorAbsolut As Boolean) As Double
        Get
            Dim e As EnterLlarg, sg As Subgrup
            e = New EnterLlarg
            For Each sg In _subGrups
                e.valordecimal = sg.saldo(mes, isValorAbsolut)
            Next sg
            saldo = e.valordecimal
            sg = Nothing
            e = Nothing
        End Get
    End Property
    Public ReadOnly Property saldo(mes As Integer, codiSubgrup As String, codiSubcompte As String, isValorAbsolut As Boolean) As Double
        Get
            Dim sg As Subgrup, s As SubcompteGrup
            saldo = 0
            sg = _subGrups.Find(Function(x) x.codi = codiSubgrup)
            If sg IsNot Nothing Then
                s = sg.subcomptes.Find(Function(x) x.codiGrup = codiSubcompte)
                If s IsNot Nothing Then
                    saldo = s.saldo(mes, isValorAbsolut)
                End If
            End If
            sg = Nothing
            s = Nothing
        End Get
    End Property
    Public Function isfilter(p As String) As Boolean
        isfilter = False
        If Len(p) = 0 Then
            isfilter = True
        Else
            If InStr(1, toString, p, vbTextCompare) > 0 Then
                isfilter = True
            End If
        End If
    End Function

    Public Function CompareTo(obj As Object) As Integer Implements IComparable.CompareTo
        If obj Is Nothing OrElse Not Me.GetType Is obj.GetType Then Return -1
        If IsNumeric(_ordre) And IsNumeric(obj.ordre) Then
            If Val(_ordre) < Val(obj.ordre) Then
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
    Public Overrides Function tostring() As String
        Return _codiProjecte & " -" & _nomProjecte
    End Function
    Protected Overrides Sub Finalize()
        _subGrups = Nothing
        _importsSubcomptes = Nothing
        MyBase.Finalize()
    End Sub
    Public ReadOnly Property copy As ProjecteCentre
        Get
            Dim sg As Subgrup
            copy = New ProjecteCentre
            copy.idProjecte = _idProjecte
            copy.codiProjecte = _codiProjecte
            copy.codiCentre = _codiCentre
            copy.idCentre = _idCentre
            copy.ordre = _ordre
            copy.importsSubcomptes = _importsSubcomptes
            copy.importsBudgets = _importsBudgets
            For Each sg In _subGrups
                copy.subGrups.Add(sg.copy)
            Next
            copy.participacio = _participacio
            copy.nomProjecte = _nomProjecte
            sg = Nothing
        End Get
    End Property

End Class
