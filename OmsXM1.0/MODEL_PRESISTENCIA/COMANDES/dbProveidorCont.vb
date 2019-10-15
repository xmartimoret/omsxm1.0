Option Explicit On
Imports System.Data.SqlClient
Module dbProveidorCont
    Private Const ID As String = "ID"
    Private Const ID_PROVEIDOR As String = "idProv"
    Private Const DEPARTAMENT As String = "Departa"
    Private Const NOM As String = "contacte"
    Private Const DIRECCIO As String = "direccio"
    Private Const POBLACIO As String = "poblacio"
    Private Const CODI_POSTAL As String = "CP"
    Private Const ACTIU As String = "actiu"
    Private Const ID_PAIS As String = "idPais"
    Private Const ID_PROVINCIA As String = "idProvi"
    Private Const TELEFON_1 As String = "tel1"
    Private Const TELEFON_2 As String = "tel2"
    Private Const NOTES As String = "notes"
    Private Const ADRESSA_ELECTRONICA As String = "email"
    'ACCESSORS CENTRE
    ''' <summary>
    ''' SAVE. Guarda un centre a la base de dades. 
    ''' Si es nou, fa una inserció si no  actualitza.
    ''' </summary>
    ''' <param name="obj"> centre</param>
    ''' <returns>identificador del centre.</returns>
    Public Function update(obj As ProveidorCont) As Integer
        If IS_SQLSERVER Then Return updateSQL(obj)
        Return updatedbf(obj)
    End Function
    Public Function insert(obj As ProveidorCont) As Integer
        If IS_SQLSERVER Then Return insertSQL(obj)
        Return insertDBF(obj)
    End Function
    Public Function remove(obj As ProveidorCont) As Boolean
        If IS_SQLSERVER Then Return removeSQL(obj)
        Return removeDBF(obj)
    End Function
    Public Function removePare(idProveidor As Integer) As Boolean
        If IS_SQLSERVER Then Return removePareSQL(idProveidor)
        Return removePareDBF(idProveidor)
    End Function
    Public Function getObjects() As List(Of ProveidorCont)
        If IS_SQLSERVER Then Return getObjectsSQL()
        Return getObjectsDBF()
    End Function
    Private Function updateSQL(obj As ProveidorCont) As Integer
        Dim sc As SqlCommand, i As Integer
        sc = New SqlCommand("UPDATE " & getTable() & " " &
                                    " SET " & ID_PROVEIDOR & "=@idProveidor," &
                                                DEPARTAMENT & "=@departament," &
                                                NOM & "=@nom," &
                                              DIRECCIO & " =@direccio, " &
                                              POBLACIO & " =@poblacio, " &
                                              CODI_POSTAL & " =@codiPostal, " &
                                              ID_PAIS & " =@idPais, " &
                                              ID_PROVINCIA & " =@idProvincia, " &
                                              TELEFON_1 & " =@telefon1, " &
                                              TELEFON_2 & " =@telefon2,  " &
                                              NOTES & " =@notes, " &
                                              ADRESSA_ELECTRONICA & " =@email, " &
                                              ACTIU & " =@actiu " &
                                    " WHERE " & ID & "=@id", DBCONNECT.getConnection)


        sc.Parameters.Add("@id", SqlDbType.Int).Value = obj.id
        sc.Parameters.Add("@idProveidor", SqlDbType.Int).Value = obj.idProveidor
        sc.Parameters.Add("@departament", SqlDbType.VarChar).Value = obj.departament
        sc.Parameters.Add("@nom", SqlDbType.VarChar).Value = obj.nom
        sc.Parameters.Add("@direccio", SqlDbType.VarChar).Value = obj.direccio
        sc.Parameters.Add("@poblacio", SqlDbType.VarChar).Value = obj.poblacio
        sc.Parameters.Add("@codiPostal", SqlDbType.VarChar).Value = obj.codiPostal

        sc.Parameters.Add("@idPais", SqlDbType.Int).Value = obj.pais.id


        sc.Parameters.Add("@idProvincia", SqlDbType.Int).Value = obj.provincia.id

        sc.Parameters.Add("@telefon1", SqlDbType.VarChar).Value = obj.telefon1
        sc.Parameters.Add("@telefon2", SqlDbType.VarChar).Value = obj.telefon2
        sc.Parameters.Add("@notes", SqlDbType.VarChar).Value = obj.notes
        sc.Parameters.Add("@actiu", SqlDbType.Bit).Value = obj.actiu
        sc.Parameters.Add("@email", SqlDbType.VarChar).Value = obj.email
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
    Private Function insertSQL(obj As ProveidorCont) As Integer
        Dim sc As SqlCommand, i As Integer
        obj.id = DBCONNECT.getMaxId(getTable) + 1
        sc = New SqlCommand(" INSERT INTO " & getTable() & " " &
                                " (" & ID & ", " & ID_PROVEIDOR & "," & DEPARTAMENT & "," & NOM & "," & DIRECCIO & ", " _
                                & POBLACIO & ", " & CODI_POSTAL & ", " _
                                & ID_PAIS & ", " & ID_PROVINCIA & ", " _
                                & TELEFON_1 & ", " & TELEFON_2 & ", " & NOTES & ", " & ADRESSA_ELECTRONICA & " , " & ACTIU & ")" &
                                " VALUES(@id,@idProveidor,@departament,@nom,@direccio,@poblacio,@codiPostal,@idPais,@idProvincia,@telefon1,@telefon2,@notes,@email,@actiu)", DBCONNECT.getConnection)

        sc.Parameters.Add("@id", SqlDbType.Int).Value = obj.id
        sc.Parameters.Add("@idProveidor", SqlDbType.Int).Value = obj.idProveidor
        sc.Parameters.Add("@departament", SqlDbType.VarChar).Value = obj.departament
        sc.Parameters.Add("@nom", SqlDbType.VarChar).Value = obj.nom
        sc.Parameters.Add("@direccio", SqlDbType.VarChar).Value = obj.direccio
        sc.Parameters.Add("@poblacio", SqlDbType.VarChar).Value = obj.poblacio
        sc.Parameters.Add("@codiPostal", SqlDbType.VarChar).Value = obj.codiPostal
        sc.Parameters.Add("@idPais", SqlDbType.Int).Value = obj.pais.id
        sc.Parameters.Add("@idProvincia", SqlDbType.Int).Value = obj.provincia.id
        sc.Parameters.Add("@telefon1", SqlDbType.VarChar).Value = obj.telefon1
        sc.Parameters.Add("@telefon2", SqlDbType.VarChar).Value = obj.telefon2
        sc.Parameters.Add("@notes", SqlDbType.VarChar).Value = obj.notes
        sc.Parameters.Add("@actiu", SqlDbType.Bit).Value = obj.actiu
        sc.Parameters.Add("@email", SqlDbType.VarChar).Value = obj.email
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
    Private Function removeSQL(obj As ProveidorCont) As Boolean
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
    Private Function removePareSQL(idProveidor As String) As Boolean
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
    Private Function getObjectsSQL() As List(Of ProveidorCont)
        Dim sc As SqlCommand, sdr As SqlDataReader, pr As ProveidorCont
        getObjectsSQL = New List(Of ProveidorCont)
        sc = New SqlCommand("SELECT * FROM " & getTable(), getConnection)
        sdr = sc.ExecuteReader
        While sdr.Read()
            pr = New ProveidorCont(sdr(ID),
                                   CONFIG.validarNull(Trim(sdr(ID_PROVEIDOR))),
                                   Trim(CONFIG.validarNull(sdr(DEPARTAMENT))),
                                   Trim(CONFIG.validarNull(sdr(NOM))),
                                   Trim(CONFIG.validarNull(sdr(DIRECCIO))),
                                   Trim(CONFIG.validarNull(sdr(POBLACIO))),
                                   Trim(CONFIG.validarNull(sdr(CODI_POSTAL))))

            pr.pais = ModelPais.getAuxiliar.getObject(sdr(ID_PAIS))
            pr.provincia = ModelProvincia.getAuxiliar.getObject(sdr(ID_PROVINCIA))
            pr.telefon1 = CONFIG.validarNull(sdr(TELEFON_1))
            pr.telefon2 = CONFIG.validarNull(sdr(TELEFON_2))
            pr.notes = CONFIG.validarNull(sdr(NOTES))
            pr.email = CONFIG.validarNull(sdr(ADRESSA_ELECTRONICA))
            pr.actiu = sdr(ACTIU)
            getObjectsSQL.Add(pr)
        End While
        sdr.Close()
        getObjectsSQL.Sort()
        sdr = Nothing
        sc = Nothing
    End Function
    Private Function updatedbf(obj As ProveidorCont) As Integer
        Dim sc As ADODB.Command
        sc = New ADODB.Command
        With sc
            .ActiveConnection = DBCONNECT.getConnectionDbf
            .CommandText = "UPDATE " & getTable() & " " &
                                    " SET " & ID_PROVEIDOR & "=?," &
                                                DEPARTAMENT & "=?," &
                                                NOM & "=?," &
                                              DIRECCIO & "=?," &
                                              POBLACIO & "=?," &
                                              CODI_POSTAL & "=?," &
                                              ID_PAIS & "=?," &
                                              ID_PROVINCIA & "=?," &
                                              TELEFON_1 & "=?," &
                                              TELEFON_2 & "=?," &
                                              NOTES & "=?," &
                                              ADRESSA_ELECTRONICA & "=?," &
                                              ACTIU & "=?" &
                                    " WHERE " & ID & "=? "

            .Parameters.Append(ADOPARAM.ToInt(obj.idProveidor))
            .Parameters.Append(ADOPARAM.ToString(obj.departament))
            .Parameters.Append(ADOPARAM.ToString(obj.nom))
            .Parameters.Append(ADOPARAM.ToString(obj.direccio))
            .Parameters.Append(ADOPARAM.ToString(obj.poblacio))
            .Parameters.Append(ADOPARAM.ToString(obj.codiPostal))
            .Parameters.Append(ADOPARAM.ToInt(obj.pais.id))
            .Parameters.Append(ADOPARAM.ToInt(obj.provincia.id))
            .Parameters.Append(ADOPARAM.ToString(obj.telefon1))
            .Parameters.Append(ADOPARAM.ToString(obj.telefon2))
            .Parameters.Append(ADOPARAM.ToString(obj.notes))
            .Parameters.Append(ADOPARAM.ToString(obj.email))
            .Parameters.Append(ADOPARAM.toBool(obj.actiu))
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
    Private Function insertDBF(obj As ProveidorCont) As Integer
        Dim sc As ADODB.Command
        sc = New ADODB.Command
        obj.id = DBCONNECT.getMaxIdDBF(getTable) + 1
        With sc
            .ActiveConnection = DBCONNECT.getConnectionDbf
            .CommandText = " INSERT INTO " & getTable() & " " &
                                " (" & ID & ", " & ID_PROVEIDOR & "," & DEPARTAMENT & "," & NOM & "," & DIRECCIO & ", " _
                                & POBLACIO & ", " & CODI_POSTAL & ", " _
                                & ID_PAIS & ", " & ID_PROVINCIA & ", " _
                                & TELEFON_1 & ", " & TELEFON_2 & ", " & NOTES & ", " & ADRESSA_ELECTRONICA & " , " & ACTIU & ")" &
                                " VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?)"

            .Parameters.Append(ADOPARAM.ToInt(obj.id))
            .Parameters.Append(ADOPARAM.ToInt(obj.idProveidor))
            .Parameters.Append(ADOPARAM.ToString(obj.departament))
            .Parameters.Append(ADOPARAM.ToString(obj.nom))
            .Parameters.Append(ADOPARAM.ToString(obj.direccio))
            .Parameters.Append(ADOPARAM.ToString(obj.poblacio))
            .Parameters.Append(ADOPARAM.ToString(obj.codiPostal))
            .Parameters.Append(ADOPARAM.ToInt(obj.pais.id))
            .Parameters.Append(ADOPARAM.ToInt(obj.provincia.id))
            .Parameters.Append(ADOPARAM.ToString(obj.telefon1))
            .Parameters.Append(ADOPARAM.ToString(obj.telefon2))
            .Parameters.Append(ADOPARAM.ToString(obj.notes))
            .Parameters.Append(ADOPARAM.ToString(obj.email))
            .Parameters.Append(ADOPARAM.toBool(obj.actiu))

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
    Private Function removeDBF(obj As ProveidorCont) As Boolean
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
    Private Function getObjectsDBF() As List(Of ProveidorCont)
        Dim rc As ADODB.Recordset, pc As ProveidorCont

        rc = New ADODB.Recordset
        getObjectsDBF = New List(Of ProveidorCont)
        rc.Open("SELECT * FROM " & getTable(), DBCONNECT.getConnectionDbf)
        While Not rc.EOF
            pc = New ProveidorCont(rc(ID).Value,
                                   CONFIG.validarNull(rc(ID_PROVEIDOR).Value),
                                   Trim(CONFIG.validarNull(rc(DEPARTAMENT).Value)),
                                   Trim(CONFIG.validarNull(rc(NOM).Value)),
                                   Trim(CONFIG.validarNull(rc(DIRECCIO).Value)),
                                   Trim(CONFIG.validarNull(rc(POBLACIO).Value)),
                                   Trim(CONFIG.validarNull(rc(CODI_POSTAL).Value)))

            pc.pais = ModelPais.getAuxiliar.getObject(rc(ID_PAIS).Value)
            pc.provincia = ModelProvincia.getAuxiliar.getObject(rc(ID_PROVINCIA).Value)
            pc.telefon1 = CONFIG.validarNull(rc(TELEFON_1).Value)
            pc.telefon2 = CONFIG.validarNull(rc(TELEFON_2).Value)
            pc.notes = CONFIG.validarNull(rc(NOTES).Value)
            pc.email = CONFIG.validarNull(rc(ADRESSA_ELECTRONICA).Value)
            pc.actiu = rc(ACTIU).Value
            getObjectsDBF.Add(pc)
            rc.MoveNext()
        End While
        If rc.State = 1 Then rc.Close()
        rc = Nothing
        getObjectsDBF.Sort()

    End Function
    Private Function getTable() As String
        Return DBCONNECT.getTaulaProveidorContacte
    End Function
End Module
