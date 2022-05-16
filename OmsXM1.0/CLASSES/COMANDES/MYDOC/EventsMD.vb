Public Class EventsMD : Implements IComparable
    Public Property id As Long
    Public Property finalitzat As Integer
    Public Property dataIni As Date
    Public Property dataFi As Date
    Public Property idUsuari As Integer
    Public Property idTasca As Integer
    Public Property idRecurs As Integer
    Public Property idTaula As Integer
    Public Property automatic As Integer

    Public Sub New()
        _id = -1
        _dataIni = Now
        _dataFi = Now
        _idUsuari = -1
    End Sub
    Public Sub New(pID As Long, pIdTasca As Integer, pIdRecurs As Integer, pIdTaula As Integer, pFinalitzat As Integer, pIdUsuari As Integer, pDataIni As Date, pDataFi As Date)
        _id = pID
        _idTasca = pIdTasca
        _idRecurs = pIdRecurs
        _idTaula = pIdTaula
        _finalitzat = pFinalitzat
        _idUsuari = pIdUsuari
        _dataIni = pDataIni
        _dataFi = pDataFi
    End Sub
    Public Sub New(pID As Long, pIdTasca As Integer, pIdRecurs As Integer, pIdTaula As Integer, pFinalitzat As Integer, pIdUsuari As Integer, pDataIni As Date, pDataFi As Date, pAutomatic As Integer)
        _id = pID
        _idTasca = pIdTasca
        _idRecurs = pIdRecurs
        _idTaula = pIdTaula
        _finalitzat = pFinalitzat
        _idUsuari = pIdUsuari
        _dataIni = pDataIni
        _dataFi = pDataFi
        _automatic = pAutomatic
    End Sub
    Public Overrides Function GetHashCode() As Integer
        Return _id
    End Function
    Public Overrides Function Equals(obj As Object) As Boolean
        If obj Is Nothing OrElse Not Me.GetType() Is obj.GetType Then Return False
        If _id = obj.id Then
            Return True
        End If
        Return False
    End Function
    Public Function CompareTo(obj As Object) As Integer Implements IComparable.CompareTo
        If obj Is Nothing OrElse Not Me.GetType Is obj.GetType Then Return -1
        If IsDate(_dataIni) And IsDate(obj.dataIni) Then
            If _dataIni < obj.dataIni Then
                Return -1
            ElseIf _dataIni > obj.DATAini Then
                Return 1
            Else
                Return 0
            End If
        Else
            Return 0
        End If
    End Function
End Class
