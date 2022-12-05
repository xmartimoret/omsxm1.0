Option Explicit On
Module ModelProveidor
    Private objects As List(Of Proveidor)
    Private dateUpdate As DateTime
    Public Function getObjects(Optional filtre As String = "") As List(Of Proveidor)
        Dim P As Proveidor
        If Not isUpdated() Then objects = getRemoteObjects()
        getObjects = New List(Of Proveidor)
        For Each P In objects
            If P.provincia Is Nothing Then
                If P.isFilter(filtre, P.poblacio) Then
                    getObjects.Add(P)

                End If
            Else
                If P.isFilter(filtre, P.poblacio, P.provincia.nom) Then
                    getObjects.Add(P)
                End If

            End If
        Next
    End Function
    Public Function getObjects(estat As Boolean) As List(Of Object)
        Dim P As Proveidor
        If Not isUpdated() Then objects = getRemoteObjects()
        getObjects = New List(Of Object)
        For Each P In objects
            If P.actiu Or Not estat Then getObjects.Add(P)
        Next
    End Function
    Public Function getObjectsActius(Optional filtre As String = "") As List(Of Proveidor)
        Dim P As Proveidor
        If Not isUpdated() Then objects = getRemoteObjects()
        getObjectsActius = New List(Of Proveidor)
        For Each P In objects
            If P.provincia Is Nothing Then
                If P.actiu Then
                    If P.isFilter(filtre, P.poblacio) Then
                        getObjectsActius.Add(P)

                    End If
                End If
            Else
                If P.actiu Then
                    If P.isFilter(filtre, P.poblacio, P.provincia.nom) Then
                        getObjectsActius.Add(P)
                    End If
                End If
            End If
        Next
    End Function
    Public Function getDataList(provincies As List(Of Proveidor)) As DataList
        Dim c As Proveidor
        getDataList = New DataList
        provincies.Sort()
        If provincies.Count > 0 Then
            getDataList.columns.Add(COLUMN.ID)
            getDataList.columns.Add(COLUMN.GENERICA("cif", 100, HorizontalAlignment.Center))
            getDataList.columns.Add(COLUMN.GENERICA("codiComptable", 100, HorizontalAlignment.Center))
            getDataList.columns.Add(COLUMN.NOM)
            getDataList.columns.Add(COLUMN.GENERICA("poblacio", 150, HorizontalAlignment.Center))
            getDataList.columns.Add(COLUMN.GENERICA("provincia", 150, HorizontalAlignment.Center))
            getDataList.columns.Add(COLUMN.GENERICA("email", 300, HorizontalAlignment.Center))
            getDataList.columns.Add(COLUMN.ESTAT)
            For Each c In provincies
                If c.provincia Is Nothing Then c.provincia = New Provincia
                If c.actiu Then
                    getDataList.rows.Add(New ListViewItem(New String() {c.id, c.codi, c.codiComptable, c.nom, c.poblacio, c.provincia.nom, c.email, IDIOMA.getString("actiu")}))
                Else
                    getDataList.rows.Add(New ListViewItem(New String() {c.id, c.codi, c.codiComptable, c.nom, c.poblacio, c.provincia.nom, c.email, IDIOMA.getString("bloquejat")}))
                End If
            Next
        End If
        c = Nothing
    End Function
    Public Function getListObjects() As Object()
        Dim obj As Proveidor, i As Integer = 0, objectes() As Object, temp As List(Of Proveidor)
        temp = getObjects("")
        ReDim objectes(temp.Count - 1)
        For Each obj In temp
            objectes(i) = obj
            i = i + 1
        Next
        getListObjects = objectes
        objectes = Nothing
        obj = Nothing
    End Function
    Public Function getListObjects(p As List(Of Proveidor)) As Object()
        Dim obj As Proveidor, i As Integer = 0, objectes() As Object, temp As List(Of Proveidor)
        temp = p
        ReDim objectes(temp.Count - 1)
        For Each obj In temp
            objectes(i) = obj
            i = i + 1
        Next
        getListObjects = objectes
        objectes = Nothing
        obj = Nothing
    End Function
    Public Function getListViewItem(c As Proveidor) As ListViewItem
        If c.actiu Then
            Return New ListViewItem(New String() {c.id, c.codi, c.codiComptable, c.nom, c.poblacio, c.provincia.nom, c.email, IDIOMA.getString("actiu")})
        Else
            Return New ListViewItem(New String() {c.id, c.codi, c.codiComptable, c.nom, c.poblacio, c.provincia.nom, c.email, IDIOMA.getString("noActiu")})
        End If
    End Function
    Public Function getListViewItem(id As Integer) As ListViewItem
        Dim a As Proveidor
        a = getObject(id)
        If a IsNot Nothing Then
            Return getListViewItem(a)
        End If
        Return Nothing
    End Function
    Public Function getObject(id As Integer) As Proveidor
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Find(Function(x) x.id = id)
    End Function
    Public Function getObject(p As String) As Proveidor
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Find(Function(x) x.codi = p)
    End Function
    Public Function getNom(id As Integer) As String
        Dim p As Proveidor
        If Not isUpdated() Then objects = getRemoteObjects()
        p = objects.FindLast(Function(x) x.id = id)
        If p IsNot Nothing Then Return p.nom
        Return ""
    End Function
    Public Function getObjectByStrings(id As Integer, nom As String) As Proveidor
        Dim p As Proveidor
        If Not isUpdated() Then objects = getRemoteObjects()
        p = objects.Find(Function(x) x.id = id)
        If IsNothing(p) Then p = objects.Find(Function(x) InStr(1, nom, x.nom, CompareMethod.Text) > 0)
        If IsNothing(p) Then p = objects.Find(Function(x) InStr(1, x.nom, nom, CompareMethod.Text) > 0)
        Return p
    End Function
    Public Function exist(obj As Proveidor) As Boolean
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Exists(Function(x) x.id <> obj.id And x.nom = obj.nom)
    End Function
    Public Function existCodi(obj As Proveidor) As Integer
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Exists(Function(x) x.id <> obj.id And x.codi = obj.codi)
    End Function
    Public Function existCodi(id As Integer, codi As String) As Boolean
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Exists(Function(x) x.id <> id And x.codi = codi)
    End Function
    Public Function save(obj As Proveidor) As Integer
        ' Dim temp As IdAccio
        If obj.id = -1 Then
            obj.id = dbProveidor.insert(obj)
            '     temp = IdAccio.INSERTAR
        Else
            obj.id = dbProveidor.update(obj)
            '    temp = IdAccio.ACTUALITZAR
        End If
        If obj.id > -1 Then
            dateUpdate = Now()
            objects.Remove(obj)
            objects.Add(obj)
            Call GOOGLE_SHEETS.save(obj)
        End If
        Return obj.id
    End Function
    Public Function remove(obj As Proveidor) As Boolean
        Dim result As Boolean
        result = dbProveidor.remove(obj)
        If result Then
            Call ModelProveidorContacte.removePare(obj.id)
            Call ModelProveidorAnotacio.removePare(obj.id)

            dateUpdate = Now()
            objects.Remove(obj)
            If Not GOOGLE_SHEETS.remove(obj) Then Call ERRORS.ERR_UPDATE_GOOGLE_SHEETS()
        End If
        Return result
    End Function

    Public Sub resetIndex()
        objects = Nothing
    End Sub
    Public Sub setdata()
        If Not isUpdated() Then objects = getRemoteObjects()
    End Sub

    Private Function getRemoteObjects() As List(Of Proveidor)
        dateUpdate = Now()
        Return dbProveidor.getObjects
    End Function
    ''' <summary>
    ''' Comprova si s'ha actualitzat la BBDD
    ''' </summary>
    ''' <returns>Cert  en cas afirmatiu, fals en cas contrari</returns>
    Private Function isUpdated() As Boolean
        If Not objects Is Nothing Then
            isUpdated = DBCONNECT.isUpdated(dateUpdate, DBCONNECT.getTaulaProveidor)
        Else
            Return False
        End If
        If isUpdated Then dateUpdate = Now
    End Function
End Module
