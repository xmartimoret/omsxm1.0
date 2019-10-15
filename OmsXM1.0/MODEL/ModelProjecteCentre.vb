Option Explicit On
Public Module ModelProjecteCentre
    Private objects As List(Of ProjecteCentre)
    Private Const N_COLUMNS As Integer = 5
    Private dateUpdate As DateTime


    Public Function getObjects(idCentre As Integer) As List(Of ProjecteCentre)
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.FindAll(Function(x) x.idCentre = idCentre)
    End Function

    ''' <summary>
    ''' Obté una llista(Datalist) per poder presentar a l'usuari mitjançant un formulari
    ''' </summary>
    ''' <param name="projectesCentre">Conjunt d'objectes a llistar</param>
    ''' <returns>DataList  amb les dades dels objectes que s'han passat com a paràmetre</returns>
    Public Function getDataList(projectesCentre As List(Of ProjecteCentre)) As DataList
        Dim obj As ProjecteCentre, p As Projecte
        getDataList = New DataList
        projectesCentre.Sort()

        If projectesCentre.Count > 0 Then
            getDataList.columns.Add(COLUMN.ID)
            getDataList.columns.Add(COLUMN.EMPRESA)
            getDataList.columns.Add(COLUMN.CODI)
            getDataList.columns.Add(COLUMN.NOM)
            For Each obj In projectesCentre
                p = ModelProjecte.getObject(obj.idProjecte)
                If p IsNot Nothing Then
                    getDataList.rows.Add(New ListViewItem(New String() {obj.id, ModelEmpresa.getObject(p.idEmpresa).nom, p.codi, p.nom}))
                End If
            Next
        End If
        obj = Nothing
        p = Nothing
    End Function
    Public Function getObject(id As String) As ProjecteCentre
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Find(Function(x) x.id = id)
    End Function
    Public Function getObject(idCentre As Integer, idProjecte As Integer) As ProjecteCentre
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Find(Function(x) x.idProjecte = idProjecte And x.idCentre = idCentre)
    End Function
    Public Function getCodiCentre(idProjecte As Integer) As String
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Find(Function(x) x.idProjecte = idProjecte).codiCentre
    End Function
    Public Function getObjectByProjecte(idProjecte As Integer) As ProjecteCentre
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Find(Function(x) x.idProjecte = idProjecte)
    End Function

    Public Function save(obj As ProjecteCentre) As Boolean
        Dim result As Boolean
        If Not exist(obj) Then
            obj.ordre = getMaxOrder(obj.idCentre) + 1
            result = dbProjecteCentre.insert(obj)
        Else
            result = dbProjecteCentre.update(obj)
        End If
        If result Then
            dateUpdate = Now()
            objects.Remove(obj)
            objects.Add(obj)
        End If
        Return result
    End Function

    Public Function remove(idProjecte As Integer, idCentre As Integer) As Boolean
        Dim result As Boolean
        result = dbProjecteCentre.remove(idProjecte, idCentre)
        If result Then
            dateUpdate = Now()
            objects.RemoveAll(Function(x) x.idCentre = idCentre And x.idProjecte = idProjecte)
        End If
        Return result
    End Function
    Public Function remove(p As ProjecteCentre) As Boolean
        Dim result As Boolean
        result = dbProjecteCentre.remove(p)
        If result Then
            dateUpdate = Now()
            objects.RemoveAll(Function(x) x.idCentre = p.idCentre And x.idProjecte = p.idProjecte)
        End If
        Return result
    End Function
    Public Function removeCentre(idCentre As Integer) As Boolean
        Dim result As Boolean
        result = dbProjecteCentre.removeCentre(idCentre)
        If result Then
            dateUpdate = Now()
            objects.RemoveAll(Function(x) x.idCentre = idCentre)
        End If
        Return result
    End Function

    Public Function exist(obj As ProjecteCentre) As Boolean
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Exists(Function(x) x.idProjecte = obj.idProjecte And x.idCentre = obj.idCentre)
    End Function
    Public Function exist(idCentre As Integer, idProjecte As Integer) As Boolean
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Exists(Function(x) x.idProjecte = idProjecte And x.idCentre = idCentre)
    End Function

    Public Function existProjecte(idProjecte As Integer) As Boolean
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Exists(Function(x) x.idProjecte = idProjecte)
    End Function
    Public Function existProjecte(departa As String, clave As String) As Boolean
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Exists(Function(x) UCase(x.departa) = UCase(departa) And UCase(x.clau) = UCase(clave))
    End Function
    Public Function changeOrdre(id1 As String, id2 As String) As Boolean
        Dim temp As String, pe1 As ProjecteCentre, pe2 As ProjecteCentre
        pe1 = getObject(id1)
        pe2 = getObject(id2)
        If pe1 Is Nothing Or pe2 Is Nothing Then Return False
        temp = pe1.ordre
        pe1.ordre = pe2.ordre
        pe2.ordre = temp
        Call save(pe1)
        Call save(pe2)
        Return True
    End Function
    Private Function getMaxOrder(idCentre As Integer) As Integer
        Dim obj As ProjecteCentre, i As Integer
        i = 0
        If Not isUpdated() Then objects = getRemoteObjects()
        For Each obj In objects
            If idCentre = obj.idCentre Then
                If obj.ordre > i Then i = obj.ordre
            End If
        Next obj
        obj = Nothing
        Return i
    End Function
    Public Function getTotalProjectes() As Integer
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Count
    End Function
    Public Sub resetIndex()
        objects = Nothing
    End Sub



    ''' <summary>
    ''' Obté els Projecte Centre de la base de dades
    ''' </summary>
    ''' <returns></returns>
    Private Function getRemoteObjects() As List(Of ProjecteCentre)
        dateUpdate = Now()
        Return dbProjecteCentre.getObjects
    End Function

    ''' <summary>
    ''' Comprova si la taula està actualtizada
    ''' </summary>
    ''' <returns>cert si està actualitzada, fals en cas contrari</returns>
    Private Function isUpdated() As Boolean
        If Not objects Is Nothing Then
            isUpdated = DBCONNECT.isUpdated(dateUpdate, DBCONNECT.getTaulaCentreProjecte)
        Else
            Return False
        End If
        If isUpdated Then dateUpdate = Now
    End Function

End Module
