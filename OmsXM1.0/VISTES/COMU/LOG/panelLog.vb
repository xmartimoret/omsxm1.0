Public Class panelLog
    Private logActual As Log
    Public Sub New(pLog As Log)
        InitializeComponent()
        logActual = pLog
        Dim sLogs As SelectLog
        sLogs = New SelectLog(logActual, "", 0)
        sLogs.Dock = DockStyle.Fill
        Me.Controls.Clear()
        Me.Controls.Add(sLogs)
        sLogs.Show()
    End Sub
End Class
