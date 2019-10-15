Option Explicit On
Module ModelDiario
    Private objects(0 To 12) As List(Of Assentament)
    Private Const FITXER_CONFIG As String = "configDataAsien"
    Private empresaActual As Empresa
    Private contaplusActual As Contaplus
    Private dateUpdate As DateTime
    Private Const separador As String = ","
    Private Const NUM_ASSENTAMENT As String = "ASIEN"
    Private Const CODI_SUBCOMPTE As String = "SUBCTA"
    Private Const DATA_ASSENTAMENT As String = "FECHA"
    Private Const CONTRAPARTIDA As String = "CONTRA"
    Private Const CLAU As String = "CLAVE"
    Private Const DEPARTAMENT As String = "DEPARTA"
    Private Const DEURE As String = "EURODEBE"
    Private Const HAVER As String = "EUROHABER"
    Private Const CONCEPTE As String = "CONCEPTO"
    Private Const DOCUMENT As String = "DOCUMENTO"
    Private Enum pos
        id = 1
        numero
        data
        subcte
        contra
        concepte
        document
        departa
        clave
        deure
        haver
        saldo
    End Enum
    Private indexCarregat As Boolean
    Private anyActual As Integer
    Private tipText() As String
    Private numeroAssentamentTransitoria As Long


    '    '@ FUNCTION: getLocalObjects
    '    '@ DESCRIPTION: Obté els objectes des dels fitxers. Això ho farà en funció de si el fitxer diario.dbf és mes nou o no que la
    '    Private Sub getLocalObjects()
    '        Dim a As Assentament, m As Integer, f As String, fitxer As IO.StreamReader
    '        Dim i As Integer
    '        For i = 1 To 12
    '            f = getDirectori(empresaActual.codi, anyActual, i)
    '            If CONFIG.fileExist(f) Then
    '                objects(i) = New List(Of Assentament)
    '                Open f For Input As ifree
    '            While Not EOF(ifree)
    '                Set a = New Assentament
    '                Input #ifree, var1(1), var1(2), var1(3), var1(4), var1(5), var1(6), var1(7), var1(8), var1(9), var1(10), var1(11)
    '                a.id = var1(1)
    '                    a.numero = var1(2)
    '                    a.dataAssentament = var1(3)
    '                    a.subcompteAssentament = var1(4)
    '                    a.contrapartida = var1(5)
    '                    a.concepte = var1(6)
    '                    a.document = var1(7)
    '                    a.departamentAssentament = var1(8)
    '                    a.clave = var1(9)
    '                    a.deure = var1(10)
    '                    a.haver = var1(11)
    '                    index(i).Add a, CStr(a.id)
    '            Wend
    '            close ifree
    '        End If
    '        Next i
    '        indexCarregat = True
    '    Set a = Nothing
    'End Sub
    'Private Sub setLocalObjects()
    '    Dim i As Integer, a As Assentament, fitxer As IO.StreamWriter
    '    For i = 1 To 12
    '        If objects(i) IsNot Nothing Then
    '            fitxer = My.Computer.FileSystem.OpenTextFileWriter(getDirectori(empresaActual.codi, anyActual, i), False)
    '            'Open getDirectori(empresaActual.codi, anyActual, i) For Output As ifree
    '            For Each a In objects(i)
    '                '  Write #ifree, a.id, a.numero, a.dataAssentament, a.subcompteAssentament, a.contrapartida, a.concepte, a.document, a.departamentAssentament, a.clave, a.deure, a.haver
    '                fitxer.WriteLine(a.id & separador & a.numero & separador & getFormatData(a.dataAssentament) & separador & getFormatString(a.subcompteAssentament) & separador & getFormatString(a.contrapartida) & separador & getFormatString(a.concepte) & separador & getFormatString(a.document) & separador & getFormatString(a.departamentAssentament) & separador & getFormatString(a.clave) & separador & a.deure & separador & a.haver)
    '            Next a
    '            fitxer.Close()
    '        End If
    '    Next i
    '    dateUpdate = Now
    '    indexCarregat = True
    '    fitxer = Nothing
    '    a = Nothing
    'End Sub
    Private Function getDirectori(codi As String, a As Integer, m As Integer) As String
        Dim d As String
        d = CONFIG.getDirectoriAssentaments
        If Right(d, 1) <> "\" Then d = d & "\"
        If Not CONFIG.folderExist(d) Then MkDir(d)
        d = d & codi & Right(a, 2) & getFormatString(m)
        getDirectori = d
    End Function
    Private Function getFormatString(i As Integer) As String
        If i < 10 Then
            getFormatString = "0" & i
        Else
            getFormatString = CStr(i)
        End If
    End Function

    Private Function getTable() As String
        If empresaActual.esModeLocal Then
            getTable = CONFIG.getFitxer(getRutaDiariActual)
        Else
            getTable = CONFIG.getFitxer(getRutaDiariActual)
        End If
    End Function
    Private Function getRutaDiariActual() As String
        If empresaActual.esModeLocal Then
            getRutaDiariActual = CONFIG.getPathDiarioLocal(empresaActual.codi, contaplusActual.anyo)
        Else
            getRutaDiariActual = CONFIG.getPathDiarioServidor(empresaActual.codi, contaplusActual.anyo)
        End If
    End Function
    Public Sub resetIndex()
        Dim i As Integer
        For i = 1 To 12
            objects(i) = Nothing
        Next i
        numeroAssentamentTransitoria = 0
        indexCarregat = False
    End Sub
    Private Function isDiarioModified() As Boolean
        isDiarioModified = False
        If dateUpdate < CONFIG.getDateFileModified(getRutaDiariActual) Then
            isDiarioModified = True
        End If
    End Function
    Private Sub setData(e As Empresa, c As Contaplus)
        If empresaActual Is Nothing Then
            empresaActual = e
            contaplusActual = c
            getRemoteObjects()
        ElseIf empresaActual.id <> e.id Then
            empresaActual = e
            contaplusActual = c
            Call getRemoteObjects()
        ElseIf contaplusActual Is Nothing Then
            empresaActual = e
            contaplusActual = c
            Call getRemoteObjects()
        ElseIf contaplusActual.id <> c.id Then
            empresaActual = e
            contaplusActual = c
            Call getRemoteObjects()
        Else
            If isDiarioModified() Or Not indexCarregat Then
                Call getRemoteObjects()
            End If
        End If
    End Sub
    Public Function getAssentamentsSubcompteProjecteByMes(e As Empresa, c As Contaplus, clave As String, departa As String, codiSubcompte As String, Optional m As Integer = 0) As List(Of Assentament)
        Dim a As Assentament, i As Integer
        Call setData(e, c)
        getAssentamentsSubcompteProjecteByMes = New List(Of Assentament)
        For i = 1 To 12
            If (m > 0 And i = m) Or m = 0 Then
                If objects(i) IsNot Nothing Then
                    For Each a In objects(i)
                        If a.subcompteAssentament = codiSubcompte And UCase(a.clave) = UCase(clave) And UCase(departa) = UCase(a.departamentAssentament) Then
                            getAssentamentsSubcompteProjecteByMes.Add(a)
                        End If
                    Next a
                End If
            End If
        Next i
        a = Nothing
    End Function
    Public Function getAssentamentsProjecteByMes(e As Empresa, c As Contaplus, clave As String, departa As String, Optional m As Integer = 0) As List(Of Assentament)
        Dim a As Assentament, i As Integer
        Call setData(e, c)
        getAssentamentsProjecteByMes = New List(Of Assentament)
        For i = 1 To 12
            If (m > 0 And i = m) Or m = 0 Then
                If objects(i) IsNot Nothing Then
                    For Each a In objects(i)
                        If UCase(a.clave) = UCase(clave) And UCase(departa) = UCase(a.departamentAssentament) Then
                            getAssentamentsProjecteByMes.Add(a)
                        End If
                    Next a
                End If
            End If
        Next i
        a = Nothing
    End Function
    Public Function getAssentamentsCentreByMes(e As Empresa, c As Contaplus, ce As Centre, Optional m As Integer = 0) As List(Of Assentament)
        Dim a As Assentament, i As Integer, j As Integer, p As ProjecteCentre
        Call setData(e, c)

        getAssentamentsCentreByMes = New List(Of Assentament)
        For i = 1 To 12
            If (m > 0 And i = m) Or m = 0 Then
                If objects(i) IsNot Nothing Then
                    getAssentamentsCentreByMes.AddRange(objects(i).FindAll(Function(x) ce.existProjecte(x.departamentAssentament & x.clave)))
                    'For Each a In objects(i)
                    '    For Each p In ce.projectes

                    '        If UCase(a.departamentAssentament) & a.clave = UCase(p.codiProjecte) Then
                    '            '    If UCase(a.clave) = UCase(codisProjecte(j, 1)) And UCase(codisProjecte(j, 0)) = UCase(a.departamentAssentament) Then
                    '            getAssentamentsCentreByMes.Add(a)
                    '            '    End If
                    '        End If
                    '    Next p


                    'For j = LBound(codisProjecte) To UBound(codisProjecte)
                    '    If UCase(a.clave) = UCase(codisProjecte(j, 1)) And UCase(codisProjecte(j, 0)) = UCase(a.departamentAssentament) Then
                    '        getAssentamentsCentreByMes.Add(a)
                    '    End If
                    'Next j
                    'Next a
                End If
            End If
        Next i
        a = Nothing
    End Function
    Public Function getAssentamentsCentreByMes(e As Empresa, c As Contaplus, codisProjecte(,) As String, Optional m As Integer = 0) As List(Of Assentament)
        Dim a As Assentament, i As Integer, j As Integer
        Call setData(e, c)
        getAssentamentsCentreByMes = New List(Of Assentament)
        For i = 1 To 12
            If (m > 0 And i = m) Or m = 0 Then
                If objects(i) IsNot Nothing Then


                    For Each a In objects(i)
                        For j = LBound(codisProjecte) To UBound(codisProjecte)
                            If UCase(a.clave) = UCase(codisProjecte(j, 1)) And UCase(codisProjecte(j, 0)) = UCase(a.departamentAssentament) Then
                                getAssentamentsCentreByMes.Add(a)
                            End If
                        Next j
                    Next a
                End If
            End If
        Next i
        a = Nothing
    End Function
    Public Function getAssentamentsPretancamentCentreByMes(e As Empresa, c As Contaplus, codisProjecte(,) As String, Optional m As Integer = 0, Optional ambTransitoria As Boolean = False) As List(Of Assentament)
        Dim a As Assentament, i As Integer, j As Integer, nTransitoria As Integer
        Call setData(e, c)
        If Not ambTransitoria Then
            nTransitoria = getNumAssentamentTransitoria(e, c, m)
        Else
            nTransitoria = -1
        End If
        getAssentamentsPretancamentCentreByMes = New List(Of Assentament)
        For i = 1 To 12
            If (m > 0 And i = m) Or m = 0 Then
                If objects(i) IsNot Nothing Then
                    For Each a In objects(i)
                        For j = LBound(codisProjecte) To UBound(codisProjecte)
                            If UCase(a.clave) = UCase(codisProjecte(j, 1)) And UCase(codisProjecte(j, 0)) = UCase(a.departamentAssentament) Then
                                If a.numero <> nTransitoria Then
                                    getAssentamentsPretancamentCentreByMes.Add(a)
                                End If
                            End If
                        Next j
                    Next a
                End If
            End If
        Next i
        a = Nothing
    End Function
    Public Function getNoVinculats(e As Empresa, c As Contaplus, Optional m As Integer = 0) As List(Of EntradaLog)
        Dim p As Projecte, i As Integer, a As Assentament, id As Integer, s As Subcompte
        Dim projectes As List(Of Projecte), subcomptes As List(Of Subcompte)
        projectes = New List(Of Projecte)
        subcomptes = New List(Of Subcompte)
        Dim entrada As EntradaLog
        Call setData(e, c)
        id = 10000
        getNoVinculats = New List(Of EntradaLog)
        For i = 1 To 12
            If (m > 0 And i <= m) Or m = 0 Then
                If objects(i) IsNot Nothing Then
                    For Each a In objects(i)
                        If a.departamentAssentament <> "" Or a.clave <> "" Then
                            If Not ModelProjecteCentre.existProjecte(a.departamentAssentament, a.clave) Then
                                If Not projectes.Exists(Function(x) x.codi = a.departamentAssentament & a.clave) Then
                                    p = ModelProjecte.getObject(a.departamentAssentament & a.clave)
                                    If p Is Nothing Then
                                        p = New Projecte
                                        p.codi = a.departamentAssentament & a.clave
                                        p.nom = IDIOMA.getString("noExisteixSistema")
                                        p.id = id
                                        getNoVinculats.Add(ModelLog.getEntradaLog(tipusEntradaLog.AVIS_log, IDIOMA.getString("noProjecte"), IDIOMA.getString("elProjecte") & vbCrLf & " " & p.codi & vbCrLf & " " & IDIOMA.getString("noDonatAltaSistema")))
                                        id = id + 1
                                    Else
                                        getNoVinculats.Add(ModelLog.getEntradaLog(tipusEntradaLog.AVIS_log, IDIOMA.getString("noProjecte"), IDIOMA.getString("elProjecte") & vbCrLf & " " & p.ToString & vbCrLf & " " & IDIOMA.getString("noVinculatCentre")))
                                    End If
                                    projectes.Add(p)
                                End If
                            End If
                        End If
                        If Not ModelSubcomptesGrup.existSubcompte(a.subcompteAssentament) Then
                            If Not subcomptes.Exists(Function(x) x.codi = a.subcompteAssentament) Then
                                s = ModelSubcompte.getobject(a.subcompteAssentament)
                                If s Is Nothing Then
                                    s = New Subcompte
                                    s.id = id
                                    id = id + 1
                                    s.codi = a.subcompteAssentament
                                    s.nom = IDIOMA.getString("noExisteixSistema")
                                    getNoVinculats.Add(ModelLog.getEntradaLog(tipusEntradaLog.AVIS_log, IDIOMA.getString("noSubcompte"), IDIOMA.getString("elSubcompte") & vbCrLf & " " & s.codi & vbCrLf & " " & IDIOMA.getString("noDonatAltaSistema")))
                                Else
                                    getNoVinculats.Add(ModelLog.getEntradaLog(tipusEntradaLog.AVIS_log, IDIOMA.getString("noSubcompte"), IDIOMA.getString("elSubcompte") & vbCrLf & " " & s.codi & vbCrLf & " " & IDIOMA.getString("noVinculatSubGrup")))
                                End If
                                subcomptes.Add(s)
                            End If
                        End If
                        If a.clave = "" Then
                            getNoVinculats.Add(ModelLog.getEntradaLog(tipusEntradaLog.AVIS_log, IDIOMA.getString("noClau"), IDIOMA.getString("lAssentamentN") & vbCrLf & " " & a.numero & ". " & IDIOMA.getString("noProjecteAssociat")))
                        End If
                    Next a
                End If
            End If
        Next i
        p = Nothing
        a = Nothing
        s = Nothing
        projectes = Nothing
        subcomptes = Nothing
        entrada = Nothing
    End Function
    Public Function getAssentamentsDepartament(e As Empresa, c As Contaplus, codiDepartament As String, dIni As Date, dFinal As Date) As List(Of Assentament)
        Dim a As Assentament, i As Integer
        Call setData(e, c)
        getAssentamentsDepartament = New List(Of Assentament)
        For i = 1 To 12
            If i >= (Month(dIni)) And i <= Month(dFinal) Then
                If objects(i) IsNot Nothing Then
                    For Each a In objects(i)
                        If StrComp(codiDepartament, a.departamentAssentament, vbTextCompare) = 0 Then
                            If Left(a.subcompteAssentament, 1) = 6 Or Left(a.subcompteAssentament, 1) = 7 Then
                                If Year(dIni) = Year(a.dataAssentament) Then getAssentamentsDepartament.Add(a)
                            End If
                        End If
                    Next a
                End If
            End If
        Next i
        a = Nothing
    End Function
    'TODO CAL VEURE PON S'APLICA XMARTI 20/10/2017

    'Public Function getListSubgrup(c As ColleccioOrdenada, m As Integer, vAbsolut As Boolean) As Variant()
    '    Dim dades As Variant, i As Integer, j As Integer, total() As EnterLlarg
    '    Dim total1 As EnterLlarg, subgrups As ColleccioOrdenada
    '    Dim sbg As Subgrup, e As Centre
    'Set subgrups = ModelSubGrup.copyObjects
    'Set total1 = New Enterllarg
    'If c.dades.Count > 0 Then
    '        ReDim dades(-1 To subgrups.dades.Count + 1, 1 To c.dades.Count + 2) As Variant
    '    ReDim total(1 To subgrups.dades.Count + 1) As Enterllarg
    '    ReDim tipText(1 To c.dades.Count + 2) As String
    '    j = 2
    '        For Each e In c.dades
    '            i = 1
    '            dades(-1, j) = e.id
    '            dades(0, j) = e.codi
    '            tipText(j) = e.tipTextProjectes
    '            For Each sbg In subgrups.dades
    '                dades(i, j) = Format(e.saldoSubgrup(sbg.identificador, m, vAbsolut) * -1, "#,##0.00;(#,##0.00)")
    '                If TypeName(total(i)) <> "Enterllarg" Then Set total(i) = New EnterLlarg
    '                ' canvi 29/01/2016
    '                total(i).valordecimal = dades(i, j)
    '                i = i + 1
    '            Next sbg
    '            dades(UBound(dades, 1), j) = Format(e.saldo(m, vAbsolut, ModelGrup.getIdGrupResum), "#,##0.00;(#,##0.00)")
    '            ' canvi 29/01/2016
    '            'total1.valordecimal = e.saldo(m, vAbsolut, 1)
    '            total1.valordecimal = e.saldo(m, vAbsolut, 1) * -1
    '            j = j + 1
    '        Next e
    '        i = 1

    '        For Each sbg In subgrups.dades
    '            dades(i, 1) = sbg.ToString
    '            If TypeName(total(i)) = "Enterllarg" Then
    '                dades(i, UBound(dades, 2)) = Format(total(i).valordecimal, "#,##0.00;(#,##0.00)")

    '            End If
    '            i = i + 1
    '        Next sbg
    '        dades(UBound(dades, 1), UBound(dades, 2)) = Format(total1.valordecimal, "#,##0.00;(#,##0.00)")
    '    Else
    '        ReDim dades(0 To 0, 0 To 0) As Variant
    'End If
    '    getListSubgrup = dades
    'Set total1 = Nothing
    'Set sbg = Nothing
    'Set e = Nothing
    'Set subgrups = Nothing
    'If TypeName(total) = "Enterllarg" Then
    '        For i = LBound(total) To UBound(total) 'reset
    '        Set total(i) = Nothing
    '    Next i
    '    End If
    'End Function
    'TODO CAL VEURE PON S'APLICA XMARTI 20/10/2017
    '    Public Function getListSubGrupCentre(e As Centre, codiSubgrup As String, vAbsolut As Boolean, a As Integer) As Variant()
    '        Dim dades As Variant, i As Integer, m As Integer, j As Integer, total() As EnterLlarg, totalMes(1 To 12) As EnterLlarg, totalCentre As EnterLlarg
    '        Dim s As SubcompteGrup, SG As Subgrup
    '        If e.subGrups.dades.Count > 0 Then
    '            For Each SG In e.subGrups.dades
    '                If SG.codi = codiSubgrup Then
    '                    ReDim dades(0 To SG.subcomptes.dades.Count + 1, 0 To 13) As Variant
    '                    ReDim total(1 To SG.subcomptes.dades.Count + 1) As Enterllarg
    '                    j = 1
    '                    For Each s In SG.subcomptes.dades
    '                        dades(j, 0) = s.toStringSubcompte
    '                        For m = 1 To 12
    '                            If j = 1 Then dades(LBound(dades, 1), m) = Left(CONFIG.mesNom(m), 3) & "-" & Right(a, 2)
    '                            'dades(j, m) = Format(e..getSaldoSubcompte(sg.identificador, s.idSubcompte, m, vAbsolut), "#,##0.00;(#,##0.00)")
    '                            ' canvi 29/01/2016
    '                            dades(j, m) = Format(s.saldo(m, vAbsolut) * -1, "#,##0.00;(#,##0.00)")
    '                            If TypeName(total(j)) <> "Enterllarg" Then Set total(j) = New EnterLlarg
    '                            If TypeName(totalMes(m)) <> "Enterllarg" Then Set totalMes(m) = New EnterLlarg

    '                            total(j).valordecimal = dades(j, m)
    '                            totalMes(m).valordecimal = dades(j, m)
    '                        Next m
    '                        If vAbsolut Then
    '                            dades(j, 13) = dades(j, 12)
    '                        Else
    '                            dades(j, 13) = Format(total(j).valordecimal, "#,##0.00;(#,##0.00)")
    '                        End If
    '                        j = j + 1
    '                    Next s
    '                End If
    '            Next SG
    '            Set totalCentre = New Enterllarg
    '            For m = 1 To 12
    '                dades(UBound(dades, 1), m) = Format(totalMes(m).valordecimal, "#,##0.00;(#,##0.00)")
    '                If (vAbsolut And m = 12) Or Not vAbsolut Then totalCentre.valordecimal = totalMes(m).valordecimal
    '            Next m
    '            dades(UBound(dades, 1), UBound(dades, 2)) = Format(totalCentre.valordecimal, "#,##0.00;(#,##0.00)")
    '        Else
    '            ReDim dades(0 To 0, 0 To 0) As Variant
    '    End If
    '        getListSubGrupCentre = dades

    '    Set s = Nothing
    '    Set totalCentre = Nothing

    '    Set SG = Nothing
    'End Function



    ' TODO CAL VEURE PON S'APLICA XMARTI 20/10/2017

    'Public Function getListAssentament(c As ColleccioOrdenada, Optional saldo As Boolean) As Variant
    '    Dim dades() As Variant, a As Assentament, i As Integer, sTotal As Double
    '    i = 1
    '    'todo es treu l'enterllarg perquè arribava a desbordament.
    '    ' cal revisar el seu funcionamnet.
    '    ' estreu aqui perquè no té valor operatiu. només es informatiu.


    '    If c.dades.Count > 0 Then
    '        ReDim dades(1 To c.dades.Count, 1 To 12) As Variant
    '    For Each a In c.dades
    '            dades(i, pos.clave) = a.clave
    '            dades(i, pos.concepte) = a.concepte
    '            dades(i, pos.contra) = a.contrapartida
    '            dades(i, pos.data) = a.dataAssentament
    '            dades(i, pos.departa) = a.departamentAssentament
    '            dades(i, pos.deure) = Format(Round(a.deure / 100, 2), "#,##0.00")
    '            dades(i, pos.document) = a.document
    '            dades(i, pos.haver) = Format(Round(a.haver / 100, 2), "#,##0.00")
    '            dades(i, pos.id) = a.id
    '            dades(i, pos.numero) = a.numero
    '            dades(i, pos.subcte) = a.subcompteAssentament
    '            sTotal = sTotal + Round(a.saldo / 100, 2)
    '            If saldo Then
    '                dades(i, pos.saldo) = Format(Round(sTotal, 2), "#,##0.00")
    '            End If
    '            i = i + 1
    '        Next a
    '    Else
    '        ReDim dades(1 To 1, 1 To 10) As Variant
    'End If
    '    getListAssentament = dades
    'End Function
    Public Function getTipText(i As Integer) As String
        getTipText = ""
        If UBound(tipText) >= i Then getTipText = tipText(i)
    End Function
    'Public Sub setAny(e As Empresa)
    '    Call resetIndex
    '    Call setdata(e)
    'End Sub
    Private Function getNumAssentamentTransitoria(e As Empresa, c As Contaplus, mes As Integer) As Long
        Call setData(e, c)
        If numeroAssentamentTransitoria = 0 Then numeroAssentamentTransitoria = getRemoteAssentamentTransitoria(mes, c.anyo, Val(CONFIG_PARAM_SERVER.getSubcompteTransitoriaSaldoDeure))
        getNumAssentamentTransitoria = numeroAssentamentTransitoria
    End Function
    ' TODO cal provar
    Private Function getRemoteAssentamentTransitoria(mes As Integer, anyo As Integer, subcta As Long) As Integer
        Dim cn As ADODB.Connection, rc As ADODB.Recordset
        cn = DBCONNECT.connectDBF(CONFIG.getDirectori(getRutaDiariActual))
        rc = New ADODB.Recordset
        rc.Open("SELECT " & NUM_ASSENTAMENT & " FROM " & getTable() & " WHERE " & CODI_SUBCOMPTE & "=  '" & subcta & "' AND MONTH(" & DATA_ASSENTAMENT & ")=" & mes & " AND   " & DOCUMENT & " = '" & Format(DateSerial(anyo, mes, 1), "M/yy") & "'", cn)
        getRemoteAssentamentTransitoria = -1
        If Not rc.EOF Then
            getRemoteAssentamentTransitoria = rc(NUM_ASSENTAMENT).Value
        End If
        If rc.State = 1 Then rc.Close()
        If cn.State = 1 Then cn.Close()
        rc = Nothing
        cn = Nothing
    End Function
    Private Sub getRemoteObjects()
        Dim cn As ADODB.Connection, rc As ADODB.Recordset, m As Integer, d As Date
        Call resetIndex()
        cn = DBCONNECT.connectDBF(CONFIG.getDirectori(getRutaDiariActual))
        rc = New ADODB.Recordset
        rc.Open("SELECT " & NUM_ASSENTAMENT & "," & DATA_ASSENTAMENT & "," & CODI_SUBCOMPTE & "," & CONTRAPARTIDA & "," & CONCEPTE & "," & DOCUMENT & "," & DEPARTAMENT & "," & CLAU & "," & DEURE & "," & HAVER &
              " FROM " & getTable() &
              " WHERE (left(" & CODI_SUBCOMPTE & ",1)= 6 OR left(" & CODI_SUBCOMPTE & ",1)=7)", cn)
        While Not rc.EOF
            If IsDate(rc(DATA_ASSENTAMENT).Value) Then
                m = Month(rc(DATA_ASSENTAMENT).Value)
                If objects(m) Is Nothing Then objects(m) = New List(Of Assentament)
                objects(m).Add(New Assentament(rc(NUM_ASSENTAMENT).Value, rc(DATA_ASSENTAMENT).Value, Trim(CONFIG.validarNull(rc(CONTRAPARTIDA).Value)), Trim(CONFIG.validarNull(rc(CODI_SUBCOMPTE).Value)), Trim(CONFIG.validarNull(rc(CONCEPTE).Value)), Trim(CONFIG.validarNull(rc(DOCUMENT).Value)), Trim(CONFIG.validarNull(rc(DEPARTAMENT).Value)), Trim(CONFIG.validarNull(rc(CLAU).Value)), Math.Round(rc(DEURE).Value * 100, 0), Math.Round(rc(HAVER).Value * 100, 0)))
            End If
            rc.MoveNext()
        End While
        dateUpdate = Now
        indexCarregat = True
        If rc.State = 1 Then rc.Close()
        If cn.State = 1 Then cn.Close()
        rc = Nothing
        cn = Nothing
    End Sub
End Module
