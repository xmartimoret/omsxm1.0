Option Explicit On
Imports System.Data.SqlClient
Module dbSubcompte
    Private Const ID As String = "id"
    Private Const CODI As String = "codi"
    Private Const NOM As String = "descripcio"
    Private Const NOTES As String = "NOTES"
    Public Function update(obj As Subcompte) As Integer
        If IS_SQLSERVER Then Return updateSQL(obj)
        Return updateDBF(obj)
    End Function
    Public Function insert(obj As Subcompte) As Integer
        If IS_SQLSERVER Then Return insertSQL(obj)
        Return insertDBF(obj)
    End Function
    Public Function remove(obj As Subcompte) As Boolean
        If IS_SQLSERVER Then Return removeSQL(obj)
        Return removeDBF(obj)
    End Function
    Public Function getObjects() As List(Of Subcompte)
        If IS_SQLSERVER Then Return getObjectsSQL()
        Return getObjectsDBF()
    End Function

    Private Function insertSQL(obj As Subcompte) As Integer
        Dim sc As SqlCommand
        obj.id = DBCONNECT.getMaxId(getTable()) + 1
        sc = New SqlCommand(" INSERT INTO " & getTable() &
                                " (" & ID & "," & CODI & "," & NOM & ")" &
                                " VALUES(@id,@codi,@nom)", DBCONNECT.getConnection)

        sc.Parameters.AddWithValue("@id", obj.id)
        sc.Parameters.AddWithValue("@codi", obj.codi)
        sc.Parameters.AddWithValue("@nom", obj.nom)
        If sc.ExecuteNonQuery() > 1 Then
            sc = Nothing
            Return obj.id
        End If
        sc = Nothing
        Return -1
    End Function
    Private Function updateSQL(obj As Subcompte) As Integer
        Dim sc As SqlCommand

        sc = New SqlCommand("UPDATE " & getTable() &
                                " SET " & CODI & "=@codi, " & NOM & "=@nom " &
                                " WHERE " & ID & "=@id", DBCONNECT.getConnection)

        sc.Parameters.AddWithValue("@id", obj.id)
        sc.Parameters.AddWithValue("@codi", obj.codi)
        sc.Parameters.AddWithValue("@nom", obj.nom)
        If sc.ExecuteNonQuery() > 1 Then
            sc = Nothing
            Return obj.id
        End If
        sc = Nothing
        Return -1
    End Function
    Private Function removeSQL(obj As Subcompte) As Boolean
        Dim sc As SqlCommand, i As Integer
        sc = New SqlCommand("DELETE FROM " & getTable() & " WHERE " & ID & "=@id", DBCONNECT.getConnection)
        sc.Parameters.Add("@id", SqlDbType.VarChar, 20, ParameterDirection.Input).Value = obj.id
        i = sc.ExecuteNonQuery
        sc = Nothing
        If i > 1 Then
            Return True
        End If
        Return False
    End Function
    Private Function getObjectsSQL() As List(Of Subcompte)
        Dim sc As SqlCommand, sdr As SqlDataReader
        getObjectsSQL = New List(Of Subcompte)
        sc = New SqlCommand("SELECT * FROM " & getTable(), DBCONNECT.getConnection)
        sdr = sc.ExecuteReader
        While sdr.Read()
            getObjectsSQL.Add(New Subcompte(sdr(ID), Trim(sdr(CODI)), Trim(sdr(CODI)), Trim(sdr(NOM))))
        End While
        sdr.Close()
        sdr = Nothing
        sc = Nothing
    End Function

    Private Function insertDBF(obj As Subcompte) As Integer
        Dim sc As ADODB.Command
        sc = New ADODB.Command
        obj.id = DBCONNECT.getMaxIdDBF(getTable) + 1
        With sc
            .ActiveConnection = DBCONNECT.getConnectionDbf
            .CommandText = " INSERT INTO " & getTable() &
                                " (" & ID & "," & CODI & "," & NOM & ")" &
                                " VALUES(?,?,?)"
            .Parameters.Append(ADOPARAM.ToInt(obj.id))
            .Parameters.Append(ADOPARAM.ToString(obj.codi))
            .Parameters.Append(ADOPARAM.ToString(obj.nom))

        End With
        Try
            sc.Execute()
            Return obj.id
        Catch ex As Exception
            Call ERRORS.ERR_EXCEPTION_SQL(ex.Message)
            Return -1
        Finally
            sc = Nothing
        End Try
    End Function
    Private Function updateDBF(obj As Subcompte) As Integer
        Dim sc As ADODB.Command
        sc = New ADODB.Command
        With sc
            .ActiveConnection = DBCONNECT.getConnectionDbf
            .CommandText = "UPDATE " & getTable() &
                                " SET " & CODI & "=?, " & NOM & "=? " &
                                " WHERE " & ID & "=?"

            .Parameters.Append(ADOPARAM.ToString(obj.codi))
            .Parameters.Append(ADOPARAM.ToString(obj.nom))
            .Parameters.Append(ADOPARAM.ToInt(obj.id))
        End With
        Try
            sc.Execute()
            Return obj.id
        Catch ex As Exception
            Call ERRORS.ERR_EXCEPTION_SQL(ex.Message)
            Return -1
        Finally
            sc = Nothing
        End Try
    End Function
    Private Function removeDBF(obj As Subcompte) As Boolean
        Dim sc As ADODB.Command
        sc = New ADODB.Command
        With sc
            sc.ActiveConnection = DBCONNECT.getConnectionDbf
            sc.CommandText = " DELETE FROM " & getTable() & " WHERE " & ID & "=?"
            sc.Parameters.Append(ADOPARAM.ToInt(obj.id, ""))
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
        rc.Open("SELECT * FROM " & getTable(), DBCONNECT.getConnectionDbf)
        While Not rc.EOF
            getObjectsDBF.Add(New Subcompte(rc(ID).Value, Trim(rc(CODI).Value), Trim(rc(CODI).Value), Trim(rc(NOM).Value)))
            rc.MoveNext()
        End While
        If rc.State = 1 Then rc.Close()
        rc = Nothing
        getObjectsDBF.Sort()
    End Function
    Private Function getTable() As String
        Return DBCONNECT.getTaulaSubcomptes
    End Function
End Module
