Public Class lstAuxiliars1
    Private objects As Object()
    Private auxiliar As ModelAuxiliar
    Friend Property obj As Object
    Private actualitzar As Boolean
    Private titolNouElement As String
    Friend Event selectObject()
    ''' <summary>
    ''' Presenta una llista de dades d'un objecte determinat. 
    ''' Permet actualitzar la llista desdel mateix List BOX amb 
    ''' l'opció '+'
    ''' </summary>
    ''' <param name="pObj">L'objecte actual de la llista, si es nothing, 
    ''' selecciona cap objectre</param>
    ''' <param name="pTaulaDades">Taula de la base de dades d'on agafa les dades</param>
    Public Sub New(pObj As Object, pTaulaDades As String)
        ' This call is required by the designer.
        auxiliar = New ModelAuxiliar(pTaulaDades)
        titolNouElement = ""
        obj = pObj
        InitializeComponent()
        actualitzar = True
        Call setData()
        Call validateControls()
        ' Add any initialization after the InitializeComponent() call.
    End Sub

    ''' <summary>
    ''' Presenta una llista de dades d'un objecte determinat. 
    ''' Permet actualitzar la llista desdel mateix List BOX amb 
    ''' l'opció '+'
    ''' </summary>
    ''' <param name="pObj">L'objecte actual de la llista, si es nothing, 
    ''' selecciona cap objectre</param>
    ''' <param name="pTaulaDades">Taula de la base de dades d'on agafa les dades</param>
    ''' <param name="pTitol">posa titol al formulari de nou element</param>
    Public Sub New(pObj As Object, pTaulaDades As String, pTitol As String)
        ' This call is required by the designer.
        auxiliar = New ModelAuxiliar(pTaulaDades)
        titolNouElement = pTitol
        obj = pObj
        InitializeComponent()
        actualitzar = True
        Call setData()
        Call validateControls()
        ' Add any initialization after the InitializeComponent() call.
    End Sub
    Private Sub setData()
        cb.Items.Clear()
        cb.Items.AddRange(auxiliar.getListObjects)
        cb.SelectedItem = obj
        cmdAfegir.Select()
    End Sub
    Private Sub validateControls()
        If obj Is Nothing Then
            cmdModificar.Enabled = False
        Else
            cmdModificar.Enabled = True
        End If
    End Sub
    Private Sub save(obj As Object)
        If obj IsNot Nothing Then
            If Not obj Is Nothing Then
                If Not auxiliar.exist(obj) Then
                    If Not auxiliar.existCodi(obj) Then
                        If auxiliar.save(obj) Then
                            Call setData()
                        End If
                    Else
                        ERRORS.ERR_EXCEPTION_SQL(ExcepcioSql.ERR_EXIST_CODI_REGISTRE)
                    End If
                Else
                    ERRORS.ERR_EXCEPTION_SQL(ExcepcioSql.ERR_EXIST_NOM_REGISTRE)
                End If
            End If
        End If
    End Sub
    Private Sub cb_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb.SelectedIndexChanged
        If cb.SelectedIndex > -1 Then
            obj = cb.SelectedItem
            RaiseEvent selectObject()
        Else
            If cb.Items.Count > 0 Then cb.SelectedIndex = 0
        End If
        Call validateControls()
    End Sub
    Private Sub cb_TextChanged(sender As Object, e As EventArgs) Handles cb.TextChanged
        If actualitzar Then
            If cb.Text = "" Then
                obj = Nothing
                RaiseEvent selectObject()
                Call validateControls()
            End If
        End If
    End Sub
    Private Sub LblAfegir_Click(sender As Object, e As EventArgs) Handles cmdAfegir.Click
        Dim temp As Object
        Select Case auxiliar.taulaActual
            Case DBCONNECT.getTaulaPais
                temp = DPais.getPais(New Pais)
            Case DBCONNECT.getTaulaTipusIva
                temp = DTipusIva.gettipusIva(New TipusIva)
            Case DBCONNECT.getTaulaTipusPagament
                temp = DTipusPagament.gettipusPagament(New TipusPagament)
            Case DBCONNECT.getTaulaArticle
                temp = DArticle.getArticle(New article)
            Case DBCONNECT.getTaulaProveidor
                temp = DProveidor.getProveidor(New Proveidor)
            Case DBCONNECT.getTaulaUnitat
                temp = DAuxiliar.getobject(New Unitat, getTitol)
            Case DBCONNECT.getTaulaFabricant
                temp = DAuxiliar.getobject(New Fabricant, getTitol)
            Case Else
                temp = DAuxiliar.getobject(New Provincia, getTitol)
        End Select
        If temp IsNot Nothing Then
            obj = temp
            Call save(temp)
        End If
        temp = Nothing
    End Sub

    Private Sub lstAuxiliars1_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.ToolTip1.SetToolTip(cmdAfegir, IDIOMA.getString("afegirElementLlista"))
        Me.ToolTip1.SetToolTip(cmdModificar, IDIOMA.getString("modificarElementLlista"))
    End Sub
    Private Function getTitol()
        If titolNouElement = "" Then
            Return IDIOMA.getString("afegirNouElement")
        Else
            Return titolNouElement
        End If
    End Function
    Private Sub cmdModificar_Click(sender As Object, e As EventArgs) Handles cmdModificar.Click
        Dim temp As Object
        Select Case auxiliar.taulaActual
            Case DBCONNECT.getTaulaPais
                temp = DPais.getPais(obj)
            Case DBCONNECT.getTaulaTipusIva
                temp = DTipusIva.gettipusIva(obj)
            Case DBCONNECT.getTaulaTipusPagament
                temp = DTipusPagament.gettipusPagament(obj)
            Case DBCONNECT.getTaulaArticle
                temp = DArticle.getArticle(obj)
            Case DBCONNECT.getTaulaProveidor
                temp = DProveidor.getProveidor(obj)
            Case DBCONNECT.getTaulaUnitat
                temp = DAuxiliar.getobject(obj, getTitol)
            Case DBCONNECT.getTaulaFabricant
                temp = DAuxiliar.getobject(obj, getTitol)
            Case Else
                temp = DAuxiliar.getobject(obj, getTitol)
        End Select
        If temp IsNot Nothing Then
            obj = temp
            Call save(temp)
        End If
        temp = Nothing
    End Sub
    Protected Overrides Sub Finalize()
        auxiliar = Nothing
        objects = Nothing
        obj = Nothing
        MyBase.Finalize()
    End Sub
End Class