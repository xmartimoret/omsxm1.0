Option Explicit On
Imports System.Data.SqlClient
Module dbProjecteEntrega
    Private Const ID_PROJECTE As String = "idProj"
    Private Const ID_ENTREGA As String = "idEnt"
    'ACCESSORS CENTRE
    ''' <summary>
    ''' SAVE. Guarda un centre a la base de dades. 
    ''' Si es nou, fa una inserció si no  actualitza.
    ''' </summary>
    ''' <param name="obj"> centre</param>
    ''' <returns>identificador del centre.</returns>

    Public Function insert(obj As projecteEntrega) As Integer
        If IS_SQLSERVER Then Return insertSql(obj)
        Return insertDBF(obj)
    End Function
    Public Function remove(obj As projecteEntrega) As Boolean
        If IS_SQLSERVER Then Return removeSql(obj)
        Return removeDBF(obj)
    End Function
    Public Function removePare(idProjecte As Integer) As Boolean
        If IS_SQLSERVER Then Return removePareSql(idProjecte)
        Return removePareDBF(idProjecte)
    End Function
    Public Function getObjects() As List(Of projecteEntrega)
        If IS_SQLSERVER Then Return getObjectsSql()
        Return getObjectsDBF()
    End Function

    'ACCESSORS CENTRE
    ''' <summary>
    ''' SAVE. Guarda un centre a la base de dades. 
    ''' Si es nou, fa una inserció si no  actualitza.
    ''' </summary>
    ''' <param name="obj"> centre</param>
    ''' <returns>identificador del centre.</returns>
    Private Function insertSql(obj As projecteEntrega) As Integer
        Dim sc As SqlCommand, i As Integer
        sc = New SqlCommand(" INSERT INTO " & getTable() & " " &
                            " (" & ID_ENTREGA & ", " & ID_PROJECTE & ")" &
                            " VALUES(@idEntrega,@idProjecte)", DBCONNECT.getConnection)
        sc.Parameters.Add("@idEntrega", SqlDbType.Int).Value = obj.idEntrega
        sc.Parameters.Add("@idProjecte", SqlDbType.Int).Value = obj.idProjecte
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
    Private Function removeSql(obj As projecteEntrega) As Boolean
        Dim sc As SqlCommand, i As Integer
        sc = New SqlCommand("DELETE FROM " & getTable() & " WHERE " & ID_PROJECTE & "=@idProjecte and  " & ID_ENTREGA & " = @idEntrega", DBCONNECT.getConnection)
        sc.Parameters.Add("@idProjecte", SqlDbType.Int).Value = obj.idProjecte
        sc.Parameters.Add("@idEntrega", SqlDbType.Int).Value = obj.idEntrega
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
    Private Function getObjectsSql() As List(Of projecteEntrega)
        Dim sc As SqlCommand, sdr As SqlDataReader, pr As projecteEntrega
        getObjectsSql = New List(Of projecteEntrega)
        sc = New SqlCommand("SELECT * FROM " & getTable(), getConnection)
        sdr = sc.ExecuteReader
        While sdr.Read()
            pr = New projecteEntrega(sdr(ID_PROJECTE), sdr(ID_ENTREGA))
            getObjectsSql.Add(pr)
        End While
        sdr.Close()
        'getObjectsSql.Sort()
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
    Private Function insertDBF(obj As projecteEntrega) As Integer
        Dim sc As ADODB.Command
        sc = New ADODB.Command
        With sc
            .ActiveConnection = DBCONNECT.getConnectionDbf
            .CommandText = " INSERT INTO " & getTable() & " " &
                            " (" & ID_ENTREGA & ", " & ID_PROJECTE & ")" &
                            " VALUES(?,?)"
            .Parameters.Append(ADOPARAM.ToInt(obj.idEntrega))
            .Parameters.Append(ADOPARAM.ToInt(obj.idProjecte))

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
    Private Function removeDBF(obj As projecteEntrega) As Boolean
        Dim sc As ADODB.Command
        sc = New ADODB.Command
        With sc
            sc.ActiveConnection = DBCONNECT.getConnectionDbf
            sc.CommandText = " DELETE FROM " & getTable() & " WHERE " & ID_PROJECTE & "=? AND " & ID_ENTREGA & "=?"
            sc.Parameters.Append(ADOPARAM.ToInt(obj.idProjecte, ""))
            sc.Parameters.Append(ADOPARAM.ToInt(obj.idEntrega, ""))
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
    Private Function getObjectsDBF() As List(Of projecteEntrega)
        Dim rc As ADODB.Recordset, pc As projecteEntrega

        rc = New ADODB.Recordset
        getObjectsDBF = New List(Of projecteEntrega)
        rc.Open("SELECT * FROM " & getTable(), DBCONNECT.getConnectionDbf)
        While Not rc.EOF
            pc = New projecteEntrega(rc(ID_PROJECTE).Value, rc(ID_ENTREGA).Value)
            getObjectsDBF.Add(pc)
            rc.MoveNext()
        End While
        If rc.State = 1 Then rc.Close()
        rc = Nothing

    End Function
    Private Function getTable() As String
        Return DBCONNECT.getTaulaProjecteEntrega
    End Function
End Module
