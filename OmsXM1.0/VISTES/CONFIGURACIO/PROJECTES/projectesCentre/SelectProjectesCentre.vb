Public Class SelectProjectesCentre
    Inherits LVSubObjects2
    Friend Event selectObject(ByVal c As ProjecteCentre)
    Friend Event addObject(ByVal c As List(Of ProjecteCentre))
    Public Sub New(pAccio As Integer, pMultiselect As Boolean, parentForm As Boolean, pIDCentre As Integer, Optional pTitol As String = "", Optional pOrdre As Integer = 0)
        MyBase.New(True, False, True, "", "", IDIOMA.getString("cmdTreure"), True)
        Me.idParent = pIDCentre
        Me.titol = pTitol
        Me.orderColumn = pOrdre

    End Sub

    Public Overrides Function afegir(id As String, idParent As String) As Boolean
        Dim projectes As List(Of Projecte), p As Projecte, pc As ProjecteCentre, result As Boolean, saved As Boolean
        Dim projectesCentre As List(Of ProjecteCentre)
        result = False
        If Val(idParent) > 0 Then
            projectesCentre = New List(Of ProjecteCentre)
            projectes = DProjectes.getProjectes(1, ModelCentre.getIdEmpresa(idParent))
            For Each p In projectes
                pc = New ProjecteCentre()
                pc.idCentre = Val(idParent)
                pc.idProjecte = p.id
                saved = save(pc)
                If saved Then projectesCentre.Add(pc)
                If Not result Then result = saved
            Next
            RaiseEvent addObject(projectesCentre)
        End If
        Return result
    End Function

    Public Overrides Function eliminar(ids As List(Of String)) As Boolean
        Dim p As ProjecteCentre, str As String, result As Boolean
        result = False
        If MISSATGES.CONFIRM_REMOVE_PROJECTE_CENTRE() Then
            For Each str In ids
                p = ModelProjecteCentre.getObject(str)
                If p.id <> "-1" Then
                    If Not result Then
                        result = ModelProjecteCentre.remove(p)
                    Else
                        Call ModelProjecteCentre.remove(p)
                    End If
                End If
            Next
        End If
        p = Nothing
        Return result
    End Function


    Public Overrides Function modificar(id As String) As Boolean
        Return False
    End Function

    Private Function save(obj As ProjecteCentre) As Boolean
        Dim saved As Boolean
        If Not obj Is Nothing Then
            If Not ModelProjecteCentre.exist(obj) Then
                saved = ModelProjecteCentre.save(obj)
                If saved Then RaiseEvent selectObject(obj)
            Else
                Throw New ExcepcioSql(ExcepcioSql.ERR_EXIST_CODI_REGISTRE)
            End If
        End If
        Return saved
    End Function
    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
    Public Overrides Function filtrar(id As String) As DataList
        Return ModelProjecteCentre.getDataList(ModelProjecteCentre.getObjects(CInt(id)))
    End Function
    Public Overrides Function seleccionar(id As String) As Boolean
        Dim p As ProjecteCentre
        p = ModelProjecteCentre.getObject(id)
        If p IsNot Nothing Then
            RaiseEvent selectObject(p)
            Return True
        End If
        Return False
    End Function
    Public Overrides Function canviarOrdre(id1 As String, id2 As String) As Boolean
        Return ModelProjecteCentre.changeOrdre(id1, id2)
    End Function
End Class
