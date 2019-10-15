Public Class ArticlePreu
    Inherits Base
    Public Property idArticle
    Public Property idProveidor
    Public Property data As Date
    Public Property base As Double
    Public Property descompte As Integer
    Public Sub New()

    End Sub
    Public Sub New(pIdArticle As Integer)
        idArticle = pIdArticle
    End Sub
    Public Sub New(pId As Integer, pIdArticle As Integer, pIdProveidor As Integer, pData As Date, pBase As Double, pDescompte As Integer)
        Me.id = pId
        _idArticle = pIdArticle
        _idProveidor = pIdProveidor
        _data = pData
        _base = pBase
        _descompte = pDescompte
    End Sub
    Public ReadOnly Property preu As Double
        Get
            Return _base - _base * (_descompte / 100)
        End Get
    End Property
    Public Function copy() As ArticlePreu
        copy = New ArticlePreu
        copy.id = Me.id
        copy.data = _data
        copy.idArticle = _idArticle
        copy.idProveidor = _idProveidor
        copy.base = _base
        copy.descompte = _descompte
    End Function
End Class
