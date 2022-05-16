Imports System.ComponentModel

Public Class frmServer
    Private fBrowser As Directori
    Private rutaActual As String

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        Me.Dispose()
    End Sub
    Private Sub validateControls(c As TextBox, valid As Boolean)
        If valid Then
            c.BackColor = Color.White
            Me.cmdSave.Enabled = True
        Else
            c.BackColor = Color.LemonChiffon
            Me.cmdSave.Enabled = False
        End If
    End Sub
    Private Sub setLanguage()
        Me.Text = IDIOMA.getString("frmserverdata_caption")
        Me.lblData.Text = IDIOMA.getString("frmserverdata_lbldata")
        Me.cmdSave.Text = IDIOMA.getString("cmdGuardar")
        Me.cmdCancel.Text = IDIOMA.getString("cmdCancelar")
        Me.lblUsuari.Text = IDIOMA.getString("frmserverdata_lblusuari")
        Me.lblClau.Text = IDIOMA.getString("frmserverdata_lblclau")
        Me.lblTaulaPedidos.Text = IDIOMA.getString("taulaPedidos")
        Me.gbSql.Text = IDIOMA.getString("serverSql")
    End Sub
    Private Sub saveData()
        Try
            Call CONFIG_FILE.setTag(CONFIG_FILE.TAG.SERVER_DATA, Me.txtServer.Text)
            Call CONFIG_FILE.setTag(CONFIG_FILE.TAG.SERVER_USUARI, Me.txtUsuari.Text)
            Call CONFIG_FILE.setTag(CONFIG_FILE.TAG.SERVER_PASSWORD, Me.txtClau.Text)
            Call CONFIG_FILE.setTag(CONFIG_FILE.TAG.TAULA_COMANDES_MYDOC, Me.txtTaulaPedidos.Text)
        Catch ex As ExcepcioConfig
            Call MISSATGES.ERR_SAVE_FILE_CONFIG(ex.ToString)
        End Try

    End Sub
    Private Sub getData()
        Try
            Me.txtClau.Text = CONFIG_FILE.getTag(CONFIG_FILE.TAG.SERVER_PASSWORD)
            Me.txtServer.Text = CONFIG_FILE.getTag(CONFIG_FILE.TAG.SERVER_DATA)
            Me.txtUsuari.Text = CONFIG_FILE.getTag(CONFIG_FILE.TAG.SERVER_USUARI)
            Me.txtTaulaPedidos.Text = CONFIG_FILE.getTaulaComandesMydoc
            fBrowser = New Directori(rutaActual, IDIOMA.getString("rutaAdjuntsMydoc"))
            fBrowser.Dock = DockStyle.Fill
            PanelRuta.Controls.Clear()
            PanelRuta.Controls.Add(fBrowser)
            fBrowser.Show()
        Catch ex As ExcepcioConfig
            Me.txtClau.Text = ""
            Me.txtServer.Text = ""
            Me.txtUsuari.Text = ""
            Call MISSATGES.ERR_SAVE_FILE_CONFIG(ex.ToString)
        End Try
    End Sub
    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click
        Dim fAvis As New frmAvis(IDIOMA.getString("frmserverdata_frmavis_caption"))
        fAvis.setData(IDIOMA.getString("frmserverdata_frmavis_titol"), IDIOMA.getString("frmserverdata_frmavis_missatge"))
        If DBCONNECT.existServer(txtServer.Text, txtUsuari.Text, txtClau.Text) Then
            Call saveData()
            Me.Dispose()
        Else
            Call MISSATGES.ERR_SERVER_DATA()
            Call saveData()
            Me.Dispose()
        End If
        fAvis.tancar()
        fAvis = Nothing
    End Sub

    Private Sub frmServerData_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call setLanguage()
        rutaActual = CONFIG_FILE.getRutafitxersMydoc

        Call getData()
    End Sub

    Private Sub txtClau_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtclau.KeyPress
        e.KeyChar = VALIDAR.signeAlfaNumeric(e.KeyChar)
    End Sub
End Class