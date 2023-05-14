
Option Explicit On
    Imports System.Data.SqlClient
    Module dbComandaRecepcio
    Private Const ID As String = "ID"
    Private Const TIPUS As String = "ESTAT"
    Private Const SERIE As String = "SERIE"
    Private Const NUM As String = "NUM"
    Private Const CODI_COMANDA As String = "CODCOM"
    Private Const ID_EMPRESA As String = "IDEMP"
    Private Const CODI_EMPRESA As String = "CODEMP"
    Private Const NOM_PROVEIDOR As String = "NPROV"
    Private Const CIF_PROVEIDOR As String = "CPROV"
    Private Const CODI_PROJECTE As String = "CODIPRO"
    Private Const RESPONSABLE_COMPRA As String = "RESP"
    Private Const BASE_COMANDA As String = "BASE"
    Private Const DATA As String = "DATAC"
    Private Const TIPUS_VENCIMENT As String = "TVENC"
    Private Const ID_MYDOC As String = "IDDOC"
    'ACCESSORS CENTRE
    ''' <summary>
    ''' SAVE. Guarda un centre a la base de dades. 
    ''' Si es nou, fa una inserció si no  actualitza.
    ''' </summary>
    ''' <param name="obj"> centre</param>
    ''' <returns>identificador del centre.</returns>
    Public Function update(obj As ComandaRecepcio) As Integer
        If IS_SQLSERVER() Then Return updateSQL(obj)
        Return updateDBF(obj)
    End Function

    Public Function insert(obj As ComandaRecepcio) As Integer
        If IS_SQLSERVER() Then Return insertSQL(obj)
        Return insertDBF(obj)
    End Function
    Public Function remove(estat As Boolean) As Boolean
        If IS_SQLSERVER() Then Return False
        Return removeDBF(estat)
    End Function
    Public Function getObjects(anyo As Integer) As List(Of ComandaRecepcio)
        If IS_SQLSERVER() Then Return getObjectsSQL(anyo)
        Return getObjectsDBF(anyo)
    End Function

    Private Function updateSQL(obj As ComandaRecepcio) As Integer
        'Dim sc As SqlCommand, i As Integer
        'sc = New SqlCommand("UPDATE " & getTable() & " " &
        '                    " SET " & CODI & "=@codi," &
        '                              SERIE & " =@serie, " &
        '                              CODI_EMPRESA & " =@codiEmpresa, " &
        '                              NOM_PROVEIDOR & " =@nomProveidor, " &
        '                              CIF_PROVEIDOR & " =@cifProveidor, " &
        '                              CODI_PROJECTE & " =@codiProjecte, " &
        '                              RESPONSABLE_COMPRA & " =@responsable, " &
        '                              BASE_COMANDA & " =@baseComanda, " &
        '                              DATA & " =@data, " &
        '                              ID_MYDOC & " =@idMydoc, " &
        '                              TIPUS & " =@tipus, " &
        '                              TIPUS_VENCIMENT & " =@tipusVenciment " &
        '                              " WHERE " & ID & "=@id", DBCONNECT.getConnection)
        'sc.Parameters.Add("@id", SqlDbType.Int).Value = obj.id
        'sc.Parameters.Add("@serie", SqlDbType.VarChar).Value = obj.codiComanda
        'sc.Parameters.Add("@codiEmpresa", SqlDbType.SmallInt).Value = obj.codiEmpresa
        'sc.Parameters.Add("@nomProveidor", SqlDbType.SmallInt).Value = obj.nomProveidor
        'sc.Parameters.Add("@cifProveidor", SqlDbType.SmallInt).Value = obj.cifProveidor
        'sc.Parameters.Add("@codiProjecte", SqlDbType.SmallInt).Value = obj.codiProjecte
        'sc.Parameters.Add("@responsable", SqlDbType.SmallInt).Value = obj.responsableCompra
        'sc.Parameters.Add("@baseComanda", SqlDbType.SmallInt).Value = obj.base
        'sc.Parameters.Add("@data", SqlDbType.Date).Value = obj.data
        'sc.Parameters.Add("@idMydoc", SqlDbType.Int).Value = obj.idMydoc
        'sc.Parameters.Add("@tipusVenciment", SqlDbType.Date).Value = obj.tipusPagament
        'sc.Parameters.Add("@tipus", SqlDbType.Bit).Value = obj.estat
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
    Private Function insertSQL(obj As ComandaRecepcio) As Integer
        'Dim sc As SqlCommand, i As Integer
        'obj.id = DBCONNECT.getMaxId(getTable) + 1
        'sc = New SqlCommand(" INSERT INTO " & getTable() & " " &
        '                " (" & ID & ", " & CODI & ", " & SERIE & ", " & CODI_EMPRESA & ", " & NOM_PROVEIDOR & ", " & CIF_PROVEIDOR & ", " & CODI_PROJECTE & ", " & RESPONSABLE_COMPRA & ", " & BASE_COMANDA & "," & DATA & "," & TIPUS_VENCIMENT & "," & ID_MYDOC & "," & TIPUS & ")" & " VALUES(@id,@codi,@serie,@codiEmpresa,@nomProveidor,@cifProveidor,@codiProjecte,@responsableCompra,@baseComanda,@data,@tipusVenciment,@idMydoc,@tipus)", DBCONNECT.getConnection)
        'sc.Parameters.Add("@id", SqlDbType.Int).Value = obj.id
        'sc.Parameters.Add("@serie", SqlDbType.VarChar).Value = obj.codiComanda
        'sc.Parameters.Add("@codiEmpresa", SqlDbType.SmallInt).Value = obj.codiEmpresa
        'sc.Parameters.Add("@nomProveidor", SqlDbType.SmallInt).Value = obj.nomProveidor
        'sc.Parameters.Add("@cifProveidor", SqlDbType.SmallInt).Value = obj.cifProveidor
        'sc.Parameters.Add("@codiProjecte", SqlDbType.SmallInt).Value = obj.codiProjecte
        'sc.Parameters.Add("@responsable", SqlDbType.SmallInt).Value = obj.responsableCompra
        'sc.Parameters.Add("@baseComanda", SqlDbType.SmallInt).Value = obj.base
        'sc.Parameters.Add("@data", SqlDbType.Date).Value = obj.data
        'sc.Parameters.Add("@idMydoc", SqlDbType.Int).Value = obj.idMydoc
        'sc.Parameters.Add("@tipusVenciment", SqlDbType.Date).Value = obj.tipusPagament
        'sc.Parameters.Add("@tipus", SqlDbType.Bit).Value = obj.estat
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
    Private Function removeSQL(obj As ComandaRecepcio, e As Integer) As Boolean
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
    Private Function getObjectsSQL(a As Integer) As List(Of ComandaRecepcio)
        'Dim sc As SqlCommand, sdr As SqlDataReader, c As ComandaRecepcio
        'getObjectsSQL = New List(Of ComandaRecepcio)
        'sc = New SqlCommand("Select * FROM " & getTable() & " WHERE YEAR(DATAC)=" & a, getConnection)
        'sdr = sc.ExecuteReader
        'While sdr.Read()
        '    c = New ComandaRecepcio
        '    c.id = sdr(ID)
        '    c.idMydoc = sdr(ID_MYDOC)
        '    c.codiComanda = sdr(CODI)
        '    c.codiEmpresa = sdr(CODI_EMPRESA)
        '    c.codiProjecte = sdr(CODI_PROJECTE)
        '    c.cifProveidor = sdr(CIF_PROVEIDOR)
        '    c.nomProveidor = sdr(NOM_PROVEIDOR)
        '    c.serie = sdr(SERIE)
        '    c.base = sdr(BASE_COMANDA)
        '    c.data = sdr(DATA)
        '    c.tipusPagament = sdr(TIPUS_VENCIMENT)
        '    c.responsableCompra = sdr(RESPONSABLE_COMPRA)
        '    c.estat = sdr(TIPUS)
        '    getObjectsSQL.Add(c)
        'End While
        'sdr.Close()
        'getObjectsSQL.Sort()
        'sdr = Nothing
        'sc = Nothing
    End Function

    Private Function updateDBF(obj As ComandaRecepcio) As Integer
        Dim sc As ADODB.Command
        sc = New ADODB.Command
        With sc
            .ActiveConnection = DBCONNECT.getConnectionDbf
            .CommandText = "UPDATE " & getTable() & " " &
                            " SET " & NUM & "=?," &
                                      CODI_COMANDA & "=?," &
                                      SERIE & " =?, " &
                                      ID_EMPRESA & "=?," &
                                      CODI_EMPRESA & " =?, " &
                                      NOM_PROVEIDOR & " =?, " &
                                      CIF_PROVEIDOR & " =?, " &
                                      CODI_PROJECTE & " =?, " &
                                      RESPONSABLE_COMPRA & " =?, " &
                                      BASE_COMANDA & " =?, " &
                                      DATA & " =?, " &
                                      ID_MYDOC & " =?, " &
                                      TIPUS & " =?, " &
                                      TIPUS_VENCIMENT & " =? " &
                            " WHERE " & ID & "=?"
            .Parameters.Append(ADOPARAM.ToInt(obj.NUM))
            .Parameters.Append(ADOPARAM.ToString(getStr(obj.codiComanda)))
            .Parameters.Append(ADOPARAM.ToString(getStr(obj.serie)))
            .Parameters.Append(ADOPARAM.ToInt(obj.idEmpresa))
            .Parameters.Append(ADOPARAM.ToString(getStr(obj.codiEmpresa)))
            .Parameters.Append(ADOPARAM.ToString(getStr(obj.nomProveidor)))
            .Parameters.Append(ADOPARAM.ToString(getString(obj.cifProveidor)))
            .Parameters.Append(ADOPARAM.ToString(getStr(obj.codiProjecte)))
            .Parameters.Append(ADOPARAM.ToString(getStr(obj.responsableCompra)))
            .Parameters.Append(ADOPARAM.ToSingle(Math.Round(obj.base) * 100, 0))
            .Parameters.Append(ADOPARAM.ToDate(obj.data))
            .Parameters.Append(ADOPARAM.ToInt(obj.idMydoc))
            .Parameters.Append(ADOPARAM.toBool(obj.estat))
            .Parameters.Append(ADOPARAM.ToString(getStr(obj.tipusPagament)))
            .Parameters.Append(ADOPARAM.ToString(getStr(obj.id)))
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
    Private Function insertDBF(obj As ComandaRecepcio) As Integer
        Dim sc As ADODB.Command
        sc = New ADODB.Command
        obj.id = DBCONNECT.getMaxIdDBF(getTable) + 1
        With sc
            .ActiveConnection = DBCONNECT.getConnectionDbf
            .CommandText = (" INSERT INTO " & getTable() & " " &
                        " (" & ID & ", " & NUM & ", " & CODI_COMANDA & ", " & SERIE & ", " & ID_EMPRESA & ", " & CODI_EMPRESA & ", " & NOM_PROVEIDOR & ", " & CIF_PROVEIDOR & ", " & CODI_PROJECTE & ", " & RESPONSABLE_COMPRA & ", " & BASE_COMANDA & "," & DATA & "," & TIPUS_VENCIMENT & "," & ID_MYDOC & "," & TIPUS & ") " &
                        "  VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)")
            .Parameters.Append(ADOPARAM.ToInt(obj.id))
            .Parameters.Append(ADOPARAM.ToInt(obj.num))
            .Parameters.Append(ADOPARAM.ToString(getStr(obj.codiComanda)))
            .Parameters.Append(ADOPARAM.ToString(getStr(obj.serie)))
            .Parameters.Append(ADOPARAM.ToInt(obj.idEmpresa))
            .Parameters.Append(ADOPARAM.ToString(getStr(obj.codiEmpresa)))
            .Parameters.Append(ADOPARAM.ToString(getStr(obj.nomProveidor)))
            .Parameters.Append(ADOPARAM.ToString(getStr(obj.cifProveidor)))
            .Parameters.Append(ADOPARAM.ToString(getStr(obj.codiProjecte)))
            .Parameters.Append(ADOPARAM.ToString(getStr(obj.responsableCompra)))
            .Parameters.Append(ADOPARAM.ToSingle(Math.Round(obj.base * 100), 0))
            .Parameters.Append(ADOPARAM.ToDate(obj.data))
            .Parameters.Append(ADOPARAM.ToString(getStr(obj.tipusPagament)))
            .Parameters.Append(ADOPARAM.ToInt(obj.idMydoc))
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
    Private Function removeDBF(estat As Boolean) As Boolean
        Dim sc As ADODB.Command
        sc = New ADODB.Command
        With sc
            sc.ActiveConnection = DBCONNECT.getConnectionDbf
            sc.CommandText = " DELETE FROM " & getTable() & " WHERE " & TIPUS & "=?"
            sc.Parameters.Append(ADOPARAM.toBool(estat, ""))
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
    Private Function getObjectsDBF(a As Integer) As List(Of ComandaRecepcio)
        Dim rc As ADODB.Recordset, c As ComandaRecepcio
        rc = New ADODB.Recordset
        getObjectsDBF = New List(Of ComandaRecepcio)
        If a > 2000 Then
            rc.Open("Select * FROM " & getTable() & " where year(DATAC)=" & a, DBCONNECT.getConnectionDbf)
        Else
            rc.Open("Select * FROM " & getTable(), DBCONNECT.getConnectionDbf)
        End If
        While Not rc.EOF
            c = New ComandaRecepcio
            c.id = rc(ID).Value
            c.num = rc(NUM).Value
            c.idMydoc = rc(ID_MYDOC).Value
            c.codiComanda = CONFIG.validarNull(rc(CODI).Value)
            c.idEmpresa = rc(ID_EMPRESA).Value
            c.codiEmpresa = CONFIG.validarNull(rc(CODI_EMPRESA).Value)
            c.codiProjecte = CONFIG.validarNull(rc(CODI_PROJECTE).Value)
            c.cifProveidor = CONFIG.validarNull(rc(CIF_PROVEIDOR).Value)
            c.nomProveidor = CONFIG.validarNull(rc(NOM_PROVEIDOR).Value)
            c.serie = CONFIG.validarNull(rc(SERIE).Value)
            c.base = Math.Round(rc(BASE_COMANDA).Value / 100, 2)
            c.data = CONFIG.validarNullDate(rc(DATA).Value)
            c.tipusPagament = CONFIG.validarNull(rc(TIPUS_VENCIMENT).Value)
            c.responsableCompra = CONFIG.validarNull(rc(RESPONSABLE_COMPRA).Value)
            c.estat = CONFIG.validarBoolean(rc(TIPUS).Value)
            getObjectsDBF.Add(c)
            rc.MoveNext()
        End While
        If rc.State = 1 Then rc.Close()
        rc = Nothing
        getObjectsDBF.Sort()
    End Function

    ''' <summary>
    ''' Obté tots els centres del sistema 
    ''' </summary>
    ''' <returns>una llista de centres</returns>

    Private Function getInt(p As Object) As Integer
            If IsNothing(p) Then Return -1
            Return p.id
        End Function
        Private Function getLong(p As Object) As Long
            If IsNothing(p) Then Return -1
            Return p.id
        End Function
        Private Function getStr(p As String) As String
            If IsNothing(p) Then Return ""
            Return p
        End Function

    Private Function getTable() As String
        Return DBCONNECT.getTaulaComandaRecepcio

    End Function

End Module
