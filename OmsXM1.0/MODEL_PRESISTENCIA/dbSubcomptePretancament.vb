Option Explicit On
Imports System.Data.SqlClient
Module dbSubcomptePretancament

    Public Function insert(id As Integer) As Integer
        If IS_SQLSERVER Then Return insertSQL(id)
        Return insertDBF(id)
    End Function

    Public Function getObjects() As List(Of Subcompte)
        If IS_SQLSERVER Then Return getObjectsSQL()
        Return getObjectsDBF()
    End Function
    Private Function insertSQL(id As Integer) As Boolean
        Dim sc As SqlCommand, j As Integer
        sc = New SqlCommand("INSERT INTO " & getTable() & " VALUES(" & id & ")", DBCONNECT.getConnection)
        j = sc.ExecuteNonQuery
        sc = Nothing
        If j > 1 Then
            Return True
        Else
            Return False
        End If
    End Function
    Private Function getObjectsSQL() As List(Of Subcompte)
        Dim sc As SqlCommand, sdr As SqlDataReader
        getObjectsSQL = New List(Of Subcompte)
        sc = New SqlCommand("Select S.ID As ID , s.codi As CODI, s.DESCRIPCIO AS NOM " &
            " FROM " & getTable() & " AS SP INNER JOIN " & DBCONNECT.getTaulaSubcomptes & " As S ON (SP.IDSUBCTE = S.ID)", DBCONNECT.getConnection)
        sdr = sc.ExecuteReader
        While sdr.Read()
            getObjectsSQL.Add(New Subcompte(sdr("ID"), Trim(sdr("CODI")), Trim(sdr("CODI")), Trim(sdr("NOM"))))
        End While
        sdr.Close()
        sdr = Nothing
        sc = Nothing
    End Function
    Private Function insertDBF(id As Integer) As Boolean
        Dim sc As ADODB.Command
        sc = New ADODB.Command

        With sc
            .ActiveConnection = DBCONNECT.getConnectionDbf
            .CommandText = "INSERT INTO " & getTable() & " VALUES(" & id & ")"
        End With
        Try
            sc.Execute()
            Return True
        Catch ex As Exception
            Call ERRORS.ERR_EXCEPTION_SQL(ex.Message)
            Return False
        Finally
            sc = Nothing
        End Try
    End Function
    Private Function getObjectsDBF() As List(Of Subcompte)
        Dim rc As ADODB.Recordset
        rc = New ADODB.Recordset
        getObjectsDBF = New List(Of Subcompte)
        rc.Open("Select S.ID As SID , s.codi As CODI, s.DESCRIPCIO AS NOM " &
            " FROM " & getTable() & " AS SP INNER JOIN " & DBCONNECT.getTaulaSubcomptes & " As S ON (SP.IDSUBCTE = S.ID)", DBCONNECT.getConnectionDbf)
        While Not rc.EOF
            getObjectsDBF.Add(New Subcompte(rc("SID").Value, Trim(rc("CODI").Value), Trim(rc("CODI").Value), Trim(rc("NOM").Value)))
            rc.MoveNext()
        End While
        If rc.State = 1 Then rc.Close()
        rc = Nothing
        getObjectsDBF.Sort()
    End Function
    Private Function getTable() As String
        Return DBCONNECT.getTaulaSubcomptePretancament
    End Function
End Module
