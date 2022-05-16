Module ModelCodiComanda
    'ID,N,10,0	SERIE,N,4,0	CODI,N,10,0	IDEMP,N,4,0	NOTES,C,250
    Private objects As List(Of CodiComanda)
    Private dateUpdate As DateTime
    Public Function getObjects(Optional filtre As String = "") As List(Of CodiComanda)
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.FindAll(Function(x) x.isFilter(filtre))
    End Function
    Public Function getDataList(codis As List(Of CodiComanda)) As DataList
        Dim c As CodiComanda
        getDataList = New DataList
        codis.Sort()
        If codis.Count > 0 Then
            getDataList.columns.Add(COLUMN.ID)
            getDataList.columns.Add(COLUMN.GENERICA("empresa", 150, HorizontalAlignment.Center))
            getDataList.columns.Add(COLUMN.GENERICA("serie", 100, HorizontalAlignment.Center))
            getDataList.columns.Add(COLUMN.CODI)
            For Each c In objects
                getDataList.rows.Add(New ListViewItem(New String() {c.id, ModelEmpresa.getNom(c.idEmpresa), c.serie, c.codi}))
            Next
        End If
        c = Nothing
    End Function
    Public Function getListViewItem(c As CodiComanda) As ListViewItem
        Return New ListViewItem(New String() {c.id, c.idEmpresa, c.serie, c.codi})
    End Function
    Public Function getListViewItem(id As Integer) As ListViewItem
        Dim c As CodiComanda
        c = getObject(id)
        If c IsNot Nothing Then
            Return New ListViewItem(New String() {c.id, c.idEmpresa, c.serie, c.codi})
        End If
        Return Nothing
    End Function

    Public Function getObject(id As Integer) As CodiComanda
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Find(Function(x) x.id = id)
    End Function
    Public Function getObject(serie As String, idEmpresa As String) As CodiComanda
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Find(Function(x) x.serie = serie And x.idEmpresa = idEmpresa)
    End Function
    Public Function exist(obj As CodiComanda) As Boolean
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Exists(Function(x) x.idEmpresa = obj.idEmpresa And x.serie = obj.serie And x.codi > obj.codi)
    End Function
    Public Function save(obj As CodiComanda) As Integer
        If obj.id = -1 Then
            obj.id = dbCodiComanda.insert(obj)
        Else
            obj.id = dbCodiComanda.update(obj)
        End If
        If obj.id > -1 Then
            dateUpdate = Now()
            objects.Remove(obj)
            objects.Add(obj)
        End If
        Return obj.id
    End Function
    Public Function remove(obj As CodiComanda) As Boolean
        Dim result As Boolean
        result = dbCodiComanda.remove(obj)
        If result Then
            dateUpdate = Now()
            objects.Remove(obj)
        End If
        Return result
    End Function
    Public Sub resetIndex()
        objects = Nothing
    End Sub
    Private Function getRemoteObjects() As List(Of CodiComanda)
        dateUpdate = Now()
        Return dbCodiComanda.getObjects
    End Function
    ''' <summary>
    ''' Comprova si s'ha actualitzat la BBDD
    ''' </summary>
    ''' <returns>Cert  en cas afirmatiu, fals en cas contrari</returns>
    Private Function isUpdated() As Boolean
        If Not objects Is Nothing Then
            isUpdated = DBCONNECT.isUpdated(dateUpdate, DBCONNECT.getTaulaCodiComanda)
        Else
            Return False
        End If
        If isUpdated Then dateUpdate = Now
    End Function

End Module
