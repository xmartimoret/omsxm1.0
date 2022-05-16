'Option Explicit On
'Imports System.Data.SqlClient

'Module dbUpdateDrive

'    Private Const ID As String = "ID"
'    Private Const TAULA As String = "TAULA"
'    Private Const ACCIO As String = "ACCIO"
'    Public Function insert(obj As UpdateDrive) As Integer
'        If IS_SQLSERVER() Then Return insertSQL(obj)
'        Return insertDBF(obj)
'    End Function
'    Public Function remove(obj As UpdateDrive) As Boolean
'        If IS_SQLSERVER() Then Return removeSQL(obj)
'        Return removeDBF(obj)
'    End Function
'    Public Function getObjects() As List(Of UpdateDrive)
'        If IS_SQLSERVER() Then Return getObjectsSQL()
'        Return getObjectsDBF()
'    End Function

'    Private Function insertSQL(obj As UpdateDrive) As Integer
'        Dim sc As SqlCommand, i As Integer
'        obj.id = DBCONNECT.getMaxId(getTable) + 1
'        sc = New SqlCommand(" INSERT INTO " & getTable() & " " &
'                                " (" & ID & ", " & TAULA & "," & ACCIO & ")" &
'                                " VALUES(@id,@taula,@accio)", DBCONNECT.getConnection)
'        sc.Parameters.Add("@id", SqlDbType.Int).Value = obj.id
'        sc.Parameters.Add("@serie", SqlDbType.Int).Value = obj.taula
'        sc.Parameters.Add("@codi", SqlDbType.Int).Value = obj.accio
'        i = sc.ExecuteNonQuery

'        sc = Nothing
'        If i >= 1 Then
'            Return obj.id
'        End If
'        Return -1
'    End Function
'    ''' <summary>
'    '''  Elimina  un centre de la base de dades
'    ''' </summary>
'    ''' <param name="obj"></param>
'    ''' <returns></returns>
'    Private Function removeSQL(obj As UpdateDrive) As Boolean
'        Dim sc As SqlCommand, i As Integer
'        sc = New SqlCommand("DELETE FROM " & getTable() & " WHERE " & ID & "=@id AND " & TAULA & "=@taula", DBCONNECT.getConnection)
'        sc.Parameters.Add("@id", SqlDbType.Int).Value = obj.id
'        sc.Parameters.Add("@taula", SqlDbType.Int).Value = obj.taula
'        i = sc.ExecuteNonQuery
'        sc = Nothing
'        If i >= 1 Then
'            Return True
'        End If
'        Return False
'    End Function

'    ''' <summary>
'    ''' Obté tots els centres del sistema 
'    ''' </summary>
'    ''' <returns>una llista de centres</returns>
'    Private Function getObjectsSQL() As List(Of UpdateDrive)
'        Dim sc As SqlCommand, sdr As SqlDataReader, cc As UpdateDrive
'        getObjectsSQL = New List(Of UpdateDrive)
'        sc = New SqlCommand("SELECT * FROM " & getTable(), getConnection)
'        sdr = sc.ExecuteReader
'        While sdr.Read()
'            cc = New UpdateDrive(sdr(ID),
'                                   sdr(TAULA),
'                                   sdr(ACCIO))
'            getObjectsSQL.Add(cc)
'        End While
'        sdr.Close()
'        getObjectsSQL.Sort()
'        sdr = Nothing
'        sc = Nothing
'    End Function
'    Private Function insertDBF(obj As UpdateDrive) As Integer
'        Dim sc As ADODB.Command
'        sc = New ADODB.Command
'        obj.id = DBCONNECT.getMaxIdDBF(getTable) + 1
'        With sc
'            .ActiveConnection = DBCONNECT.getConnectionDbf
'            .CommandText = " INSERT INTO " & getTable() & " " &
'                                " (" & ID & ", " & TAULA & "," & ACCIO & ")" &
'                                " VALUES(?,?,?)"
'            .Parameters.Append(ADOPARAM.ToInt(obj.id))
'            .Parameters.Append(ADOPARAM.ToInt(obj.taula))
'            .Parameters.Append(ADOPARAM.ToInt(obj.accio))
'        End With
'        Try
'            sc.Execute()
'            Return obj.id
'        Catch ex As Exception
'            Call ERRORS.ERR_EXCEPTION_SQL(ex.Message)
'            Return -1
'        Finally
'            sc = Nothing
'        End Try

'    End Function
'    ''' <summary>
'    '''  Elimina  un centre de la base de dades
'    ''' </summary>
'    ''' <param name="obj"></param>
'    ''' <returns></returns>
'    Private Function removeDBF(obj As UpdateDrive) As Boolean
'        Dim sc As ADODB.Command
'        sc = New ADODB.Command
'        With sc
'            sc.ActiveConnection = DBCONNECT.getConnectionDbf
'            sc.CommandText = " DELETE FROM " & getTable() & " WHERE " & ID & "=? AND " & TAULA & "=?"
'            sc.Parameters.Append(ADOPARAM.ToInt(obj.id))
'            sc.Parameters.Append(ADOPARAM.ToInt(obj.taula))
'        End With
'        Try
'            sc.Execute()
'            Return True
'        Catch ex As Exception
'            Call ERRORS.ERR_EXCEPTION_SQL(ex.Message)
'            Return False
'        Finally
'            sc = Nothing
'        End Try
'    End Function

'    ''' <summary>
'    ''' Obté tots els centres del sistema 
'    ''' </summary>
'    ''' <returns>una llista de centres</returns>
'    Private Function getObjectsDBF() As List(Of UpdateDrive)
'        Dim rc As ADODB.Recordset, cc As UpdateDrive
'        rc = New ADODB.Recordset
'        getObjectsDBF = New List(Of UpdateDrive)
'        rc.Open("SELECT * FROM " & getTable(), DBCONNECT.getConnectionDbf)
'        While Not rc.EOF
'            cc = New UpdateDrive(rc(ID).Value,
'                                   rc(TAULA).Value,
'                                   rc(ACCIO).Value)
'            getObjectsDBF.Add(cc)
'            rc.MoveNext()
'        End While
'        If rc.State = 1 Then rc.Close()
'        rc = Nothing
'        getObjectsDBF.Sort()
'    End Function
'    Private Function getTable() As String
'        Return DBCONNECT.getTaulaUpdateDrive
'    End Function
'    End Module


