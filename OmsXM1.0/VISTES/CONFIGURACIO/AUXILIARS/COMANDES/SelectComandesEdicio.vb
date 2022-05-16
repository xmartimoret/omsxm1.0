Public Class SelectComandesEdicio
    Inherits LVObjects
    Friend Property dades As DataList
    Friend Property comandes As List(Of Comanda)
    Friend Event selectObject(p As Comanda)

    Public Sub New(pAccio As Integer, pMultiselect As Boolean, parentForm As Boolean, Optional pTitol As String = "", Optional pOrdre As Integer = 0)
        Me.accio = pAccio
        Me.multiselect = pMultiselect
        Me.isForm = parentForm
        Me.titol = pTitol
        Me.orderColumn = 1
        comandes = New List(Of Comanda)
    End Sub
    Public Sub New(pAccio As Integer, pMultiselect As Boolean, parentForm As Boolean, pFiltre As String, Optional pTitol As String = "", Optional pOrdre As Integer = 0)
        Me.accio = pAccio
        Me.multiselect = pMultiselect
        Me.isForm = parentForm
        Me.titol = pTitol
        Me.txtFiltrar.Text = pFiltre
        Me.orderColumn = 1
        comandes = New List(Of Comanda)
    End Sub
    Public Overrides Function afegir(id As Integer) As Integer

        Return -1
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
        dades = ModelComandaEnEdicio.getDataList(ModelComandaEnEdicio.getObjects(0, txt))
        Return dades
    End Function

    Public Overrides Function modificar(id As Integer) As Integer
        Call frmIniComanda.modificarComanda(ModelComandaEnEdicio.getObject(id))
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
        Call ModulInfoAuxiliar.infoComandes(Me.listOrdered, pdf, IDIOMA.getString("comandesEnEdicio"), filtre)
    End Sub
    Public Overrides Sub actualitzar(id As List(Of Integer))

    End Sub
    Public Overrides Sub toolTipText(id As Integer)

    End Sub
    Public Overrides Sub guardarCopia(id As Integer)
        Call ERRORS.EN_CONSTRUCCIO()
    End Sub
End Class



