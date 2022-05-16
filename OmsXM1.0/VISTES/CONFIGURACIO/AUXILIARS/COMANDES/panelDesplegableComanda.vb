Option Explicit On
Public Class panelDesplegableComanda
    Private llargadaPanel As Integer
    Private textToolTip As String
    Private comandaActual As Comanda
    Friend listCondicionsPagament As lstAuxiliars1
    Private panelDataComanda As SelectDia
    Private panelDataEntregaEquips As SelectDia
    Private PanelDataMuntatgeEquips As SelectDia
    Friend Event accioMostrar()
    Friend Event selectObject()


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

        Me.lblCondicionsPagament.Text = IDIOMA.getString("tipusPagament") & ":"
        Me.lblDadesBancaries.Text = IDIOMA.getString("dadesBancaries") & ":"
        Me.lblData.Text = IDIOMA.getString("data") & ":"
        Me.lblEntregaEquips.Text = IDIOMA.getString("dataEntrega") & ":"
        Me.lblEntregaMuntatge.Text = IDIOMA.getString("dataMuntatge") & ":"
        Me.lblOferta.Text = IDIOMA.getString("numOferta") & ":"

        Me.lblPorts.Text = IDIOMA.getString("ports") & ":"


        Me.lblInici.Text = IDIOMA.getString("%iniciComanda")
        Me.lblFacturacio.Text = IDIOMA.getString("facturacio") & ":"
        Me.lblEEquips.Text = IDIOMA.getString("%iniciTreballs")
        Me.lblEntrega.Text = IDIOMA.getString("%entrega")
    End Sub
    Private Sub setData()
        Me.lblComanda.Text = comandaActual.getCodi
        Me.txtPorts.Text = comandaActual.ports
        Me.txtDadesBancaries.Text = comandaActual.dadesBancaries
        Me.txtOferta.Text = comandaActual.nOferta
        Me.txtEntrega.Text = comandaActual.entrega
        Me.txtIniciTreballs.Text = comandaActual.entregaEquips
        Me.txtFactComanda.Text = comandaActual.inici


    End Sub
    Public Sub setObjects(estat As Boolean)
        Me.txtPorts.Enabled = estat
        Me.txtDadesBancaries.Enabled = estat
        Me.txtOferta.Enabled = estat
        Me.txtEntrega.Enabled = estat
        Me.txtIniciTreballs.Enabled = estat
        Me.txtFactComanda.Enabled = estat
        If Not IsNothing(panelDataComanda) Then panelDataComanda.setObjects(estat)
        If Not IsNothing(panelDataEntregaEquips) Then panelDataEntregaEquips.setObjects(estat)
        If Not IsNothing(PanelDataMuntatgeEquips) Then PanelDataMuntatgeEquips.setObjects(estat)
        If Not IsNothing(listCondicionsPagament) Then listCondicionsPagament.setObjects(estat)
    End Sub
    Private Sub PanelDadesComanda_Load(sender As Object, e As EventArgs) Handles Me.Load
        Call setLanguage()
        panelDataComanda = New SelectDia(comandaActual.data, IDIOMA.getString("escollirData"))
        AddHandler panelDataComanda.selectObject, AddressOf setDate
        panelDataEntregaEquips = New SelectDia(comandaActual.dataEntrega, IDIOMA.getString("escollirData"))
        PanelDataMuntatgeEquips = New SelectDia(comandaActual.dataMuntatge, IDIOMA.getString("escollirData"))

        listCondicionsPagament = New lstAuxiliars1(comandaActual.tipusPagament, DBCONNECT.getTaulaTipusPagament)
        AddHandler listCondicionsPagament.selectObject, AddressOf setCondicions



        Me.PanelDate.Controls.Clear()
        Me.panelDataEquips.Controls.Clear()
        Me.panelDataMuntatge.Controls.Clear()
        Me.panelCondicionsPagament.Controls.Clear()

        panelDataComanda.Dock = DockStyle.Fill
        panelDataEntregaEquips.Dock = DockStyle.Fill
        PanelDataMuntatgeEquips.Dock = DockStyle.Fill
        listCondicionsPagament.Dock = DockStyle.Fill

        Me.PanelDate.Controls.Add(panelDataComanda)
        Me.panelDataEquips.Controls.Add(panelDataEntregaEquips)
        Me.panelDataMuntatge.Controls.Add(PanelDataMuntatgeEquips)
        Me.panelCondicionsPagament.Controls.Add(listCondicionsPagament)

        elements = getControls()
        If comandaActual IsNot Nothing Then Call setData()
        Call setAccio()
    End Sub
    Private Sub setDate(d As Date)

        RaiseEvent selectObject()
    End Sub
    Private Sub setCondicions()

        RaiseEvent selectObject()
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
                Return IDIOMA.getString("data") & ": " & dataActual & vbCrLf & IDIOMA.getString("tipusPagament") & ": " & listCondicionsPagament.cb.SelectedItem.ToString
            Else
                Return IDIOMA.getString("data") & ": " & dataActual
            End If

        End Get
    End Property
    Private Sub setTipTool()
        Me.lblTitpTool.Text = etiqueta
    End Sub
    Private Function getControls() As List(Of Control)
        getControls = New List(Of Control)
        getControls.Add(Me.panelDataComanda.txtData)
        getControls.Add(txtPorts)
        getControls.Add(Me.panelDataEntregaEquips.txtData)
        getControls.Add(Me.PanelDataMuntatgeEquips.txtData)
        getControls.Add(Me.txtFactComanda)
        getControls.Add(Me.txtIniciTreballs)
        getControls.Add(Me.txtEntrega)
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
    Public Property dataActual As Date
        Get
            If IsDate(panelDataComanda.txtData.Text) Then
                Return CDate(panelDataComanda.txtData.Text)
            Else
                Return Nothing
            End If

        End Get
        Set(value As Date)
            panelDataComanda.txtData.Text = Format(value, "dd-MM-yy")
        End Set
    End Property
    Public Property dataEntregaActual As Date
        Get
            If IsDate(panelDataEntregaEquips.txtData.Text) Then
                Return CDate(panelDataEntregaEquips.txtData.Text)
            Else
                Return Nothing
            End If

        End Get
        Set(value As Date)
            If Year(value) > 2000 Then
                panelDataEntregaEquips.txtData.Text = Format(value, "dd-MM-yy")
            Else
                panelDataEntregaEquips.txtData.Text = ""
            End If
        End Set
    End Property
    Public Property dataMuntatgeActual As Date
        Get
            If IsDate(PanelDataMuntatgeEquips.txtData.Text) Then
                Return CDate(PanelDataMuntatgeEquips.txtData.Text)
            Else
                Return Nothing
            End If

        End Get
        Set(value As Date)
            If Year(value) > 2000 Then
                PanelDataMuntatgeEquips.txtData.Text = Format(value, "dd-MM-yy")
            Else
                PanelDataMuntatgeEquips.txtData.Text = ""
            End If            
        End Set
    End Property
    Public Property ports As String
        Get
            Return txtPorts.Text
        End Get
        Set(value As String)
            txtPorts.Text = value
        End Set
    End Property
    Public Property FacturacioPedido As Integer
        Get
            Return txtFactComanda.Text
        End Get
        Set(value As Integer)
            txtFactComanda.Text = value
        End Set
    End Property
    Public Property dadesBancaries As String
        Get
            Return txtDadesBancaries.Text
        End Get
        Set(value As String)
            txtDadesBancaries.Text = value
        End Set
    End Property
    Public Property oferta As String
        Get
            Return txtOferta.Text
        End Get
        Set(value As String)
            txtOferta.Text = value
        End Set
    End Property
    Public Property iniciTreballs As Integer
        Get
            Return txtIniciTreballs.Text
        End Get
        Set(value As Integer)
            txtIniciTreballs.Text = value
        End Set
    End Property
    Public Property entrega As Integer
        Get
            Return txtEntrega.Text
        End Get
        Set(value As Integer)
            txtEntrega.Text = value
        End Set
    End Property
    Public Property tipuspagament As TipusPagament
        Get
            If listCondicionsPagament.obj Is Nothing Then Return New TipusPagament
            Return listCondicionsPagament.obj
        End Get
        Set(value As TipusPagament)
            listCondicionsPagament.obj = value
        End Set
    End Property

    Private Sub txtEnter_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFactComanda.KeyPress, txtEntrega.KeyPress, txtIniciTreballs.KeyPress
        e.KeyChar = VALIDAR.EnterMax(e.KeyChar, Len(sender.text), 3, sender.text, 100)
    End Sub

End Class
