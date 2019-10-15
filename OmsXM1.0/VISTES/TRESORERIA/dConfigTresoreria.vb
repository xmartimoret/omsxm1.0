Imports System.Windows.Forms

Public Class dConfigTresoreria
    Private Sub setLanguage()
        Me.Text = IDIOMA.getString("configModulTresoreria")
        Me.lblCobros.Text = IDIOMA.getString("lblCobros") & ": "
        Me.lblColumna.Text = IDIOMA.getString("lblColumnaTresoreria") & ": "
        Me.lblFullDades.Text = IDIOMA.getString("lblFullaDades") & ": "
        Me.lblNom.Text = IDIOMA.getString("lblNomConfigTresoreria") & ": "
        Me.lblPagaments.Text = IDIOMA.getString("lblPagaments") & ": "
        Me.xecNom.Text = IDIOMA.getString("xecProjecteIncrustat") & ": "
        Me.cmdGuardar.Text = IDIOMA.getString("cmdGuardar") & ": "
        Me.cmdCancelar.Text = IDIOMA.getString("cmdCancelar") & ": "
        Me.gbImportacio.Text = IDIOMA.getString("lblFitxerImportacioObres")
        Me.gbResum.Text = IDIOMA.getString("lblFitxerCash")
    End Sub
    Private Sub setData()
        Me.txtCobros.Text = CONFIG_PARAM_SERVER.getParametreCobroTresoreria
        Me.txtColumna.Text = CONFIG_PARAM_SERVER.getParametreColumnaTresoreria
        Me.txtFullaDades.Text = CONFIG_PARAM_SERVER.getParametreFullaCash
        Me.txtNom.Text = CONFIG_PARAM_SERVER.getParametreNomTresoreria
        Me.txtPagaments.Text = CONFIG_PARAM_SERVER.getParametrePagamentTresoreria
        Me.xecNom.Checked = CONFIG_PARAM_SERVER.getXecNomProjecteTresoreria
    End Sub
    Private Sub saveData()
        Call CONFIG_PARAM_SERVER.setParametreCobroTresoreria(Me.txtCobros.Text)
        Call CONFIG_PARAM_SERVER.setParametreColumnaTresoreria(Me.txtColumna.Text)
        Call CONFIG_PARAM_SERVER.setParametreFullaCash(Me.txtFullaDades.Text)
        Call CONFIG_PARAM_SERVER.setParametreNomTresoreria(Me.txtNom.Text)
        Call CONFIG_PARAM_SERVER.setParametrePagamentTresoreria(Me.txtPagaments.Text)
        Call CONFIG_PARAM_SERVER.setXecNomProjecteTresoreria(Me.xecNom.Checked)
    End Sub
    Private Sub validateControls()
        If Me.xecNom.Checked Then
            Me.lblNom.Visible = False
            Me.txtNom.Visible = False
            Me.txtNom.Text = ""
        Else
            Me.lblNom.Visible = True
            Me.txtNom.Visible = True
        End If
    End Sub

    Private Sub dConfigTresoreria_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call setData()
        Call validateControls()
    End Sub

    Private Sub cmdGuardar_Click(sender As Object, e As EventArgs) Handles cmdGuardar.Click
        Call savedata
        Me.Dispose()
    End Sub
End Class
