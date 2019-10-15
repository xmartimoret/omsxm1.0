Option Explicit On
Module ModelCentre
    Private objects As List(Of Centre)
    Private Const N_COLUMNS As Integer = 4 ' AFEGIR, NUMERO DE COLUMNES DE LA LLISTA
    Private Const ID As String = "ID"
    Private Const ID_SECCIO As String = "IDSECCIO"
    Private Const CODI As String = "CODI"
    Private Const NOM As String = "NOM"
    Private Const NOTES As String = "NOTES"
    Private Const ORDRE As String = "ORDRE"
    Private Const ACTIU As String = "ACTIU"
    Private dateUpdate As DateTime
    Public Function getObjectsEmpresa(idEmpresa As Integer, Optional filtre As String = "") As List(Of Centre)
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.FindAll(Function(x) x.idEmpresa = idEmpresa And x.isFilter(filtre, x.codiSeccio))
    End Function
    Public Function getObjects(idSeccio As Integer, filtre As String) As List(Of Centre)
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.FindAll(Function(x) x.idSeccio = idSeccio And x.isFilter(filtre))
    End Function
    Public Function getobjectsNoAdded(centresAdded As List(Of Centre), filtre As String) As List(Of Centre)
        Dim c As Centre
        If Not isUpdated() Then objects = getRemoteObjects()
        getobjectsNoAdded = objects.FindAll(Function(x) x.isFilter(filtre))
        For Each c In centresAdded
            getobjectsNoAdded.Remove(c)
        Next
        c = Nothing
    End Function
    Public Function getDataList(centres As List(Of Centre)) As DataList
        Dim c As Centre
        centres.Sort()
        getDataList = New DataList
        If centres.Count > 0 Then
            getDataList.columns.Add(COLUMN.ID)
            getDataList.columns.Add(COLUMN.CODI)
            getDataList.columns.Add(COLUMN.NOM)
            getDataList.columns.Add(COLUMN.ESTAT)
            For Each c In centres
                If c.actiu Then
                    getDataList.rows.Add(New ListViewItem(New String() {c.id, c.codi, c.nom, IDIOMA.getString("actiu")}))
                Else
                    getDataList.rows.Add(New ListViewItem(New String() {c.id, c.codi, c.nom, IDIOMA.getString("noActiu")}))
                End If
            Next
        End If
        c = Nothing
    End Function
    Public Function getDataListSeccio(centres As List(Of Centre)) As DataList
        Dim c As Centre
        getDataListSeccio = New DataList()
        If centres.Count > 0 Then
            getDataListSeccio.columns.Add(COLUMN.ID)
            getDataListSeccio.columns.Add(COLUMN.CODI)
            getDataListSeccio.columns.Add(COLUMN.SECCIO)
            getDataListSeccio.columns.Add(COLUMN.NOM)
            For Each c In centres
                getDataListSeccio.rows.Add(New ListViewItem(New String() {c.id, c.codi, c.codiSeccio, c.nom}))
            Next
        End If
        c = Nothing
    End Function

    Public Function getDataListEmpresa(centres As List(Of Centre)) As DataList
        Dim c As Centre
        getDataListEmpresa = New DataList()
        If centres.Count > 0 Then
            getDataListEmpresa.columns.Add(COLUMN.ID)
            getDataListEmpresa.columns.Add(COLUMN.EMPRESA)
            getDataListEmpresa.columns.Add(COLUMN.CODI)
            getDataListEmpresa.columns.Add(COLUMN.NOM)
            For Each c In centres
                getDataListEmpresa.rows.Add(New ListViewItem(New String() {c.id, c.codiEmpresa, c.codi, c.nom}))
            Next
        End If
        c = Nothing

    End Function

    Public Function getDataListVoss(centres As List(Of Centre), seccions As List(Of Seccio), Optional filtre As String = "") As DataList
        Dim dades(,) As String, obj As Centre, l As New List(Of ListViewItem), i As Integer, s As Seccio, seccioTrobada As Boolean
        getDataListVoss = New DataList
        If centres.Count > 0 Then
            ReDim dades(centres.Count, 2)
            i = 1
            For Each obj In centres
                seccioTrobada = False
                For Each s In seccions
                    If s.id = obj.idSeccio Then
                        If s.notes <> "" Then
                            seccioTrobada = True
                            Exit For
                        End If
                    End If
                Next s
                If Not seccioTrobada Then
                    If Len(filtre) = 0 Or InStr(1, obj.codiEmpresa & " - " & obj.codiSeccio & " - " & obj.codi, filtre, vbTextCompare) > 0 Then
                        dades(i, 0) = obj.id
                        dades(i, 1) = obj.codiEmpresa & " - " & obj.codiSeccio & " - " & obj.codi
                        dades(i, 2) = obj.notes
                        i = i + 1
                    End If
                End If
            Next obj
            If i > 1 Then
                getDataListVoss.columns.Add(COLUMN.ID)
                getDataListVoss.columns.Add(COLUMN.CENTRE)
                getDataListVoss.columns.Add(COLUMN.NOTES)
                For j As Integer = 0 To i - 1
                    getDataListVoss.rows.Add(New ListViewItem(New String() {dades(j, 0), dades(j, 1), dades(j, 2)}))
                Next j
            End If
        End If
        obj = Nothing
End Function
    Private Function getListColumnsHeaderVOSS() As ColumnHeader()
        ReDim getListColumnsHeaderVOSS(2)

    End Function
    Public Function getCodiEmpresa(idCentre As Integer) As String
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Find(Function(x) x.id = idCentre).codiEmpresa
    End Function
    Public Function getIdEmpresa(idCentre As Integer) As Integer
        Dim c As Centre
        If Not isUpdated() Then objects = getRemoteObjects()
        c = objects.Find(Function(x) x.id = idCentre)
        Return c.idEmpresa
    End Function
    Public Function getCodiSeccio(idCentre As Integer) As String
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Find(Function(x) x.id = idCentre).codiSeccio
    End Function
    Public Sub setCodiEmpresa()
        ' todo cal implementar modelseccio i modelempresa
        Dim obj As Centre
        If Not isUpdated() Then objects = getRemoteObjects()
        For Each obj In objects
            obj.codiEmpresa = ModelSeccio.getCodiEmpresa(obj.idSeccio)
            obj.codiSeccio = ModelSeccio.getCodi(obj.idSeccio)
            obj.participacio = ModelEmpresa.getParticipacio(CStr(obj.codiEmpresa))
        Next obj
        obj = Nothing
    End Sub
    Public Function getObject(id As Integer) As Object
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Find(Function(x) x.id = id)
    End Function
    Public Function getObject(codi As String) As Centre
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Find(Function(x) x.codi = codi)
    End Function
    Public Function getIDSeccio(idCentre As Integer) As Integer
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Find(Function(x) x.id = idCentre).idSeccio
    End Function
    Public Function save(obj As Centre) As Integer
        If obj.id = -1 Then
            obj.ordre = getMaxOrder(obj.idSeccio) + 1
            obj.id = dbCentre.insert(obj)
        Else
            obj.id = dbCentre.update(obj)
        End If
        If obj.id > 0 Then
            dateUpdate = Now()
            objects.Remove(obj)
            objects.Add(obj)
        End If
        Return obj.id
    End Function
    Public Function saveClearNotes(idSeccio As Integer)
        Dim i As Integer, c As Centre
        i = dbCentre.saveClearNotes(idSeccio)
        If i > 1 Then
            dateUpdate = Now()
            For Each c In objects.FindAll(Function(x) x.idSeccio = idSeccio)
                c.notes = ""
            Next
            Return True
        End If
        Return False
    End Function
    Public Function remove(obj As Centre) As Boolean
        If dbCentre.remove(obj) Then
            dateUpdate = Now()
            objects.Remove(obj)
            Return True
        Else
            Return False
        End If

    End Function
    Public Function removeSeccio(idSeccio As Integer) As Boolean
        Dim i As Integer
        i = dbCentre.removeSeccio(idSeccio)
        If i > 1 Then
            dateUpdate = Now()
            objects.RemoveAll(Function(x) x.idSeccio = idSeccio)
            Return True
        End If
        Return False
    End Function
    Public Function exist(obj As Centre) As Boolean
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Exists(Function(x) x.id <> obj.id And (x.idSeccio = obj.idSeccio And x.codi.Equals(obj.codi)))
    End Function
    Public Function existsName(obj As Centre) As Boolean
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Exists(Function(x) x.nom.Equals(obj.nom))
    End Function
    Private Function getMaxOrder(idSeccio As Integer) As Integer
        Dim obj As Centre, i As Integer
        i = 0
        If Not isUpdated() Then objects = getRemoteObjects()
        For Each obj In objects
            If idSeccio = obj.idSeccio Then
                If IsNumeric(obj.ordre) Then
                    If CInt(obj.ordre) > i Then i = obj.ordre
                Else
                    If obj.ordre > i Then i = obj.ordre
                End If
            End If
        Next obj
        obj = Nothing
        Return i
    End Function

    Public Function changeOrder(id1 As Integer, id2 As Integer)
        Dim temp As String, obj1 As Centre, obj2 As Centre
        If id1 <= 0 Or id2 <= 0 Then Return False
        obj1 = getObject(id1)
        obj2 = getObject(id2)
        If obj1 Is Nothing Or obj2 Is Nothing Then Return False
        temp = obj1.ordre
        obj1.ordre = obj2.ordre
        obj2.ordre = temp
        Call save(obj1)
        Call save(obj2)
        Return True
    End Function
    Public Sub resetIndex()
        objects = Nothing
    End Sub
    Public Sub actualitzar(estat As Boolean)
        Dim c As Centre
        If Not isUpdated() Then
            objects = getRemoteObjects()
        Else
            For Each c In objects
                c.actualitzat = estat
            Next
        End If
    End Sub

    Private Function getRemoteObjects() As List(Of Centre)
        dateUpdate = Now
        Return dbCentre.getObjects
    End Function
    ''' <summary>
    ''' Comprova si s'ha actualitzat la BBDD
    ''' </summary>
    ''' <returns>Cert  en cas afirmatiu, fals en cas contrari</returns>
    Private Function isUpdated() As Boolean
        If Not objects Is Nothing Then
            isUpdated = DBCONNECT.isUpdated(dateUpdate, DBCONNECT.getTaulaCentres)
        Else
            Return False
        End If
        If isUpdated Then dateUpdate = Now
    End Function


End Module
