Option Explicit On
Imports System.Windows.Forms

Public Class DSeccio
    Private seccioActual As Seccio
    Private actualitzar As Boolean
    Public Function getSeccio(s As Seccio) As Seccio
        seccioActual = s
        Call setLanguage()
        Call setGrupsComptables()
        Call setData()
        Me.txtCodi.Select()
        Me.ShowDialog()
        If Me.DialogResult = System.Windows.Forms.DialogResult.OK Then
            getSeccio = getData()
        Else
            getSeccio = Nothing
        End If
        Me.Close()
    End Function
    Private Sub setGrupsComptables()
        Me.lstGrups.Items.Clear()
        Me.lstGrups.Items.AddRange(ModelGrup.getListObjects(ModelGrup.getObjects()))
    End Sub
    Private Sub validateControls()
        lblErrCodi.Visible = False
        lblErrNom.Visible = False
        cmdGuardar.Enabled = True
        If txtCodi.Text.Length = 0 Then
            lblErrCodi.Visible = True
            cmdGuardar.Enabled = False
        End If
        If txtNom.Text.Length = 0 Then
            lblErrNom.Visible = True
            cmdGuardar.Enabled = False
        End If
    End Sub
    Private Sub setData()
        Dim sg As SeccioGrup, i As Integer
        actualitzar = False
        Me.lblId.Text = seccioActual.id
        Me.txtCodi.Text = seccioActual.codi
        Me.txtNom.Text = seccioActual.nom
        Me.txtNotes.Text = seccioActual.notes
        Me.xecActiu.Checked = seccioActual.actiu
        For Each sg In seccioActual.grupsComptables
            For i = 0 To lstGrups.Items.Count - 1
                If lstGrups.Items(i).id = sg.idGrup Then
                    lstGrups.SetSelected(i, True)
                    Exit For
                End If
            Next i
        Next sg
        actualitzar = True
        sg = Nothing
    End Sub
    Private Sub setLanguage()
        If seccioActual.id = -1 Then
            Me.Text = IDIOMA.getString("dSeccioNovaCaption")
        Else
            Me.Text = IDIOMA.getString("dSeccioCaption")
        End If
        Me.lblCaptionId.Text = IDIOMA.getString("id")
        Me.lblCodi.Text = IDIOMA.getString("codi")
        Me.lblNom.Text = IDIOMA.getString("nom")
        Me.lblNotes.Text = IDIOMA.getString("notes")
        Me.lblGrups.Text = IDIOMA.getString("grupsComptables")
        Me.xecActiu.Text = IDIOMA.getString("activa")
        Me.cmdGuardar.Text = IDIOMA.getString("cmdGuardar")
        Me.cmdCancelar.Text = IDIOMA.getString("cmdCancelar")
        Me.lblErrCodi.Text = IDIOMA.getString("campObligatori")
        Me.lblErrNom.Text = IDIOMA.getString("campObligatori")
    End Sub
    Private Function getData() As Seccio
        Dim i As Integer
        getData = seccioActual.copy
        getData.codi = Me.txtCodi.Text
        getData.nom = Me.txtNom.Text
        getData.notes = Me.txtNotes.Text
        getData.actiu = Me.xecActiu.Checked
        getData.grupsComptables = New List(Of SeccioGrup)
        For i = 0 To lstGrups.SelectedItems.Count - 1
            getData.grupsComptables.Add(New SeccioGrup(seccioActual.id, lstGrups.SelectedItems(i).id))
        Next i
    End Function
    Private Sub cmdGuardar_Click(sender As Object, e As EventArgs) Handles cmdGuardar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Hide()
    End Sub

    Private Sub cmdCancelar_Click(sender As Object, e As EventArgs) Handles cmdCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Hide()
    End Sub

    Private Sub DSeccio_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call validateControls()
    End Sub

    Private Sub txtCodi_TextChanged(sender As Object, e As EventArgs) Handles txtCodi.TextChanged
        If actualitzar Then Call validateControls()
    End Sub

    Private Sub txtCodi_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCodi.KeyPress
        e.KeyChar = VALIDAR.signeAlfaNumeric(e.KeyChar, txtCodi.Text.Length, 8)
    End Sub

    Private Sub txtNom_TextChanged(sender As Object, e As EventArgs) Handles txtNom.TextChanged
        If actualitzar Then Call validateControls()
    End Sub

    Private Sub txtNom_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNom.KeyPress
        e.KeyChar = VALIDAR.texte(e.KeyChar, txtNom.Text.Length, 100)
    End Sub
    Private Sub txtNotes_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNotes.KeyPress
        e.KeyChar = VALIDAR.texte(e.KeyChar, txtNotes.Text.Length, 250)
    End Sub
End Class
