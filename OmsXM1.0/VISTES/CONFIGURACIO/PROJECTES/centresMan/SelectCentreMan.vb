

Public Class SelectCentreMan
    Inherits LVSubObjects2
    Friend centres As List(Of Centre)
    Friend Event selectObject(ByVal c As Centre)
    Public Sub New(pCentres As List(Of Centre))
        centres = pCentres
    End Sub

    Public Overrides Function afegir(id As String, idParent As String) As Boolean
        Dim centresAdd As List(Of Centre)
        afegir = False
        centresAdd = DSelectCentres.getCentresNoAdded(centres, "")
        If centresAdd IsNot Nothing Then
            centres.AddRange(centresAdd)
            afegir = True
        End If
        centresAdd = Nothing
    End Function
    Public Overrides Function canviarOrdre(id1 As String, id2 As String) As Boolean
        Dim c1 As Centre, c2 As Centre, temp As String
        canviarOrdre = False
        c1 = centres.Find(Function(x) x.id = CInt(id1))
        c2 = centres.Find(Function(x) x.id = CInt(id2))
        If c1 IsNot Nothing And c2 IsNot Nothing Then
            temp = c1.ordre
            c1.ordre = c2.ordre
            c2.ordre = temp
            canviarOrdre = True
        End If
        c1 = Nothing
        c2 = Nothing
    End Function

    Public Overrides Function eliminar(ids As List(Of String)) As Boolean
        Dim str As String
        eliminar = False
        For Each str In ids
            centres.RemoveAll(Function(x) x.id = str)
            eliminar = True
        Next
    End Function

    Public Overrides Function filtrar(id As String) As DataList
        filtrar = ModelCentre.getDataList(centres)
    End Function

    Public Overrides Function modificar(id As String) As Boolean
        Return False
    End Function

    Public Overrides Function seleccionar(id As String) As Boolean
        Dim c As Centre
        c = ModelCentre.getObject(CInt(id))
        If c IsNot Nothing Then
            RaiseEvent selectObject(c)
            Return True
        End If
        Return False
    End Function
End Class
