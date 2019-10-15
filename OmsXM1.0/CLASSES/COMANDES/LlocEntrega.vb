Option Explicit On
Public Class LlocEntrega
    Inherits Base
    Public Property direccio As String
    Public Property codiPostal As String
    Public Property poblacio As String
    Public Property provincia As Provincia
    Public Property pais As Pais
    Public Property estat As Boolean
    Public Property projectes As List(Of Projecte)
    Public Sub New()
        _pais = New Pais
        _provincia = New Provincia
        _projectes = New List(Of Projecte)
        estat = True
    End Sub

    Public Sub New(pId As String, pNom As String)
        Me.id = pId
        Me.nom = pNom
        pais = New Pais
        provincia = New Provincia
        estat = True
    End Sub
    Public Function copy() As LlocEntrega
        copy = New LlocEntrega
        copy.id = Me.id
        copy.projectes = _projectes
        copy.nom = Me.nom
        copy.direccio = _direccio
        copy.poblacio = _poblacio
        copy.pais = _pais
        copy.provincia = _provincia
        copy.codiPostal = _codiPostal
        copy.estat = _estat
    End Function
    Public Function equalsComanda(p As LlocEntrega) As Boolean
        If p IsNot Nothing Then
            If StrComp(p.poblacio, _poblacio, CompareMethod.Text) <> 0 Then Return False
            If StrComp(p.codiPostal, _codiPostal, CompareMethod.Text) <> 0 Then Return False
            If StrComp(p.direccio, _direccio, CompareMethod.Text) <> 0 Then Return False
            If Not provincia.Equals(p.provincia) Then Return False
        End If
        Return True
    End Function
    Protected Overrides Sub Finalize()
        pais = Nothing
        provincia = Nothing
        projectes = Nothing
        MyBase.Finalize()
    End Sub
End Class
