Imports System.Data.SqlClient
Imports ADODB
Module DBCONNECT
#If Win64 Then
    Const PROVIDER_ As String = "Microsoft.ACE.OLEDB.12.0"
#Else
    Const PROVIDER_ As String = "Microsoft.Jet.OLEDB.4.0"
#End If

    Private cnActual As SqlConnection
    Private cnDbfActual As ADODB.Connection
    Private Const PROC_DATA_ACTUALITZACIO As String = "GET_DATE_UPDATED"
    Private Const DATABASE As String = "ApliOmsSacedeXM"
    Private Const TAULA_DEPARTAMENT_COMANDA As String = "DEPCOM"
    Private Const TAULA_UNITAT As String = "UNITAT"
    Private Const TAULA_FAMILIA As String = "FAMILIA"
    Private Const TAULA_FABRICANT As String = "FABRICAN"
    Private Const TAULA_ARTICLE_PREU As String = "ARTPREU"
    Private Const TAULA_ARTICLE As String = "ARTICLE"
    Private Const TAULA_PROJECTE_CONTACTE As String = "PROJCONT"
    Private Const TAULA_PROVEIDOR_ANOTACIO As String = "PROVNOT"
    Private Const TAULA_PAIS As String = "PAIS"
    Private Const TAULA_PROVINCIA As String = "PROVINCI"
    Private Const TAULA_TIPUS_PAGAMENT As String = "TPAGA"
    Private Const TAULA_PROVEIDOR As String = "PROVEIDO"
    Private Const TAULA_ACTUALITZACIO As String = "ACTUALITZACIOTAULES"
    Private Const TAULA_ESTIMACIONS As String = "EST"
    Private Const TAULA_BUDGETSGB As String = "BUDGETGB"
    Private Const TAULA_CENTRE_GB As String = "CENTREGB"
    Private Const TAULA_PARAMETRES As String = "PARAM"
    Private Const TAULA_EMPRESA_CONTAPLUS As String = "EMPCON"
    Private Const TAULA_SUBCOMPTE_PRETANCAMENT As String = "SUBPRE"
    Private Const TAULA_PREFIX_SUBCTE_PRETANCAMENT As String = "PRESUB"
    Private Const TAULA_MESOS As String = "ESTATMES"
    Private Const TAULA_DEPARTAMENTS As String = "DEPARTAM"
    Private Const TAULA_YELLOW_SHEET As String = "YSHEET"
    Private Const TAULA_PROJECTE_CLIENT As String = "CLIENTP"
    Private Const TAULA_CLIENT As String = "CLIENT"
    Private Const TAULA_TRANSITORIA As String = "TRANSIT"
    Private Const TAULA_SUBCOMPTE_ZAMORA As String = "SCTZAM"
    Private Const TAULA_EMPRESA As String = "EMPRESA"
    Private Const TAULA_SUBGRUPS_CENTRE As String = "CENTRESG"
    Private Const TAULA_PRETANCAMENT As String = "BUDGET"
    Private Const TAULA_GRUPS_SECCIO As String = "GRUPSS"
    Private Const TAULA_PROJECTE_COLUMNA As String = "COLUMNAP"
    Private Const TAULA_FILLA_COLUMNA As String = "COLUMNAF"
    Private Const TAULA_COLUMNA As String = "COLUMNA"
    Private Const TAULA_SECCIO As String = "SECCIO"
    Private Const TAULA_PROJECTE As String = "PROJECTE"
    Private Const TAULA_EMP_PROJ As String = "CENTREP"
    Private Const TAULA_CENTRE As String = "CENTRE"
    Private Const TAULA_SUBCOMPTES As String = "SUBCTES"
    Private Const TAULA_SUBGRUPS As String = "SUBGRUPS"
    Private Const TAULA_SUBCOMPTES_SubGrup As String = "SUBCTESG"
    Private Const TAULA_GRUPS As String = "GRUPS"
    Private Const TAULA_SUBGRUPGB As String = "SUBGRUPGB"
    Private Const TAULA_TIPUS_IVA As String = "TIVA"
    Private Const TAULA_PROVEIDOR_CONTACTES As String = "PROVCONT"
    Private Const TAULA_CONTACTES As String = "CONTACTE"
    Private Const TAULA_LLOC_ENTREGA As String = "ENTREGA"
    Private Const TAULA_PROJECTE_ENTREGA As String = "PROJENT"
    Private Const TAULA_COMANDA As String = "COMANDA"
    Private Const TAULA_ARTICLE_COMANDA As String = "CART"

    ' FUNCTION: CONNECT
    '   DESCRIPTION: Per crear una connexió a una base de dades DBF
    '   PARAM: Ruta del directori on estan ubicades les taules de la DBF
    '   RETURN: La connexió realitzada. (Objecte Connection )
    Public Function connectDBF(ruta As String) As ADODB.Connection
        Dim sqlString As String
        sqlString = getStringConnectionDBF(ruta)
        connectDBF = New ADODB.Connection()
        Try
            connectDBF.Open(sqlString)
        Catch ex As Exception
            Console.Write(ex.ToString)
        End Try
    End Function
    Public Function setConnectServer() As Boolean
        If IS_SQLSERVER() Then
            Call getConnection()
            If cnActual.State = 1 Then Return True
        Else
            Call getConnectionDbf()
            If cnDbfActual.State = 1 Then Return True
        End If
        Return False
    End Function
    Public Function getConnectionDbf() As ADODB.Connection
        Dim sqlString As String, ruta As String  ', avis As frmAvis
        If cnDbfActual Is Nothing OrElse cnDbfActual.State = 0 Then
            ' avis = New frmAvis
            'avis.setData(IDIOMA.getString("db.connectServer.Missatge"), CONFIG_FILE.getTag(CONFIG_FILE.TAG.SERVER_DATA), "")
            ruta = getRutaDBActual()
            sqlString = "Provider=" & PROVIDER_ & ";Data Source=" & ruta & ";Extended Properties=dBASE IV;"
            'sqlString = "Data Source= " & CONFIG_FILE.get  Tag(CONFIG_FILE.TAG.SERVER_DATA) & ";" &
            ' "database=" & DATABASE & "; MultipleActiveResultSets=True; user ID= " & CONFIG_FILE.getTag(CONFIG_FILE.TAG.SERVER_USUARI) & "; password = " & CONFIG_FILE.getTag(CONFIG_FILE.TAG.SERVER_PASSWORD)

            cnDbfActual = New ADODB.Connection()
            Try
                cnDbfActual.Open(getStringConnectionDBF(ruta))

            Catch ex As Exception
                'avis.Close()
                'avis = Nothing
                Call ERRORS.ERR_EXCEPTION_SQL(ExcepcioSql.ERR_CONNECT_DB)
            End Try
        End If
        'avis = Nothing
        sqlString = Nothing
        Return cnDbfActual
    End Function
    Public Function getConnection() As SqlConnection
        Dim sqlString As String
        If cnActual Is Nothing OrElse cnActual.State = 0 Then
            ' avis = New frmAvis
            'avis.setData(IDIOMA.getString("db.connectServer.Missatge"), CONFIG_FILE.getTag(CONFIG_FILE.TAG.SERVER_DATA), "")

            sqlString = "Data Source= " & CONFIG_FILE.getTag(CONFIG_FILE.TAG.SERVER_DATA) & ";" &
             "database=" & DATABASE & "; MultipleActiveResultSets=True; user ID= " & CONFIG_FILE.getTag(CONFIG_FILE.TAG.SERVER_USUARI) & "; password = " & CONFIG_FILE.getTag(CONFIG_FILE.TAG.SERVER_PASSWORD)

            cnActual = New SqlConnection(sqlString)
            Try
                cnActual.Open()

            Catch ex As Exception
                'avis.Close()
                'avis = Nothing
                Call ERRORS.ERR_EXCEPTION_SQL(ExcepcioSql.ERR_CONNECT_DB)
            End Try
        End If
        'avis = Nothing
        sqlString = Nothing
        Return cnActual
    End Function
    Public Function existServer(servidor As String, usuari As String, clau As String) As Boolean
        Dim sqlString As String, cn As SqlConnection
        sqlString = "Data Source= " & servidor & ";" &
            "database=myDB;user ID=" & usuari & " ; password =" & clau
        cn = New SqlConnection(sqlString)
        Try
            cn.Open()
            If cn.State Then
                cn.Close()
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        Finally
            cn = Nothing
        End Try
    End Function
    Public Function getDateModified(t As String) As Date
        If IS_SQLSERVER Then
            Dim rc As SqlCommand
            rc = New SqlCommand(PROC_DATA_ACTUALITZACIO, DBCONNECT.getConnection)
            rc.CommandType = CommandType.StoredProcedure
            rc.Parameters.Add("@TAULA", SqlDbType.VarChar, 20, ParameterDirection.Input).Value = t
            rc.Parameters.Add("@RESULT", SqlDbType.DateTime)
            rc.Parameters("@RESULT").Direction = ParameterDirection.Output
            rc.ExecuteNonQuery()
            If IsDate(rc.Parameters("@RESULT").Value) Then
                getDateModified = rc.Parameters("@RESULT").Value

            Else
                getDateModified = CDate("01/01/2000")
            End If
            rc = Nothing
        Else
            Return CONFIG.getDateFileModified(CONFIG.setFolder(getRutaDBActual) & CONFIG.setDbf(t))
        End If
    End Function
    Public Sub close()
        If cnActual IsNot Nothing Then If cnActual.State = 1 Then cnActual.Close()
        cnActual = Nothing

    End Sub
    Public Function getTaulaArticleComanda() As String
        Return TAULA_ARTICLE_COMANDA
    End Function
    Public Function getTaulaComanda() As String
        Return TAULA_COMANDA
    End Function
    Public Function getTaulaArticle() As String
        Return TAULA_ARTICLE
    End Function
    Public Function getTaulaArticlePreu() As String
        Return TAULA_ARTICLE_PREU
    End Function
    Public Function getTaulaFamilia() As String

        Return TAULA_FAMILIA
    End Function
    Public Function getTaulaUnitat() As String
        Return TAULA_UNITAT
    End Function
    Public Function getTaulaFabricant() As String
        Return TAULA_FABRICANT
    End Function
    Public Function getTaulaDepartamentComanda() As String
        Return TAULA_DEPARTAMENT_COMANDA
    End Function
    Public Function getTaulaProjecteContacte() As String
        Return TAULA_PROJECTE_CONTACTE
    End Function
    Public Function getTaulaContacte() As String
        Return TAULA_CONTACTES
    End Function
    Public Function getTaulaLlocEntrega() As String
        Return TAULA_LLOC_ENTREGA
    End Function
    Public Function getTaulaProjecteEntrega() As String
        Return TAULA_PROJECTE_ENTREGA
    End Function
    Public Function getTaulaProveidorAnotacio() As String
        Return TAULA_PROVEIDOR_ANOTACIO
    End Function
    Public Function getTaulaProveidorContacte() As String
        Return TAULA_PROVEIDOR_CONTACTES
    End Function
    Public Function getTaulaProveidor() As String
        Return TAULA_PROVEIDOR
    End Function
    Public Function getTaulaTipusIva() As String
        Return TAULA_TIPUS_IVA
    End Function
    Public Function getTaulaPais() As String
        Return TAULA_PAIS
    End Function
    Public Function getTaulaProvincia() As String
        Return TAULA_PROVINCIA
    End Function
    Public Function getTaulaTipusPagament() As String
        Return TAULA_tipus_pagament
    End Function
    Public Function getTaulaActualitzacio() As String
        Return TAULA_ACTUALITZACIO
    End Function
    Public Function getTaulaBudgetGB() As String
        getTaulaBudgetGB = TAULA_BUDGETSGB
    End Function
    Public Function getTaulaCentreGB() As String
        getTaulaCentreGB = TAULA_CENTRE_GB
    End Function
    Public Function getTaulaSubgrupGB() As String
        getTaulaSubgrupGB = TAULA_SUBGRUPGB
    End Function
    Public Function getTaulaParametres() As String
        getTaulaParametres = TAULA_PARAMETRES
    End Function
    Public Function getTaulaEmpresaContaplus() As String
        getTaulaEmpresaContaplus = TAULA_EMPRESA_CONTAPLUS
    End Function

    Public Function getTaulaSubcomptePretancament() As String
        getTaulaSubcomptePretancament = TAULA_SUBCOMPTE_PRETANCAMENT
    End Function
    Public Function getTaulaPrefixSubctePretancament() As String
        getTaulaPrefixSubctePretancament = TAULA_PREFIX_SUBCTE_PRETANCAMENT
    End Function
    Public Function getTaulaEstatMes() As String
        getTaulaEstatMes = TAULA_MESOS
    End Function
    Public Function getTaulaDepartament() As String
        getTaulaDepartament = TAULA_DEPARTAMENTS
    End Function
    Public Function getTaulaYelowSheet() As String
        getTaulaYelowSheet = TAULA_YELLOW_SHEET
    End Function
    Public Function getTaulaProjectesClient() As String
        getTaulaProjectesClient = TAULA_PROJECTE_CLIENT
    End Function

    Public Function getTaulaClient() As String
        getTaulaClient = TAULA_CLIENT
    End Function
    Public Function getTaulaTransitoria() As String
        getTaulaTransitoria = TAULA_TRANSITORIA
    End Function


    Public Function getTaulaSubcompteZamora()
        getTaulaSubcompteZamora = TAULA_SUBCOMPTE_ZAMORA
    End Function

    Public Function GetTaulaEmpresa() As String
        GetTaulaEmpresa = TAULA_EMPRESA
    End Function
    Public Function getTaulaCentreSubgrups() As String
        getTaulaCentreSubgrups = TAULA_SUBGRUPS_CENTRE
    End Function
    Public Function getTaulaPretancament() As String
        getTaulaPretancament = TAULA_PRETANCAMENT
    End Function
    Public Function getTaulaColumnesFilles() As String
        getTaulaColumnesFilles = TAULA_FILLA_COLUMNA
    End Function
    Public Function getTaulaProjectesColumna() As String
        getTaulaProjectesColumna = TAULA_PROJECTE_COLUMNA
    End Function
    Public Function getTaulaColumnes() As String
        getTaulaColumnes = TAULA_COLUMNA
    End Function
    Public Function getTaulaGrupsSeccio() As String
        getTaulaGrupsSeccio = TAULA_GRUPS_SECCIO
    End Function
    Public Function getTaulaSeccions() As String
        getTaulaSeccions = TAULA_SECCIO
    End Function
    Public Function getTaulaCentres() As String
        getTaulaCentres = TAULA_CENTRE
    End Function
    Public Function getTaulaProjecte() As String
        getTaulaProjecte = TAULA_PROJECTE
    End Function
    Public Function getTaulaCentreProjecte() As String
        getTaulaCentreProjecte = TAULA_EMP_PROJ
    End Function
    Public Function getTaulaSubcomptes() As String
        getTaulaSubcomptes = TAULA_SUBCOMPTES
    End Function
    Public Function getTaulaSubGrups() As String
        getTaulaSubGrups = TAULA_SUBGRUPS
    End Function
    Public Function getTaulaGrups() As String
        getTaulaGrups = TAULA_GRUPS
    End Function
    Public Function getTaulaSubcomptesGrup() As String
        getTaulaSubcomptesGrup = TAULA_SUBCOMPTES_SubGrup
    End Function
    Public Function getTaulaEstimacions() As String
        getTaulaEstimacions = TAULA_ESTIMACIONS
    End Function
    Public Function getRutaDBActual() As String
        getRutaDBActual = ""
        If CONFIG_FILE.getTag(CONFIG_FILE.TAG.ES_LOCAL) Then
            If CONFIG.folderExist(CONFIG.getDirectoriBDLocal) Then getRutaDBActual = CONFIG.getDirectoriBDLocal
        Else
            getRutaDBActual = CONFIG_FILE.getTag(TAG.RUTA_SERVIDOR_DADES)
        End If
    End Function
    Public Function getMaxId(t As String) As Long
        Dim sc As SqlCommand, sdr As SqlDataReader
        getMaxId = 0
        sc = New SqlCommand("SELECT max(id) AS MAXID FROM  " & t, getConnection)
        sdr = sc.ExecuteReader
        Try
            If sdr.Read() Then
                getMaxId = sdr("MAXID")
            End If
        Catch ex As Exception
            getMaxId = 0
        End Try

        sdr.Close()
        sdr = Nothing
        sc = Nothing
    End Function
    Public Function getMaxIdDBF(t As String) As Long
        Dim sc As ADODB.Command, rc As ADODB.Recordset
        getMaxIdDBF = 0
        sc = New ADODB.Command
        rc = New ADODB.Recordset
        With sc
            .ActiveConnection = getConnectionDbf()
            .CommandText = "SELECT max(id) AS MAXID FROM  " & t
        End With
        rc.Open(sc)
        Try
            If Not rc.EOF Then
                getMaxIdDBF = rc("MAXID").Value
            End If
        Catch ex As Exception
            getMaxIdDBF = 0
        Finally
            rc.Close()
            sc = Nothing
            rc = Nothing
        End Try
    End Function
    Public Function isUpdated(dateUpdate As DateTime, t As String) As Boolean
        If DateAdd(DateInterval.Minute, 1, dateUpdate) < Now() Then
            If getDateModified(CONFIG.setDbf(t)) > dateUpdate Then
                Return False
            End If
        End If
        Return True
    End Function
    Private Function getStringConnectionDBF(ruta As String) As String
        getStringConnectionDBF = "DRIVER=Microsoft Access dBASE Driver (*.dbf, *.ndx, *.mdx);UID = admin;UserCommitSync = Yes;" &
                                "Threads = 3;" &
                                "Statistics = 0;" &
                                "SafeTransactions = 0;" &
                                "PageTimeout = 600;" &
                                "MaxScanRows = 8;" &
                                "MaxBufferSize = 2048;" &
                                "FIL=dBASE 5.0;" &
                                "DriverId = 533;" &
                                "Deleted = 1;" &
                                "DefaultDir=" & ruta & " ;" &
                                "DBQ=" & ruta & ";" &
                                "CollatingSequence = ASCII"

    End Function
End Module
