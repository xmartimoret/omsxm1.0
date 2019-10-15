Option Explicit On
Public Class pPlantillaTransitoriaProjecte
    Private actualitzar As Boolean
    Private projectesActuals As List(Of Projecte)
    Private empresaActual As Empresa
    Private directoriActual As String

    Private Sub setEmpreses()
        cbEmpresa.Items.Clear()
        cbEmpresa.Items.AddRange(ModelEmpresa.getListObjects)
    End Sub
    Private Sub setAny()
        actualitzar = False
        Me.txtAny.Text = Year(Now)
        actualitzar = True
    End Sub
    Private Sub setProjectes()
        Dim projectes As List(Of Projecte)
        projectes = DProjectes.selectProjectes(4, empresaActual.id)
        If projectes IsNot Nothing Then
            Me.lstProjectes.Items.AddRange(CONFIG.getListObjects(projectes))
        End If

        projectes = Nothing
    End Sub
    Private Sub setDirectori()
        Dim ruta As String, tempDirectori As Directori
        ruta = CONFIG_FILE.getTag(CONFIG_FILE.TAG.DIRECTORI_FITXERS_TRANSITORIES)
        If CONFIG.folderExist(ruta) Then
            tempDirectori = New Directori(ruta, IDIOMA.getString(""))
        Else
            tempDirectori = New Directori(CONFIG.getDirectoriFitxersTransitories, IDIOMA.getString(""))
            directoriActual = CONFIG.getDirectoriFitxersTransitories
        End If
        AddHandler tempDirectori.selectObject, AddressOf getDirectori
        panelDir.Controls.Clear()
        tempDirectori.Dock = DockStyle.Fill
        panelDir.Controls.Add(tempDirectori)
        tempDirectori.Show()
    End Sub
    Private Sub getDirectori(p As String)
        directoriActual = p
    End Sub
    Private Sub setlanguage()
        Me.lblErrAny.Text = IDIOMA.getString("campObligatori")
        Me.lblErrorDir.Text = IDIOMA.getString("campObligatori")
        Me.lblErrorEmpresa.Text = IDIOMA.getString("campObligatori")
        Me.lblErrorProjectes.Text = IDIOMA.getString("campObligatori")
        Me.lblAny.Text = IDIOMA.getString("anyo") & ":"
        Me.lblEmpresa.Text = IDIOMA.getString("empresa") & ":"
        Me.lblProjectes.Text = IDIOMA.getString("projectes") & ":"
        Me.cmdAfegir.Text = IDIOMA.getString("cmdAfegir")
        Me.cmdCancelar.Text = IDIOMA.getString("cmdCancelar")
        Me.cmdGuardar.Text = IDIOMA.getString("cmdCrear")
        Me.cmdTreure.Text = IDIOMA.getString("cmdTreure")
    End Sub
    Private Sub validateControls()
        Me.cmdGuardar.Enabled = True
        Me.lblErrAny.Visible = False
        Me.lblErrorEmpresa.Visible = False
        Me.lblErrorProjectes.visible = False
        Me.lblErrorDir.Visible = False
        Me.cmdAfegir.Enabled = True
        Me.cmdTreure.Enabled = True
        If Me.cbEmpresa.SelectedIndex = -1 Then
            Me.cmdAfegir.Enabled = False
            Me.cmdGuardar.Enabled = False
            Me.lblErrorEmpresa.Visible = True
        End If
        If txtAny.Text < 2000 Then
            Me.lblErrAny.Visible = True
            cmdGuardar.Enabled = False
        End If
        If lstProjectes.Items.Count = 0 Then
            Me.lblErrorProjectes.Visible = True
            Me.cmdGuardar.Enabled = False
        End If
        If Not CONFIG.folderExist(directoriActual) Then
            Me.lblErrorDir.Visible = True
            cmdGuardar.Enabled = False
        End If
        If Not lstProjectes.SelectedItems.Count = 0 Then
            cmdTreure.Enabled = False
        End If
    End Sub
    Private Sub cmdCrear_Click()
        Call ModulFitxersTransitoria.executePlantilla(getProjectes, empresaActual.codi, directoriActual, txtAny.Text)
        Me.Dispose()
    End Sub

    Private Sub lstProjectes_Click()
        If actualitzar Then Call validateControls()
    End Sub

    Private Sub txtAny_Change()
        If actualitzar Then
            Call validateControls()
        End If
    End Sub

    Private Function getProjectes() As List(Of Projecte)
        Dim p As Projecte
        getProjectes = New List(Of Projecte)
        For Each p In lstProjectes.Items
            getProjectes.Add(p)
        Next
        p = Nothing
    End Function

    Private Sub pPlantillaTransitoriaProjecte_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call setEmpreses()
        Call setAny()
        Call setDirectori()
        Call setlanguage()
        Call validateControls()
    End Sub

    Private Sub cbEmpresa_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbEmpresa.SelectedIndexChanged
        If actualitzar Then
            If cbEmpresa.SelectedIndex > -1 Then
                empresaActual = cbEmpresa.SelectedItem
                projectesActuals = ModelProjecte.getObjects(empresaActual.id)
            Else
                empresaActual = New Empresa
            End If
            Call validateControls()
        End If
    End Sub

    Private Sub cmdCancelar_Click(sender As Object, e As EventArgs) Handles cmdCancelar.Click
        Me.Dispose()
    End Sub

    Private Sub cmdAfegir_Click(sender As Object, e As EventArgs) Handles cmdAfegir.Click
        Call setProjectes()
        Call validateControls()
    End Sub

    Private Sub cmdTreure_Click(sender As Object, e As EventArgs) Handles cmdTreure.Click
        Dim i As Integer
        For i = 0 To lstProjectes.SelectedItems.Count - 1
            lstProjectes.Items.Remove(lstProjectes.SelectedItems(i))
        Next i
        Call validateControls()
    End Sub
    Private Sub txtAny_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAny.KeyPress
        e.KeyChar = VALIDAR.Enter(e.KeyChar, txtAny.Text.Length, 4)
    End Sub

    Private Sub pPlantillaTransitoriaProjecte_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        projectesActuals = Nothing
    End Sub
    Private Sub cmdGuardar_Click(sender As Object, e As EventArgs) Handles cmdGuardar.Click
        Call ModulFitxersTransitoria.executePlantilla(getProjectes, empresaActual.codi, directoriActual, txtAny.Text)
    End Sub
End Class
