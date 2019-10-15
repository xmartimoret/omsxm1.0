Option Explicit On

Imports System.IO
Imports Microsoft.Office.Interop.Excel
Module ModulActualitzacioGB
    'MODUL: modulActualitzacioGB
    'DESCRIPCIÓ: Agrupa totes les funciones de actualització de dades dels fitxers detalls i dades DETALL
    'AUTOR: XMARTI. 2016
    Private Enum tipus
        valor = 0
        colorIndex = 1
        ampleColumna = 2
        entireHidden = 3
        fontBold = 4
    End Enum

    Private objects(0 To 12) As List(Of ImportMesSubgrup)
    Private indexCarregat As Boolean
    Private anyoActual As Integer

    Private logActual As Log
    Private Const DADES_DE As String = "Dades de:"
    Private Const ACTUALITZADES As String = "Actualitzades:"
    Private Const ACTUALITZADES_PER As String = "Per:"
    Private Const PARTICIPACIO_TITOL As String = "%:"
    Private Const RANG_CODI_SUBGRUPS As String = "_CODI_GRUP"
    Private Const RANG_CODI_CENTRES As String = "_CODI_PROJECTE"
    Private Const NOM_FULLA_DADES As String = "DADESOMS"
    'Private tempDadesGB(,) As String
    Private codiSubgrups(1000) As String
    Private codiCentres(150) As String
    Private valors(1000) As String
    Private tempCodiSubgrup As String
    Private tempFilaSubgrup As Integer
    Private tempCodiCentre As String
    Private tempColumnaCentre As Integer

    Private dateUpdate As DateTime
    Private Const MACRO_CREAR_PLANTILLA As String = "crearPlantillagb.xlam"
    Private Const FITXER_DADES_PLANTILLA_GB As String = "plantillaGB.txt"
    Private Const FITXER_DADES_GB As String = "gb.txt"
    Private Const RUTA_DADES_GB As String = "DADESGB"
    Private Const MARCA_LLIBRE_GB As String = "RUTAGB"
    Private Const MARCA_GRUP_COMPTABLE As String = "GRUP"
    Private Const MARCA_CENTRE As String = "CENTRE"
    Private Const SEPARATOR As String = "#@#@"
    'PROCEDIMENT/FUNCIÓ: setRemoteObjects
    'DESCRIPCIÓ: Per carregar les dades remotes. Des de la base de dades a la variable local (index). Per  guanyar eficàcia
    '           a l'hora de realitzar les cerques de dades els valors per mesos.
    'AUTOR: XMARTI. 24/07/2016
    'ENTRADES: -
    'SORTIDA: -



    'PROCEDIMENT/FUNCIÓ: existCentre
    'DESCRIPCIÓ: Comprova si existeixen dades d'un centre. Realitza les consultes a la base de dades directament, degut a que cal
    '           comprovar els diferents anys comptables i en memòria només tenim un període comptable. s'enten que les consultes
    '           seran poques, només quan es vulgui eliminar un centre.
    'AUTOR: XMARTI. 24/07/2016
    'ENTRADES: identificador del centre
    'SORTIDA: si/no
    Public Function existCentre(idCentre As Integer) As Boolean
        Return dbActualitzacioGB.existCentre(idCentre)
    End Function
    'PROCEDIMENT/FUNCIÓ:
    'DESCRIPCIÓ:
    'AUTOR: XMARTI. 24/07/2016
    'ENTRADES:
    'SORTIDA:
    'Public Function updateDataCentre(centreOrigen As Centre, centreDesti As Centre, mes As Integer, anyo As Integer) As Variant
    '    Dim rc As ADODB.Recordset, dadesOrigen As Collection, ims As ImportMesSubgrup
    'Set rc = New ADODB.Recordset
    'Call setData(anyo)
    '    ' ESTIC AQUI, ES POT FER AMB UN UPDATE, I POSAR UN GROUP BY  EN EL REMOTE INDEX.

    '    Call rc.Open("UPDATE " & getTable() & " SET IDCENTRE =  " & centreDesti.id & " WHERE IDCENTRE =" & centreOrigen.id & " And  MES = " & mes & " And  ANYO = " & anyo, DBCONNECT.currentConnect, adOpenDynamic, adLockOptimistic)
    '    If rc.State = 1 Then rc.Close()
    '        Set rc = Nothing
    'Set dadesOrigen = Nothing
    'Set ims = Nothing
    'End Function

    'PROCEDIMENT/FUNCIÓ:
    'DESCRIPCIÓ:
    'AUTOR: XMARTI. 24/07/2016
    'ENTRADES:
    'SORTIDA:
    Public Function removeData(idCentre As Integer, pMes As Integer, pAnyo As Integer, Optional actualitzar As Boolean = False) As Boolean
        Dim result As Boolean
        result = dbActualitzacioGB.removeData(idCentre, pMes, pAnyo)
        If actualitzar Then Call resetIndex()
        Return result
    End Function
    ' TODO FALTARÀ CONVERTIR EN UN STRING  LA LLISTA DE MESOS (INTEGER) 
    'PROCEDIMENT/FUNCIÓ:
    'DESCRIPCIÓ:
    'AUTOR: XMARTI. 24/07/2016
    'ENTRADES:
    'SORTIDA:
    Public Function getMesos(pAnyo As Integer) As List(Of Mes)
        Return dbActualitzacioGB.getMesos(pAnyo)
    End Function
    'PROCEDIMENT/FUNCIÓ:
    'DESCRIPCIÓ:
    'AUTOR: XMARTI. 24/07/2016
    'ENTRADES:
    'SORTIDA:
    Public Function getAnyos() As List(Of Integer)
        Return dbActualitzacioGB.getAnyos()
    End Function
    'PROCEDIMENT/FUNCIÓ:
    'DESCRIPCIÓ:
    'AUTOR: XMARTI. 24/07/2016
    'ENTRADES:
    'SORTIDA:
    Private Function isDBImportSubgrupModified(a As Integer) As Boolean
        If a <> anyoActual Then
            anyoActual = a
            isDBImportSubgrupModified = True
        Else
            isDBImportSubgrupModified = Not DBCONNECT.isUpdated(dateUpdate, getTable())
        End If
    End Function
    'PROCEDIMENT/FUNCIÓ:
    'DESCRIPCIÓ:
    'AUTOR: XMARTI. 24/07/2016
    'ENTRADES:
    'SORTIDA:
    Private Sub setData(a As Integer)
        If isDBImportSubgrupModified(a) Or Not indexCarregat Then
            Call SetRemoteObjects(a)
        End If
    End Sub
    Public Function getValues(idCentre As Integer, anyo As Integer, mesos() As Boolean) As List(Of ImportMesSubgrup)
        Dim ims As ImportMesSubgrup, m As Integer
        Call setData(anyo)
        getValues = New List(Of ImportMesSubgrup)
        For m = 1 To 12
            If mesos(m) Then
                If objects(m) IsNot Nothing Then
                    getValues.AddRange(objects(m).FindAll(Function(x) x.idCentre = idCentre))
                End If
            End If
        Next m
        ims = Nothing
    End Function
    'PROCEDIMENT/FUNCIÓ:
    'DESCRIPCIÓ:
    'AUTOR: XMARTI. 24/07/2016
    'ENTRADES:
    'SORTIDA:
    Public Function getValuesAny(idCentre As Integer, anyo As Integer) As List(Of ImportMesSubgrup)
        Dim m As Integer
        Call setData(anyo)
        getValuesAny = New List(Of ImportMesSubgrup)
        For m = 1 To 12
            If objects(m) IsNot Nothing Then getValuesAny.AddRange(objects(m).FindAll(Function(x) x.idCentre = idCentre))
        Next
    End Function
    'PROCEDIMENT/FUNCIÓ:
    'DESCRIPCIÓ:
    'AUTOR: XMARTI. 24/07/2016
    'ENTRADES:
    'SORTIDA:
    Public Function getValuesMes(idCentre As Integer, anyo As Integer, mes As Integer) As List(Of ImportMesSubgrup)
        Dim sg As Subgrup, i As ImportMesSubgrup
        Call setData(anyo)
        getValuesMes = New List(Of ImportMesSubgrup)
        If objects(mes) IsNot Nothing Then
            getValuesMes.AddRange(objects(mes).FindAll(Function(x) x.idCentre = idCentre))

            For Each sg In ModelSubgrup.getObjects()
                If Not getValuesMes.Exists(Function(x) x.idSubgrup = sg.id) Then
                    i = New ImportMesSubgrup
                    i.idSubgrup = sg.id
                    i.idCentre = idCentre
                    i.anyo = anyo
                    i.mes = mes

                    i.codiGrup = mes & sg.codi
                    getValuesMes.Add(i)
                End If
            Next

        End If
        sg = Nothing
    End Function
    'PROCEDIMENT/FUNCIÓ:
    'DESCRIPCIÓ:
    'AUTOR: XMARTI. 24/07/2016
    'ENTRADES:
    'SORTIDA:
    Public Function existCentreMes(anyo As Integer, idCentre As Integer, mes As Integer) As Boolean
        Call setData(anyo)
        If objects(mes) IsNot Nothing Then Return objects(mes).Exists(Function(x) x.idCentre = idCentre)
        Return False
    End Function
    'PROCEDIMENT/FUNCIÓ:
    'DESCRIPCIÓ:
    'AUTOR: XMARTI. 24/07/2016
    'ENTRADES:
    'SORTIDA:
    Public Function existEmpresaMes(anyo As Integer, idEmpresa As Integer, mes As Integer) As Boolean
        Dim ims As ImportMesSubgrup
        Call setData(anyo)
        existEmpresaMes = False
        If objects(mes) IsNot Nothing Then
            For Each ims In objects(mes)
                If ModelSeccio.getIDEmpresa(ModelCentre.getIDSeccio(ims.idCentre)) = idEmpresa Then
                    If ims.mes = mes And ims.anyo = anyo Then
                        existEmpresaMes = True
                        Exit For
                    End If
                End If
            Next ims
        End If
        ims = Nothing
    End Function
    'PROCEDIMENT/FUNCIÓ:
    'DESCRIPCIÓ:
    'AUTOR: XMARTI. 24/07/2016
    'ENTRADES:
    'SORTIDA:
    Public Sub resetIndex()
        Dim i As Integer
        For i = 1 To 12
            objects(i) = Nothing
        Next i
        indexCarregat = False
    End Sub
    'PROCEDIMENT/FUNCIÓ:exportData (Procediment  principal)
    'DESCRIPCIÓ: llegeix les dades i les presenta.
    'AUTOR: XMARTI. 24/07/2016
    'ENTRADES:
    'SORTIDA:
    Public Sub exportData(Optional esPretancament As Boolean = False, Optional esMan As Boolean = False)
        Dim centres As CentresGB, e As EntradaLog, c As Centre
        Dim fAvis As frmAvis, i As Integer, pr As Process
        Call ModelLog.resetIndex()
        logActual = New Log
        logActual.titol = IDIOMA.getString("logExportGB")
        logActual.descripcio = IDIOMA.getString("registreEstatAccionsLogGB")
        Call ModelTransitoria.resetIndex()
        Call resetIndex()
        'todo cal fer i revisar 
        centres = DExportGB.getCentres(esPretancament, esMan)
        If centres IsNot Nothing Then
            If esPretancament Then
                centres.centres = getDataTransitoria(centres.empresa, centres.centres, centres.anyActual, centres.mesos)
            Else
                fAvis = New frmAvis(IDIOMA.getString("importantDades"), IDIOMA.getString("importantDadesDe"), "-")
                i = 1
                For Each c In centres.centres
                    fAvis.setData(IDIOMA.getString("importantDadesDe"), c.nom, i & " " & IDIOMA.getString("de") & " " & centres.centres.Count)
                    If centres.totAny Then
                        c.importsSubgrups = getValuesAny(c.id, centres.anyActual)
                    Else
                        c.importsSubgrups = getValuesMes(c.id, centres.anyActual, centres.mesActual)
                    End If
                    i = i + 1
                Next
                fAvis.tancar()
            End If

            For Each e In setDataGB(centres)
                logActual.entrades.Add(e)
            Next e
            Call EXCEL.LiberarMemoria()
            If CONFIG.fileExist(CONFIG.setFolder(CONFIG.getRutaApliMacros) & "entrarDadesGB.xlsm") Then
                pr = Process.Start(CONFIG.setFolder(CONFIG.getRutaApliMacros) & "entrarDadesGB.xlsm")
                Call EXCEL.closeWorkbook("entrarDadesGB.xlsm")
            Else
                Call ERRORS.ERR_DIRECTORI_SERVIDOR_MACROS()
            End If

            For Each e In ModelDiario.getNoVinculats(centres.empresa, centres.contaplus, centres.mesActual) ' comprova el diario.
                logActual.entrades.Add(e)
            Next e
            FrmApliOms.Activate()
            Call MISSATGES.DATA_UPDATED()
            If ModelLog.hihaErrors(logActual.entrades) Then
                Call dLogs.setLog(logActual)
            End If
            If esPretancament Then
                Call FrmApliOms.setDataInforme(centres.empresa, centres.contaplus, centres.mesActual, IDIOMA.getString("dadesPretancament"))
            Else
                Call FrmApliOms.setDataContaplus(centres.empresa, centres.contaplus, centres.mesActual)
            End If
        End If
        If centres IsNot Nothing Then
            If centres.isLog Then Call FrmApliOms.setLog(logActual) 'Call ModelInformes.executeLog(logActual)
            If Not centres.isClose Then Call exportData(esPretancament)
        End If
        centres = Nothing

        logActual = Nothing
        e = Nothing
        fAvis = Nothing
    End Sub
    Public Function actualitzarData(cGB As CentresGB, mesos() As Boolean, Optional esPretancament As Boolean = False) As List(Of EntradaLog)
        Dim centres As CentresGB, e As EntradaLog
        Call ModelTransitoria.resetIndex()
        actualitzarData = New List(Of EntradaLog)
        If cGB IsNot Nothing Then
            centres = cGB
            centres.centres = getDataTransitoria(centres.empresa, centres.centres, centres.anyActual, mesos)
        Else
            centres = DExportGB.getCentres(esPretancament)
            If centres IsNot Nothing Then
                Call ModulImportTransitoria.setTempRutaGB(centres.rutaGB)
            End If
        End If

        If TypeName(centres) = "CentresGB" Then
            For Each e In setDataGB(centres) ' posa les dades a la gb
                actualitzarData.Add(e)
            Next e
            For Each e In ModelDiario.getNoVinculats(centres.empresa, centres.contaplus, centres.mesActual) ' comprova el diario.
                actualitzarData.Add(e)
            Next e
            Call MISSATGES.DATA_UPDATED()
            '        If ModelLog.hihaErrors(logActual.entrades) Then
            '            If esPretancament Then
            '                Call frmLogs.mostrar(logActual, "INCIDÈNCIES EXPORT DADES PRETANCAMENT GB")
            '            Else
            '                Call frmLogs.mostrar(logActual, "INCIDÈNCIES EXPORT DATA TANCAMENT GB")
            '            End If
            '        End If

        End If
        '    If TypeName(centres) = "CentresGB" Then
        '        If centres.islog Then Call ModelInformes.executeLog(logActual)
        '        If Not centres.isClose Then Call exportData(esPretancament)
        '    End If
        centres = Nothing
        e = Nothing
    End Function



    'PROCEDIMENT/FUNCIÓ: setDataGB
    'DESCRIPCIÓ: Presenta les dades a una GB
    'AUTOR: XMARTI. 24/07/2016
    'ENTRADES:
    'SORTIDA:
    Public Function setDataGB(centres As CentresGB) As List(Of EntradaLog)
        Dim ims As ImportMesSubgrup, c As Centre, i As Integer, rutaDades As String, rutaCentres As String
        Dim n As Integer, fulles(0 To 100) As String, mesEnCurs() As Integer
        Dim subgrups As List(Of Subgrup), countCentres As Integer
        Dim dades As List(Of List(Of String)), fila As List(Of String)
        subgrups = ModelSubgrup.getObjects
        setDataGB = New List(Of EntradaLog)
        dades = New List(Of List(Of String))

        If centres IsNot Nothing Then 'comprovem que siguin centres gb
            rutaDades = CONFIG.getRuta(CONFIG.getRutaDadesMacro, RUTA_DADES_GB)
            rutaCentres = CONFIG.getRuta(rutaDades, "CENTRES")
            fila = New List(Of String)
            fila.Add(CONFIG.setFolder(CONFIG.getDirectori(centres.rutaGB)))
            fila.Add(CONFIG.getFitxer(centres.rutaGB))
            fila.Add(centres.mesActual)
            fila.Add(centres.anyActual)
            dades.Add(fila)
            countCentres = 0
            Call FILE_IN_OUT.setInClipBoard(dades)
            For Each c In centres.centres
                n = 0
                ' If j > 0 Then ' en cas que existeixi el centre
                ReDim mesEnCurs(0 To 12)
                'If centres.totAny Then
                '    Call clearDataCentreGB(xls, j, subgrups, -1)
                'Else
                '    Call clearDataCentreGB(xls, j, subgrups, centres.mesActual)
                'End If
                dades = New List(Of List(Of String))
                For Each ims In c.importsSubgrups
                    ' i = getPosMesGrup(ims.codiGrup)
                    If mesEnCurs(ims.mes) <> ims.mes Then ' per posar els encapçalaments columna mes
                        mesEnCurs(ims.mes) = ims.mes
                        fila = New List(Of String)
                        fila.Add(ims.mes & DADES_DE)
                        fila.Add(c.codi)
                        fila.Add("'" & ims.tipusDades)
                        dades.Add(fila)
                        fila = New List(Of String)
                        fila.Add(ims.mes & PARTICIPACIO_TITOL)
                        fila.Add(c.codi)
                        fila.Add("'" & centres.participacio & "%")
                        dades.Add(fila)
                        fila = New List(Of String)

                        fila.Add(ims.mes & ACTUALITZADES)
                        fila.Add(c.codi)
                        fila.Add(Now())
                        dades.Add(fila)
                        fila = New List(Of String)
                        fila.Add(ims.mes & ACTUALITZADES_PER)
                        fila.Add(c.codi)
                        fila.Add(Environment.UserName)
                        dades.Add(fila)

                    End If
                    fila = New List(Of String)
                    fila.Add(ims.codiGrup)
                    fila.Add(c.codi)
                    fila.Add(Math.Round(ims.valor * centres.participacio / 100, 2))
                    dades.Add(fila)
                    Call setDataGB.Add(ModelLog.getEntradaLog(CONFIG.tipusEntradaLog.MIS_LOG, "SET DATA", c.ToString & " --> " & ims.codiGrup & " = " & Format(ims.valor, "#,##0.00") & "*" & centres.participacio & "% = " & Format(ims.valor * centres.participacio / 100, "#,##0.00")))
                Next ims
                Call FILE_IN_OUT.setFile(rutaCentres & c.codi & ".txt", dades)
            Next c
        End If


        ims = Nothing
        c = Nothing
        subgrups = Nothing
    End Function
    'Public Function setDataGB(centres As CentresGB) As List(Of EntradaLog)
    '    Dim wb As Workbook, xls As Range, ims As ImportMesSubgrup, c As Centre, j As Integer, i As Integer, esObert As Boolean
    '    Dim ws As Worksheet, n As Integer, fulles(0 To 100) As String, temp As String, mesEnCurs() As Integer, k As Integer
    '    Dim subgrups As List(Of Subgrup), fAvis As frmAvis, countCentres As Integer
    '    Dim apliMacro As Application
    '    subgrups = ModelSubgrup.getObjects
    '    setDataGB = New List(Of EntradaLog)
    '    If centres IsNot Nothing Then 'comprovem que siguin centres gb
    '        fAvis = New frmAvis(IDIOMA.getString("exportDadesGB"), IDIOMA.getString("iniExport"), "-")
    '        wb = EXCEL.getWorkbook(CONFIG.getFitxer(centres.rutaGB))
    '        esObert = True
    '        If wb Is Nothing Then ' en cas que no estigui obert
    '            wb = EXCEL.openWorkbook(centres.rutaGB, False, False)
    '            esObert = False
    '        End If
    '        fAvis.Activate()
    '        If EXCEL.existWorkSheet(wb, NOM_FULLA_DADES) Then 'comprovem que sigui  gb
    '            apliMacro = EXCEL.getMacros
    '            'Interaction.AppActivate(wb.Name)
    '            'System.Windows.Forms.Application.DoEvents()
    '            xls = wb.Worksheets(NOM_FULLA_DADES).Range("a1")
    '            If centres.mesActual = -1 Or centres.mesActual = 0 Then
    '                xls(1, 1) = 12
    '            Else
    '                xls(1, 1) = centres.mesActual
    '            End If
    '            xls(2, 1) = centres.anyActual
    '            wb.Application.Calculation = XlCalculation.xlCalculationManual
    '            Call setcodis(wb.Worksheets(NOM_FULLA_DADES))
    '            countCentres = 1

    '            For Each c In centres.centres
    '                fAvis.setData(IDIOMA.getString("exportDadesde"), c.ToString, countCentres & " " & IDIOMA.getString("de") & " " & centres.centres.Count)
    '                j = getPosCentre(c.codi)
    '                For n = 1 To 100
    '                    fulles(n) = ""
    '                Next n
    '                n = 0
    '                If j > 0 Then ' en cas que existeixi el centre
    '                    ReDim mesEnCurs(0 To 12)
    '                    'If centres.totAny Then
    '                    '    Call clearDataCentreGB(xls, j, subgrups, -1)
    '                    'Else
    '                    '    Call clearDataCentreGB(xls, j, subgrups, centres.mesActual)
    '                    'End If
    '                    For Each ims In c.importsSubgrups
    '                        i = getPosMesGrup(ims.codiGrup)

    '                        If i > 0 Then
    '                            If mesEnCurs(ims.mes) <> ims.mes Then ' per posar els encapçalaments columna mes
    '                                mesEnCurs(ims.mes) = ims.mes
    '                                k = getPosMesGrup(ims.mes & DADES_DE)
    '                                If k > 0 Then valors(k) = ims.tipusDades
    '                                k = getPosMesGrup(ims.mes & ACTUALITZADES)
    '                                If k > 0 Then valors(k) = "'" & Format(Now(), "d-MM-yy hh:mm")
    '                                k = getPosMesGrup(ims.mes & ACTUALITZADES_PER)
    '                                If k > 0 Then valors(k) = Environment.UserName
    '                                k = getPosMesGrup(ims.mes & PARTICIPACIO_TITOL)
    '                                If k > 0 Then valors(k) = "'" & centres.participacio & "%"
    '                            End If
    '                            valors(i) = Math.Round(ims.valor * centres.participacio / 100, 2)
    '                            'xls(i, j) = Math.Round(ims.valor * centres.participacio / 100, 2)
    '                            Call setDataGB.Add(ModelLog.getEntradaLog(CONFIG.tipusEntradaLog.MIS_LOG, "SET DATA", c.ToString & " --> " & ims.codiGrup & " = " & Format(ims.valor, "#,##0.00") & "*" & centres.participacio & "% = " & Format(ims.valor * centres.participacio / 100, "#,##0.00")))
    '                        Else
    '                            Call setDataGB.Add(ModelLog.getEntradaLog(CONFIG.tipusEntradaLog.ERR_LOG, IDIOMA.getString("subGrupNoTrobat"), IDIOMA.getString("elSubGrup") & " " & ims.codiGrup & ". " & IDIOMA.getString("noExisteixMes") & " " & ims.mes))
    '                        End If
    '                    Next ims
    '                    ' cridar  a  la  macroexcel 
    '                    If apliMacro.Run("setDataGb", wb.Worksheets(NOM_FULLA_DADES), j, valors) Then
    '                        ' cal trobar les pagines que hi ha els mesos
    '                        For Each ws In wb.Worksheets
    '                            If Not IsError(ws.Range("c339")) Then
    '                                If ws.Range("c339").Text = c.codi Then
    '                                    n = n + 1
    '                                    fulles(n) = ws.Name
    '                                End If
    '                            End If
    '                        Next ws
    '                    End If
    '                    If n = 0 Then
    '                        Call setDataGB.Add(ModelLog.getEntradaLog(CONFIG.tipusEntradaLog.AVIS_log, "NO FULLA", "El centre " & c.ToString & ". No està vinculat a una fulla GB."))
    '                    ElseIf n > 1 Then
    '                        temp = ""
    '                        For n = 1 To 100
    '                            If fulles(n) <> "" Then
    '                                temp = temp & fulles(n) & ", "
    '                            End If
    '                        Next n
    '                        Call setDataGB.Add(ModelLog.getEntradaLog(CONFIG.tipusEntradaLog.AVIS_log, IDIOMA.getString("variesFulles"), IDIOMA.getString("elCentre") & " " & c.ToString & " " & IDIOMA.getString("vinculatVariesFulles") & " : " & temp))
    '                    Else
    '                        Call setDataGB.Add(ModelLog.getEntradaLog(CONFIG.tipusEntradaLog.MIS_LOG, IDIOMA.getString("fullaVinculada"), IDIOMA.getString("elCentre") & " " & c.ToString & ". " & IDIOMA.getString("vinculadaFulla") & ": " & fulles(1)))
    '                    End If
    '                Else
    '                    Call setDataGB.Add(ModelLog.getEntradaLog(CONFIG.tipusEntradaLog.ERR_LOG, IDIOMA.getString("centreNoTrobat"), IDIOMA.getString("elCodi") & " " & c.codi & " " & IDIOMA.getString("noExisteixAGB") & " " & c.nom))
    '                End If
    '                countCentres = countCentres + 1

    '            Next c
    '            wb.Application.Calculation = XlCalculation.xlCalculationAutomatic
    '            Call fAvis.tancar()
    '            Call EXCEL.closeMacros(apliMacro)
    '        Else
    '            Call setDataGB.Add(ModelLog.getEntradaLog(CONFIG.tipusEntradaLog.ERR_LOG, IDIOMA.getString("errGB"), IDIOMA.getString("fitxerSeleccionat") & " " & wb.Name & " " & IDIOMA.getString("noFitxerGB")))
    '            If Not esObert Then Call wb.Close(False)
    '        End If
    '    End If

    '    xls = Nothing
    '    wb = Nothing
    '    ims = Nothing
    '    c = Nothing
    '    ws = Nothing
    '    subgrups = Nothing

    'End Function
    Private Function getPosMesGrup(codi As String)
        Dim i As Integer
        getPosMesGrup = -1
        For i = 1 To UBound(codiSubgrups)
            If UCase(codi) = UCase(codiSubgrups(i)) Then
                getPosMesGrup = i
                Exit For
            End If
        Next i
    End Function

    'PROCEDIMENT/FUNCIÓ:
    'DESCRIPCIÓ:
    'AUTOR: XMARTI. 24/07/2016
    'ENTRADES:
    'SORTIDA:
    Private Sub clearDataCentreGB(xls As Range, posCentre As Integer, subgrups As List(Of Subgrup), mesActual As Integer)
        Dim SG As Subgrup, i As Integer, m As Integer
        For m = 1 To 12
            If m = mesActual Or mesActual = -1 Then
                For Each SG In subgrups
                    i = getPosMesGrup(m & SG.codi)
                    If i > 0 Then xls(i, posCentre) = 0
                Next SG
            End If
        Next m
        SG = Nothing
    End Sub
    'PROCEDIMENT/FUNCIÓ:
    'DESCRIPCIÓ:
    'AUTOR: XMARTI. 24/07/2016
    'ENTRADES:
    'SORTIDA:
    Private Function getPosCentre(codi As String) As Integer
        Dim i As Integer
        getPosCentre = -1
        For i = 1 To UBound(codiCentres)
            If StrComp(Trim(codiCentres(i)), UCase(Trim(codi)), CompareMethod.Text) = 0 Then
                getPosCentre = i
                Exit For
            End If
        Next i
    End Function

    'PROCEDIMENT/FUNCIÓ:
    'DESCRIPCIÓ:
    'AUTOR: XMARTI. 24/07/2016
    'ENTRADES:
    'SORTIDA:
    Public Sub crearPlantilla()
        '1 cal escriure  al directori lcval 
        Dim nomGB As String, g As Grup, sg As Subgrup, s As Seccio, c As Centre
        Dim grupsComptables As List(Of Grup), seccions As List(Of Seccio)
        Dim p As Integer, fitxersOberts As List(Of String)
        Dim pr As Process
        fitxersOberts = EXCEL.getFitxersGBOberts()
        If fitxersOberts.Count = 1 Then
            nomGB = fitxersOberts.Item(0)
            'wb = EXCEL.getWorkbook(nomGB)
        ElseIf fitxersOberts.Count > 1 Then
            nomGB = ""
        Else
            nomGB = ""
        End If
        If CONFIG.fileExist(nomGB) Then
            Using fitxer As StreamWriter = New StreamWriter(CONFIG.getRutaDadesMacro & FITXER_DADES_PLANTILLA_GB)
                fitxer.WriteLine(MARCA_LLIBRE_GB & SEPARATOR & setFolder(CONFIG.getDirectori(nomGB)) & SEPARATOR & CONFIG.getFitxer(nomGB) & SEPARATOR & "")
                Call ModelGrup.resetIndex()
                grupsComptables = ModelGrup.getObjects
                For Each g In grupsComptables
                    For Each sg In g.subgrups
                        fitxer.WriteLine(MARCA_GRUP_COMPTABLE & SEPARATOR & g.codi & SEPARATOR & sg.codi & SEPARATOR & "")
                    Next
                Next
                Call ModelSeccio.resetIndex()
                seccions = ModelSeccio.getObjects()
                For Each s In seccions
                    p = ModelEmpresa.getParticipacio(s.idEmpresa)
                    For Each c In s.centres
                        fitxer.WriteLine(MARCA_CENTRE & SEPARATOR & p & SEPARATOR & s.codi & SEPARATOR & c.codi)
                    Next
                Next
            End Using
            Call EXCEL.LiberarMemoria()
            pr = Process.Start(CONFIG.setFolder(CONFIG.getRutaApliMacros) & MACRO_CREAR_PLANTILLA)
            Call EXCEL.closeWorkbook(MACRO_CREAR_PLANTILLA)
        Else
            Call MISSATGES.GB_NO_OBERTA()
        End If
        seccions = Nothing
        grupsComptables = Nothing

    End Sub
    '    Public Sub crearPlantilla()
    '        Dim wb As Workbook, xls As Range, ruta As String, grups As List(Of Grup), G As Grup, SG As Subgrup, s As Seccio, e As Centre
    '        Dim i As Integer, m As Integer, total(0 To 200, 0 To 2) As Integer, ini As Integer, iniGrup As Integer, j As Integer
    '        Dim p As Integer, mesActual As Integer, anyActual As Integer, fAvis As frmAvis
    '        Dim dades(10000, 200, 10) As String
    '        Dim apliMacro As Application
    '        ruta = New SelectFiles(IDIOMA.getString("escollirFitxerGB"), False, CONFIG.getDirectori(CONFIG_FILE.getTag(TAG.RUTA_GB_TANCAMENT)), "GB(*.xls*)|*.xls*").fitxer
    '        If CONFIG.fileExist(ruta) Then
    '            fAvis = New frmAvis(IDIOMA.getString("actualitzar"), IDIOMA.getString("plantillaDadesGB"), "-")
    '            wb = EXCEL.getWorkbook(CONFIG.getFitxer(ruta))
    '            If wb Is Nothing Then wb = EXCEL.openWorkbook(ruta, False, False)

    '            If EXCEL.existWorkSheet(wb, NOM_FULLA_DADES) Then
    '                wb.Activate()
    '                wb.Worksheets(NOM_FULLA_DADES).Visible = True
    '                wb.Worksheets(NOM_FULLA_DADES).Activate()
    '                fAvis.Activate()
    '                apliMacro = EXCEL.getMacros
    '                grups = ModelGrup.getObjects
    '                tempDadesGB = apliMacro.Run("getDataGb", wb.Worksheets(NOM_FULLA_DADES))
    '                ok
    '                mesActual = wb.Worksheets(NOM_FULLA_DADES).Range("a1").value
    '                anyActual = wb.Worksheets(NOM_FULLA_DADES).Range("a2").value
    '                ok
    '1 . passa a xls
    '                wb.Worksheets(NOM_FULLA_DADES).Range("a1:gy1000").ClearContents
    '                wb.Worksheets(NOM_FULLA_DADES).Range("a1:gy1000").Interior.ColorIndex = CInt(Constants.xlNone)
    '                wb.Worksheets(NOM_FULLA_DADES).Range("a1:gy1000").Font.Bold = False
    '                System.Windows.Forms.Application.DoEvents()
    '                dades(1, 2, tipus.valor) = "-" 'xls(0, i) = s.codi 'xls(1, 2) = "-"
    '                dades(1, 2, tipus.entireHidden) = True 'xls(i, 2).EntireColumn.Hidden = True
    '                i = 3
    '                For Each s In ModelSeccio.getObjects
    '                    ini = i
    '                    p = ModelEmpresa.getParticipacio(s.idEmpresa)
    '                    i = i + 1 ' per deixar un es

    '                    For Each e In s.centres
    '                        dades(0, i, tipus.valor) = "'" & p & " %" 'xls(-1, i) = "'" & p & " %"
    '                        dades(1, i, tipus.valor) = s.codi 'xls(0, i) = s.codi
    '                        dades(1, i, tipus.colorIndex) = 15 ' xls(0, i).Interior.ColorIndex = 15
    '                        dades(2, i, tipus.valor) = e.codi ' xls(1, i) = e.codi
    '                        dades(2, i, tipus.colorIndex) = 15 ' xls(1, i).Interior.ColorIndex = 15
    '                        dades(2, i, tipus.ampleColumna) = 14 '  xls(1, i).ColumnWidth = 14
    '                        i = i + 1
    '                    Next e
    '                    dades(2, ini, tipus.entireHidden) = True 'xls(1, ini).EntireColumn.Hidden = True
    '                    dades(2, i, tipus.entireHidden) = True 'xls(1, i).EntireColumn.Hidden = True
    '                    i = i + 1 ' deixar un espai entre el primer i l'últim
    '                    dades(0, i, tipus.valor) = "'" & p & " %" ' xls(-1, i) = "'" & p & " %"
    '                    dades(1, i, tipus.valor) = s.codi 'xls(0, i) = s.codi
    '                    dades(1, i, tipus.colorIndex) = 15 ' xls(0, i).Interior.ColorIndex = 15
    '                    dades(2, i, tipus.valor) = "TOTAL." & s.codi ' xls(1, i) = "TOTAL." & s.codi
    '                    dades(2, i, tipus.colorIndex) = 15 'xls(1, i).Interior.ColorIndex = 15
    '                    dades(2, i, tipus.ampleColumna) = 17 'xls(1, i).ColumnWidth = 17
    '                    dades(2, i + 1, tipus.ampleColumna) = 2 'xls(1, i + 1).ColumnWidth = 2
    '                    total(i, 1) = ini
    '                    total(i, 2) = i - 1
    '                    i = i + 2
    '                Next s
    '                For Each G In grups
    '                    G.subgrups = ModelSubgrup.getObjects(G)
    '                Next G
    '                i = 4
    '                CAL PASSAR A EXCEL 
    '                xls = wb.Worksheets(NOM_FULLA_DADES).Range("_CODI_GRUP")
    '                For m = 1 To 12
    '                    dades(i, 1, tipus.valor) = m & "%:" ' xls(i, 1) = m & "%:" ' 02/05/2016, s'afegeix el %
    '                    dades(i, 1, tipus.entireHidden) = True ' xls(i, 1).EntireRow.Hidden = True
    '                    i = i + 1
    '                    dades(i, 1, tipus.valor) = m & DADES_DE ' xls(i, 1) = m & DADES_DE
    '                    dades(i, 1, tipus.entireHidden) = True ' xls(i, 1).EntireRow.Hidden = True
    '                    i = i + 1
    '                    dades(i, 1, tipus.valor) = m & ACTUALITZADES ' xls(i, 1) = m & ACTUALITZADES
    '                    dades(i, 1, tipus.entireHidden) = True ' xls(i, 1).EntireRow.Hidden = True               
    '                    i = i + 1
    '                    dades(i, 1, tipus.valor) = m & ACTUALITZADES_PER ' xls(i, 1) = m & ACTUALITZADES_PER
    '                    dades(i, 1, tipus.entireHidden) = True ' xls(i, 1).EntireRow.Hidden = True               
    '                    i = i + 1
    '                    dades(i, 1, tipus.valor) = "=""" & Left(CONFIG.mesNom(m), 3) & " """ & " & A2" 'xls(i, 1) = "=""" & Left(CONFIG.mesNom(m), 3) & " """ & " & A2"
    '                    dades(i, 1, tipus.fontBold) = True 'xls(i, 1).Font.Bold = True
    '                    i = i + 1
    '                    For Each G In grups
    '                        iniGrup = i
    '                        For Each SG In G.subgrups
    '                            dades(i, 1, tipus.valor) = m & SG.codi 'xls(i, 1) = m & SG.codi
    '                            dades(i, 1, tipus.colorIndex) = 15 'xls(i, 1).Interior.ColorIndex = 15                    
    '                            For ini = 1 To 200
    '                                todo cal veure com ho soluciono, en algun lloc cal agafar la referencia.
    '                                If total(ini, 1) <> 0 Then
    '                                    dades(i, ini, tipus.valor) = 10 '"=sum(" & xls(i, total(ini, 1)).Address & ":" & xls(i, total(ini, 2)).Address & " )"
    '                                    xls(i, ini) = "=sum(" & xls(i, total(ini, 1)).Address & ":" & xls(i, total(ini, 2)).Address & " )"
    '                                    dades(i, ini, tipus.colorIndex) = 15 ' xls(i, ini).Interior.ColorIndex = 15
    '                                End If
    '                            Next ini

    '                            i = i + 1
    '                        Next SG
    '                        For ini = 1 To 200
    '                            If total(ini, 1) <> 0 Then
    '                                For j = total(ini, 1) To total(ini, 2)
    '                                    dades(i, j, tipus.valor) = 10 '"=sum(" & xls(iniGrup, j).Address & ":" & xls(i - 1, j).Address & ") "
    '                                    dades(i, j, tipus.colorIndex) = 15
    '                                Next j
    '                                dades(i, j, tipus.valor) = 10 ' "=sum(" & xls(iniGrup, j).Address & ":" & xls(i - 1, j).Address & ") "
    '                                dades(i, j, tipus.colorIndex) = 15
    '                                dades(i, j, tipus.fontBold) = True
    '                            End If
    '                        Next ini
    '                        dades(i, 1, tipus.colorIndex) = 15 'xls(i, 1).Interior.ColorIndex = 15
    '                        dades(i, 1, tipus.valor) = "TOTAL" ' xls(i, 1) = "TOTAL"
    '                        i = i + 2
    '                    Next G
    '                    i = i + 3
    '                Next m

    '                i = 1
    '                xls = wb.Worksheets(NOM_FULLA_DADES).Range("_CODI_PROJECTE")
    '                For j = 1 To 150
    '                    If dades(2, j, tipus.valor) <> "" Then
    '                        For i = 1 To 1000
    '                            If dades(i, 1, tipus.valor) <> "" Then ' If xls(i, 1) <> "" Then
    '                                If Left(dades(i, j, tipus.valor), 1) <> "=" Then
    '                                    dades(i, j, tipus.valor) = getTempValue(dades(j, 2, tipus.valor), dades(i, 1, tipus.valor))
    '                                End If
    '                            End If
    '                        Next i
    '                    End If
    '                Next j
    '                wb.Worksheets(NOM_FULLA_DADES).Range("a1") = mesActual
    '                wb.Worksheets(NOM_FULLA_DADES).Range("a2") = anyActual
    '                Call apliMacro.Run("crearPlantilla", wb, wb.Worksheets(NOM_FULLA_DADES), dades)

    '                Call fAvis.tancar()
    '                Call EXCEL.closeMacros(apliMacro)
    '                Call MISSATGES.DATA_UPDATED()
    '            Else
    '                Call ERRORS.ERR_NO_GB()
    '            End If
    '        End If
    '        wb = Nothing

    '        xls = Nothing
    '        grups = Nothing
    '        G = Nothing
    '        SG = Nothing
    '        s = Nothing
    '        e = Nothing
    '    End Sub
    ''PROCEDIMENT/FUNCIÓ:
    ''DESCRIPCIÓ:
    ''AUTOR: XMARTI. 24/07/2016
    ''ENTRADES:
    ''SORTIDA:
    'Public Sub crearPlantilla()
    '    'todo.
    '    ' Cal crear un array String de tres dimensions
    '    ' list (grupsComptables, centres,tipusrang) la tercera dimensió ha de tenir tantes posicions com atributs faci falta 
    '    ' tb fa falta un mateix array per l'amplada de les columnes i un per les files 
    '    Dim wb As Workbook, ruta As String, ws As Worksheet, xls As Object, grups As List(Of Grup), G As Grup, SG As Subgrup, s As Seccio, e As Centre
    '    Dim i As Integer, m As Integer, total(0 To 200, 0 To 2) As Integer, ini As Integer, iniGrup As Integer, j As Integer
    '    Dim p As Integer, mesActual As Integer, anyActual As Integer, fAvis As frmAvis
    '    ruta = New SelectFiles(IDIOMA.getString("escollirFitxerGB"), False, "", "GB(*.xls*),*.xls*").fitxer

    '    If CONFIG.fileExist(ruta) Then
    '        fAvis = New frmAvis("", "", "")

    '        wb = EXCEL.getWorkbook(CONFIG.getFitxer(ruta))
    '        If wb Is Nothing Then wb = EXCEL.openWorkbook(ruta, False, False)
    '        grups = ModelGrup.getObjects
    '        wb.Application.Calculation = XlCalculation.xlCalculationManual
    '        xls = wb.Worksheets(NOM_FULLA_DADES).Range("_CODI_PROJECTE")
    '        Call setTempDadesGB(xls)
    '        System.Windows.Forms.Application.DoEvents()
    '        mesActual = wb.Worksheets(NOM_FULLA_DADES).Range("a1")
    '        anyActual = wb.Worksheets(NOM_FULLA_DADES).Range("a2")
    '        wb.Worksheets(NOM_FULLA_DADES).visible = True
    '        wb.Worksheets(NOM_FULLA_DADES).Activate
    '        wb.Worksheets(NOM_FULLA_DADES).Range("a1:gy1000").ClearContents
    '        wb.Worksheets(NOM_FULLA_DADES).Range("a1:gy1000").Interior.ColorIndex = CInt(Constants.xlNone)
    '        wb.Worksheets(NOM_FULLA_DADES).Range("a1:gy1000").Font.Bold = False
    '        System.Windows.Forms.Application.DoEvents()
    '        xls(1, 2) = "-"
    '        xls(i, 2).EntireColumn.Hidden = True
    '        i = 3
    '        For Each s In ModelSeccio.getObjects
    '            ini = i
    '            p = ModelEmpresa.getParticipacio(s.idEmpresa)
    '            i = i + 1 ' per deixar un es
    '            For Each e In s.centres
    '                xls(-1, i) = "'" & p & " %"
    '                xls(0, i) = s.codi
    '                xls(0, i).Interior.ColorIndex = 15
    '                xls(1, i) = e.codi
    '                xls(1, i).Interior.ColorIndex = 15
    '                xls(1, i).ColumnWidth = 14
    '                i = i + 1
    '            Next e
    '            xls(1, ini).EntireColumn.Hidden = True
    '            xls(1, i).EntireColumn.Hidden = True

    '            i = i + 1 ' deixar un espai entre el primer i l'últim

    '            xls(-1, i) = "'" & p & " %"
    '            xls(0, i) = s.codi
    '            xls(0, i).Interior.ColorIndex = 15
    '            xls(1, i) = "TOTAL." & s.codi
    '            xls(1, i).Interior.ColorIndex = 15
    '            xls(1, i).ColumnWidth = 17
    '            xls(1, i + 1).ColumnWidth = 2


    '            total(i, 1) = ini
    '            total(i, 2) = i - 1
    '            i = i + 2
    '        Next s

    '        For Each G In grups
    '            G.subgrups = ModelSubgrup.getObjects(G)
    '        Next G
    '        i = 4
    '        xls = wb.Worksheets(NOM_FULLA_DADES).Range("_CODI_GRUP")
    '        For m = 1 To 12
    '            xls(i, 1) = m & "%:" ' 02/05/2016, s'afegeix el %
    '            xls(i, 1).EntireRow.Hidden = True
    '            i = i + 1
    '            xls(i, 1) = m & DADES_DE
    '            xls(i, 1).EntireRow.Hidden = True
    '            i = i + 1
    '            xls(i, 1) = m & ACTUALITZADES
    '            xls(i, 1).EntireRow.Hidden = True
    '            i = i + 1
    '            xls(i, 1) = m & ACTUALITZADES_PER
    '            xls(i, 1).EntireRow.Hidden = True
    '            i = i + 1
    '            xls(i, 1) = "=""" & Left(CONFIG.mesNom(m), 3) & " """ & " & A2"
    '            xls(i, 1).Font.Bold = True
    '            i = i + 1

    '            For Each G In grups
    '                iniGrup = i
    '                For Each SG In G.subgrups

    '                    xls(i, 1) = m & SG.codi
    '                    xls(i, 1).Interior.ColorIndex = 15
    '                    For ini = 1 To 200
    '                        If total(ini, 1) <> 0 Then
    '                            xls(i, ini) = "=sum(" & xls(i, total(ini, 1)).Address & ":" & xls(i, total(ini, 2)).Address & " )"
    '                            xls(i, ini).Interior.ColorIndex = 15
    '                        End If
    '                    Next ini

    '                    i = i + 1
    '                Next SG
    '                For ini = 1 To 200
    '                    If total(ini, 1) <> 0 Then
    '                        For j = total(ini, 1) To total(ini, 2)
    '                            xls(i, j) = "=sum(" & xls(iniGrup, j).Address & ":" & xls(i - 1, j).Address & ") "
    '                            xls(i, j).Interior.ColorIndex = 15
    '                        Next j
    '                        xls(i, j) = "=sum(" & xls(iniGrup, j).Address & ":" & xls(i - 1, j).Address & ") "
    '                        xls(i, j).Interior.ColorIndex = 15
    '                        xls(i, j).Font.Bold = True
    '                    End If
    '                Next ini
    '                xls(i, 1).Interior.ColorIndex = 15
    '                xls(i, 1) = "TOTAL"
    '                i = i + 2

    '            Next G
    '            i = i + 3
    '        Next m

    '        i = 1
    '        xls = wb.Worksheets(NOM_FULLA_DADES).Range("_CODI_PROJECTE")
    '        For j = 1 To 150
    '            If xls(1, j) <> "" Then
    '                For i = 1 To 1000
    '                    If xls(i, 1) <> "" Then
    '                        If Left(xls(i, j).Formula, 1) <> "=" Then
    '                            xls(i, j) = getTempValue(xls(1, j), xls(i, 1))
    '                        End If
    '                    End If
    '                Next i
    '            End If
    '        Next j

    '        ' aqui cal tornar a posar les dades
    '        wb.Worksheets(NOM_FULLA_DADES).Range("a1") = mesActual
    '        wb.Worksheets(NOM_FULLA_DADES).Range("a2") = anyActual

    '        wb.Application.Calculation = XlCalculation.xlCalculationAutomatic
    '        Call fAvis.tancar()
    '        Call MISSATGES.DATA_UPDATED()
    '    End If
    '    wb = Nothing
    '    ws = Nothing
    '    xls = Nothing
    '    grups = Nothing
    '    G = Nothing
    '    SG = Nothing
    '    s = Nothing
    '    e = Nothing
    'End Sub
    'PROCEDIMENT/FUNCIÓ:
    'DESCRIPCIÓ:
    'AUTOR: XMARTI. 24/07/2016
    'ENTRADES:
    'SORTIDA:
    Public Sub actualitzarMes()
        Dim anymes As AnyMesos, i As Integer, wb As Workbook, m As Integer
        wb = getWorkbook()
        If wb IsNot Nothing Then
            anymes = DMesos.getDataGb
            If anymes IsNot Nothing Then
                For m = 1 To 12
                    If anymes.esActiu(m) Then
                        wb.Worksheets(NOM_FULLA_DADES).Range("A1") = m
                        Exit For
                    End If
                Next m
                wb.Worksheets(NOM_FULLA_DADES).Range("A2") = anymes.any
            End If
        Else
            Call ERRORS.ERR_NO_GB()
        End If
        wb = Nothing
    End Sub
    'PROCEDIMENT/FUNCIÓ:
    'DESCRIPCIÓ:
    'AUTOR: XMARTI. 24/07/2016
    'ENTRADES:
    'SORTIDA:
    Private Sub setEntradaLog(codi As tipusEntradaLog, titol As String, descripcio As String)
        Dim e As EntradaLog
        e = New EntradaLog
        e.codi = codi
        e.descripcio = descripcio
        e.titol = titol
        logActual.entrades.Add(e)
        e = Nothing
    End Sub
    'PROCEDIMENT/FUNCIÓ: clearDataDetalls (PROCEDIMENT PRINCIPAL)
    'DESCRIPCIÓ: Per borrar dades DETALL.
    'AMBIT: Públic. S'encarrega de demanar els centres i les dates (mes/any) del qual es volen esborrar les dades de DETALL.
    'AUTOR: XMARTI. 24/07/2016
    'ENTRADES: - (sub PRAL)
    'SORTIDA: - (sub PRAL)
    Public Sub ClearDataDetalls()
        Dim centres As CentresGB, c As Centre
        centres = dBorrarDades.getCentres()
        If centres IsNot Nothing Then
            For Each c In centres.centres
                If centres.totAny Then
                    Call removeData(c.id, -1, centres.anyActual)
                Else
                    Call removeData(c.id, centres.mesActual, centres.anyActual)
                End If
            Next c
            Call MISSATGES.DATA_UPDATED()
        End If
        Call resetIndex()
        centres = Nothing
        c = Nothing
    End Sub




    'PROCEDIMENT/FUNCIÓ: setTempDadesGB
    'DESCRIPCIÓ: Guarda les dades de la fulla DADESOMS, les dades estan disposades en files (subgrups) i columnes (centres). Per dir-ho d'una manera fa una foto
    '           de la fulla GB, llavors a l'hora de crear la plantilla podrem tornar a col.locar les dades
    'AMBIT: Local. es fa servir per crear/actualitzar la plantilla de dades
    'AUTOR: XMARTI. 24/07/2016
    'ENTRADES: Cursor de la fulla DADESOMS de la GB
    'SORTIDA: -
    'Private Sub setTempDadesGB(xls As Object)
    '    Dim i As Integer, j As Integer, dades(0 To 1000, 0 To 150) As String, ultimaFila As Integer, ultimaColumna As Integer
    '    ultimaFila = 1
    '    ultimaColumna = 1
    '    For i = 1 To UBound(dades, 1)
    '        If xls(i, 1) <> "" Then ultimaFila = i
    '        For j = 1 To UBound(dades, 2)
    '            If i = 1 Then If xls(1, j) <> "" Then ultimaColumna = j
    '            dades(i, j) = xls(i, j)
    '        Next j
    '    Next i
    '    ReDim tempDadesGB(0 To ultimaFila, 0 To ultimaColumna)
    '    For i = 1 To UBound(tempDadesGB, 1)
    '        For j = 1 To UBound(tempDadesGB, 2)
    '            tempDadesGB(i, j) = dades(i, j)
    '        Next j
    '    Next i

    'End Sub
    'PROCEDIMENT/FUNCIÓ: getTempValue
    'DESCRIPCIÓ: per cercar  un import d'un subgrupComptable d'un centre. Aquests imports estan guardats en la variable  (tempDadesGB)
    'AMBIT: Local. serveix per tornar a presentar les dades quan es crea o s'actualitza la plantilla de dades (DADESOMS)
    'AUTOR: XMARTI. 24/07/2016
    'ENTRADES: codiCentre i codiSubgrup dels valor cercat.
    'SORTIDA: VALOR
    'Private Function getTempValue(codiCentre As String, codiSubgrup As String) As Double
    '    Dim i As Integer, trobat As Boolean, posCentre As Integer, posGrup As Integer
    '    trobat = False
    '    posCentre = 0
    '    posGrup = 0
    '    getTempValue = 0

    '    If codiCentre <> "" And codiSubgrup <> "" Then
    '        If tempCodiCentre <> codiCentre Then
    '            For i = LBound(tempDadesGB, 2) To UBound(tempDadesGB, 2)
    '                If tempDadesGB(1, i) <> "" Then
    '                    If UCase(tempDadesGB(1, i)) = UCase(codiCentre) Then
    '                        posCentre = i
    '                        tempColumnaCentre = i
    '                        tempCodiCentre = codiCentre
    '                        Exit For
    '                    End If
    '                End If
    '            Next i
    '        Else
    '            posCentre = tempColumnaCentre
    '        End If
    '        If posCentre > 0 Then
    '            If tempCodiSubgrup <> codiSubgrup Then
    '                For i = LBound(tempDadesGB, 1) To UBound(tempDadesGB, 1)
    '                    If tempDadesGB(i, 1) <> "" Then
    '                        If UCase(tempDadesGB(i, 1)) = UCase(codiSubgrup) Then
    '                            posGrup = i
    '                            tempFilaSubgrup = i
    '                            tempCodiSubgrup = codiSubgrup
    '                            Exit For
    '                        End If
    '                    End If
    '                Next i
    '            Else
    '                posGrup = tempFilaSubgrup
    '            End If
    '            If posGrup > 0 Then
    '                If UBound(tempDadesGB, 1) >= posGrup And UBound(tempDadesGB, 2) >= posCentre Then
    '                    If IsNumeric(tempDadesGB(posGrup, posCentre)) Then getTempValue = tempDadesGB(posGrup, posCentre)
    '                End If
    '            End If
    '        End If
    '    End If
    'End Function
    'PROCEDIMENT/FUNCIÓ: getWorkbook
    'DESCRIPCIÓ: cerca un fitxer GB, que estigui obert. Per fer-ho comprova que existeixi la fulla DADESOMS dins els fitxers workbooks oberts en el moment.
    'ÀMBIT: LOCAL, es fa servir per cercar un workbook i comprovar que estigui obert, abans d'obrir-lo. (per no tornar-lo a obrir en cas que ho estigui)
    'AUTOR: XMARTI. 24/07/2016
    'ENTRADES: -
    'SORTIDA: workbook (llibre GB), en cas que existeixi, sinò retorna NOTHING
    Private Function getWorkbook() As Workbook
        Dim wb As Workbook, ws As Worksheet, wbs As New Application
        getWorkbook = Nothing
        For Each wb In wbs.Workbooks
            For Each ws In wb.Worksheets
                If UCase(ws.Name) = NOM_FULLA_DADES Then
                    getWorkbook = wb
                    Exit For
                End If
            Next ws
            If getWorkbook IsNot Nothing = "WORKBOOK" Then Exit For
        Next wb
        wb = Nothing
        wbs = Nothing
    End Function
    'PROCEDIMENT/FUNCIÓ: setcodiSubgrups
    'DESCRIPCIÓ: Guarda en memòria (variable: codiSubgrups) la posiciió dels diferents subgrups dins la fulla DADESOMS de la GB (XLS)
    'AUTOR: XMARTI. 24/07/2016
    'ENTRADES: cursor de la fulla GB, on cal cercar els subgrups.
    'SORTIDA: -
    Private Sub setcodis(ws As Worksheet)
        Dim i As Integer, blancs As Integer, xls As Object
        xls = ws.Range(RANG_CODI_SUBGRUPS)
        blancs = 0
        For i = 1 To UBound(codiSubgrups)
            If xls(i, 1).text <> "" Then
                codiSubgrups(i) = xls(i, 1).text
                blancs = 0
            Else
                blancs = blancs + 1
            End If
            If blancs = 20 Then Exit For
        Next
        xls = ws.Range(RANG_CODI_CENTRES)
        blancs = 0
        For i = 1 To UBound(codiCentres)
            If xls(1, i).text <> "" Then
                codiCentres(i) = xls(1, i).text
                blancs = 0
            Else
                blancs = blancs + 1
            End If
            If blancs = 20 Then Exit For
        Next
    End Sub
    Private Function getidSubgrupMax(subgrups As List(Of Subgrup)) As Integer
        Dim i As Integer, sg As Subgrup
        i = 0
        For Each sg In subgrups
            If sg.id > i Then i = sg.id
        Next
        Return i
    End Function
    ''PROCEDIMENT/FUNCIÓ: setPosInfoGB
    ''DESCRIPCIÓ: Guarda en memòria la posició de les dades de informació de l'exportació de dades
    ''AUTOR: XMARTI. 24/07/2016
    ''ENTRADES: Cursor de la fulla GB DADESOMS
    ''SORTIDA: -
    'Private Sub setPosInfoGB(xls As Object)
    '    Dim tag As String, i As Integer, m As Integer, j As Integer
    '    tag = DADES_DE
    '    For m = 1 To 12
    '        j = 0
    '        For i = 1 To 1000
    '            If xls(i, 1).text = m & DADES_DE Then
    '                posInfoGB(1, m) = i
    '                j = j + 1
    '            ElseIf xls(i, 1).text = m & ACTUALITZADES Then
    '                posInfoGB(2, m) = i
    '                j = j + 1
    '            ElseIf xls(i, 1).text = m & ACTUALITZADES_PER Then
    '                posInfoGB(3, m) = i
    '                j = j + 1
    '            ElseIf xls(i, 1).text = m & PARTICIPACIO_TITOL Then
    '                posInfoGB(4, m) = i
    '                j = j + 1
    '            End If
    '            If j = 4 Then Exit For
    '        Next i
    '    Next m
    'End Sub
    ''PROCEDIMENT/FUNCIÓ: getPOsInfoGB
    ''DESCRIPCIÓ: cerca la posició dins la fulla DADESOMS de la GB
    ''AUTOR: XMARTI. 24/07/2016
    ''ENTRADES: mes: mes on cal cercar, tag: tipus de dades que es cerca
    ''SORTIDA: posició (fila) on està disposada la informació, dins la fulla DADESOMS.
    'Private Function getPosInfoGB(mes As Integer, tag As String) As Integer
    '    getPosInfoGB = 0


    '    Select Case tag
    '        Case DADES_DE
    '            getPosInfoGB = posInfoGB(1, mes)
    '        Case ACTUALITZADES
    '            getPosInfoGB = posInfoGB(2, mes)
    '        Case ACTUALITZADES_PER
    '            getPosInfoGB = posInfoGB(3, mes)
    '        Case PARTICIPACIO_TITOL
    '            getPosInfoGB = posInfoGB(4, mes)
    '    End Select
    'End Function



    Private Function getDataTransitoria(empresaActual As Empresa, centres As List(Of Centre), anyoActual As Integer, mesos() As Boolean) As List(Of Centre)
        Dim i As Integer, m As Integer, c As Centre, ims As ImportMesSubgrup, SG As Subgrup, contaplusActual As Contaplus
        Dim fAvis As frmAvis
        getDataTransitoria = New List(Of Centre)
        fAvis = New frmAvis(IDIOMA.getString("importantDades"), IDIOMA.getString("importantDadesDe"), "-")
        Call ModelTransitoria.resetIndex()
        Call ModulActualitzacioGB.resetIndex()
        Call ModelDiario.resetIndex()
        Call ModelCentre.resetIndex()
        Call ModelProjecteCentre.resetIndex()
        Call ModelProjecte.resetIndex()
        Call ModelSubcompte.resetIndex()
        Call ModelSubcomptesGrup.resetIndex()
        contaplusActual = ModelEmpresaContaplus.getObjectByEmpresaAny(empresaActual.id, anyoActual)
        i = 1
        For Each c In centres
            c.ordre = c.idSeccio & c.ordre
            fAvis.setData(IDIOMA.getString("importantDadesDe"), c.nom, i & " " & IDIOMA.getString("de") & " " & centres.Count)
            For m = 1 To 12
                If mesos(m) Then
                    If ModelEstatMes.getEstat(empresaActual.id, anyoActual, m) Then
                        For Each ims In ModulActualitzacioGB.getValuesMes(c.id, anyoActual, m)
                            c.importsSubgrups.Add(ims)
                        Next ims
                    ElseIf existCentreMes(anyoActual, c.id, m) ' saber si hi ha valors Detall. 
                        For Each ims In ModulActualitzacioGB.getValuesMes(c.id, anyoActual, m)
                            c.importsSubgrups.Add(ims)
                        Next ims
                    Else
                        For Each SG In ModelPretancament.getImportsSubgrupCentre(ModelPretancament.getObject(empresaActual, contaplusActual, c.id, anyoActual, m))
                            ims = New ImportMesSubgrup
                            ims.anyo = anyoActual
                            ims.idCentre = c.id
                            ims.idSubgrup = SG.id
                            ims.codiGrup = m & SG.codi
                            ims.mes = m
                            ims.valor = SG.saldoPretancament
                            ims.isPretancament = True
                            ims.tipusDades = "PRE."
                            c.importsSubgrups.Add(ims)
                        Next SG
                    End If
                End If
            Next m
            getDataTransitoria.Add(c)
            i = i + 1
        Next c
        fAvis.tancar()
        c = Nothing
        ims = Nothing
        SG = Nothing
        fAvis = Nothing
    End Function
    Private Sub SetRemoteObjects(a As Integer)
        Call resetIndex()
        objects = dbActualitzacioGB.getObjects(a)
        indexCarregat = True
        dateUpdate = Now
    End Sub
End Module
