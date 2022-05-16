Module ModelDocumentacio
    Private objects(2100) As List(Of doc)
    Private dateUpdate As DateTime
    Private anyActual As Integer
    Public Function getObjects(anyo As Integer) As List(Of doc)
        Dim d As doc, altres As String = ""
        If Not isUpdated(anyo) Then objects(anyo) = getRemoteObjects(anyo)
        getObjects = objects(anyo)
    End Function
    Public Function getObjectssolicitut(id As Integer, anyo As Integer) As List(Of doc)
        Dim d As doc, altres As String = ""
        If Not isUpdated(anyo) Then objects(anyo) = getRemoteObjects(anyo)
        getObjectssolicitut = objects(anyo).FindAll(Function(x) x.idSolicitut = id)
    End Function
    Public Function getObjectsComandaEdicio(id As Integer, anyo As Integer) As List(Of doc)
        Dim d As doc, altres As String = ""
        If Not isUpdated(anyo) Then objects(anyo) = getRemoteObjects(anyo)
        getObjectsComandaEdicio = objects(anyo).FindAll(Function(x) x.idComandaEnEdicio = id)
    End Function
    Public Function getObjectsComanda(id As Integer, anyo As Integer) As List(Of doc)
        Dim d As doc, altres As String = ""
        If Not isUpdated(anyo) Then objects(anyo) = getRemoteObjects(anyo)
        getObjectsComanda = objects(anyo).FindAll(Function(x) x.idComanda = id)
    End Function
    Public Function getObject(id As Integer, anyo As Integer) As doc
        Dim d As doc, altres As String = ""
        If Not isUpdated(anyo) Then objects(anyo) = getRemoteObjects(anyo)
        getObject = objects(anyo).Find(Function(x) x.id = id)
    End Function

    Public Function getDataList(docs As List(Of doc)) As DataList
        Dim a As doc
        getDataList = New DataList
        docs.Sort()
        If docs.Count > 0 Then
            getDataList.columns.Add(COLUMN.GENERICA("ID", 0, HorizontalAlignment.Center))
            getDataList.columns.Add(COLUMN.GENERICA("codi", 100, HorizontalAlignment.Center))
            getDataList.columns.Add(COLUMN.GENERICA("nom", 100, HorizontalAlignment.Left))
            For Each a In docs
                getDataList.rows.Add(New ListViewItem(New String() {a.id, a.codi, a.nom}))
            Next
        End If
        a = Nothing
    End Function
    Public Function save(obj As doc) As Integer
        If Not isUpdated(obj.anyo) Then objects(obj.anyo) = getRemoteObjects(obj.anyo)
        If obj.id = -1 Then
            obj.id = dbDocumentacio.insert(obj)
        Else
            obj.id = dbDocumentacio.update(obj)
        End If
        If obj.id > -1 Then
            dateUpdate = Now()
            objects(obj.anyo).Remove(obj)
            objects(obj.anyo).Add(obj)
        End If
        Return obj.id
    End Function
    Public Function remove(obj As doc) As Boolean
        Dim result As Boolean
        result = dbDocumentacio.remove(obj)
        If result Then
            dateUpdate = Now()
            objects(obj.anyo).Remove(obj)
            If CONFIG.setSeparator(CONFIG.getDirectoriServidorOfertes) & obj.nom Then
                Kill(CONFIG.setSeparator(CONFIG.getDirectoriServidorOfertes) & obj.nom)
            End If
        End If
        Return result
    End Function

    Public Sub resetIndex()
        Dim i As Integer
        For i = 2000 To UBound(objects)
            objects(i) = Nothing
        Next
    End Sub

    Private Function getRemoteObjects(anyo As Integer) As List(Of doc)
        dateUpdate = Now()
        Return dbDocumentacio.getObjects(anyo)
    End Function
    ''' <summary>
    ''' Comprova si s'ha actualitzat la BBDD
    ''' </summary>
    ''' <returns>Cert  en cas afirmatiu, fals en cas contrari</returns>
    Private Function isUpdated(anyo As Integer) As Boolean
        Try

            If Not objects(anyo) Is Nothing Then
                If anyActual <> anyo Then
                    anyActual = anyo
                    Return False
                Else
                    isUpdated = DBCONNECT.isUpdated(dateUpdate, DBCONNECT.getTaulaComanda)
                End If
            Else
                anyActual = anyo
                Return False
            End If
            If isUpdated Then dateUpdate = Now
        Catch ex As System.NullReferenceException
            anyActual = anyo
            Return False
        End Try
    End Function
End Module
