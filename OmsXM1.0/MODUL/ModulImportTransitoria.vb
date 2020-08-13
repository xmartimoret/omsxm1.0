Option Explicit On
Imports Microsoft.Office.Interop.Excel
Module ModulImportTransitoria
    Private Const EXPLOTACION As String = "EXPLOTACION"
    Private Const RESUMEN As String = "RESUMEN"
    Private tempParticipacio As Integer
    Private tempRutaGb As String
    Private logTransitoria As Log
    Public Sub execute()
        Dim fitxers() As String, f As String, fAvis As frmAvis, i As Integer, mesos As AnyMesos
        Dim p As Projecte, transitories As List(Of Transitoria), m As Integer, mesActiu As Integer
        Dim cGB As CentresGB, pc As ProjecteCentre, existData As Boolean, entradesLog As List(Of EntradaLog)
        Dim apliExcel As Application
        Dim dades(,) As String, fActual As Integer
        apliExcel = EXCEL.getMacros
        'CONFIG_FILE.getTag(TAG.ANY_TRANSITORIA)
        mesos = DMesosEmpresa.getMesos(2019, IDIOMA.getString("importDataTransitoria"))
        If mesos IsNot Nothing Then
            For Each m In mesos.mesos
                If ModelEstatMes.getEstatTransitoria(mesos.idEmpresa, mesos.any, m) Then
                    Call mesos.setMes(m, False)
                    Call ERRORS.ERR_IMPORTAR_MES_TANCAT(m)
                End If
            Next m
            fitxers = New SelectFiles(IDIOMA.getString("escollirFitxersTransitories") & " " & ModelEmpresa.getNom(mesos.idEmpresa), True, CONFIG_FILE.getTag(TAG.IMPORT_TRANSITORIA, mesos.idEmpresa), "Excel|*.xls*").fitxers
            If fitxers.Length > 0 Then
                Call CONFIG_FILE.setTag(CONFIG_FILE.TAG.IMPORT_TRANSITORIA, CONFIG.getDirectori(CStr(fitxers(0))), mesos.idEmpresa)
                Call ModelLog.resetIndex()
                logTransitoria = New Log
                cGB = New CentresGB
                logTransitoria.titol = IDIOMA.getString("importDataTransitoria")
                logTransitoria.descripcio = IDIOMA.getString("importDataTransitoria1")
                'If TypeName(mesos) = "AnyMesos" Then
                'If IsArray(fitxers) Then
                fAvis = New frmAvis(IDIOMA.getString("importDataTransitoria"), "", "-")
                i = 0
                For Each f In fitxers
                    fAvis.setData(IDIOMA.getString("importDataDe"), CONFIG.getFitxer(f), i & " " & IDIOMA.getString("de") & " " & fitxers.Length)
                    If CONFIG.fileExist(f) Then
                        Call fAvis.Activate()
                        existData = False
                        For m = 1 To 12
                            If mesos.esActiu(m) Then
                                mesActiu = m
                                dades = apliExcel.Run("importTransitoria.execute", f, mesActiu)
                                p = getProjecte(dades, mesos.idEmpresa)
                                If p IsNot Nothing Then
                                    Call actualitzarLog(CONFIG.tipusEntradaLog.MIS_LOG, IDIOMA.getString("iniImport") & " " & p.codi, IDIOMA.getString("iniImport") & " " & CONFIG.mesNom(m) & " - " & mesos.any & " " & IDIOMA.getString("de") & "  " & p.ToString)
                                    If isAnyActual(dades, mesos.any) Then
                                        fActual = getRangResumen(dades)
                                        If fActual > 0 Then
                                            transitories = importData(dades, fActual, mesos.any, m, p.id, p.idEmpresa)
                                            If transitories IsNot Nothing Then
                                                If ModelTransitoria.save(transitories, p.id, mesos.any, m) Then
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
                                            Call actualitzarLog(CONFIG.tipusEntradaLog.ERR_LOG, IDIOMA.getString("noDades") & " " & p.codi, IDIOMA.getString("errNoDadaTransitoria1"))
                                        End If
                                    Else
                                        Call actualitzarLog(CONFIG.tipusEntradaLog.ERR_LOG, IDIOMA.getString("noAny") & " " & p.codi, IDIOMA.getString("noAnyActual"))
                                    End If
                                Else
                                    Call actualitzarLog(CONFIG.tipusEntradaLog.ERR_LOG, IDIOMA.getString("noProjecte"), IDIOMA.getString("noProjecteTransitoria1") & " " & CONFIG.getFitxer(f) & IDIOMA.getString("noProjecteTransitoria"))
                                End If
                            End If
                        Next m
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
                '    End If

                Call ModulExportTransitoria.execute(mesos)
                cGB.anyActual = mesos.any
                cGB.rutaGB = tempRutaGb
                cGB.mesActual = mesActiu
                cGB.empresa = ModelEmpresa.getObject(mesos.idEmpresa)
                cGB.participacio = cGB.empresa.participacio
                cGB.contaplus = ModelEmpresaContaplus.getObjectByEmpresaAny(cGB.empresa.id, mesos.any)
                If CONFIG.fileExist(cGB.rutaGB) And cGB.participacio > 0 Then
                    entradesLog = ModulActualitzacioGB.actualitzarData(cGB, mesos.mesos, True)
                    If entradesLog IsNot Nothing Then logTransitoria.entrades.AddRange(entradesLog)

                End If
                If ModelLog.hihaErrors(logTransitoria.entrades) Then
                    Call dLogs.setLog(logTransitoria)
                End If
                If mesos.isLog Then Call ModelInformes.executeLog(logTransitoria)
            End If
        End If
        Call EXCEL.closeMacros(apliExcel)
        mesos = Nothing
        transitories = Nothing
        cGB = Nothing
        Call EXCEL.LiberarMemoria()
    End Sub

    ' vell xmarti. 14/06/2018
    'Public Sub execute()
    '    Dim fitxers() As String, f As String, fAvis As frmAvis, i As Integer, wb As Workbook, noClosed As Boolean, ws As Worksheet, mesos As AnyMesos
    '    Dim p As Projecte, transitories As List(Of Transitoria), m As Integer, mesActiu As Integer
    '    Dim cGB As CentresGB, pc As ProjecteCentre, existData As Boolean, entradesLog As List(Of EntradaLog)
    '    Dim apliExcel As Application
    '    Dim dades(,) As String, fActual As Integer
    '    apliExcel = EXCEL.getMacros
    '    mesos = dImportTransitories.getMesosImport
    '    If mesos IsNot Nothing Then
    '        fitxers = New SelectFiles(IDIOMA.getString("escollirFitxersTransitories") & " " & ModelEmpresa.getNom(mesos.idEmpresa), True, CONFIG_FILE.getTag(TAG.IMPORT_TRANSITORIA, mesos.idEmpresa), "Excel|*.xls*").fitxers
    '        If fitxers.Length > 0 Then
    '            Call CONFIG_FILE.setTag(CONFIG_FILE.TAG.IMPORT_TRANSITORIA, CONFIG.getDirectori(CStr(fitxers(0))), mesos.idEmpresa)
    '            Call ModelLog.resetIndex()
    '            logTransitoria = New Log
    '            cGB = New CentresGB
    '            logTransitoria.titol = IDIOMA.getString("importDataTransitoria")
    '            logTransitoria.descripcio = IDIOMA.getString("importDataTransitoria1")
    '            'If TypeName(mesos) = "AnyMesos" Then
    '            'If IsArray(fitxers) Then
    '            fAvis = New frmAvis(IDIOMA.getString("importDataTransitoria"), "", "-")
    '            i = 0
    '            For Each f In fitxers
    '                fAvis.setData(IDIOMA.getString("importDataDe"), CONFIG.getFitxer(f), i & " " & IDIOMA.getString("de") & " " & fitxers.Length)
    '                If CONFIG.fileExist(f) Then
    '                    wb = EXCEL.getWorkbook(CONFIG.getFitxer(f))
    '                    If wb Is Nothing Then
    '                        wb = EXCEL.openWorkbook(CStr(f), False, True)
    '                        noClosed = False
    '                    Else
    '                        noClosed = True
    '                    End If
    '                    'wb.Application.Calculation = XlCalculation.xlCalculationManual
    '                    Call fAvis.Activate()
    '                    existData = False
    '                    For m = 1 To 12
    '                        If mesos.esActiu(m) Then
    '                            mesActiu = m
    '                            ws = getWorkSheet(wb, m)
    '                            If ws IsNot Nothing Then
    '                                dades = apliExcel.Run("llegirDades", ws, 20, 150)
    '                                'xls = ws.Range("a1")
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
    '                                    Call actualitzarLog(CONFIG.tipusEntradaLog.ERR_LOG, IDIOMA.getString("noProjecte"), IDIOMA.getString("noProjecteTransitoria1") & " " & wb.Name & IDIOMA.getString("noProjecteTransitoria"))
    '                                End If
    '                            Else
    '                                Call actualitzarLog(CONFIG.tipusEntradaLog.ERR_LOG, IDIOMA.getString("noMes"), IDIOMA.getString("noMesErr") & CONFIG.mesNom(m) & IDIOMA.getString("revisarFitxerTransitoria") & " " & fitxers(i))
    '                            End If
    '                        End If
    '                    Next m
    '                    'wb.Application.Calculation = XlCalculation.xlCalculationAutomatic
    '                    If Not noClosed Then Call wb.Close(False)
    '                End If
    '                If existData Then
    '                    ' todo ens cal agafar el centre
    '                    pc = ModelProjecteCentre.getObjectByProjecte(p.id)
    '                    If pc IsNot Nothing Then
    '                        cGB.centres.Add(ModelCentre.getObject(pc.idCentre))
    '                    End If
    '                    pc = Nothing
    '                End If
    '                i = i + 1
    '            Next f
    '            Call fAvis.tancar()
    '            '    End If
    '            Call ModulExportTransitoria.execute(mesos)
    '            cGB.anyActual = mesos.any
    '            cGB.rutaGB = tempRutaGb
    '            cGB.mesActual = mesActiu
    '            cGB.empresa = ModelEmpresa.getObject(mesos.idEmpresa)
    '            cGB.participacio = cGB.empresa.participacio
    '            cGB.contaplus = ModelEmpresaContaplus.getObjectByEmpresaAny(cGB.empresa.id, mesos.any)

    '            If CONFIG.fileExist(cGB.rutaGB) And cGB.participacio > 0 Then
    '                entradesLog = ModulActualitzacioGB.actualitzarData(cGB, mesos.mesos, True)
    '                If entradesLog IsNot Nothing Then logTransitoria.entrades.AddRange(entradesLog)

    '            End If
    '            If ModelLog.hihaErrors(logTransitoria.entrades) Then
    '                Call dLogs.setLog(logTransitoria)
    '            End If
    '            If mesos.isLog Then Call ModelInformes.executeLog(logTransitoria)
    '        End If
    '    End If
    '    Call EXCEL.closeMacros(apliExcel)
    '    mesos = Nothing
    '    wb = Nothing
    '    ws = Nothing
    '    transitories = Nothing

    '    cGB = Nothing
    '    Call EXCEL.LiberarMemoria()
    'End Sub
    Private Function importData(dades(,) As String, fActual As Integer, a As Integer, m As Integer, idProjecte As Integer, idEmpresa As Integer) As List(Of Transitoria)
        Dim t As Transitoria, i As Integer, s As Subcompte, iaan As Integer, iaac As Integer, isan As Integer, isac As Integer, ias As Integer
        Dim temp As Transitoria, existeix As Boolean
        temp = New Transitoria
        temp.mes = m
        temp.anyo = a
        importData = Nothing
        iaan = getColumna(dades, fActual, temp.codiAcrualsAnyAnterior)
        iaac = getColumna(dades, fActual, temp.codiAcrualsAny)
        isan = getColumna(dades, fActual, temp.codiSafetiesAnyAnterior)
        isac = getColumna(dades, fActual, temp.codiSafetiesAny)
        ias = getColumna(dades, fActual, temp.codiAcrualsSafetiesAny)
        If ias > 0 Then
            importData = New List(Of Transitoria)
            For i = fActual To UBound(dades, 1)
                existeix = False
                If dades(i, 0) <> "" Then
                    s = ModelSubcompte.getobject(CStr(dades(i, 0)))
                    If s IsNot Nothing Then
                        t = New Transitoria
                        t.idSubcompte = s.id
                        t.anyo = a
                        t.mes = m
                        t.idEmpresa = idEmpresa
                        t.idProjecte = idProjecte
                        If iaac > 0 Then If IsNumeric(dades(i, iaac)) Then t.valorAActual = CDbl(dades(i, iaac))
                        If iaan > 0 Then If IsNumeric(dades(i, iaan)) Then t.valorAAnterior = CDbl(dades(i, iaan))
                        If ias > 0 Then
                            If IsNumeric(dades(i, ias)) Then
                                t.valorAS = CDbl(dades(i, ias))
                                Call actualitzarLog(CONFIG.tipusEntradaLog.MIS_LOG, IDIOMA.getString("import"), s.ToString & " = " & Format(dades(i, ias), "#,##0.00"))
                            Else
                                Call actualitzarLog(CONFIG.tipusEntradaLog.ERR_LOG, IDIOMA.getString("errImport"), s.ToString & " =" & IDIOMA.getString("noNumeric"))
                            End If
                        Else
                            Call actualitzarLog(CONFIG.tipusEntradaLog.ERR_LOG, IDIOMA.getString("errCodi"), s.ToString & " = " & IDIOMA.getString("noCodi") & " " & t.codiAcrualsSafetiesAny)
                        End If
                        If isac > 0 Then If IsNumeric(dades(i, isac)) Then t.valorSActual = CDbl(dades(i, isac))
                        If isan > 0 Then If IsNumeric(dades(i, isan)) Then t.valorSAnterior = CDbl(dades(i, isan))
                        existeix = True
                    ElseIf ModelYSheet.exist(CStr(DADES(i, 0))) Then
                        t = New Transitoria
                        t.anyo = a
                        t.mes = m
                        t.idProjecte = idProjecte
                        t.idEmpresa = idEmpresa
                        t.codiYellowSheet = dades(i, 0)
                        If ias > 0 Then
                            If IsNumeric(dades(i, ias)) Then
                                t.valorAS = CDbl(dades(i, ias))
                                Call actualitzarLog(CONFIG.tipusEntradaLog.MIS_LOG, IDIOMA.getString("import"), dades(i, 1) & " = " & Format(dades(i, ias), "#,##0.00"))
                            Else
                                Call actualitzarLog(CONFIG.tipusEntradaLog.ERR_LOG, IDIOMA.getString("errImport"), dades(i, 1) & " = " & IDIOMA.getString("noNumeric"))
                            End If
                        Else
                            Call actualitzarLog(CONFIG.tipusEntradaLog.ERR_LOG, IDIOMA.getString("errCodi"), dades(i, 1) & " = " & IDIOMA.getString("noCodi") & t.codiAcrualsSafetiesAny)
                        End If
                        existeix = True
                    End If
                    If existeix Then importData.Add(t)
                End If
            Next i
        End If
        temp = Nothing
        t = Nothing
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
        Dim i As Integer, j As Integer, trobat As Boolean
        trobat = False
        getProjecte = Nothing
        For i = LBound(dades, 1) To 10
            For j = LBound(dades, 2) To 10
                If UCase(dades(i, j)) = EXPLOTACION Then
                    trobat = True
                    If InStr(1, dades(i, j + 1), "(" & ModelEmpresa.getCodiEmpresa(idEmpresa) & ")", vbTextCompare) <> 0 Then
                        getProjecte = ModelProjecte.getObject(Left(dades(i, j + 1), 9), idEmpresa)
                    End If
                    Exit For
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
                If UCase(xls(i, j)) = EXPLOTACION Then
                    trobat = True
                    If IsDate(xls(i, j + 3)) Then
                        If Year(xls(i, j + 3)) = anyo Then
                            isAnyActual = True
                        End If
                    ElseIf IsNumeric(xls(i, j + 3)) Then
                        If xls(i, j + 3) = anyo Then
                            isAnyActual = True
                        End If
                    End If
                    Exit For
                End If
            Next j
            If trobat Then Exit For
        Next i
    End Function
    Private Function getRangResumen(dades(,) As String) As Integer
        Dim i As Integer, j As Integer, trobat As Boolean
        trobat = False
        getRangResumen = Nothing

        For i = LBound(dades, 1) To UBound(dades, 1)
            For j = LBound(dades, 2) To UBound(dades, 2)
                If UCase(dades(i, j)) = RESUMEN Then
                    trobat = True
                    getRangResumen = i
                    Exit For
                End If
            Next j
            If trobat Then Exit For
        Next i
    End Function
    'Private Function existCodiYellowSheet(codi As String) As Boolean
    '    existCodiYellowSheet = False
    '    If UCase(codi) = TREATMENT Or UCase(codi) = PURCHASED Or UCase(codi) = SPARES Or UCase(codi) = OTHERT Or UCase(codi) = OTHERO Or UCase(codi) = REVENUES Then existCodiYellowSheet = True
    'End Function

    Private Function getColumna(dades(,) As String, f As Integer, codi As String) As Integer
        Dim i As Integer
        getColumna = -1
        For i = 1 To 10
            If dades(f, i) <> "" Then
                If StrComp(dades(f, i), codi, vbTextCompare) = 0 Then
                    getColumna = i
                    Exit For
                End If
            End If
        Next i
    End Function
    Private Sub actualitzarLog(codi As tipusEntradaLog, titol As String, descripcio As String)
        logTransitoria.entrades.Add(ModelLog.getEntradaLog(codi, titol, descripcio))
    End Sub
    Public Sub setTempParticipacio(i As Integer)
        tempParticipacio = i
    End Sub
    Public Sub setTempRutaGB(s As String)
        tempRutaGb = s
    End Sub
End Module
