
Module ModelComandaFitxer
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
        articleId
        refArticle
        quantitatArticle
        unitatArticle
        descripcioArticle
        importArticle
        descompteArticle
        ivaArticle
    End Enum

    Public Sub saveEditComanda(p As Comanda, f As String)
        Dim ruta As String, a As articleComanda, i As Integer
        ruta = CONFIG.setSeparator(CONFIG.getRutaComandesEnEdicio)
        If CONFIG.folderExist(ruta) Then
            Using fitxer As New IO.StreamWriter(ruta & f)
                fitxer.WriteLine(comandaTxt.empresa & ";" & p.empresa.id)
                fitxer.WriteLine(comandaTxt.projecte & ";" & p.projecte.id)
                fitxer.WriteLine(comandaTxt.magatzem & ";" & p.magatzem.id)

                fitxer.WriteLine(comandaTxt.contacteProjecte & ";" & p.contacte.id)
                fitxer.WriteLine(comandaTxt.responsableProjecte)
                fitxer.WriteLine(comandaTxt.directorProjecte)
                fitxer.WriteLine(comandaTxt.proveidor & ";" & p.proveidor.id)
                fitxer.WriteLine(comandaTxt.departementProveidor & ";" & p.contacteProveidor.id)
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
                For Each a In p.articles
                    fitxer.WriteLine(comandaTxt.article & ";iniciArticle" & i)
                    fitxer.WriteLine(comandaTxt.articleId & ";" & a.article.id)
                    fitxer.WriteLine(comandaTxt.refArticle & ";" & a.article.codi)
                    fitxer.WriteLine(comandaTxt.quantitatArticle & ";" & a.quantitat)
                    fitxer.WriteLine(comandaTxt.unitatArticle & ";" & a.article.unitat.id)
                    fitxer.WriteLine(comandaTxt.descripcioArticle & ";" & a.nom)
                    fitxer.WriteLine(comandaTxt.importArticle & ";" & a.preu.preu)
                    fitxer.WriteLine(comandaTxt.descompteArticle & ";" & a.preu.descompte)
                    fitxer.WriteLine(comandaTxt.ivaArticle & ";" & a.article.iva.id)
                    fitxer.WriteLine(comandaTxt.article & ";finalArticle" & i)
                    i = i + 1
                Next

            End Using
        End If
        a = Nothing
    End Sub
    Public Function getComandes() As List(Of Comanda)
        Dim ruta As String, c As Comanda, i As Integer, f As String, fila() As String
        ruta = CONFIG.setSeparator(CONFIG.getRutaComandesEnEdicio)
        f = Dir(ruta & "* .txt", FileAttribute.Normal)
        If CONFIG.folderExist(ruta & f) Then
            Using fitxer As New IO.StreamReader(ruta)
                fila = Split(fitxer.ReadLine(), ";")
                If UBound(fila) Then
                    c = New Comanda
                    Select Case fila(0)
                        Case comandaTxt.empresa : c.empresa = ModelEmpresa.getObject(CInt(fila(1)))
                        Case comandaTxt.projecte : c.projecte = ModelProjecte.getObject(CInt(fila(1)))
                        Case comandaTxt.magatzem : c.magatzem = ModelLlocEntrega.getObject(CInt(fila(1)))
                        Case comandaTxt.contacteProjecte : c.contacte = ModelContacte.getObject(CInt(fila(1)))
                        Case comandaTxt.responsableProjecte : c.projecte.responsable = c.projecte
                        Case comandaTxt.responsableProjecte : c.projecte.responsable = c.projecte

                        Case comandaTxt.directorProjecte
                        Case comandaTxt.proveidor
                        Case comandaTxt.departementProveidor
                        Case comandaTxt.ncomanda
                        Case comandaTxt.datacomanda
                        Case comandaTxt.ports
                        Case comandaTxt.dataEntrega
                        Case comandaTxt.dataMuntatge
                        Case comandaTxt.retencio
                        Case comandaTxt.intAval
                        Case comandaTxt.nOferta
                        Case comandaTxt.tipusPagament
                        Case comandaTxt.dadesComanda


                            ' ens cal decidir quan principi i final
                        Case comandaTxt.article


                        Case comandaTxt.articleId
                        Case comandaTxt.refArticle
                        Case comandaTxt.quantitatArticle
                        Case comandaTxt.unitatArticle
                        Case comandaTxt.descripcioArticle
                        Case comandaTxt.importArticle
                        Case comandaTxt.descompteArticle
                        Case comandaTxt.ivaArticle
                    End Select
                End If
            End Using
        End If
    End Function

    Private Function getLine()

    End Function

End Module
