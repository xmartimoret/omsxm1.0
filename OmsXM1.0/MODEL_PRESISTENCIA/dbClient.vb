Option Explicit On
Imports System.Data.SqlClient
Module dbClient
    Private Const ID As String = "ID"
    Private Const NOM As String = "NOM"
    Private Const NOTES As String = "NOTES"
    Private Const ORDRE As String = "ORDRE"
    Private Const ACTIU As String = "ACTIU"
    Private Const COLOR As String = "COLOR"
    Public Function update(obj As Client) As Integer
        If IS_SQLSERVER Then Return updateSQL(obj)
        Return updateDBF(obj)
    End Function
    Public Function insert(obj As Client) As Integer
        If IS_SQLSERVER Then Return insertSQL(obj)
        Return insertDBF(obj)
    End Function
    Public Function remove(obj As Client) As Boolean
        If IS_SQLSERVER Then Return removeSQL(obj)
        Return removeDBF(obj)
    End Function
    Public Function getObjects() As List(Of Client)
        If IS_SQLSERVER Then Return getObjectsSQL()
        Return getObjectsDBF()
    End Function
    Private Function insertSQL(obj As Client) As Integer
        Dim sc As SqlCommand, i As Integer
        obj.id = DBCONNECT.getMaxId(getTable) + 1
        sc = New SqlCommand("INSERT INTO " & getTable() & " (" & ID & "," & NOM & "," & NOTES & "," & ORDRE & "," & ACTIU & "," & COLOR & " ) VALUES(@id,@nom,@notes,@ordre,@actiu,@color)", DBCONNECT.getConnection)
        sc.Parameters.Add("@id", SqlDbType.Int).Value = obj.id
        sc.Parameters.Add("@nom", SqlDbType.VarChar).Value = obj.nom
        sc.Parameters.Add("@notes", SqlDbType.VarChar).Value = obj.notes
        sc.Parameters.Add("@ordre", SqlDbType.Int).Value = Val(obj.ordre)
        sc.Parameters.Add("@actiu", SqlDbType.Int).Value = obj.actiu
        sc.Parameters.Add("@color", SqlDbType.Int).Value = obj.color
        i = sc.ExecuteNonQuery
        sc = Nothing
        If i > 1 Then
            Return obj.id
        End If
        Return -1
    End Function
    Private Function updateSQL(obj As Client) As Integer
        Dim sc As SqlCommand, i As Integer
        sc = New SqlCommand("UPDATE " & getTable() & " SET  " & NOM & " = @nom, " & NOTES & " =@notes, " & ORDRE & "   =@ordre, " & ACTIU & " =@actiu," & COLOR & "= @color  WHERE " & ID & "= @id ", DBCONNECT.getConnection)
        sc.Parameters.Add("@id", SqlDbType.Int).Value = obj.id
        sc.Parameters.Add("@nom", SqlDbType.VarChar).Value = obj.nom
        sc.Parameters.Add("@notes", SqlDbType.VarChar).Value = obj.notes
        sc.Parameters.Add("@ordre", SqlDbType.Int).Value = Val(obj.ordre)
        sc.Parameters.Add("@actiu", SqlDbType.Int).Value = obj.actiu
        sc.Parameters.Add("@color", SqlDbType.Int).Value = obj.color
        i = sc.ExecuteNonQuery
        sc = Nothing
        If i > 1 Then
            Return obj.id
        End If
        Return -1
    End Function
    Private Function removeSQL(obj As Client) As Boolean
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
    Private Function getObjectsSQL() As List(Of Client)
        Dim sc As SqlCommand, sdr As SqlDataReader
        getObjectsSQL = New List(Of Client)
        sc = New SqlCommand("SELECT * FROM " & getTable(), getConnection)
        sdr = sc.ExecuteReader
        While sdr.Read()
            getObjectsSQL.Add(New Client(sdr(ID), Trim(sdr(NOM)), Trim(sdr(NOTES)), sdr(ORDRE), sdr(ACTIU), sdr(COLOR), ModelProjecteClient.getObjects(sdr(ID))))
        End While
        sdr.Close()
        getObjectsSQL.Sort()
        sdr = Nothing
        sc = Nothing
    End Function


    Private Function insertDBF(obj As Client) As Integer
        Dim sc As ADODB.Command
        sc = New ADODB.Command
        obj.id = DBCONNECT.getMaxIdDBF(getTable) + 1
        With sc
            .ActiveConnection = DBCONNECT.getConnectionDbf
            .CommandText = "INSERT INTO " & getTable() & " (" & ID & "," & NOM & "," & NOTES & "," & ORDRE & "," & ACTIU & "," & COLOR & " ) VALUES(?,?,?,?,?,?)"
            .Parameters.Append(ADOPARAM.ToInt(obj.id))
            .Parameters.Append(ADOPARAM.ToString(obj.nom))
            .Parameters.Append(ADOPARAM.ToString(obj.notes))
            .Parameters.Append(ADOPARAM.ToString(obj.ordre))
            .Parameters.Append(ADOPARAM.toBool(obj.actiu))
            .Parameters.Append(ADOPARAM.ToInt(obj.color))
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
    Private Function updateDBF(obj As Client) As Integer
        Dim sc As ADODB.Command
        sc = New ADODB.Command
        With sc
            .ActiveConnection = DBCONNECT.getConnectionDbf
            .CommandText = "UPDATE " & getTable() & " SET  " & NOM & " = ?, " & NOTES & " =?, " & ORDRE & "   =?, " & ACTIU & " =?," & COLOR & "= ?  WHERE " & ID & "= ? "
            .Parameters.Append(ADOPARAM.ToString(obj.nom))
            .Parameters.Append(ADOPARAM.ToString(obj.notes))
            .Parameters.Append(ADOPARAM.ToString(obj.ordre))
            .Parameters.Append(ADOPARAM.toBool(obj.actiu))
            .Parameters.Append(ADOPARAM.ToInt(obj.color))
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
    Private Function removeDBF(obj As Client) As Boolean
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
    Public Function getObjectsDBF() As List(Of Client)
        Dim rc As ADODB.Recordset
        rc = New ADODB.Recordset
        getObjectsDBF = New List(Of Client)
        rc.Open("SELECT * FROM " & getTable(), getConnectionDbf)
        While Not rc.EOF
            getObjectsDBF.Add(New Client(rc(ID).Value, Trim(rc(NOM).Value), Trim(rc(NOTES).Value), rc(ORDRE).Value, rc(ACTIU).Value, rc(COLOR).Value, ModelProjecteClient.getObjects(rc(ID).Value)))
            rc.MoveNext()
        End While
        If rc.State = 1 Then rc.Close()
        rc = Nothing
        getObjectsDBF.Sort()
    End Function
    Private Function getTable() As String
        Return DBCONNECT.getTaulaClient
    End Function

End Module
