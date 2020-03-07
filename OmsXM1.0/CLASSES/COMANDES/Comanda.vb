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
    Friend Property estat As Integer

    Public Sub New()
        _estat = 0
        _articles = New List(Of articleComanda)
        _empresa = New Empresa
        _projecte = New Projecte
        _proveidor = New Proveidor
        _contacteProveidor = New ProveidorCont
        _contacte = New Contacte
        _magatzem = New LlocEntrega
        _tipusPagament = New TipusPagament
    End Sub
    Public Sub New(pId As Integer, pCodi As String)
        Me.id = pId
        Me.codi = pCodi
        _articles = New List(Of articleComanda)
        _empresa = New Empresa
        _projecte = New Projecte
        _proveidor = New Proveidor
        _contacteProveidor = New ProveidorCont
        _contacte = New Contacte
        _magatzem = New LlocEntrega
        _tipusPagament = New TipusPagament
    End Sub
    Public Sub New(pId As Integer, pCodi As String, pProveidor As Proveidor, pEmpresa As Empresa, pProjecte As Projecte)
        Me.id = pId
        Me.codi = pCodi
        _proveidor = pProveidor
        _empresa = pEmpresa
        _projecte = pProjecte
        _articles = New List(Of articleComanda)
        _contacteProveidor = New ProveidorCont
        _contacte = New Contacte
        _magatzem = New LlocEntrega
        _tipusPagament = New TipusPagament
    End Sub
    Public Sub New(pId As Integer, pCodi As String, pProveidor As Proveidor, pEmpresa As Empresa, pProjecte As Projecte, pResponsable As String, pDirector As String)
        Me.id = pId
        Me.codi = pCodi
        _proveidor = pProveidor
        _empresa = pEmpresa
        _projecte = pProjecte
        _responsable = pResponsable
        _director = pDirector
        _articles = New List(Of articleComanda)
        _contacteProveidor = New ProveidorCont
        _contacte = New Contacte
        _magatzem = New LlocEntrega
        _tipusPagament = New TipusPagament
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
    Public Function getAnyo() As Integer
        If IsDate(_data) Then
            Return Year(_data)
        End If
        Return 0
    End Function
    Public Function errorsComanda() As List(Of String)
        Dim llista As List(Of String)
        llista = New List(Of String)
        If IsNothing(_empresa) OrElse _empresa.id = -1 Then
            llista.Add("ERROR. FALTA L'EMPRESA.")
        End If
        If IsNothing(_projecte) OrElse _projecte.id = -1 Then
            llista.Add("ERROR. FALTA EL PROJECTE-EMPRESA.")
        End If
        If IsNothing(_proveidor) OrElse _proveidor.id = -1 Then
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
        If IsNothing(_magatzem) OrElse _magatzem.id = -1 Then
            llista.Add("Avis. Falta lloc d'entrega de la comanda.")
        End If
        If IsNothing(_contacte) OrElse _contacte.id = -1 Then
            llista.Add("Avis. Falta el contacte de l'entrega de la comanda.")
        End If
        If IsNothing(_tipusPagament) OrElse _tipusPagament.id = -1 Then
            llista.Add("Avis. Falta el tipus de pagament de la comanda.")
        End If
        If IsNothing(contacteProveidor) OrElse _contacteProveidor.id = -1 Then
            llista.Add("Avis. Falta el contacte del proveidor de la comanda.")
        End If
        Return llista
    End Function
    Public Function getCodiSolicitud() As String
        If IsNothing(_projecte) Then
            Return "F56-0000-" & codi
        Else
            Return "F56-" & Strings.Right(_projecte.codi, 4) & "-" & codi
        End If
    End Function
    Public Function getCodiString() As String
        Return Strings.Right(Year(data), 4) & "-" & Strings.Right(_projecte.codi, 4) & "-" & codi
    End Function

    Public Function ToStringCodi(codiProjecte As String) As String
        If _empresa.id < 10 Then
            Return Right(getAnyo, 2) & "-0" & _empresa.id & "-" & getStringCodi() & "-" & Right(codiProjecte, 4)
        Else
            Return Right(getAnyo, 2) & "-" & _empresa.id & "-" & getStringCodi() & "-" & Right(codiProjecte, 4)
        End If
    End Function
    Private Function getStringCodi() As String
        If Val(Me.codi) < 10 Then
            Return "000" & Val(Me.codi)
        ElseIf val(Me.codi) < 100 Then
            Return "00" & Val(Me.codi)
        ElseIf val(Me.codi) < 1000 Then
            Return "0" & Val(Me.codi)
        ElseIf val(Me.codi) < 10000 Then
            Return Val(Me.codi)
        End If
        Return Nothing
    End Function


    Protected Overrides Sub Finalize()
        _articles = Nothing
        _empresa = Nothing
        _projecte = Nothing
        _proveidor = Nothing
        _contacteProveidor = Nothing
        _contacte = Nothing
        _magatzem = Nothing
        _tipusPagament = Nothing
        MyBase.Finalize()
    End Sub
End Class
