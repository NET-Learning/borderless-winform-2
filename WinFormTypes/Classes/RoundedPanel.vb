Imports System.ComponentModel
Imports System.Drawing.Drawing2D
Imports System.Runtime.InteropServices

Public Class RoundedPanel
    Inherits Panel

    Private pen As Pen = New Pen(_borderColor, penWidth)
    Private Shared ReadOnly penWidth As Single = 5.5F

#Region "SET SHADOW EFFECT"
    Protected Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Const CS_DROPSHADOW As Int32 = &H20000
            Dim cp As CreateParams = MyBase.CreateParams
            If myDropShadow AndAlso Not Me.DesignMode Then
                cp.ClassStyle = cp.ClassStyle Or CS_DROPSHADOW
            Else
                cp.ClassStyle = cp.ClassStyle And Not CS_DROPSHADOW
            End If
            Return cp
        End Get
    End Property
#End Region

    Public Sub New()

    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        MyBase.OnPaint(e)
        ExtendedDraw(e)
        DrawBorder(e.Graphics)
    End Sub

    Private myDropShadow As Boolean = False
    <Browsable(True)>
    <Category("Appearance")>
    Public Property DropShadow As Boolean
        Get
            Return myDropShadow
        End Get
        Set(ByVal Value As Boolean)
            myDropShadow = Value
        End Set
    End Property

    Private _borderColor As Color = Color.White
    <Browsable(True)>
    <Category("Appearance")>
    Public Property BorderColor As Color
        Get
            Return _borderColor
        End Get
        Set(ByVal Value As Color)
            _borderColor = Value
            pen = New Pen(_borderColor, penWidth)
            Invalidate()
        End Set
    End Property

    Private _edge As Integer = 25
    <Browsable(True)>
    <Category("Appearance")>
    Public Property BorderRadius As Integer
        Get
            Return _edge
        End Get
        Set(ByVal Value As Integer)
            _edge = Value
            'Invalidate()
        End Set
    End Property


    Private Function GetLeftUpper(ByVal e As Integer) As Rectangle
        Return New Rectangle(0, 0, e, e)
    End Function

    Private Function GetRightUpper(ByVal e As Integer) As Rectangle
        Return New Rectangle(Width - e, 0, e, e)
    End Function

    Private Function GetRightLower(ByVal e As Integer) As Rectangle
        Return New Rectangle(Width - e, Height - e, e, e)
    End Function

    Private Function GetLeftLower(ByVal e As Integer) As Rectangle
        Return New Rectangle(0, Height - e, e, e)
    End Function

    Private Sub ExtendedDraw(ByVal e As PaintEventArgs)
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
        Dim path As GraphicsPath = New GraphicsPath()
        path.StartFigure()
        path.StartFigure()
        path.AddArc(GetLeftUpper(BorderRadius), 180, 90)
        path.AddLine(BorderRadius, 0, Width - BorderRadius, 0)
        path.AddArc(GetRightUpper(BorderRadius), 270, 90)
        path.AddLine(Width, BorderRadius, Width, Height - BorderRadius)
        path.AddArc(GetRightLower(BorderRadius), 0, 90)
        path.AddLine(Width - BorderRadius, Height, BorderRadius, Height)
        path.AddArc(GetLeftLower(BorderRadius), 90, 90)
        path.AddLine(0, Height - BorderRadius, 0, BorderRadius)
        path.CloseFigure()
        Region = New Region(path)
    End Sub

    Private Sub DrawSingleBorder(ByVal graphics As Graphics)
        graphics.DrawArc(pen, New Rectangle(0, 0, BorderRadius, BorderRadius), 180, 90)
        graphics.DrawArc(pen, New Rectangle(Width - BorderRadius - 1, -1, BorderRadius, BorderRadius), 270, 90)
        graphics.DrawArc(pen, New Rectangle(Width - BorderRadius - 1, Height - BorderRadius - 1, BorderRadius, BorderRadius), 0, 90)
        graphics.DrawArc(pen, New Rectangle(0, Height - BorderRadius - 1, BorderRadius, BorderRadius), 90, 90)
        graphics.DrawRectangle(pen, 0.0F, 0.0F, CType((Width - 1), Single), CType((Height - 1), Single))
    End Sub

    Private Sub DrawBorder(ByVal graphics As Graphics)
        DrawSingleBorder(graphics)
    End Sub

End Class
