Imports System.IO
Imports System.Text
Imports System.Text.RegularExpressions

Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub WebBrowser1_DocumentCompleted(ByVal sender As System.Object, ByVal e As System.Windows.Forms.WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted

    End Sub

    Private Sub RestartToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RestartToolStripMenuItem.Click
        Application.Restart()
    End Sub

    Private Sub FileToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FileToolStripMenuItem.Click

    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Application.Exit()
    End Sub

    Private Sub ConfigureToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConfigureToolStripMenuItem.Click
        Form2.Show()
    End Sub

    Private Sub GoToGithubPageToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GoToGithubPageToolStripMenuItem.Click
        Process.Start("https://github.com/WindowsJavaEdition/JavaAppletViewer")
    End Sub

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        Form3.Show()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim root As String = System.Windows.Forms.Application.StartupPath

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
        Dim root As String = System.Windows.Forms.Application.StartupPath

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

