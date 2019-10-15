Option Explicit On
Imports System.Data.SqlClient
Module dbArticleComanda
    Private Const ID As String = "ID"
    Private Const ID_COMANDA As String = "iDCOM"
    Private Const POSICIO_FILA As String = "POS"
    Private Const ID_ARTICLE As String = "IDART"
    Private Const ID_PREU_ARTICLE As String = "IDARTP"
    Private Const ID_TIPUS_IVA As String = "IDIVA"
    Private Const ID_UNITAT As String = "IDUNITAT"
    Private Const QUANTITAT As String = "QUANTI"
    Private Const NOM As String = "NOM"
    'ACCESSORS CENTRE
    ''' <summary>
    ''' SAVE. Guarda un centre a la base de dades. 
    ''' Si es nou, fa una inserció si no  actualitza.
    ''' </summary>
    ''' <param name="obj"> centre</param>
    ''' <returns>identificador del centre.</returns>
    Public Function update(obj As articleComanda) As Integer
        If IS_SQLSERVER Then Return updateSQL(obj)
        Return updateDBF(obj)
    End Function
    Public Function insert(obj As articleComanda) As Integer
        If IS_SQLSERVER Then Return insertSQL(obj)
        Return insertDBF(obj)
    End Function
    Public Function remove(obj As articleComanda) As Boolean
        If IS_SQLSERVER Then Return removeSQL(obj)
        Return removeDBF(obj)
    End Function
    Public Function getObjects() As List(Of articleComanda)
        If IS_SQLSERVER Then Return getObjectsSQL()
        Return getObjectsDBF()
    End Function
    Private Function updateSQL(obj As articleComanda) As Integer
        Dim sc As SqlCommand, i As Integer
        sc = New SqlCommand("UPDATE " & getTable() & " " &
                                " SET " & ID_COMANDA & "=@idComanda," &
                                          POSICIO_FILA & "=@posFila," &
                                          ID_ARTICLE & "=@idArticle," &
                                          ID_PREU_ARTICLE & "=@idPreuArticle," &
                                          ID_TIPUS_IVA & " =@idTipusIva, " &
                                          ID_UNITAT & " =@idUnitat, " &
                                          QUANTITAT & " =@quantitat, " &
                                          NOM & " =@nom " &
                                          " WHERE " & ID & "=@id", DBCONNECT.getConnection)
        sc.Parameters.Add("@id", SqlDbType.Int).Value = obj.id
        sc.Parameters.Add("@idComanda", SqlDbType.Int).Value = obj.id
        sc.Parameters.Add("@posfila", SqlDbType.Int).Value = obj.pos
        sc.Parameters.Add("@idArticle", SqlDbType.Int).Value = obj.article.id
        sc.Parameters.Add("@idPreuArticle", SqlDbType.Int).Value = obj.preu.id
        sc.Parameters.Add("@idTipusIva", SqlDbType.Int).Value = obj.tIva.id
        sc.Parameters.Add("@idUnitat", SqlDbType.Int).Value = obj.unitat.id
        sc.Parameters.Add("@quantitat", SqlDbType.Int).Value = obj.quantitat
        sc.Parameters.Add("@nom", SqlDbType.Int).Value = obj.nom
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
    Private Function insertSQL(obj As articleComanda) As Integer
        Dim sc As SqlCommand, i As Integer
        obj.id = DBCONNECT.getMaxId(getTable) + 1

        sc = New SqlCommand(" INSERT INTO " & getTable() & " " &
                            " (" & ID & ", " & ID_COMANDA & ", " & POSICIO_FILA & ", " & ID_ARTICLE & ", " & ID_PREU_ARTICLE & ", " & ID_TIPUS_IVA & ", " & ID_UNITAT & ", " & QUANTITAT & ", " & NOM & ")" &
                            " VALUES(@id,@idComanda,@posFila,@idArticle,@preuArticle,@tipusIva,@idUnitat,@quantitat,@nom)", DBCONNECT.getConnection)
        sc.Parameters.Add("@id", SqlDbType.Int).Value = obj.id
        sc.Parameters.Add("@idComanda", SqlDbType.Int).Value = obj.id
        sc.Parameters.Add("@posfila", SqlDbType.Int).Value = obj.pos
        sc.Parameters.Add("@idArticle", SqlDbType.Int).Value = obj.article.id
        sc.Parameters.Add("@idPreuArticle", SqlDbType.Int).Value = obj.preu.id
        sc.Parameters.Add("@idTipusIva", SqlDbType.Int).Value = obj.tIva.id
        sc.Parameters.Add("@idUnitat", SqlDbType.Int).Value = obj.unitat.id
        sc.Parameters.Add("@quantitat", SqlDbType.Int).Value = obj.quantitat
        sc.Parameters.Add("@nom", SqlDbType.Int).Value = obj.nom

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
    Private Function removeSQL(obj As articleComanda) As Boolean
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
    Private Function getObjectsSQL() As List(Of articleComanda)
        Dim sc As SqlCommand, sdr As SqlDataReader, a As articleComanda
        getObjectsSQL = New List(Of articleComanda)
        sc = New SqlCommand("Select * FROM " & getTable(), getConnection)
        sdr = sc.ExecuteReader
        While sdr.Read()
            a = New articleComanda(sdr(ID), sdr(ID_COMANDA),
                               sdr(POSICIO_FILA),
                               CONFIG.validarNull(Trim(sdr(NOM))))
            a.article = ModelArticle.getObject(sdr(ID_ARTICLE))
            a.preu = ModelarticlePreu.getObject(sdr(ID_PREU_ARTICLE))
            a.quantitat = sdr(QUANTITAT)
            a.tIva = ModelTipusIva.getAuxiliar.getObject(sdr(ID_TIPUS_IVA))
            a.unitat = ModelUnitat.getAuxiliar.getObject(sdr(ID_UNITAT))
            getObjectsSQL.Add(a)
        End While
        sdr.Close()
        sdr = Nothing
        sc = Nothing
    End Function

    Private Function updateDBF(obj As articleComanda) As Integer
        Dim sc As ADODB.Command
        sc = New ADODB.Command
        With sc
            .ActiveConnection = DBCONNECT.getConnectionDbf
            .CommandText = "UPDATE " & getTable() & " " &
                                 " SET " & ID_COMANDA & "=?," &
                                          POSICIO_FILA & "=?," &
                                          ID_ARTICLE & "=?," &
                                          ID_PREU_ARTICLE & "=?," &
                                          ID_TIPUS_IVA & " =?, " &
                                          ID_UNITAT & " =?, " &
                                          QUANTITAT & " =?, " &
                                          NOM & " =? " &
                                          " WHERE " & ID & "=?"
            .Parameters.Append(ADOPARAM.ToInt(obj.idComanda))
            .Parameters.Append(ADOPARAM.ToInt(obj.pos))
            .Parameters.Append(ADOPARAM.ToInt(obj.article.id))
            .Parameters.Append(ADOPARAM.ToInt(obj.preu.id))
            .Parameters.Append(ADOPARAM.ToInt(obj.tIva.id))
            .Parameters.Append(ADOPARAM.ToInt(obj.unitat.id))
            .Parameters.Append(ADOPARAM.ToSingle(obj.quantitat))
            .Parameters.Append(ADOPARAM.ToString(obj.nom))
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
    Private Function insertDBF(obj As articleComanda) As Integer
        Dim sc As ADODB.Command
        sc = New ADODB.Command
        obj.id = DBCONNECT.getMaxIdDBF(getTable) + 1
        With sc
            .ActiveConnection = DBCONNECT.getConnectionDbf
            .CommandText = " INSERT INTO " & getTable() & " " &
                           " (" & ID & ", " & ID_COMANDA & ", " & POSICIO_FILA & ", " & ID_ARTICLE & ", " & ID_PREU_ARTICLE & ", " & ID_TIPUS_IVA & ", " & ID_UNITAT & ", " & QUANTITAT & ", " & NOM & ")" &
                            " VALUES(?,?,?,?,?,?,?,?,?)"
            .Parameters.Append(ADOPARAM.ToInt(obj.id))
            .Parameters.Append(ADOPARAM.ToInt(obj.idComanda))
            .Parameters.Append(ADOPARAM.ToInt(obj.pos))
            .Parameters.Append(ADOPARAM.ToInt(obj.article.id))
            .Parameters.Append(ADOPARAM.ToInt(obj.preu.id))
            .Parameters.Append(ADOPARAM.ToInt(obj.tIva.id))
            .Parameters.Append(ADOPARAM.ToInt(obj.unitat.id))
            .Parameters.Append(ADOPARAM.ToSingle(obj.quantitat))
            .Parameters.Append(ADOPARAM.ToString(obj.nom))
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
    Private Function removeDBF(obj As articleComanda) As Boolean
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
    Private Function getObjectsDBF() As List(Of articleComanda)
        Dim rc As ADODB.Recordset, a As articleComanda
        rc = New ADODB.Recordset
        getObjectsDBF = New List(Of articleComanda)
        rc.Open("Select * FROM " & getTable(), DBCONNECT.getConnectionDbf)
        While Not rc.EOF
            a = New articleComanda(rc(ID).Value, rc(ID_COMANDA).Value,
                               rc(POSICIO_FILA).Value,
                               CONFIG.validarNull(Trim(rc(NOM).Value)))
            a.article = ModelArticle.getObject(rc(ID_ARTICLE).Value)
            a.preu = ModelarticlePreu.getObject(rc(ID_PREU_ARTICLE).Value)
            a.quantitat = rc(QUANTITAT).Value
            a.tIva = ModelTipusIva.getAuxiliar.getObject(rc(ID_TIPUS_IVA).Value)
            a.unitat = ModelUnitat.getAuxiliar.getObject(rc(ID_UNITAT).Value)
            getObjectsSQL.Add(a)
            rc.MoveNext()
        End While
        If rc.State = 1 Then rc.Close()
        rc = Nothing
    End Function
    Private Function getTable() As String
        Return DBCONNECT.getTaulaArticleCOMANDA
    End Function
End Module
