

Public Class SelectEmpreses
    Inherits LVObjects

    Friend Property empreses As List(Of Empresa)
    Friend Event selectObject(e As Empresa)
    Public Sub New(pAccio As Integer, pMultiselect As Boolean, parentForm As Boolean, Optional pTitol As String = "", Optional pOrdre As Integer = 0)
        Me.accio = pAccio
        Me.multiselect = pMultiselect
        Me.isForm = parentForm
        Me.titol = pTitol
        Me.orderColumn = 1
        empreses = New List(Of Empresa)
    End Sub
    Public Overrides Function afegir(id As Integer) As Integer
        Return save(DEmpresa.getEmpresa(New Empresa))
    End Function

    Public Overrides Function eliminar(id As Integer) As Boolean
        Dim e As Empresa
        e = ModelEmpresa.getObject(id)
        If e.id > -1 Then
            If MISSATGES.CONFIRM_REMOVE_EMPRESA(e.ToString) Then
                Return ModelEmpresa.remove(e)
            End If
        End If
        Return False
    End Function

    Public Overrides Function filtrar(txt As String) As DataList
        Return ModelEmpresa.getDataList(ModelEmpresa.getObjects(txt))
    End Function

    Public Overrides Function modificar(id As Integer) As Integer
        Return save(DEmpresa.getEmpresa(ModelEmpresa.getObject(id)))
    End Function

    Public Overrides Function seleccionar(ids As List(Of Integer)) As Boolean
        Dim i As Integer
        empreses = New List(Of Empresa)
        If ids.Count >= 0 Then
            For Each i In ids
                empreses.Add(ModelEmpresa.getObject(i))
            Next
            RaiseEvent selectObject(empreses.Item(0))
            Return True
        End If
        Return False
    End Function
    Private Function save(obj As Empresa) As Integer
        If Not obj Is Nothing Then
            If Not ModelEmpresa.exist(obj) Then
                Return ModelEmpresa.save(obj)
            Else
                Throw New ExcepcioSql(ExcepcioSql.ERR_EXIST_CODI_REGISTRE)
            End If
        End If
        Return False
    End Function
    Protected Overrides Sub Finalize()
        MyBase.Finalize()
        empreses = Nothing
    End Sub

    Public Overrides Function filtrar(idParent As Integer, txt As String) As DataList
        Return Nothing
    End Function

    Public Overrides Function getRow(id As Integer) As ListViewItem
        Return ModelEmpresa.getListViewItem(id)
    End Function
    Public Overrides Sub imprimir(pdf As Boolean, filtre As String)
        Call ERRORS.EN_CONSTRUCCIO()
    End Sub

    Public Overrides Sub actualitzar(id As List(Of Integer))
    End Sub
    Public Overrides Sub toolTipText(id As Integer)

    End Sub
    Public Overrides Sub guardarCopia(id As Integer)
        Call ERRORS.EN_CONSTRUCCIO()
    End Sub
End Class
