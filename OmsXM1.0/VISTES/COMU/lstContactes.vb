Public Class lstContactes
    Private objects As Object()
    Friend Property obj As Object
    Private actualitzar As Boolean
    Friend Event selectObject()
    Private idProjecte As Integer
    Public Sub New(pObj As Object)
        ' This call is required by the designer.        
        obj = pObj
        idProjecte = -1
        InitializeComponent()
        actualitzar = True
        Call setData()

        Call validateControls()
        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Public Sub New(pObj As Object, pIdProjecte As Integer)
        ' This call is required by the designer.        
        obj = pObj
        idProjecte = pIdProjecte
        InitializeComponent()
        actualitzar = True
        Call setData()

        Call validateControls()
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub setData()
        cb.Items.Clear()
        If idProjecte = -1 Then
            cb.Items.AddRange(CONFIG.getListObjects(ModelContacte.getObjects()))
        Else
            cb.Items.AddRange(ModelContacte.getListObjects(ModelProjecteContacte.getObjects(idProjecte)))
        End If
        cb.SelectedItem = obj
        cmdAfegir.Select()
    End Sub
    Public Sub setObjects(estat As Boolean)
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
                If Not ModelProjecteContacte.exist(obj.idProjecte, obj.idcontacte) Then
                    If ModelProjecteContacte.save(obj) Then

                    End If
                Else
                    ERRORS.ERR_EXCEPTION_SQL(ExcepcioSql.ERR_EXIST_NOM_REGISTRE)
                End If
            End If
        End If
    End Sub
    Private Function saveContacte(obj As Object) As Integer
        Dim id As Integer
        id = -1
        If obj IsNot Nothing Then
            If Not obj Is Nothing Then
                If Not ModelContacte.exist(obj) Then
                    id = ModelContacte.save(obj)
                Else
                    ERRORS.ERR_EXCEPTION_SQL(ExcepcioSql.ERR_EXIST_NOM_REGISTRE)
                End If
            End If
        End If
        Return id
    End Function
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
        Dim temp As ProjecteContacte, lloc As Contacte
        lloc = DContacte.getContacte(New Contacte)
        If lloc IsNot Nothing Then
            obj = lloc
            obj.id = saveContacte(lloc)
            If obj.id > -1 Then
                temp = New ProjecteContacte(idProjecte, obj.id)
                Call save(temp)
                Call setData()
            End If
        End If
        temp = Nothing
    End Sub
    Private Sub lstAuxiliars1_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.ToolTip1.SetToolTip(cmdAfegir, IDIOMA.getString("afegirElementLlista"))
        Me.ToolTip1.SetToolTip(cmdModificar, IDIOMA.getString("modificarElementLlista"))
    End Sub

    Private Sub cmdModificar_Click(sender As Object, e As EventArgs) Handles cmdModificar.Click
        Dim temp As Object
        temp = DContacte.getContacte(obj)
        If temp IsNot Nothing Then
            'temp.idProjecte = idProjecte
            obj = temp
            Call saveContacte(temp)
            RaiseEvent selectObject()
        End If
        temp = Nothing
    End Sub
    Protected Overrides Sub Finalize()
        objects = Nothing
        obj = Nothing
        MyBase.Finalize()
    End Sub

End Class
