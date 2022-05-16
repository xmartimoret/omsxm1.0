Option Explicit On
Imports exc = Microsoft.Office.Interop.Excel
Public Module modulF56
    Private Const F_EMPRESES As String = "WSEMPRESA"
    Private Const F_CONTACTES_PROVEIDOR As String = "WSCONTACTE"
    Private Const F_CONTACTES_MAGATZEM As String = "WSCONTACTEMAGATZEM"
    Private Const F_MAGATZEMS As String = "WSENTREGA"
    Private Const F_PROJECTES As String = "WSPROJECTE"
    Private Const F_PROVEIDORS As String = "WSPROVEIDOR"
    Private Const F_RESPONSABLES As String = "WSRESPONSABLE"
    Public Function execute() As String
        Dim wb As exc.Workbook, avis As frmAvis, rutaInforme As String
        Dim ws As exc.Worksheet
        avis = New frmAvis(IDIOMA.getString("esperaUnMoment"), IDIOMA.getString("creantInforme"), IDIOMA.getString("f56"))
        wb = EXCEL.getWorkbook(CONFIG.getPlantillaF56)
        If IsNothing(wb) Then wb = EXCEL.openWorkbook(CONFIG.getRutaPlantillaf56,, True)
        If Not IsNothing(wb) Then
            wb.Application.Calculation = exc.XlCalculation.xlCalculationManual
            wb.Application.ScreenUpdating = False
            wb.Application.DisplayStatusBar = False
            wb.Application.EnableEvents = False
            wb.Windows(1).Visible = False
            ws = EXCEL.getWorkSheet(wb, F_EMPRESES)
            If Not IsNothing(ws) Then
                avis.setData(IDIOMA.getString("creantInforme"), IDIOMA.getString("empreses"))
                Call setEmpreses(ws)
            End If

            ws = EXCEL.getWorkSheet(wb, F_PROJECTES)
            If Not IsNothing(ws) Then
                avis.setData(IDIOMA.getString("creantInforme"), CStr(IDIOMA.getString("projectes")))
                Call setProjectes(ws)
            End If
            ws = EXCEL.getWorkSheet(wb, F_PROVEIDORS)
            If Not IsNothing(ws) Then
                avis.setData(IDIOMA.getString("creantInforme"), CStr(IDIOMA.getString("proveidors")))
                Call setProveidors(ws)
            End If
            ws = EXCEL.getWorkSheet(wb, F_CONTACTES_PROVEIDOR)
            If Not IsNothing(ws) Then
                avis.setData(IDIOMA.getString("creantInforme"), CStr(IDIOMA.getString("contactesProveidor")))
                Call setContactesProveidors(ws)
            End If
            ws = EXCEL.getWorkSheet(wb, F_RESPONSABLES)
            If Not IsNothing(ws) Then
                avis.setData(IDIOMA.getString("creantInforme"), CStr(IDIOMA.getString("responsablesCompra")))
                Call setResponsables(ws)
            End If
            ws = EXCEL.getWorkSheet(wb, F_CONTACTES_MAGATZEM)
            If Not IsNothing(ws) Then
                avis.setData(IDIOMA.getString("creantInforme"), CStr(IDIOMA.getString("contactes")))
                Call setContactesMagatzem(ws)
            End If

            ws = EXCEL.getWorkSheet(wb, F_MAGATZEMS)
            If Not IsNothing(ws) Then
                avis.setData(IDIOMA.getString("creantInforme"), CStr(IDIOMA.getString("magatzems")))
                Call setMagatzems(ws)
            End If
            rutaInforme = CONFIG.getDirectoritemporal
            rutaInforme = CONFIG.setFolder(rutaInforme) & Format(Now, "yyMMddhhmm") & IDIOMA.getString("fitxerF568132bits") & ".xls"
            wb.SaveAs(rutaInforme)
            Application.DoEvents()
            wb.Windows(1).Visible = True
            wb.Application.Calculation = exc.XlCalculation.xlCalculationAutomatic
            wb.Application.ScreenUpdating = True
            wb.Application.DisplayStatusBar = True
            wb.Application.EnableEvents = True
            wb.Close(True)
            Application.DoEvents()
            avis.tancar()
            If CONFIG.fileExist(rutaInforme) Then Return rutaInforme
        End If
        avis.tancar()
        Return Nothing
    End Function
    Private Sub setEmpreses(ws As exc.Worksheet)
        Dim xls As exc.Range, i As Integer, e As Empresa
        xls = ws.Range("a2")
        i = 1
        For Each e In ModelEmpresa.getObjects
            xls(i, 1) = e.id
            xls(i, 2) = e.codi
            xls(i, 3) = e.nom
            i = i + 1
        Next
        xls = Nothing
    End Sub

    Private Sub setProjectes(ws As exc.Worksheet)
        Dim xls As exc.Range, i As Integer, p As Projecte
        xls = ws.Range("a2")
        i = 1
        For Each p In ModelProjecte.getObjects()
            xls(i, 1) = p.id
            xls(i, 2) = p.idEmpresa
            xls(i, 3) = p.codi
            xls(i, 4) = p.nom
            i = i + 1
        Next
        xls = Nothing
    End Sub
    Private Sub setProveidors(ws As exc.Worksheet)
        Dim xls As exc.Range, i As Integer, p As Proveidor
        xls = ws.Range("a2")
        i = 1
        For Each p In ModelProveidor.getObjectsActius()
            xls(i, 1) = p.id
            xls(i, 2) = p.codi
            xls(i, 3) = p.nom
            xls(i, 4) = p.direccio
            xls(i, 5) = p.codiPostal
            xls(i, 6) = p.provincia.nom
            xls(i, 7) = p.pais.nom
            xls(i, 8) = p.email
            i = i + 1
        Next
        xls = Nothing
    End Sub
    Private Sub setContactesProveidors(ws As exc.Worksheet)
        Dim xls As exc.Range, i As Integer, p As ProveidorCont
        xls = ws.Range("a2")
        i = 1
        For Each p In ModelProveidorContacte.getObjects(True)
            xls(i, 1) = p.id
            xls(i, 2) = p.idProveidor
            xls(i, 3) = p.departament
            xls(i, 4) = p.nom
            xls(i, 5) = p.direccio
            xls(i, 6) = p.poblacio
            xls(i, 7) = p.codiPostal
            xls(i, 8) = p.pais.nom
            xls(i, 9) = p.provincia.nom
            xls(i, 10) = p.telefon1
            xls(i, 11) = p.telefon2
            xls(i, 13) = p.email
            i = i + 1
        Next
        xls = Nothing
    End Sub
    Private Sub setResponsables(ws As exc.Worksheet)
        Dim xls As exc.Range, i As Integer, p As ResponsableCompra
        xls = ws.Range("a2")
        i = 1
        For Each p In ModelResponsableCompra.getAuxiliar.getObjectsActius
            xls(i, 1) = p.id
            xls(i, 2) = p.codi
            xls(i, 3) = p.nom
            xls(i, 4) = p.notes
            i = i + 1
        Next
        xls = Nothing
    End Sub
    Private Sub setContactesMagatzem(ws As exc.Worksheet)
        Dim xls As exc.Range, i As Integer, p As Contacte
        xls = ws.Range("a2")
        i = 1
        For Each p In ModelContacte.getObjects(True)
            xls(i, 1) = p.id
            xls(i, 2) = p.nom
            xls(i, 3) = p.cognom1
            xls(i, 4) = p.cognom2
            xls(i, 10) = p.telefon
            xls(i, 11) = p.email
            i = i + 1
        Next
        xls = Nothing
    End Sub
    Private Sub setMagatzems(ws As exc.Worksheet)
        Dim xls As exc.Range, i As Integer, p As LlocEntrega
        xls = ws.Range("a2")
        i = 1
        For Each p In ModelLlocEntrega.getObjects(True)
            xls(i, 1) = p.id
            xls(i, 2) = p.nom
            xls(i, 3) = p.direccio
            xls(i, 4) = p.poblacio
            xls(i, 5) = p.codiPostal
            xls(i, 6) = p.provincia.nom
            xls(i, 7) = p.pais.nom
            i = i + 1
        Next
        xls = Nothing
    End Sub
End Module
