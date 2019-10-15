Option Explicit On
Imports System.Windows.Forms
Public Class DMesos
    Private dadesActuals As AnyMesos
    Private actualitzar As Boolean
    Private isGB As Boolean
    Public Function getData() As AnyMesos
        isGB = False
        Me.xecBorrar.Visible = True
        Me.xecTots.Visible = True
        Me.Text = IDIOMA.getString("seleccionarData")
        Me.lstMes.SelectionMode = SelectionMode.MultiSimple
        Me.Show()
        If Me.DialogResult = DialogResult.OK Then
            Call getMesos()
            getData = dadesActuals
        Else
            getData = Nothing
        End If
        Me.Close()
    End Function
    Public Function getDataGb() As AnyMesos
        isGB = True
        Me.xecBorrar.Visible = False
        Me.xecTots.Visible = False
        Me.lstMes.SelectionMode = SelectionMode.One
        Me.Text = IDIOMA.getString("seleccionarData")
        Me.Show()
        If Me.DialogResult = DialogResult.OK Then
            Call getMesos()
            getDataGb = dadesActuals
        Else
            getDataGb = Nothing
        End If
        Me.Close()
    End Function
    Private Sub setLanguage()
        Me.lblAny.Text = IDIOMA.getString("any")
        Me.lblMes.Text = IDIOMA.getString("any")
        Me.cmdGuardar.Text = IDIOMA.getString("cmdAcceptar")
        Me.cmdCancelar.Text = IDIOMA.getString("cmdCancelar")
        Me.xecBorrar.Text = IDIOMA.getString("borrarSelect")
        Me.xecTots.Text = IDIOMA.getString("selectTots")
        Me.xecLog.Text = IDIOMA.getString("mostrarLog")
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
    Private Sub getMesos()
        Dim m As Mes
        dadesActuals = New AnyMesos
        dadesActuals.any = Val(txtAny)
        For Each m In lstMes.SelectedItems
            dadesActuals.setMes(m.num, True)
        Next m
        dadesActuals.isLog = xecLog.Checked
    End Sub

    Private Sub validateControls()
        Dim i As Integer
        Me.lblErrAny.Visible = False
        Me.cmdGuardar.Enabled = True
        If txtAny.Text = "" Then
            Me.lblErrAny.Visible = True
            Me.lblErrAny.Text = IDIOMA.getString("campObligatori")
            Me.cmdGuardar.Enabled = False
        ElseIf txtAny.Text < 2000 Then
            Me.lblErrAny.Text = IDIOMA.getString("campIncorrecte")
            Me.lblErrAny.Visible = True
            Me.cmdGuardar.Enabled = False
        End If

        If cmdGuardar.Enabled Then
            Me.cmdGuardar.Enabled = False
            If Me.lstMes.SelectedItems.Count > 0 Then Me.cmdGuardar.Enabled = True
        End If
    End Sub
    Private Sub validateXecs()
        If lstMes.SelectedItems.Count = 0 Then
            xecBorrar.Checked = True
        ElseIf lstMes.SelectedItems.Count = 12 Then
            xecTots.Checked = True
        Else
            xecBorrar.Checked = False
            xecTots.Checked = False
        End If
    End Sub

    Private Sub cmdAcceptar_Click()
        Me.DialogResult = DialogResult.OK
        Me.Hide()
    End Sub

    Private Sub cmdCancelar_Click()
        Me.DialogResult = DialogResult.Cancel
        Me.Hide()
    End Sub

    Private Sub txtAny_Change()
        Call validateControls()
    End Sub
    Private Sub UserForm_Terminate()
        dadesActuals = Nothing
    End Sub

    Private Sub DMesos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call setMesos()
        xecTots.Checked = True
        Call validateControls()
    End Sub

    Private Sub lstMes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstMes.SelectedIndexChanged
        If actualitzar Then
            Call validateControls()
            Call validateXecs()
        End If
    End Sub

    Private Sub xecBorrar_CheckedChanged(sender As Object, e As EventArgs) Handles xecBorrar.CheckedChanged
        If Not isGB Then
            Dim i As Integer
            actualitzar = False
            If xecBorrar.Checked Then
                For i = 0 To lstMes.Items.Count - 1
                    lstMes.Items(i).ckecked = False
                Next i
            End If
            actualitzar = True
            Call validateControls()
        End If
    End Sub

    Private Sub xecTots_CheckedChanged(sender As Object, e As EventArgs) Handles xecTots.CheckedChanged
        If Not isGB Then
            Dim i As Integer
            actualitzar = False
            If xecTots.Checked Then
                For i = 0 To lstMes.Items.Count - 1
                    lstMes.Items(i).ckecked = True
                Next i
            End If
            actualitzar = True
            Call validateControls()
        End If
    End Sub

    Private Sub txtAny_TextChanged(sender As Object, e As EventArgs) Handles txtAny.TextChanged
        Call validateControls()
    End Sub

    Private Sub txtAny_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAny.KeyPress
        e.KeyChar = VALIDAR.Enter(e.KeyChar, txtAny.Text.Length, 4)
    End Sub
End Class
