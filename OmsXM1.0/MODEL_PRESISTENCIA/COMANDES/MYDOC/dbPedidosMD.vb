Option Explicit On
Imports System.Data.SqlClient
Module dbPedidosMD
    Private Const ID_TAULA As String = "11"
    Private Const SYSID As String = "SYSID"
    Private Const NOM As String = "SYSNOM"
    Private Const ESTAT As String = "SYSESTADO"
    Private Const MTD_CODI As String = "MTD_00106"
    Private Const MTD_CODI_PROJECTE As String = "MTD_00036"
    Private Const MTD_PROJECTE As String = "MTD_00037"
    Private Const MTD_PROVEIDOR As String = "MTD_00030"
    Private Const MTD_DEPARTAMENT As String = "MTD_00035"
    Private Const MTD_RESPONSABLE_COMPRA As String = "MTD_00029"
    Private Const MTD_EMPRESA As String = "MTD_00033"
    Private Const MTD_ESTADO As String = "MTD_00150"
    Public Function update(id As Integer, estat As Integer) As Integer
        Return updateSQL(id, estat)
    End Function
    Public Function updateEnviado(id As Integer, estat As Integer) As Integer
        Return updateSQLEnviado(id, estat)
    End Function
    Public Function getObject(idPedido As Integer) As PedidoMD
        Return getObjectSQL(idPedido)
    End Function
    Public Function getObjects() As List(Of PedidoMD)
        Return getObjectsSQL()
    End Function
    Public Function getObjects(pEstat As Integer) As List(Of PedidoMD)
        Return getObjectsSQL(pEstat)
    End Function

    Private Function updateSQL(idComanda As Integer, pEstat As Integer) As Integer
        Dim sc As SqlCommand, i As Integer
        sc = New SqlCommand("UPDATE " & getTable() & " " &
                                " SET " & ESTAT & "=@estat " &
                                          " WHERE " & SYSID & "=@id", DBCONNECT.getConnection)
        sc.Parameters.Add("@id", SqlDbType.Int).Value = idComanda
        sc.Parameters.Add("@estat", SqlDbType.Int).Value = pEstat
        i = sc.ExecuteNonQuery
        sc = Nothing
        If i >= 1 Then
            Return idComanda
        End If
        Return -1
    End Function
    Private Function updateSQLEnviado(idComanda As Integer, estatInicial As String) As Integer
        Dim sc As SqlCommand, i As Integer
        sc = New SqlCommand("UPDATE " & getTable() & " " &
                                " SET " & MTD_ESTADO & "=@estat " &
                                          " WHERE " & SYSID & "=@id", DBCONNECT.getConnection)
        sc.Parameters.Add("@id", SqlDbType.Int).Value = idComanda
        sc.Parameters.Add("@estat", SqlDbType.VarChar).Value = estatInicial & "ENVIADO"
        i = sc.ExecuteNonQuery
        sc = Nothing
        If i >= 1 Then
            Return idComanda
        End If
        Return -1
    End Function
    Private Function getObjectsSQL() As List(Of PedidoMD)
        Dim sc As SqlCommand, sdr As SqlDataReader, a As PedidoMD
        getObjectsSQL = New List(Of PedidoMD)
        sc = New SqlCommand("Select * FROM " & getTable() & " WHERE " & ESTAT & "=8", DBCONNECT.getConnectioMyDoc)
        sdr = sc.ExecuteReader
        While sdr.Read()
            a = New PedidoMD(sdr(SYSID), Trim(CONFIG.validarNull(sdr(MTD_CODI))), Trim(CONFIG.validarNull(sdr(NOM))), sdr(ESTAT))
            a.codiProjecte = Trim(CONFIG.validarNull(sdr(MTD_CODI_PROJECTE)))
            a.proveidor = Trim(CONFIG.validarNull(sdr(MTD_PROVEIDOR)))
            a.events = ModelEventsMyDOc.getObjects(sdr(SYSID))
            getObjectsSQL.Add(a)
        End While
        sdr.Close()
        getObjectsSQL.Sort()
        sdr = Nothing
        sc = Nothing
    End Function
    Private Function getObjectsSQL(pEstat As Integer) As List(Of PedidoMD)
        Dim sc As SqlCommand, sdr As SqlDataReader, a As PedidoMD
        getObjectsSQL = New List(Of PedidoMD)
        sc = New SqlCommand("Select * FROM " & getTable() & " WHERE " & ESTAT & "=" & pEstat, DBCONNECT.getConnectioMyDoc)
        sdr = sc.ExecuteReader
        While sdr.Read()
            a = New PedidoMD(sdr(SYSID), Trim(CONFIG.validarNull(sdr(MTD_CODI))), Trim(CONFIG.validarNull(sdr(NOM))), sdr(ESTAT))
            a.codiProjecte = Trim(CONFIG.validarNull(sdr(MTD_CODI_PROJECTE)))
            a.proveidor = Trim(CONFIG.validarNull(sdr(MTD_PROVEIDOR)))
            a.empresa = Trim(CONFIG.validarNull(sdr(MTD_EMPRESA)))
            'a.events = ModelEventsMyDOc.getObjects(sdr(SYSID))
            getObjectsSQL.Add(a)
        End While
        sdr.Close()
        getObjectsSQL.Sort()
        sdr = Nothing
        sc = Nothing
    End Function
    Private Function getObjectSQL(idComanda As Integer) As PedidoMD
        Dim sc As SqlCommand, sdr As SqlDataReader, a As PedidoMD
        a = Nothing
        sc = New SqlCommand("Select * FROM " & getTable() & " WHERE " & SYSID & "=" & idComanda, DBCONNECT.getConnectioMyDoc)
        sdr = sc.ExecuteReader
        If sdr.Read() Then
            a = New PedidoMD(sdr(SYSID), Trim(CONFIG.validarNull(sdr(MTD_CODI))), Trim(CONFIG.validarNull(sdr(NOM))), sdr(ESTAT))
            a.codiProjecte = Trim(CONFIG.validarNull(sdr(MTD_CODI_PROJECTE)))
            a.proveidor = Trim(CONFIG.validarNull(sdr(MTD_PROVEIDOR)))

            a.events = ModelEventsMyDOc.getObjects(sdr(SYSID))

        End If
        sdr.Close()
        sdr = Nothing
        sc = Nothing
        Return a
    End Function
    Private Function getTable() As String
        Return "dbo.TBL_00011"
    End Function
End Module

