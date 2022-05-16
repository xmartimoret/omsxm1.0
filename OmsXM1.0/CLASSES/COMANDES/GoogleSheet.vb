Public Class GoogleSheet
    Public Property id As String
    Public Property nom As String
    Public Property numFiles As Long
    Public Property numColumnes As Integer
    Public Sub New(pId As String, pNom As String, pRows As Long, pNumColumnes As Integer)
        _id = pId
        _nom = pNom
        _numFiles = pRows
        numColumnes = pNumColumnes
    End Sub
    'Public Sub New(pId As String, pNom As String, pFilaActual As Long, pRows As Long, pTaula As String)
    '    _id = pId
    '    _nom = pNom
    '    _filaActual = pFilaActual
    '    _numFiles = pRows
    '    _taula = pTaula
    'End Sub
    'Public Sub New(pId As String, pNom As String, pFilaActual As Long, pRows As Long, pIdObjecte As Long, pTaula As String)
    '    _id = pId
    '    _nom = pNom
    '    _filaActual = pFilaActual
    '    _numFiles = pRows
    '    _idObjecteActual = pIdObjecte
    '    _taula = pTaula
    'End Sub

    Public Function getCharColumn() As String
        If numColumnes / 26 <= 1 Then
            Return Mid("abcdefghijklmnopqrstuvwxyz", numColumnes, 1)
        Else
            Return Mid("abcdefghijklmnopqrstuvwxyz", numColumnes \ 26, 1) & Mid("abcdefghijklmnopqrstuvwxyz", numColumnes Mod 26, 1)
        End If
    End Function
End Class
