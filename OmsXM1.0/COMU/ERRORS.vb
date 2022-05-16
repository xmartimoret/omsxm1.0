
Option Explicit On
Module ERRORS
    Public Sub ERR_EXCEPTION_SQL(msg As String)
        MsgBox(msg, MsgBoxStyle.Critical, IDIOMA.getString("abort"))
    End Sub
    Public Sub ERR_SUBCOMPTE_EXIST()
        Call MsgBox(IDIOMA.getString("errSubcompteExisteix"), vbCritical, IDIOMA.getString("abort"))
    End Sub
    Public Sub ERR_GRUP_EXIST()
        Call MsgBox(IDIOMA.getString("errGrupExisteix"), vbCritical, IDIOMA.getString("abort"))
    End Sub
    Public Sub ERR_PASSWORD()
        Call MsgBox(IDIOMA.getString("errClauPas"), vbCritical, IDIOMA.getString("abort"))
    End Sub
    Public Sub ERR_SUBGRUP_EXIST()
        Call MsgBox(IDIOMA.getString("errSubgrupExisteix"), vbCritical, IDIOMA.getString("abort"))
    End Sub
    Public Sub ERR_RUTA_SERVIDOR()
        Call MsgBox(IDIOMA.getString("errServidorConfigurat"), vbCritical, IDIOMA.getString("anomalia"))
    End Sub
    Public Sub ERR_RUTA_SERVIDOR_LOCAL()
        Call MsgBox(IDIOMA.getString("errServidorLocalConfigurat") & vbCrLf & IDIOMA.getString("errAvisarAdministrador"), vbCritical, IDIOMA.getString("anomalia"))
    End Sub
    Public Sub ERR_TAULES(t As String, Optional esLocal As Boolean = False)
        If esLocal Then
            Call MsgBox("NO EXISTEIXEN, A LA BASE DE DADES LOCAL (C:\..),  LES TAULES: " & vbCrLf & vbTab & t, vbCritical, IDIOMA.getString("anomalia"))
        Else
            Call MsgBox("NO EXISTEIXEN, A LA BASE DE DADES REMOTA (\\SERVIDOR),  LES TAULES: " & vbCrLf & vbTab & t, vbCritical, IDIOMA.getString("anomalia"))
        End If
    End Sub
    Public Sub NO_CHANGE_ORDER_GRUP()
        Call MsgBox(IDIOMA.getString("errOrdre"), vbCritical, IDIOMA.getString("abort"))
    End Sub
    Public Sub ERR_NO_PREDETERMINADES()
        Call MsgBox(IDIOMA.getString("errDadesPredeterminades"), vbCritical, IDIOMA.getString("abort"))
    End Sub
    Public Sub ERR_EXIST_CODE_SECCIO()
        Call MsgBox(IDIOMA.getString("errExisteixSeccioCodi"), vbCritical, IDIOMA.getString("abort"))
    End Sub
    'ERR_EXIST_CODE_DEPARTAMENT
    Public Sub ERR_EXIST_CODE_DEPARTAMENT()
        Call MsgBox(IDIOMA.getString("errExisteixDepartamentCodi"), vbCritical, IDIOMA.getString("abort"))
    End Sub
    Public Sub ERR_EXIST_NAME_SECCIO()
        Call MsgBox(IDIOMA.getString("errExisteixSeccioNom"), vbCritical, IDIOMA.getString("abort"))
    End Sub
    '
    Public Sub ERR_YSHEET_EXIST()
        Call MsgBox(IDIOMA.getString("errExisteixYellow"), vbCritical, IDIOMA.getString("abort"))
    End Sub

    Public Sub ERR_REMOVE_EMPRESA_BY_SECCIO()
        Call MsgBox(IDIOMA.getString("errEliminarEmpresa"), vbCritical, IDIOMA.getString("abort"))
    End Sub
    Public Sub ERR_REMOVE_SECCIO_BY_CENTRE()
        Call MsgBox(IDIOMA.getString("errEliminarSeccio"), vbCritical, IDIOMA.getString("abort"))
    End Sub

    Public Sub ERR_REMOVE_CLIENT_BY_PROJECTE()
        Call MsgBox(IDIOMA.getString("errEliminarClient"), vbCritical, IDIOMA.getString("abort"))
    End Sub

    '
    Public Sub ERR_REMOVE_CENTRE_BY_PROJECTE()
        Call MsgBox(IDIOMA.getString("errEliminarCentre"), vbCritical, IDIOMA.getString("abort"))
    End Sub
    Public Sub ERR_EXIST_CODE_CENTRE()
        Call MsgBox(IDIOMA.getString("errExistCentreCodi"), vbCritical, IDIOMA.getString("abort"))
    End Sub
    Public Sub ERR_EXIST_NAME_CENTRE()
        Call MsgBox(IDIOMA.getString("errExistCentreNom"), vbCritical, IDIOMA.getString("abort"))
    End Sub
    Public Sub ERR_EXIST_SUBCTA_GRUP()
        Call MsgBox(IDIOMA.getString("errEliminarSubcompteSubgrup") & vbCrLf & IDIOMA.getString("errEliminarSubcompteSubgrup1"), vbCritical, IDIOMA.getString("abort"))
    End Sub
    Public Sub ERR_EXIST_NAME_COLUMNA()
        Call MsgBox(IDIOMA.getString("errExistColumnaNom"), vbCritical, IDIOMA.getString("abort"))
    End Sub

    'ERR_REMOVE_COLUMNA_BY_PROJECTE
    Public Sub ERR_REMOVE_COLUMNA_BY_PROJECTE()
        Call MsgBox(IDIOMA.getString("errEliminarColumnaProjecte"), vbCritical, IDIOMA.getString("abort"))
    End Sub
    Public Sub ERR_REMOVE_COLUMNA_BY_COLUMNA()
        Call MsgBox(IDIOMA.getString("errEliminarColumnaColumna"), vbCritical, IDIOMA.getString("abort"))
    End Sub

    Public Sub ERR_REMOVE_PROJECTE_BY_CENTRE()
        Call MsgBox(IDIOMA.getString("errEliminarProjecteDetall"), vbCritical, IDIOMA.getString("abort"))
    End Sub
    Public Sub ERR_REMOVE_PROJECTE_BY_COLUMNA()
        Call MsgBox(IDIOMA.getString("errEliminarProjecteExpram"), vbCritical, IDIOMA.getString("abort"))
    End Sub
    Public Sub ERR_NO_FITXER_TRANSITORIA()
        Call MsgBox(IDIOMA.getString("errFitxerResumTransitories"), vbCritical, IDIOMA.getString("abort"))
    End Sub
    Public Sub ERR_NO_ANY_FITXER_TRANSITORIA()
        Call MsgBox(IDIOMA.getString("errFitxerResumTransitoriesAny"), vbCritical, IDIOMA.getString("abort"))
    End Sub
    Public Sub ERR_NO_EMPRESA_FITXER_TRANSITORIA()
        Call MsgBox(IDIOMA.getString("errFitxerResumTransitoriesEmpresa"), vbCritical, IDIOMA.getString("abort"))
    End Sub
    Public Sub ERR_NOM_FITXER_DBF()
        Call MsgBox(IDIOMA.getString("errFitxerResumTransitoriesDiario"), vbCritical, IDIOMA.getString("abort"))
    End Sub
    Public Sub ERR_NOM_FITXER_EXTORN_DBF()
        Call MsgBox(IDIOMA.getString("errFitxerResumTransitoriesDiarioExtorn"), vbCritical, IDIOMA.getString("abort"))
    End Sub
    Public Sub ERR_NO_EXIST_DIARIO(ruta As String)
        Call MsgBox(IDIOMA.getString("errFitxer") & " " & vbCrLf & vbTab & ruta & vbCrLf & vbCrLf & IDIOMA.getString("errFitxerDiarioRevisar"), vbCritical, IDIOMA.getString("abort"))
    End Sub

    Public Sub ERR_MES_ANTERIOR_OBERT()
        Call MsgBox(IDIOMA.getString("errMesTancar") & " " & vbCrLf & IDIOMA.getString("errMesTancar1"), vbCritical, IDIOMA.getString("abort"))
    End Sub
    Public Sub ERR_MES_SEGUENT_TANCAT()
        Call MsgBox(IDIOMA.getString("errMesReObrir") & " " & vbCrLf & IDIOMA.getString("errMesReObrir1"), vbCritical, IDIOMA.getString("abort"))
    End Sub
    Public Sub ERR_MES_NO_DETALLS()
        Call MsgBox(IDIOMA.getString("errMesTancar") & " " & vbCrLf & IDIOMA.getString("errMesTancar2"), vbCritical, IDIOMA.getString("abort"))
    End Sub

    Public Sub ERR_MES_NO_TRANSI()
        Call MsgBox(IDIOMA.getString("errMesTancar") & " " & vbCrLf & IDIOMA.getString("errTransitoriaNoTancada"), vbCritical, IDIOMA.getString("abort"))
    End Sub
    Public Sub ERR_NO_PLANTILLA_MAJOR()
        Call MsgBox(IDIOMA.getString("errLlibreMajor"), vbCritical, IDIOMA.getString("abort"))
    End Sub
    Public Sub ERR_BORRAR_MES_TANCAT()
        Call MsgBox(IDIOMA.getString("errMesTancatBorrar"), vbCritical, IDIOMA.getString("abort"))
    End Sub
    Public Sub ERR_BORRAR_MES_TRANSITORIA_TANCADA()
        Call MsgBox(IDIOMA.getString("errTransitoriaTancatBorrar"), vbCritical, IDIOMA.getString("abort"))
    End Sub
    Public Sub ERR_IMPORTAR_MES_TANCAT(m As Integer)
        Call MsgBox(IDIOMA.getString("errTransitoriaMes") & " " & CONFIG.mesNom(m) & "  " & IDIOMA.getString("errTransitoriaMes1"), vbCritical, IDIOMA.getString("abort"))
    End Sub
    Public Sub ERR_MES_ACTUAL_TANCAT()
        Call MsgBox(IDIOMA.getString("errMesReObrir2"), vbCritical, IDIOMA.getString("abort"))
    End Sub
    Public Sub ERR_FITXER_DIARIO_OBERT()
        Call MsgBox(IDIOMA.getString("ERR_FITXER_DIARIO_OBERT"), vbCritical, IDIOMA.getString("abort"))
    End Sub
    Public Sub ERR_NO_EXIST_ZAMORA()
        Call MsgBox(IDIOMA.getString("noEmpresaZamora") & vbCrLf & IDIOMA.getString("existirCodiZam"), vbCritical, IDIOMA.getString("abort"))
    End Sub
    Public Sub ERR_ANY()
        Call MsgBox(IDIOMA.getString("anyFitxerNoExisteix"), vbCritical, IDIOMA.getString("abort"))
    End Sub
    Public Sub ERR_NO_EXIST_ANDORRA()
        Call MsgBox(IDIOMA.getString("noEmpresaAndorra") & vbCrLf & IDIOMA.getString("existirCodiAnd"), vbCritical, IDIOMA.getString("abort"))
    End Sub
    Public Sub ERR_NO_FULLA_PRETANCAMENT()
        Call MsgBox(IDIOMA.getString("errAnyAndorra"), vbCritical, IDIOMA.getString("abort"))
    End Sub
    Public Sub ERR_NO_DIARIO_CONTAPLUS(nom As String, nomContaplus As String)
        Call MsgBox(IDIOMA.getString("errFitxerEmpresa") & " " & nom & vbCrLf & IDIOMA.getString("errFitxerEmpresa1") & "=(" & nomContaplus & ")", vbCritical, IDIOMA.getString("abort"))
    End Sub
    Public Sub ERR_PREFIX_SUBCOMPTE()
        Call MsgBox(IDIOMA.getString("errGuardarPrefix"), vbCritical, IDIOMA.getString("abort"))
    End Sub

    Public Sub ERR_ANY_DIARIO(a As Integer)
        Call MsgBox(IDIOMA.getString("errAnyDiario") & a & " ." & vbCrLf & IDIOMA.getString("errAnyDiario1"), vbCritical, IDIOMA.getString("abort"))
    End Sub

    Public Sub ERR_FULLA_ZAMORA(nomFitxer As String)
        Call MsgBox(IDIOMA.getString("errFitxerActual") & "  " & nomFitxer & IDIOMA.getString("errNoZamora"), vbCritical, IDIOMA.getString("abort"))
    End Sub

    Public Sub ERR_EXIST_ANY_COMPTABLE()
        Call MsgBox(IDIOMA.getString("ERR_EXIST_ANY_COMPTABLE"), vbCritical, IDIOMA.getString("abort"))
    End Sub
    Public Sub ERR_EXIST_NAME_CONTAPLUS(nomContaplus As String)
        Call MsgBox(IDIOMA.getString("ERR_EXIST_NAME_CONTAPLUS") & nomContaplus, vbCritical, IDIOMA.getString("abort"))
    End Sub
    Public Sub ERR_EXIST_PATH_CONTAPLUS(ruta As String)
        Call MsgBox(IDIOMA.getString("errNoDiario") & vbCrLf & ruta, vbCritical, IDIOMA.getString("abort"))
    End Sub

    Public Sub ERR_CONCEPTE_ZAMORA()
        Call MsgBox(IDIOMA.getString("errNomSubcompteZamora") & vbCrLf & IDIOMA.getString("errNoAfegir"), vbCritical, IDIOMA.getString("abort"))
    End Sub
    Public Sub ERR_NO_GB()
        Call MsgBox(IDIOMA.getString("errGbNoOberta"), vbCritical, IDIOMA.getString("abort"))
    End Sub
    'ERR_NO_MAN
    Public Sub ERR_NO_MAN()
        Call MsgBox(IDIOMA.getString("errManNoOberta"), vbCritical, IDIOMA.getString("abort"))
    End Sub
    Public Sub ERR_NO_EXIST_WORKSHEEET(fulla As String, accio As String)
        Call MsgBox(IDIOMA.getString("errNoExisteixFulla") & " " & fulla & vbCrLf & accio, vbCritical, IDIOMA.getString("abort"))
    End Sub
    Public Sub ERR_NO_PLANTILLA_VOSS(ruta As String)
        Call MsgBox(IDIOMA.getString("errNoExisteixFitxer") & " " & ruta & vbCrLf & IDIOMA.getString("errCrearVoss"), vbCritical, IDIOMA.getString("abort"))
    End Sub
    Public Sub ERR_CENTREGB_EXIST()
        Call MsgBox(IDIOMA.getString("errCentreGb"), vbCritical, IDIOMA.getString("abort"))
    End Sub
    Public Sub ERR_FULLAGB_EXIST()
        Call MsgBox(IDIOMA.getString("errCentreGb1"), vbCritical, IDIOMA.getString("abort"))
    End Sub
    Public Sub ERR_REMOVE_CENTRE_BY_DADES_DETALL(nomCentre As String)
        Call MsgBox(IDIOMA.getString("errEliminarCentre1") & " " & nomCentre & ". " & IDIOMA.getString("errEliminarCentre2") & vbCrLf & IDIOMA.getString("errEliminarCentre3"), vbCritical, IDIOMA.getString("abort"))
    End Sub
    Public Sub ERR_NO_CENTRES_TROBATS()
        Call MsgBox(IDIOMA.getString("errNoCentre"), vbCritical, IDIOMA.getString("abort"))
    End Sub
    Public Sub ERR_NO_FITXER_BUDGET()
        Call MsgBox(IDIOMA.getString("errBudgetNo"), vbCritical, IDIOMA.getString("abort"))
    End Sub
    Public Sub ERR_FITXER_OBERT()
        Call MsgBox(IDIOMA.getString("errVosObert") & vbCrLf & IDIOMA.getString("errTancar"), vbCritical, IDIOMA.getString("abort"))
    End Sub
    Public Sub ERR_FULLA_VOSS(nomFulla As String)
        Call MsgBox(IDIOMA.getString("errNoFulla") & " (" & nomFulla & ") " & IDIOMA.getString("errNoFulla1") & vbCrLf & IDIOMA.getString("errNoFulla2"), vbCritical, IDIOMA.getString("abort"))
    End Sub
    Public Sub ERR_RANG_VOSS(nomRang As String)
        Call MsgBox(IDIOMA.getString("errNoRang") & " (" & nomRang & ") " & IDIOMA.getString("errNoFulla1") & vbCrLf & IDIOMA.getString("errNoFulla2"), vbCritical, IDIOMA.getString("abort"))
    End Sub
    Public Sub ERR_NO_ESTIMACIONS(fitxer As String)
        Call MsgBox(IDIOMA.getString("errNoDadesTresoreria") & UCase(fitxer) & ")." & vbCrLf & IDIOMA.getString("errNoDadesTresoreria1") & vbCrLf & vbCrLf & IDIOMA.getString("errNoDadesTresoreria1"), vbCritical, IDIOMA.getString("abort"))
    End Sub
    Public Sub ERR_INSERT_TRESORERIA()
        Call MsgBox(IDIOMA.getString("errNoInsertarTresoreria") & vbCrLf & IDIOMA.getString("errNoInsertarTresoreria1") & vbCrLf & IDIOMA.getString("errNoInsertarTresoreria2"), vbCritical, IDIOMA.getString("abort"))
    End Sub
    Public Sub ERR_DIRECTORI_SERVIDOR_MACROS()
        Call MsgBox(IDIOMA.getString("errNoRutaApliMacros") & vbCrLf & IDIOMA.getString("errNoInsertarTresoreria1"), vbCritical, IDIOMA.getString("abort"))
    End Sub
    Public Sub ERR_NO_EXIST_PLANTILLA_LLIBRE_MAJOR()
        Call MsgBox(IDIOMA.getString("errFitxerPlantillaLLM") & vbCrLf & IDIOMA.getString("errRevisarConfiguracioSistema"), vbCritical, IDIOMA.getString("abort"))
    End Sub
    Public Sub ERR_NO_PLANTILLA_TRANSITORIA()
        Call MsgBox(IDIOMA.getString("errNofitxerPlantilla") & vbCrLf & IDIOMA.getString("errRevisarConfiguracioSistema"), vbCritical, IDIOMA.getString("abort"))
    End Sub
    Public Sub ERR_NO_EXIST_FULLA_CONFIG_MAN()
        Call MsgBox(IDIOMA.getString("errNoExistConfigMan") & vbCrLf & IDIOMA.getString("errRevisarConfiguracioSistema"), vbCritical, IDIOMA.getString("abort"))
    End Sub

    Public Sub ERR_CONFIG_MAN()
        Call MsgBox(IDIOMA.getString("errConfigMan") & vbCrLf & IDIOMA.getString("errRevisarConfiguracioSistema"), vbCritical, IDIOMA.getString("abort"))
    End Sub
    Public Sub ERR_CIF_INCORRECTE()
        Call MsgBox(IDIOMA.getString("errCifIncorrecte"), vbCritical, IDIOMA.getString("abort"))
    End Sub
    'ERR_CIF_EXIST
    Public Sub ERR_CIF_EXIST()
        Call MsgBox(IDIOMA.getString("errCifExist"), vbCritical, IDIOMA.getString("abort"))
    End Sub
    Public Sub ERR_NO_EMPRESA_COMANDA()
        Call MsgBox(IDIOMA.getString("errEmpresaComanda"), vbCritical, IDIOMA.getString("abort"))
    End Sub
    'ERR_PDF_CLOSE
    Public Sub ERR_PDF_CLOSE(p As String)
        Call MsgBox(IDIOMA.getString("errPdfClose") & vbCrLf & p, vbCritical, IDIOMA.getString("abort"))
    End Sub
    Public Sub ERR_ACTUALITZACIO_CODI_COMANDA()
        Call MsgBox(IDIOMA.getString("errActualitzacioCodiComanda"), vbCritical, IDIOMA.getString("abort"))
    End Sub
    Public Sub ERR_NO_VALIDAR_COMANDA(P As List(Of String))
        Dim texte As String, t As String
        texte = IDIOMA.getString("noEsPotCrearComanda") & vbCrLf
        For Each t In P
            texte = vbCritical & " " & t & vbCrLf
        Next
        Call MsgBox(texte, vbOK, IDIOMA.getString("abort"))
    End Sub
    Public Sub NO_SHOW_COMANDA_VALIDACIO()
        Call MsgBox(IDIOMA.getString("errMostrarComandaValidacio"), vbCritical, IDIOMA.getString("abort"))
    End Sub
    Public Sub ERR_NO_FILE_COMANDA()
        Call MsgBox(IDIOMA.getString("errPdfComanda"), vbCritical, IDIOMA.getString("abort"))
    End Sub
    Public Sub ERR_EXIST_NAME_CONTACTE()
        Call MsgBox(IDIOMA.getString("errNomContacte"), vbCritical, IDIOMA.getString("abort"))
    End Sub
    Public Sub ERR_UPDATE_GOOGLE_SHEETS()
        Call MsgBox(IDIOMA.getString("errActualtizarGoogleSheets"), vbCritical, IDIOMA.getString("abort"))
    End Sub
    Public Sub EN_CONSTRUCCIO()
        Call MsgBox(IDIOMA.getString("enConstruccio"), vbCritical, IDIOMA.getString("abort"))
    End Sub
End Module
