
Option Explicit On
Imports System.Data.SqlClient
Module dbComentarisMD
    Public Function getObjects() As List(Of ComentariMD)
        Return getObjectsSQL()
    End Function

    Private Function getObjectsSQL() As List(Of ComentariMD)
        Dim sc As SqlCommand, sdr As SqlDataReader, a As ComentariMD
        getObjectsSQL = New List(Of ComentariMD)
        sc = New SqlCommand("Select IDCOMENTARIO,E.IDRECURSO as idRecurs,U.LOGIN as login ,FECHAHORA,COMENTARIO " &
                        " FROM " & getTable() & " as C  INNER JOIN " & getTableEvents() & " AS E  ON (C.IDEVENTO = E.IDEVENTO)" & " INNER JOIN [mydb].[DBO].[TUSUARIOS] AS U ON (U.IDUSU = C.USUARIO ) " &
                        " WHERE E.IDTABLA=11 And C.ELIMINADO=0 AND YEAR(FECHAHORA)>= 2021", DBCONNECT.getConnectioMyDoc)
        sdr = sc.ExecuteReader
        While sdr.Read()
            a = New ComentariMD(sdr("IDCOMENTARIO"), sdr("login"), sdr("FECHAHORA"), sdr("idrecurs"))
            a.comentari = sdr("COMENTARIO")
            getObjectsSQL.Add(a)
        End While
        sdr.Close()
        getObjectsSQL.Sort()
        sdr = Nothing
        sc = Nothing
    End Function
    Private Function getTable() As String
        Return "dbo.TWFCOMENTARIOS"
    End Function
    Private Function getTableEvents() As String
        Return "dbo.TWFEVENTOS"
    End Function
End Module

