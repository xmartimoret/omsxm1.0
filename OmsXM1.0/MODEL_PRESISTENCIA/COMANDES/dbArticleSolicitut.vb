Option Explicit On
Imports System.Data.SqlClient
Module dbArticleSolicitut
    Private Const ID As String = "ID"
    Private Const CODI As String = "CODI"
    Private Const ID_SOLICITUT As String = "IDSOL"
    Private Const POSICIO_FILA As String = "POS"
    Private Const ID_ARTICLE As String = "IDART"
    Private Const PREU As String = "PREU"
    Private Const DESCOMPTE As String = "DCTE"
    Private Const ID_UNITAT As String = "UNITAT"
    Private Const QUANTITAT As String = "QUANTI"
    Private Const NOM As String = "NOM"
    'ACCESSORS CENTRE
    ''' <summary>
    ''' SAVE. Guarda un centre a la base de dades. 
    ''' Si es nou, fa una inserció si no  actualitza.
    ''' </summary>
    ''' <param name="obj"> centre</param>
    ''' <returns>identificador del centre.</returns>
    Public Function update(obj As ArticleSolicitut) As Integer
        If IS_SQLSERVER() Then Return updateSQL(obj)
        Return updateDBF(obj)
    End Function
    Public Function insert(obj As ArticleSolicitut) As Integer
        If IS_SQLSERVER() Then Return insertSQL(obj)
        Return insertDBF(obj)
    End Function
    Public Function remove(obj As ArticleSolicitut) As Boolean
        If IS_SQLSERVER() Then Return removeSQL(obj)
        Return removeDBF(obj)
    End Function
    Public Function remove(obj As SolicitudComanda) As Boolean
        If IS_SQLSERVER() Then Return removeSQL(obj)
        Return removeDBF(obj)
    End Function
    Public Function getObjects(iniArticle As Integer, fiArticle As Integer) As List(Of ArticleSolicitut)
        If IS_SQLSERVER() Then Return getObjectsSQL()
        Return getObjectsDBF(iniArticle, fiArticle)
    End Function
    Private Function updateSQL(obj As ArticleSolicitut) As Integer
        Dim sc As SqlCommand, i As Integer
        sc = New SqlCommand("UPDATE " & getTable() & " " &
                                " SET " & ID_SOLICITUT & "=@idComanda," &
                                          POSICIO_FILA & "=@posFila," &
                                          PREU & "=@preu," &
                                          DESCOMPTE & "=@descompte," &
                                          ID_UNITAT & " =@idUnitat, " &
                                          QUANTITAT & " =@quantitat, " &
                                          NOM & " =@nom, " &
                                          CODI & " =@codi " &
                                          " WHERE " & ID & "=@id", DBCONNECT.getConnection)
        sc.Parameters.Add("@id", SqlDbType.Int).Value = obj.id
        sc.Parameters.Add("@idComanda", SqlDbType.Int).Value = obj.id
        sc.Parameters.Add("@posfila", SqlDbType.Int).Value = obj.pos
        sc.Parameters.Add("@preu", SqlDbType.Decimal).Value = obj.preu
        sc.Parameters.Add("@descompte", SqlDbType.Decimal).Value = obj.tpcDescompte
        sc.Parameters.Add("@idUnitat", SqlDbType.Char).Value = obj.unitat
        sc.Parameters.Add("@quantitat", SqlDbType.Int).Value = obj.quantitat
        sc.Parameters.Add("@nom", SqlDbType.Int).Value = obj.nom
        sc.Parameters.Add("@codi", SqlDbType.Int).Value = obj.codi
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
    Private Function insertSQL(obj As ArticleSolicitut) As Integer
        Dim sc As SqlCommand, i As Integer
        obj.id = DBCONNECT.getMaxId(getTable) + 1

        sc = New SqlCommand(" INSERT INTO " & getTable() & " " &
                            " (" & ID & ", " & ID_SOLICITUT & ", " & POSICIO_FILA & ", " & PREU & ", " & ", " & DESCOMPTE & ", " & ID_UNITAT & ", " & QUANTITAT & ", " & NOM & "," & CODI & ")" &
                            " VALUES(@id,@idComanda,@posFila,@preuArticle,@descompte,@idUnitat,@quantitat,@nom,@codi)", DBCONNECT.getConnection)
        sc.Parameters.Add("@id", SqlDbType.Int).Value = obj.id
        sc.Parameters.Add("@idComanda", SqlDbType.Int).Value = obj.id
        sc.Parameters.Add("@posfila", SqlDbType.Int).Value = obj.pos
        sc.Parameters.Add("@preuArticle", SqlDbType.Decimal).Value = obj.preu
        sc.Parameters.Add("@descompte", SqlDbType.Decimal).Value = obj.tpcDescompte
        sc.Parameters.Add("@idUnitat", SqlDbType.Char).Value = obj.unitat
        sc.Parameters.Add("@quantitat", SqlDbType.Int).Value = obj.quantitat
        sc.Parameters.Add("@nom", SqlDbType.Int).Value = obj.nom
        sc.Parameters.Add("@codi", SqlDbType.Int).Value = obj.codi

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
    Private Function removeSQL(obj As ArticleSolicitut) As Boolean
        Dim sc As SqlCommand, i As Integer
        sc = New SqlCommand("DELETE FROM " & getTable() & " WHERE " & ID_ARTICLE & "=@id", DBCONNECT.getConnection)
        sc.Parameters.Add("@id", SqlDbType.Int).Value = obj.id
        i = sc.ExecuteNonQuery
        sc = Nothing
        If i >= 1 Then
            Return True
        End If
        Return False
    End Function
    Private Function removeSQL(obj As SolicitudComanda) As Boolean
        Dim sc As SqlCommand, i As Integer
        sc = New SqlCommand("DELETE FROM " & getTable() & " WHERE " & ID_SOLICITUT & "=@id", DBCONNECT.getConnection)
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
    Private Function getObjectsSQL() As List(Of ArticleSolicitut)
        Dim sc As SqlCommand, sdr As SqlDataReader, a As ArticleSolicitut
        getObjectsSQL = New List(Of ArticleSolicitut)
        sc = New SqlCommand("Select * FROM " & getTable(), getConnection)
        sdr = sc.ExecuteReader
        While sdr.Read()
            a = New ArticleSolicitut(sdr(ID), sdr(ID_SOLICITUT),
                               sdr(POSICIO_FILA), CONFIG.validarNull(Trim(sdr(CODI))), CONFIG.validarNull(Trim(sdr(NOM))))
            a.preu = sdr(PREU)
            a.tpcDescompte = sdr(DESCOMPTE)
            a.quantitat = sdr(QUANTITAT)

            a.unitat = ModelUnitat.getAuxiliar.getObject(sdr(ID_UNITAT))
            getObjectsSQL.Add(a)
        End While
        sdr.Close()
        sdr = Nothing
        sc = Nothing
    End Function

    Private Function updateDBF(obj As ArticleSolicitut) As Integer
        Dim sc As ADODB.Command
        sc = New ADODB.Command
        With sc
            .ActiveConnection = DBCONNECT.getConnectionDbf
            .CommandText = "UPDATE " & getTable() & " " &
                                 " SET " & ID_SOLICITUT & "=?," &
                                          POSICIO_FILA & "=?," &
                                          PREU & "=?," &
                                          DESCOMPTE & "=?," &
                                          ID_UNITAT & " =?, " &
                                          QUANTITAT & " =?, " &
                                          NOM & " =?, " &
                                          CODI & " =? " &
                                          " WHERE " & ID & "=?"
            .Parameters.Append(ADOPARAM.ToInt(obj.idSolicutComanda))
            .Parameters.Append(ADOPARAM.ToInt(obj.pos))
            .Parameters.Append(ADOPARAM.ToSingle(Math.Round(obj.preu * 1000, 0)))
            .Parameters.Append(ADOPARAM.ToSingle(Math.Round(obj.tpcDescompte * 100, 0)))
            .Parameters.Append(ADOPARAM.ToString(obj.unitat))
            .Parameters.Append(ADOPARAM.ToSingle(Math.Round(obj.quantitat * 100, 0)))
            .Parameters.Append(ADOPARAM.ToString(Left(obj.nom, 249)))
            .Parameters.Append(ADOPARAM.ToString(obj.codi))
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
    Private Function insertDBF(obj As ArticleSolicitut) As Integer
        Dim sc As ADODB.Command
        sc = New ADODB.Command
        obj.id = DBCONNECT.getMaxIdDBF(getTable) + 1
        With sc
            .ActiveConnection = DBCONNECT.getConnectionDbf
            .CommandText = " INSERT INTO " & getTable() & " " &
                           " (" & ID & ", " & ID_SOLICITUT & ", " & POSICIO_FILA & ", " & PREU & ", " & DESCOMPTE & ", " & ID_UNITAT & ", " & QUANTITAT & ", " & NOM & "," & CODI & ")" &
                            " VALUES(?,?,?,?,?,?,?,?,?)"
            .Parameters.Append(ADOPARAM.ToInt(obj.id))
            .Parameters.Append(ADOPARAM.ToInt(obj.idSolicutComanda))
            .Parameters.Append(ADOPARAM.ToInt(obj.pos))
            .Parameters.Append(ADOPARAM.ToSingle(Math.Round(obj.preu * 1000, 0)))
            .Parameters.Append(ADOPARAM.ToSingle(Math.Round(obj.tpcDescompte * 100, 0)))
            .Parameters.Append(ADOPARAM.ToString(obj.unitat))
            .Parameters.Append(ADOPARAM.ToSingle(Math.Round(obj.quantitat * 100, 0)))
            .Parameters.Append(ADOPARAM.ToString(Left(obj.nom, 249)))
            .Parameters.Append(ADOPARAM.ToString(obj.codi))
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
    Private Function removeDBF(obj As ArticleSolicitut) As Boolean
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
    Private Function removeDBF(obj As SolicitudComanda) As Boolean
        Dim sc As ADODB.Command
        sc = New ADODB.Command
        With sc
            sc.ActiveConnection = DBCONNECT.getConnectionDbf
            sc.CommandText = " DELETE FROM " & getTable() & " WHERE " & ID_SOLICITUT & "=?"
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
    Private Function getObjectsDBF() As List(Of ArticleSolicitut)
        Dim rc As ADODB.Recordset, a As ArticleSolicitut
        rc = New ADODB.Recordset
        getObjectsDBF = New List(Of ArticleSolicitut)
        rc.Open("Select * FROM " & getTable(), DBCONNECT.getConnectionDbf)
        While Not rc.EOF
            a = New ArticleSolicitut(rc(ID).Value, rc(ID_SOLICITUT).Value,
                               rc(POSICIO_FILA).Value, Trim(CONFIG.validarNull(rc(CODI).Value)),
                               Trim(CONFIG.validarNull(rc(NOM).Value)))
            a.preu = Math.Round(rc(PREU).Value / 1000, 3)
            a.tpcDescompte = Math.Round(rc(DESCOMPTE).Value / 100, 2)
            a.quantitat = Math.Round(rc(QUANTITAT).Value / 100, 2)
            Try
                a.unitat = rc(ID_UNITAT).Value
            Catch ex As System.InvalidCastException
                a.unitat = ""
            End Try

            getObjectsDBF.Add(a)
            rc.MoveNext()
        End While
        If rc.State = 1 Then rc.Close()
        rc = Nothing
    End Function
    ''' <summary>
    ''' Obté tots els centres del sistema 
    ''' </summary>
    ''' <returns>una llista de centres</returns>
    Private Function getObjectsDBF(ini As Integer, fi As Integer) As List(Of ArticleSolicitut)
        Dim rc As ADODB.Recordset, a As ArticleSolicitut
        rc = New ADODB.Recordset
        getObjectsDBF = New List(Of ArticleSolicitut)
        rc.Open("Select * FROM " & getTable() & " WHERE " & ID_SOLICITUT & " BETWEEN " & ini & " AND " & fi, DBCONNECT.getConnectionDbf)
        While Not rc.EOF
            a = New ArticleSolicitut(rc(ID).Value, rc(ID_SOLICITUT).Value,
                               rc(POSICIO_FILA).Value, Trim(CONFIG.validarNull(rc(CODI).Value)),
                               Trim(CONFIG.validarNull(rc(NOM).Value)))
            a.preu = Math.Round(rc(PREU).Value / 1000, 3)
            a.tpcDescompte = Math.Round(rc(DESCOMPTE).Value / 100, 2)
            a.quantitat = Math.Round(rc(QUANTITAT).Value / 100, 2)
            Try
                a.unitat = rc(ID_UNITAT).Value
            Catch ex As System.InvalidCastException
                a.unitat = ""
            End Try

            getObjectsDBF.Add(a)
            rc.MoveNext()
        End While
        If rc.State = 1 Then rc.Close()
        rc = Nothing
    End Function
    Private Function getTable() As String
        Return DBCONNECT.getTaulaArticleSolicitud
    End Function
End Module

