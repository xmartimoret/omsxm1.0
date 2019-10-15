Option Explicit On
Imports Microsoft.Office.Interop.Excel
Module ModulExportTransitoria
    '@ MODUL            ModulExportTransitoria
    '@ DESCRIPCIO       Exporta dades de transitories de TRANSI.DBF a un FITXER RESUM.xls
    '                   1. Agafa les transitories
    '                   2. Posa les transitories per clients i projectes
    '                   3. Carregar les dades al FITXER RESUM.xls (ModelPlantillaTransitoria)
    '                   4. Crea el LOG d'exportació (ModulInformes.crearLog)
    '@ DATA             06/01/2015
    '@ AUTOR            xmarti
    '@ OBSERVACIONS     Cal revisar el funcionament de quan s'exporten varis mesos. (Sub setTransitories)
    '                   Falta provar el client Predeterminat ALTRES

    Private mesos As AnyMesos
    Private logActual As Log
    Private Const FULLA_PLANTILLA As String = "PLANTILLA"
    '@PROCEDIMENT   SUB EXECUTE
    '@DESCRIPCIO    Carrega les dades de transitòries que estan guardades a la base de dades TRANSI.DBF
    '@ENTRADES      Optional m (AnyMesos) Variable on es guarda l'informació sobre els mesos, empresa i any a exportar.
    '               En cas que m=Nothing el procediment demana a l'usuari les dades.
    '@DATA          06/01/2015
    '@AUTOR         xmarti
    '@OBSERVACIONS  Provat, cal revisar  el funcionament quan s'exporten varis mesos.
    '               Cal revisar i implementar el funcionament després d'una importació de dades.
    Public Sub execute(Optional m As AnyMesos = Nothing)
        Dim wb As Workbook, wbTemp As Workbook, fitxer As String, codiFitxer As Integer, rutaFitxer As String, wbs As Application
        Call ModelLog.resetIndex()
        logActual = New Log
        wbs = EXCEL.getAplicacioExcel
        logActual.titol = IDIOMA.getString("exportTransitoria")
        logActual.descripcio = IDIOMA.getString("exportTransitoria1")
        wb = Nothing
        If m IsNot Nothing Then
            mesos = m
        Else
            mesos = DMesosEmpresa.getMesos((CONFIG_FILE.getTag(TAG.ANY_TRANSITORIA)), IDIOMA.getString("exportTransitoriaCaption"))
        End If
        If mesos IsNot Nothing Then
            CONFIG_FILE.setTag(TAG.ANY_TRANSITORIA, mesos.any)
            If wbs IsNot Nothing Then
                For Each wbTemp In wbs.Workbooks
                    If modelPlantillaTransitoria.isWorkbookTransitoria(wbTemp, mesos.any, mesos.idEmpresa) = 0 Then
                        wb = wbTemp
                        'TODO  XMARTI 14/06/2018 , ES AQUI QUE FALLA EN EL EXCEL 64 BITS
                        'AppActivate(wb.Name)
                        Exit For
                    End If
                Next wbTemp
            End If
            If wb Is Nothing Then
                fitxer = CONFIG_FILE.getTag(TAG.EXPORT_TRANSITORIA, mesos.idEmpresa)
                If Not CONFIG.fileExist(fitxer) Then
                    rutaFitxer = CONFIG_FILE.getTag(TAG.EXPORT_TRANSITORIA, mesos.idEmpresa)
                    fitxer = New SelectFiles(IDIOMA.getString("escollirResumTransitoria") & " " & ModelEmpresa.getNom((mesos.idEmpresa)), False, rutaFitxer, IDIOMA.getString("resumTransi") & ". {" & ModelEmpresa.getNom((mesos.idEmpresa)) & "}  *.xls*|*.xls*").fitxer
                End If
                If CONFIG.fileExist(fitxer) Then
                    Call CONFIG_FILE.setTag(TAG.EXPORT_TRANSITORIA, mesos.idEmpresa)
                    wbTemp = EXCEL.openWorkbook(fitxer, False)
                    codiFitxer = modelPlantillaTransitoria.isWorkbookTransitoria(wbTemp, mesos.any, mesos.idEmpresa)
                    If codiFitxer = 0 Then
                        wb = wbTemp
                        logActual.entrades.Add(getELog(CONFIG.tipusEntradaLog.AVIS_log, IDIOMA.getString("iniExport"), IDIOMA.getString("exportTransitoria1") & " " & wb.Path & "\" & wb.Name))
                    ElseIf codiFitxer = 1 Then
                        Call ERRORS.ERR_NO_FITXER_TRANSITORIA()
                        logActual.entrades.Add(getELog(CONFIG.tipusEntradaLog.ERR_LOG, IDIOMA.getString("errNoFitxer"), IDIOMA.getString("errNoFitxer1") & " " & wbTemp.Path & "\" & wbTemp.Name & " " & IDIOMA.getString("errNoFitxer2")))
                        wbTemp.Close(False)
                    ElseIf codiFitxer = 2 Then
                        Call ERRORS.ERR_NO_ANY_FITXER_TRANSITORIA()
                        logActual.entrades.Add(getELog(CONFIG.tipusEntradaLog.ERR_LOG, IDIOMA.getString("errNoAny"), IDIOMA.getString("errNoFitxer1") & " " & wbTemp.Path & "\" & wbTemp.Name & " " & IDIOMA.getString("errNoAny1") & " " & mesos.any))
                        wbTemp.Close(False)
                    ElseIf codiFitxer = 3 Then
                        Call ERRORS.ERR_NO_EMPRESA_FITXER_TRANSITORIA()
                        logActual.entrades.Add(getELog(CONFIG.tipusEntradaLog.ERR_LOG, IDIOMA.getString("errNoEmpresa"), IDIOMA.getString("errNoFitxer1") & " " & wbTemp.Path & "\" & wbTemp.Name & " " & IDIOMA.getString("errNoEmpresa1") & " " & ModelEmpresa.getObject(mesos.idEmpresa).ToString))
                        wbTemp.Close(False)
                    End If
                    wb.Application.Visible = True
                    wb.Activate()
                End If
            End If
            If wb IsNot Nothing Then
                wb.Application.Visible = True
                wb.Activate()

                Call setTransitories(wb)
                Call CONFIG_FILE.setTag(TAG.EXPORT_TRANSITORIA, mesos.idEmpresa)
            End If
            Call FrmApliOms.Activate()
            Call MISSATGES.DATA_UPDATED()
        End If
        If mesos IsNot Nothing Then If mesos.isLog Then Call ModelInformes.executeLog(logActual)
        mesos = Nothing
        wb = Nothing
        wbTemp = Nothing
        logActual = Nothing
        wbs = Nothing
    End Sub
    '@PROCEDIMENT   SUB SETTRANSITORIES
    '@DESCRIPCIO    Carrega les dades de les transitories guardades a la base de dades TRANSI.DBF
    '@ENTRADES      wb (Workbook) Llibre on s'exportaran les transitories
    '@DATA          06/06/2015
    '@AUTOR         xmarti
    '@OBSERVACIONS  Crec que he trobat l'error que no agafa les dades de varis mesos. ja que es matxaquen les dades.
    '               Veure la sentència modelTransitoria.getObjects (e,any, m)
    Private Sub setTransitories(wb As Workbook)
        Dim m As Integer, e As Empresa, transitories As List(Of Transitoria), clients As List(Of Client), dades(,) As String
        Dim ws As Worksheet, xlsApp As Application
        e = ModelEmpresa.getObject(mesos.idEmpresa)
        xlsApp = EXCEL.getMacros
        For m = 1 To 12
            If mesos.esActiu(m) Then
                transitories = ModelTransitoria.getObjects(e, mesos.any, m)
                logActual.entrades.Add(getELog(CONFIG.tipusEntradaLog.AVIS_log, IDIOMA.getString("getData"), IDIOMA.getString("getData1") & " " & CONFIG.mesNom(m) & "-" & mesos.any & " " & IDIOMA.getString("deEmpresa") & " " & e.ToString))
                If transitories IsNot Nothing Then ' testejat
                    clients = getClients(transitories, e)
                    dades = getStringClients(clients)
                    If clients IsNot Nothing Then
                        ws = getWorksheetMes(wb, m, mesos.any)
                        If ws IsNot Nothing Then
                            'Call setEntradesLog(modelPlantillaTransitoria.setClients(clients, wb, m, mesos.any))
                            Call xlsApp.Run("exportTransitoria", wb, ws, dades)
                            ws.Range("B4").Value = IDIOMA.getString("actualitzar") & ": " & Format(Now, "dd-MM-yy hh:mm") & Chr(10) & "Per: " & Environment.UserName
                        End If

                    End If
                Else
                    logActual.entrades.Add(getELog(CONFIG.tipusEntradaLog.AVIS_log, IDIOMA.getString("noDades"), IDIOMA.getString("noDadesTransitories") & " " & CONFIG.mesNom(m) & "-" & mesos.any & " " & IDIOMA.getString("deEmpresa") & " " & e.ToString))
                End If
            End If
        Next m
        Call EXCEL.closeMacros(xlsApp)
        e = Nothing
        transitories = Nothing
        clients = Nothing
        ws = Nothing
    End Sub
    '@PROCEDIMENT   FUNCTION GETCLIENTS
    '@DESCRIPCIO    Classifica les transitories per projectes_client. Recorre la collecció de transitòries i les posa en el seu projecte corresponen
    '               En cas que el projecte no pertany a un Client els posa a ALTRES (Client predeterminat).
    '@ENTRADES      transitories(Collection)    Collecció de transitories carregades en el procediment anterior.
    '               e(Empresa)                  Empresa de la qual pertanyen les transitories
    '@SORTIDA       (ColleccioOrdenada)         Collecció ordenada de clients-projectes-transitories
    '@DATA          06/01/2016
    '@AUTOR         xmarti
    '@OBSERVACIONS  Provat sense problemes. Falta testejar quan hi ha projectes al client ALTRES
    Private Function getClients(transitories As List(Of Transitoria), e As Empresa) As List(Of Client)
        Dim clients As List(Of Client), t As Transitoria, altres As Client, c As Client, p As ProjecteClient, afegida As Boolean
        Dim tempProjecte As Projecte
        Call ModelProjecteClient.resetIndex()
        clients = ModelClient.getObjects()
        For Each c In clients
            c.projectes = ModelProjecteClient.getObjects(c.id, e.id)
        Next c
        altres = New Client
        altres.nom = IDIOMA.getString("altres")
        altres.id = clients.Count + 1
        altres.ordre = clients.Count + 1
        altres.notes = IDIOMA.getString("projectesNoClient")
        For Each t In transitories
            afegida = False
            For Each c In clients
                For Each p In c.projectes
                    If t.idProjecte = p.idProjecte Then
                        p.transitories.Add(t)
                        afegida = True
                        Exit For
                    End If
                Next p
                If afegida Then Exit For
            Next c
            If Not afegida Then
                For Each p In altres.projectes
                    If t.idProjecte = p.idProjecte Then
                        p.transitories.Add(t)
                        afegida = True
                        Exit For
                    End If
                Next p
                If Not afegida Then
                    tempProjecte = ModelProjecte.getObject(t.idProjecte)
                    p = New ProjecteClient
                    p.clau = Right(tempProjecte.codi, 6)
                    p.departa = Left(tempProjecte.codi, 3)
                    p.idClient = altres.id
                    p.idEmpresa = tempProjecte.idEmpresa
                    p.idProjecte = tempProjecte.id
                    p.ordre = altres.projectes.Count + 1
                    p.transitories.Add(t)
                    p.toStringTransitoria = tempProjecte.ToString
                    altres.projectes.Add(p)
                End If
            End If
        Next t
        clients.Add(altres)
        getClients = clients
        t = Nothing
        altres = Nothing
        p = Nothing
        tempProjecte = Nothing
        c = Nothing
        clients = Nothing
    End Function
    '@PROCEDIMENT   FUNCTION GETELOG
    '@DESCRIPCIO    Crea una entrada de log
    '@ENTRADES      ... els diferents camps que composen una entreda Log
    '@SORTIDA       entradaLog
    '@DATA          06/01/2016
    '@AUTOR         xmarti
    Private Function getELog(codi As tipusEntradaLog, titol As String, descripcio As String) As EntradaLog
        Return ModelLog.getEntradaLog(codi, titol, descripcio)
    End Function
    '@PROCEDIMENT   SUB SETENTRADALOG
    '@DESCRIPCIO    Afegeix varies entrades log a la collecció d'entrades
    '@ENTRADES      c(Collection)   entrades a afegir
    '@DATA          06/01/2016
    '@AUTOR         xmarti
    Private Sub setEntradesLog(c As List(Of EntradaLog))
        logActual.entrades.AddRange(c)
    End Sub

    Private Function getStringClients(clients As List(Of Client)) As String(,)
        Dim dades(30000, 8) As String, i As Integer, c As Client, p As ProjecteClient, t As Transitoria

        i = 0
        For Each c In clients
            For Each p In c.projectes
                If i <= 30000 Then
                    dades(i, 0) = "client"
                    dades(i, 1) = c.nom
                    dades(i, 2) = p.toStringTransitoria
                    dades(i, 3) = c.color
                    i = i + 1
                End If
                For Each t In p.transitories
                    If i <= 30000 Then
                        dades(i, 0) = "transitoria"
                        dades(i, 1) = c.nom
                        dades(i, 2) = p.toStringTransitoria
                        dades(i, 3) = ModelSubcompte.getCodi(t.idSubcompte)
                        dades(i, 4) = t.valorAS
                        dades(i, 5) = t.valorAAnterior
                        dades(i, 6) = t.valorAActual
                        dades(i, 7) = t.valorSAnterior
                        dades(i, 8) = t.valorSActual
                        i = i + 1
                    End If
                Next
            Next
        Next
        getStringClients = CONFIG.redimensionarArrayBidimensional(dades, i, 8)
        c = Nothing
        t = Nothing
        p = Nothing
        dades = Nothing
    End Function

    Private Function getWorksheetMes(wb As Workbook, m As Integer, a As Integer) As Worksheet
        Dim nomMes As String, wsPlantilla As Worksheet, wsMes As Worksheet
        nomMes = CONFIG.mesNom(m) & " - " & a
        wsPlantilla = getWorksheetPlantilla(wb)
        wsMes = Nothing
        If wsPlantilla IsNot Nothing Then
            wsPlantilla.Visible = True
            For Each ws In wb.Worksheets
                If StrComp(ws.Name, nomMes, vbTextCompare) = 0 Then
                    wsMes = ws
                    Exit For
                End If
            Next ws
            If wsMes Is Nothing Then
                wsPlantilla.Copy(wsPlantilla)
                wsMes = wb.ActiveSheet
                wsMes.Name = nomMes
                wsMes.Range("b3").Value = nomMes
            End If
            wsPlantilla.Visible = False
        End If
        getWorksheetMes = wsMes
        wsMes = Nothing
        wsPlantilla = Nothing
    End Function
    Private Function getWorksheetPlantilla(wb As Workbook) As Worksheet
        Dim ws As Worksheet
        getWorksheetPlantilla = Nothing
        For Each ws In wb.Worksheets
            If ws.Name = FULLA_PLANTILLA Then
                getWorksheetPlantilla = ws
                Exit For
            End If
        Next ws
        ws = Nothing
    End Function
End Module
'Option Explicit On
'Imports Microsoft.Office.Interop.Excel
'Module ModulExportTransitoria
'    '@ MODUL            ModulExportTransitoria
'    '@ DESCRIPCIO       Exporta dades de transitories de TRANSI.DBF a un FITXER RESUM.xls
'    '                   1. Agafa les transitories
'    '                   2. Posa les transitories per clients i projectes
'    '                   3. Carregar les dades al FITXER RESUM.xls (ModelPlantillaTransitoria)
'    '                   4. Crea el LOG d'exportació (ModulInformes.crearLog)
'    '@ DATA             06/01/2015
'    '@ AUTOR            xmarti
'    '@ OBSERVACIONS     Cal revisar el funcionament de quan s'exporten varis mesos. (Sub setTransitories)
'    '                   Falta provar el client Predeterminat ALTRES

'    Private mesos As AnyMesos
'    Private logActual As Log
'    '@PROCEDIMENT   SUB EXECUTE
'    '@DESCRIPCIO    Carrega les dades de transitòries que estan guardades a la base de dades TRANSI.DBF
'    '@ENTRADES      Optional m (AnyMesos) Variable on es guarda l'informació sobre els mesos, empresa i any a exportar.
'    '               En cas que m=Nothing el procediment demana a l'usuari les dades.
'    '@DATA          06/01/2015
'    '@AUTOR         xmarti
'    '@OBSERVACIONS  Provat, cal revisar  el funcionament quan s'exporten varis mesos.
'    '               Cal revisar i implementar el funcionament després d'una importació de dades.
'    Public Sub execute(Optional m As AnyMesos = Nothing)
'        Dim wb As Workbook, wbTemp As Workbook, fitxer As String, codiFitxer As Integer, rutaFitxer As String, wbs As Application
'        Call ModelLog.resetIndex()
'        logActual = New Log
'        wbs = EXCEL.getAplicacioExcel
'        logActual.titol = IDIOMA.getString("exportTransitoria")
'        logActual.descripcio = IDIOMA.getString("exportTransitoria1")
'        wb = Nothing
'        If m IsNot Nothing Then
'            mesos = m
'        Else
'            mesos = dImportTransitories.getMesosExport
'        End If
'        If mesos IsNot Nothing Then
'            If wbs IsNot Nothing Then
'                For Each wbTemp In wbs.Workbooks
'                    If modelPlantillaTransitoria.isWorkbookTransitoria(wbTemp, mesos.any, mesos.idEmpresa) = 0 Then
'                        wb = wbTemp
'                        AppActivate(wb.Name)
'                        Exit For
'                    End If
'                Next wbTemp
'            End If
'            If wb Is Nothing Then
'                fitxer = CONFIG_FILE.getTag(TAG.EXPORT_TRANSITORIA, mesos.idEmpresa)
'                If Not CONFIG.fileExist(fitxer) Then
'                    rutaFitxer = CONFIG_FILE.getTag(TAG.EXPORT_TRANSITORIA, mesos.idEmpresa)
'                    fitxer = New SelectFiles(IDIOMA.getString("escollirResumTransitoria") & " " & ModelEmpresa.getNom((mesos.idEmpresa)), False, rutaFitxer, IDIOMA.getString("resumTransi") & ". {" & ModelEmpresa.getNom((mesos.idEmpresa)) & "}  *.xls*|*.xls*").fitxer
'                End If
'                If CONFIG.fileExist(fitxer) Then
'                    Call CONFIG_FILE.setTag(TAG.EXPORT_TRANSITORIA, mesos.idEmpresa)
'                    wbTemp = EXCEL.openWorkbook(fitxer, False)
'                    codiFitxer = modelPlantillaTransitoria.isWorkbookTransitoria(wbTemp, mesos.any, mesos.idEmpresa)
'                    If codiFitxer = 0 Then
'                        wb = wbTemp
'                        logActual.entrades.Add(getELog(CONFIG.tipusEntradaLog.AVIS_log, IDIOMA.getString("iniExport"), IDIOMA.getString("exportTransitoria1") & " " & wb.Path & "\" & wb.Name))
'                    ElseIf codiFitxer = 1 Then
'                        Call ERRORS.ERR_NO_FITXER_TRANSITORIA()
'                        logActual.entrades.Add(getELog(CONFIG.tipusEntradaLog.ERR_LOG, IDIOMA.getString("errNoFitxer"), IDIOMA.getString("errNoFitxer1") & " " & wbTemp.Path & "\" & wbTemp.Name & " " & IDIOMA.getString("errNoFitxer2")))
'                        wbTemp.Close(False)
'                    ElseIf codiFitxer = 2 Then
'                        Call ERRORS.ERR_NO_ANY_FITXER_TRANSITORIA()
'                        logActual.entrades.Add(getELog(CONFIG.tipusEntradaLog.ERR_LOG, IDIOMA.getString("errNoAny"), IDIOMA.getString("errNoFitxer1") & " " & wbTemp.Path & "\" & wbTemp.Name & " " & IDIOMA.getString("errNoAny1") & " " & mesos.any))
'                        wbTemp.Close(False)
'                    ElseIf codiFitxer = 3 Then
'                        Call ERRORS.ERR_NO_EMPRESA_FITXER_TRANSITORIA()
'                        logActual.entrades.Add(getELog(CONFIG.tipusEntradaLog.ERR_LOG, IDIOMA.getString("errNoEmpresa"), IDIOMA.getString("errNoFitxer1") & " " & wbTemp.Path & "\" & wbTemp.Name & " " & IDIOMA.getString("errNoEmpresa1") & " " & ModelEmpresa.getObject(mesos.idEmpresa).ToString))
'                        wbTemp.Close(False)
'                    End If

'                End If
'            End If
'            If wb IsNot Nothing Then
'                wb.Application.Calculation = XlCalculation.xlCalculationManual
'                Call setTransitories(wb)
'                Call CONFIG_FILE.setTag(TAG.EXPORT_TRANSITORIA, mesos.idEmpresa)
'                wb.Application.Calculation = XlCalculation.xlCalculationAutomatic
'            End If
'        End If


'        If mesos IsNot Nothing Then If mesos.isLog Then Call ModelInformes.executeLog(logActual)
'        mesos = Nothing
'        wb = Nothing
'        wbTemp = Nothing
'        logActual = Nothing
'        wbs = Nothing
'    End Sub
'    '@PROCEDIMENT   SUB SETTRANSITORIES
'    '@DESCRIPCIO    Carrega les dades de les transitories guardades a la base de dades TRANSI.DBF
'    '@ENTRADES      wb (Workbook) Llibre on s'exportaran les transitories
'    '@DATA          06/06/2015
'    '@AUTOR         xmarti
'    '@OBSERVACIONS  Crec que he trobat l'error que no agafa les dades de varis mesos. ja que es matxaquen les dades.
'    '               Veure la sentència modelTransitoria.getObjects (e,any, m)
'    Private Sub setTransitories(wb As Workbook)
'        Dim m As Integer, e As Empresa, transitories As List(Of Transitoria), clients As List(Of Client), dades(,) As String
'        e = ModelEmpresa.getObject(mesos.idEmpresa)
'        For m = 1 To 12
'            If mesos.esActiu(m) Then
'                transitories = ModelTransitoria.getObjects(e, mesos.any, m)


'                logActual.entrades.Add(getELog(CONFIG.tipusEntradaLog.AVIS_log, IDIOMA.getString("getData"), IDIOMA.getString("getData1") & " " & CONFIG.mesNom(m) & "-" & mesos.any & " " & IDIOMA.getString("deEmpresa") & " " & e.ToString))
'                If transitories IsNot Nothing Then ' testejat
'                    clients = getClients(transitories, e)
'                    dades = getStringClients(clients)
'                    If clients IsNot Nothing Then
'                        Call setEntradesLog(modelPlantillaTransitoria.setClients(clients, wb, m, mesos.any))
'                    End If
'                Else
'                    logActual.entrades.Add(getELog(CONFIG.tipusEntradaLog.AVIS_log, IDIOMA.getString("noDades"), IDIOMA.getString("noDadesTransitories") & " " & CONFIG.mesNom(m) & "-" & mesos.any & " " & IDIOMA.getString("deEmpresa") & " " & e.ToString))
'                End If
'            End If
'        Next m
'        e = Nothing
'        transitories = Nothing
'        clients = Nothing
'    End Sub
'    '@PROCEDIMENT   FUNCTION GETCLIENTS
'    '@DESCRIPCIO    Classifica les transitories per projectes_client. Recorre la collecció de transitòries i les posa en el seu projecte corresponen
'    '               En cas que el projecte no pertany a un Client els posa a ALTRES (Client predeterminat).
'    '@ENTRADES      transitories(Collection)    Collecció de transitories carregades en el procediment anterior.
'    '               e(Empresa)                  Empresa de la qual pertanyen les transitories
'    '@SORTIDA       (ColleccioOrdenada)         Collecció ordenada de clients-projectes-transitories
'    '@DATA          06/01/2016
'    '@AUTOR         xmarti
'    '@OBSERVACIONS  Provat sense problemes. Falta testejar quan hi ha projectes al client ALTRES
'    Private Function getClients(transitories As List(Of Transitoria), e As Empresa) As List(Of Client)
'        Dim clients As List(Of Client), t As Transitoria, altres As Client, c As Client, p As ProjecteClient, afegida As Boolean
'        Dim tempProjecte As Projecte
'        Call ModelProjecteClient.resetIndex()
'        clients = ModelClient.getObjects()
'        For Each c In clients
'            c.projectes = ModelProjecteClient.getObjects(c.id, e.id)
'        Next c
'        altres = New Client
'        altres.nom = IDIOMA.getString("altres")
'        altres.id = clients.Count + 1
'        altres.ordre = clients.Count + 1
'        altres.notes = IDIOMA.getString("projectesNoClient")
'        For Each t In transitories
'            afegida = False
'            For Each c In clients
'                For Each p In c.projectes
'                    If t.idProjecte = p.idProjecte Then
'                        p.transitories.Add(t)
'                        afegida = True
'                        Exit For
'                    End If
'                Next p
'                If afegida Then Exit For
'            Next c
'            If Not afegida Then
'                For Each p In altres.projectes
'                    If t.idProjecte = p.idProjecte Then
'                        p.transitories.Add(t)
'                        afegida = True
'                        Exit For
'                    End If
'                Next p
'                If Not afegida Then
'                    tempProjecte = ModelProjecte.getObject(t.idProjecte)
'                    p = New ProjecteClient
'                    p.clau = Right(tempProjecte.codi, 6)
'                    p.departa = Left(tempProjecte.codi, 3)
'                    p.idClient = altres.id
'                    p.idEmpresa = tempProjecte.idEmpresa
'                    p.idProjecte = tempProjecte.id
'                    p.ordre = altres.projectes.Count + 1
'                    p.transitories.Add(t)
'                    p.toStringTransitoria = tempProjecte.ToString
'                    altres.projectes.Add(p)
'                End If
'            End If
'        Next t
'        clients.Add(altres)
'        getClients = clients
'        t = Nothing
'        altres = Nothing
'        p = Nothing
'        tempProjecte = Nothing
'        c = Nothing
'        clients = Nothing
'    End Function
'    '@PROCEDIMENT   FUNCTION GETELOG
'    '@DESCRIPCIO    Crea una entrada de log
'    '@ENTRADES      ... els diferents camps que composen una entreda Log
'    '@SORTIDA       entradaLog
'    '@DATA          06/01/2016
'    '@AUTOR         xmarti
'    Private Function getELog(codi As tipusEntradaLog, titol As String, descripcio As String) As EntradaLog
'        Return ModelLog.getEntradaLog(codi, titol, descripcio)
'    End Function
'    '@PROCEDIMENT   SUB SETENTRADALOG
'    '@DESCRIPCIO    Afegeix varies entrades log a la collecció d'entrades
'    '@ENTRADES      c(Collection)   entrades a afegir
'    '@DATA          06/01/2016
'    '@AUTOR         xmarti
'    Private Sub setEntradesLog(c As List(Of EntradaLog))
'        logActual.entrades.AddRange(c)
'    End Sub

'    Private Function getStringClients(clients As List(Of Client)) As String(,)
'        Dim dades(30000, 8) As String, i As Integer, c As Client, p As ProjecteClient, t As Transitoria

'        i = 0
'        For Each c In clients
'            For Each p In c.projectes
'                If i <= 30000 Then
'                    dades(i, 0) = "client"
'                    dades(i, 1) = c.nom
'                    dades(i, 2) = p.toStringTransitoria
'                    dades(i, 3) = c.color
'                    i = i + 1
'                End If
'                For Each t In p.transitories
'                    If i <= 30000 Then
'                        dades(i, 0) = "transitoria"
'                        dades(i, 1) = c.nom
'                        dades(i, 2) = p.toStringTransitoria
'                        dades(i, 3) = ModelSubcompte.getCodi(t.idSubcompte)
'                        dades(i, 4) = t.valorAS
'                        dades(i, 5) = t.valorAAnterior
'                        dades(i, 6) = t.valorAActual
'                        dades(i, 7) = t.valorSAnterior
'                        dades(i, 8) = t.valorSActual
'                        i = i + 1
'                    End If
'                Next
'            Next
'        Next
'        getStringClients = CONFIG.redimensionarArrayBidimensional(dades, i, 7)
'        c = Nothing
'        t = Nothing
'        p = Nothing
'        dades = Nothing
'    End Function
'End Module
