Imports System.ComponentModel

Public Class frmServer
    Private Const SQL As String = "1"
    Private Const DBF As String = "2"
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
        Me.lblEscollir.Text = IDIOMA.getString("lblEscollirServidor")
        Me.optDBF.Text = IDIOMA.getString("optDbf")
        Me.optSql.Text = IDIOMA.getString("optSqlServer")
        Me.gbSql.Text = IDIOMA.getString("serverSql")
    End Sub
    Private Sub saveData()
        Try
            Call CONFIG_FILE.setTag(CONFIG_FILE.TAG.RUTA_SERVIDOR_DADES, fBrowser.lblDirectori.Text)
            If optSql.Checked Then
                Call CONFIG_FILE.setTag(CONFIG_FILE.TAG.SERVER_DATA, Me.txtServer.Text)
                Call CONFIG_FILE.setTag(CONFIG_FILE.TAG.SERVER_USUARI, Me.txtUsuari.Text)
                Call CONFIG_FILE.setTag(CONFIG_FILE.TAG.SERVER_PASSWORD, Me.txtClau.Text)
                Call CONFIG_FILE.setTag(CONFIG_FILE.TAG.TIPUS_SERVER, SQL)
            Else
                Call CONFIG_FILE.setTag(CONFIG_FILE.TAG.TIPUS_SERVER, DBF)
            End If
        Catch ex As ExcepcioConfig
            Call MISSATGES.ERR_SAVE_FILE_CONFIG(ex.ToString)
        End Try

    End Sub
    Private Sub getData()
        Try
            Me.txtClau.Text = CONFIG_FILE.getTag(CONFIG_FILE.TAG.SERVER_PASSWORD)

            Me.txtServer.Text = CONFIG_FILE.getTag(CONFIG_FILE.TAG.SERVER_DATA)
            Me.txtUsuari.Text = CONFIG_FILE.getTag(CONFIG_FILE.TAG.SERVER_USUARI)
            If CONFIG_FILE.getTag(CONFIG_FILE.TAG.TIPUS_SERVER) = DBF Then
                Me.optDBF.Checked = True
            Else
                Me.optSql.Checked = True
            End If
            fBrowser = New Directori(CONFIG_FILE.getTag(CONFIG_FILE.TAG.RUTA_SERVIDOR_DADES), Me.Text)
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
        '1 ENS CAL COMPROVAR SI EXISTEIX EL
        '2 ENS CAL POSAR FINESTRA D'ESPERA. AMB TEXTE PERSONALITZAT
        Dim fAvis As New frmAvis(IDIOMA.getString("frmserverdata_frmavis_caption"))
        If Me.optSql.Checked Then
            fAvis.setData(IDIOMA.getString("frmserverdata_frmavis_titol"), IDIOMA.getString("frmserverdata_frmavis_missatge"), "")
            If DBCONNECT.existServer(txtServer.Text, txtUsuari.Text, txtClau.Text) Then
                Call saveData()
                Me.Dispose()
            Else
                Call MISSATGES.ERR_SERVER_DATA()
            End If
        Else
            Call saveData()
            Me.Dispose()
        End If
        fAvis.tancar()
        fAvis = Nothing
    End Sub

    Private Sub frmServerData_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call setLanguage()
        Call getData()
    End Sub

    Private Sub txtClau_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtclau.KeyPress
        e.KeyChar = VALIDAR.signeAlfaNumeric(e.KeyChar)
    End Sub

End Class