

Public Class SelectSubGrupsGb

    Inherits LVSubObjects2
    Friend Event selectObject(ByVal c As SubGrupGB)
    Public Sub New(pAccio As Integer, pMultiselect As Boolean, parentForm As Boolean, pIDEmpresa As Integer, Optional pTitol As String = "", Optional pOrdre As Integer = 0)
        Me.idParent = pIDEmpresa
        Me.titol = pTitol
        Me.orderColumn = pOrdre
    End Sub
    Public Overrides Function afegir(id As String, idParent As String) As Boolean
        Dim sg As SubGrupGB
        sg = DSubGrupGB.getsubgrup(New SubGrupGB)
        If sg IsNot Nothing Then
            Return save(sg)
        End If
        Return False
    End Function
    Public Overrides Function eliminar(ids As List(Of String)) As Boolean
        Dim sg As SubGrupGB
        sg = ModelSubGrupGB.getObject(CInt(ids(0)))
        If sg.id > -1 Then
            If MISSATGES.CONFIRM_REMOVE_SUBGRUP(sg.ToString) Then
                Return ModelSubGrupGB.remove(sg)
            End If
        End If
        Return False
    End Function

    Public Overrides Function modificar(id As String) As Boolean
        Dim sg As SubGrupGB
        sg = DSubGrupGB.getsubgrup(ModelSubGrupGB.getObject(CInt(id)))
        If sg IsNot Nothing Then
            Return save(sg)
        End If
        Return False
    End Function

    Private Function save(obj As SubGrupGB) As Boolean
        Dim saved As Boolean
        If Not obj Is Nothing Then
            If Not ModelSubGrupGB.exist(obj) Then
                saved = ModelSubGrupGB.save(obj)
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
        Return ModelSubGrupGB.getDataList(ModelSubGrupGB.getObjects(""))
    End Function
    Public Overrides Function seleccionar(id As String) As Boolean
        Dim c As SubGrupGB
        c = ModelSubGrupGB.getObject(CInt(id))
        If c IsNot Nothing Then
            RaiseEvent selectObject(c)
            Return True
        End If
        Return False
    End Function
    Public Overrides Function canviarOrdre(id1 As String, id2 As String) As Boolean
        Return ModelSubGrupGB.changeOrder(Val(id1), Val(id2))
    End Function

End Class
