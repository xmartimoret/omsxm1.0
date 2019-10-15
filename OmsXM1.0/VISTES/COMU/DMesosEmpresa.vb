Option Explicit On
Imports System.Windows.Forms
Public Class DMesosEmpresa
    Private actualitzar As Boolean
    Private idEmpresaActual As Integer
    Private Const anyInici As Integer = 2015
    Public Function getMesos(Optional anyo As Integer = 0, Optional caption As String = "", Optional idEmpresa As Integer = 0) As AnyMesos
        If caption = "" Then
            Me.Text = IDIOMA.getString("dDadesImport")
        Else
            Me.Text = caption
        End If
        If anyo > 0 Then Me.txtAny.Text = anyo
        idEmpresaActual = idEmpresa
        Me.ShowDialog()
        If Me.DialogResult = DialogResult.OK Then
            getMesos = getData()
        Else
            getMesos = Nothing
        End If
        Me.Close()
    End Function



    Private Sub setLanguage()
        Me.cmdGuardar.Text = IDIOMA.getString("cmdGuardar")
        Me.cmdCancelar.Text = IDIOMA.getString("cmdCancelar")
        Me.lblAny.Text = IDIOMA.getString("any") & ":"
        Me.lblEmpresa.Text = IDIOMA.getString("empresa") & ":"
        Me.lblMes.Text = IDIOMA.getString("mes") & ":"
        Me.lblErrAny.Text = IDIOMA.getString("campObligatori")
        Me.lblErrorEmpresa.Text = IDIOMA.getString("campObligatori")
        Me.lblErrMes.Text = IDIOMA.getString("campObligatori")
        Me.xecLog.Text = IDIOMA.getString("mostrarLog")
        Me.xecTots.Text = IDIOMA.getString("selectTots")
    End Sub
    Private Sub setMesos()
        Dim i As Integer
        actualitzar = False
        lstMes.Items.Clear()

        For i = 1 To 12
            lstMes.Items.Add(New Mes(i, CONFIG.mesNom(i)))
        Next i
        actualitzar = True
    End Sub
    Private Sub setEmpreses()
        cbEmpresa.Items.Clear()
        cbEmpresa.Items.AddRange(ModelEmpresa.getListObjects)
        cbEmpresa.SelectedIndex = getListIndexEmpresa(idEmpresaActual)
    End Sub
    Private Function getListIndexEmpresa(idEmpresa As Integer) As Integer
        Dim i As Integer
        For i = 0 To cbEmpresa.Items.Count - 1
            If cbEmpresa.Items(i).id = idEmpresa Then
                Return i
            End If
        Next
        Return -1
    End Function
    Private Function getData() As AnyMesos
        Dim m As Mes
        getData = New AnyMesos
        getData.any = txtAny.Text
        getData.isLog = Me.xecLog.Checked
        For Each m In lstMes.SelectedItems
            Call getData.setMes(m.num, True)
        Next m
        If cbEmpresa.SelectedIndex > -1 Then
            getData.idEmpresa = cbEmpresa.SelectedItem.id
        End If
    End Function
    Private Sub validateControls()
        Dim i As Integer, contMesos As Integer
        cmdGuardar.Enabled = True
        lblErrAny.Visible = False
        lblErrMes.Visible = False
        Me.lblErrorEmpresa.Visible = False
        If txtAny.Text = "" Or Val(txtAny.Text) = 0 Then
            lblErrAny.Visible = True
            cmdGuardar.Enabled = False
        End If
        If cbEmpresa.SelectedIndex = -1 Then
            lblErrorEmpresa.Visible = True
            cmdGuardar.Enabled = False
        End If
        contMesos = lstMes.SelectedItems.Count
        actualitzar = False
        If contMesos = 0 Then
            lblErrMes.Visible = True
            cmdGuardar.Enabled = False
        ElseIf contMesos < lstMes.Items.Count Then
            Me.xecTots.Checked = False
        Else
            Me.xecTots.Checked = True
        End If
        actualitzar = True
    End Sub

    Private Sub lstMes_Change()
        If actualitzar Then
            Call validateControls()
        End If
    End Sub

    Private Sub txtAny_Change()
        If actualitzar Then
            Call validateControls()
        End If
    End Sub
    Private Sub cmdGuardar_Click(sender As Object, e As EventArgs) Handles cmdGuardar.Click
        Me.DialogResult = DialogResult.OK
        Me.Hide()
    End Sub

    Private Sub xecTots_CheckedChanged(sender As Object, e As EventArgs) Handles xecTots.CheckedChanged
        Dim i As Integer
        If actualitzar Then
            If xecTots.Checked = True Then
                For i = 0 To lstMes.Items.Count - 1
                    lstMes.SetSelected(i, True)
                Next i
            End If
            Call validateControls()
        End If
    End Sub

    Private Sub txtAny_TextChanged(sender As Object, e As EventArgs) Handles txtAny.TextChanged
        If actualitzar Then Call validateControls()
    End Sub

    Private Sub txtAny_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAny.KeyPress
        e.KeyChar = VALIDAR.Enter(e.KeyChar, txtAny.Text.Length, 4)
    End Sub

    Private Sub dImportTransitories_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call setLanguage()
        Call setMesos()
        Call setEmpreses()
        Call validateControls()
    End Sub

    Private Sub lstMes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstMes.SelectedIndexChanged
        If actualitzar Then Call validateControls()
    End Sub

    Private Sub cmdCancelar_Click(sender As Object, e As EventArgs) Handles cmdCancelar.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Hide()
    End Sub

    Private Sub cbEmpresa_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbEmpresa.SelectedIndexChanged
        If actualitzar Then Call validateControls()
    End Sub
End Class


