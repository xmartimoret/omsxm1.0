Public Class SelectComandesArticle
    'Inherits LVSubObjects
    'Friend Property comandes As List(Of articleComanda)
    'Friend Event selectObject(p As articleComanda)
    'Public Sub New(pIdComanda As Integer, pNomProjecte As String, Optional pTitol As String = "", Optional pOrdre As Integer = 0)
    '    Me.idParent = pIdComanda
    '    Me.titol = pTitol
    '    Me.orderColumn = 1
    '    comandes = New List(Of articleComanda)
    'End Sub

    'Public Overrides Function eliminar(id As Integer) As Boolean
    '    Return False
    'End Function
    'Private Function save(obj As articleComanda) As Integer

    '    Return False
    'End Function
    'Protected Overrides Sub Finalize()
    '    MyBase.Finalize()
    '    comandes = Nothing
    'End Sub
    'Public Overrides Function filtrar(id As Integer) As DataList
    '    Dim ac As articleComanda
    '    ac = ModelarticleComanda.getObject(id)
    '    If Not IsNothing(ac) Then
    '        Return ModelarticleComanda.getDataList((ac.codi))
    '    End If
    '    Return Nothing
    'End Function
    'Public Overrides Function afegir(id As Integer) As Boolean
    '    Return False
    'End Function

    'Public Overrides Function modificar(id As Integer) As Boolean
    '    Dim ac As articleComanda
    '    ac = ModelarticleComanda.getObject(id)
    '    If Not IsNothing(ac) Then
    '        Call frmIniComanda.mostrarComandaValidacio(ModelComandaEnEdicio.getObject(id))
    '        Return True
    '    End If
    '    Return False
    'End Function
End Class
