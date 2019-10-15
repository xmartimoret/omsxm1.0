Option Explicit On
Imports System.Data.SqlClient
Module dbColumna
    Private Const ID As String = "ID"
    Private Const CODI As String = "CODI"
    Private Const NOM As String = "NOM"
    Private Const ACUMULAT As String = "ACUMULAT"
    Private Const ORDRE As String = "ORDRE"

    Public Function update(obj As Columna) As Integer
        If IS_SQLSERVER Then Return updateSQL(obj)
        Return updateDBF(obj)
    End Function
    Public Function update(pId As Integer, pCodi As String) As String
        If IS_SQLSERVER Then Return updateSQL(pId, pCodi)
        Return updateDBF(pId, pCodi)
    End Function
    Public Function insert(obj As Columna) As Integer
        If IS_SQLSERVER Then Return insertSQL(obj)
        Return insertDBF(obj)
    End Function
    Public Function remove(obj As Columna) As Boolean
        If IS_SQLSERVER Then Return removeSQL(obj)
        Return removeDBF(obj)
    End Function
    Public Function getObjects() As List(Of Columna)
        If IS_SQLSERVER Then Return getObjectsSQL()
        Return getObjectsDBF()
    End Function

    Private Function insertSQL(obj As Columna) As Integer
        Dim sc As SqlCommand, i As Integer
        obj.id = DBCONNECT.getMaxId(getTable()) + 1
        sc = New SqlCommand(" INSERT INTO " & getTable() & " " &
                                " (" & ID & ", " & CODI & ", " & NOM & ", " & ORDRE & ", " & ACUMULAT & ")" &
                                "   VALUES(@id,@codi,@nom,@ordre,@acumulat)", DBCONNECT.getConnection)

        sc.Parameters.Add("@id", SqlDbType.Int).Value = CInt(obj.id)
        sc.Parameters.Add("@codi", SqlDbType.VarChar).Value = obj.codi
        sc.Parameters.Add("@nom", SqlDbType.VarChar).Value = obj.nom
        sc.Parameters.Add("@ordre", SqlDbType.Int).Value = obj.ordre
        sc.Parameters.Add("@acumulat", SqlDbType.Bit).Value = obj.totalitzador
        i = sc.ExecuteNonQuery
        sc = Nothing
        If i > 1 Then
            Return obj.id
        End If
        Return -1
    End Function
    Private Function updateSQL(obj As Columna) As Integer
        Dim sc As SqlCommand, i As Integer
        sc = New SqlCommand("UPDATE " & getTable() & " " &
                                " SET " & CODI & "=@codi," & NOM & " =@nom, " & ORDRE & "=@ordre ," & ACUMULAT & "=@acumulat " &
                                " WHERE " & ID & "=@id", DBCONNECT.getConnection)
        sc.Parameters.Add("@id", SqlDbType.Int).Value = CInt(obj.id)
        sc.Parameters.Add("@codi", SqlDbType.VarChar).Value = obj.codi
        sc.Parameters.Add("@nom", SqlDbType.VarChar).Value = obj.nom
        sc.Parameters.Add("@ordre", SqlDbType.Int).Value = obj.ordre
        sc.Parameters.Add("@acumulat", SqlDbType.Bit).Value = obj.totalitzador
        i = sc.ExecuteNonQuery
        sc = Nothing
        If i >= 1 Then
            Return obj.id
        End If
        Return -1
    End Function
    Private Function updateSQL(pId As Integer, pCodi As String) As String
        Dim sc As SqlCommand, i As Integer
        sc = New SqlCommand("UPDATE " & getTable() & " " &
                                " SET " & CODI & "=@codi" &
                                " WHERE " & ID & "=@id", DBCONNECT.getConnection)
        sc.Parameters.Add("@id", SqlDbType.Int).Value = pId
        sc.Parameters.Add("@codi", SqlDbType.VarChar).Value = pId
        i = sc.ExecuteNonQuery
        sc = Nothing
        If i >= 1 Then
            Return pCodi
        End If
        Return -1
    End Function
    Private Function removeSQL(obj As Columna) As Boolean
        Dim sc As SqlCommand, i As Integer
        sc = New SqlCommand("DELETE FROM " & getTable() & " WHERE " & ID & " = @id", getConnection)
        sc.Parameters.Add("@id", SqlDbType.Int).Value = obj.id
        i = sc.ExecuteNonQuery()
        If i > 0 Then
            sc = Nothing

            Return True
        End If
        sc = Nothing
        Return False
    End Function
    Private Function getObjectsSQL() As List(Of Columna)
        Dim sc As SqlCommand, sdr As SqlDataReader
        getObjectsSQL = New List(Of Columna)
        sc = New SqlCommand("SELECT * FROM " & getTable() & " ORDER BY " & ORDRE, getConnection)
        sdr = sc.ExecuteReader
        While sdr.Read()
            getObjectsSQL.Add(New Columna(sdr(ID), Trim(sdr(CODI)), Trim(sdr(NOM)), sdr(ACUMULAT), ModelProjecteColumna.getObjects(sdr(ID), ""), ModelColumnaFilla.getObjects(sdr(ID))))
        End While
        sdr.Close()
        getObjectsSQL.Sort()
        sdr = Nothing
        sc = Nothing
    End Function


    Private Function insertDBF(obj As Columna) As Integer
        Dim sc As ADODB.Command
        sc = New ADODB.Command
        obj.id = DBCONNECT.getMaxIdDBF(getTable) + 1
        With sc
            .ActiveConnection = DBCONNECT.getConnectionDbf
            .CommandText = " INSERT INTO " & getTable() & " " &
                                " (" & ID & ", " & CODI & ", " & NOM & ", " & ORDRE & ", " & ACUMULAT & ")" &
                                "   VALUES(?,?,?,?,?)"

            .Parameters.Append(ADOPARAM.ToInt(obj.id))
            .Parameters.Append(ADOPARAM.ToString(obj.codi))
            .Parameters.Append(ADOPARAM.ToString(obj.nom))
            .Parameters.Append(ADOPARAM.ToString(obj.ordre))
            .Parameters.Append(ADOPARAM.toBool(obj.totalitzador))

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
    Private Function updateDBF(obj As Columna) As Integer
        Dim sc As ADODB.Command
        sc = New ADODB.Command
        With sc
            .ActiveConnection = DBCONNECT.getConnectionDbf
            .CommandText = "UPDATE " & getTable() & " " &
                                " SET " & CODI & "=?," & NOM & " =?, " & ORDRE & "=? ," & ACUMULAT & "=? " &
                                " WHERE " & ID & "=?"
            .Parameters.Append(ADOPARAM.ToString(obj.codi))
            .Parameters.Append(ADOPARAM.ToString(obj.nom))
            .Parameters.Append(ADOPARAM.ToString(obj.ordre))
            .Parameters.Append(ADOPARAM.toBool(obj.totalitzador))
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
    Private Function updateDBF(pId As Integer, pCodi As String) As String
        Dim sc As ADODB.Command
        sc = New ADODB.Command
        With sc
            .ActiveConnection = DBCONNECT.getConnectionDbf
            .CommandText = "UPDATE " & getTable() & " " &
                                " SET " & CODI & "=@codi" &
                                " WHERE " & ID & "=@id"
            .Parameters.Append(ADOPARAM.ToString(pCodi))
            .Parameters.Append(ADOPARAM.ToInt(pId))
        End With
        Try
            sc.Execute()
            Return pCodi
        Catch ex As Exception
            Call ERRORS.ERR_EXCEPTION_SQL(ex.Message)
            Return "-1"
        Finally
            sc = Nothing
        End Try
    End Function
    Private Function removeDBF(obj As Columna) As Boolean
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
    Private Function getObjectsDBF() As List(Of Columna)
        Dim rc As ADODB.Recordset
        rc = New ADODB.Recordset
        getObjectsDBF = New List(Of Columna)
        rc.Open("SELECT * FROM " & getTable(), DBCONNECT.getConnectionDbf)
        While Not rc.EOF
            getObjectsDBF.Add(New Columna(rc(ID).Value, Trim(rc(CODI).Value), Trim(rc(NOM).Value), rc(ACUMULAT).Value, ModelProjecteColumna.getObjects(rc(ID).Value, ""), ModelColumnaFilla.getObjects(rc(ID).Value)))
            rc.MoveNext()
        End While
        If rc.State = 1 Then rc.Close()
        rc = Nothing

    End Function
    Private Function getTable() As String
        getTable = DBCONNECT.getTaulaColumnes
    End Function
End Module
