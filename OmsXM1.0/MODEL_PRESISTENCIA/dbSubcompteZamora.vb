Option Explicit On
Imports System.Data.SqlClient
Module dbSubcompteZamora
    Private Const ID As String = "ID"
    Private Const ID_SUBCOMPTE As String = "IDSUB"
    Private Const NOM As String = "NOM"
    Private Const UNIC As String = "UNIC"
    Public Function update(obj As SubcompteZamora) As Integer
        If IS_SQLSERVER Then Return updateSQL(obj)
        Return updateDBF(obj)
    End Function
    Public Function insert(obj As SubcompteZamora) As Integer
        If IS_SQLSERVER Then Return insertSQL(obj)
        Return insertDBF(obj)
    End Function
    Public Function remove(obj As SubcompteZamora) As Boolean
        If IS_SQLSERVER Then Return removeSQL(obj)
        Return removeDBF(obj)
    End Function
    Public Function deleteAll() As Boolean
        If IS_SQLSERVER Then Return deleteAllSQL()
        Return deleteAllDBF()
    End Function
    Public Function getObjects() As List(Of SubcompteZamora)
        If IS_SQLSERVER Then Return getObjectsSQL()
        Return getObjectsDBF()
    End Function

    Private Function insertSQL(obj As SubcompteZamora) As Integer
        Dim sc As SqlCommand, i As Integer
        obj.id = DBCONNECT.getMaxId(getTable) + 1
        sc = New SqlCommand("INSERT INTO " & getTable() & " (" & ID & "," & ID_SUBCOMPTE & "," & NOM & "," & UNIC & ") VALUES(@id,@idSubcompte,@nom,@unic) ", DBCONNECT.getConnection)
        sc.Parameters.Add("@id", SqlDbType.Int).Value = obj.id
        sc.Parameters.Add("@idSubcompte", SqlDbType.VarChar).Value = obj.idSubcompte
        sc.Parameters.Add("@nom", SqlDbType.VarChar).Value = obj.nom
        sc.Parameters.Add("@unic", SqlDbType.Bit).Value = obj.esUnic
        i = sc.ExecuteNonQuery
        sc = Nothing
        If i > 1 Then
            Return obj.id
        End If
        Return -1
    End Function
    Private Function updateSQL(obj As SubcompteZamora) As Integer
        Dim sc As SqlCommand, i As Integer

        sc = New SqlCommand("UPDATE " & getTable() & " SET  " & ID_SUBCOMPTE & "   = @idSubcompte,  " & NOM & "   =@nom,  " & UNIC & "   = @unic  WHERE " & ID & "= @id ", DBCONNECT.getConnection)

        sc.Parameters.Add("@id", SqlDbType.Int).Value = obj.id
        sc.Parameters.Add("@idSubcompte", SqlDbType.VarChar).Value = obj.idSubcompte
        sc.Parameters.Add("@nom", SqlDbType.VarChar).Value = obj.nom
        sc.Parameters.Add("@unic", SqlDbType.Bit).Value = obj.esUnic
        i = sc.ExecuteNonQuery
        sc = Nothing
        If i > 1 Then
            Return obj.id
        End If
        Return -1

    End Function
    Private Function removeSQL(s As SubcompteZamora) As Boolean
        Dim sc As SqlCommand, i As Integer
        sc = New SqlCommand("DELETE  FROM " & getTable() & " WHERE " & ID & "=@id", DBCONNECT.getConnection)
        sc.Parameters.Add("@id", SqlDbType.Int).Value = s.id
        i = sc.ExecuteNonQuery
        sc = Nothing
        If i > 1 Then
            Return True
        End If
        Return False
    End Function
    Private Function deleteAllSQL() As Boolean
        Dim sc As SqlCommand, i As Integer
        sc = New SqlCommand("DELETE * FROM " & getTable(), DBCONNECT.getConnection)
        i = sc.ExecuteNonQuery
        sc = Nothing
        If i > 1 Then
            Return True
        End If
        Return False
    End Function
    Private Function getObjectsSQL() As List(Of SubcompteZamora)
        Dim sc As SqlCommand, sdr As SqlDataReader
        getObjectsSQL = New List(Of SubcompteZamora)
        sc = New SqlCommand("Select * FROM " & getTable(), DBCONNECT.getConnection)
        sdr = sc.ExecuteReader
        While sdr.Read()
            getObjectsSQL.Add(New SubcompteZamora(sdr(ID), sdr(ID_SUBCOMPTE), Trim(sdr(NOM)), sdr(UNIC)))
        End While
        sdr.Close()
        sdr = Nothing
        sc = Nothing
    End Function
    Private Function insertDBF(obj As SubcompteZamora) As Integer
        Dim sc As ADODB.Command
        sc = New ADODB.Command
        obj.id = DBCONNECT.getMaxIdDBF(getTable) + 1
        With sc
            .ActiveConnection = DBCONNECT.getConnectionDbf
            .CommandText = "INSERT INTO " & getTable() & " (" & ID & "," & ID_SUBCOMPTE & "," & NOM & "," & UNIC & ") VALUES(?,?,?,?) "
            .Parameters.Append(ADOPARAM.ToInt(obj.id))
            .Parameters.Append(ADOPARAM.ToInt(obj.idSubcompte))
            .Parameters.Append(ADOPARAM.ToString(obj.nom))
            .Parameters.Append(ADOPARAM.toBool(obj.esUnic))
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
    Private Function updateDBF(obj As SubcompteZamora) As Integer
        Dim sc As ADODB.Command
        sc = New ADODB.Command
        With sc
            .ActiveConnection = DBCONNECT.getConnectionDbf
            .CommandText = "UPDATE " & getTable() & " SET  " & ID_SUBCOMPTE & "   = ?,  " & NOM & "   ?,  " & UNIC & "   = ?  WHERE " & ID & "= ? "
            .Parameters.Append(ADOPARAM.ToInt(obj.idSubcompte))
            .Parameters.Append(ADOPARAM.ToString(obj.nom))
            .Parameters.Append(ADOPARAM.toBool(obj.esUnic))
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
    Private Function removeDBF(s As SubcompteZamora) As Boolean
        Dim sc As ADODB.Command
        sc = New ADODB.Command
        With sc
            sc.ActiveConnection = DBCONNECT.getConnectionDbf
            sc.CommandText = "DELETE FROM " & getTable() & " WHERE " & ID & "=? "
            sc.Parameters.Append(ADOPARAM.ToInt(s.id, ""))
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
    Private Function deleteAllDBF() As Boolean
        Dim sc As ADODB.Command
        sc = New ADODB.Command
        With sc
            sc.ActiveConnection = DBCONNECT.getConnectionDbf
            sc.CommandText = "DELETE FROM " & getTable()
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
    Private Function getObjectsDBF() As List(Of SubcompteZamora)
        Dim rc As ADODB.Recordset
        rc = New ADODB.Recordset
        getObjectsDBF = New List(Of SubcompteZamora)
        rc.Open("Select * FROM " & getTable(), DBCONNECT.getConnectionDbf)
        While Not rc.EOF
            getObjectsDBF.Add(New SubcompteZamora(rc(ID).Value, rc(ID_SUBCOMPTE).Value, Trim(rc(NOM).Value), rc(UNIC).Value))
            rc.MoveNext()
        End While
        If rc.State = 1 Then rc.Close()
        rc = Nothing
        getObjectsDBF.Sort()
    End Function
    Private Function getTable() As String
        Return DBCONNECT.getTaulaSubcompteZamora
    End Function

End Module
