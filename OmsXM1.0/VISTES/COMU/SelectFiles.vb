Public Class SelectFiles
    Friend Property fitxers As String()
    Friend Property fitxer As String
    Public Sub New()
        InitializeComponent()
        Me.FileDialog.Multiselect = True
        Me.FileDialog.ShowDialog()
        _fitxers = Me.FileDialog.FileNames
    End Sub
    Public Sub New(pTitol As String, pMultiselect As Boolean, pDirActual As String, pFiltre As String)
        InitializeComponent()
        Me.FileDialog.Title = pTitol
        Me.FileDialog.Multiselect = pMultiselect
        Me.FileDialog.Filter = pFiltre
        Me.FileDialog.FilterIndex = 1
        Me.FileDialog.InitialDirectory = pDirActual
        Me.FileDialog.ShowDialog()
        If pMultiselect Then
            _fitxers = Me.FileDialog.FileNames
        Else
            _fitxer = Me.FileDialog.FileName
        End If
    End Sub

End Class
