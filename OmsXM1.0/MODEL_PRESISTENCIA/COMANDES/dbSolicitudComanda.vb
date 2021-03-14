Option Explicit On
Imports System.Data.SqlClient
Module dbSolicitudComanda
    Private Const ID As String = "ID"
    Private Const CODI As String = "NUM"
    Private Const DATA_COMANDA As String = "DATAC"
    Private Const NOM As String = "FITXER"
    Private Const SERIE As String = "SERIE"
    Private Const EMPRESA As String = "EMPRESA"
    Private Const CODI_PROJECTE As String = "PROJECT"
    Private Const DEPARTAMENT As String = "DEPARTA"
    Private Const ID_PROVEIDOR As String = "IDPROV"
    Private Const PROVEIDOR As String = "PROVEID"
    Private Const CONTACTE_PROVEIDOR As String = "CONTACTP"
    Private Const TELEFON_PROVEIDOR As String = "TELP"
    Private Const EMAIL_PROVEIDOR As String = "EMAILP"
    Private Const SUMINISTRE_MATERIAL As String = "SMAT"
    Private Const EMBALATGE As String = "EMB"
    Private Const TRANSPORT As String = "TRANS"
    Private Const MUNTATGE As String = "MUNT"
    Private Const SUPERVISIO As String = "SUPERV"
    Private Const POSTA_PUNT As String = "POSTA"
    Private Const PROVES_TALLER As String = "PROVT"
    Private Const PROVES_OBRA As String = "PROVO"
    Private Const POSTA_SERVEI As String = "POSTS"
    Private Const ALTRES_ALCANS As String = "ALTRAL"
    Private Const LLOC_ENTREGA As String = "LLOCENT"
    Private Const DIRECCIO_ENTREGA As String = "DIRENT"
    Private Const CONTACTE_ENTREGA As String = "CONTENT"
    Private Const TELEFON_ENTREGA As String = "TELENT"
    Private Const DATA_ENTREGA As String = "DATAENT"
    Private Const DATA_FINALITZACIO As String = "DATAFI"
    Private Const OFERTA1 As String = "OF1"
    Private Const OFERTA2 As String = "OF2"
    Private Const OFERTA3 As String = "OF3"
    Private Const COMPARATIU As String = "COMPAR"
    Private Const FORMA_PAGAMENT As String = "FPAG"
    Private Const VALTRES As String = "ALTRA"
    Private Const ESTAT As String = "ESTAT"

    'ACCESSORS CENTRE
    ''' <summary>
    ''' SAVE. Guarda un centre a la base de dades. 
    ''' Si es nou, fa una inserció si no  actualitza.
    ''' </summary>
    ''' <param name="obj"> centre</param>
    ''' <returns>identificador del centre.</returns>
    Public Function update(obj As SolicitudComanda) As Integer
        If IS_SQLSERVER() Then Return updateSQL(obj)
        Return updateDBF(obj)
    End Function
    Public Function insert(obj As SolicitudComanda) As Integer
        If IS_SQLSERVER() Then Return insertSQL(obj)
        Return insertDBF(obj)
    End Function
    Public Function remove(obj As SolicitudComanda) As Boolean
        If IS_SQLSERVER() Then Return removeSQL(obj)
        Return removeDBF(obj)
    End Function
    Public Function getObjects(estat As Integer) As List(Of SolicitudComanda)
        If IS_SQLSERVER() Then Return getObjectsSQL(estat)
        Return getObjectsDBF(estat)
    End Function
    Public Function getObjects(serie As String) As List(Of SolicitudComanda)
        If IS_SQLSERVER() Then Return getObjectsSQL(ESTAT)
        Return getObjectsDBF(ESTAT)
    End Function
    Private Function updateSQL(obj As SolicitudComanda) As Integer
        Dim sc As SqlCommand, i As Integer
        sc = New SqlCommand("UPDATE " & getTable() & " " &
                        " SET " & CODI & " =@codi, " &
                                NOM & " =@nom, " &
                                SERIE & " =@serie, " &
                                EMPRESA & " =@empresa, " &
                                CODI_PROJECTE & " =@codi_projecte, " &
                                DEPARTAMENT & " =@departament, " &
                                PROVEIDOR & " =@proveidor, " &
                                CONTACTE_PROVEIDOR & " =@contacte_proveidor, " &
                                TELEFON_PROVEIDOR & " =@telefon_proveidor, " &
                                EMAIL_PROVEIDOR & " =@email_proveidor, " &
                                SUMINISTRE_MATERIAL & " =@suministre_material, " &
                                EMBALATGE & " =@embalatge, " &
                                TRANSPORT & " =@transport, " &
                                MUNTATGE & " =@muntatge, " &
                                SUPERVISIO & " =@supervisio, " &
                                POSTA_PUNT & " =@posta_punt, " &
                                PROVES_TALLER & " =@proves_taller, " &
                                PROVES_OBRA & " =@proves_obra, " &
                                POSTA_SERVEI & " =@posta_servei, " &
                                ALTRES_ALCANS & " =@altres_alcans, " &
                                LLOC_ENTREGA & " =@lloc_entrega, " &
                                DIRECCIO_ENTREGA & " =@direccio_entrega, " &
                                CONTACTE_ENTREGA & " =@contacte_entrega, " &
                                TELEFON_ENTREGA & " =@telefon_entrega, " &
                                DATA_ENTREGA & " =@data_entrega, " &
                                DATA_FINALITZACIO & " =@data_finalitzacio, " &
                                OFERTA1 & " =@oferta1, " &
                                OFERTA2 & " =@oferta2, " &
                                OFERTA3 & " =@oferta3, " &
                                COMPARATIU & " =@comparatiu, " &
                                FORMA_PAGAMENT & " =@forma_pagament, " &
                                VALTRES & " =@valtres, " &
                                ID_PROVEIDOR & " =@idProveidor, " &
                                DATA_COMANDA & " =@dataComanda, " &
                                ESTAT & " =@estat " &
                                " WHERE " & ID & "=@id", DBCONNECT.getConnection)
        sc.Parameters.Add("@id", SqlDbType.Int).Value = obj.id
        sc.Parameters.Add("@codi", SqlDbType.Int).Value = obj.codi
        sc.Parameters.Add("@nom", SqlDbType.Char).Value = obj.NOM
        sc.Parameters.Add("@serie", SqlDbType.Char).Value = obj.serie
        sc.Parameters.Add("@empresa", SqlDbType.Char).Value = obj.empresa
        sc.Parameters.Add("@codi_projecte", SqlDbType.Char).Value = obj.codiProjecte
        sc.Parameters.Add("@departament", SqlDbType.Char).Value = obj.departament
        sc.Parameters.Add("@proveidor", SqlDbType.Char).Value = obj.proveidor
        sc.Parameters.Add("@departament_proveidor", SqlDbType.Char).Value = obj.contacteProveidor
        sc.Parameters.Add("@telefon_proveidor", SqlDbType.Char).Value = obj.telefonProveidor
        sc.Parameters.Add("@email_proveidor", SqlDbType.Char).Value = obj.emailProveidor
        sc.Parameters.Add("@suministre_material", SqlDbType.Bit).Value = obj.suministreMaterial
        sc.Parameters.Add("@embalatge", SqlDbType.Bit).Value = obj.embalatge
        sc.Parameters.Add("@transport", SqlDbType.Bit).Value = obj.transport
        sc.Parameters.Add("@muntatge", SqlDbType.Bit).Value = obj.muntatge
        sc.Parameters.Add("@supervisio", SqlDbType.Bit).Value = obj.supervisio
        sc.Parameters.Add("@posta_punt", SqlDbType.Bit).Value = obj.postaApunt
        sc.Parameters.Add("@proves_taller", SqlDbType.Bit).Value = obj.provesTaller
        sc.Parameters.Add("@proves_obra", SqlDbType.Bit).Value = obj.provesObra
        sc.Parameters.Add("@posta_servei", SqlDbType.Bit).Value = obj.postaServei
        sc.Parameters.Add("@altres_alcans", SqlDbType.Bit).Value = obj.altresAlcans
        sc.Parameters.Add("@lloc_entrega", SqlDbType.Char).Value = obj.llocEntrega
        sc.Parameters.Add("@direccio_entrega", SqlDbType.Char).Value = obj.direccioEntrega
        sc.Parameters.Add("@contacte_entrega", SqlDbType.Char).Value = obj.contacteEntrega
        sc.Parameters.Add("@telefon_entrega", SqlDbType.Char).Value = obj.telefonEntrega
        sc.Parameters.Add("@data_entrega", SqlDbType.Date).Value = obj.dataEntrega
        sc.Parameters.Add("@data_finalitzacio", SqlDbType.Date).Value = obj.dataFinalitzacio
        sc.Parameters.Add("@oferta1", SqlDbType.Char).Value = obj.oferta1
        sc.Parameters.Add("@oferta2", SqlDbType.Char).Value = obj.oferta2
        sc.Parameters.Add("@oferta3", SqlDbType.Char).Value = obj.oferta3
        sc.Parameters.Add("@comparatiu", SqlDbType.Char).Value = obj.comparatiu
        sc.Parameters.Add("@forma_pagament", SqlDbType.Char).Value = obj.formaPagament
        sc.Parameters.Add("@valtres", SqlDbType.Char).Value = obj.altresDocumentacio
        sc.Parameters.Add("@idProveidor", SqlDbType.Int).Value = obj.idProveidor
        sc.Parameters.Add("@dataComanda", SqlDbType.Int).Value = obj.dataComanda
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
    Private Function insertSQL(obj As SolicitudComanda) As Integer
        Dim sc As SqlCommand, i As Integer
        obj.id = DBCONNECT.getMaxId(getTable) + 1
        sc = New SqlCommand(" INSERT INTO " & getTable() & " " &
                    " ( " & ID & "," & DATA_COMANDA & "," & ESTAT & "," & ID_PROVEIDOR & "," & CODI & "," & NOM & "," & SERIE & "," & EMPRESA & "," & CODI_PROJECTE & "," & DEPARTAMENT & "," & PROVEIDOR & "," & CONTACTE_PROVEIDOR & "," & TELEFON_PROVEIDOR & "," & EMAIL_PROVEIDOR & "," & SUMINISTRE_MATERIAL & "," & EMBALATGE & "," & TRANSPORT & "," & MUNTATGE & "," & SUPERVISIO & "," & POSTA_PUNT & "," & PROVES_TALLER & "," & PROVES_OBRA & "," & POSTA_SERVEI & "," & ALTRES_ALCANS & "," & LLOC_ENTREGA & "," & DIRECCIO_ENTREGA & "," & CONTACTE_ENTREGA & "," & TELEFON_ENTREGA & "," & DATA_ENTREGA & "," & DATA_FINALITZACIO & "," & OFERTA1 & "," & OFERTA2 & "," & OFERTA3 & "," & COMPARATIU & "," & FORMA_PAGAMENT & "," & VALTRES & ")" &
              " VALUES(@id,@estat,@dataComanda,@idProveidor,@codi,@nom,@serie,@empresa,@codi_projecte,@departament,@proveidor,@contacte_proveidor,@telefon_proveidor,@email_proveidor,@suministre_material,@embalatge,@transport,@muntatge,@supervisio,@posta_punt,@proves_taller,@proves_obra,@posta_servei,@altres_alcans,@lloc_entrega,@direccio_entrega,@contacte_entrega,@telefon_entrega,@data_entrega,@data_finalitzacio,@oferta1,@oferta2,@oferta3,@comparatiu,@forma_pagament,@valtres)", DBCONNECT.getConnection)
        sc.Parameters.Add("@id", SqlDbType.Int).Value = obj.id
        sc.Parameters.Add("@dataComanda", SqlDbType.Int).Value = obj.dataComanda
        sc.Parameters.Add("@estat", SqlDbType.Int).Value = obj.estat
        sc.Parameters.Add("@idProveidor", SqlDbType.Int).Value = obj.idProveidor
        sc.Parameters.Add("@codi", SqlDbType.Int).Value = obj.codi
        sc.Parameters.Add("@nom", SqlDbType.Char).Value = obj.nom
        sc.Parameters.Add("@serie", SqlDbType.Char).Value = obj.serie
        sc.Parameters.Add("@empresa", SqlDbType.Char).Value = obj.empresa
        sc.Parameters.Add("@codi_projecte", SqlDbType.Char).Value = obj.codiProjecte
        sc.Parameters.Add("@departament", SqlDbType.Char).Value = obj.departament
        sc.Parameters.Add("@proveidor", SqlDbType.Char).Value = obj.proveidor
        sc.Parameters.Add("@departament_proveidor", SqlDbType.Char).Value = obj.contacteProveidor
        sc.Parameters.Add("@telefon_proveidor", SqlDbType.Char).Value = obj.telefonProveidor
        sc.Parameters.Add("@email_proveidor", SqlDbType.Char).Value = obj.emailProveidor
        sc.Parameters.Add("@suministre_material", SqlDbType.Bit).Value = obj.suministreMaterial
        sc.Parameters.Add("@embalatge", SqlDbType.Bit).Value = obj.embalatge
        sc.Parameters.Add("@transport", SqlDbType.Bit).Value = obj.transport
        sc.Parameters.Add("@muntatge", SqlDbType.Bit).Value = obj.muntatge
        sc.Parameters.Add("@supervisio", SqlDbType.Bit).Value = obj.supervisio
        sc.Parameters.Add("@posta_punt", SqlDbType.Bit).Value = obj.postaApunt
        sc.Parameters.Add("@proves_taller", SqlDbType.Bit).Value = obj.provesTaller
        sc.Parameters.Add("@proves_obra", SqlDbType.Bit).Value = obj.provesObra
        sc.Parameters.Add("@posta_servei", SqlDbType.Bit).Value = obj.postaServei
        sc.Parameters.Add("@altres_alcans", SqlDbType.Bit).Value = obj.altresAlcans
        sc.Parameters.Add("@lloc_entrega", SqlDbType.Char).Value = obj.llocEntrega
        sc.Parameters.Add("@direccio_entrega", SqlDbType.Char).Value = obj.direccioEntrega
        sc.Parameters.Add("@contacte_entrega", SqlDbType.Char).Value = obj.contacteEntrega
        sc.Parameters.Add("@telefon_entrega", SqlDbType.Char).Value = obj.telefonEntrega
        sc.Parameters.Add("@data_entrega", SqlDbType.Date).Value = obj.dataEntrega
        sc.Parameters.Add("@data_finalitzacio", SqlDbType.Date).Value = obj.dataFinalitzacio
        sc.Parameters.Add("@oferta1", SqlDbType.Char).Value = obj.oferta1
        sc.Parameters.Add("@oferta2", SqlDbType.Char).Value = obj.oferta2
        sc.Parameters.Add("@oferta3", SqlDbType.Char).Value = obj.oferta3
        sc.Parameters.Add("@comparatiu", SqlDbType.Char).Value = obj.comparatiu
        sc.Parameters.Add("@forma_pagament", SqlDbType.Char).Value = obj.formaPagament
        sc.Parameters.Add("@valtres", SqlDbType.Char).Value = obj.altresDocumentacio
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
    Private Function removeSQL(obj As SolicitudComanda) As Boolean
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
    Private Function getObjectsSQL(p As Integer) As List(Of SolicitudComanda)
        Dim sc As SqlCommand, sdr As SqlDataReader, c As SolicitudComanda
        getObjectsSQL = New List(Of SolicitudComanda)
        sc = New SqlCommand("Select * FROM " & getTable() & " where " & ESTAT & "=" & p, getConnection)
        sdr = sc.ExecuteReader
        While sdr.Read()
            c = New SolicitudComanda(sdr(ID), sdr(CODI), sdr(NOM), sdr(ESTAT))
            c.altresAlcans = sdr(ALTRES_ALCANS)
            c.altresDocumentacio = sdr(VALTRES)
            c.codiProjecte = sdr(CODI_PROJECTE)
            c.comparatiu = sdr(COMPARATIU)
            c.contacteEntrega = sdr(CONTACTE_ENTREGA)
            c.dataFinalitzacio = sdr(DATA_FINALITZACIO)
            c.departament = sdr(DEPARTAMENT)
            c.direccioEntrega = sdr(DIRECCIO_ENTREGA)
            c.emailProveidor = sdr(EMAIL_PROVEIDOR)
            c.embalatge = sdr(EMBALATGE)
            c.empresa = sdr(EMPRESA)
            c.formaPagament = sdr(FORMA_PAGAMENT)
            c.llocEntrega = sdr(LLOC_ENTREGA)
            c.muntatge = sdr(MUNTATGE)
            c.oferta1 = sdr(OFERTA1)
            c.oferta2 = sdr(OFERTA2)
            c.oferta3 = sdr(OFERTA3)
            c.postaApunt = sdr(POSTA_PUNT)
            c.postaServei = sdr(POSTA_SERVEI)
            c.proveidor = sdr(PROVEIDOR)
            c.provesObra = sdr(PROVES_OBRA)
            c.provesTaller = sdr(PROVES_TALLER)
            c.serie = sdr(SERIE)
            c.suministreMaterial = sdr(SUMINISTRE_MATERIAL)
            c.supervisio = sdr(SUPERVISIO)
            c.telefonEntrega = sdr(TELEFON_ENTREGA)
            c.telefonProveidor = sdr(TELEFON_PROVEIDOR)
            c.transport = sdr(TRANSPORT)
            c.idProveidor = sdr(ID_PROVEIDOR)
            c.dataComanda = sdr(DATA_COMANDA)
            getObjectsSQL.Add(c)
        End While
        sdr.Close()
        getObjectsSQL.Sort()
        sdr = Nothing
        sc = Nothing
    End Function
    Private Function getObjectsSQL(p As String) As List(Of SolicitudComanda)
        Dim sc As SqlCommand, sdr As SqlDataReader, c As SolicitudComanda
        getObjectsSQL = New List(Of SolicitudComanda)
        sc = New SqlCommand("Select * FROM " & getTable() & " where " & SERIE & "='" & p & "'", getConnection)
        sdr = sc.ExecuteReader
        While sdr.Read()
            c = New SolicitudComanda(sdr(ID), sdr(CODI), sdr(NOM), sdr(ESTAT))
            c.altresAlcans = sdr(ALTRES_ALCANS)
            c.altresDocumentacio = sdr(VALTRES)
            c.codiProjecte = sdr(CODI_PROJECTE)
            c.comparatiu = sdr(COMPARATIU)
            c.contacteEntrega = sdr(CONTACTE_ENTREGA)
            c.dataFinalitzacio = sdr(DATA_FINALITZACIO)
            c.departament = sdr(DEPARTAMENT)
            c.direccioEntrega = sdr(DIRECCIO_ENTREGA)
            c.emailProveidor = sdr(EMAIL_PROVEIDOR)
            c.embalatge = sdr(EMBALATGE)
            c.empresa = sdr(EMPRESA)
            c.formaPagament = sdr(FORMA_PAGAMENT)
            c.llocEntrega = sdr(LLOC_ENTREGA)
            c.muntatge = sdr(MUNTATGE)
            c.oferta1 = sdr(OFERTA1)
            c.oferta2 = sdr(OFERTA2)
            c.oferta3 = sdr(OFERTA3)
            c.postaApunt = sdr(POSTA_PUNT)
            c.postaServei = sdr(POSTA_SERVEI)
            c.proveidor = sdr(PROVEIDOR)
            c.provesObra = sdr(PROVES_OBRA)
            c.provesTaller = sdr(PROVES_TALLER)
            c.serie = sdr(SERIE)
            c.suministreMaterial = sdr(SUMINISTRE_MATERIAL)
            c.supervisio = sdr(SUPERVISIO)
            c.telefonEntrega = sdr(TELEFON_ENTREGA)
            c.telefonProveidor = sdr(TELEFON_PROVEIDOR)
            c.transport = sdr(TRANSPORT)
            c.idProveidor = sdr(ID_PROVEIDOR)
            c.dataComanda = sdr(DATA_COMANDA)
            getObjectsSQL.Add(c)
        End While
        sdr.Close()
        getObjectsSQL.Sort()
        sdr = Nothing
        sc = Nothing
    End Function

    Private Function updateDBF(obj As SolicitudComanda) As Integer
        Dim sc As ADODB.Command
        sc = New ADODB.Command
        With sc
            .ActiveConnection = DBCONNECT.getConnectionDbf
            .CommandText = "UPDATE " & getTable() & " " &
                        " SET " & CODI & " =?, " &
                                NOM & " =?, " &
                                SERIE & " =?, " &
                                EMPRESA & " =?, " &
                                CODI_PROJECTE & " =?, " &
                                DEPARTAMENT & " =?, " &
                                PROVEIDOR & " =?, " &
                                CONTACTE_PROVEIDOR & " =?, " &
                                TELEFON_PROVEIDOR & " =?, " &
                                EMAIL_PROVEIDOR & " =?, " &
                                SUMINISTRE_MATERIAL & " =?, " &
                                EMBALATGE & " =?, " &
                                TRANSPORT & " =?, " &
                                MUNTATGE & " =?, " &
                                SUPERVISIO & " =?, " &
                                POSTA_PUNT & " =?, " &
                                PROVES_TALLER & " =?, " &
                                PROVES_OBRA & " =?, " &
                                POSTA_SERVEI & " =?, " &
                                ALTRES_ALCANS & " =?, " &
                                LLOC_ENTREGA & " =?, " &
                                DIRECCIO_ENTREGA & " =?, " &
                                CONTACTE_ENTREGA & " =?, " &
                                TELEFON_ENTREGA & " =?, " &
                                DATA_ENTREGA & " =?, " &
                                DATA_FINALITZACIO & " =?, " &
                                OFERTA1 & " =?, " &
                                OFERTA2 & " =?, " &
                                OFERTA3 & " =?, " &
                                COMPARATIU & " =?, " &
                                FORMA_PAGAMENT & " =?, " &
                                VALTRES & " =?, " &
                                ID_PROVEIDOR & " =?, " &
                                DATA_COMANDA & " =?, " &
                                ESTAT & " =? " &
            " WHERE " & ID & "=?"
            .Parameters.Append(ADOPARAM.ToInt(obj.codi))
            .Parameters.Append(ADOPARAM.ToString(obj.nom))
            .Parameters.Append(ADOPARAM.ToString(obj.serie))
            .Parameters.Append(ADOPARAM.ToString(obj.empresa))
            .Parameters.Append(ADOPARAM.ToString(obj.codiProjecte))
            .Parameters.Append(ADOPARAM.ToString(obj.departament))
            .Parameters.Append(ADOPARAM.ToString(obj.proveidor))
            .Parameters.Append(ADOPARAM.ToString(obj.contacteProveidor))
            .Parameters.Append(ADOPARAM.ToString(obj.telefonProveidor))
            .Parameters.Append(ADOPARAM.ToString(obj.emailProveidor))
            .Parameters.Append(ADOPARAM.toBool(obj.suministreMaterial))
            .Parameters.Append(ADOPARAM.toBool(obj.embalatge))
            .Parameters.Append(ADOPARAM.toBool(obj.transport))
            .Parameters.Append(ADOPARAM.toBool(obj.muntatge))
            .Parameters.Append(ADOPARAM.toBool(obj.supervisio))
            .Parameters.Append(ADOPARAM.toBool(obj.postaApunt))
            .Parameters.Append(ADOPARAM.toBool(obj.provesTaller))
            .Parameters.Append(ADOPARAM.toBool(obj.provesObra))
            .Parameters.Append(ADOPARAM.toBool(obj.postaServei))
            .Parameters.Append(ADOPARAM.toBool(obj.altresAlcans))
            .Parameters.Append(ADOPARAM.ToString(obj.llocEntrega))
            .Parameters.Append(ADOPARAM.ToString(obj.direccioEntrega))
            .Parameters.Append(ADOPARAM.ToString(obj.contacteEntrega))
            .Parameters.Append(ADOPARAM.ToString(obj.telefonEntrega))
            .Parameters.Append(ADOPARAM.ToDate(obj.dataEntrega))
            .Parameters.Append(ADOPARAM.ToDate(obj.dataFinalitzacio))
            .Parameters.Append(ADOPARAM.ToString(obj.oferta1))
            .Parameters.Append(ADOPARAM.ToString(obj.oferta2))
            .Parameters.Append(ADOPARAM.ToString(obj.oferta3))
            .Parameters.Append(ADOPARAM.ToString(obj.comparatiu))
            .Parameters.Append(ADOPARAM.ToString(obj.formaPagament))
            .Parameters.Append(ADOPARAM.ToString(obj.altresDocumentacio))
            .Parameters.Append(ADOPARAM.ToInt(obj.idProveidor))
            .Parameters.Append(ADOPARAM.ToDate(obj.dataComanda))
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
    Private Function insertDBF(obj As SolicitudComanda) As Integer
        Dim sc As ADODB.Command
        sc = New ADODB.Command
        obj.id = DBCONNECT.getMaxIdDBF(getTable) + 1
        With sc
            .ActiveConnection = DBCONNECT.getConnectionDbf

            .CommandText = (" INSERT INTO " & getTable() & " " &
                     " (" & ID & "," & DATA_COMANDA & "," & ID_PROVEIDOR & "," & ESTAT & "," & CODI & "," & NOM & "," & SERIE & "," & EMPRESA & ", " & CODI_PROJECTE & ", " & DEPARTAMENT & ", " & PROVEIDOR & ", " & CONTACTE_PROVEIDOR & ", " & TELEFON_PROVEIDOR & ", " & EMAIL_PROVEIDOR & ", " & SUMINISTRE_MATERIAL & ", " & EMBALATGE & ", " & TRANSPORT & ", " & MUNTATGE & ", " & SUPERVISIO & ", " & POSTA_PUNT & ", " & PROVES_TALLER & ", " & PROVES_OBRA & ", " & POSTA_SERVEI & ", " & ALTRES_ALCANS & ", " & LLOC_ENTREGA & ", " & DIRECCIO_ENTREGA & ", " & CONTACTE_ENTREGA & ", " & TELEFON_ENTREGA & ", " & DATA_ENTREGA & ", " & DATA_FINALITZACIO & "," & OFERTA1 & ", " & OFERTA2 & ", " & OFERTA3 & ", " & COMPARATIU & ", " & FORMA_PAGAMENT & ", " & VALTRES & ")" &
                    " VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)")



            .Parameters.Append(ADOPARAM.ToInt(obj.id))
            .Parameters.Append(ADOPARAM.ToDate(obj.dataComanda))
            .Parameters.Append(ADOPARAM.ToInt(obj.idProveidor))
            .Parameters.Append(ADOPARAM.ToInt(obj.estat))
            .Parameters.Append(ADOPARAM.ToInt(CInt(obj.codi)))
            .Parameters.Append(ADOPARAM.ToString(Strings.Right(obj.nom, 250))) '6
            .Parameters.Append(ADOPARAM.ToString(obj.serie))

            .Parameters.Append(ADOPARAM.ToString(obj.empresa))
            .Parameters.Append(ADOPARAM.ToString(obj.codiProjecte))
            .Parameters.Append(ADOPARAM.ToString(obj.departament))
            .Parameters.Append(ADOPARAM.ToString(obj.proveidor))
            .Parameters.Append(ADOPARAM.ToString(obj.contacteProveidor))
            .Parameters.Append(ADOPARAM.ToString(obj.telefonProveidor))
            .Parameters.Append(ADOPARAM.ToString(obj.emailProveidor)) '14
            .Parameters.Append(ADOPARAM.toBool(obj.suministreMaterial)) '15
            .Parameters.Append(ADOPARAM.toBool(obj.embalatge))

            .Parameters.Append(ADOPARAM.toBool(obj.transport))
            .Parameters.Append(ADOPARAM.toBool(obj.muntatge))
            .Parameters.Append(ADOPARAM.toBool(obj.supervisio))
            .Parameters.Append(ADOPARAM.toBool(obj.postaApunt))
            .Parameters.Append(ADOPARAM.toBool(obj.provesTaller))
            .Parameters.Append(ADOPARAM.toBool(obj.provesObra))
            .Parameters.Append(ADOPARAM.toBool(obj.postaServei))
            .Parameters.Append(ADOPARAM.toBool(obj.altresAlcans)) '24

            .Parameters.Append(ADOPARAM.ToString(obj.llocEntrega))

            .Parameters.Append(ADOPARAM.ToString(obj.direccioEntrega))
            .Parameters.Append(ADOPARAM.ToString(obj.contacteEntrega))
            .Parameters.Append(ADOPARAM.ToString(obj.telefonEntrega))
            .Parameters.Append(ADOPARAM.ToDate(obj.dataEntrega))
            .Parameters.Append(ADOPARAM.ToDate(obj.dataFinalitzacio)) '30

            .Parameters.Append(ADOPARAM.ToString(obj.oferta1))
            .Parameters.Append(ADOPARAM.ToString(obj.oferta2))
            .Parameters.Append(ADOPARAM.ToString(obj.oferta3))

            .Parameters.Append(ADOPARAM.ToString(obj.comparatiu))
            .Parameters.Append(ADOPARAM.ToString(obj.formaPagament))
            .Parameters.Append(ADOPARAM.ToString(obj.altresDocumentacio)) '36

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
    Private Function removeDBF(obj As SolicitudComanda) As Boolean
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
    Private Function getObjectsDBF(p As Integer) As List(Of SolicitudComanda)
        Dim rc As ADODB.Recordset, c As SolicitudComanda
        rc = New ADODB.Recordset
        getObjectsDBF = New List(Of SolicitudComanda)
        rc.Open("Select * FROM " & getTable() & " WHERE " & ESTAT & "=" & p, DBCONNECT.getConnectionDbf)
        While Not rc.EOF
            c = New SolicitudComanda(rc(ID).Value, rc(CODI).Value, Trim(CONFIG.validarNull(rc(NOM).Value)), rc(ESTAT).Value)
            c.altresAlcans = rc(ALTRES_ALCANS).Value
            c.altresDocumentacio = Trim(CONFIG.validarNull(rc(VALTRES).Value))
            c.codiProjecte = Trim(CONFIG.validarNull(rc(CODI_PROJECTE).Value))
            c.comparatiu = Trim(CONFIG.validarNull(rc(COMPARATIU).Value))
            c.contacteEntrega = Trim(CONFIG.validarNull(rc(CONTACTE_ENTREGA).Value))
            c.dataFinalitzacio = rc(DATA_FINALITZACIO).Value
            c.departament = Trim(CONFIG.validarNull(rc(DEPARTAMENT).Value))
            c.direccioEntrega = Trim(CONFIG.validarNull(rc(DIRECCIO_ENTREGA).Value))
            c.emailProveidor = Trim(CONFIG.validarNull(rc(EMAIL_PROVEIDOR).Value))
            c.embalatge = rc(EMBALATGE).Value
            c.empresa = Trim(CONFIG.validarNull(rc(EMPRESA).Value))
            c.formaPagament = Trim(CONFIG.validarNull(rc(FORMA_PAGAMENT).Value))
            c.llocEntrega = Trim(CONFIG.validarNull(rc(LLOC_ENTREGA).Value))
            c.muntatge = rc(MUNTATGE).Value
            c.oferta1 = Trim(CONFIG.validarNull(rc(OFERTA1).Value))
            c.oferta2 = Trim(CONFIG.validarNull(rc(OFERTA2).Value))
            c.oferta3 = Trim(CONFIG.validarNull(rc(OFERTA3).Value))
            c.postaApunt = rc(POSTA_PUNT).Value
            c.postaServei = rc(POSTA_SERVEI).Value
            c.proveidor = rc(PROVEIDOR).Value
            c.provesObra = rc(PROVES_OBRA).Value
            c.provesTaller = rc(PROVES_TALLER).Value
            c.serie = Trim(CONFIG.validarNull(rc(SERIE).Value))
            c.suministreMaterial = rc(SUMINISTRE_MATERIAL).Value
            c.supervisio = rc(SUPERVISIO).Value
            c.telefonEntrega = Trim(CONFIG.validarNull(rc(TELEFON_ENTREGA).Value))
            c.telefonProveidor = Trim(CONFIG.validarNull(rc(TELEFON_PROVEIDOR).Value))
            c.transport = rc(TRANSPORT).Value
            c.idProveidor = rc(ID_PROVEIDOR).Value
            c.dataComanda = rc(DATA_COMANDA).Value
            getObjectsDBF.Add(c)
            rc.MoveNext()
        End While
        If rc.State = 1 Then rc.Close()
        rc = Nothing
        getObjectsDBF.Sort()
    End Function
    Private Function getObjectsDBF(p As String) As List(Of SolicitudComanda)
        Dim rc As ADODB.Recordset, c As SolicitudComanda
        rc = New ADODB.Recordset
        getObjectsDBF = New List(Of SolicitudComanda)
        rc.Open("Select * FROM " & getTable(), DBCONNECT.getConnectionDbf)
        While Not rc.EOF
            c = New SolicitudComanda(rc(ID).Value, rc(CODI).Value, Trim(CONFIG.validarNull(rc(NOM).Value)), rc(ESTAT).Value)
            c.altresAlcans = rc(ALTRES_ALCANS).Value
            c.altresDocumentacio = Trim(CONFIG.validarNull(rc(VALTRES).Value))
            c.codiProjecte = Trim(CONFIG.validarNull(rc(CODI_PROJECTE).Value))
            c.comparatiu = Trim(CONFIG.validarNull(rc(COMPARATIU).Value))
            c.contacteEntrega = Trim(CONFIG.validarNull(rc(CONTACTE_ENTREGA).Value))
            c.dataFinalitzacio = Trim(CONFIG.validarNull(rc(DATA_FINALITZACIO).Value))
            c.departament = Trim(CONFIG.validarNull(rc(DEPARTAMENT).Value))
            c.direccioEntrega = Trim(CONFIG.validarNull(rc(DIRECCIO_ENTREGA).Value))
            c.emailProveidor = CONFIG.validarNull(Trim(rc(EMAIL_PROVEIDOR).Value))
            c.embalatge = rc(EMBALATGE).Value
            c.empresa = Trim(CONFIG.validarNull(rc(EMPRESA).Value))
            c.formaPagament = Trim(CONFIG.validarNull(rc(FORMA_PAGAMENT).Value))
            c.llocEntrega = Trim(CONFIG.validarNull(rc(LLOC_ENTREGA).Value))
            c.muntatge = rc(MUNTATGE).Value
            c.oferta1 = Trim(CONFIG.validarNull(rc(OFERTA1).Value))
            c.oferta2 = Trim(CONFIG.validarNull(rc(OFERTA2).Value))
            c.oferta3 = Trim(CONFIG.validarNull(rc(OFERTA3).Value))
            c.postaApunt = rc(POSTA_PUNT).Value
            c.postaServei = rc(POSTA_SERVEI).Value
            c.proveidor = rc(PROVEIDOR).Value
            c.provesObra = rc(PROVES_OBRA).Value
            c.provesTaller = rc(PROVES_TALLER).Value
            c.serie = Trim(CONFIG.validarNull(rc(SERIE).Value))
            c.suministreMaterial = rc(SUMINISTRE_MATERIAL).Value
            c.supervisio = rc(SUPERVISIO).Value
            c.telefonEntrega = Trim(CONFIG.validarNull(rc(TELEFON_ENTREGA).Value))
            c.telefonProveidor = Trim(CONFIG.validarNull(rc(TELEFON_PROVEIDOR).Value))
            c.transport = rc(TRANSPORT).Value
            c.idProveidor = rc(ID_PROVEIDOR).Value
            c.dataComanda = rc(DATA_COMANDA).Value
            getObjectsDBF.Add(c)
            rc.MoveNext()
        End While
        If rc.State = 1 Then rc.Close()
        rc = Nothing
        getObjectsDBF.Sort()
    End Function
    Private Function getTable() As String
        Return DBCONNECT.GetTaulaSolicitudComanda
    End Function

End Module
'Private Function insertDBF(obj As SolicitudComanda) As Integer
'    Dim sc As ADODB.Command
'    sc = New ADODB.Command
'    obj.id = DBCONNECT.getMaxIdDBF(getTable) + 1
'    With sc
'        .ActiveConnection = DBCONNECT.getConnectionDbf
'        .CommandText = (" INSERT INTO " & getTable() & " " &
'                     " (" & ID() & "," & DATA_COMANDA & "," & ID_PROVEIDOR & "," & ESTAT() & "," & CODI() & "," & NOM() & "," & SERIE & "," & Empresa & "," & CODI_PROJECTE & "," & Departament & "," & Proveidor & "," & CONTACTE_PROVEIDOR & "," & TELEFON_PROVEIDOR & "," & EMAIL_PROVEIDOR & "," & SUMINISTRE_MATERIAL & "," & EMBALATGE & "," & TRANSPORT & "," & MUNTATGE & "," & SUPERVISIO & "," & POSTA_PUNT & "," & PROVES_TALLER & "," & PROVES_OBRA & "," & POSTA_SERVEI & "," & ALTRES_ALCANS & "," & LLOC_ENTREGA & "," & DIRECCIO_ENTREGA & "," & CONTACTE_ENTREGA & "," & TELEFON_ENTREGA & "," & DATA_ENTREGA & "," & DATA_FINALITZACIO & "," & OFERTA1 & "," & OFERTA2 & "," & OFERTA3 & "," & COMPARATIU & "," & FORMA_PAGAMENT & "," & VALTRES & ")" &
'                    " VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)")
'        .Parameters.Append(ADOPARAM.ToInt(obj.id))
'        .Parameters.Append(ADOPARAM.ToDate(obj.dataComanda))
'        .Parameters.Append(ADOPARAM.ToInt(obj.idProveidor))
'        .Parameters.Append(ADOPARAM.ToInt(obj.estat))
'        .Parameters.Append(ADOPARAM.ToInt(CInt(obj.codi)))
'        .Parameters.Append(ADOPARAM.ToString(obj.nom))
'        .Parameters.Append(ADOPARAM.ToString(obj.serie))

'        .Parameters.Append(ADOPARAM.ToString(obj.empresa))
'        .Parameters.Append(ADOPARAM.ToString(obj.codiProjecte))
'        .Parameters.Append(ADOPARAM.ToString(obj.departament))
'        .Parameters.Append(ADOPARAM.ToString(obj.proveidor))
'        .Parameters.Append(ADOPARAM.ToString(obj.contacteProveidor))
'        .Parameters.Append(ADOPARAM.ToString(obj.telefonProveidor))
'        .Parameters.Append(ADOPARAM.ToString(obj.emailProveidor))
'        .Parameters.Append(ADOPARAM.toBool(obj.suministreMaterial))
'        .Parameters.Append(ADOPARAM.toBool(obj.embalatge))
'        .Parameters.Append(ADOPARAM.toBool(obj.transport))
'        .Parameters.Append(ADOPARAM.toBool(obj.muntatge))
'        .Parameters.Append(ADOPARAM.toBool(obj.supervisio))
'        .Parameters.Append(ADOPARAM.toBool(obj.postaApunt))
'        .Parameters.Append(ADOPARAM.toBool(obj.provesTaller))
'        .Parameters.Append(ADOPARAM.toBool(obj.provesObra))
'        .Parameters.Append(ADOPARAM.toBool(obj.postaServei))
'        .Parameters.Append(ADOPARAM.toBool(obj.altresAlcans))
'        .Parameters.Append(ADOPARAM.ToString(obj.llocEntrega))
'        .Parameters.Append(ADOPARAM.ToString(obj.direccioEntrega))
'        .Parameters.Append(ADOPARAM.ToString(obj.contacteEntrega))
'        .Parameters.Append(ADOPARAM.ToString(obj.telefonEntrega))
'        .Parameters.Append(ADOPARAM.ToDate(obj.dataEntrega))
'        .Parameters.Append(ADOPARAM.ToDate(obj.dataFinalitzacio))
'        .Parameters.Append(ADOPARAM.ToString(obj.oferta1))
'        .Parameters.Append(ADOPARAM.ToString(obj.oferta2))
'        .Parameters.Append(ADOPARAM.ToString(obj.oferta3))
'        .Parameters.Append(ADOPARAM.ToString(obj.comparatiu))
'        .Parameters.Append(ADOPARAM.ToString(obj.formaPagament))
'        .Parameters.Append(ADOPARAM.ToString(obj.altresDocumentacio))

'    End With
'    Try
'        sc.Execute()
'        Return obj.id
'    Catch ex As Exception
'        Call ERRORS.ERR_EXCEPTION_SQL(ex.Message)
'        Return -1
'    Finally
'        sc = Nothing
'    End Try
'End Function