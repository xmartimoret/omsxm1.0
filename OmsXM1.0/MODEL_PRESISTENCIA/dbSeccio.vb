Option Explicit On
Imports System.Data.SqlClient
Module dbSeccio
    Private Const ID As String = "ID"
    Private Const ID_EMPRESA As String = "IDEMPRESA"
    Private Const CODI As String = "CODI"
    Private Const NOM As String = "NOM"
    Private Const NOTES As String = "NOTES"
    Private Const F_SALDO As String = "FSALDO"
    Private Const F_INFORME As String = "FINFORME"
    Private Const ACTIU As String = "ACTIU"
    Private Const ORDRE As String = "ORDRE"
    Public Function update(obj As Seccio) As Integer
        If IS_SQLSERVER Then Return updateSQL(obj)
        Return updateDBF(obj)
    End Function
    Public Function insert(obj As Seccio) As Integer
        If IS_SQLSERVER Then Return insertSQL(obj)
        Return insertDBF(obj)
    End Function
    Public Function remove(obj As Seccio) As Boolean
        If IS_SQLSERVER Then Return removeSQL(obj)
        Return removeDBF(obj)
    End Function
    Public Function removeSeccio(idEmpresa As Integer) As Boolean
        If IS_SQLSERVER Then Return removeSeccioSQL(idEmpresa)
        Return removeSeccioDBF(idEmpresa)
    End Function
    Public Function getObjects() As List(Of Seccio)
        If IS_SQLSERVER Then Return getObjectsSQL()
        Return getObjectsDBF()
    End Function
    Private Function insertSQL(obj As Seccio) As Integer
        Dim sc As SqlCommand, i As Integer
        obj.id = DBCONNECT.getMaxId(getTable()) + 1
        sc = New SqlCommand(" INSERT INTO " & getTable() & " " &
                                " (" & ID & ", " & ID_EMPRESA & ", " & CODI & ", " & NOM & ", " & NOTES & "," & ORDRE & "," & ACTIU & "," & F_SALDO & "," & F_INFORME & ")" &
                                " VALUES(@id,@idEmpresa,@codi,@nom,@notes,@ordre,@actiu,@fSaldo,@fInforme)", DBCONNECT.getConnection)
        sc.Parameters.Add("@id", SqlDbType.Int).Value = obj.id
        sc.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = obj.idEmpresa
        sc.Parameters.Add("@codi", SqlDbType.VarChar).Value = obj.codi
        sc.Parameters.Add("@nom", SqlDbType.VarChar).Value = obj.nom
        sc.Parameters.Add("@notes", SqlDbType.VarChar).Value = obj.notes
        sc.Parameters.Add("@ordre", SqlDbType.Int).Value = Val(obj.ordre)
        sc.Parameters.Add("@actiu", SqlDbType.Bit).Value = obj.actiu
        sc.Parameters.Add("@fSaldo", SqlDbType.VarChar).Value = obj.fullaSaldo
        sc.Parameters.Add("@fInforme", SqlDbType.VarChar).Value = obj.fullaInforme
        i = sc.ExecuteNonQuery
        sc = Nothing
        If i >= 1 Then
            Return obj.id
        End If
        Return -1
    End Function
    Private Function updateSQL(obj As Seccio) As Integer
        Dim sc As SqlCommand, i As Integer
        sc = New SqlCommand("UPDATE " & getTable() & " " &
                                " SET " & ID_EMPRESA & "=@idEmpresa," & CODI & "=@codi," & NOM & " =@nom, " & NOTES & "=@notes, " & ORDRE & "=@ordre ," & ACTIU & "=@actiu ," & F_SALDO & "=@fSaldo ," & F_INFORME & "=@fInforme " &
                                  " WHERE " & ID & "=@id", DBCONNECT.getConnection)
        sc.Parameters.Add("@id", SqlDbType.Int).Value = obj.id
        sc.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = obj.idEmpresa
        sc.Parameters.Add("@codi", SqlDbType.VarChar).Value = obj.codi
        sc.Parameters.Add("@nom", SqlDbType.VarChar).Value = obj.nom
        sc.Parameters.Add("@notes", SqlDbType.VarChar).Value = obj.notes
        sc.Parameters.Add("@ordre", SqlDbType.Int).Value = Val(obj.ordre)
        sc.Parameters.Add("@actiu", SqlDbType.Bit).Value = obj.actiu
        sc.Parameters.Add("@fSaldo", SqlDbType.VarChar).Value = obj.fullaSaldo
        sc.Parameters.Add("@fInforme", SqlDbType.VarChar).Value = obj.fullaInforme
        i = sc.ExecuteNonQuery
        sc = Nothing
        If i >= 1 Then
            Return obj.id
        End If
        Return -1
    End Function
    Private Function removeSQL(obj As Seccio) As Boolean
        Dim sc As SqlCommand, i As Integer
        sc = New SqlCommand("DELETE FROM " & getTable() & " WHERE " & ID & "=@id", DBCONNECT.getConnection)
        sc.Parameters.Add("@id", SqlDbType.Int).Value = obj.id
        i = sc.ExecuteNonQuery
        sc = Nothing
        If i >= 1 Then
            Return True
        End If
        Return False
    End Function

    Private Function removeSeccioSQL(idEmpresa As Integer) As Boolean
        Dim sc As SqlCommand, i As Integer
        sc = New SqlCommand("DELETE FROM " & getTable() & " WHERE " & ID_EMPRESA & "=@idEmpresa", DBCONNECT.getConnection)
        sc.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa
        i = sc.ExecuteNonQuery
        sc = Nothing
        If i >= 1 Then
            Return True
        End If
        Return False
    End Function
    Private Function getObjectsSQL() As List(Of Seccio)
        Dim sc As SqlCommand, sdr As SqlDataReader
        getObjectsSQL = New List(Of Seccio)
        sc = New SqlCommand("Select * FROM " & getTable(), DBCONNECT.getConnection)
        sdr = sc.ExecuteReader
        While sdr.Read()
            getObjectsSQL.Add(New Seccio(sdr(ID), sdr(ID_EMPRESA), Trim(sdr(CODI)), Trim(sdr(NOM)), Trim(sdr(NOTES).ToString), Trim(sdr(ORDRE)), Trim(sdr(F_SALDO).ToString), Trim(sdr(F_INFORME).ToString), sdr(ACTIU), ModelCentre.getObjects(sdr(ID), ""), ModelSeccioGrup.getObjects(sdr(ID))))
        End While
        sdr.Close()
        sdr = Nothing
        sc = Nothing
        getObjectsSQL.Sort()
    End Function
    Private Function insertDBF(obj As Seccio) As Integer
        Dim sc As ADODB.Command
        sc = New ADODB.Command
        obj.id = DBCONNECT.getMaxIdDBF(getTable) + 1
        With sc
            .ActiveConnection = DBCONNECT.getConnectionDbf
            .CommandText = " INSERT INTO " & getTable() & " " &
                                " (" & ID & ", " & ID_EMPRESA & ", " & CODI & ", " & NOM & ", " & NOTES & "," & ORDRE & "," & ACTIU & "," & F_SALDO & "," & F_INFORME & ")" &
                                " VALUES(?,?,?,?,?,?,?,?,?)"
            .Parameters.Append(ADOPARAM.ToInt(obj.id))
            .Parameters.Append(ADOPARAM.ToInt(obj.idEmpresa))
            .Parameters.Append(ADOPARAM.ToString(obj.codi))
            .Parameters.Append(ADOPARAM.ToString(obj.nom))
            .Parameters.Append(ADOPARAM.ToString(obj.notes))
            .Parameters.Append(ADOPARAM.ToString(obj.ordre))
            .Parameters.Append(ADOPARAM.toBool(obj.actiu))
            .Parameters.Append(ADOPARAM.ToString(obj.fullaSaldo))
            .Parameters.Append(ADOPARAM.ToString(obj.fullaInforme))
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
    Private Function updateDBF(obj As Seccio) As Integer
        Dim sc As ADODB.Command
        sc = New ADODB.Command
        With sc
            .ActiveConnection = DBCONNECT.getConnectionDbf
            .CommandText = "UPDATE " & getTable() & " " &
                                " SET " & ID_EMPRESA & "=?," & CODI & "=?," & NOM & " =?, " & NOTES & "=?, " & ORDRE & "=? ," & ACTIU & "=? ," & F_SALDO & "=? ," & F_INFORME & "=? " &
                                  " WHERE " & ID & "=?"
            .Parameters.Append(ADOPARAM.ToInt(obj.idEmpresa))
            .Parameters.Append(ADOPARAM.ToString(obj.codi))
            .Parameters.Append(ADOPARAM.ToString(obj.nom))
            .Parameters.Append(ADOPARAM.ToString(obj.notes))
            .Parameters.Append(ADOPARAM.ToString(obj.ordre))
            .Parameters.Append(ADOPARAM.toBool(obj.actiu))
            .Parameters.Append(ADOPARAM.ToString(obj.fullaSaldo))
            .Parameters.Append(ADOPARAM.ToString(obj.fullaInforme))
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
    Private Function removeDBF(obj As Seccio) As Boolean
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

    Private Function removeSeccioDBF(idEmpresa As Integer) As Boolean
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
    Private Function getObjectsDBF() As List(Of Seccio)
        Dim rc As ADODB.Recordset
        rc = New ADODB.Recordset
        getObjectsDBF = New List(Of Seccio)
        rc.Open("SELECT * FROM " & getTable(), DBCONNECT.getConnectionDbf)
        While Not rc.EOF
            getObjectsDBF.Add(New Seccio(rc(ID).Value, rc(ID_EMPRESA).Value, Trim(rc(CODI).Value), Trim(rc(NOM).Value), Trim(CONFIG.validarNull(rc(NOTES).Value)), Trim(CONFIG.validarNull(rc(ORDRE).Value)), Trim(CONFIG.validarNull(rc(F_SALDO).Value)), Trim(CONFIG.validarNull(rc(F_INFORME).Value)), rc(ACTIU).Value, ModelCentre.getObjects(rc(ID).Value, ""), ModelSeccioGrup.getObjects(rc(ID).Value)))
            rc.MoveNext()
        End While
        If rc.State = 1 Then rc.Close()
        rc = Nothing
        getObjectsDBF.Sort()
    End Function
    Private Function getTable() As String
        getTable = DBCONNECT.getTaulaSeccions
    End Function
End Module
