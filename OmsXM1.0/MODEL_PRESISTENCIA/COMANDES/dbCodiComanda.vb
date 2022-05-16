Imports System.Data.SqlClient
Module dbCodiComanda
    Private Const ID As String = "ID"
    Private Const SERIE As String = "SERIE"
    Private Const CODI As String = "CODI"
    Private Const EMPRESA As String = "IDEMP"
    Private Const NOTES As String = "NOTES"

    Public Function update(obj As CodiComanda) As Integer
        If IS_SQLSERVER() Then Return updateSQL(obj)
        Return updatedbf(obj)
    End Function
    Public Function insert(obj As CodiComanda) As Integer
        If IS_SQLSERVER() Then Return insertSQL(obj)
        Return insertDBF(obj)
    End Function
    Public Function remove(obj As CodiComanda) As Boolean
        If IS_SQLSERVER() Then Return removeSQL(obj)
        Return removeDBF(obj)
    End Function
    Public Function getObjects() As List(Of CodiComanda)
        If IS_SQLSERVER() Then Return getObjectsSQL()
        Return getObjectsDBF()
    End Function
    Private Function updateSQL(obj As CodiComanda) As Integer
        Dim sc As SqlCommand, i As Integer
        sc = New SqlCommand("UPDATE " & getTable() & " " &
                                    " SET " & SERIE & "=@serie," &
                                              CODI & "=@codi," &
                                              EMPRESA & "=@empresa," &
                                              NOTES & " =@notes, " &
                                    " WHERE " & ID & "=@id", DBCONNECT.getConnection)
        sc.Parameters.Add("@id", SqlDbType.Int).Value = obj.id
        sc.Parameters.Add("@serie", SqlDbType.Int).Value = obj.serie
        sc.Parameters.Add("@codi", SqlDbType.BigInt).Value = obj.codi
        sc.Parameters.Add("@empresa", SqlDbType.VarChar).Value = obj.idEmpresa
        sc.Parameters.Add("@notes", SqlDbType.VarChar).Value = obj.notes
        i = sc.ExecuteNonQuery
        sc = Nothing
        If i >= 1 Then
            Return obj.id
        End If
        Return -1
    End Function

    Private Function insertSQL(obj As CodiComanda) As Integer
        Dim sc As SqlCommand, i As Integer
        obj.id = DBCONNECT.getMaxId(getTable) + 1
        sc = New SqlCommand(" INSERT INTO " & getTable() & " " &
                                " (" & ID & ", " & SERIE & "," & CODI & "," & EMPRESA & "," & NOTES & ")" &
                                " VALUES(@id,@serie,@codi,@empresa,@notes)", DBCONNECT.getConnection)
        sc.Parameters.Add("@id", SqlDbType.Int).Value = obj.id
        sc.Parameters.Add("@serie", SqlDbType.Int).Value = obj.serie
        sc.Parameters.Add("@codi", SqlDbType.BigInt).Value = obj.codi
        sc.Parameters.Add("@empresa", SqlDbType.VarChar).Value = obj.idEmpresa
        sc.Parameters.Add("@notes", SqlDbType.VarChar).Value = obj.notes
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
    Private Function removeSQL(obj As CodiComanda) As Boolean
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

    ''' <summary>
    ''' Obté tots els centres del sistema 
    ''' </summary>
    ''' <returns>una llista de centres</returns>
    Private Function getObjectsSQL() As List(Of CodiComanda)
        Dim sc As SqlCommand, sdr As SqlDataReader, cc As CodiComanda
        getObjectsSQL = New List(Of CodiComanda)
        sc = New SqlCommand("SELECT * FROM " & getTable(), getConnection)
        sdr = sc.ExecuteReader
        While sdr.Read()
            cc = New CodiComanda(sdr(ID),
                                   sdr(SERIE),
                                   sdr(CODI),
                                   sdr(EMPRESA),
                                   Trim(CONFIG.validarNull(sdr(NOTES))))

            getObjectsSQL.Add(cc)
        End While
        sdr.Close()
        getObjectsSQL.Sort()
        sdr = Nothing
        sc = Nothing
    End Function
    Private Function updatedbf(obj As CodiComanda) As Integer
        Dim sc As ADODB.Command
        sc = New ADODB.Command
        With sc
            .ActiveConnection = DBCONNECT.getConnectionDbf
            .CommandText = "UPDATE " & getTable() &
                                    " SET " & SERIE & "=?," &
                                                CODI & "=?," &
                                                EMPRESA & "=?," &
                                              NOTES & "=? " &
                                     " WHERE " & ID & "=?"
            .Parameters.Append(ADOPARAM.ToInt(obj.serie))
            .Parameters.Append(ADOPARAM.ToInt(obj.codi))
            .Parameters.Append(ADOPARAM.ToInt(obj.idEmpresa))
            .Parameters.Append(ADOPARAM.ToString(obj.notes))
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
    Private Function insertDBF(obj As CodiComanda) As Integer
        Dim sc As ADODB.Command
        sc = New ADODB.Command
        obj.id = DBCONNECT.getMaxIdDBF(getTable) + 1
        With sc
            .ActiveConnection = DBCONNECT.getConnectionDbf
            .CommandText = " INSERT INTO " & getTable() & " " &
                                " (" & ID & ", " & SERIE & "," & CODI & "," & EMPRESA & "," & NOTES & ")" &
                                " VALUES(?,?,?,?,?)"
            .Parameters.Append(ADOPARAM.ToInt(obj.id))
            .Parameters.Append(ADOPARAM.ToInt(obj.serie))
            .Parameters.Append(ADOPARAM.ToInt(obj.codi))
            .Parameters.Append(ADOPARAM.ToInt(obj.idEmpresa))
            .Parameters.Append(ADOPARAM.ToString(obj.notes))
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
    Private Function removeDBF(obj As CodiComanda) As Boolean
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

    ''' <summary>
    ''' Obté tots els centres del sistema 
    ''' </summary>
    ''' <returns>una llista de centres</returns>
    Private Function getObjectsDBF() As List(Of CodiComanda)
        Dim rc As ADODB.Recordset, cc As CodiComanda
        rc = New ADODB.Recordset
        getObjectsDBF = New List(Of CodiComanda)
        rc.Open("SELECT * FROM " & getTable(), DBCONNECT.getConnectionDbf)
        While Not rc.EOF
            cc = New CodiComanda(rc(ID).Value,
                                   rc(SERIE).Value,
                                   rc(CODI).Value,
                                   rc(EMPRESA).Value,
                                   Trim(CONFIG.validarNull(rc(NOTES).Value)))
            getObjectsDBF.Add(cc)
            rc.MoveNext()
        End While
        If rc.State = 1 Then rc.Close()
        rc = Nothing
        getObjectsDBF.Sort()
    End Function
    Private Function getTable() As String
        Return DBCONNECT.getTaulaCodiComanda
    End Function
End Module
