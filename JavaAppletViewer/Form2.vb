Imports System.IO

Public Class Form2

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' check for easter egg
        If EasterEgg = 1 Then
            RadioButton1.Enabled = True
            RadioButton2.Enabled = True
        Else
            RadioButton1.Enabled = False
            RadioButton2.Enabled = False
        End If

        ' load configs again
        ' welcome to shitty code hell again
        Dim locationConfig As String = root + "\JavaAppletViewer.properties"
        Dim locationDefaultConfig As String = locationConfig + ".default"

        If System.IO.File.Exists(locationConfig) Then
            Dim startupHTMLlongConfig As String = System.IO.File.ReadAllLines(locationConfig)(0)
            Dim startupHTMLshortConfig As String = Microsoft.VisualBasic.Mid(startupHTMLlongConfig, 15)
            Dim XPvisualsConfig As String = System.IO.File.ReadAllLines(locationConfig)(1)
            Dim ignoreIEwarningsConfig As String = System.IO.File.ReadAllLines(locationConfig)(2)

            If startupHTMLshortConfig <> "" Then
                TextBox1.Text = startupHTMLshortConfig
            End If
            If XPvisualsConfig = "XPvisuals = true" Then
                CheckBox3.Checked = True
            Else
                CheckBox3.Checked = False
            End If
            If ignoreIEwarningsConfig = "ignoreIEwarnings = true" Then
                CheckBox4.Checked = True
            Else
                CheckBox4.Checked = False
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

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        ' light UI style (W.I.P)
        ' this is gonna get totally overhauled in an later update
        ' you can activate these settings with an easter egg in about window
        Form1.MenuStrip1.BackColor = Color.Gainsboro
        Form1.MenuStrip1.ForeColor = Color.Black
        Form1.BackColor = Color.WhiteSmoke
        Form1.ForeColor = Color.Black
        Me.BackColor = Color.Gainsboro
        Me.ForeColor = Color.Black
        Button1.BackColor = Color.WhiteSmoke
        Button2.BackColor = Color.WhiteSmoke
        Button3.BackColor = Color.WhiteSmoke
        Button4.BackColor = Color.WhiteSmoke
        Form1.RestartToolStripMenuItem.BackColor = Color.Gainsboro
        Form1.RestartToolStripMenuItem.ForeColor = Color.Black
        Form1.ExitToolStripMenuItem.BackColor = Color.Gainsboro
        Form1.ExitToolStripMenuItem.ForeColor = Color.Black
        Form1.ConfigureToolStripMenuItem.BackColor = Color.Gainsboro
        Form1.ConfigureToolStripMenuItem.ForeColor = Color.Black
        Form1.GoToGithubPageToolStripMenuItem.BackColor = Color.Gainsboro
        Form1.GoToGithubPageToolStripMenuItem.ForeColor = Color.Black
        Form1.AboutToolStripMenuItem.BackColor = Color.Gainsboro
        Form1.AboutToolStripMenuItem.ForeColor = Color.Black
        Form3.BackColor = Color.WhiteSmoke
        Form3.ForeColor = Color.Black
        Form3.Button1.BackColor = Color.WhiteSmoke
        Form3.PictureBox1.Image = My.Resources.normal_black
        ' I don't know why, but specificly FileToolStripMenuItem won't change
        ' it's background color when changing MenuStrip1's background color
        ' like the other Strip Menu Items, so the code below needs to be here.
        Form1.FileToolStripMenuItem.BackColor = Color.Gainsboro
    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        ' dark UI style (W.I.P)
        ' this is gonna get totally overhauled in an later update
        ' you can activate these settings with an easter egg in about window
        Form1.MenuStrip1.BackColor = Color.DimGray
        Form1.MenuStrip1.ForeColor = Color.White
        Form1.BackColor = Color.Gray
        Form1.ForeColor = Color.White
        Me.BackColor = Color.Gray
        Me.ForeColor = Color.White
        Button1.BackColor = Color.DarkGray
        Button2.BackColor = Color.DarkGray
        Button3.BackColor = Color.DarkGray
        Button4.BackColor = Color.DarkGray
        Form1.RestartToolStripMenuItem.BackColor = Color.DimGray
        Form1.RestartToolStripMenuItem.ForeColor = Color.White
        Form1.ExitToolStripMenuItem.BackColor = Color.DimGray
        Form1.ExitToolStripMenuItem.ForeColor = Color.White
        Form1.ConfigureToolStripMenuItem.BackColor = Color.DimGray
        Form1.ConfigureToolStripMenuItem.ForeColor = Color.White
        Form1.GoToGithubPageToolStripMenuItem.BackColor = Color.DimGray
        Form1.GoToGithubPageToolStripMenuItem.ForeColor = Color.White
        Form1.AboutToolStripMenuItem.BackColor = Color.DimGray
        Form1.AboutToolStripMenuItem.ForeColor = Color.White
        Form3.BackColor = Color.DimGray
        Form3.ForeColor = Color.White
        Form3.Button1.BackColor = Color.Gray
        Form3.PictureBox1.Image = My.Resources.normal_white
        ' I don't know why, but specificly FileToolStripMenuItem won't change
        ' it's background color when changing MenuStrip1's background color
        ' like the other Strip Menu Items, so the code below needs to be here.
        Form1.FileToolStripMenuItem.BackColor = Color.DimGray
    End Sub

    Private Sub CheckBox3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox3.CheckedChanged
        ' toggle XP visuals
        If CheckBox3.Checked = True Then
            Application.VisualStyleState = VisualStyles.VisualStyleState.ClientAndNonClientAreasEnabled
        ElseIf CheckBox3.Checked = False Then
            Application.VisualStyleState = VisualStyles.VisualStyleState.NoneEnabled
        End If
    End Sub

    Private Sub CheckBox4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox4.CheckedChanged
        ' toggle ignoring Internet Explorer warnings (only useful with Startup HTMLs)
        If CheckBox4.Checked = True Then
            Form1.WebBrowser1.ScriptErrorsSuppressed = True
        ElseIf CheckBox4.Checked = False Then
            Form1.WebBrowser1.ScriptErrorsSuppressed = False
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        ' close without saving
        Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        ' reset settings
        Dim locationConfig As String = root + "\JavaAppletViewer.properties"
        Dim locationDefaultConfig As String = locationConfig + ".default"

        Dim resetDialog As DialogResult = MessageBox.Show("Are you sure you want to reset to default settings?" & vbCrLf & vbCrLf & "All Java Applet Viewer user data will be lost." & vbCrLf & "(except custom UI styles)", "Java Applet Viewer: Reset to default settings", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If resetDialog = vbYes Then
            If System.IO.File.Exists(locationDefaultConfig) Then
                My.Computer.FileSystem.DeleteFile(locationConfig)
                My.Computer.FileSystem.CopyFile(locationDefaultConfig, locationConfig)
                MessageBox.Show("Restored to default settings." & vbCrLf & "Java Applet Viewer will now restart.", "Java Applet Viewer: Reset to default settings", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Application.Restart()
            Else
                MessageBox.Show("Default configuration file missing or corrupted." & vbCrLf & vbCrLf & "Please reinstall Java Applet Viewer or see Java Applet Viewer's GitHub wiki.", "Java Applet Viewer: Critical Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Process.Start("https://github.com/WindowsJavaEdition/JavaAppletViewer")
            End If
        Else
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        ' save and close
        Dim locationConfig As String = root + "\JavaAppletViewer.properties"

        Dim XPvisualsConfig As String
        Dim ignoreIEwarningsConfig As String
        Dim startupHTMLConfig As String = "startupHTML = " + TextBox1.Text

        If CheckBox3.Checked = True Then
            XPvisualsConfig = "XPvisuals = true"
        Else
            XPvisualsConfig = "XPvisuals = false"
        End If
        If CheckBox4.Checked = True Then
            ignoreIEwarningsConfig = "ignoreIEwarnings = true"
        Else
            ignoreIEwarningsConfig = "ignoreIEwarnings = false"
        End If

        If System.IO.File.Exists(locationConfig) Then
            My.Computer.FileSystem.DeleteFile(locationConfig)
        End If

        Dim CONFIGfs As FileStream = File.Create(locationConfig)
        Dim CONFIGdata As String() = {startupHTMLConfig, XPvisualsConfig, ignoreIEwarningsConfig}
        CONFIGfs.Close()
        File.WriteAllLines(locationConfig, CONFIGdata)

        Dim successDialog As DialogResult = MessageBox.Show("Saved configuration successfully." & vbCrLf & vbCrLf & "Some settings might require a restart of Java Applet Viewer." + vbCrLf + "Do you want to restart Java Applet Viewer?", "Java Applet Viewer: Success!", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
        If successDialog = vbYes Then
            Application.Restart()
        Else
            Me.Close()
        End If

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ' browse for Startup HTML file
        OpenFileDialog1.Title = "Browse..."
        OpenFileDialog1.InitialDirectory = My.Settings.HTMLstartupBrowsePath
        OpenFileDialog1.FileName = ""
        OpenFileDialog1.DefaultExt = "html"
        OpenFileDialog1.Filter = "HyperText Markup Language File (*.html)|*.html|All files (*.*)|*.*"
        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            My.Settings.HTMLstartupBrowsePath = Path.GetDirectoryName(OpenFileDialog1.FileName)
            TextBox1.Text = OpenFileDialog1.FileName
        End If
    End Sub
End Class