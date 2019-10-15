Option Explicit On
Imports System.Data.SqlClient
Module dbPrefixSubcompte
    Private Const ID As String = "ID"
    Private Const ID_SUBCOMPTE As String = "IDSUBCTE"
    Private Const PREFIX As String = "PREFIX"
    Public Function update(obj As PrefixSubcte) As Integer
        If IS_SQLSERVER Then Return updateSQL(obj)
        Return updateDBF(obj)
    End Function
    Public Function insert(obj As PrefixSubcte) As Integer
        If IS_SQLSERVER Then Return insertSQL(obj)
        Return insertDBF(obj)
    End Function
    Public Function remove(obj As PrefixSubcte) As Boolean
        If IS_SQLSERVER Then Return removeSQL(obj)
        Return removeDBF(obj)
    End Function
    Public Function getObjects() As List(Of PrefixSubcte)
        If IS_SQLSERVER Then Return getObjectsSQL()
        Return getObjectsDBF()
    End Function

    Private Function insertSQL(obj As PrefixSubcte) As Integer
        Dim sc As SqlCommand, i As Integer
        obj.id = DBCONNECT.getMaxId(getTable()) + 1
        sc = New SqlCommand(" INSERT INTO " & getTable() &
                                " (" & ID & "," & ID_SUBCOMPTE & "," & PREFIX & ")" &
                                " VALUES(@id,@idSubcompte,@prefix)", DBCONNECT.getConnection)
        sc.Parameters.AddWithValue("@id", obj.id)
        sc.Parameters.AddWithValue("@idSubcompte", obj.idSubcompte)
        sc.Parameters.AddWithValue("@prefix", obj.prefix)
        i = sc.ExecuteNonQuery
        sc = Nothing
        Return i
    End Function
    Private Function updateSQL(obj As PrefixSubcte) As Integer
        Dim sc As SqlCommand, i As Integer
        sc = New SqlCommand("UPDATE " & getTable() &
                                " SET " & ID_SUBCOMPTE & "=@idSubcompte, " & PREFIX & "=@prefix " &
                                " WHERE " & ID & "=@id", DBCONNECT.getConnection)
        sc.Parameters.AddWithValue("@id", obj.id)
        sc.Parameters.AddWithValue("@idSubcompte", obj.idSubcompte)
        sc.Parameters.AddWithValue("@prefix", obj.prefix)
        i = sc.ExecuteNonQuery()
        sc = Nothing
        Return i
    End Function
    Private Function removeSQL(obj As PrefixSubcte) As Boolean
        Dim sc As SqlCommand, i As Integer
        sc = New SqlCommand("DELETE FROM " & getTable() & " WHERE " & ID & "=@id", DBCONNECT.getConnection)
        sc.Parameters.Add("@id", SqlDbType.VarChar, 20, ParameterDirection.Input).Value = obj.id
        Try
            i = sc.ExecuteNonQuery
        Catch ex As SqlException
            Throw New ExcepcioSql(ExcepcioSql.ERR_REMOVE & vbCrLf & vbCrLf & ex.Message)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
        sc = Nothing
        If i >= 1 Then
            Return True
        End If
        Return False
    End Function
    Private Function getObjectsSQL() As List(Of PrefixSubcte)
        Dim sc As SqlCommand, sdr As SqlDataReader
        getObjectsSQL = New List(Of PrefixSubcte)
        sc = New SqlCommand("SELECT PS.ID AS psid , PS.IDSUBCTE AS psIdSubcte, PS.PREFIX AS psPrefix, s.codi as scodi, s.descripcio as sdescripcio FROM " & getTable() & " AS PS INNER JOIN " & DBCONNECT.getTaulaSubcomptes & " AS S ON(PS.IDSUBCTE = S.ID)", DBCONNECT.getConnection)
        sdr = sc.ExecuteReader
        While sdr.Read()
            getObjectsSQL.Add(New PrefixSubcte(sdr("psid"), sdr("psIdSubcte"), sdr("psPrefix"), sdr("scodi"), sdr("sdescripcio")))
        End While
        sdr.Close()
        sdr = Nothing
        sc = Nothing
    End Function

    Private Function insertDBF(obj As PrefixSubcte) As Integer
        Dim sc As ADODB.Command
        sc = New ADODB.Command
        obj.id = DBCONNECT.getMaxIdDBF(getTable) + 1
        With sc
            .ActiveConnection = DBCONNECT.getConnectionDbf
            .CommandText = " INSERT INTO " & getTable() &
                                " (" & ID & "," & ID_SUBCOMPTE & "," & PREFIX & ")" &
                                " VALUES(?,?,?)"
            .Parameters.Append(ADOPARAM.ToInt(obj.id))
            .Parameters.Append(ADOPARAM.ToInt(obj.idSubcompte))
            .Parameters.Append(ADOPARAM.ToString(obj.prefix))

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
    Private Function updateDBF(obj As PrefixSubcte) As Integer
        Dim sc As ADODB.Command
        sc = New ADODB.Command

        With sc
            .ActiveConnection = DBCONNECT.getConnectionDbf
            .CommandText = "UPDATE " & getTable() &
                                " SET " & ID_SUBCOMPTE & "=?, " & PREFIX & "=? " &
                                " WHERE " & ID & "=?"
            .Parameters.Append(ADOPARAM.ToInt(obj.idSubcompte))
            .Parameters.Append(ADOPARAM.ToString(obj.prefix))
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
    Private Function removeDBF(obj As PrefixSubcte) As Boolean
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
    Private Function getObjectsDBF() As List(Of PrefixSubcte)
        Dim rc As ADODB.Recordset
        rc = New ADODB.Recordset
        getObjectsDBF = New List(Of PrefixSubcte)
        rc.Open("SELECT PS.ID AS psid , PS.IDSUBCTE AS psIdSubcte, PS.PREFIX AS psPrefix, s.codi as scodi, s.descripcio as sdescripcio FROM " & getTable() & " AS PS INNER JOIN " & DBCONNECT.getTaulaSubcomptes & " AS S ON(PS.IDSUBCTE = S.ID)", DBCONNECT.getConnectionDbf)
        While Not rc.EOF
            getObjectsDBF.Add(New PrefixSubcte(rc("psid").Value, rc("psIdSubcte").Value, rc("psPrefix").Value, rc("scodi").Value, rc("sdescripcio").Value))
            rc.MoveNext()
        End While
        If rc.State = 1 Then rc.Close()
        rc = Nothing
        getObjectsDBF.Sort()
    End Function
    Private Function getTable() As String
        Return DBCONNECT.getTaulaPrefixSubctePretancament
    End Function
End Module
