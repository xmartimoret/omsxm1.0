Public Class LstAuxiliars
    Private objects As List(Of Object)
    Private auxiliar As ModelAuxiliar
    Friend Property obj As Object
    Private actualitzar As Boolean
    Friend Event selectObject()

    Public Sub New(pObj As Object, pTaulaDades As String)
        ' This call is required by the designer.
        auxiliar = New ModelAuxiliar(pTaulaDades)
        objects = auxiliar.getObjects
        obj = pObj
        InitializeComponent()
        Me.Height = Me.txt.Height
        txt.Text = obj.ToString
        actualitzar = True

        ' Add any initialization after the InitializeComponent() call.
    End Sub
    Private Sub txt_Enter(sender As Object, e As EventArgs) Handles txt.Enter
        RaiseEvent selectObject()
    End Sub
    Private Sub txt_TextChanged(sender As Object, e As EventArgs) Handles txt.TextChanged, txt.Enter
        If actualitzar Then
            'If txt.Text.Length = 0 Then obj.id = 0 : obj.codi = "" : obj.nom = ""
            If lst.Items.Count = 1 Then
                obj = lst.Items(0)
                If obj IsNot Nothing Then
                    lst.Items.Clear()
                    setVisible(False)
                    actualitzar = False : txt.Text = obj.ToString : actualitzar = True
                End If
            Else
                Call setVisible(True)
                Call setData()
            End If

        Else
            Call setVisible(False)
            lst.Items.Clear()
        End If
        actualitzar = True
    End Sub
    Private Sub setVisible(isVisible As Boolean)
        If isVisible Then
            lst.Visible = True
            Me.Height = 200
            Me.Parent.Height = 200
        Else
            txt.Select()
            lst.Visible = False
            Me.Height = Me.txt.Height
            If Me.Parent IsNot Nothing Then Me.Parent.Height = Me.txt.Height
        End If
        Application.DoEvents()
    End Sub
    Private Sub setData()
        Dim d() As Object
        lst.Items.Clear()
        d = filtrar(txt.Text)
        If d IsNot Nothing Then lst.Items.AddRange(d)
    End Sub
    Private Function filtrar(f As String) As Object()
        Dim dades As List(Of Object), obj As Object, i As Integer = 0, d() As Object
        If objects IsNot Nothing Then
            dades = objects.FindAll(Function(x) UCase(Strings.Left(x.nom, f.Length)) = UCase(f))
            ReDim d(dades.Count - 1)
            For Each obj In dades
                d(i) = obj
                i = i + 1
            Next
            dades = Nothing
            Return d
        End If
        Return Nothing
    End Function

    Private Sub lst_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lst.MouseUp
        obj = lst.SelectedItem
        If obj IsNot Nothing Then
            setVisible(False)
            actualitzar = False : txt.Text = obj.ToString : actualitzar = True
        End If
    End Sub
    Private Sub lst_KeyDown(sender As Object, e As KeyEventArgs) Handles lst.KeyDown
        If e.KeyCode = 13 Then
            obj = lst.SelectedItem
            If obj IsNot Nothing Then
                setVisible(False)
                actualitzar = False : txt.Text = obj.ToString
            End If
        End If
    End Sub

    Private Sub txt_KeyDown(sender As Object, e As KeyEventArgs) Handles txt.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = 40 Or (e.KeyCode = 39 And txt.SelectionStart = txt.Text.Length) Then
            If lst.Visible Then
                lst.Select()
            End If
            'ElseIf e.KeyCode = Keys.Delete Or e.KeyCode = Keys.Back Then
            '    actualitzar = False
        End If
    End Sub
    Friend Sub reset()
        lst.Visible = False
        Me.Height = Me.txt.Height
        Me.Parent.Height = Me.txt.Height
        If obj Is Nothing Then
            actualitzar = False : txt.Text = ""
        End If
    End Sub

    Protected Overrides Sub Finalize()
        auxiliar = Nothing
        objects = Nothing
        obj = Nothing
        MyBase.Finalize()
    End Sub

    Private Sub lblNou_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblNou.LinkClicked
        Dim temp As Object, temp1 As Object
        Select Case auxiliar.taulaActual
            Case DBCONNECT.getTaulaPais
                temp = DPais.getPais(New Pais)
            Case DBCONNECT.getTaulaTipusIva
                temp = DTipusIva.gettipusIva(New TipusIva)
            Case DBCONNECT.getTaulaTipusPagament
                temp = DTipusPagament.gettipusPagament(New TipusPagament)
            Case Else
                temp1 = DAuxiliar.getobject(New Provincia, IDIOMA.getString("afegirProvincia"))
                If temp1 IsNot Nothing Then
                    temp = obj
                    temp.id = temp1.id
                    temp.codi = temp1.codi
                    temp.nom = temp1.nom
                Else
                    temp = Nothing
                End If
        End Select
        If temp IsNot Nothing Then
            obj = temp
            Call save(temp)
        End If
        temp = Nothing
        temp1 = Nothing
    End Sub

    Private Sub save(obj As Object)
        If obj IsNot Nothing Then
            If Not obj Is Nothing Then
                If Not auxiliar.exist(obj) Then
                    If Not auxiliar.existCodi(obj) Then
                        If auxiliar.save(obj) Then
                            objects.Add(obj)
                            Me.txt.Text = obj.nom
                            Me.txt.Select()
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

    Private Sub lst_LostFocus(sender As Object, e As EventArgs) Handles lst.LostFocus
        Call reset()
    End Sub


    Private Sub lst_Click(sender As Object, e As EventArgs) Handles lst.Click
        If lst.SelectedIndex = -1 Then lst.SelectedIndex = 0
        Call reset()
    End Sub

End Class
