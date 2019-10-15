Option Explicit On
Imports xls = Microsoft.Office.Interop.Excel
Module ModelProveidorContaplus
    Private assentaments401 As List(Of Assentament)
    Private subctesProveidor As List(Of SubcompteProveidor)
    Private majors401 As List(Of SubcompteProveidor)
    Private contaplusActual As Contaplus
    Private dAvis As frmAvis
    Private Const TAG_PAGAMENT As String = "PAG"
    Private Const TAG_TRANSFERENCIA As String = "TRANSF"
    Private Const TAG_REBUT As String = "REBUT"
    Private Const TAG_CHEQUE As String = "CHEQ"
    Private Const TAG_REGULARITZAT As String = "REGULARITZAT"


    Private Function validateNull(s As String) As String
        If Not IsNothing(s) Then
            validateNull = s
        Else
            validateNull = ""
        End If
    End Function
    Private Function getTable() As String
        getTable = CONFIG.getFitxer(getRutaDiariActual)
    End Function
    Private Function getRutaDiariActual() As String
        If CONFIG_FILE.getTag(TAG.ES_LOCAL) Then
            getRutaDiariActual = CONFIG.getPathDiarioLocal(ModelEmpresa.getCodiEmpresa(contaplusActual.idEmpresa), contaplusActual.anyo)
        Else
            getRutaDiariActual = CONFIG.getPathDiarioServidor(ModelEmpresa.getCodiEmpresa(contaplusActual.idEmpresa), contaplusActual.anyo)
        End If
    End Function
    Private Function getWorkbook() As xls.Workbook
        Dim ruta As String
        getWorkbook = EXCEL.getWorkbook(CONFIG.getPlantillaProveidors)
        If getWorkbook Is Nothing Then
            ruta = DBCONNECT.getRutaDBActual
            If Right(ruta, 1) <> "\" Then ruta = ruta & "\"
            ruta = ruta & CONFIG.getPlantillaProveidors
            If CONFIG.fileExist(ruta) Then getWorkbook = EXCEL.openWorkbook(ruta, False)
            Application.DoEvents()
        End If
    End Function

    Public Sub resetIndex()
        contaplusActual = Nothing
        assentaments401 = Nothing
        subctesProveidor = Nothing
        majors401 = Nothing
    End Sub

    Private Sub setData(c As Contaplus)
        If contaplusActual Is Nothing Then
            contaplusActual = c
            Call getRemoteObjects()
        ElseIf contaplusActual.id <> c.id Then
            contaplusActual = c
            Call getRemoteObjects()
        End If
    End Sub
    Public Sub execute()
        '    Dim c As Contaplus, cbc As CommandBarControl
        '    cbc = CommandBars.ActionControl
        'Set c = ModelEmpresaContaplus.getObject(CInt(cbc.Parameter))
        'If TypeName(c) = "Contaplus" Then
        '        Call getWorkbook()
        '        DoEvents
        '        Call resetIndex()
        '        Call frmCarregarDades.mostrar("IMPORT DADES DIARI")
        '        Call frmCarregarDades.actualitzar("IMPORTANT DADES")
        '        Call setData(c)
        '        Call frmCarregarDades.actualitzar("EXPORTANT DADES")
        '        Call setListAssentaments()
        '        Call frmCarregarDades.tancar
        '    End If
        'Set c = Nothing
    End Sub

    Private Sub setListAssentaments()
        Dim xlExcel As Object, wb As xls.Workbook, ws As xls.Worksheet, i As Integer, a As Assentament, b As Assentament, p As SubcompteProveidor
        Dim xla As xls.Application
        Dim totalAcumulat1 As EnterLlarg, totalAcumulat2 As EnterLlarg
        Dim entradesRepetides As String, tempRegula As List(Of Assentament), entradesRegulades As String, j As Integer
        xla = Interaction.GetObject(, "excel.application")
        wb = getWorkbook()
        i = 1
        entradesRegulades = ""
        If wb IsNot Nothing Then
            xla.Calculation = xla.xlCalculationManual
            wb.RefreshAll()
            ws = EXCEL.getWorkSheet(wb, "WS400")
            If ws IsNot Nothing Then
                ws.Activate()
                Call unFormat(ws.Range("A2:I30000"))
                xlExcel = ws.Range("_INI_DATA")
                dAvis.setData(IDIOMA.getString("sumesSaldos"), "", "-")
                For Each p In subctesProveidor
                    Call setFormatTitol(ws.Range(CStr(xlExcel(i, 1).Address & ":" & xlExcel(i, 9).Address)))
                    xlExcel(i, 1) = "************* " & IDIOMA.getString("llibreMajor") & " : " & p.toString & " ******************"
                    i = i + 1
                    totalAcumulat1 = New EnterLlarg
                    totalAcumulat2 = New EnterLlarg
                    For Each a In p.assentaments
                        xlExcel(i, 1) = a.numero
                        xlExcel(i, 2) = a.subcompteAssentament
                        xlExcel(i, 3) = a.dataAssentament
                        xlExcel(i, 4) = a.contrapartida
                        xlExcel(i, 5) = a.concepte
                        xlExcel(i, 6) = a.document
                        xlExcel(i, 7) = Math.Round(a.deure / 100, 2)
                        xlExcel(i, 8) = Math.Round(a.haver / 100, 2)
                        xlExcel(i, 9) = Math.Round(a.saldoAcumulat / 100, 2)
                        totalAcumulat1.valorLong = a.deure
                        totalAcumulat2.valorLong = a.haver
                        i = i + 1
                    Next a
                    Call setFormatDosRatlles(ws.Range(CStr(xlExcel(i, 1).Address & ":" & xlExcel(i, 9).Address)))
                    xlExcel(i, 6) = IDIOMA.getString("total") & ": "
                    xlExcel(i, 7) = totalAcumulat1.valordecimal
                    xlExcel(i, 8) = totalAcumulat2.valordecimal
                    xlExcel(i, 9) = Math.Round(xlExcel(i, 7) - xlExcel(i, 8), 2)
                    i = i + 3
                Next p
            End If
            i = 1
            ws = EXCEL.getWorkSheet(wb, "WSMAJORS401")
            ws.Activate()
            Call unFormat(ws.Range("A2:I30000"))
            If ws IsNot Nothing Then
                dAvis.setData(IDIOMA.getString("llibreMajor"), "401", "-")
                xlExcel = ws.Range("_INI_DATA")
                For Each p In majors401
                    Call setFormatTitol(ws.Range(CStr(xlExcel(i, 1).Address & ":" & xlExcel(i, 9).Address)))
                    xlExcel(i, 1) = "************* " & IDIOMA.getString("llibreMajor") & " : " & p.toString & " ******************"
                    i = i + 1
                    totalAcumulat1 = New EnterLlarg
                    totalAcumulat2 = New EnterLlarg
                    For Each a In p.assentaments
                        xlExcel(i, 1) = a.numero
                        xlExcel(i, 2) = a.subcompteAssentament
                        xlExcel(i, 3) = a.dataAssentament
                        xlExcel(i, 4) = a.contrapartida
                        xlExcel(i, 5) = a.concepte
                        xlExcel(i, 6) = a.document
                        xlExcel(i, 7) = Math.Round(a.deure / 100, 2)
                        xlExcel(i, 8) = Math.Round(a.haver / 100, 2)
                        xlExcel(i, 9) = Math.Round(a.saldoAcumulat / 100, 2)
                        totalAcumulat1.valorLong = a.deure
                        totalAcumulat2.valorLong = a.haver
                        i = i + 1
                    Next a
                    Call setFormatDosRatlles(ws.Range(CStr(xlExcel(i, 1).Address & ":" & xlExcel(i, 9).Address)))
                    xlExcel(i, 6) = IDIOMA.getString("total") & ": "
                    xlExcel(i, 7) = totalAcumulat1.valordecimal
                    xlExcel(i, 8) = totalAcumulat2.valordecimal
                    xlExcel(i, 9) = Math.Round(xlExcel(i, 7) - xlExcel(i, 8), 2)
                    i = i + 3
                Next p
            End If

            i = 1
            ws = EXCEL.getWorkSheet(wb, "WS401")
            If ws IsNot Nothing Then
                ws.Activate()
                dAvis.setData(IDIOMA.getString("llibreMajor"), "401", "-")
                Call unFormat(ws.Range("A2:K30000"))
                xlExcel = ws.Range("_INI_DATA")
                Call setFormatTitol(ws.Range(CStr(xlExcel(i, 1).Address & ":" & xlExcel(i, 11).Address)))
                xlExcel(i, 1) = "********************* " & IDIOMA.getString("assentamentsNo400") & " *********************." : i = i + 1
                tempRegula = New List(Of Assentament)

                For Each a In assentaments401
                    If a.clave = "" And a.departamentAssentament <> TAG_REGULARITZAT Then
                        b = esRegularitzat(a, assentaments401)
                        If b Is Nothing Then
                            xlExcel(i, 1) = a.numero
                            xlExcel(i, 2) = a.subcompteAssentament
                            xlExcel(i, 3) = a.dataAssentament
                            xlExcel(i, 4) = a.contrapartida
                            xlExcel(i, 5) = a.concepte
                            xlExcel(i, 6) = a.document
                            xlExcel(i, 7) = Math.Round(a.deure / 100, 2)
                            xlExcel(i, 8) = Math.Round(a.haver / 100, 2)
                            xlExcel(i, 9) = Math.Round(a.saldo / 100, 2)
                            xlExcel(i, 11) = a.clave
                            Call setFormatAvis(ws.Range(CStr(xlExcel(i, 1).Address & ":" & xlExcel(i, 11).Address)))
                            i = i + 1
                        Else
                            a.id = j
                            a.ordre = Math.Abs(a.saldo)
                            a.departamentAssentament = TAG_REGULARITZAT
                            b.departamentAssentament = TAG_REGULARITZAT
                            j = j + 1
                            b.id = j
                            b.ordre = Math.Abs(b.saldo)
                            tempRegula.Add(a)
                            tempRegula.Add(b)
                            j = j + 1
                        End If
                    End If
                Next a
                i = i + 1
                Call setFormatTitol(ws.Range(CStr(xlExcel(i, 1).Address & ":" & xlExcel(i, 11).Address)))
                dAvis.setData("assentamentsDesquadrats", "", "-")
                xlExcel(i, 1) = "********************* " & IDIOMA.getString("assentaments400") & " *********************." : i = i + 1
                For Each a In assentaments401
                    If a.clave <> "" Then
                        xlExcel(i, 1) = a.numero
                        xlExcel(i, 2) = a.subcompteAssentament
                        xlExcel(i, 3) = a.dataAssentament
                        xlExcel(i, 4) = a.contrapartida
                        xlExcel(i, 5) = a.concepte
                        xlExcel(i, 6) = a.document
                        xlExcel(i, 7) = Math.Round(a.deure / 100, 2)
                        xlExcel(i, 8) = Math.Round(a.haver / 100, 2)
                        xlExcel(i, 9) = Math.Round(a.saldo / 100, 2)
                        xlExcel(i, 11) = a.clave
                        If InStr(4, a.clave, "-->", vbTextCompare) > 0 Then
                            entradesRepetides = entradesRepetides & a.clave
                            Call setFormatError(ws.Range(xlExcel(i, 1).Address & ":" & xlExcel(i, 11).Address))
                        End If
                        i = i + 1
                    End If

                Next a

            End If
            ws = EXCEL.getWorkSheet(wb, "WSTOTAL")
            ws.Activate()
            ws.Range("A2").Value = "EMPRESA:" : ws.Range("B2").Value = contaplusActual.nom : ws.Range("c2").Value = "any: " & contaplusActual.anyo
            Call unFormat(ws.Range("A4:E30000"))
            dAvis.setData(IDIOMA.getString("totalProveidors"), "", "-")
            i = 1

            If ws IsNot Nothing Then
                xlExcel = ws.Range("_INI_DATA")
                totalAcumulat1 = New EnterLlarg
                totalAcumulat2 = New EnterLlarg
                For Each p In subctesProveidor
                    'If p.saldo <> 0 Then
                    xlExcel(i, 1) = p.codiSubcompte
                    xlExcel(i, 2) = p.nomProveidor
                    xlExcel(i, 3) = p.saldo
                    xlExcel(i, 4) = p.saldo401
                    xlExcel(i, 5) = p.saldo + p.saldo401
                    totalAcumulat1.valordecimal = xlExcel(i, 3)
                    totalAcumulat2.valordecimal = xlExcel(i, 4)
                    If xlExcel(i, 3) <> 0 Or xlExcel(i, 4) <> 0 Then i = i + 1
                    'End If
                Next p

                xlExcel(i, 2) = "TOTAL:"
                xlExcel(i, 3) = totalAcumulat1.valordecimal
                xlExcel(i, 4) = totalAcumulat2.valordecimal
                xlExcel(i, 5) = xlExcel(i, 3) + xlExcel(i, 4)
                Call setFormatDosRatlles(ws.Range(xlExcel(i, 1).Address & ":" & xlExcel(i, 5).Address))

            End If
            ws = EXCEL.getWorkSheet(wb, "WSSALDOS")

            If ws IsNot Nothing Then
                ws.Activate()
                Call unFormat(ws.Range("A4:E30000"))
                i = 1
                xlExcel = ws.Range("_INI_DATA")
                totalAcumulat1 = New EnterLlarg
                totalAcumulat2 = New EnterLlarg
                ws.Range("A2").Value = "EMPRESA:" : ws.Range("B2").Value = contaplusActual.nom : ws.Range("c2").Value = "any: " & contaplusActual.anyo
                For Each p In subctesProveidor
                    If p.saldo <> 0 Then
                        xlExcel(i, 1) = p.codiSubcompte
                        xlExcel(i, 2) = p.nomProveidor
                        xlExcel(i, 3) = Math.Round(p.euroDebe / 100, 2)
                        xlExcel(i, 4) = Math.Round(p.euroHaber / 100, 2)
                        xlExcel(i, 5) = p.saldo
                        totalAcumulat1.valorLong = p.euroDebe
                        totalAcumulat2.valorLong = p.euroHaber
                        i = i + 1
                    End If
                Next p
                xlExcel(i, 2) = IDIOMA.getString("total") & ":"
                xlExcel(i, 3) = totalAcumulat1.valordecimal
                xlExcel(i, 4) = totalAcumulat2.valordecimal
                xlExcel(i, 5) = totalAcumulat1.valordecimal - totalAcumulat2.valordecimal
                Call setFormatDosRatlles(ws.Range(xlExcel(i, 1).Address & ":" & xlExcel(i, 5).Address))

                i = i + 2
                totalAcumulat1 = New EnterLlarg
                totalAcumulat2 = New EnterLlarg

                For Each p In majors401
                    xlExcel(i, 1) = p.codiSubcompte
                    xlExcel(i, 2) = p.nomProveidor
                    xlExcel(i, 3) = Math.Round(p.calcularDebe / 100, 2)
                    xlExcel(i, 4) = Math.Round(p.calcularHaber / 100, 2)
                    xlExcel(i, 5) = p.saldo
                    totalAcumulat1.valorLong = p.euroDebe
                    totalAcumulat2.valorLong = p.euroHaber
                    If p.saldo <> 0 Then i = i + 1
                Next p
                xlExcel(i, 2) = IDIOMA.getString("total") & ":"
                xlExcel(i, 3) = totalAcumulat1.valordecimal
                xlExcel(i, 4) = totalAcumulat2.valordecimal
                xlExcel(i, 5) = totalAcumulat1.valordecimal - totalAcumulat2.valordecimal
                Call setFormatDosRatlles(ws.Range(xlExcel(i, 1).Address & ":" & xlExcel(i, 5).Address))
                i = i + 2
            End If
            xla.Calculation = xla.xlCalculationAutomatic
            If tempRegula.Count > 0 Then
                For Each a In tempRegula
                    entradesRegulades = entradesRegulades & a.numero & "  " & a.subcompteAssentament & "  " & a.concepte & "  " & a.document & "  " & Format(a.saldo, "#,##0.00") & vbCrLf
                Next a
                Call DMissatges.setText(IDIOMA.getString("assentaments401Reg"), entradesRegulades)

            End If
            If Len(entradesRepetides) > 0 Then
                Call DMissatges.setText(IDIOMA.getString("assentaments401Imp"), entradesRepetides)
            Else
                Call MISSATGES.DATA_UPDATED()
            End If
        End If
        wb = Nothing
        ws = Nothing
        a = Nothing
        b = Nothing
        p = Nothing
        totalAcumulat1 = Nothing
        totalAcumulat2 = Nothing

    End Sub

    Private Sub unFormat(r As xls.Range)
        Dim xla As xls.Application
        xla = Interaction.GetObject(, "excel.application")
        r.Borders(xla.xlEdgeLeft).LineStyle = xla.xlNone
        r.Borders(xla.xlEdgeTop).LineStyle = xla.xlNone
        r.Borders(xla.xlEdgeBottom).LineStyle = xla.xlNone
        r.Borders(xla.xlEdgeRight).LineStyle = xla.xlNone
        r.Borders(xla.xlInsideVertical).LineStyle = xla.xlNone
        r.Borders(xla.xlInsideHorizontal).LineStyle = xla.xlNone
        r.Font.ColorIndex = xla.xlAutomatic
        r.Font.Bold = False
        r.Interior.ColorIndex = xla.xlNone
        r.ClearContents()
        xla = Nothing
    End Sub
    Private Sub setFormatDosRatlles(r As xls.Range)
        Dim xla As xls.Application
        xla = Interaction.GetObject(, "excel.application")
        r.Borders(xla.xlEdgeTop).LineStyle = xla.xlThin
        r.Borders(xla.xlEdgeBottom).LineStyle = xla.xlSolid
        xla = Nothing
    End Sub
    Private Sub setFormatTitol(r As xls.Range)
        Dim xla As xls.Application
        xla = Interaction.GetObject(, "excel.application")
        r.Borders(xla.xlEdgeTop).LineStyle = xla.xlSolid
        r.Borders(xla.xlEdgeBottom).LineStyle = xla.xlSolid
        r.Font.Bold = True
        xla = Nothing
    End Sub
    Private Sub setFormatAvis(r As xls.Range)
        r.Font.ColorIndex = 3
    End Sub
    Private Sub setFormatError(r As xls.Range)
        r.Interior.ColorIndex = 6
    End Sub
    Private Function esRegularitzat(a As Assentament, assentaments As List(Of Assentament)) As Assentament
        Dim b As Assentament
        esRegularitzat = Nothing
        For Each b In assentaments
            If b.departamentAssentament <> TAG_REGULARITZAT Then
                If b.clave = "" Then
                    If a.saldo + b.saldo = 0 And a.document = b.document And a.subcompteAssentament = b.subcompteAssentament Then
                        esRegularitzat = b
                        Exit For
                    End If
                End If
            End If
        Next b
        b = Nothing
    End Function
    Private Sub getRemoteObjects()
        Dim rc As ADODB.Recordset, a As Assentament, i As Integer, sp As SubcompteProveidor, tempAssen As List(Of Assentament), tempCodi As Long, tempAcum As Long
        Dim cn As ADODB.Connection, rc1 As ADODB.Recordset, a401 As Assentament, sp401 As SubcompteProveidor, tempAcumMajor As Long
        cn = DBCONNECT.connectDBF(CONFIG.getDirectori(getRutaDiariActual))
        rc = New ADODB.Recordset
        rc1 = New ADODB.Recordset
        assentaments401 = New List(Of Assentament)
        subctesProveidor = New List(Of SubcompteProveidor)
        If rc.State = 1 Then rc.Close()
        rc.Open("SELECT asien,fecha,subcta,contra,concepto,documento,eurodebe,eurohaber " &
            " FROM " & getTable() &
            " WHERE (left(subcta,3)=401)" &
            " ORDER BY SUBCTA,FECHA,ASIEN,DOCUMENTO,EURODEBE DESC, EUROHABER ASC", cn)
        i = 1
        tempCodi = 0
        tempAcum = 0
        tempAssen = New List(Of Assentament)
        sp401 = New SubcompteProveidor
        majors401 = New List(Of SubcompteProveidor)
        While Not rc.EOF
            If tempCodi = 0 Then
                sp401 = New SubcompteProveidor
                sp401.codiSubcompte = rc("SUBCTA").Value
                If contaplusActual.idEmpresa = 1 Then sp401.nomProveidor = ModelSubcompte.getDescripcio(, rc("subcta").Value)  ' falta posar els noms de les altres empreses
                tempAcumMajor = 0
            End If
            If tempCodi <> rc("SUBCTA").Value And tempCodi > 0 Then
                sp = sp401
                majors401.Add(sp401)
                sp401 = New SubcompteProveidor
                dAvis.setData(IDIOMA.getString("llibreMajor"), rc("SUBCTA").Value, "-")
                sp401.codiSubcompte = rc("SUBCTA").Value
                If contaplusActual.idEmpresa = 1 Then sp401.nomProveidor = ModelSubcompte.getDescripcio(, rc("subcta").Value) ' falta posar els noms de les altres empreses
                tempAcum = 0
                tempAcumMajor = 0
                For Each a In tempAssen
                    assentaments401.Add(a)
                Next a
                tempAssen = New List(Of Assentament)
            End If
            a = New Assentament
            a.concepte = validateNull(rc("CONCEPTO").Value)
            a.contrapartida = validateNull(rc("CONTRA").Value)
            a.dataAssentament = rc("FECHA").Value
            a.deure = Math.Round(rc("EURODEBE").Value * 100, 0)
            a.document = validateNull(rc("DOCUMENTO").Value)
            a.haver = Math.Round(rc("EUROHABER").Value * 100, 0)
            a.numero = rc("ASIEN").Value
            a.subcompteAssentament = rc("SUBCTA").Value
            tempAcum = tempAcum + a.saldo
            tempAcumMajor = tempAcumMajor + a.saldo
            a.saldoAcumulat = tempAcumMajor
            If tempAcum = 0 Then
                tempAssen = New List(Of Assentament)
            Else
                tempAssen.Add(a)
            End If
            sp401.assentaments.Add(a)
            tempCodi = rc("SUBCTA").Value
            rc.MoveNext()
        End While
        If sp.codiSubcompte <> sp401.codiSubcompte Then
            majors401.Add(sp401)
            For Each a In tempAssen
                assentaments401.Add(a)
            Next a
            tempAssen = New List(Of Assentament)
        End If
        If rc.State = 1 Then rc.Close()
        rc.Open("SELECT subcta AS S, sum (eurodebe) AS D, sum(eurohaber) AS H  " &
            " FROM " & getTable() &
            " WHERE left(subcta,3)= 400" &
            " GROUP BY subcta " &
            " ORDER BY subcta", cn)
        If Not rc.EOF Then
            While Not rc.EOF
                sp = New SubcompteProveidor
                sp.codiSubcompte = rc("S").Value
                sp.id = ModelSubcompte.getId(rc("S").Value)
                If contaplusActual.idEmpresa = 1 Then sp.nomProveidor = ModelSubcompte.getDescripcio(sp.id)  ' falta posar els noms de les altres empreses
                sp.euroDebe = Math.Round(rc("D").Value * 100, 0)
                sp.euroHaber = Math.Round(rc("H").Value * 100, 0)
                If rc1.State = 1 Then rc1.Close()
                rc1.Open("SELECT asien,fecha,subcta,contra,concepto,documento,eurodebe,eurohaber " &
                       " FROM " & getTable() &
                       " WHERE subcta ='" & rc("S").Value & "' " &
                       " ORDER BY FECHA,ASIEN,DOCUMENTO,EURODEBE DESC, EUROHABER ASC", cn)
                tempAcum = 0
                dAvis.setData(IDIOMA.getString("llibreMajor"), rc("S").Value, "")
                While Not rc1.EOF
                    a = New Assentament
                    a.concepte = validateNull(rc1("CONCEPTO").Value)
                    a.contrapartida = validateNull(rc1("CONTRA").Value)
                    a.dataAssentament = rc1("FECHA").Value
                    a.deure = Math.Round(rc1("EURODEBE").Value * 100, 0)
                    a.document = validateNull(rc1("DOCUMENTO").Value)
                    a.haver = Math.Round(rc1("EUROHABER").Value * 100, 0)
                    a.numero = rc1("ASIEN").Value
                    a.subcompteAssentament = rc1("SUBCTA").Value
                    tempAcum = tempAcum + a.saldo
                    a.saldoAcumulat = tempAcum
                    If Left(a.contrapartida, 3) = "401" And a.document <> "" Then
                        For Each a401 In assentaments401
                            If a401.subcompteAssentament = a.contrapartida And a.document = a401.document Then
                                If Math.Round(Math.Abs(a.saldo), 2) = Math.Round(Math.Abs(a401.saldo), 2) Then
                                    a401.clave = a401.clave & " --> A: " & sp.toString
                                    sp.assentaments401.Add(a401)
                                End If
                            End If
                        Next a401
                    ElseIf (StrComp(Left(a.concepte, Len(TAG_CHEQUE)), TAG_CHEQUE, vbTextCompare) = 0 Or StrComp(Left(a.concepte, Len(TAG_PAGAMENT)), TAG_PAGAMENT, vbTextCompare) = 0 Or StrComp(Left(a.concepte, Len(TAG_TRANSFERENCIA)), TAG_TRANSFERENCIA, vbTextCompare) = 0 Or StrComp(Left(a.concepte, Len(TAG_REBUT)), TAG_REBUT, vbTextCompare) = 0) And Left(a.document, 3) <> "401" Then
                        For Each a401 In assentaments401
                            If a.document = a401.document And Math.Round(Math.Abs(a.saldo), 2) = Math.Round(Math.Abs(a401.saldo), 2) And a401.contrapartida <> "401" Then
                                a401.clave = a401.clave & " --> A: " & sp.toString
                                sp.assentaments401.Add(a401)
                            End If
                        Next a401
                    End If
                    sp.assentaments.Add(a)
                    rc1.MoveNext()
                End While
                subctesProveidor.Add(sp)
                rc.MoveNext()
            End While
        End If
        If rc1.State = 1 Then rc1.Close()
        If rc.State = 1 Then rc.Close()
        If cn.State = 1 Then cn.Close()
        rc1 = Nothing
        rc = Nothing
        a = Nothing
        sp = Nothing
        cn = Nothing
    End Sub
End Module
