Option Explicit On
Public Class SelectContactes
    Inherits LVObjects
    Friend Property contactes As List(Of Contacte)
    Friend Event selectObject(p As Contacte)
    Public Sub New(pAccio As Integer, pMultiselect As Boolean, parentForm As Boolean, Optional pTitol As String = "", Optional pOrdre As Integer = 0)
        Me.accio = pAccio
        Me.multiselect = pMultiselect
        Me.isForm = parentForm
        Me.titol = pTitol
        Me.orderColumn = 0
        contactes = New List(Of Contacte)
    End Sub
    Public Overrides Function afegir(id As Integer) As Integer
        Return save(DContacte.getContacte(New Contacte))
    End Function
    Public Overrides Function eliminar(id As Integer) As Boolean
        Dim d As Contacte
        d = ModelContacte.getObject(id)
        If d IsNot Nothing Then
            If ModelComanda.existObject(id, New Contacte) Then
                If MISSATGES.CONFIRM_NO_REMOVE_DOWN_OBJECT(UCase(IDIOMA.getString("elContacte"))) Then
                    d.actiu = False
                    Call ModelContacte.save(d)
                End If
            ElseIf ModelComandaEnEdicio.existObject(id, New CONTACTE) Then
                If MISSATGES.CONFIRM_NO_REMOVE_DOWN_OBJECT(UCase(IDIOMA.getString("elContacte"))) Then
                    d.actiu = False
                    Call ModelContacte.save(d)
                End If

            ElseIf ModelProjecteContacte.existContacte(id) Then
                If MISSATGES.CONFIRM_NO_REMOVE_DOWN_OBJECT_CONTACTE(UCase(IDIOMA.getString("elContacte"))) Then
                    d.actiu = False
                    Call ModelContacte.save(d)
                End If
            ElseIf MISSATGES.CONFIRM_REMOVE_CONTACTE(d.tostring) Then
                Return ModelContacte.remove(d)
            End If
        End If
        Return False
    End Function

    Public Overrides Function filtrar(txt As String) As DataList
        Return ModelContacte.getDataList(ModelContacte.getObjects(txt))
    End Function

    Public Overrides Function modificar(id As Integer) As Integer
        Return save(DContacte.getContacte(ModelContacte.getObject(id)))
    End Function

    Public Overrides Function seleccionar(ids As List(Of Integer)) As Boolean
        Dim i As Integer, j As Integer
        contactes = New List(Of Contacte)
        j = 0
        If ids.Count >= 0 Then
            For Each i In ids
                contactes.Add(ModelContacte.getObject(i))
            Next
            RaiseEvent selectObject(contactes.Item(0))
            Return True
        End If
        Return False
    End Function
    Private Function save(obj As Contacte) As Integer
        If Not obj Is Nothing Then
            If Not ModelContacte.exist(obj) Then
                RaiseEvent selectObject(obj)
                Return ModelContacte.save(obj)
            Else
                ERRORS.ERR_EXIST_NAME_CONTACTE
            End If
        End If
        Return False
    End Function
    Protected Overrides Sub Finalize()
        MyBase.Finalize()
        contactes = Nothing
    End Sub

    Public Overrides Function filtrar(idParent As Integer, txt As String) As DataList
        Return Nothing
    End Function

    Public Overrides Function getRow(id As Integer) As ListViewItem
        Return ModelContacte.getListViewItem(id)
    End Function
    Public Overrides Sub imprimir(pdf As Boolean, filtre As String)
        'Dim tPrint As TipusImpressio
        'tPrint = DPrint.getTipusImpresio
        'If tPrint IsNot Nothing Then
        '    If tPrint.isRegistreActual Then
        '        Call ERRORS.ERR_FITXER_OBERT()
        '    Else
        '        Call modulInfoProveidor.execute(proveidorsActuals, tPrint.rutaInforme, Not tPrint.isExcel)
        '    End If

        'End If

    End Sub
    Public Overrides Sub actualitzar(id As List(Of Integer))
    End Sub
    Public Overrides Sub toolTipText(id As Integer)

    End Sub
    Public Overrides Sub guardarCopia(id As Integer)
        Call ERRORS.EN_CONSTRUCCIO()
    End Sub
End Class

