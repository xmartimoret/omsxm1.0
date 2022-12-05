Option Explicit On
Imports exc = Microsoft.Office.Interop.Excel
Module modulInfoArticle
    Private Enum pos
        ID = 1
        CODI
        NOM
        FAMILIA
        FABRICANT
        IVA
        UNITAT
    End Enum

    Public Sub execute(P As List(Of article), isPDf As Boolean, filtre As String)
        Dim wb As exc.Workbook, xls As exc.Range, i As Integer, o As article, avis As frmAvis
        wb = EXCEL.getWorkbook(CONFIG.getPlantillaArticles)
        If IsNothing(wb) Then wb = EXCEL.openWorkbook(CONFIG.getRutaPlantillaArticles,, True)
        If Not IsNothing(wb) Then
            avis = New frmAvis(IDIOMA.getString("esperaUnMoment"), IDIOMA.getString("imprimintInforme"), IDIOMA.getString("article"), P.Count)
            wb.Application.Calculation = exc.XlCalculation.xlCalculationManual
            wb.Application.ScreenUpdating = False
            wb.Application.DisplayStatusBar = False
            wb.Application.EnableEvents = False
            wb.Worksheets(1).range("A4:G4525").rows.entirerow.hidden = True
            i = 1
            xls = wb.Worksheets(1).range("A1")
            xls(1, 1) = UCase(IDIOMA.getString("informe")) & " - " & IDIOMA.getString("article")
            If filtre <> "" Then
                xls = wb.Worksheets(1).range("A2")
                xls(1, 1) = UCase(IDIOMA.getString("filtratPer")) & " (" & filtre & ")"
            End If
            xls = wb.Worksheets(1).range("a4")



            For Each o In P
                avis.setData(o.nom, i)
                xls(i, pos.ID) = o.id
                xls(i, pos.CODI) = o.codi
                xls(i, pos.NOM) = o.nom
                xls(i, pos.FAMILIA) = o.familia.nom
                xls(i, pos.FABRICANT) = o.fabricant.nom
                xls(i, pos.IVA) = o.iva.codi
                xls(i, pos.UNITAT) = o.unitat.codi
                i = i + 1
            Next



            wb.Worksheets(1).range("A4:P" & i + 1).rows.entirerow.hidden = False
            wb.Application.Calculation = exc.XlCalculation.xlCalculationAutomatic
            wb.Application.ScreenUpdating = True
            wb.Application.DisplayStatusBar = True
            wb.Application.EnableEvents = True
            avis.tancar()
        End If

        If isPDf Then
            Call PDF.killProcess()
            Try
                wb.ExportAsFixedFormat(exc.XlFixedFormatType.xlTypePDF, CONFIG.setSeparator(getRuta) & Format(Now, "yyMMddhhmm") & "_INF_ARTICLE.Pdf", 1, , , , , True)
            Catch e As Exception
                MsgBox(e.Message)
                ERRORS.ERR_PDF_CLOSE("")
            End Try
        Else
            wb.SaveAs(CONFIG.setSeparator(getRuta) & Format(Now, "yyMMddhhmm") & "_INF_ARTICLE.xlsx")
        End If
        If isPDf Then wb.Close(False)
        wb = Nothing
        xls = Nothing
    End Sub
    Public Sub execute(p As article, isPDf As Boolean)
        Dim wb As exc.Workbook, xls As exc.Range, i As Integer, avis As frmAvis, c As ArticlePreu
        wb = EXCEL.getWorkbook(CONFIG.getPlantillaArticle)
        If IsNothing(wb) Then wb = EXCEL.openWorkbook(CONFIG.getRutaPlantillaArticle,, True)
        If Not IsNothing(wb) Then
            avis = New frmAvis(IDIOMA.getString("esperaUnMoment"), IDIOMA.getString("imprimintInforme"), IDIOMA.getString("article"))
            wb.Application.Calculation = exc.XlCalculation.xlCalculationManual
            wb.Application.ScreenUpdating = False
            wb.Application.DisplayStatusBar = False
            wb.Application.EnableEvents = False
            xls = wb.Worksheets(1).range("_id") : xls(1, 1) = p.id
            xls = wb.Worksheets(1).range("_CODI") : xls(1, 1) = p.codi
            xls = wb.Worksheets(1).range("_NOM") : xls(1, 1) = p.nom
            xls = wb.Worksheets(1).range("_FAMILIA") : xls(1, 1) = p.familia.toString
            xls = wb.Worksheets(1).range("_FABRICANT") : xls(1, 1) = p.fabricant.toString
            xls = wb.Worksheets(1).range("_IVA") : xls(1, 1) = p.iva.toString
            xls = wb.Worksheets(1).range("_UNITAT") : xls(1, 1) = p.unitat.codi
            xls = wb.Worksheets(1).range("_NOTES") : xls(1, 1) = p.notes
            wb.Worksheets(1).range("A10:A1013").rows.entirerow.hidden = False
            xls = wb.Worksheets(1).range("A10")
            i = 1
            For Each c In p.preusProveidors
                xls(i, 1) = c.data
                xls(i, 3) = ModelProveidor.getNom(c.idProveidor)
                xls(1, 6) = c.base
                xls(2, 8) = c.descompte
                i = i + 1
            Next
            wb.Worksheets(1).range("A10:A" & 10 + i + 1).rows.entirerow.hidden = True
            avis.tancar()
        End If
        wb.Application.Calculation = exc.XlCalculation.xlCalculationAutomatic
        wb.Application.ScreenUpdating = True
        wb.Application.DisplayStatusBar = True
        wb.Application.EnableEvents = True
        If isPDf Then
            Call PDF.killProcess()
            Try
                wb.ExportAsFixedFormat(exc.XlFixedFormatType.xlTypePDF, CONFIG.setSeparator(getRuta) & Format(Now, "yyMMddhhmm") & "_INF_ARTICLE_" & p.id & ".Pdf", 1, , , , , True)
            Catch e As Exception
                MsgBox(e.Message)
                ERRORS.ERR_PDF_CLOSE("")
            End Try
        Else
            wb.SaveAs(CONFIG.setSeparator(getRuta) & Format(Now, "yyMMddhhmm") & "_INF_ARTICLE_" & p.id & ".xlsx")
        End If
        If isPDf Then wb.Close(False)
        wb = Nothing
        xls = Nothing
    End Sub
    Public Function execute(dades As List(Of List(Of String)), isPdf As Boolean, filtre As String)
        Dim wb As exc.Workbook, xls As exc.Range, i As Integer, o As article, avis As frmAvis
        Dim f As List(Of String)
        wb = EXCEL.getWorkbook(CONFIG.getPlantillaArticlescOMANDES)
        If IsNothing(wb) Then wb = EXCEL.openWorkbook(CONFIG.getRutaPlantillaArticlesComandes,, True)
        If Not IsNothing(wb) Then
            avis = New frmAvis(IDIOMA.getString("esperaUnMoment"), IDIOMA.getString("imprimintInforme"), IDIOMA.getString("article"), dades.Count)
            wb.Application.Calculation = exc.XlCalculation.xlCalculationManual
            wb.Application.ScreenUpdating = False
            wb.Application.DisplayStatusBar = False
            wb.Application.EnableEvents = False
            wb.Worksheets(1).range("A4:H4525").rows.entirerow.hidden = True
            i = 1
            xls = wb.Worksheets(1).range("D1")
            xls(1, 1) = UCase(IDIOMA.getString("informeArticlesComanda"))
            'If filtre <> "" Then
            xls = wb.Worksheets(1).range("D2")
            xls(1, 1) = UCase(IDIOMA.getString("filtratPer")) & " (" & filtre & ")"
            ' End If
            xls = wb.Worksheets(1).range("a4")


            i = 1
            For Each f In dades
                avis.setData(f(0), i)
                xls(i, 1) = f(0)
                xls(i, 2) = f(1)
                xls(i, 3) = f(2)
                If IsDate(f(3)) Then xls(i, 4) = CDate(f(3))
                xls(i, 5) = "'" & f(4)
                xls(i, 6) = f(5)
                xls(i, 7) = f(6)
                xls(i, 8) = f(7)
                xls(i, 9) = CDbl(f(8))
                xls(i, 10) = f(9)
                xls(i, 11) = CDbl(f(10))
                xls(i, 12) = f(11)
                xls(i, 13) = CDbl(f(12))
                xls(i, 14) = CDbl(f(13))
                i = i + 1
            Next

            wb.Worksheets(1).range("A4:P" & i + 3).rows.entirerow.hidden = False
        End If
        wb.Application.Calculation = exc.XlCalculation.xlCalculationAutomatic
        wb.Application.ScreenUpdating = True
        wb.Application.DisplayStatusBar = True
        wb.Application.EnableEvents = True
        avis.tancar()
        If isPdf Then
            Call PDF.killProcess()
            Try
                wb.ExportAsFixedFormat(exc.XlFixedFormatType.xlTypePDF, CONFIG.setSeparator(getRuta) & Format(Now, "yyMMddhhmm") & "_INF_ARTICLES_COMANDA_.Pdf", 1, , , , , True)
            Catch e As Exception
                MsgBox(e.Message)
                ERRORS.ERR_PDF_CLOSE("")
            End Try
        Else
            wb.SaveAs(CONFIG.setSeparator(getRuta) & Format(Now, "yyMMddhhmm") & "_INF_ARTICLES_COMANDA_.xlsx")
        End If
        If isPdf Then wb.Close(False)
        wb = Nothing
        xls = Nothing
    End Function
    Private Function getRuta() As String
        Dim p As String
        p = CONFIG_FILE.getTag(CONFIG_FILE.TAG.RUTA_IMPRESSIO_INFORMES)
        If Not CONFIG.folderExist(p) Then p = CONFIG.getDirectoriPredeterminatInformes
        Return p
    End Function
End Module


