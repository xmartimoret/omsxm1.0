Option Explicit On
Module ModulImportTresoreria
    Private INGRESSOS As String
    Private PAGAMENTS As String
    Private COLUMNA1 As String
    Private codiProjecteNomFulla As Boolean
    Private codiProjecteRangFulla As String
    Private Const FILES As Integer = 1000
    Private tempParticipacio As Integer
    Private tempRutaGb As String
    Private logEstimacio As Log
    Public Sub executeObres()
        '    Dim fitxerImport As String, logEstimacio As Log, nomFulles() As String, macroExcel As Application
        '    fitxerImport = dRutaTresoreria.getFitxerImport(CONFIG_FILE.getTag(CONFIG_FILE.TAG.TRESORERIA_OBRES))
        '    If CONFIG.fileExist(fitxerImport) Then
        '        INGRESSOS = CONFIG_PARAM_SERVER.getParametreCobroTresoreria
        '        PAGAMENTS = CONFIG_PARAM_SERVER.getParametrePagamentTresoreria
        '        COLUMNA1 = CONFIG_PARAM_SERVER.getParametreColumnaTresoreria
        '        codiProjecteNomFulla = CONFIG_PARAM_SERVER.getXecNomProjecteTresoreria
        '        codiProjecteRangFulla = CONFIG_PARAM_SERVER.getParametreNomTresoreria
        '        logEstimacio = New Log
        '        logEstimacio.titol = IDIOMA.getString("logTitolImportDadesTresoreria")
        '        logEstimacio.descripcio = IDIOMA.getString("logDescripcioImportDadesTresoreria")
        '        ' aqui ens cal cridar  la macro tresoreria
        '        '1 ens cal agafar els projectes. per tant ens cal trobar les dades. 



        '        '2 importar les dades.
        '        Set wb = CONFIG.getWorbook(CONFIG.getFitxer(fitxerImport.ruta))
        '        Call actualitzarLog(AVIS_log, "OBTENIR FITXER", "CERCANT I OBRINT  EL LLIBRE ESCOLLIT")
        '        If Not TypeName(wb) = "Workbook" Then
        '            Set wb = Workbooks.Open(fitxerImport.ruta, False, True)
        '            noClosed = False
        '        Else
        '            noClosed = True
        '        End If
        '        Call actualitzarLog(AVIS_log, "CERCA PROJECTES", "INICI CERCA DE PROJECTES EN EL FITXER ESCOLLIT.")
        '        Set projectes = New ColleccioOrdenada
        '        For Each ws In wb.Worksheets
        '            If codiProjecteNomFulla Then
        '                For i = 1 To Len(ws.Name)
        '                    If Len(ws.Name) - i >= 8 Then
        '                        Set p = ModelProjecte.getByCode(Mid(ws.Name, i, 9))
        '                        If TypeName(p) = "Projecte" Then
        '                            Call actualitzarLog(MIS_LOG, "PROJECTE TROBAT", "LA FULLA " & ws.Name & " CONTÉ EL PROJECTE " & p.ToString)
        '                            p.ordre = ws.Name
        '                            projectes.insertar p
        '                            Exit For
        '                        End If
        '                    Else
        '                        Exit For
        '                    End If
        '                Next i
        '            Else
        '                For i = 1 To Len(ws.Range(CStr(codiProjecteRangFulla)))
        '                    If Len(ws.Range(CStr(codiProjecteRangFulla))) - i >= 8 Then
        '                        Set p = ModelProjecte.getByCode(Mid(ws.Range(CStr(codiProjecteRangFulla)), i, 9))
        '                        If TypeName(p) = "Projecte" Then
        '                            Call actualitzarLog(MIS_LOG, "PROJECTE TROBAT", "LA FULLA " & ws.Name & " CONTÉ EL PROJECTE " & p.ToString)
        '                            p.ordre = ws.Name
        '                            projectes.insertar p
        '                            Exit For
        '                        End If
        '                    Else
        '                        Exit For
        '                    End If
        '                Next i
        '            End If
        '        Next ws
        '        If projectes.dades.Count > 0 Then
        '            Call ModelTresoreria.resetIndex()
        '            projectes = frmSelectProjectes.getProjectes(projectes, " A IMPORTAR")
        '            If TypeName(projectes) = "ColleccioOrdenada" Then
        '                For Each p In projectes.dades
        '                    Call actualitzarLog(AVIS_log, "INI IMPORT", "PROJECTE: " & p.ToString)
        '                    If ModelTresoreria.insert(importData(wb.Worksheets(p.ordre), p.id), p.id) = -1 Then
        '                        Call ERROR.ERR_INSERT_TRESORERIA
        '                        Call actualitzarLog(ERR_LOG, "ERR_INSERT", "Error a l'insertar registres a la base de dades. Falta espai. Cal borrar dades antigues. S'ha sobrepassat els 100.000 registres")
        '                        Exit For
        '                    End If
        '                    Call actualitzarLog(AVIS_log, "FI IMPORT", "PROJECTE: " & p.ToString)
        '                Next p
        '                Call ModelCompact.DBEstimacions

        '            End If
        '        Else
        '            Call ERROR.ERR_NO_ESTIMACIONS(CONFIG.getFitxer(fitxerImport.ruta))
        '            Call actualitzarLog(ERR_LOG, "ERROR NO PROJ.", "NO S'HA TROBAT CAP PROJECTE EN EL LLIBRE ESCOLLIT.")
        '        End If
        '        Call ModelTresoreria.resetIndex()
        '        Call frmCarregarDades.tancar
        '        If Not noClosed Then Call wb.Close(False)
        '        Set pts = New ColleccioOrdenada
        '        If TypeName(projectes) = "ColleccioOrdenada" Then
        '            For Each p In projectes.dades
        '                Set pt = ModelTresoreria.getProjecte(p.id)
        '                pts.insertar pt
        '            Next p
        '            Call ModelTresoreria.resetIndex()
        '            Call frmTresoreries.Show
        '            'ini export
        '            Set entradesLog = ModulExportTresoreria.exportData(pts)
        '            If TypeName(entradesLog) = "ColleccioOrdenada" Then
        '                For Each e In entradesLog.dades
        '                    logEstimacio.entrades.dades.add e
        '                Next e
        '            End If
        '            Call MISSATGE.DATA_IMPORTED
        '        End If
        '        If fitxerImport.isLog Then Call ModelInformes.executeLog(logEstimacio)
        '    End If

        'Set fitxerImport = Nothing
        'Set wb = Nothing
        'Set ws = Nothing
        'Set projectes = Nothing
        'Set p = Nothing
        'Set pt = Nothing
        'Set pts = Nothing
        'Set entradesLog = Nothing
        'Set e = Nothing
    End Sub
    'Private Function importData(ws As Object, idProjecte As Integer) As ColleccioOrdenada
    '    Dim e As Tresoreria, xls As Object, estat As Integer, blancs As Integer, i As Integer
    'Set xls = ws.Range("a1")
    'estat = 0
    'Set importData = New ColleccioOrdenada
    'For i = 1 To FILES
    '        If xls(i, 1) <> "" Then
    '            blancs = 0
    '            If estat > 0 Then
    '                If xls(i, 1) <> "" And IsNumeric(xls(i, 3)) And IsDate(xls(i, 4)) And IsDate(xls(i, 6)) Then
    '                Set e = New Tresoreria
    '                If estat = 1 Then
    '                        e.esIngres = True
    '                        Call actualitzarLog(MIS_LOG, "INGRES", xls(i, 1) & "  --> " & xls(i, 2) & "  --> " & Format(xls(i, 3), "#,##0.00 €") & "  --> " & xls(i, 4) & "  --> " & xls(i, 5) & "  --> " & xls(i, 6))
    '                    Else
    '                        e.esIngres = False
    '                        Call actualitzarLog(MIS_LOG, "PAGAMENT", xls(i, 1) & "  --> " & xls(i, 2) & "  --> " & Format(xls(i, 3), "#,##0.00 €") & "  --> " & xls(i, 4) & "  --> " & xls(i, 5) & "  --> " & xls(i, 6))
    '                    End If
    '                    e.idProjecte = idProjecte
    '                    e.concepte = xls(i, 1)
    '                    e.tipus = xls(i, 2)
    '                    e.dataEmisio = xls(i, 4)
    '                    e.dataVenciment = xls(i, 6)
    '                    e.base = xls(i, 3)
    '                    importData.dades.add e
    '            End If
    '            End If
    '            If estat = 0 Then
    '                If InStr(1, xls(i, 1), INGRESSOS, vbTextCompare) > 0 Then
    '                    If InStr(1, xls(i + 1, 1), COLUMNA1, vbTextCompare) > 0 Then estat = 1
    '                ElseIf InStr(1, xls(i, 1), PAGAMENTS, vbTextCompare) > 0 Then
    '                    If InStr(1, xls(i + 1, 1), COLUMNA1, vbTextCompare) > 0 Then estat = 2
    '                End If
    '            ElseIf estat = 1 Then
    '                If InStr(1, xls(i, 1), PAGAMENTS, vbTextCompare) > 0 Then
    '                    If InStr(1, xls(i + 1, 1), COLUMNA1, vbTextCompare) > 0 Then estat = 2
    '                End If
    '            ElseIf estat = 2 Then
    '                If InStr(1, xls(i, 1), INGRESSOS, vbTextCompare) > 0 Then
    '                    If InStr(1, xls(i + 1, 1), COLUMNA1, vbTextCompare) > 0 Then estat = 1
    '                End If
    '            End If
    '        Else
    '            blancs = blancs + 1
    '        End If
    '        If blancs > 150 Then Exit For
    '    Next i
    'Set e = Nothing
    ' End Function
    Private Sub actualitzarLog(codi As tipusEntradaLog, titol As String, descripcio As String)
        '    Dim e As EntradaLog
        'Set e = New EntradaLog
        'e.codi = codi
        '    e.titol = titol
        '    e.descripcio = descripcio
        '    logEstimacio.entrades.dades.add e
        'Set e = Nothing
    End Sub
End Module
