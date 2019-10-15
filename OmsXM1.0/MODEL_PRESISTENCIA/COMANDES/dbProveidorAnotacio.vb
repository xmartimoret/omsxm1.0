Option Explicit On
Imports System.Data.SqlClient
Module dbProveidorAnotacio
    Private Const ID As String = "ID"
    Private Const ID_PROVEIDOR As String = "idProv"
    Private Const NOTES As String = "notes"
    Private Const ESTAT As String = "estat"
    'ACCESSORS CENTRE
    ''' <summary>
    ''' SAVE. Guarda un centre a la base de dades. 
    ''' Si es nou, fa una inserció si no  actualitza.
    ''' </summary>
    ''' <param name="obj"> centre</param>
    ''' <returns>identificador del centre.</returns>
    Public Function update(obj As proveidorAnotacio) As Integer
        If IS_SQLSERVER Then Return updateSQL(obj)
        Return updateDBF(obj)
    End Function
    Public Function insert(obj As proveidorAnotacio) As Integer
        If IS_SQLSERVER Then Return insertSQL(obj)
        Return insertDBF(obj)
    End Function
    Public Function remove(obj As proveidorAnotacio) As Boolean
        If IS_SQLSERVER Then Return removeSQL(obj)
        Return removeDBF(obj)
    End Function
    Public Function removePare(idProveidor As Integer) As Boolean
        If IS_SQLSERVER Then Return removePareSQL(idProveidor)
        Return removePareDBF(idProveidor)
    End Function
    Public Function getObjects() As List(Of proveidorAnotacio)
        If IS_SQLSERVER Then Return getObjectsSQL()
        Return getObjectsDBF()
    End Function
    Private Function updateSQL(obj As proveidorAnotacio) As Integer
        Dim sc As SqlCommand, i As Integer
        sc = New SqlCommand("UPDATE " & getTable() & " " &
                                " SET " & ID_PROVEIDOR & "=@idProveidor," &
                                          NOTES & " =@notes, " &
                                          ESTAT & " =@estat " &
                                " WHERE " & ID & "=@id", DBCONNECT.getConnection)
        sc.Parameters.Add("@id", SqlDbType.Int).Value = obj.id
        sc.Parameters.Add("@idProveidor", SqlDbType.Int).Value = obj.idProveidor
        sc.Parameters.Add("@notes", SqlDbType.VarChar).Value = obj.notes
        sc.Parameters.Add("@estat", SqlDbType.Bit).Value = obj.estat
        i = sc.ExecuteNonQuery
        sc = Nothing
        If i >= 1 Then
            Return obj.id
        End If
        Return -1
    End Function
    'ACCESSORS CENTRE
    ''' <summary>
    ''' SAVE. Guarda un centre a la base de dades. 
    ''' Si es nou, fa una inserció si no  actualitza.
    ''' </summary>
    ''' <param name="obj"> centre</param>
    ''' <returns>identificador del centre.</returns>
    Private Function insertSQL(obj As proveidorAnotacio) As Integer
        Dim sc As SqlCommand, i As Integer
        obj.id = DBCONNECT.getMaxId(getTable) + 1
        sc = New SqlCommand(" INSERT INTO " & getTable() & " " &
                            " (" & ID & ", " & ID_PROVEIDOR & ", " & NOTES & ", " & ESTAT & ")" &
                            " VALUES(@id,@idProveidor,@notes,@estat)", DBCONNECT.getConnection)
        sc.Parameters.Add("@id", SqlDbType.Int).Value = obj.id
        sc.Parameters.Add("@idProveidor", SqlDbType.Int).Value = obj.idProveidor
        sc.Parameters.Add("@notes", SqlDbType.VarChar).Value = obj.notes
        sc.Parameters.Add("@estat", SqlDbType.Bit).Value = obj.estat
        i = sc.ExecuteNonQuery

        sc = Nothing
        If i >= 1 Then
            Return obj.id
        End If
        Return -1
    End Function
    ''' <summary>
    '''  Elimina  un centre de la base de dades
    ''' </summary>
    ''' <param name="obj"></param>
    ''' <returns></returns>
    Private Function removeSQL(obj As proveidorAnotacio) As Boolean
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
    Private Function removePareSQL(idProveidor As Integer) As Boolean
        Dim sc As SqlCommand, i As Integer
        sc = New SqlCommand("DELETE FROM " & getTable() & " WHERE " & ID_PROVEIDOR & "=@id", DBCONNECT.getConnection)
        sc.Parameters.Add("@id", SqlDbType.Int).Value = idProveidor
        i = sc.ExecuteNonQuery
        sc = Nothing
        If i >= 1 Then
            Return True
        End If
        Return False
    End Function
    ''' <summary>
    ''' Obté tots els centres del sistema 
    ''' </summary>
    ''' <returns>una llista de centres</returns>
    Private Function getObjectsSQL() As List(Of proveidorAnotacio)
        Dim sc As SqlCommand, sdr As SqlDataReader, pr As proveidorAnotacio
        getObjectsSQL = New List(Of proveidorAnotacio)
        sc = New SqlCommand("SELECT * FROM " & getTable(), getConnection)
        sdr = sc.ExecuteReader
        While sdr.Read()
            pr = New proveidorAnotacio(sdr(ID),
                               CONFIG.validarNull(Trim(sdr(ID_PROVEIDOR))),
                               Trim(CONFIG.validarNull(sdr(NOTES))),
                               Trim(CONFIG.validarNull(sdr(ESTAT))))
            getObjectsSQL.Add(pr)
        End While
        sdr.Close()
        getObjectsSQL.Sort()
        sdr = Nothing
        sc = Nothing
    End Function


    Private Function updateDBF(obj As proveidorAnotacio) As Integer
        Dim sc As ADODB.Command
        sc = New ADODB.Command
        With sc
            .ActiveConnection = DBCONNECT.getConnectionDbf
            .CommandText = "UPDATE " & getTable() & " " &
                                " Set " & ID_PROVEIDOR & "=?," &
                                          NOTES & " =?, " &
                                          ESTAT & " =? " &
                                " WHERE " & ID & "=?"
            .Parameters.Append(ADOPARAM.ToInt(obj.idProveidor))
            .Parameters.Append(ADOPARAM.ToString(obj.notes))
            .Parameters.Append(ADOPARAM.toBool(obj.estat))
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
    'ACCESSORS CENTRE
    ''' <summary>
    ''' SAVE. Guarda un centre a la base de dades. 
    ''' Si es nou, fa una inserció si no  actualitza.
    ''' </summary>
    ''' <param name="obj"> centre</param>
    ''' <returns>identificador del centre.</returns>
    Private Function insertDBF(obj As proveidorAnotacio) As Integer
        Dim sc As ADODB.Command
        sc = New ADODB.Command
        obj.id = DBCONNECT.getMaxIdDBF(getTable) + 1
        With sc
            .ActiveConnection = DBCONNECT.getConnectionDbf
            .CommandText = " INSERT INTO " & getTable() & " " &
                            " (" & ID & ", " & ID_PROVEIDOR & ", " & NOTES & ", " & ESTAT & ")" &
                            " VALUES(?,?,?,?)"
            .Parameters.Append(ADOPARAM.ToInt(obj.id))
            .Parameters.Append(ADOPARAM.ToInt(obj.idProveidor))
            .Parameters.Append(ADOPARAM.ToString(obj.notes))
            .Parameters.Append(ADOPARAM.toBool(obj.estat))
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
    '''  Elimina  un centre de la base de dades
    ''' </summary>
    ''' <param name="obj"></param>
    ''' <returns></returns>
    Private Function removeDBF(obj As proveidorAnotacio) As Boolean
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
    Private Function removePareDBF(idProveidor As Integer) As Boolean
        Dim sc As ADODB.Command
        sc = New ADODB.Command
        With sc
            sc.ActiveConnection = DBCONNECT.getConnectionDbf
            sc.CommandText = " DELETE FROM " & getTable() & " WHERE " & ID_PROVEIDOR & "=?"
            sc.Parameters.Append(ADOPARAM.ToInt(idProveidor, ""))
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
    ''' Obté tots els centres del sistema 
    ''' </summary>
    ''' <returns>una llista de centres</returns>
    Private Function getObjectsDBF() As List(Of proveidorAnotacio)
        Dim rc As ADODB.Recordset, p As proveidorAnotacio
        rc = New ADODB.Recordset
        getObjectsDBF = New List(Of proveidorAnotacio)
        rc.Open("SELECT * FROM " & getTable(), DBCONNECT.getConnectionDbf)
        While Not rc.EOF
            p = New proveidorAnotacio(rc(ID).Value,
                               CONFIG.validarNull(Trim(rc(ID_PROVEIDOR).Value)),
                               Trim(CONFIG.validarNull(rc(NOTES).Value)),
                               Trim(CONFIG.validarNull(rc(ESTAT).Value)))
            getObjectsDBF.Add(p)
            rc.MoveNext()
        End While
        If rc.State = 1 Then rc.Close()
        rc = Nothing
        getObjectsDBF.Sort()
    End Function
    Private Function getTable() As String
        Return DBCONNECT.getTaulaProveidorAnotacio
    End Function
End Module
