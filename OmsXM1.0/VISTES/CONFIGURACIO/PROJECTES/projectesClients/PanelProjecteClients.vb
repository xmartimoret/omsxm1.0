Option Explicit On
Public Class PanelProjecteClients
    Private panelSelectClient As SelectClient
    Private panelSelectProjecteClient As SelectProjecteClient
    Private clientActual As Client
    Private projecteClientActual As ProjecteClient
    Private contBuscador As Integer
    Private Sub setLanguage()
        Me.lblCercador.Text = IDIOMA.getString("cercador")
        Me.cmdSortir.Text = IDIOMA.getString("cmdTancar")
        Me.cmdCercador.Text = IDIOMA.getString("cmdCercador")
    End Sub
    Private Sub setClients()
        panelSelectClient = New SelectClient(1, False, False, -1, IDIOMA.getString("configClients"), 1)
        AddHandler panelSelectClient.selectObject, AddressOf getClient
        Me.PanelClient.Controls.Clear()
        panelSelectClient.Dock = DockStyle.Fill
        Me.PanelClient.Controls.Add(panelSelectClient)
        panelSelectClient.Show()
    End Sub
    Private Sub getClient(c As Client)
        clientActual = c
        Call setClient()
    End Sub
    Private Sub setClient()
        panelSelectProjecteClient = New SelectProjecteClient(1, True, False, clientActual.id, IDIOMA.getString("projectesDe") & " " & clientActual.ToString, 1)
        AddHandler panelSelectProjecteClient.selectObject, AddressOf getProjecteClient
        panelSelectProjecteClient.Dock = DockStyle.Fill
        Me.panelProjecte.Controls.Clear()
        Me.panelProjecte.Controls.Add(panelSelectProjecteClient)
        panelSelectProjecteClient.Show()
    End Sub
    Private Sub getProjecteClient(pc As ProjecteClient)
        projecteClientActual = pc
    End Sub
    Private Sub cercador()
        Dim c As Client, i As Integer, pc As ProjecteClient, trobat As Boolean, p As Projecte
        i = 1
        For Each c In ModelClient.getObjects("")
            If InStr(1, c.notes, Me.txtCercador.Text, vbTextCompare) > 0 Or InStr(1, c.nom, txtCercador.Text, vbTextCompare) > 0 Then
                If i >= contBuscador Then
                    panelSelectClient.escollir(c.id)
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
                        panelSelectClient.escollir(c.id)
                        panelSelectProjecteClient.escollir(CStr(pc.idProjecte))
                        trobat = True
                        contBuscador = contBuscador + 1
                        Exit For
                    Else
                        i = i + 1
                    End If
                End If
            Next pc
            If trobat Then Exit For
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
    End Sub
    Private Sub cmdCercador_Click(sender As Object, e As EventArgs) Handles cmdCercador.Click
        If Me.txtCercador.Text.Length > 0 Then Call cercador()
    End Sub

    Private Sub PanelProjecteClients_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call setLanguage()
        Call setClients()
    End Sub

    Private Sub cmdSortir_Click(sender As Object, e As EventArgs) Handles cmdSortir.Click
        Call FrmApliOms.resetPanel()
    End Sub
End Class
