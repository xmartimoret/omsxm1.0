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
        Me.panelProveidor = New System.Windows.Forms.Panel()
        Me.lblDataFi = New OmsXM.LBLRIGHT()
        Me.lblDataIni = New OmsXM.LBLRIGHT()
        Me.cmdFiltrar = New OmsXM.BOTO()
        Me.lblEmpresa = New OmsXM.LBLRIGHT()
        Me.cbEmpresa = New OmsXM.CBBOX()
        Me.xecTotesEmpresa = New OmsXM.XEC()
        Me.cmdCercarCodi = New OmsXM.BOTO()
        Me.lblCercarCodi = New OmsXM.LBLRIGHT()
        Me.txtCercarCodi = New OmsXM.TXT()
        Me.Lblright1 = New OmsXM.LBLRIGHT()
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
        Me.panelProjecte.Location = New System.Drawing.Point(298, 14)
        Me.panelProjecte.Name = "panelProjecte"
        Me.panelProjecte.Size = New System.Drawing.Size(531, 162)
        Me.panelProjecte.TabIndex = 15
        '
        'panelProveidor
        '
        Me.panelProveidor.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panelProveidor.Location = New System.Drawing.Point(835, 12)
        Me.panelProveidor.Name = "panelProveidor"
        Me.panelProveidor.Size = New System.Drawing.Size(237, 161)
        Me.panelProveidor.TabIndex = 16
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
        Me.cmdFiltrar.Location = New System.Drawing.Point(142, 103)
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
        'cmdCercarCodi
        '
        Me.cmdCercarCodi.AutoSize = True
        Me.cmdCercarCodi.BackColor = System.Drawing.Color.SeaShell
        Me.cmdCercarCodi.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdCercarCodi.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdCercarCodi.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.cmdCercarCodi.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdCercarCodi.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.cmdCercarCodi.Location = New System.Drawing.Point(230, 143)
        Me.cmdCercarCodi.Name = "cmdCercarCodi"
        Me.cmdCercarCodi.Size = New System.Drawing.Size(62, 30)
        Me.cmdCercarCodi.TabIndex = 17
        Me.cmdCercarCodi.Text = "Cercar"
        Me.cmdCercarCodi.UseVisualStyleBackColor = False
        Me.cmdCercarCodi.Visible = False
        '
        'lblCercarCodi
        '
        Me.lblCercarCodi.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.lblCercarCodi.ForeColor = System.Drawing.Color.Black
        Me.lblCercarCodi.Location = New System.Drawing.Point(3, 147)
        Me.lblCercarCodi.Name = "lblCercarCodi"
        Me.lblCercarCodi.Size = New System.Drawing.Size(96, 18)
        Me.lblCercarCodi.TabIndex = 18
        Me.lblCercarCodi.Text = "Cercar pe codi:"
        Me.lblCercarCodi.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblCercarCodi.Visible = False
        '
        'txtCercarCodi
        '
        Me.txtCercarCodi.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.txtCercarCodi.ForeColor = System.Drawing.Color.Blue
        Me.txtCercarCodi.Location = New System.Drawing.Point(105, 144)
        Me.txtCercarCodi.Name = "txtCercarCodi"
        Me.txtCercarCodi.Size = New System.Drawing.Size(119, 26)
        Me.txtCercarCodi.TabIndex = 19
        Me.txtCercarCodi.Visible = False
        '
        'Lblright1
        '
        Me.Lblright1.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Lblright1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Lblright1.ForeColor = System.Drawing.Color.Black
        Me.Lblright1.Location = New System.Drawing.Point(1, 136)
        Me.Lblright1.Name = "Lblright1"
        Me.Lblright1.Size = New System.Drawing.Size(295, 2)
        Me.Lblright1.TabIndex = 20
        Me.Lblright1.Text = "Lblright1"
        Me.Lblright1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Lblright1.Visible = False
        '
        'pFiltreComandes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Lblright1)
        Me.Controls.Add(Me.txtCercarCodi)
        Me.Controls.Add(Me.xecTotesEmpresa)
        Me.Controls.Add(Me.cmdCercarCodi)
        Me.Controls.Add(Me.lblCercarCodi)
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
        Me.Size = New System.Drawing.Size(1075, 176)
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
    Friend WithEvents cmdCercarCodi As BOTO
    Friend WithEvents lblCercarCodi As LBLRIGHT
    Friend WithEvents txtCercarCodi As TXT
    Friend WithEvents Lblright1 As LBLRIGHT
End Class
