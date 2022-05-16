Public Class lstProveidor
    Private objects As Object()
    Friend Property obj As Object
    Private actualitzar As Boolean
    Friend Event selectObject()


    Public Sub New(pObj As Object)
        obj = pObj
        InitializeComponent()
        actualitzar = True
        Call setData()

        Call validateControls()
        ' Add any initialization after the InitializeComponent() call.
    End Sub
    Private Sub setData()
        cb.Items.Clear()
        cb.Items.AddRange(CONFIG.getListObjects(ModelProveidor.getObjectsActius))
        cb.SelectedItem = obj
        cmdAfegir.Select()
    End Sub
    Public Sub setObjects(estat As Boolean)
        If estat = False Then cmdAfegir.Select()
        Me.cb.Enabled = estat
        Me.cmdAfegir.Enabled = estat
        Me.cmdModificar.Enabled = estat

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
                If Not ModelProveidor.exist(obj) Then
                    If Not ModelProveidor.existCodi(obj) Then
                        If ModelProveidor.save(obj) Then
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
        Else
            obj = Nothing
        End If
        RaiseEvent selectObject()
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
        temp = DProveidor.getProveidor(New Proveidor)
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
    Private Sub cmdModificar_Click(sender As Object, e As EventArgs) Handles cmdModificar.Click
        Dim temp As Object
        temp = DProveidor.getProveidor(obj)
        If temp IsNot Nothing Then
            obj = temp
            Call save(temp)
        End If
        temp = Nothing
    End Sub
    Protected Overrides Sub Finalize()
        objects = Nothing
        obj = Nothing
        MyBase.Finalize()
    End Sub


End Class
