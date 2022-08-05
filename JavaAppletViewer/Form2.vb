Public Class Form2

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click

    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        Form1.MenuStrip1.BackColor = Color.WhiteSmoke
        Form1.MenuStrip1.ForeColor = Color.Black
        Form1.BackColor = Color.WhiteSmoke
        Form1.ForeColor = Color.Black
        Me.BackColor = Color.WhiteSmoke
        Me.ForeColor = Color.Black
        Button1.BackColor = Color.WhiteSmoke
        Button2.BackColor = Color.WhiteSmoke
        Button3.BackColor = Color.WhiteSmoke
        Button4.BackColor = Color.WhiteSmoke
        Form1.RestartToolStripMenuItem.BackColor = Color.WhiteSmoke
        Form1.RestartToolStripMenuItem.ForeColor = Color.Black
        Form1.ExitToolStripMenuItem.BackColor = Color.WhiteSmoke
        Form1.ExitToolStripMenuItem.ForeColor = Color.Black
        Form1.ConfigureToolStripMenuItem.BackColor = Color.WhiteSmoke
        Form1.ConfigureToolStripMenuItem.ForeColor = Color.Black
        Form1.GoToGithubPageToolStripMenuItem.BackColor = Color.WhiteSmoke
        Form1.GoToGithubPageToolStripMenuItem.ForeColor = Color.Black
        Form1.AboutToolStripMenuItem.BackColor = Color.WhiteSmoke
        Form1.AboutToolStripMenuItem.ForeColor = Color.Black
        Form3.BackColor = Color.WhiteSmoke
        Form3.ForeColor = Color.Black
        Form3.PictureBox1.Image = My.Resources.normal_black
        ' I don't know why, but specificly FileToolStripMenuItem won't change
        ' it's background color when changing MenuStrip1's background color
        ' like the other Strip Menu Items, so the code below needs to be here.
        Form1.FileToolStripMenuItem.BackColor = Color.WhiteSmoke
    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        Form1.MenuStrip1.BackColor = Color.DimGray
        Form1.MenuStrip1.ForeColor = Color.White
        Form1.BackColor = Color.DimGray
        Form1.ForeColor = Color.White
        Me.BackColor = Color.DimGray
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
        Form3.PictureBox1.Image = My.Resources.normal_white
        ' I don't know why, but specificly FileToolStripMenuItem won't change
        ' it's background color when changing MenuStrip1's background color
        ' like the other Strip Menu Items, so the code below needs to be here.
        Form1.FileToolStripMenuItem.BackColor = Color.DimGray
    End Sub
End Class