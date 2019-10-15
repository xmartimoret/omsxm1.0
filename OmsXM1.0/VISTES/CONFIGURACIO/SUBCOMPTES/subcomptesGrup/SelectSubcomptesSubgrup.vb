Option Explicit On
Public Class SelectSubcomptesSubgrup
    Inherits LVSubObjects1
    Friend Event selectObject(ByVal sg As SubcompteGrup)
    Private idGrupComptable As Integer
    Private idSubgrupComptable As Integer
    Public Sub New(pIdSubGrup As Integer, Optional pTitol As String = "", Optional pOrdre As Integer = 0)
        Me.idParent = pIdSubGrup
        Me.titol = pTitol
        Me.orderColumn = pOrdre
    End Sub
    Public Sub New(pIdGrupComptable As Integer, pIdSubGrupComptable As Integer, Optional pTitol As String = "", Optional pOrdre As Integer = 0)
        Me.idParent = pIdSubGrupComptable
        IdGrupComptable = pIdGrupComptable
        idSubgrupComptable = pIdSubGrupComptable
        Me.titol = pTitol
        Me.orderColumn = pOrdre
    End Sub

    Public Overrides Function eliminar(id As String) As Boolean
        Dim s As SubcompteGrup
        s = ModelSubcomptesGrup.getObject(id)
        If s IsNot Nothing Then
            If MISSATGES.CONFIRM_QUIT_SUBCOMPTEGRUP(s.ToString) Then

                Return ModelSubcomptesGrup.remove(s)
            End If
        End If
        Return False
    End Function
    Public Overrides Function modificar(id As String) As Boolean
        Dim s As SubcompteGrup
        s = DSubcompteSubgrup.getSubcompte(ModelSubcomptesGrup.getObject(id))
        Return save(s)
        Return False
    End Function

    Private Function save(obj As SubcompteGrup) As Boolean
        If Not obj Is Nothing Then
            Return ModelSubcomptesGrup.save(obj)
        End If
        Return False
    End Function
    Protected Overrides Sub Finalize()
        MyBase.Finalize()

    End Sub
    Public Overrides Function afegir(id As String, idParent As String) As Boolean
        Dim subcomptes As List(Of Subcompte), s As Subcompte, sbcteGrup As SubcompteGrup, subgrupComptable As Subgrup
        subcomptes = DSelectSubcomptes.getSubcomptes(idGrupComptable)
        subgrupComptable = ModelSubgrup.getObject(idSubgrupComptable)
        If Not subcomptes Is Nothing Then
            For Each s In subcomptes
                sbcteGrup = New SubcompteGrup
                sbcteGrup.idSubGrup = idParent
                sbcteGrup.idSubcompte = s.id
                sbcteGrup.nomSubcompte = s.nom
                sbcteGrup.codiSubcompte = s.codi
                sbcteGrup.esDespesaCompra = subgrupComptable.esDespesaCompra
                sbcteGrup.esDespesaVariable = subgrupComptable.esDespesaVariable
                Call save(sbcteGrup)
            Next
            Return True
        End If
        Return False
    End Function

    Public Overrides Function filtrar(id As String, txt As String) As DataList
        Return ModelSubcomptesGrup.getDataList(ModelSubcomptesGrup.getObjects(id, txt))
    End Function

    Public Overrides Function seleccionar(id As String) As Boolean
        Dim sg As SubcompteGrup
        sg = ModelSubcomptesGrup.getObject(id)
        If sg IsNot Nothing Then
            RaiseEvent selectObject(sg)
            Return True
        End If
        Return False
    End Function
End Class
