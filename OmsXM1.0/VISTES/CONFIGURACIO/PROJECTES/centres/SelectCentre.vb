Public Class SelectCentre
    Inherits LVSubObjects2
    Friend Event addObject(ByVal c As Centre)
    Friend Event selectObject(ByVal c As Centre)
    Friend Event removeObject(ByVal c As Centre)
    Public Sub New(pAccio As Integer, pMultiselect As Boolean, parentForm As Boolean, pIDEmpresa As Integer, Optional pTitol As String = "", Optional pOrdre As Integer = 0)
        Me.idParent = pIDEmpresa
        Me.titol = pTitol
        Me.orderColumn = pOrdre
    End Sub
    Public Overrides Function afegir(id As String, idParent As String) As Boolean
        Dim c As Centre, result As Boolean
        c = DCentre.getCentre(New Centre)
        If c IsNot Nothing Then
            c.idSeccio = idParent
            c.idEmpresa = ModelSeccio.getIDEmpresa(idParent)
            result = save(c)
            If result Then RaiseEvent addObject(c)
            Return result
            End If
            Return False
    End Function

    Public Overrides Function eliminar(ids As List(Of String)) As Boolean
        Dim c As Centre
        c = ModelCentre.getObject(CInt(ids(0)))
        If c.id > -1 Then
            If c.projectes.Count = 0 Then
                If MISSATGES.CONFIRM_REMOVE_CENTRE(c.ToString) Then
                    RaiseEvent removeObject(c)
                    Return ModelCentre.remove(c)
                End If
            Else
                Call ERRORS.ERR_REMOVE_CENTRE_BY_PROJECTE()
            End If
        End If
        Return False
    End Function


    Public Overrides Function modificar(id As String) As Boolean
        Dim c As Centre
        c = DCentre.getCentre(ModelCentre.getObject(CInt(id)))
        Return save(c)
        Return False
    End Function

    Private Function save(obj As Centre) As Boolean
        Dim saved As Boolean
        If Not obj Is Nothing Then
            If Not ModelCentre.exist(obj) Then
                saved = ModelCentre.save(obj)
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
        Return ModelCentre.getDataList(ModelCentre.getObjects(CInt(id), ""))
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

    Public Overrides Function canviarOrdre(id1 As String, id2 As String) As Boolean
        Return ModelCentre.changeOrder(Val(id1), Val(id2))
    End Function
End Class
