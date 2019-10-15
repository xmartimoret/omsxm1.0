Public Class Directori
    Private descripcio As String
    Private multiselect As Boolean
    Private isFileSelection As Boolean
    Friend Event selectObject(ByVal c As String)
    ''' <summary>
    ''' Per seleccionar un directori. 
    ''' </summary>
    ''' <param name="pRuta">Ruta inicial, </param>    
    ''' <param name="pDescripcioCaption">titol que surt el diàleg </param>    
    Public Sub New(pRuta As String, pDescripcioCaption As String)
        InitializeComponent()
        Me.lblCaptionDirectori.Text = IDIOMA.getString("escollirDirectori")
        Me.lblDirectori.Text = pRuta
        isFileSelection = False
        descripcio = pDescripcioCaption
        Me.fileBrowser.Multiselect = False
        Me.cmdDirectori.Text = IDIOMA.getString("cmdDirectori")
    End Sub
    ''' <summary>
    ''' Per seleccionar un o varis fitxers,
    ''' </summary>
    ''' <param name="pRuta">Ruta inicial, </param>        
    ''' <param name="pCaption"></param>
    ''' <param name="pFiltre"></param>
    Public Sub New(pRuta As String, pCaption As String, pFiltre As String)
        InitializeComponent()
        Me.lblDirectori.Text = pRuta
        Me.lblDirectori.TextAlign = ContentAlignment.TopLeft
        isFileSelection = True
        Me.lblCaptionDirectori.Text = IDIOMA.getString("escollirFitxer")
        Me.fileBrowser.Multiselect = False
        Me.lblCaptionDirectori.Text = pCaption
        Me.fileBrowser.Filter = pFiltre
        Me.fileBrowser.FilterIndex = 1
        Me.cmdDirectori.Text = IDIOMA.getString("cmdDirectori")
    End Sub
    Private Sub cmdDirectori_Click(sender As Object, e As EventArgs) Handles cmdDirectori.Click
        If isFileSelection Then
            If CONFIG.folderExist(CONFIG.getDirectori(Me.lblDirectori.Text)) Then
                Me.fileBrowser.InitialDirectory = CONFIG.getDirectori(Me.lblDirectori.Text)
            End If
            Me.fileBrowser.ShowDialog()
            If CONFIG.fileExist(Me.fileBrowser.FileName) Then Me.lblDirectori.Text = Me.fileBrowser.FileName
        Else
            If CONFIG.folderExist(Me.lblDirectori.Text) Then
                Me.folderBrowser.Description = descripcio
                Me.folderBrowser.SelectedPath = Me.lblDirectori.Text
            End If
            Me.folderBrowser.ShowDialog()
            If CONFIG.folderExist(Me.folderBrowser.SelectedPath) Then Me.lblDirectori.Text = Me.folderBrowser.SelectedPath

        End If
        RaiseEvent selectObject(Me.lblDirectori.Text)
    End Sub

End Class
