Option Explicit On
Imports Microsoft.Office.Interop.Excel
Module ModulExportarDepartaments
    Private departaments As List(Of Departament)
    Private empresaActual As Empresa
    Private prefixos As List(Of PrefixSubcte)
    Private subcomptesPretancament As List(Of Subcompte)
    Private projectesActuals As List(Of Projecte)
    Private dataIni As Date
    Private datafinal As Date
    Private fitxerPlantilla As String
    Private rutaExportacio As String
    Private Const SEPARATOR As String = "#@#@"
    Private Const FITXER_BALANS As String = "balans.txt"
    Private Const FITXER_PRETANCAMENT As String = "PRETANCAMENT.txt"
    Private Const FITXER_PREFIXOS As String = "PREFIXOS.TXT"
    Private Const MARCA_PROJECTE As String = "P"
    Private Const MARCA_TOTAL_PROJECTE As String = "TP"
    Private Const MARCA_TOTAL_DEPARTAMENT As String = "TD"
    Private Const MARCA_SUBCOMPTE As String = "S"
    Private observacions(,) As String, iobser As Integer

    Public Sub execute()
        Dim f As dCrearLlibreMajor

        f = New dCrearLlibreMajor
        fitxerPlantilla = CONFIG.setFolder(DBCONNECT.getRutaDBActual) & CONFIG.getPlantillaLlibreMajor

        If CONFIG.fileExist(fitxerPlantilla) Then
            subcomptesPretancament = ModelSubcomptePretancament.getObjects
            prefixos = ModelPrefixSubcompte.getObjects
            prefixos.Sort(Function(x, y) (7 - x.prefix.Length).CompareTo(7 - y.prefix.Length))
            If f.ShowDialog() = DialogResult.OK Then
                Call setdata()
                Call MISSATGES.DATA_UPDATED()
            End If
        Else
            Call ERRORS.ERR_NO_EXIST_PLANTILLA_LLIBRE_MAJOR
        End If
        prefixos = Nothing
        subcomptesPretancament = Nothing
        f = Nothing
    End Sub
    Public Sub getData(d As List(Of Departament), e As Empresa, dIni As Date, dFinal As Date, projectes As List(Of Projecte), rutaExp As String)
        departaments = d
        empresaActual = e
        projectesActuals = projectes
        dataIni = dIni
        datafinal = dFinal
        rutaExportacio = setFolder(rutaExp)
    End Sub
    Private Sub setdata()
        Dim d As Departament, p As ProjecteDepartament, s As SubcompteGrup, a As Assentament, fAvis As frmAvis
        Dim balans(,) As String, i As Integer, subcompte(,) As String, j As Integer

        Dim projecte(8) As String
        Dim xlApplication As Application
        Dim deureD As Double, haverD As Double
        Dim saldoSubcompte As Double
        xlApplication = EXCEL.getMacros
        fAvis = New frmAvis(IDIOMA.getString("exportarDepartaments"))
        For Each d In departaments
            deureD = d.deure
            haverD = d.haver
            For Each p In d.projectes
                If existProjecte(p) Then
                    fAvis.setData(IDIOMA.getString("analiticDe") & ": ", p.toString, "-")
                    ReDim balans(200, 6)
                    ReDim subcompte(10000, 9)
                    ReDim observacions(10000, 4)
                    iobser = 0
                    balans(2, 2) = empresaActual.nom & " " & Year(dataIni)
                    balans(3, 2) = p.toString
                    balans(4, 2) = dataIni & " a " & datafinal
                    i = 7
                    j = 7
                    p.subcomptes.Sort(Function(x, y) x.codiSubcompte.CompareTo(y.codiSubcompte))
                    For Each s In p.subcomptes
                        balans(i, 1) = s.codiSubcompte
                        balans(i, 2) = s.nomSubcompte
                        balans(i, 3) = s.deure
                        balans(i, 4) = s.haver
                        If s.deure - s.haver > 0 Then
                            balans(i, 5) = s.deure - s.haver
                        Else
                            balans(i, 6) = s.haver - s.deure
                        End If
                        i = i + 1
                        subcompte(2, 3) = empresaActual.nom & " " & Year(dataIni)
                        subcompte(3, 3) = p.toString
                        subcompte(4, 3) = dataIni & " a " & datafinal
                        subcompte(j, 1) = "*** " & s.toStringSubcompte & " ***"
                        j = j + 1
                        s.assentaments.Sort(Function(x, y) x.dataAssentament.CompareTo(y.dataAssentament))
                        saldoSubcompte = 0
                        For Each a In s.assentaments
                            subcompte(j, 1) = a.numero
                            subcompte(j, 2) = a.dataAssentament
                            subcompte(j, 3) = a.document
                            subcompte(j, 4) = a.contrapartida
                            subcompte(j, 5) = a.concepte
                            subcompte(j, 6) = a.departamentAssentament & a.clave
                            subcompte(j, 7) = Math.Round(a.deure / 100, 2)
                            subcompte(j, 8) = Math.Round(a.haver / 100, 2)
                            saldoSubcompte = saldoSubcompte + Math.Round(a.deure - a.haver, 2)
                            subcompte(j, 9) = saldoSubcompte
                            j = j + 1
                        Next a
                        subcompte(j, 5) = "SALDO. .........."
                        subcompte(j, 7) = s.deure
                        subcompte(j, 8) = s.haver
                        subcompte(j, 9) = s.haver - s.deure
                        j = j + 1
                        'For m = 1 To 12
                        '    pretancaments(k, m, 1) = s.saldo(m, False, -1)
                        '    pretancaments(k, m, 2) = s.toStringAssentaments(m, 1)
                        'Next m
                        'k = k + 1
                    Next s
                    balans(i, 2) = "TOTAL PROYECTO. ...... "
                    balans(i, 3) = p.deure
                    balans(i, 4) = p.haver
                    If p.saldo > 0 Then
                        balans(i, 6) = p.saldo
                    Else
                        balans(i, 5) = -1 * p.saldo
                    End If
                    i = i + 1
                    balans(i, 2) = "TOTAL DEPARTAMENTO. ...... "
                    balans(i, 3) = deureD
                    balans(i, 4) = haverD
                    If haverD - deureD > 0 Then
                        balans(i, 6) = haverD - deureD
                    Else
                        balans(i, 5) = deureD - haverD
                    End If

                    subcompte(j, 5) = "TOTAL PROYECTO. ...... "
                    subcompte(j, 7) = p.deure
                    subcompte(j, 8) = p.haver
                    subcompte(j, 9) = p.saldo

                    j = j + 1
                    subcompte(j, 5) = "TOTAL DEPARTAMENTO. ...... "
                    subcompte(j, 7) = deureD
                    subcompte(j, 8) = haverD
                    subcompte(j, 9) = haverD - deureD
                    ' AQUI ENS CAL CREAR EL PRETANCAMENT A PARTIR DE LES SUBCOMPTES JA CARREGADES
                    xlApplication.Run("setLlibreProjecte", fitxerPlantilla, rutaExportacio, dataIni, datafinal, p.codiProjecte, p.nomProjecte, redimensionarArrayBidimensional(balans, i, 6), redimensionarArrayBidimensional(subcompte, j, 9), getPretancament(p.subcomptes), redimensionarArrayBidimensional(observacions, iobser, 4))
                End If
            Next p
        Next d
        xlApplication.Run("closeWorkBook", fitxerPlantilla)
        Call EXCEL.closeMacros(xlApplication)
        fAvis.tancar()
        fAvis = Nothing
        d = Nothing
        p = Nothing
        s = Nothing
        a = Nothing

    End Sub
    'Private Sub setdata()
    '    Dim d As Departament, p As ProjecteDepartament, s As SubcompteGrup, a As Assentament, subctesNO As List(Of Subcompte)
    '    Call setPrefixos()
    '    For Each d In departaments
    '        Call removeTempDades()
    '        For Each p In d.projectes
    '            Using fitxerBalans As StreamWriter = New StreamWriter(CONFIG.getRutaDadesMacroLlibreMajor & FITXER_BALANS)
    '                Using fitxerPretancament As StreamWriter = New StreamWriter(CONFIG.getRutaDadesMacroLlibreMajor & FITXER_PRETANCAMENT)
    '                    fitxerBalans.WriteLine(MARCA_PROJECTE & SEPARATOR & empresaActual.nom & SEPARATOR & p.toString & SEPARATOR & dataIni & SEPARATOR & datafinal & SEPARATOR & "")
    '                    subctesNO = New List(Of Subcompte)
    '                    For Each s In p.subcomptes
    '                        fitxerBalans.WriteLine(MARCA_SUBCOMPTE & SEPARATOR & s.codiSubcompte & SEPARATOR & s.nomSubcompte & SEPARATOR & s.deure & SEPARATOR & s.haver & SEPARATOR & "")
    '                        Using fitxerSubcompte As StreamWriter = New StreamWriter(CONFIG.getRutaDadesMacroLlibreMajorSubctes & s.ToString & ".txt")
    '                            For Each a In s.assentaments
    '                                fitxerSubcompte.WriteLine(a.numero & SEPARATOR & a.dataAssentament & SEPARATOR & a.document & SEPARATOR & a.contrapartida & SEPARATOR & a.concepte & SEPARATOR & a.departamentAssentament & a.clave & SEPARATOR & a.deure & SEPARATOR & a.haver)
    '                            Next a
    '                        End Using
    '                        For m = 1 To 12
    '                            fitxerPretancament.WriteLine(s.codiSubcompte & SEPARATOR & s.saldo(m, False, -1) & SEPARATOR & s.toStringAssentaments(m, 1))
    '                        Next m
    '                    Next s
    '                    fitxerBalans.WriteLine(MARCA_TOTAL_PROJECTE & SEPARATOR & "" & SEPARATOR & "" & SEPARATOR & p.deure & SEPARATOR & p.haver & SEPARATOR & "")
    '                    fitxerBalans.WriteLine(MARCA_TOTAL_DEPARTAMENT & SEPARATOR & "" & SEPARATOR & "" & SEPARATOR & d.deure & SEPARATOR & d.haver & SEPARATOR & "")
    '                End Using
    '            End Using
    '        Next p

    '    Next d
    '    d = Nothing
    '    p = Nothing
    '    s = Nothing
    '    a = Nothing
    'End Sub

    Private Function filtrarAssentament(a As Assentament) As Boolean
        filtrarAssentament = False
        If a.dataAssentament >= dataIni And a.dataAssentament <= datafinal Then
            filtrarAssentament = True
        End If
    End Function

    Private Function getSubcomptePrefix(codi As String) As String
        Dim p As PrefixSubcte
        getSubcomptePrefix = "-1"
        If prefixos IsNot Nothing Then
            For Each p In prefixos
                If Strings.Left(codi, p.prefix.Length) = p.prefix Then
                    getSubcomptePrefix = p.codiSubcompte
                    Exit For
                End If
            Next
        End If
        p = Nothing
    End Function
    Private Function getPretancament(subcomptes As List(Of SubcompteGrup)) As String(,,)
        Dim s As SubcompteGrup, tempSubcomptes As List(Of SubcompteGrup), tempCodi As String
        Dim sTemp As SubcompteGrup, m As Integer, valor As Double
        Dim pretancaments(,,) As String, k As Integer
        tempSubcomptes = New List(Of SubcompteGrup)
        ReDim pretancaments(500, 12, 2)
        For Each s In subcomptes
            If Not subcomptesPretancament.Exists(Function(x) x.codi = s.codiSubcompte) Then
                tempCodi = getSubcomptePrefix(s.codiSubcompte)
                If tempCodi = "-1" Then
                    'ens cal posar observacio en vermell 
                    For m = 1 To 12
                        valor = s.saldo(m, False, -1)
                        If valor <> 0 Then
                            observacions(iobser, 0) = s.codiSubcompte
                            observacions(iobser, 1) = "ERROR. EL SALDO DE LA SUBCUENTA. NO SE HA AÑADIDO AL PRE-CIERRE ACTUAL."
                            observacions(iobser, 2) = CONFIG.mesNom(m) & "-" & Year(dataIni)
                            observacions(iobser, 3) = valor
                            observacions(iobser, 4) = "red"
                            iobser = iobser + 1
                        End If
                    Next

                Else
                    sTemp = tempSubcomptes.Find(Function(x) x.codiSubcompte = tempCodi)
                    If sTemp Is Nothing Then
                        sTemp = New SubcompteGrup
                        sTemp.codiSubcompte = tempCodi
                        sTemp.toStringSubcompte = tempCodi & " - " & ModelSubcompte.getDescripcio(, tempCodi)
                        sTemp.assentaments.AddRange(s.assentaments)
                        tempSubcomptes.Add(sTemp)
                    Else
                        sTemp.assentaments.AddRange(s.assentaments)
                    End If
                    For m = 1 To 12
                        valor = s.saldo(m, False, -1)
                        If valor <> 0 Then
                            observacions(iobser, 0) = s.codiSubcompte
                            observacions(iobser, 1) = "AVISO. EL SALDO DE LA SUBCUENTA. SE HA AÑADIDO A LA SUBCTA " & sTemp.toStringSubcompte
                            observacions(iobser, 2) = CONFIG.mesNom(m) & "-" & Year(dataIni)
                            observacions(iobser, 3) = valor
                            observacions(iobser, 4) = sTemp.codiSubcompte & "-" & m
                            iobser = iobser + 1
                        End If
                    Next
                End If
            Else
                sTemp = tempSubcomptes.Find(Function(x) x.codiSubcompte = s.codiSubcompte)
                If sTemp Is Nothing Then
                    tempSubcomptes.Add(s)
                Else
                    sTemp.assentaments.AddRange(s.assentaments)
                End If
            End If
        Next
        k = 1
        For Each s In tempSubcomptes
            For m = 1 To 12
                pretancaments(k, m, 0) = s.codiSubcompte
                pretancaments(k, m, 1) = s.saldo(m, False, -1)
                pretancaments(k, m, 2) = s.toStringAssentaments(m, 1)
            Next m
            k = k + 1
        Next
        getPretancament = CONFIG.redimensionarArrayTridimensional(pretancaments, k, 12, 2)

        tempSubcomptes = Nothing
        sTemp = Nothing
        s = Nothing
        pretancaments = Nothing
    End Function

    Private Sub removeTempDades()
        'If CONFIG.folderExist(CONFIG.getRutaDadesMacroLlibreMajor) Then
        '    Call Directory.Delete(CONFIG.getRutaDadesMacroLlibreMajor, True)
        'End If
    End Sub
    Private Function existProjecte(p As ProjecteDepartament) As Boolean
        If projectesActuals IsNot Nothing Then
            If projectesActuals.Count > 0 Then
                If projectesActuals.Exists(Function(x) x.id = p.idProjecte) Then
                    Return True
                Else
                    Return False
                End If
            End If
        End If
        Return True
    End Function

End Module
