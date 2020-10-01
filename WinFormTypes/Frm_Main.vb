Imports System.Drawing.Drawing2D
Imports System.Runtime.InteropServices

Public Class Frm_Main
    ' Params
    Private ReadOnly NewFrmBordeless As New Borderless(Me)
    Private gAeroEnabled As Boolean

    Private Sub Frm_Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set style to resizable
        Me.SetStyle(ControlStyles.ResizeRedraw, True)
    End Sub

    Private Sub Btn_Exit_Click(sender As Object, e As EventArgs) Handles Btn_Exit.Click
        End
    End Sub

#Region "FORM MOVEMENT"
    Private Sub Frm_Main_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
        Call NewFrmBordeless.BorderlessMouseDown(sender, e)
    End Sub

    Private Sub Frm_Main_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
        Call NewFrmBordeless.BorderlessMouseMove(sender, e)
    End Sub

    Private Sub Frm_Main_MouseUp(sender As Object, e As MouseEventArgs) Handles Me.MouseUp
        Call NewFrmBordeless.BorderlessMouseUp(sender, e)
    End Sub

    Private Sub Pnl_MainBody_MouseDown(sender As Object, e As MouseEventArgs) Handles Pnl_MainBody.MouseDown
        Call NewFrmBordeless.BorderlessMouseDown(Me, e)
    End Sub

    Private Sub Pnl_MainBody_MouseMove(sender As Object, e As MouseEventArgs) Handles Pnl_MainBody.MouseMove
        Call NewFrmBordeless.BorderlessMouseMove(Me, e)
    End Sub

    Private Sub Pnl_MainBody_MouseUp(sender As Object, e As MouseEventArgs) Handles Pnl_MainBody.MouseUp
        Call NewFrmBordeless.BorderlessMouseUp(Me, e)
    End Sub
#End Region

#Region "FORM PAINT"
    Private Sub Frm_Main_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Call NewFrmBordeless.SetBorderlessBorderColor(Color.Orange, ButtonBorderStyle.Solid, e)
    End Sub
#End Region

#Region "SHADOW EFFECT AND RESIZER"

    Private Sub CheckAeroEnabled()
        ' If...
        If Environment.OSVersion.Version.Major >= 6 Then
            Dim vEnabled As Integer = 0
            Dim vResponse As Integer = Borderless.NativeMethods.DwmIsCompositionEnabled(vEnabled)
            gAeroEnabled = (vEnabled = 1)
        Else
            gAeroEnabled = False
        End If
    End Sub

    Protected Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            ' Call...
            Call CheckAeroEnabled()
            ' Create a new param
            Dim vCp As CreateParams = MyBase.CreateParams
            ' If not...
            If Not gAeroEnabled Then
                vCp.ClassStyle = vCp.ClassStyle Or Borderless.NativeConstants.CS_DROPSHADOW
                Return vCp
            Else
                Return vCp
            End If
        End Get
    End Property

    Protected Overrides Sub WndProc(ByRef pMsg As Message)
        Select Case pMsg.Msg
            'Shadowing
            Case Borderless.NativeConstants.WM_NCPAINT
                ' Valor
                Dim v As Integer = 2
                If gAeroEnabled Then
                    Borderless.NativeMethods.DwmSetWindowAttribute(Handle, 2, v, 4)
                    Dim vBlMargins As New Borderless.NativeStructs.MARGINS()
                    With vBlMargins
                        .bottomHeight = 1
                        .leftWidth = 1
                        .rightWidth = 1
                        .topHeight = 1
                    End With
                    Borderless.NativeMethods.DwmExtendFrameIntoClientArea(Handle, vBlMargins)
                End If
            Case Else
                ' Value
                MyBase.WndProc(pMsg)
                ' If...
                If pMsg.Msg = &H84 Then
                    Dim mp = Me.PointToClient(Cursor.Position)
                    If NewFrmBordeless.TopLeft.Contains(mp) Then
                        pMsg.Result = CType(NewFrmBordeless.HTTOPLEFT, IntPtr)
                    ElseIf NewFrmBordeless.TopRight(Me).Contains(mp) Then
                        pMsg.Result = CType(NewFrmBordeless.HTTOPRIGHT, IntPtr)
                    ElseIf NewFrmBordeless.BottomLeft(Me).Contains(mp) Then
                        pMsg.Result = CType(NewFrmBordeless.HTBOTTOMLEFT, IntPtr)
                    ElseIf NewFrmBordeless.BottomRight(Me).Contains(mp) Then
                        pMsg.Result = CType(NewFrmBordeless.HTBOTTOMRIGHT, IntPtr)
                    ElseIf NewFrmBordeless.TopY(Me).Contains(mp) Then
                        pMsg.Result = CType(NewFrmBordeless.HTTOP, IntPtr)
                    ElseIf NewFrmBordeless.LeftX(Me).Contains(mp) Then
                        pMsg.Result = CType(NewFrmBordeless.HTLEFT, IntPtr)
                    ElseIf NewFrmBordeless.RightX(Me).Contains(mp) Then
                        pMsg.Result = CType(NewFrmBordeless.HTRIGHT, IntPtr)
                    ElseIf NewFrmBordeless.BottomY(Me).Contains(mp) Then
                        pMsg.Result = CType(NewFrmBordeless.HTBOTTOM, IntPtr)
                    End If
                End If
        End Select
    End Sub

#End Region

End Class
