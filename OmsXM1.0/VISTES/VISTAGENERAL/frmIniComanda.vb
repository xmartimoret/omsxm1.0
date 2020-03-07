
Imports System.Drawing
Imports System.Windows.Forms

Public Class frmIniComanda
    Private tabs As List(Of tabControl)
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
        Me.mnuComandes.Text = IDIOMA.getString("mnuComandes")
        Me.mnuConfig.Text = IDIOMA.getString("mnuConfig_Caption")
        Me.mnuFabricants.Text = IDIOMA.getString("fabricants")
        Me.mnuFamilies.Text = IDIOMA.getString("families")
        Me.mnuImportarComandes.Text = IDIOMA.getString("mnuImportarComandes")
        Me.mnuInformes.Text = IDIOMA.getString("mnuInformes")
        Me.mnuNovaComanda.Text = IDIOMA.getString("mnuNovaComanda")
        Me.mnuPaisos.Text = IDIOMA.getString("paisos")
        Me.mnuProveidors.Text = IDIOMA.getString("proveidors")
        Me.mnuProvincies.Text = IDIOMA.getString("provincies")
        Me.mnuTipusIva.Text = IDIOMA.getString("tipusIva")
        Me.mnuTipusPagament.Text = IDIOMA.getString("tipusPagament")
        Me.mnuUnitats.Text = IDIOMA.getString("unitats")

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
                Me.pData.Controls.Clear()
                Me.pData.Controls.Add(t.panel)
                t.panel.Show()
            End If
        Next
    End Sub

    Private Sub mnuNovaComanda_Click(sender As Object, e As EventArgs) Handles mnuNovaComanda.Click
        Dim i As Integer, c As Comanda
        c = DNovaComanda.getComanda
        If c IsNot Nothing Then
            i = getIdTab(IDIOMA.getString("mnuComandes"))
            If i > -1 Then
                Call activateTab(i)
            Else
                Call setTab(c.getCodiSolicitud, New pComanda(c))
            End If
        End If
        c = Nothing
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


    Private Sub mnuVeureComandaEdicio_Click(sender As Object, e As EventArgs) Handles mnuVeureComandaEdicio.Click
        Dim p As SelectSolicitudComandes
        p = New SelectSolicitudComandes(1, True, False)
        Call setTab(IDIOMA.getString("solicitudsComanda"), p)
    End Sub
    Friend Sub modificarSolicitudComanda(c As Comanda)
        Call setTab(c.getCodiSolicitud, New pComanda(c))
    End Sub
End Class
