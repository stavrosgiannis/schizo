Public Class LoginForm1

    ' TODO: Code zum Durchf�hren der benutzerdefinierten Authentifizierung mithilfe des angegebenen Benutzernamens und des Kennworts hinzuf�gen 
    ' (Siehe https://go.microsoft.com/fwlink/?LinkId=35339).  
    ' Der benutzerdefinierte Prinzipal kann anschlie�end wie folgt an den Prinzipal des aktuellen Threads angef�gt werden: 
    '     My.User.CurrentPrincipal = CustomPrincipal
    ' wobei CustomPrincipal die IPrincipal-Implementierung ist, die f�r die Durchf�hrung der Authentifizierung verwendet wird. 
    ' Anschlie�end gibt My.User Identit�tsinformationen zur�ck, die in das CustomPrincipal-Objekt gekapselt sind,
    ' z. B. den Benutzernamen, den Anzeigenamen usw.
    Public Property benutzername As String
    Public Property passwort As String

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        benutzername = UsernameTextBox.Text
        passwort = PasswordTextBox.Text
        'MsgBox(benutzername & passwort)
        Me.Hide()
        ''Form1.login_facebook()
        ''Form1.redirectURLTimer.Start()
        ''Form1.MainTimer.Start()
        'Form1.AllinOne()
        'UsernameTextBox.Text = ""
        'PasswordTextBox.Text = ""
        ''Form1.MainTimer.Start()
        tempForm.DoEvents()

    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub

    Private Sub LoginForm1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
