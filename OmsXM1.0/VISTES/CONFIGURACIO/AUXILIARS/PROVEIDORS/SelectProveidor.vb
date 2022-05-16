
Option Explicit On
Public Class SelectProveidor
    Inherits LVObjects
    Friend Property proveidors As List(Of Proveidor)
    Friend Event selectObject(p As Proveidor)
    Public Sub New(pAccio As Integer, pMultiselect As Boolean, parentForm As Boolean, Optional pTitol As String = "", Optional pOrdre As Integer = 0)
        Me.accio = pAccio
        Me.multiselect = pMultiselect
        Me.isForm = parentForm
        Me.titol = pTitol
        Me.orderColumn = 1
        proveidors = New List(Of Proveidor)
    End Sub
    Public Overrides Function afegir(id As Integer) As Integer
        Return save(DProveidor.getProveidor(New Proveidor))
    End Function
    Public Overrides Function eliminar(id As Integer) As Boolean
        Dim d As Proveidor
        d = ModelProveidor.getObject(id)
        If d IsNot Nothing Then
            If ModelComanda.existObject(id, New Proveidor) Then
                If MISSATGES.CONFIRM_NO_REMOVE_DOWN_OBJECT(UCase(IDIOMA.getString("elProveidor"))) Then
                    d.actiu = False
                    Call ModelProveidor.save(d)
                End If
            ElseIf ModelComandaEnEdicio.existObject(id, New proveidor) Then
                If MISSATGES.CONFIRM_NO_REMOVE_DOWN_OBJECT(UCase(IDIOMA.getString("elProveidor"))) Then
                    d.actiu = False
                    Call ModelProveidor.save(d)
                End If
            ElseIf MISSATGES.CONFIRM_REMOVE_PROVEIDOR(d.ToString) Then
                Return ModelProveidor.remove(d)
            End If
        End If
        Return False
    End Function

    Public Overrides Function filtrar(txt As String) As DataList
        Return ModelProveidor.getDataList(ModelProveidor.getObjects(txt))
    End Function

    Public Overrides Function modificar(id As Integer) As Integer
        Return save(DProveidor.getProveidor(ModelProveidor.getObject(id)))
    End Function

    Public Overrides Function seleccionar(ids As List(Of Integer)) As Boolean
        Dim i As Integer, j As Integer
        proveidors = New List(Of Proveidor)
        j = 0
        If ids.Count > 0 Then
            For Each i In ids
                proveidors.Add(ModelProveidor.getObject(i))
            Next
            RaiseEvent selectObject(proveidors.Item(0))
            Return True
        End If
        Return False
    End Function

    Private Function save(obj As Proveidor) As Integer
        If Not obj Is Nothing Then
            If Not ModelProveidor.exist(obj) Then
                If Not ModelProveidor.existCodi(obj) Then
                    RaiseEvent selectObject(obj)
                    Return ModelProveidor.save(obj)
                Else
                    Throw New ExcepcioSql(ExcepcioSql.ERR_EXIST_CODI_REGISTRE)
                End If
            Else
                Throw New ExcepcioSql(ExcepcioSql.ERR_EXIST_NOM_REGISTRE)
            End If
        End If
        Return False
    End Function
    Protected Overrides Sub Finalize()
        MyBase.Finalize()
        proveidors = Nothing
    End Sub

    Public Overrides Function filtrar(idParent As Integer, txt As String) As DataList
        Return Nothing
    End Function

    Public Overrides Function getRow(id As Integer) As ListViewItem
        Return ModelProveidor.getListViewItem(id)
    End Function
    Private Function getOrderedObjects() As List(Of Proveidor)
        Dim i As Integer, o As Proveidor
        getOrderedObjects = New List(Of Proveidor)
        For Each i In Me.getIndexs
            o = ModelProveidor.getObject(i)
            getOrderedObjects.Add(o)
        Next
    End Function
    Public Overrides Sub imprimir(pdf As Boolean, filtre As String)
        Call modulInfoProveidor.execute(getOrderedObjects, pdf, filtre)
    End Sub
    Public Overrides Sub actualitzar(id As List(Of Integer))

    End Sub
    Public Overrides Sub toolTipText(id As Integer)

    End Sub
    Public Overrides Sub guardarCopia(id As Integer)
        Call ERRORS.EN_CONSTRUCCIO()
    End Sub
End Class


