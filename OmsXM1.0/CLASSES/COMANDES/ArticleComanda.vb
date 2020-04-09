﻿Public Class articleComanda
    Inherits Base
    Public Property idComanda As Integer
    Public Property pos As Integer
    Public Property quantitat As Decimal
    Public Property unitat As Unitat
    Public Property preu As Double
    Public Property tpcDescompte As Double
    Public Property tIva As TipusIva
    Public Sub New()
        _quantitat = 0
        _unitat = New Unitat
        _tIva = New TipusIva
    End Sub
    Public Sub New(pId As Integer, pIdComanda As Integer, pPos As Integer, pCodi As String, pNom As String)
        Me.id = pId
        Me.codi = pCodi
        Me.nom = pNom
        _idComanda = pIdComanda
        _pos = pPos
        _quantitat = 0
        _unitat = New Unitat
        _tIva = New TipusIva
    End Sub
    Public Sub New(pId As Integer, pIdComanda As Integer, pPos As Integer, pCodi As String, pNom As String, pQuantitat As Double, pUnitat As Unitat, pPreu As Double, pTIva As TipusIva)
        Me.id = pId
        Me.codi = pCodi
        Me.nom = pNom
        _idComanda = pIdComanda
        _pos = pPos
        'estic esborran l'article preu i article. ens caldrà guardar el rpe
        _preu = pPreu
        _quantitat = pQuantitat
        _unitat = pUnitat
        _tIva = pTIva
    End Sub


    Public ReadOnly Property base As Double
        Get
            Return (preu - descompte) * quantitat
        End Get
    End Property
    Public ReadOnly Property descompte As Double
        Get
            Return ((_tpcDescompte / 100) * (preu))
        End Get
    End Property
    Public ReadOnly Property iva As Double
        Get
            If Not IsNothing(tIva) Then Return (base - descompte) * (tIva.impost / 100)
            Return 0

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
        copy.preu = _preu
        copy.tIva = _tIva
        copy.tpcDescompte = _tpcDescompte
    End Function

    ' nota ens cal tenir una referencia generica * i pot haver-hi dos o mes proveidors amb el mateix article. llavors a l'escollir 
    ' l'article per referencia ens cal presentar les opcions.
    ' nota. ens ha de deixar modificar la descripció de l'article, el preu el descompte i l'iva. 
    ' la descripció i l'iva es modifiquen automaticament o no des del mateix article. 
    ' en canvi el preu i el descompte ens cal actualitzar el llistat de preus amb el seu proveidor.
    ' que serà el proveidor de la comanda.

    ' també cal tenir en compte les unitats, que s'ha de poder canviar, tot i que per defecte pot venir des de l'article

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
        _quantitat = Nothing
        _unitat = Nothing
        _tIva = Nothing
    End Sub
End Class
