Public Class Centre
    Inherits Base
    Public Property idSeccio As Integer
    Public Property idEmpresa As Integer
    Public Property codiSeccio As String = ""
    Public Property codiEmpresa As String = ""
    Public Property participacio As Integer = 100
    Public Property projectes As List(Of ProjecteCentre)
    Private _assentaments As List(Of Assentament)
    Private _transitories As List(Of Transitoria)
    Public Property subGrups As List(Of Subgrup)
    Public Property actiu As Boolean = True
    Public Property importsSubgrups As List(Of ImportMesSubgrup)
    Public Property importsBudget As List(Of ValorMes)
    Public Property importsSubgrupBudget As List(Of ImportMesSubgrup)
    Public Property subgrupsGb As List(Of SubGrupGB)
    Public Property actualitzat As Boolean
    Private _isDetall(12) As Boolean
    Public Sub New()
        _projectes = New List(Of ProjecteCentre)
        _assentaments = New List(Of Assentament)
        _transitories = New List(Of Transitoria)
        _importsSubgrups = New List(Of ImportMesSubgrup)
        _importsSubgrupBudget = New List(Of ImportMesSubgrup)
        _importsBudget = New List(Of ValorMes)
        _subGrups = ModelSubgrup.copyObjects
        _subgrupsGb = ModelSubGrupGB.getObjects("")
    End Sub
    Public Sub New(pIdEmpresa As Integer)
        _idEmpresa = pIdEmpresa
        _projectes = New List(Of ProjecteCentre)
        _assentaments = New List(Of Assentament)
        _importsSubgrups = New List(Of ImportMesSubgrup)
        _importsSubgrupBudget = New List(Of ImportMesSubgrup)
        _importsBudget = New List(Of ValorMes)
        _subGrups = ModelSubgrup.copyObjects
        _subgrupsGb = ModelSubGrupGB.getObjects("")
    End Sub
    Public Sub New(pId As Integer, pIdSeccio As Integer, pCodi As String, pNom As String, pNotes As String, pOrdre As String, pActiu As Boolean, pProjectes As List(Of ProjecteCentre))
        Me.id = pId
        _idSeccio = pIdSeccio
        Me.codi = pCodi
        Me.nom = pNom
        Me.notes = pNotes
        Me.ordre = pOrdre
        _actiu = pActiu
        _projectes = pProjectes
        _assentaments = New List(Of Assentament)
        _importsSubgrups = New List(Of ImportMesSubgrup)
        _importsSubgrupBudget = New List(Of ImportMesSubgrup)
        _importsBudget = New List(Of ValorMes)
        _subGrups = ModelSubgrup.copyObjects
        _subgrupsGb = ModelSubGrupGB.getObjects("")
    End Sub

    Public Sub New(pId As Integer, pIdSeccio As Integer, pCodi As String, pNom As String, pNotes As String, pOrdre As String, pActiu As Boolean, pProjectes As List(Of ProjecteCentre), PCodiSeccio As String, pIdEmpresa As Integer, pCodiEmpresa As String, pParticipacio As Integer)
        Me.id = pId
        _idSeccio = pIdSeccio
        Me.codi = pCodi
        Me.nom = pNom
        Me.notes = pNotes
        Me.ordre = pOrdre
        _actiu = pActiu
        _projectes = pProjectes
        _assentaments = New List(Of Assentament)
        _importsSubgrups = New List(Of ImportMesSubgrup)
        _importsSubgrupBudget = New List(Of ImportMesSubgrup)
        _importsBudget = New List(Of ValorMes)
        _subgrupsGb = ModelSubGrupGB.getObjects("")
        _subGrups = ModelSubgrup.copyObjects
        _codiSeccio = PCodiSeccio
        _idEmpresa = pIdEmpresa
        _codiEmpresa = pCodiEmpresa
        _participacio = pParticipacio
    End Sub
    Public Property isDetall(m As Integer) As Boolean
        Get
            Return _isDetall(m)
        End Get
        Set(value As Boolean)
            _isDetall(m) = value
        End Set
    End Property
    Public Property assentaments() As List(Of Assentament)
        Get
            Return _assentaments
        End Get
        Set(value As List(Of Assentament))
            _assentaments = value
            Call setAssentaments()
        End Set
    End Property
    Public Property transitories() As List(Of Transitoria)
        Get
            Return _transitories
        End Get
        Set(value As List(Of Transitoria))
            _transitories = value
            Call setValorsTransitories()
        End Set
    End Property

    Public ReadOnly Property saldo(mes As Integer, isValorAbsolut As Boolean, idGrup As Integer) As Double
        Get
            Dim e As EnterLlarg, sg As Subgrup
            e = New EnterLlarg
            For Each sg In _subGrups
                If sg.idGrup = idGrup Then
                    e.valordecimal = sg.saldo(mes, isValorAbsolut)
                End If
            Next sg
            saldo = e.valordecimal
            sg = Nothing
            e = Nothing
        End Get
    End Property

    Public ReadOnly Property saldoSubgrup(idSubgrup As Integer, mes As Integer, isValorAbsolut As Boolean, Optional tipusSaldo As Integer = 1) As Double
        Get
            Dim sg As Subgrup
            saldoSubgrup = 0
            For Each sg In subGrups
                If sg.id = idSubgrup Then
                    saldoSubgrup = sg.saldo(mes, isValorAbsolut, tipusSaldo)
                    Exit For
                End If
            Next sg
            sg = Nothing
        End Get
    End Property
    Public ReadOnly Property saldoDetall(idSubgrup As Integer, mes As Integer, isValorAbsolut As Boolean, Optional tipusSaldo As Integer = 1) As Double
        Get
            Dim sg As Subgrup
            saldoDetall = 0
            For Each sg In subGrups
                If sg.id = idSubgrup Then
                    If Not isValorAbsolut And mes > 1 Then
                        If isDetall(mes) Then saldoDetall = (sg.saldoDetall(mes) - sg.saldoDetall(mes - 1)) * tipusSaldo
                    Else
                        saldoDetall = sg.saldoDetall(mes) * tipusSaldo
                    End If
                    Exit For
                End If
            Next sg

            sg = Nothing
        End Get
    End Property
    Public ReadOnly Property saldoDetallGB(idSubgrup As Integer, mes As Integer, isValorAbsolut As Boolean, Optional tipusSaldo As Integer = 1) As Double
        Get
            Dim sg As SubGrupGB
            saldoDetallGB = 0
            For Each sg In subgrupsGb
                If sg.id = idSubgrup Then
                    saldoDetallGB = sg.saldo(mes, isValorAbsolut, tipusSaldo)
                    Exit For
                End If
            Next sg
            sg = Nothing
        End Get
    End Property
    Public ReadOnly Property saldoTransitoria(idSubgrup As Integer, mes As Integer, isValorAbsolut As Boolean, Optional tipusSaldo As Integer = 1) As Double
        Get
            Dim sg As Subgrup
            saldoTransitoria = 0
            For Each sg In subGrups
                If sg.id = idSubgrup Then
                    saldoTransitoria = sg.saldoTransitoria(mes, isValorAbsolut, tipusSaldo)
                    Exit For
                End If
            Next sg
            sg = Nothing
        End Get
    End Property
    Public ReadOnly Property saldoPretancament(idSubgrup As Integer, mes As Integer, isValorAbsolut As Boolean, Optional tipusSaldo As Integer = 1) As Double
        Get
            Dim sg As Subgrup
            saldoPretancament = 0
            For Each sg In subGrups
                If sg.id = idSubgrup Then
                    If isValorAbsolut And mes > 1 Then
                        If isDetall(mes) Then
                            saldoPretancament = saldoDetall(sg.id, mes, True)
                        Else
                            saldoPretancament = ((sg.saldoPretancament(mes))) * tipusSaldo + saldoDetall(sg.id, mes - 1, True)
                        End If
                    Else
                        If isDetall(mes) Then
                            saldoPretancament = saldoDetall(sg.id, mes, False)
                        Else
                            saldoPretancament = (sg.saldoPretancament(mes)) * tipusSaldo
                        End If
                    End If

                    Exit For
                End If
            Next sg
            sg = Nothing
        End Get
    End Property

    Public ReadOnly Property saldoTransitoria(idSubcompte As Integer, idSubgrup As Integer, idProjecte As Integer, mes As Integer, isValorAbsolut As Boolean, Optional tipusSaldo As Integer = 1) As Double
        Get
            Dim sg As Subgrup
            saldoTransitoria = 0
            For Each sg In subGrups
                If sg.id = idSubgrup Then
                    saldoTransitoria = sg.saldoTransitoria(idSubcompte, idProjecte, mes, isValorAbsolut, tipusSaldo)
                    Exit For
                End If
            Next sg
            sg = Nothing
        End Get
    End Property
    Public ReadOnly Property saldoBudget(idSubgrup As Integer, mes As Integer, isValorAbsolut As Boolean, Optional tipusSaldo As Integer = 1) As Double
        Get
            Dim sg As Subgrup
            saldoBudget = 0
            For Each sg In subGrups
                If sg.id = idSubgrup Then
                    saldoBudget = sg.saldoBudget(mes, isValorAbsolut) * tipusSaldo
                    Exit For
                End If
            Next sg
            sg = Nothing
        End Get
    End Property
    Public ReadOnly Property saldoProjecteSubcompte(codiSubgrup As String, codiSubcompte As String, codiProjecte As String, mes As Integer, isValorAbsolut As Boolean, Optional tipusSaldo As Integer = 0) As Double
        Get
            Dim sg As Subgrup, s As SubcompteGrup, hiHaSaldo As Boolean
            saldoProjecteSubcompte = 0
            hiHaSaldo = False
            For Each sg In subGrups
                If sg.codi = codiSubgrup Then
                    For Each s In sg.subcomptes
                        If s.codiSubcompte = codiSubcompte Then
                            saldoProjecteSubcompte = s.saldo(Strings.Left(codiProjecte, 3), Strings.Right(codiProjecte, 6), mes, isValorAbsolut, tipusSaldo)
                            hiHaSaldo = True
                        End If
                        If hiHaSaldo Then Exit For
                    Next
                End If
                If hiHaSaldo Then Exit For
            Next sg
            sg = Nothing
            s = Nothing
        End Get
    End Property


    Public ReadOnly Property tipTextProjectes() As String
        Get
            Dim pe As ProjecteCentre
            tipTextProjectes = ""
            For Each pe In _projectes
                tipTextProjectes = tipTextProjectes & vbCrLf & " " & pe.tostring
            Next pe
            pe = Nothing
        End Get
    End Property


    Public ReadOnly Property codisProjecte() As String(,)
        Get
            Dim dades(,) As String, p As ProjecteCentre, i As Integer
            If projectes.Count > 0 Then
                ReDim dades(projectes.Count - 1, 1)
                i = 0
                For Each p In projectes
                    dades(i, 0) = p.departa
                    dades(i, 1) = p.clau
                    i = i + 1
                Next p
            Else
                ReDim dades(0, 1)
            End If
            codisProjecte = dades
            p = Nothing
        End Get
    End Property
    Public ReadOnly Property existProjecte(codi As String) As Boolean
        Get
            For Each p As ProjecteCentre In _projectes
                If StrComp(p.codiProjecte, codi, CompareMethod.Text) = 0 Then
                    Return True
                End If
            Next
            Return False
        End Get
    End Property
    Private Sub setAssentaments()
        Dim sg As Subgrup, s As SubCompteGrup, a As Assentament

        For Each sg In _subGrups
            For Each s In sg.subcomptes
                s.assentaments = New List(Of Assentament)
                For Each a In _assentaments
                    If s.codiSubcompte = a.subcompteAssentament Then
                        s.assentaments.Add(a)
                    End If
                Next a
            Next s
        Next sg
        sg = Nothing
        s = Nothing
        a = Nothing
    End Sub
    Public Sub setValorsSubgrupsDetall()
        Dim sg As Subgrup, ims As ImportMesSubgrup
        For Each sg In _subGrups
            sg.importsDetall = New List(Of ImportMesSubgrup)
            For Each ims In _importsSubgrups
                If ims.idSubgrup = sg.id Then
                    sg.importsDetall.Add(ims)
                End If
            Next ims
        Next
        sg = Nothing
        ims = Nothing
    End Sub
    Public Sub setValorsSubgrupsDetallGB()
        Dim sg As SubGrupGB, ims As ImportMesSubgrup
        For Each sg In _subgrupsGb
            For Each ims In _importsSubgrups
                If sg.existsSubgrup(ims.idSubgrup) Then
                    sg.importValors.Add(ims)
                End If
            Next ims
        Next
        sg = Nothing
        ims = Nothing
    End Sub
    Public Sub setValorsSubgrupsBudget()
        Dim sg As Subgrup, ims As ImportMesSubgrup, vm As ValorMes
        For Each sg In _subGrups
            sg.importsDetall = New List(Of ImportMesSubgrup)
            For Each ims In _importsSubgrupBudget
                If ims.idSubgrup = sg.id Then
                    sg.importsBudget.Add(ims)
                End If
            Next ims
            For Each vm In _importsBudget
                If vm.idSubgrup = sg.id Then
                    ims = New ImportMesSubgrup
                    ims.anyo = vm.any
                    ims.codiGrup = sg.codi
                    ims.idCentre = Me.id
                    ims.idSubgrup = sg.id
                    ims.mes = vm.mes
                    ims.valor = vm.valor
                    sg.importsBudget.Add(ims)
                End If
            Next
        Next
        sg = Nothing
        vm = Nothing
        ims = Nothing
    End Sub
    Private Sub setValorsTransitories()
        Dim sg As Subgrup, s As SubcompteGrup, t As Transitoria
        '_subGrups = ModelSubgrup.copyObjects
        For Each sg In _subGrups
            For Each s In sg.subcomptes
                s.transitories = New List(Of Transitoria)
                For Each t In _transitories
                    If s.idSubcompte = t.idSubcompte Then
                        s.transitories.Add(t)
                    End If
                Next t
            Next s
        Next sg
        sg = Nothing
        s = Nothing
        t = Nothing
    End Sub
    Protected Overrides Sub Finalize()
        MyBase.Finalize()
        _projectes = Nothing
        _assentaments = Nothing
        _subGrups = Nothing
        _importsSubgrups = Nothing
        _importsBudget = Nothing
    End Sub

    Public ReadOnly Property assentamentsSubctaMes(codi As String, mes As Integer, isValorAbsolut As Boolean, Optional filtre As String = "") As List(Of Assentament)
        Get
            Dim a As Assentament, sb As Subgrup, s As SubcompteGrup, trobat As Boolean
            assentamentsSubctaMes = New List(Of Assentament)
            For Each sb In _subGrups
                For Each s In sb.subcomptes
                    For Each a In s.assentaments
                        If a.subcompteAssentament = codi And ((Month(a.dataAssentament) <= mes And isValorAbsolut) Or Month(a.dataAssentament) = mes) Then
                            If a.isfilter(filtre) Then
                                a.ordre = a.numero
                                assentamentsSubctaMes.Add(a)
                                trobat = True
                            End If
                        End If
                    Next a
                Next s
                If trobat Then Exit For
            Next sb
            s = Nothing
            sb = Nothing
            a = Nothing
        End Get
    End Property
    Public ReadOnly Property assentamentsProjecteSubcompteMes(codiProjecte As String, codiSubcompte As String, mes As Integer, isValorAbsolut As Boolean, Optional filtre As String = "") As List(Of Assentament)
        Get
            Dim a As Assentament, sb As Subgrup, s As SubcompteGrup, trobat As Boolean
            assentamentsProjecteSubcompteMes = New List(Of Assentament)
            For Each sb In _subGrups
                For Each s In sb.subcomptes
                    For Each a In s.assentaments
                        If a.subcompteAssentament = codiSubcompte And ((Month(a.dataAssentament) <= mes And isValorAbsolut) Or Month(a.dataAssentament) = mes) _
                            And StrComp(a.departamentAssentament, Strings.Left(codiProjecte, 3), CompareMethod.Text) = 0 And StrComp(a.clave, Strings.Right(codiProjecte, 6), CompareMethod.Text) = 0 Then
                            If a.isfilter(filtre) Then
                                a.ordre = a.numero
                                assentamentsProjecteSubcompteMes.Add(a)
                                trobat = True
                            End If
                        End If
                    Next a
                Next s
                If trobat Then Exit For
            Next sb
            s = Nothing
            sb = Nothing
            a = Nothing
        End Get
    End Property
    Public ReadOnly Property assentamentsSubGrupMes(codi As String, mes As Integer, isValorAbsolut As Boolean, Optional filtre As String = "") As List(Of Assentament)
        Get
            Dim a As Assentament, sb As Subgrup, s As SubcompteGrup
            assentamentsSubGrupMes = New List(Of Assentament)
            For Each sb In _subGrups
                If sb.codi = codi Then
                    For Each s In sb.subcomptes
                        For Each a In s.assentaments
                            If (Month(a.dataAssentament) <= mes And isValorAbsolut) Or Month(a.dataAssentament) = mes Then
                                If a.isfilter(filtre) Then
                                    a.ordre = a.numero
                                    assentamentsSubGrupMes.Add(a)
                                End If
                            End If
                        Next a
                    Next s
                End If
            Next sb
            s = Nothing
            sb = Nothing
            a = Nothing
        End Get
    End Property
    Public ReadOnly Property copy As Centre
        Get
            Dim p As ProjecteCentre, sg As Subgrup
            copy = New Centre
            copy.id = Me.id
            copy.codi = Me.codi
            copy.nom = Me.nom
            copy.ordre = Me.ordre
            copy.notes = Me.notes
            copy.actiu = _actiu
            copy.assentaments = _assentaments
            copy.idSeccio = _idSeccio
            copy.codiSeccio = _codiSeccio
            copy.codiEmpresa = _codiEmpresa
            copy.participacio = _participacio
            For Each p In _projectes
                copy.projectes.Add(p.copy)
            Next
            For Each sg In _subGrups
                copy.subGrups.Add(sg.copy)
            Next
            copy.importsBudget = _importsBudget

            copy.importsSubgrups = _importsSubgrups

            p = Nothing
            sg = Nothing
        End Get
    End Property

End Class
