Option Explicit On
Imports System.Data.SqlClient
Module dbEmpresaContaplus
    Private Const ID As String = "ID"
    Private Const ID_EMPRESA As String = "IDEMPRESA"
    Private Const ANYO As String = "ANYO"
    Private Const NOM As String = "NOM"
    Private Const CONTAPLUS As String = "CONTAPLUS"
    Public Function update(obj As Contaplus) As Integer
        If IS_SQLSERVER Then Return updateSQL(obj)
        Return updateDBF(obj)
    End Function
    Public Function insert(obj As Contaplus) As Integer
        If IS_SQLSERVER Then Return insertSQL(obj)
        Return insertDBF(obj)
    End Function
    Public Function remove(obj As Contaplus) As Boolean
        If IS_SQLSERVER Then Return removeSQL(obj)
        Return removeDBF(obj)
    End Function
    Friend Function removeEmpresa(idEmpresa As Integer) As Boolean
        If IS_SQLSERVER Then Return removeEmpresaSQL(idEmpresa)
        Return removeEmpresaDBF(idEmpresa)
    End Function
    Public Function getObjects() As List(Of Contaplus)
        If IS_SQLSERVER Then Return getObjectsSQL()
        Return getObjectsDBF()
    End Function
    Private Function insertSQL(obj As Contaplus) As Integer
        Dim sc As SqlCommand, i As Integer
        obj.id = DBCONNECT.getMaxId(getTable) + 1
        sc = New SqlCommand("INSERT INTO " & getTable() & " (" & ID & "," & ID_EMPRESA & "," & ANYO & "," & NOM & "," & CONTAPLUS & ") VALUES(@id,@idEmpresa,@anyo,@nom,@esContaplus) ", DBCONNECT.getConnection)
        sc.Parameters.Add("@id", SqlDbType.Int).Value = obj.id
        sc.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = obj.idEmpresa
        sc.Parameters.Add("@nom", SqlDbType.VarChar).Value = obj.nom
        sc.Parameters.Add("@anyo", SqlDbType.Int).Value = obj.anyo
        sc.Parameters.Add("@esContaplus", SqlDbType.Bit).Value = obj.esContaplus
        i = sc.ExecuteNonQuery
        sc = Nothing
        If i > 1 Then
            Return obj.id
        End If
        Return -1
    End Function
    Private Function updateSQL(obj As Contaplus) As Integer
        Dim sc As SqlCommand, i As Integer
        sc = New SqlCommand("UPDATE " & getTable() & " SET  " & ID_EMPRESA & "   = @idEmpresa,  " & ANYO & "   =@anyo,  " & NOM & "   = @nom, " & CONTAPLUS & "   =@esContaplus WHERE " & ID & "= @id ", DBCONNECT.getConnection)
        sc.Parameters.Add("@id", SqlDbType.Int).Value = obj.id
        sc.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = obj.idEmpresa
        sc.Parameters.Add("@nom", SqlDbType.VarChar).Value = obj.nom
        sc.Parameters.Add("@anyo", SqlDbType.Int).Value = obj.anyo
        sc.Parameters.Add("@esContaplus", SqlDbType.Bit).Value = obj.esContaplus
        i = sc.ExecuteNonQuery
        sc = Nothing
        If i > 1 Then
            Return obj.id
        End If
        Return -1
    End Function

    Private Function removeSQL(obj As Contaplus) As Boolean
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
    Private Function removeEmpresaSQL(idEmpresa As Integer) As Boolean
        Dim sc As SqlCommand, i As Integer
        sc = New SqlCommand("DELETE FROM " & getTable() & " WHERE " & ID_EMPRESA & "=@idEmpresa", DBCONNECT.getConnection)
        sc.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa
        i = sc.ExecuteNonQuery
        sc = Nothing
        If i > 1 Then
            Return True
        End If
        Return False
    End Function
    Private Function getObjectsSQL() As List(Of Contaplus)
        Dim sc As SqlCommand, sdr As SqlDataReader
        getObjectsSQL = New List(Of Contaplus)
        sc = New SqlCommand("Select * FROM " & getTable(), DBCONNECT.getConnection)
        sdr = sc.ExecuteReader
        While sdr.Read()
            getObjectsSQL.Add(New Contaplus(sdr(ID), sdr(ID_EMPRESA), sdr(ANYO), CONFIG.validarNull(sdr(NOM).ToString), sdr(CONTAPLUS)))
        End While
        sdr.Close()
        sdr = Nothing
        sc = Nothing
    End Function

    Private Function insertDBF(obj As Contaplus) As Integer
        Dim sc As ADODB.Command
        sc = New ADODB.Command
        obj.id = DBCONNECT.getMaxIdDBF(getTable) + 1
        With sc
            .ActiveConnection = DBCONNECT.getConnectionDbf
            .CommandText = "INSERT INTO " & getTable() & " (" & ID & "," & ID_EMPRESA & "," & ANYO & "," & NOM & "," & CONTAPLUS & ") VALUES(?,?,?,?,?) "
            .Parameters.Append(ADOPARAM.ToInt(obj.id))
            .Parameters.Append(ADOPARAM.ToInt(obj.idEmpresa))
            .Parameters.Append(ADOPARAM.ToInt(obj.anyo))
            .Parameters.Append(ADOPARAM.ToString(obj.nom))
            .Parameters.Append(ADOPARAM.toBool(obj.esContaplus))
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
    Private Function updateDBF(obj As Contaplus) As Integer
        Dim sc As ADODB.Command
        sc = New ADODB.Command
        obj.id = DBCONNECT.getMaxIdDBF(getTable) + 1
        With sc
            .ActiveConnection = DBCONNECT.getConnectionDbf
            .CommandText = "UPDATE " & getTable() & " SET  " & ID_EMPRESA & "   = ?,  " & ANYO & "   =?,  " & NOM & "   = ?, " & CONTAPLUS & "   =? WHERE " & ID & "= ? "

            .Parameters.Append(ADOPARAM.ToInt(obj.idEmpresa))
            .Parameters.Append(ADOPARAM.ToInt(obj.anyo))
            .Parameters.Append(ADOPARAM.ToString(obj.nom))
            .Parameters.Append(ADOPARAM.toBool(obj.esContaplus))
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

    Private Function removeDBF(obj As Contaplus) As Boolean
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
    Private Function removeEmpresaDBF(idEmpresa As Integer) As Boolean
        Dim sc As ADODB.Command
        sc = New ADODB.Command
        With sc
            sc.ActiveConnection = DBCONNECT.getConnectionDbf
            sc.CommandText = "DELETE FROM " & getTable() & " WHERE " & ID_EMPRESA & "=?"
            sc.Parameters.Append(ADOPARAM.ToInt(idEmpresa, ""))
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
    Private Function getObjectsDBF() As List(Of Contaplus)
        Dim rc As ADODB.Recordset
        rc = New ADODB.Recordset
        getObjectsDBF = New List(Of Contaplus)
        rc.Open("SELECT * FROM " & getTable(), DBCONNECT.getConnectionDbf)
        While Not rc.EOF
            getObjectsDBF.Add(New Contaplus(rc(ID).Value, rc(ID_EMPRESA).Value, rc(ANYO).Value, CONFIG.validarNull(rc(NOM).Value), rc(CONTAPLUS).Value))
            rc.MoveNext()
        End While
        If rc.State = 1 Then rc.Close()
        rc = Nothing
        getObjectsDBF.Sort()
    End Function
    Private Function getTable() As String
        Return DBCONNECT.getTaulaEmpresaContaplus
    End Function
End Module
