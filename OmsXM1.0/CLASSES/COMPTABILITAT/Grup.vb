Public Class Grup
    Inherits Base
    Public Property actualitzat As Boolean
    Public Property resum As Boolean
    Private _subgrups As List(Of Subgrup)
    Public Sub New()
        _subgrups = New List(Of Subgrup)
        _actualitzat = False
    End Sub
    Public Sub New(pId As Integer, pCodi As String, pNom As String, pNotes As String, pOrdre As String, pResum As Boolean)
        _subgrups = New List(Of Subgrup)
        _actualitzat = False
        Me.id = pId
        Me.codi = pCodi
        Me.nom = pNom
        Me.notes = pNotes
        Me.ordre = pOrdre
        _resum = pResum
    End Sub
    Public Sub New(pId As Integer, pCodi As String, pNom As String, pNotes As String, pOrdre As String, pResum As Boolean, pSubgrups As List(Of Subgrup))
        _subgrups = pSubgrups
        _actualitzat = False
        Me.id = pId
        Me.codi = pCodi
        Me.nom = pNom
        Me.notes = pNotes
        Me.ordre = pOrdre
        _resum = pResum
    End Sub
    Public ReadOnly Property copy() As Grup
        Get
            copy = New Grup
            copy.id = Me.id
            copy.actualitzat = _actualitzat
            copy.nom = Me.nom
            copy.codi = Me.codi
            copy.notes = Me.notes
            copy.resum = _resum
            copy.subgrups = _subgrups
            copy.ordre = Me.ordre
        End Get
    End Property
    Public Property subgrups() As List(Of Subgrup)
        Get
            subgrups = _subgrups
            _actualitzat = True
        End Get
        Set(value As List(Of Subgrup))
            _subgrups = value
        End Set
    End Property
    Public ReadOnly Property saldo(mes As Integer, isValorAbsolut As Boolean)
        Get
            Dim sg As Subgrup, e As EnterLlarg
            e = New EnterLlarg
            For Each sg In subgrups
                e.valordecimal = sg.saldo(mes, isValorAbsolut)
            Next sg
            saldo = e.valordecimal
            sg = Nothing
            e = Nothing
        End Get
    End Property
    Protected Overrides Sub Finalize()
        _subgrups = Nothing
        MyBase.Finalize()
    End Sub
End Class
