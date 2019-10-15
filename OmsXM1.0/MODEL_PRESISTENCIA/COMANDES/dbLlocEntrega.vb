Option Explicit On
Imports System.Data.SqlClient
Module dbLlocEntrega
    Private Const ID As String = "id"
    Private Const NOM As String = "NOM"
    Private Const DIRECCIO As String = "direccio"
    Private Const POBLACIO As String = "poblacio"
    Private Const CODI_POSTAL As String = "cp"
    Private Const ESTAT As String = "estat"
    Private Const ID_PAIS As String = "idPais"
    Private Const ID_PROVINCIA As String = "idProv"
    Private Const notes As String = "notes"
    Private auxiliarPais As ModelAuxiliar
    Private auxiliarProv As ModelAuxiliar
    'ACCESSORS CENTRE
    ''' <summary>
    ''' SAVE. Guarda un centre a la base de dades. 
    ''' Si es nou, fa una inserció si no  actualitza.
    ''' </summary>
    ''' <param name="obj"> centre</param>
    ''' <returns>identificador del centre.</returns>
    Public Function update(obj As LlocEntrega) As Integer
        If IS_SQLSERVER Then Return updateSql(obj)
        Return updateDBF(obj)
    End Function
    Public Function insert(obj As LlocEntrega) As Integer
        If IS_SQLSERVER Then Return insertSql(obj)
        Return insertDBF(obj)
    End Function
    Public Function remove(obj As LlocEntrega) As Boolean
        If IS_SQLSERVER Then Return removeSql(obj)
        Return removeDBF(obj)
    End Function
    Public Function getObjects() As List(Of LlocEntrega)
        If IS_SQLSERVER Then Return getObjectsSql()
        Return getObjectsDBF()
    End Function
    Private Function updateSql(obj As LlocEntrega) As Integer
        Dim sc As SqlCommand, i As Integer
        sc = New SqlCommand("UPDATE " & getTable() & " " &
                                " SET " & NOM & "=@nom," &
                                          DIRECCIO & " =@direccio, " &
                                          POBLACIO & " =@poblacio, " &
                                          CODI_POSTAL & " =@codiPostal, " &
                                          ID_PAIS & " =@idPais, " &
                                          ID_PROVINCIA & " =@idProvincia, " &
                                          notes & " =@notes, " &
                                          ESTAT & " =@estat " &
                                " WHERE " & ID & "=@id", DBCONNECT.getConnection)


        sc.Parameters.Add("@id", SqlDbType.Int).Value = obj.id
        sc.Parameters.Add("@nom", SqlDbType.VarChar).Value = obj.nom
        sc.Parameters.Add("@direccio", SqlDbType.VarChar).Value = obj.direccio
        sc.Parameters.Add("@poblacio", SqlDbType.VarChar).Value = obj.poblacio
        sc.Parameters.Add("@codiPostal", SqlDbType.VarChar).Value = obj.codiPostal
        sc.Parameters.Add("@idPais", SqlDbType.Int).Value = obj.pais.id
        sc.Parameters.Add("@idProvincia", SqlDbType.Int).Value = obj.provincia.id
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
    Private Function insertSql(obj As LlocEntrega) As Integer
        Dim sc As SqlCommand, i As Integer
        obj.id = DBCONNECT.getMaxId(getTable) + 1
        sc = New SqlCommand(" INSERT INTO " & getTable() & " " &
                            " (" & ID & "," & NOM & "," & DIRECCIO & ", " _
                            & POBLACIO & ", " & CODI_POSTAL & ", " _
                            & ID_PAIS & ", " & ID_PROVINCIA & ", " _
                            & notes & " , " & ESTAT & ")" &
                            " VALUES(@id,@nom,@direccio,@poblacio,@codiPostal,@idPais,@idProvincia,@notes,@estat)", DBCONNECT.getConnection)
        sc.Parameters.Add("@id", SqlDbType.Int).Value = obj.id
        sc.Parameters.Add("@nom", SqlDbType.VarChar).Value = obj.nom
        sc.Parameters.Add("@direccio", SqlDbType.VarChar).Value = obj.direccio
        sc.Parameters.Add("@poblacio", SqlDbType.VarChar).Value = obj.poblacio
        sc.Parameters.Add("@codiPostal", SqlDbType.VarChar).Value = obj.codiPostal
        sc.Parameters.Add("@idPais", SqlDbType.Int).Value = obj.pais.id
        sc.Parameters.Add("@idProvincia", SqlDbType.Int).Value = obj.provincia.id
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
    Private Function removeSql(obj As LlocEntrega) As Boolean
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
    Private Function getObjectsSql() As List(Of LlocEntrega)
        Dim sc As SqlCommand, sdr As SqlDataReader, pr As LlocEntrega
        getObjectsSql = New List(Of LlocEntrega)
        auxiliarProv = New ModelAuxiliar(DBCONNECT.getTaulaProvincia)
        auxiliarPais = New ModelAuxiliar(DBCONNECT.getTaulaProvincia)
        sc = New SqlCommand("SELECT * FROM " & getTable(), getConnection)
        sdr = sc.ExecuteReader
        While sdr.Read()
            pr = New LlocEntrega(sdr(ID),
                               CONFIG.validarNull(Trim(sdr(NOM))))
            pr.direccio = CONFIG.validarNull(sdr(DIRECCIO))
            pr.poblacio = CONFIG.validarNull(sdr(POBLACIO))
            pr.codiPostal = CONFIG.validarNull(sdr(CODI_POSTAL))
            pr.pais = ModelPais.getAuxiliar.getObject(sdr(ID_PAIS))
            pr.provincia = ModelProvincia.getAuxiliar.getObject(sdr(ID_PROVINCIA))
            pr.notes = CONFIG.validarNull(sdr(notes))
            'todo falta posar els LlocEntregas projecte
            pr.estat = sdr(ESTAT)
            getObjectsSql.Add(pr)
        End While
        sdr.Close()
        getObjectsSql.Sort()
        sdr = Nothing
        sc = Nothing
    End Function
    Private Function updateDBF(obj As LlocEntrega) As Integer
        Dim sc As ADODB.Command
        sc = New ADODB.Command
        With sc
            .ActiveConnection = DBCONNECT.getConnectionDbf
            .CommandText = "UPDATE " & getTable() & " " &
                                " Set " & NOM & "=?," &
                                          DIRECCIO & " =?, " &
                                          POBLACIO & " =?, " &
                                          CODI_POSTAL & " =?, " &
                                          ID_PAIS & " =?, " &
                                          ID_PROVINCIA & " =?, " &
                                          notes & " =?, " &
                                          ESTAT & " =? " &
                                " WHERE " & ID & "=?"
            .Parameters.Append(ADOPARAM.ToString(obj.nom))
            .Parameters.Append(ADOPARAM.ToString(obj.direccio))
            .Parameters.Append(ADOPARAM.ToString(obj.poblacio))
            .Parameters.Append(ADOPARAM.ToString(obj.codiPostal))
            .Parameters.Append(ADOPARAM.ToInt(obj.pais.id))
            .Parameters.Append(ADOPARAM.ToInt(obj.provincia.id))
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
    Private Function insertDBF(obj As LlocEntrega) As Integer
        Dim sc As ADODB.Command
        sc = New ADODB.Command
        obj.id = DBCONNECT.getMaxIdDBF(getTable) + 1
        With sc
            .ActiveConnection = DBCONNECT.getConnectionDbf
            .CommandText = " INSERT INTO " & getTable() & " " &
                            " (" & ID & "," & NOM & "," & DIRECCIO & ", " _
                            & POBLACIO & ", " & CODI_POSTAL & ", " _
                            & ID_PAIS & ", " & ID_PROVINCIA & ", " _
                            & notes & " , " & ESTAT & ")" &
                            " VALUES(?,?,?,?,?,?,?,?,?)"
            .Parameters.Append(ADOPARAM.ToInt(obj.id))
            .Parameters.Append(ADOPARAM.ToString(obj.nom))
            .Parameters.Append(ADOPARAM.ToString(obj.direccio))
            .Parameters.Append(ADOPARAM.ToString(obj.poblacio))
            .Parameters.Append(ADOPARAM.ToString(obj.codiPostal))
            .Parameters.Append(ADOPARAM.ToInt(obj.pais.id))
            .Parameters.Append(ADOPARAM.ToInt(obj.provincia.id))
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
    Private Function removeDBF(obj As LlocEntrega) As Boolean
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
    Private Function getObjectsDBF() As List(Of LlocEntrega)
        Dim rc As ADODB.Recordset, pc As LlocEntrega

        rc = New ADODB.Recordset
        getObjectsDBF = New List(Of LlocEntrega)
        rc.Open("SELECT * FROM " & getTable(), DBCONNECT.getConnectionDbf)
        While Not rc.EOF
            pc = New LlocEntrega(rc(ID).Value,
                               CONFIG.validarNull(Trim(rc(NOM).Value)))
            pc.direccio = CONFIG.validarNull(rc(DIRECCIO).Value)
            pc.poblacio = CONFIG.validarNull(rc(POBLACIO).Value)
            pc.codiPostal = CONFIG.validarNull(rc(CODI_POSTAL).Value)
            pc.pais = ModelPais.getAuxiliar.getObject(rc(ID_PAIS).Value)
            pc.provincia = ModelProvincia.getAuxiliar.getObject(rc(ID_PROVINCIA).Value)
            pc.notes = CONFIG.validarNull(rc(notes).Value)
            pc.estat = rc(ESTAT).Value
            getObjectsDBF.Add(pc)
            rc.MoveNext()
        End While
        If rc.State = 1 Then rc.Close()
        rc = Nothing
        getObjectsDBF.Sort()
    End Function
    Private Function getTable() As String
        Return DBCONNECT.getTaulaLlocEntrega
    End Function
End Module
