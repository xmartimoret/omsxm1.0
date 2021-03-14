Option Explicit On
Imports System.Configuration

''' Project: $safeprojectname$
''' Module: CONFIG_FILE   
''' -------------
''' <summary>
'''     Per  llegir i escriure en el fitxer app.config de l'aplicació.
''' </summary>
''' <example>
'''     per exemple, el servidor de dades, usuari i clau d'acces al servidor. 
'''     Usuari actual de l'aplicació i altres. 
''' </example>
''' 
Module CONFIG_FILE
    Friend Enum TAG
        RUTA_GB_PRETANCAMENT = 1
        RUTA_GB_TANCAMENT = 2
        IMPORT_TRANSITORIA = 3
        EXPORT_TRANSITORIA = 4
        TRESORERIA_OBRES = 5
        RUTA_SERVIDOR_DADES = 6
        RUTA_CONTAPLUS = 7
        CASH_TRESORERIA = 8
        GB_BUDGET = 9
        RUTA_DEPARTAMENTS = 10
        RUTA_ESTADISTIQUES = 11
        RUTA_SUM_ESTADISTIQUES = 12
        RUTA_FITXER_ZAMORA = 13
        RUTA_FITXER_ANDORRA = 14
        ANY_ACTUAL_UTE = 15
        MES_ACTUAL_UTE = 16
        ANY_TRANSITORIA = 17
        ES_LOCAL = 18
        SERVER_DATA = 19
        SERVER_USUARI = 20
        SERVER_PASSWORD = 21
        RUTA_APLICACIO = 22
        RUTA_EXPORTACIO_DBF = 23
        RUTA_DIR_FITXERS_VOS = 24
        RUTA_EXPORT_MAN = 25
        TIPUS_USUARI = 26
        DATA_INI_VENCIMENT = 27
        DATA_FI_VENCIMENT = 28
        DATA_INI_EXPORT_DEPARTAMENTS = 29
        DATA_FI_EXPORT_DEPARTAMENTS = 30
        ID_EMPRESA_ACTUAL = 31
        SUBCOMPTE_TRANSITORIA_COMPRES = 32
        SUBCOMPTE_TRANSITORIA_VENDES = 33
        DIRECTORI_FITXERS_TRANSITORIES = 34
        MES_ACTUAL_INFORMES = 35
        ES_INCREMENTAL_INFORME = 36
        TIPUS_INFORME = 37
        SECCIO_INFORME = 38
        ANY_BUDGET = 39
        IMPORT_BUDGET = 40
        TIPUS_SERVER = 41
        WIDHT_SPLIT_COMANDES = 42
    End Enum
    Private Sub getValues()
        Try
            Dim appSettings = ConfigurationManager.AppSettings()
            If appSettings.Count = 0 Then
                Console.WriteLine("AppSettings is empty.")
            Else
                For Each key As String In appSettings.AllKeys
                    Console.WriteLine("Key: {0} Value: {1}", key, appSettings(key))
                Next
            End If
        Catch e As ConfigurationErrorsException
            Console.WriteLine("Error reading app settings")
        End Try
    End Sub
    Private Function getValue(key As String) As String
        Dim result As String = "", a As Integer
        Try
            Dim config_file = ConfigurationManager.OpenExeConfiguration(Application.StartupPath & "\" & System.IO.Path.GetFileName(Application.ExecutablePath))
            'Dim config_file = ConfigurationManager.ExeConfiguration(CONFIG.getDirectoriAplicacio & "\" & System.IO.Path.GetFileName(Application.ExecutablePath))
            Dim appSettins = config_file.AppSettings
            Dim settings = config_file.AppSettings.Settings
            'result = appSettins(key)
            If IsNothing(settings(key)) Then
                result = ""
            Else
                result = settings(key).Value
            End If
        Catch e As Exception
            Call setValue(key, "")
            Return ""
        End Try
        Return result
    End Function
    ''' <summary>
    ''' Afegiex i modifica una nou parell (clau, valor) en el fitxer app.config de 
    ''' cal definir be el path de l'execució de l'aplicació 
    ''' <code>Application.StartUp</code> Agafa el path on s'executa l'aplicació
    ''' <code>System.IO.Path.GetFileName(Application.ExecutablePath)</code> Agafa el nom del fitxer config de l'aplicació
    ''' </summary>
    ''' <param name="key">Clau del valor. Camp únic, en cas que existeixi, es modifica el valor sinò afegiex un nou parell </param>
    ''' <param name="value">Valor de la clau</param>
    ''' <![CDATA[agost 2016. Xmarti]]>
    Private Sub setValue(key As String, value As String)
        Try
            Dim config_file = ConfigurationManager.OpenExeConfiguration(Application.StartupPath & "\" & System.IO.Path.GetFileName(Application.ExecutablePath))
            'Dim config_file = ConfigurationManager.OpenExeConfiguration(CONFIG.getDirectoriAplicacio() & "\" & System.IO.Path.GetFileName(Application.ExecutablePath))
            Dim settings = config_file.AppSettings.Settings
            If IsNothing(settings(key)) Then
                settings.Add(key, value)
            Else
                settings(key).Value = value
            End If
            config_file.Save(ConfigurationSaveMode.Modified)
            ConfigurationManager.RefreshSection(config_file.AppSettings.SectionInformation.Name)
        Catch e As ConfigurationErrorsException
            Throw New ExcepcioConfig(ExcepcioConfig.ERR_GET_VALUE)
        End Try
    End Sub
    Public Function getClauUsuari(login As String) As String
        Return getValue(login)
    End Function
    Public Sub setClauUsuari(login As String, value As String)
        Call setValue(login, value)
    End Sub
    Public Function getTag(tag As TAG, Optional empresa As String = "") As String
        Return getValue(tag & empresa)
    End Function
    Public Sub setTag(tag As TAG, value As String, Optional empresa As String = "")
        Call setValue(tag & empresa, value)
    End Sub
End Module
