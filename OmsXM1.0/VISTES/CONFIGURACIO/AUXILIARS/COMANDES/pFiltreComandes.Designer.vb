<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class pFiltreComandes
    Inherits System.Windows.Forms.UserControl

    'UserControl reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.panelDataFi = New System.Windows.Forms.Panel()
        Me.panelDataInici = New System.Windows.Forms.Panel()
        Me.panelProjecte = New System.Windows.Forms.Panel()
        Me.cmdTreureProjecte = New OmsXM.BOTO()
        Me.cmdAfegirProjecte = New OmsXM.BOTO()
        Me.lstProjectes = New OmsXM.LSTBOX()
        Me.lblProjectes = New OmsXM.LBLRIGHT()
        Me.panelProveidor = New System.Windows.Forms.Panel()
        Me.cmdTreureProveidor = New OmsXM.BOTO()
        Me.cmdAfegirProveidor = New OmsXM.BOTO()
        Me.lstProveidors = New OmsXM.LSTBOX()
        Me.lblProveidors = New OmsXM.LBLRIGHT()
        Me.xecTotesEmpresa = New OmsXM.XEC()
        Me.lblDataFi = New OmsXM.LBLRIGHT()
        Me.lblDataIni = New OmsXM.LBLRIGHT()
        Me.cmdFiltrar = New OmsXM.BOTO()
        Me.lblEmpresa = New OmsXM.LBLRIGHT()
        Me.cbEmpresa = New OmsXM.CBBOX()
        Me.panelProjecte.SuspendLayout()
        Me.panelProveidor.SuspendLayout()
        Me.SuspendLayout()
        '
        'panelDataFi
        '
        Me.panelDataFi.Location = New System.Drawing.Point(185, 72)
        Me.panelDataFi.Name = "panelDataFi"
        Me.panelDataFi.Size = New System.Drawing.Size(107, 28)
        Me.panelDataFi.TabIndex = 11
        '
        'panelDataInici
        '
        Me.panelDataInici.Location = New System.Drawing.Point(39, 73)
        Me.panelDataInici.Name = "panelDataInici"
        Me.panelDataInici.Size = New System.Drawing.Size(115, 27)
        Me.panelDataInici.TabIndex = 10
        '
        'panelProjecte
        '
        Me.panelProjecte.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.panelProjecte.Controls.Add(Me.cmdTreureProjecte)
        Me.panelProjecte.Controls.Add(Me.cmdAfegirProjecte)
        Me.panelProjecte.Controls.Add(Me.lstProjectes)
        Me.panelProjecte.Controls.Add(Me.lblProjectes)
        Me.panelProjecte.Location = New System.Drawing.Point(298, 14)
        Me.panelProjecte.Name = "panelProjecte"
        Me.panelProjecte.Size = New System.Drawing.Size(508, 131)
        Me.panelProjecte.TabIndex = 15
        '
        'cmdTreureProjecte
        '
        Me.cmdTreureProjecte.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdTreureProjecte.AutoSize = True
        Me.cmdTreureProjecte.BackColor = System.Drawing.Color.SeaShell
        Me.cmdTreureProjecte.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdTreureProjecte.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdTreureProjecte.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.cmdTreureProjecte.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdTreureProjecte.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.cmdTreureProjecte.Location = New System.Drawing.Point(419, 71)
        Me.cmdTreureProjecte.Name = "cmdTreureProjecte"
        Me.cmdTreureProjecte.Size = New System.Drawing.Size(76, 25)
        Me.cmdTreureProjecte.TabIndex = 24
        Me.cmdTreureProjecte.Text = "Treure"
        Me.cmdTreureProjecte.UseVisualStyleBackColor = False
        '
        'cmdAfegirProjecte
        '
        Me.cmdAfegirProjecte.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdAfegirProjecte.AutoSize = True
        Me.cmdAfegirProjecte.BackColor = System.Drawing.Color.SeaShell
        Me.cmdAfegirProjecte.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdAfegirProjecte.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdAfegirProjecte.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.cmdAfegirProjecte.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdAfegirProjecte.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.cmdAfegirProjecte.Location = New System.Drawing.Point(419, 35)
        Me.cmdAfegirProjecte.Name = "cmdAfegirProjecte"
        Me.cmdAfegirProjecte.Size = New System.Drawing.Size(76, 25)
        Me.cmdAfegirProjecte.TabIndex = 21
        Me.cmdAfegirProjecte.Text = "Afegir"
        Me.cmdAfegirProjecte.UseVisualStyleBackColor = False
        '
        'lstProjectes
        '
        Me.lstProjectes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstProjectes.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.lstProjectes.ForeColor = System.Drawing.Color.Blue
        Me.lstProjectes.FormattingEnabled = True
        Me.lstProjectes.Location = New System.Drawing.Point(18, 35)
        Me.lstProjectes.Name = "lstProjectes"
        Me.lstProjectes.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lstProjectes.Size = New System.Drawing.Size(395, 82)
        Me.lstProjectes.TabIndex = 23
        '
        'lblProjectes
        '
        Me.lblProjectes.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblProjectes.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.lblProjectes.ForeColor = System.Drawing.Color.Black
        Me.lblProjectes.Location = New System.Drawing.Point(15, 11)
        Me.lblProjectes.Name = "lblProjectes"
        Me.lblProjectes.Size = New System.Drawing.Size(490, 18)
        Me.lblProjectes.TabIndex = 21
        Me.lblProjectes.Text = "Projectes a Cercar"
        Me.lblProjectes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'panelProveidor
        '
        Me.panelProveidor.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panelProveidor.Controls.Add(Me.cmdTreureProveidor)
        Me.panelProveidor.Controls.Add(Me.cmdAfegirProveidor)
        Me.panelProveidor.Controls.Add(Me.lstProveidors)
        Me.panelProveidor.Controls.Add(Me.lblProveidors)
        Me.panelProveidor.Location = New System.Drawing.Point(812, 12)
        Me.panelProveidor.Name = "panelProveidor"
        Me.panelProveidor.Size = New System.Drawing.Size(383, 133)
        Me.panelProveidor.TabIndex = 16
        '
        'cmdTreureProveidor
        '
        Me.cmdTreureProveidor.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdTreureProveidor.AutoSize = True
        Me.cmdTreureProveidor.BackColor = System.Drawing.Color.SeaShell
        Me.cmdTreureProveidor.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdTreureProveidor.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdTreureProveidor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.cmdTreureProveidor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdTreureProveidor.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.cmdTreureProveidor.Location = New System.Drawing.Point(298, 81)
        Me.cmdTreureProveidor.Name = "cmdTreureProveidor"
        Me.cmdTreureProveidor.Size = New System.Drawing.Size(76, 25)
        Me.cmdTreureProveidor.TabIndex = 28
        Me.cmdTreureProveidor.Text = "Treure"
        Me.cmdTreureProveidor.UseVisualStyleBackColor = False
        '
        'cmdAfegirProveidor
        '
        Me.cmdAfegirProveidor.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdAfegirProveidor.AutoSize = True
        Me.cmdAfegirProveidor.BackColor = System.Drawing.Color.SeaShell
        Me.cmdAfegirProveidor.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdAfegirProveidor.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdAfegirProveidor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.cmdAfegirProveidor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdAfegirProveidor.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.cmdAfegirProveidor.Location = New System.Drawing.Point(298, 45)
        Me.cmdAfegirProveidor.Name = "cmdAfegirProveidor"
        Me.cmdAfegirProveidor.Size = New System.Drawing.Size(76, 25)
        Me.cmdAfegirProveidor.TabIndex = 25
        Me.cmdAfegirProveidor.Text = "Afegir"
        Me.cmdAfegirProveidor.UseVisualStyleBackColor = False
        '
        'lstProveidors
        '
        Me.lstProveidors.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstProveidors.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.lstProveidors.ForeColor = System.Drawing.Color.Blue
        Me.lstProveidors.FormattingEnabled = True
        Me.lstProveidors.Location = New System.Drawing.Point(17, 45)
        Me.lstProveidors.Name = "lstProveidors"
        Me.lstProveidors.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lstProveidors.Size = New System.Drawing.Size(275, 69)
        Me.lstProveidors.TabIndex = 27
        '
        'lblProveidors
        '
        Me.lblProveidors.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblProveidors.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.lblProveidors.ForeColor = System.Drawing.Color.Black
        Me.lblProveidors.Location = New System.Drawing.Point(14, 21)
        Me.lblProveidors.Name = "lblProveidors"
        Me.lblProveidors.Size = New System.Drawing.Size(360, 18)
        Me.lblProveidors.TabIndex = 26
        Me.lblProveidors.Text = "Proveidors a Cercar"
        Me.lblProveidors.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'xecTotesEmpresa
        '
        Me.xecTotesEmpresa.AutoSize = True
        Me.xecTotesEmpresa.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.xecTotesEmpresa.ForeColor = System.Drawing.Color.Black
        Me.xecTotesEmpresa.Location = New System.Drawing.Point(15, 49)
        Me.xecTotesEmpresa.Name = "xecTotesEmpresa"
        Me.xecTotesEmpresa.Size = New System.Drawing.Size(59, 22)
        Me.xecTotesEmpresa.TabIndex = 0
        Me.xecTotesEmpresa.Text = "Xec1"
        Me.xecTotesEmpresa.UseVisualStyleBackColor = True
        '
        'lblDataFi
        '
        Me.lblDataFi.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.lblDataFi.ForeColor = System.Drawing.Color.Black
        Me.lblDataFi.Location = New System.Drawing.Point(160, 73)
        Me.lblDataFi.Name = "lblDataFi"
        Me.lblDataFi.Size = New System.Drawing.Size(25, 26)
        Me.lblDataFi.TabIndex = 14
        Me.lblDataFi.Text = "Lblright2"
        Me.lblDataFi.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblDataIni
        '
        Me.lblDataIni.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.lblDataIni.ForeColor = System.Drawing.Color.Black
        Me.lblDataIni.Location = New System.Drawing.Point(3, 74)
        Me.lblDataIni.Name = "lblDataIni"
        Me.lblDataIni.Size = New System.Drawing.Size(30, 26)
        Me.lblDataIni.TabIndex = 13
        Me.lblDataIni.Text = "Lblright1"
        Me.lblDataIni.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdFiltrar
        '
        Me.cmdFiltrar.AutoSize = True
        Me.cmdFiltrar.BackColor = System.Drawing.Color.SeaShell
        Me.cmdFiltrar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdFiltrar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdFiltrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.cmdFiltrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdFiltrar.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.cmdFiltrar.Location = New System.Drawing.Point(142, 113)
        Me.cmdFiltrar.Name = "cmdFiltrar"
        Me.cmdFiltrar.Size = New System.Drawing.Size(150, 30)
        Me.cmdFiltrar.TabIndex = 12
        Me.cmdFiltrar.Text = "Boto1"
        Me.cmdFiltrar.UseVisualStyleBackColor = False
        '
        'lblEmpresa
        '
        Me.lblEmpresa.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.lblEmpresa.ForeColor = System.Drawing.Color.Black
        Me.lblEmpresa.Location = New System.Drawing.Point(3, 6)
        Me.lblEmpresa.Name = "lblEmpresa"
        Me.lblEmpresa.Size = New System.Drawing.Size(136, 18)
        Me.lblEmpresa.TabIndex = 1
        Me.lblEmpresa.Text = "Lblright1"
        Me.lblEmpresa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cbEmpresa
        '
        Me.cbEmpresa.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.cbEmpresa.ForeColor = System.Drawing.Color.Blue
        Me.cbEmpresa.FormattingEnabled = True
        Me.cbEmpresa.Location = New System.Drawing.Point(3, 25)
        Me.cbEmpresa.Name = "cbEmpresa"
        Me.cbEmpresa.Size = New System.Drawing.Size(289, 21)
        Me.cbEmpresa.TabIndex = 0
        '
        'pFiltreComandes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.xecTotesEmpresa)
        Me.Controls.Add(Me.panelProveidor)
        Me.Controls.Add(Me.panelProjecte)
        Me.Controls.Add(Me.lblDataFi)
        Me.Controls.Add(Me.lblDataIni)
        Me.Controls.Add(Me.cmdFiltrar)
        Me.Controls.Add(Me.panelDataFi)
        Me.Controls.Add(Me.panelDataInici)
        Me.Controls.Add(Me.lblEmpresa)
        Me.Controls.Add(Me.cbEmpresa)
        Me.Name = "pFiltreComandes"
        Me.Size = New System.Drawing.Size(1198, 148)
        Me.panelProjecte.ResumeLayout(False)
        Me.panelProjecte.PerformLayout()
        Me.panelProveidor.ResumeLayout(False)
        Me.panelProveidor.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cbEmpresa As CBBOX
    Friend WithEvents lblEmpresa As LBLRIGHT
    Friend WithEvents lblDataFi As LBLRIGHT
    Friend WithEvents lblDataIni As LBLRIGHT
    Friend WithEvents cmdFiltrar As BOTO
    Friend WithEvents panelDataFi As Panel
    Friend WithEvents panelDataInici As Panel
    Friend WithEvents panelProjecte As Panel
    Friend WithEvents panelProveidor As Panel
    Friend WithEvents xecTotesEmpresa As XEC
    Friend WithEvents cmdTreureProjecte As BOTO
    Friend WithEvents cmdAfegirProjecte As BOTO
    Friend WithEvents lstProjectes As LSTBOX
    Friend WithEvents lblProjectes As LBLRIGHT
    Friend WithEvents cmdTreureProveidor As BOTO
    Friend WithEvents cmdAfegirProveidor As BOTO
    Friend WithEvents lstProveidors As LSTBOX
    Friend WithEvents lblProveidors As LBLRIGHT
End Class
