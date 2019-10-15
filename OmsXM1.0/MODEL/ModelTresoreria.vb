Option Explicit On
Module ModelTresoreria
    Private objects As List(Of Tresoreria)
    Private projectesCentres As List(Of ProjecteTresoreria)
    Private Const COLUMNS As Integer = 11
    Private ids(0 To 100000) As Boolean
    Private dateUpdate As DateTime

    Public Function getDataListProjectes(c As List(Of ProjecteTresoreria)) As DataList
        Dim pt As ProjecteTresoreria
        getDataListProjectes = New DataList
        If c.Count > 0 Then
            getDataListProjectes.columns.Add(COLUMN.ID)
            getDataListProjectes.columns.Add(COLUMN.GENERICA(IDIOMA.getString("centre"), 50, HorizontalAlignment.Center))
            getDataListProjectes.columns.Add(COLUMN.GENERICA(IDIOMA.getString("projecte"), 50, HorizontalAlignment.Center))
            getDataListProjectes.columns.Add(COLUMN.NOM)
            For Each pt In c
                getDataListProjectes.rows.Add(New ListViewItem(New String() {pt.id, pt.codiCentre, pt.codiProjecte, pt.nomProjecte}))
            Next
        End If
        pt = Nothing
    End Function

    Public Function getObjects() As List(Of Tresoreria)
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects
    End Function
    Public Function getObject(id As Integer) As Tresoreria
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Find(Function(x) x.id = id)
    End Function
    Private Function getobjectsByProjecte(idProjecte As String) As List(Of Tresoreria)
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.FindAll(Function(x) x.idProjecte = idProjecte)
    End Function
    Public Function getProjectes() As List(Of ProjecteTresoreria)
        If projectesCentres Is Nothing Then projectesCentres = getRemoteProjectes()
        Return projectesCentres
    End Function
    Public Sub setData()
        If Not isUpdated() Then objects = getRemoteObjects()
    End Sub
    Public Function getCentres() As List(Of Centre)
        Dim c As Centre, pt As ProjecteTresoreria
        getCentres = New List(Of Centre)
        If projectesCentres Is Nothing Then projectesCentres = getRemoteProjectes()
        For Each pt In projectesCentres
            If Not getCentres.Exists(Function(x) x.codi = pt.codiCentre) Then
                c = ModelCentre.getObject(pt.codiCentre)
                If c IsNot Nothing Then
                    c.ordre = c.codi
                    getCentres.Add(c)
                End If
            End If
        Next pt
        pt = Nothing
        c = Nothing
    End Function
    Public Function getProjecte(idProjecte As Integer) As ProjecteTresoreria
        Dim pt As ProjecteTresoreria
        If projectesCentres Is Nothing Then projectesCentres = getRemoteProjectes()
        getProjecte = Nothing
        For Each pt In projectesCentres
            If pt.idProjecte = idProjecte Then
                getProjecte = pt
                Exit For
            End If
        Next pt
        pt = Nothing
    End Function
    Public Function getDataList(estimacions As List(Of Tresoreria)) As DataList
        Dim e As Tresoreria
        getDataList = New DataList
        If estimacions.Count > 0 Then
            getDataList.columns.Add(COLUMN.ID)
            getDataList.columns.Add(COLUMN.GENERICA(IDIOMA.getString("esIngres"), 50, HorizontalAlignment.Center))
            getDataList.columns.Add(COLUMN.GENERICA(IDIOMA.getString("projecte"), 50, HorizontalAlignment.Center))
            getDataList.columns.Add(COLUMN.GENERICA(IDIOMA.getString("concepte"), 150, HorizontalAlignment.Center))
            getDataList.columns.Add(COLUMN.GENERICA(IDIOMA.getString("tipus"), 50, HorizontalAlignment.Center))
            getDataList.columns.Add(COLUMN.GENERICA(IDIOMA.getString("concepte"), 150, HorizontalAlignment.Center))
            getDataList.columns.Add(COLUMN.GENERICA(IDIOMA.getString("dataEmisio"), 75, HorizontalAlignment.Center))
            getDataList.columns.Add(COLUMN.GENERICA(IDIOMA.getString("base"), 75, HorizontalAlignment.Center))
            getDataList.columns.Add(COLUMN.GENERICA(IDIOMA.getString("iva"), 75, HorizontalAlignment.Center))
            getDataList.columns.Add(COLUMN.GENERICA(IDIOMA.getString("total"), 75, HorizontalAlignment.Center))

            getDataList.columns.Add(COLUMN.GENERICA(IDIOMA.getString("dataVenciment"), 75, HorizontalAlignment.Center))
            For Each e In estimacions
                If e.esIngres Then
                    getDataList.rows.Add(New ListViewItem(New String() {e.id, "COB.", ModelProjecte.getCodi(e.idProjecte), e.concepte, e.dataEmisio, e.tipus, e.base, e.iva, e.total}))
                Else
                    getDataList.rows.Add(New ListViewItem(New String() {e.id, "PAG.", ModelProjecte.getCodi(e.idProjecte), e.concepte, e.dataEmisio, e.tipus, e.base, e.iva, e.total}))
                End If
            Next
        End If
        e = Nothing
    End Function

    Public Function insert(estimacions As List(Of Tresoreria), idProjecte As Integer) As Boolean
        Dim i As Integer, dades As List(Of Tresoreria), e As Tresoreria
        dades = UpdateIva(estimacions)
        If delete(idProjecte) Then
            For Each e In dades
                insert = getId()
                e.id = insert
                If insert = -1 Then Exit For
                Call dbTresoreria.insert(e)
                i = i + 1
            Next
        End If
        If i > 1 Then
            dateUpdate = Now()
            Return True
        End If
        Return False
    End Function
    Public Function update(t As Tresoreria) As Boolean
        If dbTresoreria.update(t) Then
            dateUpdate = Now()
            objects.Remove(t)
            objects.Add(t)
            Return True
        End If
        Return False
    End Function
    Public Function delete(idProjecte As Integer) As Boolean
        If dbTresoreria.remove(idProjecte) Then
            dateUpdate = Now()
            objects.RemoveAll(Function(x) x.idProjecte = idProjecte)
            Return True
        End If
        Return False
    End Function
    Public Sub resetIndex()
        objects = Nothing
        projectesCentres = Nothing
    End Sub
    Private Function getTable() As String
        Return DBCONNECT.getTaulaEstimacions
    End Function
    Private Function UpdateIva(estimacions As List(Of Tresoreria)) As List(Of Tresoreria)
        Dim e As Tresoreria, eNova As Tresoreria
        If Not isUpdated() Then objects = getRemoteObjects()
        For Each eNova In estimacions
            For Each e In objects
                If e.idProjecte = eNova.idProjecte Then
                    If StrComp(eNova.concepte, e.concepte, vbTextCompare) = 0 Then
                        If Math.Round(eNova.base, 2) = Math.Round(e.base, 2) Then
                            eNova.tipusIva = e.tipusIva
                            Exit For
                        End If
                    End If
                End If
            Next e
        Next eNova
        UpdateIva = estimacions
        e = Nothing
        eNova = Nothing
    End Function
    Private Function getRemoteObjects() As List(Of Tresoreria)
        dateUpdate = Now()
        Return dbTresoreria.getObjects
    End Function
    ' ESTIC AQUI, CAL MIRAR D'IMPLEMENTAR EL COMMIT I ROLLBACK PER LES  MULTI INSERTS, UPDATE
    ' I COMPROVAR SI EL TRIGGER QUAN S'EXCUTA, 


    ''' <summary>
    ''' Comprova si la taula està actualtizada
    ''' </summary>
    ''' <returns>cert si està actualitzada, fals en cas contrari</returns>
    Private Function isUpdated() As Boolean
        If Not objects Is Nothing Then
            isUpdated = DBCONNECT.isUpdated(dateUpdate, getTable())
        Else
            Return False
        End If
        If isUpdated Then dateUpdate = Now
    End Function
    Private Function getRemoteProjectes() As List(Of ProjecteTresoreria)
        Dim pt As ProjecteTresoreria, objects As List(Of ProjecteTresoreria)
        objects = dbTresoreria.getProjectes
        For Each pt In objects
            pt.codiCentre = ModelProjecteCentre.getCodiCentre(pt.idProjecte)
            pt.importsTresoreria = ModelTresoreria.getobjectsByProjecte(pt.idProjecte)
        Next
        dateUpdate = Now()
        Return objects
    End Function

    Private Function getId() As Long
        Dim i As Long
        getId = -1
        For i = LBound(ids) To UBound(ids)
            If Not ids(i) Then
                getId = i
                ids(i) = True
                Exit For
            End If
        Next i
    End Function
End Module
