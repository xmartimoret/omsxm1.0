Public Class SelectCodiComanda
    Inherits LVObjects
    Friend Property codisComanda As List(Of CodiComanda)
    Friend Event selectObject(p As CodiComanda)

    Public Sub New(pAccio As Integer, pMultiselect As Boolean, parentForm As Boolean, Optional pTitol As String = "", Optional pOrdre As Integer = 0)
        Me.accio = pAccio
        Me.multiselect = pMultiselect
        Me.isForm = parentForm
        Me.titol = pTitol
        Me.orderColumn = 1
        codisComanda = New List(Of CodiComanda)
    End Sub
    Public Sub New(pAccio As Integer, pMultiselect As Boolean, parentForm As Boolean, pFiltre As String, Optional pTitol As String = "", Optional pOrdre As Integer = 0)
        Me.accio = pAccio
        Me.multiselect = pMultiselect
        Me.isForm = parentForm
        Me.titol = pTitol
        Me.txtFiltrar.Text = pFiltre
        Me.orderColumn = 1
        codisComanda = New List(Of CodiComanda)
    End Sub
    Public Overrides Function afegir(id As Integer) As Integer
        Return -1
    End Function
    Public Overrides Function eliminar(id As Integer) As Boolean
        Dim d As CodiComanda
        d = ModelCodiComanda.getObject(id)
        If d IsNot Nothing Then
            If MISSATGES.CONFIRM_REMOVE_CODI_COMANDA() Then
                Return ModelCodiComanda.remove(d)
            End If
        End If
        Return False
    End Function

    Public Overrides Function filtrar(txt As String) As DataList
        Return ModelCodiComanda.getDataList(ModelCodiComanda.getObjects(txt))
    End Function
    Public Overrides Function modificar(id As Integer) As Integer
        Return save(DCodiComanda.getCodi(ModelCodiComanda.getObject(id)))
    End Function

    Public Overrides Function seleccionar(ids As List(Of Integer)) As Boolean
        Dim i As Integer, j As Integer
        codisComanda = New List(Of CodiComanda)
        j = 0
        If ids.Count >= 0 Then
            For Each i In ids
                codisComanda.Add(ModelCodiComanda.getObject(i))
            Next
            RaiseEvent selectObject(codisComanda.Item(0))
            Return True
        End If
        Return False
    End Function
    Private Function save(obj As CodiComanda) As Integer
        If Not obj Is Nothing Then
            If Not ModelCodiComanda.exist(obj) Then
                Return ModelCodiComanda.save(obj)
            Else
                Throw New ExcepcioSql(ExcepcioSql.ERR_EXIST_NOM_REGISTRE)
            End If
        End If
        Return False
    End Function
    Protected Overrides Sub Finalize()
        MyBase.Finalize()
        codisComanda = Nothing
    End Sub
    Public Overrides Function filtrar(idParent As Integer, txt As String) As DataList
        Return Nothing
    End Function

    Public Overrides Function getRow(id As Integer) As ListViewItem
        Return ModelCodiComanda.getListViewItem(id)
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
