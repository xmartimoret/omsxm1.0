Public Class Proveidor
    Inherits Base

    Public Property nomFiscal As String
    Public Property direccio As String
    Public Property poblacio As String
    Public Property codiPostal As String
    Public Property dataAlta As String
    Public Property dataBaixa As String
    Public Property actiu As Boolean = True
    Public Property pais As Pais
    Public Property provincia As Provincia
    Public Property tipusPagament As TipusPagament
    Public Property iban1 As String
    Public Property iban2 As String
    Public Property iban3 As String
    Public Property email As String
    Public Property codiComptable As String
    Public Property contactes As List(Of ProveidorCont)
    Public Property anotacions As List(Of proveidorAnotacio)
    Public Property idContacteActual As Integer
    Public Sub New()
        _actiu = True
        _pais = New Pais
        _provincia = New Provincia
        _tipusPagament = New TipusPagament
        _contactes = New List(Of ProveidorCont)
        _anotacions = New List(Of proveidorAnotacio)
    End Sub
    Public Sub New(pId As Integer, pCif As String, pNom As String, pNomFiscal As String, pDireccio As String, pPoblacio As String)
        Me.id = pId
        Me.codi = pCif
        Me.ordre = pNom
        Me.nom = pNom
        _nomFiscal = pNomFiscal
        _direccio = pDireccio
        _poblacio = pPoblacio
        _pais = New Pais
        _provincia = New Provincia
        _tipusPagament = New TipusPagament
        _contactes = New List(Of ProveidorCont)
        _actiu = True
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
        _contactes = New List(Of ProveidorCont)
        _actiu = True
    End Sub
    Public ReadOnly Property contacteActual As ProveidorCont
        Get
            Return _contactes.Find(Function(x) x.id = idContacteActual)
        End Get
    End Property
    Public Function getContacte(p As String) As ProveidorCont
        Dim ps() As String
        If p <> "" Then
            ps = Split(p, " - ")
            For Each pc As ProveidorCont In _contactes
                If UBound(ps) > 0 Then
                    If StrComp(ps(0), pc.departament, CompareMethod.Text) = 0 And StrComp(ps(1), pc.nom, CompareMethod.Text) = 0 Then
                        Return pc
                    End If
                End If
                If StrComp(ps(0), pc.nom, CompareMethod.Text) = 0 Then
                    Return pc
                End If
                If StrComp(ps(0), pc.departament, CompareMethod.Text) = 0 Then
                    Return pc
                End If
            Next
        End If
        Return Nothing
    End Function

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
        copy.codiComptable = _codiComptable
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
    Public Function isAnotacioActiva() As Boolean
        Dim a As proveidorAnotacio
        For Each a In anotacions
            If a.estat Then Return True
        Next
        Return False
    End Function
    Public Function getAnotacions() As String
        Dim a As proveidorAnotacio
        getAnotacions = ""
        For Each a In anotacions
            getAnotacions = getAnotacions & a.nom & vbCrLf
        Next
    End Function
    Public Function getAnotacionsActives() As String
        Dim a As proveidorAnotacio
        getAnotacionsActives = ""
        For Each a In anotacions
            If a.estat Then getAnotacionsActives = getAnotacionsActives & a.notes & vbCrLf
        Next
    End Function
    Public Overrides Function ToString() As String
        Return nom
    End Function
    Public Function toStringComanda()
        Dim texte As String = ""
        texte = "  " & _direccio & " " & _codiPostal
        If Not IsNothing(_poblacio) Then texte = texte & "   " & _poblacio
        If Not IsNothing(_provincia) Then texte = texte & vbCrLf & _provincia.nom
        If Not IsNothing(_pais) Then texte = texte & "-(" & _pais.nom & ")"
        Return texte
    End Function
    Public Function toTarget() As String
        Dim texte As String
        texte = _direccio & vbCrLf & _codiPostal
        If Not IsNothing(_poblacio) Then texte = texte & "-" & _poblacio
        If Not IsNothing(_provincia) Then texte = texte & vbCrLf & _provincia.nom
        If Not IsNothing(_pais) Then texte = texte & "-(" & _pais.nom & ")"
        Return texte
    End Function
    Public Function getCorreoComanda() As String
        Dim c As ProveidorCont
        If _email <> "" Then Return _email
        For Each c In contactes
            If c.email <> "" Then Return c.email
        Next
        Return ""
    End Function
    Protected Overrides Sub Finalize()
        _pais = Nothing
        _provincia = Nothing
        _tipusPagament = Nothing
        _contactes = Nothing
        _anotacions = Nothing
        MyBase.Finalize()
    End Sub
End Class
