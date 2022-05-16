
'IDTAREA	IDPROCESO	TITULO	TIPO
'43  8	RESP. ENGENIERIA Y CONSTRUCCION	3
'44  8	DIRECTOR DE COMPRAS	3
'45  8	GERENCIA	3
'46  8	PENDIENTE DE PEDIDO KRITER	3
'98  8	INTRODUCIR COMPARATIVA + PRESUPUESTOS	3
'112 8	ENVIAR PEDIDO A PROVEEDOR	3
'139 8	VALIDACION RESPONSABLE DE LA COMPRA	3
'214 8	DATOS INCOMPLETOS	3
'221 8	PENDIENTE ELIMINAR	3
'626 8	RESPONSABLE PRODUCCION	3
'951 8	YA ENVIADOS.VALIDAR	3
'1430    8	RESP. ESTUDIOS Y PROYECTOS	3
'1431    8	RESP. INDUSTRIA Y INNOVACION	3


Option Explicit On
Imports System.Data.SqlClient
Module dbEventsMD
    Private Const ID As String = "IDEVENTO"
    Private Const ID_TAREA As String = "IDTAREA"
    Private Const ID_RECURSO As String = "IDRECURSO"
    Private Const ID_TABLA As String = "IDTABLA"
    Private Const FINALIZADO As String = "FINALIZADO"
    Private Const AUTOMATICO As String = "AUTOMATICO"
    Private Const USUARIO As String = "USUARIO"
    Private Const FECHA_ENTRADA As String = "FECHAENTRADA"
    Private Const FECHA_REALIZADO As String = "FECHAREALIZADO"
    Private Const ASOCIADOA As String = "ASOCIADOA"

    ' NOTES.
    '1 ENS CAL AGAFAR ELS EVENTS  PER TAULA? . CAL PENSAR  COM MUNTAR L'ESTRUCTURA. SI FER-HO DINAMIC O ESTATIC. ES A DIR NOS HA SABEM QUIN RECORREGUT CAL FER.  I QUINES PARADES MANUALS HI HA . 
    ' LLAVORS  ENS  CAL AGAFAR ELS RECURSOS PER TAULA I ELS QUE ESTAN EN EL WORKFLOW . I CAL QUE S'ACTUALITZI DINAMICAMENT
    ' O MILLOR DIT GUARDAR  ELS EVENTS PER DIA O PER DIA 

    ' EN TOT CAS. EN AQUEST CAS CAL
    'ACTUALTIZAR L'ESTAT  D'UN EVENT 
    ' INSERTAR NOUS EVENTS . 
    ' SELECT EVENTS PER SABER L'ESTAT DELS RECURSOS  DE LA TAULA 

    ' ENS CAL FER PROVES

    Public Function update(idevent As Long, idEstat As Integer, idUsuari As Integer) As Integer
        Return updateSQL(idevent, idEstat, idUsuari)
    End Function
    Public Function insert(obj As EventsMD) As Integer
        Return insertSQL(obj)
    End Function
    Public Function getObjects() As List(Of EventsMD)
        Return getObjectsSQL()
    End Function
    Public Function getObjects(idRecurs As Integer) As List(Of EventsMD)
        Return getObjectsSQL(idRecurs)
    End Function
    ' TODO FALTA L'USUARI.
    Private Function updateSQL(idEvent As Long, estat As Integer, idUsuari As Integer) As Integer
        Dim sc As SqlCommand, i As Integer

        If idEvent > 0 Then
            sc = New SqlCommand("UPDATE " & getTable() & " " &
                                " SET " & FINALIZADO & "=@idEstat, " &
                                          FECHA_REALIZADO & " =@fRealitzat, " &
                                          USUARIO & " =@usuari " &
                                          " WHERE " & ID & "=@id", DBCONNECT.getConnection)
            sc.Parameters.Add("@id", SqlDbType.Int).Value = idEvent
            sc.Parameters.Add("@idEstat", SqlDbType.Int).Value = estat
            sc.Parameters.Add("@fRealitzat", SqlDbType.DateTime).Value = Now
            sc.Parameters.Add("@usuari", SqlDbType.Int).Value = idUsuari
            i = sc.ExecuteNonQuery
            sc = Nothing
            If i >= 1 Then
                Return idEvent
            End If
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
    Private Function insertSQL(obj As EventsMD) As Integer
        Dim sc As SqlCommand, i As Integer
        sc = New SqlCommand(" INSERT INTO " & getTable() & " " &
                            " (" & ID_TAREA & ", " & ID_RECURSO & ", " & ID_TABLA & ", " & FINALIZADO & ", " & FECHA_ENTRADA & ", " & FECHA_REALIZADO & ", " & USUARIO & ", " & AUTOMATICO & ", " & ASOCIADOA & ")" &
                            " VALUES(@idTarea,@idRecurso,@idTabla,@finalizado,@fEntrada,@fRealizado,@usuario,@automatic,@asociadoa)", DBCONNECT.getConnection)
        sc.Parameters.Add("@idTarea", SqlDbType.Int).Value = obj.idTasca
        sc.Parameters.Add("@idRecurso", SqlDbType.VarChar).Value = obj.idRecurs
        sc.Parameters.Add("@idTabla", SqlDbType.VarChar).Value = obj.idTaula
        sc.Parameters.Add("@finalizado", SqlDbType.VarChar).Value = obj.finalitzat
        sc.Parameters.Add("@fEntrada", SqlDbType.DateTime).Value = obj.dataIni
        sc.Parameters.Add("@fRealizado", SqlDbType.DateTime).Value = obj.dataFi
        sc.Parameters.Add("@usuario", SqlDbType.Int).Value = obj.idUsuari
        sc.Parameters.Add("@automatic", SqlDbType.Int).Value = obj.automatic
        sc.Parameters.Add("@asociadoa", SqlDbType.Int).Value = 0
        i = sc.ExecuteNonQuery

        sc = Nothing
        If i >= 1 Then
            Return obj.id
        End If
        Return -1
    End Function

    ''' <summary>
    ''' Obté tots els centres del sistema 
    ''' </summary>
    ''' <returns>una llista de centres</returns>
    Private Function getObjectsSQL() As List(Of EventsMD)
        Dim sc As SqlCommand, sdr As SqlDataReader, a As EventsMD
        getObjectsSQL = New List(Of EventsMD)
        sc = New SqlCommand("Select IDEVENTO,IDTAREA, IDRECURSO,IDTABLA,FINALIZADO,AUTOMATICO,USUARIO,FECHAENTRADA,FECHAREALIZADO " &
                            " FROM " & getTable() & " as EV INNER JOIN " & getTableComanda() & " AS c  ON (EV.IDRECURSO = c.SYSID)" &
                            " WHERE EV.IDTABLA=@idTaula And EV.FINALIZADO=0 AND c.sysestado=8 ", DBCONNECT.getConnectioMyDoc)
        sc.Parameters.Add("@idTaula", SqlDbType.Int).Value = Right(getTableComanda, 2)
        sdr = sc.ExecuteReader
        While sdr.Read()
            a = New EventsMD(sdr(ID), sdr(ID_TAREA), sdr(ID_RECURSO), sdr(ID_TABLA), sdr(FINALIZADO), sdr(USUARIO), sdr(FECHA_ENTRADA), sdr(FECHA_REALIZADO), sdr(AUTOMATICO))
            getObjectsSQL.Add(a)
        End While
        sdr.Close()
        getObjectsSQL.Sort()
        sdr = Nothing
        sc = Nothing
    End Function
    Private Function getObjectsSQL(idRecurs As Integer) As List(Of EventsMD)
        Dim sc As SqlCommand, sdr As SqlDataReader, a As EventsMD
        getObjectsSQL = New List(Of EventsMD)
        sc = New SqlCommand("Select IDEVENTO,IDTAREA, IDRECURSO,IDTABLA,FINALIZADO,AUTOMATICO,USUARIO,FECHAENTRADA,FECHAREALIZADO " &
                            " FROM " & getTable() & " as EV INNER JOIN " & getTableComanda() & " AS c  ON (EV.IDRECURSO = c.SYSID)" &
                            " WHERE EV.IDTABLA=@idTaula And EV.FINALIZADO=0 AND c.sysestado=8 and IDRECURSO= @idrecurs ", DBCONNECT.getConnectioMyDoc)
        sc.Parameters.Add("@idTaula", SqlDbType.Int).Value = Right(getTableComanda, 2)
        sc.Parameters.Add("@idrecurs", SqlDbType.Int).Value = idRecurs
        sdr = sc.ExecuteReader
        While sdr.Read()
            a = New EventsMD(sdr(ID), sdr(ID_TAREA), sdr(ID_RECURSO), sdr(ID_TABLA), sdr(FINALIZADO), sdr(USUARIO), sdr(FECHA_ENTRADA), sdr(FECHA_REALIZADO), sdr(AUTOMATICO))
            getObjectsSQL.Add(a)
        End While
        sdr.Close()
        getObjectsSQL.Sort()
        sdr = Nothing
        sc = Nothing
    End Function
    Private Function getTable() As String
        Return "dbo.TWFEVENTOS"
    End Function
    Private Function getTableComanda() As String
        Return CONFIG_FILE.getTaulaComandesMydoc
    End Function
End Module

