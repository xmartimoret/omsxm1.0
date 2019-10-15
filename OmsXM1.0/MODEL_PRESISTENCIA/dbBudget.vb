Option Explicit On
Imports System.Data.SqlClient
Module dbBudget
    Private Const ANYO As String = "ANYO"
    Private Const MES As String = "MES"
    Private Const VALOR As String = "VALOR"
    Private Const ID_EMPRESA As String = "IDEMPRESA"
    Private Const ID_PROJECTE As String = "IDPROJECTE"
    Private Const ID_SUBGRUP As String = "IDSUBGRUP"
    Private Const ID_SUBCOMPTE As String = "IDSUBCTE"

    Public Sub saveMesAny(valors As List(Of ValorMes), a As Integer, m As Integer)
        If IS_SQLSERVER Then
            Call saveMesAnySQL(valors, a, m)
        Else
            Call saveMesAnyDBF(valors, a, m)
        End If
    End Sub
    Public Function remove(idProjecte As Integer, m As Integer, a As Integer) As Boolean
        If IS_SQLSERVER Then
            Return removeSQL(idProjecte, m, a)
        Else
            Return removeDBF(idProjecte, m, a)
        End If
    End Function
    Public Function hihaDades(idProjecte As Integer, anyo As Integer) As Boolean
        If IS_SQLSERVER Then
            Return hihaDadesSQL(idProjecte, anyo)
        Else
            Return hihaDadesDBF(idProjecte, anyo)
        End If
    End Function
    Public Function DeleteZeroValues() As Boolean
        If IS_SQLSERVER Then
            Return DeleteZeroValuesSQL()
        Else
            Return DeleteZeroValuesDBF()
        End If
    End Function
    Public Function getAnyos(idEmpresa As Integer) As List(Of Integer)
        If IS_SQLSERVER Then
            Return getAnyosSQL(idEmpresa)
        Else
            Return getAnyosDBF(idEmpresa)
        End If
    End Function
    Public Function getObjects(a As Integer) As List(Of ValorMes)()
        If IS_SQLSERVER Then
            Return getObjectsSQL(a)
        Else
            Return getObjectsDBF(a)
        End If
    End Function

    Private Sub saveMesAnySQL(valors As List(Of ValorMes), a As Integer, m As Integer)
        Dim sc As SqlCommand, sdr As SqlDataReader, v As ValorMes, i As Integer
        sc = New SqlCommand("SELECT * FROM " & getTable() & " WHERE  " & ANYO & " = @anyo AND " & MES & "= @mes", DBCONNECT.getConnection)
        sc.Parameters.Add("@anyo", SqlDbType.Int).Value = a
        sc.Parameters.Add("@mes", SqlDbType.Int).Value = m
        sdr = sc.ExecuteReader
        While sdr.Read()
            For Each v In valors
                If _
                      sdr(ANYO) = v.any _
                  And sdr(MES) = v.mes _
                  And sdr(ID_PROJECTE) = v.idProjecte _
                  And sdr(ID_SUBCOMPTE) = v.idSubcompte _
                  And sdr(ID_SUBGRUP) = v.idSubgrup _
                  And sdr(ID_EMPRESA) = v.idEmpresa _
                Then
                    sc = New SqlCommand("UPDATE " & getTable() & " SET " & VALOR & "= @valor WHERE " & ANYO & " = @anyo " &
                                                                                             " AND " & MES & " = @mes " &
                                                                                             " AND " & ID_PROJECTE & " = @idProjecte " &
                                                                                             " AND " & ID_SUBCOMPTE & " = @id_subcompte " &
                                                                                             " AND " & ID_SUBGRUP & " = @idSubgrup " &
                                                                                             " AND " & ID_EMPRESA & " = @idEmpresa " _
                                       , DBCONNECT.getConnection)
                    sc.Parameters.Add("@anyo", SqlDbType.Int).Value = v.any
                    sc.Parameters.Add("@mes", SqlDbType.Int).Value = v.mes
                    sc.Parameters.Add("@idProjecte", SqlDbType.Int).Value = v.idProjecte
                    sc.Parameters.Add("@idSubcompte", SqlDbType.Int).Value = v.idSubcompte
                    sc.Parameters.Add("@idSubgrup", SqlDbType.Int).Value = v.idSubgrup
                    sc.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = v.idEmpresa
                    sc.Parameters.Add("@valor", SqlDbType.Decimal).Value = v.valor
                    i = sc.ExecuteNonQuery()
                    If i > 0 Then v.actualitzat = True
                    Exit For
                End If
            Next
        End While
        sdr.Close()
        For Each v In valors
            If Not v.actualitzat Then
                sc = New SqlCommand("INSERT INTO " & getTable() & " (" & ANYO & "," & MES & "," & ID_SUBCOMPTE & "," & ID_SUBGRUP & "," & ID_PROJECTE & "," & ID_EMPRESA & "," & VALOR & ") VALUES(@anyo,@mes,@idSubcompte,@idSubgrup,@idProjecte,@idEmpresa,@valor)", DBCONNECT.getConnection)
                sc.Parameters.Add("@anyo", SqlDbType.Int).Value = v.any
                sc.Parameters.Add("@mes", SqlDbType.Int).Value = v.mes
                sc.Parameters.Add("@idProjecte", SqlDbType.Int).Value = v.idProjecte
                sc.Parameters.Add("@idSubcompte", SqlDbType.Int).Value = v.idSubcompte
                sc.Parameters.Add("@idSubgrup", SqlDbType.Int).Value = v.idSubgrup
                sc.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = v.idEmpresa
                sc.Parameters.Add("@valor", SqlDbType.Decimal).Value = v.valor
                i = sc.ExecuteNonQuery()
            End If
        Next
        sc = Nothing
        sdr = Nothing
    End Sub
    Private Function removeSQL(idProjecte As Integer, m As Integer, a As Integer) As Boolean
        Dim sc As SqlCommand, i As Integer
        sc = New SqlCommand("DELETE  FROM " & getTable() & " WHERE " & ID_PROJECTE & "= @idProjecte And " & ANYO & "= @anyo And  " & MES & " = @mes", DBCONNECT.getConnection)
        sc.Parameters.Add("@idProjecte", SqlDbType.Int).Value = idProjecte
        sc.Parameters.Add("@idMes", SqlDbType.Int).Value = m
        sc.Parameters.Add("@anyo", SqlDbType.Int).Value = a
        i = sc.ExecuteNonQuery
        sc = Nothing
        If i > 1 Then
            Return True
        End If
        Return False
    End Function
    Private Function hihaDadesSQL(idProjecte As Integer, anyo As Integer) As Boolean
        Dim sc As SqlCommand, sdr As SqlDataReader
        sc = New SqlCommand("select top 1 " & MES & " FROM " & getTable() & " WHERE " & ID_PROJECTE & "=@idProjecte And " & anyo & "= @Anyo", DBCONNECT.getConnection)
        sc.Parameters.Add("@idProjecte", SqlDbType.Int).Value = idProjecte
        sc.Parameters.Add("@anyo", SqlDbType.Int).Value = anyo
        sdr = sc.ExecuteReader
        If sdr.Read Then
            sdr.Close()
            sdr = Nothing
            sc = Nothing
            Return True
        End If
        sdr.Close()
        sdr = Nothing
        sc = Nothing
        Return False
    End Function
    Private Function DeleteZeroValuesSQL() As Boolean
        Dim sc As SqlCommand, i As Integer
        sc = New SqlCommand("DELETE * FROM " & getTable() & " WHERE " & VALOR & "=0", DBCONNECT.getConnection)
        i = sc.ExecuteNonQuery
        sc = Nothing
        If i > 1 Then
            Return True
        End If
        Return False
    End Function
    Private Function getAnyosSQL(idEmpresa As Integer) As List(Of Integer)
        Dim sc As SqlCommand, sdr As SqlDataReader
        getAnyosSQL = New List(Of Integer)
        sc = New SqlCommand("SELECT distinct " & ANYO & " FROM " & getTable() & " WHERE " & ID_EMPRESA & "= @idEmpresa  ORDER BY " & ANYO, DBCONNECT.getConnection)
        sc.Parameters.Add("@idEmpresa", SqlDbType.Int).Value = idEmpresa
        sdr = sc.ExecuteReader
        While sdr.Read()
            getAnyosSQL.Add(sdr(ANYO))
        End While
        sdr.Close()
        sdr = Nothing
        sc = Nothing
    End Function
    Private Function getObjectsSQL(a As Integer) As List(Of ValorMes)()
        Dim sc As SqlCommand, sdr As SqlDataReader, dades(12) As List(Of ValorMes)
        sc = New SqlCommand("Select * FROM " & getTable() & " WHERE " & ANYO & " = " & a, DBCONNECT.getConnection)
        sdr = sc.ExecuteReader
        While sdr.Read()
            If dades(sdr(MES)) Is Nothing Then dades(sdr(MES)) = New List(Of ValorMes)
            dades(sdr(MES)).Add(New ValorMes(sdr(ANYO), sdr(MES), sdr(ID_PROJECTE), sdr(ID_SUBCOMPTE), sdr(ID_EMPRESA), sdr(ID_SUBGRUP), sdr(VALOR)))
        End While
        sdr.Close()
        sdr = Nothing
        sc = Nothing
        Return dades
    End Function

    'dbf
    Private Sub saveMesAnyDBF(valors As List(Of ValorMes), a As Integer, m As Integer)
        Dim sc As ADODB.Command, rc As ADODB.Recordset, v As ValorMes
        sc = New ADODB.Command
        rc = New ADODB.Recordset
        With sc
            .ActiveConnection = DBCONNECT.getConnectionDbf
            .CommandText = "SELECT * FROM " & getTable() & " WHERE  " & ANYO & " = ? AND " & MES & "= ?"
            .Parameters.Append(ADOPARAM.ToInt(a))
            .Parameters.Append(ADOPARAM.ToInt(m))
        End With
        rc.Open(sc)
        While Not rc.EOF
            For Each v In valors
                If _
                      rc(ANYO).Value = v.any _
                  And rc(MES).Value = v.mes _
                  And rc(ID_PROJECTE).Value = v.idProjecte _
                  And rc(ID_SUBCOMPTE).Value = v.idSubcompte _
                  And rc(ID_SUBGRUP).Value = v.idSubgrup _
                  And rc(ID_EMPRESA).Value = v.idEmpresa _
                Then
                    sc = New ADODB.Command
                    With sc
                        .ActiveConnection = DBCONNECT.getConnectionDbf
                        .CommandText = "UPDATE " & getTable() & " SET " & VALOR & "= ? WHERE " & ANYO & " = ? " &
                                                                                             " AND " & MES & " = ? " &
                                                                                             " AND " & ID_PROJECTE & " = ? " &
                                                                                             " AND " & ID_SUBCOMPTE & " = ? " &
                                                                                             " AND " & ID_SUBGRUP & " = ? " &
                                                                                            " AND " & ID_EMPRESA & " = ? "

                        .Parameters.Append(ADOPARAM.ToSingle(v.valor))
                        .Parameters.Append(ADOPARAM.ToInt(v.any))
                        .Parameters.Append(ADOPARAM.ToInt(v.mes))
                        .Parameters.Append(ADOPARAM.ToInt(v.idProjecte))
                        .Parameters.Append(ADOPARAM.ToInt(v.idSubcompte))
                        .Parameters.Append(ADOPARAM.ToInt(v.idSubgrup))
                        .Parameters.Append(ADOPARAM.ToInt(v.idEmpresa))
                    End With
                    Try
                        sc.Execute()
                        v.actualitzat = True
                    Catch ex As Exception
                        v.actualitzat = False
                    End Try
                    Exit For
                End If
            Next
            rc.MoveNext()
        End While
        rc.Close()
        For Each v In valors
            If Not v.actualitzat Then
                sc = New ADODB.Command
                With sc
                    .ActiveConnection = DBCONNECT.getConnectionDbf
                    .CommandText = "INSERT INTO " & getTable() & " (" & ANYO & "," & MES & "," & ID_SUBCOMPTE & "," & ID_SUBGRUP & "," & ID_PROJECTE & "," & ID_EMPRESA & "," & VALOR & ") VALUES(?,?,?,?,?,?,?)"
                    .Parameters.Append(ADOPARAM.ToInt(v.any))
                    .Parameters.Append(ADOPARAM.ToInt(v.mes))
                    .Parameters.Append(ADOPARAM.ToInt(v.idSubcompte))
                    .Parameters.Append(ADOPARAM.ToInt(v.idSubgrup))
                    .Parameters.Append(ADOPARAM.ToInt(v.idProjecte))
                    .Parameters.Append(ADOPARAM.ToInt(v.idEmpresa))
                    .Parameters.Append(ADOPARAM.ToSingle(v.valor))
                End With
                Try
                    sc.Execute()
                Catch ex As Exception
                End Try
                Exit For
            End If
        Next
        rc.Close()
        sc = Nothing
        rc = Nothing
    End Sub
    Private Function removeDBF(idProjecte As Integer, m As Integer, a As Integer) As Boolean
        Dim sc As ADODB.Command
        sc = New ADODB.Command
        With sc
            .ActiveConnection = DBCONNECT.getConnectionDbf
            .CommandText = "delete()  FROM " & getTable() & " WHERE " & ID_PROJECTE & "= ? And " & ANYO & "= ? And  " & MES & " = ?"
            .Parameters.Append(ADOPARAM.ToInt(idProjecte))
            .Parameters.Append(ADOPARAM.ToInt(a))
            .Parameters.Append(ADOPARAM.ToInt(m))
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
    Private Function hihaDadesDBF(idProjecte As Integer, anyo As Integer) As Boolean
        Dim sc As ADODB.Command, rc As ADODB.Recordset
        sc = New ADODB.Command
        rc = New ADODB.Recordset
        With sc
            .ActiveConnection = DBCONNECT.getConnectionDbf
            .CommandText = "Select top 1 " & MES & " FROM " & getTable() & " WHERE " & ID_PROJECTE & "=? And " & anyo & "= ?"
            .Parameters.Append(ADOPARAM.ToInt(idProjecte))
            .Parameters.Append(ADOPARAM.ToInt(anyo))
        End With
        Try
            rc.Open(sc)
            If Not rc.EOF Then
                Return True
            Else
                Return False
            End If
            rc.Close()
        Catch ex As Exception
            ERRORS.ERR_EXCEPTION_SQL(ex.Message)
            Return False
        Finally
            If rc.State = 1 Then rc.Close()
            rc = Nothing
            sc = Nothing
        End Try
    End Function
    Private Function DeleteZeroValuesDBF() As Boolean
        Dim sc As ADODB.Command
        sc = New ADODB.Command
        With sc
            .ActiveConnection = DBCONNECT.getConnectionDbf
            .CommandText = "DELETE * FROM " & getTable() & " WHERE " & VALOR & "=0"
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
    Private Function getAnyosDBF(idEmpresa As Integer) As List(Of Integer)
        Dim sc As ADODB.Command, rc As ADODB.Recordset
        sc = New ADODB.Command
        rc = New ADODB.Recordset
        getAnyosDBF = New List(Of Integer)
        With sc
            .ActiveConnection = DBCONNECT.getConnectionDbf
            .CommandText = "Select distinct " & ANYO & " FROM " & getTable() & " WHERE " & ID_EMPRESA & "= ?  ORDER BY " & ANYO
            .Parameters.Append(ADOPARAM.ToInt(idEmpresa))
        End With
        Try
            rc.Open(sc)
            While Not rc.EOF
                getAnyosDBF.Add(rc(ANYO).Value)
                rc.movnext
            End While
            rc.Close()
        Catch ex As Exception
            ERRORS.ERR_EXCEPTION_SQL(ex.Message)
        Finally
            If rc.State = 1 Then rc.Close()
            rc = Nothing
            sc = Nothing
        End Try
    End Function
    Private Function getObjectsDBF(a As Integer) As List(Of ValorMes)()
        Dim rc As ADODB.Recordset, dades(12) As List(Of ValorMes)
        rc = New ADODB.Recordset
        rc.Open("Select * FROM " & getTable() & " WHERE " & ANYO & " = " & a, DBCONNECT.getConnectionDbf)
        While Not rc.EOF
            If dades(rc(MES).Value) Is Nothing Then dades(rc(MES).Value) = New List(Of ValorMes)
            dades(rc(MES).Value).Add(New ValorMes(rc(ANYO).Value, rc(MES).Value, rc(ID_PROJECTE).Value, rc(ID_SUBCOMPTE).Value, rc(ID_EMPRESA).Value, rc(ID_SUBGRUP).Value, rc(VALOR).Value))
            rc.MoveNext()
        End While
        rc.Close()
        rc = Nothing
        Return dades
    End Function
    Private Function getTable() As String
        Return DBCONNECT.getTaulaPretancament
    End Function

End Module
