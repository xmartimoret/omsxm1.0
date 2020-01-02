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
        Me.mnuConfig = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuAxiliars = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTipusPagament = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuProvincies = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPaisos = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTipusIva = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuUnitats = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFamilies = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuCentres = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuProveidors = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFabricants = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuArticles = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuComandes = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuNovaComanda = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuVeureComandaEdicio = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuImportarComandes = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuVeureComandes = New System.Windows.Forms.ToolStripMenuItem()
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
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuConfig, Me.mnuComandes, Me.mnuInformes})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(660, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'mnuConfig
        '
        Me.mnuConfig.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuAxiliars, Me.mnuCentres, Me.mnuProveidors, Me.mnuFabricants, Me.mnuArticles})
        Me.mnuConfig.Name = "mnuConfig"
        Me.mnuConfig.Size = New System.Drawing.Size(86, 20)
        Me.mnuConfig.Text = "configuracio"
        '
        'mnuAxiliars
        '
        Me.mnuAxiliars.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuTipusPagament, Me.mnuProvincies, Me.mnuPaisos, Me.mnuTipusIva, Me.mnuUnitats, Me.mnuFamilies})
        Me.mnuAxiliars.Name = "mnuAxiliars"
        Me.mnuAxiliars.Size = New System.Drawing.Size(130, 22)
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
        'mnuCentres
        '
        Me.mnuCentres.Name = "mnuCentres"
        Me.mnuCentres.Size = New System.Drawing.Size(130, 22)
        Me.mnuCentres.Text = "centrres"
        '
        'mnuProveidors
        '
        Me.mnuProveidors.Name = "mnuProveidors"
        Me.mnuProveidors.Size = New System.Drawing.Size(130, 22)
        Me.mnuProveidors.Text = "proveidors"
        '
        'mnuFabricants
        '
        Me.mnuFabricants.Name = "mnuFabricants"
        Me.mnuFabricants.Size = New System.Drawing.Size(130, 22)
        Me.mnuFabricants.Text = "fabricants"
        '
        'mnuArticles
        '
        Me.mnuArticles.Name = "mnuArticles"
        Me.mnuArticles.Size = New System.Drawing.Size(130, 22)
        Me.mnuArticles.Text = "articles"
        '
        'mnuComandes
        '
        Me.mnuComandes.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuNovaComanda, Me.mnuVeureComandaEdicio, Me.mnuImportarComandes, Me.mnuVeureComandes})
        Me.mnuComandes.Name = "mnuComandes"
        Me.mnuComandes.Size = New System.Drawing.Size(74, 20)
        Me.mnuComandes.Text = "comandes"
        '
        'mnuNovaComanda
        '
        Me.mnuNovaComanda.Name = "mnuNovaComanda"
        Me.mnuNovaComanda.Size = New System.Drawing.Size(239, 22)
        Me.mnuNovaComanda.Text = "nova comanda"
        '
        'mnuVeureComandaEdicio
        '
        Me.mnuVeureComandaEdicio.Name = "mnuVeureComandaEdicio"
        Me.mnuVeureComandaEdicio.Size = New System.Drawing.Size(239, 22)
        Me.mnuVeureComandaEdicio.Text = "veure comandes en edicio"
        '
        'mnuImportarComandes
        '
        Me.mnuImportarComandes.Name = "mnuImportarComandes"
        Me.mnuImportarComandes.Size = New System.Drawing.Size(239, 22)
        Me.mnuImportarComandes.Text = "importar solicituts de comanda"
        '
        'mnuVeureComandes
        '
        Me.mnuVeureComandes.Name = "mnuVeureComandes"
        Me.mnuVeureComandes.Size = New System.Drawing.Size(239, 22)
        Me.mnuVeureComandes.Text = "Veure comandes"
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
    Friend WithEvents mnuImportarComandes As ToolStripMenuItem
    Friend WithEvents mnuVeureComandes As ToolStripMenuItem
End Class
