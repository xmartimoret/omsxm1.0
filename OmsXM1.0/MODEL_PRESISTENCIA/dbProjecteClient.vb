Option Explicit On
Imports System.Data.SqlClient
Module dbProjecteClient
    Private Const ID_PROJECTE As String = "IDPROJ"
    Private Const ID_CLIENT As String = "IDCLI"
    Private Const ORDRE As String = "ordre"
    Public Function update(obj As ProjecteClient) As Integer
        If IS_SQLSERVER Then Return updateSQL(obj)
        Return updateDBF(obj)
    End Function
    Public Function insert(obj As ProjecteClient) As Integer
        If IS_SQLSERVER Then Return insertSQL(obj)
        Return insertDBF(obj)
    End Function
    Public Function remove(idprojecte As Integer, idclient As Integer) As Boolean
        If IS_SQLSERVER Then Return removeSQL(idprojecte, idclient)
        Return removeDBF(idprojecte, idclient)
    End Function
    Friend Function removeClient(idClient As Integer) As Boolean
        If IS_SQLSERVER Then Return removeClientSQL(idClient)
        Return removeClientDBF(idClient)
    End Function
    Public Function getObjects() As List(Of ProjecteClient)
        If IS_SQLSERVER Then Return getObjectsSQL()
        Return getObjectsDBF()
    End Function
    Private Function insertSQL(obj As ProjecteClient) As Boolean
        Dim sc As SqlCommand, i As Integer
        sc = New SqlCommand(" INSERT INTO " & getTable() & " " &
                     " (" & ID_PROJECTE & ",  " & ID_CLIENT & "," & ORDRE & ")" &
                     " VALUES(@idProjecte,@idClient,@ordre)", DBCONNECT.getConnection)
        sc.Parameters.Add("@idProjecte", SqlDbType.Int).Value = obj.idProjecte
        sc.Parameters.Add("@idClient", SqlDbType.Int).Value = obj.idClient
        sc.Parameters.Add("@ordre", SqlDbType.Int).Value = Val(obj.ordre)
        i = sc.ExecuteNonQuery
        sc = Nothing
        If i > 1 Then
            Return True
        End If
        Return False
    End Function
    Private Function updateSQL(obj As ProjecteClient) As Boolean
        Dim sc As SqlCommand, i As Integer
        sc = New SqlCommand(" UPDATE " & getTable() & " SET " & ORDRE & "=@ordre" &
                 " WHERE " & ID_PROJECTE & "=@IdProjecte AND " & ID_CLIENT & " = @idClient", DBCONNECT.getConnection)
        sc.Parameters.Add("@idProjecte", SqlDbType.Int).Value = obj.idProjecte
        sc.Parameters.Add("@idClient", SqlDbType.Int).Value = obj.idClient
        sc.Parameters.Add("@ordre", SqlDbType.Int).Value = Val(obj.ordre)
        i = sc.ExecuteNonQuery
        sc = Nothing
        If i > 1 Then
            Return True
        End If
        Return False
    End Function
    Private Function removeSQL(idProjecte As Integer, idClient As Integer) As Boolean
        Dim sc As SqlCommand, i As Integer
        sc = New SqlCommand("DELETE FROM " & getTable() & " WHERE " & ID_PROJECTE & "=@idProjecte And " & ID_CLIENT & "= @IdClient", DBCONNECT.getConnection)
        sc.Parameters.Add("@idprojecte", SqlDbType.Int).Value = idProjecte
        sc.Parameters.Add("@idClient", SqlDbType.Int).Value = idClient
        i = sc.ExecuteNonQuery
        sc = Nothing
        If i > 1 Then
            Return True
        End If
        Return False
    End Function
    Private Function removeClientSQL(idClient As Integer) As Boolean
        Dim sc As SqlCommand, i As Integer
        sc = New SqlCommand("DELETE FROM " & getTable() & " WHERE  " & ID_CLIENT & "= @IdClient", DBCONNECT.getConnection)
        sc.Parameters.Add("@idClient", SqlDbType.Int).Value = idClient
        i = sc.ExecuteNonQuery
        sc = Nothing
        If i > 1 Then
            Return True
        End If
        Return False
    End Function
    Private Function getObjectsSQL() As List(Of ProjecteClient)
        Dim sc As SqlCommand, sdr As SqlDataReader, sqlString As String
        getObjectsSQL = New List(Of ProjecteClient)
        sqlString = "Select PC.IDPROJ As IDPROJ,PC.IDCLI As IDCLIENT, PC.ORDRE As ORDRE, P.CODI As CODI, P.NOM As NOM, P.IDEMPRESA As IDEMPRESA  " &
            " FROM " & getTable() & " As PC INNER JOIN " & getTableProjecte() & " As P On (PC.IDPROJ=P.ID) "
        sc = New SqlCommand(sqlString, DBCONNECT.getConnection)
        sdr = sc.ExecuteReader
        While sdr.Read()
            getObjectsSQL.Add(New ProjecteClient(sdr("IDCLIENT"), sdr("IDPROJ"), sdr("IDEMPRESA"), sdr("CODI"), sdr("NOM"), sdr("ORDRE")))
        End While
        sdr.Close()
        sdr = Nothing
        sc = Nothing
        getObjectsSQL.Sort()
    End Function

    Private Function insertDBF(obj As ProjecteClient) As Boolean
        Dim sc As ADODB.Command
        sc = New ADODB.Command
        With sc
            .ActiveConnection = DBCONNECT.getConnectionDbf
            .CommandText = " INSERT INTO " & getTable() & " " &
                     " (" & ID_PROJECTE & ",  " & ID_CLIENT & "," & ORDRE & ")" &
                     " VALUES(?,?,?)"
            .Parameters.Append(ADOPARAM.ToInt(obj.idProjecte))
            .Parameters.Append(ADOPARAM.ToInt(obj.idClient))
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
    Private Function updateDBF(obj As ProjecteClient) As Boolean
        Dim sc As ADODB.Command
        sc = New ADODB.Command
        With sc
            .ActiveConnection = DBCONNECT.getConnectionDbf
            .CommandText = " UPDATE " & getTable() & " SET " & ORDRE & "=?" &
                 " WHERE " & ID_PROJECTE & "=? AND " & ID_CLIENT & " = ?"
            .Parameters.Append(ADOPARAM.ToString(obj.ordre))
            .Parameters.Append(ADOPARAM.ToInt(obj.idProjecte))
            .Parameters.Append(ADOPARAM.ToInt(obj.idClient))
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
    Private Function removeDBF(idProjecte As Integer, idClient As Integer) As Boolean
        Dim sc As ADODB.Command
        sc = New ADODB.Command
        With sc
            sc.ActiveConnection = DBCONNECT.getConnectionDbf
            sc.CommandText = "DELETE FROM " & getTable() & " WHERE " & ID_PROJECTE & "=? And " & ID_CLIENT & "= ?"
            sc.Parameters.Append(ADOPARAM.ToInt(idProjecte))
            sc.Parameters.Append(ADOPARAM.ToInt(idClient))
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
    Private Function removeClientDBF(idClient As Integer) As Boolean
        Dim sc As ADODB.Command
        sc = New ADODB.Command
        With sc
            sc.ActiveConnection = DBCONNECT.getConnectionDbf
            sc.CommandText = "DELETE FROM " & getTable() & " WHERE " & ID_CLIENT & "= ?"
            sc.Parameters.Append(ADOPARAM.ToInt(idClient))
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
    Private Function getObjectsDBF() As List(Of ProjecteClient)
        Dim rc As ADODB.Recordset
        rc = New ADODB.Recordset
        getObjectsDBF = New List(Of ProjecteClient)
        rc.Open("Select PC.IDPROJ As IDPROJ,PC.IDCLI As IDCLIENT, PC.ORDRE As ORDRE, P.CODI As CODI, P.NOM As NOM, P.IDEMPRESA As IDEMPRESA  " &
            " FROM " & getTable() & " As PC INNER JOIN " & getTableProjecte() & " As P On (PC.IDPROJ=P.ID) ", DBCONNECT.getConnectionDbf)
        While Not rc.EOF
            getObjectsDBF.Add(New ProjecteClient(rc("IDCLIENT").Value, rc("IDPROJ").Value, rc("IDEMPRESA").Value, rc("CODI").Value, rc("NOM").Value, rc("ORDRE").Value))
            rc.MoveNext()
        End While
        If rc.State = 1 Then rc.Close()
        rc = Nothing
        getObjectsDBF.Sort()
    End Function
    Private Function getTable() As String
        getTable = DBCONNECT.getTaulaProjectesClient
    End Function
    Private Function getTableProjecte() As String
        getTableProjecte = DBCONNECT.getTaulaProjecte
    End Function
End Module
