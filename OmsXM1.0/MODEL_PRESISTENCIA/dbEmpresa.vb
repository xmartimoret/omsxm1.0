Option Explicit On
Imports System.Data.SqlClient
Module dbEmpresa
    Private Const ID As String = "ID"
    Private Const CIF As String = "CIF"
    Private Const CODI As String = "CODI"
    Private Const NOM As String = "NOM"
    Private Const NOTES As String = "NOTES"
    Private Const ORDRE As String = "ORDRE"
    Private Const PARTICIPACIO As String = "PARTICIPA"
    Public Function update(obj As Empresa) As Integer
        If IS_SQLSERVER Then Return updateSQL(obj)
        Return updateDBF(obj)
    End Function
    Public Function insert(obj As Empresa) As Integer
        If IS_SQLSERVER Then Return insertSQL(obj)
        Return insertDBF(obj)
    End Function
    Public Function remove(obj As Empresa) As Boolean
        If IS_SQLSERVER Then Return removeSQL(obj)
        Return removeDBF(obj)
    End Function
    Public Function getObjects() As List(Of Empresa)
        If IS_SQLSERVER Then Return getObjectsSQL()
        Return getObjectsDBF()
    End Function
    Private Function insertSQL(obj As Empresa) As Integer
        Dim sc As SqlCommand, i As Integer
        obj.id = DBCONNECT.getMaxId(getTable) + 1
        sc = New SqlCommand("INSERT INTO " & getTable() & " (" & ID & "," & CODI & "," & CIF & "," & NOM & "," & NOTES & "," & ORDRE & "," & PARTICIPACIO & ") VALUES(@id,@codi,@cif,@nom,@notes,@ordre,@participacio) ", DBCONNECT.getConnection)
        sc.Parameters.Add("@id", SqlDbType.Int).Value = obj.id
        sc.Parameters.Add("@cif", SqlDbType.VarChar).Value = obj.cif
        sc.Parameters.Add("@codi", SqlDbType.VarChar).Value = obj.codi
        sc.Parameters.Add("@nom", SqlDbType.VarChar).Value = obj.nom
        sc.Parameters.Add("@notes", SqlDbType.VarChar).Value = obj.notes
        sc.Parameters.Add("@ordre", SqlDbType.Int).Value = Val(obj.ordre)
        sc.Parameters.Add("@participacio", SqlDbType.Int).Value = obj.participacio
        i = sc.ExecuteNonQuery
        sc = Nothing
        If i > 1 Then
            Return obj.id
        End If
        Return -1
    End Function
    Private Function updateSQL(obj As Empresa) As Integer
        Dim sc As SqlCommand, i As Integer
        sc = New SqlCommand("UPDATE " & getTable() & " SET  " & CODI & "   = @codi,  " & CIF & "   =@cif,  " & NOM & "   = @nom, " & NOTES & "   =@notes, " & PARTICIPACIO & "   =@participacio, " & ORDRE & "   =@ordre  WHERE " & ID & "= @id ", DBCONNECT.getConnection)
        sc.Parameters.Add("@id", SqlDbType.Int).Value = obj.id
        sc.Parameters.Add("@cif", SqlDbType.VarChar).Value = obj.cif
        sc.Parameters.Add("@codi", SqlDbType.VarChar).Value = obj.codi
        sc.Parameters.Add("@nom", SqlDbType.VarChar).Value = obj.nom
        sc.Parameters.Add("@notes", SqlDbType.VarChar).Value = obj.notes
        sc.Parameters.Add("@ordre", SqlDbType.Int).Value = Val(obj.ordre)
        sc.Parameters.Add("@participacio", SqlDbType.Int).Value = obj.participacio
        i = sc.ExecuteNonQuery
        sc = Nothing
        If i > 1 Then
            Return obj.id
        End If
        Return -1
    End Function
    Private Function removeSQL(obj As Empresa) As Boolean
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
    Private Function getObjectsSQL() As List(Of Empresa)
        Dim sc As SqlCommand, sdr As SqlDataReader
        getObjectsSQL = New List(Of Empresa)
        sc = New SqlCommand("Select * FROM " & getTable(), DBCONNECT.getConnection)
        sdr = sc.ExecuteReader
        While sdr.Read()
            getObjectsSQL.Add(New Empresa(sdr(ID), Trim(sdr(CODI)), Trim(sdr(ORDRE)), Trim(sdr(CIF).ToString), Trim(sdr(NOM)), sdr(PARTICIPACIO), ModelEmpresaContaplus.getObjects(sdr(ID)), ModelSeccio.getObjects(sdr(ID))))
        End While
        sdr.Close()
    End Function

    Private Function insertDBF(obj As Empresa) As Integer
        Dim sc As ADODB.Command
        sc = New ADODB.Command
        obj.id = DBCONNECT.getMaxIdDBF(getTable) + 1
        With sc
            .ActiveConnection = DBCONNECT.getConnectionDbf
            .CommandText = "INSERT INTO " & getTable() & " (" & ID & "," & CODI & "," & CIF & "," & NOM & "," & NOTES & "," & ORDRE & "," & PARTICIPACIO & ") VALUES(@id,@codi,@cif,@nom,@notes,@ordre,@participacio) "
            .Parameters.Append(ADOPARAM.ToInt(obj.id))
            .Parameters.Append(ADOPARAM.ToString(obj.codi))
            .Parameters.Append(ADOPARAM.ToString(obj.cif))
            .Parameters.Append(ADOPARAM.ToString(obj.nom))
            .Parameters.Append(ADOPARAM.ToString(obj.notes))
            .Parameters.Append(ADOPARAM.ToString(obj.ordre))
            .Parameters.Append(ADOPARAM.ToInt(obj.participacio))
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
    Private Function updateDBF(obj As Empresa) As Integer
        Dim sc As ADODB.Command
        sc = New ADODB.Command
        obj.id = DBCONNECT.getMaxIdDBF(getTable) + 1
        With sc
            .ActiveConnection = DBCONNECT.getConnectionDbf
            .CommandText = "UPDATE " & getTable() & " SET  " & CODI & "   = ?,  " & CIF & "   =?,  " & NOM & "   = ?, " & NOTES & "   =?, " & PARTICIPACIO & "   =?, " & ORDRE & "   =?  WHERE " & ID & "= ? "
            .Parameters.Append(ADOPARAM.ToString(obj.codi))
            .Parameters.Append(ADOPARAM.ToString(obj.cif))
            .Parameters.Append(ADOPARAM.ToString(obj.nom))
            .Parameters.Append(ADOPARAM.ToString(obj.notes))
            .Parameters.Append(ADOPARAM.ToInt(obj.participacio))
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
    Private Function removeDBF(obj As Empresa) As Boolean
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
    Private Function getObjectsDBF() As List(Of Empresa)
        Dim rc As ADODB.Recordset
        rc = New ADODB.Recordset
        getObjectsDBF = New List(Of Empresa)
        rc.Open("SELECT * FROM " & getTable(), DBCONNECT.getConnectionDbf)
        While Not rc.EOF
            getObjectsDBF.Add(New Empresa(rc(ID).Value, Trim(rc(CODI).Value), Trim(rc(ORDRE).Value), Trim(CONFIG.validarNull(rc(CIF).Value)), Trim(CONFIG.validarNull(rc(NOM).Value)), rc(PARTICIPACIO).Value, ModelEmpresaContaplus.getObjects(rc(ID).Value), ModelSeccio.getObjects(rc(ID).Value)))
            rc.MoveNext()
        End While
        If rc.State = 1 Then rc.Close()
        rc = Nothing
        getObjectsDBF.Sort()
    End Function

    Private Function getTable() As String
        Return DBCONNECT.GetTaulaEmpresa
    End Function
End Module
