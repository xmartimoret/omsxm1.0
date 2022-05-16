Option Explicit On
Public Class frmAvis
    Private totalComptador As Long
    Public Sub New()
        InitializeComponent()
        Me.Text = IDIOMA.getString("esperaUnMoment")
        Me.lblTitol.Text = IDIOMA.getString("esperaUnMoment")
        Me.lblMissatge.Text = ""
        Me.lblComptador.Text = ""
        Me.pgBar.Visible = False
        Me.Show()
        Application.DoEvents()
    End Sub
    ''' <summary>
    ''' Inicialitza el Formulari Avis
    ''' </summary>
    ''' <param name="titolForm">Inicialitza el titol del formulari</param>
    Public Sub New(titolForm As String)
        InitializeComponent()
        Me.Text = titolForm
        Me.lblTitol.Text = ""
        Me.lblMissatge.Text = ""
        Me.lblComptador.Text = ""
        Me.pgBar.Visible = False
        Me.Show()
        Application.DoEvents()
    End Sub
    ''' <summary>
    ''' Inicialitza el Formulari Avis
    ''' </summary>
    ''' <param name="pTitolForm">Inicia el titol del Formulñari</param>
    ''' <param name="pTitolMissatge">Inicia el titol del misstage</param>
    ''' <param name="pMissatge">Inicia el missatge</param>
    Public Sub New(pTitolForm As String, pTitolMissatge As String, pMissatge As String)
        InitializeComponent()
        Me.Text = pTitolForm
        Me.lblTitol.Text = pTitolMissatge
        Me.lblMissatge.Text = pMissatge
        Me.lblComptador.Text = ""
        Me.pgBar.Visible = False
        Me.Show()
        Application.DoEvents()
    End Sub
    ''' <summary>
    ''' Inicialitza el Formulari Avis
    ''' </summary>
    ''' <param name="pTitolForm">Inicia el titol del Formulñari</param>
    ''' <param name="pTitolMissatge">Inicia el titol del misstage</param>
    ''' <param name="pMissatge">Inicia el missatge</param>
    Public Sub New(pTitolForm As String, pTitolMissatge As String, pMissatge As String, pTotalComptador As Long)
        InitializeComponent()
        Me.Text = pTitolForm
        Me.lblTitol.Text = pTitolMissatge
        Me.lblMissatge.Text = pMissatge
        Me.lblComptador.Text = ""
        Me.pgBar.Visible = True
        Me.pgBar.Minimum = 0
        Me.pgBar.Maximum = 100
        Me.totalComptador = pTotalComptador
        Me.Show()
        Application.DoEvents()
    End Sub
    ''' <summary>
    ''' Actualitza les dades del formulari
    ''' </summary>
    ''' <param name="pTitolMissatge">set LblTitol. Actualitza el titol del missatge</param>
    ''' <param name="missatge">set LblMissatge. Actualitza el missatge</param>
    ''' <param name="comptador">set lblComptador. Actualitza el comptador</param>
    Public Sub setData(pTitolMissatge As String, missatge As String, comptador As Long)
        Dim t As Double
        t = comptador * 100 / totalComptador
        If t >= pgBar.Minimum And t <= pgBar.Maximum Then
            pgBar.Value = t
        End If
        Me.lblComptador.Text = pgBar.Value & " %."
        Me.lblMissatge.Text = missatge
        Me.lblTitol.Text = pTitolMissatge
        Application.DoEvents()
        Me.Activate()
    End Sub
    Public Sub setData(pTitolMissatge As String, missatge As String)
        Me.lblComptador.Text = ""
        Me.lblMissatge.Text = missatge
        Me.lblTitol.Text = pTitolMissatge
        Application.DoEvents()
        Me.Activate()
    End Sub
    Public Sub setData(missatge As String, comptador As Long)
        Dim t As Double
        t = comptador * 100 / totalComptador
        If t >= pgBar.Minimum And t <= pgBar.Maximum Then
            pgBar.Value = t
        End If
        Me.lblComptador.Text = pgBar.Value & " %."
        Me.lblMissatge.Text = missatge
        Application.DoEvents()
        Me.Activate()
    End Sub
    ''' <summary>
    ''' Tanca el formulari Avis
    ''' </summary>
    Public Sub tancar()
        Me.Dispose()
    End Sub

End Class