Public Class SelectDia

    Friend Property dataInferior As Date
    Friend Property dataSuperior As Date
    Private titolCalendari As String
    Friend Event selectObject(ByVal c As Date)

    Public Sub New()
        InitializeComponent()
        txtData.Text = ""
    End Sub
    Public Sub New(d As Date, Optional t As String = "")
        InitializeComponent()
        titolCalendari = t
        dataInferior = DateSerial(2000, 1, 1)
        dataSuperior = DateSerial(2100, 12, 31)
        If Year(d) > 1999 Then
            txtData.Text = Format(d, "dd-MM-yy")
        Else
            txtData.Text = ""
        End If
    End Sub
    Public Sub New(d As Date, dInferior As Date, dSuperior As Date, Optional t As String = "")
        InitializeComponent()
        dataInferior = dInferior
        dataSuperior = dSuperior
        titolCalendari = t
        If Year(d) > 1999 Then
            txtData.Text = Format(d, "dd-MM-yy")
        Else
            txtData.Text = ""
        End If
    End Sub
    Friend Sub setObjects(estat As Boolean)
        Me.cmdData.Enabled = estat
        Me.txtData.Enabled = estat
    End Sub
    Private Sub cmdData_Click(sender As Object, e As EventArgs) Handles cmdData.Click, txtData.DoubleClick
        Dim temp As Date
        If IsDate(txtData.Text) Then temp = CDate(txtData.Text)
        temp = Calendari.getDate(temp, _dataInferior, _dataSuperior, titolCalendari, IDIOMA.getIdioma)
        If temp >= DateSerial(1900, 1, 1) Then
            txtData.Text = Format(temp, "dd-MM-yy")
        End If
        temp = Nothing
    End Sub

    Private Sub txtData_TextChanged(sender As Object, e As EventArgs) Handles txtData.TextChanged
        If IsDate(txtData.Text) Then RaiseEvent selectObject(CDate(txtData.Text))
    End Sub

    Private Sub txtData_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtData.KeyPress
        If Asc(e.KeyChar) = 13 Or Asc(e.KeyChar) = 10 Then
            Dim temp As Date
            If IsDate(txtData.Text) Then temp = CDate(txtData.Text)
            temp = Calendari.getDate(temp, _dataInferior, _dataSuperior, titolCalendari, IDIOMA.getIdioma)
            If temp >= DateSerial(1900, 1, 1) Then
                txtData.Text = Format(temp, "dd-MM-yy")
            End If
            temp = Nothing
        Else
            e.KeyChar = VALIDAR.Data(e.KeyChar, txtData.Text, txtData.Text.Length, txtData.SelectionStart)
        End If

    End Sub
    Public Property dataActual As Date
        Get
            If IsDate(txtData.Text) Then Return CDate(Me.txtData.Text)
            Return Nothing
        End Get
        Set(value As Date)
            Me.txtData.Text = value
        End Set
    End Property


End Class
