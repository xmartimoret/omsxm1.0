<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class empresesSeccionsCentres
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.panelCentre = New System.Windows.Forms.Panel()
        Me.panelSeccio = New System.Windows.Forms.Panel()
        Me.panelProjecte = New System.Windows.Forms.Panel()
        Me.txtCercador = New System.Windows.Forms.TextBox()
        Me.lblCercador = New System.Windows.Forms.Label()
        Me.lblEmpresa = New System.Windows.Forms.Label()
        Me.cbEmpresa = New CBBOX()
        Me.cmdCercador = New BOTO()
        Me.cmdSortir = New BOTO()
        Me.SuspendLayout()
        '
        'panelCentre
        '
        Me.panelCentre.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panelCentre.Location = New System.Drawing.Point(95, 247)
        Me.panelCentre.Name = "panelCentre"
        Me.panelCentre.Size = New System.Drawing.Size(643, 66)
        Me.panelCentre.TabIndex = 1
        '
        'panelSeccio
        '
        Me.panelSeccio.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panelSeccio.Location = New System.Drawing.Point(48, 39)
        Me.panelSeccio.Name = "panelSeccio"
        Me.panelSeccio.Size = New System.Drawing.Size(690, 202)
        Me.panelSeccio.TabIndex = 2
        '
        'panelProjecte
        '
        Me.panelProjecte.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panelProjecte.Location = New System.Drawing.Point(136, 319)
        Me.panelProjecte.Name = "panelProjecte"
        Me.panelProjecte.Size = New System.Drawing.Size(602, 183)
        Me.panelProjecte.TabIndex = 2
        '
        'txtCercador
        '
        Me.txtCercador.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtCercador.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.txtCercador.ForeColor = System.Drawing.Color.Blue
        Me.txtCercador.Location = New System.Drawing.Point(214, 525)
        Me.txtCercador.Name = "txtCercador"
        Me.txtCercador.Size = New System.Drawing.Size(213, 26)
        Me.txtCercador.TabIndex = 43
        '
        'lblCercador
        '
        Me.lblCercador.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblCercador.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCercador.Location = New System.Drawing.Point(18, 528)
        Me.lblCercador.Name = "lblCercador"
        Me.lblCercador.Size = New System.Drawing.Size(190, 18)
        Me.lblCercador.TabIndex = 42
        Me.lblCercador.Text = "Label1"
        Me.lblCercador.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblEmpresa
        '
        Me.lblEmpresa.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmpresa.Location = New System.Drawing.Point(53, 10)
        Me.lblEmpresa.Name = "lblEmpresa"
        Me.lblEmpresa.Size = New System.Drawing.Size(110, 18)
        Me.lblEmpresa.TabIndex = 48
        Me.lblEmpresa.Text = "Label1"
        Me.lblEmpresa.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cbEmpresa
        '
        Me.cbEmpresa.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.cbEmpresa.ForeColor = System.Drawing.Color.Blue
        Me.cbEmpresa.FormattingEnabled = True
        Me.cbEmpresa.Location = New System.Drawing.Point(169, 7)
        Me.cbEmpresa.Name = "cbEmpresa"
        Me.cbEmpresa.Size = New System.Drawing.Size(383, 26)
        Me.cbEmpresa.TabIndex = 46
        '
        'cmdCercador
        '
        Me.cmdCercador.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdCercador.AutoSize = True
        Me.cmdCercador.BackColor = System.Drawing.Color.SeaShell
        Me.cmdCercador.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdCercador.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdCercador.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.cmdCercador.Location = New System.Drawing.Point(433, 520)
        Me.cmdCercador.Name = "cmdCercador"
        Me.cmdCercador.Size = New System.Drawing.Size(108, 32)
        Me.cmdCercador.TabIndex = 44
        Me.cmdCercador.UseVisualStyleBackColor = False
        '
        'cmdSortir
        '
        Me.cmdSortir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSortir.AutoSize = True
        Me.cmdSortir.BackColor = System.Drawing.Color.SeaShell
        Me.cmdSortir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdSortir.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdSortir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.cmdSortir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdSortir.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.cmdSortir.Location = New System.Drawing.Point(650, 521)
        Me.cmdSortir.Name = "cmdSortir"
        Me.cmdSortir.Size = New System.Drawing.Size(88, 30)
        Me.cmdSortir.TabIndex = 3
        Me.cmdSortir.Text = "Boto1"
        Me.cmdSortir.UseVisualStyleBackColor = False
        '
        'empresesSeccionsCentres
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lblEmpresa)
        Me.Controls.Add(Me.cbEmpresa)
        Me.Controls.Add(Me.cmdCercador)
        Me.Controls.Add(Me.txtCercador)
        Me.Controls.Add(Me.lblCercador)
        Me.Controls.Add(Me.cmdSortir)
        Me.Controls.Add(Me.panelProjecte)
        Me.Controls.Add(Me.panelCentre)
        Me.Controls.Add(Me.panelSeccio)
        Me.Name = "empresesSeccionsCentres"
        Me.Size = New System.Drawing.Size(752, 558)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents panelCentre As Panel
    Friend WithEvents panelSeccio As Panel
    Friend WithEvents panelProjecte As Panel
    Friend WithEvents cmdSortir As BOTO
    Friend WithEvents cmdCercador As BOTO
    Friend WithEvents txtCercador As TextBox
    Friend WithEvents lblCercador As Label
    Friend WithEvents lblEmpresa As Label
    Friend WithEvents cbEmpresa As CBBOX
End Class
