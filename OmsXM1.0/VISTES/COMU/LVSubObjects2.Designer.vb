<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LVSubObjects2
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
        Me.lblTitol = New System.Windows.Forms.Label()
        Me.lblCount = New System.Windows.Forms.Label()
        Me.lstData = New System.Windows.Forms.ListView()
        Me.lblOrdre = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cmdSeguent = New OmsXM.BOTO()
        Me.cmdAnterior = New OmsXM.BOTO()
        Me.cmdEliminar = New OmsXM.BOTO()
        Me.cmdModificar = New OmsXM.BOTO()
        Me.cmdAfegir = New OmsXM.BOTO()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblTitol
        '
        Me.lblTitol.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTitol.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitol.ForeColor = System.Drawing.Color.Black
        Me.lblTitol.Location = New System.Drawing.Point(3, 0)
        Me.lblTitol.Name = "lblTitol"
        Me.lblTitol.Size = New System.Drawing.Size(628, 24)
        Me.lblTitol.TabIndex = 48
        Me.lblTitol.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCount
        '
        Me.lblCount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCount.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.lblCount.ForeColor = System.Drawing.Color.Blue
        Me.lblCount.Location = New System.Drawing.Point(39, 186)
        Me.lblCount.Name = "lblCount"
        Me.lblCount.Size = New System.Drawing.Size(395, 16)
        Me.lblCount.TabIndex = 45
        Me.lblCount.Text = "lblCount"
        Me.lblCount.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'lstData
        '
        Me.lstData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstData.BackColor = System.Drawing.SystemColors.HighlightText
        Me.lstData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lstData.CheckBoxes = True
        Me.lstData.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lstData.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.lstData.ForeColor = System.Drawing.Color.Blue
        Me.lstData.FullRowSelect = True
        Me.lstData.GridLines = True
        Me.lstData.HideSelection = False
        Me.lstData.Location = New System.Drawing.Point(7, 27)
        Me.lstData.MultiSelect = False
        Me.lstData.Name = "lstData"
        Me.lstData.Size = New System.Drawing.Size(427, 156)
        Me.lstData.TabIndex = 43
        Me.lstData.UseCompatibleStateImageBehavior = False
        Me.lstData.View = System.Windows.Forms.View.Details
        '
        'lblOrdre
        '
        Me.lblOrdre.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblOrdre.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.lblOrdre.ForeColor = System.Drawing.Color.Black
        Me.lblOrdre.Location = New System.Drawing.Point(10, 52)
        Me.lblOrdre.Name = "lblOrdre"
        Me.lblOrdre.Size = New System.Drawing.Size(59, 20)
        Me.lblOrdre.TabIndex = 51
        Me.lblOrdre.Text = "Label1"
        Me.lblOrdre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.cmdSeguent)
        Me.Panel1.Controls.Add(Me.lblOrdre)
        Me.Panel1.Controls.Add(Me.cmdAnterior)
        Me.Panel1.Location = New System.Drawing.Point(441, 30)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(77, 132)
        Me.Panel1.TabIndex = 52
        '
        'cmdSeguent
        '
        Me.cmdSeguent.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSeguent.AutoSize = True
        Me.cmdSeguent.BackColor = System.Drawing.Color.SeaShell
        Me.cmdSeguent.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdSeguent.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdSeguent.Font = New System.Drawing.Font("Webdings", 25.0!)
        Me.cmdSeguent.Location = New System.Drawing.Point(6, 79)
        Me.cmdSeguent.Name = "cmdSeguent"
        Me.cmdSeguent.Size = New System.Drawing.Size(63, 43)
        Me.cmdSeguent.TabIndex = 50
        Me.cmdSeguent.Text = "6"
        Me.cmdSeguent.UseVisualStyleBackColor = True
        '
        'cmdAnterior
        '
        Me.cmdAnterior.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdAnterior.AutoSize = True
        Me.cmdAnterior.BackColor = System.Drawing.Color.SeaShell
        Me.cmdAnterior.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdAnterior.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdAnterior.Font = New System.Drawing.Font("Webdings", 25.0!)
        Me.cmdAnterior.Location = New System.Drawing.Point(6, 6)
        Me.cmdAnterior.Name = "cmdAnterior"
        Me.cmdAnterior.Size = New System.Drawing.Size(63, 43)
        Me.cmdAnterior.TabIndex = 49
        Me.cmdAnterior.Text = "5"
        Me.cmdAnterior.UseVisualStyleBackColor = True
        '
        'cmdEliminar
        '
        Me.cmdEliminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdEliminar.AutoSize = True
        Me.cmdEliminar.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.cmdEliminar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdEliminar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdEliminar.FlatAppearance.BorderSize = 3
        Me.cmdEliminar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSlateGray
        Me.cmdEliminar.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdEliminar.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.cmdEliminar.Location = New System.Drawing.Point(524, 121)
        Me.cmdEliminar.Name = "cmdEliminar"
        Me.cmdEliminar.Size = New System.Drawing.Size(107, 30)
        Me.cmdEliminar.TabIndex = 47
        Me.cmdEliminar.Text = "cmdEliminar"
        Me.cmdEliminar.UseVisualStyleBackColor = False
        '
        'cmdModificar
        '
        Me.cmdModificar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdModificar.AutoSize = True
        Me.cmdModificar.BackColor = System.Drawing.Color.SeaShell
        Me.cmdModificar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdModificar.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdModificar.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.cmdModificar.Location = New System.Drawing.Point(524, 82)
        Me.cmdModificar.Name = "cmdModificar"
        Me.cmdModificar.Size = New System.Drawing.Size(107, 30)
        Me.cmdModificar.TabIndex = 46
        Me.cmdModificar.Text = "cmdModificar"
        Me.cmdModificar.UseVisualStyleBackColor = True
        '
        'cmdAfegir
        '
        Me.cmdAfegir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdAfegir.AutoSize = True
        Me.cmdAfegir.BackColor = System.Drawing.Color.SeaShell
        Me.cmdAfegir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdAfegir.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdAfegir.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.cmdAfegir.Location = New System.Drawing.Point(524, 46)
        Me.cmdAfegir.Name = "cmdAfegir"
        Me.cmdAfegir.Size = New System.Drawing.Size(107, 30)
        Me.cmdAfegir.TabIndex = 44
        Me.cmdAfegir.Text = "cmdAfegir"
        Me.cmdAfegir.UseVisualStyleBackColor = True
        '
        'LVSubObjects2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.lblTitol)
        Me.Controls.Add(Me.cmdEliminar)
        Me.Controls.Add(Me.cmdModificar)
        Me.Controls.Add(Me.lblCount)
        Me.Controls.Add(Me.cmdAfegir)
        Me.Controls.Add(Me.lstData)
        Me.Name = "LVSubObjects2"
        Me.Size = New System.Drawing.Size(644, 202)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblTitol As Label
    Friend WithEvents cmdEliminar As BOTO
    Friend WithEvents cmdModificar As BOTO
    Friend WithEvents lblCount As Label
    Friend WithEvents cmdAfegir As BOTO
    Friend WithEvents lstData As ListView
    Friend WithEvents cmdAnterior As BOTO
    Friend WithEvents cmdSeguent As BOTO
    Friend WithEvents lblOrdre As Label
    Friend WithEvents Panel1 As Panel
End Class
