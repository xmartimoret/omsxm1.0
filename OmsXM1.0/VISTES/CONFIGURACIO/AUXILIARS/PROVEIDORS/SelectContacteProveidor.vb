Public Class SelectContacteProveidor
    Inherits LVSubObjectsSelect
    Friend Property contactes As List(Of ProveidorCont)
    Friend Event selectObject(p As ProveidorCont)
    Public Sub New(pIdparent As Integer, pNomProveidor As String)
        Me.orderColumn = 1
        Me.idParent = pIdparent
        Me.Text = IDIOMA.getString("contactes") & " " & pNomProveidor
        contactes = New List(Of ProveidorCont)
    End Sub



    'Public Overrides Function modificar(id As Integer) As Integer
    '    Return -1
    'End Function

    'Public Overrides Function seleccionar(ids As List(Of Integer)) As Boolean
    '    Dim i As Integer, j As Integer
    '    contactes = New List(Of ProveidorCont)
    '    j = 0
    '    If ids.Count > 0 Then
    '        For Each i In ids
    '            contactes.Add(ModelProveidorContacte.getObject(i))
    '        Next
    '        RaiseEvent selectObject(contactes.Item(0))
    '        Return True
    '    End If
    '    Return False
    'End Function


    Protected Overrides Sub Finalize()
        MyBase.Finalize()
        contactes = Nothing
    End Sub

    Public Overrides Function seleccionar(id As String) As Boolean
        Dim pr As ProveidorCont
        pr = ModelProveidorContacte.getObject(id)
        If Not IsNothing(pr) Then
            RaiseEvent selectObject(pr)
            Return True
        End If
        Return False
        pr = Nothing
    End Function


    Public Overrides Function mostrar(id As String) As Boolean
        Me.Parent.Parent.Dispose()
    End Function

    Public Overrides Function filtrar(id As String) As DataList
        Return ModelProveidorContacte.getDataList(ModelProveidorContacte.getObjects(CInt(id)))
    End Function
End Class
