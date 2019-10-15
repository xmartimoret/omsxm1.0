Option Explicit On
Public Class ProjecteDepartament : Implements IComparable
    Public Property idDepartament As Integer
    Public Property idProjecte As Integer
    Public Property codiProjecte As String
    Public Property nomProjecte As String
    Public Property subcomptes As List(Of SubcompteGrup)
    Public Property subcomptesNoActives As List(Of SubcompteGrup)
    Public Sub New()
        _subcomptes = New List(Of SubcompteGrup)
        _subcomptesNoActives = New List(Of SubcompteGrup)
    End Sub
    Public Sub setAssentament(a As Assentament)
        Dim sg As SubcompteGrup, trobat As Boolean, s As Subcompte
        trobat = False
        For Each sg In _subcomptes
            If a.subcompteAssentament = sg.codiSubcompte Then
                sg.assentaments.Add(a)
                trobat = True
                Exit For
            End If
        Next sg
        If Not trobat Then
            s = ModelSubcompte.getobject(a.subcompteAssentament)
            sg = New SubcompteGrup
            If TypeName(s) = "Subcompte" Then
                sg.codiSubcompte = s.codi
                sg.idSubcompte = s.id
                sg.nomSubcompte = s.nom
                sg.toStringSubcompte = s.ToString
                sg.assentaments.Add(a)
                _subcomptes.Add(sg)
            Else
                sg.codiSubcompte = a.subcompteAssentament
                sg.assentaments.Add(a)
                sg.toStringSubcompte = a.subcompteAssentament & " - SUBCOMPTE NO DONADA D'ALTA, EN EL SISTEMA"
                subcomptesNoActives.Add(sg)
            End If
        End If
        sg = Nothing
        s = Nothing
    End Sub
    Public ReadOnly Property deure() As Double
        Get
            Dim sg As SubcompteGrup, valor As EnterLlarg
            valor = New EnterLlarg
            For Each sg In _subcomptes
                valor.valordecimal = sg.deure
            Next sg
            For Each sg In _subcomptesNoActives
                valor.valordecimal = sg.deure
            Next sg
            deure = valor.valordecimal
            sg = Nothing
        End Get
    End Property
    Public ReadOnly Property haver() As Double
        Get
            Dim sg As SubcompteGrup, valor As EnterLlarg
            valor = New EnterLlarg
            For Each sg In _subcomptes
                valor.valordecimal = sg.haver
            Next sg
            For Each sg In _subcomptesNoActives
                valor.valordecimal = sg.haver
            Next sg
            haver = valor.valordecimal
            sg = Nothing
        End Get
    End Property
    Public ReadOnly Property saldo() As Double
        Get
            saldo = haver - deure
        End Get
    End Property
    Public Overrides Function toString() As String
        Return _codiProjecte & " - " & _nomProjecte
    End Function
    Protected Overrides Sub Finalize()
        _subcomptes = Nothing
        _subcomptesNoActives = Nothing
        MyBase.Finalize()
    End Sub

    Public Function CompareTo(obj As Object) As Integer Implements IComparable.CompareTo
        If obj Is Nothing OrElse Not Me.GetType Is obj.GetType Then Return -1
        Return StrComp(_codiProjecte, obj.codiProjecte)
    End Function
End Class
