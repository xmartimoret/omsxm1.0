﻿Option Explicit On
Imports System.Data.SqlClient
Module dbComandaEnEdicio
    Private Const ID As String = "ID"
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
    Private Const RETENCIO As String = "RET"
    Private Const AVAL As String = "AVAL"
    Private Const OFERTA As String = "OFERTA"
    Private Const ID_TIPUS_PAGAMENT As String = "IDPAGO"
    Private Const DADES_BANCARIES As String = "BANC"
    Private Const PORTS As String = "PORTS"
    Private Const NOTES As String = "notes"
    Private Const RESPONSABLE As String = "RESPON"
    Private Const DIRECTOR As String = "DIRECTO"
    Private Const ESTAT As String = "ESTAT"
    'ACCESSORS CENTRE
    ''' <summary>
    ''' SAVE. Guarda un centre a la base de dades. 
    ''' Si es nou, fa una inserció si no  actualitza.
    ''' </summary>
    ''' <param name="obj"> centre</param>
    ''' <returns>identificador del centre.</returns>
    Public Function update(obj As Comanda) As Integer
        If IS_SQLSERVER() Then Return updateSQL(obj)
        Return updateDBF(obj)
    End Function
    Public Function insert(obj As Comanda) As Integer
        If IS_SQLSERVER() Then Return insertSQL(obj)
        Return insertDBF(obj)
    End Function
    Public Function remove(obj As Comanda) As Boolean
        If IS_SQLSERVER() Then Return removeSQL(obj)
        Return removeDBF(obj)
    End Function
    Public Function getObjects() As List(Of Comanda)
        If IS_SQLSERVER() Then Return getObjectsSQL()
        Return getObjectsDBF()
    End Function

    Private Function updateSQL(obj As Comanda) As Integer
        Dim sc As SqlCommand, i As Integer
        sc = New SqlCommand("UPDATE " & getTable() & " " &
                            " SET " & CODI & "=@codi," &
                                      ID_EMPRESA & " =@idEmpresa, " &
                                      ID_PROVEIDOR & " =@idProveidor, " &
                                      ID_CONTACTE_PROVEIDOR & " =@IdContacteProveidor, " &
                                      ID_PROJECTE & " =@idProjecte, " &
                                      ID_CONTACTE_PROJECTE & " =@idContacteprojecte, " &
                                      ID_MAGATZEM & " =@idMagatzem, " &
                                      DATA_COMANDA & " =@dataComanda, " &
                                      DATA_MUNTATGE & " =@dataMuntatge, " &
                                      DATA_ENTREGA & " =@dataentrega, " &
                                      RETENCIO & " =@retencio, " &
                                      AVAL & " =@aval, " &
                                      OFERTA & " =@oferta, " &
                                      ID_TIPUS_PAGAMENT & " =@idTipusPagament, " &
                                      DADES_BANCARIES & " =@dadesBancaries, " &
                                      PORTS & " =@ports, " &
                                      NOTES & " =@notes, " &
                                      RESPONSABLE & " =@responsable, " &
                                      DIRECTOR & " =@director, " &
                                      ESTAT & " =@estat " &
                                      " WHERE " & ID & "=@id", DBCONNECT.getConnection)
        sc.Parameters.Add("@id", SqlDbType.Int).Value = obj.id
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
        sc.Parameters.Add("@retencio", SqlDbType.VarChar).Value = obj.retencio
        sc.Parameters.Add("@aval", SqlDbType.VarChar).Value = obj.interAval
        sc.Parameters.Add("@oferta", SqlDbType.VarChar).Value = obj.nOferta
        sc.Parameters.Add("@idTipusPagament", SqlDbType.SmallInt).Value = obj.tipusPagament.id
        sc.Parameters.Add("@dadesBancaries", SqlDbType.VarChar).Value = obj.dadesBancaries
        sc.Parameters.Add("@ports", SqlDbType.VarChar).Value = obj.ports
        sc.Parameters.Add("@notes", SqlDbType.VarChar).Value = obj.notes
        sc.Parameters.Add("@responsable", SqlDbType.VarChar).Value = obj.responsable
        sc.Parameters.Add("@director", SqlDbType.VarChar).Value = obj.director
        sc.Parameters.Add("@estat", SqlDbType.Int).Value = obj.estat
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
    Private Function insertSQL(obj As Comanda) As Integer
        Dim sc As SqlCommand, i As Integer
        obj.id = DBCONNECT.getMaxId(getTable) + 1
        sc = New SqlCommand(" INSERT INTO " & getTable() & " " &
                        " (" & ID & ", " & CODI & ", " & ID_EMPRESA & ", " & ID_PROVEIDOR & ", " & ID_CONTACTE_PROVEIDOR & ", " & ID_PROJECTE & ", " & ID_CONTACTE_PROJECTE & ", " & ID_MAGATZEM & "," &
                         DATA_COMANDA & "," & DATA_MUNTATGE & "," & DATA_ENTREGA & "," & RETENCIO & "," & AVAL & "," & OFERTA & "," & ID_TIPUS_PAGAMENT & "," & DADES_BANCARIES & "," & PORTS & "," & NOTES & "," & RESPONSABLE & "," & DIRECTOR & "," & ESTAT & ")" &
                        " VALUES(@id,@codi,@idEmpresa,@idProveidor,@idContacteProveidor,@idProjecte,@idContacteProjecte,@idMagatzem,@dataComanda,@dataMuntatge,@dataEntrega,@retencio,@aval,@oferta,@idtipusPagament,@dadesBancaries,@ports,@notes,@responsable,@director,@estat)", DBCONNECT.getConnection)
        sc.Parameters.Add("@id", SqlDbType.Int).Value = obj.id
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
        sc.Parameters.Add("@retencio", SqlDbType.VarChar).Value = obj.retencio
        sc.Parameters.Add("@aval", SqlDbType.VarChar).Value = obj.interAval
        sc.Parameters.Add("@oferta", SqlDbType.VarChar).Value = obj.nOferta
        sc.Parameters.Add("@idTipusPagament", SqlDbType.SmallInt).Value = obj.tipusPagament.id
        sc.Parameters.Add("@dadesBancaries", SqlDbType.VarChar).Value = obj.dadesBancaries
        sc.Parameters.Add("@ports", SqlDbType.VarChar).Value = obj.ports
        sc.Parameters.Add("@notes", SqlDbType.VarChar).Value = obj.notes
        sc.Parameters.Add("@responsable", SqlDbType.VarChar).Value = obj.responsable
        sc.Parameters.Add("@director", SqlDbType.VarChar).Value = obj.director
        sc.Parameters.Add("@estat", SqlDbType.Int).Value = obj.estat
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
    Private Function removeSQL(obj As Comanda) As Boolean
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
    Private Function getObjectsSQL() As List(Of Comanda)
        Dim sc As SqlCommand, sdr As SqlDataReader, c As Comanda
        getObjectsSQL = New List(Of Comanda)
        sc = New SqlCommand("Select * FROM " & getTable(), getConnection)
        sdr = sc.ExecuteReader
        While sdr.Read()
            c = New Comanda(sdr(ID), CONFIG.validarNull(Trim(sdr(CODI))), ModelProveidor.getObject(sdr(ID_PROVEIDOR)), ModelEmpresa.getObject(sdr(ID_EMPRESA)), ModelProjecte.getObject(sdr(ID_PROJECTE)))
            'TODO CAL IMPLEMENTAR ARTICLES COMANDA 
            'c.articles = modela
            c.contacte = ModelContacte.getObject(sdr(ID_CONTACTE_PROJECTE))
            c.contacteProveidor = ModelProveidorContacte.getObject(sdr(ID_CONTACTE_PROVEIDOR))
            c.dadesBancaries = CONFIG.validarNull(Trim(sdr(DADES_BANCARIES)))
            c.data = CONFIG.validarNull(Trim(sdr(DATA_COMANDA)))
            c.dataEntrega = CONFIG.validarNull(Trim(sdr(DATA_ENTREGA)))
            c.dataMuntatge = CONFIG.validarNull(Trim(sdr(DATA_MUNTATGE)))
            c.interAval = CONFIG.validarNull(Trim(sdr(AVAL)))
            c.magatzem = ModelLlocEntrega.getObject(sdr(ID_MAGATZEM))
            c.nOferta = CONFIG.validarNull(Trim(sdr(OFERTA)))
            c.notes = CONFIG.validarNull(Trim(sdr(NOTES)))
            c.ports = CONFIG.validarNull(Trim(sdr(PORTS)))
            c.retencio = CONFIG.validarNull(Trim(sdr(RETENCIO)))
            c.tipusPagament = ModelTipusPagament.getAuxiliar.getObject(sdr(ID_TIPUS_PAGAMENT))
            c.responsable = CONFIG.validarNull(sdr(RESPONSABLE))
            c.director = CONFIG.validarNull(sdr(DIRECTOR))
            c.estat = sdr(ESTAT)
            getObjectsSQL.Add(c)
        End While
        sdr.Close()
        getObjectsSQL.Sort()
        sdr = Nothing
        sc = Nothing
    End Function

    Private Function updateDBF(obj As Comanda) As Integer
        Dim sc As ADODB.Command
        sc = New ADODB.Command
        With sc
            .ActiveConnection = DBCONNECT.getConnectionDbf
            .CommandText = "UPDATE " & getTable() & " " &
                            " SET " & CODI & "=?," &
                                      ID_EMPRESA & " =?, " &
                                      ID_PROVEIDOR & " =?, " &
                                      ID_CONTACTE_PROVEIDOR & " =?, " &
                                      ID_PROJECTE & " =?, " &
                                      ID_CONTACTE_PROJECTE & " =?, " &
                                      ID_MAGATZEM & " =?, " &
                                      DATA_COMANDA & " =?, " &
                                      DATA_MUNTATGE & " =?, " &
                                      DATA_ENTREGA & " =?, " &
                                      RETENCIO & " =?, " &
                                      AVAL & " =?, " &
                                      OFERTA & " =?, " &
                                      ID_TIPUS_PAGAMENT & " =?, " &
                                      DADES_BANCARIES & " =?, " &
                                      PORTS & " =?, " &
                                      NOTES & " =?, " &
                                      RESPONSABLE & " =?, " &
                                      DIRECTOR & " =?, " &
                                      ESTAT & " =? " &
                                      " WHERE " & ID & "=?"
            .Parameters.Append(ADOPARAM.ToString(obj.codi))
            .Parameters.Append(ADOPARAM.ToInt(getInt(obj.empresa)))
            .Parameters.Append(ADOPARAM.ToInt(getInt(obj.proveidor)))
            .Parameters.Append(ADOPARAM.ToInt(getInt(obj.contacteProveidor)))
            .Parameters.Append(ADOPARAM.ToInt(getInt(obj.projecte)))
            .Parameters.Append(ADOPARAM.ToInt(getInt(obj.contacte)))
            .Parameters.Append(ADOPARAM.ToInt(getInt(obj.magatzem)))
            .Parameters.Append(ADOPARAM.ToDate(obj.data))
            .Parameters.Append(ADOPARAM.ToDate(obj.dataMuntatge))
            .Parameters.Append(ADOPARAM.ToDate(obj.dataEntrega))
            .Parameters.Append(ADOPARAM.ToString(getStr(obj.retencio)))
            .Parameters.Append(ADOPARAM.ToString(getStr(obj.interAval)))
            .Parameters.Append(ADOPARAM.ToString(getStr(obj.nOferta)))
            .Parameters.Append(ADOPARAM.ToInt(getInt(obj.tipusPagament)))
            .Parameters.Append(ADOPARAM.ToString(getStr(obj.dadesBancaries)))
            .Parameters.Append(ADOPARAM.ToString(getStr(obj.ports)))
            .Parameters.Append(ADOPARAM.ToString(getStr(obj.notes)))
            .Parameters.Append(ADOPARAM.ToString(getStr(obj.responsable)))
            .Parameters.Append(ADOPARAM.ToString(getStr(obj.director)))
            .Parameters.Append(ADOPARAM.ToInt(obj.estat))
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
    Private Function insertDBF(obj As Comanda) As Integer
        Dim sc As ADODB.Command
        sc = New ADODB.Command
        obj.id = DBCONNECT.getMaxIdDBF(getTable) + 1
        With sc
            .ActiveConnection = DBCONNECT.getConnectionDbf
            .CommandText = (" INSERT INTO " & getTable() & " " &
                        " (" & ID & ", " & CODI & ", " & ID_EMPRESA & ", " & ID_PROVEIDOR & ", " & ID_CONTACTE_PROVEIDOR & ", " & ID_PROJECTE & ", " & ID_CONTACTE_PROJECTE & ", " & ID_MAGATZEM & "," &
                         DATA_COMANDA & "," & DATA_MUNTATGE & "," & DATA_ENTREGA & "," & RETENCIO & "," & AVAL & "," & OFERTA & "," & ID_TIPUS_PAGAMENT & "," & DADES_BANCARIES & "," & PORTS & "," & NOTES & "," & RESPONSABLE & "," & DIRECTOR & "," & ESTAT & ")" &
                        " VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)")

            .Parameters.Append(ADOPARAM.ToInt(obj.id))
            .Parameters.Append(ADOPARAM.ToString(obj.codi))
            .Parameters.Append(ADOPARAM.ToInt(getInt(obj.empresa)))
            .Parameters.Append(ADOPARAM.ToInt(getInt(obj.proveidor)))
            .Parameters.Append(ADOPARAM.ToInt(getInt(obj.contacteProveidor)))
            .Parameters.Append(ADOPARAM.ToInt(getInt(obj.projecte)))
            .Parameters.Append(ADOPARAM.ToInt(getInt(obj.contacte)))
            .Parameters.Append(ADOPARAM.ToInt(getInt(obj.magatzem)))
            .Parameters.Append(ADOPARAM.ToDate(obj.data))
            .Parameters.Append(ADOPARAM.ToDate(obj.dataMuntatge))
            .Parameters.Append(ADOPARAM.ToDate(obj.dataEntrega))
            .Parameters.Append(ADOPARAM.ToString(getStr(obj.retencio)))
            .Parameters.Append(ADOPARAM.ToString(getStr(obj.interAval)))
            .Parameters.Append(ADOPARAM.ToString(getStr(obj.nOferta)))
            .Parameters.Append(ADOPARAM.ToInt(getInt(obj.tipusPagament)))
            .Parameters.Append(ADOPARAM.ToString(getStr(obj.dadesBancaries)))
            .Parameters.Append(ADOPARAM.ToString(getStr(obj.ports)))
            .Parameters.Append(ADOPARAM.ToString(getStr(obj.notes)))
            .Parameters.Append(ADOPARAM.ToString(getStr(obj.responsable)))
            .Parameters.Append(ADOPARAM.ToString(getStr(obj.director)))
            .Parameters.Append(ADOPARAM.ToInt(obj.estat))
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
    Private Function removeDBF(obj As Comanda) As Boolean
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
    Private Function getObjectsDBF() As List(Of Comanda)
        Dim rc As ADODB.Recordset, c As Comanda
        rc = New ADODB.Recordset
        getObjectsDBF = New List(Of Comanda)
        rc.Open("Select * FROM " & getTable(), DBCONNECT.getConnectionDbf)
        While Not rc.EOF
            c = New Comanda(rc(ID).Value, CONFIG.validarNull(Trim(rc(CODI).Value)), ModelProveidor.getObject(CInt(rc(ID_PROVEIDOR).Value)), ModelEmpresa.getObject(CInt(rc(ID_EMPRESA).Value)), ModelProjecte.getObject(CInt(rc(ID_PROJECTE).Value)))
            'TODO CAL IMPLEMENTAR ARTICLES COMANDA 

            c.contacte = ModelContacte.getObject(CInt(rc(ID_CONTACTE_PROJECTE).Value))
            c.contacteProveidor = ModelProveidorContacte.getObject(rc(ID_CONTACTE_PROVEIDOR).Value)
            c.dadesBancaries = Trim(CONFIG.validarNull(rc(DADES_BANCARIES).Value))
            c.data = Trim(CONFIG.validarNull(rc(DATA_COMANDA).Value))
            c.dataEntrega = Trim(CONFIG.validarNull(rc(DATA_ENTREGA).Value))
            c.dataMuntatge = Trim(CONFIG.validarNull(rc(DATA_MUNTATGE).Value))
            c.interAval = Trim(CONFIG.validarNull(rc(AVAL).Value))
            c.magatzem = ModelLlocEntrega.getObject(rc(ID_MAGATZEM).Value)
            c.nOferta = Trim(CONFIG.validarNull(rc(OFERTA).Value))
            c.notes = Trim(CONFIG.validarNull(rc(NOTES).Value))
            c.ports = Trim(CONFIG.validarNull(rc(PORTS).Value))
            c.retencio = Trim(CONFIG.validarNull(rc(RETENCIO).Value))
            c.tipusPagament = ModelTipusPagament.getAuxiliar.getObject(rc(ID_TIPUS_PAGAMENT).Value)
            c.responsable = CONFIG.validarNull(rc(RESPONSABLE).Value)
            c.director = CONFIG.validarNull(rc(DIRECTOR).Value)
            c.estat = rc(ESTAT).Value
            getObjectsDBF.Add(c)
            rc.MoveNext()
        End While
        If rc.State = 1 Then rc.Close()
        rc = Nothing
        getObjectsDBF.Sort()
    End Function
    Private Function getInt(p As Object) As Integer
        If IsNothing(p) Then Return -1
        Return p.id
    End Function
    Private Function getStr(p As String) As String
        If IsNothing(p) Then Return ""
        Return p
    End Function

    Private Function getTable() As String
        Return DBCONNECT.getTaulaComandaEdicio
    End Function
End Module
