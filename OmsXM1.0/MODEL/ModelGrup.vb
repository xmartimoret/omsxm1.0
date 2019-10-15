Option Explicit On
''' <summary>
''' Grups Comptables. 
''' <autor>xmarti  Agost 2017</autor>
''' </summary>
Public Module ModelGrup
    Private objects As List(Of Grup)

    Private Const N_COLUMNS As Integer = 2
    Private dateUpdate As DateTime
    Public Function getObjects() As List(Of Grup)
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects
    End Function

    Public Function getObjects(filtre As String) As List(Of Grup)
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.FindAll(Function(x) x.isFilter(filtre))
    End Function
    ''' <summary>
    ''' Obté una llista(Datalist) per poder presentar a l'usuari mitjançant un formulari
    ''' </summary>
    ''' <param name="grups">Conjunt d'objectes a llistar</param>
    ''' <returns>DataList  amb les dades dels objectes que s'han passat com a paràmetre</returns>
    Public Function getDataList(grups As List(Of Grup)) As DataList
        Dim g As Grup
        getDataList = New DataList
        If grups.Count > 0 Then
            getDataList.columns.Add(COLUMN.ID)
            getDataList.columns.Add(COLUMN.NOM)
            For Each g In grups
                getDataList.rows.Add(New ListViewItem(New String() {g.id, g.ToString}))
            Next
        End If
        g = Nothing
    End Function
    Public Function getListObjects(grups As List(Of Grup)) As Object()
        Dim obj As Grup, i As Integer = 0, objectes() As Object
        ReDim objectes(grups.Count - 1)
        For Each obj In grups
            objectes(i) = obj
            i = i + 1
        Next
        getListObjects = objectes
        objectes = Nothing
        obj = Nothing
    End Function
    ''' <summary>
    ''' Obté un GrupComptable a partir del seu identificador.
    ''' </summary>
    ''' <param name="id">Identificador</param>
    ''' <returns>Subgrup Comptable</returns>
    Public Function getObject(id As Integer) As Grup
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Find(Function(X) X.id = id)
    End Function
    ''' <summary>
    ''' Obté un GrupComptable a partir del seu Codi.
    ''' </summary>
    ''' <param name="codi">codi</param>
    ''' <returns>Grup Comptable</returns>
    Public Function getObject(codi As String) As Grup
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Find(Function(X) X.codi = codi)
    End Function
    ''' <summary>
    ''' Guardar un subgrup comptable a la base de dades.
    ''' Si no existeix l'insereix, sino l'actualitza
    ''' </summary>
    ''' <param name="obj">subgrupComptable a guardar</param>
    ''' <returns>l'identificador del subgrup comptable guardat</returns>
    Public Function save(obj As Grup) As Integer
        Dim i As Integer
        If obj.id = -1 Then
            obj.ordre = getMaxOrder() + 1
            i = dbGrup.insert(obj)
        Else
            i = dbGrup.update(obj)
        End If
        If i > -1 Then
            obj.id = 1
            dateUpdate = Now()
            objects.Remove(obj)
            objects.Add(obj)
            Return obj.id
        End If
        Return -1
    End Function
    ''' <summary>
    ''' Elimina un Grup comptable de la base de dades i del sistema
    ''' </summary>
    ''' <param name="obj">Grup comptable a eliminar</param>
    ''' <returns>cert si s'ha eliminat, fals en cas contrari</returns>
    Public Function remove(obj As Grup) As Boolean
        If dbGrup.remove(obj.id) Then
            dateUpdate = Now()
            objects.Remove(obj)
            Return True
        End If
        Return False
    End Function
    ''' <summary>
    ''' Elimina un Grup comptable de la base de dades i del sistema
    ''' </summary>
    ''' <param name="id">Grup comptable a eliminar</param>
    ''' <returns>cert si s'ha eliminat, fals en cas contrari</returns>
    Public Function remove(id As Integer) As Boolean
        If dbGrup.remove(id) Then
            dateUpdate = Now()
            objects.RemoveAll(Function(x) x.id = id)
            Return True
        End If
        Return False
    End Function
    ''' <summary>
    ''' Comprova que existeix un Grupcomptable.
    ''' </summary>
    ''' <param name="g">Grup Comptable</param>
    ''' <returns>cert si exiteix, fals en cas contrari</returns>
    Public Function exist(g As Grup) As Boolean
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Exists(Function(x) x.id <> g.id And StrComp(x.codi, g.codi, CompareMethod.Text) = 0)
    End Function
    ''' <summary>
    ''' Comprova que existeix un Grupcomptable.
    ''' </summary>
    ''' <param name="id">identificador del grup Comptable</param>
    ''' <returns>cert si exiteix, fals en cas contrari</returns>
    Public Function exist(id As Integer) As Boolean
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Exists(Function(x) x.id = id)
    End Function

    ''' <summary>
    ''' Canvia l'ordre de dos GrupsComptables
    ''' </summary>
    ''' <param name="g1">GrupComptable </param>
    ''' <param name="g2">GrupComptable</param>
    Public Sub changeOrder(g1 As Grup, g2 As Grup)
        Dim temp As Integer
        If UCase(TypeName(g1)) = UCase("grup") And UCase(TypeName(g2)) = UCase("grup") Then
            If g1.id > 0 And g2.id > 0 Then
                temp = g1.ordre
                g1.ordre = g2.ordre
                g2.ordre = temp
                Call save(g1)
                Call save(g2)
            End If
        End If
    End Sub
    ''' <summary>
    ''' Cerca el grup que fa de resum
    ''' </summary>
    ''' <returns>Enter, id Grup</returns>
    Public Function getIdGrupResum() As Integer
        If Not isUpdated() Then objects = getRemoteObjects()
        getIdGrupResum = 0
        getIdGrupResum = objects.Find(Function(x) x.resum = True).id
    End Function
    ''' <summary>
    ''' Reseteja els subgrups del sistema. Borra els objectes residents en memòria
    ''' </summary>
    Public Sub resetIndex()
        objects = Nothing
    End Sub
    'PRIVATE FUNCTIONS
    ''' <summary>
    ''' Calcula l'ordre maxim dins un grup Comptable
    ''' </summary>    
    ''' <returns>Enter, l'ordre max d'un grup comptable</returns>
    Private Function getMaxOrder() As Integer
        Dim obj As Grup
        If Not isUpdated() Then objects = getRemoteObjects()
        getMaxOrder = 0
        For Each obj In objects
            If obj.ordre > getMaxOrder() Then getMaxOrder = obj.ordre
        Next obj
        obj = Nothing
    End Function
    ''' <summary>
    ''' obté tots els subgrupsComptables de la BBDD
    ''' </summary>
    ''' <returns>Una llista de tots els SubgrupsComptables de la BBDD</returns>
    Private Function getRemoteObjects() As List(Of Grup)
        dateUpdate = Now()
        Return dbGrup.getObjects
    End Function
    ''' <summary>
    ''' Comprova si s'ha actualitzat la BBDD
    ''' </summary>
    ''' <returns>Cert  en cas afirmatiu, fals en cas contrari</returns>
    Private Function isUpdated() As Boolean
        If Not objects Is Nothing Then
            isUpdated = DBCONNECT.isUpdated(dateUpdate, getTable())
        Else
            Return False
        End If
        If isUpdated Then dateUpdate = Now
    End Function
    ''' <summary>
    ''' obté el nom de la taula de la BBDD
    ''' </summary>
    ''' <returns>String</returns>
    Private Function getTable() As String
        Return DBCONNECT.getTaulaGrups
    End Function

End Module
