Public Class CodiComanda
    Inherits Base

    Public Property serie As Integer
    Public Property idEmpresa As Integer
    Public Overloads Property codi As Long
    Public Property codiProjecte As String = ""
    Public Sub New()

    End Sub

    Public Sub New(pID As Integer, pSerie As Integer, pCodi As Long, pIdempresa As Integer, pCodiProjecte As String, Optional pNotes As String = "")
        Me.id = pID
        _serie = pSerie
        _codi = pCodi
        _idEmpresa = pIdempresa
        _codiProjecte = pCodiProjecte
        Me.notes = pNotes
    End Sub
    Public Function copy() As CodiComanda
        copy = New CodiComanda
        copy.id = Me.id
        copy.codi = _codi
        copy.serie = _serie
        copy.codiProjecte = _codiProjecte
        copy.nom = Me.nom
        copy.idEmpresa = _idEmpresa
    End Function
    Private Function codiToString() As String
        If _codi > 99999 Then
            Return Me.codi
        Else
            Return CONFIG.getNumStringDigits(_codi, 5)
        End If
    End Function
    Public Overrides Function toString() As String
        Return Right(_serie, 2) & "-" & codiToString() & "-" & Right(_codiProjecte, 4) & "-" & CONFIG.getDosDigits(idEmpresa)
    End Function
    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class
