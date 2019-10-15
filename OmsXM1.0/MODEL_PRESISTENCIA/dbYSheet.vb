Option Explicit On
Imports System.Data.SqlClient
Module dbYSheet
    Private Const ID As String = "ID"
    Private Const NOM As String = "NOM"
    Private Const CODI As String = "CODI"
    Private Const ORDRE As String = "ORDRE"
    Public Function update(obj As YSheet) As Integer
        If IS_SQLSERVER Then Return updateSQL(obj)
        Return updateDBF(obj)
    End Function
    Public Function insert(obj As YSheet) As Integer
        If IS_SQLSERVER Then Return insertSQL(obj)
        Return insertDBF(obj)
    End Function
    Public Function remove(obj As YSheet) As Boolean
        If IS_SQLSERVER Then Return removeSQL(obj)
        Return removeDBF(obj)
    End Function
    Public Function getObjects() As List(Of YSheet)
        If IS_SQLSERVER Then Return getObjectsSQL()
        Return getObjectsDBF()
    End Function

    Private Function insertSQL(obj As YSheet) As Integer
        Dim sc As SqlCommand, i As Integer
        obj.id = DBCONNECT.getMaxId(getTable) + 1
        sc = New SqlCommand("INSERT INTO " & getTable() & " (" & ID & "," & CODI & "," & NOM & "," & ORDRE & " ) VALUES(@id,@codi,@nom,@ordre)", DBCONNECT.getConnection)
        sc.Parameters.Add("@id", SqlDbType.Int).Value = obj.id
        sc.Parameters.Add("@nom", SqlDbType.VarChar).Value = obj.nom
        sc.Parameters.Add("@codi", SqlDbType.VarChar).Value = obj.codi
        sc.Parameters.Add("@ordre", SqlDbType.Int).Value = Val(obj.ordre)
        i = sc.ExecuteNonQuery
        sc = Nothing
        If i > 1 Then
            Return obj.id
        End If
        Return -1
    End Function
    Private Function updateSQL(obj As YSheet) As Integer
        Dim sc As SqlCommand, i As Integer
        sc = New SqlCommand("UPDATE " & getTable() & " SET  " & CODI & " = @codi, " & NOM & " =@nom, " & ORDRE & "   =@ordre  WHERE " & ID & "= @id ", DBCONNECT.getConnection)
        sc.Parameters.Add("@id", SqlDbType.Int).Value = obj.id
        sc.Parameters.Add("@nom", SqlDbType.VarChar).Value = obj.nom
        sc.Parameters.Add("@codi", SqlDbType.VarChar).Value = obj.codi
        sc.Parameters.Add("@ordre", SqlDbType.Int).Value = Val(obj.ordre)
        i = sc.ExecuteNonQuery
        sc = Nothing
        If i > 1 Then
            Return obj.id
        End If
        Return -1
    End Function
    Private Function removeSQL(obj As YSheet) As Boolean
        Dim sc As SqlCommand, i As Integer
        sc = New SqlCommand("DELETE FROM " & getTable() & " WHERE " & ID & "=@id", DBCONNECT.getConnection)
        sc.Parameters.Add("@id", SqlDbType.Int).Value = obj.id
        i = sc.ExecuteNonQuery
        sc = Nothing
        If i > 1 Then
            Return True
        End If
        Return False
    End Function
    Private Function getObjectsSQL() As List(Of YSheet)
        Dim sc As SqlCommand, sdr As SqlDataReader
        getObjectsSQL = New List(Of YSheet)
        sc = New SqlCommand("SELECT * FROM " & getTable(), getConnection)
        sdr = sc.ExecuteReader
        While sdr.Read()
            getObjectsSQL.Add(New YSheet(sdr(ID), Trim(sdr(CODI)), Trim(sdr(NOM)), sdr(ORDRE)))
        End While
        sdr.Close()
        getObjectsSQL.Sort()
        sdr = Nothing
        sc = Nothing
    End Function

    Private Function insertDBF(obj As YSheet) As Integer
        Dim sc As ADODB.Command
        sc = New ADODB.Command
        obj.id = DBCONNECT.getMaxIdDBF(getTable) + 1
        With sc
            .ActiveConnection = DBCONNECT.getConnectionDbf
            .CommandText = "INSERT INTO " & getTable() & " (" & ID & "," & CODI & "," & NOM & "," & ORDRE & " ) VALUES(@id,@codi,@nom,@ordre)"
            .Parameters.Append(ADOPARAM.ToInt(obj.id))
            .Parameters.Append(ADOPARAM.ToString(obj.codi))
            .Parameters.Append(ADOPARAM.ToString(obj.nom))
            .Parameters.Append(ADOPARAM.ToString(obj.ordre))
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
    Private Function updateDBF(obj As YSheet) As Integer
        Dim sc As ADODB.Command
        sc = New ADODB.Command
        With sc
            .ActiveConnection = DBCONNECT.getConnectionDbf
            .CommandText = "UPDATE " & getTable() & " SET  " & CODI & " = ?, " & NOM & " =?, " & ORDRE & "   =?  WHERE " & ID & "= ? "
            .Parameters.Append(ADOPARAM.ToString(obj.codi))
            .Parameters.Append(ADOPARAM.ToString(obj.nom))
            .Parameters.Append(ADOPARAM.ToString(obj.ordre))
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
    Private Function removeDBF(obj As YSheet) As Boolean
        Dim sc As ADODB.Command
        sc = New ADODB.Command
        With sc
            .ActiveConnection = DBCONNECT.getConnectionDbf
            .CommandText = "DELETE FROM " & getTable() & " WHERE " & ID & "=@id"
            .Parameters.Append(ADOPARAM.ToInt(obj.id))
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
    Private Function getObjectsDBF() As List(Of YSheet)
        Dim rc As ADODB.Recordset
        rc = New ADODB.Recordset
        getObjectsDBF = New List(Of YSheet)
        rc.Open("SELECT * FROM " & getTable(), DBCONNECT.getConnectionDbf)
        While Not rc.EOF
            getObjectsDBF.Add(New YSheet(rc(ID).Value, Trim(rc(CODI).Value), Trim(rc(NOM).Value), rc(ORDRE).Value))
            rc.MoveNext()
        End While
        If rc.State = 1 Then rc.Close()
        rc = Nothing
        getObjectsDBF.Sort()
    End Function
    Private Function getTable() As String
        getTable = DBCONNECT.getTaulaYelowSheet
    End Function
End Module
