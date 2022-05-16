Public Class article
    Inherits Base
    Public Property familia As Familia
    Public Property unitat As Unitat
    Public Property fabricant As Fabricant
    Public Property iva As TipusIva
    Public Property preusProveidors As List(Of ArticlePreu)
    Public Property actiu As Boolean = True
    Public Sub New()
        _familia = New Familia
        _unitat = New Unitat
        _fabricant = New Fabricant
        _iva = New TipusIva
        _preusProveidors = New List(Of ArticlePreu)
    End Sub
    Public Sub New(pId As Integer, pCodi As String, pNom As String, pNotes As String)
        Me.id = pId
        Me.codi = pCodi
        Me.nom = pNom
        Me.notes = pNotes
        _familia = New Familia
        _unitat = New Unitat
        _fabricant = New Fabricant
        _iva = New TipusIva
        _preusProveidors = New List(Of ArticlePreu)
    End Sub
    Public Sub New(pId As Integer, pCodi As String, pNom As String, pNotes As String, pUni As Unitat, pfamilia As Familia)
        Me.id = pId
        Me.codi = pCodi
        Me.nom = pNom
        Me.notes = pNotes
        _unitat = pUni
        _familia = pfamilia
        _fabricant = New Fabricant
        _iva = New TipusIva
        _preusProveidors = New List(Of ArticlePreu)
    End Sub
    Public Sub New(pId As Integer, pCodi As String, pNom As String, pNotes As String, pUni As Unitat, pfamilia As Familia, pFabricant As Fabricant, pIva As TipusIva)
        Me.id = pId
        Me.codi = pCodi
        Me.nom = pNom
        Me.notes = pNotes
        _unitat = pUni
        _familia = pfamilia
        _fabricant = pFabricant
        _iva = pIva
    End Sub
    Public Function copy() As article
        copy = New article
        copy.id = Me.id
        copy.codi = Me.codi
        copy.nom = Me.nom
        copy.familia = _familia
        copy.unitat = _unitat
        copy.fabricant = _fabricant
        copy.iva = _iva
    End Function
    Public Function getUltimPreu(idProveidor As Integer) As ArticlePreu
        Dim ap As ArticlePreu, temp As ArticlePreu
        temp = New ArticlePreu
        For Each ap In preusProveidors
            If ap.idProveidor = idProveidor Or idProveidor = -1 Then
                If IsNothing(temp) Then
                    temp = ap
                Else
                    If temp.data <= ap.data Then
                        temp = ap
                    End If
                End If
            End If
        Next
        getUltimPreu = temp
        temp = Nothing
        ap = Nothing
    End Function
    Protected Overrides Sub Finalize()
        _familia = Nothing
        _fabricant = Nothing
        _unitat = Nothing
        _iva = Nothing
        _preusProveidors = Nothing
        MyBase.Finalize()
    End Sub
End Class
