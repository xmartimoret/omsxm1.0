Option Explicit On
Public Class avis
    Public Sub New()
        InitializeComponent()
        lblAvis.Text = IDIOMA.getString("campObligatori")
        Picture.Image = listImage.Images.Item(0)
        lblAvis.ForeColor = Color.Red
    End Sub
    Public Sub New(isOk As Boolean, pText As String)
        InitializeComponent()
        lblAvis.Text = pText
        If isOk Then
            Picture.Image = listImage.Images.Item(1)
            lblAvis.ForeColor = Color.Green
        Else
            Picture.Image = listImage.Images.Item(0)
            lblAvis.ForeColor = Color.Red
        End If
    End Sub

    Private Sub lblAvis_Click(sender As Object, e As EventArgs) Handles lblAvis.Click

    End Sub
End Class
