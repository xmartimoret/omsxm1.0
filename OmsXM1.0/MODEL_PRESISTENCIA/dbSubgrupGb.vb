
Option Explicit On
Imports System.Data.SqlClient
Module dbSubgrupGb
    Private Const ID As String = "id"
    Private Const CODI As String = "codi"
    Private Const NOM As String = "nom"
    Private Const FORMULA As String = "formula"
    Private Const ES_TOTAL As String = "esTotal"
    Private Const ORDRE As String = "ordre"
    Private Const STRING_FORMULA As String = "toStringFormula"
    Public Function update(obj As SubGrupGB) As Integer
        If IS_SQLSERVER Then Return updateSQL(obj)
        Return updateDBF(obj)
    End Function
    Public Function insert(obj As SubGrupGB) As Integer
        If IS_SQLSERVER Then Return insertSQL(obj)
        Return insertDBF(obj)
    End Function
    Public Function remove(id As Integer) As Boolean
        If IS_SQLSERVER Then Return removeSQL(id)
        Return removeDBF(id)
    End Function
    Public Function getObjects() As List(Of SubGrupGB)
        If IS_SQLSERVER Then Return getObjectsSQL()
        Return getObjectsDBF()
    End Function

    Private Function insertSQL(obj As SubGrupGB) As Integer
        Dim sc As SqlCommand, i As Integer
        obj.id = DBCONNECT.getMaxId(getTable()) + 1
        sc = New SqlCommand(" INSERT INTO " & getTable() & " " &
                                " (" & ID & ",  " & CODI & ", " & NOM & ", " & FORMULA & ", " & ES_TOTAL & ", " & ORDRE & "," & STRING_FORMULA & ")" &
                                " VALUES(@id,@codi,@nom,@formula,@esTotal,@ordre,@StringFormula)", DBCONNECT.getConnection)
        sc.Parameters.Add("@id", SqlDbType.Int).Value = obj.id
        sc.Parameters.Add("@codi", SqlDbType.VarChar).Value = obj.codi
        sc.Parameters.Add("@nom", SqlDbType.VarChar).Value = obj.nom
        sc.Parameters.Add("@formula", SqlDbType.VarChar).Value = obj.formula
        sc.Parameters.Add("@esTotal", SqlDbType.Bit).Value = obj.esTotal
        sc.Parameters.Add("@ordre", SqlDbType.Int).Value = obj.ordre
        sc.Parameters.Add("@StringFormula", SqlDbType.Int).Value = obj.toStringFormula
        i = sc.ExecuteNonQuery
        sc = Nothing
        If i >= 1 Then
            Return obj.id
        End If
        Return -1
    End Function
    Private Function updateSQL(obj As SubGrupGB) As Integer
        Dim sc As SqlCommand, i As Integer
        sc = New SqlCommand("UPDATE " & getTable() & " " &
                                " SET " & CODI & "=@codi," & NOM & " =@nom, " & FORMULA & "=@formula, " & ES_TOTAL & "=@esTotal, " & ORDRE & "=@ordre, " & STRING_FORMULA & " =@StringFormula " &
                                " WHERE " & ID & "=@id", DBCONNECT.getConnection)
        sc.Parameters.Add("@id", SqlDbType.Int).Value = obj.id
        sc.Parameters.Add("@codi", SqlDbType.VarChar).Value = obj.codi
        sc.Parameters.Add("@nom", SqlDbType.VarChar).Value = obj.nom
        sc.Parameters.Add("@formula", SqlDbType.VarChar).Value = obj.formula
        sc.Parameters.Add("@esTotal", SqlDbType.Bit).Value = obj.esTotal
        sc.Parameters.Add("@ordre", SqlDbType.Int).Value = obj.ordre
        sc.Parameters.Add("@StringFormula", SqlDbType.VarChar).Value = obj.toStringFormula
        i = sc.ExecuteNonQuery
        sc = Nothing
        If i >= 1 Then
            Return obj.id
        End If
        Return -1
    End Function
    ''' <summary>
    ''' Elimina un Grup comptable de la base de dades i del sistema
    ''' </summary>
    ''' <param name="id">Grup comptable a eliminar</param>
    ''' <returns>cert si s'ha eliminat, fals en cas contrari</returns>
    Private Function removeSQL(id As Integer) As Boolean
        Dim sc As SqlCommand, i As Integer
        sc = New SqlCommand("DELETE FROM " & getTable() & " WHERE " & id & "=@id", DBCONNECT.getConnection)
        sc.Parameters.Add("@id", SqlDbType.Int).Value = id
        i = sc.ExecuteNonQuery
        sc = Nothing
        If i > 1 Then
            Return True
        End If
        Return False
    End Function
    ''' <summary>
    ''' obté tots els subgrupsComptables de la BBDD
    ''' </summary>
    ''' <returns>Una llista de tots els SubgrupsComptables de la BBDD</returns>
    Private Function getObjectsSQL() As List(Of SubGrupGB)
        Dim sc As SqlCommand, sdr As SqlDataReader
        getObjectsSQL = New List(Of SubGrupGB)
        sc = New SqlCommand("Select * FROM " & getTable(), DBCONNECT.getConnection)
        sdr = sc.ExecuteReader
        While sdr.Read()
            getObjectsSQL.Add(New SubGrupGB(sdr(ID), Trim(sdr(CODI)), Trim(sdr(NOM)), Trim(CONFIG.validarNull(sdr(FORMULA))), sdr(ORDRE), sdr(ES_TOTAL), CONFIG.validarNull(sdr(STRING_FORMULA))))
        End While
        sdr.Close()
        sdr = Nothing
        sc = Nothing
    End Function
    Private Function insertDBF(obj As SubGrupGB) As Integer
        Dim sc As ADODB.Command
        sc = New ADODB.Command
        obj.id = DBCONNECT.getMaxIdDBF(getTable) + 1
        With sc
            .ActiveConnection = DBCONNECT.getConnectionDbf
            .CommandText = " INSERT INTO " & getTable() & " " &
                                " (" & ID & ",  " & CODI & ", " & NOM & ", " & FORMULA & ", " & ES_TOTAL & ", " & ORDRE & "," & STRING_FORMULA & ")" &
                                " VALUES(?,?,?,?,?,?,?)"
            .Parameters.Append(ADOPARAM.ToInt(obj.id))
            .Parameters.Append(ADOPARAM.ToString(obj.codi))
            .Parameters.Append(ADOPARAM.ToString(obj.nom))
            .Parameters.Append(ADOPARAM.ToString(obj.formula))
            .Parameters.Append(ADOPARAM.toBool(obj.esTotal))
            .Parameters.Append(ADOPARAM.ToString(obj.ordre))
            .Parameters.Append(ADOPARAM.ToString(obj.toStringFormula))
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
    Private Function updateDBF(obj As SubGrupGB) As Integer
        Dim sc As ADODB.Command
        sc = New ADODB.Command
        With sc
            .ActiveConnection = DBCONNECT.getConnectionDbf
            .CommandText = "UPDATE " & getTable() & " " &
                                " SET " & CODI & "=?," & NOM & " =?, " & FORMULA & "=?, " & ES_TOTAL & "=?, " & ORDRE & "=?, " & STRING_FORMULA & " =? " &
                                " WHERE " & ID & "=?"
            .Parameters.Append(ADOPARAM.ToString(obj.codi))
            .Parameters.Append(ADOPARAM.ToString(obj.nom))
            .Parameters.Append(ADOPARAM.ToString(obj.formula))
            .Parameters.Append(ADOPARAM.toBool(obj.esTotal))
            .Parameters.Append(ADOPARAM.ToString(obj.ordre))
            .Parameters.Append(ADOPARAM.ToString(obj.toStringFormula))
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
    ''' Elimina un Grup comptable de la base de dades i del sistema
    ''' </summary>
    ''' <param name="id">Grup comptable a eliminar</param>
    ''' <returns>cert si s'ha eliminat, fals en cas contrari</returns>
    Private Function removeDBF(id As Integer) As Boolean
        Dim sc As ADODB.Command
        sc = New ADODB.Command
        With sc
            sc.ActiveConnection = DBCONNECT.getConnectionDbf
            sc.CommandText = "DELETE FROM " & getTable() & " WHERE " & id & "=? "
            sc.Parameters.Append(ADOPARAM.ToInt(id, ""))
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
    Private Function getObjectsDBF() As List(Of SubGrupGB)
        Dim rc As ADODB.Recordset
        rc = New ADODB.Recordset
        getObjectsDBF = New List(Of SubGrupGB)
        rc.Open("Select * FROM " & getTable(), DBCONNECT.getConnectionDbf)
        While Not rc.EOF
            getObjectsDBF.Add(New SubGrupGB(rc(ID).Value, Trim(rc(CODI).Value), Trim(rc(NOM).Value), Trim(CONFIG.validarNull(rc(FORMULA).Value)), rc(ORDRE).Value, rc(ES_TOTAL).Value, CONFIG.validarNull(rc(STRING_FORMULA).ToString)))
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
        Return DBCONNECT.getTaulaSubgrupGB
    End Function
End Module


