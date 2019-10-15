Public Class SelectDepartamentsLLM
    Inherits LVSubObjects2
    Friend Event selectObject(d As Departament)
    Public Sub New(Optional pTitol As String = "", Optional pOrdre As Integer = 0)
        Me.titol = pTitol
        Me.orderColumn = 1
    End Sub
    Private Function save(obj As Departament) As Boolean
        If Not obj Is Nothing Then
            If Not ModelDepartament.exist(obj) Then
                Return ModelDepartament.save(obj)
            Else
                Throw New ExcepcioSql(ExcepcioSql.ERR_EXIST_CODI_REGISTRE)
            End If
        End If
        Return False
    End Function
    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub


    Public Overrides Function seleccionar(id As String) As Boolean
        Dim d As Departament
        If IsNumeric(id) Then
            d = ModelDepartament.getObject(CInt(id))
            RaiseEvent selectObject(d)
            Return True
        End If
        Return False
    End Function

    Public Overrides Function afegir(id As String, idParent As String) As Boolean
        Return save(DDepartament.getDepartament(New Departament))
    End Function

    Public Overrides Function modificar(id As String) As Boolean
        If IsNumeric(id) Then
            Return save(DDepartament.getDepartament(ModelDepartament.getObject(CInt(id))))
        Else
            Return False
        End If
    End Function

    Public Overrides Function eliminar(ids As List(Of String)) As Boolean
        Dim d As Departament, id As String, result As Boolean
        For Each id In ids
            d = ModelDepartament.getObject(id)
            If d IsNot Nothing Then
                If MISSATGES.CONFIRM_REMOVE_DEPARTAMENT() Then
                    If ModelDepartament.remove(d) Then result = True
                End If
            End If
        Next
        Return result
    End Function

    Public Overrides Function canviarOrdre(id1 As String, id2 As String) As Boolean
        Return False
    End Function

    Public Overrides Function filtrar(id As String) As DataList
        Return ModelDepartament.getDataList(ModelDepartament.getObjects())
    End Function
End Class
