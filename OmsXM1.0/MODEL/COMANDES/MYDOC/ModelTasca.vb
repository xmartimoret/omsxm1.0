Option Explicit On
Module ModelTasca
    Private objects As List(Of Tasca)
    Public Function getObjects()
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects
    End Function
    Public Function getObject(id As Integer) As Tasca
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Find(Function(x) x.id = id)
    End Function
    Public Function getNom(id As Integer) As String
        Dim t As Tasca
        If Not isUpdated() Then objects = getRemoteObjects()
        For Each t In objects
            If t.id = id Then
                Return t.nom
            End If
        Next
        Return ""
    End Function
    Public Function esFinalWorkflow(id As Integer) As Boolean
        If id = 112 Or id = 951 Then Return True
        Return False
    End Function
    Public Function getIdTascaFinal() As Integer
        Return 42
    End Function
    Private Function isUpdated() As Boolean
        If objects Is Nothing Then
            Return False
        Else
            Return True
        End If
    End Function
    Private Function getRemoteObjects() As List(Of Tasca)
        Dim o As List(Of Tasca)
        o = New List(Of Tasca)
        o.Add(New Tasca(214, "DATOS INCOMPLETOS", 1))
        o.Add(New Tasca(9, "INTRODUCIR COMPARATIVA + PRESUPUESTOS", 2))
        o.Add(New Tasca(46, "PENDIENTE DE PEDIDO KRITER", 3))
        o.Add(New Tasca(221, "PENDIENTE ELIMINAR", 4))
        o.Add(New Tasca(139, "VALIDACION RESPONSABLE DE LA COMPRA", 5))
        o.Add(New Tasca(626, "RESPONSABLE PRODUCCION", 6))
        o.Add(New Tasca(43, "RESP. ENGENIERIA Y CONSTRUCCION", 7))
        o.Add(New Tasca(1430, "RESP.ESTUDIOS Y PROYECTOS", 8))
        o.Add(New Tasca(1431, "RESP.INDUSTRIA Y INNOVACION", 9))
        o.Add(New Tasca(44, "DIRECTOR DE COMPRAS", 10))
        o.Add(New Tasca(45, "GERENCIA", 11))
        o.Add(New Tasca(112, "ENVIAR PEDIDO A PROVEEDOR", 12))
        o.Add(New Tasca(951, "YA ENVIADOS.VALIDAR", 13))
        o.Add(New Tasca(42, "FIN", 14))
        Return o
    End Function
End Module
'IDTAREA	IDPROCESO	TITULO	TIPO
'41  8	Inicio	0
'42  8	Fin	1
'43  8	RESP. ENGENIERIA Y CONSTRUCCION	3
'44  8	DIRECTOR DE COMPRAS	3
'45  8	GERENCIA	3
'46  8	PENDIENTE DE PEDIDO KRITER	3
'48  8	Envio de correo	8
'50  8	EXTRACCION DEL CORREO	9
'72  8	Tarea 9	2
'84  8	Tarea 10	13

'98  8	INTRODUCIR COMPARATIVA + PRESUPUESTOS	3
'112 8	ENVIAR PEDIDO A PROVEEDOR	3
'139 8	VALIDACION RESPONSABLE DE LA COMPRA	3
'143 8	ENVIAR AL USUARIO	8
'194 8	Tarea 16	9
'209 8	ES OBRA?	5
'213 8	GENERADOR DE METADATOS	10
'214 8	DATOS INCOMPLETOS	3
'221 8	PENDIENTE ELIMINAR	3
'554 8	actualitzarKritter	17
'626 8	RESPONSABLE PRODUCCION	3
'627 8	correoDptoCompras	8
'950 8	Tarea 24	13
'951 8	YA ENVIADOS.VALIDAR	3
'952 8	ES ENVIADO?	5
'1032    8	<500	13
'1033    8	ENVIADO <500	13
'1034    8	es < 500	5
'1134    8	CanviTitolDocument	17
'1135    8	LOGIN	9
'1138    8	Tarea 32	5
'1139    8	LoginMAGarcia	13
'1145    8	esNBlanque	5
'1261    8	loginCFernandez	13
'1262    8	actualitzarKritter1	17
'1265    8	 es Alberola	5
'1430    8	RESP. ESTUDIOS Y PROYECTOS	3
'1431    8	RESP. INDUSTRIA Y INNOVACION	3