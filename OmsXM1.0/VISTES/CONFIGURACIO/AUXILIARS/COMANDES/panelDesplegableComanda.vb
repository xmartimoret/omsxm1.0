Public Class panelDesplegableComanda
    Private llargadaPanel As Integer
    Private textToolTip As String
    Private comandaActual As Comanda
    Friend listCondicionsPagament As lstAuxiliars1
    Private dataComanda As SelectDia
    Private dataEntregaEquips As SelectDia
    Private dataMuntatgeEquips As SelectDia
    Friend Event accioMostrar()
    Private actualitzar As Boolean
    Private elements As List(Of Control)

    Public Sub New(pComanda As Comanda)
        InitializeComponent()
        comandaActual = pComanda
        If comandaActual IsNot Nothing Then Call setData()
    End Sub
    Public Sub New()
        InitializeComponent()
        comandaActual = New Comanda
        elements = getControls()

    End Sub
    Public Sub New(pHeight As Integer, pTecla As String)
        InitializeComponent()
        comandaActual = New Comanda

        llargadaPanel = pHeight
        Button1.Text = "&" & pTecla

    End Sub
    Public Sub New(pHeight As Integer, pTecla As String, pComanda As Comanda)
        InitializeComponent()
        llargadaPanel = pHeight
        comandaActual = pComanda
        Button1.Text = "&" & pTecla

    End Sub

    Private Sub setLanguage()
        Me.lblInterAval.Text = IDIOMA.getString("interAval")
        Me.lblCondicionsPagament.Text = IDIOMA.getString("tipusPagament")
        Me.lblDadesBancaries.Text = IDIOMA.getString("dadesBancaries")
        Me.lblData.Text = IDIOMA.getString("data")
        Me.lblEntregaEquips.Text = IDIOMA.getString("dataEntrega")
        Me.lblEntregaMuntatge.Text = IDIOMA.getString("dataMuntatge")
        Me.lblOferta.Text = IDIOMA.getString("numOferta")
        Me.lblRetencio.Text = IDIOMA.getString("retencio")
        Me.lblPorts.Text = IDIOMA.getString("ports")
    End Sub
    Private Sub setData()
        Me.lblComanda.Text = IDIOMA.getString("nComanda") & ": " & comandaActual.codi
        Me.txtPorts.Text = comandaActual.ports
        Me.txtDadesBancaries.Text = comandaActual.dadesBancaries
        Me.txtOferta.Text = comandaActual.nOferta
        Me.txtRetencio.Text = comandaActual.retencio
        Me.txtInterAval.Text = comandaActual.interAval
    End Sub
    Private Sub PanelDadesComanda_Load(sender As Object, e As EventArgs) Handles Me.Load
        Call setLanguage()
        dataComanda = New SelectDia(comandaActual.data, IDIOMA.getString("escollirData"))
        dataEntregaEquips = New SelectDia(comandaActual.dataEntrega, IDIOMA.getString("escollirData"))
        dataMuntatgeEquips = New SelectDia(comandaActual.dataMuntatge, IDIOMA.getString("escollirData"))
        listCondicionsPagament = New lstAuxiliars1(comandaActual.tipusPagament, DBCONNECT.getTaulaTipusPagament)
        Me.PanelDate.Controls.Clear()
        Me.panelDataEquips.Controls.Clear()
        Me.panelDataMuntatge.Controls.Clear()
        Me.panelCondicionsPagament.Controls.Clear()
        dataComanda.Dock = DockStyle.Fill
        dataEntregaEquips.Dock = DockStyle.Fill
        dataMuntatgeEquips.Dock = DockStyle.Fill
        listCondicionsPagament.Dock = DockStyle.Fill
        Me.PanelDate.Controls.Add(dataComanda)
        Me.panelDataEquips.Controls.Add(dataEntregaEquips)
        Me.panelDataMuntatge.Controls.Add(dataMuntatgeEquips)
        Me.panelCondicionsPagament.Controls.Add(listCondicionsPagament)
        elements = getControls()
        If comandaActual IsNot Nothing Then Call setData()
        Call setAccio()
    End Sub
    Friend Sub setAccio()
        If lblAccio.Text = " - " Then
            lblAccio.Text = " + "
            Me.panelData.Visible = False
            Me.panelTipTool.Visible = True
            Me.Height = 60
            Me.Parent.Height = 60
            Me.ToolTip1.SetToolTip(lblAccio, IDIOMA.getString("mostrarDades") & " " & textToolTip)
            Call setTipTool()
        Else
            lblAccio.Text = " - "
            Me.Height = llargadaPanel
            Me.Parent.Height = llargadaPanel
            Me.panelData.Visible = True
            Me.panelTipTool.Visible = False
            'dataComanda.txtData.Select()
        End If

        RaiseEvent accioMostrar()
    End Sub
    Private Sub lblAccio_Click(sender As Object, e As EventArgs) Handles lblAccio.Click
        Call setAccio()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Call setAccio()
    End Sub
    Private ReadOnly Property etiqueta As String
        Get
            If listCondicionsPagament.cb.SelectedIndex > -1 Then
                Return IDIOMA.getString("data") & ": " & dataComanda.dataActual & vbCrLf & IDIOMA.getString("tipusPagament") & ": " & listCondicionsPagament.cb.SelectedItem.ToString
            Else
                Return IDIOMA.getString("data") & ": " & dataComanda.dataActual
            End If

        End Get
    End Property
    Private Sub setTipTool()
        Me.lblTitpTool.Text = etiqueta
    End Sub
    Private Function getControls() As List(Of Control)
        getControls = New List(Of Control)
        getControls.Add(Me.dataComanda.txtData)
        getControls.Add(txtPorts)
        getControls.Add(Me.dataEntregaEquips.txtData)
        getControls.Add(Me.dataMuntatgeEquips.txtData)
        getControls.Add(Me.txtRetencio)
        getControls.Add(Me.txtInterAval)
        getControls.Add(Me.txtOferta)
        getControls.Add(Me.listCondicionsPagament.cb)
        getControls.Add(Me.txtDadesBancaries)
    End Function
    Private Sub getTab(sender As Object, p As Integer)
        Dim i As Integer
        For i = 0 To elements.Count - 1
            If sender.Equals(elements(i)) Then
                Exit For
            End If
        Next
        If i + p = elements.Count Then
            elements(0).Select()
        ElseIf i + p < 0 Then
            elements(elements.Count - 1).Select()
        Else
            elements(i + p).Select()
        End If
    End Sub


End Class
