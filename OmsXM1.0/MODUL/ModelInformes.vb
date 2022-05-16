Option Explicit On
Imports Microsoft.Office.Interop.Excel
Module ModelInformes

    Public Sub executeEmpreses()
        Dim wb As Workbook, xls As Object, i As Integer
        Dim empreses As List(Of Empresa), e As Empresa, s As Seccio
        Dim c As Centre, p As Projecte, pe As ProjecteCentre
        Dim r As Range
        wb = EXCEL.getNewWorkbook
        xls = wb.Worksheets(1).range("a1")
        xls(1, 1) = "INFORME EMPRESES-SECCIONS-CENTRES-PROJECTES"
        Call setTitol1(xls)
        xls(2, 7) = "DATA:"
        xls(2, 7).HorizontalAlignment = HorizontalAlignment.Right
        xls(2, 8) = Format(Now, "dd-MM-yy")
        xls(3, 6) = "APLI: Aplioms"
        i = 4
        empreses = ModelEmpresa.getObjects("")
        For Each e In empreses
            For Each s In e.seccions
                xls(i, 1) = "(" & e.codi & ") " & e.nom & ". " & s.ordre & ": " & s.ToString
                Call setTitol2(xls(i, 1))
                i = i + 1
                For Each c In s.centres
                    xls(i, 2) = c.ToString
                    Call setTitol2(xls(i, 2))
                    i = i + 1
                    For Each pe In c.projectes
                        Call setTitol3(xls(i, 2))
                        xls(i, 2).HorizontalAlignment = HorizontalAlignment.Right
                        Call setTitol3(xls(i, 3))
                        xls(i, 3) = pe.participacio & " %."
                        xls(i, 3).HorizontalAlignment = HorizontalAlignment.Center
                        Call setTitol3(xls(i, 4))
                        xls(i, 4) = ModelProjecte.getObject(pe.idProjecte).ToString
                        i = i + 1
                    Next pe
                    i = i + 1
                Next c
                i = i + 1
            Next s
            i = i + 1
        Next e
        With wb.Worksheets(1).PageSetup
            .PrintTitleRows = "$1:$3"
            .PrintTitleColumns = ""
            .RightFooter = "&P   de  &N"
            .PrintArea = "$A$4:$I$" & i + 2
            .Zoom = False
            .FitToPagesWide = 1
            .FitToPagesTall = i \ 20 + 1
        End With
        wb = Nothing
        xls = Nothing
    End Sub
    Public Sub executeSubcomptes()
        Dim wb As Workbook, xls As Object, i As Integer, temp As String
        Dim grups As List(Of Grup), g As Grup
        Dim SG As Subgrup, sCg As SubcompteGrup
        wb = EXCEL.getNewWorkbook
        xls = wb.Worksheets(1).Range("A1:I1")
        xls(1, 1) = "INFORME GRUPS-SUBGRUPS-SUBCOMPTES"
        Call setTitol1(xls)
        xls(2, 7) = "DATA:"
        xls(2, 7).HorizontalAlignment = HorizontalAlignment.Right
        xls(2, 8) = Format(Now, "dd-MM-yy")
        xls(3, 6) = "APLI: APLIOMS"
        xls(4, 2) = "(*)despesa de Compra"
        Call setTitolCompra(xls(4, 2))
        Call setTitolCompra(xls(4, 3))
        xls(4, 5) = "(**)despesa variable"
        Call setTitolVariable(xls(4, 5))
        Call setTitolVariable(xls(4, 6))
        i = 6
        grups = ModelGrup.getObjects
        For Each g In grups
            xls(i, 1) = "Grup " & g.ordre & " - " & g.ToString
            Call setTitol2(xls(i, 1))
            i = i + 1
            For Each SG In ModelSubgrup.getObjects(g)
                temp = ""
                If SG.esDespesaCompra Then temp = "(*) "
                If SG.esDespesaVariable Then temp = temp & "(**) "
                xls(i, 2) = temp & SG.ToString
                Call setTitol2(xls(i, 2))
                i = i + 1
                For Each sCg In ModelSubcomptesGrup.getObjects(SG.id)
                    'Call setTitol3(xls(i, 2))
                    xls(i, 2).HorizontalAlignment = HorizontalAlignment.Center
                    'Call setTitol3(xls(i, 3))
                    temp = ""
                    If sCg.esDespesaCompra Then temp = "(*) "
                    If sCg.esDespesaVariable Then temp = temp & "(**) "

                    If sCg.esDespesaCompra Then
                        Call setTitolCompra(xls(i, 2))
                        Call setTitolCompra(xls(i, 3))
                        Call setTitolCompra(xls(i, 4))
                        Call setTitolCompra(xls(i, 5))
                        Call setTitolCompra(xls(i, 6))
                        Call setTitolCompra(xls(i, 7))
                    ElseIf sCg.esDespesaVariable Then
                        Call setTitolVariable(xls(i, 2))
                        Call setTitolVariable(xls(i, 3))
                        Call setTitolVariable(xls(i, 4))
                        Call setTitolVariable(xls(i, 5))
                        Call setTitolVariable(xls(i, 6))
                        Call setTitolVariable(xls(i, 7))
                    Else
                        Call setTitol3(xls(i, 2))
                        Call setTitol3(xls(i, 3))
                    End If

                    xls(i, 3) = temp & ModelSubcompte.getObject(sCg.idSubcompte).ToString
                    i = i + 1
                Next sCg
                i = i + 1
            Next SG
            i = i + 1
        Next g

        With wb.Worksheets(1).PageSetup
            .PrintTitleRows = "$1:$3"
            .PrintTitleColumns = ""
            .RightFooter = "&P   de  &N"
            .PrintArea = "$A$4:$I$" & i + 2
            .Zoom = False
            .FitToPagesWide = 1
            .FitToPagesTall = i \ 20 + 1
        End With
        wb = Nothing
        xls = Nothing
        grups = Nothing
        g = Nothing
        SG = Nothing
        sCg = Nothing
    End Sub
    Public Sub executeDespesesCompres()
        Dim wb As Workbook, xls As Object, i As Integer, enhiha As Boolean, cont As Integer
        Dim grups As List(Of Grup), g As Grup
        Dim SG As Subgrup, sCg As SubcompteGrup
        wb = EXCEL.getNewWorkbook
        xls = wb.Worksheets(1).Range("A1:I1")
        xls(1, 1) = "INFORME SUBCOMPTES DESPESES DE COMPRES"
        Call setTitol1(xls)
        xls(2, 7) = "DATA:"
        xls(2, 7).HorizontalAlignment = HorizontalAlignment.Right
        xls(2, 8) = Format(Now, "dd-MM-yy")
        xls(3, 6) = "APLI: aplioms"
        i = 5
        grups = ModelGrup.getObjects
        cont = 1
        For Each g In grups
            For Each SG In ModelSubgrup.getObjects(g)
                enhiha = False
                For Each sCg In ModelSubcomptesGrup.getObjects(SG.id)
                    If sCg.esDespesaCompra Then
                        xls(i, 1) = cont & " "
                        xls(i, 2) = SG.codi & " -"

                        xls(i, 2).HorizontalAlignment = HorizontalAlignment.Right
                        xls(i, 3) = ModelSubcompte.getObject(sCg.idSubcompte).ToString
                        Call setTitol3(xls(i, 3))
                        enhiha = True
                        cont = cont + 1
                        i = i + 1
                    End If
                Next sCg
                If enhiha Then i = i + 1
            Next SG

        Next g

        With wb.Worksheets(1).PageSetup
            .PrintTitleRows = "$1:$3"
            .PrintTitleColumns = ""
            .RightFooter = "&P   de  &N"
            .PrintArea = "$A$4:$I$" & i + 2
            .Zoom = False
            .FitToPagesWide = 1
            .FitToPagesTall = i \ 20 + 1
        End With
        wb = Nothing
        xls = Nothing
        grups = Nothing
        g = Nothing
        SG = Nothing
        sCg = Nothing
    End Sub
    Public Sub executeDespesesVariables()
        Dim wb As Workbook, xls As Object, i As Integer, enhiha As Boolean, cont As Integer
        Dim grups As List(Of Grup), g As Grup
        Dim SG As Subgrup, sCg As SubcompteGrup
        wb = EXCEL.getNewWorkbook
        xls = wb.Worksheets(1).Range("A1:I1")
        xls(1, 1) = "INFORME SUBCOMPTES DESPESES VARIABLES"
        Call setTitol1(xls)
        xls(2, 7) = "DATA:"
        xls(2, 7).HorizontalAlignment = HorizontalAlignment.Right
        xls(2, 8) = Format(Now, "dd-MM-yy")
        xls(3, 6) = "APLI: APLIOMS"
        i = 5
        grups = ModelGrup.getObjects
        cont = 1
        For Each g In grups
            For Each SG In ModelSubgrup.getObjects(g)
                enhiha = False
                For Each sCg In ModelSubcomptesGrup.getObjects(SG.id)
                    If sCg.esDespesaVariable Then
                        xls(i, 1) = cont & " "
                        xls(i, 2) = SG.codi & " -"

                        xls(i, 2).HorizontalAlignment = HorizontalAlignment.Right
                        xls(i, 3) = ModelSubcompte.getObject(sCg.idSubcompte).ToString
                        Call setTitol3(xls(i, 3))
                        enhiha = True
                        cont = cont + 1
                        i = i + 1
                    End If
                Next sCg
                If enhiha Then i = i + 1
            Next SG

        Next g

        With wb.Worksheets(1).PageSetup
            .PrintTitleRows = "$1:$3"
            .PrintTitleColumns = ""
            .RightFooter = "&P   de  &N"
            .PrintArea = "$A$4:$I$" & i + 2
            .Zoom = False
            .FitToPagesWide = 1
            .FitToPagesTall = i \ 20 + 1
        End With
        wb = Nothing
        xls = Nothing
        grups = Nothing
        g = Nothing
        SG = Nothing
        sCg = Nothing
    End Sub
    Public Sub executeColumnes()
        Dim wb As Workbook, xls As Object, i As Integer
        Dim columnes As List(Of Columna), c As Columna, p As ProjecteColumna, cf As ColumnaFilla
        wb = EXCEL.getNewWorkbook
        xls = wb.Worksheets(1).Range("A1:I1")
        xls(1, 1) = "INFORME COLUMNES EXPRAM-PROJECTES"
        Call setTitol1(xls)
        xls(2, 7) = "DATA:"
        xls(2, 7).HorizontalAlignment = HorizontalAlignment.Right
        xls(2, 8) = Format(Now, "dd-MM-yy")
        xls(3, 6) = "APLI: APLIOMS"

        i = 4
        columnes = ModelColumna.getObjects("")
        For Each c In columnes
            xls(i, 1) = "COLUMNA: " & c.ToString
            Call setTitol2(xls(i, 1))
            i = i + 1
            For Each cf In ModelColumnaFilla.getObjects(c.id)
                xls(i, 2) = cf.ToString
                Call setTitol3(xls(i, 2))
                i = i + 1
            Next cf
            For Each p In ModelProjecteColumna.getObjects(c.id, "")
                xls(i, 2) = p.ToString
                Call setTitol3(xls(i, 2))
                i = i + 1
            Next p
            i = i + 1
        Next c

        With wb.Worksheets(1).PageSetup
            .PrintTitleRows = "$1:$3"
            .PrintTitleColumns = ""
            .RightFooter = "&P   de  &N"
            .PrintArea = "$A$4:$I$" & i + 2
            .Zoom = False
            .FitToPagesWide = 1
            .FitToPagesTall = i \ 20 + 1
        End With
        wb = Nothing
        xls = Nothing
        columnes = Nothing
        c = Nothing
        cf = Nothing
        p = Nothing

    End Sub

    Public Sub executeLog(l As Log)
        Dim wb As Workbook, xls As Object, i As Integer
        Dim e As EntradaLog
        wb = EXCEL.getNewWorkbook
        xls = wb.Worksheets(1).Range("A1:I1")
        wb.Application.Calculation = XlCalculation.xlCalculationManual
        xls(1, 1) = "LOG ... " & Format(Now, "yyMMddhhmm") & l.titol
        Call setTitol1(xls)
        xls(2, 1) = "DATA:"
        xls(2, 2) = Format(Now, "dd-MM-yy")
        xls(2, 4) = "HORA: "
        xls(2, 5) = Format(Now, "H:NN:SS")
        xls(3, 1) = "log Titol : " & l.titol
        xls(4, 1) = "log Descripció: " & l.descripcio
        i = 6
        For Each e In l.entrades
            xls(i, 1) = e.titol
            xls(i, 2) = e.descripcio
            Select Case e.codi
                Case tipusEntradaLog.AVIS_log
                    Call setFormatAvis(xls(i, 1))
                    Call setFormatAvis(xls(i, 2))
                Case tipusEntradaLog.ERR_LOG
                    Call setFormatError(xls(i, 1))
                    Call setFormatError(xls(i, 2))
                Case tipusEntradaLog.MIS_LOG
                    Call setFormatMissatge(xls(i, 1))
                    Call setFormatMissatge(xls(i, 2))
            End Select

            i = i + 1
        Next e

        With wb.Worksheets(1).PageSetup
            .PrintTitleRows = "$1:$3"
            .PrintTitleColumns = ""
            .RightFooter = "&P   de  &N"
            .PrintArea = "$A$4:$I$" & i + 2
            .Zoom = False
            .FitToPagesWide = 1
            .FitToPagesTall = i \ 20 + 1
        End With
        wb.SaveAs(CONFIG.getdirectoriLogAplicacio & "\" & Format(Now, "yyMMddHHmm") & "_" & l.titol)
        wb.Application.Calculation = XlCalculation.xlCalculationAutomatic
        wb = Nothing
        xls = Nothing
    End Sub
    Private Sub setTitol1(r As Range)
        r.Font.Name = "ARIAL"
        r.Font.size = 13
        r.Select
        r.Merge()
        r.HorizontalAlignment = HorizontalAlignment.Center
        r.VerticalAlignment = HorizontalAlignment.Center

    End Sub
    Private Sub setTitol2(r As Range)
        r.Font.FontStyle = "CALIBRI"
        r.Font.size = 12
        r.Font.Bold = True
    End Sub
    Private Sub setTitol3(r As Range)
        r.Font.FontStyle = "CALIBRI"
        r.Font.size = 10
        r.Font.Italic = True
    End Sub
    Private Sub setTitolCompra(r As Range)
        r.Font.FontStyle = "CALIBRI"
        r.Font.size = 10
        r.Font.Italic = True
        r.Interior.ColorIndex = 6
    End Sub
    Private Sub setTitolVariable(r As Range)
        r.Font.FontStyle = "CALIBRI"
        r.Font.size = 10
        r.Font.Italic = True
        r.Interior.ColorIndex = 4
    End Sub
    Private Sub setFormatMissatge(r As Range)
        r.Font.FontStyle = "CALIBRI"
        r.Font.size = 10
        r.Font.Italic = True
    End Sub
    Private Sub setFormatAvis(r As Range)
        r.Font.FontStyle = "CALIBRI"
        r.Font.size = 10
        r.Font.Bold = True
    End Sub
    Private Sub setFormatError(r As Range)
        r.Font.FontStyle = "CALIBRI"
        r.Font.size = 12
        r.Font.ColorIndex = 3
        r.Font.Bold = True
    End Sub


End Module
