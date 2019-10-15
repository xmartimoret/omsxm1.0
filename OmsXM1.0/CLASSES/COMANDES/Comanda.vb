Public Class Comanda
    Inherits Base
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
    Public Sub New()

    End Sub
    Public Sub New(pId As Integer, pCodi As String, pProveidor As Proveidor, pEmpresa As Empresa, pProjecte As Projecte)
        Me.id = pId
        Me.codi = pCodi
        _proveidor = pProveidor
        _empresa = pEmpresa
        _projecte = pProjecte
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
End Class
