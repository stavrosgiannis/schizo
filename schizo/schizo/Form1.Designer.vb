﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
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

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.WebBrowser1 = New System.Windows.Forms.WebBrowser()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.InviteBt = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Anmelden = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.runJSTimer = New System.Windows.Forms.Timer(Me.components)
        Me.redirectURLTimer = New System.Windows.Forms.Timer(Me.components)
        Me.runJSToConfirmTimer = New System.Windows.Forms.Timer(Me.components)
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.ClickOnAllFriendsTimer = New System.Windows.Forms.Timer(Me.components)
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.MainTimer = New System.Windows.Forms.Timer(Me.components)
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.CheckForSaveDialogTimer = New System.Windows.Forms.Timer(Me.components)
        Me.Timer3 = New System.Windows.Forms.Timer(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CheckLoginTimer = New System.Windows.Forms.Timer(Me.components)
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Timer4 = New System.Windows.Forms.Timer(Me.components)
        Me.Button6 = New System.Windows.Forms.Button()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'WebBrowser1
        '
        Me.WebBrowser1.Location = New System.Drawing.Point(543, 4)
        Me.WebBrowser1.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser1.Name = "WebBrowser1"
        Me.WebBrowser1.Size = New System.Drawing.Size(538, 552)
        Me.WebBrowser1.TabIndex = 0
        '
        'Timer1
        '
        '
        'InviteBt
        '
        Me.InviteBt.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.InviteBt.Location = New System.Drawing.Point(12, 110)
        Me.InviteBt.Name = "InviteBt"
        Me.InviteBt.Size = New System.Drawing.Size(85, 29)
        Me.InviteBt.TabIndex = 1
        Me.InviteBt.Text = "Invite"
        Me.InviteBt.UseVisualStyleBackColor = True
        Me.InviteBt.Visible = False
        '
        'TextBox1
        '
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.ForeColor = System.Drawing.Color.Red
        Me.TextBox1.Location = New System.Drawing.Point(12, 4)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(124, 29)
        Me.TextBox1.TabIndex = 2
        Me.TextBox1.Text = "NOT READY"
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Anmelden
        '
        Me.Anmelden.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Anmelden.Location = New System.Drawing.Point(12, 145)
        Me.Anmelden.Name = "Anmelden"
        Me.Anmelden.Size = New System.Drawing.Size(85, 29)
        Me.Anmelden.TabIndex = 6
        Me.Anmelden.Text = "Anmelden"
        Me.Anmelden.UseVisualStyleBackColor = True
        Me.Anmelden.Visible = False
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(12, 39)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(85, 29)
        Me.Button3.TabIndex = 7
        Me.Button3.Text = "RESET"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'runJSTimer
        '
        Me.runJSTimer.Interval = 5000
        '
        'redirectURLTimer
        '
        Me.redirectURLTimer.Interval = 2000
        '
        'runJSToConfirmTimer
        '
        Me.runJSToConfirmTimer.Interval = 4000
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlLight
        Me.Label3.Location = New System.Drawing.Point(9, 522)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(19, 13)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "30"
        '
        'Timer2
        '
        Me.Timer2.Interval = 1000
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(1086, 559)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 12
        Me.PictureBox1.TabStop = False
        '
        'ClickOnAllFriendsTimer
        '
        Me.ClickOnAllFriendsTimer.Interval = 4000
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(431, 28)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 13
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(142, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(74, 13)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Ausgewählt: 0"
        '
        'MainTimer
        '
        Me.MainTimer.Interval = 6000
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(12, 543)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(1062, 13)
        Me.ProgressBar1.TabIndex = 15
        Me.ProgressBar1.Visible = False
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(37, 236)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 16
        Me.Button2.Text = "Button2"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(26, 318)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(511, 95)
        Me.ListBox1.TabIndex = 17
        Me.ListBox1.Visible = False
        '
        'CheckForSaveDialogTimer
        '
        Me.CheckForSaveDialogTimer.Enabled = True
        Me.CheckForSaveDialogTimer.Interval = 500
        '
        'Timer3
        '
        Me.Timer3.Interval = 500
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(132, 145)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 18
        Me.Label1.Text = "Label1"
        '
        'CheckLoginTimer
        '
        Me.CheckLoginTimer.Interval = 3000
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(223, 74)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(75, 23)
        Me.Button4.TabIndex = 19
        Me.Button4.Text = "Button4"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(337, 110)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(75, 23)
        Me.Button5.TabIndex = 20
        Me.Button5.Text = "Button5"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Timer4
        '
        Me.Timer4.Interval = 1000
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(404, 205)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(75, 23)
        Me.Button6.TabIndex = 21
        Me.Button6.Text = "Button6"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ClientSize = New System.Drawing.Size(1086, 559)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Anmelden)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.InviteBt)
        Me.Controls.Add(Me.WebBrowser1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Name = "Form1"
        Me.Text = "SCHIZO-EVENTS"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents WebBrowser1 As WebBrowser
    Friend WithEvents Timer1 As Timer
    Friend WithEvents InviteBt As Button
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Anmelden As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents runJSTimer As Timer
    Friend WithEvents redirectURLTimer As Timer
    Friend WithEvents runJSToConfirmTimer As Timer
    Friend WithEvents Label3 As Label
    Friend WithEvents Timer2 As Timer
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents ClickOnAllFriendsTimer As Timer
    Friend WithEvents Button1 As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents MainTimer As Timer
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents Button2 As Button
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents CheckForSaveDialogTimer As Timer
    Friend WithEvents Timer3 As Timer
    Friend WithEvents Label1 As Label
    Friend WithEvents CheckLoginTimer As Timer
    Friend WithEvents Button4 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents Timer4 As Timer
    Friend WithEvents Button6 As Button
End Class
