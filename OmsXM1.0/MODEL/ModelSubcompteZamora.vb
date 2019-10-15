Option Explicit On
Module ModelSubcompteZamora
    Private objects As List(Of SubcompteZamora)
    Private dateUpdate As DateTime
    Private Const ID As String = "ID"
    Private Const ID_SUBCOMPTE As String = "IDSUB"
    Private Const NOM As String = "NOM"
    Private Const UNIC As String = "UNIC"
    Public Function getObjects() As List(Of SubcompteZamora)
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects
    End Function
    Public Function getObjects(filtre As String) As List(Of SubcompteZamora)
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.FindAll(Function(x) x.isFilter(filtre))
    End Function
    Public Function getDataList(subcomptesZam As List(Of SubcompteZamora)) As DataList
        Dim s As SubcompteZamora
        getDataList = New DataList
        If subcomptesZam.Count > 0 Then
            getDataList.columns.Add(COLUMN.ID)
            getDataList.columns.Add(COLUMN.NOM)
            getDataList.columns.Add(COLUMN.GENERICA(IDIOMA.getString("subcompte"), 100, HorizontalAlignment.Center))
            For Each s In subcomptesZam
                getDataList.rows.Add(New ListViewItem(New String() {s.id, s.nom, ModelSubcompte.getObject(s.idSubcompte).ToString}))
            Next
        End If
        s = Nothing
    End Function
    Public Function getObject(id As Long) As SubcompteZamora
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Find(Function(x) x.id = id)
    End Function
    Public Function getObjectByDescripcio(d As String) As SubcompteZamora
        ' string1. en el que se busca
        ' string2. lo que se busca
        Dim s As SubcompteZamora
        If Not isUpdated() Then objects = getRemoteObjects()
        getObjectByDescripcio = Nothing
        For Each s In objects
            If s.esUnic Then
                If StrComp(d, s.nom, vbTextCompare) = 0 Then
                    getObjectByDescripcio = s
                    Exit For
                End If
            End If
        Next s
        If getObjectByDescripcio Is Nothing Then
            For Each s In objects
                If Not s.esUnic Then
                    If InStr(1, d, s.nom, vbTextCompare) > 0 Then
                        getObjectByDescripcio = s
                        Exit For
                    End If
                End If
            Next s
        End If
        s = Nothing
    End Function
    'Public Function getDescripcio(id As Integer) As String
    '    Dim s As Subcompte
    '    If TypeName(tempSubcomptes) <> "ColleccioOrdenada" Then Set tempSubcomptes = getRemoteObjects
    '    For Each s In tempSubcomptes.dades
    '        If s.id = id Then
    '            getDescripcio = s.descripcio
    '            Exit For
    '        End If
    '    Next s
    '    Set s = Nothing
    'End Function
    'Public Function getCodi(id As Integer) As Long
    '    Dim s As Subcompte
    '    If TypeName(tempSubcomptes) <> "ColleccioOrdenada" Then Set tempSubcomptes = getRemoteObjects
    '    For Each s In tempSubcomptes.dades
    '        If s.id = id Then
    '            getCodi = s.codi
    '            Exit For
    '        End If
    '    Next s
    '    Set s = Nothing
    'End Function
    'Public Function getToString(id As Integer) As String
    '    Dim s As Subcompte
    '    If TypeName(tempSubcomptes) <> "ColleccioOrdenada" Then Set tempSubcomptes = getRemoteObjects
    '    For Each s In tempSubcomptes.dades
    '        If s.id = id Then
    '            getToString = s.toString
    '            Exit For
    '        End If
    '    Next s
    '    Set s = Nothing
    'End Function
    Public Function save(obj As SubcompteZamora) As Integer
        Dim i As Integer
        If obj.id = -1 Then
            i = dbSubcompteZamora.insert(obj)
        Else
            i = dbSubcompteZamora.update(obj)
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
    Public Function remove(s As SubcompteZamora) As Boolean
        If dbSubcompteZamora.remove(s) Then
            objects.Remove(s)
            Return True
        End If
        Return False
    End Function
    Private Function deleteAll() As Boolean
        If dbSubcompteZamora.deleteAll Then
            Call resetIndex()
            Return True
        End If
        Return False
    End Function
    Public Function exist(s As SubcompteZamora) As Boolean
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Exists(Function(x) StrComp(x.nom, s.nom, CompareMethod.Text) = 0 And x.id = s.id)
    End Function
    Public Function existNom(s As SubcompteZamora) As Boolean
        Dim s1 As SubcompteZamora
        existNom = False
        If Not isUpdated() Then objects = getRemoteObjects()

        For Each s1 In objects
            If s.esUnic Then
                If StrComp(s.nom, s1.nom, vbTextCompare) = 0 And s1.id <> s.id Then
                    existNom = True
                End If
            Else
                If InStr(1, s.nom, s1.nom, vbTextCompare) > 0 And s1.id <> s.id Then
                    existNom = True
                    Exit For
                ElseIf InStr(1, s1.nom, s.nom, vbTextCompare) > 0 And s1.id <> s.id Then
                    existNom = True
                    Exit For
                End If
            End If
        Next s1
        s1 = Nothing
    End Function

    Public Sub resetIndex()
        objects = Nothing
    End Sub
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
    Private Function getRemoteObjects() As List(Of SubcompteZamora)
        dateUpdate = Now()
        Return dbSubcompteZamora.getObjects
    End Function
    Private Function getTable() As String
        Return DBCONNECT.getTaulaSubcompteZamora
    End Function

End Module
