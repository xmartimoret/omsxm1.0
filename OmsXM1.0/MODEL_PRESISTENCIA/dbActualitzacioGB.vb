Imports System.Data.SqlClient
Module dbActualitzacioGB
    Private Const MES As String = "MES"
    Private Const ANYO As String = "ANYO"
    Private Const ID_CENTRE As String = "IDCENTRE"
    Private Const ID_SUBGRUP As String = "IDSUBGRUP"
    Private Const VALOR As String = "VALOR"
    Public Function existCentre(idCentre As Integer) As Boolean
        If IS_SQLSERVER Then Return existCentreSQL(idCentre)
        Return existCentreDBF(idCentre)
    End Function
    Public Function removeData(idCentre As Integer, pMes As Integer, pAnyo As Integer) As Boolean
        If IS_SQLSERVER Then Return removeDataSQL(idCentre, pMes, pAnyo)
        Return removeDataDBF(idCentre, pMes, pAnyo)
    End Function
    Public Function getMesos(pAnyo As Integer) As List(Of Mes)
        If IS_SQLSERVER Then Return getMesosSQL(pAnyo)
        Return getMesosDBF(pAnyo)
    End Function
    Public Function getAnyos() As List(Of Integer)
        If IS_SQLSERVER Then Return getAnyosSQL()
        Return getAnyosDBF()
    End Function

    Public Function getObjects(a As Integer) As List(Of ImportMesSubgrup)()
        If IS_SQLSERVER Then Return getObjectsSQL(a)
        Return getObjectsDBF(a)
    End Function
    Private Function existCentreSQL(idCentre As Integer) As Boolean
        Dim sc As SqlCommand, sdr As SqlDataReader
        sc = New SqlCommand("SELECT TOP 1 " & ID_CENTRE & " FROM " & getTable() & " WHERE " & ID_CENTRE & "=@idCentre", getConnection)
        sc.Parameters.Add("@idCentre", SqlDbType.Int).Value = idCentre
        sdr = sc.ExecuteReader
        If sdr.HasRows Then
            Return True
        Else
            Return False
        End If
        sdr.Close()
        sdr = Nothing
        sc = Nothing
    End Function
    Private Function removeDataSQL(idCentre As Integer, pMes As Integer, pAnyo As Integer, Optional actualitzar As Boolean = False) As Boolean
        Dim sc As SqlCommand, i As Integer
        If pMes > 0 Then
            sc = New SqlCommand("DELETE FROM " & getTable() & " WHERE " & ID_CENTRE & "=@idCentre  AND " & MES & "=@mes And " & ANYO & "=@anyo", DBCONNECT.getConnection)
            sc.Parameters.Add("@mes", SqlDbType.Int).Value = pMes
        Else
            sc = New SqlCommand("DELETE FROM " & getTable() & " WHERE " & ID_CENTRE & "=@idCentre  AND " & ANYO & " =@anyo", DBCONNECT.getConnection)
        End If
        sc.Parameters.Add("@idCentre", SqlDbType.Int).Value = idCentre
        sc.Parameters.Add("@anyo", SqlDbType.Int).Value = pAnyo
        i = sc.ExecuteNonQuery
        sc = Nothing

        If i >= 1 Then Return True
        Return False
    End Function
    Private Function getMesosSQL(pAnyo As Integer) As List(Of Mes)
        Dim sc As SqlCommand, sdr As SqlDataReader
        sc = New SqlCommand("SELECT distinct " & MES & " FROM " & getTable() & " WHERE " & ANYO & " =@anyo ORDER BY " & MES, getConnection)
        sc.Parameters.Add("@anyo", SqlDbType.Int).Value = pAnyo
        sdr = sc.ExecuteReader
        getMesosSQL = New List(Of Mes)
        While sdr.Read
            getMesosSQL.Add(New Mes(sdr(MES), CONFIG.mesNom(sdr(MES))))
        End While
        sdr.Close()
        sdr = Nothing
        sc = Nothing
    End Function
    Private Function getAnyosSQL() As List(Of Integer)
        Dim sc As SqlCommand, sdr As SqlDataReader, a As List(Of Integer)
        sc = New SqlCommand("SELECT distinct " & ANYO & " FROM " & getTable() & " ORDER BY " & ANYO, getConnection)
        sdr = sc.ExecuteReader
        a = New List(Of Integer)
        While sdr.Read
            a.Add(sdr(ANYO))
        End While
        sdr.Close()
        getAnyosSQL = a
        sdr = Nothing
        sc = Nothing
        a = Nothing
    End Function
    Private Function getObjectsSQL(a As Integer) As List(Of ImportMesSubgrup)()
        Dim ims As ImportMesSubgrup, objects(0 To 12) As List(Of ImportMesSubgrup)
        Dim sc As SqlCommand, sdr As SqlDataReader
        sc = New SqlCommand("SELECT " & ID_SUBGRUP & "," & ID_CENTRE & "," & MES & "," & ANYO & ",  SUM(" & VALOR & ") AS SVALOR  FROM " & getTable() & " WHERE " & ANYO & "= @anyo    GROUP BY " & ID_SUBGRUP & "," & ID_CENTRE & "," & MES & "," & ANYO, getConnection)
        sc.Parameters.Add("@anyo", SqlDbType.Int).Value = a
        sdr = sc.ExecuteReader
        While sdr.Read()
            ims = (New ImportMesSubgrup(sdr(ANYO), sdr(MES), sdr(ID_CENTRE), sdr(ID_SUBGRUP), sdr("SVALOR"), "TANC.", sdr(MES) & ModelSubgrup.getCodi(sdr(ID_SUBGRUP))))
            If objects(sdr(MES)) Is Nothing Then objects(sdr(MES)) = New List(Of ImportMesSubgrup)
            objects(sdr(MES)).Add(ims)
        End While
        sdr.Close()
        sdr = Nothing
        sc = Nothing
        ims = Nothing
        Return objects
    End Function
    Private Function getObjectsDBF(a As Integer) As List(Of ImportMesSubgrup)()
        Dim ims As ImportMesSubgrup, objects(0 To 12) As List(Of ImportMesSubgrup)
        Dim rc As ADODB.Recordset
        rc = New ADODB.Recordset
        rc.Open("SELECT " & ID_SUBGRUP & "," & ID_CENTRE & "," & MES & "," & ANYO & ",  SUM(" & VALOR & ") AS SVALOR  FROM " & getTable() & " WHERE " & ANYO & "= " & a & " GROUP BY " & ID_SUBGRUP & "," & ID_CENTRE & "," & MES & "," & ANYO, DBCONNECT.getConnectionDbf)
        While Not rc.EOF
            ims = (New ImportMesSubgrup(rc(ANYO).Value, rc(MES).Value, rc(ID_CENTRE).Value, rc(ID_SUBGRUP).Value, rc("SVALOR").Value, "TANC.", rc(MES).Value & ModelSubgrup.getCodi(rc(ID_SUBGRUP).Value)))
            If objects(rc(MES).Value) Is Nothing Then objects(rc(MES).Value) = New List(Of ImportMesSubgrup)
            objects(rc(MES).Value).Add(ims)
            rc.MoveNext()
        End While
        If rc.State = 1 Then rc.Close()
        rc = Nothing
        ims = Nothing
        Return objects
    End Function
    Private Function existCentreDBF(idCentre As Integer) As Boolean
        Dim rc As ADODB.Recordset, result As Boolean
        rc = New ADODB.Recordset
        rc.Open("SELECT TOP 1 " & ID_CENTRE & " FROM " & getTable() & " WHERE " & ID_CENTRE & "=" & idCentre, DBCONNECT.getConnectionDbf)
        If rc.EOF Then
            result = False
        Else
            result = True
        End If
        If rc.State = 1 Then rc.Close()
        rc = Nothing
        Return result
    End Function
    Private Function removeDataDBF(idCentre As Integer, pMes As Integer, pAnyo As Integer) As Boolean
        Dim sc As ADODB.Command
        sc = New ADODB.Command
        With sc
            .ActiveConnection = DBCONNECT.getConnectionDbf
            If pMes > 0 Then
                .CommandText = "DELETE FROM " & getTable() & " WHERE " & ID_CENTRE & "=?  AND " & MES & "=? And " & ANYO & "=?"
                .Parameters.Append(ADOPARAM.ToInt(idCentre))
                .Parameters.Append(ADOPARAM.ToInt(pMes))
                .Parameters.Append(ADOPARAM.ToInt(pAnyo))
            Else
                .CommandText = "DELETE FROM " & getTable() & " WHERE " & ID_CENTRE & "=?   And " & ANYO & "=?"
                .Parameters.Append(ADOPARAM.ToInt(idCentre))
                .Parameters.Append(ADOPARAM.ToInt(pAnyo))
            End If

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
    Private Function getMesosDBF(pAnyo As Integer) As List(Of Mes)
        Dim rc As ADODB.Recordset
        rc = New ADODB.Recordset
        getMesosDBF = New List(Of Mes)
        rc.Open("SELECT distinct " & MES & " FROM " & getTable() & " WHERE " & ANYO & " =" & pAnyo & " ORDER BY " & MES, DBCONNECT.getConnectionDbf)
        While Not rc.EOF
            getMesosDBF.Add(New Mes(rc(MES).Value, CONFIG.mesNom(rc(MES).Value)))
            rc.MoveNext()
        End While
        If rc.State = 1 Then rc.Close()
        rc = Nothing
    End Function
    Private Function getAnyosDBF() As List(Of Integer)
        Dim rc As ADODB.Recordset
        rc = New ADODB.Recordset
        getAnyosDBF = New List(Of Integer)
        rc.Open("SELECT distinct " & ANYO & " FROM " & getTable() & " ORDER BY " & ANYO, DBCONNECT.getConnectionDbf)
        While Not rc.EOF
            getAnyosDBF.Add(rc(ANYO).Value)
            rc.MoveNext()
        End While
        If rc.State = 1 Then rc.Close()
        rc = Nothing
    End Function

    Private Function getTable() As String
        Return DBCONNECT.getTaulaCentreSubgrups
    End Function
End Module
