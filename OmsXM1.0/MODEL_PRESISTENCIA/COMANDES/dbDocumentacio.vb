Imports System.Data.SqlClient
Module dbDocumentacio
    Private Const ID As String = "ID"
    Private Const ID_PROVEIDOR As String = "IDPROV"
    Private Const CODI As String = "CODI"
    Private Const NOM As String = "NOM"
    Private Const ID_SOLICITUT As String = "IDSE"
    Private Const ID_COMANDA_EDICIO As String = "IDCE"
    Private Const ID_COMANDA As String = "IDC"
    Private Const ANYO As String = "ANYO"
    Private Const DATA As String = "DATA"
    'ACCESSORS CENTRE
    ''' <summary>
    ''' SAVE. Guarda un centre a la base de dades. 
    ''' Si es nou, fa una inserció si no  actualitza.
    ''' </summary>
    ''' <param name="obj"> centre</param>
    ''' <returns>identificador del centre.</returns>
    Public Function update(obj As doc) As Integer
        If IS_SQLSERVER() Then Return updateSQL(obj)
        Return updateDBF(obj)
    End Function
    Public Function insert(obj As doc) As Integer
        If IS_SQLSERVER() Then Return insertSQL(obj)
        Return insertDBF(obj)
    End Function
    Public Function remove(obj As doc) As Boolean
        If IS_SQLSERVER() Then Return removeSQL(obj)
        Return removeDBF(obj)
    End Function
    Public Function getObjects(a As Integer) As List(Of doc)
        If IS_SQLSERVER() Then Return getObjectsSQL(a)
        Return getObjectsDBF(a)
    End Function
    Private Function updateSQL(obj As doc) As Integer
        'Dim sc As SqlCommand, i As Integer
        'sc = New SqlCommand("UPDATE " & getTable() & " " &
        '                        " SET " & CODI & "=@codi," &
        '                                  NOM & " =@nom, " &
        '                                  NOTES & " =@notes, " &
        '                                  ID_FAMILIA & " =@IdFamilia, " &
        '                                  ID_UNITAT & " =@idUnitat, " &
        '                                  ID_FABRICANT & " =@idFabricant, " &
        '                                  ID_IVA & " =@idIva " &
        '                                  " WHERE " & ID & "=@id", DBCONNECT.getConnection)
        'sc.Parameters.Add("@id", SqlDbType.Int).Value = obj.id
        'sc.Parameters.Add("@codi", SqlDbType.VarChar).Value = obj.codi
        'sc.Parameters.Add("@nom", SqlDbType.VarChar).Value = obj.nom
        'sc.Parameters.Add("@notes", SqlDbType.VarChar).Value = obj.notes
        'sc.Parameters.Add("@idFamilia", SqlDbType.Int).Value = obj.familia.id
        'sc.Parameters.Add("@idUnitat", SqlDbType.Int).Value = obj.unitat.id
        'sc.Parameters.Add("@idFabricant", SqlDbType.Int).Value = obj.fabricant.id
        'sc.Parameters.Add("@idIva", SqlDbType.Int).Value = obj.iva.id
        'i = sc.ExecuteNonQuery
        'sc = Nothing
        'If i >= 1 Then
        '    Return obj.id
        'End If
        Return -1
    End Function
    'ACCESSORS CENTRE
    ''' <summary>
    ''' SAVE. Guarda un centre a la base de dades. 
    ''' Si es nou, fa una inserció si no  actualitza.
    ''' </summary>
    ''' <param name="obj"> centre</param>
    ''' <returns>identificador del centre.</returns>
    Private Function insertSQL(obj As doc) As Integer
        'Dim sc As SqlCommand, i As Integer
        'obj.id = DBCONNECT.getMaxId(getTable) + 1
        'sc = New SqlCommand(" INSERT INTO " & getTable() & " " &
        '                    " (" & ID & ", " & CODI & ", " & NOM & ", " & NOTES & ", " & ID_FAMILIA & ", " & ID_FABRICANT & ", " & ID_UNITAT & ", " & ID_IVA & ")" &
        '                    " VALUES(@id,@codi,@nom,@notes,@idFamilia,@idFabricant,@idUnitat,@idIva)", DBCONNECT.getConnection)
        'sc.Parameters.Add("@id", SqlDbType.Int).Value = obj.id
        'sc.Parameters.Add("@codi", SqlDbType.VarChar).Value = obj.codi
        'sc.Parameters.Add("@nom", SqlDbType.VarChar).Value = obj.nom
        'sc.Parameters.Add("@notes", SqlDbType.VarChar).Value = obj.notes
        'sc.Parameters.Add("@idFamilia", SqlDbType.Int).Value = obj.familia.id
        'sc.Parameters.Add("@idUnitat", SqlDbType.Int).Value = obj.unitat.id
        'sc.Parameters.Add("@idFabricant", SqlDbType.Int).Value = obj.fabricant.id
        'sc.Parameters.Add("@idIva", SqlDbType.Int).Value = obj.iva.id
        'i = sc.ExecuteNonQuery

        'sc = Nothing
        'If i >= 1 Then
        '    Return obj.id
        'End If
        Return -1
    End Function
    ''' <summary>
    '''  Elimina  un centre de la base de dades
    ''' </summary>
    ''' <param name="obj"></param>
    ''' <returns></returns>
    Private Function removeSQL(obj As doc) As Boolean
        'Dim sc As SqlCommand, i As Integer
        'sc = New SqlCommand("DELETE FROM " & getTable() & " WHERE " & ID & "=@id", DBCONNECT.getConnection)
        'sc.Parameters.Add("@id", SqlDbType.Int).Value = obj.id
        'i = sc.ExecuteNonQuery
        'sc = Nothing
        'If i >= 1 Then
        '    Return True
        'End If
        Return False
    End Function
    ''' <summary>
    ''' Obté tots els centres del sistema 
    ''' </summary>
    ''' <returns>una llista de centres</returns>
    Private Function getObjectsSQL(a As Integer) As List(Of doc)
        'Dim sc As SqlCommand, sdr As SqlDataReader, a As article
        'getObjectsSQL = New List(Of article)
        'sc = New SqlCommand("Select * FROM " & getTable(), getConnection)
        'sdr = sc.ExecuteReader
        'While sdr.Read()
        '    a = New article(sdr(ID),
        '                       CONFIG.validarNull(Trim(sdr(CODI))),
        '                       CONFIG.validarNull(Trim(sdr(NOM))),
        '                       Trim(CONFIG.validarNull(sdr(NOTES))))
        '    a.familia = ModelFamilia.getAuxiliar.getObject(sdr(ID_FAMILIA))
        '    a.unitat = ModelUnitat.getAuxiliar.getObject(sdr(ID_UNITAT))
        '    a.fabricant = ModelFabricant.getAuxiliar.getObject(sdr(ID_FABRICANT))
        '    a.iva = ModelTipusIva.getAuxiliar.getObject(sdr(ID_IVA))
        '    getObjectsSQL.Add(a)
        'End While
        'sdr.Close()
        'getObjectsSQL.Sort()
        'sdr = Nothing
        'sc = Nothing
        Return Nothing
    End Function

    Private Function updateDBF(obj As doc) As Integer
        Dim sc As ADODB.Command
        sc = New ADODB.Command
        With sc
            .ActiveConnection = DBCONNECT.getConnectionDbf
            .CommandText = "UPDATE " & getTable() & " " &
                                " Set " & CODI & "=?," &
                                          NOM & " =?, " &
                                          ID_SOLICITUT & " =?, " &
                                          ID_COMANDA_EDICIO & " =?, " &
                                          DATA & " =?, " &
                                          ID_PROVEIDOR & " =?, " &
                                          ANYO & " =?, " &
                                          ID_COMANDA & " =? " &
                                          " WHERE " & ID & "=?"
            .Parameters.Append(ADOPARAM.ToString(obj.codi))
            .Parameters.Append(ADOPARAM.ToString(obj.nom))
            .Parameters.Append(ADOPARAM.ToInt(obj.idSolicitut))
            .Parameters.Append(ADOPARAM.ToInt(obj.idComandaEnEdicio))
            .Parameters.Append(ADOPARAM.ToDate(obj.data))
            .Parameters.Append(ADOPARAM.ToInt(obj.idProveidor))
            .Parameters.Append(ADOPARAM.ToInt(obj.anyo))
            .Parameters.Append(ADOPARAM.ToInt(obj.idComanda))
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
    Private Function insertDBF(obj As doc) As Integer
        Dim sc As ADODB.Command
        sc = New ADODB.Command
        obj.id = DBCONNECT.getMaxIdDBF(getTable) + 1
        With sc
            .ActiveConnection = DBCONNECT.getConnectionDbf
            .CommandText = " INSERT INTO " & getTable() & " " &
                            " (" & ID & ", " & ID_PROVEIDOR & ", " & CODI & ", " & NOM & ", " & ID_SOLICITUT & ", " & ID_COMANDA_EDICIO & ", " & ID_COMANDA & ", " & DATA & ", " & ANYO & ")" &
                            " VALUES(?,?,?,?,?,?,?,?,?)"
            .Parameters.Append(ADOPARAM.ToInt(obj.id))
            .Parameters.Append(ADOPARAM.ToInt(obj.idProveidor))
            .Parameters.Append(ADOPARAM.ToString(obj.codi))
            .Parameters.Append(ADOPARAM.ToString(obj.nom))
            .Parameters.Append(ADOPARAM.ToInt(obj.idSolicitut))
            .Parameters.Append(ADOPARAM.ToInt(obj.idComandaEnEdicio))
            .Parameters.Append(ADOPARAM.ToInt(obj.idComanda))
            .Parameters.Append(ADOPARAM.ToDate(obj.data))
            .Parameters.Append(ADOPARAM.ToInt(obj.anyo))

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
    Private Function removeDBF(obj As doc) As Boolean
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
    Private Function getObjectsDBF(a As Integer) As List(Of doc)
        Dim rc As ADODB.Recordset, d As doc, av As frmAvis, i As Long, max As Long
        rc = New ADODB.Recordset

        getObjectsDBF = New List(Of doc)
        rc.Open("Select count(id)  FROM " & getTable() & " WHERE ANYO=" & a, DBCONNECT.getConnectionDbf)
        If Not rc.EOF Then
            max = rc(0).Value
            av = New frmAvis(IDIOMA.getString("esperaUnMoment"), IDIOMA.getString("carregantDades"), IDIOMA.getString("articles"), max)
            rc.Close()
            rc.Open("Select * FROM " & getTable() & " WHERE ANYO =" & a, DBCONNECT.getConnectionDbf)
            i = 1
            While Not rc.EOF
                d = New doc(rc(ID).Value,
                                   rc(ID_SOLICITUT).Value,
                                   rc(ID_COMANDA_EDICIO).Value,
                                   rc(ID_COMANDA).Value)
                d.codi = Trim(CONFIG.validarNull(rc(CODI).Value))
                d.nom = Trim(CONFIG.validarNull(rc(NOM).Value))
                d.anyo = rc(ANYO).Value
                d.idProveidor = rc(ID_PROVEIDOR).Value
                If d.idProveidor > 0 Then d.nomProveidor = ModelProveidor.getNom(d.idProveidor)
                d.data = Trim(CONFIG.validarNullDate(rc(DATA).Value))

                getObjectsDBF.Add(d)
                av.setData(d.nom, i)
                rc.MoveNext()
                i = i + 1
            End While
        End If
        If rc.State = 1 Then rc.Close()
        rc = Nothing
        av.tancar()
        getObjectsDBF.Sort()
    End Function

    Private Function getTable() As String
        Return DBCONNECT.getTaulaDocumentacio
    End Function
End Module
