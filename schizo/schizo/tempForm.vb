Imports System.IO

Public Class tempForm
    Private Sub tempForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized

        Try

            If My.Computer.FileSystem.FileExists(Application.StartupPath & "\update.bat") Then
                File.Delete(Application.StartupPath & "\update.bat")
            ElseIf My.Computer.FileSystem.FileExists(Application.StartupPath & "\update.exe") Then
                File.Delete(Application.StartupPath & "\update.exe")
            End If
            'Initializing frameworks
            If Form1.testnetwork() = True Then
                Form1.queryNewVersion()
            End If



            If My.Computer.FileSystem.FileExists(Application.StartupPath & "\config.ini") Then
                Form1.urlINI = Form1.IniReadValue("EVENTS", "URL")
                WebBrowser1.Navigate(Form1.urlINI)
            Else
                MsgBox("Konnte die config.ini nicht auslesen!")
                Application.Exit()
            End If

        Catch ex As Exception
            Form1.WriteToErrorLog(ex.Message, ex.StackTrace, "Exception")
            MsgBox("Oops! Looks like something went wrong..", MsgBoxStyle.Critical)
            Application.Exit()
        End Try
    End Sub

    Private Sub tempForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Try
            System.Diagnostics.Process.Start("rundll32.exe", "InetCpl.cpl,ClearMyTracksByProcess 8")
            System.Diagnostics.Process.Start("rundll32.exe", "InetCpl.cpl,ClearMyTracksByProcess 2")
            System.Diagnostics.Process.Start("rundll32.exe", "InetCpl.cpl,ClearMyTracksByProcess 1")
        Catch ex As Exception
            Form1.WriteToErrorLog(ex.Message, ex.StackTrace, "Exception")
            MsgBox("Oops! Looks like something went wrong..", MsgBoxStyle.Critical)
            Application.Exit()
        End Try
    End Sub
End Class