Option Explicit On
Imports System.Data.SqlClient
Module dbProveidor
    Private Const ID As String = "ID"
    Private Const NOM As String = "nomC"
    Private Const CIF As String = "CIF"
    Private Const NOM_FISCAL As String = "nomF"
    Private Const DIRECCIO As String = "dirF"
    Private Const POBLACIO As String = "poblacio"
    Private Const CODI_POSTAL As String = "cp"
    Private Const DATA_ALTA As String = "dataIn"
    Private Const ACTIU As String = "estat"
    Private Const ID_PAIS As String = "idPais"
    Private Const ID_PROVINCIA As String = "idProv"
    Private Const ID_TIPUS_PAGAMENT As String = "idPag"
    Private Const IBAN1 As String = "iban1"
    Private Const IBAN2 As String = "iban2"
    Private Const IBAN3 As String = "iban3"
    Private Const EMAIL As String = "email"
    Private Const CODI_COMPTABLE As String = "CCOMPT"

    Public Function update(obj As Proveidor) As Integer
        If IS_SQLSERVER Then Return updateSQL(obj)
        Return updateDBF(obj)
    End Function
    Public Function insert(obj As Proveidor) As Integer
        If IS_SQLSERVER Then Return insertSQL(obj)
        Return insertDBF(obj)
    End Function
    Public Function remove(obj As Proveidor) As Boolean
        If IS_SQLSERVER Then Return removeSQL(obj)
        Return removeDBF(obj)
    End Function
    Public Function getObjects() As List(Of Proveidor)
        If IS_SQLSERVER Then Return getObjectsSQL()
        Return getObjectsDBF()
    End Function


    Private Function updateSQL(obj As Proveidor) As Integer
        Dim sc As SqlCommand, i As Integer
        sc = New SqlCommand("UPDATE " & getTable() & " " &
                                " SET " & NOM & "=@nom," &
                                          CIF & " =@cif, " &
                                          NOM_FISCAL & " =@nomFiscal, " &
                                          DIRECCIO & " =@direccio, " &
                                          POBLACIO & " =@poblacio, " &
                                          CODI_POSTAL & " =@codiPostal, " &
                                          ID_PAIS & " =@idPais, " &
                                          ID_PROVINCIA & " =@idProvincia, " &
                                          ID_TIPUS_PAGAMENT & " =@idTipusPagament, " &
                                          IBAN1 & " =@iban1, " &
                                          IBAN2 & " =@iban2, " &
                                          IBAN3 & " =@iban3, " &
                                          EMAIL & " =@email, " &
                                          ACTIU & " =@actiu, " &
                                          CODI_COMPTABLE & "=@codiComptable " &
                                " WHERE " & ID & "=@id", DBCONNECT.getConnection)


        sc.Parameters.Add("@id", SqlDbType.Int).Value = obj.id
        sc.Parameters.Add("@nom", SqlDbType.VarChar).Value = obj.nom
        sc.Parameters.Add("@cif", SqlDbType.VarChar).Value = obj.codi
        sc.Parameters.Add("@nomFiscal", SqlDbType.VarChar).Value = obj.nomFiscal
        sc.Parameters.Add("@direccio", SqlDbType.VarChar).Value = obj.direccio
        sc.Parameters.Add("@poblacio", SqlDbType.VarChar).Value = obj.poblacio
        sc.Parameters.Add("@codiPostal", SqlDbType.VarChar).Value = obj.codiPostal

        sc.Parameters.Add("@idPais", SqlDbType.Int).Value = obj.pais.id


        sc.Parameters.Add("@idProvincia", SqlDbType.Int).Value = obj.provincia.id


        sc.Parameters.Add("@idTipusPagament", SqlDbType.Int).Value = obj.tipusPagament.id


        sc.Parameters.Add("@iban1", SqlDbType.VarChar).Value = obj.iban1
        sc.Parameters.Add("@iban2", SqlDbType.VarChar).Value = obj.iban2
        sc.Parameters.Add("@iban3", SqlDbType.VarChar).Value = obj.iban3
        sc.Parameters.Add("@email", SqlDbType.VarChar).Value = obj.email
        sc.Parameters.Add("@actiu", SqlDbType.Bit).Value = obj.actiu
        sc.Parameters.Add("@codiComptable", SqlDbType.VarChar).Value = obj.codiComptable
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
    Private Function insertSQL(obj As Proveidor) As Integer
        Dim sc As SqlCommand, i As Integer
        obj.id = DBCONNECT.getMaxId(getTable) + 1
        sc = New SqlCommand(" INSERT INTO " & getTable() & " " &
                            " (" & ID & ", " & CIF & ", " & NOM_FISCAL & ", " & NOM & ", " & DIRECCIO & ", " _
                            & POBLACIO & ", " & CODI_POSTAL & ", " _
                            & DATA_ALTA & ", " & ID_PAIS & ", " & ID_PROVINCIA & ", " & ID_TIPUS_PAGAMENT & ", " _
                            & IBAN1 & ", " & IBAN2 & ", " & IBAN3 & ", " & EMAIL & "," & ACTIU & "," & CODI_COMPTABLE & ")" &
                            " VALUES(@id,@cif,@nomFiscal,@nom,@direccio,@poblacio,@codiPostal,@dataAlta,@idPais,@idProvincia,@idTipusPagament,@iban1,@iban2,@iban3,@email,@actiu,@codiComptable)", DBCONNECT.getConnection)

        sc.Parameters.Add("@id", SqlDbType.Int).Value = obj.id
        sc.Parameters.Add("@nom", SqlDbType.VarChar).Value = obj.nom
        sc.Parameters.Add("@cif", SqlDbType.VarChar).Value = obj.codi
        sc.Parameters.Add("@nomFiscal", SqlDbType.VarChar).Value = obj.nomFiscal
        sc.Parameters.Add("@direccio", SqlDbType.VarChar).Value = obj.direccio
        sc.Parameters.Add("@poblacio", SqlDbType.VarChar).Value = obj.poblacio
        sc.Parameters.Add("@codiPostal", SqlDbType.VarChar).Value = obj.codiPostal
        sc.Parameters.Add("@dataAlta", SqlDbType.Date).Value = Now
        sc.Parameters.Add("@idPais", SqlDbType.Int).Value = obj.pais.id


        sc.Parameters.Add("@idProvincia", SqlDbType.Int).Value = obj.provincia.id


        sc.Parameters.Add("@idTipusPagament", SqlDbType.Int).Value = obj.tipusPagament.id


        sc.Parameters.Add("@iban1", SqlDbType.VarChar).Value = obj.iban1
        sc.Parameters.Add("@iban2", SqlDbType.VarChar).Value = obj.iban2
        sc.Parameters.Add("@iban3", SqlDbType.VarChar).Value = obj.iban3
        sc.Parameters.Add("@email", SqlDbType.VarChar).Value = obj.email
        sc.Parameters.Add("@actiu", SqlDbType.Bit).Value = obj.actiu
        sc.Parameters.Add("@codiComptable", SqlDbType.VarChar).Value = obj.codiComptable
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
    Private Function removeSQL(obj As Proveidor) As Boolean
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
    Private Function getObjectsSQL() As List(Of Proveidor)
        Dim sc As SqlCommand, sdr As SqlDataReader, pr As Proveidor
        getObjectsSQL = New List(Of Proveidor)
        sc = New SqlCommand("SELECT * FROM " & getTable(), getConnection)
        sdr = sc.ExecuteReader
        While sdr.Read()
            pr = New Proveidor(sdr(ID),
                               CONFIG.validarNull((sdr(CIF))),
                               CONFIG.validarNull((sdr(NOM))),
                               CONFIG.validarNull((sdr(NOM_FISCAL))),
                               CONFIG.validarNull((sdr(DIRECCIO))),
                               CONFIG.validarNull((sdr(POBLACIO))))
            pr.pais = ModelPais.getAuxiliar.getObject(sdr(ID_PAIS))
            pr.provincia = ModelProvincia.getAuxiliar.getObject(sdr(ID_PROVINCIA))
            pr.tipusPagament = ModelTipusPagament.getAuxiliar.getObject(sdr(ID_TIPUS_PAGAMENT))
            pr.iban1 = CONFIG.validarNull(sdr(IBAN1))
            pr.iban2 = CONFIG.validarNull(sdr(IBAN2))
            pr.iban3 = CONFIG.validarNull(sdr(IBAN3))
            pr.email = CONFIG.validarNull(sdr(EMAIL))
            pr.contactes = ModelProveidorContacte.getObjects(pr.id)
            pr.anotacions = ModelProveidorAnotacio.getObjects(pr.id)
            pr.codiComptable = CONFIG.validarNull(sdr(CODI_COMPTABLE))
            getObjectsSQL.Add(pr)
        End While
        sdr.Close()
        getObjectsSQL.Sort()
        sdr = Nothing
        sc = Nothing
    End Function


    Private Function updateDBF(obj As Proveidor) As Integer
        Dim sc As ADODB.Command
        sc = New ADODB.Command
        With sc
            .ActiveConnection = DBCONNECT.getConnectionDbf
            .CommandText = "UPDATE " & getTable() & " " &
                                " SET " & NOM & "=?," &
                                          CIF & " =?, " &
                                          NOM_FISCAL & " =?, " &
                                          DIRECCIO & " =?, " &
                                          POBLACIO & " =?, " &
                                          CODI_POSTAL & " =?, " &
                                          ID_PAIS & " =?, " &
                                          ID_PROVINCIA & " =?, " &
                                          ID_TIPUS_PAGAMENT & " =?, " &
                                          IBAN1 & " =?, " &
                                          IBAN2 & " =?, " &
                                          IBAN3 & " =?, " &
                                          EMAIL & " =?, " &
                                          ACTIU & " =?, " &
                                          CODI_COMPTABLE & " =? " &
                                " WHERE " & ID & "=?"
            .Parameters.Append(ADOPARAM.ToString(obj.nom))
            .Parameters.Append(ADOPARAM.ToString(obj.codi))
            .Parameters.Append(ADOPARAM.ToString(obj.nomFiscal))
            .Parameters.Append(ADOPARAM.ToString(obj.direccio))
            .Parameters.Append(ADOPARAM.ToString(obj.poblacio))
            .Parameters.Append(ADOPARAM.ToString(obj.codiPostal))
            .Parameters.Append(ADOPARAM.ToInt(obj.pais.id))
            .Parameters.Append(ADOPARAM.ToInt(obj.provincia.id))
            .Parameters.Append(ADOPARAM.ToInt(obj.tipusPagament.id))
            .Parameters.Append(ADOPARAM.ToString(obj.iban1))
            .Parameters.Append(ADOPARAM.ToString(obj.iban2))
            .Parameters.Append(ADOPARAM.ToString(obj.iban3))
            .Parameters.Append(ADOPARAM.ToString(obj.email))
            .Parameters.Append(ADOPARAM.toBool(obj.actiu))
            .Parameters.Append(ADOPARAM.ToString(obj.codiComptable))
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
    Private Function insertDBF(obj As Proveidor) As Integer
        Dim sc As ADODB.Command
        sc = New ADODB.Command
        obj.id = DBCONNECT.getMaxIdDBF(getTable) + 1
        With sc
            .ActiveConnection = DBCONNECT.getConnectionDbf
            .CommandText = " INSERT INTO " & getTable() & " " &
                            " (" & ID & ", " & CIF & ", " & NOM_FISCAL & ", " & NOM & ", " & DIRECCIO & ", " _
                            & POBLACIO & ", " & CODI_POSTAL & ", " _
                            & DATA_ALTA & ", " & ID_PAIS & ", " & ID_PROVINCIA & ", " & ID_TIPUS_PAGAMENT & ", " _
                            & IBAN1 & ", " & IBAN2 & ", " & IBAN3 & ", " & EMAIL & "," & ACTIU & "," & CODI_COMPTABLE & ")" &
                            " VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)"

            .Parameters.Append(ADOPARAM.ToInt(obj.id))
            .Parameters.Append(ADOPARAM.ToString(obj.codi))
            .Parameters.Append(ADOPARAM.ToString(obj.nom))
            .Parameters.Append(ADOPARAM.ToString(obj.nomFiscal))
            .Parameters.Append(ADOPARAM.ToString(obj.direccio))
            .Parameters.Append(ADOPARAM.ToString(obj.poblacio))
            .Parameters.Append(ADOPARAM.ToString(obj.codiPostal))
            .Parameters.Append(ADOPARAM.ToDate(Now))
            .Parameters.Append(ADOPARAM.ToInt(obj.pais.id))
            .Parameters.Append(ADOPARAM.ToInt(obj.provincia.id))
            .Parameters.Append(ADOPARAM.ToInt(obj.tipusPagament.id))
            .Parameters.Append(ADOPARAM.ToString(obj.iban1))
            .Parameters.Append(ADOPARAM.ToString(obj.iban2))
            .Parameters.Append(ADOPARAM.ToString(obj.iban3))
            .Parameters.Append(ADOPARAM.ToString(obj.email))
            .Parameters.Append(ADOPARAM.toBool(obj.actiu))
            .Parameters.Append(ADOPARAM.ToString(obj.codiComptable))
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
    Private Function removeDBF(obj As Proveidor) As Boolean
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
    Private Function getObjectsDBF() As List(Of Proveidor)
        Dim rc As ADODB.Recordset, p As Proveidor
        rc = New ADODB.Recordset
        getObjectsDBF = New List(Of Proveidor)
        rc.Open("SELECT * FROM " & getTable(), DBCONNECT.getConnectionDbf)
        While Not rc.EOF
            p = New Proveidor(rc(ID).Value,
                               (CONFIG.validarNull(rc(CIF).Value)),
                               (CONFIG.validarNull(rc(NOM).Value)),
                               (CONFIG.validarNull(rc(NOM_FISCAL).Value)),
                               (CONFIG.validarNull(rc(DIRECCIO).Value)),
                               (CONFIG.validarNull(rc(POBLACIO).Value)))
            p.codiComptable = (CONFIG.validarNull(rc(CODI_COMPTABLE).Value))
            p.pais = ModelPais.getAuxiliar.getObject(rc(ID_PAIS).Value)
            p.provincia = ModelProvincia.getAuxiliar.getObject(rc(ID_PROVINCIA).Value)
            p.tipusPagament = ModelTipusPagament.getAuxiliar.getObject(rc(ID_TIPUS_PAGAMENT).Value)
            p.iban1 = (CONFIG.validarNull(rc(IBAN1).Value))
            p.iban2 = (CONFIG.validarNull(rc(IBAN2).Value))
            p.iban3 = (CONFIG.validarNull(rc(IBAN3).Value))
            p.email = (CONFIG.validarNull(rc(EMAIL).Value))
            p.contactes = ModelProveidorContacte.getObjects(rc(ID).Value)
            p.anotacions = ModelProveidorAnotacio.getObjects(
                rc(ID).Value)

            getObjectsDBF.Add(p)
            rc.MoveNext()
        End While
        If rc.State = 1 Then rc.Close()
        rc = Nothing
        getObjectsDBF.Sort()
    End Function
    Private Function getTable() As String
        Return DBCONNECT.getTaulaProveidor
    End Function
End Module
