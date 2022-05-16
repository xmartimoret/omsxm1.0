Option Explicit On
Public Class SelectProjectes
    Inherits LVObjects
    Friend Property projectes As List(Of Projecte)
    Private tipusProjecte As Integer
    Public Sub New(pAccio As Integer, pMultiselect As Boolean, parentForm As Boolean, Optional pTitol As String = "", Optional pOrdre As Integer = 0)
        Me.accio = pAccio
        Me.multiselect = pMultiselect
        Me.isForm = parentForm
        Me.titol = pTitol
        Me.orderColumn = pOrdre
        projectes = New List(Of Projecte)
        tipusProjecte = 0
    End Sub
    Public Sub New(pTipus As Integer, pIdParent As Integer, pAccio As Integer, pMultiselect As Boolean, parentForm As Boolean, Optional pTitol As String = "", Optional pOrdre As Integer = 0)
        tipusProjecte = pTipus
        Me.idParent = pIdParent
        Me.accio = pAccio
        Me.multiselect = pMultiselect
        Me.isForm = parentForm
        Me.titol = pTitol
        Me.orderColumn = pOrdre
        projectes = New List(Of Projecte)

    End Sub
    Public Overrides Function afegir(id As Integer) As Integer
        Return save(DProjecte.getProjecte(New Projecte))
    End Function

    Public Overrides Function eliminar(id As Integer) As Boolean
        Dim p As Projecte
        p = ModelProjecte.getObject(id)
        If p.id > -1 Then
            If MISSATGES.CONFIRM_REMOVE_PROJECTE(p.ToString) Then
                Return ModelProjecte.remove(p)
            End If
        End If
        Return False
    End Function

    Public Overrides Function filtrar(txt As String) As DataList

        Select Case tipusProjecte
            Case 1
                Return ModelProjecte.getDataList(ModelProjecte.getObjectsNoAdded(idParent, txt))
            Case 2
                Return ModelProjecte.getDataList(ModelProjecte.getNoSelectedExpramObjects(idParent, txt))
            Case 3
                Return ModelProjecte.getDataList(ModelProjecte.getNoSelectedClientObjects(txt))
            Case 4
                Return ModelProjecte.getDataList(ModelProjecte.getObjects(idParent, txt))
            Case Else
                Return ModelProjecte.getDataList(ModelProjecte.getObjects(txt))
        End Select
    End Function

    Public Overrides Function modificar(id As Integer) As Integer

        Return save(DProjecte.getProjecte(ModelProjecte.getObject(id)))


    End Function

    Public Overrides Function seleccionar(ids As List(Of Integer)) As Boolean
        Dim i As Integer
        projectes = New List(Of Projecte)
        If ids.Count >= 0 Then
            For Each i In ids
                projectes.Add(ModelProjecte.getObject(i))
            Next
            Return True
        End If
        Return False
    End Function
    Private Function save(obj As Projecte) As Integer
        If Not obj Is Nothing Then
            If Not ModelProjecte.exist(obj) Then
                Return ModelProjecte.save(obj)
            Else
                Throw New ExcepcioSql(ExcepcioSql.ERR_EXIST_CODI_REGISTRE)
            End If
        End If
        Return False
    End Function
    Protected Overrides Sub Finalize()
        MyBase.Finalize()
        projectes = Nothing
    End Sub

    Public Overrides Function filtrar(idParent As Integer, txt As String) As DataList
        Return Nothing
    End Function

    Public Overrides Function getRow(id As Integer) As ListViewItem
        Return ModelProjecte.getListViewItem(id)
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
