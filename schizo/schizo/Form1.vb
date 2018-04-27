Imports mshtml
Imports System.Text
Public Class Form1
    Dim pswaHeight As Object
    Dim pswaWidth As Object
    Dim pswaHeightInt As Integer
    Dim pswaWidthInt As Integer

#Region "ini. API"
    ''' <summary>
    ''' Create a New INI file to store or load data
    ''' </summary>

    Public _inipath As String = Application.StartupPath & "\config.ini"

    Private Declare Function WritePrivateProfileStringA Lib "kernel32" (ByVal section As String, ByVal key As String, ByVal val As String, ByVal filePath As String) As Long

    Private Declare Function GetPrivateProfileStringA Lib "kernel32" (ByVal section As String, ByVal key As String, ByVal def As String, ByVal retVal As StringBuilder, ByVal size As Integer, ByVal filePath As String) As Integer

    ''' <summary>
    ''' Write Data to the INI File
    ''' </summary>
    ''' <PARAM name="Section"></PARAM>
    ''' Section name
    ''' <PARAM name="Key"></PARAM>
    ''' Key Name
    ''' <PARAM name="Value"></PARAM>
    ''' Value Name
    Public Sub IniWriteValue(ByVal Section As String, ByVal Key As String, ByVal Value As String)
        WritePrivateProfileStringA(Section, Key, Value, Me._inipath)
    End Sub

    ''' <summary>
    ''' Read Data Value From the Ini File
    ''' </summary>
    ''' <PARAM name="Section"></PARAM>
    ''' <PARAM name="Key"></PARAM>
    ''' <PARAM name="Path"></PARAM>
    ''' <returns></returns>
    Public Function IniReadValue(ByVal Section As String, ByVal Key As String) As String
        Dim temp As StringBuilder = New StringBuilder(255)
        Dim i As Integer = GetPrivateProfileStringA(Section, Key, "", temp, 255, Me._inipath)
        Return temp.ToString
    End Function
#End Region

    Private Enum Exec
        OLECMDID_OPTICAL_ZOOM = 63
    End Enum

    Private Enum execOpt
        OLECMDEXECOPT_DODEFAULT = 0
        OLECMDEXECOPT_PROMPTUSER = 1
        OLECMDEXECOPT_DONTPROMPTUSER = 2
        OLECMDEXECOPT_SHOWHELP = 3
    End Enum

    Dim urlINI As String
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        pswaHeight = Screen.PrimaryScreen.WorkingArea.Height
        pswaWidth = Screen.PrimaryScreen.WorkingArea.Width
        pswaHeightInt = CInt(pswaHeight)
        pswaWidthInt = CInt(pswaWidth)

        If My.Computer.FileSystem.FileExists(Application.StartupPath & "\config.ini") Then
            urlINI = IniReadValue("EVENTS", "URL")
            WebBrowser1.Navigate(urlINI)
        Else
            Application.Exit()
        End If
    End Sub

    Private Sub login_facebook()
        WebBrowser1.Document.GetElementById("Email").SetAttribute("value", TextBox2.Text)
        WebBrowser1.Document.GetElementById("pass").SetAttribute("value", TextBox3.Text)
        WebBrowser1.Document.GetElementById("loginbutton").InvokeMember("click")
    End Sub

    Private Sub WebBrowser1_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted
        'Timer1.Start()
        TextBox1.Text = "READY"

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

        WebBrowser1.Height = Me.Height - 120
    End Sub

    Private Sub WebBrowser1_Navigating(sender As Object, e As WebBrowserNavigatingEventArgs) Handles WebBrowser1.Navigating
        TextBox1.Text = "NOT READY"
    End Sub

    Public Sub runJS()
        Dim headElement As HtmlElement = WebBrowser1.Document.GetElementsByTagName("head")(0)
        Dim scriptElement As HtmlElement = WebBrowser1.Document.CreateElement("script")
        Dim element As IHTMLScriptElement = DirectCast(scriptElement.DomElement, IHTMLScriptElement)
        element.text = "javascript:var inputs = document.getElementsByClassName('_1pu2'); 
                            for(var i=0;i<inputs.length;i++) { inputs[i].click(); }"
        headElement.AppendChild(scriptElement)
        WebBrowser1.Document.InvokeScript("sayHello")
    End Sub

    Private Sub InviteBt_Click(sender As Object, e As EventArgs) Handles InviteBt.Click
        If TextBox1.Text = "READY" Then

            clickOnTeilen()
            runJSTimer.Start()
            Label3.Text = "10"
            Timer2.Start()

        Else

            MsgBox("Die Seite wurde noch nicht geladen!")
        End If
    End Sub

    Public Sub runJSToConfirm()
        Dim headElement As HtmlElement = WebBrowser1.Document.GetElementsByTagName("head")(0)
        Dim scriptElement As HtmlElement = WebBrowser1.Document.CreateElement("script")
        Dim element As IHTMLScriptElement = DirectCast(scriptElement.DomElement, IHTMLScriptElement)
        element.text = "javascript:var inputs = document.getElementsByClassName('layerConfirm'); 
                            var rake = inputs[0]; rake.click(); "
        headElement.AppendChild(scriptElement)
        WebBrowser1.Document.InvokeScript("sayHello")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        runJSToConfirm()
    End Sub

    Public Sub clickOnTeilen()
        WebBrowser1.Document.GetElementById("u_0_11").InvokeMember("click")
        'Threading.Thread.Sleep(500)
        SendKeys.Send("{ENTER}")
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Anmelden.Click
        login_facebook()
        redirectURLTimer.Start()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        redirectURLTimer.Start()
        Label3.Text = "10"
        System.Diagnostics.Process.Start("rundll32.exe", "InetCpl.cpl,ClearMyTracksByProcess 8")
        System.Diagnostics.Process.Start("rundll32.exe", "InetCpl.cpl,ClearMyTracksByProcess 2")
        System.Diagnostics.Process.Start("rundll32.exe", "InetCpl.cpl,ClearMyTracksByProcess 1")
        TextBox2.Text = ""
        TextBox3.Text = ""
        redirectURLTimer.Start()
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles runJSTimer.Tick
        runJS()
        runJSTimer.Stop()
    End Sub

    Private Sub redirectURLTimer_Tick(sender As Object, e As EventArgs) Handles redirectURLTimer.Tick
        WebBrowser1.Navigate(urlINI)
        redirectURLTimer.Stop()
    End Sub

    Private Sub resetTimer_Tick(sender As Object, e As EventArgs)

    End Sub

    Private Sub runJSToConfirmTimer_Tick(sender As Object, e As EventArgs) Handles runJSToConfirmTimer.Tick
        runJSToConfirm()
        runJSToConfirmTimer.Stop()
    End Sub

    Private Sub Timer2_Tick_1(sender As Object, e As EventArgs) Handles Timer2.Tick
        Label3.Text = Label3.Text - 1
        If Label3.Text = "1" Then
            Timer2.Stop()
            runJSToConfirm()
            Beep()
        End If
    End Sub
End Class
