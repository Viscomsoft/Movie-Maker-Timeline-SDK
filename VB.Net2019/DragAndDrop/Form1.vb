Public Class Form1

    Private Sub button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button1.Click
        OpenFileDialog1.Filter = "All Files (*.*)|*.*|mpg (*.mpg*.vob) | *.mpg;*.vob|avi (*.avi) | *.avi|Divx (*.divx) | *.divx|wmv (*.wmv)| *.wmv|QuickTime (*.mov)| *.mov|MP4 (*.mp4) | *.mp4|AVCHD (*.m2ts*.ts*.mts*m2t)|*.m2ts;*.ts;*.mts;*.m2t|wav (*.wav)|*.wav|MP3 (*.mp3)|*.mp3|WMA (*.wma)|*.wma||"

        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then

            listBox1.Items.Add(OpenFileDialog1.FileName)
        End If

    End Sub

    Private Sub listBox1_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles listBox1.MouseDown
        If listBox1.Items.Count = 0 Or listBox1.SelectedItem = Nothing Then
            Exit Sub
        End If

        Dim s As String = listBox1.SelectedItem.ToString()

        Me.DoDragDrop(s, DragDropEffects.All)
       
    End Sub

    Private Sub button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button2.Click
        AxTimelineControl1.Play()
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        cboscale.Items.Add("0.01")
        cboscale.Items.Add("0.03")

        cboscale.Items.Add("0.05")
        cboscale.Items.Add("0.1")
        cboscale.Items.Add("0.2")
        cboscale.Items.Add("0.4")
        cboscale.Items.Add("1.0")
        cboscale.Items.Add("2.0")
        cboscale.Items.Add("3.0")
        cboscale.SelectedIndex = 6
    End Sub

    Private Sub cboscale_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboscale.SelectedIndexChanged
        AxTimelineControl1.SetScale(cboscale.Text)
    End Sub
End Class
