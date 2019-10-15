Option Explicit On
Public Class Empresa
    Inherits Base
    Public Property cif As String
    Public Property empresesContaplus As List(Of Contaplus)
    Public Property seccions As List(Of Seccio)
    Public Property participacio As Integer
    Public Property esModeLocal As Boolean
    Public Sub New()
        _seccions = New List(Of Seccio)
        _empresesContaplus = New List(Of Contaplus)
    End Sub

    Public Sub New(pId As Integer, pCodi As String, pOrdre As String, pCif As String, pNom As String, PParticipa As Integer)
        Me.id = pId
        Me.codi = pCodi
        _cif = pCif
        Me.ordre = pOrdre
        Me.nom = pNom
        _participacio = PParticipa
        _seccions = New List(Of Seccio)
        _empresesContaplus = New List(Of Contaplus)
    End Sub
    Public Sub New(pId As Integer, pCodi As String, pOrdre As String, pCif As String, pNom As String, PParticipa As Integer, pEmpresesContaplus As List(Of Contaplus), pSeccions As List(Of Seccio))
        Me.id = pId
        Me.codi = pCodi
        _cif = pCif
        Me.ordre = pOrdre
        Me.nom = pNom
        _participacio = PParticipa
        _empresesContaplus = pEmpresesContaplus
        _seccions = pSeccions
    End Sub
    Public ReadOnly Property centres() As List(Of Centre)
        Get
            Dim s As Seccio, c As Centre
            centres = New List(Of Centre)
            For Each s In _seccions
                For Each c In s.centres
                    centres.Add(c)
                Next c
            Next s
            s = Nothing
            c = Nothing
        End Get
    End Property
    Public ReadOnly Property copy As Empresa
        Get
            copy = New Empresa
            copy.id = Me.id
            copy.codi = Me.codi
            copy.cif = _cif
            copy.ordre = Me.ordre
            copy.nom = Me.nom
            copy.participacio = _participacio
            copy.empresesContaplus = _empresesContaplus
            copy.seccions = _seccions
        End Get
    End Property
    Protected Overrides Sub Finalize()
        _seccions = Nothing
        _empresesContaplus = Nothing
        MyBase.Finalize()
    End Sub
End Class
