Option Explicit On
Imports System.Data.SqlClient
Module dbTransitoria
    Private Const ANYO As String = "ANYO"
    Private Const MES As String = "MES"
    Private Const ID_EMPRESA As String = "IDEMPRESA"
    Private Const ID_PROJECTE As String = "PROJECT"
    Private Const ID_SUBCOMPTE As String = "SUBCTE"
    Private Const YSHEET As String = "YSHEET"
    Private Const VAS As String = "VAS"
    Private Const VAAN As String = "VAAN"
    Private Const VAAC As String = "VAAC"
    Private Const VSAN As String = "VSAN"
    Private Const VSAC As String = "VSAC"
    Friend Function getAnyos(idEmpresa As Integer) As Integer()
        If IS_SQLSERVER Then Return getAnyosSQL(idEmpresa)
        Return getAnyosDBF(idEmpresa)
    End Function
    Public Function getMesos(idEmpresa As Integer, pAnyo As Integer) As List(Of Mes)
        If IS_SQLSERVER Then Return getMesosSQL(idEmpresa, pAnyo)
        Return getMesosDBF(idEmpresa, pAnyo)
    End Function
    Public Function getListAnys(idEmpresa As Integer) As List(Of Integer)
        If IS_SQLSERVER Then Return getListAnysSQL(idEmpresa)
        Return getListAnysDBF(idEmpresa)
    End Function
    Public Function insert(obj As Transitoria) As Integer
        If IS_SQLSERVER Then Return insertSQL(obj)
        Return insertDBF(obj)
    End Function
    Public Function remove(idProjecte As Integer, pAnyo As Integer) As Boolean
        If IS_SQLSERVER Then Return removeSQL(idProjecte, pAnyo)
        Return removeDBF(idProjecte, pAnyo)
    End Function
    Public Function remove(idProjecte As Integer, pAnyo As Integer, pMes As Integer) As Boolean
        If IS_SQLSERVER Then Return removeSQL(idProjecte, pAnyo, pMes)
        Return removeDBF(idProjecte, pAnyo, pMes)
    End Function
    Public Function removeProjecte(idProjecte As Integer) As Boolean
        If IS_SQLSERVER Then Return removeProjecteSQL(idProjecte)
        Return removeProjecteDBF(idProjecte)
    End Function
    Public Function getObjects(anyActual As Integer) As List(Of Transitoria)()
        If IS_SQLSERVER Then Return getObjectsSQL(anyActual)
        Return getObjectsDBF(anyActual)
    End Function
    Private Function getAnyosSQL(idEmpresa As Integer) As Integer()
        Dim sc As SqlCommand, sdr As SqlDataReader, dades(1000) As Integer, i As Integer, temp() As Integer
        sc = New SqlCommand("SELECT distinct " & ANYO & " FROM " & getTable() & " WHERE idEmpresa = @idEmpresa ORDER BY " & ANYO, DBCONNECT.getConnection)
        sc.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa
        sdr = sc.ExecuteReader
        i = 0
        While sdr.Read()
            dades(i) = sdr(ANYO)
            i = i + 1
        End While
        sdr.Close()
        sdr = Nothing
        sc = Nothing
        If i > 0 Then
            ReDim temp(i - 1)
            For i = 0 To UBound(temp)
                temp(i) = dades(i)
            Next i
        Else
            ReDim temp(0)
        End If
        Return temp
    End Function
    Private Function getListAnysSQL(idEmpresa As Integer) As List(Of Integer)
        Dim sc As SqlCommand, sdr As SqlDataReader
        sc = New SqlCommand("SELECT distinct " & ANYO & " FROM " & getTable() & " WHERE " & ID_EMPRESA & "=@idEmpresa order by " & ANYO, DBCONNECT.getConnection)
        sc.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa
        sdr = sc.ExecuteReader
        getListAnysSQL = New List(Of Integer)
        While sdr.Read()
            getListAnysSQL.Add(sdr(ANYO))
        End While
        sdr.Close()
        sdr = Nothing
        sc = Nothing
    End Function
    Private Function getMesosSQL(idEmpresa As Integer, pAnyo As Integer) As List(Of Mes)
        Dim sc As SqlCommand, sdr As SqlDataReader
        getMesosSQL = New List(Of Mes)
        sc = New SqlCommand("SELECT distinct " & MES & " FROM " & getTable() & " WHERE " & ID_EMPRESA & "=@idEmpresa and " & ANYO & " = @anyo order by " & MES, DBCONNECT.getConnection)
        sc.Parameters.Add("@anyo", SqlDbType.Int).Value = pAnyo
        sc.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa
        sdr = sc.ExecuteReader
        While sdr.Read()
            getMesosSQL.Add(New Mes(sdr("MES"), CONFIG.mesNom(sdr("MES"))))
        End While
        sdr.Close()
        sdr = Nothing
        sc = Nothing
    End Function
    Private Function insertSQL(t As Transitoria) As Boolean
        Dim sc As SqlCommand, i As Integer, sqlString As String
        sqlString = "INSERT INTO " & getTable() & "(" & ANYO & "," & ID_EMPRESA & "," & ID_PROJECTE & "," & ID_SUBCOMPTE & "," & MES & "," & VAAC & "," & VAAN & "," & VAS & "," & VSAC & "," & VSAN & "," & YSHEET & ") " &
                                                   " VALUES(@anyo,@idEmpresa,@idProjecte,@idSubcompte,@mes,@vaac,@vaan,@vas,@vsac,@vsan,@ysheet)"
        sc = New SqlCommand(sqlString, DBCONNECT.getConnection)
        sc.Parameters.Add("@anyo", SqlDbType.Int).Value = t.anyo
        sc.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = t.idEmpresa
        sc.Parameters.Add("@idProjecte", SqlDbType.Int).Value = t.idProjecte
        sc.Parameters.Add("@idSubcompte", SqlDbType.Int).Value = t.idSubcompte
        sc.Parameters.Add("@mes", SqlDbType.Int).Value = t.mes
        sc.Parameters.Add("@vaac", SqlDbType.Decimal).Value = t.valorAActual
        sc.Parameters.Add("@vaan", SqlDbType.Decimal).Value = t.valorAAnterior
        sc.Parameters.Add("@vas", SqlDbType.Decimal).Value = t.valorAS
        sc.Parameters.Add("@vsac", SqlDbType.Decimal).Value = t.valorSActual
        sc.Parameters.Add("@vsan", SqlDbType.Decimal).Value = t.valorSAnterior
        sc.Parameters.Add("@ysheet", SqlDbType.VarChar).Value = CONFIG.validarNull(t.codiYellowSheet)
        i = sc.ExecuteNonQuery
        sc = Nothing
        If i >= 1 Then
            Return True
        End If
        Return False
    End Function
    Private Function removeSQL(idProjecte As Integer, pAnyo As Integer) As Boolean
        Dim sc As SqlCommand, result As Boolean
        result = False
        sc = New SqlCommand("DELETE FROM " & getTable() & " WHERE " & ID_PROJECTE & "=@idProjecte And " & ANYO & " = @Anyo", DBCONNECT.getConnection)
        sc.Parameters.Add("@idProjecte", SqlDbType.Int).Value = idProjecte
        sc.Parameters.Add("@Anyo", SqlDbType.Int).Value = pAnyo
        Call sc.ExecuteNonQuery()
        sc = Nothing
        result = True
        Return result
    End Function
    Private Function removeSQL(idProjecte As Integer, pAnyo As Integer, pMes As Integer) As Boolean
        Dim sc As SqlCommand, result As Boolean
        result = False
        sc = New SqlCommand("DELETE FROM " & getTable() & " WHERE " & ID_PROJECTE & "=@idProjecte AND " & ANYO & " = @Anyo AND " & MES & " =@Mes", DBCONNECT.getConnection)
        sc.Parameters.Add("@idProjecte", SqlDbType.Int).Value = idProjecte
        sc.Parameters.Add("@Mes", SqlDbType.Int).Value = pMes
        sc.Parameters.Add("@Anyo", SqlDbType.Int).Value = pAnyo
        Call sc.ExecuteNonQuery()
        sc = Nothing
        result = True
        Return result
    End Function
    Private Function removeProjecteSQL(idProjecte As Integer) As Boolean
        Dim sc As SqlCommand, i As Integer
        sc = New SqlCommand("DELETE FROM " & getTable() & " WHERE " & ID_PROJECTE & "=@idProjecte", DBCONNECT.getConnection)
        sc.Parameters.Add("@idProjecte", SqlDbType.Int).Value = idProjecte
        i = sc.ExecuteNonQuery
        sc = Nothing
        If i > 1 Then
            Return True
        End If
        Return False
    End Function
    Private Function getObjectsSQL(anyActual As Integer) As List(Of Transitoria)()
        Dim sc As SqlCommand, sdr As SqlDataReader, objects(12) As List(Of Transitoria)
        sc = New SqlCommand("SELECT * FROM " & getTable() & " WHERE " & ANYO & " = @anyo", DBCONNECT.getConnection)
        sc.Parameters.Add("@anyo", SqlDbType.Int).Value = anyActual
        sdr = sc.ExecuteReader
        While sdr.Read()
            If objects(sdr(MES)) Is Nothing Then objects(sdr(MES)) = New List(Of Transitoria)
            objects(sdr(MES)).Add(New Transitoria(sdr(MES), sdr(ANYO), sdr(ID_EMPRESA), sdr(ID_PROJECTE), CONFIG.validarNull(sdr(YSHEET)), sdr(ID_SUBCOMPTE), sdr(VAS), sdr(VAAN), sdr(VAAC), sdr(VSAN), sdr(VSAC)))
        End While
        sdr.Close()
        sdr = Nothing
        sc = Nothing
        Return objects
    End Function

    Private Function getAnyosDBF(idEmpresa As Integer) As Integer()
        Dim rc As ADODB.Recordset, dades(1000) As Integer, i As Integer, temp() As Integer
        rc = New ADODB.Recordset
        rc.Open("SELECT distinct " & ANYO & " FROM " & getTable() & " WHERE idEmpresa = " & idEmpresa & " ORDER BY " & ANYO, DBCONNECT.getConnectionDbf)
        i = 0
        While Not rc.EOF
            dades(i) = rc(ANYO).Value
            i = i + 1
            rc.MoveNext()
        End While
        rc.Close()
        rc = Nothing
        If i > 0 Then
            ReDim temp(i - 1)
            For i = 0 To UBound(temp)
                temp(i) = dades(i)
            Next i
        Else
            ReDim temp(0)
        End If
        Return temp
    End Function
    Private Function getListAnysDBF(idEmpresa As Integer) As List(Of Integer)
        Dim rc As ADODB.Recordset
        rc = New ADODB.Recordset
        rc.Open("SELECT distinct " & ANYO & " FROM " & getTable() & " WHERE idEmpresa = " & idEmpresa & " ORDER BY " & ANYO, DBCONNECT.getConnectionDbf)
        getListAnysDBF = New List(Of Integer)
        While Not rc.EOF
            getListAnysDBF.Add(rc(ANYO).Value)
            rc.MoveNext()
        End While
        rc.Close()
        rc = Nothing
    End Function
    Private Function getMesosDBF(idEmpresa As Integer, pAnyo As Integer) As List(Of Mes)
        Dim rc As ADODB.Recordset
        rc = New ADODB.Recordset
        rc.Open("SELECT distinct " & MES & " FROM " & getTable() & " WHERE " & ID_EMPRESA & "=" & idEmpresa & " and " & ANYO & " = " & pAnyo & " order by " & MES, DBCONNECT.getConnectionDbf)
        getMesosDBF = New List(Of Mes)
        While Not rc.EOF
            getMesosDBF.Add(rc(MES).Value)
            rc.MoveNext()
        End While
        rc.Close()
        rc = Nothing
    End Function
    Private Function insertDBF(obj As Transitoria) As Boolean
        Dim sc As ADODB.Command
        sc = New ADODB.Command
        With sc
            .ActiveConnection = DBCONNECT.getConnectionDbf
            .CommandText = "INSERT INTO " & getTable() & "(" & ANYO & "," & ID_EMPRESA & "," & ID_PROJECTE & "," & ID_SUBCOMPTE & "," & MES & "," & VAAC & "," & VAAN & "," & VAS & "," & VSAC & "," & VSAN & "," & YSHEET & ") " &
                                                   " VALUES(?,?,?,?,?,?,?,?,?,?,?)"
            .Parameters.Append(ADOPARAM.ToInt(obj.anyo))
            .Parameters.Append(ADOPARAM.ToInt(obj.idEmpresa))
            .Parameters.Append(ADOPARAM.ToInt(obj.idProjecte))
            .Parameters.Append(ADOPARAM.ToInt(obj.idSubcompte))
            .Parameters.Append(ADOPARAM.ToInt(obj.mes))
            .Parameters.Append(ADOPARAM.ToSingle(obj.valorAActual))
            .Parameters.Append(ADOPARAM.ToSingle(obj.valorAAnterior))
            .Parameters.Append(ADOPARAM.ToSingle(obj.valorAS))
            .Parameters.Append(ADOPARAM.ToSingle(obj.valorSActual))
            .Parameters.Append(ADOPARAM.ToSingle(obj.valorSAnterior))
            .Parameters.Append(ADOPARAM.ToString(obj.codiYellowSheet))
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
    Private Function removeDBF(idProjecte As Integer, pAnyo As Integer) As Boolean
        Dim sc As ADODB.Command
        sc = New ADODB.Command
        With sc
            .ActiveConnection = DBCONNECT.getConnectionDbf
            .CommandText = "DELETE FROM " & getTable() & " WHERE " & ID_PROJECTE & "=? And " & ANYO & " = ?"
            .Parameters.Append(ADOPARAM.ToInt(idProjecte))
            .Parameters.Append(ADOPARAM.ToInt(pAnyo))
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
    Private Function removeDBF(idProjecte As Integer, pAnyo As Integer, pMes As Integer) As Boolean
        Dim sc As ADODB.Command
        sc = New ADODB.Command
        With sc
            .ActiveConnection = DBCONNECT.getConnectionDbf
            .CommandText = "DELETE FROM " & getTable() & " WHERE " & ID_PROJECTE & "=? AND " & ANYO & " =? AND " & MES & " =?"
            .Parameters.Append(ADOPARAM.ToInt(idProjecte))
            .Parameters.Append(ADOPARAM.ToInt(pAnyo))
            .Parameters.Append(ADOPARAM.ToInt(pMes))
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
    Private Function removeProjecteDBF(idProjecte As Integer) As Boolean
        Dim sc As ADODB.Command
        sc = New ADODB.Command
        With sc
            .ActiveConnection = DBCONNECT.getConnectionDbf
            .CommandText = "DELETE FROM " & getTable() & " WHERE " & ID_PROJECTE & "=?"
            .Parameters.Append(ADOPARAM.ToInt(idProjecte))
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
    Private Function getObjectsDBF(anyActual As Integer) As List(Of Transitoria)()
        Dim rc As ADODB.Recordset, objects(12) As List(Of Transitoria)
        rc = New ADODB.Recordset
        rc.Open("SELECT * FROM " & getTable() & " WHERE " & ANYO & " =" & anyActual, DBCONNECT.getConnectionDbf)
        While Not rc.EOF
            If objects(rc(MES).Value) Is Nothing Then objects(rc(MES).Value) = New List(Of Transitoria)
            objects(rc(MES).Value).Add(New Transitoria(rc(MES).Value, rc(ANYO).Value, rc(ID_EMPRESA).Value, rc(ID_PROJECTE).Value, CONFIG.validarNull(rc(YSHEET).Value), rc(ID_SUBCOMPTE).Value, rc(VAS).Value, rc(VAAN).Value, rc(VAAC).Value, rc(VSAN).Value, rc(VSAC).Value))
            rc.MoveNext()
        End While
        If rc.State = 1 Then rc.Close()
        rc = Nothing
        Return objects
    End Function
    Private Function getTable() As String
        getTable = DBCONNECT.getTaulaTransitoria
    End Function

End Module
