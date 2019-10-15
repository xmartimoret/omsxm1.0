Public Class SelectColumnaProjectes
    Inherits LVSubObjects1
    Friend Event selectObject(ByVal cf As ProjecteColumna)
    Friend Event addObject(ByVal projectes As List(Of ProjecteColumna))
    Friend Event RemoveObject(ByVal cf As ProjecteColumna)
    Private idColumna As Integer
    Public Sub New(idColumna As Integer, Optional pTitol As String = "", Optional pOrdre As Integer = 0)
        MyBase.New(True, False, True, "", "", IDIOMA.getString("cmdTreure"))
        Me.idParent = idColumna
        Me.titol = pTitol
        Me.orderColumn = pOrdre
    End Sub
    Public Overrides Function afegir(id As String, idParent As String) As Boolean
        Dim projectes As List(Of Projecte), p As Projecte, cp As ProjecteColumna
        Dim cps As List(Of ProjecteColumna), result As Boolean
        projectes = DProjectes.getProjectes(2, idParent)
        If Not projectes Is Nothing Then
            cps = New List(Of ProjecteColumna)
            For Each p In projectes
                cp = New ProjecteColumna
                cp.idColumna = idParent
                cp.idProjecte = p.id
                If save(cp) Then cps.Add(cp)
            Next
            RaiseEvent addObject(cps)
            result = True
        End If
        cps = Nothing
        projectes = Nothing
        p = Nothing
        cp = Nothing
        Return result
    End Function
    Public Overrides Function eliminar(id As String) As Boolean
        Dim cp As ProjecteColumna, result As Boolean
        cp = ModelProjecteColumna.getObject(id)
        result = False
        If cp IsNot Nothing Then
            If MISSATGES.CONFIRM_QUIT_COLUMNAPROJECTE Then
                result = ModelProjecteColumna.remove(cp)
                If result Then RaiseEvent RemoveObject(cp)
            End If
        End If
        Return result
    End Function
    Public Overrides Function modificar(id As String) As Boolean
        Return False
    End Function

    Private Function save(obj As ProjecteColumna) As Boolean
        If Not obj Is Nothing Then
            Return ModelProjecteColumna.save(obj)
        End If
        Return False
    End Function
    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Public Overrides Function filtrar(id As String, txt As String) As DataList
        Return ModelProjecteColumna.getDataList(ModelProjecteColumna.getObjects(id, txt))
    End Function

    Public Overrides Function seleccionar(id As String) As Boolean
        Dim cp As ProjecteColumna
        cp = ModelProjecteColumna.getObject(id)
        If cp IsNot Nothing Then
            RaiseEvent selectObject(cp)
            Return True
        End If
        Return False
    End Function


End Class
