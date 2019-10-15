Option Explicit On
Imports Microsoft.Office.Interop.Excel
Module ModulImportAndorra
    ' notes 02/02/2016.
    ' cal donar d'alta l'ute andorra.
    ' cal revisar el save data i com agafa els valors ,
    ' cal implementar  el log  perque revisi si els subcomptes d'andorra pertanyen a un subgrup. i avisar.
    ' també cal avisar  si hi ha un subcompte que no estigui donat d'alta. (revisar si te  7 digits i es un valor  numeric)
    ''NOTES 02/02/2016 . CAL COMPROVAR ELS MESOS I ELS ANYS

    Private subcomptes As List(Of Subcompte)
    Private anyActual As Integer
    Private assentaments(0 To 12) As Collection
    Private mesActual As Integer
    Private projecteActual As Projecte
    Private empresaActual As Empresa
    Private dadesCentres As CentresGB
    Private logActual As Log
    Private Const FULLA_PRETANCAMENT As String = "PRETANCAMENT"
    Private fAvis As frmAvis
    Public Sub execute()
        Dim projectes As List(Of Projecte), isOpen As Boolean
        Dim wbActual As Workbook, wsActual As Worksheet

        Call ModelLog.resetIndex()
        logActual = New Log
        logActual.descripcio = IDIOMA.getString("logImportDadesAndorra")
        logActual.titol = IDIOMA.getString("logImportAndorraTitol")
        dadesCentres = dImportUtes.getDadesAndorra
        Call resetIndex()

        empresaActual = ModelEmpresa.getObject(CONFIG.getCodiAndorra)
        If dadesCentres IsNot Nothing Then
            fAvis = New frmAvis(IDIOMA.getString("actualitzar"), "ANDORRA", "")
            anyActual = dadesCentres.anyActual
            mesActual = dadesCentres.mesActual
            Call actualitzarLog(CONFIG.tipusEntradaLog.AVIS_log, IDIOMA.getString("iniImport"), IDIOMA.getString("iniImport1") & anyActual)
            projectes = ModelProjecte.getObjects(empresaActual.id)
            If projectes.Count = 1 Then
                projecteActual = projectes.Item(0)
            ElseIf projectes.Count > 1 Then
                projectes = DProjectes.getProjectes(1, empresaActual.id)
                If projectes.Count > 0 Then
                    projecteActual = projectes.Item(1)
                End If
            End If
            If TypeName(projecteActual) = "Projecte" Then
                wbActual = EXCEL.getWorkbook(CONFIG.getFitxer(dadesCentres.rutaGB))
                isOpen = True
                If wbActual Is Nothing Then
                    isOpen = False
                    wbActual = EXCEL.openWorkbook(dadesCentres.rutaGB, False, True)
                End If
                wsActual = getWorksheetPretancamentAndorra(wbActual, projecteActual.codi)
                If wsActual IsNot Nothing Then
                    fAvis.setData(IDIOMA.getString("obrirFitxer"), wbActual.Name, "")
                    Call setData(wsActual)
                    If Not isOpen Then wbActual.Close(False)
                    fAvis.tancar()
                    Call FrmApliOms.setDataContaplus(empresaActual, ModelEmpresaContaplus.getObjectByEmpresaAny(empresaActual.id, anyActual), mesActual)
                    Call MISSATGES.DATA_UPDATED()
                Else
                    fAvis.tancar()
                    Call actualitzarLog(CONFIG.tipusEntradaLog.ERR_LOG, IDIOMA.getString("errLogAndorraPretancament"), IDIOMA.getString("errLogAndorraPretancament1") & " " & wbActual.Name & " " & IDIOMA.getString("errLogAndorraPretancament2"))
                    Call ERRORS.ERR_NO_FULLA_PRETANCAMENT()
                End If

            Else
                Call actualitzarLog(CONFIG.tipusEntradaLog.ERR_LOG, IDIOMA.getString("errLogAndorraProjecte"), IDIOMA.getString("errLogAndorraProjecte1"))
            End If
            If dadesCentres.isLog Then Call ModelInformes.executeLog(logActual)
        End If
        ' Call FrmApliOms.setLog(logActual)
        projecteActual = Nothing
        subcomptes = Nothing
        projectes = Nothing
        wbActual = Nothing
        dadesCentres = Nothing
        empresaActual = Nothing
        wsActual = Nothing
        logActual = Nothing
        fAvis = Nothing
    End Sub
    Private Sub setData(wsActual As Worksheet)
        Dim i As Integer, j As Integer, m As Integer, esAnyOk As Boolean, apliExcel As Application
        Dim subcta As Subcompte, a As Assentament, anytrobat As Integer, dades(,) As String
        apliExcel = EXCEL.getMacros
        dades = apliExcel.Run("llegirDades", wsActual, 20, 150)
        anytrobat = getAnyAndorra(dades)
        If anytrobat = anyActual Then
            esAnyOk = True
        Else
            Call actualitzarLog(CONFIG.tipusEntradaLog.ERR_LOG, IDIOMA.getString("logErrorAny"), IDIOMA.getString("errLogAndorraAny"))
            esAnyOk = False
            Call ERRORS.ERR_ANY()
        End If
        If esAnyOk Then
            For i = 1 To UBound(dades, 1)
                If dades(i, 0) <> "" Then
                    If IsNumeric(dades(i, 0)) Then
                        If Len(dades(i, 0)) = 7 Then
                            subcta = ModelSubcompte.getobject(CStr(dades(i, 0)))
                            If TypeName(subcta) = "Subcompte" Then
                                If Not ModelSubcomptesGrup.existSubcompte(subcta.id) Then Call actualitzarLog(CONFIG.tipusEntradaLog.AVIS_log, IDIOMA.getString("avisLogSubcompte"), IDIOMA.getString("elSubcompte") & " " & subcta.codi & ". " & IDIOMA.getString("avisLogSubcompteAndorra"))
                                j = getMes(1, dades)
                                If j > 0 Then
                                    For m = 1 To 12
                                        If mesActual = m Or mesActual = -1 Then
                                            fAvis.setData(subcta.codi, Left(subcta.nom, 24), dades(i, j))
                                            a = New Assentament
                                            a.numero = m
                                            a.subcompteAssentament = subcta.codi
                                            a.concepte = Left(subcta.nom, 24)
                                            a.clave = Right(projecteActual.codi, 6)
                                            If m = 12 Then
                                                a.dataAssentament = DateSerial(anyActual, m, 31)
                                            Else
                                                a.dataAssentament = DateAdd(DateInterval.Day, -1, DateSerial(anyActual, m + 1, 1))
                                            End If
                                            a.departamentAssentament = Left(projecteActual.codi, 3)
                                            If Left(a.subcompteAssentament, 1) = "6" Then
                                                If dades(i, j) < 0 Then
                                                    a.haver = Math.Round(dades(i, j) * 100 * -1, 0)
                                                    a.deure = 0
                                                Else
                                                    a.deure = Math.Round(dades(i, j) * 100, 0)
                                                    a.haver = 0
                                                End If
                                            Else
                                                If dades(i, j) > 0 Then
                                                    a.haver = Math.Round(dades(i, j) * 100, 0)
                                                    a.deure = 0
                                                Else
                                                    a.deure = Math.Round(dades(i, j) * 100 * -1, 0)
                                                    a.haver = 0
                                                End If
                                            End If
                                            If assentaments(m) Is Nothing Then
                                                assentaments(m) = New Collection
                                            End If
                                            If a.saldo <> 0 Then
                                                assentaments(m).Add(a)
                                                Call actualitzarLog(CONFIG.tipusEntradaLog.MIS_LOG, a.subcompteAssentament, " = " & a.dataAssentament & " ... " & Format(Math.Round(a.saldo / 100, 2), "#,##0.00"))
                                            End If
                                        End If
                                        j = j + 1
                                    Next
                                End If
                            Else
                                Call actualitzarLog(CONFIG.tipusEntradaLog.ERR_LOG, IDIOMA.getString("errNoExistSubte"), IDIOMA.getString("elSubcompte") & " " & dades(i, 1) & " " & IDIOMA.getString("errLogAndorraSubcte"))
                            End If
                        End If
                    End If
                End If
            Next
            fAvis.setData("ANDORRA", IDIOMA.getString("guardarDades"), "")
            Call save()
        End If
        Call EXCEL.closeMacros(apliExcel)
        subcta = Nothing
        a = Nothing
    End Sub
    Private Sub save()
        Dim cn As ADODB.Connection, ruta As String
        Dim rc As ADODB.Recordset, i As Integer, a As Assentament
        rc = New ADODB.Recordset
        ruta = getFitxerDiari(empresaActual.codi, anyActual)
        cn = DBCONNECT.connectDBF(CONFIG.getDirectori(ruta))
        If Not CONFIG.fileExist(ruta) Then Call ModulCrearDB.crearTaulaDia(cn, ruta)
        rc.Open("SELECT TOP 1 * FROM " & getTable(ruta) & " WHERE YEAR (FECHA)<> " & anyActual, cn)
        If rc.EOF Then
            Call actualitzarLog(CONFIG.tipusEntradaLog.AVIS_log, IDIOMA.getString("logIniGuardar"), IDIOMA.getString("avisLogIniDadesAndorra"))
            For i = 1 To 12
                If assentaments(i) IsNot Nothing Then
                    If rc.State = 1 Then rc.Close()
                    rc.Open("delete * from " & getTable(ruta) & " where asien = " & i & " And year(fecha) = " & anyActual, cn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                    rc.Open("Select * FROM " & getTable(ruta), cn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                    For Each a In assentaments(i)
                        rc.AddNew()
                        If Not CONFIG.esNull(a.clave) Then rc("CLAVE").Value = a.clave
                        If Not CONFIG.esNull(a.concepte) Then rc("CONCEPTO").Value = a.concepte
                        If Not CONFIG.esNull(a.contrapartida) Then rc("CONTRA").Value = a.contrapartida
                        If Not CONFIG.esNull(a.dataAssentament) Then rc("FECHA").Value = a.dataAssentament
                        If Not CONFIG.esNull(a.departamentAssentament) Then rc("DEPARTA").Value = a.departamentAssentament
                        rc("EURODEBE").Value = Math.Round(a.deure / 100, 2)
                        If Not CONFIG.esNull(a.document) Then rc("DOCUMENTO").Value = a.document
                        rc("EUROHABER").Value = Math.Round(a.haver / 100, 2)
                        rc("ASIEN").Value = a.numero
                        If Not CONFIG.esNull(a.subcompteAssentament) Then rc("SUBCTA").Value = a.subcompteAssentament
                        Call actualitzarLog(CONFIG.tipusEntradaLog.MIS_LOG, a.subcompteAssentament, " = " & a.dataAssentament & " ... " & Format(Math.Round(a.saldo / 100, 2), "#,##0.00"))
                        rc.Update()
                    Next a


                    Call actualitzarLog(CONFIG.tipusEntradaLog.AVIS_log, IDIOMA.getString("logFiGuardar"), IDIOMA.getString("avisLogFiDadesAndorra"))
                    'TODO CAL COMPACTAR LA TAULA
                End If
            Next i
        Else
            Call ERRORS.ERR_ANY_DIARIO(anyActual)
            Call actualitzarLog(CONFIG.tipusEntradaLog.ERR_LOG, IDIOMA.getString("logErrAnyDiario"), IDIOMA.getString("logErrAnyDiarioDescripcio") & anyActual)
        End If
        fAvis.setData(IDIOMA.getString("actualitzar"), ruta, "")
        Call FileCopy(ruta, CONFIG.getPathDiarioLocal(empresaActual.codi, anyActual))
        If rc.State = 1 Then rc.Close()
        If cn.State = 1 Then cn.Close()
        rc = Nothing
        cn = Nothing

        Exit Sub
error1:
        If Err.Number > 0 Then
            Call MsgBox(IDIOMA.getString("msgErrImportAndorra") & vbCrLf & Err.Description, vbCritical, "Error Nº: " & Err.Number)
            Err.Clear()
            Err.Number = 0
        End If
        favis.tancar()
        If rc.State = 1 Then rc.Close()
        rc = Nothing
        cn = Nothing
    End Sub
    Private Sub resetIndex()
        Dim i As Integer
        For i = 1 To 12
            assentaments(i) = Nothing
        Next i
    End Sub

    Private Function getAny(nom As String) As Integer
        Dim i As Integer
        getAny = 0
        For i = 1 To Len(nom)
            If IsNumeric(Mid(nom, i, 4)) Then
                If Mid(nom, i, 4) > 2000 And Mid(nom, i, 4) < 2050 Then
                    getAny = Mid(nom, i, 4)
                End If
            End If
        Next
    End Function
    Private Function getMes(m As Integer, xls(,) As String) As Integer
        Dim i As Integer, j As Integer, trobat As Boolean
        getMes = -1
        For i = 1 To UBound(xls, 1)
            For j = 1 To UBound(xls, 2)
                If xls(i, j) <> "" Then
                    If CONFIG.isMonth(m, xls(i, j)) Then
                        getMes = j
                        trobat = True
                        Exit For
                    End If
                End If
            Next j
            If trobat = True Then Exit For
        Next i
    End Function
    Private Function getTable(ruta As String) As String
        getTable = CONFIG.getFitxer(ruta)
    End Function
    Private Function getWorksheetPretancamentAndorra(wb As Workbook, codiProjecte As String) As Worksheet
        Dim ws As Worksheet, i As Integer, j As Integer, xls As Object, k As Integer, l As Integer, trobat As Boolean
        getWorksheetPretancamentAndorra = Nothing
        For Each ws In wb.Worksheets
            If UCase(ws.Name) = FULLA_PRETANCAMENT Then
                For i = 1 To 4
                    For j = 1 To 4
                        If InStr(1, codiProjecte, xls(i, j).text, vbTextCompare) <> 0 Then
                            getWorksheetPretancamentAndorra = ws
                            trobat = True
                            Exit For
                        End If
                    Next j
                    If trobat Then Exit For
                Next i
                Exit For
            Else
                trobat = False
                xls = ws.Range("a1")
                For i = 1 To 4
                    For j = 1 To 4
                        If InStr(1, xls(i, j).text, FULLA_PRETANCAMENT, vbTextCompare) <> 0 Then
                            For k = 1 To 4
                                For l = 1 To 4
                                    If InStr(1, codiProjecte, xls(k, l).text, vbTextCompare) <> 0 Then
                                        getWorksheetPretancamentAndorra = ws
                                        trobat = True
                                        Exit For
                                    End If
                                Next l
                                If trobat Then Exit For
                            Next k
                            trobat = True
                            Exit For
                        End If
                    Next j
                    If trobat Then Exit For
                Next i
            End If
        Next ws
        xls = Nothing
        ws = Nothing
    End Function
    Private Function getAnyAndorra(dades(,) As String) As Integer
        Dim i As Integer, j As Integer, a As Integer
        getAnyAndorra = 0
        For i = 0 To 4
            For j = 0 To 4
                For a = 2015 To Year(Now)
                    If InStr(1, dades(i, j), a, vbTextCompare) <> 0 Then
                        getAnyAndorra = a
                        Exit For
                    End If
                Next a
                If getAnyAndorra > 0 Then Exit For
            Next j
            If getAnyAndorra > 0 Then Exit For
        Next i
    End Function
    Public Function getAnyos(codi As String) As List(Of Integer)
        Dim cn As ADODB.Connection, ruta As String, fitxer As String
        Dim rc As ADODB.Recordset, i As Integer
        rc = New ADODB.Recordset
        ruta = CONFIG.getDirectori(getFitxerDiari(codi, 0))
        cn = DBCONNECT.connectDBF(ruta)
        getAnyos = New List(Of Integer)
        fitxer = Dir(ruta & "*.dbf", vbArchive)
        While Len(fitxer) > 0
            If rc.State = 1 Then rc.Close()
            rc.Open("SELECT TOP 1 year(fecha) as anyo FROM " & fitxer & " ORDER BY YEAR(fecha) ", cn)
            i = 1
            If Not rc.EOF Then
                getAnyos.Add(rc(0).Value)
            End If
            fitxer = Dir()
        End While
        If rc.State = 1 Then rc.Close()
        If cn.State = 1 Then cn.Close()
        rc = Nothing
        cn = Nothing
    End Function
    Public Function getMesos(codi As String, a As Integer) As List(Of Mes)
        Dim cn As ADODB.Connection, ruta As String
        Dim rc As ADODB.Recordset, i As Integer
        getMesos = New List(Of Mes)
        cn = New ADODB.Connection
        rc = New ADODB.Recordset
        ruta = getFitxerDiari(codi, a)
        If CONFIG.fileExist(ruta) Then
            cn = DBCONNECT.connectDBF(CONFIG.getDirectori(ruta))
            rc.Open("SELECT distinct month(fecha) as anyo FROM " & CONFIG.getFitxer(ruta) & " WHERE YEAR (FECHA)=" & a & "  ORDER BY MONTH(fecha) ", cn)
            i = 1
            While Not rc.EOF
                getMesos.Add(New Mes(rc(0).Value, CONFIG.mesNom(rc(0).Value)))
                rc.MoveNext()
            End While
        End If
        If rc.State = 1 Then rc.Close()
        If cn.State = 1 Then cn.Close()
        rc = Nothing
        cn = Nothing
    End Function
    Private Sub actualitzarLog(codi As tipusEntradaLog, titol As String, descripcio As String)
        logActual.entrades.Add(ModelLog.getEntradaLog(codi, titol, descripcio))
    End Sub
    Private Function getFitxerDiari(codi As String, Optional anyo As Integer = 0) As String
        If CONFIG_FILE.getTag(TAG.ES_LOCAL) Then
            getFitxerDiari = CONFIG.getPathDiarioLocal(codi, anyo)
        Else
            getFitxerDiari = CONFIG.getPathDiarioServidor(codi, anyo)
        End If
    End Function
End Module
