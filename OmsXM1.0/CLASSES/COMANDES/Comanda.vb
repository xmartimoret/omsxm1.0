Public Class Comanda
    Inherits Base
    Friend Property docMyDoc As PedidoMD
    Friend Property idMydoc As Long
    Friend Property serie As String
    Friend Property idSolicitut As Integer
    Friend Property empresa As Empresa = New Empresa
    Friend Property proveidor As Proveidor = New Proveidor
    Friend Property contacteProveidor As ProveidorCont = New ProveidorCont
    Friend Property projecte As Projecte = New Projecte
    Friend Property contacte As Contacte = New Contacte
    Friend Property magatzem As LlocEntrega = New LlocEntrega
    Friend Property data As Date
    Friend Property dataEntrega As Date
    Friend Property dataMuntatge As Date
    Friend Property nOferta As String = ""
    Friend Property tipusPagament As TipusPagament = New TipusPagament
    Friend Property dadesBancaries As String = ""
    Friend Property articles As List(Of articleComanda)
    Friend Property ports As String = ""
    Friend Property responsable As String = ""
    Friend Property director As String = ""
    Friend Property estat As Integer
    Friend Property nomFitxerSolicitut As String = ""
    Friend Property solicitutF56 As SolicitudComanda = New SolicitudComanda
    Friend Property responsableCompra As ResponsableCompra = New ResponsableCompra
    Friend Property entrega As Integer = 100
    Friend Property inici As Integer = 0
    Friend Property documentacio As List(Of doc)
    Friend Property comentaris As List(Of ComentariMD)
    Friend Property entregaEquips As Integer = 0
    Friend Property departament As String = ""
    Friend Property urgent As Boolean
    Private baseComandaImport As Double = 0
    Private ivaComandaImport As Double = 0
    Private pagines(15, 49, 1) As articleComanda
    Public Sub New()
        _estat = 0
        _projecte = New Projecte
        _articles = New List(Of articleComanda)
        _data = Now
        _docMyDoc = New PedidoMD
        _idMydoc = -1
        _documentacio = New List(Of doc)
        _comentaris = New List(Of ComentariMD)
    End Sub
    Public Sub New(pId As Integer, pCodi As String)
        Me.id = pId
        Me.codi = pCodi
        _articles = New List(Of articleComanda)
        _documentacio = New List(Of doc)
        _data = Now
        _docMyDoc = New PedidoMD
        _comentaris = New List(Of ComentariMD)
        _idMydoc = -1
        _projecte = New Projecte
    End Sub
    Public Sub New(pId As Integer, pCodi As String, pProveidor As Proveidor, pEmpresa As Empresa, pProjecte As Projecte)
        Me.id = pId
        Me.codi = pCodi
        _proveidor = pProveidor
        _empresa = pEmpresa
        _projecte = pProjecte
        _articles = New List(Of articleComanda)
        _documentacio = New List(Of doc)
        _data = Now
        _docMyDoc = New PedidoMD
        _comentaris = New List(Of ComentariMD)
        _idMydoc = -1
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
        _documentacio = New List(Of doc)
        _data = Now
        _docMyDoc = New PedidoMD
        _comentaris = New List(Of ComentariMD)
        _idMydoc = -1
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
        copy.nOferta = _nOferta
        copy.tipusPagament = _tipusPagament
        copy.dadesBancaries = _dadesBancaries
        copy.articles = _articles
        copy.documentacio = _documentacio
        copy.ports = _ports
        copy.responsable = _responsable
        copy.director = _director
        copy.nomFitxerSolicitut = _nomFitxerSolicitut
        copy.solicitutF56 = _solicitutF56
        copy.responsableCompra = _responsableCompra
        copy.serie = _serie
        copy.entrega = _entrega
        copy.inici = _inici
        copy.entregaEquips = _entregaEquips
        copy.baseComanda = baseComanda
        copy.ivaComanda = ivaComanda
        copy.estat = _estat
        copy.docMyDoc = _docMyDoc
        copy.idMydoc = _idMydoc
        copy.comentaris = _comentaris
        copy.departament = _departament
        copy.urgent = _urgent
    End Function
    Public Function base() As Double
        Dim a As articleComanda, suma As Double
        For Each a In articles
            suma = suma + a.base
        Next
        Return suma
    End Function
    Public Function base(tipus As Integer) As Double
        Dim a As articleComanda, suma As Double
        For Each a In articles
            If Not IsNothing(a.tIva) Then If a.tIva.impost = tipus Then suma = suma + a.base
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
    Public Property baseComanda As Double
        Get
            If baseComandaImport = 0 Then
                baseComandaImport = base()
            End If
            Return baseComandaImport
        End Get
        Set(value As Double)
            baseComandaImport = value
        End Set
    End Property
    Public Property ivaComanda As Double
        Get
            If ivaComandaImport = 0 Then
                ivaComandaImport = iva()
            End If
            Return ivaComandaImport
        End Get
        Set(value As Double)
            ivaComandaImport = value
        End Set
    End Property

    Public Function totalComanda() As Double
        totalComanda = baseComanda + ivaComanda
    End Function
    Public Function getAnyo() As Integer
        If IsDate(_data) Then
            Return Year(_data)
        End If
        Return 0
    End Function
    Public Function getTotalFiles() As Integer
        Dim n As Integer = 0, a As articleComanda
        For Each a In _articles
            If a.pos > n Then n = a.pos
        Next
        a = Nothing
        Return n
    End Function
    Public Function errorsComanda() As List(Of String)
        Dim llista As List(Of String)
        llista = New List(Of String)
        If IsNothing(_empresa) OrElse _empresa.id = -1 Then
            llista.Add(IDIOMA.getString("errFaltaEmpresa"))
        End If
        If IsNothing(_projecte) OrElse _projecte.id = -1 Then
            llista.Add(IDIOMA.getString("errFaltaProjecteEmpresa"))
        End If
        If IsNothing(_proveidor) OrElse _proveidor.id = -1 Then
            llista.Add(IDIOMA.getString("errFaltaProveidor"))
        End If
        If Year(_data) < 2010 Then
            llista.Add(IDIOMA.getString("errFaltaData"))
        End If
        If IsNothing(_responsableCompra) OrElse _responsableCompra.id = -1 Then
            llista.Add(IDIOMA.getString("errFaltaResponsableCompra"))
        End If
        If _articles.Count = 0 Then
            llista.Add(IDIOMA.getString("errFaltenArticles"))
        End If
        Return llista
    End Function
    Public Function avisosComanda() As List(Of String)
        Dim llista As List(Of String)
        llista = New List(Of String)
        If IsNothing(_magatzem) OrElse _magatzem.id = -1 Then
            llista.Add(IDIOMA.getString("avisFaltaMagatzemComanda"))
        End If
        If IsNothing(_contacte) OrElse _contacte.id = -1 Then
            llista.Add(IDIOMA.getString("avisFaltaContacteEntrega"))
        End If
        If IsNothing(_tipusPagament) OrElse _tipusPagament.id = -1 Then
            llista.Add(IDIOMA.getString("avisFaltaTipusPagament"))
        End If
        If IsNothing(contacteProveidor) OrElse _contacteProveidor.id = -1 Then
            llista.Add(IDIOMA.getString("avisFaltaContacteProveidor"))
        End If
        Return llista
    End Function

    Public Function getCodi() As String
        Dim c As CodiComanda, idEmpresa As Integer, codiProjecte As String
        If IsNothing(_empresa) Then
            idEmpresa = -1
        Else
            idEmpresa = _empresa.id
        End If
        If IsNothing(_projecte) Then
            codiProjecte = "-1"
        Else
            codiProjecte = _projecte.codi
        End If
        Try
            c = New CodiComanda(-1, serie, Me.codi, idEmpresa, codiProjecte, "")
        Catch ex As Exception
            c = New CodiComanda
        End Try
        Return c.toString
    End Function
    Private Function getCodiEdicio() As String
        Return IDIOMA.getString("novaComanda") & "(" & Me.id & ")"
    End Function
    Public Function getMaxFilesArticles() As Integer
        Dim a As articleComanda, pos As Integer
        pos = 0
        For Each a In _articles
            If pos < a.pos Then pos = a.pos
        Next
        Return pos
    End Function
    Public Function getReportFiles() As Integer
        If getMaxFilesArticles() Mod 50 < 24 Then
            Return 50 * (getMaxFilesArticles() \ 50) + 23
        Else
            Return 50 * (getMaxFilesArticles() \ 50) + 50 + 23

        End If
    End Function
    Public Function getReportFile(a As articleComanda) As Integer
        '50 i 25 ultima pagina
        Dim f As Integer, r As Integer, p50 As Integer, p25 As Integer, i As Integer, j As Integer
        f = getMaxFilesArticles()
        p50 = f \ 50
        If f Mod 50 < 26 Then
            p25 = 1
        Else
            p25 = 2
        End If
        For i = 1 To p50 * 50
            If i = a.pos Then
                Return i
            End If
        Next i
        j = i + 1
        For i = 1 To p25 * 25
            If j = a.pos Then
                If i > 25 Then
                    Return j + 25
                Else
                    Return j
                End If
            End If
            j = j + 1
        Next i
        Return a.pos
    End Function
    Public Function tipusComanda() As String
        If baseComanda > 500 Then
            Return ""
        Else
            Return "-1"
        End If
    End Function
    Public Function getCorreuProveidor() As String
        Dim c As ProveidorCont
        If Not proveidor Is Nothing Then
            If Not IsNothing(contacteProveidor) Then If contacteProveidor.email <> "" Then Return contacteProveidor.email
            If proveidor.email <> "" Then Return proveidor.email
            For Each c In proveidor.contactes
                If c.email <> "" Then
                    Return c.email
                End If
            Next
        End If
        Return ""
        c = Nothing
    End Function
    Public Overrides Function isFilter(textFiltre As String, Optional opcionalP1 As String = "", Optional opcionalP2 As String = "") As Boolean
        Dim filtres() As String, f As String, fComanda As String = ""
        isFilter = False
        If Len(textFiltre) = 0 Then
            isFilter = True
        Else
            If Not IsNothing(_projecte) Then fComanda = _projecte.codi
            If Not IsNothing(_proveidor) Then fComanda = fComanda & _proveidor.nom
            If Not IsNothing(_empresa) Then fComanda = fComanda & _empresa.nom
            filtres = Split(textFiltre, "+")
            If UBound(filtres) = 0 Then filtres = Split(textFiltre, "*")
            For Each f In filtres
                If InStr(1, fComanda, f, vbTextCompare) > 0 Or
               (opcionalP1 <> "" And InStr(1, opcionalP1, f, vbTextCompare) > 0) Or
               (opcionalP2 <> "" And InStr(1, opcionalP2, f, vbTextCompare) > 0) Then
                    isFilter = True
                    Exit For
                Else
                    isFilter = False
                End If
            Next
        End If
    End Function
    Public Function getEventActual() As EventsMD
        Dim e As EventsMD
        For Each e In docMyDoc.events
            If e.finalitzat = 0 Then
                Return e
            End If
        Next
        Return Nothing
    End Function
    Public Function getTascaActual() As Integer
        Dim e As EventsMD
        If Not IsNothing(docMyDoc) Then
            For Each e In docMyDoc.events
                If e.finalitzat = 0 Then
                    Return e.idTasca
                End If
            Next
        End If
        Return -1
    End Function
    Public Function getNumeroMydoc() As Long
        If Not IsNothing(docMyDoc) Then Return docMyDoc.id
        Return -1
    End Function
    Public Function getStringTascaMydoc() As String
        Dim e As EventsMD
        If Not IsNothing(docMyDoc) Then
            e = docMyDoc.getEstatWorkflow
            If Not IsNothing(e) Then
                Return ModelTasca.getNom(e.idTasca)
            ElseIf _idMydoc > 0 Then
                Return "GESTOR DOCUMENTAL"
            End If
        ElseIf _idMydoc > 0 Then
            Return "GESTOR DOCUMENTAL"
        End If
        Return ""
    End Function
    Public Function getDataTascaMydoc() As Date
        Dim e As EventsMD
        If Not IsNothing(docMyDoc) Then
            e = docMyDoc.getEstatWorkflow
            If Not IsNothing(e) Then
                Return e.dataIni
            End If
        End If
        Return _data
    End Function
    Public Overrides Function ToString() As String
        If proveidor IsNot Nothing Then Return getCodi() & " - " & proveidor.nom
        Return getCodi()
    End Function
    Public Function toStingNomComanda()
        If Not proveidor Is Nothing Then Return getCodi() & "-" & _idMydoc & "-" & Left(proveidor.nom, 10)
        Return getCodi() & "-" & getNumeroMydoc()
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
        _responsableCompra = Nothing
        MyBase.Finalize()
    End Sub
End Class
