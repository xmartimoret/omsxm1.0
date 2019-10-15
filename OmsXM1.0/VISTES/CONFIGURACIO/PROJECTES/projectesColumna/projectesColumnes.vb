Public Class projectesColumnes
    Private columnaActual As Columna
    Private fillaActual As ColumnaFilla
    Private projecteActual As ProjecteColumna
    Private contBuscador As Integer
    Private panelColumna As SelectColumnes
    Private panelSub As SelectColumnaFilles
    Private panelSub1 As SelectColumnaProjectes
    Private Sub setLanguage()
        Me.lblCercador.Text = IDIOMA.getString("cercador")
        Me.cmdTancar.Text = IDIOMA.getString("cmdTancar")
        Me.cmdCercador.Text = IDIOMA.getString("cmdCercador")
    End Sub
    Private Sub setColumnes()
        panelColumna = New SelectColumnes(1, IDIOMA.getString("configColumnes"), 1)
        AddHandler panelColumna.selectObject, AddressOf getColumna
        Me.panelColumnes.Controls.Clear()
        panelColumna.Dock = DockStyle.Fill
        Me.panelColumnes.Controls.Add(panelColumna)
        panelColumna.Show()
    End Sub
    Private Sub getColumna(c As Columna)
        columnaActual = c
        Call setColumna()
    End Sub
    Private Sub setColumna()
        If columnaActual.totalitzador Then
            panelSub = New SelectColumnaFilles(columnaActual.id, IDIOMA.getString("columnesDe") & " " & columnaActual.ToString, 1)
            AddHandler panelSub.selectObject, AddressOf getColumnaFilla
            AddHandler panelSub.addObject, AddressOf setColumnaFilla
            AddHandler panelSub.removeObject, AddressOf removeColumnaFilla
            panelSub.Dock = DockStyle.Fill
            Me.PanelProjectes.Controls.Clear()
            Me.PanelProjectes.Controls.Add(panelSub)
            panelSub.Show()
        Else

            panelSub1 = New SelectColumnaProjectes(columnaActual.id, IDIOMA.getString("projectesDe") & " " & columnaActual.ToString, 1)
            AddHandler panelSub1.selectObject, AddressOf getColumnaProjecte
            AddHandler panelSub1.addObject, AddressOf setColumnaProjecte
            AddHandler panelSub1.RemoveObject, AddressOf removeColumnaprojecte
            panelSub1.Dock = DockStyle.Fill
            Me.PanelProjectes.Controls.Clear()
            Me.PanelProjectes.Controls.Add(panelSub1)
            panelSub1.Show()
        End If

    End Sub
    Private Sub getColumnaFilla(cf As ColumnaFilla)
        fillaActual = cf
    End Sub
    Private Sub getColumnaProjecte(pc As ProjecteColumna)
        projecteActual = pc
    End Sub
    Private Sub setColumnaFilla(columnes As List(Of ColumnaFilla))
        Dim cf As ColumnaFilla
        For Each cf In columnes
            columnaActual.columnes.Add(cf)
        Next
        cf = Nothing
    End Sub
    Private Sub setColumnaProjecte(projectes As List(Of ProjecteColumna))
        Dim cp As ProjecteColumna
        For Each cp In projectes
            columnaActual.projectes.Add(cp)
        Next
        cp = Nothing
    End Sub
    Private Sub removeColumnaFilla(pc As ColumnaFilla)
        fillaActual = Nothing
        columnaActual.columnes.Remove(pc)
    End Sub
    Private Sub removeColumnaProjecte(pc As ProjecteColumna)
        projecteActual = Nothing
        columnaActual.projectes.Remove(pc)
    End Sub

    Private Sub projectesColumnes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call setLanguage()
        Call setColumnes()
    End Sub
    Private Sub cercador()
        Dim c As Columna, i As Integer, pc As ProjecteColumna, trobat As Boolean, p As Projecte, cf As ColumnaFilla, cFilla As Columna
        i = 1
        For Each c In ModelColumna.getObjects("")
            If InStr(1, c.codi, Me.txtCercador.Text, vbTextCompare) > 0 Or InStr(1, c.nom, txtCercador.Text, vbTextCompare) > 0 Then
                If i >= contBuscador Then
                    panelColumna.escollir(c.id)
                    trobat = True
                    contBuscador = contBuscador + 1
                    Exit For
                Else
                    i = i + 1
                End If
            End If
            If trobat Then Exit For
            For Each pc In c.projectes
                p = ModelProjecte.getObject(pc.idProjecte)
                If InStr(1, p.codi, Me.txtCercador.Text, vbTextCompare) > 0 Or InStr(1, p.nom, Me.txtCercador.Text, vbTextCompare) > 0 Then
                    If i >= contBuscador Then
                        panelColumna.escollir(c.id)
                        panelSub1.escollir(pc.id)
                        trobat = True
                        contBuscador = contBuscador + 1
                        Exit For
                    Else
                        i = i + 1
                    End If
                End If
            Next pc
            If trobat Then Exit For
            For Each cf In c.columnes
                cFilla = ModelColumna.getObject(cf.idFilla)
                If InStr(1, cFilla.codi, Me.txtCercador.Text, vbTextCompare) > 0 Or InStr(1, cFilla.nom, Me.txtCercador.Text, vbTextCompare) > 0 Then
                    If i >= contBuscador Then
                        panelColumna.escollir(c.id)
                        panelSub.escollir(cf.idFilla)
                        trobat = True
                        contBuscador = contBuscador + 1
                        Exit For
                    Else
                        i = i + 1
                    End If
                End If
            Next cf
        Next c
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
        c = Nothing
        pc = Nothing
        p = Nothing
        cf = Nothing
        cFilla = Nothing
    End Sub

    Private Sub cmdCercador_Click(sender As Object, e As EventArgs) Handles cmdCercador.Click
        If Me.txtCercador.Text.Length > 0 Then Call cercador()
    End Sub

    Private Sub cmdTancar_Click(sender As Object, e As EventArgs) Handles cmdTancar.Click
        Call FrmApliOms.resetPanel()
    End Sub
End Class
