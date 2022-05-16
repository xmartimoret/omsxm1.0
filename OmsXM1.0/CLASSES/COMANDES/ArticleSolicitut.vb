Public Class ArticleSolicitut

    Inherits Base
    Public Property idSolicutComanda As Integer
    Public Property pos As Integer
    Public Property quantitat As Decimal
    Public Property unitat As String = ""
    Public Property preu As Double
    Public Property tpcDescompte As Double
    Public Property descripcio As List(Of String)
    Public Sub New()
        _quantitat = 0
        _descripcio = New List(Of String)
    End Sub
    Public Sub New(pId As Integer, pidSolicutComanda As Integer, pPos As Integer, pCodi As String, pNom As String)
        Me.id = pId
        Me.codi = pCodi
        Me.nom = pNom
        _idSolicutComanda = pidSolicutComanda
        _pos = pPos
        _quantitat = 0
        _descripcio = New List(Of String)
    End Sub
    Public Sub New(pId As Integer, pidSolicutComanda As Integer, pPos As Integer, pCodi As String, pNom As String, pQuantitat As Double, pUnitat As String, pPreu As Double)
        Me.id = pId
        Me.codi = pCodi
        Me.nom = pNom
        _idSolicutComanda = pidSolicutComanda
        _pos = pPos
        _quantitat = pQuantitat
        _unitat = pUnitat
        _descripcio = New List(Of String)
    End Sub


    Public ReadOnly Property base As Double
        Get
            Return (preu - descompte) * quantitat
        End Get
    End Property
    Public ReadOnly Property descompte As Double
        Get
            Return ((_tpcDescompte) * (preu))
        End Get
    End Property

    Public ReadOnly Property total As Double
        Get
            Return base - descompte
        End Get
    End Property
    Public Function copy() As ArticleSolicitut
        copy = New ArticleSolicitut
        copy.id = Me.id
        copy.nom = Me.nom
        copy.codi = Me.codi
        copy.idSolicutComanda = _idSolicutComanda
        copy.pos = _pos
        copy.quantitat = _quantitat
        copy.unitat = _unitat
        copy.preu = _preu
        copy.tpcDescompte = _tpcDescompte
        copy.descripcio = _descripcio
    End Function

    Protected Overrides Sub Finalize()
            MyBase.Finalize()
            _quantitat = Nothing
        _descripcio = Nothing
    End Sub
    End Class


