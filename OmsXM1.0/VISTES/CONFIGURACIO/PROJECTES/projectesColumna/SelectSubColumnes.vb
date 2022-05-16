Public Class SelectSubColumnes
    Inherits LVObjects
    Friend Property columnes As List(Of Columna)
    Private tipusProjecte As Integer
    Public Sub New(pAccio As Integer, pMultiselect As Boolean, parentForm As Boolean, Optional pTitol As String = "", Optional pOrdre As Integer = 0)
        Me.accio = pAccio
        Me.multiselect = pMultiselect
        Me.isForm = parentForm
        Me.titol = pTitol
        Me.orderColumn = pOrdre
        columnes = New List(Of Columna)
        tipusProjecte = 0
    End Sub

    Public Overrides Function afegir(id As Integer) As Integer
        Return Nothing
    End Function

    Public Overrides Function eliminar(id As Integer) As Boolean

        Return False
    End Function

    Public Overrides Function filtrar(txt As String) As DataList
        Return ModelColumna.getDataList(ModelColumna.getObjects(txt))
    End Function

    Public Overrides Function modificar(id As Integer) As Integer
        Return Nothing
    End Function

    Public Overrides Function seleccionar(ids As List(Of Integer)) As Boolean
        Dim i As Integer
        columnes = New List(Of Columna)
        If ids.Count >= 0 Then
            For Each i In ids
                columnes.Add(ModelColumna.getObject(i))
            Next
            Return True
        End If
        Return False
    End Function
    Private Function save(obj As Projecte) As Integer
        Return Nothing
    End Function
    Protected Overrides Sub Finalize()
        MyBase.Finalize()
        columnes = Nothing
    End Sub

    Public Overrides Function filtrar(idParent As Integer, txt As String) As DataList
        Return Nothing
    End Function

    Public Overrides Function getRow(id As Integer) As ListViewItem
        Return ModelColumna.getListViewItem(id)
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
