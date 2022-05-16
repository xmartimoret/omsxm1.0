

Public Class SelectPrefixSubcompte
    Inherits LVObjects

    Friend Property subcomptes As List(Of PrefixSubcte)
    Public Sub New(pAccio As Integer, pMultiselect As Boolean, parentForm As Boolean, Optional pTitol As String = "")
        Me.accio = pAccio
        Me.multiselect = pMultiselect
        Me.isForm = parentForm
        Me.titol = pTitol
        _subcomptes = New List(Of PrefixSubcte)
    End Sub
    Public Overrides Function afegir(id As Integer) As Integer
        Dim p As PrefixSubcte
        p = DPrefixSubcompte.getPrefix(New PrefixSubcte)
        Return save(p)
        Return False
    End Function
    Public Overrides Function eliminar(id As Integer) As Boolean
        Dim p As PrefixSubcte
        p = ModelPrefixSubcompte.getObject(id)
        If p.id > -1 Then
            If MISSATGES.CONFIRM_REMOVE_SUBCOMPTE(p.toString) Then
                Return ModelPrefixSubcompte.remove(p)
            End If
        End If
        Return False
    End Function
    Public Overrides Function filtrar(txt As String) As DataList
        Return ModelPrefixSubcompte.getDataList(ModelPrefixSubcompte.getObjects(txt))
    End Function

    Public Overrides Function modificar(id As Integer) As Integer
        Dim p As PrefixSubcte
        p = DPrefixSubcompte.getPrefix(ModelPrefixSubcompte.getObject(id))
        Return save(p)
        Return False
    End Function

    Public Overrides Function seleccionar(ids As List(Of Integer)) As Boolean
        Dim i As Integer
        subcomptes = New List(Of PrefixSubcte)
        If ids.Count >= 0 Then
            For Each i In ids
                subcomptes.Add(ModelPrefixSubcompte.getObject(i))
            Next
            Return True
        End If
        Return False
    End Function
    Private Function save(obj As PrefixSubcte) As Integer
        If Not obj Is Nothing Then
            If Not ModelPrefixSubcompte.exist(obj) Then
                Return ModelPrefixSubcompte.save(obj)
            Else
                Throw New ExcepcioSql(ExcepcioSql.ERR_EXIST_CODI_REGISTRE)
            End If
        End If
        Return False
    End Function
    Protected Overrides Sub Finalize()
        MyBase.Finalize()
        subcomptes = Nothing
    End Sub

    Public Overrides Function filtrar(idParent As Integer, txt As String) As DataList
        Return Nothing
    End Function

    Public Overrides Function getRow(id As Integer) As ListViewItem
        Throw New NotImplementedException()
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
