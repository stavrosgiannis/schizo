﻿Imports System.ComponentModel
Imports System.IO
Imports System.Net
Imports System.Text
Imports MSHTML

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

#Region "Error Logger"

    '*************************************************************
    'NAME:          WriteToErrorLog
    'PURPOSE:       Open or create an error log and submit error message
    'PARAMETERS:    msg - message to be written to error file
    '               stkTrace - stack trace from error message
    '               title - title of the error file entry
    'RETURNS:       Nothing
    '*************************************************************
    Public Sub WriteToErrorLog(ByVal msg As String,
           ByVal stkTrace As String, ByVal title As String)

        'check and make the directory if necessary; this is set to look in
        'the Application folder, you may wish to place the error log in
        'another Location depending upon the user's role and write access to
        'different areas of the file system
        If Not System.IO.Directory.Exists(Application.StartupPath &
    "\Errors\") Then
            System.IO.Directory.CreateDirectory(Application.StartupPath &
            "\Errors\")
        End If

        'check the file
        Dim fs As FileStream = New FileStream(Application.StartupPath &
        "\Errors\errlog.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite)
        Dim s As StreamWriter = New StreamWriter(fs)
        s.Close()
        fs.Close()

        'log it
        Dim fs1 As FileStream = New FileStream(Application.StartupPath &
        "\Errors\errlog.txt", FileMode.Append, FileAccess.Write)
        Dim s1 As StreamWriter = New StreamWriter(fs1)
        s1.Write("Title: " & title & vbCrLf)
        s1.Write("Message: " & msg & vbCrLf)
        s1.Write("StackTrace: " & stkTrace & vbCrLf)
        s1.Write("Date/Time: " & DateTime.Now.ToString() & vbCrLf)
        s1.Write("================================================" & vbCrLf)
        s1.Close()
        fs1.Close()

    End Sub

#End Region

#Region "searchForUpdate"

    Public urlINI As String
    Dim WithEvents WC As New WebClient
    Dim urlini2 As String = "https://raw.githubusercontent.com/stavrosgiannis/schizo/master/config.ini"
    Dim urlexe As String = "https://raw.githubusercontent.com/stavrosgiannis/schizo/master/update.exe"

    Public Sub queryNewVersion()

        If My.Computer.FileSystem.FileExists(_inipath) = False Then
            My.Computer.Network.DownloadFile(urlini2, _inipath)
        Else
            My.Computer.FileSystem.DeleteFile(_inipath, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
            My.Computer.Network.DownloadFile(urlini2, _inipath)
        End If

        ReadUpdateFiles()

    End Sub

    Public Sub downloadUpdate()
        urlexe = IniReadValue("update", "urlexe")

        If My.Computer.FileSystem.FileExists(Application.StartupPath & "\update.exe") Then
            My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\update.exe", FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
            WC.DownloadFileAsync(New Uri(urlexe), Application.StartupPath & "\update.exe")
        Else
            WC.DownloadFileAsync(New Uri(urlexe), Application.StartupPath & "\update.exe")

        End If

    End Sub

    Public Sub extractbatchfile()

        My.Computer.Network.DownloadFile("https://raw.githubusercontent.com/stavrosgiannis/schizo/master/update.bat", Application.StartupPath & "\update.bat")
        Process.Start(Application.StartupPath & "\update.bat")
    End Sub

    Public Sub ReadUpdateFiles()
        If My.Computer.FileSystem.FileExists(_inipath) Then
            Dim iniversion As String = IniReadValue("update", "version")
            If iniversion <= Application.ProductVersion Then
            Else
                Me.Enabled = False
                downloadUpdate()

            End If
        End If
    End Sub

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

    Public Function testnetwork()
        If My.Computer.Network.IsAvailable Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try

            If My.Computer.FileSystem.FileExists(Application.StartupPath & "\update.bat") Then
                File.Delete(Application.StartupPath & "\update.bat")
            ElseIf My.Computer.FileSystem.FileExists(Application.StartupPath & "\update.exe") Then
                File.Delete(Application.StartupPath & "\update.exe")
            End If
            'Initializing frameworks
            If testnetwork() = True Then
                queryNewVersion()
            End If

            pswaHeight = Screen.PrimaryScreen.WorkingArea.Height
            pswaWidth = Screen.PrimaryScreen.WorkingArea.Width
            pswaHeightInt = CInt(pswaHeight)
            pswaWidthInt = CInt(pswaWidth)

            If My.Computer.FileSystem.FileExists(Application.StartupPath & "\config.ini") Then
                urlINI = IniReadValue("EVENTS", "URL")
                WebBrowser1.Navigate("m.facebook.com")
            Else
                MsgBox("Konnte die config.ini nicht auslesen!")
                Application.Exit()
            End If
        Catch ex As Exception
            WriteToErrorLog(ex.Message, ex.StackTrace, "Exception")
            MsgBox("Oops! Looks like something went wrong..", MsgBoxStyle.Critical)
            Application.Exit()
        End Try

    End Sub

    Public Sub login_facebook()
        If LoginForm1.passwort IsNot Nothing And LoginForm1.benutzername IsNot Nothing Then
            WebBrowser1.Document.GetElementById("Email").SetAttribute("value", LoginForm1.benutzername)
            WebBrowser1.Document.GetElementById("pass").SetAttribute("value", LoginForm1.passwort)
            WebBrowser1.Document.GetElementById("loginbutton").InvokeMember("click")
        Else
            MsgBox("Bitte Melde dich erst an! oder drücke RESET", MsgBoxStyle.Information)
        End If

    End Sub

    Private Sub WebBrowser1_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted
        'Timer1.Start()
        TextBox1.Text = "READY"
        Label1.Text = WebBrowser1.Url.ToString
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
        'Dim headElement As HtmlElement = WebBrowser1.Document.GetElementsByTagName("head")(0)
        'Dim scriptElement As HtmlElement = WebBrowser1.Document.CreateElement("script")
        'Dim element As IHTMLScriptElement = DirectCast(scriptElement.DomElement, IHTMLScriptElement)
        'element.text = "javascript:var inputs = document.getElementsByClassName('_1pu2');
        '                    for(var i=0;i<inputs.length;i++) { inputs[i].click(); }"
        'headElement.AppendChild(scriptElement)
        'WebBrowser1.Document.InvokeScript("sayHello")

        Dim myLink =
            (
                From T In WebBrowser1.Document.GetElementsByTagName("a").Cast(Of HtmlElement)()
                Where T.InnerText = "Alle auswählen"
            ).FirstOrDefault
        If myLink IsNot Nothing Then
            myLink.InvokeMember("Click")
            Beep()
        Else
            MessageBox.Show("Not found")
        End If

        For Each h As HtmlElement In WebBrowser1.Document.GetElementsByTagName("span")
            If Not Object.ReferenceEquals(h.GetAttribute("className"), Nothing) AndAlso h.GetAttribute("className").Equals("_fe1") Then
                Label4.Text = "Ausgewählt: " & h.InnerText
                Exit For
            End If
        Next

    End Sub

    Private Sub InviteBt_Click(sender As Object, e As EventArgs) Handles InviteBt.Click
        If TextBox1.Text = "READY" Then

            clickOnTeilen()
            'ClickOnAllFriendsTimer.Start()

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

        'WebBrowser1.Document.GetElementById("u_0_11").InvokeMember("click")

        WebBrowser1.Document.GetElementById("u_0_11").InvokeMember("click")

        'Threading.Thread.Sleep(500)
        SendKeys.Send("{ENTER}")

    End Sub

    Public Function checkForSaveDialog()
        Try
            If WebBrowser1.ReadyState = WebBrowserReadyState.Complete Then

                WebBrowser1.Navigate("m.facebook.com/login/save-device/cancel/?flow=interstitial_nux&amp;nux_source=regular_login")

                CheckForSaveDialogTimer.Stop()
                Timer3.Start()
                Return True

            End If
            Return False
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Public Sub AllinOne()
        mobileFBlogin()

    End Sub

    Public Function mobileFBlogin()
        Try
            If WebBrowser1.ReadyState = WebBrowserReadyState.Complete Then

                For Each element As HtmlElement In WebBrowser1.Document.All
                    If element.Name <> Nothing Then
                        ListBox1.Items.Add(element.Name)
                    End If
                    If InStr(element.Name, "pass") Then
                        'Nun Value auslesen
                        element.SetAttribute("value", LoginForm1.passwort)

                    End If
                    If InStr(element.Name, "email") Then
                        'Nun Value auslesen
                        element.SetAttribute("value", LoginForm1.benutzername)

                    End If
                    If InStr(element.Name, "login") Then
                        'Nun Value auslesen
                        element.InvokeMember("click")

                    End If

                Next

                CheckLoginTimer.Start()

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Anmelden.Click
        If TextBox1.Text = "READY" Then

            clickOnTeilen()
            'ClickOnAllFriendsTimer.Start()

            runJSTimer.Start()

            Label3.Text = "30"
            Timer2.Start()

        End If

    End Sub

    Private Function GetImageUrl() As String
        If (WebBrowser1.Document IsNot Nothing) Then

            Dim Urls As String

            For Each ImgElement As HtmlElement In WebBrowser1.Document.Images
                If ImgElement.GetAttribute("alt").Contains(GetUserInfo) Then
                    Urls = ImgElement.GetAttribute("src")

                End If

            Next

            Return False
        End If
    End Function

    Public Function GetUserInfo()
        Try
            If WebBrowser1.ReadyState = WebBrowserReadyState.Complete Then

                For Each curElement As HtmlElement In WebBrowser1.Document.GetElementsByTagName("a")
                    If curElement <> Nothing Then
                        If curElement.GetAttribute("class").Contains("gz ha") Then
                            Return curElement.InnerText
                        End If

                        If curElement.InnerHtml <> Nothing Then
                            ListBox1.Items.Add(curElement.OuterHtml)
                        End If

                    End If

                Next

                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function

    Public Sub reset()
        Label3.Text = "30"
        Label4.Text = "Ausgewählt: 0"
        System.Diagnostics.Process.Start("rundll32.exe", "InetCpl.cpl,ClearMyTracksByProcess 8")
        System.Diagnostics.Process.Start("rundll32.exe", "InetCpl.cpl,ClearMyTracksByProcess 2")
        System.Diagnostics.Process.Start("rundll32.exe", "InetCpl.cpl,ClearMyTracksByProcess 1")
        LoginForm1.UsernameTextBox.Text = ""
        LoginForm1.PasswordTextBox.Text = ""
        LoginForm1.benutzername = ""
        LoginForm1.passwort = ""
        redirectURLTimer.Start()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        reset()
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles runJSTimer.Tick
        runJS()
        runJSTimer.Stop()
    End Sub

    Private Sub redirectURLTimer_Tick(sender As Object, e As EventArgs) Handles redirectURLTimer.Tick
        WebBrowser1.Navigate("m.facebook.com")
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

    Private Sub ClickOnAllFriendsTimer_Tick(sender As Object, e As EventArgs) Handles ClickOnAllFriendsTimer.Tick

        Dim myLink =
            (
                From T In WebBrowser1.Document.GetElementsByTagName("a").Cast(Of HtmlElement)()
                Where T.InnerText = "Alle Freunde"
            ).FirstOrDefault
        If myLink IsNot Nothing Then
            myLink.InvokeMember("Click")
            Beep()
        Else
            MessageBox.Show("Not found")
        End If

        ClickOnAllFriendsTimer.Stop()
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        MsgBox(LoginForm1.benutzername.ToString & LoginForm1.passwort.ToString)

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        LoginForm1.Show()
    End Sub

    Private Sub MainTimer_Tick(sender As Object, e As EventArgs) Handles MainTimer.Tick
        If TextBox1.Text = "READY" Then

            clickOnTeilen()
            'ClickOnAllFriendsTimer.Start()

            runJSTimer.Start()

            Label3.Text = "30"
            Timer2.Start()

        End If
        MainTimer.Stop()
    End Sub

    Private Sub WC_DownloadProgressChanged(sender As Object, e As DownloadProgressChangedEventArgs) Handles WC.DownloadProgressChanged
        tempForm.ToolStripProgressBar1.Visible = True
        'TextBox1.Visible = True
        tempForm.ToolStripProgressBar1.Value = e.ProgressPercentage
    End Sub

    Private Sub WC_DownloadFileCompleted(sender As Object, e As AsyncCompletedEventArgs) Handles WC.DownloadFileCompleted
        tempForm.ToolStripProgressBar1.Visible = False
        extractbatchfile()
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        findInviteButton()
    End Sub

    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles CheckForSaveDialogTimer.Tick
        If WebBrowser1.Url <> Nothing Then
            If WebBrowser1.Url.ToString.Contains("save-device") Then

                checkForSaveDialog()

            End If
        End If

    End Sub

    Private Sub Timer3_Tick_1(sender As Object, e As EventArgs) Handles Timer3.Tick
        If WebBrowser1.ReadyState = WebBrowserReadyState.Complete Then
            WebBrowser1.Navigate(urlINI)
            Timer3.Stop()
        End If
    End Sub

    Public Function findInviteButton()
        If WebBrowser1.ReadyState = WebBrowserReadyState.Complete Then
            If WebBrowser1.Url.ToString.Contains("events") Then
                For Each element As HtmlElement In WebBrowser1.Document.All

                    If element.GetAttribute("href").Contains("friendselect.php") Then
                        'Nun Value auslesen
                        element.InvokeMember("click")

                    End If
                Next

                Return False
            End If
        End If
    End Function

    Public Function listallfriends()
        If WebBrowser1.ReadyState = WebBrowserReadyState.Complete Then
            Dim myLink =
           (
               From T In WebBrowser1.Document.GetElementsByTagName("a").Cast(Of HtmlElement)()
               Where T.InnerText = "Freund/in einladen"
           ).FirstOrDefault
            If myLink IsNot Nothing Then
                myLink.InvokeMember("Click")
                Beep()
            Else
                MessageBox.Show("Not found")
            End If
        End If
    End Function

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        System.Diagnostics.Process.Start("rundll32.exe", "InetCpl.cpl,ClearMyTracksByProcess 8")
        System.Diagnostics.Process.Start("rundll32.exe", "InetCpl.cpl,ClearMyTracksByProcess 2")
        System.Diagnostics.Process.Start("rundll32.exe", "InetCpl.cpl,ClearMyTracksByProcess 1")

    End Sub

    Private Sub CheckLoginTimer_Tick(sender As Object, e As EventArgs) Handles CheckLoginTimer.Tick

        If WebBrowser1.Url.ToString.Contains("login/?email=") = False Then
            CheckLoginTimer.Stop()
            MsgBox("Logged in")
        Else
            CheckLoginTimer.Stop()
            MsgBox("Email oder Passwort ist falsch")

        End If

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        listallfriends()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If WebBrowser1.ReadyState = WebBrowserReadyState.Complete Then
            Dim myLink =
          (
              From T In WebBrowser1.Document.GetElementsByTagName("a").Cast(Of HtmlElement)()
              Where T.InnerText = "Alle Freunde"
          ).FirstOrDefault
            If myLink IsNot Nothing Then
                myLink.InvokeMember("Click")
                Beep()
            Else
                MessageBox.Show("Not found")
            End If
        End If
    End Sub

    Dim anzahl As Integer = 0
    Dim page As String = "1"

    Private Sub Timer4_Tick(sender As Object, e As EventArgs) Handles Timer4.Tick
        If WebBrowser1.Url.ToString.Contains("friendinvite") Then
            If WebBrowser1.ReadyState = WebBrowserReadyState.Complete Then
                Dim myLink =
               (
                   From T In WebBrowser1.Document.GetElementsByTagName("a").Cast(Of HtmlElement)()
                   Where T.InnerText = "Weitere Personen hinzufügen"
               ).FirstOrDefault
                If myLink IsNot Nothing Then
                    myLink.InvokeMember("Click")
                Else
                    MessageBox.Show("Not found")
                End If
            End If
        ElseIf WebBrowser1.Url.ToString.Contains("friendselect") Then

            If WebBrowser1.ReadyState = WebBrowserReadyState.Complete Then
                Dim myLink =
           (
               From T In WebBrowser1.Document.GetElementsByTagName("a").Cast(Of HtmlElement)()
               Where T.InnerText = "Freund/in einladen"
           ).FirstOrDefault
                If myLink IsNot Nothing Then
                    myLink.InvokeMember("Click")
                    anzahl = anzahl + 1
                    Label4.Text = "Ausgewählt: " & anzahl
                Else
                    Dim myLink2 =
          (
              From T In WebBrowser1.Document.GetElementsByTagName("a").Cast(Of HtmlElement)()
              Where T.InnerText = page
          ).FirstOrDefault
                    If myLink2 IsNot Nothing Then
                        myLink2.InvokeMember("Click")
                        page = page + 1
                    Else
                        Timer4.Stop()
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Timer4.Start()
    End Sub

End Class