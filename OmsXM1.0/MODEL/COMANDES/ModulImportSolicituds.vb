Option Explicit On
Imports System.Text
Module ModulImportSolicituds
    Private objects As List(Of CodiDescripcio)
    Private Const TIPUS_FITXER As String = ".xmm"
    Private Const EMPRESA As String = "empresa"
    Private Const PROJECTE As String = "projecte"
    Private Const DEPARTAMENT As String = "departament"
    Private Const ID_PROVEIDOR As String = "idProveidor"
    Private Const PROVEIDOR As String = "proveidor"
    Private Const ID_CONTACTE_PROVEIDOR As String = "idContacteProveidor"
    Private Const CONTACTE_PROVEIDOR As String = "contacteProveidor"
    Private Const TELEFON_PROEVEIDOR As String = "telefonProveidor"
    Private Const EMAIL_PROVEIDOR As String = "emailProveidor"
    Private Const SUMINISTRE_MATERIAL As String = "suministreMaterial"
    Private Const EMBALATGE As String = "embalatge"
    Private Const TRANSPORT As String = "transport"
    Private Const MUNTATGE As String = "muntatge"
    Private Const SUPERVISIO As String = "supervisio"
    Private Const POSTAPUNT As String = "postapunt"
    Private Const PROVES_TALLER As String = "provesTaller"
    Private Const PROVES_OBRA As String = "provesObra"
    Private Const POSTA_SERVEI As String = "postaServei"
    Private Const ALTRES_ALCANS As String = "altresAlcans"
    Private Const ID_LLOC_ENTREGA As String = "idLlocEntrega"
    Private Const LLOC_ENTREGA As String = "llocEntrega"
    Private Const DIRECCIO_ENTREGA As String = "direccioEntrega"
    Private Const ID_CONTACTE_ENTREGA As String = "idContacteEntrega"
    Private Const CONTACTE_ENTREGA As String = "contacteEntrega"
    Private Const TELEFON_ENTREGA As String = "telefonEntrega"
    Private Const EMAIL_ENTREGA As String = "emailEntrega"
    Private Const DATA_COMANDA As String = "dataSolicitud"
    Private Const DATA_ENTREGA As String = "dataEntrega"
    Private Const DATA_FINALITZACIO As String = "dataFinalitzacio"
    Private Const OFERTA1 As String = "oferta1"
    Private Const documentacio As String = "adjunt"
    Private Const FORMA_PAGAMENT As String = "formaPagament"
    Private Const ALTRES_DOCUMENTACIO As String = "altres"
    Private Const INICI_ARTICLE As String = "iniciArticle"
    Private Const POS_ARTICLE As String = "posArticle"
    Private Const QUANTITAT As String = "quantitat"
    Private Const UNITAT As String = "unitat"
    Private Const REFERENCIA As String = "referencia"
    Private Const DESCRIPCIO As String = "descripcio"
    Private Const PREU_UNITARI As String = "preuUnitari"
    Private Const DESCOMPTE As String = "descompte"
    Private Const FI_ARTICLE As String = "fiArticle"
    Private Const ID_RESPONSABLE As String = "idResponsableCompra"
    Private Const RESPONSABLE As String = "responsableCompra"
    Private Const FITXER_PDF As String = "fitxerPDF"
    Private logActual As Log

    Private Function getSolicitudComanda(f As String) As SolicitudComanda
        Dim c As SolicitudComanda, a As ArticleSolicitut, fila() As String, d As doc, isDescripcioArticle As Boolean

        If CONFIG.fileExist(f) Then
            c = New SolicitudComanda
            c.nom = f
            Using fitxer As New IO.StreamReader(f, Encoding.GetEncoding(1252)) ' obre el fitxer 
                If Not logActual Is Nothing Then logActual.entrades.Add(ModelLog.getEntradaLog(tipusEntradaLog.MIS_LOG, IDIOMA.getString("importDadesDe"), f))
                Do
                    fila = Split(fitxer.ReadLine(), ";")
                    If isDescripcioArticle And UBound(fila) = 0 Then
                        a.descripcio.Add(fila(0))
                    ElseIf UBound(fila) > 0 Then
                        Select Case fila(0)
                            Case EMPRESA : c.empresa = fila(1)
                            Case ID_RESPONSABLE : c.IdResponsableCompra = fila(1)
                            Case RESPONSABLE : c.responsableCompra = fila(1)
                            Case DATA_COMANDA : c.dataComanda = fila(1)
                            Case PROJECTE : c.codiProjecte = fila(1)
                            Case DEPARTAMENT : c.departament = fila(1)
                            Case ID_LLOC_ENTREGA : c.idLlocEntrega = fila(1)
                            Case LLOC_ENTREGA : c.llocEntrega = fila(1)
                            Case DIRECCIO_ENTREGA : c.direccioEntrega = fila(1)
                            Case ID_CONTACTE_ENTREGA : c.idContacteEntrega = fila(1)
                            Case CONTACTE_ENTREGA : c.contacteEntrega = fila(1)

                            Case EMAIL_ENTREGA : c.emailEntrega = fila(1)
                            Case TELEFON_ENTREGA : c.telefonEntrega = fila(1)
                            Case ID_CONTACTE_PROVEIDOR : c.idContacteProveidor = fila(1)
                            Case PROVEIDOR : c.proveidor = fila(1)
                            Case ID_PROVEIDOR : c.idProveidor = fila(1)
                            Case CONTACTE_PROVEIDOR : c.contacteProveidor = fila(1)
                            Case TELEFON_PROEVEIDOR : c.telefonProveidor = fila(1)
                            Case EMAIL_PROVEIDOR : c.emailProveidor = fila(1)
                            Case SUMINISTRE_MATERIAL : c.suministreMaterial = CONFIG.validarBoolean(fila(1))
                            Case EMBALATGE : c.embalatge = CONFIG.validarBoolean(fila(1))
                            Case TRANSPORT : c.transport = CONFIG.validarBoolean(fila(1))
                            Case MUNTATGE : c.muntatge = CONFIG.validarBoolean(fila(1))
                            Case SUPERVISIO : c.supervisio = CONFIG.validarBoolean(fila(1))
                            Case POSTAPUNT : c.postaApunt = CONFIG.validarBoolean(fila(1))
                            Case PROVES_TALLER : c.provesTaller = CONFIG.validarBoolean(fila(1))
                            Case PROVES_OBRA : c.provesObra = CONFIG.validarBoolean(fila(1))
                            Case POSTA_SERVEI : c.postaServei = CONFIG.validarBoolean(fila(1))
                            Case ALTRES_ALCANS : c.altresAlcans = CONFIG.validarBoolean(fila(1))
                            Case DATA_ENTREGA : If IsDate(fila(1)) Then c.dataEntrega = CDate(fila(1))
                            Case DATA_FINALITZACIO : If IsDate(fila(1)) Then c.dataFinalitzacio = CDate(fila(1))
                            Case FORMA_PAGAMENT : c.formaPagament = fila(1)
                            Case OFERTA1 : c.oferta1 = fila(1)
                            Case documentacio
                                d = New doc
                                d.codi = "OFERTA"
                                d.nom = fila(1)
                                c.documentacio.Add(d)
                            Case ALTRES_DOCUMENTACIO : c.altresDocumentacio = fila(1)
                            Case FITXER_PDF
                                d = New doc
                                d.codi = "F56"
                                d.nom = fila(1)
                                c.documentacio.Add(d)
                            Case INICI_ARTICLE
                                a = New ArticleSolicitut
                                isDescripcioArticle = False
                            Case REFERENCIA
                                a.codi = fila(1)
                                isDescripcioArticle = False
                            Case POS_ARTICLE : a.pos = fila(1)
                                isDescripcioArticle = False
                            Case QUANTITAT
                                If CONFIG.isNumericPositiu(fila(1)) Then a.quantitat = fila(1) Else a.quantitat = 0
                                isDescripcioArticle = False
                            Case UNITAT
                                a.unitat = CONFIG.validarNull(fila(1))
                                isDescripcioArticle = False
                            Case DESCRIPCIO
                                a.nom = fila(1)
                                isDescripcioArticle = True
                            Case PREU_UNITARI
                                If IsNumeric(fila(1)) Then a.preu = fila(1)
                                isDescripcioArticle = False
                            Case DESCOMPTE
                                If IsNumeric(fila(1)) Then a.tpcDescompte = fila(1) * 100
                                isDescripcioArticle = False
                            Case FI_ARTICLE
                                If Not IsNothing(a) Then c.articles.Add(a)
                                isDescripcioArticle = False
                        End Select
                        If Not logActual Is Nothing Then logActual.entrades.Add(ModelLog.getEntradaLog(tipusEntradaLog.MIS_LOG, fila(0), fila(1)))
                    End If
                Loop While Not fitxer.EndOfStream
            End Using
            Return c
        End If
        Return Nothing
    End Function
    Public Function getObjects() As List(Of CodiDescripcio)
        Dim ruta As String, f As String, s As CodiDescripcio, i As Integer
        ruta = CONFIG_FILE.getTag(TAG.RUTA_FITXERS_SOLICITUT)
        getObjects = New List(Of CodiDescripcio)
        i = 1
        If CONFIG.folderExist(ruta) Then
            f = Dir(CONFIG.setSeparator(ruta) & "*.xmm", FileAttribute.Normal)
            Do While f <> ""
                s = New CodiDescripcio
                s.codi = i
                s.descripcio = CONFIG.setSeparator(ruta) & f
                i = i + 1
                getObjects.Add(s)
                f = Dir()
            Loop
        End If
        s = Nothing
    End Function

    Public Function getFitxer(id As Integer) As String
        Dim f As CodiDescripcio
        If objects Is Nothing Then objects = getObjects()

        For Each f In objects
            If f.codi = id Then
                Return f.descripcio
            End If
        Next
        Return Nothing
    End Function
    Public Function getObject(id As Integer) As CodiDescripcio
        Dim f As CodiDescripcio
        If objects Is Nothing Then objects = getObjects()
        For Each f In objects
            If f.codi = id Then
                Return f
            End If
        Next
        Return Nothing
    End Function
    Public Function getDataList(fitxers As List(Of CodiDescripcio), filtre As String) As DataList
        Dim f As CodiDescripcio, s As SolicitudComanda
        getDataList = New DataList
        getDataList.columns.Add(COLUMN.ID)
        getDataList.columns.Add(COLUMN.EMPRESA)
        getDataList.columns.Add(COLUMN.GENERICA("dataModificacio", 100, HorizontalAlignment.Center))
        getDataList.columns.Add(COLUMN.GENERICA("projecte", 150, HorizontalAlignment.Center))
        getDataList.columns.Add(COLUMN.GENERICA("proveidor", 300, HorizontalAlignment.Left))
        getDataList.columns.Add(COLUMN.GENERICA("llocEntrega", 300, HorizontalAlignment.Left))
        getDataList.columns.Add(COLUMN.GENERICA("contacte", 150, HorizontalAlignment.Left))
        getDataList.columns.Add(COLUMN.GENERICA("responsableCompra", 150, HorizontalAlignment.Left))
        getDataList.columns.Add(COLUMN.GENERICA("fitxer", 400, HorizontalAlignment.Center))

        For Each f In fitxers
            s = getSolicitudComanda(f.descripcio)
            If s Is Nothing Then
                s = New SolicitudComanda
            End If
            If s.isFilter(filtre, f.descripcio) Then
                getDataList.rows.Add(New ListViewItem(New String() {f.codi, s.empresa, CDate(CONFIG.getDateFileModified(f.descripcio)), s.codiProjecte, s.proveidor, s.llocEntrega, s.contacteEntrega, s.responsableCompra, f.descripcio}))
            End If
        Next
        s = Nothing
    End Function


    Public Sub reset()
        objects = Nothing
    End Sub
    Public Function importFitxers(fitxers As List(Of CodiDescripcio)) As List(Of SolicitudComanda)
        Dim f As CodiDescripcio, sc As SolicitudComanda, objects As List(Of SolicitudComanda), a As frmAvis, d As doc

        objects = New List(Of SolicitudComanda)
        a = New frmAvis(IDIOMA.getString("esperaUnMoment"), IDIOMA.getString("importarF56"), fitxers.Count)
        For Each f In fitxers
            sc = getSolicitudComanda(f.descripcio)
            If Not IsNothing(sc) Then

                objects.Add(sc)
                    a.setData(IDIOMA.getString("importarF56"), f.descripcio)
                    ' End If
                End If
        Next
        a.tancar()
        f = Nothing
        sc = Nothing
        Return objects
    End Function
    Public Function remove(f As String) As Boolean
        Dim s As SolicitudComanda, d As doc, ruta As String
        s = getSolicitudComanda(f)
        Try
            If CONFIG.fileExist(f) Then
                My.Computer.FileSystem.MoveFile(f, CONFIG.setSeparator(CONFIG.getRutaComandesImportades) & CONFIG.getFitxer(f), True)
                'My.Computer.FileSystem.DeleteFile(f)
                'Call Kill(f)

                ruta = CONFIG.setFolder(CONFIG.getDirectori(f))
                For Each d In s.documentacio
                    If CONFIG.fileExist(ruta & d.nom) Then
                        'My.Computer.FileSystem.DeleteFile(ruta & d.nom)
                        My.Computer.FileSystem.MoveFile(ruta & d.nom, CONFIG.setSeparator(CONFIG.getRutaComandesImportades) & d.nom, True)
                        'Kill(ruta & d.nom)
                    End If
                Next
                objects = getObjects()
                Return True
            End If
        Catch ex As Exception
            Return False
        End Try
        Return False
    End Function
    Public Function save(sc As SolicitudComanda) As Boolean
        sc.id = ModelComandaSolicitud.save(sc)
        If sc.id > 0 Then
            For Each d In sc.documentacio
                d.idSolicitut = sc.id
                d.anyo = sc.getAnyo
                If ModelDocumentacio.save(d) > 0 Then
                    If CONFIG.fileExist(CONFIG.setSeparator(CONFIG_FILE.getTag(TAG.RUTA_FITXERS_SOLICITUT)) & d.nom) Then
                        My.Computer.FileSystem.MoveFile(CONFIG.setSeparator(CONFIG_FILE.getTag(TAG.RUTA_FITXERS_SOLICITUT)) & d.nom, CONFIG.setSeparator(CONFIG.getDirectoriServidorOfertes) & d.nom, True)
                        'Call FileCopy(CONFIG.setSeparator(CONFIG_FILE.getTag(TAG.RUTA_FITXERS_SOLICITUT)) & d.nom, CONFIG.setSeparator(CONFIG.getDirectoriServidorOfertes) & d.nom)
                        'Kill(CONFIG.setSeparator(CONFIG_FILE.getTag(TAG.RUTA_FITXERS_SOLICITUT)) & d.nom)                        
                    End If
                End If
            Next
            Call setFitxers(sc.nom, sc.documentacio)
            Return True
        End If
        Return False
    End Function
    Private Function setFitxers(f As String, docs As List(Of doc)) As Boolean

        If CONFIG.fileExist(f) Then
            My.Computer.FileSystem.MoveFile(f, CONFIG.setSeparator(CONFIG.getRutaComandesImportades) & CONFIG.getFitxer(f), True)
            'Call FileCopy(f, CONFIG.setSeparator(CONFIG.getRutaComandesImportades) & CONFIG.getFitxer(f))
            'Call Kill(f)
        End If
        For Each d In docs

        Next d
        Return False
    End Function

End Module
