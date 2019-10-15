Public Class Contacte
    Inherits Base
    Public Property cognom1 As String
    Public Property cognom2 As String
    Public Property direccio As String
    Public Property codiPostal As String
    Public Property poblacio As String
    Public Property provincia As Provincia
    Public Property pais As Pais
    Public Property estat As Boolean
    Public Property telefon As String
    Public Property email As String
    Public Property projectes As List(Of Projecte)
    Public Sub New()
        _pais = New Pais
        _projectes = New List(Of Projecte)
        _provincia = New Provincia
        estat = True
    End Sub
    Public Sub New(pId As String, pNom As String, pCognom1 As String, pCognom2 As String)
        Me.id = pId
        Me.nom = pNom
        Me.cognom1 = pCognom1
        Me.cognom2 = pCognom2
        _projectes = New List(Of Projecte)
        _pais = New Pais
        _provincia = New Provincia
        estat = True
    End Sub
    Public Sub New(pId As String, pNom As String, pProjectes As List(Of Projecte))
        Me.id = pId
        Me.nom = pNom
        _projectes = pProjectes
        _pais = New Pais
        _provincia = New Provincia
        estat = True
    End Sub
    Public Function copy() As Contacte
        copy = New Contacte
        copy.id = Me.id
        copy.projectes = _projectes
        copy.nom = Me.nom
        copy.cognom1 = _cognom1
        copy.cognom2 = _cognom2
        copy.direccio = _direccio
        copy.poblacio = _poblacio
        copy.pais = _pais
        copy.provincia = _provincia
        copy.codiPostal = _codiPostal
        copy.estat = _estat
        copy.telefon = _telefon
        copy.email = _email
    End Function
    Public Function equalsComanda(p As Contacte) As Boolean
        If p IsNot Nothing Then
            If StrComp(p.poblacio, _poblacio, CompareMethod.Text) <> 0 Then Return False
            If StrComp(p.codiPostal, _codiPostal, CompareMethod.Text) <> 0 Then Return False
            If StrComp(p.direccio, _direccio, CompareMethod.Text) <> 0 Then Return False
            If StrComp(p.email, _email, CompareMethod.Text) <> 0 Then Return False
            If Not provincia.Equals(p.provincia) Then Return False
        End If
        Return True
    End Function
    Public Overrides Function tostring() As String
        Return Me.nom & " " & _cognom1 & " " & _cognom2
    End Function
    Protected Overrides Sub Finalize()
        _pais = Nothing
        _provincia = Nothing
        _projectes = Nothing
        MyBase.Finalize()
    End Sub
End Class
