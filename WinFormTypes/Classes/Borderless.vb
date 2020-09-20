Imports System.Runtime.InteropServices

Public Class Borderless
    Inherits Form

#Region "PARAMETERS"
    ' Params
    Private IsFormMoving As Boolean = False
    Private MouseX As Integer
    Private MouseY As Integer
    Private Const CS_DROPSHADOW As Integer = 131072
    Public HTLEFT As Integer = 10
    Public HTRIGHT As Integer = 11
    Public HTTOP As Integer = 12
    Public HTTOPLEFT As Integer = 13
    Public HTTOPRIGHT As Integer = 14
    Public HTBOTTOM As Integer = 15
    Public HTBOTTOMLEFT As Integer = 16
    Public HTBOTTOMRIGHT As Integer = 17
    Public ImaginaryBorderSize As Integer = 5
#End Region

#Region "DEFAULT CONSTRUCTOR"
    ' New
    Sub New(ByVal frmOwner As Control)
        ' Loads
        Me.DoubleBuffered = True
        Me.Owner = frmOwner
        Call SetBorderless(frmOwner)
    End Sub
#End Region

#Region "BORDERLESS MOVE EVENTS"
    '/* BORDERLESS EVENTS */
    Public Sub BorderlessMouseDown(ByVal frmOwner As Object, mva As MouseEventArgs)
        'If ...
        If mva.Button = MouseButtons.Left Then
            ' Change values
            Me.IsFormMoving = True
            Me.MouseX = Cursor.Position.X - frmOwner.Left
            Me.MouseY = Cursor.Position.Y - frmOwner.Top
        End If
    End Sub
    Public Sub BorderlessMouseMove(ByVal frmOwner As Object, mva As MouseEventArgs)
        'If ...
        If Me.IsFormMoving = True Then
            ' Change values
            frmOwner.Left = Cursor.Position.X - Me.MouseX
            frmOwner.Top = Cursor.Position.Y - Me.MouseY
        End If
    End Sub
    Public Sub BorderlessMouseUp(ByVal frmOwner As Object, mva As MouseEventArgs)
        ' Change values
        Me.IsFormMoving = False
    End Sub
#End Region

#Region "RESIZE EVENTS"
    Function TopY(ByVal frmOwner As Form) As Rectangle
        Return New Rectangle(0, 0, frmOwner.ClientSize.Width, ImaginaryBorderSize)
    End Function

    Function LeftX(ByVal frmOwner As Form) As Rectangle
        Return New Rectangle(0, 0, ImaginaryBorderSize, frmOwner.ClientSize.Height)
    End Function

    Function BottomY(ByVal frmOwner As Form) As Rectangle
        Return New Rectangle(0, frmOwner.ClientSize.Height - ImaginaryBorderSize, frmOwner.ClientSize.Width, ImaginaryBorderSize)
    End Function

    Function RightX(ByVal frmOwner As Form) As Rectangle
        Return New Rectangle(frmOwner.ClientSize.Width - ImaginaryBorderSize, 0, ImaginaryBorderSize, frmOwner.ClientSize.Height)
    End Function

    Function TopLeft() As Rectangle
        Return New Rectangle(0, 0, ImaginaryBorderSize, ImaginaryBorderSize)
    End Function

    Function TopRight(ByVal frmOwner As Form) As Rectangle
        Return New Rectangle(frmOwner.ClientSize.Width - ImaginaryBorderSize, 0, ImaginaryBorderSize, ImaginaryBorderSize)
    End Function

    Function BottomLeft(ByVal frmOwner As Form) As Rectangle
        Return New Rectangle(0, frmOwner.ClientSize.Height - ImaginaryBorderSize, ImaginaryBorderSize, ImaginaryBorderSize)
    End Function

    Function BottomRight(ByVal frmOwner As Form) As Rectangle
        Return New Rectangle(frmOwner.ClientSize.Width - ImaginaryBorderSize, frmOwner.ClientSize.Height - ImaginaryBorderSize, ImaginaryBorderSize, ImaginaryBorderSize)
    End Function
#End Region


#Region "SET BORDERLESS"
    '/* SET BORDERLESS */
    Private Sub SetBorderless(ByVal frmOwner As Form)
        Me.FormBorderStyle = FormBorderStyle.None
        frmOwner.FormBorderStyle = Me.FormBorderStyle
    End Sub
#End Region

#Region "SET BORDER COLOR"
    '/* SET BORDERLESS */
    Protected Friend Sub SetBorderlessBorderColor(ByVal pColor As Color, vBorderStyleSolid As ButtonBorderStyle, e As PaintEventArgs)
        ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, pColor, vBorderStyleSolid)
        'DrawBorder(leftColor As Drawing.Color, leftWidth As Integer, leftStyle As ButtonBorderStyle, topColor As Drawing.Color, topWidth As Integer, topStyle As ButtonBorderStyle, rightColor As Drawing.Color, rightWidth As Integer, rightStyle As ButtonBorderStyle, bottomColor As Drawing.Color, bottomWidth As Integer, bottomStyle As ButtonBorderStyle)
    End Sub
#End Region


#Region "SET SHADOW EFFECT"
    '/* SET SHADOW */
    Public Class NativeStructs
        Public Structure MARGINS
            Public leftWidth As Integer
            Public rightWidth As Integer
            Public topHeight As Integer
            Public bottomHeight As Integer
        End Structure
    End Class

    Public Class NativeMethods
        <DllImport("dwmapi")>
        Public Shared Function DwmExtendFrameIntoClientArea(ByVal hWnd As IntPtr, ByRef pMarInset As NativeStructs.MARGINS) As Integer
        End Function
        <DllImport("dwmapi")>
        Friend Shared Function DwmSetWindowAttribute(ByVal hwnd As IntPtr, ByVal attr As Integer, ByRef attrValue As Integer, ByVal attrSize As Integer) As Integer
        End Function
        <DllImport("dwmapi.dll")>
        Public Shared Function DwmIsCompositionEnabled(ByRef pfEnabled As Integer) As Integer
        End Function
    End Class

    Public Class NativeConstants
        Public Const CS_DROPSHADOW As Integer = &H20000
        Public Const WM_NCPAINT As Integer = &H85
    End Class

    ' Override the CreateParams property
    Protected Overrides ReadOnly Property CreateParams() As System.Windows.Forms.CreateParams
        Get
            Const CS_DROPSHADOW As Integer = 131072
            Dim vCreateParams As CreateParams = MyBase.CreateParams
            ' Check OS Before using XP drop shadow
            Dim OSVersion As Version = System.Environment.OSVersion.Version()
            ' Select case...
            Select Case OSVersion.Major
                Case Is < 5
                Case 5
                    If OSVersion.Minor > 0 Then
                        vCreateParams.ClassStyle = vCreateParams.ClassStyle Or CS_DROPSHADOW
                    End If
                Case Is > 5
                    vCreateParams.ClassStyle = vCreateParams.ClassStyle Or CS_DROPSHADOW
                Case Else
            End Select
            ' Return value
            Return vCreateParams
        End Get
    End Property
#End Region

End Class
