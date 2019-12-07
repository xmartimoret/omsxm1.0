Public Class Proveidor
    Inherits Base

    Public Property nomFiscal As String
    Public Property direccio As String
    Public Property poblacio As String
    Public Property codiPostal As String
    Public Property dataAlta As String
    Public Property dataBaixa As String
    Public Property actiu As Boolean
    Public Property pais As Pais
    Public Property provincia As Provincia
    Public Property tipusPagament As TipusPagament
    Public Property iban1 As String
    Public Property iban2 As String
    Public Property iban3 As String
    Public Property email As String
    Public Property contactes As List(Of ProveidorCont)
    Public Property idContacteActual As Integer
    Public Sub New()
        actiu = True
        pais = New Pais
        provincia = New Provincia
        tipusPagament = New TipusPagament
        contactes = New List(Of ProveidorCont)
    End Sub
    Public Sub New(pId As Integer, pCif As String, pNom As String, pNomFiscal As String, pDireccio As String, pPoblacio As String)
        Me.id = pId
        Me.codi = pCif
        Me.ordre = pNom
        Me.nom = pNom
        _nomFiscal = pNomFiscal
        _direccio = pDireccio
        _poblacio = pPoblacio
        pais = New Pais
        provincia = New Provincia
        tipusPagament = New TipusPagament
        contactes = New List(Of ProveidorCont)
        actiu = True
    End Sub
    Public Sub New(pId As Integer, pCif As String, pNom As String, pNomFiscal As String, pDireccio As String, pPoblacio As String, pPais As Pais, pProvincia As Provincia, pTipusPagament As TipusPagament)
        Me.id = pId
        Me.codi = pCif
        Me.ordre = pNom
        Me.nom = pNom
        _nomFiscal = pNomFiscal
        _direccio = pDireccio
        _poblacio = pPoblacio
        _pais = pPais
        _provincia = pProvincia
        _tipusPagament = pTipusPagament
        contactes = New List(Of ProveidorCont)
        actiu = True
    End Sub
    Public ReadOnly Property contacteActual As ProveidorCont
        Get
            Return _contactes.Find(Function(x) x.id = idContacteActual)
        End Get
    End Property
    Public Function copy() As Proveidor
        copy = New Proveidor
        copy.id = Me.id
        copy.nom = Me.nom
        copy.codi = Me.codi
        copy.dataAlta = _dataAlta
        copy.dataBaixa = _dataBaixa
        copy.nomFiscal = _nomFiscal
        copy.direccio = _direccio
        copy.poblacio = _poblacio
        copy.pais = _pais
        copy.provincia = _provincia
        copy.tipusPagament = _tipusPagament
        copy.actiu = _actiu
        copy.codiPostal = _codiPostal
        copy.iban1 = _iban1
        copy.iban2 = _iban2
        copy.iban3 = _iban3
        copy.email = _email
        copy.contactes = _contactes
        copy.idContacteActual = _idContacteActual
    End Function
    Public Function equalsComanda(p As Proveidor) As Boolean
        If p IsNot Nothing Then
            If StrComp(p.poblacio, _poblacio, CompareMethod.Text) <> 0 Then Return False
            If StrComp(p.codiPostal, _codiPostal, CompareMethod.Text) <> 0 Then Return False
            If StrComp(p.direccio, _direccio, CompareMethod.Text) <> 0 Then Return False
            If StrComp(p.email, _email, CompareMethod.Text) <> 0 Then Return False
            If Not provincia.Equals(p.provincia) Then Return False
        End If
        Return True
    End Function
    Public Overrides Function ToString() As String
        Return nom
    End Function
    Public Function toTarget() As String
        Dim texte As String
        texte = _direccio & vbCrLf & _codiPostal
        If Not IsNothing(_poblacio) Then texte = texte & "-" & _poblacio
        If Not IsNothing(_provincia) Then texte = vbCrLf & _provincia.nom
        If Not IsNothing(_pais) Then texte = texte & "-(" & _pais.nom & ")"
        Return texte
    End Function
    Protected Overrides Sub Finalize()
        pais = Nothing
        provincia = Nothing
        tipusPagament = Nothing
        contactes = Nothing
        MyBase.Finalize()
    End Sub
End Class
