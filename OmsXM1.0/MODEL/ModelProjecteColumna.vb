Option Explicit On
''' <summary>
''' Representa els projectes que estan associats a una columna en l'aplicació EXPRAM
'''  </summary>
'''<autor>xmarti - agost 2017</autor>
Module ModelProjecteColumna
    Private objects As List(Of ProjecteColumna)

    Private Const COLUMNS As Integer = 2
    Private dateUpdate As DateTime
    ''' <summary>
    ''' Per recuperar els projectes d'una columna, 
    ''' si ja estan en memòria, els agafa, sino va a la base de dades. 
    ''' </summary>
    ''' <param name="idColumna">Identificador de la columna </param>
    ''' <returns>llista de projectes que pertanyen a una columna</returns>
    Public Function getObjects(idColumna As Integer, txt As String) As List(Of ProjecteColumna)
        Dim o As ProjecteColumna, pTemp As Projecte
        getObjects = New List(Of ProjecteColumna)
        If Not isUpdated() Then objects = getRemoteObjects()
        For Each o In objects
            If o.idColumna = idColumna Then
                pTemp = ModelProjecte.getObject(o.idProjecte)
                If TypeName(pTemp) = "Projecte" Then
                    If pTemp.isFilter(txt) Then
                        getObjects.Add(o)
                    End If
                End If
            End If
        Next o
        o = Nothing
        pTemp = Nothing
    End Function
    Public Function getObject(id As String) As ProjecteColumna
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Find(Function(x) x.id = id)
    End Function

    ''' <summary>
    ''' Comprova si existeix un ProjecteColumna
    ''' </summary>
    ''' <param name="obj"> objecte a comprovar</param>
    ''' <returns>true si existeix, en cas contrari false</returns>
    Public Function exist(obj As ProjecteColumna) As Boolean
        If Not isUpdated() Then objects = getRemoteObjects()
        exist = objects.Exists(Function(x) x.id = obj.id)
    End Function
    ''' <summary>
    ''' Comprova si existeix un projecte que estigui vinculat a una columna
    ''' </summary>
    ''' <param name="idProjecte">Identificador del projecte</param>
    ''' <returns>Cert si existeix, fals en cas contrari</returns>
    Public Function existProject(idProjecte As Integer) As Boolean
        If Not isUpdated() Then objects = getRemoteObjects()
        existProject = objects.Exists(Function(x) x.idProjecte = idProjecte)
    End Function
    Public Function getDataList(projectes As List(Of ProjecteColumna)) As DataList
        Dim pc As ProjecteColumna, p As Projecte
        getDataList = New DataList
        If projectes.Count > 0 Then
            getDataList.columns.Add(COLUMN.ID)
            getDataList.columns.Add(COLUMN.ID)
            getDataList.columns.Add(COLUMN.EMPRESA)
            getDataList.columns.Add(COLUMN.CODI)
            getDataList.columns.Add(COLUMN.NOM)
            For Each pc In projectes
                p = ModelProjecte.getObject(pc.idProjecte)
                getDataList.rows.Add(New ListViewItem(New String() {pc.id, p.idEmpresa, ModelEmpresa.getNom(p.idEmpresa), p.codi, p.nom}))
            Next
        End If
        p = Nothing
        pc = Nothing
    End Function
    ''' <summary>
    ''' Guarda un projecte columna a la base de dades i actualitza la llista d'objectes 
    ''' que estan en memoria. Només el guarda en cas que no existeix, no es pot actualitzar.
    ''' </summary>
    ''' <param name="obj">ProjecteColumna a guardara</param>
    ''' <returns>Cert si s'ha dut a terme l'acció, fals en cas contrari</returns>
    Public Function save(obj As ProjecteColumna) As Boolean
        If Not exist(obj) Then
            If dbProjecteColumna.Insert(obj) Then
                dateUpdate = Now()
                objects.Add(obj)
                Return True
            End If
        End If
        Return False
    End Function
    ''' <summary>
    ''' Elimina un ProjecteColumna de la base de dades i actualitza els objectes que estan 
    ''' en memòria-
    ''' </summary>
    ''' <param name="obj">ProjecteColumna a eliminar</param>
    ''' <returns>Cert si s'ha dut a terme l'acció, fals en cas contrari</returns>
    Public Function remove(obj As ProjecteColumna) As Boolean
        If dbProjecteColumna.remove(obj) Then
            dateUpdate = Now()
            objects.RemoveAll(Function(X) X.id = obj.id)
            Return True
        End If
        Return False
    End Function
    ''' <summary>
    ''' Reseteja la llista que conté els objectes en memòria
    ''' </summary>
    Public Sub resetIndex()
        objects = Nothing
    End Sub
    ''' <summary>
    ''' Carrega en memòria tots els objectes 
    ''' </summary>
    ''' <returns>Llista de projecteColumna</returns>
    Private Function getRemoteObjects() As List(Of ProjecteColumna)
        dateUpdate = Now()
        Return dbProjecteColumna.getObjects
    End Function
    ''' <summary>
    ''' Comprova si la taula de base de dades ha estat actualitzada
    ''' </summary>
    ''' <returns>cert en cas afirmatiu , fals en cas contrari</returns>
    Private Function isUpdated() As Boolean
        If Not objects Is Nothing Then
            isUpdated = DBCONNECT.isUpdated(dateUpdate, getTable())
        Else
            Return False
        End If
        If isUpdated Then dateUpdate = Now
    End Function
    ''' <summary>
    ''' Obté el nom de la taula projecteColumna a la base de dades
    ''' </summary>
    ''' <returns>nom de la taula</returns>
    Private Function getTable() As String
        getTable = DBCONNECT.getTaulaProjectesColumna
    End Function


End Module
