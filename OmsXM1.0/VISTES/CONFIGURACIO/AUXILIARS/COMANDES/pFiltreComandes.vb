Public Class pFiltreComandes
    Private pProjectes As lstBoxFilter
    Private pProveidors As lstBoxFilter
    'Private pArticles As lstBoxFilter
    Private actualitzar As Boolean
    Private empresaActual As Empresa
    Private pDataIni As SelectDia
    Private pDataFi As SelectDia
    Friend Event selectObjects(comandes As List(Of Comanda))
    Public Sub New()
        InitializeComponent()
        empresaActual = ModelEmpresa.getObject(1)
        Call setLanguage()
        Call setEmpreses()
        Call setDates()
        Call setProveidors()
        Call setArticles()
    End Sub
    Private Sub setLanguage()
        Me.lblDataFi.Text = IDIOMA.getString("a")
        Me.lblDataIni.Text = IDIOMA.getString("de")
        Me.lblEmpresa.Text = IDIOMA.getString("empreses")
        Me.cmdFiltrar.Text = IDIOMA.getString("cercar")
        Me.xecTotesEmpresa.Text = IDIOMA.getString("totesLesEmpreses")
    End Sub
    Private Sub setEmpreses()
        actualitzar = False
        cbEmpresa.Items.Clear()
        cbEmpresa.Items.AddRange(ModelEmpresa.getListObjects)
        actualitzar = True
        If empresaActual IsNot Nothing Then Me.cbEmpresa.SelectedItem = empresaActual

    End Sub
    Private Sub setProjectes()
        pProjectes = New lstBoxFilter(IDIOMA.getString("projectes"), ModelProjecte.getListObjects(empresaActual.id))
        panelProjecte.Controls.Clear()
        pProjectes.Dock = DockStyle.Fill
        panelProjecte.Controls.Add(pProjectes)
    End Sub
    Private Sub setArticles()
        'pArticles = New lstBoxFilter(IDIOMA.getString("articles"), ModelArticle.getListObjects())
        'panelArticle.Controls.Clear()
        'pArticles.Dock = DockStyle.Fill
        'panelArticle.Controls.Add(pArticles)
    End Sub
    Private Sub setProveidors()
        pProveidors = New lstBoxFilter(IDIOMA.getString("proveidors"), ModelProveidor.getlistObjects)
        panelProveidor.Controls.Clear()
        pProveidors.Dock = DockStyle.Fill
        panelProveidor.Controls.Add(pProveidors)
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
                Call setProjectes()
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
        Dim P As New frmAvis(IDIOMA.getString("esperaUnMoment"), IDIOMA.getString("cercantComandes"), ""), comandes As List(Of Comanda), a As Comanda
        comandes = New List(Of Comanda)
        '   For Each a In ModelComandaEnEdicio.getObjects(CDate(pDataIni.txtData.Text), CDate(pDataFi.txtData.Text), empresaActual.id, getProveidors, getProjectes, 0)
        If xecTotesEmpresa.Checked Then
            comandes.AddRange(ModelComandaEnEdicio.getObjects(CDate(pDataIni.txtData.Text), CDate(pDataFi.txtData.Text), -1, getProveidors, getProjectes, 0))
            comandes.AddRange(ModelComandaEnEdicio.getObjects(CDate(pDataIni.txtData.Text), CDate(pDataFi.txtData.Text), -1, getProveidors, getProjectes, 1))
            comandes.AddRange(ModelComanda.getObjects(CDate(pDataIni.txtData.Text), CDate(pDataFi.txtData.Text), -1, getProveidors, getProjectes))
        Else
            comandes.AddRange(ModelComandaEnEdicio.getObjects(CDate(pDataIni.txtData.Text), CDate(pDataFi.txtData.Text), empresaActual.id, getProveidors, getProjectes, 0))
            comandes.AddRange(ModelComandaEnEdicio.getObjects(CDate(pDataIni.txtData.Text), CDate(pDataFi.txtData.Text), empresaActual.id, getProveidors, getProjectes, 1))
            comandes.AddRange(ModelComanda.getObjects(CDate(pDataIni.txtData.Text), CDate(pDataFi.txtData.Text), empresaActual.id, getProveidors, getProjectes))
        End If

        ' Next

        RaiseEvent selectObjects(comandes)
        P.tancar()
    End Sub
    Private Function getProveidors() As List(Of Proveidor)
        Dim p As Proveidor
        getProveidors = New List(Of Proveidor)
        For Each p In pProveidors.lstData.SelectedItems()
            getProveidors.Add(p)
        Next
        p = Nothing
    End Function
    Private Function getProjectes() As List(Of Projecte)
        Dim p As Projecte
        getProjectes = New List(Of Projecte)
        For Each p In pProjectes.lstData.SelectedItems()
            getProjectes.Add(p)
        Next
        p = Nothing
    End Function

    Private Sub xecTotesEmpresa_CheckedChanged(sender As Object, e As EventArgs) Handles xecTotesEmpresa.CheckedChanged

    End Sub
End Class
