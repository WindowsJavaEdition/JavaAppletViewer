Public Class Form3

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ' close about window
        Me.Close()
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        ' easter egg
        ' it enables the light and dark UI styles option in configuration form (Form2.vb)
        ' when JAV is restarted or shut down it will revert back to normal
        ' this easter egg will be removed when a complete rewrite of the UI styles happens
        MessageBox.Show("You have triggered an easter egg!" & vbCrLf & vbCrLf & "See the configuration window for dark and light UI styles!" & vbCrLf & vbCrLf & "Here's a warning, though:" & vbCrLf & "This is an unfinished feature and it will be getting a rewrite in the future.", "Java Applet Viewer: Easter Egg", MessageBoxButtons.OK, MessageBoxIcon.Information)
        EasterEgg = 1
    End Sub
End Class