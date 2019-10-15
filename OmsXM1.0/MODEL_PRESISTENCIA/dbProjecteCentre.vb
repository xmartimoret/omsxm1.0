Option Explicit On
Imports System.Data.SqlClient

Module dbProjecteCentre
    Private Const ID_PROJECTE As String = "IDPROJECTE"
    Private Const ID_CENTRE As String = "idCentre"
    Private Const ORDRE As String = "ORDRE"
    Public Function update(obj As ProjecteCentre) As Integer
        If IS_SQLSERVER Then Return updateSQL(obj)
        Return updateDBF(obj)
    End Function
    Public Function insert(obj As ProjecteCentre) As Integer
        If IS_SQLSERVER Then Return insertSQL(obj)
        Return insertDBF(obj)
    End Function
    Public Function remove(idProjecte As Integer, idCentre As Integer) As Boolean
        If IS_SQLSERVER Then Return removeSQL(idProjecte, idCentre)
        Return removeDBF(idProjecte, idCentre)
    End Function
    Public Function remove(obj As ProjecteCentre) As Boolean
        If IS_SQLSERVER Then Return removeSQL(obj)
        Return removeDBF(obj)
    End Function
    Public Function removeCentre(idCentre As Integer) As Boolean
        If IS_SQLSERVER Then Return removeCentreSQL(idCentre)
        Return removeCentreDBF(idCentre)
    End Function
    Public Function getObjects() As List(Of ProjecteCentre)
        If IS_SQLSERVER Then Return getObjectsSQL()
        Return getObjectsDBF()
    End Function
    Private Function insertSQL(obj As ProjecteCentre) As Boolean
        Dim sc As SqlCommand, i As Integer
        sc = New SqlCommand(" INSERT INTO " & getTable() & " " &
                     " (" & ID_PROJECTE & ",  " & ID_CENTRE & "," & ORDRE & ")" &
                     " VALUES(@idProjecte,@idCentre,@ordre)", DBCONNECT.getConnection)
        sc.Parameters.Add("@idProjecte", SqlDbType.Int).Value = obj.idProjecte
        sc.Parameters.Add("@idCentre", SqlDbType.Int).Value = obj.idCentre
        sc.Parameters.Add("@idClient", SqlDbType.Int).Value = obj.idCentre
        sc.Parameters.Add("@ordre", SqlDbType.Int).Value = Val(obj.ordre)
        i = sc.ExecuteNonQuery
        sc = Nothing
        If i > 1 Then
            Return True
        End If
        Return False
    End Function
    Private Function updateSQL(obj As ProjecteCentre) As Boolean
        Dim sc As SqlCommand, i As Integer
        sc = New SqlCommand(" UPDATE " & getTable() & " SET " & ORDRE & "=@ordre" &
                 " WHERE " & ID_PROJECTE & "=@IdProjecte AND " & ID_CENTRE & " = @idCentre", DBCONNECT.getConnection)
        sc.Parameters.Add("@idProjecte", SqlDbType.Int).Value = obj.idProjecte
        sc.Parameters.Add("@idCentre", SqlDbType.Int).Value = obj.idCentre
        sc.Parameters.Add("@idClient", SqlDbType.Int).Value = obj.idCentre
        sc.Parameters.Add("@ordre", SqlDbType.Int).Value = Val(obj.ordre)
        i = sc.ExecuteNonQuery
        sc = Nothing
        If i > 1 Then
            Return True
        End If
        Return False
    End Function
    Private Function removeSQL(idProjecte As Integer, idCentre As Integer) As Boolean
        Dim sc As SqlCommand, i As Integer
        sc = New SqlCommand("DELETE FROM " & getTable() & " WHERE " & ID_CENTRE & "=@idCentre AND " & ID_PROJECTE & "=@IdProjecte", DBCONNECT.getConnection)
        sc.Parameters.Add("@idCentre", SqlDbType.Int).Value = idCentre
        sc.Parameters.Add("@idProjecte", SqlDbType.Int).Value = idProjecte
        i = sc.ExecuteNonQuery
        sc = Nothing
        If i > 1 Then
            Return True
        End If
        Return False
    End Function
    Private Function removeSQL(p As ProjecteCentre) As Boolean
        Dim sc As SqlCommand, i As Integer
        sc = New SqlCommand("DELETE FROM " & getTable() & " WHERE " & ID_CENTRE & "=@idCentre AND " & ID_PROJECTE & "=@IdProjecte", DBCONNECT.getConnection)
        sc.Parameters.Add("@idCentre", SqlDbType.Int).Value = p.idCentre
        sc.Parameters.Add("@idProjecte", SqlDbType.Int).Value = p.idProjecte
        i = sc.ExecuteNonQuery
        sc = Nothing
        If i > 1 Then
            Return True
        End If
        Return False
    End Function
    Private Function removeCentreSQL(idCentre As Integer) As Boolean
        Dim sc As SqlCommand, i As Integer
        sc = New SqlCommand("DELETE FROM " & getTable() & " WHERE " & ID_CENTRE & "=@idCentre", DBCONNECT.getConnection)
        sc.Parameters.Add("@idCentre", SqlDbType.Int).Value = idCentre
        i = sc.ExecuteNonQuery
        sc = Nothing
        If i > 1 Then
            Return True
        End If
        Return False
    End Function
    ''' <summary>
    ''' Obté els Projecte Centre de la base de dades
    ''' </summary>
    ''' <returns></returns>
    Private Function getObjectsSQL() As List(Of ProjecteCentre)
        Dim sc As SqlCommand, sdr As SqlDataReader, sqlString As String
        getObjectsSQL = New List(Of ProjecteCentre)
        sqlString = "Select PC.IDPROJECTE As CIDPROJECTE, PC.IDCENTRE As CIDCENTRE,PC.ORDRE As CORDRE,P.CODI As PCODI, P.NOM As PNOM, C.CODI As CENTRECODI " &
           " FROM (" & getTable() & " As PC INNER JOIN " & getTableProjecte() & " As P  On (PC.IDPROJECTE= P.ID)) INNER JOIN " & getTaulaCentres() & " As C On (C.ID=PC.IDCENTRE)"
        sc = New SqlCommand(sqlString, DBCONNECT.getConnection)
        sdr = sc.ExecuteReader
        While sdr.Read()
            getObjectsSQL.Add(New ProjecteCentre(sdr("CIDPROJECTE"), sdr("CIDCENTRE"), sdr("cOrdre"), 100, sdr("CENTRECODI"), sdr("pCodi"), sdr("PNOM")))
        End While

        sdr.Close()
        sdr = Nothing
        sc = Nothing
    End Function
    Private Function insertDBF(obj As ProjecteCentre) As Boolean
        Dim sc As ADODB.Command
        sc = New ADODB.Command
        With sc
            .ActiveConnection = DBCONNECT.getConnectionDbf
            .CommandText = " INSERT INTO " & getTable() & " " &
                     " (" & ID_PROJECTE & ",  " & ID_CENTRE & "," & ORDRE & ")" &
                     " VALUES(?,?,?)"
            .Parameters.Append(ADOPARAM.ToInt(obj.idProjecte))
            .Parameters.Append(ADOPARAM.ToInt(obj.idCentre))
            .Parameters.Append(ADOPARAM.ToString(obj.ordre))
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
    Private Function updateDBF(obj As ProjecteCentre) As Boolean
        Dim sc As ADODB.Command
        sc = New ADODB.Command
        With sc
            .ActiveConnection = DBCONNECT.getConnectionDbf
            .CommandText = " UPDATE " & getTable() & " SET " & ORDRE & "=?" &
                 " WHERE " & ID_PROJECTE & "=? AND " & ID_CENTRE & " = ?"
            .Parameters.Append(ADOPARAM.ToString(obj.ordre))
            .Parameters.Append(ADOPARAM.ToInt(obj.idProjecte))
            .Parameters.Append(ADOPARAM.ToInt(obj.idCentre))
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
    Private Function removeDBF(idProjecte As Integer, idCentre As Integer) As Boolean
        Dim sc As ADODB.Command
        sc = New ADODB.Command
        With sc
            sc.ActiveConnection = DBCONNECT.getConnectionDbf
            sc.CommandText = "DELETE FROM " & getTable() & " WHERE " & ID_CENTRE & "=? AND " & ID_PROJECTE & "=?"
            sc.Parameters.Append(ADOPARAM.ToInt(idCentre))
            sc.Parameters.Append(ADOPARAM.ToInt(idProjecte))
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
    Private Function removeDBF(p As ProjecteCentre) As Boolean
        Dim sc As ADODB.Command
        sc = New ADODB.Command
        With sc
            sc.ActiveConnection = DBCONNECT.getConnectionDbf
            sc.CommandText = "DELETE FROM " & getTable() & " WHERE " & ID_CENTRE & "=? AND " & ID_PROJECTE & "=?"
            sc.Parameters.Append(ADOPARAM.ToInt(p.idCentre))
            sc.Parameters.Append(ADOPARAM.ToInt(p.idProjecte))
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
    Private Function removeCentreDBF(idCentre As Integer) As Boolean

        Dim sc As ADODB.Command
        sc = New ADODB.Command
        With sc
            sc.ActiveConnection = DBCONNECT.getConnectionDbf
            sc.CommandText = "DELETE FROM " & getTable() & " WHERE " & ID_CENTRE & "=? "
            sc.Parameters.Append(ADOPARAM.ToInt(idCentre))
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
    ''' Obté els Projecte Centre de la base de dades
    ''' </summary>
    ''' <returns></returns>
    Private Function getObjectsDBF() As List(Of ProjecteCentre)
        Dim rc As ADODB.Recordset
        rc = New ADODB.Recordset
        getObjectsDBF = New List(Of ProjecteCentre)
        rc.Open("Select PC.IDPROJECTE As CIDPROJECTE, PC.IDCENTRE As CIDCENTRE,PC.ORDRE As CORDRE,P.CODI As PCODI, P.NOM As PNOM, C.CODI As CENTRECODI " &
           " FROM (" & getTable() & " As PC INNER JOIN " & getTableProjecte() & " As P  On (PC.IDPROJECTE= P.ID)) INNER JOIN " & getTaulaCentres() & " As C On (C.ID=PC.IDCENTRE)", DBCONNECT.getConnectionDbf)
        While Not rc.EOF
            getObjectsDBF.Add(New ProjecteCentre(rc("CIDPROJECTE").Value, rc("CIDCENTRE").Value, rc("cOrdre").Value, 100, rc("CENTRECODI").Value, rc("pCodi").Value, rc("PNOM").Value))
            rc.MoveNext()
        End While
        If rc.State = 1 Then rc.Close()
        rc = Nothing
        getObjectsDBF.Sort()
    End Function
    ''' <summary>
    ''' torna el nom de la taula ProjecteCentre de la BBDD
    ''' </summary>
    ''' <returns>string Nom taula</returns>
    Private Function getTable() As String
        getTable = DBCONNECT.getTaulaCentreProjecte
    End Function
    ''' <summary>
    ''' torna el nom de la taula projecte de la BBDD
    ''' </summary>
    ''' <returns>string Nom taula</returns>
    Private Function getTableProjecte() As String
        Return DBCONNECT.getTaulaProjecte
    End Function
    ''' <summary>
    ''' Obté el nom de la taula Centre de la BBDD
    ''' </summary>
    ''' <returns>String Nom  taula</returns>
    Private Function getTableCentres() As String
        Return DBCONNECT.getTaulaCentres
    End Function

End Module
