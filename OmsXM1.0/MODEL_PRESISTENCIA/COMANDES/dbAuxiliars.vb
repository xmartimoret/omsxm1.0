Option Explicit On
Imports System.Data.SqlClient
Module dbAuxiliars
    Private Const ID As String = "ID"
    Private Const CODI As String = "CODI"
    Private Const NOM As String = "NOM"
    Private Const ABREVIATURA As String = "ABREVIATUR"
    Private Const IMPOST As String = "IMPOST"
    Private Const REQUIVALENCIA As String = "REQUI"
    Private Const ACTIU As String = "Actiu"
    Private Const DIES As String = "DIES"
    Private Const DIA_PAGAMENT As String = "diaPaga"
    Private Const EMAIL As String = "EMAIL"
    Private tipus As String
    Public Function update(obj) As Integer
        tipus = obj.GetType.Name
        Select Case LCase(tipus)
            Case "tipusiva" : If IS_SQLSERVER Then Return updateSQL(toTipusIva(obj))
                Return updateDBF(toTipusIva(obj))
            Case "tipuspagament" : If IS_SQLSERVER Then Return updateSQL(toTipusPagament(obj))
                Return updateDBF(toTipusPagament(obj))
            Case "pais" : If IS_SQLSERVER Then Return updateSql(toPais(obj))
                Return updateDbf(toPais(obj))
            Case "responsablecompra" : If IS_SQLSERVER() Then Return updateSQL(toResponsableCompra(obj))
                Return updateDBF(toResponsableCompra(obj))
            Case Else : If IS_SQLSERVER Then Return updateSQL(obj)
                Return updateDBF(obj)
        End Select
    End Function
    Public Function insert(obj As Object) As Integer
        tipus = obj.GetType.Name
        Select Case LCase(tipus)
            Case "tipusiva" : If IS_SQLSERVER Then Return insertSQL(toTipusIva(obj))
                Return insertDBF(toTipusIva(obj))
            Case "tipuspagament" : If IS_SQLSERVER Then Return insertSQL(toTipusPagament(obj))
                Return insertDBF(toTipusPagament(obj))
            Case "pais" : If IS_SQLSERVER Then Return insertSql(toPais(obj))
                Return insertDbf(toPais(obj))
            Case "responsbleCompra" : If IS_SQLSERVER() Then Return insertSQL(toResponsableCompra(obj))
                Return insertDBF(toResponsableCompra(obj))
                'Case "article" : Return dbArticle.insert(obj)
                'Case "proveidor" : Return dbProveidor.insert(obj)
            Case Else : If IS_SQLSERVER Then Return insertSQL(obj)
                Return insertDBF(obj)
        End Select
    End Function
    Public Function remove(obj As Object) As Boolean
        tipus = obj.GetType.Name
        If IS_SQLSERVER Then Return removeSQL(obj)
        Return removeDBF(obj)
    End Function
    Public Function getObjects(t As String) As List(Of Object)
        tipus = t
        If IS_SQLSERVER Then Return getObjectsSQL()
        Return getObjectsDBF()
    End Function
    Private Function insertSQL(obj As Object) As Integer
        Dim sc As SqlCommand, i As Integer
        obj.id = DBCONNECT.getMaxId(getTable()) + 1
        sc = New SqlCommand(" INSERT INTO " & getTable() & " " &
                            " (" & ID & "," & CODI & ", " & NOM & ")" &
                            " VALUES(@id,@codi,@nom)", DBCONNECT.getConnection)
        sc.Parameters.Add("@id", SqlDbType.Int).Value = obj.id
        sc.Parameters.Add("@codi", SqlDbType.VarChar).Value = obj.codi
        sc.Parameters.Add("@nom", SqlDbType.VarChar).Value = obj.nom

        i = sc.ExecuteNonQuery
        sc = Nothing
        If i > 1 Then
            Return obj.id
        End If
        Return -1
    End Function
    Private Function insertSQL(obj As TipusIva) As Integer
        Dim sc As SqlCommand, i As Integer
        obj.id = DBCONNECT.getMaxId(getTable) + 1

        sc = New SqlCommand(" INSERT INTO " & getTable() & " " &
                            " (" & ID & ", " & IMPOST & ", " & CODI & ", " & NOM & ", " & REQUIVALENCIA & ", " & ACTIU & ")" &
                            " VALUES(@id,@impost,@codi,@nom,@requivalencia,@actiu)", DBCONNECT.getConnection)
        sc.Parameters.Add("@id", SqlDbType.Int).Value = obj.id
        sc.Parameters.Add("@impost", SqlDbType.Int).Value = obj.impost
        sc.Parameters.Add("@requivalencia", SqlDbType.Decimal).Value = obj.rEquivalencia
        sc.Parameters.Add("@codi", SqlDbType.VarChar).Value = obj.codi
        sc.Parameters.Add("@nom", SqlDbType.VarChar).Value = obj.nom
        sc.Parameters.Add("@actiu", SqlDbType.Bit).Value = obj.actiu
        i = sc.ExecuteNonQuery
        sc = Nothing
        If i >= 1 Then
            Return obj.id
        End If
        Return -1
    End Function
    Private Function insertSQL(obj As TipusPagament) As Integer
        Dim sc As SqlCommand, i As Integer
        obj.id = DBCONNECT.getMaxId(getTable) + 1

        sc = New SqlCommand(" INSERT INTO " & getTable() & " " &
                            " (" & ID & ", " & DIES & ", " & CODI & ", " & NOM & ", " & DIA_PAGAMENT & ", " & ACTIU & ")" &
                            " VALUES(@id,@dies,@codi,@nom,@diaPagament,@actiu)", DBCONNECT.getConnection)
        sc.Parameters.Add("@id", SqlDbType.Int).Value = obj.id
        sc.Parameters.Add("@dies", SqlDbType.Int).Value = obj.dies
        sc.Parameters.Add("@diaPagament", SqlDbType.Int).Value = obj.diaPagament
        sc.Parameters.Add("@codi", SqlDbType.VarChar).Value = obj.codi
        sc.Parameters.Add("@nom", SqlDbType.VarChar).Value = obj.nom
        sc.Parameters.Add("@actiu", SqlDbType.Bit).Value = obj.actiu
        i = sc.ExecuteNonQuery
        sc = Nothing
        If i >= 1 Then
            Return obj.id
        End If
        Return -1
    End Function
    Private Function insertSql(obj As Pais) As Integer
        Dim sc As SqlCommand, i As Integer
        obj.id = DBCONNECT.getMaxId(getTable) + 1

        sc = New SqlCommand(" INSERT INTO " & getTable() & " " &
                            " (" & ID & ", " & ABREVIATURA & ", " & CODI & ", " & NOM & ")" &
                            " VALUES(@id,@abrev,@codi,@nom)", DBCONNECT.getConnection)
        sc.Parameters.Add("@id", SqlDbType.Int).Value = obj.id
        sc.Parameters.Add("@abrev", SqlDbType.VarChar).Value = obj.abreviatura
        sc.Parameters.Add("@codi", SqlDbType.VarChar).Value = obj.codi
        sc.Parameters.Add("@nom", SqlDbType.VarChar).Value = obj.nom
        i = sc.ExecuteNonQuery
        sc = Nothing
        If i >= 1 Then
            Return obj.id
        End If
        Return -1
    End Function
    Private Function insertSql(obj As ResponsableCompra) As Integer
        Dim sc As SqlCommand, i As Integer
        obj.id = DBCONNECT.getMaxId(getTable) + 1

        sc = New SqlCommand(" INSERT INTO " & getTable() & " " &
                            " (" & ID & ", " & EMAIL & ", " & CODI & ", " & NOM & ")" &
                            " VALUES(@id,@notes,@codi,@nom)", DBCONNECT.getConnection)
        sc.Parameters.Add("@id", SqlDbType.Int).Value = obj.id
        sc.Parameters.Add("@notes", SqlDbType.VarChar).Value = obj.notes
        sc.Parameters.Add("@codi", SqlDbType.VarChar).Value = obj.codi
        sc.Parameters.Add("@nom", SqlDbType.VarChar).Value = obj.nom
        i = sc.ExecuteNonQuery
        sc = Nothing
        If i >= 1 Then
            Return obj.id
        End If
        Return -1
    End Function

    Private Function updateSQL(obj As Object) As Integer
        Dim sc As SqlCommand, i As Integer
        sc = New SqlCommand("UPDATE " & getTable() & " " &
                            " SET " & CODI & "=@codi," & NOM & " =@nom " &
                            " WHERE " & ID & "=@id", DBCONNECT.getConnection)
        sc.Parameters.Add("@id", SqlDbType.Int).Value = obj.id
        sc.Parameters.Add("@codi", SqlDbType.VarChar).Value = obj.codi
        sc.Parameters.Add("@nom", SqlDbType.VarChar).Value = obj.nom
        i = sc.ExecuteNonQuery
        sc = Nothing
        If i > 1 Then
            Return obj.id
        End If
        Return -1
    End Function
    Private Function updateSQL(obj As TipusIva) As Integer
        Dim sc As SqlCommand, i As Integer
        sc = New SqlCommand("UPDATE " & getTable() & " " &
                                " SET " & IMPOST & "=@impost," & CODI & "=@codi," & NOM & " =@nom," & REQUIVALENCIA & " =@requivalencia," & ACTIU & " =@actiu " &
                                " WHERE " & ID & "=@id", DBCONNECT.getConnection)
        sc.Parameters.Add("@id", SqlDbType.Int).Value = obj.id
        sc.Parameters.Add("@impost", SqlDbType.Int).Value = obj.impost
        sc.Parameters.Add("@requivalencia", SqlDbType.Decimal).Value = obj.rEquivalencia
        sc.Parameters.Add("@codi", SqlDbType.VarChar).Value = obj.codi
        sc.Parameters.Add("@nom", SqlDbType.VarChar).Value = obj.nom
        sc.Parameters.Add("@actiu", SqlDbType.Bit).Value = obj.actiu
        i = sc.ExecuteNonQuery
        sc = Nothing
        If i >= 1 Then
            Return obj.id
        End If
        Return -1
    End Function
    Private Function updateSQL(obj As TipusPagament) As Integer
        Dim sc As SqlCommand, i As Integer
        sc = New SqlCommand("UPDATE " & getTable() & " " &
                                " SET " & DIES & "=@dies," & CODI & "=@codi," & NOM & " =@nom," & DIA_PAGAMENT & " =@diaPagament," & ACTIU & " =@actiu " &
                                " WHERE " & ID & "=@id", DBCONNECT.getConnection)
        sc.Parameters.Add("@id", SqlDbType.Int).Value = obj.id
        sc.Parameters.Add("@dies", SqlDbType.Int).Value = obj.dies
        sc.Parameters.Add("@diaPagament", SqlDbType.Int).Value = obj.diaPagament
        sc.Parameters.Add("@codi", SqlDbType.VarChar).Value = obj.codi
        sc.Parameters.Add("@nom", SqlDbType.VarChar).Value = obj.nom
        sc.Parameters.Add("@actiu", SqlDbType.Bit).Value = obj.actiu
        i = sc.ExecuteNonQuery
        sc = Nothing
        If i >= 1 Then
            Return obj.id
        End If
        Return -1
    End Function
    Private Function updateSql(obj As Pais) As Integer
        Dim sc As SqlCommand, i As Integer
        sc = New SqlCommand("UPDATE " & getTable() & " " &
                                " SET " & ABREVIATURA & "=@abrev," & CODI & "=@codi," & NOM & " =@nom " &
                                " WHERE " & ID & "=@id", DBCONNECT.getConnection)
        sc.Parameters.Add("@id", SqlDbType.Int).Value = obj.id
        sc.Parameters.Add("@abrev", SqlDbType.VarChar).Value = obj.abreviatura
        sc.Parameters.Add("@codi", SqlDbType.VarChar).Value = obj.codi
        sc.Parameters.Add("@nom", SqlDbType.VarChar).Value = obj.nom
        i = sc.ExecuteNonQuery
        sc = Nothing
        If i >= 1 Then
            Return obj.id
        End If
        Return -1
    End Function
    Private Function updateSql(obj As ResponsableCompra) As Integer
        Dim sc As SqlCommand, i As Integer
        sc = New SqlCommand("UPDATE " & getTable() & " " &
                                " SET " & EMAIL & "=@notes," & CODI & "=@codi," & NOM & " =@nom " &
                                " WHERE " & ID & "=@id", DBCONNECT.getConnection)
        sc.Parameters.Add("@id", SqlDbType.Int).Value = obj.id
        sc.Parameters.Add("@notes", SqlDbType.VarChar).Value = obj.notes
        sc.Parameters.Add("@codi", SqlDbType.VarChar).Value = obj.codi
        sc.Parameters.Add("@nom", SqlDbType.VarChar).Value = obj.nom
        i = sc.ExecuteNonQuery
        sc = Nothing
        If i >= 1 Then
            Return obj.id
        End If
        Return -1
    End Function
    Private Function removeSQL(obj As Object) As Boolean
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
    Private Function getObjectsSQL() As List(Of Object)
        Dim sc As SqlCommand, sdr As SqlDataReader, dades As List(Of Object)
        dades = New List(Of Object)
        sc = New SqlCommand("Select * FROM " & getTable(), DBCONNECT.getConnection)
        sdr = sc.ExecuteReader
        While sdr.Read()
            Select Case UCase(tipus)
                Case DBCONNECT.getTaulaUnitat : dades.Add(New Unitat(sdr(ID), Trim(sdr(CODI)), Trim(sdr(NOM))))
                Case DBCONNECT.getTaulaFamilia : dades.Add(New Familia(sdr(ID), Trim(sdr(CODI)), Trim(sdr(NOM))))
                Case DBCONNECT.getTaulaFabricant : dades.Add(New Fabricant(sdr(ID), Trim(sdr(CODI)), Trim(sdr(NOM))))
                Case DBCONNECT.getTaulaProvincia : dades.Add(New Provincia(sdr(ID), Trim(sdr(CODI)), Trim(sdr(NOM))))
                Case DBCONNECT.getTaulaTipusIva : dades.Add(New TipusIva(sdr(ID), Trim(sdr(NOM)), Trim(sdr(CODI)), Trim(sdr(NOM)), Trim(sdr(IMPOST)), Trim(sdr(REQUIVALENCIA)), Trim(sdr(ACTIU))))
                Case DBCONNECT.getTaulaPais : dades.Add(New Pais(sdr(ID), Trim(sdr(ABREVIATURA)), Trim(sdr(CODI)), Trim(sdr(NOM))))
                Case DBCONNECT.getTaulaTipusPagament : dades.Add(New TipusPagament(sdr(ID), Trim(sdr(NOM)), Trim(sdr(CODI)), Trim(sdr(NOM)), Trim(sdr(DIES)), Trim(sdr(DIA_PAGAMENT)), Trim(sdr(ACTIU))))
                Case DBCONNECT.getTaulaResponsableCompra : dades.Add(New ResponsableCompra(sdr(ID), Trim(sdr(CODI)), Trim(sdr(NOM)), Trim(sdr(EMAIL)), Trim(sdr(ACTIU))))
            End Select
        End While
        sdr.Close()
        sdr = Nothing
        sc = Nothing
        Return dades
    End Function

    Private Function insertDBF(obj As Object) As Integer
        Dim sc As ADODB.Command
        sc = New ADODB.Command
        obj.id = DBCONNECT.getMaxIdDBF(getTable) + 1
        With sc
            .ActiveConnection = DBCONNECT.getConnectionDbf
            .CommandText = " INSERT INTO " & getTable() & " " &
                            " (" & ID & ", " & CODI & ", " & NOM & ")" &
                            " VALUES(?,?,?)"
            .Parameters.Append(ADOPARAM.ToInt(obj.id))
            .Parameters.Append(ADOPARAM.ToString(obj.codi))
            .Parameters.Append(ADOPARAM.ToString(obj.nom))

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
    Private Function insertDBF(obj As ResponsableCompra) As Integer
        Dim sc As ADODB.Command
        sc = New ADODB.Command
        obj.id = DBCONNECT.getMaxIdDBF(getTable) + 1
        With sc
            .ActiveConnection = DBCONNECT.getConnectionDbf
            .CommandText = " INSERT INTO " & getTable() & " " &
                            " (" & ID & ", " & CODI & ", " & NOM & ", " & EMAIL & ", " & ACTIU & ")" &
                            " VALUES(?,?,?,?,?)"
            .Parameters.Append(ADOPARAM.ToInt(obj.id))
            .Parameters.Append(ADOPARAM.ToString(obj.codi))
            .Parameters.Append(ADOPARAM.ToString(obj.nom))
            .Parameters.Append(ADOPARAM.ToString(obj.notes))
            .Parameters.Append(ADOPARAM.toBool(obj.actiu))
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
    Private Function insertDbf(obj As Pais) As Integer
        Dim sc As ADODB.Command, rc As ADODB.Recordset
        obj.id = DBCONNECT.getMaxIdDBF(getTable) + 1
        sc = New ADODB.Command
        rc = New ADODB.Recordset
        With sc
            sc.ActiveConnection = DBCONNECT.getConnectionDbf
            sc.CommandText = " INSERT INTO " & getTable() & " " &
                            " (" & ID & ", " & ABREVIATURA & ", " & CODI & ", " & NOM & ", " & EMAIL & ", " & ACTIU & ")" &
                            " VALUES(?,?,?,?)"
            sc.Parameters.Append(ADOPARAM.ToInt(obj.id, ""))
            sc.Parameters.Append(ADOPARAM.ToString(obj.abreviatura, ""))
            sc.Parameters.Append(ADOPARAM.ToString(obj.codi, ""))
            sc.Parameters.Append(ADOPARAM.ToString(obj.nom, ""))

        End With
        Try
            rc.Open(sc)
            Return obj.id
        Catch ex As Exception
            Call ERRORS.ERR_EXCEPTION_SQL(ex.Message)
            Return -1
        Finally
            sc = Nothing
            rc = Nothing
        End Try
    End Function
    Private Function insertDBF(obj As TipusIva) As Integer
        Dim sc As ADODB.Command
        sc = New ADODB.Command
        obj.id = DBCONNECT.getMaxIdDBF(getTable) + 1
        With sc
            .ActiveConnection = DBCONNECT.getConnectionDbf
            .CommandText = " INSERT INTO " & getTable() & " " &
                            " (" & ID & ", " & IMPOST & ", " & CODI & ", " & NOM & ", " & REQUIVALENCIA & ", " & ACTIU & ")" &
                            " VALUES(?,?,?,?,?,?)"
            .Parameters.Append(ADOPARAM.ToInt(obj.id))
            .Parameters.Append(ADOPARAM.ToInt(obj.impost))
            .Parameters.Append(ADOPARAM.ToString(obj.codi))
            .Parameters.Append(ADOPARAM.ToString(obj.nom))
            .Parameters.Append(ADOPARAM.ToSingle(obj.rEquivalencia))
            .Parameters.Append(ADOPARAM.toBool(obj.actiu))

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
    Private Function insertDBF(obj As TipusPagament) As Integer
        Dim sc As ADODB.Command
        sc = New ADODB.Command
        obj.id = DBCONNECT.getMaxIdDBF(getTable) + 1
        With sc
            .ActiveConnection = DBCONNECT.getConnectionDbf
            .CommandText = " INSERT INTO " & getTable() & " " &
                            " (" & ID & ", " & DIES & ", " & CODI & ", " & NOM & ", " & DIA_PAGAMENT & ", " & ACTIU & ")" &
                            " VALUES(?,?,?,?,?,?)"
            .Parameters.Append(ADOPARAM.ToInt(obj.id))
            .Parameters.Append(ADOPARAM.ToInt(obj.dies))
            .Parameters.Append(ADOPARAM.ToString(obj.codi))
            .Parameters.Append(ADOPARAM.ToString(obj.nom))
            .Parameters.Append(ADOPARAM.ToInt(obj.diaPagament))
            .Parameters.Append(ADOPARAM.toBool(obj.actiu))
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

    Private Function updateDBF(obj As Object) As Integer
        Dim sc As ADODB.Command
        sc = New ADODB.Command
        With sc
            .ActiveConnection = DBCONNECT.getConnectionDbf
            .CommandText = "UPDATE " & getTable() & " " &
                            " SET " & CODI & "=?," & NOM & " =? " &
                            " WHERE " & ID & "=?"
            .Parameters.Append(ADOPARAM.ToString(obj.codi))
            .Parameters.Append(ADOPARAM.ToString(obj.nom))
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
    Private Function updateDBF(obj As TipusIva) As Integer
        Dim sc As ADODB.Command
        sc = New ADODB.Command
        With sc
            .ActiveConnection = DBCONNECT.getConnectionDbf
            .CommandText = "UPDATE " & getTable() & " " &
                           " SET " & IMPOST & "=?," & CODI & "=?," & NOM & " =?," & REQUIVALENCIA & " =?," & ACTIU & " =? " &
                           " WHERE " & ID & "=?"
            .Parameters.Append(ADOPARAM.ToInt(obj.impost))
            .Parameters.Append(ADOPARAM.ToString(obj.codi))
            .Parameters.Append(ADOPARAM.ToString(obj.nom))
            .Parameters.Append(ADOPARAM.ToSingle(obj.rEquivalencia))
            .Parameters.Append(ADOPARAM.toBool(obj.actiu))
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
    Private Function updateDBF(obj As TipusPagament) As Integer
        Dim sc As ADODB.Command
        sc = New ADODB.Command
        With sc
            .ActiveConnection = DBCONNECT.getConnectionDbf
            .CommandText = "UPDATE " & getTable() & " " &
                                " SET " & DIES & "=?," & CODI & "=?," & NOM & " =?," & DIA_PAGAMENT & " =?," & ACTIU & " =? " &
                                " WHERE " & ID & "=@id"
            .Parameters.Append(ADOPARAM.ToInt(obj.dies))
            .Parameters.Append(ADOPARAM.ToString(obj.codi))
            .Parameters.Append(ADOPARAM.ToString(obj.nom))
            .Parameters.Append(ADOPARAM.ToInt(obj.diaPagament))
            .Parameters.Append(ADOPARAM.toBool(obj.actiu))
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
    Private Function updateDbf(obj As Pais) As Integer
        Dim sc As ADODB.Command
        sc = New ADODB.Command
        With sc
            sc.ActiveConnection = DBCONNECT.getConnectionDbf
            sc.CommandText = "UPDATE " & getTable() & " " &
                                " SET " & ABREVIATURA & "=?," & CODI & "=?," & NOM & " =? " &
                                " WHERE " & ID & "=?"
            sc.Parameters.Append(ADOPARAM.ToString(obj.abreviatura, ""))
            sc.Parameters.Append(ADOPARAM.ToString(obj.codi, ""))
            sc.Parameters.Append(ADOPARAM.ToString(obj.nom, ""))
            sc.Parameters.Append(ADOPARAM.ToInt(obj.id, ""))
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
    Private Function updateDBF(obj As ResponsableCompra) As Integer
        Dim sc As ADODB.Command
        sc = New ADODB.Command
        With sc
            .ActiveConnection = DBCONNECT.getConnectionDbf
            .CommandText = "UPDATE " & getTable() & " " &
                            " SET " & CODI & "=?," & NOM & " =?, " & EMAIL & " =?, " & ACTIU & " =? " &
                             " WHERE " & ID & "=?"
            .Parameters.Append(ADOPARAM.ToString(obj.codi))
            .Parameters.Append(ADOPARAM.ToString(obj.nom))
            .Parameters.Append(ADOPARAM.ToString(obj.notes))
            .Parameters.Append(ADOPARAM.toBool(obj.actiu))
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
    Private Function removeDBF(obj As Object) As Boolean
        Dim sc As ADODB.Command
        sc = New ADODB.Command
        With sc
            sc.ActiveConnection = DBCONNECT.getConnectionDbf
            sc.CommandText = " DELETE FROM " & getTable() & " WHERE " & ID & "=?"
            sc.Parameters.Append(ADOPARAM.ToInt(obj.ID, ""))
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
    Private Function getObjectsDBF() As List(Of Object)
        Dim rc As ADODB.Recordset
        rc = New ADODB.Recordset
        getObjectsDBF = New List(Of Object)
        rc.Open("SELECT * FROM " & getTable(), DBCONNECT.getConnectionDbf)
        While Not rc.EOF
            Select Case UCase(tipus)
                Case DBCONNECT.getTaulaUnitat : getObjectsDBF.Add(New Unitat(rc(ID).Value, Trim(CONFIG.validarNull(rc(CODI).Value)), Trim(CONFIG.validarNull(rc(NOM).Value))))
                Case DBCONNECT.getTaulaFamilia : getObjectsDBF.Add(New Familia(rc(ID).Value, Trim(CONFIG.validarNull(rc(CODI).Value)), Trim(CONFIG.validarNull(rc(NOM).Value))))
                Case DBCONNECT.getTaulaFabricant : getObjectsDBF.Add(New Fabricant(rc(ID).Value, Trim(CONFIG.validarNull(rc(CODI).Value)), Trim(CONFIG.validarNull(rc(NOM).Value))))
                Case DBCONNECT.getTaulaProvincia : getObjectsDBF.Add(New Provincia(rc(ID).Value, Trim(CONFIG.validarNull(rc(CODI).Value)), Trim(CONFIG.validarNull(rc(NOM).Value))))
                Case DBCONNECT.getTaulaPais : getObjectsDBF.Add(New Pais(rc(ID).Value, Trim(CONFIG.validarNull(rc(ABREVIATURA).Value)), Trim(CONFIG.validarNull(rc(CODI).Value)), Trim(CONFIG.validarNull(rc(NOM).Value))))
                Case DBCONNECT.getTaulaTipusIva : getObjectsDBF.Add(New TipusIva(rc(ID).Value, rc(IMPOST).Value, Trim(CONFIG.validarNull(rc(CODI).Value)), Trim(CONFIG.validarNull(rc(NOM).Value)), Trim(rc(IMPOST).Value), Trim(rc(REQUIVALENCIA).Value), Trim(rc(ACTIU).Value)))
                Case DBCONNECT.getTaulaTipusPagament : getObjectsDBF.Add(New TipusPagament(rc(ID).Value, Trim(rc(NOM).Value), Trim(rc(CODI).Value), Trim(CONFIG.validarNull(rc(NOM).Value)), Trim(rc(DIES).Value), Trim(rc(DIA_PAGAMENT).Value), Trim(rc(ACTIU).Value)))
                Case DBCONNECT.getTaulaResponsableCompra : getObjectsDBF.Add(New ResponsableCompra(rc(ID).Value, Trim(rc(CODI).Value), Trim(CONFIG.validarNull(rc(NOM).Value)), Trim(CONFIG.validarNull(rc(EMAIL).Value)), rc(ACTIU).Value))


            End Select
            rc.MoveNext()
        End While
        If rc.State = 1 Then rc.Close()
        rc = Nothing
        getObjectsDBF.Sort()
    End Function

    Private Function getTable() As String
        Select Case LCase(tipus)
            Case "tipusiva" : Return DBCONNECT.getTaulaTipusIva
            Case "tipuspagament" : Return DBCONNECT.getTaulaTipusPagament
            Case "provincia" : Return DBCONNECT.getTaulaProvincia
            Case "responsablecompra" : Return DBCONNECT.getTaulaResponsableCompra
            Case Else : Return tipus
        End Select

        Return tipus
    End Function
    Private Function toPais(obj As Object) As Pais
        toPais = New Pais
        toPais.id = obj.id
        toPais.codi = obj.codi
        toPais.abreviatura = obj.abreviatura
        toPais.nom = obj.nom

    End Function
    'Private Function toArticle(obj As Object) As article
    '    toArticle = New article
    '    toArticle.id = obj.id
    '    toArticle.codi = obj.codi
    '    toArticle.fabricant = obj.fabricant
    '    toArticle.familia = obj.familia
    '    toArticle.iva = obj.iva
    '    toArticle.unitat = obj.unitat
    '    toArticle.nom = obj.nom
    'End Function
    'Private Function toProveidor(obj As Object) As Proveidor
    '    toProveidor = New Proveidor
    '    toProveidor.id = obj.ID
    '    toProveidor.nom = obj.NOM
    '    toProveidor.codi = obj.CODI
    '    toProveidor.dataAlta = obj.dataAlta
    '    toProveidor.dataBaixa = obj.dataBaixa
    '    toProveidor.nomFiscal = obj.nomFiscal
    '    toProveidor.direccio = obj.direccio
    '    toProveidor.poblacio = obj.poblacio
    '    toProveidor.pais = obj.pais
    '    toProveidor.provincia = obj.provincia
    '    toProveidor.tipusPagament = obj.tipusPagament
    '    toProveidor.actiu = obj.actiu
    '    toProveidor.codiPostal = obj.codiPostal
    '    toProveidor.iban1 = obj.iban1
    '    toProveidor.iban2 = obj.iban2
    '    toProveidor.iban3 = obj.iban3
    '    toProveidor.email = obj.email
    'End Function
    Private Function toTipusPagament(obj As Object) As TipusPagament
        toTipusPagament = New TipusPagament
        toTipusPagament.id = obj.id
        toTipusPagament.codi = obj.codi
        toTipusPagament.dies = obj.dies
        toTipusPagament.diaPagament = obj.diaPagament
        toTipusPagament.notes = obj.notes
        toTipusPagament.nom = obj.nom
        toTipusPagament.actiu = obj.actiu
    End Function
    Private Function toTipusIva(obj As Object) As TipusIva
        toTipusIva = New TipusIva
        toTipusIva.id = obj.id
        toTipusIva.codi = obj.codi
        toTipusIva.rEquivalencia = obj.requivalencia
        toTipusIva.impost = obj.impost
        toTipusIva.notes = obj.notes
        toTipusIva.nom = obj.nom
        toTipusIva.actiu = obj.actiu
    End Function
    Private Function toResponsableCompra(obj As Object) As ResponsableCompra
        toResponsableCompra = New ResponsableCompra
        toResponsableCompra.id = obj.id
        toResponsableCompra.codi = obj.codi
        toResponsableCompra.notes = obj.notes
        toResponsableCompra.nom = obj.nom
        toResponsableCompra.actiu = obj.actiu
    End Function
End Module
