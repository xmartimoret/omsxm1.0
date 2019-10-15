Imports System.Windows.Forms

Public Class DParametresBudget
    Private tempFullaParametresVoss As String
    Private tempNomFullaInformeVoss As String
    Private tempIniAnyActualVoss As String
    Private tempIniAnySeguentVoss As String
    Private tempIniCodiVoss As String
    Private tempIniInfoAnyActualVoss As String
    Private tempIniInfoAnySeguentVoss As String
    Private tempNomFullaDadesVoss As String
    Private tempNomFullaExplotacions As String
    Private tempNomFullaHeadquarters As String
    Private tempNomFullaObres As String
    Private tempRangAnyFitxerVoss As String
    Private tempRangNomProjecteVoss As String
    Private Sub setData()
        Me.txtDadesAnyActual.Text = CONFIG_PARAM_SERVER.getRangDadesAnyActual
        Me.txtDadesAnySeguent.Text = CONFIG_PARAM_SERVER.getRangDadesAnySeguent
        Me.txtfullaParametres.Text = CONFIG_PARAM_SERVER.getFullaParametresVoss
        Me.txtInfoAnyActual.Text = CONFIG_PARAM_SERVER.getRangInfoAnyActual
        Me.txtInfoAnySeguent.Text = CONFIG_PARAM_SERVER.getRangInfoAnySeguent
        Me.txtNomFullaDadesBudgetExplotacions.Text = CONFIG_PARAM_SERVER.getFullaBudgetExplotacions
        Me.txtNomFullaDadesBudgetHead.Text = CONFIG_PARAM_SERVER.getFullaBudgetHeadquarters
        Me.txtNomFullaDadesBudgetObres.Text = CONFIG_PARAM_SERVER.getFullaBudgetObres
        Me.txtNomFullaDadesCopiar.Text = CONFIG_PARAM_SERVER.getFullaDadesVoss
        Me.txtNomInformePresentar.Text = CONFIG_PARAM_SERVER.getFullaInformeVoss
        Me.txtRangAnyFitxerVoss.Text = CONFIG_PARAM_SERVER.getRangAnyVoss
        Me.txtRangCodiGrup.Text = CONFIG_PARAM_SERVER.getRangCodiSubgrupVoss
        Me.txtRangProjecteVoss.Text = CONFIG_PARAM_SERVER.getRangNomProjecteVOSS
        tempFullaParametresVoss = Me.txtfullaParametres.Text
        tempNomFullaInformeVoss = Me.txtNomInformePresentar.Text
        tempIniAnyActualVoss = Me.txtDadesAnyActual.Text
        tempIniAnySeguentVoss = Me.txtDadesAnySeguent.Text
        tempIniCodiVoss = Me.txtRangCodiGrup.Text
        tempIniInfoAnyActualVoss = Me.txtInfoAnyActual.Text
        tempIniInfoAnySeguentVoss = Me.txtInfoAnySeguent.Text
        tempNomFullaDadesVoss = Me.txtNomFullaDadesCopiar.Text
        tempNomFullaExplotacions = Me.txtNomFullaDadesBudgetExplotacions.Text
        tempNomFullaHeadquarters = Me.txtNomFullaDadesBudgetHead.Text
        tempNomFullaObres = Me.txtNomFullaDadesBudgetObres.Text
        tempRangAnyFitxerVoss = Me.txtRangAnyFitxerVoss.Text
        tempRangNomProjecteVoss = Me.txtRangProjecteVoss.Text
    End Sub
    Private Sub saveData()
        If tempFullaParametresVoss <> Me.txtfullaParametres.Text Then Call CONFIG_PARAM_SERVER.setFullaParametresVoss(Me.txtfullaParametres.Text)
        If tempNomFullaInformeVoss <> Me.txtNomInformePresentar.Text Then Call CONFIG_PARAM_SERVER.setFullaInformeVoss(Me.txtNomInformePresentar.Text)
        If tempIniAnyActualVoss <> Me.txtDadesAnyActual.Text Then Call CONFIG_PARAM_SERVER.setRangDadesAnyActual(Me.txtDadesAnyActual.Text)
        If tempIniAnySeguentVoss <> Me.txtDadesAnySeguent.Text Then Call CONFIG_PARAM_SERVER.setRangDadesAnySeguent(Me.txtDadesAnySeguent.Text)
        If tempIniCodiVoss <> Me.txtRangCodiGrup.Text Then Call CONFIG_PARAM_SERVER.setRangCodiSubgrupVoss(Me.txtRangCodiGrup.Text)
        If tempIniInfoAnyActualVoss <> Me.txtInfoAnyActual.Text Then Call CONFIG_PARAM_SERVER.setRangInfoAnyActual(Me.txtInfoAnyActual.Text)
        If tempIniInfoAnyActualVoss <> Me.txtInfoAnySeguent.Text Then Call CONFIG_PARAM_SERVER.setRangInfoAnySeguent(Me.txtInfoAnySeguent.Text)
        If tempNomFullaDadesVoss <> Me.txtNomFullaDadesCopiar.Text Then Call CONFIG_PARAM_SERVER.setFullaDadesVoss(Me.txtNomFullaDadesCopiar.Text)
        If tempNomFullaExplotacions <> Me.txtNomFullaDadesBudgetExplotacions.Text Then Call CONFIG_PARAM_SERVER.setFullaBudgetExplotacions(Me.txtNomFullaDadesBudgetExplotacions.Text)
        If tempNomFullaHeadquarters <> Me.txtNomFullaDadesBudgetHead.Text Then Call CONFIG_PARAM_SERVER.setFullaBudgetHeadquarters(Me.txtNomFullaDadesBudgetHead.Text)
        If tempNomFullaObres <> Me.txtNomFullaDadesBudgetObres.Text Then Call CONFIG_PARAM_SERVER.setFullaBudgetObres(Me.txtNomFullaDadesBudgetObres.Text)
        If tempRangAnyFitxerVoss <> Me.txtRangAnyFitxerVoss.Text Then Call CONFIG_PARAM_SERVER.setRangAnyVoss(Me.txtRangAnyFitxerVoss.Text)
        If tempRangNomProjecteVoss <> Me.txtRangProjecteVoss.Text Then Call CONFIG_PARAM_SERVER.setRangNomProjecteVOSS(Me.txtRangProjecteVoss.Text)
    End Sub

    Private Sub setLanguage()
        Me.lblDadesAnyActual.Text = IDIOMA.getString("lblDadesAnyActual")
        Me.lblDadesAnySeguent.Text = IDIOMA.getString("lblDadesAnySeguent")
        Me.lblFullaParametres.Text = IDIOMA.getString("lblFullaParametres")
        Me.lblInfoAnyActual.Text = IDIOMA.getString("lblInfoAnyActual")
        Me.lblInfoAnySeguent.Text = IDIOMA.getString("lblInfoAnySeguent")
        Me.lblInfoDadesAnyActual.Text = IDIOMA.getString("lblInfoDadesAnyActual")
        Me.lblInfoDadesAnySeguent.Text = IDIOMA.getString("lblInfoDadesAnySeguent")
        Me.lblInfoInfoAnyActual.Text = IDIOMA.getString("lblInfoInfoAnyActual")
        Me.lblInfoInfoAnySeguent.Text = IDIOMA.getString("lblInfoInfoAnySeguent")
        Me.lblInfoRangAnyFitxerVoss.Text = IDIOMA.getString("lblInfoRangAnyFitxerVoss")
        Me.lblInfoRangCodiGrup.Text = IDIOMA.getString("lblInfoRangCodiGrup")
        Me.lblInfoRangProjecteVoss.Text = IDIOMA.getString("lblInfoRangProjecteVoss")
        Me.lblNomFullaDadesBudgetExplotacions.Text = IDIOMA.getString("lblNomfullaDadesBudget")
        Me.lblNomFullaDadesBudgetHead.Text = IDIOMA.getString("lblNomfullaDadesBudget")
        Me.lblNomFullaDadesBudgetObres.Text = IDIOMA.getString("lblNomfullaDadesBudget")
        Me.lblNomFullaDadesCopiar.Text = IDIOMA.getString("lblNomFullaDadesCopiar")
        Me.lblNomInformePresentar.Text = IDIOMA.getString("lblNomInformePresentar")
        Me.lblRangAnyFitxerVoss.Text = IDIOMA.getString("lblRangAnyFitxerVoss")
        Me.lblRangCodiGrup.Text = IDIOMA.getString("lblRangCodiGrup")
        Me.lblRangProjecteVoss.Text = IDIOMA.getString("lblRangProjecteVoss")
        Me.lblTitol1.Text = IDIOMA.getString("lblTitol1")
        Me.lblTitol2.Text = IDIOMA.getString("lblTitol2")
        Me.lblTitol3.Text = IDIOMA.getString("lblTitol3")
        Me.lblTitol4.Text = IDIOMA.getString("lblTitol4")
        Me.cmdCancelar.Text = IDIOMA.getString("cmdCancelar")
        Me.cmdGuardar.Text = IDIOMA.getString("cmdGuardar")
        Me.Text = IDIOMA.getString("dPametresBudget")
    End Sub

    Private Sub DParametresBudget_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call setLanguage()
        Call setData()
    End Sub

    Private Sub cmdGuardar_Click(sender As Object, e As EventArgs) Handles cmdGuardar.Click
        Call saveData()
        Me.Dispose()
    End Sub

    Private Sub cmdCancelar_Click(sender As Object, e As EventArgs) Handles cmdCancelar.Click
        Me.Dispose()
    End Sub

    Private Sub txtNomFullaDadesBudgetExplotacions_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNomFullaDadesBudgetExplotacions.KeyPress
        e.KeyChar = VALIDAR.texte(e.KeyChar, Len(txtNomFullaDadesBudgetExplotacions.Text), 25)
    End Sub
    Private Sub txtNomFullaDadesBudgetHead_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNomFullaDadesBudgetHead.KeyPress
        e.KeyChar = VALIDAR.texte(e.KeyChar, Len(txtNomFullaDadesBudgetHead.Text), 25)
    End Sub
    Private Sub txtNomFullaDadesBudgetObres_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNomFullaDadesBudgetObres.KeyPress
        e.KeyChar = VALIDAR.texte(e.KeyChar, Len(txtNomFullaDadesBudgetObres.Text), 25)
    End Sub
    Private Sub txtfullaParametres_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtfullaParametres.KeyPress
        e.KeyChar = VALIDAR.texte(e.KeyChar, Len(txtfullaParametres.Text), 25)
    End Sub
End Class
