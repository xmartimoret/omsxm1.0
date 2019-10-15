Option Explicit On
Imports System.Data.SqlClient

Module dbSubcomptesGrup
    Private Const ID_SUBCTE As String = "IDSUBCTA"
    Private Const ID_SUBGRUP As String = "IDGRUP"
    Private Const ES_VARIABLE As String = "esVariable"
    Private Const ES_COMPRA As String = "esCompra"
    Public Function update(obj As SubcompteGrup) As Integer
        If IS_SQLSERVER Then Return updateSQL(obj)
        Return updateDBF(obj)
    End Function
    Public Function updateSubgrup(obj As Subgrup) As Boolean
        If IS_SQLSERVER Then Return updateSubgrupSQL(obj)
        Return updateSubgrupDBF(obj)
    End Function
    Public Function insert(obj As SubcompteGrup) As Integer
        If IS_SQLSERVER Then Return insertSQL(obj)
        Return insertDBF(obj)
    End Function
    Public Function remove(obj As SubcompteGrup) As Boolean
        If IS_SQLSERVER Then Return removeSQL(obj)
        Return removeDBF(obj)
    End Function
    Public Function removeGroup(idGrup As Integer) As Boolean
        If IS_SQLSERVER Then Return removeGroupSQL(idGrup)
        Return removeGroupDBF(idGrup)
    End Function
    Public Function getObjects() As List(Of SubcompteGrup)
        If IS_SQLSERVER Then Return getObjectsSQL()
        Return getObjectsDBF()
    End Function

    ''' <summary>
    ''' Guarda un subcompteSubgrup Comptable a la BBDD.
    ''' Si no existeix l'inserta, sinó l'actualitza
    ''' </summary>
    ''' <param name="obj">SubcompteSubgrup a guardar</param>
    ''' <returns>Cert si l'operació s'ha dut a terme,fals en cas contrari</returns>
    Private Function insertSQL(obj As SubcompteGrup) As Boolean
        Dim sc As SqlCommand, i As Integer
        sc = New SqlCommand(" INSERT INTO " & getTable() & " " &
                                " (" & ID_SUBCTE & ", " & ID_SUBGRUP & ", " & ES_COMPRA & ", " & ES_VARIABLE & ")" &
                                " VALUES(@idSubcompte,@idSubgrup,@esCompra,@esVariable)", DBCONNECT.getConnection)
        sc.Parameters.Add("@idSubcompte", SqlDbType.Int).Value = obj.idSubcompte
        sc.Parameters.Add("@idSubgrup", SqlDbType.Int).Value = obj.idSubGrup
        sc.Parameters.Add("@esCompra", SqlDbType.Bit).Value = obj.esDespesaCompra
        sc.Parameters.Add("@esVariable", SqlDbType.Bit).Value = obj.esDespesaVariable
        i = sc.ExecuteNonQuery
        sc = Nothing
        If i >= 1 Then
            Return True
        End If
        Return False
    End Function
    ''' <summary>
    ''' Guarda un subcompteSubgrup Comptable a la BBDD.
    ''' Si no existeix l'inserta, sinó l'actualitza
    ''' </summary>
    ''' <param name="obj">SubcompteSubgrup a guardar</param>
    ''' <returns>Cert si l'operació s'ha dut a terme,fals en cas contrari</returns>
    Private Function updateSQL(obj As SubcompteGrup) As Boolean
        Dim sc As SqlCommand, i As Integer
        sc = New SqlCommand("UPDATE " & getTable() & " " &
                                " SET " & ES_COMPRA & "=@esCompra," & ES_VARIABLE & "=@esVariable " &
                                " WHERE " & ID_SUBCTE & "=@idSubcompte AND " & ID_SUBGRUP & "=@idSubgrup", DBCONNECT.getConnection)
        sc.Parameters.Add("@idSubcompte", SqlDbType.Int).Value = obj.idSubcompte
        sc.Parameters.Add("@idSubgrup", SqlDbType.Int).Value = obj.idSubGrup
        sc.Parameters.Add("@esCompra", SqlDbType.Bit).Value = obj.esDespesaCompra
        sc.Parameters.Add("@esVariable", SqlDbType.Bit).Value = obj.esDespesaVariable
        i = sc.ExecuteNonQuery
        sc = Nothing
        If i >= 1 Then
            Return True
        End If
        Return False
    End Function
    ''' <summary>
    ''' Actualitza els camps despesa variable i despesa de compra de tot un Subgrup Comptable
    ''' </summary>
    ''' <param name="obj"> SubGrup a actualitzar</param>
    ''' <returns>Cert si es dur a terme l'operació, fals en cas contrari</returns>
    Private Function updateSubgrupSQL(obj As Subgrup) As Boolean
        Dim sc As SqlCommand, i As Integer
        sc = New SqlCommand("UPDATE " & getTable() & " SET " & ES_VARIABLE & "=@esVariable," & ES_COMPRA & "= @esCompra WHERE " & ID_SUBGRUP & " = @idSubGrup", DBCONNECT.getConnection)
        sc.Parameters.Add("@idSubGrup", SqlDbType.Int).Value = obj.id
        sc.Parameters.Add("@esVariable", SqlDbType.Bit).Value = obj.intDespesaVariable
        sc.Parameters.Add("@esCompra", SqlDbType.Bit).Value = obj.intDespesaCompra
        i = sc.ExecuteNonQuery
        sc = Nothing
        If i >= 1 Then
            Return True
        End If
        Return False
    End Function
    ''' <summary>
    '''  Elimina un SubcompteSubgrup  de la BBDD
    ''' </summary>
    ''' <param name="obj">SubcompteSubgrup a eliminar</param>
    ''' <returns>Cert si es dur a terme l'acció, fals en cas contrari</returns>
    Private Function removeSQL(obj As SubcompteGrup) As Boolean
        Dim sc As SqlCommand, i As Integer
        sc = New SqlCommand("DELETE FROM " & getTable() & " WHERE " & ID_SUBGRUP & "=@idSubGrup AND " & ID_SUBCTE & "=@idSubcte", DBCONNECT.getConnection)
        sc.Parameters.Add("@idSubGrup", SqlDbType.Int).Value = obj.idSubGrup
        sc.Parameters.Add("@idSubcte", SqlDbType.Int).Value = obj.idSubcompte
        i = sc.ExecuteNonQuery
        sc = Nothing
        If i >= 1 Then

            Return True
        End If
        Return False
    End Function
    ''' <summary>
    '''  Elimina totes les subcomptes d'un subgrup a la BBDD
    ''' </summary>
    ''' <param name="idGrup">Id del Subgrup  a l'eliminar els Subcomptes</param>
    ''' <returns>Cert si es dur a terme l'acció, fals en cas contrari</returns>
    Private Function removeGroupSQL(idGrup As Integer) As Boolean
        Dim sc As SqlCommand, i As Integer
        sc = New SqlCommand("DELETE FROM " & getTable() & " WHERE " & ID_SUBGRUP & "=@idGrup", DBCONNECT.getConnection)
        sc.Parameters.Add("@idGrup", SqlDbType.Int).Value = idGrup
        i = sc.ExecuteNonQuery
        sc = Nothing
        If i > 1 Then
            Return True
        End If
        Return False
    End Function

    ''' <summary>
    ''' Obté tots els objectes SubcompteSubgrup de la base de dades
    ''' </summary>
    ''' <returns>Llista de subcompteGrup</returns>
    Private Function getObjectsSQL() As List(Of SubcompteGrup)
        Dim sc As SqlCommand, sdr As SqlDataReader, sqlString As String
        getObjectsSQL = New List(Of SubcompteGrup)
        sqlString = " SELECT CG.IDGRUP AS IDSUBGRUP,SG.IDGRUP AS IDGRUP, CG.IDSUBCTA AS IDSUBCTA, SG.CODI AS SGCODI, S.CODI AS SCODI, S.DESCRIPCIO AS SNOM, CG.ESCOMPRA AS SESCOMP, CG.ESVARIABLE AS SESVAR  " &
                    " FROM (" & getTable() & " AS CG INNER JOIN " & getTableSubcomptes() & " AS S ON (CG.IDSUBCTA = S.ID))" &
                                                   " INNER JOIN " & getTableSubgrups() & " As SG  On (CG.IDGRUP = SG.ID)"
        sc = New SqlCommand(sqlString, DBCONNECT.getConnection)
        sdr = sc.ExecuteReader
        While sdr.Read()
            getObjectsSQL.Add(New SubcompteGrup(sdr("IDSUBGRUP"), sdr("IDGRUP"), sdr("IDSUBCTA"), sdr("SCODI"), sdr("SGCODI"), sdr("SESCOMP"), sdr("SESVAR"), sdr("SNOM")))
        End While
        sdr.Close()
        sdr = Nothing
        sc = Nothing
    End Function
    ''' <summary>
    ''' Guarda un subcompteSubgrup Comptable a la BBDD.
    ''' Si no existeix l'inserta, sinó l'actualitza
    ''' </summary>
    ''' <param name="obj">SubcompteSubgrup a guardar</param>
    ''' <returns>Cert si l'operació s'ha dut a terme,fals en cas contrari</returns>
    Private Function insertDBF(obj As SubcompteGrup) As Boolean
        Dim sc As ADODB.Command
        sc = New ADODB.Command
        With sc
            .ActiveConnection = DBCONNECT.getConnectionDbf
            .CommandText = " INSERT INTO " & getTable() & " " &
                                " (" & ID_SUBCTE & ", " & ID_SUBGRUP & ", " & ES_COMPRA & ", " & ES_VARIABLE & ")" &
                                " VALUES(?,?,?,?)"
            .Parameters.Append(ADOPARAM.ToInt(obj.idSubcompte))
            .Parameters.Append(ADOPARAM.ToInt(obj.idSubGrup))
            .Parameters.Append(ADOPARAM.toBool(obj.esDespesaCompra))
            .Parameters.Append(ADOPARAM.toBool(obj.esDespesaVariable))
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
    ''' Guarda un subcompteSubgrup Comptable a la BBDD.
    ''' Si no existeix l'inserta, sinó l'actualitza
    ''' </summary>
    ''' <param name="obj">SubcompteSubgrup a guardar</param>
    ''' <returns>Cert si l'operació s'ha dut a terme,fals en cas contrari</returns>
    Private Function updateDBF(obj As SubcompteGrup) As Boolean
        Dim sc As ADODB.Command
        sc = New ADODB.Command
        With sc
            .ActiveConnection = DBCONNECT.getConnectionDbf
            .CommandText = "UPDATE " & getTable() & " " &
                                " SET " & ES_COMPRA & "=?," & ES_VARIABLE & "=? " &
                                " WHERE " & ID_SUBCTE & "=? AND " & ID_SUBGRUP & "=?"
            .Parameters.Append(ADOPARAM.toBool(obj.esDespesaCompra))
            .Parameters.Append(ADOPARAM.toBool(obj.esDespesaVariable))
            .Parameters.Append(ADOPARAM.ToInt(obj.idSubcompte))
            .Parameters.Append(ADOPARAM.ToInt(obj.idSubGrup))
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
    ''' Actualitza els camps despesa variable i despesa de compra de tot un Subgrup Comptable
    ''' </summary>
    ''' <param name="obj"> SubGrup a actualitzar</param>
    ''' <returns>Cert si es dur a terme l'operació, fals en cas contrari</returns>
    Private Function updateSubgrupDBF(obj As Subgrup) As Boolean
        Dim sc As ADODB.Command
        sc = New ADODB.Command
        With sc
            .ActiveConnection = DBCONNECT.getConnectionDbf
            .CommandText = "UPDATE " & getTable() & " SET " & ES_VARIABLE & "=?," & ES_COMPRA & "= ? WHERE " & ID_SUBGRUP & " = ?"
            .Parameters.Append(ADOPARAM.toBool(obj.esDespesaVariable))
            .Parameters.Append(ADOPARAM.toBool(obj.esDespesaCompra))
            .Parameters.Append(ADOPARAM.ToInt(obj.id))

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
    '''  Elimina un SubcompteSubgrup  de la BBDD
    ''' </summary>
    ''' <param name="obj">SubcompteSubgrup a eliminar</param>
    ''' <returns>Cert si es dur a terme l'acció, fals en cas contrari</returns>
    Private Function removeDBF(obj As SubcompteGrup) As Boolean
        Dim sc As ADODB.Command
        sc = New ADODB.Command
        With sc
            sc.ActiveConnection = DBCONNECT.getConnectionDbf
            sc.CommandText = "DELETE FROM " & getTable() & " WHERE " & ID_SUBGRUP & "=? AND " & ID_SUBCTE & "=?"
            sc.Parameters.Append(ADOPARAM.ToInt(obj.idSubGrup, ""))
            sc.Parameters.Append(ADOPARAM.ToInt(obj.idSubcompte, ""))
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
    '''  Elimina totes les subcomptes d'un subgrup a la BBDD
    ''' </summary>
    ''' <param name="idGrup">Id del Subgrup  a l'eliminar els Subcomptes</param>
    ''' <returns>Cert si es dur a terme l'acció, fals en cas contrari</returns>
    Private Function removeGroupDBF(idGrup As Integer) As Boolean
        Dim sc As ADODB.Command
        sc = New ADODB.Command
        With sc
            sc.ActiveConnection = DBCONNECT.getConnectionDbf
            sc.CommandText = "DELETE FROM " & getTable() & " WHERE " & ID_SUBGRUP & "?"
            sc.Parameters.Append(ADOPARAM.ToInt(idGrup, ""))
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
    ''' Obté tots els objectes SubcompteSubgrup de la base de dades
    ''' </summary>
    ''' <returns>Llista de subcompteGrup</returns>
    Private Function getObjectsDBF() As List(Of SubcompteGrup)
        Dim rc As ADODB.Recordset
        rc = New ADODB.Recordset
        getObjectsDBF = New List(Of SubcompteGrup)
        rc.Open(" SELECT CG.IDGRUP AS IDSUBGRUP,SG.IDGRUP AS IDGRUP, CG.IDSUBCTA AS IDSUBCTA, SG.CODI AS SGCODI, S.CODI AS SCODI, S.DESCRIPCIO AS SNOM, CG.ESCOMPRA AS SESCOMP, CG.ESVARIABLE AS SESVAR  " &
                    " FROM (" & getTable() & " AS CG INNER JOIN " & getTableSubcomptes() & " AS S ON (CG.IDSUBCTA = S.ID))" &
                                                   " INNER JOIN " & getTableSubgrups() & " As SG  On (CG.IDGRUP = SG.ID)", DBCONNECT.getConnectionDbf)
        While Not rc.EOF
            getObjectsDBF.Add(New SubcompteGrup(rc("IDSUBGRUP").Value, rc("IDGRUP").Value, rc("IDSUBCTA").Value, rc("SCODI").Value, rc("SGCODI").Value, rc("SESCOMP").Value, rc("SESVAR").Value, rc("SNOM").Value))
            rc.MoveNext()
        End While
        If rc.State = 1 Then rc.Close()
        rc = Nothing
        'getObjectsDBF.Sort()
    End Function
    ''' <summary>
    ''' Obté el nom de la taula de dades SubcompteGrup
    ''' </summary>
    ''' <returns>String (nom de la taula)</returns>
    Private Function getTable() As String
        getTable = DBCONNECT.getTaulaSubcomptesGrup
    End Function
    ''' <summary>
    ''' Obte el nom de la taula Subcompte a la base de dades
    ''' </summary>
    ''' <returns>String (nom de la taula)</returns>
    Private Function getTableSubcomptes() As String
        getTableSubcomptes = DBCONNECT.getTaulaSubcomptes
    End Function
    ''' <summary>
    ''' Obté el nom de la taula Subgrups de  la base de dades
    ''' </summary>
    ''' <returns>String (nom de la taula)</returns>
    Private Function getTableSubgrups() As String
        getTableSubgrups = DBCONNECT.getTaulaSubGrups
    End Function
End Module
