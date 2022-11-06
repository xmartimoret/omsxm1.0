Public Class SelectComandesEnValidacio
    Inherits LVObjects
    Friend Property comandes As List(Of Comanda)
    Friend Event selectObject(p As Comanda)

    Public Sub New(pAccio As Integer, pMultiselect As Boolean, parentForm As Boolean, Optional pTitol As String = "", Optional pOrdre As Integer = 3)
        Me.accio = pAccio
        Me.multiselect = pMultiselect
        Me.isForm = parentForm
        Me.titol = pTitol
        Me.orderColumn = pOrdre
        comandes = New List(Of Comanda)
        Me.mnuContextual.Items(0).Text = IDIOMA.getString("enviarComanda")
        Me.mnuContextual.Items(1).Text = IDIOMA.getString("tancarComanda")

    End Sub
    Public Sub New(pAccio As Integer, pMultiselect As Boolean, parentForm As Boolean, pFiltre As String, Optional pTitol As String = "", Optional pOrdre As Integer = 3)
        Me.accio = pAccio
        Me.multiselect = pMultiselect
        Me.isForm = parentForm
        Me.titol = pTitol
        Me.txtFiltrar.Text = pFiltre
        Me.orderColumn = pOrdre
        comandes = New List(Of Comanda)
        Me.mnuContextual.Items(0).Text = IDIOMA.getString("enviarComanda")
        Me.mnuContextual.Items(1).Text = IDIOMA.getString("tancarComanda")
    End Sub
    Public Overrides Function afegir(id As Integer) As Integer
        Dim d As Comanda, rutaFitxer As String, result As Integer

        d = ModelComandaEnEdicio.getObject(id)
        If Not IsNothing(d) Then
            rutaFitxer = CONFIG.getDirectoriPDFComandesEnValidacio & d.getCodi & ".pdf"
            If CONFIG.fileExist(rutaFitxer) Then

                result = ModelComandaEnEdicio.enviarComanda(d, rutaFitxer)
                If result = 1 Then
                    frmIniComanda.updateComandesEnviades()
                    frmIniComanda.refreshTabActual()
                ElseIf result = 0 Then
                    frmIniComanda.updateComandesEnviades()
                    frmIniComanda.refreshTabActual()
                End If
            End If
        End If

    End Function
    Public Overrides Function eliminar(id As Integer) As Boolean
        Dim d As Comanda
        d = ModelComandaEnEdicio.getObject(id)
        If d IsNot Nothing Then
            If MISSATGES.CONFIRM_PENDENT_REMOVE_COMANDA() Then
                If ModelComandaEnEdicio.aBassura(d) Then
                    Call frmIniComanda.updatecomanda()
                    Call frmIniComanda.updateComandaEliminacio()
                    Return True
                End If
            End If
            End If
        Return False
    End Function

    Public Overrides Function filtrar(txt As String) As DataList
        Call ModelPedidosMydoc.resetIndex()
        Call ModelEventsMyDOc.resetIndex()
        Return ModelComandaEnEdicio.getDataList(ModelComandaEnEdicio.getObjects(1, txt))
    End Function

    Public Overrides Function modificar(id As Integer) As Integer
        Call frmIniComanda.mostrarComandaValidacio(ModelComandaEnEdicio.getObject(id))
        Return id
    End Function

    Public Overrides Function seleccionar(ids As List(Of Integer)) As Boolean
        Dim i As Integer, j As Integer
        comandes = New List(Of Comanda)
        j = 0
        If ids.Count >= 0 Then
            For Each i In ids
                comandes.Add(ModelComandaEnEdicio.getObject(i))
            Next
            RaiseEvent selectObject(comandes.Item(0))
            Return True
        End If
        Return False
    End Function
    Private Function save(obj As Comanda) As Integer
        If Not obj Is Nothing Then
            If Not ModelComandaEnEdicio.exist(obj) Then
                If Not ModelComandaEnEdicio.existCodi(obj) Then
                    RaiseEvent selectObject(obj)
                    Return ModelComandaEnEdicio.save(obj)
                Else
                    Throw New ExcepcioSql(ExcepcioSql.ERR_EXIST_CODI_REGISTRE)
                End If
            Else
                Throw New ExcepcioSql(ExcepcioSql.ERR_EXIST_NOM_REGISTRE)
            End If
        End If
        Return False
    End Function
    Protected Overrides Sub Finalize()
        MyBase.Finalize()
        comandes = Nothing
    End Sub

    Public Overrides Function filtrar(idParent As Integer, txt As String) As DataList
        Return Nothing
    End Function

    Public Overrides Function getRow(id As Integer) As ListViewItem
        Return ModelComandaEnEdicio.getListViewItem(id)
    End Function

    Public Overrides Sub imprimir(pdf As Boolean, filtre As String)
        Call ModulInfoAuxiliar.infoComandes(Me.listOrdered, pdf, IDIOMA.getString("comandesEnValidacio"), filtre)
    End Sub
    Public Overrides Sub actualitzar(ids As List(Of Integer))
        Dim d As Comanda, rutaFitxer As String, result As Integer, id As Integer, f As frmAvis, i As Integer
        If MISSATGES.CONFIRM_SEND_COMANDES Then
            i = 1
            f = New frmAvis(IDIOMA.getString("actualitzantDades"), IDIOMA.getString("guardantComanda"), IDIOMA.getString(""), ids.Count)
            For Each id In ids
                d = ModelComandaEnEdicio.getObject(id)
                If Not IsNothing(d) Then
                    f.setData(d.ToString, i & " " & IDIOMA.getString("de") & " " & ids.Count)
                    rutaFitxer = CONFIG.getDirectoriPDFComandesEnValidacio & d.getCodi & ".pdf"
                    If CONFIG.fileExist(rutaFitxer) Then
                        result = ModelComandaEnEdicio.passarAEnviada(d, rutaFitxer)
                    End If
                    i = i + 1
                End If
            Next id
            f.tancar()
            frmIniComanda.updateComandesEnviades()
            frmIniComanda.refreshTabActual()
        End If
        f = Nothing
        d = Nothing
    End Sub

    Public Overrides Sub guardarCopia(id As Integer)
        Dim rutaFitxer As String, c As Comanda, rutaExport As String
        c = ModelComandaEnEdicio.getObject(id)
        If Not IsNothing(c) Then
            rutaFitxer = CONFIG.getDirectoriPDFComandesEnValidacio & c.getCodi & ".pdf"
            If CONFIG.fileExist(rutaFitxer) Then
                rutaExport = CONFIG.getRutaEmpresaComandesPDF(c.empresa.nom, c.getAnyo)
                If CONFIG.folderExist(rutaExport) Then
                    rutaExport = CONFIG.setFolder(rutaExport) & c.toStingNomComanda & ".pdf"
                    FileCopy(rutaFitxer, rutaExport)
                    MISSATGES.COMANDA_GUARDADA(rutaExport)

                End If
            End If
        End If
        c = Nothing
    End Sub

    Public Overrides Sub toolTipText(id As Integer)

    End Sub
End Class
