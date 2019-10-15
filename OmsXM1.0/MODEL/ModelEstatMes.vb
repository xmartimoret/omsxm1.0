Option Explicit On
Module ModelEstatMes
    Private objects As List(Of EstatMes)
    Private dateUpdate As DateTime

    Public Function getObjects(idEmpresa As Integer, a As Integer) As List(Of EstatMes)
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.FindAll(Function(x) x.idEmpresa = idEmpresa And x.anyo = a)
    End Function
    'Public Function getList(c As ColleccioOrdenada) As Variant()
    '    Dim i As Integer, dades() As Variant, m As EstatMes
    '    If c.dades.Count > 0 Then
    '        ReDim dades(1 To c.dades.Count, 1 To COLUMNS) As Variant
    '    i = 1
    '        For Each m In c.dades
    '            dades(i, 1) = CONFIG.mesNom(m.mes)
    '            If m.estat Then
    '                dades(i, 2) = "TANCAT"
    '            Else
    '                dades(i, 2) = "OBERT"
    '            End If
    '            i = i + 1
    '        Next m
    '    Else
    '        ReDim dades(0) As Variant
    'End If
    '    getList = dades
    'End Function
    Public Function getObject(idEmpresa As Integer, a As Integer, m As Integer) As EstatMes
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Find(Function(x) x.idEmpresa = idEmpresa And x.anyo = a And x.mes = m)
    End Function
    Public Function getAnyEnCurs(idEmpresa) As Integer
        Dim em As EstatMes
        getAnyEnCurs = 0
        If Not isUpdated() Then objects = getRemoteObjects()
        For Each em In objects
            If em.idEmpresa = idEmpresa And em.estat = False Then
                getAnyEnCurs = em.anyo
                Exit For
            Else
                getAnyEnCurs = em.anyo
            End If
        Next em
        em = Nothing
    End Function
    Public Function getEstat(idEmpresa As Integer, a As Integer, m As Integer) As Boolean
        Dim e As EstatMes
        If Not isUpdated() Then objects = getRemoteObjects()
        e = objects.Find(Function(x) x.idEmpresa = idEmpresa And x.anyo = a And x.mes = m)
        If e Is Nothing Then
            Return False
        Else
            Return e.estat
        End If
    End Function
    Public Function getEstatTransitoria(idEmpresa As Integer, a As Integer, m As Integer) As Boolean
        Dim e As EstatMes
        If Not isUpdated() Then objects = getRemoteObjects()
        e = objects.Find(Function(x) x.idEmpresa = idEmpresa And x.anyo = a And x.mes = m)
        If e Is Nothing Then
            Return False
        Else
            Return e.estatTransitoria
        End If
    End Function
    Public Function exist(obj As EstatMes) As Boolean
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects.Exists(Function(x) x.id = obj.id)
    End Function
    Public Function save(obj As EstatMes) As Boolean
        Dim result As Boolean
        If Not exist(obj) Then
            result = dbEstatMes.insert(obj)
        Else
            result = dbEstatMes.update(obj)
        End If
        If result Then
            dateUpdate = Now()
            objects.RemoveAll(Function(x) x.id = obj.id)
            objects.Add(obj)
            Return True
        End If
        Return False
    End Function
    Public Function actualitzar(idEmpresa As Integer, a As Integer) As Boolean
        Dim m As EstatMes, maxMes As Integer, i As Integer
        If Not isUpdated() Then objects = getRemoteObjects()
        maxMes = 1
        For Each m In objects
            If idEmpresa = m.idEmpresa And a = m.anyo And maxMes < m.mes Then
                maxMes = m.mes
            End If
        Next m
        If maxMes < 12 Then
            For i = maxMes To 12
                m = New EstatMes
                m.anyo = a
                m.idEmpresa = idEmpresa
                m.mes = i
                Call save(m)
            Next i
            m = Nothing
            Return True
        End If
        m = Nothing
        Return False
    End Function

    Public Sub reset()
        objects = Nothing
    End Sub
    Private Function getRemoteObjects() As List(Of EstatMes)
        dateUpdate = Now()
        Return dbEstatMes.getObjects
    End Function

    Private Function isUpdated() As Boolean
        If Not objects Is Nothing Then
            isUpdated = DBCONNECT.isUpdated(dateUpdate, getTable())
        Else
            Return False
        End If
        If isUpdated Then dateUpdate = Now
    End Function
    Private Function getTable() As String
        Return DBCONNECT.getTaulaEstatMes
    End Function
End Module
