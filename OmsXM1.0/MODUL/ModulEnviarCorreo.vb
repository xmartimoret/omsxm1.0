Imports MAIL = Microsoft.Office.Interop.Outlook
Module ModulEnviarCorreo
    Public Function enviarCorreu(adjunt As String, titol As String, c As Comanda, Pdesti As String, Optional adjunt1 As String = "") As Boolean
        Dim objOutlook As MAIL.Application
        Dim objSession As MAIL.NameSpace
        Dim objMessage As MAIL.MailItem
        Dim objCorreo As MAIL.Account
        Dim objRecipient As Object
        Dim desti As String
        'Dim AccountFrom As MAIL.Account
        On Error GoTo ERRFI

        objOutlook = CreateObject("Outlook.Application")
        objSession = objOutlook.GetNamespace("MAPI")
        objMessage = objOutlook.CreateItem(MAIL.OlItemType.olMailItem)
        desti = Pdesti
        objRecipient = objSession.CreateRecipient(desti)
        objSession.Logon()
        'AccountFrom = getAccountOutlook(objOutlook, CONFIG_FILE.getTag(CONFIG_FILE.TAG.CORREU_PREDETERMINAT))
        'If Not IsNothing(AccountFrom) Then objMessage.SendUsigAccount = AccountFrom
        If desti <> "" Then
            objMessage.Recipients.Add(desti)
        Else
            objMessage.Recipients.Add("compras@remondis.es")
        End If
        'objMessage.CC = CONFIG_RUTES.getCorreuCC
        objMessage.Subject = titol
        'objMessage.RTFBody
        'objMessage.Body = cos
        If CONFIG.fileExist(adjunt) Then objMessage.Attachments.Add(adjunt)

        If CONFIG.fileExist(adjunt1) Then objMessage.Attachments.Add(adjunt1)
        objMessage.HTMLBody = getCosMissatge(c) & vbCrLf & CONFIG_FILE.getTag(TAG.FIRMA_CORREU)
        ' objCorreo = getCorreuPredeterminat(objOutlook, CONFIG_FILE.getTag(TAG.CORREU_PREDETERMINAT)) : If Not IsNothing(objCorreo) Then objMessage.SendUsingAccount = objCorreo
        objMessage.Display()
        objSession.Logoff()

        objRecipient = Nothing
        objOutlook = Nothing
        objSession = Nothing
        objMessage = Nothing

        enviarCorreu = True
        Exit Function
ERRFI:
        Err.Clear()
        enviarCorreu = False
        objRecipient = Nothing
        objOutlook = Nothing
        objSession = Nothing
        objMessage = Nothing

    End Function

    Public Function enviarF56(adjunt As String, titol As String, Pdesti As String) As Boolean
        Dim objOutlook As MAIL.Application
        Dim objSession As MAIL.NameSpace
        Dim objMessage As MAIL.MailItem
        Dim objRecipient As Object
        Dim objOrigen As Object
        Dim objCorreo As MAIL.Account
        Dim desti As String
        On Error GoTo ERRFI

        objOutlook = CreateObject("Outlook.Application")
        objSession = objOutlook.GetNamespace("MAPI")

        objMessage = objOutlook.CreateItem(MAIL.OlItemType.olMailItem)
        desti = Pdesti
        objRecipient = objSession.CreateRecipient(desti)
        objOrigen = objSession.CreateRecipient("xmarti@oms-sacede.es")
        objSession.Logon()
        If desti <> "" Then
            objMessage.Recipients.Add(desti)
        Else
            objMessage.Recipients.Add("")
        End If
        objMessage.Subject = titol
        If CONFIG.fileExist(adjunt) Then objMessage.Attachments.Add(adjunt)
        objMessage.HTMLBody = getCosMissatgeF56()
        'objCorreo = getCorreuPredeterminat(objOutlook, CONFIG_FILE.getTag(TAG.CORREU_PREDETERMINAT)) : If Not IsNothing(objCorreo) Then objMessage.Sender.Address = objCorreo
        objMessage.Display()
        objSession.Logoff()
        objRecipient = Nothing
        objOutlook = Nothing
        objSession = Nothing
        objMessage = Nothing
        enviarF56 = True
        Exit Function
ERRFI:
        Err.Clear()
        enviarF56 = False
        objRecipient = Nothing
        objOutlook = Nothing
        objSession = Nothing
        objMessage = Nothing
    End Function
    Private Function getCosMissatge(c As Comanda)
        Dim t As String, a As articleComanda
        Dim r As String
        t = "<p>Buenos días, <br>adjunto pedido. </p> " &
            "<table width=""700"" border="" 0"">"
        c.articles = ModelArticleComandaEnEdicio.getObjects(c.id)
        r = "<tr> <th width = ""10%"" >" & IDIOMA.getString("quantitat") & " &nbsp;</td> " &
                    "<th width = ""10%"" >" & IDIOMA.getString("unitats") & " &nbsp;</td> " &
                    "<th width=""80%"" style=""text-align: left"">" & IDIOMA.getString("descripcio") & " &nbsp;</td> " &
                    " </tr>"
        '"<th width = ""10%"" >" & IDIOMA.getString("import") & " &nbsp;</td> " &
        '"<th width=""10&"">" & IDIOMA.getString("descompte") & " &nbsp;</td> " &
        '"<th width=""10%"">" & IDIOMA.getString("total") & " &nbsp;</td> " &

        t = t & r
        For Each a In c.articles
            r = "<tr> <td style=""text-align: right"">" & a.quantitat & " &nbsp;</td> " &
                    "<td style=""text-align: center"">" & a.unitat.codi & " &nbsp;</td> " &
                    "<td style=""text-align: left"">" & a.nom & " &nbsp;</td> " &
                    " </tr>"
            '"<td style=""text-align: right"" >" & Format(a.base, "#.##0,00 €") & " &nbsp;</td> " &
            '"<td style=""text-align: right"">" & Format(a.descompte, "#.##0,00 €") & " &nbsp;</td> " &
            '"<td style=""text-align: right"">" & Format(a.total, "#.##0,00 €") & " &nbsp;</td> " &


            t = t & r
        Next
        t = t & "</table>"
        Return t
    End Function
    Private Function getCosMissatgeF56() As String
        Dim t As String
        t = "<p>Buenos días, <br>adjunto formulario F56  actualizado. </p>  <div Class=""container"">" &
            " <p> Dpto de Compras</p>" &
            " <p> REMONDIS AGUA,  S.A.U.<br/>Consell de Cent,  445-449, Entlo. B // 08013 Barcelona // España<br/>T +34  932.214.748 <br /><a href = ""mailto:compras@REMONDIS.es"" > compras@remondis.es </a> </p>" &
            " <p> <img src = ""https://www.remondis-iberia.es/img/colors/blue/logo.png"" width=""181"" height=""57""></p>" &
            " <p> Nuestra información de protección de datos se puede encontrar  en el siguiente <a href=""https://www.remondis-iberia.es/en/privacidad.pdf""> " &
                " <strong> Link</strong></a><strong><u>.</u></strong>" &
                " <br> REMONDIS&nbsp;  AGUA, S.A.U // Consell de Cent, 445 - 449, Entlo.B // 8013 Barcelona // España  // N.I.F. A-08593345 // Inscrita Registro Mercantil  Barcelona // Folio 163 // Tomo 43.668 // Hoja 43388 // Inscripción 89 // Managing Director: Daniel Martínez  Mustienes" &
                " <br> A company Of the  REMONDIS Group </p> </div>"
        Return t
    End Function
    Private Function getCorreuPredeterminat(app As MAIL.Application, p As String) As MAIL.Account
        Dim comptes As MAIL.Accounts = app, ae As MAIL.AddressEntry
        Dim correu As MAIL.Account
        For Each correu In comptes
            If StrComp(correu.SmtpAddress, p, CompareMethod.Text) = 0 Then
                Return correu
            End If
        Next
        Return Nothing
    End Function
    'Private Function getAccountOutlook(ByVal application As MAIL.Application, ByVal smtpAddress As String) As MAIL.Account
    '    Dim accounts As MAIL.Accounts = application.Session.Accounts
    '    Dim account As MAIL.Account
    '    For Each account In accounts
    '        If account.SmtpAddress = smtpAddress Then
    '            Return account
    '        End If
    '    Next
    '    Return Nothing
    'End Function
End Module
