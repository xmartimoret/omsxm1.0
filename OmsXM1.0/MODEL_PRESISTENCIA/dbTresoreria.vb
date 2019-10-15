Option Explicit On
Imports System.Data.SqlClient
Module dbTresoreria
    Private Const ID As String = "ID"
    Private Const ID_PROJECTE As String = "IDPROJ"
    Private Const CONCEPTE As String = "CONCEPTE"
    Private Const INGRES As String = "INGRES"
    Private Const TIPUS As String = "TIPUS"
    Private Const BASE As String = "BASE"
    Private Const TIPUS_IVA As String = "TIVA"
    Private Const DATA_EMISIO As String = "DATAEM"
    Private Const DATA_VENCIMENT As String = "DATAVEN"
    Public Function update(obj As Tresoreria) As Integer
        If IS_SQLSERVER Then Return updateSQL(obj)
        Return updateDBF(obj)
    End Function
    Public Function insert(obj As Tresoreria) As Integer
        If IS_SQLSERVER Then Return insertSQL(obj)
        Return insertDBF(obj)
    End Function
    Public Function remove(id As Integer) As Boolean
        If IS_SQLSERVER Then Return removeSQL(id)
        Return removeDBF(id)
    End Function
    Public Function getObjects() As List(Of Tresoreria)
        If IS_SQLSERVER Then Return getObjectsSQL()
        Return getObjectsDBF()
    End Function
    Public Function getProjectes() As List(Of ProjecteTresoreria)
        If IS_SQLSERVER Then Return getProjectesSQL()
        Return getProjectesDBF()
    End Function
    Private Function insertSQL(e As Tresoreria) As Boolean
        Dim sc As SqlCommand, i As Integer
        e.id = DBCONNECT.getMaxId(getTable()) + 1
        sc = New SqlCommand("INSERT INTO " & getTable() &
                                    "(" & ID & "," & ID_PROJECTE & "," & CONCEPTE & "," & INGRES & "," & TIPUS & "," & BASE & "," & TIPUS_IVA & "," & DATA_EMISIO & "," & DATA_VENCIMENT & ") " &
                                    " VALUES(@id,@idProjecte,@concepte,@ingres,@tipus,@base,@tIva,@dataEm,@dataVen)", DBCONNECT.getConnection)
        sc.Parameters.Add("@id", SqlDbType.Int).Value = e.id
        sc.Parameters.Add("@idProjecte", SqlDbType.Int).Value = e.idProjecte
        sc.Parameters.Add("@concepte", SqlDbType.VarChar).Value = CONFIG.validarApostrof(e.concepte)
        sc.Parameters.Add("@ingres", SqlDbType.Bit).Value = e.esIngres
        sc.Parameters.Add("@tipus", SqlDbType.VarChar).Value = e.tipus
        sc.Parameters.Add("@tIva", SqlDbType.Int).Value = e.tipusIva
        sc.Parameters.Add("@base", SqlDbType.Decimal).Value = e.base
        sc.Parameters.Add("@dataEm", SqlDbType.Date).Value = e.dataEmisio
        sc.Parameters.Add("@dataVen", SqlDbType.Date).Value = e.dataVenciment
        i = sc.ExecuteNonQuery
        sc = Nothing
        If i > 1 Then
            Return True
        End If
        Return False
    End Function
    Private Function updateSQL(t As Tresoreria) As Boolean
        Dim sc As SqlCommand, i As Integer
        sc = New SqlCommand("UPDATE " & getTable() & " SET " & TIPUS_IVA & "= @tipusIva " & t.tipusIva & "  where " & ID & "=@id ", DBCONNECT.getConnection)
        sc.Parameters.Add("@id", SqlDbType.Int).Value = t.id
        sc.Parameters.Add("@tipusIva", SqlDbType.Int).Value = t.tipusIva
        i = sc.ExecuteNonQuery
        sc = Nothing
        If i > 1 Then
            Return True
        End If
        Return False
    End Function
    Private Function removeSQl(idProjecte As Integer) As Boolean
        Dim sc As SqlCommand, i As Integer
        sc = New SqlCommand("DELETE * FROM " & getTable() & " WHERE " & ID_PROJECTE & "=@idProjecte", DBCONNECT.getConnection)
        sc.Parameters.Add("@idProjecte", SqlDbType.Int).Value = idProjecte
        i = sc.ExecuteNonQuery
        sc = Nothing
        If i > 1 Then
            Return True
        End If
        Return False
    End Function
    Private Function getObjectsSQL() As List(Of Tresoreria)
        Dim sc As SqlCommand, sdr As SqlDataReader
        getObjectsSQL = New List(Of Tresoreria)
        sc = New SqlCommand("Select * FROM " & getTable(), DBCONNECT.getConnection)
        sdr = sc.ExecuteReader
        While sdr.Read()
            getObjectsSQL.Add(New Tresoreria(sdr(ID), sdr(ID_PROJECTE), Trim(sdr(CONCEPTE)), sdr(INGRES), Trim(sdr(TIPUS)), sdr(BASE), sdr(TIPUS_IVA), sdr(DATA_EMISIO), sdr(DATA_VENCIMENT)))
        End While
        sdr.Close()
        sdr = Nothing
        sc = Nothing

    End Function
    Private Function getProjectesSQL() As List(Of ProjecteTresoreria)
        Dim sc As SqlCommand, sdr As SqlDataReader, p As Projecte, pt As ProjecteTresoreria
        getProjectesSQL = New List(Of ProjecteTresoreria)
        sc = New SqlCommand("Select distinct " & ID_PROJECTE & " FROM " & getTable(), DBCONNECT.getConnection)
        sdr = sc.ExecuteReader
        While sdr.Read()
            p = ModelProjecte.getObject(CInt(sdr(ID_PROJECTE)))
            If p IsNot Nothing Then
                pt = New ProjecteTresoreria
                pt.idProjecte = p.id
                pt.codiProjecte = p.codi
                pt.nomProjecte = p.nom
                getProjectesSQL.Add(pt)
            End If
        End While
        sdr.Close()
        sdr = Nothing
        sc = Nothing
    End Function
    Private Function insertDBF(e As Tresoreria) As Boolean
        Dim sc As ADODB.Command
        sc = New ADODB.Command
        e.id = DBCONNECT.getMaxIdDBF(getTable) + 1
        With sc
            .ActiveConnection = DBCONNECT.getConnectionDbf
            .CommandText = "INSERT INTO " & getTable() &
                                    "(" & ID & "," & ID_PROJECTE & "," & CONCEPTE & "," & INGRES & "," & TIPUS & "," & BASE & "," & TIPUS_IVA & "," & DATA_EMISIO & "," & DATA_VENCIMENT & ") " &
                                    " VALUES(?,?,?,?,?,?,?,?,?)"
            .Parameters.Append(ADOPARAM.ToInt(e.id))
            .Parameters.Append(ADOPARAM.ToInt(e.idProjecte))
            .Parameters.Append(ADOPARAM.ToString(e.concepte))
            .Parameters.Append(ADOPARAM.toBool(e.esIngres))
            .Parameters.Append(ADOPARAM.ToString(e.tipus))
            .Parameters.Append(ADOPARAM.ToSingle(e.base))
            .Parameters.Append(ADOPARAM.ToInt(e.tipusIva))
            .Parameters.Append(ADOPARAM.ToDate(e.dataEmisio))
            .Parameters.Append(ADOPARAM.ToDate(e.dataVenciment))
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
    Private Function updateDBF(t As Tresoreria) As Boolean
        Dim sc As ADODB.Command
        sc = New ADODB.Command
        With sc
            .ActiveConnection = DBCONNECT.getConnectionDbf
            .CommandText = "UPDATE " & getTable() & " SET " & TIPUS_IVA & "= ? " & t.tipusIva & "  where " & ID & "=? "
            .Parameters.Append(ADOPARAM.ToInt(t.tipusIva))
            .Parameters.Append(ADOPARAM.ToInt(t.id))
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
    Private Function removeDBF(idProjecte As Integer) As Boolean
        Dim sc As ADODB.Command
        sc = New ADODB.Command
        With sc
            .ActiveConnection = DBCONNECT.getConnectionDbf
            .CommandText = "DELETE * FROM " & getTable() & " WHERE " & ID_PROJECTE & "=@?"
            .Parameters.Append(ADOPARAM.ToInt(idProjecte))
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
    Private Function getObjectsDBF() As List(Of Tresoreria)
        Dim rc As ADODB.Recordset
        rc = New ADODB.Recordset
        getObjectsDBF = New List(Of Tresoreria)
        rc.Open("Select * FROM " & getTable(), DBCONNECT.getConnectionDbf)
        While Not rc.EOF
            getObjectsDBF.Add(New Tresoreria(rc(ID).Value, rc(ID_PROJECTE).Value, Trim(rc(CONCEPTE).Value), rc(INGRES).Value, Trim(rc(TIPUS).Value), rc(BASE).Value, rc(TIPUS_IVA).Value, rc(DATA_EMISIO).Value, rc(DATA_VENCIMENT).Value))
            rc.MoveNext()
        End While
        If rc.State = 1 Then rc.Close()
        rc = Nothing
        getObjectsDBF.Sort()
    End Function
    Private Function getProjectesDBF() As List(Of ProjecteTresoreria)
        Dim rc As ADODB.Recordset, pt As ProjecteTresoreria, p As Projecte
        rc = New ADODB.Recordset
        getProjectesDBF = New List(Of ProjecteTresoreria)
        rc.Open("Select distinct " & ID_PROJECTE & " FROM " & getTable(), DBCONNECT.getConnectionDbf)
        While Not rc.EOF
            p = ModelProjecte.getObject(CInt(rc(ID_PROJECTE).Value))
            If p IsNot Nothing Then
                pt = New ProjecteTresoreria
                pt.idProjecte = p.id
                pt.codiProjecte = p.codi
                pt.nomProjecte = p.nom
                getProjectesDBF.Add(pt)
            End If
            rc.MoveNext()
        End While
        If rc.State = 1 Then rc.Close()
        rc = Nothing
        getObjectsDBF.Sort()
    End Function
    Private Function getTable() As String
        getTable = DBCONNECT.getTaulaEstimacions
    End Function

End Module
