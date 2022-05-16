Imports EXC = Microsoft.Office.Interop.Excel
Module ModulInformeSubcomptesCompra
    Private subcomptes As List(Of SubcompteGrup)
    Private dataInicial As Date
    Private dataFinal As Date
    Private contaplusActual As Contaplus
    Public Sub execute()
        Dim c As Contaplus, a As AnyMesos
        a = DMesosEmpresa.getMesos(Year(Now), IDIOMA.getString(""), 1)

        c = ModelEmpresaContaplus.getObjectByEmpresaAny(a.idEmpresa, a.any)
        If Not IsNothing(c) Then
            contaplusActual = c
            dataInicial = DateSerial(c.anyo, 1, 1)
            dataFinal = DateSerial(c.anyo, 12, 31)
            If dataFinal > dataInicial Then

                Call setData(c)

                Call MISSATGES.DATA_UPDATED()
            End If
        End If
        c = Nothing
    End Sub
    Private Sub setData(c As Contaplus)
        Dim wb As EXC.Workbook, ws As EXC.Worksheet, f As frmAvis
        Dim rc As ADODB.Recordset, a As Assentament, sCompra As SubcompteGrup, xls As EXC.Range, i As Integer, subcomptesProveidor As List(Of Subcompte), s As Subcompte
        Dim cn As ADODB.Connection, rc1 As ADODB.Recordset, taulaDiario As String, xlsProv As EXC.Range, xlsAssentament As EXC.Range, k As Integer
        Dim j As Integer, total As Double
        cn = DBCONNECT.connectDBF(CONFIG.getDirectori(getRutaDiariActual))
        rc = New ADODB.Recordset
        rc1 = New ADODB.Recordset
        wb = getWorkbook()
        If TypeName(wb) = "Workbook" Then

            ws = EXCEL.getWorkSheet(wb, "Hoja1")
            xls = ws.Range("a1")
            xls(1, 1) = ModelEmpresa.getNom(c.idEmpresa) & ". Dades de  " & dataInicial & " a " & dataFinal
            xls = ws.Range("a3")
            ws = EXCEL.getWorkSheet(wb, "Hoja2")
            xlsProv = ws.Range("a3")
            ws = EXCEL.getWorkSheet(wb, "Hoja3")
            xlsAssentament = ws.Range("a3")
            subcomptes = New List(Of SubcompteGrup)
            taulaDiario = getTable()
            wb.Application.Calculation = EXC.XlCalculation.xlCalculationManual
            While Len(xls(i, 1).value) > 0
                i = i + 1
            End While
            f = New frmAvis(IDIOMA.getString("importDadesDiario"), "", "", i)

            i = 1
            j = 1
            k = 1
            While Len(xls(i, 1).value) > 0
                If rc.State = 1 Then rc.Close()
                f.setData(xls(i, 1).value & "-" & xls(i, 2).value, i)
                rc.Open("SELECT s.asien,s.subcta as sCompra , s1.subcta as s1Prov,s1.eurodebe,s1.eurohaber,s1.contra as  s1Contra ,S1.FECHA AS s1Fecha,s1.concepto as s1Concepte ,s.departa as sdeparta, s.clave as sclave " &
                   " FROM " & taulaDiario & " AS S INNER JOIN " & taulaDiario & " AS S1 ON (S.ASIEN= S1.ASIEN )" &
                   " WHERE s.subcta='" & xls(i, 1).value & "'  and s.FECHA BETWEEN #" & dataInicial & "# AND #" & dataFinal & "# and ( UCASE(S1.CONCEPTO) NOT   like '%PAGAMENT%')", cn)
                If Not rc.EOF Then
                    sCompra = New SubcompteGrup
                    sCompra.codiSubcompte = rc("sCompra").Value
                    sCompra.idSubcompte = ModelSubcompte.getId(rc("sCompra").Value)
                    rc1.Open("SELECT SUM(EURODEBE) AS debe ,SUM (EUROHABER) as haber FROM " & taulaDiario & "  WHERE SUBCTA ='" & rc("scompra").Value & "' and CONCEPTO not like '%pagament%'", cn)
                    If Not rc1.EOF Then
                        sCompra.valorDeure = rc1("debe").Value
                        sCompra.valorHaver = rc1("haber").Value
                        xls(i, 3).value = rc1("debe").Value
                        xls(i, 4).value = rc1("haber").Value
                        xls(i, 5).value = xls(i, 3).value - xls(i, 4).value
                    End If
                    rc1.Close()

                    subcomptesProveidor = New List(Of Subcompte)
                    xlsAssentament(k, 1).value = "ASSENTAMENTS SUBCTE " & sCompra.codiSubcompte & " - " & ModelSubcompte.getDescripcio(, sCompra.codiSubcompte)
                    xlsProv(j, 1).value = "PROVEIDORS SUBCTE " & sCompra.codiSubcompte & " - " & ModelSubcompte.getDescripcio(, sCompra.codiSubcompte)
                    k = k + 1
                    j = j + 1
                    total = 0
                    While Not rc.EOF
                        If rc("S1PROV").Value <> "4009001" Then
                            If Left(rc("s1prov").Value, 1) = "4" Then
                                a = New Assentament
                                a.deure = Math.Round(rc("EURODEBE").Value * 100, 0)
                                a.haver = Math.Round(rc("EUROHABER").Value * 100, 0)
                                a.numero = rc("ASIEN").Value
                                a.subcompteAssentament = rc("s1prov").Value
                                a.dataAssentament = rc("s1Fecha").Value
                                a.concepte = rc("s1Concepte").Value
                                a.clave = rc("sclave").Value
                                a.departamentAssentament = rc("sDeparta").Value
                                If Not IsDBNull(rc("s1Contra").Value) Then a.contrapartida = rc("s1Contra").Value
                                sCompra.assentaments.Add(a)
                                If Left(a.subcompteAssentament, 3) = "400" Then
                                    xlsAssentament(k, 1) = a.numero
                                    xlsAssentament(k, 2) = a.dataAssentament
                                    xlsAssentament(k, 3) = sCompra.codiSubcompte
                                    xlsAssentament(k, 4) = a.subcompteAssentament
                                    xlsAssentament(k, 5) = a.departamentAssentament & a.clave
                                    xlsAssentament(k, 6) = a.concepte
                                    xlsAssentament(k, 7) = a.deure / 100
                                    xlsAssentament(k, 8) = a.haver / 100
                                    total = total + a.saldo / 100
                                    xlsAssentament(k, 9) = total
                                    k = k + 1
                                    If Not subcomptesProveidor.Exists(Function(x) x.codi = a.subcompteAssentament) Then
                                        s = ModelSubcompte.getobject(CStr(a.subcompteAssentament))
                                        If TypeName(s) = "Subcompte" Then subcomptesProveidor.Add(s)
                                    End If
                                End If
                            End If
                        End If
                        rc.MoveNext()
                    End While
                    k = k + 2

                    For Each s In subcomptesProveidor
                        xlsProv(j, 1) = sCompra.codiSubcompte
                        xlsProv(j, 2) = s.codi
                        xlsProv(j, 3) = s.nom
                        xlsProv(j, 4) = sCompra.saldoAssentaments(s.codi) '+ sCompra.saldoAssentaments("472", s.codi)
                        j = j + 1
                    Next s
                    j = j + 2
                End If
                i = i + 1
            End While
            wb.SaveAs(CONFIG.setSeparator(CONFIG.getDirectoriPredeterminatInformes) & Format(Now, "yyMMddhhmmss") & "-INF.SALDO-SUBCOMPTES-COMPRA.xlsx")
            wb.Application.Calculation = EXC.XlCalculation.xlCalculationAutomatic
            f.tancar()
            If rc1.State = 1 Then rc1.Close()
            If rc.State = 1 Then rc.Close()
            If cn.State = 1 Then cn.Close()
        End If
        rc1 = Nothing
        rc = Nothing
        a = Nothing
        wb = Nothing
        cn = Nothing
        ws = Nothing
    End Sub
    Private Function getSubcompte(codiSubcompte As Long) As SubcompteGrup
        Dim s As SubcompteGrup
        For Each s In subcomptes
            If s.codiSubcompte = codiSubcompte Then
                getSubcompte = s
                Exit For
            End If
        Next s
        s = Nothing
    End Function

    Private Function getTable() As String
        getTable = CONFIG.getFitxer(getRutaDiariActual)
    End Function
    Private Function getRutaDiariActual() As String
        getRutaDiariActual = CONFIG.getPathDiarioServidor(ModelEmpresa.getCodiEmpresa(contaplusActual.idEmpresa), contaplusActual.anyo)
    End Function
    Private Function getWorkbook() As EXC.Workbook
        Dim ruta As String
        getWorkbook = EXCEL.getWorkbook(CONFIG.getPlantillaResumCompres)
        If Not TypeName(getWorkbook) = "Workbook" Then
            ruta = CONFIG.getRutaPlantillaResumSubcompteCompres
            If CONFIG.fileExist(ruta) Then getWorkbook = EXCEL.openWorkbook(CONFIG.getRutaPlantillaResumSubcompteCompres)
        End If
    End Function










End Module
