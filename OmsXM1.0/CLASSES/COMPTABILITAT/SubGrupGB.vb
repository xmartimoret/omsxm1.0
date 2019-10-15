Public Class SubGrupGB
    Inherits Base
    Private Property _formula As String
    Public Property toStringFormula As String
    Public Property esTotal As Boolean
    Public Property importValors As List(Of ImportMesSubgrup)
    Private form As List(Of CodiDescripcio)
    Public Sub New()
        _formula = ""
        _importValors = New List(Of ImportMesSubgrup)
        form = New List(Of CodiDescripcio)
    End Sub
    Public Sub New(pId As Integer, pCodi As String, pNom As String, pFormula As String)
        Me.id = pId
        Me.codi = pCodi
        Me.nom = pNom
        _formula = pFormula
        form = New List(Of CodiDescripcio)
        _importValors = New List(Of ImportMesSubgrup)
    End Sub
    Public Sub New(pId As Integer, pCodi As String, pNom As String, pFormula As String, pOrdre As String, pTotal As Boolean, pStringFormula As String)
        Me.id = pId
        Me.codi = pCodi
        Me.nom = pNom
        _formula = pFormula
        Me.ordre = pOrdre
        _esTotal = pTotal
        _toStringFormula = pStringFormula
        form = New List(Of CodiDescripcio)
        _importValors = New List(Of ImportMesSubgrup)
    End Sub
    Public ReadOnly Property copy() As SubGrupGB
        Get
            copy = New SubGrupGB
            copy.id = Me.id
            copy.codi = Me.codi
            copy.nom = Me.nom
            copy.ordre = Me.ordre
            copy.formula = _formula
            copy.esTotal = _esTotal
            copy.toStringFormula = _toStringFormula
            copy.notes = Me.notes
        End Get
    End Property
    Public Property formula() As String
        Get
            Return _formula
        End Get
        Set(value As String)
            _formula = value
            Call setForm(value)
        End Set
    End Property

    Private Sub setForm(p As String)
        Dim i As Integer, f As CodiDescripcio
        f = Nothing
        For i = 1 To p.Length
            If isOperator(Strings.Mid(p, i, 1)) Then
                If f IsNot Nothing Then
                    form.Add(f)
                End If
                f = New CodiDescripcio
                f.codi = Strings.Mid(p, i, 1)
            Else
                f.descripcio = f.descripcio & Mid(p, i, 1)
            End If
        Next
        If f IsNot Nothing Then
            form.Add(f)
        End If
        f = Nothing
    End Sub
    Private Function isOperator(t As String) As Boolean
        If t = "+" Or t = "-" Or t = "*" Or t = "/" Then Return True
        Return False
    End Function
    Public Function existsSubgrup(id As Integer) As Boolean
        Dim f As CodiDescripcio
        existsSubgrup = False
        For Each f In form
            If Val(f.descripcio) = id Then
                existsSubgrup = True
            End If
        Next
        f = Nothing
    End Function
    Public Function saldo(m As Integer, isAbsolut As Boolean, Optional tipus As Integer = 1) As Double
        Dim ims As ImportMesSubgrup, esOk As Boolean, imp As Double
        For Each ims In importValors
            If isAbsolut Then
                If ims.mes <= m Then esOk = True
            Else
                If ims.mes = m Then esOk = True
            End If
            If esOk Then
                Select Case getSigne(ims.idSubgrup)
                    Case "+" : imp = imp + ims.valor
                    Case "-" : imp = imp - ims.valor
                    Case "*" : imp = imp * ims.valor
                    Case "/" : imp = imp / ims.valor
                End Select
            End If
        Next
        ims = Nothing
        Return imp * tipus
    End Function
    Private Function getSigne(idSubcta As Integer) As String
        Dim c As CodiDescripcio
        getSigne = "+"
        For Each c In form
            If c.descripcio = idSubcta Then
                getSigne = c.codi
                Exit For
            End If
        Next
        c = Nothing
    End Function
    Protected Overrides Sub Finalize()
        _formula = Nothing
        MyBase.Finalize()
    End Sub
End Class
