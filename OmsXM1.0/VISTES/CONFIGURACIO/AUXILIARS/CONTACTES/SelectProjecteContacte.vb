Option Explicit On
Public Class Selectprojectecontacte
    Inherits LVSubObjects
    Friend Property contactes As List(Of ProjecteContacte)
    Friend Property nomProjecte As String
    Public Sub New(pIdProjecte As Integer, pNomProjecte As String, Optional pTitol As String = "", Optional pOrdre As Integer = 0)
        Me.idParent = pIdProjecte
        _nomProjecte = pNomProjecte
        Me.titol = pTitol
        Me.orderColumn = pOrdre
        _contactes = New List(Of ProjecteContacte)
    End Sub
    Public Overrides Function afegir(id As Integer) As Boolean
        Dim contactes As List(Of Contacte), c As Contacte, result As Boolean
        contactes = DAuxiliars.getContactes()
        For Each c In contactes
            If Not ModelProjecteContacte.exist(id, c.id) Then
                result = save(New ProjecteContacte(id, c.id))
            End If
        Next
        Return result
    End Function
    Public Overrides Function eliminar(id As Integer) As Boolean
        Dim d As ProjecteContacte
        d = ModelProjecteContacte.getObject(Me.idParent, id)

        If d IsNot Nothing Then
            If MISSATGES.CONFIRM_REMOVE_PROJECTE_CONTACTE() Then
                Return ModelProjecteContacte.remove(d)
            End If
        End If
        Return False
    End Function

    Public Overrides Function modificar(id As Integer) As Boolean
        Dim c As Contacte, result As Boolean
        c = ModelContacte.getObject(id)
        c = DContacte.getContacte(c)
        If c IsNot Nothing Then
            If ModelContacte.save(c) Then
                result = True
            End If
        End If
        Return result
    End Function


    Private Function save(obj As ProjecteContacte) As Integer
        If Not obj Is Nothing Then
            Return ModelProjecteContacte.save(obj)
        End If
        Return False
    End Function
    Protected Overrides Sub Finalize()
        MyBase.Finalize()
        contactes = Nothing
    End Sub
    Public Overrides Function filtrar(id As Integer) As DataList
        Return ModelProjecteContacte.getDataList(ModelProjecteContacte.getObjects(id))
    End Function
End Class

