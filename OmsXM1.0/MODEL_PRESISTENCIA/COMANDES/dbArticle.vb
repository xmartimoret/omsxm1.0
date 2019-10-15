Option Explicit On
Imports System.Data.SqlClient
Module dbArticle

    Private Const ID As String = "ID"
    Private Const CODI As String = "CODI"
    Private Const NOM As String = "NOM"
    Private Const ID_IVA As String = "IDIVA"
    Private Const ID_FAMILIA As String = "IDFAMILIA"
    Private Const ID_FABRICANT As String = "IDFABRICAN"
    Private Const ID_UNITAT As String = "IDUNITAT"
    Private Const NOTES As String = "notes"
    'ACCESSORS CENTRE
    ''' <summary>
    ''' SAVE. Guarda un centre a la base de dades. 
    ''' Si es nou, fa una inserció si no  actualitza.
    ''' </summary>
    ''' <param name="obj"> centre</param>
    ''' <returns>identificador del centre.</returns>
    Public Function update(obj As article) As Integer
        If IS_SQLSERVER Then Return updateSQL(obj)
        Return updateDBF(obj)
    End Function
    Public Function insert(obj As article) As Integer
        If IS_SQLSERVER Then Return insertSQL(obj)
        Return insertDBF(obj)
    End Function
    Public Function remove(obj As article) As Boolean
        If IS_SQLSERVER Then Return removeSQL(obj)
        Return removeDBF(obj)
    End Function
    Public Function getObjects() As List(Of article)
        If IS_SQLSERVER Then Return getObjectsSQL()
        Return getObjectsDBF()
    End Function
    Private Function updateSQL(obj As article) As Integer
        Dim sc As SqlCommand, i As Integer
        sc = New SqlCommand("UPDATE " & getTable() & " " &
                                " SET " & CODI & "=@codi," &
                                          NOM & " =@nom, " &
                                          NOTES & " =@notes, " &
                                          ID_FAMILIA & " =@IdFamilia, " &
                                          ID_UNITAT & " =@idUnitat, " &
                                          ID_FABRICANT & " =@idFabricant, " &
                                          ID_IVA & " =@idIva " &
                                          " WHERE " & ID & "=@id", DBCONNECT.getConnection)
        sc.Parameters.Add("@id", SqlDbType.Int).Value = obj.id
        sc.Parameters.Add("@codi", SqlDbType.VarChar).Value = obj.codi
        sc.Parameters.Add("@nom", SqlDbType.VarChar).Value = obj.nom
        sc.Parameters.Add("@notes", SqlDbType.VarChar).Value = obj.notes
        sc.Parameters.Add("@idFamilia", SqlDbType.Int).Value = obj.familia.id
        sc.Parameters.Add("@idUnitat", SqlDbType.Int).Value = obj.unitat.id
        sc.Parameters.Add("@idFabricant", SqlDbType.Int).Value = obj.fabricant.id
        sc.Parameters.Add("@idIva", SqlDbType.Int).Value = obj.iva.id
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
    Private Function insertSQL(obj As article) As Integer
        Dim sc As SqlCommand, i As Integer
        obj.id = DBCONNECT.getMaxId(getTable) + 1
        sc = New SqlCommand(" INSERT INTO " & getTable() & " " &
                            " (" & ID & ", " & CODI & ", " & NOM & ", " & NOTES & ", " & ID_FAMILIA & ", " & ID_FABRICANT & ", " & ID_UNITAT & ", " & ID_IVA & ")" &
                            " VALUES(@id,@codi,@nom,@notes,@idFamilia,@idFabricant,@idUnitat,@idIva)", DBCONNECT.getConnection)
        sc.Parameters.Add("@id", SqlDbType.Int).Value = obj.id
        sc.Parameters.Add("@codi", SqlDbType.VarChar).Value = obj.codi
        sc.Parameters.Add("@nom", SqlDbType.VarChar).Value = obj.nom
        sc.Parameters.Add("@notes", SqlDbType.VarChar).Value = obj.notes
        sc.Parameters.Add("@idFamilia", SqlDbType.Int).Value = obj.familia.id
        sc.Parameters.Add("@idUnitat", SqlDbType.Int).Value = obj.unitat.id
        sc.Parameters.Add("@idFabricant", SqlDbType.Int).Value = obj.fabricant.id
        sc.Parameters.Add("@idIva", SqlDbType.Int).Value = obj.iva.id
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
    Private Function removeSQL(obj As article) As Boolean
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
    Private Function getObjectsSQL() As List(Of article)
        Dim sc As SqlCommand, sdr As SqlDataReader, a As article
        getObjectsSQL = New List(Of article)
        sc = New SqlCommand("Select * FROM " & getTable(), getConnection)
        sdr = sc.ExecuteReader
        While sdr.Read()
            a = New article(sdr(ID),
                               CONFIG.validarNull(Trim(sdr(CODI))),
                               CONFIG.validarNull(Trim(sdr(NOM))),
                               Trim(CONFIG.validarNull(sdr(NOTES))))
            a.familia = ModelFamilia.getAuxiliar.getObject(sdr(ID_FAMILIA))
            a.unitat = ModelUnitat.getAuxiliar.getObject(sdr(ID_UNITAT))
            a.fabricant = ModelFabricant.getAuxiliar.getObject(sdr(ID_FABRICANT))
            a.iva = ModelTipusIva.getAuxiliar.getObject(sdr(ID_IVA))
            getObjectsSQL.Add(a)
        End While
        sdr.Close()
        getObjectsSQL.Sort()
        sdr = Nothing
        sc = Nothing
    End Function

    Private Function updateDBF(obj As article) As Integer
        Dim sc As ADODB.Command
        sc = New ADODB.Command
        With sc
            .ActiveConnection = DBCONNECT.getConnectionDbf
            .CommandText = "UPDATE " & getTable() & " " &
                                " Set " & CODI & "=?," &
                                          NOM & " =?, " &
                                          NOTES & " =?, " &
                                          ID_FAMILIA & " =?, " &
                                          ID_UNITAT & " =?, " &
                                          ID_FABRICANT & " =?, " &
                                          ID_IVA & " =? " &
                                          " WHERE " & ID & "=?"
            .Parameters.Append(ADOPARAM.ToString(obj.codi))
            .Parameters.Append(ADOPARAM.ToString(obj.nom))
            .Parameters.Append(ADOPARAM.ToString(obj.notes))
            .Parameters.Append(ADOPARAM.ToInt(obj.familia.id))
            .Parameters.Append(ADOPARAM.ToInt(obj.unitat.id))
            .Parameters.Append(ADOPARAM.ToInt(obj.fabricant.id))
            .Parameters.Append(ADOPARAM.ToInt(obj.iva.id))
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
    Private Function insertDBF(obj As article) As Integer
        Dim sc As ADODB.Command
        sc = New ADODB.Command
        obj.id = DBCONNECT.getMaxIdDBF(getTable) + 1
        With sc
            .ActiveConnection = DBCONNECT.getConnectionDbf
            .CommandText = " INSERT INTO " & getTable() & " " &
                            " (" & ID & ", " & CODI & ", " & NOM & ", " & NOTES & ", " & ID_FAMILIA & ", " & ID_FABRICANT & ", " & ID_UNITAT & ", " & ID_IVA & ")" &
                            " VALUES(?,?,?,?,?,?,?,?)"
            .Parameters.Append(ADOPARAM.ToInt(obj.id))
            .Parameters.Append(ADOPARAM.ToString(obj.codi))
            .Parameters.Append(ADOPARAM.ToString(obj.nom))
            .Parameters.Append(ADOPARAM.ToString(obj.notes))
            .Parameters.Append(ADOPARAM.ToInt(obj.familia.id))
            .Parameters.Append(ADOPARAM.ToInt(obj.fabricant.id))
            .Parameters.Append(ADOPARAM.ToInt(obj.unitat.id))
            .Parameters.Append(ADOPARAM.ToInt(obj.iva.id))

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
    Private Function removeDBF(obj As article) As Boolean
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
    Private Function getObjectsDBF() As List(Of article)
        Dim rc As ADODB.Recordset, a As article
        rc = New ADODB.Recordset
        getObjectsDBF = New List(Of article)
        rc.Open("Select * FROM " & getTable(), DBCONNECT.getConnectionDbf)
        While Not rc.EOF
            a = New article(rc(ID).Value,
                               CONFIG.validarNull(Trim(rc(CODI).Value)),
                               Trim(CONFIG.validarNull(rc(NOM).Value)),
                               Trim(CONFIG.validarNull(rc(NOTES).Value)))
            a.familia = ModelFamilia.getAuxiliar.getObject(rc(ID_FAMILIA).Value)
            a.unitat = ModelUnitat.getAuxiliar.getObject(rc(ID_UNITAT).Value)
            a.fabricant = ModelFabricant.getAuxiliar.getObject(rc(ID_FABRICANT).Value)
            a.iva = ModelTipusIva.getAuxiliar.getObject(rc(ID_IVA).Value)
            getObjectsDBF.Add(a)
            rc.MoveNext()
        End While
        If rc.State = 1 Then rc.Close()
        rc = Nothing
        getObjectsDBF.Sort()
    End Function
    Private Function getTable() As String
        Return DBCONNECT.getTaulaArticle
    End Function
End Module

