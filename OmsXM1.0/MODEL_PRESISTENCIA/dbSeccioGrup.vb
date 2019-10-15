Option Explicit On
Imports System.Data.SqlClient
Module dbSeccioGrup
    Private Const ID_GRUP As String = "IDGRUP"
    Private Const ID_SECCIO As String = "IDSECCIO"
    Public Function insert(idSeccio As Integer, idGrup As Integer) As Integer
        If IS_SQLSERVER Then Return insertSQL(idSeccio, idGrup)
        Return insertDBF(idSeccio, idGrup)
    End Function
    Public Function remove(idSeccio As Integer, idGrup As Integer) As Boolean
        If IS_SQLSERVER Then Return removeSQL(idSeccio, idGrup)
        Return removeDBF(idSeccio, idGrup)
    End Function
    Public Function removeSeccio(idSeccio As Integer) As Boolean
        If IS_SQLSERVER Then Return removeSeccioSQL(idSeccio)
        Return removeSeccioDBF(idSeccio)
    End Function
    Public Function getObjects() As List(Of SeccioGrup)
        If IS_SQLSERVER Then Return getObjectsSQL()
        Return getObjectsDBF()
    End Function


    ''' <summary>
    ''' Guarda un grup comptable per una seccio
    ''' </summary>
    ''' <param name="idSeccio"> id seccio</param>
    ''' <param name="idGrup">id  grup</param>
    ''' <returns>cert si es dur a terme l'operacio, fals en cas contrari</returns>
    Private Function insertSQL(idSeccio As Integer, idGrup As Integer) As Boolean
        Dim sc As SqlCommand, i As Integer
        sc = New SqlCommand(" INSERT INTO " & getTable() & " " &
                     " (" & ID_SECCIO & ",  " & ID_GRUP & ")" &
                     " VALUES(@idSeccio,@idGrup)", DBCONNECT.getConnection)
        sc.Parameters.Add("@idSeccio", SqlDbType.Int).Value = idSeccio
        sc.Parameters.Add("@idgrup", SqlDbType.Int).Value = idGrup
        i = sc.ExecuteNonQuery
        sc = Nothing
        If i >= 1 Then
            Return True
        End If
        Return False
    End Function
    ''' <summary>
    '''     Elimina un grup Comptable associat a una seccio
    ''' </summary>
    ''' <param name="idSeccio">id de la seccio</param>
    ''' <param name="idGrup">id del grup</param>
    ''' <returns>Cert  si l'operació es dur a terme, fals en cas contrari</returns>
    Private Function removeSQL(idSeccio As Integer, idGrup As Integer) As Boolean
        Dim sc As SqlCommand, i As Integer
        sc = New SqlCommand("DELETE FROM " & getTable() & " WHERE " & ID_SECCIO & "=@idSeccio AND " & ID_GRUP & "= @IdGrup", DBCONNECT.getConnection)
        sc.Parameters.Add("@idSeccio", SqlDbType.Int).Value = idSeccio
        sc.Parameters.Add("@idGrup", SqlDbType.Int).Value = idGrup
        i = sc.ExecuteNonQuery
        sc = Nothing
        If i >= 1 Then
            Return True
        End If
        Return False
    End Function
    ''' <summary>
    ''' Elimina tots els grups Comptables d'una seccio
    ''' </summary>
    ''' <param name="idSeccio">idSeccio</param>
    ''' <returns>cert si l'operació es dur a terme, fals en cas contrari</returns>
    Private Function removeSeccioSQL(idSeccio As Integer) As Boolean
        Dim sc As SqlCommand, i As Integer
        sc = New SqlCommand("DELETE FROM " & getTable() & " WHERE " & ID_SECCIO & "=@idSeccio", DBCONNECT.getConnection)
        sc.Parameters.Add("@idSeccio", SqlDbType.Int).Value = idSeccio
        i = sc.ExecuteNonQuery
        sc = Nothing
        If i >= 1 Then
            Return True
        End If
        Return False
    End Function

    ''' <summary>
    ''' obté tots els seccioGrup de la BBDD
    ''' </summary>
    ''' <returns>Una llista de tots els SeccioGrup de la BBDD</returns>
    Private Function getObjectsSQL() As List(Of SeccioGrup)
        Dim sc As SqlCommand, sdr As SqlDataReader
        getObjectsSQL = New List(Of SeccioGrup)
        sc = New SqlCommand("Select * FROM " & getTable(), DBCONNECT.getConnection)
        sdr = sc.ExecuteReader
        While sdr.Read()
            getObjectsSQL.Add(New SeccioGrup(sdr(ID_SECCIO), sdr(ID_GRUP)))
        End While
        sdr.Close()
        sdr = Nothing
        sc = Nothing
    End Function
    ''' <summary>
    ''' Guarda un grup comptable per una seccio
    ''' </summary>
    ''' <param name="idSeccio"> id seccio</param>
    ''' <param name="idGrup">id  grup</param>
    ''' <returns>cert si es dur a terme l'operacio, fals en cas contrari</returns>
    Private Function insertDBF(idSeccio As Integer, idGrup As Integer) As Boolean
        Dim sc As ADODB.Command
        sc = New ADODB.Command
        With sc
            .ActiveConnection = DBCONNECT.getConnectionDbf
            .CommandText = " INSERT INTO " & getTable() & " " &
                     " (" & ID_SECCIO & ",  " & ID_GRUP & ")" &
                     " VALUES(?,?)"
            .Parameters.Append(ADOPARAM.ToInt(idSeccio))
            .Parameters.Append(ADOPARAM.ToInt(idGrup))
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
    '''     Elimina un grup Comptable associat a una seccio
    ''' </summary>
    ''' <param name="idSeccio">id de la seccio</param>
    ''' <param name="idGrup">id del grup</param>
    ''' <returns>Cert  si l'operació es dur a terme, fals en cas contrari</returns>
    Private Function removeDBF(idSeccio As Integer, idGrup As Integer) As Boolean
        Dim sc As ADODB.Command
        sc = New ADODB.Command
        With sc
            sc.ActiveConnection = DBCONNECT.getConnectionDbf
            sc.CommandText = "DELETE FROM " & getTable() & " WHERE " & ID_SECCIO & "=? AND " & ID_GRUP & "= ?"
            sc.Parameters.Append(ADOPARAM.ToInt(idSeccio))
            sc.Parameters.Append(ADOPARAM.ToInt(idGrup))
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
    ''' Elimina tots els grups Comptables d'una seccio
    ''' </summary>
    ''' <param name="idSeccio">idSeccio</param>
    ''' <returns>cert si l'operació es dur a terme, fals en cas contrari</returns>
    Private Function removeSeccioDBF(idSeccio As Integer) As Boolean
        Dim sc As ADODB.Command
        sc = New ADODB.Command
        With sc
            sc.ActiveConnection = DBCONNECT.getConnectionDbf
            sc.CommandText = "DELETE FROM " & getTable() & " WHERE " & ID_SECCIO & "=@idSeccio"
            sc.Parameters.Append(ADOPARAM.ToInt(idSeccio))
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
    ''' obté tots els seccioGrup de la BBDD
    ''' </summary>
    ''' <returns>Una llista de tots els SeccioGrup de la BBDD</returns>
    Private Function getObjectsDBF() As List(Of SeccioGrup)
        Dim rc As ADODB.Recordset
        rc = New ADODB.Recordset
        getObjectsDBF = New List(Of SeccioGrup)
        rc.Open("SELECT * FROM " & getTable(), DBCONNECT.getConnectionDbf)
        While Not rc.EOF
            getObjectsDBF.Add(New SeccioGrup(rc(ID_SECCIO).Value, rc(ID_GRUP).Value))
            rc.MoveNext()
        End While
        If rc.State = 1 Then rc.Close()
        rc = Nothing

    End Function
    ''' <summary>
    ''' Obté el nom de la base de dades de la BBDD
    ''' </summary>
    ''' <returns> String. NomTaulaDades</returns>
    Private Function getTable() As String
        Return DBCONNECT.getTaulaGrupsSeccio
    End Function
End Module
