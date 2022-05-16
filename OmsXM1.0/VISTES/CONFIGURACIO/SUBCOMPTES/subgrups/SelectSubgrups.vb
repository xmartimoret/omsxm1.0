

Public Class SelectSubgrups
    Inherits LVSubObjects1

    Friend Event selectObject(ByVal sg As Subgrup)

    Public Sub New(pAccio As Integer, pMultiselect As Boolean, parentForm As Boolean, pIdGrup As Integer, Optional pTitol As String = "", Optional pOrdre As Integer = 0)
        Me.idParent = pIdGrup
        Me.titol = pTitol
        Me.orderColumn = pOrdre
    End Sub
    Public Overrides Function afegir(id As String, idParent As String) As Boolean
        Dim s As Subgrup
        s = DSubgrup.getsubgrup(New Subgrup)
        If s IsNot Nothing Then
            s.idGrup = idParent
            Return save(s)
        End If
        Return False
    End Function

    Public Overrides Function eliminar(id As String) As Boolean
        Dim s As Subgrup
        s = ModelSubgrup.getObject(CInt(id))
        If s.id > -1 Then
            If MISSATGES.CONFIRM_REMOVE_SUBGRUP(s.ToString) Then
                Return ModelSubgrup.remove(s)
            End If
        End If
        Return False
    End Function


    Public Overrides Function modificar(id As String) As Boolean
        Dim s As Subgrup
        s = DSubgrup.getsubgrup(ModelSubgrup.getObject(CInt(id)))
        Return save(s)
        Return False
    End Function

    Private Function save(obj As Subgrup) As Boolean
        Dim saved As Boolean
        If Not obj Is Nothing Then
            If Not ModelSubgrup.exist(obj) Then
                saved = ModelSubgrup.save(obj)
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

    Public Overrides Function filtrar(id As String, txt As String) As DataList
        Return ModelSubgrup.getDataList(ModelSubgrup.getObjects(CInt(id), txt))
    End Function

    Public Overrides Function seleccionar(id As String) As Boolean
        Dim sg As Subgrup
        sg = ModelSubgrup.getObject(CInt(id))
        If sg IsNot Nothing Then
            RaiseEvent selectObject(sg)
            Return True
        End If
        Return False
    End Function
End Class
