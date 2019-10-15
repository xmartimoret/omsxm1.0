
Public Class SelectColumnaFilles
    Inherits LVSubObjects1
    Friend Event selectObject(ByVal cf As ColumnaFilla)
    Friend Event addObject(ByVal columnes As List(Of ColumnaFilla))
    Friend Event removeObject(ByVal cf As ColumnaFilla)
    Private idColumna As Integer
    Public Sub New(idColumna As Integer, Optional pTitol As String = "", Optional pOrdre As Integer = 0)
        MyBase.New(True, False, True, "", "", IDIOMA.getString("cmdTreure"))
        Me.idParent = idColumna
        Me.titol = pTitol
        Me.orderColumn = pOrdre
    End Sub
    Public Overrides Function afegir(id As String, idParent As String) As Boolean
        Dim columnes As List(Of Columna), c As Columna, cf As ColumnaFilla, result As Boolean
        Dim columnesFilles As List(Of ColumnaFilla)
        columnes = DColumnes.getColumnes(idParent, IDIOMA.getString("selectColumnes"))
        If Not columnes Is Nothing Then
            columnesFilles = New List(Of ColumnaFilla)
            For Each c In columnes
                cf = New ColumnaFilla
                cf.idColumna = idParent
                cf.idFilla = c.id
                If save(cf) Then columnesFilles.Add(cf)
            Next
            RaiseEvent addObject(columnesFilles)
            result = True
        End If
        columnes = Nothing
        columnesFilles = Nothing
        c = Nothing
        cf = Nothing
        Return result
    End Function
    Public Overrides Function eliminar(id As String) As Boolean
        Dim cf As ColumnaFilla, result As Boolean
        cf = ModelColumnaFilla.getObject(id)
        If cf IsNot Nothing Then
            If MISSATGES.CONFIRM_QUIT_COLUMNAFILLA Then
                result = ModelColumnaFilla.remove(cf)
                If result Then RaiseEvent removeObject(cf)
            End If
        End If
        Return result
    End Function
    Public Overrides Function modificar(id As String) As Boolean
        Return False
    End Function

    Private Function save(obj As ColumnaFilla) As Boolean
        If Not obj Is Nothing Then
            Return ModelColumnaFilla.save(obj)
        End If
        Return False
    End Function
    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Public Overrides Function filtrar(id As String, txt As String) As DataList
        Return ModelColumna.getDataList(ModelColumnaFilla.getFilles(id, txt))
    End Function

    Public Overrides Function seleccionar(id As String) As Boolean
        Dim cf As ColumnaFilla

        cf = ModelColumnaFilla.getObject(id)
        If cf IsNot Nothing Then
            RaiseEvent selectObject(cf)
            Return True
        End If
        Return False
    End Function


End Class
