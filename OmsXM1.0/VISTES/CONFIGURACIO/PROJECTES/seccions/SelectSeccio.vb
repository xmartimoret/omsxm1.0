Public Class SelectSeccio
    Inherits LVSubObjects2
    Friend Event selectObject(ByVal s As Seccio)

    Public Sub New(pAccio As Integer, pMultiselect As Boolean, parentForm As Boolean, pIDEmpresa As Integer, Optional pTitol As String = "", Optional pOrdre As Integer = 0)
        Me.idParent = pIDEmpresa
        Me.titol = pTitol
        Me.orderColumn = pOrdre
    End Sub
    Public Overrides Function afegir(id As String, idParent As String) As Boolean
        Dim s As Seccio
        s = DSeccio.getSeccio(New Seccio)
        If s IsNot Nothing Then
            s.idEmpresa = idParent
            Return save(s)
        End If
        Return False
    End Function

    Public Overrides Function eliminar(ids As List(Of String)) As Boolean
        Dim s As Seccio
        s = ModelSeccio.getObject(CInt(ids(0)))
        If s.id > -1 Then
            If s.centres.Count = 0 Then
                If MISSATGES.CONFIRM_REMOVE_SECCIO(s.ToString) Then
                    Return ModelSeccio.remove(s)
                End If
            Else
                Call ERRORS.ERR_REMOVE_SECCIO_BY_CENTRE()
            End If
        End If
            Return False
    End Function


    Public Overrides Function modificar(id As String) As Boolean
        Dim s As Seccio
        s = DSeccio.getSeccio(ModelSeccio.getObject(CInt(id)))
        Return save(s)
        Return False
    End Function

    Private Function save(obj As Seccio) As Boolean
        Dim saved As Boolean
        If Not obj Is Nothing Then
            If Not ModelSeccio.exist(obj) Then
                saved = ModelSeccio.save(obj)
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
        Return ModelSeccio.getDataList(ModelSeccio.getObjects(CInt(id)))
    End Function
    Public Overrides Function seleccionar(id As String) As Boolean
        Dim s As Seccio
        s = ModelSeccio.getObject(CInt(id))
        If s IsNot Nothing Then
            RaiseEvent selectObject(s)
            Return True
        End If
        Return False
    End Function
    Public Overrides Function canviarOrdre(obj1 As String, obj2 As String) As Boolean
        Return ModelSeccio.changeOrder(Val(obj1), Val(obj2))
    End Function
End Class
