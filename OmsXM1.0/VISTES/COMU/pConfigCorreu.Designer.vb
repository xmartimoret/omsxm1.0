<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class pConfigCorreu
    Inherits System.Windows.Forms.UserControl

    'UserControl reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.txtSign = New OmsXM.TXT()
        Me.lblCaption = New OmsXM.LBLMIDDLE()
        Me.Boto1 = New OmsXM.BOTO()
        Me.lblDireccio = New OmsXM.LBLMIDDLE()
        Me.txtCorreu = New OmsXM.TXT()
        Me.SuspendLayout()
        '
        'txtSign
        '
        Me.txtSign.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSign.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.txtSign.ForeColor = System.Drawing.Color.Blue
        Me.txtSign.Location = New System.Drawing.Point(0, 76)
        Me.txtSign.Multiline = True
        Me.txtSign.Name = "txtSign"
        Me.txtSign.Size = New System.Drawing.Size(478, 497)
        Me.txtSign.TabIndex = 2
        '
        'lblCaption
        '
        Me.lblCaption.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCaption.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCaption.ForeColor = System.Drawing.Color.Black
        Me.lblCaption.Location = New System.Drawing.Point(0, 50)
        Me.lblCaption.Name = "lblCaption"
        Me.lblCaption.Size = New System.Drawing.Size(491, 23)
        Me.lblCaption.TabIndex = 1
        Me.lblCaption.Text = "Lblmiddle1"
        Me.lblCaption.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Boto1
        '
        Me.Boto1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Boto1.AutoSize = True
        Me.Boto1.BackColor = System.Drawing.Color.SeaShell
        Me.Boto1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Boto1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Boto1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Boto1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Boto1.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.Boto1.Location = New System.Drawing.Point(283, 579)
        Me.Boto1.Name = "Boto1"
        Me.Boto1.Size = New System.Drawing.Size(198, 30)
        Me.Boto1.TabIndex = 2
        Me.Boto1.Text = "Boto1"
        Me.Boto1.UseVisualStyleBackColor = False
        '
        'lblDireccio
        '
        Me.lblDireccio.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDireccio.ForeColor = System.Drawing.Color.Black
        Me.lblDireccio.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblDireccio.Location = New System.Drawing.Point(3, 8)
        Me.lblDireccio.Name = "lblDireccio"
        Me.lblDireccio.Size = New System.Drawing.Size(142, 23)
        Me.lblDireccio.TabIndex = 3
        Me.lblDireccio.Text = "Correu predeterminat"
        Me.lblDireccio.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtCorreu
        '
        Me.txtCorreu.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCorreu.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.txtCorreu.ForeColor = System.Drawing.Color.Blue
        Me.txtCorreu.Location = New System.Drawing.Point(154, 8)
        Me.txtCorreu.Name = "txtCorreu"
        Me.txtCorreu.Size = New System.Drawing.Size(324, 26)
        Me.txtCorreu.TabIndex = 1
        '
        'pConfigCorreu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.txtCorreu)
        Me.Controls.Add(Me.lblDireccio)
        Me.Controls.Add(Me.Boto1)
        Me.Controls.Add(Me.lblCaption)
        Me.Controls.Add(Me.txtSign)
        Me.Name = "pConfigCorreu"
        Me.Size = New System.Drawing.Size(494, 627)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtSign As TXT
    Friend WithEvents lblCaption As LBLMIDDLE
    Friend WithEvents Boto1 As BOTO
    Friend WithEvents lblDireccio As LBLMIDDLE
    Friend WithEvents txtCorreu As TXT
End Class
