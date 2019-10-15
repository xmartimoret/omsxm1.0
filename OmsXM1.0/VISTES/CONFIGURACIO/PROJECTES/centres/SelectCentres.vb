Public Class SelectCentres
    Inherits LVObjectsParent
    Friend centres As List(Of Centre)
    Private centresAdded As List(Of Centre)
    Private isNoAdded As Boolean
    Public Sub New(pIdEmpresa As Integer, pMultiselect As Boolean, parentForm As Boolean, Optional pTitol As String = "", Optional pOrdre As Integer = 0)
        Me.accio = 0
        Me.multiselect = pMultiselect
        Me.isForm = parentForm
        Me.titol = pTitol
        Me.orderColumn = pOrdre
        Me.idParent = pIdEmpresa
        isNoAdded = False
    End Sub
    Public Sub New(pCentres As List(Of Centre), pMultiselect As Boolean, parentForm As Boolean, Optional pTitol As String = "", Optional pOrdre As Integer = 0)
        Me.accio = 0
        Me.multiselect = pMultiselect
        Me.isForm = parentForm
        Me.titol = pTitol
        Me.orderColumn = pOrdre
        isNoAdded = True
        centresAdded = pCentres
    End Sub
    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
    Public Overrides Function filtrar(idParent As Integer, txt As String) As DataList
        If isNoAdded Then
            Return ModelCentre.getDataListSeccio(ModelCentre.getobjectsNoAdded(centresAdded, txt))
        Else
            Return ModelCentre.getDataListSeccio(ModelCentre.getObjectsEmpresa(idParent, txt))
        End If

    End Function
    Public Overrides Function seleccionar(ids As List(Of Integer)) As Boolean
        Dim i As Integer
        centres = New List(Of Centre)
        If ids.Count >= 0 Then
            For Each i In ids
                centres.Add(ModelCentre.getObject(i))
            Next
            Return True
        End If
        Return False
    End Function
    Public Overrides Function afegir(id As Integer) As Boolean
        Return False
    End Function
    Public Overrides Function modificar(id As Integer) As Boolean
        Return False
    End Function
    Public Overrides Function eliminar(id As Integer) As Boolean
        Return False
    End Function
End Class
