﻿Option Explicit On

Module CONFIG
    Private Const SQL As String = "1"
    Private Const DBF As String = "2"

    Public Enum tipusAplicacio
        detall = 1
        expram
        mant
        gbHuguet
    End Enum
    Public Enum tipusEntradaLog
        MIS_LOG = 1
        AVIS_log = 2
        ERR_LOG = 3
    End Enum
    Public Enum tipusExportBudget
        GB = 1
        man = 2
        VOSS = 3
    End Enum

    Private Const NOM_FITXER_SIGNATURA_CORREU As String = "signEmail.txt"
    Private Const PLANTILLA_RESUM_SUBCOMPTE_COMPRES As String = "plantillaSubcomptesCompres.xlsx"
    Private Const PLANTILLA_COMANDES As String = "plantillaComandes.xlsx"
    Private Const PLANTILLA As String = "plantilles"
    Private Const PLANTILLA_INFO_ARTICLES_COMANDES As String = "plantillaArticlesComandes.xlsx"
    Private Const PLANTILLA_F56 As String = "plantillaF56.xls"
    Private Const PLANTILLA_INFO_ARTICLES As String = "plantillaArticles.xlsx"
    Private Const PLANTILLA_INFO_ARTICLE As String = "plantillaArticle.xlsx"
    Private Const PLANTILLA_INFO_AUXILIAR As String = "plantillaAuxiliar.xlsx"
    Private Const PLANTILLA_INFO_TIPUS_IVA As String = "plantillaTipusIva.xlsx"
    Private Const PLANTILLA_INFO_TIPUS_PAGAMENT As String = "plantillaTipusPagament.xlsx"
    Private Const PLANTILLA_INFO_PAIS As String = "plantillaPais.xlsx"
    Private Const PLANTILLA_INFO_LLOC_ENTREGA As String = "plantillaLlocEntrega.xlsx"
    Private Const PLANTILLA_INFO_LLOCS_ENTREGA As String = "plantillaLlocsEntrega.xlsx"
    Private Const PLANTILLA_INFO_PROVEIDOR As String = "plantillaProveidor.xlsx"
    Private Const PLANTILLA_INFO_PROVEIDORS As String = "plantillaProveidors.xlsx"
    Private Const PLANTILLA_LLIBRE_MAJOR As String = "plantillaLlibreMajor.xls"
    Private Const RUTA_APLICACIO As String = "C:\APLIXM_OMS_SACEDE"
    Private Const RUTA_EXPORTACIO_DBF As String = "EXPORT_DBF"
    Private Const RUTA_EXPORTACIO_DEPARTAMENTS As String = "EXPORT_PROJECTES_DEPARTAMENT"
    Private Const RUTA_FITXERS_ESTADISTIQUES As String = "FITXERS_ESTADISTIQUES"
    Private Const NOM_FITXER_DIARI As String = "DIA"
    Private Const NOM_FITXER_SUBCTA As String = "SCT"
    Private Const NOM_FITXER_PROYE As String = "PRO"
    Private Const TROS_PATH_SERVER As String = "\BD_APLI_OMS_SACEDE"
    Private Const CODI_ZAMORA As String = "ZAM"
    Private Const CODI_ANDORRA As String = "AND"
    Private Const FOLDER_FITXERS_VOSS As String = "EXPORTACIO_FITXERS_VOSS"
    Private Const MENU_WORKSHEET As String = "Worksheet Menu Bar"
    Private Const RUTA_MACROS As String = "APLI_MACROS"
    Private Const RUTA_DADES_MACROS As String = "APLI_MACROS"
    Private Const RUTA_DADES_MACROS_LLIBRE_MAJOR As String = "LLIBRE_MAJOR"
    Private Const RUTA_DADES_MACROS_LLIBRE_MAJOR_SUBCOMPTES As String = "SUBCOMPTES"
    Private Const RUTA_DIRECTORI_FITXERS_TRANSITORIES As String = "FITXERS_TRANSITORIA_PROJECTES"
    Private Const NOM_FITXER_CODI_COMANDES As String = "codiComandes.txt"
    Private Const TEMP As String = "TEMP"
    Public Function fileExist(path As String) As Boolean
        Return System.IO.File.Exists(path)
    End Function
    Public Function folderExist(path As String) As Boolean
        Return System.IO.Directory.Exists(path)
    End Function
    Public Function isRutaServer(path As String) As Boolean
        isRutaServer = False
        If InStr(1, path, TROS_PATH_SERVER, vbTextCompare) <> 0 Then
            If Left(LCase(path), 2) <> "c:" Or Left(LCase(path), 2) <> "d:" Then
                isRutaServer = True
            End If
        End If
    End Function
    Public Function getRutaPlantilles() As String
        Dim ruta As String
        ruta = setFolder(DBCONNECT.getRutaDBActual)
        ruta = ruta & setFolder(PLANTILLA)
        Return ruta
    End Function

    Public Function getPlantillaLlibreMajor() As String
        getPlantillaLlibreMajor = PLANTILLA_LLIBRE_MAJOR
    End Function
    Public Function getPlantillaProveidors() As String
        getPlantillaProveidors = PLANTILLA_INFO_PROVEIDORS
    End Function

    Public Function getPlantillaLlocsEntrega() As String
        getPlantillaLlocsEntrega = PLANTILLA_INFO_LLOCS_ENTREGA
    End Function
    Public Function getPlantillaLlocEntrega() As String
        getPlantillaLlocEntrega = PLANTILLA_INFO_LLOC_ENTREGA
    End Function
    Public Function getPlantillaProveidor() As String
        getPlantillaProveidor = PLANTILLA_INFO_PROVEIDOR
    End Function
    Public Function getRutaPlantillaProveidors() As String
        Return setFolder(getRutaPlantilles) & getPlantillaProveidors()
    End Function
    Public Function getPlantillaTipusPagament() As String
        Return PLANTILLA_INFO_TIPUS_PAGAMENT
    End Function
    Public Function getPlantillaPais() As String
        Return PLANTILLA_INFO_PAIS
    End Function
    Public Function getPlantillaTipusIva() As String
        Return PLANTILLA_INFO_TIPUS_IVA
    End Function
    Public Function getPlantillaAuxiliar() As String
        Return PLANTILLA_INFO_AUXILIAR
    End Function
    Public Function getPlantillaArticles() As String
        Return PLANTILLA_INFO_ARTICLES
    End Function
    Public Function getPlantillaArticlescOMANDES() As String
        Return PLANTILLA_INFO_ARTICLES_COMANDES
    End Function
    Public Function getPlantillaArticle() As String
        Return PLANTILLA_INFO_ARTICLE
    End Function
    Public Function getPlantillaF56() As String
        Return PLANTILLA_F56
    End Function
    Public Function getRutaPlantillaProveidor() As String
        Return setFolder(getRutaPlantilles) & getPlantillaProveidor()
    End Function
    Public Function getPlantillaResumCompres()
        Return PLANTILLA_RESUM_SUBCOMPTE_COMPRES
    End Function
    Public Function getRutaPlantillaResumSubcompteCompres() As String
        Return setFolder(getRutaPlantilles) & getPlantillaResumCompres()
    End Function
    Public Function getPlantillaComandes() As String
        Return PLANTILLA_COMANDES
    End Function
    Public Function getRutaPlantillaComandes() As String
        Return setFolder(getRutaPlantilles) & getPlantillaComandes()
    End Function
    Public Function getRutaPlantillaLlocsEntrega() As String
        Return setFolder(getRutaPlantilles) & getPlantillaLlocsEntrega()
    End Function
    Public Function getRutaPlantillaLlocEntrega() As String
        Return setFolder(getRutaPlantilles) & getPlantillaLlocEntrega()
    End Function
    Public Function getRutaPlantillaPais() As String
        Return setFolder(getRutaPlantilles) & getPlantillaPais()
    End Function
    Public Function getRutaPlantillaTipusIva() As String
        Return setFolder(getRutaPlantilles) & getPlantillaTipusIva()
    End Function
    Public Function getRutaPlantillaTipusPagament() As String
        Return setFolder(getRutaPlantilles) & getPlantillaTipusPagament()
    End Function
    Public Function getRutaPlantillaAuxiliar() As String
        Return setFolder(getRutaPlantilles) & getPlantillaAuxiliar()
    End Function
    Public Function getRutaPlantillaArticles() As String
        Return setFolder(getRutaPlantilles) & getPlantillaArticles()
    End Function
    Public Function getRutaPlantillaArticlesComandes() As String
        Return setFolder(getRutaPlantilles) & getPlantillaArticlescOMANDES()
    End Function
    Public Function getRutaPlantillaArticle() As String
        Return setFolder(getRutaPlantilles) & getPlantillaArticle()
    End Function
    Public Function getRutaPlantillaf56() As String
        Return setFolder(getRutaPlantilles) & getPlantillaF56()
    End Function
    Public Function getDirectori(ruta As String) As String
        Dim i As Integer
        For i = Len(ruta) To 1 Step -1
            If Mid(ruta, i, 1) = "\" Or Mid(ruta, i, 1) = "/" Then
                Exit For
            End If
        Next i
        getDirectori = Left(ruta, i)
    End Function
    Public Function getFitxer(ruta As String) As String
        Dim i As Integer, temp As String = ""
        For i = Len(ruta) To 1 Step -1
            If Mid(ruta, i, 1) <> "\" And Mid(ruta, i, 1) <> "/" Then
                temp = Mid(ruta, i, 1) & temp
            Else
                Exit For
            End If
        Next i
        getFitxer = temp
    End Function

    ' TODO: FALTA CREAR ELS MODULS 
    Public Function actualtizarWorkooks(Optional grups As Boolean = False, Optional projectes As Boolean = False, Optional mesos As Boolean = False) As Boolean
        'Dim wb As EXCEL.Workbook, wbs As EXCEL.Workbooks
        'actualtizarWorkooks = False
        'If existConnectDB() Then
        '    'ens cal actualitzar els subGrups
        '    For Each wb In wbs
        '        Select Case UCase(wb.CodeName)
        '            Case "WBREGULARITZACIOV6" : actualtizarWorkooks = ModulActualitzacioDETALL.actualitzar(wb, grups, projectes, mesos)
        '            Case "WBEXPRAMV2" : actualtizarWorkooks = ModulActualitzacioEXPRAM.actualitzar(wb)
        '        End Select
        '    Next wb

        'End If
        'wb = Nothing
    End Function
    'TODO CAL VEURE, COM CANVIAR LA SEVA FUNCIONALITAT
    'Public Function existConnectDB(Optional tempRuta As String) As Boolean
    '    Dim taules As String, ruta As String
    '    existConnectDB = True
    '    If Len(tempRuta) > 0 Then
    '        ruta = tempRuta
    '    Else
    '        ruta = CONFIG_RUTES.getRutaServidorDades
    '    End If
    '    If Not dades.isLocal Then
    '        If Not CONFIG.folderExist(ruta) Then
    '            Call ERROR.ERR_RUTA_SERVIDOR
    '        existConnectDB = False
    '        Else
    '            taules = CONFIG.existTaulesDades(ruta)
    '            If taules <> "" Then
    '                Call ERROR.ERR_TAULES(taules)
    '            existConnectDB = False
    '            End If
    '        End If

    '    Else
    '        If Not CONFIG.folderExist(CONFIG.getDirectoriBDLocal) Then
    '            Call ERROR.ERR_RUTA_SERVIDOR_LOCAL
    '    Else
    '            taules = CONFIG.existTaulesDades(ruta)

    '            If taules <> "" Then
    '                Call ERROR.ERR_TAULES(taules, True)
    '            existConnectDB = False
    '            End If
    '        End If
    '    End If
    'End Function

    Public Function mesNom(m As Integer) As String
        mesNom = ""
        Select Case m
            Case 1 : mesNom = IDIOMA.getString("gener")
            Case 2 : mesNom = IDIOMA.getString("febrer")
            Case 3 : mesNom = IDIOMA.getString("març")
            Case 4 : mesNom = IDIOMA.getString("abril")
            Case 5 : mesNom = IDIOMA.getString("maig")
            Case 6 : mesNom = IDIOMA.getString("juny")
            Case 7 : mesNom = IDIOMA.getString("juliol")
            Case 8 : mesNom = IDIOMA.getString("agost")
            Case 9 : mesNom = IDIOMA.getString("setembre")
            Case 10 : mesNom = IDIOMA.getString("octubre")
            Case 11 : mesNom = IDIOMA.getString("novembre")
            Case 12 : mesNom = IDIOMA.getString("decembre")
        End Select
    End Function

    Public Function getDirectoriAplicacio() As String
        Dim ruta As String
        ruta = RUTA_APLICACIO
        If Not CONFIG.folderExist(ruta) Then MkDir(ruta)
        getDirectoriAplicacio = ruta
    End Function
    Public Function getDirectoriPredeterminatFitxersVoss() As String
        Dim ruta As String
        ruta = setFolder(getDirectoriAplicacio())
        ruta = setFolder(ruta & FOLDER_FITXERS_VOSS)
        If Not folderExist(ruta) Then MkDir(ruta)
        getDirectoriPredeterminatFitxersVoss = ruta
    End Function

    Public Function getdirectoriLogAplicacio() As String
        Dim ruta As String
        ruta = getDirectoriAplicacio() & "\logs"
        If Not CONFIG.folderExist(ruta) Then MkDir(ruta)
        getdirectoriLogAplicacio = ruta
    End Function
    Public Function getDirectoriBDLocal() As String
        Dim ruta As String
        ruta = getDirectoriAplicacio() & "\BD_LOCAL_APLI_OMS"
        If Not CONFIG.folderExist(ruta) Then MkDir(ruta)
        getDirectoriBDLocal = ruta
    End Function

    Public Function getRutaBDRemote(Optional nomTaula As String = "") As String
        getRutaBDRemote = DBCONNECT.getRutaDBActual
        If Right(getRutaBDRemote, 1) <> "\" Then getRutaBDRemote = getRutaBDRemote & "\"
        getRutaBDRemote = getRutaBDRemote & nomTaula
    End Function

    Public Function getRutaComandesImportades() As String
        Dim rutaDb As String
        rutaDb = setSeparator(CONFIG_FILE.getTag(TAG.RUTA_FITXERS_SOLICITUT))
        If folderExist(rutaDb) Then
            rutaDb = rutaDb & "IMPORTADES\"
            If Not folderExist(rutaDb) Then Call MkDir(rutaDb)
            Return rutaDb
        End If
        Return Nothing
    End Function
    Public Function getDirectoriAssentaments() As String

        getDirectoriAssentaments = setFolder(getDirectoriAplicacio())
        getDirectoriAssentaments = getDirectoriAssentaments & "assentaments"
    End Function
    Public Function getDateFileModified(f As String) As Date
        'System.IO.File.GetLastWriteTime(strFilepath & File.ToString()).ToShortDateString()
        'Dim fs As Object
        'fs = CreateObject("Scripting.FileSystemObject")

        'getDateFileModified = Format(fs.GETFILE(f).DateLastModified, "dd-mm-yy hh:nn")
        'fs = Nothing
        Return System.IO.File.GetLastWriteTime(f)
    End Function

    Public Function isMonth(m As Integer, nom As String) As Boolean
        Dim noms As String(), i As Integer
        noms = getNomMes(m)
        isMonth = False
        For i = LBound(noms) To UBound(noms)
            If InStr(1, noms(i), nom, vbTextCompare) > 0 Then
                isMonth = True
                Exit For
            End If
        Next i
    End Function

    Public Function getNomMes(i As Integer) As String()
        getNomMes = {""}
        Select Case i
            Case 1 : getNomMes = {"gener", "enero", "january", "jan"}
            Case 2 : getNomMes = {"febrer", "febrero", "february", "feb"}
            Case 3 : getNomMes = {"març", "marzo", "mrz", "mar", "march"}
            Case 4 : getNomMes = {"abril", "april", "apr", "abr"}
            Case 5 : getNomMes = {"maig", "mayo", "mai", "may"}
            Case 6 : getNomMes = {"juny", "junio", "jun", "june"}
            Case 7 : getNomMes = {"juliol", "julio", "jul", "july"}
            Case 8 : getNomMes = {"agost", "agosto", "aug", "august"}
            Case 9 : getNomMes = {"setembre", "septiembre", "septiembre", "septembre", "september", "setember", "set", "sept", "sep"}
            Case 10 : getNomMes = {"octubre", "october", "okt", "oct"}
            Case 11 : getNomMes = {"novembre", "noviembre", "november", "nov"}
            Case 12 : getNomMes = {"desembre", "decembre", "diciembre", "december", "dec", "dez"}
        End Select
    End Function
    Public Function getUcaseTrim(t As String) As String
        Dim i As Integer
        getUcaseTrim = ""
        For i = 1 To Len(t)
            If Not Mid(t, i, 1) = " " Then getUcaseTrim = getUcaseTrim & UCase(Mid(t, i, 1))
        Next i
    End Function
    Public Function getDirectoriPredeterminatExportDBF() As String
        getDirectoriPredeterminatExportDBF = setFolder(CONFIG.getDirectoriAplicacio)
        getDirectoriPredeterminatExportDBF = getDirectoriPredeterminatExportDBF & RUTA_EXPORTACIO_DBF
        If Not folderExist(getDirectoriPredeterminatExportDBF) Then Call MkDir(getDirectoriPredeterminatExportDBF)
    End Function
    Public Function getDirectoriPredeterminatExportDepartaments() As String
        getDirectoriPredeterminatExportDepartaments = setFolder(CONFIG.getDirectoriAplicacio)
        getDirectoriPredeterminatExportDepartaments = getDirectoriPredeterminatExportDepartaments & RUTA_EXPORTACIO_DEPARTAMENTS
        If Not folderExist(getDirectoriPredeterminatExportDepartaments) Then Call MkDir(getDirectoriPredeterminatExportDepartaments)
    End Function
    Public Function getDirectoriFitxersTransitories() As String
        getDirectoriFitxersTransitories = setFolder(CONFIG.getDirectoriAplicacio)
        getDirectoriFitxersTransitories = getDirectoriFitxersTransitories & RUTA_DIRECTORI_FITXERS_TRANSITORIES
        If Not folderExist(getDirectoriFitxersTransitories) Then Call MkDir(getDirectoriFitxersTransitories)
    End Function
    Public Function getDirectoriPredeterminatFitxersEstadistiques() As String

        getDirectoriPredeterminatFitxersEstadistiques = setFolder(CONFIG.getDirectoriAplicacio)
        getDirectoriPredeterminatFitxersEstadistiques = getDirectoriPredeterminatFitxersEstadistiques & RUTA_FITXERS_ESTADISTIQUES
        If Not folderExist(getDirectoriPredeterminatFitxersEstadistiques) Then Call MkDir(getDirectoriPredeterminatFitxersEstadistiques)
    End Function
    Public Function getDirectoriPredeterminatInformes() As String
        Dim ruta As String
        ruta = setFolder(CONFIG.getDirectoriAplicacio)
        ruta = ruta & "INFORMES\"
        If Not folderExist(ruta) Then Call MkDir(ruta)
        Return ruta
    End Function
    Public Function getEspais(texte As String, espais As Integer, esquerra As Boolean)
        Dim i As Integer
        If espais > Len(texte) Then
            getEspais = texte
            For i = 1 To espais
                If esquerra Then
                    getEspais = getEspais & "."
                Else
                    getEspais = "." & getEspais
                End If
            Next i
        Else
            If esquerra Then
                getEspais = Left(texte, espais)
            Else
                getEspais = Right(texte, espais)
            End If
        End If
    End Function
    Public Function getCodiZamora() As String
        getCodiZamora = CODI_ZAMORA
    End Function
    Public Function getCodiAndorra() As String
        getCodiAndorra = CODI_ANDORRA
    End Function
    Public Function getPathDiarioContaplus(eConta As String) As String
        getPathDiarioContaplus = setFolder(CONFIG_FILE.getTag(TAG.RUTA_CONTAPLUS))
        getPathDiarioContaplus = getPathDiarioContaplus & eConta & "\diario.dbf"
    End Function
    Public Function getPathSubctaContaplus(eConta As String) As String
        getPathSubctaContaplus = setFolder(CONFIG_FILE.getTag(TAG.RUTA_CONTAPLUS))
        getPathSubctaContaplus = getPathSubctaContaplus & eConta & "\subcta.dbf"
    End Function
    Public Function getPathProyeContaplus(eConta As String) As String
        getPathProyeContaplus = setFolder(CONFIG_FILE.getTag(TAG.RUTA_CONTAPLUS))
        getPathProyeContaplus = getPathProyeContaplus & eConta & "\proye.dbf"
    End Function
    Public Function getPathDiarioServidor(codiEmpresa As String, anyo As Integer) As String
        getPathDiarioServidor = setFolder(CONFIG_FILE.getTag(TAG.RUTA_SERVIDOR_DADES)) & codiEmpresa & "\"
        If Not CONFIG.folderExist(getPathDiarioServidor) Then MkDir(getPathDiarioServidor)
        getPathDiarioServidor = getPathDiarioServidor & NOM_FITXER_DIARI & Right(anyo, 2) & ".dbf"
    End Function
    Public Function getPathSubctaServidor(codiEmpresa As String, anyo As Integer) As String
        getPathSubctaServidor = setFolder(CONFIG_FILE.getTag(TAG.RUTA_SERVIDOR_DADES)) & codiEmpresa & "\"
        If Not CONFIG.folderExist(getPathSubctaServidor) Then MkDir(getPathSubctaServidor)
        getPathSubctaServidor = getPathSubctaServidor & NOM_FITXER_SUBCTA & Right(anyo, 2) & ".dbf"
    End Function
    Public Function getPathProyeServidor(codiEmpresa As String, anyo As Integer) As String
        getPathProyeServidor = setFolder(CONFIG_FILE.getTag(TAG.RUTA_SERVIDOR_DADES)) & codiEmpresa & "\"
        If Not CONFIG.folderExist(getPathProyeServidor) Then MkDir(getPathProyeServidor)
        getPathProyeServidor = getPathProyeServidor & NOM_FITXER_PROYE & Right(anyo, 2) & ".dbf"
    End Function
    Public Function getPathDiarioLocal(codiEmpresa As String, anyo As Integer) As String
        getPathDiarioLocal = setFolder(CONFIG.getDirectoriBDLocal) & codiEmpresa & "\"
        If Not CONFIG.folderExist(getPathDiarioLocal) Then MkDir(getPathDiarioLocal)
        getPathDiarioLocal = getPathDiarioLocal & NOM_FITXER_DIARI & Right(anyo, 2) & ".dbf"
    End Function
    Public Function getPathSubctaLocal(codiEmpresa As String, anyo As Integer) As String
        getPathSubctaLocal = setFolder(CONFIG.getDirectoriBDLocal) & codiEmpresa & "\"
        If Not CONFIG.folderExist(getPathSubctaLocal) Then MkDir(getPathSubctaLocal)
        getPathSubctaLocal = getPathSubctaLocal & NOM_FITXER_SUBCTA & Right(anyo, 2) & ".dbf"
    End Function
    Public Function getPathProyeLocal(codiEmpresa As String, anyo As Integer) As String
        getPathProyeLocal = setFolder(CONFIG.getDirectoriBDLocal) & codiEmpresa & "\"
        If Not CONFIG.folderExist(getPathProyeLocal) Then MkDir(getPathProyeLocal)
        getPathProyeLocal = getPathProyeLocal & NOM_FITXER_PROYE & Right(anyo, 2) & ".dbf"
    End Function
    Public Function getFitxerAjuda() As String
        Dim ruta As String, nom As String, fitxer As String = ""
        ruta = setFolder(CONFIG.getDirectoriBDLocal)
        nom = Dir(ruta & ".*pdf", vbArchive)
        Do While nom <> ""
            If InStr(1, nom, "ajuda", vbTextCompare) <> 0 Then
                fitxer = nom
                Exit Do
            End If
            nom = Dir()
        Loop
        getFitxerAjuda = ruta & fitxer
    End Function

    Public Function filtrar(llista(,) As String, textFiltre As String) As String(,)
        Dim i As Integer, j As Integer, temp(,) As String, k As Integer, m As Integer
        Dim temp1(,) As String
        ReDim temp(UBound(llista, 1), UBound(llista, 2))
        m = LBound(llista, 1)
        For i = LBound(llista, 1) To UBound(llista, 1)
            For j = LBound(llista, 2) To UBound(llista, 2)
                If InStr(1, llista(i, j), textFiltre, vbTextCompare) <> 0 Then
                    For k = LBound(llista, 2) To UBound(llista, 2)
                        temp(m, k) = llista(i, k)
                    Next k
                    m = m + 1
                    Exit For
                End If
            Next j
        Next i
        If m > LBound(llista, 1) Then
            ReDim temp1(m - 1, UBound(llista, 2))
            For i = LBound(temp1, 1) To UBound(temp1, 1)
                For j = LBound(temp1, 2) To UBound(temp1, 2)
                    temp1(i, j) = temp(i, j)
                Next j
            Next i
        Else
            ReDim temp1(0, 0)
        End If
        filtrar = temp1
    End Function
    Public Function getTabulacio(t As String, espais As Integer, esquerra As Boolean) As String
        Dim i As Integer
        getTabulacio = ""
        For i = Len(t) To espais
            getTabulacio = getTabulacio & "-->"
        Next i
        If esquerra Then
            getTabulacio = t & getTabulacio
        Else
            getTabulacio = getTabulacio & t
        End If
    End Function
    Public Function esNull(t As String) As Boolean
        If t Is Nothing Then
            esNull = True
        ElseIf UCase(t) = "NULO" Then
            esNull = True
        ElseIf t = "" Then
            esNull = True
        Else
            esNull = False
        End If
    End Function
    Public Function validarApostrof(t As String) As String
        Dim i As Integer
        validarApostrof = ""
        For i = 1 To Len(t)
            If Mid(t, i, 1) = "'" Then validarApostrof = validarApostrof & "'"
            validarApostrof = validarApostrof & Mid(t, i, 1)
        Next i
    End Function
    Public Function validarBoolean(t As String) As Boolean
        If UCase(Left(t, 1)) = "V" Then Return True
        If UCase(Left(t, 1)) = "T" Then Return True
        Return False
    End Function
    Public Function validarNull(t) As String
        If t Is Nothing OrElse t.GetType.Name = "DBNull" Then Return ""
        Return Trim(t)
    End Function
    Public Function validarNullDate(t) As Date
        If t Is Nothing OrElse t.GetType.Name = "DBNull" Then Return DateSerial(0, 0, 0)
        Return Trim(t)
    End Function
    Public Function setFolder(ruta As String) As String
        If Right(ruta, 1) <> "\" Then Return ruta & "\"
        Return ruta
    End Function
    Public Function setDbf(ruta As String) As String
        If Right(ruta, 4) <> ".dbf" Then Return ruta & ".dbf"
        Return ruta
    End Function


    Public Sub resetDades()
        Dim dAvis As frmAvis
        dAvis = New frmAvis(IDIOMA.getString("resetDades"), IDIOMA.getString("resetIndex"), "-")
        Call DBCONNECT.close()
        Call ModelEmpresa.resetIndex()
        Call ModelSeccio.resetIndex()
        Call ModelCentre.resetIndex()
        Call ModelClient.resetIndex()
        Call ModelColumna.resetIndex()
        Call ModelColumnaFilla.resetIndex()
        Call ModelDepartament.resetIndex()
        Call ModelDiario.resetIndex()
        Call ModelEmpresaContaplus.resetIndex()
        Call ModelEstatMes.reset()
        Call ModelGrup.resetIndex()
        Call ModelPrefixSubcompte.resetIndex()
        Call ModelProjecte.resetIndex()
        Call ModelProjecteClient.resetIndex()
        Call ModelProjecteColumna.resetIndex()
        Call ModelSeccio.resetIndex()
        Call ModelSeccioGrup.resetIndex()
        Call ModelSubcompte.resetIndex()
        Call ModelSubcomptePretancament.resetIndex()
        Call ModelSubcomptesGrup.resetIndex()
        Call ModelSubcompteZamora.resetIndex
        Call ModelSubgrup.resetIndex()
        Call ModelTransitoria.resetIndex()
        Call ModelBudget.resetIndex()
        Call ModelYSheet.resetIndex()
        Call ModelTresoreria.resetIndex()
        Call ModelProveidorContaplus.resetIndex()
        Call ModelPais.resetIndex()
        Call ModelTipusPagament.resetIndex()
        Call ModelProjecteContacte.resetIndex()
        Call ModelProveidorAnotacio.resetIndex()
        Call ModelProveidorContacte.resetIndex()
        Call ModelProvincia.resetIndex()
        Call ModelTipusIva.resetIndex()
        Call ModelArticle.resetIndex()
        Call ModelFamilia.resetIndex()
        Call ModelFabricant.resetIndex()
        Call ModelUnitat.resetIndex()
        Call ModelTipusIva.resetIndex()
        Call ModelTipusPagament.resetIndex()
        Call ModelDocumentacio.resetIndex()
        Call ModelComanda.resetIndex()
        Call ModelComandaEnEdicio.resetIndex()
        Call dAvis.setData(IDIOMA.getString("resetDades"), IDIOMA.getString("actualitzaWorkBooks"))
        Call CONFIG.actualtizarWorkooks(True, True, True)

        Call CONFIG_PARAM_SERVER.resetIndex()
        Call dAvis.tancar()
        dAvis = Nothing
        GC.Collect()
        Call EXCEL.LiberarMemoria()
    End Sub
    Public Function getListObjects(objectes) As Object()
        Dim obj As Object, i As Integer = 0, temp() As Object
        ReDim temp(objectes.Count - 1)
        For Each obj In objectes
            temp(i) = obj
            i = i + 1
        Next
        getListObjects = temp
        temp = Nothing
        obj = Nothing
    End Function
    Public Function getTipusEntradaLog(t As tipusEntradaLog) As String
        Select Case t
            Case tipusEntradaLog.AVIS_log
                Return IDIOMA.getString("avisLog")
            Case tipusEntradaLog.ERR_LOG
                Return IDIOMA.getString("errLog")
            Case tipusEntradaLog.MIS_LOG
                Return IDIOMA.getString("missatgeLog")
        End Select
        Return ""
    End Function
    Public Function getRutaApliMacros() As String
        Dim ruta As String
        ruta = setFolder(DBCONNECT.getRutaDBActual)
        ruta = setFolder(ruta & RUTA_MACROS)
        If Not folderExist(ruta) Then MkDir(ruta)
        Return ruta
    End Function
    Public Function getRutaDadesMacro() As String
        Dim ruta As String
        ruta = setFolder(RUTA_APLICACIO)
        ruta = ruta & setFolder(RUTA_DADES_MACROS)
        If Not folderExist(ruta) Then MkDir(ruta)
        Return ruta
    End Function
    Public Function getRutaPlantillaComanda(idEmpresa As Integer) As String
        Dim ruta As String
        ruta = setFolder(DBCONNECT.getRutaDBActual)
        ruta = ruta & setFolder("plantilles")
        If Not folderExist(ruta) Then MkDir(ruta)
        ruta = ruta & setFolder("comanda")
        If Not folderExist(ruta) Then MkDir(ruta)
        Select Case idEmpresa
            Case 1 : Return setFolder(ruta) & "01-Comanda.xlsx"
            Case 2 : Return setFolder(ruta) & "02-Comanda.xlsx"
            Case 8 : Return setFolder(ruta) & "08-Comanda.xlsx"
            Case 10 : Return setFolder(ruta) & "10-Comanda.xlsx"
            Case 11 : Return setFolder(ruta) & "11-Comanda.xlsx"
            Case Else : Return setFolder(ruta) & "01-Comanda.xlsx"
        End Select
    End Function
    Public Function getDirectoriPDFComandesEnValidacio() As String
        Dim ruta As String
        ruta = setFolder(DBCONNECT.getRutaDBActual)
        ruta = ruta & setFolder("comandesPDF")
        If Not folderExist(ruta) Then MkDir(ruta)
        ruta = ruta & setFolder("enValidacio")
        If Not folderExist(ruta) Then MkDir(ruta)
        Return setFolder(ruta)

    End Function
    Public Function getDirectoriPDFComandesEnviades(idEmpresa As String) As String
        Dim ruta As String
        ruta = setFolder(DBCONNECT.getRutaDBActual)
        ruta = ruta & setFolder("comandesPDF")
        If Not folderExist(ruta) Then MkDir(ruta)
        ruta = ruta & setFolder("enviades")
        If Not folderExist(ruta) Then MkDir(ruta)
        ruta = ruta & setFolder(getDosDigits(idEmpresa))
        If Not folderExist(ruta) Then MkDir(ruta)
        Return setFolder(ruta)
    End Function

    Public Function getDirectoriPDFComandes() As String
        Dim ruta As String
        ruta = setFolder(DBCONNECT.getRutaDBActual)
        ruta = ruta & setFolder("comandesPDF")
        If Not folderExist(ruta) Then MkDir(ruta)
        ruta = ruta & setFolder("enEdicio")
        If Not folderExist(ruta) Then MkDir(ruta)
        Return setFolder(ruta)
    End Function
    Public Function getRuta(ruta As String, carpeta As String) As String
        Dim r As String
        r = setFolder(ruta)
        r = r & setFolder(carpeta)
        If Not folderExist(r) Then MkDir(r)
        Return r
    End Function
    Public Function getRutaDadesMacroLlibreMajor() As String
        Dim ruta As String
        ruta = getRutaDadesMacro()
        ruta = setFolder(setFolder(ruta) & RUTA_DADES_MACROS_LLIBRE_MAJOR)
        If Not folderExist(ruta) Then MkDir(ruta)
        Return ruta
    End Function
    Public Function getRutaDadesMacroLlibreMajorSubctes() As String
        Dim ruta As String
        ruta = getRutaDadesMacroLlibreMajor()
        ruta = setFolder(setFolder(ruta) & RUTA_DADES_MACROS_LLIBRE_MAJOR_SUBCOMPTES)
        If Not folderExist(ruta) Then MkDir(ruta)
        Return ruta
    End Function

    Public Function getDosDigits(p As Integer) As String
        If p < 10 Then
            Return "0" & p
        End If
        Return p
    End Function
    Public Function getNumStringDigits(p As Integer, digits As Integer) As String
        Dim i As Integer
        getNumStringDigits = p
        For i = CStr(p).Length To digits
            getNumStringDigits = "0" & getNumStringDigits
        Next
    End Function
    Public Function getListObjects(pObjectes As List(Of Object)) As Object()
        Dim obj As Object, i As Integer = 0, objectes() As Object
        ReDim objectes(pObjectes.Count - 1)
        For Each obj In pObjectes
            objectes(i) = obj
            i = i + 1
        Next
        getListObjects = objectes
        objectes = Nothing
        obj = Nothing
    End Function
    Public Function redimensionarArrayBidimensional(a(,) As String, f As Integer, c As Integer) As String(,)
        Dim dades(,) As String, i As Integer, j As Integer
        ReDim dades(f, c)
        For i = 0 To f
            For j = 0 To c
                dades(i, j) = a(i, j)
            Next
        Next
        Return dades
    End Function
    Public Function redimensionarArrayTridimensional(a(,,) As String, f As Integer, c As Integer, z As Integer) As String(,,)
        Dim dades(,,) As String, i As Integer, j As Integer, k As Integer
        ReDim dades(f, c, z)
        For i = 0 To f
            For j = 0 To c
                For k = 0 To z
                    dades(i, j, k) = a(i, j, k)
                Next
            Next
        Next
        Return dades
    End Function
    Public Function IS_SQLSERVER() As Boolean
        If CONFIG_FILE.getTag(CONFIG_FILE.TAG.TIPUS_SERVER) = SQL Then
            IS_SQLSERVER = True
        Else
            IS_SQLSERVER = False
        End If
    End Function
    Public Function setSeparator(p As String) As String
        If Strings.Right(p, 1) <> "\" Then Return p & "\"
        Return p
    End Function
    Public Function isNumericPositiu(p As String) As Boolean
        If IsNumeric(p) Then
            If Val(p) > 0 Then
                Return True
            End If
        End If
        Return False
    End Function
    Public Sub setPanel(p As Panel, obj As Object)
        p.Controls.Clear()
        obj.Dock = DockStyle.Fill
        p.Controls.Add(obj)
        obj.Show()
    End Sub
    Public Function getDirectoriServidorMYDOC() As String
        getDirectoriServidorMYDOC = setFolder(CONFIG_FILE.getTag(TAG.RUTA_SERVIDOR_DADES))
    End Function

    Public Function getDirectoriServidorF56() As String
        getDirectoriServidorF56 = getDirectoriServidorMYDOC() & "F56\"
        If Not CONFIG.folderExist(getDirectoriServidorOfertes) Then MkDir(getDirectoriServidorOfertes)
    End Function
    Public Function getDirectoriServidorOfertes() As String
        getDirectoriServidorOfertes = getDirectoriServidorMYDOC() & "OFERTES\"
        If Not CONFIG.folderExist(getDirectoriServidorOfertes) Then MkDir(getDirectoriServidorOfertes)
    End Function
    Public Function getfitxerComandaEnValidacio(p As String) As String
        Dim ruta As String, f As String
        ruta = setSeparator(CONFIG.getDirectoriPDFComandesEnValidacio)
        If folderExist(ruta) Then
            f = Dir(ruta & "*.pdf", FileAttribute.Archive)
            Do While f <> ""
                If InStr(1, f, p, CompareMethod.Text) > 0 Then
                    Return ruta & f
                End If
                f = Dir()
            Loop
        End If
        Return ""
    End Function
    'Public Function encoding(p As String) As String
    '    Dim bytes As Byte() = System.Text.Encoding.UTF8.GetBytes(p)
    '    Return System.Text.Encoding.UTF8.GetString(bytes)
    'End Function
    Public Function getRutaEmpresaComandesPDF(nomEmpresa As String) As String
        Dim ruta As String
        ruta = setFolder(CONFIG_FILE.getTag(TAG.RUTA_FITXERS_COMANDA))
        If Not CONFIG.folderExist(ruta) Then MkDir(ruta)
        ruta = ruta & setFolder(nomEmpresa)
        If Not CONFIG.folderExist(ruta) Then MkDir(ruta)
        getRutaEmpresaComandesPDF = ruta
    End Function
    Public Function getRutaEmpresaComandesPDF(nomEmpresa As String, a As Integer) As String
        Dim ruta As String
        ruta = setFolder(CONFIG_FILE.getTag(TAG.RUTA_FITXERS_COMANDA))
        If Not CONFIG.folderExist(ruta) Then MkDir(ruta)
        ruta = ruta & setFolder(nomEmpresa)
        If Not CONFIG.folderExist(ruta) Then MkDir(ruta)
        ruta = ruta & setFolder(a)
        If Not CONFIG.folderExist(ruta) Then MkDir(ruta)
        getRutaEmpresaComandesPDF = ruta
    End Function
    Public Function getDirectoritemporal()
        Dim ruta As String
        ruta = setFolder(getDirectoriAplicacio())
        ruta = ruta & TEMP
        If Not folderExist(ruta) Then Call MkDir(ruta)
        Return ruta
    End Function
    Public Function getRutaFitxerSignaturaCorreu() As String
        Return setFolder(DBCONNECT.getRutaDBActual) & NOM_FITXER_SIGNATURA_CORREU
    End Function
    Public Function getRutaComandaPDF(idEmpresa As Integer, codi As String, anyo As String, e As Integer)
        Dim f As String, ruta As String, temp() As String
        If e = 2 Then
            ruta = CONFIG.getDirectoriPDFComandesEnviades(idEmpresa)
        Else
            ruta = CONFIG.getDirectoriPDFComandesEnValidacio()
        End If
        f = Dir(ruta & "*.pdf", FileAttribute.Archive)
        Do While f <> ""
            temp = Split(f, "-")
            If UBound(temp) > 0 Then
                If Strings.Right(Val(temp(0)), 2) = anyo Then
                    If Val(temp(1)) = Val(codi) Then
                        If Val(temp(3)) = idEmpresa Then
                            Return ruta & f
                        End If
                    End If
                End If
            End If
            f = Dir()
        Loop
        Return ""
    End Function
End Module
