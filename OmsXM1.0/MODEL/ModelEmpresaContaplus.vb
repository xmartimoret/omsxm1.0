Option Explicit On

Public Module ModelEmpresaContaplus
    Private objects As List(Of Contaplus)


    Private Const N_COLUMNS As Integer = 4
    Private dateUpdate As DateTime
    Public Function getObjects(idEmpresa As Integer) As List(Of Contaplus)
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.FindAll(Function(x) x.idEmpresa = idEmpresa)
    End Function
    Public Function getObject(id As Integer) As Contaplus
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Find(Function(x) x.id = id)
    End Function
    Public Function getObjectByEmpresaAny(idEmpresa As Integer, anyo As Integer) As Contaplus
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Find(Function(x) x.idEmpresa = idEmpresa And x.anyo = anyo)
    End Function
    Public Function getDataList(empresesC As List(Of Contaplus)) As DataList
        Dim c As Contaplus, rutaDiario As String
        getDataList = New DataList
        If empresesC.Count > 0 Then
            getDataList.columns.Add(COLUMN.ID)
            getDataList.columns.Add(COLUMN.ANYO)
            getDataList.columns.Add(COLUMN.NOM(150))
            getDataList.columns.Add(COLUMN.DATA_MODIFICAT)
            For Each c In empresesC
                rutaDiario = CONFIG.getPathDiarioContaplus(c.nom)
                If CONFIG.fileExist(rutaDiario) Then
                    getDataList.rows.Add(New ListViewItem(New String() {c.id, c.anyo, c.nom, CONFIG.getDateFileModified(rutaDiario)}))
                Else
                    getDataList.rows.Add(New ListViewItem(New String() {c.id, c.anyo, c.nom, ""}))
                End If
            Next
        End If
        c = Nothing
    End Function

    Public Function getListObjects(e As Empresa) As Object()
        Dim obj As Contaplus, i As Integer = 0, objectes() As Object
        ReDim objectes(e.empresesContaplus.Count - 1)
        For Each obj In e.empresesContaplus
            objectes(i) = obj
            i = i + 1
        Next
        getListObjects = objectes
        objectes = Nothing
        obj = Nothing
    End Function

    ' todo cal veure com es carrega el combo
    'Public Function getListCombo(cc As ColleccioOrdenada) As Variant()
    '    Dim dades() As Variant, i As Integer, c As Contaplus
    '    If cc.dades.Count > 0 Then
    '        ReDim dades(1 To cc.dades.Count, 1 To 3) As Variant
    '    i = 1
    '        For Each c In cc.dades
    '            dades(i, 1) = c.id
    '            dades(i, 2) = c.anyo
    '            dades(i, 3) = c.nom
    '            i = i + 1
    '        Next c
    '    Else
    '        ReDim dades(0 To 0, 0 To 0) As Variant
    'End If
    '    getListCombo = dades
    'Set c = Nothing
    'End Function

    Public Function save(obj As Contaplus) As Integer
        Dim i As Integer
        If obj.id = -1 Then
            i = dbEmpresaContaplus.insert(obj)
        Else
            i = dbEmpresaContaplus.update(obj)
        End If
        If i > -1 Then
            dateUpdate = Now()
            objects.RemoveAll(Function(x) x.id = obj.id)
            objects.Add(obj)
            Return i
        End If
        Return -1
    End Function

    Public Function remove(obj As Contaplus) As Boolean
        If dbEmpresaContaplus.remove(obj) Then
            dateUpdate = Now()
            objects.RemoveAll(Function(x) x.id = obj.id)
            Return True
        End If
        Return False
    End Function
    Public Function removeEmpresa(idEmpresa As Integer) As Boolean
        If dbEmpresaContaplus.removeEmpresa(idEmpresa) Then
            dateUpdate = Now()
            objects.RemoveAll(Function(x) x.idEmpresa = idEmpresa)
            Return True
        End If
        Return False
    End Function
    Public Function existName(obj As Contaplus) As Boolean
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Exists(Function(x) x.id <> obj.id And (StrComp(x.nom, obj.nom, vbTextCompare) = 0 And obj.esContaplus))
    End Function
    Public Function existAny(obj As Contaplus) As Boolean
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Exists(Function(x) x.id <> obj.id And (x.idEmpresa = obj.idEmpresa And x.anyo = obj.anyo))
    End Function
    Public Sub resetIndex()
        objects = Nothing
    End Sub

    Private Function getRemoteObjects() As List(Of Contaplus)
        dateUpdate = Now()
        Return dbEmpresaContaplus.getObjects
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
        Return DBCONNECT.getTaulaEmpresaContaplus
    End Function

End Module
