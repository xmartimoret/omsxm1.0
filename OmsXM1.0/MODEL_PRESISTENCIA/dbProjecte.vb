Option Explicit On
Imports System.Data.SqlClient
Module dbProjecte
    Private Const ID As String = "ID"
    Private Const ID_EMPRESA As String = "IDEMPRESA"
    Private Const CODI As String = "CODI"
    Private Const NOM As String = "NOM"
    Private Const NOTES As String = "NOTES"
    Private Const RESPONSABLE As String = "RESP"
    Private Const DIRECTOR As String = "DIR"
    Public Function update(obj As Projecte) As Integer
        If IS_SQLSERVER Then Return updateSQL(obj)
        Return updateDBF(obj)
    End Function
    Public Function insert(obj As Projecte) As Integer
        If IS_SQLSERVER Then Return insertSQL(obj)
        Return insertDBF(obj)
    End Function
    Public Function remove(obj As Projecte) As Boolean
        If IS_SQLSERVER Then Return removeSQL(obj)
        Return removeDBF(obj)
    End Function
    Public Function getObjects() As List(Of Projecte)
        If IS_SQLSERVER Then Return getObjectsSQL()
        Return getObjectsDBF()
    End Function

    Private Function insertSQL(obj As Projecte) As Integer
        Dim sc As SqlCommand, i As Integer
        obj.id = DBCONNECT.getMaxId(getTable()) + 1
        sc = New SqlCommand(" INSERT INTO " & getTable() & " " &
                                " (" & ID & ", " & ID_EMPRESA & ", " & CODI & ", " & NOM & ", " & NOTES & "," & RESPONSABLE & "," & DIRECTOR & ")" &
                                " VALUES(@id,@idEmpresa,@
                                codi,@nom,@notes,@resp,@dir)", DBCONNECT.getConnection)


        sc.Parameters.Add("@id", SqlDbType.Int).Value = obj.id
        sc.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = obj.idEmpresa
        sc.Parameters.Add("@codi", SqlDbType.VarChar).Value = obj.codi
        sc.Parameters.Add("@nom", SqlDbType.VarChar).Value = obj.nom
        sc.Parameters.Add("@notes", SqlDbType.VarChar).Value = obj.notes
        sc.Parameters.Add("@resp", SqlDbType.VarChar).Value = obj.responsable
        sc.Parameters.Add("@dir", SqlDbType.VarChar).Value = obj.director
        i = sc.ExecuteNonQuery
        sc = Nothing
        If i > 1 Then
            Return obj.id
        End If
        Return -1
    End Function
    Private Function updateSQL(obj As Projecte) As Integer
        Dim sc As SqlCommand, i As Integer
        sc = New SqlCommand("UPDATE " & getTable() & " " &
                                " SET " & ID_EMPRESA & "=@idEmpresa," & CODI & "=@codi," & NOM & " =@nom, " & NOTES & "=@notes " & RESPONSABLE & "=@resp " & DIRECTOR & "=@dir " &
                                " WHERE " & ID & "=@id", DBCONNECT.getConnection)
        sc.Parameters.Add("@id", SqlDbType.Int).Value = obj.id
        sc.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = obj.idEmpresa
        sc.Parameters.Add("@codi", SqlDbType.VarChar).Value = obj.codi
        sc.Parameters.Add("@nom", SqlDbType.VarChar).Value = obj.nom
        sc.Parameters.Add("@notes", SqlDbType.VarChar).Value = obj.notes
        sc.Parameters.Add("@resp", SqlDbType.VarChar).Value = obj.responsable
        sc.Parameters.Add("@dir", SqlDbType.VarChar).Value = obj.director
        i = sc.ExecuteNonQuery
        sc = Nothing
        If i > 1 Then
            Return obj.id
        End If
        Return -1
    End Function
    Private Function removeSQL(obj As Object) As Boolean
        Dim sc As SqlCommand, i As Integer
        sc = New SqlCommand("DELETE FROM " & getTable() & " WHERE " & ID & "=@ID", DBCONNECT.getConnection)
        sc.Parameters.Add("@id", SqlDbType.Int).Value = obj.id
        i = sc.ExecuteNonQuery
        sc = Nothing
        If i > 1 Then
            Return True
        End If
        Return False
    End Function
    Private Function getObjectsSQL() As List(Of Projecte)
        Dim sc As SqlCommand, sdr As SqlDataReader, dades As List(Of Projecte)
        dades = New List(Of Projecte)
        sc = New SqlCommand("Select * FROM " & getTable(), DBCONNECT.getConnection)
        sdr = sc.ExecuteReader
        While sdr.Read()
            dades.Add(New Projecte(sdr(ID), sdr(ID_EMPRESA), Trim(sdr(CODI)), Trim(sdr(CODI)), Trim(sdr(NOM)), "", ModelEmpresa.getObject(sdr(ID_EMPRESA)).ToString, Trim(sdr(RESPONSABLE)), Trim(sdr(DIRECTOR))))
        End While
        sdr.Close()
        sdr = Nothing
        sc = Nothing
        Return dades
    End Function

    Private Function insertDBF(obj As Projecte) As Integer
        Dim sc As ADODB.Command
        sc = New ADODB.Command
        obj.id = DBCONNECT.getMaxIdDBF(getTable) + 1
        With sc
            .ActiveConnection = DBCONNECT.getConnectionDbf
            .CommandText = " INSERT INTO " & getTable() & " " &
                                " (" & ID & ", " & ID_EMPRESA & ", " & CODI & ", " & NOM & "," & RESPONSABLE & "," & DIRECTOR & ")" &
                                " VALUES(?,?,?,?,?,?)"
            .Parameters.Append(ADOPARAM.ToInt(obj.id))
            .Parameters.Append(ADOPARAM.ToInt(obj.idEmpresa))
            .Parameters.Append(ADOPARAM.ToString(obj.codi))
            .Parameters.Append(ADOPARAM.ToString(obj.nom))
            .Parameters.Append(ADOPARAM.ToString(obj.responsable))
            .Parameters.Append(ADOPARAM.ToString(obj.director))
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
    Private Function updateDBF(obj As Projecte) As Integer
        Dim sc As ADODB.Command
        sc = New ADODB.Command
        With sc
            .ActiveConnection = DBCONNECT.getConnectionDbf
            .CommandText = "UPDATE " & getTable() & " " &
                                " SET " & ID_EMPRESA & "=?," & CODI & "=?," & NOM & " =?, " & RESPONSABLE & " =?, " & DIRECTOR & "=? " &
                                " WHERE " & ID & "=?"
            .Parameters.Append(ADOPARAM.ToInt(obj.idEmpresa))
            .Parameters.Append(ADOPARAM.ToString(obj.codi))
            .Parameters.Append(ADOPARAM.ToString(obj.nom))
            .Parameters.Append(ADOPARAM.ToString(obj.responsable))
            .Parameters.Append(ADOPARAM.ToString(obj.director))
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
    Private Function removeDBF(obj As Object) As Boolean
        Dim sc As ADODB.Command
        sc = New ADODB.Command
        With sc
            sc.ActiveConnection = DBCONNECT.getConnectionDbf
            sc.CommandText = " DELETE FROM " & getTable() & " WHERE " & ID & "=?"
            sc.Parameters.Append(ADOPARAM.ToInt(obj.ID, ""))
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
    Private Function getObjectsDBF() As List(Of Projecte)
        Dim rc As ADODB.Recordset
        rc = New ADODB.Recordset
        getObjectsDBF = New List(Of Projecte)
        'rc.Open("SELECT P.ID AS PID, P.CODI FROM " & getTable() & " AS p INNER JOIN EMPRESA AS E ON (E.ID= P.IDEMPRESA)  ", DBCONNECT.getConnectionDbf)
        rc.Open("SELECT * FROM " & getTable(), DBCONNECT.getConnectionDbf)
        While Not rc.EOF
            getObjectsDBF.Add(New Projecte(rc(ID).Value, rc(ID_EMPRESA).Value, Trim(rc(CODI).Value), Trim(rc(CODI).Value), Trim(rc(NOM).Value), "", ModelEmpresa.getCodiEmpresa(rc(ID_EMPRESA).Value) & " -" & ModelEmpresa.getNom(rc(ID_EMPRESA).Value), Trim(CONFIG.validarNull(rc(RESPONSABLE).Value)), Trim(CONFIG.validarNull(rc(DIRECTOR).Value))))

            'getObjectsDBF.Add(New Projecte(rc(ID).Value, rc(ID_EMPRESA).Value, Trim(rc(CODI).Value), Trim(rc(CODI).Value), Trim(rc(NOM).Value), "", ""))
            rc.MoveNext()
        End While
        If rc.State = 1 Then rc.Close()
        rc = Nothing
        getObjectsDBF.Sort()
    End Function
    Private Function getTable() As String
        Return DBCONNECT.getTaulaProjecte
    End Function
End Module

