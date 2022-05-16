Public Class pPlantillaTransitoria
    Private subcompteActual As Subcompte
    Private ySheetActual As YSheet
    Private updated As Boolean
    Public Sub New()
        InitializeComponent()
    End Sub
    Private Sub setLanguage()
        Me.lblEmpresa.Text = IDIOMA.getString("empresa") & ":"
        Me.lblAny.Text = IDIOMA.getString("anyo") & ":"
        Me.cmdGuardar.Text = IDIOMA.getString("cmdCrear")
        Me.cmdCancelar.Text = IDIOMA.getString("cmdCancelar")
        Me.lblErrAny.Text = IDIOMA.getString("campOblogatori")
        Me.lblErrorEmpresa.Text = IDIOMA.getString("campObligatori")
    End Sub
    Private Sub validateControls()
        Me.lblErrAny.Visible = False
        Me.lblErrorEmpresa.Visible = False
        Me.cmdGuardar.Enabled = True
        If Not IsNumeric(txtAny.Text) Then
            Me.lblErrAny.Visible = True
            Me.cmdGuardar.Enabled = False
        End If
        If cbEmpresa.SelectedIndex = -1 Then
            Me.lblErrorEmpresa.Visible = True
            Me.cmdGuardar.Enabled = False
        End If

    End Sub
    Private Sub setEmpreses()
        updated = False
        cbEmpresa.Items.Clear()
        cbEmpresa.Items.AddRange(ModelEmpresa.getListObjects)
        updated = True
    End Sub
    Private Sub getEmpresa()
        Dim e As Empresa
        e = modelPlantillaTransitoria.getEmpresa()
        If e IsNot Nothing Then
            For i = 0 To cbEmpresa.Items.Count - 1
                If cbEmpresa.Items(i).id = e.id Then
                    cbEmpresa.SelectedIndex = i
                    Exit For
                End If
            Next
        End If
        e = Nothing
    End Sub
    Private Sub getAny()
        txtAny.Text = modelPlantillaTransitoria.getAny
    End Sub
    Private Sub setSubcomptes()
        Dim p As SelectSubcomptesTransitoria
        p = New SelectSubcomptesTransitoria(0, True, 0, 0, IDIOMA.getString("subcomptes"), 1)
        AddHandler p.selectObject, AddressOf setSubcompte
        pSubcomptes.Controls.Clear()
        p.Dock = DockStyle.Fill
        pSubcomptes.Controls.Add(p)
        p.Show()
    End Sub
    Private Sub setYellowSheets()
        Dim p As SelectYSheetsTransitoria
        p = New SelectYSheetsTransitoria(0, True, 0, 0, IDIOMA.getString("ySheets"), 1)
        AddHandler p.selectObject, AddressOf setYSheet
        pYsheets.Controls.Clear()
        p.Dock = DockStyle.Fill
        pYsheets.Controls.Add(p)
        p.Show()
    End Sub
    Private Sub setSubcompte(s As Subcompte)
        subcompteActual = s
    End Sub
    Private Sub setYSheet(y As YSheet)
        ySheetActual = y
    End Sub
    Private Sub pPlantillaTransitoria_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call setLanguage()
        Call setEmpreses()
        Call setSubcomptes()
        Call setYellowSheets()
        Call getAny()
        Call getEmpresa()
        Call validateControls()
    End Sub

    Private Sub cmdGuardar_Click(sender As Object, e As EventArgs) Handles cmdGuardar.Click
        Call modelPlantillaTransitoria.crearPlantilla()
    End Sub

    Private Sub cmdCancelar_Click(sender As Object, e As EventArgs) Handles cmdCancelar.Click
        Me.Dispose()
    End Sub

    Private Sub pPlantillaTransitoria_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        Call modelPlantillaTransitoria.save()
    End Sub

    Private Sub cbEmpresa_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbEmpresa.SelectedIndexChanged
        If updated Then
            If cbEmpresa.SelectedIndex > -1 Then
                Call modelPlantillaTransitoria.setEmpresa(cbEmpresa.SelectedItem)
            End If
            Call validateControls()
        End If
    End Sub

    Private Sub txtAny_TextChanged(sender As Object, e As EventArgs) Handles txtAny.TextChanged
        If updated Then
            If IsNumeric(txtAny.Text) Then Call modelPlantillaTransitoria.setAny(txtAny.Text)
            Call validateControls()
        End If

    End Sub



End Class
