Option Explicit On
Public Class Seccio
    Inherits Base
    Public Property idEmpresa As Integer
    Public Property codiEmpresa As String
    Public Property fullaSaldo As String
    Public Property fullaInforme As String
    Public Property actiu As Boolean
    Public Property centres As List(Of Centre)
    Public Property projectes As List(Of Projecte)
    Public Property grupsComptables As List(Of SeccioGrup)
    Public Property subGrups As List(Of Subgrup)
    Public Property importsSubgrup As Collection
    Public Property importsBudget As Collection
    Public Sub New()
        _centres = New List(Of Centre)
        _projectes = New List(Of Projecte)
        _grupsComptables = New List(Of SeccioGrup)
        _subGrups = New List(Of Subgrup)
        _importsSubgrup = New Collection
        _importsBudget = New Collection
        _fullaSaldo = ""
        _fullaInforme = ""
    End Sub
    Public Sub New(pId As Integer, pIdEmpresa As Integer, pCodi As String, pNom As String, pNotes As String, pOrdre As String, pFSaldo As String, pFinforme As String, pActiu As Boolean)
        Me.id = pId
        Me.idEmpresa = pIdEmpresa
        Me.codi = pCodi
        Me.nom = pNom
        Me.notes = pNotes
        Me.ordre = pOrdre
        Me.fullaInforme = pFinforme
        Me.fullaSaldo = pFSaldo
        Me.actiu = pActiu
        _centres = New List(Of Centre)
        _projectes = New List(Of Projecte)
        _grupsComptables = New List(Of SeccioGrup)
        _subGrups = New List(Of Subgrup)
        _importsSubgrup = New Collection
        _importsBudget = New Collection
    End Sub
    Public Sub New(pId As Integer, pIdEmpresa As Integer, pCodi As String, pNom As String, pNotes As String, pOrdre As String, pFSaldo As String, pFinforme As String, pActiu As Boolean, pCentres As List(Of Centre), pGrupsComptables As List(Of SeccioGrup))
        Me.id = pId
        Me.idEmpresa = pIdEmpresa
        Me.codi = pCodi
        Me.nom = pNom
        Me.notes = pNotes
        Me.ordre = pOrdre
        Me.fullaInforme = pFinforme
        Me.fullaSaldo = pFSaldo
        Me.actiu = pActiu
        _centres = pCentres
        _grupsComptables = pGrupsComptables
        _projectes = New List(Of Projecte)
        _subGrups = New List(Of Subgrup)
        _importsSubgrup = New Collection
        _importsBudget = New Collection
    End Sub

    Public Sub setValorsSubgrupsDetall()
        Dim sg As Subgrup, ims As ImportMesSubgrup
        _subGrups = ModelSubgrup.copyObjects
        For Each sg In subGrups
            For Each ims In _importsSubgrup
                If ims.idSubgrup = sg.id Then
                    sg.importsDetall.Add(ims)
                End If
            Next ims
        Next sg
        sg = Nothing
        ims = Nothing
    End Sub
    Public Sub setValorsSubgrupsBudget()
        Dim sg As Subgrup, ims As ImportMesSubgrup
        _subGrups = ModelSubgrup.copyObjects
        For Each sg In subGrups
            For Each ims In _importsBudget
                If ims.idSubgrup = sg.id Then
                    sg.importsBudget.Add(ims)
                End If
            Next ims
        Next sg
        sg = Nothing
        ims = Nothing
    End Sub
    Public ReadOnly Property copy As Seccio
        Get
            Dim c As Centre
            copy = New Seccio
            copy.actiu = _actiu
            For Each c In _centres
                copy.centres.Add(c.copy)
            Next
            copy.codi = Me.codi
            copy.codiEmpresa = _codiEmpresa
            copy.fullaInforme = _fullaInforme
            copy.fullaSaldo = _fullaSaldo
            copy.grupsComptables = _grupsComptables
            copy.id = Me.id
            copy.idEmpresa = _idEmpresa
            copy.importsBudget = _importsBudget
            copy.importsSubgrup = _importsSubgrup
            copy.nom = Me.nom
            copy.notes = Me.notes
            copy.ordre = Me.ordre
            copy.subGrups = _subGrups
            c = Nothing
        End Get
    End Property

    Protected Overrides Sub Finalize()
        _centres = Nothing
        _grupsComptables = Nothing
        _subGrups = Nothing
        _importsSubgrup = Nothing
        _importsBudget = Nothing
        MyBase.Finalize()
    End Sub
End Class
