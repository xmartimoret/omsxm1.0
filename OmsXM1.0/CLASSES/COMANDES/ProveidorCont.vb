Public Class ProveidorCont
    Inherits Base
    Public Property idProveidor As Integer
    Public Property departament As String
    Public Property telefon1 As String
    Public Property telefon2 As String
    Public Property direccio As String
    Public Property poblacio As String
    Public Property provincia As Provincia
    Public Property pais As Pais
    Public Property codiPostal As String
    Public Property email As String
    Public Property actiu As Boolean
    Public Sub New()
        _provincia = New Provincia
        _pais = New Pais
    End Sub
    Public Sub New(pIdProveidor As Integer)
        _provincia = New Provincia
        _pais = New Pais
        _idProveidor = pIdProveidor
    End Sub
    Public Sub New(pId As Integer, pIdProveidor As String, pDepartament As String, pNom As String, pDireccio As String, pPoblacio As String, pCodiPostal As String)
        Me.id = pId
        _idProveidor = pIdProveidor
        _departament = pDepartament
        Me.ordre = pNom
        Me.nom = pNom
        _direccio = pDireccio
        _poblacio = pPoblacio
        _codiPostal = pCodiPostal
        _provincia = New Provincia
        _pais = New Pais
        actiu = True
    End Sub
    Public Sub New(pId As Integer, pIdProveidor As String, pDepartament As String, pNom As String, pDireccio As String, pPoblacio As String, pCodiPostal As String, pProvincia As Provincia, pPais As Pais, pTel1 As String, pTel2 As String, pCorreu As String, pNotes As String)
        Me.id = pId
        _idProveidor = pIdProveidor
        _departament = pDepartament
        Me.ordre = pNom
        Me.nom = pNom
        _direccio = pDireccio
        _poblacio = pPoblacio
        _pais = pPais
        _provincia = pProvincia
        _telefon1 = pTel1
        _telefon2 = pTel1
        _email = pCorreu
        Me.notes = pNotes
        actiu = True
    End Sub
    Public Function copy() As ProveidorCont
        copy = New ProveidorCont
        copy.id = Me.id
        copy.nom = Me.nom
        copy.idProveidor = _idProveidor
        copy.ordre = Me.ordre
        copy.departament = _departament
        copy.direccio = _direccio
        copy.poblacio = _poblacio
        copy.pais = _pais
        copy.provincia = _provincia
        copy.codi = Me.codi
        copy.codiPostal = _codiPostal
        copy.telefon1 = _telefon1
        copy.telefon2 = _telefon2
        copy.email = _email
        copy.notes = Me.notes
        Me.actiu = _actiu
    End Function
    Public Function equalsComanda(p As ProveidorCont) As Boolean
        If p IsNot Nothing Then
            If StrComp(p.telefon1, _telefon1, CompareMethod.Text) <> 0 Then Return False
            If StrComp(p.email, _email, CompareMethod.Text) <> 0 Then Return False
        End If
        Return True
    End Function
    Public Overrides Function toString() As String
        Return _departament & " " & Me.nom
    End Function
    Protected Overrides Sub Finalize()
        pais = Nothing
        provincia = Nothing
        MyBase.Finalize()
    End Sub
End Class
