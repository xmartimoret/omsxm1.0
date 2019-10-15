Option Explicit On

Module ModelEmpresa

    Private objects As List(Of Empresa)
    Private dateUpdate As Date
    Private Const N_Columns As Integer = 4

    Public Function getObjects() As List(Of Empresa)
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects
    End Function
    Public Function getObjects(filter As String) As List(Of Empresa)
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.FindAll(Function(x) x.isFilter(filter))
    End Function
    Public Function getObjectsContaplus() As List(Of Empresa)
        Dim e As Empresa, c As Contaplus
        If Not isUpdated() Then objects = getRemoteObjects()
        getObjectsContaplus = New List(Of Empresa)
        For Each e In objects
            For Each c In e.empresesContaplus
                If c.esContaplus Then
                    getObjectsContaplus.Add(e)
                    Exit For
                End If
            Next c
        Next e
        e = Nothing
        c = Nothing
    End Function
    Public Function getObject(id As Integer) As Empresa
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Find(Function(x) x.id = id)
    End Function
    Public Function getObject(codi As String) As Empresa
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Find(Function(x) x.codi = codi)
    End Function
    Public Function getCodiEmpresa(id As Integer) As String
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Find(Function(x) x.id = id).codi
    End Function
    Public Function getNom(id As Integer) As String
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Find(Function(x) x.id = id).nom
    End Function
    Public Function exist(obj As Empresa) As Boolean
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Exists(Function(x) x.id <> obj.id And StrComp(x.codi, obj.codi, CompareMethod.Text) = 0)
    End Function
    Public Function getListObjects() As Object()
        Dim obj As Empresa, i As Integer = 0, objectes() As Object
        If Not isUpdated() Then objects = getRemoteObjects()
        ReDim objectes(objects.Count - 1)

        For Each obj In objects
            objectes(i) = obj
            i = i + 1
        Next
        getListObjects = objectes
        objectes = Nothing
        obj = Nothing
    End Function
    Public Function getListObjects(empreses As List(Of Empresa)) As Object()
        Dim obj As Empresa, i As Integer = 0, objectes() As Object
        ReDim objectes(empreses.Count - 1)
        For Each obj In empreses
            objectes(i) = obj
            i = i + 1
        Next
        getListObjects = objectes
        objectes = Nothing
        obj = Nothing
    End Function
    Public Function getDataList(empreses As List(Of Empresa)) As DataList
        Dim e As Empresa
        getDataList = New DataList
        If empreses.Count > 0 Then
            getDataList.columns.Add(COLUMN.ID)
            getDataList.columns.Add(COLUMN.CODI)
            getDataList.columns.Add(COLUMN.NOM)
            getDataList.columns.Add(COLUMN.PARTICIPACIO)
            For Each e In empreses
                getDataList.rows.Add(New ListViewItem(New String() {e.id, e.codi, e.nom, e.participacio & "%"}))
            Next
        End If
        e = Nothing
    End Function
    Public Function getListNomsEmpresaBYPOSID() As String()
        Dim e As Empresa, dades() As String
        If Not isUpdated() Then objects = getRemoteObjects()
        ReDim dades(0 To objects.Count)
        For Each e In objects
            dades(e.id) = e.nom
        Next e
        getListNomsEmpresaBYPOSID = dades
        e = Nothing
    End Function
    'todo cal veure com s'emplena el combo.
    'Public Function getListCombo(c As ColleccioOrdenada) As Variant()
    '    Dim dades() As Variant, i As Integer, e As Empresa
    '    If c.dades.Count > 0 Then
    '        ReDim dades(1 To c.dades.Count, 1 To 2) As Variant
    '    i = 1
    '        For Each e In c.dades
    '            dades(i, 1) = e.id
    '            dades(i, 2) = e.nom
    '            i = i + 1
    '        Next e
    '    Else
    '        ReDim dades(0 To 0, 0 To 0) As Variant
    'End If
    '    getListCombo = dades
    'Set e = Nothing
    'End Function
    Public Function save(obj As Empresa) As Integer
        Dim i As Integer
        If obj.id = -1 Then
            i = dbEmpresa.insert(obj)
        Else
            i = dbEmpresa.update(obj)
        End If

        If i > -1 Then
            obj.id = i
            dateUpdate = Now()
            objects.Remove(obj)
            objects.Add(obj)
            Return obj.id
        End If
        Return -1
    End Function
    Public Function remove(obj As Empresa) As Boolean
        Dim result As Boolean
        result = dbEmpresa.remove(obj)
        If result Then
            dateUpdate = Now()
            objects.Remove(obj)
            Call ModelEmpresaContaplus.removeEmpresa(obj.id)
            Call ModelSeccio.removeSeccio(obj.id)
            Return True
        End If
        Return False
    End Function
    Public Sub resetIndex()
        objects = Nothing
    End Sub
    Public Sub changeOrder(e1 As Empresa, e2 As Empresa)
        Dim temp As Integer
        temp = e1.ordre
        e1.ordre = e2.ordre
        e2.ordre = temp
        Call save(e1)
        Call save(e2)
    End Sub

    Private Function getMaxOrder() As Long
        Dim e As Empresa
        getMaxOrder = 0
        If Not isUpdated() Then objects = getRemoteObjects()
        For Each e In objects
            If getMaxOrder() < e.ordre Then getMaxOrder = e.ordre
        Next e
        e = Nothing
    End Function
    'todo, cal estudiar que fem amb les funcions reordenar
    '    Public Sub reOrdenar()
    '        Dim rc As ADODB.Recordset, i As Integer
    '    Set rc = New ADODB.Recordset
    '    rc.Open "SELECT ORDRE FROM " & getTable() & " ORDER BY ordre ", DBCONNECT.currentConnect, adOpenDynamic, adLockOptimistic
    '    i = 1
    '        While Not rc.EOF
    '            rc("ordre") = i
    '            rc.update
    '            i = i + 1
    '            rc.MoveNext
    '    Wend
    '    If rc.State = 1 Then
    '            rc.Close
    '        End If
    '        Call resetIndex()
    '            Set rc = Nothing
    'End Sub

    Public Function getParticipacio(id As Integer) As Integer
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Find(Function(x) x.id = id).participacio
    End Function

    Public Function getParticipacio(codi As String) As Integer
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Find(Function(x) x.codi = codi).participacio
    End Function
    Public Function updateDiarisServerLocal() As Boolean
        Dim e As Empresa, rRemote As String, rLocal As String, c As Contaplus
        Dim frm As frmAvis
        'On Error GoTo err1
        If Not isUpdated() Then objects = getRemoteObjects()
        frm = New frmAvis(IDIOMA.getString("actualitzar"), "", "")

        For Each e In objects
            For Each c In e.empresesContaplus
                rRemote = CONFIG.getPathDiarioServidor(e.codi, c.anyo)
                rLocal = CONFIG.getPathDiarioLocal(e.codi, c.anyo)
                If CONFIG.fileExist(rRemote) Then
                    If Not CONFIG.fileExist(rLocal) Then
                        Call frm.setData(IDIOMA.getString("remot") & "-->" & IDIOMA.getString("local"), "DIARI. " & e.nom, c.anyo)
                        Try
                            Call FileCopy(rRemote, rLocal)
                        Catch ex As Exception
                            Call ERRORS.ERR_FITXER_DIARIO_OBERT()
                        End Try
                    Else
                        If CONFIG.getDateFileModified(rRemote) <> CONFIG.getDateFileModified(rLocal) Then
                            Call frm.setData(IDIOMA.getString("remot") & "-->" & IDIOMA.getString("local"), "DIARI. " & e.nom, c.anyo)
                            Try
                                Call FileCopy(rRemote, rLocal)
                            Catch ex As Exception
                                Call ERRORS.ERR_FITXER_DIARIO_OBERT()
                            End Try
                        End If
                    End If
                End If
            Next c
        Next e
        Call frm.tancar()
        e = Nothing
        frm = Nothing
        c = Nothing
        Return True
    End Function
    ' todo falta definir que fem amb el mode local
    Private Function getRemoteObjects() As List(Of Empresa)
        Dim e As Empresa, dades As List(Of Empresa)
        dateUpdate = Now()
        dades = dbEmpresa.getObjects
        'For Each e In dades
        '    e.empresesContaplus = ModelEmpresaContaplus.getObjects(e.id)
        'Next
        Return dades
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
        Return DBCONNECT.GetTaulaEmpresa
    End Function
End Module
