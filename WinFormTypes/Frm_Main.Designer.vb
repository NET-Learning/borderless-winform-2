<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Frm_Main
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Btn_Exit = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Pnl_MainBody = New System.Windows.Forms.Panel()
        Me.RoundedPanel1 = New WinFormTypes.RoundedPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.RoundedPanel2 = New WinFormTypes.RoundedPanel()
        Me.Pnl_MainBody.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Btn_Exit
        '
        Me.Btn_Exit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_Exit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Btn_Exit.FlatAppearance.BorderSize = 0
        Me.Btn_Exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn_Exit.Font = New System.Drawing.Font("Webdings", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Btn_Exit.Location = New System.Drawing.Point(750, 3)
        Me.Btn_Exit.Name = "Btn_Exit"
        Me.Btn_Exit.Size = New System.Drawing.Size(45, 35)
        Me.Btn_Exit.TabIndex = 0
        Me.Btn_Exit.Text = "r"
        Me.Btn_Exit.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(191, 219)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(442, 42)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "New Borderless WinForm"
        '
        'Pnl_MainBody
        '
        Me.Pnl_MainBody.BackColor = System.Drawing.SystemColors.Control
        Me.Pnl_MainBody.Controls.Add(Me.Panel2)
        Me.Pnl_MainBody.Controls.Add(Me.Panel1)
        Me.Pnl_MainBody.Controls.Add(Me.Label1)
        Me.Pnl_MainBody.Controls.Add(Me.Btn_Exit)
        Me.Pnl_MainBody.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Pnl_MainBody.Location = New System.Drawing.Point(1, 1)
        Me.Pnl_MainBody.Name = "Pnl_MainBody"
        Me.Pnl_MainBody.Size = New System.Drawing.Size(798, 506)
        Me.Pnl_MainBody.TabIndex = 2
        '
        'RoundedPanel1
        '
        Me.RoundedPanel1.BackColor = System.Drawing.Color.White
        Me.RoundedPanel1.BackgroundImage = Global.WinFormTypes.My.Resources.Resources.square_shadow_overlay
        Me.RoundedPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.RoundedPanel1.BorderColor = System.Drawing.Color.Maroon
        Me.RoundedPanel1.BorderRadius = 25
        Me.RoundedPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RoundedPanel1.DropShadow = True
        Me.RoundedPanel1.Location = New System.Drawing.Point(10, 10)
        Me.RoundedPanel1.Name = "RoundedPanel1"
        Me.RoundedPanel1.Size = New System.Drawing.Size(224, 152)
        Me.RoundedPanel1.TabIndex = 2
        '
        'Panel1
        '
        Me.Panel1.BackgroundImage = Global.WinFormTypes.My.Resources.Resources.shadow322
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Controls.Add(Me.RoundedPanel1)
        Me.Panel1.Location = New System.Drawing.Point(3, 331)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Padding = New System.Windows.Forms.Padding(10)
        Me.Panel1.Size = New System.Drawing.Size(244, 172)
        Me.Panel1.TabIndex = 4
        '
        'Panel2
        '
        Me.Panel2.BackgroundImage = Global.WinFormTypes.My.Resources.Resources.shadow322
        Me.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel2.Controls.Add(Me.RoundedPanel2)
        Me.Panel2.Location = New System.Drawing.Point(551, 331)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Padding = New System.Windows.Forms.Padding(10)
        Me.Panel2.Size = New System.Drawing.Size(244, 172)
        Me.Panel2.TabIndex = 5
        '
        'RoundedPanel2
        '
        Me.RoundedPanel2.BackColor = System.Drawing.Color.White
        Me.RoundedPanel2.BackgroundImage = Global.WinFormTypes.My.Resources.Resources.square_shadow_overlay
        Me.RoundedPanel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.RoundedPanel2.BorderColor = System.Drawing.Color.ForestGreen
        Me.RoundedPanel2.BorderRadius = 25
        Me.RoundedPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RoundedPanel2.DropShadow = True
        Me.RoundedPanel2.Location = New System.Drawing.Point(10, 10)
        Me.RoundedPanel2.Name = "RoundedPanel2"
        Me.RoundedPanel2.Size = New System.Drawing.Size(224, 152)
        Me.RoundedPanel2.TabIndex = 2
        '
        'Frm_Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 508)
        Me.Controls.Add(Me.Pnl_MainBody)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MinimumSize = New System.Drawing.Size(480, 240)
        Me.Name = "Frm_Main"
        Me.Padding = New System.Windows.Forms.Padding(1)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "WinForm Main"
        Me.Pnl_MainBody.ResumeLayout(False)
        Me.Pnl_MainBody.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Btn_Exit As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Pnl_MainBody As Panel
    Friend WithEvents RoundedPanel1 As RoundedPanel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents RoundedPanel2 As RoundedPanel
End Class
