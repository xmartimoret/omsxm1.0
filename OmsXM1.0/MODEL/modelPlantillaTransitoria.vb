Option Explicit On
Imports System.IO
Imports Microsoft.Office.Interop.Excel
Module modelPlantillaTransitoria
    '@ MODUL            ModelPlantillaTransitoria
    '@ DESCRIPCIO       Té dos funcions:
    '                   1. El model per crear un fitxer RESUM
    '                       Guarda en memòria els subcomptes i apartats que configuren un fitxer resum
    '                       Guarda en un fitxer de text la configuració actual. (subctes,apartats, any, empresa)
    '                       La seva vista és frmPlantillaTransitoria.
    '                       Objectes relacionats (AnyMesos,Subcompte,Transitoria,YSheet,Client,ProjecteClient,Projecte)
    '                   2. Carrega les dades dels clients a un Fitxer resum.
    '@ DATA             06/01/2016
    '@ AUTOR            xmarti
    '@ OBSERVACIONS     Funciona. Amb tot cal testejar (comprovar al validesa de les dades) la exportació de varis mesos i varios projectes,
    '                   Cal posar informació a la pàgina Resum mensual. (titol(mes/any), dataActualització, usuariActualitzacio)
    Private subcomptes As List(Of Subcompte)  ' subcomptes que pertanyen a una transitoria
    Private ySheets As List(Of YSheet)     ' apartats yellow sheets que pertanyen a una transitoria
    Private anyActual As Integer
    Private empresaActual As Empresa
    '** CONSTANTS
    Private Const FITXER_PLANTILLA As String = "plantillaTransitoria.txt" 'nom fitxer on es guarda la configuració
    Private Const MARCA_RESUM As String = "RESUM_TRANSITORIA" ' marca per saber que es tracta d'un fitxer transitoria
    Private Const FULLA_CONFIG As String = "CONFIG_RESUM"
    Private Const FULLA_PLANTILLA As String = "PLANTILLA"
    Private Const RANG_FITXER_TRANSITORIA As String = "A1"
    Private Const RANG_ANY_ACTUAL As String = "A2"
    Private Const RANG_EMPRESA_ACTUAL As String = "A3"
    Private Const RANG_PROJECTES As String = "D4"
    Private Const SEPARATOR As String = "#@#@"
    Private Const TIPUS_SUBCOMPTE As String = "S"
    Private Const TIPUS_ANY As String = "A"
    Private Const TIPUS_EMPRESA As String = "E"
    Private Const TIPUS_YELLOW As String = "Y"
    Private Const FITXER_DADES_PLANTILLA_TRANSITORIA As String = "dadesPlantillaTransitoria.txt"
    ' ***
    ' guia per trobar els codis desl diferents subcomptes dins la fulla resum. D'aquesta manera només es carrega una vegada i no
    '  s'ha de cercar per cada transitoria.
    Private filesSubcomptes(0 To 1000, 0 To 2) As String

    '***** INI ACCESSORS (subcomptes, subcomptesNoafegits, ApartatsYellowSheets, ApartatsYellowSheetsNoafegits, empresa, any)
    Public Function getSubcomptes() As List(Of Subcompte)
        If subcomptes Is Nothing Then Call getObjects()
        getSubcomptes = subcomptes
    End Function
    Public Function getSubcompte(id As Integer) As Subcompte
        Dim s As Subcompte
        s = subcomptes.Find(Function(x) x.id = id)
        If s IsNot Nothing Then Return s
        Return Nothing
    End Function
    Public Function getSubcomptesNoAdded() As List(Of Subcompte)
        Dim s As Subcompte, objects As List(Of Subcompte)
        objects = ModelSubcompte.getObjects
        getSubcomptesNoAdded = New List(Of Subcompte)
        For Each s In objects
            If Not existSubcompte(s) Then getSubcomptesNoAdded.Add(s)
        Next s
        s = Nothing
        objects = Nothing
    End Function
    Public Function getySheetsNoAdded() As List(Of YSheet)
        Dim Y As YSheet, objects As List(Of YSheet)
        objects = ModelYSheet.getObjects
        getySheetsNoAdded = New List(Of YSheet)
        For Each Y In objects
            If Not existYSheet(Y) Then getySheetsNoAdded.Add(Y)
        Next Y
        Y = Nothing
        objects = Nothing
    End Function
    Public Function getySheets() As List(Of YSheet)
        getySheets = ySheets
    End Function
    Public Function getYSheet(id As String) As YSheet
        Dim y As YSheet
        y = ySheets.Find(Function(x) x.id = id)
        If y IsNot Nothing Then Return y
        Return Nothing
    End Function
    Public Function getAny() As Integer
        getAny = anyActual
    End Function
    Public Sub setAny(p As Integer)
        anyActual = p
    End Sub
    Public Function getEmpresa() As Empresa
        getEmpresa = empresaActual
    End Function
    Public Sub setEmpresa(p As Empresa)
        empresaActual = p
    End Sub
    Public Sub setSubcompte(s As Subcompte)
        s.ordre = getOrderMaxSubcompte() + 1
        If subcomptes Is Nothing Then subcomptes = New List(Of Subcompte)
        subcomptes.Add(s)
    End Sub
    Public Sub removeSubcompte(id As Integer)
        If subcomptes IsNot Nothing Then
            subcomptes.RemoveAll(Function(x) x.id = id)
        End If
    End Sub
    Public Sub setYSheets(Y As YSheet)
        Y.ordre = getOrderMaxYSheet() + 1
        If ySheets Is Nothing Then ySheets = New List(Of YSheet)
        ySheets.Add(Y)
    End Sub
    Public Sub removeYSheets(id As String)
        If ySheets IsNot Nothing Then
            ySheets.RemoveAll(Function(x) x.id = id)
        End If
    End Sub
    Public Sub changeOrderSubcomptes(id1 As Integer, id2 As Integer)
        Dim s1 As Subcompte, s2 As Subcompte
        Dim temp As String
        s1 = getSubcompte(id1)
        s2 = getSubcompte(id2)
        If s1 IsNot Nothing And s2 IsNot Nothing Then
            temp = s1.ordre
            s1.ordre = s2.ordre
            s2.ordre = temp
            subcomptes.Remove(s1)
            subcomptes.Remove(s2)
            subcomptes.Add(s1)
            subcomptes.Add(s2)
            subcomptes.Sort 
        End If
        s1 = Nothing
        s2 = Nothing
    End Sub
    Public Sub changeOrderYSheets(id1 As String, id2 As String)
        Dim y1 As YSheet, y2 As YSheet
        Dim temp As String
        y1 = getYSheet(id1)
        y2 = getYSheet(id2)
        If y1 IsNot Nothing And y2 IsNot Nothing Then
            temp = y1.ordre
            y1.ordre = y2.ordre
            y2.ordre = temp
            ySheets.Remove(y1)
            ySheets.Remove(y2)
            ySheets.Add(y1)
            ySheets.Add(y2)
        End If
    End Sub
    Public Sub save()
        Dim s As Subcompte, Y As YSheet
        Using fitxer As New IO.StreamWriter(getFitxerTransitoria)
            If subcomptes IsNot Nothing Then
                For Each s In subcomptes
                    fitxer.WriteLine(TIPUS_SUBCOMPTE & SEPARATOR & s.id & SEPARATOR & s.ordre)
                Next s
            End If
            If ySheets IsNot Nothing Then
                For Each Y In ySheets
                    fitxer.WriteLine(TIPUS_YELLOW & SEPARATOR & Y.id & SEPARATOR, Y.ordre)
                Next Y
            End If
            fitxer.WriteLine(TIPUS_ANY & SEPARATOR & anyActual & SEPARATOR & 0)
            If empresaActual IsNot Nothing Then fitxer.WriteLine(TIPUS_EMPRESA & SEPARATOR & empresaActual.id & SEPARATOR & 0)
        End Using
        s = Nothing
        Y = Nothing
    End Sub
    Public Sub getObjects()
        Dim filaActual() As String, s As Subcompte, Y As YSheet
        Call reset()
        If CONFIG.fileExist(getFitxerTransitoria) Then
            Using fitxer As New Microsoft.VisualBasic.FileIO.TextFieldParser(getFitxerTransitoria)
                fitxer.TextFieldType = FileIO.FieldType.Delimited
                fitxer.SetDelimiters(SEPARATOR)
                While Not fitxer.EndOfData
                    Try
                        filaActual = fitxer.ReadFields
                        If UBound(filaActual) = 2 Then
                            Select Case filaActual(0)
                                Case TIPUS_SUBCOMPTE
                                    If subcomptes Is Nothing Then subcomptes = New List(Of Subcompte)
                                    s = ModelSubcompte.getObject(CInt(filaActual(1)))
                                    If s IsNot Nothing Then
                                        s.ordre = filaActual(2)
                                        subcomptes.Add(s)
                                    End If
                                Case TIPUS_YELLOW
                                    If ySheets Is Nothing Then ySheets = New List(Of YSheet)
                                    Y = ModelYSheet.getObject(CInt(filaActual(1)))
                                    If Y IsNot Nothing Then
                                        Y.ordre = filaActual(2)
                                        ySheets.Add(Y)
                                    End If
                                Case TIPUS_ANY
                                    anyActual = filaActual(1)
                                Case TIPUS_EMPRESA
                                    empresaActual = ModelEmpresa.getObject(CInt(filaActual(1)))
                            End Select
                        End If
                    Catch ex As Microsoft.VisualBasic.FileIO.MalformedLineException
                        MsgBox("error " & ex.Message)
                    End Try
                End While
                If ySheets IsNot Nothing Then ySheets.Sort()
                If subcomptes IsNot Nothing Then subcomptes.Sort()
            End Using
        End If
        s = Nothing
        Y = Nothing
    End Sub
    Public Function existSubcompte(s As Subcompte) As Boolean
        If subcomptes IsNot Nothing Then Return subcomptes.Exists(Function(x) x.id = s.id)
        Return False
    End Function
    Public Function existYSheet(Y As YSheet) As Boolean
        If ySheets IsNot Nothing Then Return ySheets.Exists(Function(x) x.id = Y.id)
        Return False
    End Function
    Private Function getFitxerTransitoria() As String
        Return CONFIG.getRutaBDRemote(FITXER_PLANTILLA)
    End Function
    Private Function getOrderMaxSubcompte() As Integer
        Dim s As Subcompte
        getOrderMaxSubcompte = 0
        If subcomptes IsNot Nothing Then
            For Each s In subcomptes
                If s.ordre > getOrderMaxSubcompte Then getOrderMaxSubcompte = s.ordre
            Next s
        End If
        s = Nothing
    End Function
    Private Function getOrderMaxYSheet() As Integer
        Dim Y As YSheet
        getOrderMaxYSheet = 0
        If ySheets IsNot Nothing Then
            For Each Y In ySheets
                If Y.ordre > getOrderMaxYSheet Then getOrderMaxYSheet = Y.ordre
            Next Y
        End If
        Y = Nothing
    End Function
    Public Sub reset()
        subcomptes = Nothing
        ySheets = Nothing
    End Sub
    Public Function isWorkbookTransitoria(wb As Workbook, anyo As Integer, idEmpresa As Integer) As Integer
        Dim ws As Worksheet
        isWorkbookTransitoria = 1 ' NO ES UN FITXER TRANSITORIA
        For Each ws In wb.Worksheets
            If ws.Name = FULLA_CONFIG Then
                If ws.Range(RANG_FITXER_TRANSITORIA).Text = MARCA_RESUM Then
                    isWorkbookTransitoria = 2 ' NO CORRESPON A L'ANY ACTUAL
                    If ws.Range(RANG_ANY_ACTUAL).Text = anyo Then
                        isWorkbookTransitoria = 3 ' NO ES UN DE L'EMPRESA ESCOLLIDA
                        If ws.Range(RANG_EMPRESA_ACTUAL).Text = idEmpresa Then
                            isWorkbookTransitoria = 0 ' 'ES UN FITXER TRANSITORIA
                            Exit For
                        End If
                    End If
                End If
            End If
        Next ws
        ws = Nothing
    End Function

    ' *****  FI ACCESSORS
    Public Sub crearPlantilla()
        '1 cal escriure  al directori lcval 
        Dim s As Subcompte, y As YSheet
        Dim pr As Process
        Using fitxer As StreamWriter = New StreamWriter(CONFIG.getRutaDadesMacro & FITXER_DADES_PLANTILLA_TRANSITORIA)
            fitxer.WriteLine(TIPUS_ANY & SEPARATOR & anyActual & SEPARATOR & "" & SEPARATOR & "")
            fitxer.WriteLine(TIPUS_EMPRESA & SEPARATOR & empresaActual.id & SEPARATOR & empresaActual.codi & SEPARATOR & empresaActual.nom)
            If subcomptes IsNot Nothing Then
                For Each s In subcomptes
                    fitxer.WriteLine(TIPUS_SUBCOMPTE & SEPARATOR & s.id & SEPARATOR & s.codi & SEPARATOR & s.nom)
                Next
            End If
            If ySheets IsNot Nothing Then
                For Each y In ySheets
                    fitxer.WriteLine(TIPUS_YELLOW & SEPARATOR & y.id & SEPARATOR & y.codi & SEPARATOR & y.nom)
                Next
            End If
        End Using
        Call EXCEL.LiberarMemoria()
        If CONFIG.fileExist(CONFIG.setFolder(CONFIG.getRutaApliMacros) & "crearPlantillaTransitoria.xlam") Then
            pr = Process.Start(CONFIG.setFolder(CONFIG.getRutaApliMacros) & "crearPlantillaTransitoria.xlam")
            Call EXCEL.closeWorkbook("crearPlantillaTransitoria.xlam")
        Else
            Call ERRORS.ERR_DIRECTORI_SERVIDOR_MACROS
        End If
        s = Nothing
        y = Nothing
        pr = Nothing
    End Sub
    '***** CREAR PLANTILLA *****
    'Public Sub crearPlantilla()
    '    Dim wb As Workbook, xls As Object, i As Integer, t As Transitoria
    '    Dim ias As Integer, iaant As Integer, iaact As Integer, isant As Integer, isact As Integer
    '    wb = EXCEL.getNewWorkbook
    '    wb.Worksheets(1).Name = FULLA_CONFIG
    '    wb.Worksheets(1).Range(RANG_FITXER_TRANSITORIA) = MARCA_RESUM
    '    wb.Worksheets(1).Range(RANG_ANY_ACTUAL) = anyActual
    '    wb.Worksheets(1).Range(RANG_EMPRESA_ACTUAL) = empresaActual.id
    '    wb.Worksheets.Add
    '    wb.ActiveSheet.Name = FULLA_PLANTILLA
    '    xls = wb.ActiveSheet.Range("a1")
    '    xls(1, 2) = "TRANSITORIA"
    '    xls(2, 2) = empresaActual.nom
    '    xls(1, 1).ColumnWidth = 6
    '    xls(1, 2).ColumnWidth = 35
    '    xls(1, 3).ColumnWidth = 11
    '    Call setFont(xls(2, 2), 12, 1, False, True, True)
    '    Call setFont(xls(3, 2), 12, 1, False, True, True)
    '    Call setFont(xls(4, 2), 9, 1, False, False, False)
    '    xls(1, 4).ColumnWidth = 3
    '    xls(1, 5).ColumnWidth = 14
    '    Call setFont(xls(1, 2), 16, 1, False, True)
    '    t = New Transitoria
    '    t.anyo = anyActual
    '    Call setFont(xls(3, 3), 9, 1, False, True, True)
    '    Call setFont(xls(3, 4), 9, 1, False, True, True)
    '    Call setFont(xls(4, 4), 7, 1, False, True, True)
    '    Call setFont(xls(4, 3), 7, 1, False, True, True)
    '    xls(4, 3).WrapText = True
    '    xls(4, 4).WrapText = True
    '    xls(4, 5) = "TOTAL"
    '    Call setFont(xls(4, 5), 10, 1, False, True)

    '    'ACRUALS SAFETY ANY
    '    xls(5, 2) = t.codiAcrualsSafetiesAny
    '    xls(5, 2).Interior.ColorIndex = 15
    '    xls(5, 3).Interior.ColorIndex = 15
    '    xls(5, 3).Select
    '    wb.ActiveWindow.FreezePanes = True
    '    xls(5, 4).Interior.ColorIndex = 15
    '    xls(5, 5).Interior.ColorIndex = 15
    '    i = 6
    '    ias = i
    '    i = repaintSubcomptes(xls, i)
    '    i = i + 2


    '    'YELLOW Sheet
    '    If ySheets IsNot Nothing Then
    '        If ySheets.Count > 0 Then
    '            xls(i, 2) = "YELLOW SHEET REMONDIS (Accruals)"
    '            xls(i, 2).Font.Bold = True
    '            xls(i, 2).Font.ColorIndex = 3
    '            i = i + 1
    '            i = repaintYSheets(xls, i)
    '            i = i + 2
    '        End If
    '    End If

    '    ' ACRUALS ANY ANTERIOR
    '    xls(i, 2) = t.codiAcrualsAnyAnterior
    '    xls(i, 2).Interior.ColorIndex = 15
    '    xls(i, 3).Interior.ColorIndex = 15
    '    xls(i, 4).Interior.ColorIndex = 15
    '    xls(i, 5).Interior.ColorIndex = 15
    '    i = i + 1
    '    iaant = i
    '    i = repaintSubcomptes(xls, i)
    '    i = i + 2
    '    ' ACRUALS ANY ACTUAL
    '    xls(i, 2) = t.codiAcrualsAny
    '    xls(i, 2).Interior.ColorIndex = 15
    '    xls(i, 3).Interior.ColorIndex = 15
    '    xls(i, 4).Interior.ColorIndex = 15
    '    xls(i, 5).Interior.ColorIndex = 15
    '    i = i + 1
    '    iaact = i
    '    i = repaintSubcomptes(xls, i)
    '    i = i + 2
    '    ' SAFETIES ANY ANTERIOR
    '    xls(i, 2) = t.codiSafetiesAnyAnterior
    '    xls(i, 2).Interior.ColorIndex = 15
    '    xls(i, 3).Interior.ColorIndex = 15
    '    xls(i, 4).Interior.ColorIndex = 15
    '    xls(i, 5).Interior.ColorIndex = 15
    '    i = i + 1
    '    isant = i
    '    i = repaintSubcomptes(xls, i)
    '    i = i + 2
    '    ' SAFETIES ANY ACTUAL
    '    xls(i, 2) = t.codiSafetiesAny
    '    xls(i, 2).Interior.ColorIndex = 15
    '    xls(i, 3).Interior.ColorIndex = 15
    '    xls(i, 4).Interior.ColorIndex = 15
    '    xls(i, 5).Interior.ColorIndex = 15
    '    i = i + 1
    '    isact = i
    '    i = repaintSubcomptes(xls, i)
    '    i = i + 2
    '    'CONTROL
    '    xls(i, 2) = "CONTROL"
    '    xls(i, 2).Interior.ColorIndex = 8
    '    xls(i, 3).Interior.ColorIndex = 8
    '    xls(i, 4).Interior.ColorIndex = 8
    '    xls(i, 5).Interior.ColorIndex = 8
    '    i = i + 1
    '    Call repaintControl(xls, ias, iaant, iaact, isant, isact, i)
    '    wb.Worksheets("CONFIG_RESUM").visible = False
    '    xls(1, 3).COLUMNS.Hidden = True
    '    t = Nothing
    '    wb = Nothing
    '    xls = Nothing
    'End Sub




    '**** EXPORT DATA****
    '@ PROCEDIMENT  FUNCTION SETCLIENTS
    '@ DESCRIPCIO   Procediment principal per portar a terme l'exportació. Exporta les dades per mes i any
    '@ ENTRADES
    '@ SORTIDA
    '@ DATA
    '@ AUTOR
    '@ OBSERVACIONS
    Public Function setClients(clients As List(Of Client), wb As Workbook, mes As Integer, anyo As Integer) As List(Of EntradaLog)
        Dim c As Client, p As ProjecteClient, nomMes As String, wsPlantilla As Worksheet, wsMes As Worksheet, ws As Worksheet
        Dim xls As Object, j As Integer, xlsDades As Object, f As Integer, columna As Integer
        Dim t As Transitoria, toStringSubcte As String
        setClients = New List(Of EntradaLog)
        nomMes = CONFIG.mesNom(mes) & " - " & anyo
        setClients.Add(getELog(CONFIG.tipusEntradaLog.AVIS_log, IDIOMA.getString("iniDades") & nomMes, IDIOMA.getString("iniExportDades") & nomMes & " " & IDIOMA.getString("enFitxerResum") & " " & wb.Name))
        wsPlantilla = getWorksheetPlantilla(wb)
        If wsPlantilla IsNot Nothing Then
            wsPlantilla.Visible = True
            For Each ws In wb.Worksheets
                If StrComp(ws.Name, nomMes, vbTextCompare) = 0 Then
                    wsMes = ws
                    Call borrarProjectes(wsMes)
                    Exit For
                End If
            Next ws

            If wsMes Is Nothing Then
                wsPlantilla.Copy(wsPlantilla)
                wsMes = wb.ActiveSheet
                wsMes.Name = nomMes
            End If
            wsPlantilla.Visible = False

            For Each c In clients
                For Each p In c.projectes
                    Call afegirColumnaProjecte(wsMes)
                Next p
            Next c
            wsMes.Visible = True
            wsMes.Activate()
            xls = wsMes.Range(RANG_PROJECTES)
            xlsDades = wsMes.Range("a1")
            wsMes.Range("B3").Value = CStr(UCase(nomMes))
            wsMes.Range("B4").Value = IDIOMA.getString("actualitzar") & ": " & Format(Now, "dd-MM-yy hh:mm") & Chr(10) & "Per: " & Environment.UserName
            j = 1
            Call setFilesSubcomptes(wsMes, anyo) ' guardar la guia per poder trobar la fila dels diferents subcomptes
            wsMes.Columns("C:C").EntireColumn.Hidden = False
            For Each c In clients
                'log
                setClients.Add(getELog(CONFIG.tipusEntradaLog.AVIS_log, IDIOMA.getString("iniDades") & " " & c.nom, " " & IDIOMA.getString("iniExportClient") & " " & c.ToString))
                For Each p In c.projectes
                    setClients.Add(getELog(CONFIG.tipusEntradaLog.AVIS_log, IDIOMA.getString("iniDades") & " " & p.departa & p.clau, IDIOMA.getString("iniExportDades") & " " & p.ToString))
                    wsMes.Columns(xls(1, j).Column).Select
                    wsMes.Columns("C:C").copy
                    wsMes.Paste()
                    wb.Application.CutCopyMode = False
                    wsMes.Range(CStr(xls(0, j).Address)).Value = c.nom
                    wsMes.Range(xls(0, j).Address).Interior.ColorIndex = c.color
                    wsMes.Range(xls(1, j).Address).Value = Left(p.toStringTransitoria, 25)
                    columna = xls(1, j).Column
                    For Each t In p.transitoriesMes(mes)
                        If t.idSubcompte > 0 Then
                            f = trobarFilaSubcompte(t.codiAcrualsSafetiesAny, t.idSubcompte)
                            toStringSubcte = ModelSubcompte.getToString(t.idSubcompte)
                            If f > 0 Then
                                xlsDades(f, columna) = t.valorAS
                                setClients.Add(getELog(CONFIG.tipusEntradaLog.MIS_LOG, Left(toStringSubcte, 7), IDIOMA.getString("valor") & " " & t.codiAcrualsSafetiesAny & " = " & xlsDades(f, columna).text))
                            Else
                                setClients.Add(getELog(CONFIG.tipusEntradaLog.ERR_LOG, IDIOMA.getString("errSubcompte"), IDIOMA.getString("noSubcompte") & " " & ModelSubcompte.getToString(t.idSubcompte) & IDIOMA.getString("enApartat") & " " & t.codiAcrualsSafetiesAny))
                            End If
                            f = trobarFilaSubcompte(t.codiAcrualsAny, t.idSubcompte)
                            If f > 0 Then
                                xlsDades(f, columna) = t.valorAActual
                                setClients.Add(getELog(CONFIG.tipusEntradaLog.MIS_LOG, Left(toStringSubcte, 7), IDIOMA.getString("valor") & " " & t.codiAcrualsAny & " = " & xlsDades(f, columna).text))
                            Else
                                'estic aqui 
                                setClients.Add(getELog(CONFIG.tipusEntradaLog.ERR_LOG, IDIOMA.getString("errSubcompte"), IDIOMA.getString("noSubcompteTrobada") & ModelSubcompte.getToString(t.idSubcompte) & " " & IDIOMA.getString("enApartat") & " " & t.codiAcrualsAny))
                            End If
                            f = trobarFilaSubcompte(t.codiAcrualsAnyAnterior, t.idSubcompte)
                            If f > 0 Then
                                xlsDades(f, columna) = t.valorAAnterior
                                setClients.Add(getELog(CONFIG.tipusEntradaLog.MIS_LOG, Left(toStringSubcte, 7), IDIOMA.getString("valor") & " " & t.codiAcrualsAnyAnterior & " = " & xlsDades(f, columna).text))
                            Else
                                setClients.Add(getELog(CONFIG.tipusEntradaLog.ERR_LOG, IDIOMA.getString("errSubcompte"), IDIOMA.getString("noSubcompteTrobada") & ModelSubcompte.getToString(t.idSubcompte) & " " & IDIOMA.getString("enApartat") & " " & t.codiAcrualsAnyAnterior))
                            End If
                            f = trobarFilaSubcompte(t.codiSafetiesAny, t.idSubcompte)
                            If f > 0 Then
                                xlsDades(f, columna) = t.valorSActual
                                setClients.Add(getELog(CONFIG.tipusEntradaLog.MIS_LOG, Left(toStringSubcte, 7), IDIOMA.getString("valor") & t.codiSafetiesAny & " = " & xlsDades(f, columna).text))
                            Else
                                setClients.Add(getELog(CONFIG.tipusEntradaLog.ERR_LOG, IDIOMA.getString("errSubcompte"), IDIOMA.getString("noSubcompteTrobada") & " " & ModelSubcompte.getToString(t.idSubcompte) & " " & IDIOMA.getString("enApartat") & " " & t.codiSafetiesAny))
                            End If
                            f = trobarFilaSubcompte(t.codiSafetiesAnyAnterior, t.idSubcompte)
                            If f > 0 Then
                                xlsDades(f, columna) = t.valorSAnterior
                                setClients.Add(getELog(CONFIG.tipusEntradaLog.MIS_LOG, Left(toStringSubcte, 7), IDIOMA.getString("valor") & " " & t.codiSafetiesAnyAnterior & " = " & xlsDades(f, columna).text))
                            Else
                                setClients.Add(getELog(CONFIG.tipusEntradaLog.ERR_LOG, IDIOMA.getString("errSubcompte"), IDIOMA.getString("noSubcompteTrobada") & " " & ModelSubcompte.getToString(t.idSubcompte) & " " & IDIOMA.getString("enApartat") & " " & t.codiSafetiesAnyAnterior))
                            End If
                        ElseIf t.codiYellowSheet <> "" Then
                            f = trobarFilaYSheet(CONFIG.getUcaseTrim(t.codiYellowSheet))
                            If f > 0 Then
                                xlsDades(f, columna) = t.valorAS
                                setClients.Add(getELog(CONFIG.tipusEntradaLog.MIS_LOG, t.codiYellowSheet, IDIOMA.getString("valor") & " " & t.codiYellowSheet & " = " & xlsDades(f, columna).text))
                            Else
                                setClients.Add(getELog(CONFIG.tipusEntradaLog.ERR_LOG, IDIOMA.getString("errSubcompte"), IDIOMA.getString("noSubcompteTrobada") & " " & t.codiYellowSheet))
                            End If
                        End If
                    Next t
                    j = j + 1
                Next p
            Next c
            wsMes.Columns("C:C").EntireColumn.Hidden = True
        Else
            setClients.Add(getELog(CONFIG.tipusEntradaLog.ERR_LOG, IDIOMA.getString("errNoPlantilla"), IDIOMA.getString("noExisteixPlantillaDades") & " " & wb.Name))
        End If
        c = Nothing
        wsPlantilla = Nothing
        wsMes = Nothing
        xls = Nothing
        xlsDades = Nothing
        ws = Nothing
    End Function
    Private Function getWorksheetPlantilla(wb As Workbook) As Worksheet
        Dim ws As Worksheet
        getWorksheetPlantilla = Nothing
        For Each ws In wb.Worksheets
            If StrComp(ws.Name, FULLA_PLANTILLA, CompareMethod.Text) = 0 Then
                getWorksheetPlantilla = ws
                Exit For
            End If
        Next
        ws = Nothing
    End Function
    Private Sub borrarProjectes(ws As Worksheet)
        Dim xls As Object, j As Integer
        xls = ws.Range(RANG_PROJECTES)
        j = 1
        While Not (xls(1, j).text = "" Or xls(1, j).text = "TOTAL")
            j = j + 1
        End While
        If j > 1 Then
            ws.Range(xls(1, 1).Address & ":" & xls(1, j - 1).Address).EntireColumn.delete
        End If
        xls = Nothing
    End Sub

    Private Sub afegirColumnaProjecte(ws As Worksheet)
        Dim xls As Object, j As Integer
        xls = ws.Range(RANG_PROJECTES)
        j = 1
        ws.Columns(xls(1, j).Column).insert(Shift:=XlDirection.xlToRight, CopyOrigin:=XlInsertFormatOrigin.xlFormatFromLeftOrAbove)
        xls = Nothing
    End Sub

    Private Function trobarFilaSubcompte(apartat As String, codiSubcompte As String) As Integer
        Dim i As Integer
        trobarFilaSubcompte = 0
        For i = LBound(filesSubcomptes) To UBound(filesSubcomptes)
            If apartat = filesSubcomptes(i, 1) And codiSubcompte = filesSubcomptes(i, 2) Then
                trobarFilaSubcompte = i + 1
                Exit For
            End If
        Next i
    End Function
    Private Function trobarFilaYSheet(codi As String) As Integer
        Dim i As Integer
        trobarFilaYSheet = 0
        For i = LBound(filesSubcomptes) To UBound(filesSubcomptes)
            If codi = filesSubcomptes(i, 2) Then
                trobarFilaYSheet = i
                Exit For
            End If
        Next i
    End Function
    Private Sub setFilesSubcomptes(ws As Worksheet, anyo As Integer)
        Dim xls As Object, i As Integer, t As Transitoria, codi As String
        t = New Transitoria
        t.anyo = anyo
        xls = ws.Range("a1")
        codi = ""
        For i = LBound(filesSubcomptes) To UBound(filesSubcomptes)
            If t.isCode(xls(i + 1, 2).text) Then codi = xls(i + 1, 2).text
            filesSubcomptes(i, 1) = codi
            If IsNumeric(xls(i + 1, 1).text) Then
                filesSubcomptes(i, 2) = ModelSubcompte.getId(xls(i+1, 1).text)
            Else
                filesSubcomptes(i, 2) = CONFIG.getUcaseTrim(xls(i + 1, 1).text)
            End If
        Next i
    End Sub
    Private Function getELog(codi As tipusEntradaLog, titol As String, descripcio As String) As EntradaLog
        getELog = New EntradaLog
        getELog.codi = codi
        getELog.titol = titol
        getELog.descripcio = descripcio
    End Function
End Module
