﻿Public Class panelDesplegableEmpresa
    Private llargadaPanel As Integer
    Private textToolTip As String
    Private listLLocsEntrega As lstLlocsEntrega
    Private listContactes As lstContactes
    Friend empresaActual As Empresa
    Friend projecteActual As Projecte
    Friend llocActual As LlocEntrega
    Friend contacteActual As Contacte
    Friend Event tempProveidor(p As Proveidor, c As ProveidorCont)
    Friend Event accioMostrar()
    Private actualitzar As Boolean
    Private elements As List(Of Control)
    Public Sub New()
        InitializeComponent()
        elements = getControls()
        Call setAccio()
    End Sub
    Public Sub New(pHeight As Integer, pTecla As String)
        InitializeComponent()
        empresaActual = New Empresa
        elements = getControls()
        llargadaPanel = pHeight
        Button1.Text = "&" & pTecla
    End Sub
    Public Sub New(pHeight As Integer, pTecla As String, pEmpresa As Empresa)
        InitializeComponent()
        elements = getControls()
        llargadaPanel = pHeight
        empresaActual = pEmpresa
        Button1.Text = "&" & pTecla
    End Sub
    Public Sub New(pHeight As Integer, pTecla As String, pEmpresa As Empresa, pProjecte As Projecte)
        InitializeComponent()
        llargadaPanel = pHeight
        empresaActual = pEmpresa
        projecteActual = pProjecte
        Button1.Text = "&" & pTecla
    End Sub

    Private Sub setLanguage()
        Me.lblContacte.Text = IDIOMA.getString("contacte") & ":"
        Me.lblEmpresa.Text = IDIOMA.getString("empresa") & ":"
        Me.lblProjecte.Text = IDIOMA.getString("projecte") & ":"
        Me.lblContacte.Text = IDIOMA.getString("contacte") & ":"
        Me.lblMagatzem.Text = IDIOMA.getString("magatzem") & ":"
        Me.lblResponsables.Text = IDIOMA.getString("responsables") & ":"
    End Sub
    Private Sub validateControls()
        If cbEmpresa.SelectedIndex = -1 Then
            cbProjecte.Enabled = False
            lblDireccio.Text = ""
            txtDirector.Enabled = False
            txtResponsable.Enabled = False
        Else
            cbProjecte.Enabled = True
            txtDirector.Enabled = True
            txtResponsable.Enabled = True
        End If
    End Sub
    Private Sub setEmpresa()
        actualitzar = False
        If Not IsNothing(empresaActual) Then
            cbProjecte.Items.Clear()
            cbProjecte.Items.AddRange(ModelProjecte.getListObjects(empresaActual.id))
            cbProjecte.SelectedItem = projecteActual
        Else
            cbProjecte.Items.Clear()
            cbProjecte.SelectedIndex = -1
        End If
        actualitzar = True
        Call validateControls()
    End Sub
    Private Sub setProjecte()
        projecteActual.magatzems = ModelProjecteEntrega.getObjects(projecteActual.id)
        projecteActual.contactes = ModelProjecteContacte.getObjects(projecteActual.id)
        If projecteActual.magatzems.Count > 0 Then
            listLLocsEntrega = New lstLlocsEntrega(ModelLlocEntrega.getObject(projecteActual.magatzems.Item(0).idEntrega))
        Else
            listLLocsEntrega = New lstLlocsEntrega(ModelLlocEntrega.getObject(Nothing))
        End If
        If projecteActual.contactes.Count > 0 Then
            listContactes = New lstContactes(ModelContacte.getObject(projecteActual.contactes.Item(0).idContacte))
        Else
            listContactes = New lstContactes(ModelContacte.getObject(Nothing))
        End If
        AddHandler listContactes.selectObject, AddressOf setContacte

        Me.panelMagatzem.Controls.Clear()
        listLLocsEntrega.Dock = DockStyle.Fill
        Me.panelMagatzem.Controls.Add(listLLocsEntrega)
        AddHandler listLLocsEntrega.selectObject, AddressOf setLlocEntrega
        Call setLlocEntrega()
        Me.PanelContacte.Controls.Clear()
        listContactes.Dock = DockStyle.Fill
        Me.PanelContacte.Controls.Add(listContactes)
        Call setContacte()
        txtResponsable.Text = projecteActual.responsable
        txtDirector.Text = projecteActual.director
        Call validateControls()
    End Sub
    Private Sub setLlocEntrega()

        llocActual = listLLocsEntrega.obj
        If Not IsNothing(listLLocsEntrega.obj) Then
            lblDireccio.Text = llocActual.toTarget
        Else
            lblDireccio.Text = ""
        End If
    End Sub
    Private Sub setContacte()
        contacteActual = listContactes.obj
        If Not IsNothing(listContactes.obj) Then
            lblTelEmail.Text = contacteActual.toTarget
        Else
            lblTelEmail.Text = ""
        End If
    End Sub
    Private ReadOnly Property etiqueta As String
        Get
            Return IDIOMA.getString("projecte") & ": " & projecteActual.nom & " | " & llocActual.nom & " | " & contacteActual.nom
        End Get
    End Property
    Private Function getDadesLLocEntrega() As LlocEntrega
        getDadesLLocEntrega = llocActual.copy
    End Function
    Private Function getDadesContacte() As Contacte
        getDadesContacte = contacteActual.copy
    End Function

    Friend Sub setAccio()
        If lblAccio.Text = " - " Then
            lblAccio.Text = " + "
            Me.panelData.Visible = False
            Me.PanelTipTool.Visible = True
            Me.Height = 60
            Me.Parent.Height = 60
            Me.ToolTip1.SetToolTip(lblAccio, IDIOMA.getString("mostrarDades") & " " & textToolTip)
            Call setTipTool()
        Else
            lblAccio.Text = " - "
            Me.Height = llargadaPanel
            Me.Parent.Height = llargadaPanel
            Me.panelData.Visible = True
            Me.PanelTipTool.Visible = False
        End If
        If Not IsNothing(cbEmpresa) Then cbEmpresa.Select()
        RaiseEvent accioMostrar()
    End Sub
    Private Sub lblAccio_Click(sender As Object, e As EventArgs) Handles lblAccio.Click
        Call setAccio()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Call setAccio()
    End Sub
    Private Sub setTipTool()
        Dim t As String = ""
        If projecteActual IsNot Nothing Then
            t = projecteActual.ToString & vbCrLf
            If llocActual IsNot Nothing Then
                t = t & llocActual.ToString
            End If
            If contacteActual IsNot Nothing Then t = t & vbCrLf & contacteActual.tostring
        End If
        Me.lblTipTool.Text = t
    End Sub

    Private Sub cbEmpresa_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbEmpresa.SelectedIndexChanged
        If cbEmpresa.SelectedIndex > -1 Then
            empresaActual = cbEmpresa.SelectedItem
            Call setEmpresa()
            If lblAccio.Text = " + " Then
                Call setAccio()
            End If
        Else
            empresaActual = Nothing
            Call setEmpresa()
            If lblAccio.Text = " - " Then
                Call setAccio()
            End If
        End If
        Call validateControls()
    End Sub
    Private Sub cbEmpresa_TextChanged(sender As Object, e As EventArgs) Handles cbEmpresa.TextChanged
        If actualitzar Then
            If cbEmpresa.Text = "" Then
                empresaActual = Nothing
                Call setEmpresa()
                If lblAccio.Text = " - " Then
                    Call setAccio()
                End If
            End If
        End If
    End Sub
    Private Sub cbProjecte_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbProjecte.SelectedIndexChanged
        If cbProjecte.SelectedIndex > -1 Then
            projecteActual = cbProjecte.SelectedItem
            Call setProjecte()
        Else
            projecteActual = Nothing
            listLLocsEntrega = Nothing
            Me.PanelContacte.Controls.Clear()
            Me.panelMagatzem.Controls.Clear()
            Me.lblDireccio.Text = ""
            Me.lblContacte.Text = ""
            Me.txtResponsable.Text = ""
            Me.txtDirector.Text = ""
        End If
        Call validateControls()
    End Sub
    Private Sub cbProjecte_TextChanged(sender As Object, e As EventArgs) Handles cbProjecte.TextChanged
        If actualitzar Then
            If cbProjecte.Text = "" Then
                projecteActual = Nothing
                listLLocsEntrega = Nothing
                Me.PanelContacte.Controls.Clear()
                Me.panelMagatzem.Controls.Clear()
                Me.lblDireccio.Text = ""
                Me.lblContacte.Text = ""
                Me.txtResponsable.Text = ""
                Me.txtDirector.Text = ""
            End If
        End If
    End Sub
    Private Sub panelDesplegableEmpresa_Load(sender As Object, e As EventArgs) Handles Me.Load
        actualitzar = False
        cbEmpresa.Items.AddRange(ModelEmpresa.getListObjects)
        actualitzar = True
        If empresaActual IsNot Nothing Then Me.cbEmpresa.SelectedItem = empresaActual
        Call setLanguage()
        Call setAccio()
        Call validateControls()
    End Sub

    Private Sub txt_KeyDown(sender As Object, e As KeyEventArgs) Handles panelMagatzem.KeyDown,
                                                                         PanelContacte.KeyDown,
                                                                         txtDirector.KeyDown,
                                                                         txtResponsable.KeyDown
        If e.KeyValue = Keys.Enter Or e.KeyValue = Keys.Down Then
            e.Handled = False
            Call SendKeys.Send("{tab}")
        ElseIf e.KeyValue = Keys.Up Then
            e.Handled = False
            Call getTab(sender, -1)
        End If
    End Sub
    Private Function getControls() As List(Of Control)
        getControls = New List(Of Control)
        getControls.Add(panelMagatzem)
        getControls.Add(txtResponsable)
        getControls.Add(txtDirector)
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
    Protected Overrides Sub Finalize()
        MyBase.Finalize()
        listLLocsEntrega = Nothing
        listContactes = Nothing
        empresaActual = Nothing
        projecteActual = Nothing
        llocActual = Nothing
        contacteActual = Nothing
    End Sub
End Class
