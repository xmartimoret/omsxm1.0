Option Explicit On
Imports System.Data.SqlClient
Module dbProjecteContacte
    Private Const ID_PROJECTE As String = "idProj"
    Private Const ID_CONTACTE As String = "idCont"
    Private Const PREDETERMINAT As String = "PRED"
    'ACCESSORS CENTRE
    ''' <summary>
    ''' SAVE. Guarda un centre a la base de dades. 
    ''' Si es nou, fa una inserció si no  actualitza.
    ''' </summary>
    ''' <param name="obj"> centre</param>
    ''' <returns>identificador del centre.</returns>

    Public Function insert(obj As ProjecteContacte) As Integer
        If IS_SQLSERVER Then Return insertSql(obj)
        Return insertDBF(obj)
    End Function
    Public Function remove(obj As ProjecteContacte) As Boolean
        If IS_SQLSERVER Then Return removeSql(obj)
        Return removeDBF(obj)
    End Function
    Public Function removePare(idProjecte As Integer) As Boolean
        If IS_SQLSERVER Then Return removePareSQL(idProjecte)
        Return removePareDBF(idProjecte)
    End Function
    Public Function getObjects() As List(Of ProjecteContacte)
        If IS_SQLSERVER Then Return getObjectsSql()
        Return getObjectsDBF()
    End Function

    Public Function updatePredeterminat(obj As ProjecteContacte) As Boolean
        If IS_SQLSERVER() Then Return updatePredeterminatSql(obj)
        updatePredeterminatDBF(obj.idProjecte)
        Return updatePredeterminatDBF(obj)
    End Function

    'ACCESSORS CENTRE
    ''' <summary>
    ''' SAVE. Guarda un centre a la base de dades. 
    ''' Si es nou, fa una inserció si no  actualitza.
    ''' </summary>
    ''' <param name="obj"> centre</param>
    ''' <returns>identificador del centre.</returns>
    Private Function insertSql(obj As ProjecteContacte) As Integer
        Dim sc As SqlCommand, i As Integer
        sc = New SqlCommand(" INSERT INTO " & getTable() & " " &
                            " (" & ID_CONTACTE & ", " & ID_PROJECTE & ", " & PREDETERMINAT & ")" &
                            " VALUES(@idContacte,@idProjecte,@predeterminat)", DBCONNECT.getConnection)
        sc.Parameters.Add("@idContacte", SqlDbType.Int).Value = obj.idContacte
        sc.Parameters.Add("@idProjecte", SqlDbType.Int).Value = obj.idProjecte
        sc.Parameters.Add("@predeterminat", SqlDbType.Bit).Value = obj.predeterminat
        i = sc.ExecuteNonQuery
        sc = Nothing
        If i >= 1 Then
            Return 1
        End If
        Return -1
    End Function
    Private Function updatePredeterminatSql(obj As ProjecteContacte) As Integer
        Dim sc As SqlCommand, i As Integer

        sc = New SqlCommand(" UPDATE " & getTable() & " SET " & PREDETERMINAT & "=@predeterminat WHERE " & ID_PROJECTE & "=@idProjecte", DBCONNECT.getConnection)
        sc.Parameters.Add("@idProjecte", SqlDbType.Int).Value = obj.idProjecte
        sc.Parameters.Add("@predeterminat", SqlDbType.Bit).Value = False

        sc = New SqlCommand(" UPDATE " & getTable() & " SET " & PREDETERMINAT & "=@predeterminat WHERE " & ID_PROJECTE & "=@idProjecte AND " & ID_CONTACTE & " =@idContacte", DBCONNECT.getConnection)
        sc.Parameters.Add("@idContacte", SqlDbType.Int).Value = obj.idContacte
        sc.Parameters.Add("@idProjecte", SqlDbType.Int).Value = obj.idProjecte
        sc.Parameters.Add("@predeterminat", SqlDbType.Bit).Value = True


        i = sc.ExecuteNonQuery
        sc = Nothing
        If i >= 1 Then
            Return 1
        End If
        Return -1
    End Function
    ''' <summary>
    '''  Elimina  un centre de la base de dades
    ''' </summary>
    ''' <param name="obj"></param>
    ''' <returns></returns>
    Private Function removeSql(obj As ProjecteContacte) As Boolean
        Dim sc As SqlCommand, i As Integer
        sc = New SqlCommand("DELETE FROM " & getTable() & " WHERE " & ID_PROJECTE & "=@idProjecte and  " & ID_CONTACTE & " = @idContacte", DBCONNECT.getConnection)
        sc.Parameters.Add("@idProjecte", SqlDbType.Int).Value = obj.idProjecte
        sc.Parameters.Add("@idContacte", SqlDbType.Int).Value = obj.idContacte
        i = sc.ExecuteNonQuery
        sc = Nothing
        If i >= 1 Then
            Return True
        End If
        Return False
    End Function
    Private Function removePareSql(idProjecte As Integer) As Boolean
        Dim sc As SqlCommand, i As Integer
        sc = New SqlCommand("DELETE FROM " & getTable() & " WHERE " & ID_PROJECTE & "=@idProjecte ", DBCONNECT.getConnection)
        sc.Parameters.Add("@idProjecte", SqlDbType.Int).Value = idProjecte
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
    Private Function getObjectsSql() As List(Of ProjecteContacte)
        Dim sc As SqlCommand, sdr As SqlDataReader, pr As ProjecteContacte
        getObjectsSql = New List(Of ProjecteContacte)
        sc = New SqlCommand("SELECT * FROM " & getTable(), getConnection)
        sdr = sc.ExecuteReader
        While sdr.Read()
            pr = New ProjecteContacte(sdr(ID_PROJECTE), sdr(ID_CONTACTE), sdr(PREDETERMINAT))
            getObjectsSql.Add(pr)
        End While
        sdr.Close()
        ' getObjectsSql.Sort()
        sdr = Nothing
        sc = Nothing
    End Function

    'ACCESSORS CENTRE
    ''' <summary>
    ''' SAVE. Guarda un centre a la base de dades. 
    ''' Si es nou, fa una inserció si no  actualitza.
    ''' </summary>
    ''' <param name="obj"> centre</param>
    ''' <returns>identificador del centre.</returns>
    Private Function insertDBF(obj As ProjecteContacte) As Integer
        Dim sc As ADODB.Command
        sc = New ADODB.Command
        With sc
            .ActiveConnection = DBCONNECT.getConnectionDbf
            .CommandText = " INSERT INTO " & getTable() & " " &
                            " (" & ID_CONTACTE & ", " & ID_PROJECTE & ", " & PREDETERMINAT & ")" &
                            " VALUES(?,?,?)"
            .Parameters.Append(ADOPARAM.ToInt(obj.idContacte))
            .Parameters.Append(ADOPARAM.ToInt(obj.idProjecte))
            .Parameters.Append(ADOPARAM.toBool(obj.predeterminat))

        End With
        Try
            sc.Execute()
            Return 1
        Catch ex As Exception
            Call ERRORS.ERR_EXCEPTION_SQL(ex.Message)
            Return -1
        Finally
            sc = Nothing
        End Try
    End Function

    Private Function updatePredeterminatDBF(idProjecte As Integer) As Integer
        Dim sc As ADODB.Command
        sc = New ADODB.Command
        With sc
            .ActiveConnection = DBCONNECT.getConnectionDbf
            .CommandText = " UPDATE " & getTable() & " " &
                            " SET " & PREDETERMINAT & "=? WHERE " & ID_PROJECTE & "=?"
            .Parameters.Append(ADOPARAM.toBool(False))
            .Parameters.Append(ADOPARAM.ToInt(idProjecte))
        End With
        Try
            sc.Execute()
            Return 1
        Catch ex As Exception
            Call ERRORS.ERR_EXCEPTION_SQL(ex.Message)
            Return -1
        Finally
            sc = Nothing
        End Try
    End Function
    Private Function updatePredeterminatDBF(obj As ProjecteContacte) As Integer
        Dim sc As ADODB.Command
        sc = New ADODB.Command
        With sc
            .ActiveConnection = DBCONNECT.getConnectionDbf
            .CommandText = " UPDATE " & getTable() & " " &
                            " SET " & PREDETERMINAT & "=? WHERE " & ID_PROJECTE & "=? AND " & ID_CONTACTE & "=?"
            .Parameters.Append(ADOPARAM.toBool(True))
            .Parameters.Append(ADOPARAM.ToInt(obj.idProjecte))
            .Parameters.Append(ADOPARAM.ToInt(obj.idContacte))
        End With
        Try
            sc.Execute()
            Return 1
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
    Private Function removeDBF(obj As ProjecteContacte) As Boolean
        Dim sc As ADODB.Command
        sc = New ADODB.Command
        With sc
            sc.ActiveConnection = DBCONNECT.getConnectionDbf
            sc.CommandText = " DELETE FROM " & getTable() & " WHERE " & ID_PROJECTE & "=? AND " & ID_CONTACTE & "=?"
            sc.Parameters.Append(ADOPARAM.ToInt(obj.idProjecte, ""))
            sc.Parameters.Append(ADOPARAM.ToInt(obj.idContacte, ""))
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
    Private Function removePareDBF(idProjecte As Integer) As Boolean
        Dim sc As ADODB.Command
        sc = New ADODB.Command
        With sc
            sc.ActiveConnection = DBCONNECT.getConnectionDbf
            sc.CommandText = " DELETE FROM " & getTable() & " WHERE " & ID_PROJECTE & "=? "
            sc.Parameters.Append(ADOPARAM.ToInt(idProjecte, ""))
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
    Private Function getObjectsDBF() As List(Of ProjecteContacte)
        Dim rc As ADODB.Recordset, pc As ProjecteContacte

        rc = New ADODB.Recordset
        getObjectsDBF = New List(Of ProjecteContacte)
        rc.Open("SELECT * FROM " & getTable(), DBCONNECT.getConnectionDbf)
        While Not rc.EOF
            pc = New ProjecteContacte(rc(ID_PROJECTE).Value, rc(ID_CONTACTE).Value, rc(PREDETERMINAT).Value)
            getObjectsDBF.Add(pc)
            rc.MoveNext()
        End While
        If rc.State = 1 Then rc.Close()
        rc = Nothing

    End Function
    Private Function getTable() As String
        Return DBCONNECT.getTaulaProjecteContacte
    End Function
End Module
