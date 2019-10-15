Public Class SelectProjecteClient
    Inherits LVSubObjects2
    Friend Event selectObject(ByVal c As ProjecteClient)
    Public Sub New(pAccio As Integer, pMultiselect As Boolean, parentForm As Boolean, pIDClient As Integer, Optional pTitol As String = "", Optional pOrdre As Integer = 0)
        MyBase.New(True, False, True, "", "", IDIOMA.getString("cmdTreure"), True)
        Me.idParent = pIDClient
        Me.titol = pTitol
        Me.orderColumn = pOrdre
    End Sub

    Public Overrides Function afegir(id As String, idParent As String) As Boolean
        Dim projectes As List(Of Projecte), p As Projecte, pc As ProjecteClient, result As Boolean, saved As Boolean
        projectes = DProjectes.getProjectes(3, "")
        result = False
        For Each p In projectes
            pc = New ProjecteClient()
            pc.idClient = Val(idParent)
            pc.idProjecte = p.id
            saved = save(pc)
            If Not result Then result = saved
        Next
        Return result
    End Function

    Public Overrides Function eliminar(ids As List(Of String)) As Boolean
        Dim pc As ProjecteClient, str As String, result As Boolean
        result = False
        If MISSATGES.CONFIRM_REMOVE_PROJECTE_CLIENT() Then
            For Each str In ids
                pc = ModelProjecteClient.getObject(str)
                If pc IsNot Nothing Then
                    If Not result Then
                        result = ModelProjecteClient.remove(pc.idProjecte, pc.idClient)
                    Else
                        Call ModelProjecteCentre.remove(pc.idProjecte, pc.idClient)
                    End If
                End If
            Next
        End If
        pc = Nothing
        Return result
    End Function

    Public Overrides Function modificar(id As String) As Boolean
        Return False
    End Function

    Private Function save(obj As ProjecteClient) As Boolean
        Dim saved As Boolean
        If Not obj Is Nothing Then
            If Not ModelProjecteClient.exist(obj) Then
                saved = ModelProjecteClient.save(obj)
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
        Return ModelProjecteClient.getDataList(ModelProjecteClient.getObjects(CInt(id)))
    End Function
    Public Overrides Function seleccionar(id As String) As Boolean
        Dim p As ProjecteClient
        p = ModelProjecteClient.getObject(id)
        If p IsNot Nothing Then
            RaiseEvent selectObject(p)
            Return True
        End If
        Return False
    End Function
    Public Overrides Function canviarOrdre(id1 As String, id2 As String) As Boolean
        Dim pc1 As ProjecteClient, pc2 As ProjecteClient
        pc1 = ModelProjecteClient.getObject(id1)
        pc2 = ModelProjecteClient.getObject(id2)
        If pc1 Is Nothing Or pc2 Is Nothing Then Return False
        Call ModelProjecteClient.changeOrder(pc1, pc2)
        pc1 = Nothing
        pc2 = Nothing
        Return True
    End Function
End Class
