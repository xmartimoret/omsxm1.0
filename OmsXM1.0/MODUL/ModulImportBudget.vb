Option Explicit On
Imports Microsoft.Office.Interop.Excel
Module ModulImportBudget
    Private Const MARCA_BUDGET As String = "BUDGET"
    Private Const FULLA_PRETANCAMENT As String = "PRETANCAMENT"
    Private Const RANG_CODI_SUBCOMPTES As String = "A1"
    Private Const RANG_ANY As String = "B1"
    Private Const RANG_CODI As String = "D1"
    Private Const RANG_CODI_EMPRESA As String = "C1"
    Private idEmpresaActual As Integer
    Private logBudget As Log
    'ini import transitoria

    Public Sub execute()
        Dim fitxers() As String, f As String, fAvis As frmAvis, i As Integer, mesos As AnyMesos
        Dim p As Projecte, budgets As List(Of ValorMes), m As Integer
        Dim cGB As CentresGB, pc As ProjecteCentre, existData As Boolean
        Dim apliExcel As Application
        Dim dades(,) As String
        apliExcel = EXCEL.getMacros
        mesos = DMesosEmpresa.getMesos(Val(CONFIG_FILE.getTag(TAG.ANY_BUDGET)), IDIOMA.getString("importDataBudget"), CONFIG_FILE.getTag(TAG.ID_EMPRESA_ACTUAL))
        If mesos IsNot Nothing Then
            fitxers = New SelectFiles(IDIOMA.getString("escollirFitxersBudget") & " " & ModelEmpresa.getNom(mesos.idEmpresa), True, CONFIG_FILE.getTag(TAG.IMPORT_BUDGET, mesos.idEmpresa), "Excel|*.xls*").fitxers
            If fitxers.Length > 0 Then
                Call CONFIG_FILE.setTag(CONFIG_FILE.TAG.IMPORT_BUDGET, CONFIG.getDirectori(CStr(fitxers(0))), mesos.idEmpresa)
                Call ModelLog.resetIndex()
                logBudget = New Log
                cGB = New CentresGB
                logBudget.titol = IDIOMA.getString("importDataBudget")
                logBudget.descripcio = IDIOMA.getString("importDataBudget1")
                'If TypeName(mesos) = "AnyMesos" Then
                'If IsArray(fitxers) Then
                fAvis = New frmAvis(IDIOMA.getString("importDataBudget"), "", "-")
                i = 0
                For Each f In fitxers
                    fAvis.setData(IDIOMA.getString("importDataDe"), CONFIG.getFitxer(f), i & " " & IDIOMA.getString("de") & " " & fitxers.Length)
                    If CONFIG.fileExist(f) Then
                        Call fAvis.Activate()
                        existData = False
                        dades = apliExcel.Run("importBudget.execute", f)
                        p = getProjecte(dades, mesos.idEmpresa)
                        If p IsNot Nothing Then
                            Call actualitzarLog(CONFIG.tipusEntradaLog.MIS_LOG, IDIOMA.getString("iniImport") & " " & p.codi, IDIOMA.getString("iniImport") & " " & CONFIG.mesNom(m) & " - " & mesos.any & " " & IDIOMA.getString("de") & "  " & p.ToString)
                            If isAnyActual(dades, mesos.any) Then
                                budgets = importData(dades, mesos, p.id)
                                If budgets IsNot Nothing Then
                                    If ModelBudget.saveMesAny(budgets, mesos.any, m) Then
                                        Call actualitzarLog(CONFIG.tipusEntradaLog.MIS_LOG, IDIOMA.getString("dadesImportades") & " " & p.codi, "OK")
                                        existData = True
                                    Else
                                        Call actualitzarLog(CONFIG.tipusEntradaLog.ERR_LOG, IDIOMA.getString("dadesImportades") & " " & p.codi, IDIOMA.getString("errNoGuardarTransitoria"))
                                    End If
                                    Call actualitzarLog(CONFIG.tipusEntradaLog.MIS_LOG, IDIOMA.getString("fImport") & " " & p.codi, IDIOMA.getString("fImport") & " " & CONFIG.mesNom(m) & "-" & mesos.any & " " & IDIOMA.getString("de") & " " & p.ToString)
                                Else
                                    Call actualitzarLog(CONFIG.tipusEntradaLog.ERR_LOG, IDIOMA.getString("noDades") & " " & p.codi, IDIOMA.getString("errNoDadaTransitoria"))
                                End If
                            Else
                                Call actualitzarLog(CONFIG.tipusEntradaLog.ERR_LOG, IDIOMA.getString("noAny") & " " & p.ToString, IDIOMA.getString("noAnyActual"))
                            End If
                        Else
                            Call actualitzarLog(CONFIG.tipusEntradaLog.ERR_LOG, IDIOMA.getString("noProjecte"), IDIOMA.getString("noProjecteBudget1") & " " & CONFIG.getFitxer(f) & IDIOMA.getString("noProjecteBudget"))
                        End If
                    End If
                    If existData Then
                        ' todo ens cal agafar el centre
                        pc = ModelProjecteCentre.getObjectByProjecte(p.id)
                        If pc IsNot Nothing Then
                            cGB.centres.Add(ModelCentre.getObject(pc.idCentre))
                        End If
                        pc = Nothing
                    End If
                    i = i + 1
                Next f
                Call fAvis.tancar()
                Call CONFIG_FILE.setTag(TAG.ANY_BUDGET, mesos.any)
                Call CONFIG_FILE.setTag(TAG.ID_EMPRESA_ACTUAL, mesos.idEmpresa)
                Call MISSATGES.DATA_UPDATED()
            End If

            If ModelLog.hihaErrors(logBudget.entrades) Then
                Call dLogs.setLog(logBudget)
            End If
            If mesos.isLog Then Call ModelInformes.executeLog(logBudget)
        End If
        Call EXCEL.closeMacros(apliExcel)
        mesos = Nothing
        ' falta llistar log en cas que existeixi
        'falta llistar errors en cas que en hi hagi., veure import transitories
        'falta copiar any i ruta


        Call EXCEL.LiberarMemoria()
    End Sub

    Private Function importData(dades(,) As String, a As AnyMesos, idProjecte As Integer) As List(Of ValorMes)
        Dim vm As ValorMes, i As Integer, s As Subcompte, m As Integer
        Dim j As Integer, columnes(12) As Integer
        importData = Nothing
        importData = New List(Of ValorMes)
        columnes = getColumnesMes(dades)
        For i = 0 To UBound(dades, 1)
            If dades(i, 0) <> "" Then
                s = ModelSubcompte.getobject(CStr(dades(i, 0)))
                If s IsNot Nothing Then
                    For m = 1 To 12
                        If a.mesos(m) Then
                            j = columnes(m)
                            If j > 0 Then
                                vm = New ValorMes
                                vm.idSubcompte = s.id
                                vm.any = a.any
                                vm.idEmpresa = a.idEmpresa
                                vm.idProjecte = idProjecte
                                vm.mes = m
                                If IsNumeric(dades(i, j)) Then
                                    vm.valor = dades(i, j)
                                Else
                                    vm.valor = 0
                                End If
                                importData.Add(vm)
                                End If
                            End If
                    Next
                End If
            End If
        Next i
        vm = Nothing
    End Function

    Private Function getColumnesMes(dades(,) As String) As Integer()
        Dim i As Integer, j As Integer, nomMesos() As String, columnes(12) As Integer, m As Integer, nNoms As Integer
        For m = 1 To 12
            columnes(m) = -1
            nomMesos = CONFIG.getNomMes(m)
            For i = 1 To 10
                For j = 1 To UBound(dades, 2)
                    If dades(i, j) <> "" Then
                        For nNoms = 0 To UBound(nomMesos)
                            If StrComp(dades(i, j), nomMesos(nNoms), vbTextCompare) = 0 Then
                                columnes(m) = j
                                Exit For
                            End If
                        Next
                    End If
                    If columnes(m) > 0 Then Exit For
                Next j
                If columnes(m) > 0 Then Exit For
            Next i
        Next
        Return columnes
    End Function
    Private Function getWorkSheet(wb As Workbook, mes As Integer) As Worksheet
        Dim sh As Worksheet, noms() As String, i As Integer
        Dim trobada As Boolean
        noms = CONFIG.getNomMes(mes)
        trobada = False
        getWorkSheet = Nothing
        For Each sh In wb.Worksheets
            For i = LBound(noms) To UBound(noms)
                If InStr(1, sh.Name, noms(i), vbTextCompare) > 0 Then
                    trobada = True
                    getWorkSheet = sh
                    Exit For
                End If
            Next i
            If trobada Then Exit For
        Next sh
        sh = Nothing
    End Function
    Private Function getProjecte(dades(,) As String, idEmpresa As Integer) As Projecte
        Dim i As Integer, j As Integer, trobat As Boolean, codiEmpresa As String
        trobat = False
        codiEmpresa = ModelEmpresa.getCodiEmpresa(idEmpresa)
        getProjecte = Nothing
        For i = LBound(dades, 1) To 10
            For j = LBound(dades, 2) To 10
                If dades(i, j) IsNot Nothing Then
                    If dades(i, j).Length >= 3 Then
                        If UCase(dades(i, j)) = UCase(codiEmpresa) Then
                            trobat = True
                            getProjecte = ModelProjecte.getObject(Left(dades(i, j + 1), 9), idEmpresa)
                            Exit For
                        End If
                    End If
                End If
            Next j
            If trobat Then Exit For
        Next i
    End Function
        Private Function isAnyActual(xls(,) As String, anyo As Integer) As Boolean
            Dim i As Integer, j As Integer, trobat As Boolean
            isAnyActual = False
            trobat = False
            For i = LBound(xls, 1) To 10
            For j = LBound(xls, 2) To 10
                If xls(i, j) <> "" Then
                    If InStr(1, xls(i, j), MARCA_BUDGET, CompareMethod.Text) > 0 Then
                        trobat = True
                        If Right(xls(i, j), 4) = anyo Then
                            isAnyActual = True
                        ElseIf Right(xls(i, j), 2) = Right(anyo, 2) Then
                            isAnyActual = True
                        End If
                        Exit For
                    End If
                End If
            Next j
            If trobat Then Exit For
            Next i
        End Function

    'Private Function existCodiYellowSheet(codi As String) As Boolean
    '    existCodiYellowSheet = False
    '    If UCase(codi) = TREATMENT Or UCase(codi) = PURCHASED Or UCase(codi) = SPARES Or UCase(codi) = OTHERT Or UCase(codi) = OTHERO Or UCase(codi) = REVENUES Then existCodiYellowSheet = True
    'End Function


    Private Sub actualitzarLog(codi As tipusEntradaLog, titol As String, descripcio As String)
        logBudget.entrades.Add(ModelLog.getEntradaLog(codi, titol, descripcio))
    End Sub









    '        Public Sub execute()
    '        Dim fitxers() As String, f As String, fAvis As frmAvis, i As Integer, mesos As AnyMesos
    '        Dim p As Projecte, transitories As List(Of Transitoria), m As Integer, mesActiu As Integer
    '        Dim cGB As CentresGB, pc As ProjecteCentre, existData As Boolean, entradesLog As List(Of EntradaLog)
    '        Dim apliExcel As Application
    '        Dim dades(,) As String, fActual As Integer
    '        apliExcel = EXCEL.getMacros
    '        mesos = DMesosEmpresa.getMesos(CONFIG_FILE.getTag(TAG.ANY_TRANSITORIA), IDIOMA.getString("importDataTransitoria"))
    '        If mesos IsNot Nothing Then
    '            For Each m In mesos.mesos
    '                If ModelEstatMes.getEstatTransitoria(mesos.idEmpresa, mesos.any, m) Then
    '                    Call mesos.setMes(m, False)
    '                    Call ERRORS.ERR_IMPORTAR_MES_TANCAT(m)
    '                End If
    '            Next m
    '            fitxers = New SelectFiles(IDIOMA.getString("escollirFitxersTransitories") & " " & ModelEmpresa.getNom(mesos.idEmpresa), True, CONFIG_FILE.getTag(TAG.IMPORT_TRANSITORIA, mesos.idEmpresa), "Excel|*.xls*").fitxers
    '            If fitxers.Length > 0 Then
    '                Call CONFIG_FILE.setTag(CONFIG_FILE.TAG.IMPORT_TRANSITORIA, CONFIG.getDirectori(CStr(fitxers(0))), mesos.idEmpresa)
    '                Call ModelLog.resetIndex()
    '                logTransitoria = New Log
    '                cGB = New CentresGB
    '                logTransitoria.titol = IDIOMA.getString("importDataTransitoria")
    '                logTransitoria.descripcio = IDIOMA.getString("importDataTransitoria1")
    '                'If TypeName(mesos) = "AnyMesos" Then
    '                'If IsArray(fitxers) Then
    '                fAvis = New frmAvis(IDIOMA.getString("importDataTransitoria"), "", "-")
    '                i = 0
    '                For Each f In fitxers
    '                    fAvis.setData(IDIOMA.getString("importDataDe"), CONFIG.getFitxer(f), i & " " & IDIOMA.getString("de") & " " & fitxers.Length)
    '                    If CONFIG.fileExist(f) Then
    '                        Call fAvis.Activate()
    '                        existData = False
    '                        For m = 1 To 12
    '                            If mesos.esActiu(m) Then
    '                                mesActiu = m
    '                                dades = apliExcel.Run("importTransitoria.execute", f, mesActiu)
    '                                p = getProjecte(dades, mesos.idEmpresa)
    '                                If p IsNot Nothing Then
    '                                    Call actualitzarLog(CONFIG.tipusEntradaLog.MIS_LOG, IDIOMA.getString("iniImport") & " " & p.codi, IDIOMA.getString("iniImport") & " " & CONFIG.mesNom(m) & " - " & mesos.any & " " & IDIOMA.getString("de") & "  " & p.ToString)
    '                                    If isAnyActual(dades, mesos.any) Then
    '                                        fActual = getRangResumen(dades)
    '                                        If fActual > 0 Then
    '                                            transitories = importData(dades, fActual, mesos.any, m, p.id, p.idEmpresa)
    '                                            If transitories IsNot Nothing Then
    '                                                If ModelTransitoria.save(transitories, p.id, mesos.any, m) Then
    '                                                    Call actualitzarLog(CONFIG.tipusEntradaLog.MIS_LOG, IDIOMA.getString("dadesImportades") & " " & p.codi, "OK")
    '                                                    existData = True
    '                                                Else
    '                                                    Call actualitzarLog(CONFIG.tipusEntradaLog.ERR_LOG, IDIOMA.getString("dadesImportades") & " " & p.codi, IDIOMA.getString("errNoGuardarTransitoria"))
    '                                                End If
    '                                                Call actualitzarLog(CONFIG.tipusEntradaLog.MIS_LOG, IDIOMA.getString("fImport") & " " & p.codi, IDIOMA.getString("fImport") & " " & CONFIG.mesNom(m) & "-" & mesos.any & " " & IDIOMA.getString("de") & " " & p.ToString)
    '                                            Else
    '                                                Call actualitzarLog(CONFIG.tipusEntradaLog.ERR_LOG, IDIOMA.getString("noDades") & " " & p.codi, IDIOMA.getString("errNoDadaTransitoria"))
    '                                            End If

    '                                        Else
    '                                            Call actualitzarLog(CONFIG.tipusEntradaLog.ERR_LOG, IDIOMA.getString("noDades") & " " & p.codi, IDIOMA.getString("errNoDadaTransitoria1"))
    '                                        End If
    '                                    Else
    '                                        Call actualitzarLog(CONFIG.tipusEntradaLog.ERR_LOG, IDIOMA.getString("noAny") & " " & p.codi, IDIOMA.getString("noAnyActual"))
    '                                    End If
    '                                Else
    '                                    Call actualitzarLog(CONFIG.tipusEntradaLog.ERR_LOG, IDIOMA.getString("noProjecte"), IDIOMA.getString("noProjecteTransitoria1") & " " & CONFIG.getFitxer(f) & IDIOMA.getString("noProjecteTransitoria"))
    '                                End If
    '                            End If
    '                        Next m
    '                    End If
    '                    If existData Then
    '                        ' todo ens cal agafar el centre
    '                        pc = ModelProjecteCentre.getObjectByProjecte(p.id)
    '                        If pc IsNot Nothing Then
    '                            cGB.centres.Add(ModelCentre.getObject(pc.idCentre))
    '                        End If
    '                        pc = Nothing
    '                    End If
    '                    i = i + 1
    '                Next f
    '                Call fAvis.tancar()
    '                '    End If

    '                Call ModulExportTransitoria.execute(mesos)
    '                cGB.anyActual = mesos.any
    '                cGB.rutaGB = tempRutaGb
    '                cGB.mesActual = mesActiu
    '                cGB.empresa = ModelEmpresa.getObject(mesos.idEmpresa)
    '                cGB.participacio = cGB.empresa.participacio
    '                cGB.contaplus = ModelEmpresaContaplus.getObjectByEmpresaAny(cGB.empresa.id, mesos.any)
    '                If CONFIG.fileExist(cGB.rutaGB) And cGB.participacio > 0 Then
    '                    entradesLog = ModulActualitzacioGB.actualitzarData(cGB, mesos.mesos, True)
    '                    If entradesLog IsNot Nothing Then logTransitoria.entrades.AddRange(entradesLog)

    '                End If
    '                If ModelLog.hihaErrors(logTransitoria.entrades) Then
    '                    Call dLogs.setLog(logTransitoria)
    '                End If
    '                If mesos.isLog Then Call ModelInformes.executeLog(logTransitoria)
    '            End If
    '        End If
    '        Call EXCEL.closeMacros(apliExcel)
    '        mesos = Nothing
    '        transitories = Nothing
    '        cGB = Nothing
    '        Call EXCEL.LiberarMemoria()
    '    End Sub
    '    Public Sub EXECUTEzusam()
    '        Dim wB As Workbook, ruta As String, am As AnyMesos
    '    Set am = frmMesos.getData
    '    If TypeName(am) = "AnyMesos" Then
    '            ruta = Application.GetOpenFilename("ZUSAM(*.xls*),*.xls*", , "Escollir fitxer ZUSAMMENFASSUNG.XLS .", "Escollir", False)
    '            If CONFIG.fileExist(ruta) Then  'EXISTFILE

    '           Set wB = CONFIG.getWorbook(CONFIG.getFitxer(ruta))

    '            If TypeName(wB) <> "Workbook" Then
    '             Set wB = Workbooks.Open(CStr(ruta), False, True)     ' GETWORKBOOK
    '            End If
    '                If TypeName(wB) = "Workbook" Then
    '                    Call ModelCentre.setCodiEmpresa()
    '                    Call frmImportBudget.getDataBudgetZUSAM(am, wB)
    '                End If
    '            End If
    '        End If
    '    End Sub




    '    Public Function getWorkSheetData(wB As Workbook) As Worksheet
    '        Dim sh As Worksheet
    '        For Each sh In wB.Worksheets
    '            If InStr(1, sh.Name, FULLA_PRETANCAMENT, vbTextCompare) <> 0 Then
    '            Set getWorkSheetData = sh
    '            Exit For
    '            End If
    '        Next sh
    '    Set sh = Nothing
    'End Function
    '    Public Function getYear(ws As Worksheet) As Variant
    '        If IsNumeric(Trim(Right(ws.Range(RANG_ANY), 4))) Then
    '            getYear = Val(Right(ws.Range(RANG_ANY), 4))
    '        ElseIf IsNumeric(Trim(Left(ws.Range(RANG_ANY), 4))) Then
    '            getYear = Val(Left(ws.Range(RANG_ANY), 4))
    '        Else
    '            getYear = 0
    '        End If
    '    End Function
    '    Public Function getProjecte(ws As Worksheet) As ProjecteCentre
    '        Dim p As Projecte, e As Empresa, xls As Object, i As Integer, j As Integer
    '    Set xls = ws.Range("a1")
    '    ' 1 trobar empresa
    '    Set e = getEmpresa(ws)
    '    ' 2 trobar projecte
    '    If TypeName(e) = "Empresa" Then
    '            For i = 1 To 5
    '                For j = 1 To 5
    '                    If xls(i, j) <> "" And Len(xls(i, j)) > 8 Then
    '                    Set p = ModelProjecte.getByCode(Left(xls(i, j), 9), e.id)
    '                    If TypeName(p) = "Projecte" Then
    '                        Set getProjecte = ModelProjecteCentre.getObjectByProjecte(p.id)
    '                    End If
    '                    End If
    '                Next j
    '            Next i
    '        End If

    '    Set p = Nothing
    '    Set e = Nothing
    '    Set xls = Nothing
    'End Function
    '    Public Function getEmpresa(ws As Worksheet) As Empresa
    '        Dim xls As Object, i As Integer, j As Integer
    '    Set xls = ws.Range("a1")
    '    ' 1 trobar empresa
    '    For i = 1 To 5
    '            For j = 1 To 5
    '                If xls(i, j) <> "" And Len(xls(i, j)) < 5 Then
    '                Set getEmpresa = ModelEmpresa.getobjectByCode(xls(i, j))
    '                If TypeName(getEmpresa) = "Empresa" Then
    '                        idEmpresaActual = getEmpresa.id
    '                        Exit For
    '                    End If
    '                End If
    '            Next j
    '            If TypeName(getEmpresa) = "Empresa" Then Exit For
    '        Next i
    '    Set xls = Nothing
    'End Function
    '    Public Function getSubcomptes(ws As Worksheet, pe As ProjecteCentre, calendari As AnyMesos) As ColleccioOrdenada
    '        Dim xls As Object, i As Integer, posMes() As Integer, m As Integer, idSubgrups() As Integer, j As Integer
    '        Dim s As Subcompte, v As ValorMes
    '    Set xls = ws.Range(RANG_CODI_SUBCOMPTES)
    '    i = 1
    '    Set getSubcomptes = New ColleccioOrdenada
    '    Set entradesLogActual = New ColleccioOrdenada
    '    posMes = getPosMes(xls)
    '        For i = 1 To 250
    '            If IsNumeric(xls(i, 1)) And Len(xls(i, 1)) = 7 Then ' cerquem el subcompte
    '            Set s = ModelSubcompte.getObjectByCodi(xls(i, 1)) ' getSubcompe
    '            If TypeName(s) = "Subcompte" Then
    '                    If ModelSubcomptesGrup.existSubcompte(s.id) Then ' comprovem que sigui una subcompteGrup
    '                        For m = 1 To 12
    '                            If calendari.esActiu(m) Then 'comprova que el mes es actiu
    '                                If posMes(m) <> -1 Then
    '                                    If IsNumeric(xls(i, posMes(m))) Then
    '                                        If xls(i, posMes(m)) <> 0 Then
    '                                            idSubgrups = ModelSubcomptesGrup.getIdSubgrups(s.id) ' comprova a quants subgrups pertany el subcomtpe
    '                                            If LBound(idSubgrups) > 0 Then
    '                                                For j = 1 To UBound(idSubgrups)
    '                                                Set v = New ValorMes
    '                                                v.anyo = calendari.anyo
    '                                                    v.idProjecte = pe.idProjecte
    '                                                    v.idEmpresa = idEmpresaActual
    '                                                    v.idSubcompte = s.id
    '                                                    v.idSubgrup = idSubgrups(j)
    '                                                    v.mes = m
    '                                                    'ESTIC AQUI 20/07/2016. CAL PODER SUMAR VALORS EN EL MATEIX SUBCOMPTE.
    '                                                    v.valor = xls(i, posMes(m))
    '                                                    v.codiSubcompte = s.codi
    '                                                    getSubcomptes.dades.add v ' per cada subcompte crea  una entrada

    '                                                    Call setEntradaLog(MIS_LOG, "GET", "Import " & CONFIG.mesCatala(m) & " de " & s.codi & " = " & v.valor)
    '                                                Next j
    '                                            End If
    '                                        End If
    '                                    Else
    '                                        Call setEntradaLog(ERR_LOG, "ERROR NUMERIC", "Import no numèric de: " & pe.codiProjecte & " - " & s.ToString & " de " & CONFIG.mesCatala(m))
    '                                    End If
    '                                Else
    '                                    Call setEntradaLog(ERR_LOG, "ERROR MES", "Mes no Trobat: " & pe.codiProjecte & " - " & CONFIG.mesCatala(m))
    '                                End If
    '                            End If
    '                        Next m
    '                    Else
    '                        Call setEntradaLog(ERR_LOG, "ERROR SUBCTE", "SUBCTE no vinculada a un grup Comptable: " & pe.codiProjecte & " - " & s.ToString)
    '                    End If
    '                Else

    '                    Call setEntradaLog(ERR_LOG, "ERROR SUBCTE", "SUBCTE no trobada: " & pe.codiProjecte & " - " & xls(i, 1))
    '                End If
    '            End If
    '        Next i
    '    Set xls = Nothing
    '    Set s = Nothing
    '    Set v = Nothing
    'End Function
    '    Public Function getSubGrupsZUSAM(ws As Worksheet, pe As ProjecteCentre, calendari As AnyMesos) As ColleccioOrdenada
    '        Dim xls As Object, i As Integer, posMes() As Integer, m As Integer, idSubgrups() As Integer, j As Integer
    '        Dim SG As Subgrup, v As ValorMes
    '    Set xls = ws.Range("b73")
    '    i = 1
    '    Set getSubGrupsZUSAM = New ColleccioOrdenada
    '    Set entradesLogActual = New ColleccioOrdenada
    '    idEmpresaActual = ModelEmpresa.getIdEmpresa(ModelCentre.getCodiEmpresa(pe.idCentre))
    '        For i = 1 To 100
    '            If xls(i, 1) <> "" Then ' cerquem el subcompte
    '            Set SG = ModelSubGrup.getobjectByCode(xls(i, 1))  ' getSubcompe
    '            If TypeName(SG) = "SubGrup" Then
    '                    For m = 1 To 12
    '                        If calendari.esActiu(m) Then 'comprova que el mes es actiu
    '                             Set v = New ValorMes
    '                             v.anyo = calendari.anyo
    '                            v.idProjecte = pe.idProjecte
    '                            v.idEmpresa = idEmpresaActual
    '                            v.idSubcompte = 0
    '                            v.idSubgrup = SG.identificador
    '                            v.mes = m
    '                            'ESTIC AQUI 20/07/2016. CAL PODER SUMAR VALORS EN EL MATEIX SUBCOMPTE.
    '                            v.valor = xls(i, m + 2)
    '                            getSubGrupsZUSAM.dades.add v ' per cada subcompte crea  una entrada
    '                            Call setEntradaLog(MIS_LOG, "GET", "Import " & CONFIG.mesCatala(m) & " de " & SG.codi & " = " & v.valor)
    '                        Else
    '                            Call setEntradaLog(ERR_LOG, "ERROR MES", "Mes no Trobat: " & pe.codiProjecte & " - " & CONFIG.mesCatala(m))
    '                        End If

    '                    Next m

    '                Else
    '                    Call setEntradaLog(ERR_LOG, "ERROR SUBCTE", "SUBCTE no trobada: " & pe.codiProjecte & " - " & xls(i, 1))
    '                End If
    '            End If
    '        Next i
    '    Set xls = Nothing

    '    Set v = Nothing
    'End Function




    '    Private Function getPosMes(xls As Object) As Integer()
    '        Dim temp(1 To 12) As Integer, i As Integer, j As Integer, tempNom As Variant, X As Integer, Y As Integer, trobat As Boolean

    '        For i = 1 To 12
    '            tempNom = CONFIG.getNomMes(i)
    '            trobat = False
    '            For j = LBound(tempNom) To UBound(tempNom)
    '                For X = 1 To 10
    '                    For Y = 1 To 25
    '                        If UCase(Trim(xls(X, Y))) = UCase(tempNom(j)) Then
    '                            trobat = True
    '                            Exit For
    '                        End If
    '                    Next Y
    '                    If trobat Then Exit For
    '                Next X
    '                If trobat Then
    '                    temp(i) = Y
    '                    Exit For
    '                End If
    '            Next j
    '            If Not trobat Then temp(i) = -1
    '        Next i
    '        getPosMes = temp
    '    End Function

    '    Private Sub setEntradaLog(codi As tipusEntradaLog, titol As String, descripcio As String)
    '        Dim e As EntradaLog
    '    Set e = New EntradaLog
    '    iLog = iLog + 1
    '        e.id = iLog
    '        e.codi = codi
    '        e.descripcio = descripcio
    '        e.titol = titol
    '        entradesLogActual.dades.add e
    '    Set e = Nothing
    'End Sub
    '    Public Function getEntradeslogActual() As ColleccioOrdenada
    '    Set getEntradeslogActual = entradesLogActual
    'End Function

End Module
