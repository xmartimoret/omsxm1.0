Option Explicit On
Module ModelLlocEntrega
    Private objects As List(Of LlocEntrega)
    Private dateUpdate As DateTime
    Public Function getObjects(Optional filtre As String = "") As List(Of LlocEntrega)
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.FindAll(Function(x) x.isFilter(filtre, x.poblacio))
    End Function
    Public Function getObjects(estat As Boolean) As List(Of Object)
        Dim ll As LlocEntrega
        If Not isUpdated() Then objects = getRemoteObjects()
        getObjects = New List(Of Object)
        For Each ll In objects
            If ll.actiu Or Not estat Then getObjects.Add(ll)
        Next
    End Function
    Public Function getObjectsActius(Optional filtre As String = "") As List(Of LlocEntrega)
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.FindAll(Function(x) x.isFilter(filtre, x.poblacio) And x.actiu = True)
    End Function
    Public Function getDataList(LlocEntregas As List(Of LlocEntrega)) As DataList
        Dim c As LlocEntrega
        getDataList = New DataList
        LlocEntregas.Sort()
        If LlocEntregas.Count > 0 Then
            getDataList.columns.Add(COLUMN.ID)
            getDataList.columns.Add(COLUMN.NOM)
            getDataList.columns.Add(COLUMN.GENERICA("poblacio", 100, HorizontalAlignment.Center))
            getDataList.columns.Add(COLUMN.GENERICA("provincia", 100, HorizontalAlignment.Center))
            getDataList.columns.Add(COLUMN.ESTAT)
            For Each c In LlocEntregas
                If c.provincia Is Nothing Then c.provincia = New Provincia
                If c.actiu Then
                    getDataList.rows.Add(New ListViewItem(New String() {c.id, c.nom, c.poblacio, c.provincia.nom, IDIOMA.getString("actiu")}))
                Else
                    getDataList.rows.Add(New ListViewItem(New String() {c.id, c.nom, c.poblacio, c.provincia.nom, IDIOMA.getString("noActiu")}))
                End If
            Next
        End If
        c = Nothing
    End Function
    Public Function getListViewItem(c As LlocEntrega) As ListViewItem
        If c.provincia Is Nothing Then c.provincia = New Provincia
        If c.actiu Then
            Return New ListViewItem(New String() {c.id, c.nom, c.poblacio, c.provincia.nom, IDIOMA.getString("actiu")})
        Else

            Return New ListViewItem(New String() {c.id, c.nom, c.poblacio, c.provincia.nom, IDIOMA.getString("noActiu")})
        End If
    End Function
    Public Function getListViewItem(id As Integer) As ListViewItem
        Dim c As LlocEntrega
        c = getObject(id)
        If c IsNot Nothing Then
            If c.provincia Is Nothing Then c.provincia = New Provincia
            If c.actiu Then
                Return New ListViewItem(New String() {c.id, c.nom, c.poblacio, c.provincia.nom, IDIOMA.getString("actiu")})
            Else

                Return New ListViewItem(New String() {c.id, c.nom, c.poblacio, c.provincia.nom, IDIOMA.getString("noActiu")})
            End If
        End If
        Return Nothing
    End Function
    Public Function getListObjects(preferits As List(Of projecteEntrega)) As Object()
        Dim obj As LlocEntrega, i As Integer = 0, objectes() As Object, temp As List(Of LlocEntrega)
        Dim pc As projecteEntrega, ll As LlocEntrega
        temp = getObjects("")
        ReDim objectes(temp.Count - 1)
        For Each pc In preferits
            ll = getObject(pc.idEntrega)
            objectes(i) = ll
            i = i + 1
        Next
        objectes(i) = New LlocEntrega
        i = i + 1
        For Each obj In temp
            If Not preferits.Exists(Function(x) x.idEntrega = obj.id) Then
                objectes(i) = obj
                i = i + 1
            End If
        Next
            getListObjects = objectes
        objectes = Nothing
        obj = Nothing
    End Function
    Public Function getObject(id As Integer) As LlocEntrega
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Find(Function(x) x.id = id)
    End Function

    Public Function getObjectByName(p As String) As LlocEntrega
        If Not isUpdated() Then objects = getRemoteObjects()
        For Each ll As LlocEntrega In objects
            If Strings.InStr(1, ll.nom, p, CompareMethod.Text) > 0 Then
                Return ll
            End If
        Next
        For Each ll In objects
            If Strings.InStr(1, p, ll.nom, CompareMethod.Text) > 0 Then
                Return ll
            End If
        Next
        Return Nothing
    End Function
    Public Function exist(obj As LlocEntrega) As Boolean
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Exists(Function(x) x.id <> obj.id And StrComp(x.nom, obj.nom, CompareMethod.Text) = 0)
    End Function

    Public Function save(obj As LlocEntrega) As Integer
        If obj.id = -1 Then
            obj.id = dbLlocEntrega.insert(obj)

        Else
            obj.id = dbLlocEntrega.update(obj)
        End If

        If obj.id > -1 Then
            dateUpdate = Now()
            objects.Remove(obj)
            objects.Add(obj)
            If Not GOOGLE_SHEETS.save(obj) Then Call ERRORS.ERR_UPDATE_GOOGLE_SHEETS()
        End If
        Return obj.id
    End Function
    Public Function remove(obj As LlocEntrega) As Boolean
        Dim result As Boolean
        result = dbLlocEntrega.remove(obj)
        If result Then
            dateUpdate = Now()
            objects.Remove(obj)
            If Not GOOGLE_SHEETS.remove(obj) Then Call ERRORS.ERR_UPDATE_GOOGLE_SHEETS()
        End If
        Return result
    End Function

    Public Sub resetIndex()
        objects = Nothing
    End Sub

    Private Function getRemoteObjects() As List(Of LlocEntrega)
        dateUpdate = Now()
        Return dbLlocEntrega.getObjects
    End Function
    ''' <summary>
    ''' Comprova si s'ha actualitzat la BBDD
    ''' </summary>
    ''' <returns>Cert  en cas afirmatiu, fals en cas contrari</returns>
    Private Function isUpdated() As Boolean
        If Not objects Is Nothing Then
            isUpdated = DBCONNECT.isUpdated(dateUpdate, DBCONNECT.getTaulaLlocEntrega)
        Else
            Return False
        End If
        If isUpdated Then dateUpdate = Now
    End Function
End Module
