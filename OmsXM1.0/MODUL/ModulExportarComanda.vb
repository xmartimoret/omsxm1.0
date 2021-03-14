Option Explicit On
Imports exc = Microsoft.Office.Interop.Excel
Module ModulExportarComanda
    Public Sub execute(c As Comanda)
        Dim wb As exc.Workbook, xls As exc.Range, i As Integer, ws As exc.Worksheet, a As articleComanda
        'Dim apliMacro As exc.Application
        wb = EXCEL.getWorkbook("plantillaComanda.xls")
        'apliMacro = EXCEL.getMacros()
        If IsNothing(wb) Then wb = EXCEL.openWorkbook(CONFIG.getRutaPlantillaComanda)
        If Not IsNothing(wb) Then
            ws = wb.Worksheets("f1")
            xls = ws.Range("_proveidor")
            xls(1, 1) = c.proveidor.ToString
            xls(3, 1) = "   " & c.proveidor.direccio & vbCrLf & "   " & c.proveidor.codiPostal & "-" & c.proveidor.poblacio & vbCrLf _
            & "   " & c.proveidor.provincia.ToString & vbCrLf & "    " & c.contacteProveidor.toString
            xls = ws.Range("_data")
            xls(1, 1) = c.data
            xls = ws.Range("_numero_comanda")
            xls(1, 1) = c.ToStringCodi
            xls = ws.Range("_projecte") : xls(1, 1) = c.projecte.ToString
            xls = ws.Range("_ports") : xls(1, 1) = c.ports
            xls = ws.Range("_magatzem")
            xls(1, 1) = c.magatzem.direccio & vbCrLf & c.magatzem.codiPostal & "-" & c.magatzem.poblacio & vbCrLf & c.magatzem.provincia.ToString
            xls = ws.Range("_CONTACTE") : xls(1, 1) = c.contacte.tostring

            i = 1
            For Each a In c.articles
                xls = ws.Range("_quantitat") : xls(a.pos + 1, 1) = a.quantitat
                xls = ws.Range("_UNITAT") : xls(a.pos + 1, 1) = a.unitat.toString
                xls = ws.Range("_DESCRIPCIO") : xls(a.pos + 1, 1) = a.nom
                xls = ws.Range("_PREU") : xls(a.pos + 1, 1) = a.preu
                xls = ws.Range("_DESCOMPTE") : xls(a.pos + 1, 1) = a.tpcDescompte & "%"
                xls = ws.Range("_TOTAL") : xls(a.pos + 1, 1) = a.base
            Next
            xls = ws.Range("_data_entrega") : xls(1, 1) = c.dataEntrega
            xls = ws.Range("_data_muntatge") : xls(1, 1) = c.dataMuntatge
            xls = ws.Range("_BASE_IMPONIBLE") : xls(1, 1) = c.base
            xls = ws.Range("_TOTAL_IVA") : xls(1, 1) = c.iva
            xls = ws.Range("_TOTAL_COMANDA") : xls(1, 1) = c.total
            xls = ws.Range("_RESPONSABLE_COMPRA") : xls(1, 1) = c.responsable
            xls = ws.Range("_DIRECTOR_COMPRES") : xls(1, 1) = c.director
            xls = ws.Range("_TIPUS_PAGAMENT") : xls(1, 1) = "Forma de pago" & vbCrLf & c.tipusPagament.ToString
            xls = ws.Range("_DADES_BANCARIES") : xls(1, 1) = "Datos Bancarios" & vbCrLf & c.dadesBancaries
            Call PDF.killProcess()
            Try
                ws.ExportAsFixedFormat(exc.XlFixedFormatType.xlTypePDF, CONFIG.getDirectoriPDFComandes & c.ToStringCodi, 1, , , , , True)
            Catch
                ERRORS.ERR_PDF_CLOSE(c.ToStringCodi)
            End Try


        End If
        wb.Close(False)
        ' apliMacro.Run("crearComanda", CONFIG.getDirectoriPDFComandes & c.ToStringCodi & ".xlsx", CONFIG.getDirectoriPDFComandes & c.ToStringCodi & ".pdf")
        ' Call EXCEL.closeMacros(apliMacro)

        wb = Nothing
        xls = Nothing
        ws = Nothing
        ' apliMacro = Nothing
    End Sub

End Module
