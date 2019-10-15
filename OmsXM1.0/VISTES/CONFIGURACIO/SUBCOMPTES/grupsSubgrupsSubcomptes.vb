Public Class grupsSubgrupsSubcomptes
    Private grupActual As Grup
    Private pSubgrupActual As SelectSubgrups
    Private pSubcomptesSubgrup As SelectSubcomptesSubgrup
    Private subcompteActual As SubcompteGrup
    Private actualitzar As Boolean
    Private contBuscador As Integer
    Public Sub New()
        InitializeComponent()
        Call setLanguage()
        Call setGrups()
        If Me.cbGrup.Items.Count > 0 Then Me.cbGrup.SelectedIndex = 0
    End Sub
    Public Sub setLanguage()
        actualitzar = False
        Me.lblCercador.Text = IDIOMA.getString("cercador")
        Me.lblGrup.Text = IDIOMA.getString("grups")
        Me.cmdCercador.Text = IDIOMA.getString("cmdCercador")
        Me.cmdEditarGrups.Text = IDIOMA.getString("cmdEditarGrups")
        Me.cmdTancar.Text = IDIOMA.getString("cmdSortir")
        actualitzar = True
    End Sub

    Public Sub setGrups()
        actualitzar = False
        cbGrup.Items.Clear()
        cbGrup.Items.AddRange(ModelGrup.getListObjects(ModelGrup.getObjects))
        actualitzar = True
    End Sub
    Private Function getIdGrup() As Integer
        Dim i As Integer
        For i = 0 To cbGrup.Items.Count - 1
            If cbGrup.Items(i).id = grupActual.id Then
                Return i
            End If
        Next
        Return -1
    End Function
    Private Sub setSubgrups()
        pSubgrupActual = New SelectSubgrups(1, False, False, grupActual.id, IDIOMA.getString("subgrupsComptables") & " " & IDIOMA.getString("de") & " " & grupActual.nom, 1)
        AddHandler pSubgrupActual.selectObject, AddressOf setSubcomptes
        Me.PanelSubgrups.Controls.Clear()
        pSubgrupActual.Dock = DockStyle.Fill
        Me.PanelSubgrups.Controls.Add(pSubgrupActual)
        pSubgrupActual.Show()
    End Sub
    Private Sub setSubcomptes(sg As Subgrup)
        pSubcomptesSubgrup = New SelectSubcomptesSubgrup(grupActual.id, sg.id, "SUBCOMPTES DE " & sg.ToString, 2)
        AddHandler pSubcomptesSubgrup.selectObject, AddressOf setSubcompte
        Me.PanelSubcomptes.Controls.Clear()
        pSubcomptesSubgrup.Dock = DockStyle.Fill
        pSubcomptesSubgrup.Show()
        Me.PanelSubcomptes.Controls.Add(pSubcomptesSubgrup)
    End Sub
    Private Sub setSubcompte(s As SubcompteGrup)
        subcompteActual = s
    End Sub
    Private Sub cbGrup_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbGrup.SelectedIndexChanged
        If actualitzar Then
            grupActual = cbGrup.SelectedItem
            Call setSubgrups()
            Me.PanelSubcomptes.Controls.Clear()
        End If
    End Sub
    Private Sub cercador()
        Dim g As Subgrup, s As SubcompteGrup, i As Integer, trobat As Boolean, subcte As Subcompte
        i = 1
        For Each g In grupActual.subgrups
            If Not g.actualitzat Then g.subcomptes = ModelSubcomptesGrup.getObjects(g.id)
            If InStr(1, g.codi, Me.txtCercador.Text, vbTextCompare) > 0 Or InStr(1, g.nom, txtCercador.Text, vbTextCompare) > 0 Then
                If i >= contBuscador Then
                    pSubgrupActual.escollir(g.id)
                    trobat = True
                    contBuscador = contBuscador + 1
                    Exit For
                Else
                    i = i + 1
                End If
            End If
            If trobat Then Exit For
            For Each s In g.subcomptes
                subcte = ModelSubcompte.getObject(s.idSubcompte)
                If InStr(1, subcte.codi, Me.txtCercador.Text, vbTextCompare) > 0 Or InStr(1, subcte.nom, Me.txtCercador.Text, vbTextCompare) > 0 Then
                    If i >= contBuscador Then
                        pSubgrupActual.escollir(g.id)
                        pSubcomptesSubgrup.escollir(s.id)
                        trobat = True
                        contBuscador = contBuscador + 1
                        Exit For
                    Else
                        i = i + 1
                    End If
                End If
            Next s
            If trobat Then Exit For
        Next g
        If Not trobat Then
            If contBuscador > 1 Then
                Call MISSATGES.NOT_SEARCH_ANOTHER_ACCOUNT()
                cmdCercador.Text = IDIOMA.getString("cmdCercador")
            Else
                Call MISSATGES.NOT_SEARCH_ACCOUNT()
            End If
            contBuscador = 1
        Else
            cmdCercador.Text = IDIOMA.getString("cmdCercadorSeguent")
        End If
        g = Nothing
        s = Nothing
    End Sub
    Private Sub cmdCercador_Click(sender As Object, e As EventArgs) Handles cmdCercador.Click
        If Me.txtCercador.Text <> "" Then Call cercador()
    End Sub

    Private Sub cmdEditarGrups_Click(sender As Object, e As EventArgs) Handles cmdEditarGrups.Click
        Dim pGrup As New DGrups
        Call DGrups.ShowDialog()
        Call setGrups()
        pGrup = Nothing
    End Sub

    Private Sub cmdTancar_Click(sender As Object, e As EventArgs) Handles cmdTancar.Click
        Me.Dispose()
    End Sub


End Class
