Option Explicit On
Module ModulImportSolicituds
    Private Const TIPUS_FITXER As String = ".xmm"
    Private dateUpdate As Date
    Private objects As List(Of SolicitudComanda)
    Private Const EMPRESA As String = "empresa"
    Private Const PROJECTE As String = "projecte"
    Private Const DEPARTAMENT As String = "departament"
    Private Const ID_PROVEIDOR As String = "idProveidor"
    Private Const PROVEIDOR As String = "proveidor"
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
    Private Const LLOC_ENTREGA As String = "llocEntrega"
    Private Const DIRECCIO_ENTREGA As String = "direccioEntrega"
    Private Const CONTACTE_ENTREGA As String = "contacteEntrega"
    Private Const TELEFON_ENTREGA As String = "telefonEntrega"
    Private Const DATA_ENTREGA As String = "dataEntrega"
    Private Const DATA_FINALITZACIO As String = "dataFinalitzacio"
    Private Const OFERTA1 As String = "oferta1"
    Private Const OFERTA2 As String = "oferta2"
    Private Const OFERTA3 As String = "oferta3"
    Private Const COMPARATIU As String = "comparatiu"
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
    Private logActual As Log

    Private Function getSolicitudComanda(f As String) As SolicitudComanda
        Dim c As SolicitudComanda, a As articleComanda, fila() As String
        If CONFIG.fileExist(f) Then
            c = New SolicitudComanda

            Using fitxer As New IO.StreamReader(f)
                logActual.entrades.Add(ModelLog.getEntradaLog(tipusEntradaLog.MIS_LOG, IDIOMA.getString("importDadesDe"), f))
                Do
                    fila = Split(fitxer.ReadLine(), ";")
                    If UBound(fila) > 0 Then
                        Select Case fila(0)
                            Case EMPRESA : c.empresa = fila(1)
                            Case PROJECTE : c.codiProjecte = fila(1)
                            Case DEPARTAMENT : c.departament = fila(1)
                            Case LLOC_ENTREGA : c.llocEntrega = fila(1)
                            Case DIRECCIO_ENTREGA = c.direccioEntrega = fila(1)
                            Case CONTACTE_ENTREGA : c.contacteEntrega = fila(1)
                            Case TELEFON_ENTREGA : c.telefonEntrega = fila(1)
                            Case PROVEIDOR : c.proveidor = fila(1)
                            Case ID_PROVEIDOR : c.idProveidor = fila(1)
                            Case CONTACTE_PROVEIDOR : c.contacteProveidor = fila(1)
                            Case TELEFON_PROEVEIDOR : c.telefonProveidor = fila(1)
                            Case EMAIL_PROVEIDOR : c.emailProveidor = fila(1)
                            Case SUMINISTRE_MATERIAL : c.suministreMaterial = CBool(fila(1))
                            Case EMBALATGE : c.embalatge = CBool(fila(1))
                            Case TRANSPORT : c.transport = CBool(fila(1))
                            Case MUNTATGE : c.muntatge = CBool(fila(1))
                            Case SUPERVISIO : c.supervisio = CBool(fila(1))
                            Case POSTAPUNT : c.postaApunt = CBool(fila(1))
                            Case PROVES_TALLER : c.provesTaller = CBool(fila(1))
                            Case PROVES_OBRA : c.provesObra = CBool(fila(1))
                            Case POSTA_SERVEI : c.postaServei = CBool(fila(1))
                            Case ALTRES_ALCANS : c.altresAlcans = CBool(fila(1))
                            Case DATA_ENTREGA : If IsDate(fila(1)) Then c.dataEntrega = CDate(fila(1))
                            Case DATA_FINALITZACIO : If IsDate(fila(1)) Then c.dataFinalitzacio = CDate(fila(1))
                            Case FORMA_PAGAMENT : c.formaPagament = fila(1)
                            Case OFERTA1 : c.oferta1 = fila(1)
                            Case OFERTA2 : c.oferta2 = fila(1)
                            Case OFERTA3 : c.oferta3 = fila(1)
                            Case COMPARATIU : c.comparatiu = fila(1)
                            Case ALTRES_DOCUMENTACIO : c.altresDocumentacio = fila(1)
                            Case INICI_ARTICLE : a = New articleComanda
                            Case REFERENCIA : a.codi = fila(1)
                            Case POS_ARTICLE : a.pos = fila(1)
                            Case QUANTITAT : If CONFIG.isNumericPositiu(fila(1)) Then a.quantitat = fila(1) Else a.quantitat = 0
                            Case UNITAT : a.unitat = ModelUnitat.getAuxiliar.getObjectAprox(fila(1))
                            Case DESCRIPCIO : a.nom = fila(1)
                            Case PREU_UNITARI : If IsNumeric(fila(1)) Then a.preu = fila(1)
                            Case DESCOMPTE : If IsNumeric(fila(1)) Then a.tpcDescompte = fila(1)
                            Case FI_ARTICLE : If Not IsNothing(a) Then c.articles.Add(a)
                        End Select
                        logActual.entrades.Add(ModelLog.getEntradaLog(tipusEntradaLog.MIS_LOG, fila(0), fila(1)))
                    End If
                Loop While Not fitxer.EndOfStream
            End Using
            Return c
        End If
        Return Nothing
    End Function
    Public Sub importFitxers()
        Dim ruta As String, f As String, sc As SolicitudComanda
        ruta = CONFIG.getRutaComandesEnEdicio
        logActual = New Log()
        logActual.titol = IDIOMA.getString("titolLogImportSolicituts")
        logActual.descripcio = IDIOMA.getString("descripcioLogImportSolicituts")

        If CONFIG.folderExist(ruta) Then
            f = Dir(CONFIG.setSeparator(ruta) & "*.xmm", FileAttribute.Normal)
            Do While f <> ""
                sc = getSolicitudComanda(CONFIG.setSeparator(ruta) & f)
                If Not IsNothing(sc) Then
                    logActual.entrades.Add(ModelLog.getEntradaLog(tipusEntradaLog.AVIS_log, IDIOMA.getString("guardaSolicitut"), f))
                    sc.id = ModelComandaSolicitud.save(sc)
                    If sc.id > -1 Then
                        logActual.entrades.Add(ModelLog.getEntradaLog(tipusEntradaLog.AVIS_log, IDIOMA.getString("borraFitxerDades"), f))
                        Call setFitxer(ruta, f)
                    End If
                End If
                f = Dir()
            Loop
        End If
        Call frmIniComanda.setLog(logActual)
        logActual = Nothing
    End Sub
    Private Function setFitxer(ruta As String, f As String) As Boolean
        If CONFIG.fileExist(CONFIG.setSeparator(ruta) & f) Then
            Call FileCopy(CONFIG.setSeparator(ruta) & f, CONFIG.getRutaComandesImportades & f)
            Call Kill(CONFIG.setSeparator(ruta) & f)
        End If
        Return False
    End Function
End Module
