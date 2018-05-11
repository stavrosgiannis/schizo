
Imports mshtml
Imports System.Text
Imports System.Net
Imports System.IO
Imports System.ComponentModel

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

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        LoginForm1.Show()
    End Sub

    Public Function login_facebook()
        If LoginForm1.passwort IsNot Nothing And LoginForm1.benutzername IsNot Nothing Then
            WebBrowser1.Document.GetElementById("Email").SetAttribute("value", LoginForm1.benutzername)
            WebBrowser1.Document.GetElementById("pass").SetAttribute("value", LoginForm1.passwort)
            WebBrowser1.Document.GetElementById("loginbutton").InvokeMember("click")
            Return True
        Else
            MsgBox("Bitte Melde dich erst an! oder drücke RESET", MsgBoxStyle.Information)
            Return False
        End If


    End Function

    Public Function runJS()
        Try
            MsgBox("Das kann bisschen dauern, keine Panik!")
            Dim headElement As HtmlElement = WebBrowser1.Document.GetElementsByTagName("head")(0)
            Dim scriptElement As HtmlElement = WebBrowser1.Document.CreateElement("script")
            Dim element As IHTMLScriptElement = DirectCast(scriptElement.DomElement, IHTMLScriptElement)
            element.text = "javascript:var inputs = document.getElementsByClassName('_1pu2'); 
                            for(var i=0;i<inputs.length;i++) { inputs[i].click(); }"
            headElement.AppendChild(scriptElement)
            WebBrowser1.Document.InvokeScript("sayHello")
            Return True
        Catch ex As Exception
            Form1.WriteToErrorLog(ex.Message, ex.StackTrace, "Exception")
            MsgBox("Oops! Looks like something went wrong..", MsgBoxStyle.Critical)
            Return False
        End Try

        Return True
    End Function

    Public Sub DoEvents()
        WebBrowser1.Visible = True
        If WebBrowser1.ReadyState = WebBrowserReadyState.Complete Then
            CheckLoginTimer.Start()
            If login_facebook() = True Then
                If WebBrowser1.ReadyState = WebBrowserReadyState.Complete Then
                    redirectURLTimer.Start()


                End If
            End If
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles CheckLoginTimer.Tick
        If WebBrowser1.Url.ToString.Contains("login.php?") = False Then
            CheckLoginTimer.Stop()
            Label2.Text = "Erfolgreich eingeloggt!"

        Else
            CheckLoginTimer.Stop()
            Label2.Text = "Email oder Passwort ist falsch!"

        End If
    End Sub

    Private Sub SiteLoadingTimer_Tick(sender As Object, e As EventArgs) Handles SiteLoadingTimer.Tick
        If WebBrowser1.Url <> Nothing Then
            TextBox1.Text = WebBrowser1.Url.OriginalString
        End If
        If WebBrowser1.ReadyState = WebBrowserReadyState.Loading Then
            Label1.Text = "Loading"
        End If
        If WebBrowser1.ReadyState = WebBrowserReadyState.Complete Then
            Label1.Text = "Complete"
        End If
        If WebBrowser1.ReadyState = WebBrowserReadyState.Interactive Then
            Label1.Text = "Interactive"
        End If
        If WebBrowser1.ReadyState = WebBrowserReadyState.Loaded Then
            Label1.Text = "Loaded"
        End If
        If WebBrowser1.ReadyState = WebBrowserReadyState.Uninitialized Then
            Label1.Text = "Uninitialized"
        End If
    End Sub

    Public Sub reset()
        WebBrowser1.Visible = False
        Label1.Text = ""
        Label2.Text = ""
        System.Diagnostics.Process.Start("rundll32.exe", "InetCpl.cpl,ClearMyTracksByProcess 8")
        System.Diagnostics.Process.Start("rundll32.exe", "InetCpl.cpl,ClearMyTracksByProcess 2")
        System.Diagnostics.Process.Start("rundll32.exe", "InetCpl.cpl,ClearMyTracksByProcess 1")
        LoginForm1.UsernameTextBox.Text = ""
        LoginForm1.PasswordTextBox.Text = ""
        LoginForm1.benutzername = ""
        LoginForm1.passwort = ""
        redirectURLTimer.Start()
    End Sub

    Private Sub PictureBox1_MouseClick(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseClick

    End Sub

    Private Sub WebBrowser1_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted

    End Sub

    Private Sub PictureBox1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseDoubleClick

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        reset()
    End Sub

    Private Sub redirectURLTimer_Tick(sender As Object, e As EventArgs) Handles redirectURLTimer.Tick
        WebBrowser1.Navigate(Form1.urlINI)
        redirectURLTimer.Stop()
    End Sub

    Public Function checkForSaveDialog()
        If WebBrowser1.ReadyState = WebBrowserReadyState.Complete Then
            WebBrowser1.Navigate(Form1.urlINI)
            Return False
        End If

        Return True
    End Function

    Private Sub CheckDeviceSaveDialogTimer_Tick(sender As Object, e As EventArgs) Handles CheckDeviceSaveDialogTimer.Tick
        If WebBrowser1.Url <> Nothing Then
            If WebBrowser1.Url.ToString.Contains("save-device") Then

                checkForSaveDialog()

            End If
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If runJS() = True Then

            MsgBox("Es wurden alle verfügbaren Freunde eingeladen!")
        End If
    End Sub
End Class