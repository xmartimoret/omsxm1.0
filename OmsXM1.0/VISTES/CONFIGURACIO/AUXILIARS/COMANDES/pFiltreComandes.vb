Public Class pFiltreComandes
    Private projectes As List(Of Projecte)
    Private proveidors As List(Of Proveidor)
    Private actualitzar As Boolean
    Private empresaActual As Empresa
    Private pDataIni As SelectDia
    Private pDataFi As SelectDia
    Friend Event selectObjects(comandes As List(Of Comanda))
    Friend filtreActual As String
    Public Sub New()
        InitializeComponent()
        empresaActual = ModelEmpresa.getObject(1)

        Call setLanguage()
        Call setEmpreses()
        Call setDates()
    End Sub
    Private Sub setLanguage()
        Me.lblDataFi.Text = IDIOMA.getString("a")
        Me.lblDataIni.Text = IDIOMA.getString("de")
        Me.lblEmpresa.Text = IDIOMA.getString("empreses")
        Me.cmdFiltrar.Text = IDIOMA.getString("cercar")
        Me.xecTotesEmpresa.Text = IDIOMA.getString("totesLesEmpreses")
        Me.lblProveidors.Text = IDIOMA.getString("proveidorsACercar")
        Me.lblProjectes.Text = IDIOMA.getString("projectesACercar")
        Me.cmdAfegirProjecte.Text = IDIOMA.getString("cmdAfegir")
        Me.cmdAfegirProveidor.Text = IDIOMA.getString("cmdAfegir")
        Me.cmdTreureProjecte.Text = IDIOMA.getString("cmdTreure")
        Me.cmdTreureProveidor.Text = IDIOMA.getString("cmdTreure")

    End Sub
    Private Sub setEmpreses()
        actualitzar = False
        cbEmpresa.Items.Clear()
        cbEmpresa.Items.AddRange(ModelEmpresa.getListObjects)
        actualitzar = True
        If empresaActual IsNot Nothing Then Me.cbEmpresa.SelectedItem = empresaActual

    End Sub

    Private Sub setDates()

        pDataIni = New SelectDia(Now, IDIOMA.getString("escollirData"))
        Me.panelDataInici.Controls.Clear()
        pDataIni.Dock = DockStyle.Fill
        Me.panelDataInici.Controls.Add(pDataIni)

        pDataFi = New SelectDia(Now, IDIOMA.getString("escollirData"))
        Me.panelDataFi.Controls.Clear()
        pDataFi.Dock = DockStyle.Fill
        Me.panelDataFi.Controls.Add(pDataFi)
    End Sub

    Private Sub cbEmpresa_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbEmpresa.SelectedIndexChanged
        If actualitzar Then
            If cbEmpresa.SelectedIndex > -1 Then
                empresaActual = cbEmpresa.SelectedItem
                'Call setProjectes()
            End If
        End If
    End Sub
    Public Property empresa As Empresa
        Get
            Return empresaActual
        End Get
        Set(value As Empresa)
            empresaActual = value
        End Set
    End Property

    Private Sub cmdFiltrar_Click(sender As Object, e As EventArgs) Handles cmdFiltrar.Click
        Dim P As New frmAvis(IDIOMA.getString("esperaUnMoment"), IDIOMA.getString("cercantComandes"), ""), comandes As List(Of Comanda), t As Proveidor, t1 As Projecte
        comandes = New List(Of Comanda)
        filtreActual = "(" & pDataIni.dataActual & " a " & pDataFi.dataActual & ")"
        If xecTotesEmpresa.Checked Then
            comandes.AddRange(ModelComandaEnEdicio.getObjects(CDate(pDataIni.txtData.Text), CDate(pDataFi.txtData.Text), -1, getProveidors, getProjectes, 0))
            comandes.AddRange(ModelComandaEnEdicio.getObjects(CDate(pDataIni.txtData.Text), CDate(pDataFi.txtData.Text), -1, getProveidors, getProjectes, 1))
            comandes.AddRange(ModelComanda.getObjects(CDate(pDataIni.txtData.Text), CDate(pDataFi.txtData.Text), -1, getProveidors, getProjectes))

        Else

            comandes.AddRange(ModelComandaEnEdicio.getObjects(CDate(pDataIni.txtData.Text), CDate(pDataFi.txtData.Text), empresaActual.id, getProveidors, getProjectes, 0))
            comandes.AddRange(ModelComandaEnEdicio.getObjects(CDate(pDataIni.txtData.Text), CDate(pDataFi.txtData.Text), empresaActual.id, getProveidors, getProjectes, 1))
            comandes.AddRange(ModelComanda.getObjects(CDate(pDataIni.txtData.Text), CDate(pDataFi.txtData.Text), empresaActual.id, getProveidors, getProjectes))
        End If

        If lstProjectes.Items.Count > 0 Then
            filtreActual = filtreActual & vbCrLf & IDIOMA.getString("projectes") & ": "
            For Each t1 In lstProjectes.Items
                filtreActual = filtreActual & t1.codi & ", "
            Next
        End If
        If lstProveidors.Items.Count > 0 Then
            filtreActual = filtreActual & vbCrLf & IDIOMA.getString("proveidors") & ": "
            For Each t In lstProveidors.Items
                filtreActual = filtreActual & t.nom & ", "
            Next
        End If
        RaiseEvent selectObjects(comandes)
        P.tancar()
    End Sub
    Private Function getProveidors() As List(Of Proveidor)
        Dim p As Proveidor
        getProveidors = New List(Of Proveidor)
        For Each p In lstProveidors.Items
            getProveidors.Add(p)
        Next
        p = Nothing
    End Function
    Private Function getProjectes() As List(Of Projecte)
        Dim p As Projecte
        getProjectes = New List(Of Projecte)
        For Each p In lstProjectes.Items
            getProjectes.Add(p)
        Next
        p = Nothing
    End Function
    Private Sub cmdAfegirProjecte_Click(sender As Object, e As EventArgs) Handles cmdAfegirProjecte.Click
        Dim tempProjectes As List(Of Projecte)
        If xecTotesEmpresa.Checked Then
            tempProjectes = DAuxiliars.getProjectes()
        Else
            tempProjectes = DAuxiliars.getProjectes(empresaActual.id)
        End If
        If Not IsNothing(tempProjectes) Then
            lstProjectes.Items.AddRange(ModelProjecte.getListObjects(tempProjectes))
        End If
        tempProjectes = Nothing
    End Sub

    Private Sub cmdTreureProjecte_Click(sender As Object, e As EventArgs) Handles cmdTreureProjecte.Click
        Dim p As Projecte, temp As List(Of Projecte)
        temp = New List(Of Projecte)
        For Each p In lstProjectes.SelectedItems()
            temp.Add(p)
        Next
        For Each p In temp
            lstProjectes.Items.Remove(p)
        Next
        p = Nothing
        temp = Nothing
    End Sub

    Private Sub cmdTreureProveidor_Click(sender As Object, e As EventArgs) Handles cmdTreureProveidor.Click
        Dim p As Proveidor, temp As List(Of Proveidor)
        temp = New List(Of Proveidor)
        For Each p In lstProveidors.SelectedItems()
            temp.Add(p)
        Next
        For Each p In temp
            lstProveidors.Items.Remove(p)
        Next
        p = Nothing
        temp = Nothing
    End Sub

    Private Sub cmdAfegirProveidor_Click(sender As Object, e As EventArgs) Handles cmdAfegirProveidor.Click
        Dim tempProveidors As List(Of Proveidor)
        tempProveidors = DAuxiliars.getProveidors()
        If Not IsNothing(tempProveidors) Then
            lstProveidors.Items.AddRange(ModelProveidor.getListObjects(tempProveidors))
        End If
        tempProveidors = Nothing
    End Sub

End Class

'copia seguretat 22/11/22
'Public Class pFiltreComandes
'    Private pProjectes As lstBoxFilter
'    Private pProveidors As lstBoxFilter
'    'Private pArticles As lstBoxFilter
'    Private actualitzar As Boolean
'    Private empresaActual As Empresa
'    Private pDataIni As SelectDia
'    Private pDataFi As SelectDia
'    Friend Event selectObjects(comandes As List(Of Comanda))
'    Public Sub New()
'        InitializeComponent()
'        empresaActual = ModelEmpresa.getObject(1)
'        If txtCercarCodi.TextLength < 4 Then
'            Me.cmdCercarCodi.Enabled = False
'        Else
'            Me.cmdCercarCodi.Enabled = True
'        End If
'        Call setLanguage()
'        Call setEmpreses()
'        Call setDates()
'        Call setProveidors()
'        Call setArticles()
'    End Sub
'    Private Sub setLanguage()
'        Me.lblDataFi.Text = IDIOMA.getString("a")
'        Me.lblDataIni.Text = IDIOMA.getString("de")
'        Me.lblEmpresa.Text = IDIOMA.getString("empreses")
'        Me.cmdFiltrar.Text = IDIOMA.getString("cercar")
'        Me.xecTotesEmpresa.Text = IDIOMA.getString("totesLesEmpreses")
'        Me.lblCercarCodi.Text = IDIOMA.getString("cercarPerCodi")
'        Me.cmdCercarCodi.Text = IDIOMA.getString("cercar")

'    End Sub
'    Private Sub setEmpreses()
'        actualitzar = False
'        cbEmpresa.Items.Clear()
'        cbEmpresa.Items.AddRange(ModelEmpresa.getListObjects)
'        actualitzar = True
'        If empresaActual IsNot Nothing Then Me.cbEmpresa.SelectedItem = empresaActual

'    End Sub
'    Private Sub setProjectes()
'        pProjectes = New lstBoxFilter(IDIOMA.getString("projectes"), ModelProjecte.getListObjects(empresaActual.id))
'        panelProjecte.Controls.Clear()
'        pProjectes.Dock = DockStyle.Fill
'        panelProjecte.Controls.Add(pProjectes)
'    End Sub
'    Private Sub setArticles()
'        'pArticles = New lstBoxFilter(IDIOMA.getString("articles"), ModelArticle.getListObjects())
'        'panelArticle.Controls.Clear()
'        'pArticles.Dock = DockStyle.Fill
'        'panelArticle.Controls.Add(pArticles)
'    End Sub
'    Private Sub setProveidors()
'        pProveidors = New lstBoxFilter(IDIOMA.getString("proveidors"), ModelProveidor.getListObjects)
'        panelProveidor.Controls.Clear()
'        pProveidors.Dock = DockStyle.Fill
'        panelProveidor.Controls.Add(pProveidors)
'    End Sub
'    Private Sub setDates()

'        pDataIni = New SelectDia(Now, IDIOMA.getString("escollirData"))
'        Me.panelDataInici.Controls.Clear()
'        pDataIni.Dock = DockStyle.Fill
'        Me.panelDataInici.Controls.Add(pDataIni)

'        pDataFi = New SelectDia(Now, IDIOMA.getString("escollirData"))
'        Me.panelDataFi.Controls.Clear()
'        pDataFi.Dock = DockStyle.Fill
'        Me.panelDataFi.Controls.Add(pDataFi)
'    End Sub

'    Private Sub cbEmpresa_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbEmpresa.SelectedIndexChanged
'        If actualitzar Then
'            If cbEmpresa.SelectedIndex > -1 Then
'                empresaActual = cbEmpresa.SelectedItem
'                Call setProjectes()
'            End If
'        End If
'    End Sub
'    Public Property empresa As Empresa
'        Get
'            Return empresaActual
'        End Get
'        Set(value As Empresa)
'            empresaActual = value
'        End Set
'    End Property

'    Private Sub cmdFiltrar_Click(sender As Object, e As EventArgs) Handles cmdFiltrar.Click
'        Dim P As New frmAvis(IDIOMA.getString("esperaUnMoment"), IDIOMA.getString("cercantComandes"), ""), comandes As List(Of Comanda)
'        comandes = New List(Of Comanda)
'        '   For Each a In ModelComandaEnEdicio.getObjects(CDate(pDataIni.txtData.Text), CDate(pDataFi.txtData.Text), empresaActual.id, getProveidors, getProjectes, 0)
'        If xecTotesEmpresa.Checked Then
'            comandes.AddRange(ModelComandaEnEdicio.getObjects(CDate(pDataIni.txtData.Text), CDate(pDataFi.txtData.Text), -1, getProveidors, getProjectes, 0))
'            comandes.AddRange(ModelComandaEnEdicio.getObjects(CDate(pDataIni.txtData.Text), CDate(pDataFi.txtData.Text), -1, getProveidors, getProjectes, 1))
'            comandes.AddRange(ModelComanda.getObjects(CDate(pDataIni.txtData.Text), CDate(pDataFi.txtData.Text), -1, getProveidors, getProjectes))
'        Else
'            comandes.AddRange(ModelComandaEnEdicio.getObjects(CDate(pDataIni.txtData.Text), CDate(pDataFi.txtData.Text), empresaActual.id, getProveidors, getProjectes, 0))
'            comandes.AddRange(ModelComandaEnEdicio.getObjects(CDate(pDataIni.txtData.Text), CDate(pDataFi.txtData.Text), empresaActual.id, getProveidors, getProjectes, 1))
'            comandes.AddRange(ModelComanda.getObjects(CDate(pDataIni.txtData.Text), CDate(pDataFi.txtData.Text), empresaActual.id, getProveidors, getProjectes))
'        End If

'        ' Next

'        RaiseEvent selectObjects(comandes)
'        P.tancar()
'    End Sub
'    Private Function getProveidors() As List(Of Proveidor)
'        Dim p As Proveidor
'        getProveidors = New List(Of Proveidor)
'        For Each p In pProveidors.lstData.SelectedItems()
'            getProveidors.Add(p)
'        Next
'        p = Nothing
'    End Function
'    Private Function getProjectes() As List(Of Projecte)
'        Dim p As Projecte
'        getProjectes = New List(Of Projecte)
'        For Each p In pProjectes.lstData.SelectedItems()
'            getProjectes.Add(p)
'        Next
'        p = Nothing
'    End Function

'    Private Sub cmdCercarCodi_Click(sender As Object, e As EventArgs) Handles cmdCercarCodi.Click
'        Dim P As New frmAvis(IDIOMA.getString("esperaUnMoment"), IDIOMA.getString("cercantComandes"), ""), comandes As List(Of Comanda), idEmpresa As Integer = -1
'        comandes = New List(Of Comanda)
'        If xecTotesEmpresa.Checked Then idEmpresa = empresaActual.id
'        comandes.AddRange(ModelComandaEnEdicio.getObjectsByCodiComanda(Me.txtCercarCodi.Text))
'        comandes.AddRange(ModelComanda.getObjectsByCodiComanda(Me.txtCercarCodi.Text, idEmpresa))
'        RaiseEvent selectObjects(comandes)
'        P.tancar()
'    End Sub

'    Private Sub txtCercarCodi_TextChanged(sender As Object, e As EventArgs) Handles txtCercarCodi.TextChanged
'        If txtCercarCodi.TextLength < 1 Then
'            Me.cmdCercarCodi.Enabled = False
'        Else
'            Me.cmdCercarCodi.Enabled = True
'        End If
'    End Sub

'End Class

