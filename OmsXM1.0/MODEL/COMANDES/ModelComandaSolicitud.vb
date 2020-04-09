
Module ModelComandaSolicitud
    Private Const TIPUS_FITXER As String = ".xmm"
    Private dateUpdate As Date

    Private Enum comandaTxt
        empresa = 1
        projecte
        magatzem
        contacteProjecte
        responsableProjecte
        directorProjecte
        proveidor
        departementProveidor
        ncomanda
        datacomanda = 10
        ports
        dataEntrega
        dataMuntatge
        retencio
        intAval
        nOferta
        tipusPagament
        dadesComanda
        article
        articleId
        pos = 21
        refArticle
        quantitatArticle
        unitatArticle
        descripcioArticle
        importArticle
        descompteArticle
        ivaArticle
    End Enum
    Private objects As List(Of Comanda)
    Private codis As List(Of String)
    Private Function getRemoteObjects() As List(Of Comanda)
        Dim ruta As String, c As Comanda, f As String, fila() As String, a As articleComanda, comandes As List(Of Comanda)
        ruta = CONFIG.setSeparator(CONFIG.getRutaComandesEnEdicio)
        f = Dir(ruta & "*" & TIPUS_FITXER, FileAttribute.Normal)
        comandes = New List(Of Comanda)
        codis = New List(Of String)
        Do While f <> ""
            If CONFIG.fileExist(ruta & f) Then
                c = New Comanda()
                codis.Add(f)
                Using fitxer As New IO.StreamReader(ruta & f)

                    Do
                        fila = Split(fitxer.ReadLine(), ";")
                        If UBound(fila) > 0 Then
                            Select Case fila(0)
                                Case comandaTxt.empresa
                                    If isNumericPositiu(fila(1)) Then c.empresa = ModelEmpresa.getObject(CInt(fila(1))) Else c.empresa = New Empresa
                                Case comandaTxt.projecte : If CONFIG.isNumericPositiu(fila(1)) Then c.projecte = ModelProjecte.getObject(CInt(fila(1))) Else c.projecte = New Projecte
                                Case comandaTxt.magatzem : If CONFIG.isNumericPositiu(fila(1)) Then c.magatzem = ModelLlocEntrega.getObject(CInt(fila(1))) Else c.magatzem = New LlocEntrega
                                Case comandaTxt.contacteProjecte : If CONFIG.isNumericPositiu(fila(1)) Then c.contacte = ModelContacte.getObject(CInt(fila(1))) Else c.contacte = New Contacte
                                Case comandaTxt.responsableProjecte : c.responsable = fila(1)
                                Case comandaTxt.directorProjecte : c.director = fila(1)
                                Case comandaTxt.proveidor : If CONFIG.isNumericPositiu(fila(1)) Then c.proveidor = ModelProveidor.getObject(CInt(fila(1))) Else c.proveidor = New Proveidor
                                Case comandaTxt.departementProveidor : If CONFIG.isNumericPositiu(fila(1)) Then c.contacteProveidor = ModelProveidorContacte.getObject(CInt(fila(1))) Else c.contacteProveidor = New ProveidorCont
                                Case comandaTxt.ncomanda
                                    c.codi = fila(1)
                                    If IsNumeric(c.codi) Then
                                        c.id = CInt(c.codi)
                                        c.idSolicitut = c.id
                                    End If
                                Case comandaTxt.datacomanda : If IsDate(fila(1)) Then c.data = CDate(fila(1))
                                Case comandaTxt.ports : c.ports = fila(1)
                                Case comandaTxt.dataEntrega : If IsDate(fila(1)) Then c.dataEntrega = CDate(fila(1))
                                Case comandaTxt.dataMuntatge : If IsDate(fila(1)) Then c.dataMuntatge = CDate(fila(1))
                                Case comandaTxt.retencio : c.retencio = fila(1)
                                Case comandaTxt.intAval : c.interAval = fila(1)
                                Case comandaTxt.nOferta : c.nOferta = fila(1)
                                Case comandaTxt.tipusPagament : If IsNumeric(fila(1)) Then c.tipusPagament = ModelTipusPagament.getAuxiliar.getObject(CInt(fila(1))) Else c.tipusPagament = New TipusPagament
                                Case comandaTxt.dadesComanda : c.dadesBancaries = fila(1)

                                Case comandaTxt.article
                                    If fila(1) = "iniciArticle" Then
                                        a = New articleComanda
                                    Else
                                        'nomes pot ser inici o final
                                        If Not IsNothing(a) Then c.articles.Add(a)
                                    End If
                                Case comandaTxt.articleId
                                    If IsNothing(a) Then a = New articleComanda
                                Case comandaTxt.refArticle : a.codi = fila(1)
                                Case comandaTxt.pos : a.pos = fila(1)
                                Case comandaTxt.quantitatArticle : If CONFIG.isNumericPositiu(fila(1)) Then a.quantitat = fila(1) Else a.quantitat = 0
                                Case comandaTxt.unitatArticle : If CONFIG.isNumericPositiu(fila(1)) Then a.unitat = ModelUnitat.getAuxiliar.getObject(CInt(fila(1))) Else a.unitat = New Unitat
                                Case comandaTxt.descripcioArticle : a.nom = fila(1)
                                Case comandaTxt.importArticle : If CONFIG.isNumericPositiu(fila(1)) Then a.preu = fila(1)
                                Case comandaTxt.descompteArticle : If CONFIG.isNumericPositiu(fila(1)) Then a.tpcDescompte = fila(1)
                                Case comandaTxt.ivaArticle : If CONFIG.isNumericPositiu(fila(1)) Then a.tIva = ModelTipusIva.getAuxiliar.getObject(CInt(fila(1))) Else a.tIva = New TipusIva
                            End Select
                        End If

                    Loop While Not fitxer.EndOfStream
                End Using
                c.nomFitxerSolicitut = f
                comandes.Add(c)
            End If
            f = Dir()
        Loop
        dateUpdate = Now
        Return comandes
    End Function
    Public Function getObjects() As List(Of Comanda)
        If Not isUpdated() Then objects = getRemoteObjects()
        Return objects
    End Function
    Public Function getObjects(filtre As String) As List(Of Comanda)
        Dim a As Comanda, altres As String = ""
        If Not isUpdated() Then objects = getRemoteObjects()
        getObjects = New List(Of Comanda)
        For Each a In objects
            If a.proveidor IsNot Nothing Then altres = a.proveidor.nom & a.proveidor.codi
            If a.projecte IsNot Nothing Then altres = altres & a.projecte.nom & a.projecte.codi
            If a.empresa IsNot Nothing Then altres = altres & a.empresa.nom & a.empresa.codi

            If altres <> "" Then
                If a.isFilter(filtre, altres) Then
                    getObjects.Add(a)
                End If
            Else
                If a.isFilter(filtre) Then
                    getObjects.Add(a)
                End If
            End If
        Next
    End Function
    Public Function getObject(id As Integer) As Comanda
        If IsNothing(objects) Then objects = getRemoteObjects()
        Return objects.Find(Function(x) x.id = id)
    End Function
    Public Function save(p As Comanda) As Boolean
        Dim ruta As String, a As articleComanda, i As Integer
        ruta = CONFIG.setSeparator(CONFIG.getRutaComandesEnEdicio)
        If CONFIG.folderExist(ruta) Then
            If p.nomFitxerSolicitut = "" Then p.nomFitxerSolicitut = p.codi & TIPUS_FITXER
            Using fitxer As New IO.StreamWriter(ruta & p.nomFitxerSolicitut)
                If Not IsNothing(p.empresa) Then fitxer.WriteLine(comandaTxt.empresa & ";" & p.empresa.id)
                If Not IsNothing(p.projecte) Then fitxer.WriteLine(comandaTxt.projecte & ";" & p.projecte.id)
                If Not IsNothing(p.magatzem) Then fitxer.WriteLine(comandaTxt.magatzem & ";" & p.magatzem.id)

                If Not IsNothing(p.contacte) Then fitxer.WriteLine(comandaTxt.contacteProjecte & ";" & p.contacte.id)
                fitxer.WriteLine(comandaTxt.responsableProjecte)
                fitxer.WriteLine(comandaTxt.directorProjecte)
                If Not IsNothing(p.proveidor) Then fitxer.WriteLine(comandaTxt.proveidor & ";" & p.proveidor.id)
                If Not IsNothing(p.contacteProveidor) Then fitxer.WriteLine(comandaTxt.departementProveidor & ";" & p.contacteProveidor.id)
                fitxer.WriteLine(comandaTxt.ncomanda & ";" & p.codi)
                fitxer.WriteLine(comandaTxt.datacomanda & ";" & p.data)
                fitxer.WriteLine(comandaTxt.ports & ";" & p.ports)
                fitxer.WriteLine(comandaTxt.dataEntrega & ";" & p.dataEntrega)
                fitxer.WriteLine(comandaTxt.dataMuntatge & ";" & p.dataMuntatge)
                fitxer.WriteLine(comandaTxt.retencio & ";" & p.retencio)
                fitxer.WriteLine(comandaTxt.intAval & ";" & p.interAval)
                fitxer.WriteLine(comandaTxt.nOferta & ";" & p.nOferta)
                If Not IsNothing(p.tipusPagament) Then fitxer.WriteLine(comandaTxt.tipusPagament & ";" & p.tipusPagament.id)
                fitxer.WriteLine(comandaTxt.dadesComanda & ";" & p.dadesBancaries)
                i = 1
                If Not IsNothing(p.articles) Then
                    For Each a In p.articles
                        fitxer.WriteLine(comandaTxt.article & ";iniciArticle")
                        fitxer.WriteLine(comandaTxt.pos & ";" & a.pos)
                        fitxer.WriteLine(comandaTxt.articleId & ";" & a.id)
                        fitxer.WriteLine(comandaTxt.refArticle & ";" & a.codi)
                        fitxer.WriteLine(comandaTxt.quantitatArticle & ";" & a.quantitat)
                        If Not IsNothing(a.unitat) Then fitxer.WriteLine(comandaTxt.unitatArticle & ";" & a.unitat.id)
                        fitxer.WriteLine(comandaTxt.descripcioArticle & ";" & a.nom)
                        If Not IsNothing(a.preu) Then fitxer.WriteLine(comandaTxt.importArticle & ";" & a.preu)
                        If Not IsNothing(a.preu) Then fitxer.WriteLine(comandaTxt.descompteArticle & ";" & a.tpcDescompte)
                        If Not IsNothing(a.tIva) Then fitxer.WriteLine(comandaTxt.ivaArticle & ";" & a.tIva.id)
                        fitxer.WriteLine(comandaTxt.article & ";finalArticle")
                        i = i + 1
                    Next
                End If
            End Using
            objects.Add(p)
            codis.Add(p.codi)
            Return True
        End If
        Return False
        a = Nothing
    End Function
    Public Function remove(c As Comanda) As Boolean
        Dim ruta As String, result As Boolean = False
        ruta = CONFIG.setSeparator(CONFIG.getRutaComandesEnEdicio)
        If CONFIG.folderExist(ruta) Then
            If CONFIG.fileExist(ruta & c.nomFitxerSolicitut) Then
                Call Kill(ruta & c.nomFitxerSolicitut)
                result = removeComanda(c)
                Call removeCodi(c.nomFitxerSolicitut)
            End If
        End If
        dateUpdate = Now
        Return result
    End Function
    Private Function removeComanda(c As Comanda) As Boolean
        Dim t As Comanda, result As Boolean
        result = False
        For Each t In objects
            If t.id = c.idSolicitut Then
                objects.Remove(t)
                result = True
                Exit For
            End If
        Next
        t = Nothing
        Return result
    End Function
    Private Sub removeCodi(c As String)
        codis.Remove(c)
    End Sub
    Public Function getNewCode() As String
        Dim temp As Integer, p As String
        If IsNothing(objects) Then objects = getRemoteObjects()
        For Each p In codis
            If IsNumeric(Left(p, 3)) Then
                If CInt(temp) < CInt(Left(p, 3)) Then
                    temp = Left(p, 3)
                End If
            End If
        Next
        If temp + 1 < 10 Then
            Return "00" & temp + 1
        ElseIf temp + 1 < 100 Then
            Return "0" & temp + 1
        Else
            Return temp + 1
        End If
    End Function
    Private Function isUpdated() As Boolean
        If Not objects Is Nothing Then
            If getDateUpdated() > dateUpdate Then
                isUpdated = False
            Else
                isUpdated = True
            End If
        Else
            Return False
        End If
        If isUpdated Then dateUpdate = Now
    End Function
    Private Function getDateUpdated() As DateTime
        Dim ruta As String, f As String, d As DateTime
        ruta = CONFIG.setSeparator(CONFIG.getRutaComandesEnEdicio)
        f = Dir(ruta & "*" & TIPUS_FITXER, FileAttribute.Normal)
        Do While f <> ""
            If CONFIG.fileExist(ruta & f) Then
                d = CONFIG.getDateFileModified(ruta & f)
                If d > dateUpdate Then
                    Return d
                End If
            End If
            f = Dir()
        Loop
        Return dateUpdate
    End Function
End Module
