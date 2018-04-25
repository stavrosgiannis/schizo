Imports mshtml
Public Class Form1
    Dim pswaHeight As Object
    Dim pswaWidth As Object
    Dim pswaHeightInt As Integer
    Dim pswaWidthInt As Integer

    Private Enum Exec
        OLECMDID_OPTICAL_ZOOM = 63
    End Enum

    Private Enum execOpt
        OLECMDEXECOPT_DODEFAULT = 0
        OLECMDEXECOPT_PROMPTUSER = 1
        OLECMDEXECOPT_DONTPROMPTUSER = 2
        OLECMDEXECOPT_SHOWHELP = 3
    End Enum
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        pswaHeight = Screen.PrimaryScreen.WorkingArea.Height
        pswaWidth = Screen.PrimaryScreen.WorkingArea.Width
        pswaHeightInt = CInt(pswaHeight)
        pswaWidthInt = CInt(pswaWidth)
    End Sub

    Private Sub login_facebook()
        WebBrowser1.Document.GetElementById("Email").SetAttribute("value", TextBox2.Text)
        WebBrowser1.Document.GetElementById("pass").SetAttribute("value", TextBox3.Text)
        WebBrowser1.Document.GetElementById("loginbutton").InvokeMember("click")
    End Sub

    Private Sub WebBrowser1_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted

        TextBox1.Text = "READY"
        Timer1.Start()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick


        If WebBrowser1.Width > Math.Round(pswaWidthInt / 5.6) And WebBrowser1.Width < Math.Round(pswaWidthInt / 2.97) Or WebBrowser1.Height > Math.Round(pswaHeightInt / 3.0) And WebBrowser1.Height < Math.Round(pswaHeightInt / 2.4) Then
            Try
                Dim Res As Object = Nothing
                Dim MyWeb As Object
                MyWeb = Me.WebBrowser1.ActiveXInstance
                MyWeb.ExecWB(Exec.OLECMDID_OPTICAL_ZOOM, execOpt.OLECMDEXECOPT_PROMPTUSER, 40, IntPtr.Zero)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If

        If WebBrowser1.Width > Math.Round(pswaWidthInt / 2.97) And WebBrowser1.Width < Math.Round(pswaWidthInt / 2.58) Or WebBrowser1.Height > Math.Round(pswaHeightInt / 2.4) And WebBrowser1.Height < Math.Round(pswaHeightInt / 2.13) Then
            Try
                Dim Res As Object = Nothing
                Dim MyWeb As Object
                MyWeb = Me.WebBrowser1.ActiveXInstance
                MyWeb.ExecWB(Exec.OLECMDID_OPTICAL_ZOOM, execOpt.OLECMDEXECOPT_PROMPTUSER, 50, IntPtr.Zero)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If

        If WebBrowser1.Width > Math.Round(pswaWidthInt / 2.58) And WebBrowser1.Width < Math.Round(pswaWidthInt / 2.23) Or WebBrowser1.Height > Math.Round(pswaHeightInt / 2.13) And WebBrowser1.Height < Math.Round(pswaHeightInt / 1.85) Then
            Try
                Dim Res As Object = Nothing
                Dim MyWeb As Object
                MyWeb = Me.WebBrowser1.ActiveXInstance
                MyWeb.ExecWB(Exec.OLECMDID_OPTICAL_ZOOM, execOpt.OLECMDEXECOPT_PROMPTUSER, 60, IntPtr.Zero)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If

        If WebBrowser1.Width > Math.Round(pswaWidthInt / 2.23) And WebBrowser1.Width < Math.Round(pswaWidthInt / 1.89) Or WebBrowser1.Height > Math.Round(pswaHeightInt / 1.85) And WebBrowser1.Height < Math.Round(pswaHeightInt / 1.64) Then
            Try
                Dim Res As Object = Nothing
                Dim MyWeb As Object
                MyWeb = Me.WebBrowser1.ActiveXInstance
                MyWeb.ExecWB(Exec.OLECMDID_OPTICAL_ZOOM, execOpt.OLECMDEXECOPT_PROMPTUSER, 70, IntPtr.Zero)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If

        If WebBrowser1.Width > Math.Round(pswaWidthInt / 1.89) And WebBrowser1.Width < Math.Round(pswaWidthInt / 1.6) Or WebBrowser1.Height > Math.Round(pswaHeightInt / 1.64) And WebBrowser1.Height < Math.Round(pswaHeightInt / 1.53) Then
            Try
                Dim Res As Object = Nothing
                Dim MyWeb As Object
                MyWeb = Me.WebBrowser1.ActiveXInstance
                MyWeb.ExecWB(Exec.OLECMDID_OPTICAL_ZOOM, execOpt.OLECMDEXECOPT_PROMPTUSER, 80, IntPtr.Zero)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If

        If WebBrowser1.Width > Math.Round(pswaWidthInt / 1.6) And WebBrowser1.Width < Math.Round(pswaWidthInt / 1.2) Or WebBrowser1.Height > Math.Round(pswaHeightInt / 1.53) And WebBrowser1.Height < Math.Round(pswaHeightInt / 1.16) Then
            Try
                Dim Res As Object = Nothing
                Dim MyWeb As Object
                MyWeb = Me.WebBrowser1.ActiveXInstance
                MyWeb.ExecWB(Exec.OLECMDID_OPTICAL_ZOOM, execOpt.OLECMDEXECOPT_PROMPTUSER, 90, IntPtr.Zero)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If

        If WebBrowser1.Width > Math.Round(pswaWidthInt / 1.2) AndAlso WebBrowser1.Height > Math.Round(pswaHeightInt / 1.16) Then
            Try
                Dim Res As Object = Nothing
                Dim MyWeb As Object
                MyWeb = Me.WebBrowser1.ActiveXInstance
                MyWeb.ExecWB(Exec.OLECMDID_OPTICAL_ZOOM, execOpt.OLECMDEXECOPT_PROMPTUSER, 100, IntPtr.Zero)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub Form1_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged
        WebBrowser1.Height = Me.Height - 150
    End Sub

    Private Sub WebBrowser1_Navigating(sender As Object, e As WebBrowserNavigatingEventArgs) Handles WebBrowser1.Navigating
        TextBox1.Text = "NOT READY"
    End Sub

    Private Sub InviteBt_Click(sender As Object, e As EventArgs) Handles InviteBt.Click
        If TextBox1.Text = "READY" Then
            Dim headElement As HtmlElement = WebBrowser1.Document.GetElementsByTagName("head")(0)
            Dim scriptElement As HtmlElement = WebBrowser1.Document.CreateElement("script")
            Dim element As IHTMLScriptElement = DirectCast(scriptElement.DomElement, IHTMLScriptElement)
            element.text = "javascript:var inputs = document.getElementsByClassName('_1pu2'); 
                            for(var i=0;i<inputs.length;i++) { inputs[i].click(); }"
            headElement.AppendChild(scriptElement)
            WebBrowser1.Document.InvokeScript("sayHello")
        Else
            MsgBox("Die Seite wurde noch nicht geladen!")
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        WebBrowser1.Document.GetElementById("u_0_11").InvokeMember("click")
        Threading.Thread.Sleep(500)
        SendKeys.Send("{ENTER} ")

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        login_facebook()
    End Sub
End Class
