<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmIniComanda
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.pMenu = New System.Windows.Forms.Panel()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.mnuAplicacio = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuApliServidor = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuApliRutaDirectori = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuConfig = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuAxiliars = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTipusPagament = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuProvincies = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPaisos = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTipusIva = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuUnitats = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFamilies = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuCentres = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuLlocsEntrega = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuContactesCentre = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuProveidors = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFabricants = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuArticles = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSolicitutComanda = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuEditarSolicitutComanda = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuComandes = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuImportF56 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuNovaComanda = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuVeureComandaEdicio = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuVeureComandes = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuComandesEnviar = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuInformes = New System.Windows.Forms.ToolStripMenuItem()
        Me.panelTabs = New System.Windows.Forms.Panel()
        Me.pData = New System.Windows.Forms.Panel()
        Me.pMenu.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'pMenu
        '
        Me.pMenu.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pMenu.Controls.Add(Me.MenuStrip1)
        Me.pMenu.Location = New System.Drawing.Point(1, 0)
        Me.pMenu.Name = "pMenu"
        Me.pMenu.Size = New System.Drawing.Size(660, 33)
        Me.pMenu.TabIndex = 0
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuAplicacio, Me.mnuConfig, Me.mnuSolicitutComanda, Me.mnuComandes, Me.mnuInformes})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(4, 2, 0, 2)
        Me.MenuStrip1.Size = New System.Drawing.Size(660, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'mnuAplicacio
        '
        Me.mnuAplicacio.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuApliServidor, Me.mnuApliRutaDirectori})
        Me.mnuAplicacio.Name = "mnuAplicacio"
        Me.mnuAplicacio.Size = New System.Drawing.Size(66, 20)
        Me.mnuAplicacio.Text = "aplicacio"
        '
        'mnuApliServidor
        '
        Me.mnuApliServidor.Name = "mnuApliServidor"
        Me.mnuApliServidor.Size = New System.Drawing.Size(205, 22)
        Me.mnuApliServidor.Text = "Sewrvidor"
        '
        'mnuApliRutaDirectori
        '
        Me.mnuApliRutaDirectori.Name = "mnuApliRutaDirectori"
        Me.mnuApliRutaDirectori.Size = New System.Drawing.Size(205, 22)
        Me.mnuApliRutaDirectori.Text = "Ruta Directgori Aplicacio"
        '
        'mnuConfig
        '
        Me.mnuConfig.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuAxiliars, Me.ToolStripSeparator1, Me.mnuCentres, Me.mnuLlocsEntrega, Me.mnuContactesCentre, Me.ToolStripSeparator2, Me.mnuProveidors, Me.mnuFabricants, Me.ToolStripSeparator3, Me.mnuArticles})
        Me.mnuConfig.Name = "mnuConfig"
        Me.mnuConfig.Size = New System.Drawing.Size(86, 20)
        Me.mnuConfig.Text = "configuracio"
        '
        'mnuAxiliars
        '
        Me.mnuAxiliars.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuTipusPagament, Me.mnuProvincies, Me.mnuPaisos, Me.mnuTipusIva, Me.mnuUnitats, Me.mnuFamilies})
        Me.mnuAxiliars.Name = "mnuAxiliars"
        Me.mnuAxiliars.Size = New System.Drawing.Size(180, 22)
        Me.mnuAxiliars.Text = "auxiliars"
        '
        'mnuTipusPagament
        '
        Me.mnuTipusPagament.Name = "mnuTipusPagament"
        Me.mnuTipusPagament.Size = New System.Drawing.Size(154, 22)
        Me.mnuTipusPagament.Text = "tipusPagament"
        '
        'mnuProvincies
        '
        Me.mnuProvincies.Name = "mnuProvincies"
        Me.mnuProvincies.Size = New System.Drawing.Size(154, 22)
        Me.mnuProvincies.Text = "provincies"
        '
        'mnuPaisos
        '
        Me.mnuPaisos.Name = "mnuPaisos"
        Me.mnuPaisos.Size = New System.Drawing.Size(154, 22)
        Me.mnuPaisos.Text = "paisos"
        '
        'mnuTipusIva
        '
        Me.mnuTipusIva.Name = "mnuTipusIva"
        Me.mnuTipusIva.Size = New System.Drawing.Size(154, 22)
        Me.mnuTipusIva.Text = "tipus iva"
        '
        'mnuUnitats
        '
        Me.mnuUnitats.Name = "mnuUnitats"
        Me.mnuUnitats.Size = New System.Drawing.Size(154, 22)
        Me.mnuUnitats.Text = "Unitats"
        '
        'mnuFamilies
        '
        Me.mnuFamilies.Name = "mnuFamilies"
        Me.mnuFamilies.Size = New System.Drawing.Size(154, 22)
        Me.mnuFamilies.Text = "families"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(177, 6)
        '
        'mnuCentres
        '
        Me.mnuCentres.Name = "mnuCentres"
        Me.mnuCentres.Size = New System.Drawing.Size(180, 22)
        Me.mnuCentres.Text = "centrres"
        '
        'mnuLlocsEntrega
        '
        Me.mnuLlocsEntrega.Name = "mnuLlocsEntrega"
        Me.mnuLlocsEntrega.Size = New System.Drawing.Size(180, 22)
        Me.mnuLlocsEntrega.Text = "llocsEntrega"
        '
        'mnuContactesCentre
        '
        Me.mnuContactesCentre.Name = "mnuContactesCentre"
        Me.mnuContactesCentre.Size = New System.Drawing.Size(180, 22)
        Me.mnuContactesCentre.Text = "ContactesCentre"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(177, 6)
        '
        'mnuProveidors
        '
        Me.mnuProveidors.Name = "mnuProveidors"
        Me.mnuProveidors.Size = New System.Drawing.Size(180, 22)
        Me.mnuProveidors.Text = "proveidors"
        '
        'mnuFabricants
        '
        Me.mnuFabricants.Name = "mnuFabricants"
        Me.mnuFabricants.Size = New System.Drawing.Size(180, 22)
        Me.mnuFabricants.Text = "fabricants"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(177, 6)
        '
        'mnuArticles
        '
        Me.mnuArticles.Name = "mnuArticles"
        Me.mnuArticles.Size = New System.Drawing.Size(180, 22)
        Me.mnuArticles.Text = "articles"
        '
        'mnuSolicitutComanda
        '
        Me.mnuSolicitutComanda.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuEditarSolicitutComanda})
        Me.mnuSolicitutComanda.Name = "mnuSolicitutComanda"
        Me.mnuSolicitutComanda.Size = New System.Drawing.Size(120, 20)
        Me.mnuSolicitutComanda.Text = "solicitutdComanda"
        '
        'mnuEditarSolicitutComanda
        '
        Me.mnuEditarSolicitutComanda.Name = "mnuEditarSolicitutComanda"
        Me.mnuEditarSolicitutComanda.Size = New System.Drawing.Size(104, 22)
        Me.mnuEditarSolicitutComanda.Text = "Editar"
        '
        'mnuComandes
        '
        Me.mnuComandes.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuImportF56, Me.mnuNovaComanda, Me.mnuVeureComandaEdicio, Me.ToolStripSeparator4, Me.ToolStripSeparator5, Me.mnuVeureComandes, Me.mnuComandesEnviar})
        Me.mnuComandes.Name = "mnuComandes"
        Me.mnuComandes.Size = New System.Drawing.Size(74, 20)
        Me.mnuComandes.Text = "comandes"
        '
        'mnuImportF56
        '
        Me.mnuImportF56.Name = "mnuImportF56"
        Me.mnuImportF56.Size = New System.Drawing.Size(249, 22)
        Me.mnuImportF56.Text = "Importar Solicitutd de comanda"
        '
        'mnuNovaComanda
        '
        Me.mnuNovaComanda.Name = "mnuNovaComanda"
        Me.mnuNovaComanda.Size = New System.Drawing.Size(249, 22)
        Me.mnuNovaComanda.Text = "nova Comanda"
        '
        'mnuVeureComandaEdicio
        '
        Me.mnuVeureComandaEdicio.Name = "mnuVeureComandaEdicio"
        Me.mnuVeureComandaEdicio.Size = New System.Drawing.Size(249, 22)
        Me.mnuVeureComandaEdicio.Text = "Comandes en edicio"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(246, 6)
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(246, 6)
        '
        'mnuVeureComandes
        '
        Me.mnuVeureComandes.Name = "mnuVeureComandes"
        Me.mnuVeureComandes.Size = New System.Drawing.Size(249, 22)
        Me.mnuVeureComandes.Text = "cercar Comandes"
        '
        'mnuComandesEnviar
        '
        Me.mnuComandesEnviar.Name = "mnuComandesEnviar"
        Me.mnuComandesEnviar.Size = New System.Drawing.Size(249, 22)
        Me.mnuComandesEnviar.Text = "Comandes per Enviar a proveidor"
        '
        'mnuInformes
        '
        Me.mnuInformes.Name = "mnuInformes"
        Me.mnuInformes.Size = New System.Drawing.Size(66, 20)
        Me.mnuInformes.Text = "informes"
        '
        'panelTabs
        '
        Me.panelTabs.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panelTabs.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.panelTabs.ForeColor = System.Drawing.Color.Coral
        Me.panelTabs.Location = New System.Drawing.Point(1, 30)
        Me.panelTabs.Name = "panelTabs"
        Me.panelTabs.Size = New System.Drawing.Size(660, 32)
        Me.panelTabs.TabIndex = 1
        '
        'pData
        '
        Me.pData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pData.Location = New System.Drawing.Point(1, 65)
        Me.pData.Name = "pData"
        Me.pData.Size = New System.Drawing.Size(660, 391)
        Me.pData.TabIndex = 2
        '
        'frmIniComanda
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(659, 445)
        Me.Controls.Add(Me.pData)
        Me.Controls.Add(Me.panelTabs)
        Me.Controls.Add(Me.pMenu)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmIniComanda"
        Me.Text = "frmIniComanda"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pMenu.ResumeLayout(False)
        Me.pMenu.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pMenu As Panel
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents panelTabs As Panel
    Friend WithEvents pData As Panel
    Friend WithEvents mnuConfig As ToolStripMenuItem
    Friend WithEvents mnuComandes As ToolStripMenuItem
    Friend WithEvents mnuInformes As ToolStripMenuItem
    Friend WithEvents mnuAxiliars As ToolStripMenuItem
    Friend WithEvents mnuTipusPagament As ToolStripMenuItem
    Friend WithEvents mnuProvincies As ToolStripMenuItem
    Friend WithEvents mnuPaisos As ToolStripMenuItem
    Friend WithEvents mnuCentres As ToolStripMenuItem
    Friend WithEvents mnuProveidors As ToolStripMenuItem
    Friend WithEvents mnuTipusIva As ToolStripMenuItem
    Friend WithEvents mnuUnitats As ToolStripMenuItem
    Friend WithEvents mnuFamilies As ToolStripMenuItem
    Friend WithEvents mnuFabricants As ToolStripMenuItem
    Friend WithEvents mnuArticles As ToolStripMenuItem
    Friend WithEvents mnuNovaComanda As ToolStripMenuItem
    Friend WithEvents mnuVeureComandaEdicio As ToolStripMenuItem
    Friend WithEvents mnuVeureComandes As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents mnuLlocsEntrega As ToolStripMenuItem
    Friend WithEvents mnuContactesCentre As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents mnuAplicacio As ToolStripMenuItem
    Friend WithEvents mnuApliServidor As ToolStripMenuItem
    Friend WithEvents mnuApliRutaDirectori As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
    Friend WithEvents mnuSolicitutComanda As ToolStripMenuItem
    Friend WithEvents mnuEditarSolicitutComanda As ToolStripMenuItem
    Friend WithEvents mnuImportF56 As ToolStripMenuItem
    Friend WithEvents mnuComandesEnviar As ToolStripMenuItem
End Class
