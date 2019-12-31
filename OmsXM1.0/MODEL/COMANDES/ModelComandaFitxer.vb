
Module ModelComandaFitxer
    Private Const TIPUS_FITXER As String = "xmm"
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
        datacomanda
        ports
        dataEntrega
        dataMuntatge
        retencio
        intAval
        nOferta
        tipusPagament
        dadesComanda
        article
        pos
        articleId
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
        f = Dir(ruta & "*." & TIPUS_FITXER, FileAttribute.Normal)
        comandes = New List(Of Comanda)
        codis = New List(Of String)
        Do While f <> ""
            If CONFIG.fileExist(ruta & f) Then
                c = New Comanda
                codis.Add(f)
                Using fitxer As New IO.StreamReader(ruta & f)
                    fila = Split(fitxer.ReadLine(), ";")
                    If UBound(fila) > 0 Then

                        Select Case fila(0)
                            Case comandaTxt.empresa : If IsNumeric(fila(1)) Then c.empresa = ModelEmpresa.getObject(CInt(fila(1)))
                            Case comandaTxt.projecte : If IsNumeric(fila(1)) Then c.projecte = ModelProjecte.getObject(CInt(fila(1)))
                            Case comandaTxt.magatzem : If IsNumeric(fila(1)) Then c.magatzem = ModelLlocEntrega.getObject(CInt(fila(1)))
                            Case comandaTxt.contacteProjecte : If IsNumeric(fila(1)) Then c.contacte = ModelContacte.getObject(CInt(fila(1)))
                            Case comandaTxt.responsableProjecte : c.responsable = fila(1)
                            Case comandaTxt.directorProjecte : c.director = fila(1)
                            Case comandaTxt.proveidor : If IsNumeric(fila(1)) Then c.proveidor = ModelProveidor.getObject(CInt(fila(1)))
                            Case comandaTxt.departementProveidor : If IsNumeric(fila(1)) Then c.contacteProveidor = ModelProveidorContacte.getObject(CInt(fila(1)))
                            Case comandaTxt.ncomanda : c.codi = fila(1)
                            Case comandaTxt.datacomanda : If IsDate(fila(1)) Then c.data = CDate(fila(1))
                            Case comandaTxt.ports : c.ports = fila(1)
                            Case comandaTxt.dataEntrega : If IsDate(fila(1)) Then c.dataEntrega = CDate(fila(1))
                            Case comandaTxt.dataMuntatge : If IsDate(fila(1)) Then c.dataMuntatge = CDate(fila(1))
                            Case comandaTxt.retencio : c.retencio = fila(1)
                            Case comandaTxt.intAval : c.interAval = fila(1)
                            Case comandaTxt.nOferta : c.nOferta = fila(1)
                            Case comandaTxt.tipusPagament : If IsNumeric(fila(1)) Then c.tipusPagament = ModelTipusPagament.getAuxiliar.getObject(CInt(fila(1)))
                            Case comandaTxt.dadesComanda : c.dadesBancaries = fila(1)

                            Case comandaTxt.article
                                If fila(1) = "iniciArticle" Then
                                    a = New articleComanda
                                Else
                                    'nomes pot ser inici o final
                                    If Not IsNothing(a) Then c.articles.Add(a)
                                End If
                            Case comandaTxt.articleId
                                If IsNumeric(fila(1)) Then a.article = ModelArticle.getObject(CInt(fila(1)))
                                If IsNothing(a) Then a = New articleComanda
                            Case comandaTxt.refArticle : a.article.codi = fila(1)
                            Case comandaTxt.quantitatArticle : If IsNumeric(fila(1)) Then a.quantitat = fila(1)
                            Case comandaTxt.unitatArticle : If IsNumeric(fila(1)) Then a.article.unitat = ModelUnitat.getAuxiliar.getObject(CInt(fila(1)))
                            Case comandaTxt.descripcioArticle : a.article.nom = fila(1)
                            Case comandaTxt.importArticle : If IsNumeric(fila(1)) Then a.preu.base = fila(1)
                            Case comandaTxt.descompteArticle : If IsNumeric(fila(1)) Then a.preu.descompte = fila(1)
                            Case comandaTxt.ivaArticle : If IsNumeric(fila(1)) Then a.article.iva = ModelTipusIva.getAuxiliar.getObject(CInt(fila(1)))
                        End Select
                    End If
                End Using
                comandes.Add(c)
            End If
            f = Dir()
        Loop
        Return comandes
    End Function
    Public Function getObjects() As List(Of Comanda)
        If IsNothing(objects) Then objects = getRemoteObjects()
        Return objects
    End Function
    Public Function saveEditComanda(p As Comanda) As Boolean
        Dim ruta As String, a As articleComanda, i As Integer
        ruta = CONFIG.setSeparator(CONFIG.getRutaComandesEnEdicio)
        If CONFIG.folderExist(ruta) Then
            Using fitxer As New IO.StreamWriter(ruta & p.codi & "." & TIPUS_FITXER)
                If Not IsNothing(p.empresa) Then fitxer.WriteLine(comandaTxt.empresa & ";" & p.empresa.id)
                If Not IsNothing(p.projecte) Then fitxer.WriteLine(comandaTxt.projecte & ";" & p.projecte.id)
                If Not IsNothing(p.magatzem) Then fitxer.WriteLine(comandaTxt.magatzem & ";" & p.magatzem.id)

                If Not IsNothing(p.contacte) Then fitxer.WriteLine(comandaTxt.contacteProjecte & ";" & p.contacte.id)
                fitxer.WriteLine(comandaTxt.responsableProjecte)
                fitxer.WriteLine(comandaTxt.directorProjecte)
                If Not IsNothing(p.proveidor) Then fitxer.WriteLine(comandaTxt.proveidor & ";" & p.proveidor.id)
                If Not IsNothing(p.contacteProveidor) Then fitxer.WriteLine(comandaTxt.departementProveidor & ";" & p.contacteProveidor.id)
                fitxer.WriteLine(comandaTxt.ncomanda)
                fitxer.WriteLine(comandaTxt.datacomanda)
                fitxer.WriteLine(comandaTxt.ports)
                fitxer.WriteLine(comandaTxt.dataEntrega)
                fitxer.WriteLine(comandaTxt.dataMuntatge)
                fitxer.WriteLine(comandaTxt.retencio)
                fitxer.WriteLine(comandaTxt.intAval)
                fitxer.WriteLine(comandaTxt.nOferta)
                fitxer.WriteLine(comandaTxt.tipusPagament)
                fitxer.WriteLine(comandaTxt.dadesComanda)
                i = 1
                If Not IsNothing(p.articles) Then
                    For Each a In p.articles
                        fitxer.WriteLine(comandaTxt.article & ";iniciArticle")
                        fitxer.WriteLine(comandaTxt.articleId & ";" & a.id)
                        fitxer.WriteLine(comandaTxt.refArticle & ";" & a.codi)
                        fitxer.WriteLine(comandaTxt.quantitatArticle & ";" & a.quantitat)
                        If Not IsNothing(a.article.unitat) Then fitxer.WriteLine(comandaTxt.unitatArticle & ";" & a.article.unitat.id)
                        fitxer.WriteLine(comandaTxt.descripcioArticle & ";" & a.nom)
                        If Not IsNothing(a.preu) Then fitxer.WriteLine(comandaTxt.importArticle & ";" & a.preu.base)
                        If Not IsNothing(a.preu) Then fitxer.WriteLine(comandaTxt.descompteArticle & ";" & a.preu.descompte)
                        If Not IsNothing(a.iva) Then fitxer.WriteLine(comandaTxt.ivaArticle & ";" & a.article.iva.id)
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
    Public Function removeComanda(c As Comanda, f As String) As Boolean
        Dim ruta As String, result As Boolean = False
        ruta = CONFIG.setSeparator(CONFIG.getRutaComandesEnEdicio)
        If CONFIG.folderExist(ruta) Then
            If CONFIG.fileExist(ruta & f) Then
                Call Kill(ruta & f)
                result = removeObject(c)
                Call removeCodi(f)
            End If
        End If
        Return result
    End Function
    Private Function removeObject(c As Comanda) As Boolean
        Dim t As Comanda, result As Boolean
        result = False
        For Each t In objects
            If t.codi = c.codi Then
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
End Module
