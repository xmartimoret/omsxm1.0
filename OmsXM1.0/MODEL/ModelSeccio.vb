Option Explicit On
Module ModelSeccio
    Private objects As List(Of Seccio)
    Private Const N_COLUMNS As Integer = 4
    Private dateUpdate As DateTime
    Private Const ID As String = "ID"
    Private Const ID_EMPRESA As String = "IDEMPRESA"
    Private Const CODI As String = "CODI"
    Private Const NOM As String = "NOM"
    Private Const NOTES As String = "NOTES"
    Private Const F_SALDO As String = "FSALDO"
    Private Const F_INFORME As String = "FINFORME"
    Private Const ACTIU As String = "ACTIU"
    Private Const ORDRE As String = "ORDRE"
    Public Function getObjects(Optional idEmpresa As Integer = 0) As List(Of Seccio)
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.FindAll(Function(x) idEmpresa = 0 Or x.idEmpresa = idEmpresa)
    End Function
    Public Function getObjects(idEmpresa As Integer, filtre As String) As List(Of Seccio)
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.FindAll(Function(x) x.idEmpresa = idEmpresa And x.isFilter(filtre))
    End Function
    Public Function getCodiEmpresa(idSeccio As Integer) As String
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Find(Function(x) x.id = idSeccio).codiEmpresa
    End Function
    Public Function getCodi(idSeccio As Integer) As String
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Find(Function(x) x.id = idSeccio).codi
    End Function
    Public Function getDataList(seccions As List(Of Seccio)) As DataList
        Dim s As Seccio
        seccions.Sort()
        getDataList = New DataList
        If seccions.Count > 0 Then
            getDataList.columns.Add(COLUMN.ID)
            getDataList.columns.Add(COLUMN.CODI)
            getDataList.columns.Add(COLUMN.NOM)
            getDataList.columns.Add(COLUMN.ESTAT)
            For Each s In seccions
                If s.actiu Then
                    getDataList.rows.Add(New ListViewItem(New String() {s.id, s.codi, s.nom, IDIOMA.getString("activa")}))
                Else
                    getDataList.rows.Add(New ListViewItem(New String() {s.id, s.codi, s.nom, IDIOMA.getString("noActiva")}))
                End If
            Next
        End If
        s = Nothing
    End Function
    Public Function getListObjects(seccions As List(Of Seccio)) As Object()
        Dim obj As Seccio, i As Integer = 0, objectes() As Object
        ReDim objectes(seccions.Count - 1)
        For Each obj In seccions
            objectes(i) = obj
            i = i + 1
        Next
        getListObjects = objectes
        objectes = Nothing
        obj = Nothing
    End Function
    Public Function getDataListGB(seccions As List(Of Seccio)) As DataList
        Dim s As Seccio
        getDataListGB = New DataList
        If seccions.Count > 0 Then
            getDataListGB.columns.Add(COLUMN.ID)

            getDataListGB.columns.Add(COLUMN.CODI)
            getDataListGB.columns.Add(COLUMN.NOM)
            getDataListGB.columns.Add(COLUMN.EMPRESA)
            For Each s In seccions
                getDataListGB.rows.Add(New ListViewItem(New String() {s.id, s.codi, s.nom, ModelEmpresa.getObject(s.idEmpresa).codi & "-" & s.nom}))
            Next
        End If
        s = Nothing
    End Function
    Public Function getDataListVOSS(seccions As List(Of Seccio), Optional filtre As String = "") As DataList
        Dim s As Seccio
        getDataListVOSS = New DataList
        If seccions.Count > 0 Then
            getDataListVOSS.columns.Add(COLUMN.ID)
            getDataListVOSS.columns.Add(COLUMN.CODI)
            getDataListVOSS.columns.Add(COLUMN.NOM)
            For Each s In seccions
                If Len(filtre) = 0 Or InStr(1, s.codiEmpresa & " - " & s.codi, filtre, vbTextCompare) > 0 Then
                    getDataListVOSS.rows.Add(New ListViewItem(New String() {s.id, s.codiEmpresa & " - " & s.codi, s.notes}))
                End If
            Next
        End If
        s = Nothing
    End Function
    Public Sub setCodiEmpresa()
        Dim obj As Seccio
        If Not isUpdated() Then objects = getRemoteObjects()
        For Each obj In objects
            obj.codiEmpresa = ModelEmpresa.getCodiEmpresa(obj.idEmpresa)
        Next obj
        obj = Nothing
    End Sub
    Public Function getObject(id As Integer) As Object
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Find(Function(x) x.id = id)
    End Function
    Public Function getObject(codi As String) As Seccio
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Find(Function(x) x.codi = codi)
    End Function
    Public Function getIDEmpresa(idSeccio As Integer) As Integer
        Dim obj As Seccio
        If Not isUpdated() Then objects = getRemoteObjects()
        obj = objects.Find(Function(x) x.id = idSeccio)
        If obj Is Nothing Then
            Return -1
        Else
            Return obj.idEmpresa
        End If
    End Function
    Public Function getProjectesSeccio(s As Seccio) As List(Of ProjecteCentre)
        Dim e As Centre, pe As ProjecteCentre
        If Not isUpdated() Then objects = getRemoteObjects()
        getProjectesSeccio = New List(Of ProjecteCentre)
        For Each e In s.centres
            For Each pe In e.projectes
                getProjectesSeccio.Add(pe)
            Next pe
        Next e
        e = Nothing
        pe = Nothing
    End Function
    Public Function save(obj As Seccio) As Integer
        Dim i As Integer
        If obj.id = -1 Then
            obj.ordre = getMaxOrder(obj.idEmpresa) + 1
            i = dbSeccio.insert(obj)
        Else
            i = dbSeccio.update(obj)
        End If
        If i > -1 Then
            dateUpdate = Now()
            objects.Remove(obj)
            objects.Add(obj)
            Return obj.id
        End If
        Return -1
    End Function
    Public Function remove(obj As Seccio) As Boolean
        If dbSeccio.remove(obj) Then
            dateUpdate = Now()
            objects.Remove(obj)
            Return True
        End If
        Return False
    End Function

    Public Function removeSeccio(idEmpresa As Integer) As Boolean
        If dbSeccio.removeSeccio(idEmpresa) Then
            dateUpdate = Now()
            objects.RemoveAll(Function(x) x.idEmpresa = idEmpresa)
            Return True
        End If
        Return False
    End Function
    Public Function exist(obj As Seccio) As Boolean
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Exists(Function(x) (x.id <> obj.id) And x.codi.Equals(obj.codi))
    End Function
    Public Function existsName(obj As Seccio) As Boolean
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Exists(Function(x) (x.id <> obj.id) And x.nom.Equals(obj.nom))
    End Function

    Private Function getMaxOrder(idEmpresa As Integer) As Integer
        Dim obj As Seccio, i As Integer
        i = 0
        If Not isUpdated() Then objects = getRemoteObjects()
        For Each obj In objects
            If idEmpresa = obj.idEmpresa Then
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
        Dim temp As String, obj1 As Seccio, obj2 As Seccio
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
    Private Function getRemoteObjects() As List(Of Seccio)
        dateUpdate = Now()
        Return dbSeccio.getObjects
    End Function
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
    Private Function getTable() As String
        getTable = DBCONNECT.getTaulaSeccions
    End Function

End Module
