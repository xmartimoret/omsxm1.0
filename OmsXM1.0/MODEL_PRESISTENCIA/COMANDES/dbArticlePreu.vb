Option Explicit On
Imports System.Data.SqlClient
Module dbArticlePreu
    Private Const ID As String = "ID"
    Private Const ID_ARTICLE As String = "IDART"
    Private Const ID_PROVEIDOR As String = "IDPROV"
    Private Const DATA As String = "DATA"
    Private Const IMPORT_BASE As String = "PREU"
    Private Const DESCOMPTE As String = "DESCOMPTE"
    'ACCESSORS CENTRE
    ''' <summary>
    ''' SAVE. Guarda un centre a la base de dades. 
    ''' Si es nou, fa una inserció si no  actualitza.
    ''' </summary>
    ''' <param name="obj"> centre</param>
    ''' <returns>identificador del centre.</returns>
    Public Function update(obj As ArticlePreu) As Integer
        If IS_SQLSERVER Then Return updateSQL(obj)
        Return updateDBF(obj)
    End Function
    Public Function insert(obj As ArticlePreu) As Integer
        If IS_SQLSERVER Then Return insertSQL(obj)
        Return insertDBF(obj)
    End Function
    Public Function remove(obj As ArticlePreu) As Boolean
        If IS_SQLSERVER Then Return removeSQL(obj)
        Return removeDBF(obj)
    End Function
    Public Function getObjects() As List(Of ArticlePreu)
        If IS_SQLSERVER Then Return getObjectsSQL()
        Return getObjectsDBF()
    End Function
    Private Function updateSQL(obj As ArticlePreu) As Integer
        Dim sc As SqlCommand, i As Integer
        sc = New SqlCommand("UPDATE " & getTable() & " " &
                                " SET " & ID_ARTICLE & "=@idArticle," &
                                          ID_PROVEIDOR & "=@idProveidor," &
                                          DATA & "=@data," &
                                          IMPORT_BASE & " =@base, " &
                                          DESCOMPTE & " =@descompte " &
                                          " WHERE " & ID & "=@id", DBCONNECT.getConnection)
        sc.Parameters.Add("@id", SqlDbType.Int).Value = obj.id
        sc.Parameters.Add("@idArticle", SqlDbType.Int).Value = obj.idArticle
        sc.Parameters.Add("@idProveidor", SqlDbType.Int).Value = obj.idProveidor
        sc.Parameters.Add("@data", SqlDbType.Date).Value = obj.data
        sc.Parameters.Add("@base", SqlDbType.Decimal).Value = obj.base
        sc.Parameters.Add("@descompte", SqlDbType.Int).Value = obj.descompte
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
    Private Function insertSQL(obj As ArticlePreu) As Integer
        Dim sc As SqlCommand, i As Integer
        obj.id = DBCONNECT.getMaxId(getTable) + 1
        sc = New SqlCommand(" INSERT INTO " & getTable() & " " &
                            " (" & ID & ", " & ID_ARTICLE & ", " & ID_PROVEIDOR & ", " & DATA & ", " & IMPORT_BASE & ", " & DESCOMPTE & ")" &
                            " VALUES(@id,@idArticle,@idProveidor,@data,@base,@descompte)", DBCONNECT.getConnection)
        sc.Parameters.Add("@id", SqlDbType.Int).Value = obj.id
        sc.Parameters.Add("@idArticle", SqlDbType.Int).Value = obj.idArticle
        sc.Parameters.Add("@idProveidor", SqlDbType.Int).Value = obj.idProveidor
        sc.Parameters.Add("@data", SqlDbType.Date).Value = obj.data
        sc.Parameters.Add("@base", SqlDbType.Decimal).Value = obj.base
        sc.Parameters.Add("@descompte", SqlDbType.Int).Value = obj.descompte

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
    Private Function removeSQL(obj As ArticlePreu) As Boolean
        Dim sc As SqlCommand, i As Integer
        sc = New SqlCommand("DELETE FROM " & getTable() & " WHERE " & ID_ARTICLE & "=@id", DBCONNECT.getConnection)
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
    Private Function getObjectsSQL() As List(Of ArticlePreu)
        Dim sc As SqlCommand, sdr As SqlDataReader, a As ArticlePreu
        getObjectsSQL = New List(Of ArticlePreu)
        sc = New SqlCommand("Select * FROM " & getTable(), getConnection)
        sdr = sc.ExecuteReader
        While sdr.Read()
            a = New ArticlePreu(sdr(ID),
                               sdr(ID_ARTICLE),
                               sdr(ID_PROVEIDOR),
                               CONFIG.validarNull(sdr(DATA)),
                               sdr(IMPORT_BASE),
                               sdr(DESCOMPTE))
            getObjectsSQL.Add(a)
        End While
        sdr.Close()
        sdr = Nothing
        sc = Nothing
    End Function

    Private Function updateDBF(obj As ArticlePreu) As Integer
        Dim sc As ADODB.Command
        sc = New ADODB.Command
        With sc
            .ActiveConnection = DBCONNECT.getConnectionDbf
            .CommandText = "UPDATE " & getTable() & " " &
                                " SET " & ID_ARTICLE & "=?," &
                                          ID_PROVEIDOR & "=?," &
                                          DATA & "=?," &
                                          IMPORT_BASE & " =?, " &
                                          DESCOMPTE & " =? " &
                                          " WHERE " & ID & "=?"

            .Parameters.Append(ADOPARAM.ToInt(obj.idArticle))
            .Parameters.Append(ADOPARAM.ToInt(obj.idProveidor))
            .Parameters.Append(ADOPARAM.ToDate(obj.data))
            .Parameters.Append(ADOPARAM.ToSingle(obj.base))
            .Parameters.Append(ADOPARAM.ToInt(obj.descompte))
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
    Private Function insertDBF(obj As ArticlePreu) As Integer
        Dim sc As ADODB.Command
        sc = New ADODB.Command
        obj.id = DBCONNECT.getMaxIdDBF(getTable) + 1
        With sc
            .ActiveConnection = DBCONNECT.getConnectionDbf
            .CommandText = " INSERT INTO " & getTable() & " " &
                            " (" & ID & ", " & ID_ARTICLE & ", " & ID_PROVEIDOR & ", " & DATA & ", " & IMPORT_BASE & ", " & DESCOMPTE & ")" &
                            " VALUES(?,?,?,?,?,?)"
            .Parameters.Append(ADOPARAM.ToInt(obj.id))
            .Parameters.Append(ADOPARAM.ToInt(obj.idArticle))
            .Parameters.Append(ADOPARAM.ToInt(obj.idProveidor))
            .Parameters.Append(ADOPARAM.ToDate(obj.data))
            .Parameters.Append(ADOPARAM.ToSingle(obj.base))
            .Parameters.Append(ADOPARAM.ToInt(obj.descompte))

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
    Private Function removeDBF(obj As ArticlePreu) As Boolean
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
    Private Function getObjectsDBF() As List(Of ArticlePreu)
        Dim rc As ADODB.Recordset, a As ArticlePreu
        rc = New ADODB.Recordset
        getObjectsDBF = New List(Of ArticlePreu)
        rc.Open("Select * FROM " & getTable(), DBCONNECT.getConnectionDbf)
        While Not rc.EOF
            a = New ArticlePreu(rc(ID).Value,
                               rc(ID_ARTICLE).Value,
                               rc(ID_PROVEIDOR).Value,
                               CONFIG.validarNull(rc(DATA).Value),
                               rc(IMPORT_BASE).Value,
                               rc(DESCOMPTE).Value)
            getObjectsDBF.Add(a)
            rc.MoveNext()
        End While
        If rc.State = 1 Then rc.Close()
        rc = Nothing
    End Function
    Private Function getTable() As String
        Return DBCONNECT.getTaulaArticlePreu
    End Function
End Module
