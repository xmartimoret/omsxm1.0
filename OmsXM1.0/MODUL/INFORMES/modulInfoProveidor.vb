Option Explicit On
Imports exc = Microsoft.Office.Interop.Excel
Module modulInfoProveidor
    Private Enum pos
        ID = 1
        CIF
        CODI_COMPTABLE
        NOM_FISCAL
        NOM_COMERCIAL
        DIRECCIO
        CODI_POSTAL
        POBLACIO
        PROVINCIA
        PAIS
        TIPUS_PAGAMENT
        IBAN
        EMAIL
        DATA_ALTA
        DATA_BAIXA
        ACTIU
    End Enum
    Private Enum posCont
        ID = 2
        DEPARTA
        CONTACTE
        DIRECCIO
        POBLACIO
        CP
        PROVIVINCIA
        PAIS
        TEL1
        TEL2
        EMAIL
        NOTES
        ACTIU
    End Enum

    Public Sub execute(P As List(Of Proveidor), isPDf As Boolean, filtre As String)
        Dim wb As exc.Workbook, xls As exc.Range, i As Integer, o As Proveidor, c As ProveidorCont, j As Integer, avis As frmAvis
        wb = EXCEL.getWorkbook(CONFIG.getPlantillaProveidors)
        If IsNothing(wb) Then wb = EXCEL.openWorkbook(CONFIG.getRutaPlantillaProveidors,, True)
        If Not IsNothing(wb) Then
            avis = New frmAvis(IDIOMA.getString("esperaUnMoment"), IDIOMA.getString("imprimintInforme"), IDIOMA.getString("proveidor"), P.Count)
            wb.Application.Calculation = exc.XlCalculation.xlCalculationManual
            wb.Application.ScreenUpdating = False
            wb.Application.DisplayStatusBar = False
            wb.Application.EnableEvents = False
            wb.Worksheets(1).range("A4:P4525").rows.entirerow.hidden = True
            i = 1
            xls = wb.Worksheets(1).range("A1")
            xls(1, 1) = UCase(IDIOMA.getString("informe")) & " - " & IDIOMA.getString("proveidor")
            If filtre <> "" Then
                xls = wb.Worksheets(1).range("A2")
                xls(1, 1) = UCase(IDIOMA.getString("filtratPer")) & " (" & filtre & ")"
            End If
            xls = wb.Worksheets(1).range("a4")
                For Each o In P
                    avis.setData(o.nom, i)
                    xls(i, pos.ID) = o.id
                    xls(i, pos.CIF) = o.codi
                    xls(i, pos.NOM_FISCAL) = o.nomFiscal
                    xls(i, pos.NOM_COMERCIAL) = o.nom
                    If o.actiu Then
                        xls(i, pos.ACTIU) = IDIOMA.getString("si")
                    Else
                        xls(i, pos.ACTIU) = IDIOMA.getString("no")
                    End If
                    xls(i, pos.CODI_COMPTABLE) = o.codiComptable
                    xls(i, pos.CODI_POSTAL) = o.codiPostal
                    xls(i, pos.DATA_ALTA) = o.dataAlta
                    xls(i, pos.DATA_BAIXA) = o.dataBaixa
                    xls(i, pos.DIRECCIO) = o.direccio
                    xls(i, pos.CODI_POSTAL) = o.codiPostal
                    xls(i, pos.POBLACIO) = o.poblacio
                    xls(i, pos.EMAIL) = o.email
                    xls(i, pos.IBAN) = o.iban1
                    xls(i, pos.PAIS) = o.pais.nom
                    xls(i, pos.PROVINCIA) = o.provincia.nom
                    xls(i, pos.TIPUS_PAGAMENT) = o.tipusPagament.nom
                    i = i + 1

            Next
                wb.Worksheets(1).range("A2:P" & i + 1).rows.entirerow.hidden = False
                wb.Application.Calculation = exc.XlCalculation.xlCalculationAutomatic
                wb.Application.ScreenUpdating = True
                wb.Application.DisplayStatusBar = True
                wb.Application.EnableEvents = True
                avis.tancar()
            End If

            If isPDf Then
            Call PDF.killProcess()
            Try
                wb.ExportAsFixedFormat(exc.XlFixedFormatType.xlTypePDF, CONFIG.setSeparator(getRuta) & Format(Now, "yyMMddhhmm") & "_INF_PROVEIDOR.Pdf", 1, , , , , True)
            Catch e As Exception
                MsgBox(e.Message)
                ERRORS.ERR_PDF_CLOSE("")
            End Try
        Else
            wb.SaveAs(CONFIG.setSeparator(getRuta) & Format(Now, "yyMMddhhmm") & "_INF_PROVEIDOR.xlsx")
        End If
        If isPDf Then wb.Close(False)
        wb = Nothing
        xls = Nothing
    End Sub
    Public Sub execute(p As Proveidor, isPDf As Boolean)
        Dim wb As exc.Workbook, xls As exc.Range, i As Integer, c As ProveidorCont, j As Integer
        Dim rangC(10, 1) As String, avis As frmAvis

        wb = EXCEL.getWorkbook(CONFIG.getPlantillaProveidor)
        If IsNothing(wb) Then wb = EXCEL.openWorkbook(CONFIG.getRutaPlantillaProveidor,, True)
        If Not IsNothing(wb) Then
            avis = New frmAvis(IDIOMA.getString("esperaUnMoment"), IDIOMA.getString("imprimintInforme"), IDIOMA.getString("proveidor"))
            wb.Application.Calculation = exc.XlCalculation.xlCalculationManual
            wb.Application.ScreenUpdating = False
            wb.Application.DisplayStatusBar = False
            wb.Application.EnableEvents = False

            xls = wb.Worksheets(1).range("_id") : xls(1, 1) = p.id
            xls = wb.Worksheets(1).range("_CODI_COMPTABLE") : xls(1, 1) = p.codiComptable
            xls = wb.Worksheets(1).range("_NIF") : xls(1, 1) = p.codi
            xls = wb.Worksheets(1).range("_NOM_FISCAL") : xls(1, 1) = p.nomFiscal
            xls = wb.Worksheets(1).range("_NOM_COMERCIAL") : xls(1, 1) = p.nom
            xls = wb.Worksheets(1).range("_DIRECCIO") : xls(1, 1) = p.direccio
            xls = wb.Worksheets(1).range("_POBLACIO") : xls(1, 1) = p.poblacio
            xls = wb.Worksheets(1).range("_CP") : xls(1, 1) = p.codiPostal
            xls = wb.Worksheets(1).range("_PROVINCIA") : xls(1, 1) = p.provincia.nom
            xls = wb.Worksheets(1).range("_PAIS") : xls(1, 1) = p.pais.nom
            xls = wb.Worksheets(1).range("_TIPUS_PAGAMENT") : xls(1, 1) = p.tipusPagament.ToString
            xls = wb.Worksheets(1).range("_IBAN") : xls(1, 1) = p.iban1
            xls = wb.Worksheets(1).range("_EMAIL") : xls(1, 1) = p.email
            xls = wb.Worksheets(1).range("_DATA_ALTA") : xls(1, 1) = p.dataAlta
            xls = wb.Worksheets(1).range("_DATA_BAIXA") : xls(1, 1) = p.dataBaixa
            If p.actiu Then
                xls = wb.Worksheets(1).range("_ESTAT") : xls(1, 1) = IDIOMA.getString("actiu")
            Else
                xls = wb.Worksheets(1).range("_ESTAT") : xls(1, 1) = IDIOMA.getString("noActiu")
            End If

            rangC(1, 0) = "_IDC1"
            rangC(2, 0) = "_IDC2"
            rangC(3, 0) = "_IDC3"
            rangC(4, 0) = "_IDC4"
            rangC(5, 0) = "_IDC5"
            rangC(6, 0) = "_IDC6"
            rangC(7, 0) = "_IDC7"
            rangC(8, 0) = "_IDC8"
            rangC(9, 0) = "_IDC9"
            rangC(10, 0) = "_IDC10"
            rangC(1, 1) = "A14:G21"
            rangC(2, 1) = "A22:G29"
            rangC(3, 1) = "A30:G37"
            rangC(4, 1) = "A38:G45"
            rangC(5, 1) = "A46:G53"
            rangC(6, 1) = "A54:G61"
            rangC(7, 1) = "A62:G69"
            rangC(8, 1) = "A70:G77"
            rangC(9, 1) = "A78:G85"
            rangC(10, 1) = "A86:G93"
            For i = 1 To 10
                wb.Worksheets(1).range(rangC(i, 1)).rows.entirerow.hidden = True
            Next
            i = 1
            For Each c In p.contactes
                wb.Worksheets(1).range(rangC(i, 1)).rows.entirerow.hidden = False
                xls = wb.Worksheets(1).range(rangC(i, 0))
                xls(1, 1) = c.id
                xls(1, 2) = c.departament
                xls(1, 4) = c.nom
                xls(2, 3) = c.direccio
                xls(3, 3) = c.poblacio
                xls(3, 7) = c.codiPostal
                xls(4, 3) = c.provincia.ToString
                xls(4, 6) = c.pais.ToString
                xls(5, 3) = c.telefon1
                xls(5, 4) = c.telefon2
                If c.actiu Then
                    xls(5, 7) = IDIOMA.getString("actiu")
                Else
                    xls(5, 7) = IDIOMA.getString("noActiu")
                End If
                xls(6, 3) = c.email
                i = i + 1
            Next
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
