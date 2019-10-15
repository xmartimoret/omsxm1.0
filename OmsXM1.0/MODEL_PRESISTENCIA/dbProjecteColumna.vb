Option Explicit On
Imports System.Data.SqlClient
Module dbProjecteColumna
    Private Const ID_PROJECTE As String = "IDPROJECTE"
    Private Const ID_COLUMNA As String = "IDCOLUMNA"
    Public Function insert(obj As ProjecteColumna) As Integer
        If IS_SQLSERVER Then Return InsertSQL(obj)
        Return InsertDBF(obj)
    End Function
    Public Function remove(obj As ProjecteColumna) As Boolean
        If IS_SQLSERVER Then Return removeSQL(obj)
        Return removeDBF(obj)
    End Function
    Public Function getObjects() As List(Of ProjecteColumna)
        If IS_SQLSERVER Then Return getObjectsSQL()
        Return getObjectsDBF()
    End Function
    ''' <summary>
    ''' Guarda un projecte columna a la base de dades i actualitza la llista d'objectes 
    ''' que estan en memoria. Només el guarda en cas que no existeix, no es pot actualitzar.
    ''' </summary>
    ''' <param name="obj">ProjecteColumna a guardara</param>
    ''' <returns>Cert si s'ha dut a terme l'acció, fals en cas contrari</returns>
    Private Function InsertSQL(obj As ProjecteColumna) As Boolean
        Dim sc As SqlCommand
        sc = New SqlCommand("INSERT INTO " & getTable() & " " &
                                " (" & ID_PROJECTE & "," & ID_COLUMNA & ") " &
                                " VALUES(@idProjecte,@idColumna)", DBCONNECT.getConnection)
        sc.Parameters.Add("@idProjecte", SqlDbType.Int).Value = obj.idProjecte
        sc.Parameters.Add("@idColumna", SqlDbType.Int).Value = obj.idColumna
        If sc.ExecuteNonQuery > 1 Then
            sc = Nothing
            Return True
        End If
        Return False
    End Function
    ''' <summary>
    ''' Elimina un ProjecteColumna de la base de dades i actualitza els objectes que estan 
    ''' en memòria-
    ''' </summary>
    ''' <param name="obj">ProjecteColumna a eliminar</param>
    ''' <returns>Cert si s'ha dut a terme l'acció, fals en cas contrari</returns>
    Private Function removeSQL(obj As ProjecteColumna) As Boolean
        Dim sc As SqlCommand
        sc = New SqlCommand(" DELETE FROM " & getTable() &
                            " WHERE " & ID_PROJECTE & "=@idProjecte and " & ID_COLUMNA & "=@idColumna ", DBCONNECT.getConnection)
        sc.Parameters.Add("@idProjecte", SqlDbType.Int).Value = obj.idProjecte
        sc.Parameters.Add("@idColumna", SqlDbType.Int).Value = obj.idColumna
        If sc.ExecuteNonQuery > 1 Then
            sc = Nothing
            Return True
        End If
        Return False
    End Function
    ''' <summary>
    ''' Carrega en memòria tots els objectes 
    ''' </summary>
    ''' <returns>Llista de projecteColumna</returns>
    Private Function getObjectsSQL() As List(Of ProjecteColumna)
        Dim sc As SqlCommand, sdr As SqlDataReader
        getObjectsSQL = New List(Of ProjecteColumna)
        sc = New SqlCommand("SELECT * FROM " & getTable(), DBCONNECT.getConnection)
        sdr = sc.ExecuteReader
        While sdr.Read()
            getObjectsSQL.Add(New ProjecteColumna(sdr(ID_PROJECTE), sdr(ID_COLUMNA)))
        End While
        sdr.Close()
        sdr = Nothing
        sc = Nothing
    End Function

    Private Function InsertDBF(obj As ProjecteColumna) As Boolean
        Dim sc As ADODB.Command
        sc = New ADODB.Command
        With sc
            .ActiveConnection = DBCONNECT.getConnectionDbf
            .CommandText = "INSERT INTO " & getTable() & " " &
                                " (" & ID_PROJECTE & "," & ID_COLUMNA & ") " &
                                " VALUES(?,?)"
            .Parameters.Append(ADOPARAM.ToInt(obj.idProjecte))
            .Parameters.Append(ADOPARAM.ToInt(obj.idColumna))
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
    ''' Elimina un ProjecteColumna de la base de dades i actualitza els objectes que estan 
    ''' en memòria-
    ''' </summary>
    ''' <param name="obj">ProjecteColumna a eliminar</param>
    ''' <returns>Cert si s'ha dut a terme l'acció, fals en cas contrari</returns>
    Private Function removeDBF(obj As ProjecteColumna) As Boolean
        Dim sc As ADODB.Command
        sc = New ADODB.Command
        With sc
            sc.ActiveConnection = DBCONNECT.getConnectionDbf
            sc.CommandText = " DELETE FROM " & getTable() &
                            " WHERE " & ID_PROJECTE & "=? and " & ID_COLUMNA & "=? "
            sc.Parameters.Append(ADOPARAM.ToInt(obj.idProjecte))
            sc.Parameters.Append(ADOPARAM.ToInt(obj.idColumna))
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
    ''' Carrega en memòria tots els objectes 
    ''' </summary>
    ''' <returns>Llista de projecteColumna</returns>
    Private Function getObjectsDBF() As List(Of ProjecteColumna)
        Dim rc As ADODB.Recordset
        rc = New ADODB.Recordset
        getObjectsDBF = New List(Of ProjecteColumna)
        rc.Open("SELECT * FROM " & getTable(), DBCONNECT.getConnectionDbf)
        While Not rc.EOF
            getObjectsDBF.Add(New ProjecteColumna(rc(ID_PROJECTE).Value, rc(ID_COLUMNA).Value))
            rc.MoveNext()
        End While
        If rc.State = 1 Then rc.Close()
        rc = Nothing
        getObjectsDBF.Sort()
    End Function


    ''' <summary>
    ''' Obté el nom de la taula projecteColumna a la base de dades
    ''' </summary>
    ''' <returns>nom de la taula</returns>
    Private Function getTable() As String
        getTable = DBCONNECT.getTaulaProjectesColumna
    End Function
End Module
