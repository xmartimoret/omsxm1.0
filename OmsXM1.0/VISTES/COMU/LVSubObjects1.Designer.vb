<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class LVSubObjects1
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.components = New System.ComponentModel.Container()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblTitol = New System.Windows.Forms.Label()
        Me.lblCount = New System.Windows.Forms.Label()
        Me.lstData = New System.Windows.Forms.ListView()
        Me.txtFiltrar = New System.Windows.Forms.TextBox()
        Me.lblFiltrar = New System.Windows.Forms.Label()
        Me.cmdActualitzar = New System.Windows.Forms.Button()
        Me.cmdImprimir = New System.Windows.Forms.Button()
        Me.cmdEliminar = New System.Windows.Forms.Button()
        Me.cmdModificar = New System.Windows.Forms.Button()
        Me.cmdAfegir = New System.Windows.Forms.Button()
        Me.tTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(7, -5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(592, 2)
        Me.Label1.TabIndex = 39
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTitol
        '
        Me.lblTitol.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTitol.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitol.ForeColor = System.Drawing.Color.Black
        Me.lblTitol.Location = New System.Drawing.Point(169, 10)
        Me.lblTitol.Name = "lblTitol"
        Me.lblTitol.Size = New System.Drawing.Size(419, 24)
        Me.lblTitol.TabIndex = 38
        Me.lblTitol.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCount
        '
        Me.lblCount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCount.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.lblCount.ForeColor = System.Drawing.Color.Blue
        Me.lblCount.Location = New System.Drawing.Point(410, 395)
        Me.lblCount.Name = "lblCount"
        Me.lblCount.Size = New System.Drawing.Size(178, 21)
        Me.lblCount.TabIndex = 35
        Me.lblCount.Text = "lblCount"
        Me.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lstData
        '
        Me.lstData.AllowColumnReorder = True
        Me.lstData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstData.BackColor = System.Drawing.SystemColors.HighlightText
        Me.lstData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lstData.CheckBoxes = True
        Me.lstData.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.lstData.ForeColor = System.Drawing.Color.Blue
        Me.lstData.FullRowSelect = True
        Me.lstData.GridLines = True
        Me.lstData.HideSelection = False
        Me.lstData.Location = New System.Drawing.Point(3, 63)
        Me.lstData.MultiSelect = False
        Me.lstData.Name = "lstData"
        Me.lstData.Size = New System.Drawing.Size(585, 329)
        Me.lstData.TabIndex = 33
        Me.lstData.UseCompatibleStateImageBehavior = False
        Me.lstData.View = System.Windows.Forms.View.Details
        '
        'txtFiltrar
        '
        Me.txtFiltrar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFiltrar.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFiltrar.ForeColor = System.Drawing.Color.Red
        Me.txtFiltrar.Location = New System.Drawing.Point(92, 37)
        Me.txtFiltrar.Name = "txtFiltrar"
        Me.txtFiltrar.Size = New System.Drawing.Size(496, 22)
        Me.txtFiltrar.TabIndex = 41
        '
        'lblFiltrar
        '
        Me.lblFiltrar.AutoSize = True
        Me.lblFiltrar.ForeColor = System.Drawing.Color.Red
        Me.lblFiltrar.Location = New System.Drawing.Point(6, 42)
        Me.lblFiltrar.Name = "lblFiltrar"
        Me.lblFiltrar.Size = New System.Drawing.Size(80, 13)
        Me.lblFiltrar.TabIndex = 42
        Me.lblFiltrar.Text = "FILTRAR PER:"
        '
        'cmdActualitzar
        '
        Me.cmdActualitzar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdActualitzar.Image = Global.OmsXM.My.Resources.Resources.actualitzar
        Me.cmdActualitzar.Location = New System.Drawing.Point(110, 5)
        Me.cmdActualitzar.Name = "cmdActualitzar"
        Me.cmdActualitzar.Size = New System.Drawing.Size(26, 28)
        Me.cmdActualitzar.TabIndex = 47
        Me.cmdActualitzar.UseVisualStyleBackColor = True
        '
        'cmdImprimir
        '
        Me.cmdImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdImprimir.Image = Global.OmsXM.My.Resources.Resources.botoImprimir
        Me.cmdImprimir.Location = New System.Drawing.Point(140, 6)
        Me.cmdImprimir.Name = "cmdImprimir"
        Me.cmdImprimir.Size = New System.Drawing.Size(26, 28)
        Me.cmdImprimir.TabIndex = 46
        Me.cmdImprimir.UseVisualStyleBackColor = True
        '
        'cmdEliminar
        '
        Me.cmdEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdEliminar.Image = Global.OmsXM.My.Resources.Resources.BotoBorrar
        Me.cmdEliminar.Location = New System.Drawing.Point(61, 6)
        Me.cmdEliminar.Name = "cmdEliminar"
        Me.cmdEliminar.Size = New System.Drawing.Size(26, 28)
        Me.cmdEliminar.TabIndex = 45
        Me.cmdEliminar.UseVisualStyleBackColor = True
        '
        'cmdModificar
        '
        Me.cmdModificar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdModificar.Image = Global.OmsXM.My.Resources.Resources.BotoModificar
        Me.cmdModificar.Location = New System.Drawing.Point(32, 6)
        Me.cmdModificar.Name = "cmdModificar"
        Me.cmdModificar.Size = New System.Drawing.Size(26, 28)
        Me.cmdModificar.TabIndex = 44
        Me.cmdModificar.UseVisualStyleBackColor = True
        '
        'cmdAfegir
        '
        Me.cmdAfegir.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdAfegir.Image = Global.OmsXM.My.Resources.Resources.BotoNou
        Me.cmdAfegir.Location = New System.Drawing.Point(3, 6)
        Me.cmdAfegir.Name = "cmdAfegir"
        Me.cmdAfegir.Size = New System.Drawing.Size(26, 28)
        Me.cmdAfegir.TabIndex = 43
        Me.cmdAfegir.UseVisualStyleBackColor = True
        '
        'LVSubObjects1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.cmdActualitzar)
        Me.Controls.Add(Me.cmdImprimir)
        Me.Controls.Add(Me.cmdEliminar)
        Me.Controls.Add(Me.cmdModificar)
        Me.Controls.Add(Me.cmdAfegir)
        Me.Controls.Add(Me.txtFiltrar)
        Me.Controls.Add(Me.lblFiltrar)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblTitol)
        Me.Controls.Add(Me.lblCount)
        Me.Controls.Add(Me.lstData)
        Me.Name = "LVSubObjects1"
        Me.Size = New System.Drawing.Size(591, 416)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents lblTitol As Label
    Friend WithEvents lblCount As Label
    Friend WithEvents lstData As ListView
    Friend WithEvents txtFiltrar As TextBox
    Friend WithEvents lblFiltrar As Label
    Friend WithEvents cmdActualitzar As Button
    Friend WithEvents cmdImprimir As Button
    Friend WithEvents cmdEliminar As Button
    Friend WithEvents cmdModificar As Button
    Friend WithEvents cmdAfegir As Button
    Friend WithEvents tTip1 As ToolTip
End Class
