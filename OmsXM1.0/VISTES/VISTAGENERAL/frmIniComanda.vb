
Imports System.Drawing
Imports System.Windows.Forms

Public Class frmIniComanda
    Private tabs As List(Of tabControl)
    Private refrescarSolicitudsComanda As Boolean
    Private refrescarComandaEnEdicio As Boolean
    Private refrescarFitxersF56 As Boolean
    Private idActual As Integer
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        tabs = New List(Of tabControl)
        Call setLanguage()
        If Not DBCONNECT.setConnectServer Then
            Dim fr As New frmServer
            fr.ShowDialog()
            fr.Dispose()
            fr = Nothing
        End If
    End Sub
    Private Sub setLanguage()
        Me.mnuAplicacio.Text = IDIOMA.getString("mnuAplicacio")
        Me.mnuApliServidor.Text = IDIOMA.getString("mnuConfigServer_Caption")
        Me.mnuApliRutaDirectori.Text = IDIOMA.getString("mnuConfigServerDirectori_Caption")

        Me.mnuArticles.Text = IDIOMA.getString("articles")
        Me.mnuAxiliars.Text = IDIOMA.getString("mnuAxiliars")
        Me.mnuCentres.Text = IDIOMA.getString("centres")
        Me.mnuLlocsEntrega.Text = IDIOMA.getString("mnuLlocsEntrega")
        Me.mnuContactesCentre.Text = IDIOMA.getString("mnuContactesCentre")
        Me.mnuComandes.Text = IDIOMA.getString("mnuComandes")
        Me.mnuConfig.Text = IDIOMA.getString("mnuConfig_Caption")
        Me.mnuFabricants.Text = IDIOMA.getString("fabricants")
        Me.mnuFamilies.Text = IDIOMA.getString("families")

        Me.mnuInformes.Text = IDIOMA.getString("mnuInformes")
        Me.mnuNovaComanda.Text = IDIOMA.getString("mnuNovaComanda")
        Me.mnuPaisos.Text = IDIOMA.getString("paisos")
        Me.mnuProveidors.Text = IDIOMA.getString("proveidors")
        Me.mnuProvincies.Text = IDIOMA.getString("provincies")
        Me.mnuTipusIva.Text = IDIOMA.getString("tipusIva")
        Me.mnuTipusPagament.Text = IDIOMA.getString("tipusPagament")
        Me.mnuUnitats.Text = IDIOMA.getString("unitats")

        Me.mnuSolicitutComanda.Text = IDIOMA.getString("mnuSolicitutComanda")
        Me.mnuEditarSolicitutComanda.Text = IDIOMA.getString("mnuEditarSolicitutF56")
        Me.mnuImportF56.Text = IDIOMA.getString("importarF56")
        Me.mnuEditarSolicitutComanda.Text = IDIOMA.getString("editarF56")

        Me.mnuComandes.Text = IDIOMA.getString("comanda")
        Me.mnuVeureComandaEdicio.Text = IDIOMA.getString("veureComandaEdicio")
        Me.mnuComandesEnviar.Text = IDIOMA.getString("veureComandaEnviar")

    End Sub

    Private Sub setTabs()
        Dim t As tabControl, posLeft As Integer, posTop As Integer
        posLeft = 4
        posTop = 4
        panelTabs.Controls.Clear()
        For Each t In tabs
            panelTabs.Controls.Add(t)
            t.Left = posLeft
            t.Top = posTop
            AddHandler t.close, AddressOf closetab
            AddHandler t.isActivate, AddressOf activateTab
            posLeft = t.Left + t.Width + 4
        Next
    End Sub
    Private Sub closetab(id As Integer)
        Dim t As tabControl
        Me.pData.Controls.Clear()
        For Each t In tabs
            If t.id = id Then
                tabs.Remove(t)
                Exit For
            End If
        Next
        Call setTabs()
    End Sub
    Private Sub activateTab(id As Integer)
        Dim t As tabControl
        For Each t In tabs
            If t.id <> id Then
                t.deActivate()
                t.panel.Hide()
            Else
                t.activate()
                If t.nom = IDIOMA.getString("solicitudsComanda") Then
                    If refrescarSolicitudsComanda Then
                        t.panel = New SelectSolicitudComandes(1, True, False)
                        t.panel.Dock = DockStyle.Fill
                        refrescarSolicitudsComanda = False
                    End If
                ElseIf t.nom = IDIOMA.getString("comandesEdicio") Then
                    If refrescarComandaEnEdicio Then
                        t.panel = New SelectComandesEdicio(1, True, False)
                        t.panel.Dock = DockStyle.Fill
                        refrescarComandaEnEdicio = False
                    End If
                ElseIf t.nom = IDIOMA.getString("fitxersF56") Then
                    If refrescarFitxersF56 Then
                        t.panel = New SelectFitxersSolicitut(0, True, False)
                        t.panel.Dock = DockStyle.Fill
                    End If
                End If
                Me.pData.Controls.Clear()
                Me.pData.Controls.Add(t.panel)
                t.panel.Show()
                idActual = id
            End If
        Next
    End Sub

    Private Sub mnuNovaComanda_Click(sender As Object, e As EventArgs) Handles mnuNovaComanda.Click
        Dim i As Integer, c As Comanda, panelComanda As pComanda
        c = DNovaComanda.getComanda
        If c IsNot Nothing Then
            i = getIdTab(IDIOMA.getString("mnuComandes"))
            If i > -1 Then
                Call activateTab(i)
            Else
                panelComanda = New pComanda(c)
                Call setTab(c.ToStringCodi, panelComanda)
            End If
        End If
        c = Nothing
    End Sub
    Private Sub updatecomanda()
        refrescarComandaEnEdicio = True
    End Sub
    'Private Sub RemoveSelectSolicitud(c As SolicitudComanda)
    '    If ModelComandaSolicitud.remove(c) Then refrescarSolicitudsComanda = True
    'End Sub

    Private Sub setTab(titol As String, c As UserControl)
        Dim t As tabControl, i As Integer, posLeft As Integer
        i = getIdTab(titol)
        If i = -1 Then
            i = 1
            posLeft = 4
            For Each t In tabs
                i = i + 1
                posLeft = t.Left + t.Width + 4
            Next
            t = New tabControl(i, titol, c)
            tabs.Add(t)
            panelTabs.Controls.Add(t)
            t.Left = posLeft
            t.Top = 4
            AddHandler t.close, AddressOf closetab
            AddHandler t.isActivate, AddressOf activateTab
        End If
        Call activateTab(i)
    End Sub

    Private Sub mnuProveidors_Click(sender As Object, e As EventArgs) Handles mnuProveidors.Click
        Call setTab(IDIOMA.getString("proveidors"), New pProveidors)
    End Sub

    Private Sub mnuCentres_Click(sender As Object, e As EventArgs) Handles mnuCentres.Click
        Call setTab(IDIOMA.getString("centres"), New pProjectesContactes)
    End Sub
    Private Function getIdTab(p As String) As Integer
        Dim t As tabControl
        For Each t In tabs
            If p = t.nom Then
                Return t.id
            End If
        Next
        Return -1
    End Function

    Friend Sub modificarComanda(c As Comanda)
        Dim panelComanda As pComanda
        panelComanda = New pComanda(c)
        Call setTab(c.ToStringCodi, panelComanda)
        AddHandler panelComanda.UpdateComanda, AddressOf updateComanda
    End Sub
    Friend Sub modificarSolicitut(c As SolicitudComanda, tipusComanda As Integer)
        Dim panelComanda As pSolicitutComanda
        panelComanda = New pSolicitutComanda(c)
        Call setTab(c.toStringCodi, panelComanda)
        'AddHandler panelComanda.removeItem, AddressOf RemoveSelectSolicitud
    End Sub
    Private Sub mnuArticles_Click(sender As Object, e As EventArgs) Handles mnuArticles.Click
        Dim p As pArticlesPreus
        p = New pArticlesPreus()
        Call setTab(IDIOMA.getString("articles"), p)

    End Sub

    Private Sub mnuTipusPagament_Click(sender As Object, e As EventArgs) Handles mnuTipusPagament.Click
        Dim p As DAuxiliars
        p = New DAuxiliars
        p.setTipusPagament()
        p = Nothing
    End Sub
    Private Sub mnuPaisos_Click(sender As Object, e As EventArgs) Handles mnuPaisos.Click
        Dim p As DAuxiliars
        p = New DAuxiliars
        p.setPaisos()
        p = Nothing
    End Sub

    Private Sub mnuProvincies_Click(sender As Object, e As EventArgs) Handles mnuProvincies.Click
        Dim p As DAuxiliars
        p = New DAuxiliars
        p.setProvincies()
        p = Nothing
    End Sub
    Private Sub mnuTipusIva_Click(sender As Object, e As EventArgs) Handles mnuTipusIva.Click
        Dim p As DAuxiliars
        p = New DAuxiliars
        p.setTipusIva()
        p = Nothing
    End Sub

    Private Sub mnuUnitats_Click(sender As Object, e As EventArgs) Handles mnuUnitats.Click
        Dim p As DAuxiliars
        p = New DAuxiliars
        p.setUnitats()
        p = Nothing
    End Sub


    Private Sub mnuFamilies_Click(sender As Object, e As EventArgs) Handles mnuFamilies.Click
        Dim p As DAuxiliars
        p = New DAuxiliars
        p.setFamilies()
        p = Nothing
    End Sub

    Private Sub mnuFabricants_Click(sender As Object, e As EventArgs) Handles mnuFabricants.Click
        Dim p As DAuxiliars
        p = New DAuxiliars
        p.setFabricants()
        p = Nothing
    End Sub



    Private Sub mnuVeureSolicituts_Click(sender As Object, e As EventArgs) Handles mnuEditarSolicitutComanda.Click
        Dim p As SelectSolicitudComandes
        p = New SelectSolicitudComandes(1, True, False)
        Call setTab(IDIOMA.getString("solicitudsComanda"), p)
    End Sub
    Friend Sub setLog(l As Log)
        Dim p As panelLog
        p = New panelLog(l)
        Call setTab(l.titol, p)
    End Sub

    Private Sub setFitxers(fitxers As List(Of CodiDescripcio))
        Call ModulImportSolicituds.importFitxers(fitxers)

        refrescarSolicitudsComanda = True
    End Sub
    Private Sub mnuApliServidor_Click(sender As Object, e As EventArgs) Handles mnuApliServidor.Click
        Dim fr As New frmServer
        fr.ShowDialog()
        fr.Dispose()
        fr = Nothing
    End Sub

    Private Sub mnuApliRutaDirectori_Click(sender As Object, e As EventArgs) Handles mnuApliRutaDirectori.Click
        Dim f As New dRutaServidorDades, ruta As String
        ruta = f.getDirectori(CONFIG_FILE.getTag(CONFIG_FILE.TAG.RUTA_SERVIDOR_DADES), IDIOMA.getString("configRutaServidorDades"))
        f.Dispose()
        If CONFIG.folderExist(ruta) Then
            Call CONFIG_FILE.setTag(CONFIG_FILE.TAG.RUTA_SERVIDOR_DADES, ruta)
        End If

        f = Nothing
    End Sub

    Private Sub mnuimportSolicitut_Click(sender As Object, e As EventArgs)
        'Dim objects As List(Of SolicitudComanda), c As Comanda, s As SolicitudComanda, p As SelectComandesEdicio, i As Integer
        'objects = ModulImportSolicituds.importFitxers(ModulImportSolicituds.getObjects())
        'i = 0
        'If objects.Count > 0 Then
        '    For Each s In objects
        '        s.id = ModelComandaSolicitud.save(s)
        '        If s.id > 0 Then
        '            c = ModelComandaEnEdicio.getNewComandaToF56(s)
        '            If Not IsNothing(c) Then
        '                c.idSolicitut = s.id
        '                c.id = ModelComandaEnEdicio.save(c)
        '                i = i + 1
        '            End If
        '        End If
        '    Next
        '    If i > 0 Then
        '        refrescarComanda = True
        '        p = New SelectComandesEdicio(1, True, False)
        '        Me.Visible = False
        '        Call setTab(IDIOMA.getString("comandesEdicio"), p)
        '        Me.Visible = True
        '    End If
        'End If
        'objects = Nothing
        's = Nothing
        'c = Nothing
        Dim p As SelectFitxersSolicitut
        p = New SelectFitxersSolicitut(0, True, False)
        refrescarFitxersF56 = False
        Call setTab(IDIOMA.getString("fitxersF56"), p)
        AddHandler p.selectObject, AddressOf importFitxersf56

    End Sub
    Private Sub importFitxersf56(fitxers As List(Of CodiDescripcio))
        Dim objects As List(Of SolicitudComanda), c As Comanda, s As SolicitudComanda, p As SelectComandesEdicio, i As Integer
        objects = ModulImportSolicituds.importFitxers(fitxers)
        i = 0
        If objects.Count > 0 Then
            For Each s In objects
                s.id = ModelComandaSolicitud.save(s)

                If s.id > 0 Then
                    c = ModelComandaEnEdicio.getNewComandaToF56(s)
                    If Not IsNothing(c) Then
                        c.idSolicitut = s.id
                        c.estat = 0
                        c.id = ModelComandaEnEdicio.save(c)
                        i = i + 1
                    End If
                End If
            Next
            If i > 0 Then
                refrescarComandaEnEdicio = True
                p = New SelectComandesEdicio(1, True, False)
                Me.Visible = False
                Call setTab(IDIOMA.getString("comandaEdicio"), p)
                Me.Visible = True
            End If
            refrescarFitxersF56 = True
        End If
        objects = Nothing
        s = Nothing
        c = Nothing
    End Sub

    Private Sub mnuVeureComandaEdicio_Click(sender As Object, e As EventArgs) Handles mnuVeureComandaEdicio.Click
        Dim p As SelectComandesEdicio
        p = New SelectComandesEdicio(1, True, False)
        Me.Visible = False
        Call setTab(IDIOMA.getString("comandesEdicio"), p)
        Me.Visible = True
    End Sub
    Friend Sub activatePrevious()
        Call closetab(idActual)
        Call activateTab(idActual - 1)
    End Sub

    Private Sub ImportarSolicitutdDeComandaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mnuImportF56.Click
        Dim p As SelectFitxersSolicitut
        p = New SelectFitxersSolicitut(0, True, False)
        refrescarFitxersF56 = False
        Call setTab(IDIOMA.getString("fitxersF56"), p)
        AddHandler p.selectObject, AddressOf importFitxersf56
    End Sub

    Private Sub frmIniComanda_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub mnuComandes_Click(sender As Object, e As EventArgs) Handles mnuComandes.Click

    End Sub

    Private Sub mnuLlocsEntrega_Click(sender As Object, e As EventArgs) Handles mnuLlocsEntrega.Click
        Dim p As SelectLlocEntrega
        p = New SelectLlocEntrega(1, True, False, IDIOMA.getString("magatzemsLlocsEntrega"), 1)
        Call setTab(IDIOMA.getString("magatzems"), New pLlocEntrega)
    End Sub

    Private Sub mnuContactesCentre_Click(sender As Object, e As EventArgs) Handles mnuContactesCentre.Click
        Call setTab(IDIOMA.getString("contactesProjecte"), New pContactes)
    End Sub
End Class
