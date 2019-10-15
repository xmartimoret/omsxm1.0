Option Explicit On
Module ModelTransitoria
    Private objects(12) As List(Of Transitoria)
    Private indexCarregat As Boolean
    Private anyActual As Integer
    Private ultimMes As Integer
    Private empresaActual As Empresa
    Public Function getAnyos(idEmpresa As Integer) As Integer()
        Return dbTransitoria.getAnyos(idEmpresa)
    End Function
    Public Function getUltimMes() As Integer
        getUltimMes = ultimMes
    End Function
    Public Function getObjects(e As Empresa, anyo As Integer, mes As Integer) As List(Of Transitoria)
        Dim t As Transitoria
        If Not isUpdated(anyo, e) Then Call SetRemoteObjects()
        getObjects = New List(Of Transitoria)
        If objects(mes) IsNot Nothing Then
            For Each t In objects(mes)
                If t.idEmpresa = e.id And anyo = t.anyo Then getObjects.Add(t)
            Next t
        End If
        t = Nothing
    End Function
    Public Function getObjectsByCentreAnyMes(e As Empresa, c As Centre, anyo As Integer, mes As Integer) As List(Of Transitoria)
        Dim t As Transitoria, p As ProjecteCentre
        If Not isUpdated(anyo, e) Then Call SetRemoteObjects()
        getObjectsByCentreAnyMes = New List(Of Transitoria)
        If objects(mes) IsNot Nothing Then
            For Each t In objects(mes)
                For Each p In c.projectes
                    If t.idEmpresa = e.id And p.idProjecte = t.idProjecte And anyo = t.anyo And mes = t.mes Then getObjectsByCentreAnyMes.Add(t)
                Next p
            Next t
        End If
        t = Nothing
        p = Nothing
    End Function
    Public Function getObjectsByCentreAny(e As Empresa, c As Centre, anyo As Integer) As List(Of Transitoria)
        Dim t As Transitoria, p As ProjecteCentre, m As Integer
        If Not isUpdated(anyo, e) Then Call SetRemoteObjects()
        getObjectsByCentreAny = New List(Of Transitoria)
        For m = 1 To 12
            If objects(m) IsNot Nothing Then
                For Each t In objects(m)
                    For Each p In c.projectes
                        If t.idEmpresa = e.id And p.idProjecte = t.idProjecte And anyo = t.anyo Then getObjectsByCentreAny.Add(t)
                    Next p
                Next t
            End If
        Next
        t = Nothing
        p = Nothing
    End Function

    ' notes ha canviat. 
    Public Function getListAnys(idEmpresa As Integer) As List(Of Integer)
        Return dbTransitoria.getListAnys(idEmpresa)
    End Function

    Public Function getMesos(idEmpresa As Integer, pAnyo As Integer) As List(Of Mes)
        Return dbTransitoria.getMesos(idEmpresa, pAnyo)
    End Function
    Public Function save(c As List(Of Transitoria), idProjecte As Integer, pAnyo As Integer, pMes As Integer)
        Dim result As Boolean
        If remove(idProjecte, pAnyo, pMes) Then
            For Each t In c
                result = result Or dbTransitoria.insert(t)
            Next
        End If
        If result Then
            Return True
        End If
        Return False
    End Function
    Public Function remove(idProjecte As Integer, pAnyo As Integer, pMes As Integer) As Boolean
        Dim result As Boolean
        result = False
        If pMes > 0 Then
            result = dbTransitoria.remove(idProjecte, pAnyo, pMes)
        Else
            result = dbTransitoria.remove(idProjecte, pAnyo)
        End If
        Return result
    End Function

    Public Function removeProjecte(idProjecte As Integer) As Boolean
        If dbTransitoria.removeProjecte(idProjecte) Then
            Return True
        End If
        Return False
    End Function
    Public Sub resetIndex()
        Dim i As Integer
        For i = 1 To 12
            objects(i) = Nothing
        Next i
        indexCarregat = False
    End Sub
    'todo 

    Public Sub ClearDataTransitoria()
        Dim centres As CentresGB, p As Projecte, dAvis As frmAvis, i As Integer
        centres = dBorrarDades.getProjectes
        If centres IsNot Nothing Then
            If centres.projectes.Count > 0 Then
                dAvis = New frmAvis(IDIOMA.getString("esborrarTransitories"), "", "")
                i = 1
                For Each p In centres.projectes
                    Call dAvis.setData(IDIOMA.getString("dadesDe"), p.codi, i & " " & IDIOMA.getString("de") & " " & centres.projectes.Count)
                    Call remove(p.id, centres.anyActual, centres.mesActual)
                    i = i + 1
                Next p
                Call dAvis.tancar()
                Call MISSATGES.DATA_UPDATED()
                Call resetIndex()
            End If
        End If
            centres = Nothing
        p = Nothing
    End Sub
    Private Function isUpdated(a As Integer, e As Empresa) As Boolean
        isUpdated = True
        If Not indexCarregat Then
            isUpdated = False
        ElseIf a <> anyActual Then
            isUpdated = False
        ElseIf empresaActual Is Nothing Then
            isUpdated = False
        ElseIf empresaActual.id <> e.id Then
            isUpdated = False
        End If
        empresaActual = e
        anyActual = a
    End Function
    Private Sub SetRemoteObjects()
        Dim m As Integer
        objects = dbTransitoria.getObjects(anyActual)
        For m = 1 To 12
            If objects(m) Is Nothing Then Exit For
            ultimMes = m
        Next
        indexCarregat = True
    End Sub
    Private Function getTable() As String
        getTable = DBCONNECT.getTaulaTransitoria
    End Function
End Module
