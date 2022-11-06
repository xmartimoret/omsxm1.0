Public Class pCercarComandes
    Private pFiltre As pFiltreComandes
    Private pComandes As SelectComandes
    Public Sub New()
        InitializeComponent()
        pFiltre = New pFiltreComandes
        pFiltre.Dock = DockStyle.Fill
        splitCercador.Panel1.Controls.Clear()
        splitCercador.Panel1.Controls.Add(pFiltre)
        AddHandler pFiltre.selectObjects, AddressOf setComandes
    End Sub

    Private Sub setComandes(comandes As List(Of Comanda))
        Dim P As New frmAvis(IDIOMA.getString("esperaUnMoment"), IDIOMA.getString("presentantComandes"), "")
        pComandes = New SelectComandes(IDIOMA.getString("comandes"), comandes)
        pComandes.Dock = DockStyle.Fill
        panelComandes.Controls.Clear()
        panelComandes.Controls.Add(pComandes)
        AddHandler pComandes.updateData, AddressOf setTotal
        AddHandler pComandes.selectObject, AddressOf getPdfComanda
        Call setTotal()
        pComandes.Show()
        P.tancar()
    End Sub
    Private Sub getPdfComanda(c As Comanda)
        Dim ruta As String

        If c.estat = 0 Then
            Call frmIniComanda.modificarComanda(c)
        Else
            ruta = CONFIG.getRutaComandaPDF(c.empresa.id, c.codi, Strings.Right(c.getAnyo, 2), c.estat)
            If CONFIG.fileExist(ruta) Then

                Call frmIniComanda.mostrarComanda(c, ruta)

            Else
                Call ERRORS.ERR_NO_FILE_COMANDA
            End If
        End If
    End Sub
    Private Sub setTotal()
        Dim c As ListViewItem, base As Double = 0, iva As Double = 0
        For Each c In pComandes.lstData.Items
            base = base + c.SubItems(8).Text
            iva = iva + c.SubItems(9).Text
        Next
        lblBase.Text = IDIOMA.getString("base") & ": " & Format(base, "#,##0.00 €")
        lblIva.Text = IDIOMA.getString("iva") & ": " & Format(iva, "#,##0.00 €")
        lblTotal.Text = IDIOMA.getString("total") & ": " & Format(base + iva, "#,##0.00  €")
        c = Nothing
    End Sub


    'Private Function getRutaPDF(idEmpresa As Integer, codi As String, anyo As String, e As Integer)
    '    Dim f As String, ruta As String, temp() As String
    '    If e = 2 Then
    '        ruta = CONFIG.getDirectoriPDFComandesEnviades(idEmpresa)
    '    Else
    '        ruta = CONFIG.getDirectoriPDFComandesEnValidacio()
    '    End If
    '    f = Dir(ruta & "*.pdf", FileAttribute.Archive)
    '    Do While f <> ""
    '        temp = Split(f, "-")
    '        If UBound(temp) > 0 Then
    '            If Strings.Right(Val(temp(0)), 2) = anyo Then
    '                If Val(temp(1)) = Val(codi) Then
    '                    If Val(temp(3)) = idEmpresa Then
    '                        Return ruta & f
    '                    End If
    '                End If
    '                End If
    '        End If
    '        f = Dir()
    '    Loop
    '    Return ""
    'End Function


End Class
