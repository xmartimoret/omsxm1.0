
Imports System.Drawing
Imports System.Windows.Forms

Public Class frmIniComanda
    Private tabs As List(Of tabControl)
    Private refrescarSolicitudsComanda As Boolean
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
        Me.mnuSolicituts.Text = IDIOMA.getString("mnuSolicituts")
        Me.mnuNovaSolicitut.Text = IDIOMA.getString("mnuNouF56")
        Me.mnuVeureSolicituts.Text = IDIOMA.getString("mnuVeureSolicituts")
        Me.mnuImportarSolicituts.Text = IDIOMA.getString("mnuImportarSolicituts")
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
                End If
                Me.pData.Controls.Clear()
                Me.pData.Controls.Add(t.panel)
                t.panel.Show()
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
                panelComanda = New pComanda(c, 1)
                Call setTab(c.getCodiSolicitud, panelComanda)
                'AddHandler panelComanda.AddItem, AddressOf RefreshComanda
            End If
        End If


        c = Nothing
    End Sub
    Private Sub RemoveSelectComanda(c As Comanda, tipusComanda As Integer)
        If ModelComandaSolicitud.remove(c) Then refrescarSolicitudsComanda = True
    End Sub
    Private Sub RefreshComanda()
        '1. Ens cal cercar si existeix el selectComandes. i si es una solicitud de comanda. 
        refrescarSolicitudsComanda = True
    End Sub
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

    Friend Sub modificarComanda(c As Comanda, tipusComanda As Integer)
        Dim panelComanda As pComanda
        panelComanda = New pComanda(c, tipusComanda)
        If tipusComanda = 0 Then
            Call setTab(c.getCodiSolicitud, panelComanda)
        Else
            Call setTab(c.getCodiString, panelComanda)
        End If
        AddHandler panelComanda.removeItem, AddressOf RemoveSelectComanda
    End Sub
    Friend Sub modificarSolicitut(c As SolicitudComanda, tipusComanda As Integer)
        Dim panelComanda As pComanda
        panelComanda = New pComanda(c, tipusComanda)

        Call setTab(c.getCodiString, panelComanda)

        AddHandler panelComanda.removeItem, AddressOf RemoveSelectComanda
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

    Private Sub mnuNovaSolicitut_Click(sender As Object, e As EventArgs) Handles mnuNovaSolicitut.Click
        Dim i As Integer, c As Comanda, panelComanda As pComanda
        c = DNovaComanda.getComanda
        If c IsNot Nothing Then
            i = getIdTab(IDIOMA.getString("mnuComandes"))
            If i > -1 Then
                Call activateTab(i)
            Else
                panelComanda = New pComanda(c, 0)
                Call setTab(c.getCodiSolicitud, panelComanda)
                'AddHandler panelComanda.AddItem, AddressOf RefreshComanda
            End If
        End If

        c = Nothing
    End Sub

    Private Sub mnuVeureSolicituts_Click(sender As Object, e As EventArgs) Handles mnuVeureSolicituts.Click
        Dim p As SelectSolicitudComandes
        p = New SelectSolicitudComandes(1, True, False)

        Call setTab(IDIOMA.getString("solicitudsComanda"), p)
    End Sub
    Friend Sub setLog(l As Log)
        Dim p As panelLog
        p = New panelLog(l)
        Call setTab(IDIOMA.getString(l.titol), p)
    End Sub

    Private Sub mnuImportarSolicituts_Click(sender As Object, e As EventArgs) Handles mnuImportarSolicituts.Click
        Call ModulImportSolicituds.importFitxers()
    End Sub


End Class
