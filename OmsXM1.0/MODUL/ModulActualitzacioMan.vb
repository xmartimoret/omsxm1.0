'estic aquí
Option Explicit On

Imports Microsoft.Office.Interop.Excel
Module ModulActualitzacioMan
    Private Const CODE_NAME_WORKSHEET_DADES As String = "WSPROJECTE"
    Private Const RANG_PROJECTES As String = "_RANG_PROJECTES"
    Private Const RANG_CODI_SUBGRUPS As String = "_CODI_GRUP"
    Private Const CODE_NAME_WORKBOOK As String = "WBMAN5"
    Private Const WORKSHEET_ACUM As String = "WSACUM"
    Private Const WORKSHEET_MONTH As String = "WSMENSUAL"
    Private Const WORKSHEET_BUDGET As String = "WSBUDGET"
    Private Const WORKSHEET_REAL As String = "WSREAL"
    Private Const WORKSHEET_CONFIG As String = "CONFIG"
    Private Const NUM_PROJECTES As Integer = 30
    Private Const RANG_TITOL_PROJECTES1 As String = "_TITOL_PROJECTE1"
    Private Const RANG_TITOL_PROJECTES2 As String = "_TITOL_PROJECTE2"
    Private Const RANG_TITOL_PROJECTES3 As String = "_TITOL_PROJECTE3"
    Private Const FULLA_DADES_REAL As String = "REAL"
    Private Const FULLA_DADES_BUDGET As String = "BUDGET"

    Private posSubgrupGb() As Long
    Private Const DADES_DE As String = "Dades de:"
    Private Const ACTUALITZADES As String = "Actualitzades:"
    Private Const ACTUALITZADES_PER As String = "Per:"
    Private Const PARTICIPACIO_TITOL As String = "%:"

    Private codiSubgrups(1000) As String
    Private codiCentres(150) As String
    Private valors(1000) As String
    Private tempCodiSubgrup As String
    Private tempFilaSubgrup As Integer
    Private tempCodiCentre As String
    Private tempColumnaCentre As Integer
    '1 ENS CAL AGAFAR EL LLIBRE I COMPROVAR QUE SIGUI UN WBMAN
    '2 ENS CAL SELECCIONAR EL CENTRE
    '3 CALDRÀ POSAR EL NOM DE LA FULLA I PODER CANVIAR L'ORDRE
    Private Function getObjects(xls As Range) As List(Of Centre)
        Dim c As Centre, i As Integer
        getObjects = New List(Of Centre)
        For i = 1 To NUM_PROJECTES
            If xls(i, 1).TEXT <> "" Then
                c = ModelCentre.getObject(CStr(xls(i, 1).TEXT))
                If c IsNot Nothing Then
                    c.ordre = i
                    getObjects.Add(c)
                End If
            End If
        Next i
    End Function
    Public Sub execute()
        Dim centres As List(Of Centre), c As Centre, xlaApli As Application, xls As Range
        Dim wbActual As Workbook, strCentres(,) As String, i As Integer
        xlaApli = EXCEL.getMacros
        wbActual = EXCEL.getWorkbookByCodeName(CODE_NAME_WORKBOOK)
        If wbActual IsNot Nothing Then
            If EXCEL.existWorkSheet(wbActual, WORKSHEET_CONFIG) Then
                xls = wbActual.Worksheets(WORKSHEET_CONFIG).RANGE(RANG_PROJECTES)
                centres = DCentresMan.getCentres(getObjects(xls), wbActual.Name)
                If centres IsNot Nothing Then
                    If xlaApli.Run("clearProjectesMan", wbActual) Then
                        ReDim strCentres(centres.Count - 1, 1)
                        i = 0
                        For Each c In centres
                            strCentres(i, 0) = c.codi
                            strCentres(i, 1) = c.nom
                            i = i + 1
                        Next c
                        If xlaApli.Run("setConfigProjectesMan", wbActual, strCentres) Then
                            Call MISSATGES.DATA_UPDATED()
                        Else
                            ERRORS.ERR_CONFIG_MAN
                        End If
                    Else
                        ERRORS.ERR_NO_EXIST_FULLA_CONFIG_MAN()
                    End If
                End If
            Else
                ERRORS.ERR_NO_EXIST_FULLA_CONFIG_MAN
            End If
        Else
            Call ERRORS.ERR_NO_MAN()
        End If
        Call EXCEL.closeMacros(xlaApli)
        centres = Nothing
        c = Nothing
        xls = Nothing
    End Sub

    ' NOU: Per unificar el setData a una GB.
    ' DATA: 10/05/2016
    ' AUTOR: XMARTI
    Public Function setData(centres As CentresGB, esReal As Boolean) As Collection
        Dim wB As Workbook, xls As Object, ims As ImportMesSubgrup, c As Centre, j As Integer, i As Integer, esObert As Boolean
        Dim mesEnCurs() As Integer, k As Integer
        Dim fullaDades As String
        Dim subgrups As List(Of Subgrup)
        Dim fAvis As frmAvis, apliMacro As Application
        subgrups = ModelSubgrup.getObjects
        setData = New Collection
        If centres IsNot Nothing Then 'comprovem que siguin centres gb
            If esReal Then
                fAvis = New frmAvis(IDIOMA.getString("dadesRealsMan"), IDIOMA.getString("carregantDades"), "")
                fullaDades = FULLA_DADES_REAL
            Else
                fAvis = New frmAvis(IDIOMA.getString("dadesBudgetMan"), IDIOMA.getString("carregantDades"), "")
                fullaDades = FULLA_DADES_BUDGET
            End If
            wB = EXCEL.getWorkbook(CONFIG.getFitxer(centres.rutaGB))
            esObert = True
            If TypeName(wB) <> "Workbook" Then ' en cas que no estigui obert
                wB = EXCEL.openWorkbook(centres.rutaGB, False, False)
                esObert = False
            End If
            If EXCEL.existWorkSheet(wB, fullaDades) Then 'comprovem que sigui  gb
                xls = wB.Worksheets(fullaDades).Range("a1")
                If centres.mesActual = -1 Then
                    xls(1, 1) = 12
                Else
                    xls(1, 1) = centres.mesActual
                End If
                xls(2, 1) = centres.anyActual
                apliMacro = EXCEL.getMacros
                Call setcodis(wB.Worksheets(fullaDades))
                For Each c In centres.centres
                    fAvis.setData(IDIOMA.getString("carregantDades"), c.ToString, "")
                    j = getPosCentre(c.codi)
                    If j > 0 Then ' en cas que existeixi el centre
                        ReDim mesEnCurs(0 To 12)
                        For Each ims In c.importsSubgrups
                            'i = cercarGrup(wb.Worksheets("dadesoms").Range("_codi_grup"), ims.codiGrup)
                            i = posSubgrupGb(ims.codiGrup)
                            ' cercar grup
                            If i > 0 Then
                                If mesEnCurs(ims.mes) <> ims.mes Then ' per posar els encapçalaments columna mes
                                    mesEnCurs(ims.mes) = ims.mes
                                    k = getPosMesGrup(ims.mes & DADES_DE)
                                    If k > 0 Then valors(k) = ims.tipusDades
                                    k = getPosMesGrup(ims.mes & ACTUALITZADES)
                                    If k > 0 Then valors(k) = "'" & Format(Now(), "DD-MM-YY HH:NN")
                                    k = getPosMesGrup(ims.mes & ACTUALITZADES_PER)
                                    If k > 0 Then valors(k) = Environment.UserName
                                    k = getPosMesGrup(ims.mes & PARTICIPACIO_TITOL)
                                    If k > 0 Then valors(k) = "'" & centres.participacio & "%"
                                End If
                                valors(i) = Math.Round(ims.valor * centres.participacio / 100, 2)
                                Call setData.Add(ModelLog.getEntradaLog(tipusEntradaLog.MIS_LOG, IDIOMA.getString("setData"), c.ToString & " --> " & ims.codiGrup & " = " & Format(ims.valor, "#,##0.00") & "*" & centres.participacio & "% = " & Format(ims.valor * centres.participacio / 100, "#,##0.00")))
                            Else
                                Call setData.Add(ModelLog.getEntradaLog(tipusEntradaLog.ERR_LOG, IDIOMA.getString("subGrupNoTrobat"), IDIOMA.getString("elSubGrup") & " " & ims.codiGrup & ". " & IDIOMA.getString("noExisteixMes") & " " & ims.mes))
                            End If
                        Next ims
                        apliMacro.Run("setDataGb", wB.Worksheets(fullaDades), j, valors)
                    Else
                        Call setData.Add(ModelLog.getEntradaLog(tipusEntradaLog.ERR_LOG, IDIOMA.getString("centreNoTrobat"), IDIOMA.getString("elCodi") & " " & c.codi & " " & IDIOMA.getString("noExisteixAGB") & c.nom))
                    End If
                Next c

                Call fAvis.tancar()
            Else
                Call setData.Add(ModelLog.getEntradaLog(tipusEntradaLog.ERR_LOG, IDIOMA.getString("errFitxerMan"), IDIOMA.getString("elFitxerSeleccionat") & " " & wB.Name & " " & IDIOMA.getString("noFitxerMan") & " ."))
                If Not esObert Then Call wB.Close(False)
            End If
        End If
        ReDim posSubgrupGb(0 To 0)
        xls = Nothing
        wB = Nothing
        ims = Nothing
        c = Nothing
        subgrups = Nothing
    End Function
    Private Sub setcodis(ws As Worksheet)
        Dim i As Integer, blancs As Integer, xls As Object
        xls = ws.Range(RANG_CODI_SUBGRUPS)
        blancs = 0
        For i = 1 To UBound(codiSubgrups)
            If xls(i, 1).text <> "" Then
                codiSubgrups(i) = xls(i, 1).text
                blancs = 0
            Else
                blancs = blancs + 1
            End If
            If blancs = 20 Then Exit For
        Next
        xls = ws.Range(RANG_PROJECTES)
        blancs = 0
        For i = 1 To UBound(codiCentres)
            If xls(1, i).text <> "" Then
                codiCentres(i) = xls(1, i).text
                blancs = 0
            Else
                blancs = blancs + 1
            End If
            If blancs = 20 Then Exit For
        Next
    End Sub

    'PROCEDIMENT/FUNCIÓ:
    'DESCRIPCIÓ:
    'AUTOR: XMARTI. 24/07/2016
    'ENTRADES:
    'SORTIDA:
    Private Function getPosCentre(codi As String) As Integer
        Dim i As Integer
        getPosCentre = -1
        For i = 1 To UBound(codiCentres)
            If StrComp(Trim(codiCentres(i)), UCase(Trim(codi)), CompareMethod.Text) = 0 Then
                getPosCentre = i
                Exit For
            End If
        Next i
    End Function
    Private Function getPosMesGrup(codi As String)
        Dim i As Integer
        getPosMesGrup = -1
        For i = 1 To UBound(codiSubgrups)
            If UCase(codi) = UCase(codiSubgrups(i)) Then
                getPosMesGrup = i
                Exit For
            End If
        Next i
    End Function

    ' NOU, AQUI NOMES EM D'AGAFAR EL CENTRES.
    Public Sub exportData()
        Dim centres As CentresGB, e As EntradaLog, logActual As Log
        logActual = New Log
        logActual.titol = IDIOMA.getString("logExportMan")
        logActual.descripcio = IDIOMA.getString("logDescripcioMan")
        Call ModelTransitoria.resetIndex()
        centres = DExportGB.getCentres(False, True)
        If centres IsNot Nothing Then
            For Each e In setData(centres, True)
                logActual.entrades.Add(e)
            Next e
            For Each e In ModelDiario.getNoVinculats(centres.empresa, centres.contaplus, centres.mesActual) ' comprova el diario.
                logActual.entrades.Add(e)
            Next e
            Call MISSATGES.DATA_UPDATED()
            If ModelLog.hihaErrors(logActual.entrades) Then
                Call dLogs.setLog(logActual)
            End If
        End If
        If centres IsNot Nothing Then
            If centres.isLog Then Call ModelInformes.executeLog(logActual)
            If Not centres.isClose Then Call exportData()
        End If
        centres = Nothing
        logActual = Nothing
        e = Nothing
    End Sub
    Public Sub actualitzarMes()
        Dim anymes As AnyMesos, wB As Workbook, m As Integer
        wB = EXCEL.getWorkbookByCodeName(CODE_NAME_WORKBOOK)
        If wB IsNot Nothing Then
            anymes = DMesos.getDataGb
            If anymes IsNot Nothing Then
                For m = 1 To 12
                    If anymes.esActiu(m) Then
                        wB.Worksheets(FULLA_DADES_REAL).Range("A1").Text = m
                        wB.Worksheets(FULLA_DADES_BUDGET).Range("A1").Text = m
                        Exit For
                    End If
                Next m
                wB.Worksheets(FULLA_DADES_REAL).Range("A2").Text = anymes.any
                wB.Worksheets(FULLA_DADES_BUDGET).Range("A2").Text = anymes.any
                wB.Worksheets(WORKSHEET_CONFIG).Range("_RANG_ANY_ACTUAL").Text = anymes.any
            End If
        Else

        End If
        wB = Nothing
    End Sub

End Module
