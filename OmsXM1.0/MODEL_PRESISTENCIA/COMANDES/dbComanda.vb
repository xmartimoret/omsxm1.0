Option Explicit On
Imports System.Data.SqlClient
Module dbComanda
    Private Const ID As String = "ID"
    Private Const IDCE As String = "IDCE"
    Private Const ID_MYDOC As String = "IDMYDOC"
    Private Const SERIE As String = "SERIE"
    Private Const CODI As String = "NUM"
    Private Const ID_EMPRESA As String = "IDEMP"
    Private Const ID_PROVEIDOR As String = "IDPROV"
    Private Const ID_CONTACTE_PROVEIDOR As String = "IDCPROV"
    Private Const ID_PROJECTE As String = "IDPROJ"
    Private Const ID_CONTACTE_PROJECTE As String = "IDCPROJ"
    Private Const ID_MAGATZEM As String = "IDMAGAT"
    Private Const DATA_COMANDA As String = "DATAC"
    Private Const DATA_MUNTATGE As String = "DATAM"
    Private Const DATA_ENTREGA As String = "DATAE"
    Private Const INICI_COMANDA As String = "INICI"
    Private Const INICI_MUNTATGE As String = "EQUIP"
    Private Const ENTREGA As String = "ENTREGA"
    Private Const OFERTA As String = "OFERTA"
    Private Const ID_TIPUS_PAGAMENT As String = "IDPAGO"
    Private Const DADES_BANCARIES As String = "BANC"
    Private Const PORTS As String = "PORTS"
    Private Const NOTES As String = "notes"
    Private Const ESTAT As String = "ESTAT"
    Private Const IDSOLICITUT As String = "IDSOL"
    Private Const RESPONSABLE_COMPRA As String = "RESPC"
    Private Const BASE_COMANDA As String = "BASE"
    Private Const IVA_COMANDA As String = "IVA"
    Private Const URGENT As String = "URG"
    Private Const DEPARTAMENT As String = "DEP"
    'ACCESSORS CENTRE
    ''' <summary>
    ''' SAVE. Guarda un centre a la base de dades. 
    ''' Si es nou, fa una inserció si no  actualitza.
    ''' </summary>
    ''' <param name="obj"> centre</param>
    ''' <returns>identificador del centre.</returns>
    Public Function update(obj As Comanda, estat As Integer) As Integer
        If IS_SQLSERVER() Then Return updateSQL(obj, estat)
        Return updateDBF(obj, estat)
    End Function
    Public Function update(idComanda As Integer, estat As Integer, idMydoc As Long) As Integer
        If IS_SQLSERVER() Then Return updateSQL(idComanda, estat, idMydoc)
        Return updateDBF(idComanda, estat, idMydoc)
    End Function
    Public Function updateEstat(idComanda As Integer, estat As Integer) As Integer
        If IS_SQLSERVER() Then Return updateEstatSQL(idComanda, estat)
        Return updateEstatDBF(idComanda, estat)
    End Function
    Public Function updateUrgent(idComanda As Integer, estat As Integer, valor As Boolean) As Integer
        If IS_SQLSERVER() Then Return updateUrgentSQL(idComanda, estat, valor)
        Return updateUrgentDBF(idComanda, estat, valor)
    End Function
    'updateDBFImport
    Public Function updateImport(obj As Comanda, estat As Integer) As Integer
        Return updateDBFImport(obj, estat)
    End Function
    Public Function insert(obj As Comanda, estat As Integer) As Integer
        If IS_SQLSERVER() Then Return insertSQL(obj, estat)
        Return insertDBF(obj, estat)
    End Function
    Public Function remove(obj As Comanda, estat As Integer) As Boolean
        If IS_SQLSERVER() Then Return removeSQL(obj, estat)
        Return removeDBF(obj, estat)
    End Function
    Public Function getObjects(anyo As Integer, estat As Integer) As List(Of Comanda)
        If IS_SQLSERVER() Then Return getObjectsSQL(anyo, estat)
        Return getObjectsDBF(anyo, estat)
    End Function
    Public Function getObjects(codi As String, estat As Integer, idempresa As Integer, Optional anyo As Integer = 0) As List(Of Comanda)
        If IS_SQLSERVER() Then Return getObjectsSQL(anyo, estat)
        Return getObjectsDBFByCodi(codi, estat, idempresa, anyo)
    End Function
    Public Function exist(id As Integer, p As Object, estat As Integer) As Boolean
        If IS_SQLSERVER() Then Return existSQL(id, p, estat)
        Return existDBF(id, p, estat)
    End Function

    Private Function updateSQL(obj As Comanda, e As Integer) As Integer
        Dim sc As SqlCommand, i As Integer
        sc = New SqlCommand("UPDATE " & getTable(e) & " " &
                            " SET " & CODI & "=@codi," &
                                      IDCE & "=@idce," &
                                      ID_EMPRESA & " =@idEmpresa, " &
                                      ID_PROVEIDOR & " =@idProveidor, " &
                                      ID_CONTACTE_PROVEIDOR & " =@IdContacteProveidor, " &
                                      ID_PROJECTE & " =@idProjecte, " &
                                      ID_CONTACTE_PROJECTE & " =@idContacteprojecte, " &
                                      ID_MAGATZEM & " =@idMagatzem, " &
                                      DATA_COMANDA & " =@dataComanda, " &
                                      DATA_MUNTATGE & " =@dataMuntatge, " &
                                      DATA_ENTREGA & " =@dataentrega, " &
                                      INICI_COMANDA & " =@iniciComanda, " &
                                      INICI_MUNTATGE & " =@iniciMuntatge, " &
                                      ENTREGA & " =@entrega, " &
                                      OFERTA & " =@oferta, " &
                                      ID_TIPUS_PAGAMENT & " =@idTipusPagament, " &
                                      DADES_BANCARIES & " =@dadesBancaries, " &
                                      PORTS & " =@ports, " &
                                      ESTAT & " =@estat, " &
                                      IDSOLICITUT & " =@idSolicitut, " &
                                      RESPONSABLE_COMPRA & " =@responsableCompra " &
                                      " WHERE " & ID & "=@id", DBCONNECT.getConnection)
        sc.Parameters.Add("@id", SqlDbType.Int).Value = obj.id
        sc.Parameters.Add("@codi", SqlDbType.VarChar).Value = obj.codi
        sc.Parameters.Add("@idce", SqlDbType.Int).Value = obj.idComandaEdicio
        sc.Parameters.Add("@idempresa", SqlDbType.SmallInt).Value = obj.empresa.id
        sc.Parameters.Add("@idProveidor", SqlDbType.SmallInt).Value = obj.proveidor.id
        sc.Parameters.Add("@IdContacteProveidor", SqlDbType.SmallInt).Value = obj.contacteProveidor.id
        sc.Parameters.Add("@idProjecte", SqlDbType.SmallInt).Value = obj.projecte.id
        sc.Parameters.Add("@idContacteprojecte", SqlDbType.SmallInt).Value = obj.contacte.id
        sc.Parameters.Add("@idMagatzem", SqlDbType.SmallInt).Value = obj.magatzem.id
        sc.Parameters.Add("@dataComanda", SqlDbType.Date).Value = obj.data
        sc.Parameters.Add("@dataMuntatge", SqlDbType.Date).Value = obj.dataMuntatge
        sc.Parameters.Add("@dataentrega", SqlDbType.Date).Value = obj.dataEntrega
        sc.Parameters.Add("@iniciComanda", SqlDbType.SmallInt).Value = obj.inici
        sc.Parameters.Add("@iniciMuntatge", SqlDbType.SmallInt).Value = obj.entregaEquips
        sc.Parameters.Add("@entrega", SqlDbType.SmallInt).Value = obj.entrega
        sc.Parameters.Add("@oferta", SqlDbType.VarChar).Value = obj.nOferta
        sc.Parameters.Add("@idTipusPagament", SqlDbType.SmallInt).Value = obj.tipusPagament.id
        sc.Parameters.Add("@dadesBancaries", SqlDbType.VarChar).Value = obj.dadesBancaries
        sc.Parameters.Add("@ports", SqlDbType.VarChar).Value = obj.ports
        sc.Parameters.Add("@estat", SqlDbType.Int).Value = obj.estat
        sc.Parameters.Add("@idSolitut", SqlDbType.Int).Value = obj.idSolicitut
        sc.Parameters.Add("@responsableCompra", SqlDbType.Int).Value = obj.responsableCompra.id
        i = sc.ExecuteNonQuery
        sc = Nothing
        If i >= 1 Then
            Return obj.id
        End If
        Return -1
    End Function
    Private Function updateSQL(idComanda As Integer, e As Integer, idMydoc As Long) As Integer
        Dim sc As SqlCommand, i As Integer
        sc = New SqlCommand("UPDATE " & getTable(e) & " " &
                            " SET " & ID_MYDOC & "=@idMydoc " &
                                      " WHERE " & ID & "=@id", DBCONNECT.getConnection)
        sc.Parameters.Add("@id", SqlDbType.Int).Value = idComanda
        sc.Parameters.Add("@idMydoc", SqlDbType.Int).Value = idMydoc
        i = sc.ExecuteNonQuery
        sc = Nothing
        If i >= 1 Then
            Return idComanda
        End If
        Return -1
    End Function
    Private Function updateEstatSQL(idComanda As Integer, e As Integer) As Integer
        Dim sc As SqlCommand, i As Integer
        sc = New SqlCommand("UPDATE " & getTable(e) & " " &
                            " SET " & ESTAT & "=@estat " &
                                      " WHERE " & ID & "=@id", DBCONNECT.getConnection)
        sc.Parameters.Add("@id", SqlDbType.Int).Value = idComanda
        sc.Parameters.Add("@estat", SqlDbType.Int).Value = e
        i = sc.ExecuteNonQuery
        sc = Nothing
        If i >= 1 Then
            Return idComanda
        End If
        Return -1
    End Function
    Private Function updateUrgentSQL(idComanda As Integer, e As Integer, v As Boolean) As Integer
        Dim sc As SqlCommand, i As Integer
        sc = New SqlCommand("UPDATE " & getTable(e) & " " &
                            " SET " & URGENT & "=@valor " &
                                      " WHERE " & ID & "=@id", DBCONNECT.getConnection)
        sc.Parameters.Add("@id", SqlDbType.Int).Value = idComanda
        sc.Parameters.Add("@valor", SqlDbType.Bit).Value = v
        i = sc.ExecuteNonQuery
        sc = Nothing
        If i >= 1 Then
            Return idComanda
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
    Private Function insertSQL(obj As Comanda, e As Integer) As Integer
        Dim sc As SqlCommand, i As Integer
        obj.id = DBCONNECT.getMaxId(getTable(e)) + 1
        sc = New SqlCommand(" INSERT INTO " & getTable(e) & " " &
                        " (" & ID & "," & IDCE & "," & ID_MYDOC & ", " & CODI & ", " & ID_EMPRESA & ", " & ID_PROVEIDOR & ", " & ID_CONTACTE_PROVEIDOR & ", " & ID_PROJECTE & ", " & ID_CONTACTE_PROJECTE & ", " & ID_MAGATZEM & "," &
                         DATA_COMANDA & "," & DATA_MUNTATGE & "," & DATA_ENTREGA & "," & INICI_COMANDA & "," & INICI_MUNTATGE & "," & ENTREGA & "," & OFERTA & "," & ID_TIPUS_PAGAMENT & "," & DADES_BANCARIES & "," & PORTS & "," & ESTAT & "," & RESPONSABLE_COMPRA & "," & IDSOLICITUT & ")" &
                        " VALUES(@id,@idce,@idMydoc,@codi,@idEmpresa,@idProveidor,@idContacteProveidor,@idProjecte,@idContacteProjecte,@idMagatzem,@dataComanda,@dataMuntatge,@dataEntrega,@iniciComanda,@iniciMuntatge,entrega,@oferta,@idtipusPagament,@dadesBancaries,@ports,@estat,@responsableCompra,@idSolicitut)", DBCONNECT.getConnection)
        sc.Parameters.Add("@id", SqlDbType.Int).Value = obj.id
        sc.Parameters.Add("@idce", SqlDbType.Int).Value = obj.idComandaEdicio
        sc.Parameters.Add("@idMydoc", SqlDbType.Int).Value = obj.idMydoc
        sc.Parameters.Add("@codi", SqlDbType.VarChar).Value = obj.codi
        sc.Parameters.Add("@idempresa", SqlDbType.SmallInt).Value = obj.empresa.id
        sc.Parameters.Add("@idProveidor", SqlDbType.SmallInt).Value = obj.proveidor.id
        sc.Parameters.Add("@IdContacteProveidor", SqlDbType.SmallInt).Value = obj.contacteProveidor.id
        sc.Parameters.Add("@idProjecte", SqlDbType.SmallInt).Value = obj.projecte.id
        sc.Parameters.Add("@idContacteprojecte", SqlDbType.SmallInt).Value = obj.contacte.id
        sc.Parameters.Add("@idMagatzem", SqlDbType.SmallInt).Value = obj.magatzem.id
        sc.Parameters.Add("@dataComanda", SqlDbType.Date).Value = obj.data
        sc.Parameters.Add("@dataMuntatge", SqlDbType.Date).Value = obj.dataMuntatge
        sc.Parameters.Add("@dataentrega", SqlDbType.Date).Value = obj.dataEntrega
        sc.Parameters.Add("@iniciComanda", SqlDbType.SmallInt).Value = obj.inici
        sc.Parameters.Add("@iniciMuntatge", SqlDbType.SmallInt).Value = obj.entregaEquips
        sc.Parameters.Add("@entrega", SqlDbType.SmallInt).Value = obj.entrega
        sc.Parameters.Add("@oferta", SqlDbType.VarChar).Value = obj.nOferta
        sc.Parameters.Add("@idTipusPagament", SqlDbType.SmallInt).Value = obj.tipusPagament.id
        sc.Parameters.Add("@dadesBancaries", SqlDbType.VarChar).Value = obj.dadesBancaries
        sc.Parameters.Add("@ports", SqlDbType.VarChar).Value = obj.ports
        sc.Parameters.Add("@estat", SqlDbType.Int).Value = obj.estat
        sc.Parameters.Add("@idSolicitut", SqlDbType.Int).Value = obj.idSolicitut
        sc.Parameters.Add("@responsableCompra", SqlDbType.Int).Value = obj.responsableCompra.id
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
    Private Function removeSQL(obj As Comanda, e As Integer) As Boolean
        Dim sc As SqlCommand, i As Integer
        sc = New SqlCommand("DELETE FROM " & getTable(e) & " WHERE " & ID & "=@id", DBCONNECT.getConnection)
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
    Private Function getObjectsSQL(a As Integer, e As Integer) As List(Of Comanda)
        Dim sc As SqlCommand, sdr As SqlDataReader, c As Comanda
        getObjectsSQL = New List(Of Comanda)
        sc = New SqlCommand("Select * FROM " & getTable(e) & " WHERE YEAR(DATAC)=" & a, getConnection)
        sdr = sc.ExecuteReader
        While sdr.Read()
            c = New Comanda(sdr(ID), CONFIG.validarNull(Trim(sdr(CODI))), ModelProveidor.getObject(sdr(ID_PROVEIDOR)), ModelEmpresa.getObject(sdr(ID_EMPRESA)), ModelProjecte.getObject(sdr(ID_PROJECTE)))
            'TODO CAL IMPLEMENTAR ARTICLES COMANDA 
            'c.articles = modela
            c.idComandaEdicio = sdr(IDCE)
            c.contacte = ModelContacte.getObject(sdr(ID_CONTACTE_PROJECTE))
            c.contacteProveidor = ModelProveidorContacte.getObject(sdr(ID_CONTACTE_PROVEIDOR))
            c.dadesBancaries = CONFIG.validarNull(Trim(sdr(DADES_BANCARIES)))
            c.data = CONFIG.validarNull(Trim(sdr(DATA_COMANDA)))
            c.dataEntrega = CONFIG.validarNull(Trim(sdr(DATA_ENTREGA)))
            c.dataMuntatge = CONFIG.validarNull(Trim(sdr(DATA_MUNTATGE)))
            c.inici = sdr(INICI_COMANDA)
            c.entregaEquips = sdr(INICI_MUNTATGE)
            c.magatzem = ModelLlocEntrega.getObject(sdr(ID_MAGATZEM))
            c.nOferta = Trim(CONFIG.validarNull(sdr(OFERTA)))
            c.ports = Trim(CONFIG.validarNull(sdr(PORTS)))
            c.entrega = sdr(ENTREGA)
            c.tipusPagament = ModelTipusPagament.getAuxiliar.getObject(sdr(ID_TIPUS_PAGAMENT))
            c.estat = sdr(ESTAT)
            c.idSolicitut = sdr(IDSOLICITUT)
            c.responsableCompra = ModelResponsableCompra.getAuxiliar.getObject(sdr(RESPONSABLE_COMPRA))
            getObjectsSQL.Add(c)
        End While
        sdr.Close()
        getObjectsSQL.Sort()
        sdr = Nothing
        sc = Nothing
    End Function
    Private Function existsQL(id As Integer, p As Object, e As Integer) As Boolean
        Dim sc As SqlCommand, sdr As SqlDataReader, camp As String
        camp = getCamp(p)
        existsQL = False
        If camp <> "" Then
            sc = New SqlCommand("Select TOP 1 * FROM " & getTable(e) & " WHERE " & camp & "=" & id, getConnection)
            sdr = sc.ExecuteReader
            If sdr.Read() Then existsQL = True
            sdr.Close()
            sdr = Nothing
            sc = Nothing
        End If
    End Function
    Private Function updateDBF(obj As Comanda, e As Integer) As Integer
        Dim sc As ADODB.Command
        sc = New ADODB.Command
        With sc
            .ActiveConnection = DBCONNECT.getConnectionDbf
            .CommandText = "UPDATE " & getTable(e) & " " &
                            " SET " & CODI & "=?," &
                                      IDCE & " =?, " &
                                      ID_EMPRESA & " =?, " &
                                      SERIE & "=?," &
                                      ID_PROVEIDOR & " =?, " &
                                      ID_CONTACTE_PROVEIDOR & " =?, " &
                                      ID_PROJECTE & " =?, " &
                                      ID_CONTACTE_PROJECTE & " =?, " &
                                      ID_MAGATZEM & " =?, " &
                                      DATA_COMANDA & " =?, " &
                                      DATA_MUNTATGE & " =?, " &
                                      DATA_ENTREGA & " =?, " &
                                      INICI_COMANDA & " =?, " &
                                      INICI_MUNTATGE & " =?, " &
                                      ENTREGA & " =?, " &
                                      OFERTA & " =?, " &
                                      ID_TIPUS_PAGAMENT & " =?, " &
                                      DADES_BANCARIES & " =?, " &
                                      PORTS & " =?, " &
                                      ESTAT & " =?, " &
                                      IDSOLICITUT & " =?, " &
                                      RESPONSABLE_COMPRA & " =?, " &
                                      BASE_COMANDA & " =?, " &
                                      IVA_COMANDA & " =?, " &
                                      DEPARTAMENT & " =?, " &
                                      URGENT & " =?, " &
                                      ID_MYDOC & " =? " &
                            " WHERE " & ID & "=?"
            .Parameters.Append(ADOPARAM.ToString(obj.codi))
            .Parameters.Append(ADOPARAM.ToInt(getInt(obj.idComandaEdicio)))
            .Parameters.Append(ADOPARAM.ToInt(getInt(obj.empresa)))
            .Parameters.Append(ADOPARAM.ToString(getStr(obj.serie)))
            .Parameters.Append(ADOPARAM.ToInt(getInt(obj.proveidor)))
            .Parameters.Append(ADOPARAM.ToInt(getInt(obj.contacteProveidor)))
            .Parameters.Append(ADOPARAM.ToInt(getInt(obj.projecte)))
            .Parameters.Append(ADOPARAM.ToInt(getInt(obj.contacte)))
            .Parameters.Append(ADOPARAM.ToInt(getInt(obj.magatzem)))
            .Parameters.Append(ADOPARAM.ToDate(obj.data))
            .Parameters.Append(ADOPARAM.ToDate(obj.dataMuntatge))
            .Parameters.Append(ADOPARAM.ToDate(obj.dataEntrega))
            .Parameters.Append(ADOPARAM.ToInt(getStr(obj.inici)))
            .Parameters.Append(ADOPARAM.ToInt(getStr(obj.entregaEquips)))
            .Parameters.Append(ADOPARAM.ToInt(getStr(obj.entrega)))
            .Parameters.Append(ADOPARAM.ToString(getStr(obj.nOferta)))
            .Parameters.Append(ADOPARAM.ToInt(getInt(obj.tipusPagament)))
            .Parameters.Append(ADOPARAM.ToString(getStr(obj.dadesBancaries)))
            .Parameters.Append(ADOPARAM.ToString(getStr(obj.ports)))
            .Parameters.Append(ADOPARAM.ToInt(obj.estat))
            .Parameters.Append(ADOPARAM.ToInt(obj.idSolicitut))
            .Parameters.Append(ADOPARAM.ToInt(obj.responsableCompra.id))
            .Parameters.Append(ADOPARAM.ToSingle(Math.Round(obj.baseComanda * 1000, 0)))
            .Parameters.Append(ADOPARAM.ToSingle(Math.Round(obj.ivaComanda * 1000, 0)))
            .Parameters.Append(ADOPARAM.ToString(getStr(obj.departament)))
            .Parameters.Append(ADOPARAM.toBool(getStr(obj.urgent)))
            .Parameters.Append(ADOPARAM.ToInt(getStr(obj.idMydoc)))
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
    Private Function updateDBFImport(obj As Comanda, e As Integer) As Integer
        Dim sc As ADODB.Command
        sc = New ADODB.Command
        With sc
            .ActiveConnection = DBCONNECT.getConnectionDbf
            .CommandText = "UPDATE " & getTable(e) & " " &
                            " SET " & BASE_COMANDA & " =?, " &
                                      IVA_COMANDA & " =? " &
                                      " WHERE " & ID & "=?"
            .Parameters.Append(ADOPARAM.ToSingle(Math.Round(obj.baseComanda * 1000, 0)))
            .Parameters.Append(ADOPARAM.ToSingle(Math.Round(obj.ivaComanda * 1000, 0)))
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
    Private Function updateDBF(idComanda As Integer, e As Integer, idMyDoc As Integer) As Integer
        Dim sc As ADODB.Command
        sc = New ADODB.Command
        With sc
            .ActiveConnection = DBCONNECT.getConnectionDbf
            .CommandText = "UPDATE " & getTable(e) & " " &
                            " SET " & ID_MYDOC & "=?" & " " &
                                      " WHERE " & ID & "=?"
            .Parameters.Append(ADOPARAM.ToInt(idMyDoc))
            .Parameters.Append(ADOPARAM.ToInt(idComanda))
        End With
        Try
            sc.Execute()
            Return idComanda
        Catch ex As Exception
            Call ERRORS.ERR_EXCEPTION_SQL(ex.Message)
            Return -1
        Finally
            sc = Nothing
        End Try
    End Function
    Private Function updateEstatDBF(idComanda As Integer, e As Integer) As Integer
        Dim sc As ADODB.Command
        sc = New ADODB.Command
        With sc
            .ActiveConnection = DBCONNECT.getConnectionDbf
            .CommandText = "UPDATE " & getTable(e) & " " &
                            " SET " & ESTAT & "=?" & " " &
                                      " WHERE " & ID & "=?"

            .Parameters.Append(ADOPARAM.ToInt(e))
            .Parameters.Append(ADOPARAM.ToInt(idComanda))
        End With
        Try
            sc.Execute()
            Return idComanda
        Catch ex As Exception
            Call ERRORS.ERR_EXCEPTION_SQL(ex.Message)
            Return -1
        Finally
            sc = Nothing
        End Try
    End Function
    Private Function updateUrgentDBF(idComanda As Integer, e As Integer, v As Boolean) As Integer
        Dim sc As ADODB.Command
        sc = New ADODB.Command
        With sc
            .ActiveConnection = DBCONNECT.getConnectionDbf
            .CommandText = "UPDATE " & getTable(e) & " " &
                            " SET " & URGENT & "=?" & " " &
                                      " WHERE " & ID & "=?"

            .Parameters.Append(ADOPARAM.toBool(v))
            .Parameters.Append(ADOPARAM.ToInt(idComanda))
        End With
        Try
            sc.Execute()
            Return idComanda
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
    Private Function insertDBF(obj As Comanda, e As Integer) As Integer
        Dim sc As ADODB.Command
        sc = New ADODB.Command
        obj.id = DBCONNECT.getMaxIdDBF(getTable(e)) + 1
        With sc
            .ActiveConnection = DBCONNECT.getConnectionDbf
            .CommandText = (" INSERT INTO " & getTable(e) & " " &
                        " (" & ID & "," & IDCE & "," & CODI & ", " & ID_EMPRESA & ", " & SERIE & "," & ID_PROVEIDOR & ", " & ID_CONTACTE_PROVEIDOR & ", " & ID_PROJECTE & ", " & ID_CONTACTE_PROJECTE & ", " & ID_MAGATZEM & "," &
                         DATA_COMANDA & "," & DATA_MUNTATGE & "," & DATA_ENTREGA & "," & INICI_COMANDA & "," & INICI_MUNTATGE & "," & ENTREGA & "," & OFERTA & "," & ID_TIPUS_PAGAMENT & "," & DADES_BANCARIES & "," & PORTS & "," & ESTAT & "," & IDSOLICITUT & "," & RESPONSABLE_COMPRA & "," & BASE_COMANDA & "," & IVA_COMANDA & "," & DEPARTAMENT & "," & URGENT & "," & ID_MYDOC & ")" &
                        " VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)")

            .Parameters.Append(ADOPARAM.ToInt(obj.id))
            .Parameters.Append(ADOPARAM.ToInt(obj.idComandaEdicio))
            .Parameters.Append(ADOPARAM.ToString(obj.codi))
            .Parameters.Append(ADOPARAM.ToInt(getInt(obj.empresa)))
            .Parameters.Append(ADOPARAM.ToString(getStr(obj.serie)))
            .Parameters.Append(ADOPARAM.ToInt(getInt(obj.proveidor)))
            .Parameters.Append(ADOPARAM.ToInt(getInt(obj.contacteProveidor)))
            .Parameters.Append(ADOPARAM.ToInt(getInt(obj.projecte)))
            .Parameters.Append(ADOPARAM.ToInt(getInt(obj.contacte)))
            .Parameters.Append(ADOPARAM.ToInt(getInt(obj.magatzem)))
            .Parameters.Append(ADOPARAM.ToDate(obj.data))
            .Parameters.Append(ADOPARAM.ToDate(obj.dataMuntatge))
            .Parameters.Append(ADOPARAM.ToDate(obj.dataEntrega))
            .Parameters.Append(ADOPARAM.ToInt(getStr(obj.inici)))
            .Parameters.Append(ADOPARAM.ToInt(getStr(obj.entregaEquips)))
            .Parameters.Append(ADOPARAM.ToInt(getStr(obj.entrega)))
            .Parameters.Append(ADOPARAM.ToString(getStr(obj.nOferta)))
            .Parameters.Append(ADOPARAM.ToInt(getInt(obj.tipusPagament)))
            .Parameters.Append(ADOPARAM.ToString(getStr(obj.dadesBancaries)))
            .Parameters.Append(ADOPARAM.ToString(getStr(obj.ports)))
            .Parameters.Append(ADOPARAM.ToInt(obj.estat))
            .Parameters.Append(ADOPARAM.ToInt(obj.idSolicitut))
            .Parameters.Append(ADOPARAM.ToInt(obj.responsableCompra.id))
            .Parameters.Append(ADOPARAM.ToSingle(Math.Round(obj.baseComanda * 1000, 0)))
            .Parameters.Append(ADOPARAM.ToSingle(Math.Round(obj.ivaComanda * 1000, 0)))
            .Parameters.Append(ADOPARAM.ToString(obj.departament))
            .Parameters.Append(ADOPARAM.toBool(obj.urgent))
            .Parameters.Append(ADOPARAM.ToInt(obj.idMydoc))
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
    Private Function removeDBF(obj As Comanda, e As Integer) As Boolean
        Dim sc As ADODB.Command
        sc = New ADODB.Command
        With sc
            sc.ActiveConnection = DBCONNECT.getConnectionDbf
            sc.CommandText = " DELETE FROM " & getTable(e) & " WHERE " & ID & "=?"
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
    Private Function getObjectsDBF(a As Integer, e As Integer) As List(Of Comanda)
        Dim rc As ADODB.Recordset, c As Comanda
        rc = New ADODB.Recordset
        Call ModelPedidosMydoc.resetIndex()
        getObjectsDBF = New List(Of Comanda)
        If a > 2000 Then
            rc.Open("Select * FROM " & getTable(e) & " where year(DATAC)=" & a, DBCONNECT.getConnectionDbf)
        Else
            rc.Open("Select * FROM " & getTable(e), DBCONNECT.getConnectionDbf)
        End If

        While Not rc.EOF
            c = New Comanda(rc(ID).Value, CONFIG.validarNull(Trim(rc(CODI).Value)), ModelProveidor.getObject(CInt(rc(ID_PROVEIDOR).Value)), ModelEmpresa.getObject(CInt(rc(ID_EMPRESA).Value)), ModelProjecte.getObject(CInt(rc(ID_PROJECTE).Value)))
            If rc(ID_MYDOC).Value Is Nothing OrElse rc(ID_MYDOC).Value.GetType.Name = "DBNull" Then
                'If rc(ID_MYDOC).Value <= 0 Then
                c.docMyDoc = New PedidoMD
                c.comentaris = New List(Of ComentariMD)
            Else
                c.docMyDoc = ModelPedidosMydoc.getObject(rc(ID_MYDOC).Value)
                c.idMydoc = rc(ID_MYDOC).Value
                If rc(ID_MYDOC).Value > 10000 Then
                    c.comentaris = ModelComentarisMydoc.getObjects(rc(ID_MYDOC).Value)
                End If
            End If
            c.idComandaEdicio = rc(IDCE).Value
            c.contacte = ModelContacte.getObject(CInt(rc(ID_CONTACTE_PROJECTE).Value))
            c.contacteProveidor = ModelProveidorContacte.getObject(rc(ID_CONTACTE_PROVEIDOR).Value)
            c.dadesBancaries = CONFIG.validarNull(rc(DADES_BANCARIES).Value)
            c.data = CONFIG.validarNullDate(rc(DATA_COMANDA).Value)
            c.dataEntrega = CONFIG.validarNullDate(rc(DATA_ENTREGA).Value)
            c.dataMuntatge = CONFIG.validarNullDate(rc(DATA_MUNTATGE).Value)
            c.inici = rc(INICI_COMANDA).Value
            c.magatzem = ModelLlocEntrega.getObject(rc(ID_MAGATZEM).Value)
            c.nOferta = CONFIG.validarNull(rc(OFERTA).Value)
            c.ports = CONFIG.validarNull(rc(PORTS).Value)
            c.entrega = rc(ENTREGA).Value
            c.entregaEquips = rc(INICI_MUNTATGE).Value
            c.tipusPagament = ModelTipusPagament.getAuxiliar.getObject(rc(ID_TIPUS_PAGAMENT).Value)
            c.estat = rc(ESTAT).Value
            c.serie = CONFIG.validarNull(rc(SERIE).Value)
            c.idSolicitut = rc(IDSOLICITUT).Value
            '220516 desactivat xmarti pq tarda molt a carregar-se. Sobretot al carregar tots els articles/solicitut. caldria fer un array de llistes i anar-les carregant a poc a poc.
            'c.solicitutF56 = ModelComandaSolicitud.getObject(c.idSolicitut)
            c.responsableCompra = ModelResponsableCompra.getAuxiliar.getObject(rc(RESPONSABLE_COMPRA).Value)
            c.baseComanda = Math.Round(rc(BASE_COMANDA).Value / 1000, 3)
            c.ivaComanda = Math.Round(rc(IVA_COMANDA).Value / 1000, 3)
            c.departament = CONFIG.validarNull(rc(DEPARTAMENT).Value)
            c.urgent = rc(URGENT).Value

            If e = 2 Then
                c.documentacio = ModelDocumentacio.getObjectsComanda(c.id, c.idComandaEdicio, c.getAnyo)
                c.articles = ModelarticleComanda.getObjects(c.id)
            Else
                c.documentacio = ModelDocumentacio.getObjectsComandaEdicio(c.idComandaEdicio, c.getAnyo)
                c.articles = ModelArticleComandaEnEdicio.getObjects(c.id)
            End If
            getObjectsDBF.Add(c)
            rc.MoveNext()
        End While
        If rc.State = 1 Then rc.Close()
        rc = Nothing
        getObjectsDBF.Sort()
    End Function
    Public Function getObjectsDBFByCodi(pCodi As String, e As Integer, idEmpresa As Integer, anyo As Integer) As List(Of Comanda)
        Dim rc As ADODB.Recordset, c As Comanda
        rc = New ADODB.Recordset
        getObjectsDBFByCodi = New List(Of Comanda)
        If anyo = 0 Then
            If idEmpresa > 0 Then
                rc.Open("Select * FROM " & getTable(e) & " where num = '" & pCodi & "' and IDEMP=" & idEmpresa, DBCONNECT.getConnectionDbf)
            Else
                rc.Open("Select * FROM " & getTable(e) & " where num = '" & pCodi & "'", DBCONNECT.getConnectionDbf)
            End If
        Else
            If idEmpresa > 0 Then
                rc.Open("Select * FROM " & getTable(e) & " where num   ='" & pCodi & "' and IDEMP=" & idEmpresa & " AND SERIE='" & anyo & "' ", DBCONNECT.getConnectionDbf)
            Else
                rc.Open("Select * FROM " & getTable(e) & " where num   ='" & pCodi & "' AND SERIE='" & anyo & "'", DBCONNECT.getConnectionDbf)
            End If
        End If
        While Not rc.EOF
            c = New Comanda(rc(ID).Value, CONFIG.validarNull(Trim(rc(CODI).Value)), ModelProveidor.getObject(CInt(rc(ID_PROVEIDOR).Value)), ModelEmpresa.getObject(CInt(rc(ID_EMPRESA).Value)), ModelProjecte.getObject(CInt(rc(ID_PROJECTE).Value)))
            If rc(ID_MYDOC).Value Is Nothing OrElse rc(ID_MYDOC).Value.GetType.Name = "DBNull" Then
                'If rc(ID_MYDOC).Value <= 0 Then
                c.docMyDoc = New PedidoMD
                c.comentaris = New List(Of ComentariMD)
            Else
                c.docMyDoc = ModelPedidosMydoc.getObject(rc(ID_MYDOC).Value)
                c.idMydoc = rc(ID_MYDOC).Value
                If rc(ID_MYDOC).Value > 10000 Then
                    c.comentaris = ModelComentarisMydoc.getObjects(rc(ID_MYDOC).Value)
                End If
            End If
            c.idComandaEdicio = rc(IDCE).Value
            c.contacte = ModelContacte.getObject(CInt(rc(ID_CONTACTE_PROJECTE).Value))
            c.contacteProveidor = ModelProveidorContacte.getObject(rc(ID_CONTACTE_PROVEIDOR).Value)
            c.dadesBancaries = CONFIG.validarNull(rc(DADES_BANCARIES).Value)
            c.data = CONFIG.validarNullDate(rc(DATA_COMANDA).Value)
            c.dataEntrega = CONFIG.validarNullDate(rc(DATA_ENTREGA).Value)
            c.dataMuntatge = CONFIG.validarNullDate(rc(DATA_MUNTATGE).Value)
            c.inici = rc(INICI_COMANDA).Value
            c.magatzem = ModelLlocEntrega.getObject(rc(ID_MAGATZEM).Value)
            c.nOferta = CONFIG.validarNull(rc(OFERTA).Value)
            c.ports = CONFIG.validarNull(rc(PORTS).Value)
            c.entrega = rc(ENTREGA).Value
            c.entregaEquips = rc(INICI_MUNTATGE).Value
            c.tipusPagament = ModelTipusPagament.getAuxiliar.getObject(rc(ID_TIPUS_PAGAMENT).Value)
            c.estat = rc(ESTAT).Value
            c.serie = CONFIG.validarNull(rc(SERIE).Value)
            c.idSolicitut = rc(IDSOLICITUT).Value
            '220516 desactivat xmarti pq tarda molt a carregar-se. Sobretot al carregar tots els articles/solicitut. caldria fer un array de llistes i anar-les carregant a poc a poc.
            'c.solicitutF56 = ModelComandaSolicitud.getObject(c.idSolicitut)
            c.responsableCompra = ModelResponsableCompra.getAuxiliar.getObject(rc(RESPONSABLE_COMPRA).Value)
            c.baseComanda = Math.Round(rc(BASE_COMANDA).Value / 1000, 3)
            c.ivaComanda = Math.Round(rc(IVA_COMANDA).Value / 1000, 3)
            c.departament = CONFIG.validarNull(rc(DEPARTAMENT).Value)
            c.urgent = rc(URGENT).Value
            If e = 2 Then
                c.documentacio = ModelDocumentacio.getObjectsComanda(c.id, c.idComandaEdicio, c.getAnyo)
                c.articles = ModelarticleComanda.getObjects(c.id)
            Else
                c.documentacio = ModelDocumentacio.getObjectsComandaEdicio(c.id, c.getAnyo)
                c.articles = ModelArticleComandaEnEdicio.getObjects(c.id)
            End If
            getObjectsDBFByCodi.Add(c)
            rc.MoveNext()
        End While
        If rc.State = 1 Then rc.Close()
        rc = Nothing
        getObjectsDBFByCodi.Sort()
    End Function
    ''' <summary>
    ''' Obté tots els centres del sistema 
    ''' </summary>
    ''' <returns>una llista de centres</returns>
    Private Function existDBF(id As Integer, p As Object, e As Integer) As Boolean
        Dim rc As ADODB.Recordset, camp As String
        camp = getCamp(p)
        existDBF = False
        If camp <> "" Then
            rc = New ADODB.Recordset
            rc.Open("Select top 1 * FROM " & getTable(e) & " where " & camp & "=" & id, DBCONNECT.getConnectionDbf)
            If Not rc.EOF Then existDBF = True
            If rc.State = 1 Then rc.Close()
            rc = Nothing
        End If
    End Function
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

    Private Function getTable(estat As Integer) As String
        If estat = 2 Then
            Return DBCONNECT.getTaulaComanda
        Else
            Return DBCONNECT.getTaulaComandaEdicio
        End If

    End Function
    Private Function getCamp(p As Object) As String
        Select Case p.GetType.Name
            Case "Proveidor" : Return ID_PROVEIDOR
            Case "ProveidorCont" : Return ID_CONTACTE_PROVEIDOR
            Case "Contacte" : Return ID_CONTACTE_PROJECTE
            Case "LlocEntrega" : Return ID_MAGATZEM
            Case "Projecte" : Return ID_PROJECTE
            Case "Empresa" : Return ID_EMPRESA
        End Select
        Return ""
    End Function
    'Right(_serie, 2) & "-" & codiToString() & "-" & Right(_codiProjecte, 4) & "-" & CONFIG.getDosDigits(idEmpresa)
End Module

