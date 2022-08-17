Imports System.IO

Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' load configs
        ' welcome to shitty code hell
        Dim locationConfig As String = root + "\JavaAppletViewer.properties"
        Dim locationDefaultConfig As String = locationConfig + ".default"

        If System.IO.File.Exists(locationConfig) Then
            Dim startupHTMLlongConfig As String = System.IO.File.ReadAllLines(locationConfig)(0)
            Dim startupHTMLshortConfig As String = Microsoft.VisualBasic.Mid(startupHTMLlongConfig, 15)
            Dim XPvisualsConfig As String = System.IO.File.ReadAllLines(locationConfig)(1)
            Dim ignoreIEwarningsConfig As String = System.IO.File.ReadAllLines(locationConfig)(2)

            WebBrowser1.Navigate(startupHTMLshortConfig)
            If XPvisualsConfig = "XPvisuals = true" Then
                Application.VisualStyleState = VisualStyles.VisualStyleState.ClientAndNonClientAreasEnabled
            Else
                Application.VisualStyleState = VisualStyles.VisualStyleState.NoneEnabled
            End If
            If ignoreIEwarningsConfig = "ignoreIEwarnings = true" Then
                WebBrowser1.ScriptErrorsSuppressed = True
            Else
                WebBrowser1.ScriptErrorsSuppressed = False
            End If
        Else
            Dim resultConfig As DialogResult = MessageBox.Show("The configuration file is missing or corrupted." & vbCrLf & vbCrLf & "Press OK to reset your settings." & vbCrLf & "Press Cancel to turn off the application.", "Java Applet Viewer: Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)
            If resultConfig = vbOK Then
                If System.IO.File.Exists(locationDefaultConfig) Then
                    My.Computer.FileSystem.CopyFile(locationDefaultConfig, locationConfig)
                    Application.Restart()
                Else
                    MessageBox.Show("Default configuration file missing or corrupted." & vbCrLf & vbCrLf & "Please reinstall Java Applet Viewer or see Java Applet Viewer's GitHub wiki.", "Java Applet Viewer: Critical Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Process.Start("https://github.com/WindowsJavaEdition/JavaAppletViewer")
                    Application.Exit()
                End If
            Else
                Application.Exit()
            End If
        End If
    End Sub

    Private Sub RestartToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RestartToolStripMenuItem.Click
        ' restart application
        Application.Restart()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        ' exit application
        Application.Exit()
    End Sub

    Private Sub ConfigureToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConfigureToolStripMenuItem.Click
        ' open configuration window
        Form2.Show()
    End Sub

    Private Sub GoToGithubPageToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GoToGithubPageToolStripMenuItem.Click
        ' open JAV's GitHub repo on default browser
        Process.Start("https://github.com/WindowsJavaEdition/JavaAppletViewer")
    End Sub

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        ' open about window
        Form3.Show()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ' launch/close applet
        Dim classCodebaseApplet As String = TextBox1.Text
        Dim classCodeApplet As String = TextBox2.Text
        Dim widthApplet As String = TextBox3.Text
        Dim heightApplet As String = TextBox4.Text

        If Button1.Text = "Launch Applet" Then

            If classCodebaseApplet = "" Then
                MsgBox("Error: No applet location provided! Can't continue.")
            Else

                If classCodeApplet = "" Then
                    MsgBox("Error: No applet(-s) provided! Can't continue.")
                Else

                    If widthApplet = "" Then
                        widthApplet = Me.Width
                    End If

                    If heightApplet = "" Then
                        heightApplet = Me.Height
                    End If

                    TextBox1.Text = classCodebaseApplet
                    TextBox1.Enabled = False
                    TextBox2.Text = classCodeApplet
                    TextBox2.Enabled = False
                    TextBox3.Text = widthApplet
                    TextBox3.Enabled = False
                    TextBox4.Text = heightApplet
                    TextBox4.Enabled = False
                    Button2.Enabled = False
                    Button1.Text = "Close Applet"

                    Dim HTMLfs As FileStream = File.Create(root + "\launcher.html")
                    Dim HTMLdata As String() = {"<html>", "<head>", "<title>Java Applet Viewer</title>", "</head>", "<body>", "<applet codebase=" + classCodebaseApplet + " code=" + classCodeApplet + " width=" + widthApplet + " height=" + heightApplet + ">", "</applet>", "</body>", "</html>"}
                    HTMLfs.Close()
                    File.WriteAllLines(root + "\launcher.html", HTMLdata)

                    WebBrowser1.Navigate(root + "\launcher.html")

                End If

            End If

        Else
            Application.Restart()
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        ' browse for applets
        OpenFileDialog1.Title = "Browse..."
        OpenFileDialog1.InitialDirectory = root + "\examples"
        OpenFileDialog1.FileName = ""
        OpenFileDialog1.DefaultExt = "class"
        OpenFileDialog1.Filter = "Java Class File (*.class)|*.class|All files (*.*)|*.*"
        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            TextBox1.Text = Path.GetDirectoryName(OpenFileDialog1.FileName)
            TextBox2.Text = Path.GetFileName(OpenFileDialog1.FileName)
        End If
    End Sub
End Class

