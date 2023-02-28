Option Explicit On
Imports exc = Microsoft.Office.Interop.Excel
Module ModulInfoAuxiliar

    Public Sub infoTipusPagament(P As List(Of Object), isPDf As Boolean, filtre As String)
        Dim wb As exc.Workbook, xls As exc.Range, i As Integer, o As TipusPagament, avis As frmAvis
        wb = EXCEL.getWorkbook(CONFIG.getPlantillaTipusPagament)
        If IsNothing(wb) Then wb = EXCEL.openWorkbook(CONFIG.getRutaPlantillaTipusPagament,, True)
        If Not IsNothing(wb) Then
            avis = New frmAvis(IDIOMA.getString("esperaUnMoment"), IDIOMA.getString("imprimintInforme"), IDIOMA.getString("tipusPagament"), P.Count)
            wb.Application.Calculation = exc.XlCalculation.xlCalculationManual
            wb.Application.ScreenUpdating = False
            wb.Application.DisplayStatusBar = False
            wb.Application.EnableEvents = False
            wb.Worksheets(1).range("A4:H4525").rows.entirerow.hidden = True
            xls = wb.Worksheets(1).range("A1")
            xls(1, 1) = UCase(IDIOMA.getString("informe")) & " - " & IDIOMA.getString("tipusPagament")
            If filtre <> "" Then
                xls = wb.Worksheets(1).range("A2")
                xls(1, 1) = UCase(IDIOMA.getString("filtratPer")) & " (" & filtre & ")"
            End If

            i = 1
            xls = wb.Worksheets(1).range("a4")
            For Each o In P
                avis.setData(o.nom, i)
                xls(i, 1) = o.id
                xls(i, 2) = o.codi
                xls(i, 3) = o.nom
                xls(i, 4) = o.dies
                xls(i, 5) = o.diaPagament
                If o.actiu Then
                    xls(i, 6) = IDIOMA.getString("si")
                Else
                    xls(i, 6) = IDIOMA.getString("no")
                End If

                i = i + 1
            Next
            wb.Worksheets(1).range("A4:H" & i + 1).rows.entirerow.hidden = False
            wb.Application.Calculation = exc.XlCalculation.xlCalculationAutomatic
            wb.Application.ScreenUpdating = True
            wb.Application.DisplayStatusBar = True
            wb.Application.EnableEvents = True
            avis.tancar()
        End If
        If isPDf Then
            Call PDF.killProcess()
            Try
                wb.ExportAsFixedFormat(exc.XlFixedFormatType.xlTypePDF, CONFIG.setSeparator(getRuta) & Format(Now, "yyMMddhhmm") & "_INF_TIPUS_PAGAMENT.Pdf", 1, , , , , True)
            Catch e As Exception
                MsgBox(e.Message)
                ERRORS.ERR_PDF_CLOSE("")
            End Try
        Else
            wb.SaveAs(CONFIG.setSeparator(getRuta) & Format(Now, "yyMMddhhmm") & "_INF_TIPUS_PAGAMENT.xlsx")
        End If
        If isPDf Then wb.Close(False)
        wb = Nothing
        xls = Nothing
    End Sub
    Public Sub infoPais(P As List(Of Object), isPDf As Boolean, filtre As String)
        Dim wb As exc.Workbook, xls As exc.Range, i As Integer, o As Pais, avis As frmAvis
        wb = EXCEL.getWorkbook(CONFIG.getPlantillaPais)
        If IsNothing(wb) Then wb = EXCEL.openWorkbook(CONFIG.getRutaPlantillaPais,, True)
        If Not IsNothing(wb) Then
            avis = New frmAvis(IDIOMA.getString("esperaUnMoment"), IDIOMA.getString("imprimintInforme"), IDIOMA.getString("pais"), P.Count)
            wb.Application.Calculation = exc.XlCalculation.xlCalculationManual
            wb.Application.ScreenUpdating = False
            wb.Application.DisplayStatusBar = False
            wb.Application.EnableEvents = False
            wb.Worksheets(1).range("A4:H4525").rows.entirerow.hidden = True
            xls = wb.Worksheets(1).range("A1")
            xls(1, 1) = UCase(IDIOMA.getString("informe")) & " - " & IDIOMA.getString("pais")
            If filtre <> "" Then
                xls = wb.Worksheets(1).range("A2")
                xls(1, 1) = UCase(IDIOMA.getString("filtratPer")) & " (" & filtre & ")"
            End If
            i = 1
            xls = wb.Worksheets(1).range("a4")
            For Each o In P
                avis.setData(o.nom, i)
                xls(i, 1) = o.id
                xls(i, 2) = o.codi
                xls(i, 3) = o.abreviatura
                xls(i, 4) = o.nom
                xls(i, 5) = o.notes
                If o.actiu Then
                    xls(i, 6) = IDIOMA.getString("si")
                Else
                    xls(i, 6) = IDIOMA.getString("no")
                End If

                i = i + 1
            Next
            wb.Worksheets(1).range("A4:H" & i + 1).rows.entirerow.hidden = False
            wb.Application.Calculation = exc.XlCalculation.xlCalculationAutomatic
            wb.Application.ScreenUpdating = True
            wb.Application.DisplayStatusBar = True
            wb.Application.EnableEvents = True
            avis.tancar()
        End If
        If isPDf Then
            Call PDF.killProcess()
            Try
                wb.ExportAsFixedFormat(exc.XlFixedFormatType.xlTypePDF, CONFIG.setSeparator(getRuta) & Format(Now, "yyMMddhhmm") & "_INF_PAISOS.Pdf", 1, , , , , True)
            Catch e As Exception
                MsgBox(e.Message)
                ERRORS.ERR_PDF_CLOSE("")
            End Try
        Else
            wb.SaveAs(CONFIG.setSeparator(getRuta) & Format(Now, "yyMMddhhmm") & "_INF_PAISOS.xlsx")
        End If
        If isPDf Then wb.Close(False)
        wb = Nothing
        xls = Nothing
    End Sub
    Public Sub infoTipusIva(P As List(Of Object), isPDf As Boolean, filtre As String)
        Dim wb As exc.Workbook, xls As exc.Range, i As Integer, o As TipusIva, avis As frmAvis
        wb = EXCEL.getWorkbook(CONFIG.getPlantillaPais)
        If IsNothing(wb) Then wb = EXCEL.openWorkbook(CONFIG.getRutaPlantillaPais,, True)
        If Not IsNothing(wb) Then
            avis = New frmAvis(IDIOMA.getString("esperaUnMoment"), IDIOMA.getString("imprimintInforme"), IDIOMA.getString("tipusIva"), P.Count)
            wb.Application.Calculation = exc.XlCalculation.xlCalculationManual
            wb.Application.ScreenUpdating = False
            wb.Application.DisplayStatusBar = False
            wb.Application.EnableEvents = False
            wb.Worksheets(1).range("A4:H4525").rows.entirerow.hidden = True
            xls = wb.Worksheets(1).range("A1")
            xls(1, 1) = UCase(IDIOMA.getString("informe")) & " - " & IDIOMA.getString("tipusIva")
            If filtre <> "" Then
                xls = wb.Worksheets(1).range("A2")
                xls(1, 1) = UCase(IDIOMA.getString("filtratPer")) & " (" & filtre & ")"
            End If
            i = 1
            xls = wb.Worksheets(1).range("a4")
            For Each o In P
                avis.setData(o.nom, i)
                xls(i, 1) = o.id
                xls(i, 2) = o.codi
                xls(i, 3) = o.nom
                xls(i, 4) = o.impost
                xls(i, 5) = o.rEquivalencia
                If o.actiu Then
                    xls(i, 6) = IDIOMA.getString("si")
                Else
                    xls(i, 6) = IDIOMA.getString("no")
                End If

                i = i + 1
            Next
            wb.Worksheets(1).range("A4:H" & i + 1).rows.entirerow.hidden = False
            wb.Application.Calculation = exc.XlCalculation.xlCalculationAutomatic
            wb.Application.ScreenUpdating = True
            wb.Application.DisplayStatusBar = True
            wb.Application.EnableEvents = True
            avis.tancar()
        End If
        If isPDf Then
            Call PDF.killProcess()
            Try
                wb.ExportAsFixedFormat(exc.XlFixedFormatType.xlTypePDF, CONFIG.setSeparator(getRuta) & Format(Now, "yyMMddhhmm") & "_INF_TIPUS_IVA.Pdf", 1, , , , , True)
            Catch e As Exception
                MsgBox(e.Message)
                ERRORS.ERR_PDF_CLOSE("")
            End Try
        Else
            wb.SaveAs(CONFIG.setSeparator(getRuta) & Format(Now, "yyMMddhhmm") & "_INF_TIPUS_IVA.xlsx")
        End If
        If isPDf Then wb.Close(False)
        wb = Nothing
        xls = Nothing
    End Sub
    Public Sub infoAuxiliar(P As List(Of Object), isPDf As Boolean, filtre As String)
        Dim wb As exc.Workbook, xls As exc.Range, i As Integer, o As Object, avis As frmAvis
        wb = EXCEL.getWorkbook(CONFIG.getPlantillaAuxiliar)
        If IsNothing(wb) Then wb = EXCEL.openWorkbook(CONFIG.getRutaPlantillaAuxiliar,, True)
        If Not IsNothing(wb) Then
            If P.Count > 0 Then
                avis = New frmAvis(IDIOMA.getString("esperaUnMoment"), IDIOMA.getString("imprimintInforme"), P(0).GetType.Name, P.Count)
                wb.Application.Calculation = exc.XlCalculation.xlCalculationManual
                wb.Application.ScreenUpdating = False
                wb.Application.DisplayStatusBar = False
                wb.Application.EnableEvents = False
                wb.Worksheets(1).range("A4:H4525").rows.entirerow.hidden = True
                xls = wb.Worksheets(1).range("A1")
                xls(1, 1) = IDIOMA.getString("informe") & " " & P(0).GetType.Name
                i = 1
                If filtre <> "" Then
                    xls = wb.Worksheets(1).range("A2")
                    xls(1, 1) = UCase(IDIOMA.getString("filtratPer")) & " (" & filtre & ")"
                End If
                xls = wb.Worksheets(1).range("a4")
                For Each o In P
                    avis.setData(o.nom, i)
                    xls(i, 1) = o.id
                    xls(i, 2) = o.codi
                    xls(i, 3) = o.nom
                    xls(i, 4) = o.notes
                    If o.actiu Then
                        xls(i, 5) = IDIOMA.getString("si")
                    Else
                        xls(i, 5) = IDIOMA.getString("no")
                    End If

                    i = i + 1
                Next
                wb.Worksheets(1).range("A4:H" & i + 1).rows.entirerow.hidden = False
                wb.Application.Calculation = exc.XlCalculation.xlCalculationAutomatic
                wb.Application.ScreenUpdating = True
                wb.Application.DisplayStatusBar = True
                wb.Application.EnableEvents = True
                avis.tancar()
                If isPDf Then
                    Call PDF.killProcess()
                    Try
                        wb.ExportAsFixedFormat(exc.XlFixedFormatType.xlTypePDF, CONFIG.setSeparator(getRuta) & Format(Now, "yyMMddhhmm") & "_INF_" & P(0).GetType.Name & ".Pdf", 1, , , , , True)
                    Catch e As Exception
                        MsgBox(e.Message)
                        ERRORS.ERR_PDF_CLOSE("")
                    End Try

                Else
                    wb.SaveAs(CONFIG.setSeparator(getRuta) & Format(Now, "yyMMddhhmm") & "_INF_" & P(0).GetType.Name & " .xlsx")
                End If
            End If
        End If
        If isPDf Then wb.Close(False)
        wb = Nothing
        xls = Nothing
    End Sub
    Public Function infoComandes(comandes As List(Of List(Of String)), isPDf As Boolean, titol As String, filtre As String) As String
        Dim wb As exc.Workbook, xls As exc.Range, i As Integer, r As List(Of String), s As String, j As Integer, f As frmAvis
        Dim ruta As String = getRuta(), ruta2 As String = ""
        wb = EXCEL.getWorkbook(CONFIG.getPlantillaComandes)
        If IsNothing(wb) Then wb = EXCEL.openWorkbook(CONFIG.getRutaPlantillaComandes,, True)
        If Not IsNothing(wb) Then
            wb.Application.Calculation = exc.XlCalculation.xlCalculationManual
            f = New frmAvis(IDIOMA.getString("esperaUnMoment"), IDIOMA.getString("imprimintInforme"), "")
            i = 1
            xls = wb.Worksheets(1).range("a7")
            wb.Worksheets(1).range("E1") = titol
            wb.Worksheets(1).range("c2") = filtre
            For Each r In comandes
                j = 1
                For Each s In r
                    'If IsDate(s) Then
                    '    xls(i, j) = CDate(s)
                    'Else
                    If j = 6 Or j = 15 Then 'DATA
                        If IsDate(s) Then xls(i, j) = CDate(s)
                    ElseIf j = 10 Or j = 11 Or j = 12 Then 'BASE, IVA I TOTAL
                        If IsNumeric(s) Then xls(i, j) = CDbl(s)
                    Else
                        xls(i, j) = s
                    End If

                    'End If
                    j = j + 1
                Next
                i = i + 1
            Next
            wb.Application.Calculation = exc.XlCalculation.xlCalculationAutomatic

            If isPDf Then
                Call PDF.killProcess()
                Try
                    If CONFIG.folderExist(ruta) Then
                        ruta2 = ruta & Format(Now, "yyMMddhhmm") & "_INF_COMANDES.Pdf"
                        wb.ExportAsFixedFormat(exc.XlFixedFormatType.xlTypePDF, ruta2, 1, , , , , True)
                    End If
                Catch e As Exception
                    MsgBox(e.Message)
                    ERRORS.ERR_PDF_CLOSE(ruta2)
                End Try
                wb.Close(False)
            Else
                i = 1
                Do
                    ruta2 = ruta & Format(Now, "yyMMddhhmm") & "_INF_COMANDES-" & i & ".xlsx"
                    i = i + 1
                Loop While CONFIG.fileExist(ruta2)
                wb.SaveAs(ruta2)
            End If
            f.tancar()

        End If
        wb = Nothing
        xls = Nothing
        Return ruta2
    End Function
    Public Function infoComandesEnValidacio(comandes As List(Of List(Of String)), isPDf As Boolean, titol As String, filtre As String) As String
        Dim wb As exc.Workbook, xls As exc.Range, i As Integer, r As List(Of String), s As String, j As Integer, f As frmAvis
        Dim ruta As String = getRuta(), ruta2 As String = "", xlsComment As exc.Comment, xlsRange As exc.Range

        wb = EXCEL.getWorkbook(CONFIG.getPlantillaComandesEnEdicio)

        If IsNothing(wb) Then wb = EXCEL.openWorkbook(CONFIG.getRutaPlantillaComandesEnEdicio,, True)
        If Not IsNothing(wb) Then
            wb.Application.Visible = False
            wb.Application.Calculation = exc.XlCalculation.xlCalculationManual
            f = New frmAvis(IDIOMA.getString("esperaUnMoment"), IDIOMA.getString("imprimintInforme"), comandes.Count)
            i = 1
            xls = wb.Worksheets(1).range("a7")
            wb.Worksheets(1).range("E1") = titol
            wb.Worksheets(1).range("c2") = filtre
            For Each r In comandes
                j = 1

                For Each s In r
                    If j = 4 Or j = 13 Then 'DATA
                        If IsDate(s) Then xls(i, j) = CDate(s)
                    ElseIf j = 8 Or j = 9 Then 'BASE, IVA I TOTAL
                        If IsNumeric(s) Then xls(i, j) = CDbl(s)
                    Else
                        xls(i, j) = s
                    End If
                    If j = 7 Then
                        f.setData(s, i)
                        xls(i, j).ClearComments
                        xlsComment = xls(i, j).AddComment(ModelArticleComandaEnEdicio.getStringArticles(Val(r(0))))

                        xlsComment.Shape.ScaleHeight(0.2 * ModelArticleComandaEnEdicio.getnumArticles(Val(r(0))), Microsoft.Office.Core.MsoTriState.msoFalse)
                        xlsComment.Shape.ScaleWidth(4, Microsoft.Office.Core.MsoTriState.msoFalse)
                        'xlsComment.Text(ModelArticleComandaEnEdicio.getStringArticles(Val(r(0))))
                    End If
                    j = j + 1
                Next
                i = i + 1
            Next
            wb.Application.Calculation = exc.XlCalculation.xlCalculationAutomatic
            wb.Application.Visible = True
            If isPDf Then
                Call PDF.killProcess()
                Try
                    If CONFIG.folderExist(ruta) Then
                        ruta2 = ruta & Format(Now, "yyMMddhhmm") & "_INF_COMANDES.Pdf"
                        wb.ExportAsFixedFormat(exc.XlFixedFormatType.xlTypePDF, ruta2, 1, , , , , True)
                    End If
                Catch e As Exception
                    MsgBox(e.Message)
                    ERRORS.ERR_PDF_CLOSE(ruta2)
                End Try
                wb.Close(False)
            Else
                i = 1
                Do
                    ruta2 = ruta & Format(Now, "yyMMddhhmm") & "_INF_COMANDES-" & i & ".xlsx"
                    i = i + 1
                Loop While CONFIG.fileExist(ruta2)
                wb.SaveAs(ruta2)
            End If
            f.tancar()

        End If
        wb = Nothing
        xls = Nothing
        Return ruta2
    End Function
    Private Function getRuta() As String
        Dim p As String
        p = CONFIG_FILE.getTag(CONFIG_FILE.TAG.RUTA_IMPRESSIO_INFORMES)
        If Not CONFIG.folderExist(p) Then p = CONFIG.getDirectoriPredeterminatInformes
        Return p
    End Function
End Module
