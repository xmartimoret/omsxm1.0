Imports System.Windows.Forms
' per tal de saber si existeix la comanda i o cal revisar si cal actualitzar les dades . 
' crec que passant la comanda se'n fa prou. 

' llavors  caldrà veure si hi ha proveidor, si hi ha contacte proveidor, si hi ha magatzem, si hi ha contacte magatzem. 
' també cal saber si les dades son les correctes. 
Public Class DImportF56Avisos
    Private empresaActual As Empresa
    Private projecteActual As Projecte
    Private solicitutActual As SolicitudComanda
    Private proveidorActual As Proveidor
    Private contacteProveidorActual As ProveidorCont
    Private magatzemActual As LlocEntrega
    Private contacteMagatzemActual As Contacte
    Private isEmpresa As Boolean = False
    Private isProjecte As Boolean = False
    Private isProveidor As Boolean = False
    Private isContacteProveidor As Boolean = False
    Private isMagatzem As Boolean = False
    Private isContacteMagatzem As Boolean = False
    Private isUnload As Boolean = True
    Public Function getData(pSolicitut As SolicitudComanda) As SolicitudComanda
        solicitutActual = pSolicitut
        Call setLanguage()
        Call setData()
        Call validateControls()
        getData = Nothing
        If isProveidor Or isContacteProveidor Or isContacteMagatzem Or isMagatzem Then
            Me.Text = IDIOMA.getString("avisosimportComanda") & " " & IDIOMA.getString("mnuNouF56") & " " & solicitutActual.dataComanda
            Me.ShowDialog()
            If Not isUnload Then
                getData = solicitutActual
            End If
        Else
            getData = solicitutActual
        End If
        Me.Dispose()
    End Function
    Private Sub setData()
        Dim ll As LlocEntrega, c As Contacte
        Me.lblEmpresa.Text = solicitutActual.empresa
        Me.lblProjecte.Text = solicitutActual.codiProjecte
        Me.lblProveidor.Text = solicitutActual.proveidor
        Me.lblContacteProveidor.Text = solicitutActual.contacteProveidor
        Me.lblLlocEntrega.Text = solicitutActual.llocEntrega
        Me.lblContacte.Text = solicitutActual.contacteEntrega

        empresaActual = ModelEmpresa.getObject(solicitutActual.empresa)
        If IsNothing(empresaActual) Then
            Me.Panel6.Visible = True
            empresaActual = New Empresa
            lblAvis6.Text = IDIOMA.getString("noHiHaEmpresa")
            isEmpresa = True
        Else
            Me.Panel6.Visible = False
            isEmpresa = False
        End If
        projecteActual = ModelProjecte.getObject(solicitutActual.codiProjecte)
        If IsNothing(projecteActual) Then
            Me.Panel5.Visible = True
            projecteActual = New Projecte
            lblAvis5.Text = IDIOMA.getString("noHiHaProjecte")
            isProjecte = True
        Else
            Me.Panel5.Visible = False
            isProjecte = False
        End If

        proveidorActual = ModelProveidor.getObject(solicitutActual.idProveidor)
        If IsNothing(proveidorActual) Then
            Me.Panel1.Visible = True
            proveidorActual = New Proveidor
            proveidorActual.nom = solicitutActual.proveidor
            lblAvis1.Text = IDIOMA.getString("elProveidorNoExisteix") & " " & Format(solicitutActual.proveidor, "") & vbCrLf & IDIOMA.getString("volsDonarloAlta")
            isProveidor = True
        Else
            Me.Panel1.Visible = False
            isProveidor = False
        End If

        If solicitutActual.idContacteProveidor <= 0 Then
            Me.Panel2.Visible = True
            contacteProveidorActual = New ProveidorCont
            contacteProveidorActual.nom = solicitutActual.contacteProveidor
            contacteProveidorActual.telefon1 = solicitutActual.telefonProveidor
            contacteProveidorActual.email = solicitutActual.emailProveidor
            lblAvis2.Text = IDIOMA.getString("elContacteProveidorNoExisteix") & " " & solicitutActual.contacteProveidor & vbCrLf & IDIOMA.getString("volsDonarloAlta")
            Call validateControls()
            isContacteProveidor = True
        Else
            Me.Panel2.Visible = False
            isContacteProveidor = False
        End If
        ll = ModelLlocEntrega.getObjectByName(solicitutActual.llocEntrega)
        If ll Is Nothing Then
            Me.Panel3.Visible = True
            magatzemActual = New LlocEntrega
            magatzemActual.nom = solicitutActual.llocEntrega
            magatzemActual.direccio = solicitutActual.direccioEntrega
            lblAvis3.Text = IDIOMA.getString("elMagatzemNoExisteix") & " " & solicitutActual.llocEntrega & vbCrLf & IDIOMA.getString("volsDonarloAlta")

            isMagatzem = True
        Else
            Me.Panel3.Visible = False
            isMagatzem = False
        End If
        c = ModelContacte.getObject(solicitutActual.idContacteEntrega)
        If c Is Nothing Then
            Me.Panel4.Visible = True
            contacteMagatzemActual = New Contacte
            contacteMagatzemActual.nom = solicitutActual.contacteEntrega
            contacteMagatzemActual.telefon = solicitutActual.telefonEntrega
            contacteMagatzemActual.email = solicitutActual.emailEntrega
            lblAvis4.Text = IDIOMA.getString("elContacteNoExisteix") & " " & solicitutActual.contacteEntrega & vbCrLf & IDIOMA.getString("volsDonarloAlta")
            isContacteMagatzem = True
        Else
            Me.Panel4.Visible = False
            isContacteMagatzem = False
        End If
    End Sub
    Private Sub setLanguage()
        Me.cmdAfegir1.Text = IDIOMA.getString("cmdAfegir")
        Me.cmdEscollir1.Text = IDIOMA.getString("cmdEscollir")
        Me.cmdAfegir2.Text = IDIOMA.getString("cmdAfegir")
        Me.cmdEscollir2.Text = IDIOMA.getString("cmdEscollir")
        Me.cmdAfegir3.Text = IDIOMA.getString("cmdAfegir")
        Me.cmdEscollir3.Text = IDIOMA.getString("cmdEscollir")
        Me.cmdAfegir4.Text = IDIOMA.getString("cmdAfegir")
        Me.cmdEscollir4.Text = IDIOMA.getString("cmdEscollir")
        Me.lblTContacte.Text = UCase(IDIOMA.getString("contacte")) & ":"
        Me.lblTContacteProveidor.Text = UCase(IDIOMA.getString("contacteProveidor")) & ":"
        Me.lblTLlocEntrega.Text = UCase(IDIOMA.getString("llocEntrega")) & ":"
        Me.lblTProveidor.Text = UCase(IDIOMA.getString("proveidor")) & ":"
        Me.cmdCancelar.Text = IDIOMA.getString("cmdCancelar")
        Me.cmdGuardar.Text = IDIOMA.getString("cmdCrearComanda")
        Me.cmdEscollirEmpresa.Text = IDIOMA.getString("cmdEscollir")
        Me.cmdEscollirProjecte.Text = IDIOMA.getString("cmdEscollir")
    End Sub
    Private Sub validateControls()
        Dim i As Integer
        cmdAfegir2.Enabled = True
        cmdEscollir2.Enabled = True
        If proveidorActual Is Nothing Then
            cmdAfegir2.Enabled = False
            cmdEscollir2.Enabled = False
        ElseIf proveidorActual.id = -1 Then
            cmdAfegir2.Enabled = False
            cmdEscollir2.Enabled = False
        End If
    End Sub

    Private Sub cmdAfegir1_Click(sender As Object, e As EventArgs) Handles cmdAfegir1.Click
        Dim p As Proveidor
        p = DProveidor.getProveidor(proveidorActual)
        If Not p Is Nothing Then
            p.id = ModelProveidor.save(p)
            If p.id > 0 Then
                proveidorActual = p
                solicitutActual.idProveidor = p.id
                solicitutActual.proveidor = p.nom
                Call setData()
            End If
        End If
    End Sub

    Private Sub cmdAfegir2_Click(sender As Object, e As EventArgs) Handles cmdAfegir2.Click
        Dim cp As ProveidorCont
        cp = New ProveidorCont
        cp.idProveidor = proveidorActual.id
        cp.nom = solicitutActual.contacteProveidor
        cp.telefon1 = solicitutActual.telefonProveidor
        cp.email = solicitutActual.emailProveidor
        cp = DProveidorContacte.getProveidor(cp)
        If Not cp Is Nothing Then
            cp.id = ModelProveidorContacte.save(cp)
            If cp.id > 0 Then
                contacteProveidorActual = cp
                solicitutActual.idContacteProveidor = cp.id
                solicitutActual.contacteProveidor = cp.nom
                solicitutActual.telefonProveidor = cp.telefon1
                solicitutActual.emailProveidor = cp.email
                Call setData()
            End If
        End If
        cp = Nothing
    End Sub
    Private Sub cmdAfegir3_Click(sender As Object, e As EventArgs) Handles cmdAfegir3.Click
        Dim ll As LlocEntrega
        ll = DLlocEntrega.getLlocEntrega(magatzemActual)
        If Not ll Is Nothing Then
            ll.id = ModelLlocEntrega.save(ll)
            If ll.id > 0 Then
                magatzemActual = ll
                solicitutActual.idLlocEntrega = ll.id
                solicitutActual.llocEntrega = ll.nom
                solicitutActual.direccioEntrega = ll.direccio & " " & ll.poblacio & "-" & ll.codiPostal
                Call setData()
            End If
        End If
        ll = Nothing
    End Sub
    Private Sub cmdAfegir4_Click(sender As Object, e As EventArgs) Handles cmdAfegir4.Click
        Dim ll As Contacte
        ll = DContacte.getContacte(contacteMagatzemActual)
        If Not ll Is Nothing Then
            ll.id = ModelContacte.save(ll)
            If ll.id > 0 Then
                contacteMagatzemActual = ll
                solicitutActual.idContacteEntrega = ll.id
                solicitutActual.contacteEntrega = ll.nom
                solicitutActual.telefonEntrega = ll.telefon
                solicitutActual.emailEntrega = ll.email
                Call setData()
            End If
        End If
        ll = Nothing
    End Sub

    Private Sub cmdEscollir1_Click(sender As Object, e As EventArgs) Handles cmdEscollir1.Click
        Dim p As Proveidor
        p = DAuxiliars.getProveidor
        If Not p Is Nothing Then
            If p.id > 0 Then
                proveidorActual = p
                solicitutActual.idProveidor = p.id
                solicitutActual.proveidor = p.nom
                Call setData()
            End If
        End If
        p = Nothing
    End Sub

    Private Sub cmdEscollir2_Click(sender As Object, e As EventArgs) Handles cmdEscollir2.Click
        Dim ll As ProveidorCont
        ll = DAuxiliars.getContacteProveidor(proveidorActual)
        If Not ll Is Nothing Then
            If ll.id > 0 Then
                contacteProveidorActual = ll
                solicitutActual.idContacteProveidor = ll.id
                solicitutActual.contacteProveidor = ll.nom
                Call setData()
            End If
        End If
        ll = Nothing
    End Sub
    Private Sub cmdEscollir3_Click(sender As Object, e As EventArgs) Handles cmdEscollir3.Click
        Dim ll As LlocEntrega
        ll = DAuxiliars.getEntrega
        If Not ll Is Nothing Then
            If ll.id > 0 Then
                magatzemActual = ll
                solicitutActual.idLlocEntrega = ll.id
                solicitutActual.llocEntrega = ll.nom
                solicitutActual.direccioEntrega = ll.direccio & " " & ll.poblacio & "-" & ll.codiPostal
                Call setData()
            End If
        End If
        ll = Nothing
    End Sub

    Private Sub cmdEscollir4_Click(sender As Object, e As EventArgs) Handles cmdEscollir4.Click
        Dim ll As Contacte
        ll = DAuxiliars.getContacte
        If Not ll Is Nothing Then
            If ll.id > 0 Then
                contacteMagatzemActual = ll
                solicitutActual.idContacteEntrega = ll.id
                solicitutActual.contacteEntrega = ll.nom
                solicitutActual.telefonEntrega = ll.telefon
                solicitutActual.emailEntrega = ll.email
                Call setData()
            End If
        End If
        ll = Nothing
    End Sub


    Private Sub cmdTancar_Click(sender As Object, e As EventArgs) Handles cmdGuardar.Click
        If isEmpresa Then
            Call ERRORS.ERR_FALTA_EMPRESA_SOLICITUT()
        ElseIf isProjecte Then
            Call ERRORS.ERR_FALTA_PROJECTE_SOLICITUT()
        Else
            isUnload = False
            Me.Hide()
        End If
    End Sub

    Private Sub cmdCancelar_Click(sender As Object, e As EventArgs) Handles cmdCancelar.Click
        Me.Hide()
    End Sub

    Private Sub cmdEscollirEmpresa_Click(sender As Object, e As EventArgs) Handles cmdEscollirEmpresa.Click
        Dim p As Empresa
        p = DAuxiliars.getEmpresa
        If Not p Is Nothing Then
            If p.id > 0 Then
                empresaActual = p
                solicitutActual.empresa = p.codi
                Call setData()
            End If
        End If
        p = Nothing
    End Sub

    Private Sub cmdEscollirProjecte_Click(sender As Object, e As EventArgs) Handles cmdEscollirProjecte.Click
        Dim p As Projecte
        p = DAuxiliars.getProjecte
        If Not p Is Nothing Then
            If p.id > 0 Then
                projecteActual = p
                solicitutActual.codiProjecte = p.codi
                Call setData()
            End If
        End If
        p = Nothing
    End Sub

End Class
