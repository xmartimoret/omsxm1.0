Public Class SolicitudComanda
    Inherits Base

    Friend Property dataComanda As Date
    Friend Property serie As Integer
    Friend Property empresa As String = ""
    Friend Property departament As String = ""
    Friend Property codiProjecte As String = ""
    Friend Property proveidor As String = ""
    Friend Property idProveidor As Integer = -1
    Friend Property idContacteProveidor As Integer = -1
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
    Friend Property idLlocEntrega As Integer = -1
    Friend Property llocEntrega As String = ""
    Friend Property direccioEntrega As String = ""
    Friend Property idContacteEntrega As Integer = -1
    Friend Property contacteEntrega As String = ""
    Friend Property telefonEntrega As String = ""
    Friend Property emailEntrega As String = ""
    Friend Property dataEntrega As Date
    Friend Property dataFinalitzacio As Date
    Friend Property oferta1 As String = ""
    Friend Property fitxerOferta1 As String = ""
    Friend Property oferta2 As String = ""
    Friend Property fitxerOferta2 As String = ""
    Friend Property oferta3 As String = ""
    Friend Property fitxerOferta3 As String = ""
    Friend Property comparatiu As String = ""
    Friend Property fitxerComparatiu As String = ""
    Friend Property formaPagament As String = ""
    Friend Property altresDocumentacio As String = ""
    Friend Property articles As List(Of ArticleSolicitut)
    Friend Property documentacio As List(Of doc)
    Friend Property estat As Integer
    Friend Property pdfSolicitut As String = ""
    Friend Property IdResponsableCompra As String = ""
    Friend Property responsableCompra As String = ""
    Public Sub New()
        Me.id = -1
        estat = 0
        articles = New List(Of ArticleSolicitut)
        documentacio = New List(Of doc)
    End Sub
    Public Sub New(pId As Integer)
        Me.id = pId

        estat = 0
        articles = New List(Of ArticleSolicitut)
        documentacio = New List(Of doc)
    End Sub
    Public Sub New(pId As Integer, pNom As String, pEstat As Integer)
        Me.id = pId
        Me.nom = pNom
        Me.estat = pEstat
        articles = New List(Of ArticleSolicitut)
        documentacio = New List(Of doc)
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
    Public Function getAnyo() As Integer
        Return Year(dataComanda)
    End Function
    Public Function getTotalFiles() As Integer
        Dim n As Integer = 0, a As ArticleSolicitut
        For Each a In _articles
            If a.pos > n Then n = a.pos
        Next
        a = Nothing
        Return n
    End Function
    Public Overrides Function toString() As String
        Return IDIOMA.getString("empresa") & ": " & _empresa & "; " & IDIOMA.getString("projecte") & ": " & _codiProjecte & "; " & IDIOMA.getString("proveidor") & ": " & _proveidor & "; " & IDIOMA.getString("llocEntrega") & ": " & _llocEntrega
    End Function
    Public Overrides Function isFilter(textFiltre As String, Optional opcionalP1 As String = "", Optional opcionalP2 As String = "") As Boolean
        Dim filtres() As String, f As String
        isFilter = False
        If Len(textFiltre) = 0 Then
            isFilter = True
        Else
            filtres = Split(textFiltre, "+")
            If UBound(filtres) = 0 Then filtres = Split(textFiltre, " ")
            If UBound(filtres) = 0 Then filtres = Split(textFiltre, "*")
            For Each f In filtres
                If InStr(1, Me.codiProjecte, f, vbTextCompare) > 0 Or
               InStr(1, Me.proveidor, f, vbTextCompare) > 0 Or
               InStr(1, Me.empresa, f, vbTextCompare) > 0 Or
               (opcionalP1 <> "" And InStr(1, opcionalP1, f, vbTextCompare) > 0) Or
               (opcionalP2 <> "" And InStr(1, opcionalP2, f, vbTextCompare) > 0) Then
                    isFilter = True
                Else
                    isFilter = False
                    Exit For
                End If
            Next
        End If
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
