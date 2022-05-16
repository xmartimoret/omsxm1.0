<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class avis
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(avis))
        Me.Picture = New System.Windows.Forms.PictureBox()
        Me.lblAvis = New OmsXM.LBLREDTopLeft()
        Me.listImage = New System.Windows.Forms.ImageList(Me.components)
        CType(Me.Picture, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Picture
        '
        Me.Picture.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Picture.Location = New System.Drawing.Point(-1, -1)
        Me.Picture.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Picture.Name = "Picture"
        Me.Picture.Size = New System.Drawing.Size(30, 29)
        Me.Picture.TabIndex = 0
        Me.Picture.TabStop = False
        '
        'lblAvis
        '
        Me.lblAvis.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblAvis.Font = New System.Drawing.Font("Tahoma", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAvis.ForeColor = System.Drawing.Color.Red
        Me.lblAvis.Location = New System.Drawing.Point(32, 5)
        Me.lblAvis.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblAvis.Name = "lblAvis"
        Me.lblAvis.Size = New System.Drawing.Size(245, 24)
        Me.lblAvis.TabIndex = 1
        Me.lblAvis.Text = "texte4"
        '
        'listImage
        '
        Me.listImage.ImageStream = CType(resources.GetObject("listImage.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.listImage.TransparentColor = System.Drawing.Color.Transparent
        Me.listImage.Images.SetKeyName(0, "Err.jpg")
        Me.listImage.Images.SetKeyName(1, "Ok.jpg")
        '
        'avis
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.Controls.Add(Me.lblAvis)
        Me.Controls.Add(Me.Picture)
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Name = "avis"
        Me.Size = New System.Drawing.Size(277, 29)
        CType(Me.Picture, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Picture As PictureBox
    Friend WithEvents lblAvis As LBLREDTopLeft
    Friend WithEvents listImage As ImageList
End Class
