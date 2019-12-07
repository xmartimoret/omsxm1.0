Public Class articleComanda
    Inherits Base
    Public Property idComanda As Integer
    Public Property pos As Integer
    Public Property quantitat As Decimal
    Public Property unitat As Unitat
    Private Property _article As article 'referencia, descripcio, preu, descompte, iva
    Public Property preu As ArticlePreu
    Public Property tIva As TipusIva


    Public Sub New()
        _article = New article
        _preu = New ArticlePreu
        _quantitat = 0
        _unitat = New Unitat
        _tIva = New TipusIva
    End Sub
    Public Sub New(pId As Integer, pIdComanda As Integer, pPos As Integer, pNom As String)
        Me.id = pId

        Me.nom = pNom
        _idComanda = pIdComanda
        _pos = pPos
        _article = New article
        _preu = New ArticlePreu
        _quantitat = 0
        _unitat = New Unitat
        _tIva = New TipusIva
    End Sub
    Public Sub New(pId As Integer, pIdComanda As Integer, pPos As Integer, pNom As String, pArticle As article, pQuantitat As Double, pUnitat As Unitat, pPreu As ArticlePreu, pTIva As TipusIva)
        Me.id = pId
        Me.nom = pNom
        _idComanda = pIdComanda
        _pos = pPos
        _article = pArticle
        _preu = pPreu
        _quantitat = pQuantitat
        _unitat = pUnitat
        _tIva = pTIva
    End Sub


    Public ReadOnly Property base As Double
        Get
            Return preu.preu * quantitat
        End Get
    End Property
    Public ReadOnly Property descompte As Double
        Get
            Return ((preu.descompte / 100) * (base))
        End Get
    End Property
    Public ReadOnly Property iva As Double
        Get
            Return (base - descompte) * (tIva.impost / 100)
        End Get
    End Property
    Public ReadOnly Property total As Double
        Get
            Return base - descompte + iva
        End Get
    End Property
    Public Function copy() As articleComanda
        copy = New articleComanda
        copy.id = Me.id
        copy.nom = Me.nom
        copy.codi = Me.codi
        copy.idComanda = _idComanda
        copy.pos = _pos
        copy.quantitat = _quantitat
        copy.unitat = _unitat
        copy.article = _article 'referencia, descripcio, preu, descompte, iva
        copy.preu = _preu
        copy.tIva = _tIva

    End Function
    Public Property article() As article
        Get
            Return _article
        End Get
        Set(value As article)
            _article = value
            _unitat = value.unitat
            nom = value.nom
            codi = value.codi
        End Set
    End Property
    ' nota ens cal tenir una referencia generica * i pot haver-hi dos o mes proveidors amb el mateix article. llavors a l'escollir 
    ' l'article per referencia ens cal presentar les opcions.
    ' nota. ens ha de deixar modificar la descripció de l'article, el preu el descompte i l'iva. 
    ' la descripció i l'iva es modifiquen automaticament o no des del mateix article. 
    ' en canvi el preu i el descompte ens cal actualitzar el llistat de preus amb el seu proveidor.
    ' que serà el proveidor de la comanda.

    ' també cal tenir en compte les unitats, que s'ha de poder canviar, tot i que per defecte pot venir des de l'article

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
        _article = Nothing
        _preu = Nothing
        _quantitat = Nothing
        _unitat = Nothing
        _tIva = Nothing
    End Sub
End Class
