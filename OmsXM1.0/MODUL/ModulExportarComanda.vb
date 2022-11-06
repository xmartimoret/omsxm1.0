'Option Explicit On
'Imports exc = Microsoft.Office.Interop.Excel
'Imports ClosedXML.Excel
'Module ModulExportarComanda
'    Public Function execute(c As Comanda, isPDF As Boolean, rutaFitxer As String, Optional setVisible As Boolean = True) As String
'        Dim wb As IXLWorkbook, xls As IXLRange, i As Integer, ws As IXLWorksheet, a As articleComanda, j As Integer, ruta2 As String = ""
'        Dim temp As String, files As Integer, descripcio As String, wbExc As exc.Workbook
'        'Dim apliMacro As exc.Application

'        wb = New XLWorkbook(CONFIG.getRutaPlantillaComanda(c.empresa.id))
'        'wb = EXCEL.getWorkbook(getPlantillaEmpresa(c.empresa.id))

'        'If IsNothing(wb) Then wb = EXCEL.openWorkbook(CONFIG.getRutaPlantillaComanda(c.empresa.id),, True)
'        If Not IsNothing(wb) Then
'            files = c.getMaxFilesArticles
'            j = 1
'            'COMPTE PAGINES
'            ws = wb.Worksheet("f1")
'            ws.Range("_DADES").Clear(XLClearOptions.AllContents)
'            If Not IsNothing(c.proveidor) Then
'                xls = ws.Range("_PROVEIDOR")
'                xls.Cell(1, 1).Value = c.proveidor.ToString
'                xls = ws.Range("_CONTACTE_PROVEIDOR")
'                xls.Cell(1, 1).Value = getStringProveidor(c)
'                If Not IsNothing(c.contacteProveidor) Then
'                    temp = "   " & c.contacteProveidor.toString & vbCrLf
'                    If c.contacteProveidor.telefon1 <> "" Then
'                        temp = temp & c.contacteProveidor.telefon1
'                    End If
'                    If c.contacteProveidor.email <> "" Then
'                        temp = temp & "-" & c.contacteProveidor.email
'                    End If
'                End If

'                xls.Cell(6, 1).Value = temp
'            End If
'            If Year(c.data) > 1999 Then
'                xls = ws.Range("_DATA")
'                xls.Cell(1, 1).Value = c.data
'            End If

'            xls = ws.Range("_NUM_COMANDA")
'            xls.Cell(1, 1).Value = c.getCodi
'            xls = ws.Range("_projecte") : xls.Cell(1, 1).Value = c.projecte.ToString
'            xls = ws.Range("_ports") : xls.Cell(1, 1).Value = c.ports
'            xls = ws.Range("_magatzem")
'            xls.Cell(1, 1).Value = getStringMagatzem(c)
'            If c.contacte IsNot Nothing Then xls = ws.Range("_CONTACTE") : xls.Cell(1, 1).Value = c.contacte.tostring & " (" & c.contacte.toTarget & ")"
'            If Year(c.dataEntrega) > 1999 Then
'                xls = ws.Range("_data_entrega") : xls.Cell(1, 1).Value = c.dataEntrega
'            Else
'                xls = ws.Range("_data_entrega") : xls.Cell(1, 1).Value = ""
'            End If
'            If Year(c.dataMuntatge) > 1999 Then
'                xls = ws.Range("_data_muntatge") : xls.Cell(1, 1).Value = c.dataMuntatge
'            Else
'                xls = ws.Range("_data_muntatge") : xls.Cell(1, 1).Value = ""
'            End If
'            xls = ws.Range("_BASE0") : xls.Cell(1, 1).Value = c.base(0)
'            xls = ws.Range("_BASE4") : xls.Cell(1, 1).Value = c.base(4)
'            xls = ws.Range("_BASE10") : xls.Cell(1, 1).Value = c.base(10)
'            xls = ws.Range("_BASE21") : xls.Cell(1, 1).Value = c.base(21)
'            xls = ws.Range("_TIPUS_PAGAMENT") : xls.Cell(1, 1).Value = c.tipusPagament.ToString
'            xls = ws.Range("_iban") : xls.Cell(1, 1).Value = c.dadesBancaries
'            xls = ws.Range("_oferta") : xls.Cell(1, 1).Value = c.nOferta
'            xls = ws.Range("_FACTURACIO1") : xls.Cell(1, 1).Value = c.inici & " %" : xls.Cell(1, 3).Value = IDIOMA.getString("alIniciComanda")
'            xls = ws.Range("_FACTURACIO2") : xls.Cell(1, 1).Value = c.entregaEquips & " %" : xls.Cell(1, 3).Value = IDIOMA.getString("iniciTreballs")
'            xls = ws.Range("_FACTURACIO3") : xls.Cell(1, 1).Value = c.entrega & " %" : xls.Cell(1, 3).Value = IDIOMA.getString("entregaComanda")
'            i = 1
'            xls = ws.Range("_DADES")
'            For Each a In c.articles
'                i = c.getReportFile(a)
'                xls.Cell(i, 1).Value = a.quantitat
'                xls.Cell(i, 3).Value = a.unitat.toString

'                If a.codi = "" Then
'                    descripcio = "     " & a.nom
'                Else
'                    descripcio = "  " & a.codi & " - " & a.nom
'                End If
'                If descripcio.Length > 120 Then
'                    'xls.Cell(i, 4).Rows.RowHeight = 30
'                    xls.Cell(i, 4).WorksheetRow.Height = 30
'                End If


'                xls.Cell(i, 4).Value = descripcio
'                xls.Cell(i, 12).Value = a.preu
'                xls.Cell(i, 15).Value = a.tpcDescompte & "%"
'                xls.Cell(i, 16).Value = a.base
'            Next

'            ws.Rows(c.getReportFiles + 15 & ":564").Delete()

'            'ws.Range("b" & c.getReportFiles + 15 & ":b564").Delete(XLShiftDeletedCells.ShiftCellsUp)
'            ws.PageSetup.SetPagesTall(1)
'            ws.PageSetup.SetPagesWide(1)
'            ws.Range("a1").Select()

'            If c.getReportFiles > 50 Then
'                For i = 50 To c.getReportFiles - 50 Step 50
'                    ws.PageSetup.AddHorizontalPageBreak(15 + i)
'                Next
'                For i = 50 To c.getReportFiles Step 50
'                    'With ws.Range("b" & 15 + i & ":" & "r" & 15 + i).Borders(exc.XlBordersIndex.xlEdgeTop)
'                    With ws.Range("b" & 15 + i & ":" & "r" & 15 + i).Style.Border
'                        .TopBorder = XLBorderStyleValues.Thin
'                        .TopBorderColor = XLColor.Black
'                    End With
'                Next

'            End If

'            '  ActiveWindow.SelectedSheets.HPageBreaks.Add Before:=ActiveCell
'            If isPDF Then
'                Call PDF.killProcess()
'                Try
'                    wb.Save(rutaFitxer)
'                    wbExc = EXCEL.openWorkbook(rutaFitxer,, False)
'                    wbExc.ExportAsFixedFormat(exc.XlFixedFormatType.xlTypePDF, rutaFitxer, 1, , , , , setVisible)
'                    wbExc.Close(False)
'                    ruta2 = getRutaEmpresaComandesPDF(c.empresa.nom)
'                    If CONFIG.folderExist(ruta2) Then
'                        ruta2 = CONFIG.setSeparator(ruta2) & c.getCodi & " " & Strings.Left(c.proveidor.nom, 10) & ".xls"
'                        wb.Save(ruta2)
'                        wbExc = EXCEL.openWorkbook(rutaFitxer,, False)
'                        wbExc.ExportAsFixedFormat(exc.XlFixedFormatType.xlTypePDF, ruta2, 1, , , , , setVisible)
'                        wbExc.Close(False)
'                    End If
'                Catch e As Exception
'                    MsgBox(e.Message)
'                    ERRORS.ERR_PDF_CLOSE(c.getCodi)
'                End Try
'            Else
'                i = 1
'                Do
'                    ruta2 = CONFIG.setFolder(CONFIG.getDirectoriPredeterminatInformes) & c.getCodi & " " & Strings.Left(c.proveidor.nom, 10) & "-" & i & ".xlsx"
'                    i = i + 1
'                Loop While CONFIG.fileExist(ruta2)
'                wb.SaveAs(ruta2)
'                wbExc = EXCEL.openWorkbook(ruta2,, True)
'            End If
'        End If
'        'If isPDF Then wb.close 
'        wb = Nothing
'        xls = Nothing
'        ws = Nothing
'        wbExc = Nothing
'        Return ruta2
'    End Function

'    Private Function getStringMagatzem(c As Comanda) As String
'        If c.magatzem Is Nothing Then Return ""
'        If c.magatzem.provincia Is Nothing Then
'            Return c.magatzem.toString & vbCrLf & c.magatzem.direccio & vbCrLf & c.magatzem.codiPostal & "-" & c.magatzem.poblacio
'        Else
'            Return c.magatzem.toString & vbCrLf & c.magatzem.direccio & vbCrLf & c.magatzem.codiPostal & "-" & c.magatzem.poblacio & vbCrLf & c.magatzem.provincia.ToString
'        End If
'    End Function
'    Private Function getStringProveidor(c As Comanda) As String
'        Dim temp As String = ""
'        If c.proveidor Is Nothing Then Return ""
'        temp = c.proveidor.direccio & vbCrLf & "   " & c.proveidor.codiPostal & " " & c.proveidor.poblacio & vbCrLf & "   "
'        If c.proveidor.provincia Is Nothing Then
'            temp = temp & c.proveidor.provincia.ToString & " " & c.proveidor.pais.ToString
'        End If
'        Return temp
'    End Function
'    Private Sub resetPagesSetup(ws As IXLWorksheet)
'        Dim i As Integer, j As Integer
'        ws.PageSetup.PrintAreas.Add("$B$15:$R$594")
'        'With ws.PageSetup
'        '    .FitToPagesWide = 1
'        '    .FitToPagesTall = False
'        'End With
'    End Sub
'    Private Function getPlantillaEmpresa(id As Integer) As String
'        If id < 10 Then Return "0" & id & "-Comanda.xlsx"
'        Return id & "-Comanda.xlsx"
'    End Function

'End Module
' copia de seguretat 03/07/2022
Option Explicit On
Imports exc = Microsoft.Office.Interop.Excel

Module ModulExportarComanda
    Public Function execute(c As Comanda, isPDF As Boolean, rutaFitxer As String, Optional setVisible As Boolean = True) As String
        Dim wb As exc.Workbook, xls As exc.Range, i As Integer, ws As exc.Worksheet, a As articleComanda, j As Integer, ruta2 As String = ""
        Dim temp As String, files As Integer, k As Integer, descripcio As String
        'Dim apliMacro As exc.Application
        wb = EXCEL.getWorkbook(getPlantillaEmpresa(c.empresa.id))

        If IsNothing(wb) Then wb = EXCEL.openWorkbook(CONFIG.getRutaPlantillaComanda(c.empresa.id),, True)
        If Not IsNothing(wb) Then
            files = c.getMaxFilesArticles
            j = 1
            'COMPTE PAGINES
            ws = wb.Worksheets("f1")
            ' ws.Range("_DADES").EntireRow.Hidden = True

            ws.Range("_DADES").ClearContents()
            If Not IsNothing(c.proveidor) Then
                xls = ws.Range("_PROVEIDOR")
                xls(1, 1) = c.proveidor.ToString
                xls = ws.Range("_CONTACTE_PROVEIDOR")
                xls(1, 1) = getStringProveidor(c)
                If Not IsNothing(c.contacteProveidor) Then
                    temp = "   " & c.contacteProveidor.toString & vbCrLf

                    If c.contacteProveidor.telefon1 <> "" Then
                        temp = temp & c.contacteProveidor.telefon1
                    End If
                    If c.contacteProveidor.email <> "" Then
                        temp = temp & "-" & c.contacteProveidor.email
                    End If
                End If

                xls(6, 1) = temp
            End If
            If Year(c.data) > 1999 Then
                xls = ws.Range("_DATA")
                xls(1, 1) = c.data
            End If

            xls = ws.Range("_NUM_COMANDA")
            xls(1, 1) = c.getCodi
            xls = ws.Range("_projecte") : xls(1, 1) = c.projecte.ToString
            xls = ws.Range("_ports") : xls(1, 1) = c.ports
            xls = ws.Range("_magatzem")
            xls(1, 1) = getStringMagatzem(c)
            If c.contacte IsNot Nothing Then xls = ws.Range("_CONTACTE") : xls(1, 1) = c.contacte.tostring & " (" & c.contacte.toTarget & ")"
            If Year(c.dataEntrega) > 1999 Then
                xls = ws.Range("_data_entrega") : xls(1, 1) = c.dataEntrega
            Else
                xls = ws.Range("_data_entrega") : xls(1, 1) = ""
            End If
            If Year(c.dataMuntatge) > 1999 Then
                xls = ws.Range("_data_muntatge") : xls(1, 1) = c.dataMuntatge
            Else
                xls = ws.Range("_data_muntatge") : xls(1, 1) = ""
            End If
            xls = ws.Range("_BASE0") : xls(1, 1) = c.base(0)
            xls = ws.Range("_BASE4") : xls(1, 1) = c.base(4)
            xls = ws.Range("_BASE10") : xls(1, 1) = c.base(10)
            xls = ws.Range("_BASE21") : xls(1, 1) = c.base(21)
            xls = ws.Range("_TIPUS_PAGAMENT") : xls(1, 1) = c.tipusPagament.ToString
            xls = ws.Range("_iban") : xls(1, 1) = c.dadesBancaries
            xls = ws.Range("_oferta") : xls(1, 1) = c.nOferta
            xls = ws.Range("_FACTURACIO1") : xls(1, 1) = c.inici & " %" : xls(1, 3) = IDIOMA.getString("alIniciComanda")
            xls = ws.Range("_FACTURACIO2") : xls(1, 1) = c.entregaEquips & " %" : xls(1, 3) = IDIOMA.getString("iniciTreballs")
            xls = ws.Range("_FACTURACIO3") : xls(1, 1) = c.entrega & " %" : xls(1, 3) = IDIOMA.getString("entregaComanda")
            i = 1
            xls = ws.Range("_DADES")
            For Each a In c.articles
                i = c.getReportFile(a)
                xls(i, 1) = a.quantitat
                xls(i, 3) = a.unitat.toString

                If a.codi = "" Then
                    descripcio = "     " & a.nom
                Else
                    descripcio = "  " & a.codi & " - " & a.nom
                End If
                If descripcio.Length > 120 Then
                    xls(i, 4).Rows.RowHeight = 30
                End If
                xls(i, 4) = descripcio
                xls(i, 12) = a.preu
                xls(i, 15) = a.tpcDescompte & "%"
                xls(i, 16) = a.base
            Next
            '  ws.Range("b15:b" & c.getReportFiles + 15).EntireRow.Hidden = False
            ws.Range("b" & c.getReportFiles + 15 & ":b564").EntireRow.Delete()

            ' paginacio 
            'For i = 1 To ws.HPageBreaks.Count
            '    ws.HPageBreaks(i).Delete()
            'Next
            If c.getReportFiles > 50 Then
                For i = 50 To c.getReportFiles - 50 Step 50
                    ws.HPageBreaks.Add(ws.Range("b" & 15 + i))
                Next
                For i = 50 To c.getReportFiles Step 50
                    With ws.Range("b" & 15 + i & ":" & "r" & 15 + i).Borders(exc.XlBordersIndex.xlEdgeTop)
                        .LineStyle = exc.XlLineStyle.xlContinuous
                        .Weight = exc.XlBorderWeight.xlThin
                        .ColorIndex = 0
                        .TintAndShade = 0
                    End With
                Next

            End If

            '  ActiveWindow.SelectedSheets.HPageBreaks.Add Before:=ActiveCell
            If isPDF Then
                Call PDF.killProcess()
                Try
                    wb.ExportAsFixedFormat(exc.XlFixedFormatType.xlTypePDF, rutaFitxer, 1, , , , , setVisible)
                    ruta2 = getRutaEmpresaComandesPDF(c.empresa.nom)
                    If CONFIG.folderExist(ruta2) Then
                        ruta2 = CONFIG.setSeparator(ruta2) & c.getCodi & " " & Strings.Left(c.proveidor.nom, 10) & ".pdf"
                        wb.ExportAsFixedFormat(exc.XlFixedFormatType.xlTypePDF, ruta2, 1, , , , , setVisible)
                    End If

                Catch e As Exception
                    MsgBox(e.Message)
                    ERRORS.ERR_PDF_CLOSE(c.getCodi)
                End Try
            Else
                i = 1
                Do
                    ruta2 = CONFIG.setFolder(CONFIG.getDirectoriPredeterminatInformes) & c.getCodi & " " & Strings.Left(c.proveidor.nom, 10) & "-" & i & ".xlsx"
                    i = i + 1
                Loop While CONFIG.fileExist(ruta2)
                wb.SaveAs(ruta2)
            End If
        End If
        If isPDF Then wb.Close(False)
        wb = Nothing
        xls = Nothing
        ws = Nothing
        Return ruta2
    End Function

    Private Function getStringMagatzem(c As Comanda) As String
        If c.magatzem Is Nothing Then Return ""
        If c.magatzem.provincia Is Nothing Then
            Return c.magatzem.toString & vbCrLf & c.magatzem.direccio & vbCrLf & c.magatzem.codiPostal & "-" & c.magatzem.poblacio
        Else
            Return c.magatzem.toString & vbCrLf & c.magatzem.direccio & vbCrLf & c.magatzem.codiPostal & "-" & c.magatzem.poblacio & vbCrLf & c.magatzem.provincia.ToString
        End If
    End Function
    Private Function getStringProveidor(c As Comanda) As String
        Dim temp As String = ""
        If c.proveidor Is Nothing Then Return ""
        temp = c.proveidor.direccio & vbCrLf & "   " & c.proveidor.codiPostal & " " & c.proveidor.poblacio & vbCrLf & "   "
        If c.proveidor.provincia Is Nothing Then
            temp = temp & c.proveidor.provincia.ToString & " " & c.proveidor.pais.ToString
        End If
        Return temp
    End Function
    Private Sub resetPagesSetup(ws As exc.Worksheet)
        Dim i As Integer, j As Integer
        ws.PageSetup.PrintArea = "$B$15:$R$594"
        With ws.PageSetup
            .FitToPagesWide = 1
            .FitToPagesTall = False
        End With
    End Sub
    Private Function getPlantillaEmpresa(id As Integer) As String
        If id < 10 Then Return "0" & id & "-Comanda.xlsx"
        Return id & "-Comanda.xlsx"
    End Function

End Module

