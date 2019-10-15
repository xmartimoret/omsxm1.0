Option Explicit On
Public Class frmAvis
    Public Sub New()
        InitializeComponent()
        Me.Text = IDIOMA.getString("esperar_moment")
        Me.lblTitol.Text = IDIOMA.getString("esperar_moment")
        Me.lblMissatge.Text = ""
        Me.lblComptador.Text = ""
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
        Me.lblMissatge.Text = pTitolMissatge
        Me.lblComptador.Text = ""
        Me.Show()
        Application.DoEvents()
    End Sub
    ''' <summary>
    ''' Actualitza les dades del formulari
    ''' </summary>
    ''' <param name="pTitolMissatge">set LblTitol. Actualitza el titol del missatge</param>
    ''' <param name="missatge">set LblMissatge. Actualitza el missatge</param>
    ''' <param name="comptador">set lblComptador. Actualitza el comptador</param>
    Public Sub setData(pTitolMissatge As String, missatge As String, comptador As String)
        Me.lblComptador.Text = comptador
        Me.lblMissatge.Text = missatge
        Me.lblTitol.Text = pTitolMissatge
        Application.DoEvents()
    End Sub
    ''' <summary>
    ''' Tanca el formulari Avis
    ''' </summary>
    Public Sub tancar()
        Me.Dispose()
    End Sub

End Class