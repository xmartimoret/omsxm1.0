Imports System.Windows.Forms

Public Class DSubGrupGB
    Private subgrupActual As SubGrupGB
    Private actualitzar As Boolean

    Private cursorFormula As Integer
    Private formula As String
    Public Sub New()
        InitializeComponent()
    End Sub
    Public Function getsubgrup(psubgrup As SubGrupGB) As SubGrupGB
        subgrupActual = psubgrup
        If subgrupActual.id = -1 Then
            Me.Text = IDIOMA.getString("dsubgrupAfegirsubgrup")
        Else
            Me.Text = IDIOMA.getString("dsubgrupModificarsubgrup")
        End If
        Call setLanguage()
        Call setSubgrups
        Call setSubgrupsGB
        Call setData()
        Me.ShowDialog()
        If Me.DialogResult = System.Windows.Forms.DialogResult.OK Then
            getsubgrup = getData()
            Me.Close()
        Else
            getsubgrup = Nothing
            Me.Close()
        End If
    End Function
    Private Sub setData()
        lblId.Text = subgrupActual.id
        txtCodi.Text = subgrupActual.codi
        txtNom.Text = subgrupActual.nom
        txtFormula.Text = subgrupActual.toStringFormula
        xecTotal.Checked = subgrupActual.esTotal
    End Sub
    Private Sub setSubgrups()
        actualitzar = False
        Me.cbSubgrup.Items.Clear()
        Me.cbSubgrup.Items.AddRange(ModelSubgrup.getListObjects())
        actualitzar = True
    End Sub
    Private Sub setSubgrupsgb()
        actualitzar = False
        Me.cbSubGrupGB.Items.Clear()
        Me.cbSubGrupGB.Items.AddRange(ModelSubGrupGB.getListObjects())
        actualitzar = True
    End Sub
    Private Sub setLanguage()
        Me.lblCodi.Text = IDIOMA.getString("codi")
        Me.lblIdCaption.Text = IDIOMA.getString("id")
        Me.lblNom.Text = IDIOMA.getString("nom")
        Me.lblFormulaCaption.Text = IDIOMA.getString("formula")
        Me.lblSubgrup.Text = IDIOMA.getString("subgrup")
        Me.lblSubgrupGb.Text = IDIOMA.getString("subgrupGb")
        Me.lblErrNom.Text = IDIOMA.getString("campObligatori")
        Me.cmdGuardar.Text = IDIOMA.getString("cmdGuardar")
        Me.cmdCancelar.Text = IDIOMA.getString("cmdCancelar")
        Me.xecTotal.Text = IDIOMA.getString("sumaSubgrups")
    End Sub
    Private Sub validateControls()
        Me.lblErrCodi.Visible = False
        Me.lblErrNom.Visible = False
        Me.cmdGuardar.Enabled = True
        If txtCodi.Text.Length = 0 Then
            Me.lblErrCodi.Visible = True
            Me.cmdGuardar.Enabled = False
            Me.lblErrCodi.Text = IDIOMA.getString("campObligatori")
        End If
        If txtNom.Text.Length = 0 Then
            Me.lblErrNom.Visible = True
            Me.cmdGuardar.Enabled = False
        End If
    End Sub

    Private Function getData() As SubGrupGB
        getData = subgrupActual.copy
        getData.codi = txtCodi.Text
        getData.nom = txtNom.Text
        getData.formula = getFormula(txtFormula.Text)
        getData.esTotal = xecTotal.Checked
        getData.toStringFormula = txtFormula.Text
    End Function
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGuardar.Click
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Hide()
        End Sub

        Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click

        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Hide()
        End Sub

        Private Sub Dsubgrup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            Call validateControls()
        End Sub
        Private Sub txtCodi_TextChanged(sender As Object, e As EventArgs) Handles txtCodi.TextChanged
            Call validateControls()
        End Sub
        Private Sub txtNom_TextChanged(sender As Object, e As EventArgs) Handles txtNom.TextChanged
            Call validateControls()
        End Sub
        Private Sub txtCodi_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCodi.KeyPress
        e.KeyChar = VALIDAR.AlfaNumeric(e.KeyChar, txtCodi.Text.Length, 8)
        e.Handled = False
        End Sub
    Private Sub editFormula(t As String, id As Integer)
        Dim tLeft As String, tRight As String
        tLeft = Strings.Left(txtFormula.Text, cursorFormula)
        tRight = Strings.Right(txtFormula.Text, txtFormula.Text.Length - cursorFormula)

        txtFormula.Text = tLeft & getOperator() & t & tRight
        cursorFormula = cursorFormula + t.Length + 1

    End Sub



    Private Sub cbSubgrup_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbSubgrup.SelectedIndexChanged
        If actualitzar Then
            If cbSubgrup.SelectedIndex > -1 Then Call editFormula(cbSubgrup.SelectedItem.codi, cbSubgrup.SelectedItem.id)
        End If
    End Sub

    Private Sub cbSubGrupGB_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbSubGrupGB.SelectedIndexChanged
        If actualitzar Then
            If cbSubGrupGB.SelectedIndex > -1 Then Call editFormula(cbSubGrupGB.SelectedItem.codi, cbSubGrupGB.SelectedItem.id)
        End If
    End Sub


    Private Sub txtFormula_MouseUp(sender As Object, e As MouseEventArgs) Handles txtFormula.MouseUp
        cursorFormula = txtFormula.SelectionStart
    End Sub

    Private Sub txtFormula_KeyUp(sender As Object, e As KeyEventArgs) Handles txtFormula.KeyUp
        cursorFormula = txtFormula.SelectionStart
    End Sub
    Private Function getOperator() As String
        If optMultiplicar.Checked Then
            Return "*"
        ElseIf optRestar.Checked Then
            Return "-"
        ElseIf optDividir.Checked Then
            Return "/"
        Else
            Return "+"
        End If
    End Function
    Private Function getFormula(t As String) As String
        Dim i As Integer, result As String, codi As String, sg As Subgrup, sggb As SubGrupGB
        result = ""
        codi = ""
        For i = 1 To t.Length
            If isOperator(Strings.Mid(t, i, 1)) Then
                If codi <> "" Then
                    sg = ModelSubgrup.getObject(codi)
                    If sg Is Nothing Then
                        sggb = ModelSubGrupGB.getObject(codi)
                        If sggb IsNot Nothing Then
                            result = result & Strings.Right(sggb.formula, sggb.formula.Length - 1)
                        End If
                    Else
                        result = result & sg.id
                    End If
                    codi = ""
                    result = result & Strings.Mid(t, i, 1)
                Else
                    result = result & Strings.Mid(t, i, 1)

                End If

            Else
                codi = codi & Strings.Mid(t, i, 1)
            End If
        Next
        If codi <> "" Then
            sg = ModelSubgrup.getObject(codi)
            If sg Is Nothing Then
                sggb = ModelSubGrupGB.getObject(codi)
                If sggb IsNot Nothing Then
                    result = result & Strings.Right(sggb.formula, sggb.formula.Length - 1)
                End If
            Else
                result = result & sg.id
            End If
        End If
        sg = Nothing
        sggb = Nothing
        Return result
    End Function
    Private Function isOperator(t As String) As Boolean
        If t = "+" Or t = "-" Or t = "*" Or t = "/" Then Return True
        Return False
    End Function

End Class

