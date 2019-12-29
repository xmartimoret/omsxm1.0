Public Class Comanda
    Inherits Base
    Private Const delimitador As String = ";"
    Friend Property empresa As Empresa
    Friend Property proveidor As Proveidor
    Friend Property contacteProveidor As ProveidorCont
    Friend Property projecte As Projecte
    Friend Property contacte As Contacte
    Friend Property magatzem As LlocEntrega
    Friend Property data As Date
    Friend Property dataEntrega As Date
    Friend Property dataMuntatge As Date
    Friend Property retencio As String
    Friend Property interAval As String
    Friend Property nOferta As String
    Friend Property tipusPagament As TipusPagament
    Friend Property dadesBancaries As String
    Friend Property articles As List(Of articleComanda)
    Friend Property ports As String
    Friend Property responsable As String
    Friend Property director As String
    Public Sub New()

    End Sub
    Public Sub New(pId As Integer, pCodi As String, pProveidor As Proveidor, pEmpresa As Empresa, pProjecte As Projecte)
        Me.id = pId
        Me.codi = pCodi
        _proveidor = pProveidor
        _empresa = pEmpresa
        _projecte = pProjecte
    End Sub
    Public Sub New(pId As Integer, pCodi As String, pProveidor As Proveidor, pEmpresa As Empresa, pProjecte As Projecte, pResponsable As String, pDirector As String)
        Me.id = pId
        Me.codi = pCodi
        _proveidor = pProveidor
        _empresa = pEmpresa
        _projecte = pProjecte
        _responsable = pResponsable
        _director = pDirector
    End Sub
    Public Function copy() As Comanda
        copy = New Comanda
        copy.id = Me.id
        copy.codi = Me.codi
        copy.empresa = _empresa
        copy.proveidor = _proveidor
        copy.contacteProveidor = _contacteProveidor
        copy.projecte = _projecte
        copy.contacte = _contacte
        copy.magatzem = _magatzem
        copy.data = _data
        copy.dataEntrega = _dataEntrega
        copy.dataMuntatge = _dataMuntatge
        copy.retencio = _retencio
        copy.interAval = _interAval
        copy.nOferta = _nOferta
        copy.tipusPagament = _tipusPagament
        copy.dadesBancaries = _dadesBancaries
        copy.articles = _articles
        copy.ports = _ports
        copy.responsable = _responsable
        copy.director = _director
    End Function
    Public Function base() As Double
        Dim a As articleComanda, suma As Double
        For Each a In articles
            suma = suma + a.base
        Next
        Return suma
    End Function
    Public Function descompte() As Double
        Dim a As articleComanda, suma As Double
        For Each a In articles
            suma = suma + a.descompte
        Next
        Return suma
    End Function
    Public Function iva() As Double
        Dim a As articleComanda, suma As Double
        For Each a In articles
            suma = suma + a.iva
        Next
        Return suma
    End Function
    Public Function total() As Double
        Dim a As articleComanda, suma As Double
        For Each a In articles
            suma = suma + a.total
        Next
        Return suma
    End Function

    Public Function errorsComanda() As List(Of String)
        Dim llista As List(Of String)
        llista = New List(Of String)
        If IsNothing(_empresa) Then
            llista.Add("ERROR. FALTA L'EMPRESA.")
        End If
        If IsNothing(_projecte) Then
            llista.Add("ERROR. FALTA EL PROJECTE-EMPRESA.")
        End If
        If IsNothing(_proveidor) Then
            llista.Add("ERROR. FALTA EL PROVEÏDOR")
        End If

        If Year(_data) < 2010 Then
            llista.Add("ERROR. FALTA LA DATA")
        End If
        Return llista
    End Function
    Public Function avisosComanda() As List(Of String)
        Dim llista As List(Of String)
        llista = New List(Of String)
        If IsNothing(_magatzem) Then
            llista.Add("Avis. Falta lloc d'entrega de la comanda.")
        End If
        If IsNothing(_contacte) Then
            llista.Add("Avis. Falta el contacte de l'entrega de la comanda.")
        End If
        If IsNothing(_tipusPagament) Then
            llista.Add("Avis. Falta el tipus de pagament de la comanda.")
        End If
        If IsNothing(contacteProveidor) Then
            llista.Add("Avis. Falta el contacte del proveidor de la comanda.")
        End If
        Return llista
    End Function
    Public Function getCodiSolicitud() As String
        If IsNothing(_projecte) Then
            Return "PREV-0000-" & codi
        Else
            Return "PREV-" & Strings.Right(_projecte.codi, 4) & "-" & codi
        End If
    End Function
    Public Function getCodiString() As String
        Return Strings.Right(Year(data), 2) & "-" & Strings.Right(_projecte.codi, 4) & "-" & codi
    End Function
End Class
