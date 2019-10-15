Option Explicit On
Imports System.Data.SqlClient
Module dbSubgrup
    Private Const ID As String = "id"
    Private Const ID_GRUP As String = "idGrup"
    Private Const CODI As String = "codi"
    Private Const NOM As String = "descripcio"
    Private Const NOTES As String = "notes"
    Private Const TIPUS_CODI As String = "tipusCodi"
    Private Const ORDRE As String = "ordre"
    Private Const ES_VARIABLE As String = "esVariable"
    Private Const ES_COMPRA As String = "esCompra"

    Public Function update(obj As Subgrup) As Integer
        If IS_SQLSERVER Then Return updateSQL(obj)
        Return updateDBF(obj)
    End Function
    Public Function insert(obj As Subgrup) As Integer
        If IS_SQLSERVER Then Return insertSQL(obj)
        Return insertDBF(obj)
    End Function
    Public Function remove(obj As Subgrup) As Boolean
        If IS_SQLSERVER Then Return removeSQL(obj)
        Return removeDBF(obj)
    End Function
    Public Function removeGrup(obj As Grup) As Boolean
        If IS_SQLSERVER Then Return removeGrupSQL(obj)
        Return removeGrupDBF(obj)
    End Function
    Public Function getObjects() As List(Of Subgrup)
        If IS_SQLSERVER Then Return getObjectsSQL()
        Return getObjectsDBF()
    End Function

    ''' <summary>
    ''' Guardar un subgrup comptable a la base de dades.
    ''' Si no existeix l'insereix, sino l'actualitza
    ''' </summary>
    ''' <param name="obj">subgrupComptable a guardar</param>
    ''' <returns>l'identificador del subgrup comptable guardat</returns>
    Private Function insertSQL(obj As Subgrup) As Integer
        Dim sc As SqlCommand, i As Integer
        obj.id = DBCONNECT.getMaxId(getTable()) + 1
        sc = New SqlCommand(" INSERT INTO " & getTable() & " " &
                                " (" & ID & ", " & ID_GRUP & ", " & CODI & ", " & NOM & ", " & NOTES & "," & TIPUS_CODI & "," & ORDRE & "," & ES_VARIABLE & "," & ES_COMPRA & ")" &
                                " VALUES(@id,@idGrup,@codi,@nom,@notes,@tipusCodi,@ordre,@esVariable,@esCompra)", DBCONNECT.getConnection)
        sc.Parameters.Add("@id", SqlDbType.Int).Value = obj.id
        sc.Parameters.Add("@idGrup", SqlDbType.Int).Value = obj.idGrup
        sc.Parameters.Add("@codi", SqlDbType.VarChar).Value = obj.codi
        sc.Parameters.Add("@nom", SqlDbType.VarChar).Value = obj.nom
        sc.Parameters.Add("@notes", SqlDbType.VarChar).Value = obj.notes
        sc.Parameters.Add("@tipusCodi", SqlDbType.Int).Value = obj.tipusCodi
        sc.Parameters.Add("@ordre", SqlDbType.Int).Value = Val(obj.ordre)
        sc.Parameters.Add("@esVariable", SqlDbType.Bit).Value = obj.esDespesaVariable
        sc.Parameters.Add("@esCompra", SqlDbType.Bit).Value = obj.esDespesaCompra
        i = sc.ExecuteNonQuery
        sc = Nothing
        If i > 1 Then
            Return obj.id
        End If
        Return -1
    End Function
    Private Function updateSQL(obj As Subgrup) As Integer
        Dim sc As SqlCommand, i As Integer

        sc = New SqlCommand("UPDATE " & getTable() & " " &
                                " SET " & ID_GRUP & "=@idgrup," & CODI & "=@codi," & NOM & " =@nom, " & NOTES & "=@notes, " & TIPUS_CODI & "=@tipusCodi, " & ORDRE & "=@ordre, " & ES_VARIABLE & "=@esVariable, " & ES_COMPRA & "=@esCompra " &
                                " WHERE " & ID & "=@id", DBCONNECT.getConnection)

        sc.Parameters.Add("@id", SqlDbType.Int).Value = obj.id
        sc.Parameters.Add("@idGrup", SqlDbType.Int).Value = obj.idGrup
        sc.Parameters.Add("@codi", SqlDbType.VarChar).Value = obj.codi
        sc.Parameters.Add("@nom", SqlDbType.VarChar).Value = obj.nom
        sc.Parameters.Add("@notes", SqlDbType.VarChar).Value = obj.notes
        sc.Parameters.Add("@tipusCodi", SqlDbType.Int).Value = obj.tipusCodi
        sc.Parameters.Add("@ordre", SqlDbType.Int).Value = Val(obj.ordre)
        sc.Parameters.Add("@esVariable", SqlDbType.Bit).Value = obj.esDespesaVariable
        sc.Parameters.Add("@esCompra", SqlDbType.Bit).Value = obj.esDespesaCompra
        i = sc.ExecuteNonQuery
        sc = Nothing
        If i > 1 Then
            Return obj.id
        End If
        Return -1
    End Function
    ''' <summary>
    ''' Elimina un subgrup comptable de la base de dades i del sistema
    ''' </summary>
    ''' <param name="obj">Subgrup comptable a eliminar</param>
    ''' <returns>cert si s'ha eliminat, fals en cas contrari</returns>
    Private Function removeSQL(obj As Subgrup) As Boolean
        Dim sc As SqlCommand, i As Integer
        sc = New SqlCommand("DELETE FROM " & getTable() & " WHERE " & ID & "=@ID", DBCONNECT.getConnection)
        sc.Parameters.Add("@id", SqlDbType.Int).Value = obj.id
        i = sc.ExecuteNonQuery
        sc = Nothing
        If i > 1 Then
            Return True
        End If
        Return False
    End Function

    Private Function removeGrupSQL(g As Grup) As Boolean
        Dim sc As SqlCommand, i As Integer, sg As Subgrup
        For Each sg In g.subgrups
            Call ModelSubcomptesGrup.removeGroup(sg.id)
        Next sg
        sc = New SqlCommand("DELETE  FROM " & getTableGrups() & " WHERE id=" & g.id, DBCONNECT.getConnection)
        sc.Parameters.Add("@id", SqlDbType.Int).Value = g.id
        i = sc.ExecuteNonQuery
        sc = Nothing
        sg = Nothing
        If i > 1 Then
            Return True
        End If
        Return False
    End Function
    ''' <summary>
    ''' obté tots els subgrupsComptables de la BBDD
    ''' </summary>
    ''' <returns>Una llista de tots els SubgrupsComptables de la BBDD</returns>
    Private Function getObjectsSQL() As List(Of Subgrup)
        Dim sc As SqlCommand, sdr As SqlDataReader
        getObjectsSQL = New List(Of Subgrup)
        sc = New SqlCommand("Select * FROM " & getTable(), DBCONNECT.getConnection)
        sdr = sc.ExecuteReader
        While sdr.Read()
            getObjectsSQL.Add(New Subgrup(sdr(ID), sdr(ID_GRUP), Trim(sdr(CODI)), Trim(sdr(NOM)), Trim(CONFIG.validarNull(sdr(NOTES))), sdr(ORDRE), sdr(TIPUS_CODI), sdr(ES_VARIABLE), sdr(ES_COMPRA), ModelSubcomptesGrup.getObjects(sdr(ID))))
        End While
        sdr.Close()
        sdr = Nothing
        sc = Nothing
    End Function
    ''' <summary>
    ''' Guardar un subgrup comptable a la base de dades.
    ''' Si no existeix l'insereix, sino l'actualitza
    ''' </summary>
    ''' <param name="obj">subgrupComptable a guardar</param>
    ''' <returns>l'identificador del subgrup comptable guardat</returns>
    Private Function insertDBF(obj As Subgrup) As Integer
        Dim sc As ADODB.Command
        sc = New ADODB.Command
        obj.id = DBCONNECT.getMaxIdDBF(getTable) + 1
        With sc
            .ActiveConnection = DBCONNECT.getConnectionDbf
            .CommandText = " INSERT INTO " & getTable() & " " &
                                " (" & ID & ", " & ID_GRUP & ", " & CODI & ", " & NOM & ", " & NOTES & "," & TIPUS_CODI & "," & ORDRE & "," & ES_VARIABLE & "," & ES_COMPRA & ")" &
                                " VALUES(?,?,?,?,?,?,?,?,?)"
            .Parameters.Append(ADOPARAM.ToInt(obj.id))
            .Parameters.Append(ADOPARAM.ToInt(obj.idGrup))
            .Parameters.Append(ADOPARAM.ToString(obj.codi))
            .Parameters.Append(ADOPARAM.ToString(obj.nom))
            .Parameters.Append(ADOPARAM.ToString(obj.notes))
            .Parameters.Append(ADOPARAM.ToInt(obj.tipusCodi))
            .Parameters.Append(ADOPARAM.ToString(obj.ordre))
            .Parameters.Append(ADOPARAM.toBool(obj.esDespesaVariable))
            .Parameters.Append(ADOPARAM.toBool(obj.esDespesaCompra))
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
    Private Function updateDBF(obj As Subgrup) As Integer
        Dim sc As ADODB.Command
        sc = New ADODB.Command
        With sc
            .ActiveConnection = DBCONNECT.getConnectionDbf
            .CommandText = "UPDATE " & getTable() & " " &
                                " SET " & ID_GRUP & "=?," & CODI & "=?," & NOM & " =?, " & NOTES & "=?, " & TIPUS_CODI & "=?, " & ORDRE & "=?, " & ES_VARIABLE & "=?, " & ES_COMPRA & "=? " &
                                " WHERE " & ID & "=@id"
            .Parameters.Append(ADOPARAM.ToInt(obj.idGrup))
            .Parameters.Append(ADOPARAM.ToString(obj.codi))
            .Parameters.Append(ADOPARAM.ToString(obj.nom))
            .Parameters.Append(ADOPARAM.ToString(obj.notes))
            .Parameters.Append(ADOPARAM.ToInt(obj.tipusCodi))
            .Parameters.Append(ADOPARAM.ToString(obj.ordre))
            .Parameters.Append(ADOPARAM.toBool(obj.esDespesaVariable))
            .Parameters.Append(ADOPARAM.toBool(obj.esDespesaCompra))
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
    ''' <summary>
    ''' Elimina un subgrup comptable de la base de dades i del sistema
    ''' </summary>
    ''' <param name="obj">Subgrup comptable a eliminar</param>
    ''' <returns>cert si s'ha eliminat, fals en cas contrari</returns>
    Private Function removeDBF(obj As Subgrup) As Boolean
        Dim sc As ADODB.Command
        sc = New ADODB.Command
        With sc
            sc.ActiveConnection = DBCONNECT.getConnectionDbf
            sc.CommandText = "DELETE FROM " & getTable() & " WHERE " & ID & "=? "
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

    Private Function removeGrupDBF(g As Grup) As Boolean
        Dim sc As ADODB.Command, sg As Subgrup
        sc = New ADODB.Command
        For Each sg In g.subgrups
            Call ModelSubcomptesGrup.removeGroup(sg.id)
        Next sg
        With sc
            sc.ActiveConnection = DBCONNECT.getConnectionDbf
            sc.CommandText = "DELETE  FROM " & getTableGrups() & " WHERE id=" & g.id
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
    ''' obté tots els subgrupsComptables de la BBDD
    ''' </summary>
    ''' <returns>Una llista de tots els SubgrupsComptables de la BBDD</returns>
    Private Function getObjectsDBF() As List(Of Subgrup)
        Dim rc As ADODB.Recordset
        rc = New ADODB.Recordset
        getObjectsDBF = New List(Of Subgrup)
        rc.Open("Select * FROM " & getTable(), DBCONNECT.getConnectionDbf)
        While Not rc.EOF
            getObjectsDBF.Add(New Subgrup(rc(ID).Value, rc(ID_GRUP).Value, Trim(rc(CODI).Value), Trim(rc(NOM).Value), Trim(CONFIG.validarNull(rc(NOTES).Value)), rc(ORDRE).Value, rc(TIPUS_CODI).Value, rc(ES_VARIABLE).Value, rc(ES_COMPRA).Value, ModelSubcomptesGrup.getObjects(rc(ID).Value)))
            rc.MoveNext()
        End While
        If rc.State = 1 Then rc.Close()
        rc = Nothing
        getObjectsDBF.Sort()
    End Function

    ''' <summary>
    ''' obté el nom de la taula de la BBDD
    ''' </summary>
    ''' <returns>String</returns>
    Private Function getTable() As String
        Return DBCONNECT.getTaulaSubGrups
    End Function
    Private Function getTableGrups() As String
        Return DBCONNECT.getTaulaGrups
    End Function
End Module
