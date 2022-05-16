Public Class SelectFitxersSolicitut
    Inherits LVObjectsImport
    Friend Property fitxers As List(Of CodiDescripcio)
    Friend Event selectObject(fitxers As List(Of CodiDescripcio))

    Public Sub New(pAccio As Integer, pMultiselect As Boolean, parentForm As Boolean, Optional pTitol As String = "", Optional pOrdre As Integer = 0)
        Me.accio = pAccio
        Me.multiselect = pMultiselect
        Me.isForm = parentForm
        Me.orderColumn = 1
        fitxers = New List(Of CodiDescripcio)
    End Sub
    Public Sub New(pAccio As Integer, pMultiselect As Boolean, parentForm As Boolean, pFiltre As String, Optional pTitol As String = "", Optional pOrdre As Integer = 0)
        Me.accio = pAccio
        Me.multiselect = pMultiselect
        Me.isForm = parentForm
        Me.titol = pTitol
        Me.txtFiltrar.Text = pFiltre
        Me.orderColumn = 1
        fitxers = New List(Of CodiDescripcio)
    End Sub
    Public Overrides Function afegir(id As Integer) As Integer
        'aqui cal obrir la finestra per crear una nova comanda

        'no ens caldrà guardar la comanda o es una nova comanda que te vida per si sola.
        'ens caldrà posar un control de actualització cada vegada que s'activi la pestanya. (per si s'en guarda una de nova com si es valida una d'actualitzada
        ' Return save(DComanda.getComanda(New Comanda))
    End Function
    Public Overrides Function eliminar(id As Integer) As Boolean
        Dim ruta As String
        ruta = ModulImportSolicituds.getFitxer(id)
        If CONFIG.fileExist(ruta) Then
            If MISSATGES.CONFIRM_REMOVE_SOLICITUD_COMANDA(ruta) Then
                Return ModulImportSolicituds.remove(ruta)
            End If
        End If
        Return False
    End Function

    Public Overrides Function filtrar(txt As String) As DataList
        Return ModulImportSolicituds.getDataList(ModulImportSolicituds.getObjects, txt)
    End Function

    Public Overrides Function seleccionar(ids As List(Of Integer)) As Boolean
        Dim i As Integer, j As Integer
        fitxers = New List(Of CodiDescripcio)
        j = 0
        Call ModulImportSolicituds.reset()
        If ids.Count >= 0 Then
            For Each i In ids
                fitxers.Add(ModulImportSolicituds.getObject(i))
            Next
            RaiseEvent selectObject(fitxers)


            Return True
        End If
        Return False
    End Function
    Private Function save(obj As Comanda) As Integer
        Return False
    End Function
    Protected Overrides Sub Finalize()
        MyBase.Finalize()
        fitxers = Nothing
    End Sub

    Public Overrides Function filtrar(idParent As Integer, txt As String) As DataList
        Return Nothing
    End Function
End Class
