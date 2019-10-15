<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DArticlePreu
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Me.cData = New OmsXM.SelectDia()
        Me.lblProveidor = New System.Windows.Forms.Label()
        Me.lblArticleCaption = New System.Windows.Forms.Label()
        Me.pProveidor = New System.Windows.Forms.Panel()
        Me.lblId = New System.Windows.Forms.Label()
        Me.lblIdCaption = New System.Windows.Forms.Label()
        Me.lblData = New System.Windows.Forms.Label()
        Me.lblBase = New System.Windows.Forms.Label()
        Me.txtBase = New System.Windows.Forms.TextBox()
        Me.lblDescompte = New System.Windows.Forms.Label()
        Me.txtDescompte = New System.Windows.Forms.TextBox()
        Me.cmdGuardar = New System.Windows.Forms.Button()
        Me.cmdCancelar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblArticle = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'cData
        '
        Me.cData.dataActual = New Date(CType(0, Long))
        Me.cData.Location = New System.Drawing.Point(154, 137)
        Me.cData.Name = "cData"
        Me.cData.Size = New System.Drawing.Size(116, 24)
        Me.cData.TabIndex = 0
        '
        'lblProveidor
        '
        Me.lblProveidor.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProveidor.Location = New System.Drawing.Point(4, 106)
        Me.lblProveidor.Name = "lblProveidor"
        Me.lblProveidor.Size = New System.Drawing.Size(141, 23)
        Me.lblProveidor.TabIndex = 97
        Me.lblProveidor.Text = "Label1"
        Me.lblProveidor.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblArticleCaption
        '
        Me.lblArticleCaption.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblArticleCaption.Location = New System.Drawing.Point(4, 31)
        Me.lblArticleCaption.Name = "lblArticleCaption"
        Me.lblArticleCaption.Size = New System.Drawing.Size(141, 23)
        Me.lblArticleCaption.TabIndex = 98
        Me.lblArticleCaption.Text = "Label1"
        Me.lblArticleCaption.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pProveidor
        '
        Me.pProveidor.Location = New System.Drawing.Point(154, 102)
        Me.pProveidor.Name = "pProveidor"
        Me.pProveidor.Size = New System.Drawing.Size(199, 29)
        Me.pProveidor.TabIndex = 96
        '
        'lblId
        '
        Me.lblId.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblId.ForeColor = System.Drawing.Color.Blue
        Me.lblId.Location = New System.Drawing.Point(151, 5)
        Me.lblId.Name = "lblId"
        Me.lblId.Size = New System.Drawing.Size(156, 23)
        Me.lblId.TabIndex = 100
        Me.lblId.Text = "Label1"
        Me.lblId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblIdCaption
        '
        Me.lblIdCaption.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIdCaption.Location = New System.Drawing.Point(4, 4)
        Me.lblIdCaption.Name = "lblIdCaption"
        Me.lblIdCaption.Size = New System.Drawing.Size(141, 23)
        Me.lblIdCaption.TabIndex = 99
        Me.lblIdCaption.Text = "Label1"
        Me.lblIdCaption.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblData
        '
        Me.lblData.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblData.Location = New System.Drawing.Point(4, 138)
        Me.lblData.Name = "lblData"
        Me.lblData.Size = New System.Drawing.Size(141, 23)
        Me.lblData.TabIndex = 101
        Me.lblData.Text = "Label1"
        Me.lblData.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblBase
        '
        Me.lblBase.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBase.Location = New System.Drawing.Point(4, 167)
        Me.lblBase.Name = "lblBase"
        Me.lblBase.Size = New System.Drawing.Size(141, 23)
        Me.lblBase.TabIndex = 103
        Me.lblBase.Text = "Label1"
        Me.lblBase.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtBase
        '
        Me.txtBase.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.txtBase.ForeColor = System.Drawing.Color.Blue
        Me.txtBase.Location = New System.Drawing.Point(154, 167)
        Me.txtBase.Name = "txtBase"
        Me.txtBase.Size = New System.Drawing.Size(116, 26)
        Me.txtBase.TabIndex = 102
        '
        'lblDescompte
        '
        Me.lblDescompte.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescompte.Location = New System.Drawing.Point(4, 199)
        Me.lblDescompte.Name = "lblDescompte"
        Me.lblDescompte.Size = New System.Drawing.Size(141, 23)
        Me.lblDescompte.TabIndex = 105
        Me.lblDescompte.Text = "Label1"
        Me.lblDescompte.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtDescompte
        '
        Me.txtDescompte.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.txtDescompte.ForeColor = System.Drawing.Color.Blue
        Me.txtDescompte.Location = New System.Drawing.Point(154, 199)
        Me.txtDescompte.Name = "txtDescompte"
        Me.txtDescompte.Size = New System.Drawing.Size(68, 26)
        Me.txtDescompte.TabIndex = 104
        '
        'cmdGuardar
        '
        Me.cmdGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdGuardar.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.cmdGuardar.Location = New System.Drawing.Point(12, 243)
        Me.cmdGuardar.Name = "cmdGuardar"
        Me.cmdGuardar.Size = New System.Drawing.Size(133, 31)
        Me.cmdGuardar.TabIndex = 106
        Me.cmdGuardar.Text = "OK"
        '
        'cmdCancelar
        '
        Me.cmdCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancelar.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.cmdCancelar.Location = New System.Drawing.Point(218, 243)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(148, 31)
        Me.cmdCancelar.TabIndex = 107
        Me.cmdCancelar.Text = "Cancel"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(276, 134)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(19, 23)
        Me.Label1.TabIndex = 108
        Me.Label1.Text = "€"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(228, 202)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(19, 23)
        Me.Label2.TabIndex = 109
        Me.Label2.Text = "%"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblArticle
        '
        Me.lblArticle.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblArticle.ForeColor = System.Drawing.Color.Blue
        Me.lblArticle.Location = New System.Drawing.Point(151, 31)
        Me.lblArticle.Name = "lblArticle"
        Me.lblArticle.Size = New System.Drawing.Size(215, 53)
        Me.lblArticle.TabIndex = 110
        Me.lblArticle.Text = "Label1"
        '
        'DArticlePreu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(378, 299)
        Me.Controls.Add(Me.lblArticle)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdGuardar)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.lblDescompte)
        Me.Controls.Add(Me.txtDescompte)
        Me.Controls.Add(Me.lblBase)
        Me.Controls.Add(Me.txtBase)
        Me.Controls.Add(Me.lblData)
        Me.Controls.Add(Me.lblId)
        Me.Controls.Add(Me.lblIdCaption)
        Me.Controls.Add(Me.lblProveidor)
        Me.Controls.Add(Me.lblArticleCaption)
        Me.Controls.Add(Me.pProveidor)
        Me.Controls.Add(Me.cData)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DArticlePreu"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "DArticlePreu"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cData As SelectDia
    Friend WithEvents lblProveidor As Label
    Friend WithEvents lblArticleCaption As Label
    Friend WithEvents pProveidor As Panel
    Friend WithEvents lblId As Label
    Friend WithEvents lblIdCaption As Label
    Friend WithEvents lblData As Label
    Friend WithEvents lblBase As Label
    Friend WithEvents txtBase As TextBox
    Friend WithEvents lblDescompte As Label
    Friend WithEvents txtDescompte As TextBox
    Friend WithEvents cmdGuardar As Button
    Friend WithEvents cmdCancelar As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents lblArticle As Label
End Class
