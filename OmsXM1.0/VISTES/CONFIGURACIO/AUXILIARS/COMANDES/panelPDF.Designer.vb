<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class panelPDF
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(panelPDF))
        Me.pdfReaderComanda = New AxAcroPDFLib.AxAcroPDF()
        Me.cmdEnviar = New System.Windows.Forms.Button()
        Me.lblTitol = New OmsXM.LBLRIGHT()
        Me.cmdAdjunts = New System.Windows.Forms.Button()
        Me.cmdPdf = New System.Windows.Forms.Button()
        Me.cmdEliminar = New System.Windows.Forms.Button()
        Me.cmdCopiar = New System.Windows.Forms.Button()
        Me.cmdExcel = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cmdBaixar = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.SplitC = New System.Windows.Forms.SplitContainer()
        Me.lblAdjunts = New OmsXM.LBLRED()
        Me.cbAdjunts = New System.Windows.Forms.ComboBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.pdfReader = New AxAcroPDFLib.AxAcroPDF()
        Me.cmdValidar = New System.Windows.Forms.Button()
        Me.tTip1 = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.pdfReaderComanda, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.SplitC, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitC.Panel1.SuspendLayout()
        Me.SplitC.Panel2.SuspendLayout()
        Me.SplitC.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.pdfReader, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pdfReaderComanda
        '
        Me.pdfReaderComanda.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pdfReaderComanda.Enabled = True
        Me.pdfReaderComanda.Location = New System.Drawing.Point(0, 0)
        Me.pdfReaderComanda.Name = "pdfReaderComanda"
        Me.pdfReaderComanda.OcxState = CType(resources.GetObject("pdfReaderComanda.OcxState"), System.Windows.Forms.AxHost.State)
        Me.pdfReaderComanda.Size = New System.Drawing.Size(847, 571)
        Me.pdfReaderComanda.TabIndex = 0
        '
        'cmdEnviar
        '
        Me.cmdEnviar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdEnviar.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.cmdEnviar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdEnviar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdEnviar.Location = New System.Drawing.Point(945, 616)
        Me.cmdEnviar.Name = "cmdEnviar"
        Me.cmdEnviar.Size = New System.Drawing.Size(168, 28)
        Me.cmdEnviar.TabIndex = 80
        Me.cmdEnviar.Text = "ENVIAR"
        Me.cmdEnviar.UseVisualStyleBackColor = False
        '
        'lblTitol
        '
        Me.lblTitol.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTitol.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitol.ForeColor = System.Drawing.Color.Black
        Me.lblTitol.Location = New System.Drawing.Point(171, 1)
        Me.lblTitol.Name = "lblTitol"
        Me.lblTitol.Size = New System.Drawing.Size(765, 32)
        Me.lblTitol.TabIndex = 82
        Me.lblTitol.Text = "Lblright1"
        Me.lblTitol.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmdAdjunts
        '
        Me.cmdAdjunts.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdAdjunts.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.cmdAdjunts.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdAdjunts.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdAdjunts.Location = New System.Drawing.Point(942, 2)
        Me.cmdAdjunts.Name = "cmdAdjunts"
        Me.cmdAdjunts.Size = New System.Drawing.Size(192, 28)
        Me.cmdAdjunts.TabIndex = 78
        Me.cmdAdjunts.Text = "Veure F56"
        Me.cmdAdjunts.UseVisualStyleBackColor = False
        '
        'cmdPdf
        '
        Me.cmdPdf.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdPdf.Image = Global.OmsXM.My.Resources.Resources.pdf
        Me.cmdPdf.Location = New System.Drawing.Point(139, 4)
        Me.cmdPdf.Name = "cmdPdf"
        Me.cmdPdf.Size = New System.Drawing.Size(26, 28)
        Me.cmdPdf.TabIndex = 31
        Me.cmdPdf.UseVisualStyleBackColor = True
        '
        'cmdEliminar
        '
        Me.cmdEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdEliminar.Image = Global.OmsXM.My.Resources.Resources.BotoBorrar
        Me.cmdEliminar.Location = New System.Drawing.Point(75, 5)
        Me.cmdEliminar.Name = "cmdEliminar"
        Me.cmdEliminar.Size = New System.Drawing.Size(26, 28)
        Me.cmdEliminar.TabIndex = 76
        Me.cmdEliminar.Text = "                                                  "
        Me.cmdEliminar.UseVisualStyleBackColor = True
        '
        'cmdCopiar
        '
        Me.cmdCopiar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdCopiar.Image = Global.OmsXM.My.Resources.Resources.copiar
        Me.cmdCopiar.Location = New System.Drawing.Point(3, 4)
        Me.cmdCopiar.Name = "cmdCopiar"
        Me.cmdCopiar.Size = New System.Drawing.Size(26, 28)
        Me.cmdCopiar.TabIndex = 77
        Me.cmdCopiar.UseVisualStyleBackColor = True
        '
        'cmdExcel
        '
        Me.cmdExcel.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdExcel.Image = Global.OmsXM.My.Resources.Resources.excel
        Me.cmdExcel.Location = New System.Drawing.Point(107, 4)
        Me.cmdExcel.Name = "cmdExcel"
        Me.cmdExcel.Size = New System.Drawing.Size(26, 28)
        Me.cmdExcel.TabIndex = 80
        Me.cmdExcel.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.Panel1.Controls.Add(Me.cmdBaixar)
        Me.Panel1.Controls.Add(Me.cmdExcel)
        Me.Panel1.Controls.Add(Me.cmdAdjunts)
        Me.Panel1.Controls.Add(Me.lblTitol)
        Me.Panel1.Controls.Add(Me.cmdCopiar)
        Me.Panel1.Controls.Add(Me.cmdEliminar)
        Me.Panel1.Controls.Add(Me.cmdPdf)
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1147, 35)
        Me.Panel1.TabIndex = 86
        '
        'cmdBaixar
        '
        Me.cmdBaixar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdBaixar.Image = Global.OmsXM.My.Resources.Resources.descarrega
        Me.cmdBaixar.Location = New System.Drawing.Point(35, 4)
        Me.cmdBaixar.Name = "cmdBaixar"
        Me.cmdBaixar.Size = New System.Drawing.Size(32, 28)
        Me.cmdBaixar.TabIndex = 83
        Me.cmdBaixar.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.Controls.Add(Me.SplitC)
        Me.Panel2.Location = New System.Drawing.Point(3, 39)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1147, 571)
        Me.Panel2.TabIndex = 87
        '
        'SplitC
        '
        Me.SplitC.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitC.Location = New System.Drawing.Point(0, 0)
        Me.SplitC.Name = "SplitC"
        '
        'SplitC.Panel1
        '
        Me.SplitC.Panel1.Controls.Add(Me.pdfReaderComanda)
        '
        'SplitC.Panel2
        '
        Me.SplitC.Panel2.Controls.Add(Me.lblAdjunts)
        Me.SplitC.Panel2.Controls.Add(Me.cbAdjunts)
        Me.SplitC.Panel2.Controls.Add(Me.Panel3)
        Me.SplitC.Size = New System.Drawing.Size(1147, 571)
        Me.SplitC.SplitterDistance = 847
        Me.SplitC.TabIndex = 0
        '
        'lblAdjunts
        '
        Me.lblAdjunts.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAdjunts.ForeColor = System.Drawing.Color.Black
        Me.lblAdjunts.Location = New System.Drawing.Point(12, 9)
        Me.lblAdjunts.Name = "lblAdjunts"
        Me.lblAdjunts.Size = New System.Drawing.Size(158, 19)
        Me.lblAdjunts.TabIndex = 77
        Me.lblAdjunts.Text = "Cercador"
        Me.lblAdjunts.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cbAdjunts
        '
        Me.cbAdjunts.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbAdjunts.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbAdjunts.ForeColor = System.Drawing.Color.Blue
        Me.cbAdjunts.FormattingEnabled = True
        Me.cbAdjunts.Location = New System.Drawing.Point(176, 4)
        Me.cbAdjunts.Name = "cbAdjunts"
        Me.cbAdjunts.Size = New System.Drawing.Size(117, 24)
        Me.cbAdjunts.TabIndex = 76
        '
        'Panel3
        '
        Me.Panel3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel3.Controls.Add(Me.pdfReader)
        Me.Panel3.Location = New System.Drawing.Point(3, 31)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(290, 537)
        Me.Panel3.TabIndex = 0
        '
        'pdfReader
        '
        Me.pdfReader.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pdfReader.Enabled = True
        Me.pdfReader.Location = New System.Drawing.Point(0, 0)
        Me.pdfReader.Name = "pdfReader"
        Me.pdfReader.OcxState = CType(resources.GetObject("pdfReader.OcxState"), System.Windows.Forms.AxHost.State)
        Me.pdfReader.Size = New System.Drawing.Size(290, 537)
        Me.pdfReader.TabIndex = 1
        '
        'cmdValidar
        '
        Me.cmdValidar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdValidar.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.cmdValidar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdValidar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdValidar.Location = New System.Drawing.Point(44, 616)
        Me.cmdValidar.Name = "cmdValidar"
        Me.cmdValidar.Size = New System.Drawing.Size(156, 28)
        Me.cmdValidar.TabIndex = 81
        Me.cmdValidar.Text = "ValidarComanda"
        Me.cmdValidar.UseVisualStyleBackColor = False
        '
        'panelPDF
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.cmdValidar)
        Me.Controls.Add(Me.cmdEnviar)
        Me.Name = "panelPDF"
        Me.Size = New System.Drawing.Size(1153, 675)
        CType(Me.pdfReaderComanda, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.SplitC.Panel1.ResumeLayout(False)
        Me.SplitC.Panel2.ResumeLayout(False)
        CType(Me.SplitC, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitC.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        CType(Me.pdfReader, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pdfReaderComanda As AxAcroPDFLib.AxAcroPDF
    Friend WithEvents cmdEnviar As Button
    Friend WithEvents lblTitol As LBLRIGHT
    Friend WithEvents cmdAdjunts As Button
    Friend WithEvents cmdPdf As Button
    Friend WithEvents cmdEliminar As Button
    Friend WithEvents cmdCopiar As Button
    Friend WithEvents cmdExcel As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents SplitC As SplitContainer
    Friend WithEvents cmdValidar As Button
    Friend WithEvents Panel3 As Panel
    Friend WithEvents pdfReader As AxAcroPDFLib.AxAcroPDF
    Friend WithEvents lblAdjunts As LBLRED
    Friend WithEvents cbAdjunts As ComboBox
    Friend WithEvents cmdBaixar As Button
    Friend WithEvents tTip1 As ToolTip
End Class
