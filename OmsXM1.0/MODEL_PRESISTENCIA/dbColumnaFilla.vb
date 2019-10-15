Option Explicit On
Imports System.Data.SqlClient
Module dbColumnaFilla
    Private Const IDFILLA As String = "IDFILLA"
    Private Const IDCOLUMNA As String = "IDCOLUMNA"
    Public Function insert(obj As ColumnaFilla) As Integer
        If IS_SQLSERVER Then Return insertSQL(obj)
        Return insertDBF(obj)
    End Function
    Public Function remove(obj As ColumnaFilla) As Boolean
        If IS_SQLSERVER Then Return removeSQL(obj)
        Return removeDBF(obj)
    End Function
    Public Function removeColumna(obj As Columna) As Boolean
        If IS_SQLSERVER Then Return removeColumnaSQL(obj)
        Return removeColumnaDBF(obj)
    End Function
    Public Function getObjects() As List(Of ColumnaFilla)
        If IS_SQLSERVER Then Return getObjectsSQL()
        Return getObjectsDBF()
    End Function

    Private Function insertSQL(obj As ColumnaFilla) As Boolean
        Dim sc As SqlCommand, i As Integer
        sc = New SqlCommand(" INSERT INTO " & getTable() & " " &
                                " (" & IDFILLA & ", " & IDCOLUMNA & ")" &
                                " VALUES(@idFilla,@idColumna)", DBCONNECT.getConnection)
        sc.Parameters.Add("@idFilla", SqlDbType.Int).Value = obj.idFilla
        sc.Parameters.Add("@idColumna", SqlDbType.Int).Value = obj.idColumna
        i = sc.ExecuteNonQuery
        sc = Nothing
        If i >= 1 Then
            Return True
        End If
        Return False
    End Function

    Private Function removeSQL(obj As ColumnaFilla) As Boolean
        Dim sc As SqlCommand, i As Integer
        sc = New SqlCommand("DELETE FROM " & getTable() & " WHERE " & IDCOLUMNA & " = @idColumna AND " & IDFILLA & " =@idFilla ", getConnection)
        sc.Parameters.Add("@idColumna", SqlDbType.Int).Value = obj.idColumna
        sc.Parameters.Add("@idFilla", SqlDbType.Int).Value = obj.idFilla
        i = sc.ExecuteNonQuery()
        sc = Nothing
        If i > 0 Then
            Return True
        End If
        Return False
    End Function
    Private Function removeColumnaSQL(c As Columna) As Boolean
        Dim sc As SqlCommand, i As Integer
        sc = New SqlCommand("DELETE FROM " & getTable() & " WHERE " & IDCOLUMNA & " = @idColumna", getConnection)
        sc.Parameters.Add("@idColumna", SqlDbType.Int).Value = c.id
        i = sc.ExecuteNonQuery()
        sc = Nothing
        If i > 0 Then
            Return True
        End If
        sc = Nothing
        Return False
    End Function
    Private Function getObjectsSQL() As List(Of ColumnaFilla)
        Dim sc As SqlCommand, sdr As SqlDataReader
        getObjectsSQL = New List(Of ColumnaFilla)
        sc = New SqlCommand("SELECT * FROM " & getTable(), getConnection)
        sdr = sc.ExecuteReader
        While sdr.Read()
            getObjectsSQL.Add(New ColumnaFilla(sdr(IDFILLA), sdr(IDCOLUMNA)))
        End While
        sdr.Close()
        getObjectsSQL.Sort()
        sdr = Nothing
        sc = Nothing
    End Function
    Private Function insertDBF(obj As ColumnaFilla) As Boolean
        Dim sc As ADODB.Command
        sc = New ADODB.Command
        With sc
            .ActiveConnection = DBCONNECT.getConnectionDbf
            .CommandText = " INSERT INTO " & getTable() & " " &
                                " (" & IDFILLA & ", " & IDCOLUMNA & ")" &
                                " VALUES(?,?)"
            .Parameters.Append(ADOPARAM.ToInt(obj.idFilla))
            .Parameters.Append(ADOPARAM.ToInt(obj.idColumna))

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

    Private Function removeDBF(obj As ColumnaFilla) As Boolean
        Dim sc As ADODB.Command
        sc = New ADODB.Command
        With sc
            .ActiveConnection = DBCONNECT.getConnectionDbf
            .CommandText = "DELETE FROM " & getTable() & " WHERE " & IDCOLUMNA & " = ? AND " & IDFILLA & " =? "
            .Parameters.Append(ADOPARAM.ToInt(obj.idColumna))
            .Parameters.Append(ADOPARAM.ToInt(obj.idFilla))

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
    Private Function removeColumnaDBF(c As Columna) As Boolean
        Dim sc As ADODB.Command
        sc = New ADODB.Command
        With sc
            .ActiveConnection = DBCONNECT.getConnectionDbf
            .CommandText = "DELETE FROM " & getTable() & " WHERE " & IDCOLUMNA & " = ?"
            .Parameters.Append(ADOPARAM.ToInt(c.id))
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
    Private Function getObjectsDBF() As List(Of ColumnaFilla)
        Dim rc As ADODB.Recordset
        rc = New ADODB.Recordset
        getObjectsDBF = New List(Of ColumnaFilla)
        rc.Open("SELECT * FROM " & getTable(), DBCONNECT.getConnectionDbf)
        While Not rc.EOF
            getObjectsDBF.Add(New ColumnaFilla(rc(IDFILLA).Value, rc(IDCOLUMNA).Value))
            rc.MoveNext()
        End While
        If rc.State = 1 Then rc.Close()
        rc = Nothing
        getObjectsDBF.Sort()
    End Function
    Friend Function getTable() As String
        getTable = DBCONNECT.getTaulaColumnesFilles
    End Function
End Module
