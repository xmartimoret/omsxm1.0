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
    Public Function getObject(id As Integer) As Proveidor
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Find(Function(x) x.id = id)
    End Function
    Public Function getNom(id As Integer) As String
        Dim p As Proveidor
        If Not isUpdated() Then objects = getRemoteObjects()
        p = objects.FindLast(Function(x) x.id = id)
        If p IsNot Nothing Then Return p.nom
        Return ""
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
        If obj.id = -1 Then
            obj.id = dbProveidor.insert(obj)
        Else
            obj.id = dbProveidor.update(obj)
        End If
        If obj.id > -1 Then
            dateUpdate = Now()
            objects.Remove(obj)
            objects.Add(obj)
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
        End If
        Return result
    End Function

    Public Sub resetIndex()
        objects = Nothing
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
