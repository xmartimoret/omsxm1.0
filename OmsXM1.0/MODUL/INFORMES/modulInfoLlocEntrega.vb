Option Explicit On
Imports exc = Microsoft.Office.Interop.Excel

Module modulInfoLlocEntrega
    Private Enum pos
        ID = 1
        CODI
        NOM
        DIRECCIO
        CODI_POSTAL
        POBLACIO
        PROVINCIA
        PAIS
        ACTIU
    End Enum
    Public Sub execute(P As List(Of LlocEntrega), isPDf As Boolean, filtre As String)
        Dim wb As exc.Workbook, xls As exc.Range, i As Integer, o As LlocEntrega, avis As frmAvis
        wb = EXCEL.getWorkbook(CONFIG.getPlantillaLlocsEntrega)
        If IsNothing(wb) Then wb = EXCEL.openWorkbook(CONFIG.getRutaPlantillaLlocsEntrega,, True)
        If Not IsNothing(wb) Then
            avis = New frmAvis(IDIOMA.getString("esperaUnMoment"), IDIOMA.getString("imprimintInforme"), IDIOMA.getString("llocEntrega"), P.Count)
            wb.Application.Calculation = exc.XlCalculation.xlCalculationManual
            wb.Application.ScreenUpdating = False
            wb.Application.DisplayStatusBar = False
            wb.Application.EnableEvents = False
            wb.Worksheets(1).range("A4:i4525").rows.entirerow.hidden = True
            xls = wb.Worksheets(1).range("A1")
            xls(1, 1) = UCase(IDIOMA.getString("informe")) & " - " & IDIOMA.getString("llocEntrega")
            If filtre <> "" Then
                xls = wb.Worksheets(1).range("A2")
                xls(1, 1) = UCase(IDIOMA.getString("filtratPer")) & " (" & filtre & ")"
            End If
            i = 1
            xls = wb.Worksheets(1).range("a4")
            For Each o In P
                avis.setData(o.nom, i)
                xls(i, pos.ID) = o.id
                xls(i, pos.CODI) = o.codi
                xls(i, pos.NOM) = o.nom
                If o.actiu Then
                    xls(i, pos.ACTIU) = IDIOMA.getString("si")
                Else
                    xls(i, pos.ACTIU) = IDIOMA.getString("no")
                End If
                xls(i, pos.CODI_POSTAL) = o.codiPostal
                xls(i, pos.DIRECCIO) = o.direccio
                xls(i, pos.CODI_POSTAL) = o.codiPostal
                xls(i, pos.POBLACIO) = o.poblacio
                xls(i, pos.PAIS) = o.pais.nom
                xls(i, pos.PROVINCIA) = o.provincia.nom
                i = i + 1
            Next
            wb.Worksheets(1).range("A4:i" & i + 1).rows.entirerow.hidden = False
            wb.Application.Calculation = exc.XlCalculation.xlCalculationAutomatic
            wb.Application.ScreenUpdating = True
            wb.Application.DisplayStatusBar = True
            wb.Application.EnableEvents = True
            avis.tancar()
        End If
        If isPDf Then
            Call PDF.killProcess()
            Try
                wb.ExportAsFixedFormat(exc.XlFixedFormatType.xlTypePDF, CONFIG.setSeparator(getRuta) & Format(Now, "yyMMddhhmm") & "_INF_LLOCS_ENTREGA.Pdf", 1, , , , , True)
            Catch e As Exception
                MsgBox(e.Message)
                ERRORS.ERR_PDF_CLOSE("")
            End Try
        Else
            wb.SaveAs(CONFIG.setSeparator(getRuta) & Format(Now, "yyMMddhhmm") & "_INF_LLOCS_ENTREGA.xlsx")
        End If
        If isPDf Then wb.Close(False)
        wb = Nothing
        xls = Nothing
    End Sub
    Public Sub execute(p As LlocEntrega, isPDf As Boolean)
        Dim wb As exc.Workbook, xls As exc.Range, i As Integer, j As Integer
        Dim rangC(10, 1) As String, avis As frmAvis

        wb = EXCEL.getWorkbook(CONFIG.getPlantillaLlocEntrega)
        If IsNothing(wb) Then wb = EXCEL.openWorkbook(CONFIG.getRutaPlantillaLlocEntrega,, True)
        If Not IsNothing(wb) Then
            avis = New frmAvis(IDIOMA.getString("esperaUnMoment"), IDIOMA.getString("imprimintInforme"), IDIOMA.getString("llocEntrega"))
            wb.Application.Calculation = exc.XlCalculation.xlCalculationManual
            wb.Application.ScreenUpdating = False
            wb.Application.DisplayStatusBar = False
            wb.Application.EnableEvents = False

            xls = wb.Worksheets(1).range("_id") : xls(1, 1) = p.id
            xls = wb.Worksheets(1).range("_CODI") : xls(1, 1) = p.codi
            xls = wb.Worksheets(1).range("_NOM") : xls(1, 1) = p.nom
            xls = wb.Worksheets(1).range("_DIRECCIO") : xls(1, 1) = p.direccio
            xls = wb.Worksheets(1).range("_POBLACIO") : xls(1, 1) = p.poblacio
            xls = wb.Worksheets(1).range("_CP") : xls(1, 1) = p.codiPostal
            xls = wb.Worksheets(1).range("_PROVINCIA") : xls(1, 1) = p.provincia.nom
            xls = wb.Worksheets(1).range("_PAIS") : xls(1, 1) = p.pais.nom
            If p.actiu Then
                xls = wb.Worksheets(1).range("_ESTAT") : xls(1, 1) = IDIOMA.getString("actiu")
            Else
                xls = wb.Worksheets(1).range("_ESTAT") : xls(1, 1) = IDIOMA.getString("noActiu")
            End If
            xls = wb.Worksheets(1).range("_NOTES") : xls(1, 1) = p.notes
            avis.tancar()
        End If
        wb.Application.Calculation = exc.XlCalculation.xlCalculationAutomatic
        wb.Application.ScreenUpdating = True
        wb.Application.DisplayStatusBar = True
        wb.Application.EnableEvents = True

        If isPDf Then
            Call PDF.killProcess()
            Try
                wb.ExportAsFixedFormat(exc.XlFixedFormatType.xlTypePDF, CONFIG.setSeparator(getRuta) & Format(Now, "yyMMddhhmm") & "_INF_PROV_" & p.id & ".Pdf", 1, , , , , True)
            Catch e As Exception
                MsgBox(e.Message)
                ERRORS.ERR_PDF_CLOSE("")
            End Try
        Else
            wb.SaveAs(CONFIG.setSeparator(getRuta) & Format(Now, "yyMMddhhmm") & "_INF_PROV_" & p.id & ".xlsx")
        End If
        If isPDf Then wb.Close(False)
        wb = Nothing
        xls = Nothing
    End Sub
    Private Function getRuta() As String
        Dim p As String
        p = CONFIG_FILE.getTag(CONFIG_FILE.TAG.RUTA_IMPRESSIO_INFORMES)
        If Not CONFIG.folderExist(p) Then p = CONFIG.getDirectoriPredeterminatInformes
        Return p
    End Function
End Module


