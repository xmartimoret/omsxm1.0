Option Explicit On
Imports System.Data.SqlClient
Module dbGrup
    Private Const ID As String = "id"
    Private Const CODI As String = "codi"
    Private Const NOM As String = "descripcio"
    Private Const NOTES As String = "notes"
    Private Const RESUM As String = "resum"
    Private Const ORDRE As String = "ordre"
    Public Function update(obj As Grup) As Integer
        If IS_SQLSERVER Then Return updateSQL(obj)
        Return updateDBF(obj)
    End Function
    Public Function insert(obj As Grup) As Integer
        If IS_SQLSERVER Then Return insertSQL(obj)
        Return insertDBF(obj)
    End Function
    Public Function remove(id As Integer) As Boolean
        If IS_SQLSERVER Then Return removeSQL(id)
        Return removeDBF(id)
    End Function
    Public Function getObjects() As List(Of Grup)
        If IS_SQLSERVER Then Return getObjectsSQL()
        Return getObjectsDBF()
    End Function
    Private Function insertSQL(obj As Grup) As Integer
        Dim sc As SqlCommand, i As Integer
        obj.id = DBCONNECT.getMaxId(getTable()) + 1
        sc = New SqlCommand(" INSERT INTO " & getTable() & " " &
                                " (" & ID & ",  " & CODI & ", " & NOM & ", " & NOTES & "," & ORDRE & "," & RESUM & ")" &
                                " VALUES(@id,@codi,@nom,@notes,@ordre,@resum)", DBCONNECT.getConnection)
        sc.Parameters.Add("@id", SqlDbType.Int).Value = obj.id
        sc.Parameters.Add("@codi", SqlDbType.VarChar).Value = obj.codi
        sc.Parameters.Add("@nom", SqlDbType.VarChar).Value = obj.nom
        sc.Parameters.Add("@notes", SqlDbType.VarChar).Value = obj.notes
        sc.Parameters.Add("@ordre", SqlDbType.Int).Value = Val(obj.ordre)
        sc.Parameters.Add("@resum", SqlDbType.Bit).Value = obj.resum
        i = sc.ExecuteNonQuery
        sc = Nothing
        If i > 1 Then
            Return obj.id
        End If
        Return -1
    End Function
    Private Function updateSQL(obj As Grup) As Integer
        Dim sc As SqlCommand, i As Integer
        sc = New SqlCommand("UPDATE " & getTable() & " " &
                                " SET " & CODI & "=@codi," & NOM & " =@nom, " & NOTES & "=@notes, " & ORDRE & "=@ordre, " & RESUM & "=@resum" &
                                " WHERE " & ID & "=@id", DBCONNECT.getConnection)
        sc.Parameters.Add("@id", SqlDbType.Int).Value = obj.id
        sc.Parameters.Add("@codi", SqlDbType.VarChar).Value = obj.codi
        sc.Parameters.Add("@nom", SqlDbType.VarChar).Value = obj.nom
        sc.Parameters.Add("@notes", SqlDbType.VarChar).Value = obj.notes
        sc.Parameters.Add("@ordre", SqlDbType.Int).Value = Val(obj.ordre)
        sc.Parameters.Add("@resum", SqlDbType.Bit).Value = obj.resum
        i = sc.ExecuteNonQuery
        sc = Nothing
        If i > 1 Then
            Return obj.id
        End If
        Return -1
    End Function
    ''' <summary>
    ''' Elimina un Grup comptable de la base de dades i del sistema
    ''' </summary>
    ''' <param name="id">Grup comptable a eliminar</param>
    ''' <returns>cert si s'ha eliminat, fals en cas contrari</returns>
    Private Function removeSQL(id As Integer) As Boolean
        Dim sc As SqlCommand, i As Integer
        sc = New SqlCommand("DELETE FROM " & getTable() & " WHERE " & id & "=@ID", DBCONNECT.getConnection)
        sc.Parameters.Add("@id", SqlDbType.Int).Value = id
        i = sc.ExecuteNonQuery
        sc = Nothing
        If i > 1 Then
            Return True
        End If
        Return False
    End Function
    ''' <summary>
    ''' obté tots els subgrupsComptables de la BBDD
    ''' </summary>
    ''' <returns>Una llista de tots els SubgrupsComptables de la BBDD</returns>
    Private Function getObjectsSQL() As List(Of Grup)
        Dim sc As SqlCommand, sdr As SqlDataReader
        getObjectsSQL = New List(Of Grup)
        sc = New SqlCommand("Select * FROM " & getTable(), DBCONNECT.getConnection)
        sdr = sc.ExecuteReader
        While sdr.Read()
            getObjectsSQL.Add(New Grup(sdr(ID), Trim(sdr(CODI)), Trim(sdr(NOM)), Trim(CONFIG.validarNull(sdr(NOTES))), sdr(ORDRE), sdr(RESUM), ModelSubgrup.getObjects(sdr(ID))))
        End While
        sdr.Close()
        sdr = Nothing
        sc = Nothing
    End Function

    Private Function insertDBF(obj As Grup) As Integer
        Dim sc As ADODB.Command
        sc = New ADODB.Command
        obj.id = DBCONNECT.getMaxIdDBF(getTable) + 1
        With sc
            .ActiveConnection = DBCONNECT.getConnectionDbf
            .CommandText = " INSERT INTO " & getTable() & " " &
                                " (" & ID & ",  " & CODI & ", " & NOM & ", " & NOTES & "," & ORDRE & "," & RESUM & ")" &
                                " VALUES(?,?,?,?,?,?)"
            .Parameters.Append(ADOPARAM.ToInt(obj.id))
            .Parameters.Append(ADOPARAM.ToString(obj.codi))
            .Parameters.Append(ADOPARAM.ToString(obj.nom))
            .Parameters.Append(ADOPARAM.ToString(obj.notes))
            .Parameters.Append(ADOPARAM.ToString(obj.ordre))
            .Parameters.Append(ADOPARAM.toBool(obj.resum))
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
    Private Function updateDBF(obj As Grup) As Integer
        Dim sc As ADODB.Command
        sc = New ADODB.Command
        obj.id = DBCONNECT.getMaxIdDBF(getTable) + 1
        With sc
            .ActiveConnection = DBCONNECT.getConnectionDbf
            .CommandText = "UPDATE " & getTable() & " " &
                                " SET " & CODI & "=@codi," & NOM & " =@nom, " & NOTES & "=@notes, " & ORDRE & "=@ordre, " & RESUM & "=@resum" &
                                " WHERE " & ID & "=@id"
            .Parameters.Append(ADOPARAM.ToString(obj.codi))
            .Parameters.Append(ADOPARAM.ToString(obj.nom))
            .Parameters.Append(ADOPARAM.ToString(obj.notes))
            .Parameters.Append(ADOPARAM.ToString(obj.ordre))
            .Parameters.Append(ADOPARAM.toBool(obj.resum))
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
    ''' <summary>
    ''' Elimina un Grup comptable de la base de dades i del sistema
    ''' </summary>
    ''' <param name="id">Grup comptable a eliminar</param>
    ''' <returns>cert si s'ha eliminat, fals en cas contrari</returns>
    Private Function removeDBF(id As Integer) As Boolean
        Dim sc As ADODB.Command
        sc = New ADODB.Command
        With sc
            sc.ActiveConnection = DBCONNECT.getConnectionDbf
            sc.CommandText = " DELETE FROM " & getTable() & " WHERE " & id & "=?"
            sc.Parameters.Append(ADOPARAM.ToInt(id, ""))
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
    ''' <summary>
    ''' obté tots els subgrupsComptables de la BBDD
    ''' </summary>
    ''' <returns>Una llista de tots els SubgrupsComptables de la BBDD</returns>
    Private Function getObjectsDBF() As List(Of Grup)
        Dim rc As ADODB.Recordset
        rc = New ADODB.Recordset
        getObjectsDBF = New List(Of Grup)
        rc.Open("SELECT * FROM " & getTable(), DBCONNECT.getConnectionDbf)
        While Not rc.EOF
            getObjectsDBF.Add(New Grup(rc(ID).Value, Trim(rc(CODI).Value), Trim(rc(NOM).Value), Trim(CONFIG.validarNull(rc(NOTES).Value)), rc(ORDRE).Value, rc(RESUM).Value, ModelSubgrup.getObjects(rc(ID).Value)))
            rc.MoveNext()
        End While
        If rc.State = 1 Then rc.Close()
        rc = Nothing
        getObjectsDBF.Sort()
    End Function
    ''' <summary>
    ''' obté el nom de la taula de la BBDD
    ''' </summary>
    ''' <returns>String</returns>
    Private Function getTable() As String
        Return DBCONNECT.getTaulaGrups
    End Function
End Module
