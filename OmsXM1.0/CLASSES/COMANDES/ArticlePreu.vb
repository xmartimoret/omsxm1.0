Public Class ArticlePreu
    Inherits Base
    Public Property idArticle As Integer
    Public Property idProveidor As Integer
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
    Public Overrides Function Equals(obj As Object) As Boolean
        If obj.idArticle <> _idArticle Then Return False
        If obj.idProveidor <> _idProveidor Then Return False
        If obj.base > _base + 0.02 And obj.base < base - 0.02 Then Return False
        If obj.descompte <> _descompte Then Return False
        Return True
    End Function

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
