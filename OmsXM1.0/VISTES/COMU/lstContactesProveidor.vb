Public Class lstContactesProveidor
    Private objects As Object()
    Friend Property obj As Object
    Private actualitzar As Boolean
    Friend Event selectObject()
    Private idProveidor As Integer
    Public Sub New(pObj As Object, pIdProveidor As Integer)
        ' This call is required by the designer.        
        obj = pObj
        idProveidor = pIdProveidor
        InitializeComponent()
        actualitzar = True

        ' Add any initialization after the InitializeComponent() call.
    End Sub
    Private Sub setData()
        cb.Items.Clear()
        cb.Items.AddRange(CONFIG.getListObjects(ModelProveidorContacte.getObjects(idProveidor)))
        cb.SelectedItem = obj
        If cb.SelectedIndex = -1 Then
            If cb.Items.Count > 0 Then
                cb.SelectedIndex = 0
            End If
        End If
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
                If Not ModelProveidorContacte.exist(obj) Then
                    If ModelProveidorContacte.save(obj) Then
                        Call setData()
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
        temp = DProveidorContacte.getProveidor(New ProveidorCont)
        If temp IsNot Nothing Then
            temp.idproveidor = idProveidor
            obj = temp
            Call save(temp)
        End If
        temp = Nothing
    End Sub
    Private Sub lstAuxiliars1_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.ToolTip1.SetToolTip(cmdAfegir, IDIOMA.getString("afegirElementLlista"))
        Me.ToolTip1.SetToolTip(cmdModificar, IDIOMA.getString("modificarElementLlista"))
        Call setData()
        Call validateControls()
    End Sub

    Private Sub cmdModificar_Click(sender As Object, e As EventArgs) Handles cmdModificar.Click
        Dim temp As Object
        temp = DProveidorContacte.getProveidor(obj)
        If temp IsNot Nothing Then
            'temp.idproveidor = idProveidor
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
