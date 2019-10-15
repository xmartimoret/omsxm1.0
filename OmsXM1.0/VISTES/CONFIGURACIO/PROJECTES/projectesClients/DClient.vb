Imports System.Windows.Forms

Public Class DClient
    Private clientActual As Client
    Private actualitzar As Boolean
    Public Function getClient(pClient As Client) As Client
        clientActual = pClient
        If pClient.id = -1 Then
            Me.Text = IDIOMA.getString("afegirNouClient")
        Else
            Me.Text = IDIOMA.getString("modificarClient") & " " & pClient.ToString
        End If
        Me.ShowDialog()
        If Me.DialogResult = System.Windows.Forms.DialogResult.OK Then
            getClient = getData()
            Me.Close()
        Else
            getClient = Nothing
            Me.Close()
        End If
    End Function
    Private Sub setData()
        actualitzar = False
        Me.lblId.Text = clientActual.id
        Me.txtNom.Text = clientActual.nom
        Me.txtNotes.Text = clientActual.notes
        Me.xecActiu.Checked = clientActual.actiu
        If clientActual.color = 23 Then
            Me.opt23.Checked = True
        ElseIf clientActual.color = 4 Then
            Me.opt4.Checked = True
        ElseIf clientActual.color = 40 Then
            Me.opt40.Checked = True
        ElseIf clientActual.color = 46 Then
            Me.opt46.Checked = True
        ElseIf clientActual.color = 6 Then
            Me.opt6.Checked = True
        ElseIf clientActual.color = 7 Then
            Me.opt7.Checked = True
        ElseIf clientActual.color = 8 Then
            Me.opt8.Checked = True
        Else
            Me.opt.Checked = True
        End If
        actualitzar = True
    End Sub
    Private Function getData() As Client
        getData = New Client
        clientActual.id = Me.lblId.Text
        clientActual.nom = Me.txtNom.Text
        clientActual.notes = Me.txtNotes.Text
        clientActual.actiu = Me.xecActiu.Checked
        If Me.opt23.Checked Then
            clientActual.color = 23
        ElseIf Me.opt4.Checked Then
            clientActual.color = 4
        ElseIf Me.opt40.Checked Then
            clientActual.color = 40
        ElseIf Me.opt46.Checked Then
            clientActual.color = 46
        ElseIf Me.opt6.Checked Then
            clientActual.color = 6
        ElseIf Me.opt7.Checked Then
            clientActual.color = 7
        ElseIf Me.opt8.Checked Then
            clientActual.color = 8
        Else
            clientActual.color = -1
        End If
        Return clientActual
    End Function
    Private Sub validateControls()
        cmdGuardar.Enabled = True
        lblErrNom.Visible = False
        If txtNom.Text = "" Then
            cmdGuardar.Enabled = False
            lblErrNom.Visible = True
        End If
    End Sub
    Private Sub setLanguage()
        Me.lblIdCaption.Text = IDIOMA.getString("id")
        Me.lblNom.Text = IDIOMA.getString("nom")
        Me.lblNotes.Text = IDIOMA.getString("notes")
        Me.xecActiu.Text = IDIOMA.getString("actiu")
        Me.lblColor.Text = IDIOMA.getString("color")
        Me.cmdGuardar.Text = IDIOMA.getString("cmdGuardar")
        Me.cmdCancelar.Text = IDIOMA.getString("cmdCancelar")
        Me.lblErrNom.Text = IDIOMA.getString("campOblitori")
    End Sub
    Private Sub DClient_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call setLanguage()
        Call setData()
        Call validateControls()
    End Sub

    Private Sub cmdGuardar_Click(sender As Object, e As EventArgs) Handles cmdGuardar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Hide()
    End Sub

    Private Sub cmdCancelar_Click(sender As Object, e As EventArgs) Handles cmdCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.No
        Me.Hide()
    End Sub

    Private Sub txtNom_TextChanged(sender As Object, e As EventArgs) Handles txtNom.TextChanged
        If actualitzar Then
            Call validateControls()
        End If
    End Sub
    Private Sub txtNom_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNom.KeyPress
        e.KeyChar = VALIDAR.AlfaNumeric(e.KeyChar, txtNom.Text.Length, 15)
    End Sub
End Class
