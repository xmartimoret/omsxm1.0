Option Explicit On
Module ModelContacte
    Private objects As List(Of Contacte)
    Private dateUpdate As DateTime
    Public Function getObjects(Optional filtre As String = "") As List(Of Contacte)
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.FindAll(Function(x) x.isFilter(filtre, x.poblacio))
    End Function
    Public Function getDataList(contactes As List(Of Contacte)) As DataList
        Dim c As Contacte
        getDataList = New DataList
        contactes.Sort()
        If contactes.Count > 0 Then
            getDataList.columns.Add(COLUMN.ID)
            getDataList.columns.Add(COLUMN.NOM)
            getDataList.columns.Add(COLUMN.GENERICA("cognom", 100, HorizontalAlignment.Center))
            getDataList.columns.Add(COLUMN.GENERICA("cognom", 100, HorizontalAlignment.Center))
            getDataList.columns.Add(COLUMN.GENERICA("poblacio", 100, HorizontalAlignment.Center))
            getDataList.columns.Add(COLUMN.GENERICA("provincia", 100, HorizontalAlignment.Center))
            getDataList.columns.Add(COLUMN.GENERICA("telefon", 100, HorizontalAlignment.Center))
            getDataList.columns.Add(COLUMN.GENERICA("email", 150, HorizontalAlignment.Center))
            getDataList.columns.Add(COLUMN.ESTAT)
            For Each c In contactes
                If c.provincia Is Nothing Then c.provincia = New Provincia
                If c.estat Then
                    getDataList.rows.Add(New ListViewItem(New String() {c.id, c.nom, c.cognom1, c.cognom2, c.poblacio, c.provincia.nom, c.telefon, c.email, IDIOMA.getString("actiu")}))
                Else
                    getDataList.rows.Add(New ListViewItem(New String() {c.id, c.nom, c.cognom1, c.cognom2, c.poblacio, c.provincia.nom, c.telefon, c.email, IDIOMA.getString("noActiu")}))
                End If
            Next
        End If
        c = Nothing
    End Function
    Public Function getListObjects(preferits As List(Of ProjecteContacte)) As Object()
        Dim obj As Contacte, i As Integer = 0, objectes() As Object, temp As List(Of Contacte)
        Dim pc As ProjecteContacte, ll As Contacte
        temp = getObjects()
        ReDim objectes(temp.Count - 1)
        For Each pc In preferits
            ll = getObject(pc.idContacte)
            objectes(i) = ll
            i = i + 1
        Next
        For Each obj In temp
            If Not preferits.Exists(Function(x) x.idContacte = obj.id) Then
                objectes(i) = obj
                i = i + 1
            End If
        Next
        getListObjects = objectes
        objectes = Nothing
        obj = Nothing
    End Function
    Public Function getObject(id As Integer) As Contacte
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Find(Function(x) x.id = id)
    End Function
    Public Function getObject(p As String) As Contacte
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Find(Function(x) InStr(1, p, x.telefon, CompareMethod.Text) > 1)
    End Function
    Public Function getObjectByName(p As String) As Contacte
        Dim c As Contacte
        If Not isUpdated() Then objects = getRemoteObjects()
        For Each c In objects
            If InStr(c.nom, p, CompareMethod.Text) > 0 Then
                Return c
            End If
        Next
        For Each c In objects
            If InStr(p, c.nom, CompareMethod.Text) > 0 Then
                Return c
            End If
        Next

    End Function
    Public Function exist(obj As Contacte) As Boolean
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Exists(Function(x) x.id <> obj.id And StrComp(x.nom, obj.nom, CompareMethod.Text) = 0 And StrComp(x.cognom1, obj.cognom1, CompareMethod.Text) = 0 And StrComp(x.cognom2, obj.cognom2, CompareMethod.Text) = 0)
    End Function

    Public Function save(obj As Contacte) As Integer
        If obj.id = -1 Then
            obj.id = dbContacte.insert(obj)
        Else
            obj.id = dbContacte.update(obj)
        End If
        If obj.id > -1 Then
            dateUpdate = Now()
            objects.Remove(obj)
            objects.Add(obj)
        End If
        Return obj.id
    End Function
    Public Function remove(obj As Contacte) As Boolean
        Dim result As Boolean
        result = dbContacte.remove(obj)
        If result Then
            dateUpdate = Now()
            objects.Remove(obj)
        End If
        Return result
    End Function

    Public Sub resetIndex()
        objects = Nothing
    End Sub

    Private Function getRemoteObjects() As List(Of Contacte)
        dateUpdate = Now()
        Return dbContacte.getObjects
    End Function
    ''' <summary>
    ''' Comprova si s'ha actualitzat la BBDD
    ''' </summary>
    ''' <returns>Cert  en cas afirmatiu, fals en cas contrari</returns>
    Private Function isUpdated() As Boolean
        If Not objects Is Nothing Then
            isUpdated = DBCONNECT.isUpdated(dateUpdate, DBCONNECT.getTaulaContacte)
        Else
            Return False
        End If
        If isUpdated Then dateUpdate = Now
    End Function
End Module
