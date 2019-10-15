

Public Class SelectDepartament
    Inherits LVObjects
    Friend Property departaments As List(Of Departament)
    Public Sub New(pAccio As Integer, pMultiselect As Boolean, parentForm As Boolean, Optional pTitol As String = "", Optional pOrdre As Integer = 0)
        Me.accio = pAccio
        Me.multiselect = pMultiselect
        Me.isForm = parentForm
        Me.titol = pTitol
        Me.orderColumn = 1
        departaments = New List(Of Departament)
    End Sub
    Public Overrides Function afegir(id As Integer) As Integer
        Return save(DDepartament.getDepartament(New Departament))
    End Function
    Public Overrides Function eliminar(id As Integer) As Boolean
        Dim d As Departament
        d = ModelDepartament.getObject(id)
        If d IsNot Nothing Then
            If MISSATGES.CONFIRM_REMOVE_DEPARTAMENT() Then
                Return ModelDepartament.remove(d)
            End If
        End If
        Return False
    End Function

    Public Overrides Function filtrar(txt As String) As DataList
        Return ModelDepartament.getDataList(ModelDepartament.getObjects(txt))
    End Function

    Public Overrides Function modificar(id As Integer) As Integer
        Return save(DDepartament.getDepartament(ModelDepartament.getObject(id)))
    End Function

    Public Overrides Function seleccionar(ids As List(Of Integer)) As Boolean
        Dim i As Integer
        departaments = New List(Of Departament)
        If ids.Count >= 0 Then
            For Each i In ids
                departaments.Add(ModelDepartament.getObject(i))
            Next
            Return True
        End If
        Return False
    End Function
    Private Function save(obj As Departament) As Integer
        If Not obj Is Nothing Then
            If Not ModelDepartament.exist(obj) Then
                Return ModelDepartament.save(obj)
            Else
                Throw New ExcepcioSql(ExcepcioSql.ERR_EXIST_CODI_REGISTRE)
            End If
        End If
        Return -1
    End Function
    Protected Overrides Sub Finalize()
        MyBase.Finalize()
        departaments = Nothing
    End Sub

    Public Overrides Function filtrar(idParent As Integer, txt As String) As DataList
        Return Nothing
    End Function
End Class


