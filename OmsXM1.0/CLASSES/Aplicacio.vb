Option Explicit On
Imports XLS = Microsoft.Office.Interop.Excel
Public Class Aplicacio
    Inherits ComparadorOrdre
    Public Property dateOpen As Date
    Public Property dateUpdateGroup As Date
    Public Property dateUpdateProject As Date
    Public Property dateUpdateMesos As Date
    'TODO
    Public Property tipus As Integer
    Public Property wb As XLS.Workbook
    Public Property updateProject As Boolean
    Public Property updateGroup As Boolean
    Public Property updateMesos As Boolean
    Public Sub New()
        _updateProject = False
        _updateGroup = False
    End Sub
    Public ReadOnly Property path() As String
        Get
            Return CONFIG.setFolder(_wb.Path) & _wb.Name
        End Get
    End Property

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
        _wb = Nothing
    End Sub

End Class
