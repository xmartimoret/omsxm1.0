Imports System

Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms

Public Class ButtonTab
    ' TODO: *** Comprobar si es Inherits o Implements ***
    Inherits System.Windows.Forms.TabControl

    ' Delegado para indicar cual es la pagina que hemos cerrado
    Public Delegate Function PreRemoveTab(indx As Integer) As Boolean
    ' Color Inicial del gradiente
    Private ColorInicial As Color
    ' Color Final del gradiente
    Private ColorFinal As Color
    ' Propiedad del color inicial del gradiente
    Public Property ColorInicialPagina() As Color
        Get
            Return ColorInicial
        End Get
        Set(value As Color)
            ColorInicial = value
            RepintarFichas()
        End Set

    End Property

    ' Propiedad del color final del gradiente
    Public Property ColorFinalPagina() As Color
        Get
            Return ColorFinal
        End Get
        Set(value As Color)
            ColorFinal = value
            RepintarFichas()
        End Set

    End Property

    Public PreRemoveTabPage As PreRemoveTab
    Public Sub New()
        PreRemoveTabPage = Nothing
        ' Le indicamos que vamos a dibajar de forma manual
        Me.DrawMode = TabDrawMode.OwnerDrawFixed
        RepintarFichas()

    End Sub

    Protected Overrides Sub OnDrawItem(e As DrawItemEventArgs)
        Dim r As Rectangle = e.Bounds
        Dim format1 As New StringFormat(StringFormatFlags.LineLimit)
        ' Cojemos el rectangulo cabezera de la ficha y creamos nuestro
        ' rectangulo donde pintaremos el boton X y el texto
        r = GetTabRect(e.Index)
        r.Offset(e.Bounds.Left + 2, 2)
        r.Width = 7
        r.Height = 7

        ' Creamos un pincel para dibujar la x que aparecera en la cabezera de la ficha
        Dim b As Brush = New SolidBrush(Color.Black)
        Dim p As New Pen(b)
        p.Color = Color.Red
        p.Width = 2

        ' Dibujamos la x que simulara el boton de cerrar ficha
        e.Graphics.DrawLine(p, r.X, r.Y, r.X + r.Width, r.Y + r.Height)
        e.Graphics.DrawLine(p, r.X + r.Width, r.Y, r.X, r.Y + r.Height)
        ' Pintamos tambien el texto de la ficha
        Dim titel As String = Me.TabPages(e.Index).Text
        Dim f As Font = Me.Font

        e.Graphics.DrawString(titel, f, b, New PointF(r.X + 10, r.Y), format1)

    End Sub

    Private Sub RepintarFichas()
        'For Each ctl As TabPage In Me.TabPages

        '    Dim gradPincel As LinearGradientBrush
        '    ' Creamos un pincel con las caracteristicas de tamaño de la ficha y con los colores especificados
        '    gradPincel = New LinearGradientBrush(New Point(0, 0), New Point(ctl.Width, ctl.Height), ColorInicialPagina, ColorFinalPagina)
        '    ' Creamos una imagen que es la que vamos a "pegar" encima de la ficha
        '    Dim bmp As New Bitmap(ctl.Width, ctl.Height)
        '    Dim g As Graphics = Graphics.FromImage(bmp)
        '    g.FillRectangle(gradPincel, New Rectangle(10, 4, ctl.Width, ctl.Height))
        '    ctl.BackgroundImage = bmp
        '    ' Expandimos la imagen para que ocupe toda la ficha siempre
        '    ctl.BackgroundImageLayout = ImageLayout.Stretch

        'Next

    End Sub

    Protected Overrides Sub OnMouseClick(e As MouseEventArgs)
        ' Obtenemos la posicion donde se ha pulsado el boton
        ' del raton
        Dim p As Point = e.Location
        For i As Integer = 0 To TabCount - 1
            ' Comprobamos para cada Tab si las coordenadas obtenidas
            ' en la pulsacion del raton estan contenidas dentro del
            ' "cuadrado" correspondiente a la x de la cabezera de la
            ' pestaña
            Dim r As Rectangle = GetTabRect(i)
            r.Offset(10, 4)
            r.Width = 7
            r.Height = 7
            If r.Contains(p) Then
                CloseTab(i)

            End If

        Next

    End Sub

    ' Cerramos la ficha que se haya pulsado
    Private Sub CloseTab(i As Integer)
        ' Si no hay ninguna pagina eliminada
        If PreRemoveTabPage IsNot Nothing Then
            ' Obtenemos si la pagina ha sido eliminada
            Dim closeIt As Boolean = PreRemoveTabPage(i)
            If Not closeIt Then
                Return
            End If

        End If
        ' Eliminamos la pagina
        TabPages.Remove(TabPages(i))

    End Sub

End Class

