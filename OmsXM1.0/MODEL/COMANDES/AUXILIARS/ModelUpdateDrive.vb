'Option Explicit On
'Module ModelUpdateDrive
'    Private objects As List(Of UpdateDrive)
'    Private dateUpdate As DateTime
'    Friend Enum IdTaula
'        PROVEIDOR = 1
'        CONTACTE_PROVEIDOR = 2
'        MAGATZEM = 3
'        CONTACTE_MAGATZEM = 4
'        EMPRESA = 5
'        RESPONSABLE = 6
'        PROJECTE = 7
'    End Enum
'    Friend Enum IdAccio
'        SELECCIONAR = 0
'        ACTUALITZAR = 1
'        INSERTAR = 2
'        ELIMINAR = 3
'    End Enum
'    Public Function getObjects(Optional accio As IdAccio = 0) As List(Of UpdateDrive)
'        Dim a As UpdateDrive
'        If Not isUpdated() Then objects = getRemoteObjects()
'        getObjects = New List(Of UpdateDrive)
'        If accio = 0 Then Return objects
'        For Each a In objects
'            If accio = a.accio Then
'                getObjects.Add(a)
'            End If
'        Next
'        a = Nothing
'    End Function
'    Public Function getObjects(taula As IdTaula, Optional accio As IdAccio = 0) As List(Of UpdateDrive)
'        Dim a As UpdateDrive
'        If Not isUpdated() Then objects = getRemoteObjects()
'        getObjects = New List(Of UpdateDrive)
'        For Each a In objects
'            If taula = a.taula Then
'                If accio = 0 Or accio = a.accio Then
'                    getObjects.Add(a)
'                End If
'            End If
'        Next
'        a = Nothing
'    End Function
'    Public Function getObject(id As Integer, taula As IdTaula) As UpdateDrive
'        If Not isUpdated() Then objects = getRemoteObjects()
'        Return objects.Find(Function(x) x.id = id And x.taula = taula)
'    End Function
'    Public Function exist(id As Integer, taula As IdTaula) As Boolean
'        If Not isUpdated() Then objects = getRemoteObjects()
'        Return objects.Exists(Function(x) x.id = id And x.taula = taula)
'    End Function
'    Public Function save(obj As UpdateDrive) As Boolean
'        Dim result As Boolean
'        result = dbUpdateDrive.insert(obj)
'        If result Then
'            dateUpdate = Now()
'            objects.Add(obj)
'        End If
'        Return result
'    End Function
'    Public Function remove(obj As UpdateDrive) As Boolean
'        Dim result As Boolean
'        result = dbUpdateDrive.remove(obj)
'        If result Then
'            dateUpdate = Now()
'            objects.Remove(obj)
'        End If
'        Return result
'    End Function
'    Public Sub resetIndex()
'        objects = Nothing
'    End Sub
'    Public Sub setdata()
'        If Not isUpdated() Then objects = getRemoteObjects()
'    End Sub
'    Private Function getRemoteObjects() As List(Of UpdateDrive)
'        dateUpdate = Now()
'        Return dbUpdateDrive.getObjects
'    End Function
'    ''' <summary>
'    ''' Comprova si s'ha actualitzat la BBDD
'    ''' </summary>
'    ''' <returns>Cert  en cas afirmatiu, fals en cas contrari</returns>
'    Private Function isUpdated() As Boolean
'        If Not objects Is Nothing Then
'            isUpdated = DBCONNECT.isUpdated(dateUpdate, DBCONNECT.getTaulaUpdateDrive)
'        Else
'            Return False
'        End If
'        If isUpdated Then dateUpdate = Now
'    End Function
'End Module


