Option Explicit On
Imports System.Data.SqlClient
Module dbEstatMes
    Private Const MES As String = "MES"
    Private Const ANYO As String = "anyo"
    Private Const ID_EMPRESA As String = "idEmpresa"
    Private Const ESTAT_MES As String = "ESTAT"
    Private Const ESTAT_TRANSITORIA As String = "TRANSI"
    Public Function update(obj As EstatMes) As Integer
        If IS_SQLSERVER Then Return updateSQL(obj)
        Return updateDBF(obj)
    End Function
    Public Function insert(obj As EstatMes) As Integer
        If IS_SQLSERVER Then Return insertSQL(obj)
        Return insertDBF(obj)
    End Function

    Public Function getObjects() As List(Of EstatMes)
        If IS_SQLSERVER Then Return getObjectsSQL()
        Return getObjectsDBF()
    End Function

    Private Function insertSQL(obj As EstatMes) As Boolean
        Dim sc As SqlCommand, i As Integer
        sc = New SqlCommand("INSERT INTO " & getTable() & " (" & MES & "," & ANYO & "," & ID_EMPRESA & "," & ESTAT_MES & "," & ESTAT_TRANSITORIA & " ) VALUES(@mes,@anyo,@idEmpresa,@estatMes,@estatTransitoria)", DBCONNECT.getConnection)
        sc.Parameters.Add("@mes", SqlDbType.Int).Value = obj.mes
        sc.Parameters.Add("@anyo", SqlDbType.Int).Value = obj.anyo
        sc.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = obj.idEmpresa
        sc.Parameters.Add("@estatMes", SqlDbType.Bit).Value = Val(obj.estat)
        sc.Parameters.Add("@estatTransitoria", SqlDbType.Bit).Value = obj.estatTransitoria
        i = sc.ExecuteNonQuery
        sc = Nothing
        If i > 1 Then
            Return True
        End If
        Return False
    End Function
    Private Function updateSQL(obj As EstatMes) As Boolean
        Dim sc As SqlCommand, i As Integer
        sc = New SqlCommand("UPDATE " & getTable() & " SET  " & ESTAT_TRANSITORIA & " = @estatTransitoria, " & ESTAT_MES & " =@estatMes WHERE " & MES & "= @mes AND " & ANYO & "=@anyo AND " & ID_EMPRESA & "= @idEmpresa", DBCONNECT.getConnection)
        sc.Parameters.Add("@mes", SqlDbType.Int).Value = obj.mes
        sc.Parameters.Add("@anyo", SqlDbType.Int).Value = obj.anyo
        sc.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = obj.idEmpresa
        sc.Parameters.Add("@estatMes", SqlDbType.Bit).Value = Val(obj.estat)
        sc.Parameters.Add("@estatTransitoria", SqlDbType.Bit).Value = obj.estatTransitoria
        i = sc.ExecuteNonQuery
        sc = Nothing
        If i > 1 Then
            Return True
        End If
        Return False
    End Function
    Private Function getObjectsSQL() As List(Of EstatMes)
        Dim sc As SqlCommand, sdr As SqlDataReader
        getObjectsSQL = New List(Of EstatMes)
        sc = New SqlCommand("SELECT * FROM " & getTable(), getConnection)
        sdr = sc.ExecuteReader
        While sdr.Read()
            getObjectsSQL.Add(New EstatMes(sdr(MES), sdr(ANYO), sdr(ID_EMPRESA), sdr(ESTAT_MES), sdr(ESTAT_TRANSITORIA)))
        End While
        sdr.Close()
        getObjectsSQL.Sort()
        sdr = Nothing
        sc = Nothing
    End Function

    Private Function insertDBF(obj As EstatMes) As Boolean
        Dim sc As ADODB.Command
        sc = New ADODB.Command
        With sc
            .ActiveConnection = DBCONNECT.getConnectionDbf
            .CommandText = "INSERT INTO " & getTable() & " (" & MES & "," & ANYO & "," & ID_EMPRESA & "," & ESTAT_MES & "," & ESTAT_TRANSITORIA & " ) VALUES(?,?,?,?,?)"
            .Parameters.Append(ADOPARAM.ToInt(obj.mes))
            .Parameters.Append(ADOPARAM.ToInt(obj.anyo))
            .Parameters.Append(ADOPARAM.ToInt(obj.idEmpresa))
            .Parameters.Append(ADOPARAM.toBool(obj.estat))
            .Parameters.Append(ADOPARAM.toBool(obj.estatTransitoria))
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
    Private Function updateDBF(obj As EstatMes) As Boolean
        Dim sc As ADODB.Command
        sc = New ADODB.Command
        With sc
            .ActiveConnection = DBCONNECT.getConnectionDbf
            .CommandText = "UPDATE " & getTable() & " SET  " & ESTAT_TRANSITORIA & " = ?, " & ESTAT_MES & " =? WHERE " & MES & "= ? AND " & ANYO & "=? AND " & ID_EMPRESA & "= ?"
            .Parameters.Append(ADOPARAM.toBool(obj.estatTransitoria))
            .Parameters.Append(ADOPARAM.toBool(obj.estat))
            .Parameters.Append(ADOPARAM.ToInt(obj.mes))
            .Parameters.Append(ADOPARAM.ToInt(obj.anyo))
            .Parameters.Append(ADOPARAM.ToInt(obj.idEmpresa))
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
    Private Function getObjectsDBF() As List(Of EstatMes)
        Dim rc As ADODB.Recordset
        rc = New ADODB.Recordset
        getObjectsDBF = New List(Of EstatMes)
        rc.Open("SELECT * FROM " & getTable(), DBCONNECT.getConnectionDbf)
        While Not rc.EOF
            getObjectsDBF.Add(New EstatMes(rc(MES).Value, rc(ANYO).Value, rc(ID_EMPRESA).Value, rc(ESTAT_MES).Value, rc(ESTAT_TRANSITORIA).Value))
            rc.MoveNext()
        End While
        If rc.State = 1 Then rc.Close()
        rc = Nothing
        getObjectsDBF.Sort()
    End Function

    Private Function getTable() As String
        Return DBCONNECT.getTaulaEstatMes
    End Function
End Module
