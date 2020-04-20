'Imports outlook = Microsoft.Office.Interop.Outlook

'Module EMAIL

'    Public Sub setComandes()
'        Dim inBox As outlook.MAPIFolder
'        inBox = New outlook.MAPIFolder()
'    End Sub

'    '''
'    Dim otkInboxFolder As outlook.MAPIFolder = otkNameSpace.GetDefaultFolder(outlook.OlDefaultFolders.olFolderInbox)
'    Dim SubFolder = otkInboxFolder.Folders.Item * "TheSubfolderName")
'Dim otkMailItems As outlook.Items = SubFolder.Items
'    '''

'    Outlook.MAPIFolder inBox = this.Application.ActiveExplorer()
'        .Session.GetDefaultFolder(Outlook
'        .OlDefaultFolders.olFolderInbox);
'    Outlook.Items inBoxItems = inBox.Items;
'    Outlook.MailItem newEmail = null;
'    inBoxItems = inBoxItems.Restrict("[Unread] = true");
'    Try
'    {
'        foreach (object collectionItem in inBoxItems)
'        {
'            newEmail = collectionItem as Outlook.MailItem;
'            If (newEmail!= null)
'            {
'                If (newEmail.Attachments.Count > 0)
'                {
'                    For (int i = 1; i <= newEmail
'                       .Attachments.Count; i++)
'                    {
'                        newEmail.Attachments[i].SaveAsFile
'                            (@"C:\TestFileSave\" +
'                            newEmail.Attachments[i].FileName);
'                    }
'                }
'            }
'        }
'    }
'    Catch (Exception ex)
'    {
'        String errorInfo = (String)ex.Message
'            .Substring(0, 11);
'        If (errorInfo == "Cannot save")
'        {
'            MessageBox.Show(@"Create Folder C:\TestFileSave");
'        }
'    }
'End Module
