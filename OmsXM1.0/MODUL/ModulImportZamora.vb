Option Explicit On
Imports Microsoft.Office.Interop.Excel
Module ModulImportZamora
    Private subcomptes As List(Of Subcompte)
    Private anyActual As Integer
    Private assentaments(0 To 12) As List(Of Assentament)
    Private mesActual As Integer
    Private projecteActual As Projecte
    Private empresaActual As Empresa
    Private dadesCentres As CentresGB
    Private logActual As Log
    Private fAvis As frmAvis
    Public Sub execute()
        Dim projectes As List(Of Projecte), isOpen As Boolean, wbactual As Workbook

        dadesCentres = dImportUtes.getDadesZamora
        Call resetIndex()
        Call ModelLog.resetIndex()
        logActual = New Log
        logActual.descripcio = IDIOMA.getString("descripcioLogImportZamora")
        logActual.titol = IDIOMA.getString("titolLogImportZamora")
        empresaActual = ModelEmpresa.getObject(CONFIG.getCodiZamora)
        If dadesCentres IsNot Nothing Then
            fAvis = New frmAvis(IDIOMA.getString("actualitzar"), "ZAMORA", "")
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

            If projecteActual IsNot Nothing Then
                wbActual = EXCEL.getWorkbook(CONFIG.getFitxer(dadesCentres.rutaGB))
                isOpen = True
                If wbactual Is Nothing Then
                    isOpen = False
                    wbactual = EXCEL.openWorkbook(dadesCentres.rutaGB, False, True)
                End If
                If wbactual IsNot Nothing Then
                    fAvis.setData(IDIOMA.getString("obrirFitxer"), wbactual.Name, "")
                    If setData(wbactual) Then
                        fAvis.tancar()
                        Call MISSATGES.DATA_UPDATED()
                        Call FrmApliOms.setDataContaplus(empresaActual, ModelEmpresaContaplus.getObjectByEmpresaAny(empresaActual.id, anyActual), mesActual)
                    Else
                        fAvis.tancar()
                    End If
                    If Not isOpen Then wbactual.Close(False)
                    If dadesCentres.isLog Then Call ModelInformes.executeLog(logActual)
                End If
            End If
        End If
        projecteActual = Nothing
        subcomptes = Nothing
        projectes = Nothing
        wbActual = Nothing
        dadesCentres = Nothing
        empresaActual = Nothing
        logActual = Nothing
        fAvis = Nothing
    End Sub
    Private Function setData(wbActual As Workbook) As Boolean
        Dim xls As Object, i As Integer, j As Integer, m As Integer, apliExcel As Application, dades(,) As String
        Dim a As Assentament
        apliExcel = EXCEL.getMacros
        setData = False
        dades = apliExcel.Run("llegirDades", wbActual.Worksheets(1), 20, 150)
        If isWorksheetZamora(dades) Then
            If getAny(wbActual.Worksheets(1).Name) = anyActual Then
                For i = 0 To UBound(dades, 1)
                    If IsNumeric(dades(i, 0)) And Trim(dades(i, 0)).Length = 7 Then ' agafem el numero subcte
                        If ModelSubcomptesGrup.existSubcompte(CStr(dades(i, 0))) Then
                            j = getMes(1, dades)
                            If j > 0 Then
                                For m = 1 To 12
                                    If mesActual = m Or mesActual = -1 Then
                                        a = New Assentament
                                        a.numero = m
                                        fAvis.setData(dades(i, 0), Left(dades(i, 1), 24), dades(i, j))
                                        a.subcompteAssentament = dades(i, 0)
                                        a.concepte = dades(i, 1)
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
                                            assentaments(m) = New List(Of Assentament)
                                        End If
                                        If a.saldo <> 0 Then
                                            assentaments(m).Add(a)
                                            Call actualitzarLog(CONFIG.tipusEntradaLog.MIS_LOG, dades(i, 0), " = " & a.dataAssentament & " ... " & Format(Math.Round(a.saldo / 100, 2), "#,##0.00"))
                                        End If
                                    End If
                                    j = j + 1
                                Next m
                            End If
                        Else
                            Call actualitzarLog(CONFIG.tipusEntradaLog.ERR_LOG, IDIOMA.getString("errNoExistSubte"), IDIOMA.getString("elSubcompte") & " " & xls(i, 1) & " " & IDIOMA.getString("deZamoraNoExisteix"))
                        End If
                    End If
                Next i
                Call actualitzarLog(CONFIG.tipusEntradaLog.AVIS_log, IDIOMA.getString("avisFiImportData"), IDIOMA.getString("fiImportDataAny") & anyActual)
                fAvis.setData("ANDORRA", IDIOMA.getString("guardarDades"), "")
                setData = save()
            Else
                Call actualitzarLog(CONFIG.tipusEntradaLog.ERR_LOG, IDIOMA.getString("logErrorAny"), IDIOMA.getString("logErrorAnyDescripcio"))
                Call ERRORS.ERR_ANY()
            End If
        Else
            Call actualitzarLog(CONFIG.tipusEntradaLog.ERR_LOG, IDIOMA.getString("logErrFitxer"), IDIOMA.getString("logErrFitxerZamora"))
            Call ERRORS.ERR_FULLA_ZAMORA(wbActual.Name)
        End If
        a = Nothing
    End Function
    Private Function save() As Boolean
        Dim cn As ADODB.Connection, ruta As String
        Dim rc As ADODB.Recordset, i As Integer, a As Assentament
        On Error GoTo error1
        rc = New ADODB.Recordset
        ruta = getFitxerDiari(empresaActual.codi, anyActual)
        save = False
        cn = DBCONNECT.connectDBF(CONFIG.getDirectori(ruta))
        If Not CONFIG.fileExist(ruta) Then Call ModulCrearDB.crearTaulaDia(cn, ruta)
        rc.Open("SELECT TOP 1 * FROM " & getTable(ruta) & " WHERE YEAR (FECHA)<> " & anyActual, cn)
        If rc.EOF Then
            Call actualitzarLog(CONFIG.tipusEntradaLog.AVIS_log, IDIOMA.getString("logIniGuardar"), IDIOMA.getString("logIniGuardarDescripcio") & " . UTE ZAMORA.")
            For i = 1 To 12
                If assentaments(i) IsNot Nothing Then
                    If rc.State = 1 Then rc.Close()
                    rc.Open("DELETE * from " & getTable(ruta) & " WHERE asien = " & i & " AND year(fecha) = " & anyActual, cn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                    rc.Open("SELECT * FROM " & getTable(ruta), cn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                    For Each a In assentaments(i)
                        rc.AddNew()
                        If Not CONFIG.esNull(a.clave) Then rc("CLAVE").Value = a.clave
                        If Not CONFIG.esNull(a.concepte) Then rc("CONCEPTO").Value = Left(a.concepte, 25)
                        If Not CONFIG.esNull(a.contrapartida) Then rc("CONTRA").Value = a.contrapartida
                        If Not CONFIG.esNull(a.dataAssentament) Then rc("FECHA").Value = a.dataAssentament
                        If Not CONFIG.esNull(a.departamentAssentament) Then rc("DEPARTA").Value = a.departamentAssentament
                        rc("EURODEBE").Value = Math.Round(a.deure / 100, 2)
                        If Not CONFIG.esNull(a.document) Then rc("DOCUMENTO").Value = a.document
                        rc("EUROHABER").Value = Math.Round(a.haver / 100, 2)
                        rc("ASIEN").Value = a.numero
                        If Not CONFIG.esNull(a.subcompteAssentament) Then rc("SUBCTA").Value = a.subcompteAssentament
                        Call actualitzarLog(CONFIG.tipusEntradaLog.MIS_LOG, a.subcompteAssentament, " = " & a.dataAssentament & " ... " & Format(Math.Round(a.saldo / 100, 2), "#,##0.00"))
                    Next a
                    rc.Update()
                    Call actualitzarLog(CONFIG.tipusEntradaLog.AVIS_log, IDIOMA.getString("logFiGuardar"), IDIOMA.getString("logFiGuardarDescripcio") & " UTE ANDORRA")
                End If
            Next i
            save = True
        Else
            Call ERRORS.ERR_ANY_DIARIO(anyActual)
            Call actualitzarLog(CONFIG.tipusEntradaLog.ERR_LOG, IDIOMA.getString("logErrAnyDiario"), IDIOMA.getString("logErrAnyDiarioDescripcio") & anyActual)
        End If
        If rc.State = 1 Then rc.Close()
        If cn.State = 1 Then cn.Close()

        favis.setData(IDIOMA.getString("actualitzar"), ruta, "")
        Call FileCopy(ruta, CONFIG.getPathDiarioLocal(empresaActual.codi, anyActual))

        rc = Nothing
        cn = Nothing
        Exit Function
error1:
        If Err.Number <> 0 Then
            Call MsgBox(IDIOMA.getString("msgErrImportZamora") & " " & vbCrLf & Err.Description, vbCritical, "Error Nº: " & Err.Number)
            Err.Clear()
            Err.Number = 0
        End If
        save = False
        rc = Nothing
        cn = Nothing
    End Function

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
    Private Function getMes(m As Integer, dades(,) As String) As Integer
        Dim i As Integer, j As Integer, trobat As Boolean
        getMes = -1
        For i = LBound(dades, 1) To UBound(dades, 1)
            For j = LBound(dades, 2) To UBound(dades, 2)
                If dades(i, j) <> "" Then
                    If CONFIG.isMonth(m, dades(i, j)) Then
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

    Private Function isWorksheetZamora(xls As Object) As Boolean
        Dim i As Integer, j As Integer
        isWorksheetZamora = False
        For i = 1 To 3
            For j = 1 To 4
                If InStr(1, xls(i, j), "ZAMORA", vbTextCompare) > 0 Then
                    isWorksheetZamora = True
                    Exit For
                End If
            Next j
            If isWorksheetZamora Then Exit For
        Next i
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
