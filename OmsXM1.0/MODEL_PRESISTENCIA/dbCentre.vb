Option Explicit On
Imports System.Data.SqlClient
Module dbCentre
    Private Const ID As String = "ID"
    Private Const ID_SECCIO As String = "IDSECCIO"
    Private Const CODI As String = "CODI"
    Private Const NOM As String = "NOM"
    Private Const NOTES As String = "NOTES"
    Private Const ORDRE As String = "ORDRE"
    Private Const ACTIU As String = "ACTIU"
    Private Const COLOR As String = "COLOR"
    Public Function update(obj As Centre) As Integer
        If IS_SQLSERVER Then Return updateSQL(obj)
        Return updateDBF(obj)
    End Function
    Public Function insert(obj As Centre) As Integer
        If IS_SQLSERVER Then Return insertSQL(obj)
        Return insertDBF(obj)
    End Function
    Public Function remove(obj As Centre) As Boolean
        If IS_SQLSERVER Then Return removeSQL(obj)
        Return removeDBF(obj)
    End Function
    Public Function getObjects() As List(Of Centre)
        If IS_SQLSERVER Then Return getObjectsSQL()
        Return getObjectsDBF()
    End Function
    Public Function removeSeccio(idSeccio As Integer) As Boolean
        If IS_SQLSERVER Then Return removeSeccioSQL(idSeccio)
        Return removeSeccioDBF(idSeccio)
    End Function
    Public Function saveClearNotes(idSeccio As Integer) As Boolean
        If IS_SQLSERVER Then Return saveClearNotesSQL(idSeccio)
        Return saveClearNotesDBF(idSeccio)
    End Function
    'ACCESSORS CENTRE
    ''' <summary>
    ''' SAVE. Guarda un centre a la base de dades. 
    ''' Si es nou, fa una inserció si no  actualitza.
    ''' </summary>
    ''' <param name="obj"> centre</param>
    ''' <returns>identificador del centre.</returns>
    Private Function updateSQL(obj As Centre) As Integer
        Dim sc As SqlCommand, i As Integer
        sc = New SqlCommand("UPDATE " & getTable() & " " &
                                " SET " & ID_SECCIO & "=@idseccio," & CODI & "=@codi," & NOM & " =@nom, " & NOTES & "=@notes, " & ORDRE & "=@ordre ," & ACTIU & "=@actiu " &
                                " WHERE " & ID & "=@id", DBCONNECT.getConnection)
        sc.Parameters.Add("@id", SqlDbType.Int).Value = obj.id
        sc.Parameters.Add("@idSeccio", SqlDbType.Int).Value = obj.idSeccio
        sc.Parameters.Add("@codi", SqlDbType.VarChar).Value = obj.codi
        sc.Parameters.Add("@nom", SqlDbType.VarChar).Value = obj.nom
        sc.Parameters.Add("@notes", SqlDbType.VarChar).Value = obj.notes
        sc.Parameters.Add("@ordre", SqlDbType.Int).Value = obj.ordre
        sc.Parameters.Add("@actiu", SqlDbType.Bit).Value = obj.actiu
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
    Private Function insertSQL(obj As Centre) As Integer
        Dim sc As SqlCommand, i As Integer

        obj.id = DBCONNECT.getMaxId(getTable) + 1

        sc = New SqlCommand(" INSERT INTO " & getTable() & " " &
                                " (" & ID & ", " & ID_SECCIO & ", " & CODI & ", " & NOM & ", " & NOTES & "," & ORDRE & "," & ACTIU & ")" &
                                " VALUES(@id,@idSeccio,@codi,@nom,@notes,@ordre,@actiu)", DBCONNECT.getConnection)
        sc.Parameters.Add("@id", SqlDbType.Int).Value = obj.id
        sc.Parameters.Add("@idSeccio", SqlDbType.Int).Value = obj.idSeccio
        sc.Parameters.Add("@codi", SqlDbType.VarChar).Value = obj.codi
        sc.Parameters.Add("@nom", SqlDbType.VarChar).Value = obj.nom
        sc.Parameters.Add("@notes", SqlDbType.VarChar).Value = obj.notes
        sc.Parameters.Add("@ordre", SqlDbType.Int).Value = obj.ordre
        sc.Parameters.Add("@actiu", SqlDbType.Bit).Value = obj.actiu
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

    Private Function removeSQL(obj As Centre) As Boolean
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
    Private Function getObjectsSQL() As List(Of Centre)
        Dim sc As SqlCommand, sdr As SqlDataReader
        getObjectsSQL = New List(Of Centre)
        sc = New SqlCommand("SELECT c.id as CID, S.ID AS SID, C.CODI AS CCODI, C.NOM AS CNOM, C.NOTES AS CNOTES,C.ORDRE AS CORDRE, C.ACTIU AS CACTIU, S.CODI AS SCODI, E.ID AS EID, E.CODI AS ECODI , E.PARTICIPA AS EPARTICIPACIO FROM " & DBCONNECT.getTaulaCentres & " AS C INNER JOIN " & DBCONNECT.getTaulaSeccions & " AS S ON (S.ID= C.IDSECCIO) INNER JOIN " & DBCONNECT.GetTaulaEmpresa & " AS E ON (E.ID=S.IDEMPRESA) ", getConnection)
        sdr = sc.ExecuteReader
        While sdr.Read()
            getObjectsSQL.Add(New Centre(sdr("CID"), sdr("SID"), Trim(sdr("CCODI")), Trim(sdr("CNOM")), Trim(sdr("CNOTES").ToString), sdr("CORDRE"), sdr("CACTIU"), ModelProjecteCentre.getObjects(sdr("CID")), Trim(sdr("SCODI")), Trim(sdr("EID")), Trim(sdr("ECODI")), Trim(sdr("EPARTICIPACIO"))))
        End While
        sdr.Close()
        getObjectsSQL.Sort()
        sdr = Nothing
        sc = Nothing
    End Function
    Private Function removeSeccioSQL(idSeccio As Integer)
        Dim sc As SqlCommand, i As Integer
        sc = New SqlCommand("DELETE FROM " & getTable() & " WHERE " & ID_SECCIO & "=@idSeccio", DBCONNECT.getConnection)
        sc.Parameters.Add("@idSeccio", SqlDbType.Int).Value = idSeccio
        i = sc.ExecuteNonQuery
        sc = Nothing
        If i >= 1 Then
            Return True
        End If
        Return False
    End Function
    Private Function saveClearNotesSQL(idSeccio As Integer)
        Dim sc As SqlCommand, i As Integer
        sc = New SqlCommand("UPDATE " & getTable() & " SET NOTES=''  WHERE " & ID_SECCIO & "=@idSeccio", DBCONNECT.getConnection)
        sc.Parameters.Add("@idSeccio", SqlDbType.Int).Value = idSeccio
        i = sc.ExecuteNonQuery
        sc = Nothing
        If i >= 1 Then
            Return True
        End If
        Return False
    End Function

    '  dbf

    'ACCESSORS CENTRE
    ''' <summary>
    ''' SAVE. Guarda un centre a la base de dades. 
    ''' Si es nou, fa una inserció si no  actualitza.
    ''' </summary>
    ''' <param name="obj"> centre</param>
    ''' <returns>identificador del centre.</returns>
    Private Function updateDBF(obj As Centre) As Integer
        Dim sc As ADODB.Command
        sc = New ADODB.Command
        With sc
            .ActiveConnection = DBCONNECT.getConnectionDbf
            .CommandText = "UPDATE " & getTable() & " " &
                                " SET " & ID_SECCIO & "=? ," & CODI & "=?," & NOM & " =?, " & NOTES & "=?, " & ORDRE & "=? ," & ACTIU & "=? " &
                                " WHERE " & ID & "=@id"
            .Parameters.Append(ADOPARAM.ToInt(obj.idSeccio))
            .Parameters.Append(ADOPARAM.ToString(obj.codi))
            .Parameters.Append(ADOPARAM.ToString(obj.nom))
            .Parameters.Append(ADOPARAM.ToString(obj.notes))
            .Parameters.Append(ADOPARAM.ToString(obj.ordre))
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
    'ACCESSORS CENTRE
    ''' <summary>
    ''' SAVE. Guarda un centre a la base de dades. 
    ''' Si es nou, fa una inserció si no  actualitza.
    ''' </summary>
    ''' <param name="obj"> centre</param>
    ''' <returns>identificador del centre.</returns>
    Private Function insertDBF(obj As Centre) As Integer
        Dim sc As ADODB.Command
        sc = New ADODB.Command
        obj.id = DBCONNECT.getMaxIdDBF(getTable) + 1
        With sc
            .ActiveConnection = DBCONNECT.getConnectionDbf
            .CommandText = " INSERT INTO " & getTable() & " " &
                                " (" & ID & ", " & ID_SECCIO & ", " & CODI & ", " & NOM & ", " & NOTES & "," & ORDRE & "," & ACTIU & ")" &
                                " VALUES(@id,@idSeccio,@codi,@nom,@notes,@ordre,@actiu)"
            .Parameters.Append(ADOPARAM.ToInt(obj.id))
            .Parameters.Append(ADOPARAM.ToInt(obj.idSeccio))
            .Parameters.Append(ADOPARAM.ToString(obj.codi))
            .Parameters.Append(ADOPARAM.ToString(obj.nom))
            .Parameters.Append(ADOPARAM.ToString(obj.notes))
            .Parameters.Append(ADOPARAM.ToString(obj.ordre))
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
    ''' <summary>
    '''  Elimina  un centre de la base de dades
    ''' </summary>
    ''' <param name="obj"></param>
    ''' <returns></returns>
    Private Function removeDBF(obj As Centre) As Boolean
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
    Private Function getObjectsDBF() As List(Of Centre)
        Dim rc As ADODB.Recordset
        rc = New ADODB.Recordset
        getObjectsDBF = New List(Of Centre)
        rc.Open("SELECT c.id as CID, S.ID AS SID, C.CODI AS CCODI, C.NOM AS CNOM, C.NOTES AS CNOTES,C.ORDRE AS CORDRE, C.ACTIU AS CACTIU, S.CODI AS SCODI, E.ID AS EID, E.CODI AS ECODI , E.PARTICIPA AS EPARTICIPACIO FROM ((" & DBCONNECT.getTaulaCentres & " AS C INNER JOIN " & DBCONNECT.getTaulaSeccions & " AS S ON (S.ID= C.IDSECCIO)) INNER JOIN " & DBCONNECT.GetTaulaEmpresa & " AS E ON (E.ID=S.IDEMPRESA)) ", DBCONNECT.getConnectionDbf)
        While Not rc.EOF
            getObjectsDBF.Add(New Centre(rc("CID").Value, rc("SID").Value, Trim(CONFIG.validarNull(rc("CCODI").Value)), Trim(CONFIG.validarNull(rc("CNOM").Value)), Trim(CONFIG.validarNull(rc("CNOTES").Value)), CONFIG.validarNull(rc("CORDRE").Value), rc("CACTIU").Value, ModelProjecteCentre.getObjects(rc("CID").Value), Trim(CONFIG.validarNull(rc("SCODI").Value)), Trim(rc("EID").Value), Trim(CONFIG.validarNull(rc("ECODI").Value)), Trim(rc("EPARTICIPACIO").Value)))
            rc.MoveNext()
        End While
        If rc.State = 1 Then rc.Close()
        rc = Nothing
        getObjectsDBF.Sort()
    End Function
    Private Function removeSeccioDBF(idSeccio As Integer)
        Dim sc As ADODB.Command
        sc = New ADODB.Command
        With sc
            sc.ActiveConnection = DBCONNECT.getConnectionDbf
            sc.CommandText = "DELETE FROM " & getTable() & " WHERE " & ID_SECCIO & "=?"
            sc.Parameters.Append(ADOPARAM.ToInt(idSeccio, ""))
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
    Private Function saveClearNotesDBF(idSeccio As Integer) As Boolean
        Dim sc As ADODB.Command
        sc = New ADODB.Command
        With sc
            .ActiveConnection = DBCONNECT.getConnectionDbf
            .CommandText = "UPDATE " & getTable() & " SET NOTES=''  WHERE " & ID_SECCIO & "=@idSeccio"
            .Parameters.Append(ADOPARAM.ToInt(idSeccio))
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
    Private Function getTable() As String
        Return DBCONNECT.getTaulaCentres
    End Function
End Module
