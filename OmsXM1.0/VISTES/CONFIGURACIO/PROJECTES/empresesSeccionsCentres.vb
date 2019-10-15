Public Class empresesSeccionsCentres
    Private empresaActual As Empresa
    Private seccioActual As Seccio
    Private centreActual As Centre
    Private projecteActual As ProjecteCentre
    Private actualitzar As Boolean
    Private contBuscador As Integer
    Private seccions As SelectSeccio
    Private centres As SelectCentre
    Private projectes As SelectProjectesCentre
    Private Sub setEmpreses()
        actualitzar = False
        cbEmpresa.Items.Clear()
        cbEmpresa.Items.AddRange(ModelEmpresa.getListObjects)
        cbEmpresa.SelectedIndex = getIndexEmpresa()
        If cbEmpresa.SelectedIndex > -1 Then empresaActual = cbEmpresa.SelectedItem
        actualitzar = True
    End Sub
    Private Function getIndexEmpresa() As Integer
        Dim i As Integer

        If empresaActual Is Nothing And cbEmpresa.Items.Count > 0 Then
            Return 0
        End If
        For i = 0 To cbEmpresa.Items.Count - 1
            If cbEmpresa.Items(i).id = empresaActual.id Then
                Return i
            End If
        Next
        Return 0
    End Function
    Private Sub setSeccions()

        seccions = New SelectSeccio(1, False, False, empresaActual.id, IDIOMA.getString("seccions") & " de " & empresaActual.nom, 1)
        AddHandler seccions.selectObject, AddressOf setSeccio
        seccions.Dock = DockStyle.Fill
        panelSeccio.Controls.Clear()
        seccions.Show()
        panelSeccio.Controls.Add(seccions)
        panelCentre.Controls.Clear()
    End Sub
    Private Sub setSeccio(s As Seccio)
        seccioActual = s
        Call setCentres()
    End Sub
    Private Sub setCentres()
        centres = New SelectCentre(1, False, False, seccioActual.id, IDIOMA.getString("centres") & " " & empresaActual.nom & "." & seccioActual.nom, 1)
        AddHandler centres.selectObject, AddressOf setCentre
        AddHandler centres.removeObject, AddressOf quitCentre
        AddHandler centres.AddObject, AddressOf setCentreSeccio
        centres.Dock = DockStyle.Fill
        panelCentre.Controls.Clear()
        centres.Show()
        panelCentre.Controls.Add(centres)
        panelProjecte.Controls.Clear()
    End Sub
    Private Sub setCentreSeccio(c As Centre)
        seccioActual.centres.Add(c)
        centreActual = c
    End Sub
    Private Sub setCentre(c As Centre)
        centreActual = c
        Call setProjectes()
    End Sub

    Private Sub quitCentre(c As Centre)
        seccioActual.centres.Remove(c)
    End Sub
    Private Sub setProjectes()

        projectes = New SelectProjectesCentre(1, False, False, centreActual.id, IDIOMA.getString("projectes") & " " & empresaActual.nom & "." & seccioActual.nom & "." & centreActual.nom, 1)
        AddHandler projectes.selectObject, AddressOf setProjecte
        AddHandler projectes.addObject, AddressOf setProjectes
        projectes.Dock = DockStyle.Fill
        panelProjecte.Controls.Clear()
        projectes.Show()
        panelProjecte.Controls.Add(projectes)

    End Sub
    Private Sub setProjecte(p As ProjecteCentre)
        projecteActual = p
    End Sub
    Private Sub setProjectes(projectes As List(Of ProjecteCentre))
        Dim pc As ProjecteCentre
        If centreActual IsNot Nothing Then
            For Each pc In projectes
                centreActual.projectes.Add(pc)
            Next
        End If
        pc = Nothing
    End Sub
    Private Sub setLanguage()
        Me.lblCercador.Text = IDIOMA.getString("cercador")
        Me.cmdCercador.Text = IDIOMA.getString("cmdCercador")
        Me.cmdSortir.Text = IDIOMA.getString("cmdSortir")
        Me.lblEmpresa.Text = IDIOMA.getString("empresa")
        Me.cmdSortir.Text = IDIOMA.getString("cmdSortir")
    End Sub
    Private Sub cbEmpresa_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbEmpresa.SelectedIndexChanged
        If actualitzar Then
            If cbEmpresa.SelectedIndex > -1 Then
                empresaActual = cbEmpresa.SelectedItem
                Call setSeccions()
            Else
                empresaActual = New Empresa
                panelSeccio.Controls.Clear()
            End If
            panelCentre.Controls.Clear()
            panelProjecte.Controls.Clear()
        End If
    End Sub

    Private Sub empresesSeccionsCentres_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call setLanguage()
        Call setEmpreses()
        If empresaActual IsNot Nothing Then Call setSeccions()
    End Sub

    Private Sub cmdSortir_Click(sender As Object, e As EventArgs) Handles cmdSortir.Click
        Call FrmApliOms.resetPanel()
    End Sub

    Private Sub cercador()
        Dim s As Seccio, c As Centre, i As Integer, trobat As Boolean, p As ProjecteCentre, j As Integer
        i = 1
        For j = 0 To cbEmpresa.Items.Count - 1
            empresaActual = cbEmpresa.Items(j)
            For Each s In empresaActual.seccions
                If InStr(1, s.codi, Me.txtCercador.Text, vbTextCompare) > 0 Or InStr(1, s.nom, txtCercador.Text, vbTextCompare) > 0 Then
                    If i >= contBuscador Then
                        cbEmpresa.SelectedIndex = j
                        seccions.escollir(s.id)

                        trobat = True
                        contBuscador = contBuscador + 1
                        Exit For
                    Else
                        i = i + 1
                    End If
                End If
                If trobat Then Exit For
                For Each c In s.centres
                    If InStr(1, c.codi, Me.txtCercador.Text, vbTextCompare) > 0 Or InStr(1, c.nom, Me.txtCercador.Text, vbTextCompare) > 0 Then
                        If i >= contBuscador Then
                            cbEmpresa.SelectedIndex = j
                            seccions.escollir(s.id)
                            centres.escollir(c.id)
                            trobat = True
                            contBuscador = contBuscador + 1
                            Exit For
                        Else
                            i = i + 1
                        End If
                    End If
                    For Each p In c.projectes
                        If InStr(1, p.codiProjecte, Me.txtCercador.Text, vbTextCompare) > 0 Or InStr(1, p.tostring, Me.txtCercador.Text, vbTextCompare) > 0 Then
                            If i >= contBuscador Then
                                cbEmpresa.SelectedIndex = j
                                seccions.escollir(s.id)
                                centres.escollir(c.id)
                                projectes.escollir(p.id)
                                trobat = True
                                contBuscador = contBuscador + 1
                                Exit For
                            Else
                                i = i + 1
                            End If
                        End If
                    Next p
                    If trobat Then Exit For
                Next c
                If trobat Then Exit For
            Next s
            If trobat Then Exit For
        Next
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
        p = Nothing
        c = Nothing
        s = Nothing
    End Sub

    Private Sub cmdCercador_Click(sender As Object, e As EventArgs) Handles cmdCercador.Click
        Call cercador()
    End Sub
End Class
