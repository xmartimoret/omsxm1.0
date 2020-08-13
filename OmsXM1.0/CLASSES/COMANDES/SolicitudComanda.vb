Public Class SolicitudComanda
    Inherits Base
    Friend Property dataComanda As Date
    Friend Property serie As String = ""
    Friend Property empresa As String = ""
    Friend Property departament As String = ""
    Friend Property codiProjecte As String = ""
    Friend Property proveidor As String = ""
    Friend Property idProveidor As Integer
    Friend Property contacteProveidor As String = ""
    Friend Property telefonProveidor As String = ""
    Friend Property emailProveidor As String = ""
    Friend Property suministreMaterial As Boolean
    Friend Property embalatge As Boolean
    Friend Property transport As Boolean
    Friend Property muntatge As Boolean
    Friend Property supervisio As Boolean
    Friend Property postaApunt As Boolean
    Friend Property provesTaller As Boolean
    Friend Property provesObra As Boolean
    Friend Property postaServei As Boolean
    Friend Property altresAlcans As Boolean
    Friend Property llocEntrega As String = ""
    Friend Property direccioEntrega As String = ""
    Friend Property contacteEntrega As String = ""
    Friend Property telefonEntrega As String = ""
    Friend Property dataEntrega As Date
    Friend Property dataFinalitzacio As Date
    Friend Property oferta1 As String = ""
    Friend Property oferta2 As String = ""
    Friend Property oferta3 As String = ""
    Friend Property comparatiu As String = ""
    Friend Property formaPagament As String = ""
    Friend Property altresDocumentacio As String = ""
    Friend Property articles As List(Of ArticleSolicitut)
    Friend Property estat As Integer
    Public Sub New()
        Me.id = -1
        estat = 0
        articles = New List(Of ArticleSolicitut)
    End Sub
    Public Sub New(pId As Integer, pCodi As Integer)
        Me.id = pId
        Me.codi = pCodi
        estat = 0
        articles = New List(Of ArticleSolicitut)
    End Sub
    Public Sub New(pId As Integer, pCodi As Integer, pNom As String, pEstat As Integer)
        Me.id = pId
        Me.codi = pCodi
        Me.nom = pNom
        Me.estat = pEstat
        articles = New List(Of ArticleSolicitut)
    End Sub
    Public Function base() As Double
        Dim a As ArticleSolicitut, suma As Double
        For Each a In articles
            suma = suma + a.base
        Next
        Return suma
    End Function

    Public Function descompte() As Double
        Dim a As ArticleSolicitut, suma As Double
        For Each a In articles
            suma = suma + a.descompte
        Next
        Return suma
    End Function

    Public Function total() As Double
        Dim a As ArticleSolicitut, suma As Double
        For Each a In articles
            suma = suma + a.total
        Next
        Return suma
    End Function
    Public Function toStringCodi() As String
        If _codiProjecte = "" Then
            Return "F56-0000-" & codi
        Else
            Return "F56-" & Strings.Right(_codiProjecte, 4) & "-" & codi
        End If
    End Function
    Protected Overrides Sub Finalize()
        MyBase.Finalize()
        articles = Nothing
    End Sub
End Class
