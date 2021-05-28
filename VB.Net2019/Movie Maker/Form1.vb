

Public Class Form1
    
    Public MyVar As Integer
    Public IsChanged As Boolean

    Private Sub Blacklist_ThirdPartyFilters()
        AxTimelineControl1.DecoderFilterClearList()


        If chkblacklist.Checked Then

            AxTimelineControl1.DecoderFilterType = 0
            AxTimelineControl1.DecoderFilterAddToList("LAV  Splitter")
            AxTimelineControl1.DecoderFilterAddToList("LAV Audio Decoder")
            AxTimelineControl1.DecoderFilterAddToList("Microsoft DTV-DVD Video Decoder")
            AxTimelineControl1.DecoderFilterAddToList("Microsoft DTV-DVD Audio Decoder")
            AxTimelineControl1.DecoderFilterAddToList("ffdshow Video Decoder")
            AxTimelineControl1.DecoderFilterAddToList("Elecard AVC Video Decoder HD")
            AxTimelineControl1.DecoderFilterAddToList("MainConcept AVC/H.264 Video Decoder")
            AxTimelineControl1.DecoderFilterAddToList("MainConcept (Adobe2) AVC/H.264 Video Decoder")
            AxTimelineControl1.DecoderFilterAddToList("Sonic AVC/H.264 Video Decoder")
            AxTimelineControl1.DecoderFilterAddToList("AVObjects H.264/AVC Decoder")
            AxTimelineControl1.DecoderFilterAddToList("Sonic Cinemaster® VideoDecoder 4.3 (Game1X)")
            AxTimelineControl1.DecoderFilterAddToList("VisioForge YUV2RGB")
            AxTimelineControl1.DecoderFilterAddToList("Elecard MP4 Demultiplexer")


        End If
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click

        Blacklist_ThirdPartyFilters()

     
        AxTimelineControl1.PreviewWndAspectRatio = chkpreviewaspectratio.Checked

        If AxTimelineControl1.IsPause And IsChanged = False Then



            AxTimelineControl1.Play()
        Else


            AxTimelineControl1.Stop()

            If chkusedualdisplay.Checked Then
                AxTimelineControl1.UseDualDisplay = True
            Else
                AxTimelineControl1.UseDualDisplay = False
            End If
            AxTimelineControl1.SetVideoTrackFrameRate(txtvideotrackframerate.Text)
            AxTimelineControl1.SetVideoTrackResolution(txtvideotrackwidth.Text, txtvideotrackheight.Text)
            AxTimelineControl1.Play()

            ListBox1.Items.Clear()
            For i = 0 To AxTimelineControl1.DecoderGetCurrentFiltersCount() - 1

                ListBox1.Items.Add(AxTimelineControl1.DecoderGetCurrentFilterName(i))
            Next


            IsChanged = False
        End If
        UpdateTimelineDuration()
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        radioDragOverToRight.Checked = True
        cbopreviewsize.Items.Add("Fit To Window")
        cbopreviewsize.Items.Add("150")
        cbopreviewsize.Items.Add("140")
        cbopreviewsize.Items.Add("130")
        cbopreviewsize.Items.Add("120")
        cbopreviewsize.Items.Add("110")
        cbopreviewsize.Items.Add("100")
        cbopreviewsize.Items.Add("90")
        cbopreviewsize.Items.Add("80")
        cbopreviewsize.Items.Add("70")
        cbopreviewsize.Items.Add("60")
        cbopreviewsize.Items.Add("50")
        cbopreviewsize.Items.Add("40")
        cbopreviewsize.Items.Add("30")
        cbopreviewsize.Items.Add("20")

        cbopreviewsize.SelectedIndex = 0










        TabControl1.SelectedIndex = 1
        TabOutputType.SelectedIndex = 2

        cboimagestretchmode.Items.Add("Stretched To Fit")
        cboimagestretchmode.Items.Add("No Resize")
        cboimagestretchmode.Items.Add("Keep Aspect Ratio")
        cboimagestretchmode.Items.Add("Resize no letter box")
        cboimagestretchmode.SelectedIndex = 0


        cbovideostretchmode.Items.Add("Stretched To Fit")
        cbovideostretchmode.Items.Add("No Resize")
        cbovideostretchmode.Items.Add("Keep Aspect Ratio")
        cbovideostretchmode.Items.Add("Resize no letter box")
        cbovideostretchmode.SelectedIndex=0


        cbovideostretchmode2.Items.Add("Stretched To Fit")
        cbovideostretchmode2.Items.Add("No Resize")
        cbovideostretchmode2.Items.Add("Keep Aspect Ratio")
        cbovideostretchmode2.Items.Add("Resize no letter box")
        cbovideostretchmode2.SelectedIndex = 0


        MyVar = 0
        IsChanged = False

        cboGPU.Items.Add("None")
        cboGPU.Items.Add("Nvidia")
        cboGPU.Items.Add("AMD")
        cboGPU.Items.Add("Intel")
        cboGPU.SelectedIndex = 0


        cbonvidapreset.Items.Add("slow")
        cbonvidapreset.Items.Add("medium")
        cbonvidapreset.Items.Add("fast")
        cbonvidapreset.Items.Add("high performance")
        cbonvidapreset.Items.Add("high quality")
        cbonvidapreset.Items.Add("bluray disk")
        cbonvidapreset.Items.Add("low latency")
        cbonvidapreset.Items.Add("low latency high quality")
        cbonvidapreset.Items.Add("low latency high performance")
        cbonvidapreset.Items.Add("lossless")
        cbonvidapreset.Items.Add("lossless high performance")
        cbonvidapreset.SelectedIndex = 3

        cboBgTheme.Items.Add("Panel")
        cboBgTheme.Items.Add("Track")
        cboBgTheme.Items.Add("Track Title")
        cboBgTheme.Items.Add("Content")
        cboBgTheme.Items.Add("Time Scale")
        cboBgTheme.Items.Add("ScrollBar")
        cboBgTheme.Items.Add("ScrollBar Item")
        cboBgTheme.Items.Add("ToolTip")
        cboBgTheme.Items.Add("SeekBar")
        cboBgTheme.SelectedIndex = 0

        cboFgTheme.Items.Add("Content")
        cboFgTheme.Items.Add("Time Scale")
        cboFgTheme.Items.Add("ScrollBar Item")
        cboFgTheme.Items.Add("ToolTip")
        cboFgTheme.Items.Add("SeekBar")
        cboFgTheme.SelectedIndex = 0

        cboBorderTheme.Items.Add("Content")
        cboBorderTheme.Items.Add("Time Scale")
        cboBorderTheme.Items.Add("ScrollBar")
        cboBorderTheme.Items.Add("ScrollBar Item")
        cboBorderTheme.Items.Add("SelectionBox")
        cboBorderTheme.Items.Add("ToolTip")
        cboBorderTheme.Items.Add("SeekBar")
        cboBorderTheme.SelectedIndex = 0

        'audio 1
         cboavchdaudiosamplerate.Items.Add("44100")
        cboavchdaudiosamplerate.Items.Add("48000")
        cboavchdaudiosamplerate.SelectedIndex = 0

        cboavchdvideobitrate.Items.Add("256")
        cboavchdvideobitrate.Items.Add("384")
        cboavchdvideobitrate.Items.Add("512")
        cboavchdvideobitrate.Items.Add("768")
        cboavchdvideobitrate.Items.Add("1024")
        cboavchdvideobitrate.Items.Add("4096")
        cboavchdvideobitrate.SelectedIndex = 0

        cboavchdaudiobitrate.Items.Add("48")
        cboavchdaudiobitrate.Items.Add("96")
        cboavchdaudiobitrate.Items.Add("128")
        cboavchdaudiobitrate.Items.Add("256")
        cboavchdaudiobitrate.SelectedIndex = 1


        cboavchdframerate.Items.Add("23.97")
        cboavchdframerate.Items.Add("24")
        cboavchdframerate.Items.Add("25")
        cboavchdframerate.Items.Add("29.97")

        cboavchdframerate.SelectedIndex = 2


        cboMpegFrameRate.Items.Add(("23.976"))
        cboMpegFrameRate.Items.Add(("24"))
        cboMpegFrameRate.Items.Add(("25"))
        cboMpegFrameRate.Items.Add(("29.97"))
        cboMpegFrameRate.Items.Add(("30"))
        cboMpegFrameRate.Items.Add(("50"))
        cboMpegFrameRate.Items.Add(("59.94"))
        cboMpegFrameRate.SelectedIndex = 0

        cboMpegType.Items.Add(("VCD PAL"))
        cboMpegType.Items.Add(("VCD NTSC"))
        cboMpegType.Items.Add(("SVCD PAL"))
        cboMpegType.Items.Add(("SVCD NTSC"))
        cboMpegType.Items.Add(("DVD PAL"))
        cboMpegType.Items.Add(("DVD NTSC"))
        cboMpegType.Items.Add(("MPEG1"))
        cboMpegType.Items.Add(("MPEG2"))
        cboMpegType.SelectedIndex = 0

        cboMpegaudiosamplerate.Items.Add(("32000"))
        cboMpegaudiosamplerate.Items.Add(("44100"))
        cboMpegaudiosamplerate.Items.Add(("48000"))
        cboMpegaudiosamplerate.SelectedIndex = 1


        cboscale.Items.Add("0.01")
        cboscale.Items.Add("0.03")

        cboscale.Items.Add("0.05")
        cboscale.Items.Add("0.1")
        cboscale.Items.Add("0.2")
        cboscale.Items.Add("0.4")
        cboscale.Items.Add("1.0")
        cboscale.Items.Add("2.0")
        cboscale.Items.Add("3.0")
        cboscale.SelectedIndex = 0

        cbotrantrack.Items.Add("Video")
        cbotrantrack.Items.Add("Image")
        cbotrantrack.SelectedIndex = 0

        txtvideo1trackindex.Text = AxTimelineControl1.GetVideo1TrackIndex()
        txtvideo2trackindex.Text = AxTimelineControl1.GetVideo2TrackIndex()
        txtimagetrackindex.Text = AxTimelineControl1.GetImageTrackIndex()
        txtaudio1trackindex.Text = AxTimelineControl1.GetAudio1TrackIndex()
        txtaudio2trackindex.Text = AxTimelineControl1.GetAudio2TrackIndex()

        txteffecttrackindex.Text = AxTimelineControl1.GetEffectTrackIndex()
        txttrantrackindex.Text = AxTimelineControl1.GetTransitionTrackIndex()
        txttexttrackindex.Text = AxTimelineControl1.GetTextTrackIndex()

        Dim iCount As Integer
        Dim strEffect As String
        Dim strTransition As String
        Dim strVideoCompressor As String
        Dim strAudioCompressor As String
        Dim strWMVProfile As String

        iCount = 0
        strEffect = "Empty"
        Do While strEffect <> ""

            strEffect = AxTimelineControl1.GetDESEffect(iCount)

            If (strEffect <> "") Then
                cboeffectname.Items.Add(strEffect)
                iCount = iCount + 1
            End If

        Loop

        If cboeffectname.Items.Count > 0 Then
            cboeffectname.SelectedIndex = 0
        End If


        iCount = 0
        strTransition = "Empty"
        Do While strTransition <> ""

            strTransition = AxTimelineControl1.GetDESTransition(iCount)

            If (strTransition <> "") Then
                cbotranname.Items.Add(strTransition)
                iCount = iCount + 1
            End If

        Loop

        If cbotranname.Items.Count > 0 Then
            cbotranname.SelectedIndex = 0
        End If



        iCount = 0
        strVideoCompressor = "Empty"
        Do While strVideoCompressor <> ""

            strVideoCompressor = AxTimelineControl1.GetVideoEncoder(iCount)

            If (strVideoCompressor <> "") Then
                cboavivencoder.Items.Add(strVideoCompressor)

                If strVideoCompressor = "DV Video Encoder" Then
                    cboavivencoder.SelectedIndex = iCount

                End If
                iCount = iCount + 1
            End If

        Loop

        ' If cboavivencoder.Items.Count > 0 Then
        'cboavivencoder.SelectedIndex = 0
        ' End If


        iCount = 0
        strAudioCompressor = "Empty"
        Do While strAudioCompressor <> ""

            strAudioCompressor = AxTimelineControl1.GetAudioEncoder(iCount)

            If (strAudioCompressor <> "") Then
                cboaviaencoder.Items.Add(strAudioCompressor)

                If strAudioCompressor = "PCM" Then
                    cboaviaencoder.SelectedIndex = iCount

                End If
                iCount = iCount + 1
            End If

        Loop


        iCount = 0
        strWMVProfile = "Empty"
        Do While strWMVProfile <> ""

            strWMVProfile = AxTimelineControl1.GetWMVProfile(iCount)

            If (strWMVProfile <> "") Then
                cboWMVProfile.Items.Add(strWMVProfile)
                iCount = iCount + 1
            End If

        Loop

        If cboWMVProfile.Items.Count > 0 Then
            cboWMVProfile.SelectedIndex = 0
        End If



        AxTimelineControl1.SetPreviewWnd(PictureBox1.Handle)

        cboMP4AspectRadio.Items.Add(("4:3"))
        cboMP4AspectRadio.Items.Add(("16:9"))
        cboMP4AspectRadio.SelectedIndex = 0

        cbopreset.Items.Add("superfast")
        cbopreset.Items.Add("veryfast")
        cbopreset.Items.Add("faster")
        cbopreset.Items.Add("fast")
        cbopreset.Items.Add("medium")
        cbopreset.Items.Add("slow")
        cbopreset.Items.Add("slower")
        cbopreset.Items.Add("veryslow")
        cbopreset.SelectedIndex = 0

    End Sub

    Private Sub cboscale_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboscale.SelectedIndexChanged
        AxTimelineControl1.SetScale(cboscale.Text)
    End Sub

 
    Private Sub Button6_Click(sender As System.Object, e As System.EventArgs) Handles Button6.Click

        OpenFileDialog1.Filter = "All Files (*.*)|*.*|mpg (*.mpg*.vob) | *.mpg;*.vob|avi (*.avi) | *.avi|Divx (*.divx) | *.divx|wmv (*.wmv)| *.wmv|QuickTime (*.mov)| *.mov|MP4 (*.mp4) | *.mp4|WebM (*.webm) | *.webm|FLV (*.flv) | *.flv|MKV (*.mkv) | *.mkv|AVCHD (*.m2ts*.ts*.mts*m2t)|*.m2ts;*.ts;*.mts;*.m2t||"


        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then

            txtvideo1.Text = OpenFileDialog1.FileName

            AxTimelineControl1.GetMediaInfo(txtvideo1.Text, txtvideo1clipstop.Text, TextBoxWidth.Text, TextBoxHeight.Text, TextBoxFrameRate.Text, TextBoxVideoBitrate.Text, TextBoxAudioBitrate.Text, TextBoxAudioSample.Text, TextBoxAudioChannel.Text, TextBoxVideoStreamCount.Text, TextBoxAudioStreamCount.Text, TextBoxMediaContainer.Text, TextBoxVideoStreamFormat.Text, TextBoxAudioStreamFormat.Text)

            txtvideo1clipstart.Text = "0"
            txtvideo1mediastart.Text = "0"


        End If

    End Sub
    Private Sub UpdateTimelineDuration()
        txtTimelineDur.Text = AxTimelineControl1.GetTimelineDuration()
    End Sub
    Private Sub btnaddvideo1_Click(sender As System.Object, e As System.EventArgs) Handles btnaddvideo1.Click
        Dim iResultClipIndex As Integer

        iResultClipIndex = AxTimelineControl1.AddVideoClip(txtvideo1trackindex.Text, txtvideo1.Text, txtvideo1clipstart.Text, txtvideo1clipstop.Text, txtvideo1mediastart.Text, cbovideostretchmode.SelectedIndex)

        If iResultClipIndex = -6 Then
            MessageBox.Show("Does not support this media format")
            Exit Sub
        ElseIf iResultClipIndex = -5 Then
            MessageBox.Show("Unknow error")
            Exit Sub
        ElseIf iResultClipIndex = -4 Then
            MessageBox.Show("track no found")
            Exit Sub
        ElseIf iResultClipIndex = -3 Then
            MessageBox.Show("clipStartTime >= clipStopTime")
            Exit Sub
        ElseIf iResultClipIndex = -2 Then
            MessageBox.Show("the path of video file not found")
            Exit Sub
        ElseIf iResultClipIndex = -1 Then
            MessageBox.Show("the path of video file is empty")
            Exit Sub

        End If


        txtvideo1clipindex.Text = iResultClipIndex

        If TextBoxAudioStreamCount.Text <> 0 Then
            AxTimelineControl1.AddAudioClip(txtaudio1trackindex.Text, txtvideo1.Text, txtvideo1clipstart.Text, txtvideo1clipstop.Text, txtvideo1mediastart.Text, txtaudio1volume.Text)
        End If

        If txtvideo1clipindex.Text = "0" Then
            txtvideotrackwidth.Text = TextBoxWidth.Text
            txtvideotrackheight.Text = TextBoxHeight.Text
            AxTimelineControl1.SetVideoTrackResolution(TextBoxWidth.Text, TextBoxHeight.Text)

        End If

        IsChanged = True

        UpdateTimelineDuration()
    End Sub

    Private Sub Button5_Click(sender As System.Object, e As System.EventArgs) Handles Button5.Click
        Dim iResult As Integer
        iResult = AxTimelineControl1.ChangeVideoClip(txtvideo1trackindex.Text, txtvideo1clipindex.Text, txtvideo1.Text, txtvideo1clipstart.Text, txtvideo1clipstop.Text, txtvideo1mediastart.Text)
        IsChanged = True
        UpdateTimelineDuration()
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub CheckBox1_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub Button7_Click(sender As System.Object, e As System.EventArgs) Handles Button7.Click
        AxTimelineControl1.DeleteClip(txtvideo1trackindex.Text, txtvideo1clipindex.Text)
        IsChanged = True
        UpdateTimelineDuration()
    End Sub



    Private Sub Button8_Click(sender As System.Object, e As System.EventArgs)
    End Sub

    Private Sub chkVideo1Visible_Click(sender As System.Object, e As System.EventArgs) Handles chkVideo1Visible.Click
        If chkVideo1Visible.Checked Then
            AxTimelineControl1.SetTrackVisible(txtvideo1trackindex.Text, True)
        Else
            AxTimelineControl1.SetTrackVisible(txtvideo1trackindex.Text, False)

        End If
    End Sub

    Private Sub Button11_Click(sender As System.Object, e As System.EventArgs) Handles Button11.Click
        OpenFileDialog1.Filter = "All Files (*.*)|*.*|mpg (*.mpg*.vob) | *.mpg;*.vob|avi (*.avi) | *.avi|Divx (*.divx) | *.divx|wmv (*.wmv)| *.wmv|QuickTime (*.mov)| *.mov|MP4 (*.mp4) | *.mp4|WebM (*.webm) | *.webm|FLV (*.flv) | *.flv|MKV (*.mkv) | *.mkv|AVCHD (*.m2ts*.ts*.mts*m2t)|*.m2ts;*.ts;*.mts;*.m2t||"

        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then

            txtvideo2.Text = OpenFileDialog1.FileName
            AxTimelineControl1.GetMediaInfo(txtvideo2.Text, txtvideo2clipstop.Text, TextBoxWidth2.Text, TextBoxHeight2.Text, TextBoxFrameRate2.Text, TextBoxVideoBitrate2.Text, TextBoxAudioBitrate2.Text, TextBoxAudioSample2.Text, TextBoxAudioChannel2.Text, TextBoxVideoStreamCount2.Text, TextBoxAudioStreamCount2.Text, TextBoxMediaContainer2.Text, TextBoxVideoStreamFormat2.Text, TextBoxAudioStreamFormat2.Text)

            txtvideo2clipstart.Text = "0"
            txtvideo2mediastart.Text = "0"


        End If
    End Sub

    Private Sub Button12_Click(sender As System.Object, e As System.EventArgs) Handles Button12.Click
        Dim iResultClipIndex As Integer
        iResultClipIndex = AxTimelineControl1.AddVideoClip(txtvideo2trackindex.Text, txtvideo2.Text, txtvideo2clipstart.Text, txtvideo2clipstop.Text, txtvideo2mediastart.Text, cbovideostretchmode2.SelectedIndex)

        If iResultClipIndex = -6 Then
            MessageBox.Show("Does not support this media format")
            Exit Sub
        ElseIf iResultClipIndex = -5 Then
            MessageBox.Show("Unknow error")
            Exit Sub
        ElseIf iResultClipIndex = -4 Then
            MessageBox.Show("track no found")
            Exit Sub
        ElseIf iResultClipIndex = -3 Then
            MessageBox.Show("clipStartTime >= clipStopTime")
            Exit Sub
        ElseIf iResultClipIndex = -2 Then
            MessageBox.Show("the path of video file not found")
            Exit Sub
        ElseIf iResultClipIndex = -1 Then
            MessageBox.Show("the path of video file is empty")
            Exit Sub

        End If

        txtvideo2clipindex.Text = iResultClipIndex

        If TextBoxAudioStreamCount2.Text <> 0 Then
            AxTimelineControl1.AddAudioClip(txtaudio2trackindex.Text, txtvideo2.Text, txtvideo2clipstart.Text, txtvideo2clipstop.Text, txtvideo2mediastart.Text, txtaudio2volume.Text)
        End If

        IsChanged = True
        UpdateTimelineDuration()
    End Sub

    Private Sub Button10_Click(sender As System.Object, e As System.EventArgs) Handles Button10.Click
        AxTimelineControl1.ChangeVideoClip(txtvideo2trackindex.Text, txtvideo2clipindex.Text, txtvideo2.Text, txtvideo2clipstart.Text, txtvideo2clipstop.Text, txtvideo2mediastart.Text)
        IsChanged = True
        UpdateTimelineDuration()
    End Sub

    Private Sub Button9_Click(sender As System.Object, e As System.EventArgs) Handles Button9.Click
        AxTimelineControl1.DeleteClip(txtvideo2trackindex.Text, txtvideo2clipindex.Text)
        IsChanged = True
        UpdateTimelineDuration()
    End Sub

    Private Sub chkVideo2Visible_Click(sender As System.Object, e As System.EventArgs) Handles chkVideo2Visible.Click
        If chkVideo2Visible.Checked Then
            AxTimelineControl1.SetTrackVisible(txtvideo2trackindex.Text, True)
        Else
            AxTimelineControl1.SetTrackVisible(txtvideo2trackindex.Text, False)

        End If
    End Sub

    Private Sub Button13_Click(sender As System.Object, e As System.EventArgs) Handles Button13.Click

        OpenFileDialog1.Filter = "JPEG Files (*.jpg)|*.jpg|BMP Files (*.bmp)|*.bmp||"

        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then

            txtimage.Text = OpenFileDialog1.FileName

        End If

    End Sub

    Private Sub Button16_Click(sender As System.Object, e As System.EventArgs) Handles Button16.Click
        txtimageclipindex.Text = AxTimelineControl1.AddImageClip(txtimagetrackindex.Text, txtimage.Text, txtimageclipstart.Text, txtimageclipstop.Text, cboimagestretchmode.SelectedIndex)
        IsChanged = True
        UpdateTimelineDuration()
    End Sub

    Private Sub chkImageVisible_Click(sender As System.Object, e As System.EventArgs) Handles chkImageVisible.Click
        If chkImageVisible.Checked Then
            AxTimelineControl1.SetTrackVisible(txtimagetrackindex.Text, True)
        Else
            AxTimelineControl1.SetTrackVisible(txtimagetrackindex.Text, False)

        End If
    End Sub

    Private Sub Button15_Click(sender As System.Object, e As System.EventArgs) Handles Button15.Click
        AxTimelineControl1.ChangeImageClip(txtimagetrackindex.Text, txtimageclipindex.Text, txtimage.Text, txtimageclipstart.Text, txtimageclipstop.Text)
        IsChanged = True
        UpdateTimelineDuration()
    End Sub

    Private Sub chkAudio1Visible_Click(sender As System.Object, e As System.EventArgs) Handles chkAudio1Visible.Click
        If chkAudio1Visible.Checked Then
            AxTimelineControl1.SetTrackVisible(txtaudio1trackindex.Text, True)
        Else
            AxTimelineControl1.SetTrackVisible(txtaudio1trackindex.Text, False)

        End If
    End Sub

    Private Sub Button20_Click(sender As System.Object, e As System.EventArgs) Handles Button20.Click
        Dim iResultClipIndex As Integer
        iResultClipIndex = AxTimelineControl1.AddAudioClip(txtaudio1trackindex.Text, txtaudio1.Text, txtaudio1clipstart.Text, txtaudio1clipstop.Text, txtaudio1mediastart.Text, txtaudio1volume.Text)

      
        If iResultClipIndex = -6 Then
            MessageBox.Show("Does not support this media format")
            Exit Sub
        ElseIf iResultClipIndex = -5 Then
            MessageBox.Show("Unknow error")
            Exit Sub
        ElseIf iResultClipIndex = -4 Then
            MessageBox.Show("track no found")
            Exit Sub
        ElseIf iResultClipIndex = -3 Then
            MessageBox.Show("clipStartTime >= clipStopTime")
            Exit Sub
        ElseIf iResultClipIndex = -2 Then
            MessageBox.Show("the path of video/audio file not found")
            Exit Sub
        ElseIf iResultClipIndex = -1 Then
            MessageBox.Show("the path of video/audio file is empty")
            Exit Sub

        End If
        txtaudio1clipindex.Text = iResultClipIndex

        IsChanged = True
        UpdateTimelineDuration()
    End Sub

    Private Sub Button19_Click(sender As System.Object, e As System.EventArgs) Handles Button19.Click

        OpenFileDialog1.Filter = "All Files (*.*)|*.*|wav (*.wav)|*.wav|MP3 (*.mp3)|*.mp3|WMA (*.wma)|*.wma|M4a (*.m4a)|*.m4a|Ogg (*.ogg)|*.ogg|AC3 (*.ac3)|*.ac3|Flac (*.flac)|*.flac|MP2 (*.mp2)|*.mp2|mpg (*.mpg*.vob) | *.mpg;*.vob|avi (*.avi) | *.avi|Divx (*.divx) | *.divx|wmv (*.wmv)| *.wmv|QuickTime (*.mov)| *.mov|MP4 (*.mp4) | *.mp4|WebM (*.webm) | *.webm|FLV (*.flv) | *.flv|MKV (*.mkv) | *.mkv|AVCHD (*.m2ts*.ts*.mts*m2t)|*.m2ts;*.ts;*.mts;*.m2t||"

        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then


            txtaudio1.Text = OpenFileDialog1.FileName

            AxTimelineControl1.GetMediaInfo(txtaudio1.Text, txtaudio1clipstop.Text, TextBoxA1Width.Text, TextBoxA1Height.Text, TextBoxA1FrameRate.Text, TextBoxA1VideoBitrate.Text, TextBoxA1AudioBitrate.Text, TextBoxA1AudioSample.Text, TextBoxA1AudioChannel.Text, TextBoxA1VideoStreamCount.Text, TextBoxA1AudioStreamCount.Text, TextBoxA1MediaContainer.Text, TextBoxA1VideoStreamFormat.Text, TextBoxA1AudioStreamFormat.Text)

           
            txtaudio1clipstart.Text = "0"

        End If

    End Sub

    Private Sub chkAudio2Visible_Click(sender As System.Object, e As System.EventArgs) Handles chkAudio2Visible.Click
        If chkAudio2Visible.Checked Then
            AxTimelineControl1.SetTrackVisible(txtaudio2trackindex.Text, True)
        Else
            AxTimelineControl1.SetTrackVisible(txtaudio2trackindex.Text, False)

        End If
    End Sub

    Private Sub Button23_Click(sender As System.Object, e As System.EventArgs) Handles Button23.Click
        OpenFileDialog1.Filter = "All Files (*.*)|*.*|wav (*.wav)|*.wav|MP3 (*.mp3)|*.mp3|WMA (*.wma)|*.wma|M4a (*.m4a)|*.m4a|Ogg (*.ogg)|*.ogg|AC3 (*.ac3)|*.ac3|Flac (*.flac)|*.flac|MP2 (*.mp2)|*.mp2|mpg (*.mpg*.vob) | *.mpg;*.vob|avi (*.avi) | *.avi|Divx (*.divx) | *.divx|wmv (*.wmv)| *.wmv|QuickTime (*.mov)| *.mov|MP4 (*.mp4) | *.mp4|WebM (*.webm) | *.webm|FLV (*.flv) | *.flv|MKV (*.mkv) | *.mkv|AVCHD (*.m2ts*.ts*.mts*m2t)|*.m2ts;*.ts;*.mts;*.m2t||"


        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then

            txtaudio2.Text = OpenFileDialog1.FileName
            AxTimelineControl1.GetMediaInfo(txtaudio2.Text, txtaudio2clipstop.Text, TextBoxA2Width.Text, TextBoxA2Height.Text, TextBoxA2FrameRate.Text, TextBoxA2VideoBitrate.Text, TextBoxA2AudioBitrate.Text, TextBoxA2AudioSample.Text, TextBoxA2AudioChannel.Text, TextBoxA2VideoStreamCount.Text, TextBoxA2AudioStreamCount.Text, TextBoxA2MediaContainer.Text, TextBoxA2VideoStreamFormat.Text, TextBoxA2AudioStreamFormat.Text)

            txtaudio2clipstart.Text = "0"

        End If

    End Sub

    Private Sub Button24_Click(sender As System.Object, e As System.EventArgs) Handles Button24.Click
        Dim iResultClipIndex As Integer
        txtaudio2clipindex.Text = AxTimelineControl1.AddAudioClip(txtaudio2trackindex.Text, txtaudio2.Text, txtaudio2clipstart.Text, txtaudio2clipstop.Text, txtaudio2mediastart.Text, txtaudio2volume.Text)

        If iResultClipIndex = -6 Then
            MessageBox.Show("Does not support this media format")
            Exit Sub
        ElseIf iResultClipIndex = -5 Then
            MessageBox.Show("Unknow error")
            Exit Sub
        ElseIf iResultClipIndex = -4 Then
            MessageBox.Show("track no found")
            Exit Sub
        ElseIf iResultClipIndex = -3 Then
            MessageBox.Show("clipStartTime >= clipStopTime")
            Exit Sub
        ElseIf iResultClipIndex = -2 Then
            MessageBox.Show("the path of video/audio file not found")
            Exit Sub
        ElseIf iResultClipIndex = -1 Then
            MessageBox.Show("the path of video/audio file is empty")
            Exit Sub

        End If
        txtaudio2clipindex.Text = iResultClipIndex

        IsChanged = True
        UpdateTimelineDuration()
    End Sub

    Private Sub Button18_Click(sender As System.Object, e As System.EventArgs) Handles Button18.Click
        AxTimelineControl1.ChangeAudioClip(txtaudio1trackindex.Text, txtaudio1clipindex.Text, txtaudio1.Text, txtaudio1clipstart.Text, txtaudio1clipstop.Text, txtaudio1mediastart.Text, txtaudio1volume.Text)
        IsChanged = True
        UpdateTimelineDuration()
    End Sub

    Private Sub Button17_Click(sender As System.Object, e As System.EventArgs) Handles Button17.Click
        AxTimelineControl1.DeleteClip(txtaudio1trackindex.Text, txtaudio1clipindex.Text)
        IsChanged = True
        UpdateTimelineDuration()
    End Sub

    Private Sub Button22_Click(sender As System.Object, e As System.EventArgs) Handles Button22.Click
        AxTimelineControl1.ChangeAudioClip(txtaudio2trackindex.Text, txtaudio2clipindex.Text, txtaudio2.Text, txtaudio2clipstart.Text, txtaudio2clipstop.Text, txtaudio2mediastart.Text, txtaudio2volume.Text)
        IsChanged = True
        UpdateTimelineDuration()
    End Sub

    Private Sub Button21_Click(sender As System.Object, e As System.EventArgs) Handles Button21.Click
        AxTimelineControl1.DeleteClip(txtaudio2trackindex.Text, txtaudio2clipindex.Text)
        IsChanged = True
        UpdateTimelineDuration()
    End Sub

    Public Function Color2Uint32(ByVal clr As Color) As UInt32
        Dim t As Int32
        Dim a() As Byte

        t = ColorTranslator.ToOle(clr)


        a = BitConverter.GetBytes(t)

        Return BitConverter.ToUInt32(a, 0)


    End Function

    Private Sub Button28_Click(sender As System.Object, e As System.EventArgs) Handles Button28.Click
        ' 
        AxTimelineControl1.SetTextClipQuality(720, 480)

        txttextclipindex.Text = AxTimelineControl1.AddTextClip(txttexttrackindex.Text, txtText.Text, txttextclipstart.Text, txttextclipstop.Text, FontDialog1.Font.ToHfont(), txtTextX.Text, txtTextY.Text, Color2Uint32(ColorDialog1.Color))
        IsChanged = True
        UpdateTimelineDuration()

        ' video track resolution will affect the text clip quality
        If txtvideotrackwidth.Text <= 640 Then
            txtvideotrackwidth.Text = "720"
            txtvideotrackheight.Text = "480"
            AxTimelineControl1.SetVideoTrackResolution(txtvideotrackwidth.Text, txtvideotrackheight.Text)


        End If
       

    End Sub

    Private Sub Button25_Click(sender As System.Object, e As System.EventArgs) Handles Button25.Click
        FontDialog1.ShowDialog()

    End Sub

    Private Sub Button29_Click(sender As System.Object, e As System.EventArgs) Handles Button29.Click
        ColorDialog1.ShowDialog()
    End Sub

    Private Sub Button27_Click(sender As System.Object, e As System.EventArgs) Handles Button27.Click
        AxTimelineControl1.ChangeTextClip(txttexttrackindex.Text, txttextclipindex.Text, txtText.Text, txttextclipstart.Text, txttextclipstop.Text, FontDialog1.Font.ToHfont(), txtTextX.Text, txtTextY.Text, Color2Uint32(ColorDialog1.Color))
        IsChanged = True
        UpdateTimelineDuration()
    End Sub

    Private Sub cboeffectname_Click(sender As System.Object, e As System.EventArgs) Handles cboeffectname.Click



    End Sub

    Private Sub cboeffectname_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboeffectname.SelectedIndexChanged
        If cboeffectname.Text = "BasicImage" Then
            txtEffectParam.Text = "GrayScale=1,Invert=0,Mirror=0,Rotation=0,XRay=0"
        ElseIf cboeffectname.Text = "Blur" Then
            txtEffectParam.Text = "PixelRadius=10.0"
        ElseIf cboeffectname.Text = "Emboss" Then
            txtEffectParam.Text = "Bias=0.7"
        ElseIf cboeffectname.Text = "Engrave" Then
            txtEffectParam.Text = "Bias=1.0"
        ElseIf cboeffectname.Text = "MotionBlur" Then
            txtEffectParam.Text = "Direction=90,Strength=5"
        ElseIf cboeffectname.Text = "Pixelate" Then
            txtEffectParam.Text = "MaxSquare=20,Percent=25"
        ElseIf cboeffectname.Text = "Wave" Then
            txtEffectParam.Text = "Freq=3,LightStrength=15,Phase=75,Strength=50"
        ElseIf cboeffectname.Text = "Microsoft Movie Maker Age Filter" Then
            txtEffectParam.Text = "Age=50"
        ElseIf cboeffectname.Text = "Shadow" Then
            txtEffectParam.Text = "direction=50,color=#0000FF,strength=20"
        ElseIf cboeffectname.Text = "Chroma" Then
            txtEffectParam.Text = "color=FFFFFF"



        Else
            txtEffectParam.Text = ""
        End If
    End Sub

    Private Sub Button32_Click(sender As System.Object, e As System.EventArgs) Handles Button32.Click

        txteffectclipindex.Text = AxTimelineControl1.AddEffect(txteffecttrackindex.Text, cboeffectname.Text, txteffectstart.Text, txteffectstop.Text, txtEffectParam.Text)
        IsChanged = True
        UpdateTimelineDuration()
    End Sub

    Private Sub Button31_Click(sender As System.Object, e As System.EventArgs) Handles Button31.Click
        AxTimelineControl1.ChangeEffect(txteffecttrackindex.Text, txteffectclipindex.Text, cboeffectname.Text, txteffectstart.Text, txteffectstop.Text, txtEffectParam.Text)
        IsChanged = True
        UpdateTimelineDuration()
    End Sub

    Private Sub chkEffectVisible_Click(sender As System.Object, e As System.EventArgs) Handles chkEffectVisible.Click


        If chkEffectVisible.Checked Then
            AxTimelineControl1.SetTrackVisible(txteffecttrackindex.Text, True)
        Else
            AxTimelineControl1.SetTrackVisible(txteffecttrackindex.Text, False)

        End If

    End Sub

    Private Sub chkTextVisible_Click(sender As System.Object, e As System.EventArgs) Handles chkTextVisible.Click


        If chkTextVisible.Checked Then
            AxTimelineControl1.SetTrackVisible(txttexttrackindex.Text, True)
        Else
            AxTimelineControl1.SetTrackVisible(txttexttrackindex.Text, False)

        End If

    End Sub

    Private Sub Button35_Click(sender As System.Object, e As System.EventArgs) Handles Button35.Click
        Dim itrantrack As Integer

        ' 2 is video track
        '3 is image track
        If cbotrantrack.SelectedIndex = 0 Then
            itrantrack = 2
        Else
            itrantrack = 3

        End If

        txttranclipindex.Text = AxTimelineControl1.AddTransition(txttrantrackindex.Text, cbotranname.Text, txttranstart.Text, txttranstop.Text, txtTranParam.Text, itrantrack, chkrevdir.Checked)
        IsChanged = True
        UpdateTimelineDuration()
    End Sub

    Private Sub Button34_Click(sender As System.Object, e As System.EventArgs) Handles Button34.Click
        Dim itrantrack As Integer
        If cbotrantrack.SelectedIndex = 0 Then
            itrantrack = 2
        Else
            itrantrack = 3

        End If
        AxTimelineControl1.ChangeTransition(txttrantrackindex.Text, txttranclipindex.Text, cbotranname.Text, txttranstart.Text, txttranstop.Text, txtTranParam.Text, itrantrack, chkrevdir.Checked)
        IsChanged = True
        UpdateTimelineDuration()
    End Sub

    Private Sub Button33_Click(sender As System.Object, e As System.EventArgs) Handles Button33.Click
        AxTimelineControl1.DeleteTransition(txttrantrackindex.Text, txttranclipindex.Text)
        IsChanged = True
        UpdateTimelineDuration()
    End Sub

    Private Sub Button14_Click(sender As System.Object, e As System.EventArgs) Handles Button14.Click
        AxTimelineControl1.DeleteClip(txtimagetrackindex.Text, txtimageclipindex.Text)
        IsChanged = True
        UpdateTimelineDuration()
    End Sub

    Private Sub AxTimelineControl1_OnClick(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub TabPage9_Click(sender As System.Object, e As System.EventArgs) Handles TabPage9.Click

    End Sub

    Private Sub AxTimelineControl1_OnPlaying(sender As System.Object, e As AxTimelineAxLib._ITimelineControlEvents_OnPlayingEvent) Handles AxTimelineControl1.OnPlaying
        txtcurrentpos.Text = e.currentPosition / 1000
    End Sub

    Private Sub Button36_Click(sender As System.Object, e As System.EventArgs) Handles Button36.Click
        Dim strFilter As String
        Dim iresult As Integer


        Blacklist_ThirdPartyFilters()

        AxTimelineControl1.SetVideoTrackFrameRate(txtvideotrackframerate.Text)
        AxTimelineControl1.SetVideoTrackResolution(txtvideotrackwidth.Text, txtvideotrackheight.Text)

        If TabOutputType.SelectedIndex = 3 Then
            AxTimelineControl1.OutputType = cboMpegType.SelectedIndex + 3 'outputtype 3 is vcd pal, 4 is vcd ntsc
        ElseIf TabOutputType.SelectedIndex = 4 Then
            AxTimelineControl1.OutputType = 11 'avchd
        ElseIf TabOutputType.SelectedIndex = 5 Then
            AxTimelineControl1.OutputType = 12 'flv
        Else
            AxTimelineControl1.OutputType = TabOutputType.SelectedIndex

        End If

        If AxTimelineControl1.OutputType = 0 Then
            If chkUseVideocomp.Checked Then
                AxTimelineControl1.AVIVideoCompressor = cboavivencoder.SelectedIndex
                AxTimelineControl1.AVIAudioCompressor = cboaviaencoder.SelectedIndex
            Else
                AxTimelineControl1.AVIVideoCompressor = -1
                AxTimelineControl1.AVIAudioCompressor = -1

            End If
            strFilter = "AVI File (*.avi)|*.avi||"

        ElseIf AxTimelineControl1.OutputType = 1 Then
            strFilter = "WMV File (*.wmv)|*.wmv||"
            AxTimelineControl1.WMVProfile = cboWMVProfile.SelectedIndex

        ElseIf AxTimelineControl1.OutputType = 2 Then
            AxTimelineControl1.MP4AspectRatio = cboMP4AspectRadio.SelectedIndex
            AxTimelineControl1.MP4AudioBitrate = MP4AudioBitrate.Text
            AxTimelineControl1.MP4AudioChannels = MP4AudioChannel.Text
            AxTimelineControl1.MP4AudioSampleRate = MP4AudioSampleRate.Text
            AxTimelineControl1.MP4Framerate = MP4FrameRate.Text
            AxTimelineControl1.MP4H264Preset = cbopreset.SelectedIndex
            AxTimelineControl1.MP4Height = MP4Height.Text
            AxTimelineControl1.MP4Width = MP4Width.Text
            AxTimelineControl1.MP4VideoBitrate = MP4VideoBitrate.Text
            AxTimelineControl1.MP4GPUCodec = cboGPU.SelectedIndex
            AxTimelineControl1.MP4NVIDAPreset = cbonvidapreset.SelectedIndex

            strFilter = "MP4 File (*.mp4)|*.mp4||"
        ElseIf AxTimelineControl1.OutputType = 11 Then

            AxTimelineControl1.AVCHDAudioBitrate = cboavchdaudiobitrate.Items(cboavchdaudiobitrate.SelectedIndex)
            AxTimelineControl1.AVCHDVideoBitrate = cboavchdvideobitrate.Items(cboavchdvideobitrate.SelectedIndex)
            AxTimelineControl1.AVCHDVideoFrameRate = cboavchdframerate.Items(cboavchdframerate.SelectedIndex)


            Me.AxTimelineControl1.AVCHDWidth = txtavchdwidth.Text
            Me.AxTimelineControl1.AVCHDHeight = txtavchdheight.Text

            If Me.cboavchdaudiosamplerate.SelectedIndex = 0 Then
                Me.AxTimelineControl1.AVCHDAudioSampleRate = 44100
            Else
                Me.AxTimelineControl1.AVCHDAudioSampleRate = 48000
            End If

            If Me.chkavchd169.Checked Then

                Me.AxTimelineControl1.AVCHDAspectRatio = 1
            Else

                Me.AxTimelineControl1.AVCHDAspectRatio = 0

            End If
            strFilter = "AVCHD File (*.m2ts)|*.m2ts||"


        ElseIf AxTimelineControl1.OutputType = 12 Then
            AxTimelineControl1.FLVVideoBitrate = flvVideoBitrate.Text
            AxTimelineControl1.FLVAudioBitrate = flvAudioBitrate.Text
            AxTimelineControl1.FLVAudioChannels = flvAudioChannel.Text
            AxTimelineControl1.FLVAudioSampleRate = flvAudioSampleRate.Text
            AxTimelineControl1.FLVFrameRate = flvFrameRate.Text
            AxTimelineControl1.FLVWidth = flvWidth.Text
            AxTimelineControl1.FLVHeight = flvHeight.Text

            strFilter = "FLV File (*.flv)|*.flv||"
        Else

            AxTimelineControl1.MPEGFrameRate = cboMpegFrameRate.Items(cboMpegFrameRate.SelectedIndex)
            AxTimelineControl1.MPEGAudioSampleRate = cboMpegaudiosamplerate.Items(cboMpegaudiosamplerate.SelectedIndex)
            AxTimelineControl1.MPEGAudioBitrate = txtAudioBitRate.Text
            AxTimelineControl1.MPEGAudioChannels = txtMPEGAudioChannel.Text
            AxTimelineControl1.MPEGVideoBitrate = txtVideoBitRate.Text
            AxTimelineControl1.MPEGWidth = txtmpegwidth.Text
            AxTimelineControl1.MPEGHeight = txtmpegheight.Text

            
            If chkmpeg169.Checked Then
                AxTimelineControl1.MPEGAspectRatio = 1
            Else
                AxTimelineControl1.MPEGAspectRatio = 0

            End If
            strFilter = "MPEG File (*.mpg)|*.mpg||"


        End If

        SaveFileDialog1.Filter = strFilter
        If SaveFileDialog1.ShowDialog() = DialogResult.OK Then

            iresult = Me.AxTimelineControl1.Save(SaveFileDialog1.FileName)


            ListBox1.Items.Clear()
            For i = 0 To AxTimelineControl1.DecoderGetCurrentFiltersCount() - 1

                ListBox1.Items.Add(AxTimelineControl1.DecoderGetCurrentFilterName(i))
            Next


            If iresult <> 1 Then
                MessageBox.Show("Save Failed")
            End If
        End If

    End Sub

    Private Sub AxTimelineControl1_OnConvertCompleted(sender As System.Object, e As System.EventArgs) Handles AxTimelineControl1.OnConvertCompleted
        MessageBox.Show("Save Completed")
    End Sub

    Private Sub cboavivencoder_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub AxTimelineControl1_OnConvertProgress(sender As System.Object, e As AxTimelineAxLib._ITimelineControlEvents_OnConvertProgressEvent) Handles AxTimelineControl1.OnConvertProgress
        ProgressBar1.Value = e.progress
    End Sub

    Private Sub AxTimelineControl1_OnClickClip(sender As System.Object, e As AxTimelineAxLib._ITimelineControlEvents_OnClickClipEvent) Handles AxTimelineControl1.OnClickClip
        Dim iColor As UInteger
        Dim iFont As Integer
        Dim strEffectName As String
        Dim strTransitionName As String
        Dim imediaTrackIndex As Integer
        Dim ireverseDirection As Integer


        If (e.trackIndex = AxTimelineControl1.GetVideo1TrackIndex()) Then

            txtvideo1clipindex.Text = e.clipIndex.ToString

            'Dim str1 As String


            AxTimelineControl1.GetVideoClip(e.trackIndex, e.clipIndex, txtvideo1.Text, txtvideo1clipstart.Text, txtvideo1clipstop.Text, txtvideo1mediastart.Text, cbovideostretchmode.SelectedIndex)

            TabControl1.SelectedIndex = 1



        ElseIf (e.trackIndex = AxTimelineControl1.GetVideo2TrackIndex()) Then

            txtvideo2clipindex.Text = e.clipIndex.ToString

            'Dim str1 As String
            AxTimelineControl1.GetVideoClip(e.trackIndex, e.clipIndex, txtvideo2.Text, txtvideo2clipstart.Text, txtvideo2clipstop.Text, txtvideo2mediastart.Text, cbovideostretchmode2.SelectedIndex)

            TabControl1.SelectedIndex = 2

        ElseIf (e.trackIndex = AxTimelineControl1.GetAudio1TrackIndex()) Then

            txtaudio1clipindex.Text = e.clipIndex.ToString

            AxTimelineControl1.GetAudioClip(e.trackIndex, e.clipIndex, txtaudio1.Text, txtaudio1clipstart.Text, txtaudio1clipstop.Text, txtaudio1mediastart.Text, txtaudio1volume.Text)

            TabControl1.SelectedIndex = 4

        ElseIf (e.trackIndex = AxTimelineControl1.GetAudio2TrackIndex()) Then

            txtaudio2clipindex.Text = e.clipIndex.ToString

            AxTimelineControl1.GetAudioClip(e.trackIndex, e.clipIndex, txtaudio2.Text, txtaudio2clipstart.Text, txtaudio2clipstop.Text, txtaudio2mediastart.Text, txtaudio2volume.Text)

            TabControl1.SelectedIndex = 5

        ElseIf (e.trackIndex = AxTimelineControl1.GetImageTrackIndex()) Then
            txtimageclipindex.Text = e.clipIndex.ToString

            AxTimelineControl1.GetImageClip(e.trackIndex, e.clipIndex, txtimage.Text, txtimageclipstart.Text, txtimageclipstop.Text, cboimagestretchmode.SelectedIndex)

            TabControl1.SelectedIndex = 3
        ElseIf (e.trackIndex = AxTimelineControl1.GetTextTrackIndex()) Then

            txttextclipindex.Text = e.clipIndex.ToString

            AxTimelineControl1.GetTextClip(e.trackIndex, e.clipIndex, txtText.Text, txttextclipstart.Text, txttextclipstop.Text, iFont, txtTextX.Text, txtTextY.Text, iColor)

            Dim myTextColor As Color = ColorTranslator.FromOle(iColor)
            ColorDialog1.Color = myTextColor

            TabControl1.SelectedIndex = 6

        ElseIf (e.trackIndex = AxTimelineControl1.GetEffectTrackIndex()) Then

            txteffectclipindex.Text = e.clipIndex.ToString
            AxTimelineControl1.GetEffect(e.trackIndex, e.clipIndex, strEffectName, txteffectstart.Text, txteffectstop.Text, txtEffectParam.Text)

            Dim iFindIndex As Integer

            iFindIndex = cboeffectname.FindString(strEffectName)

            If iFindIndex <> -1 Then cboeffectname.SelectedIndex = iFindIndex

            TabControl1.SelectedIndex = 7

        ElseIf (e.trackIndex = AxTimelineControl1.GetTransitionTrackIndex()) Then

            txttrantrackindex.Text = e.clipIndex.ToString
            AxTimelineControl1.GetTransition(e.trackIndex, e.clipIndex, strTransitionName, txttranstart.Text, txttranstop.Text, txtTranParam.Text, imediaTrackIndex, chkrevdir.Checked)

            Dim iFindIndex As Integer

            iFindIndex = cbotranname.FindString(strTransitionName)

            If iFindIndex <> -1 Then cbotranname.SelectedIndex = iFindIndex

           
            If imediaTrackIndex = 2 Then
                cbotrantrack.SelectedIndex = 0
            ElseIf imediaTrackIndex = 3 Then
                cbotrantrack.SelectedIndex = 1
            End If

            TabControl1.SelectedIndex = 8
        End If




    End Sub

    Private Sub AxTimelineControl1_OnClick_1(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        Dim result As Boolean


        AxTimelineControl1.PreviewWndAspectRatio = False


        Exit Sub


        SaveFileDialog1.Filter = "Project Files (*.xml)|*.xml||"
        If SaveFileDialog1.ShowDialog() = DialogResult.OK Then

            result = AxTimelineControl1.SaveProject(SaveFileDialog1.FileName)

            If result <> True Then
                MessageBox.Show("failed")
            End If
        End If


    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        Dim result As Boolean
        'AxTimelineControl1.SetPreviewWndSize(20)
        AxTimelineControl1.PreviewWndAspectRatio = True

        Exit Sub

        OpenFileDialog1.Filter = "Project Files (*.xml)|*.xml||"

        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then

            result = AxTimelineControl1.LoadProject(OpenFileDialog1.FileName)
       
            If result <> True Then
                MessageBox.Show("failed")
            End If
        End If

    End Sub

    Private Sub TabPage13_Click(sender As System.Object, e As System.EventArgs) Handles TabPage13.Click

    End Sub

    Private Sub cboMpegType_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboMpegType.SelectedIndexChanged
        If cboMpegType.Text = "MPEG1" Or cboMpegType.Text = "MPEG2" Then
            cboMpegFrameRate.Enabled = True
            cboMpegaudiosamplerate.Enabled = True
            txtAudioBitRate.Enabled = True
            txtmpegwidth.Enabled = True
            txtmpegheight.Enabled = True
            txtVideoBitRate.Enabled = True
            txtMPEGAudioChannel.Enabled = True
        Else
            cboMpegFrameRate.Enabled = False
            cboMpegaudiosamplerate.Enabled = False
            txtAudioBitRate.Enabled = False
            txtmpegwidth.Enabled = False
            txtmpegheight.Enabled = False
            txtVideoBitRate.Enabled = False
            txtMPEGAudioChannel.Enabled = False

        End If
    End Sub

    Private Sub Button37_Click(sender As System.Object, e As System.EventArgs) Handles Button37.Click
        AxTimelineControl1.Pause()
    End Sub

    Private Sub Button38_Click(sender As System.Object, e As System.EventArgs) Handles Button38.Click
        AxTimelineControl1.Stop()
    End Sub

    Private Sub chkTransitionVisible_Click(sender As System.Object, e As System.EventArgs) Handles chkTransitionVisible.Click

        If chkTransitionVisible.Checked Then
            AxTimelineControl1.SetTrackVisible(txttrantrackindex.Text, True)
        Else
            AxTimelineControl1.SetTrackVisible(txttrantrackindex.Text, False)

        End If

    End Sub

    Private Sub Button2_Click_1(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        AxTimelineControl1.StopConversion()
    End Sub

    Private Sub Button30_Click(sender As System.Object, e As System.EventArgs) Handles Button30.Click
        AxTimelineControl1.DeleteEffect(txteffecttrackindex.Text, txteffectclipindex.Text)
        IsChanged = True
        UpdateTimelineDuration()
    End Sub

    Private Sub TabPage1_Click(sender As System.Object, e As System.EventArgs) Handles TabPage1.Click

    End Sub

    Private Sub Button8_Click_1(sender As System.Object, e As System.EventArgs) Handles Button8.Click
        AxTimelineControl1.Clear()
    End Sub

    
    Private Sub Button40_Click(sender As System.Object, e As System.EventArgs)
    End Sub

    Private Sub AxTimelineControl1_OnUpdate(sender As System.Object, e As System.EventArgs) Handles AxTimelineControl1.OnUpdate
    End Sub

    Private Sub Button26_Click(sender As System.Object, e As System.EventArgs) Handles Button26.Click
        AxTimelineControl1.DeleteClip(txttexttrackindex.Text, txttextclipindex.Text)

        IsChanged = True
        UpdateTimelineDuration()
    End Sub

    Private Sub chkVideo1Visible_Click_1(sender As System.Object, e As System.EventArgs) Handles chkVideo1Visible.Click
        If chkVideo1Visible.Checked Then
            AxTimelineControl1.SetTrackVisible(txtvideo1trackindex.Text, True)
        Else
            AxTimelineControl1.SetTrackVisible(txtvideo1trackindex.Text, False)

        End If
    End Sub

    Private Sub chkVideo1Visible_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkVideo1Visible.CheckedChanged

    End Sub

   
    Private Sub Button39_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub chkenableseeking_Click(sender As System.Object, e As System.EventArgs) Handles chkenableseeking.Click
        If chkenableseeking.Checked Then
            AxTimelineControl1.EnableSeeking = True
        Else
            AxTimelineControl1.EnableSeeking = False
        End If
    End Sub

    Private Sub chkenableseeking_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkenableseeking.CheckedChanged

    End Sub

    Private Sub btnbgtheme_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnbgtheme.Click
        If ColorDialog1.ShowDialog() = DialogResult.OK Then
            AxTimelineControl1.SetThemeBg(cboBgTheme.SelectedIndex, Color2Uint32(ColorDialog1.Color))
        End If

    End Sub

    Private Sub btnfgtheme_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnfgtheme.Click
        If ColorDialog1.ShowDialog() = DialogResult.OK Then
            AxTimelineControl1.SetThemeFg(cboFgTheme.SelectedIndex, Color2Uint32(ColorDialog1.Color))
        End If

    End Sub

    Private Sub btnbordertheme_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnbordertheme.Click
        If ColorDialog1.ShowDialog() = DialogResult.OK Then
            AxTimelineControl1.SetThemeBorder(cboBorderTheme.SelectedIndex, Color2Uint32(ColorDialog1.Color))
        End If

    End Sub

    Private Sub btntrackicon1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btntrackicon1.Click
        OpenFileDialog1.Filter = "PNG Files (*.png)|*.png||"

        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            AxTimelineControl1.ChangeTrackImage(0, OpenFileDialog1.FileName)

            AxTimelineControl1.SetScale(cboscale.Text)
        End If
    End Sub

    
    Private Sub btntrackicon2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btntrackicon2.Click
        OpenFileDialog1.Filter = "PNG Files (*.png)|*.png||"

        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            AxTimelineControl1.ChangeTrackImage(1, OpenFileDialog1.FileName)
            AxTimelineControl1.SetScale(cboscale.Text)

        End If
    End Sub

    Private Sub btntrackicon3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btntrackicon3.Click
        OpenFileDialog1.Filter = "PNG Files (*.png)|*.png||"

        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            AxTimelineControl1.ChangeTrackImage(2, OpenFileDialog1.FileName)
            AxTimelineControl1.SetScale(cboscale.Text)

        End If
    End Sub

    Private Sub btntrackicon4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btntrackicon4.Click
        OpenFileDialog1.Filter = "PNG Files (*.png)|*.png||"

        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            AxTimelineControl1.ChangeTrackImage(3, OpenFileDialog1.FileName)
            AxTimelineControl1.SetScale(cboscale.Text)

        End If
    End Sub

    Private Sub btntrackicon5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btntrackicon5.Click
        OpenFileDialog1.Filter = "PNG Files (*.png)|*.png||"

        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            AxTimelineControl1.ChangeTrackImage(4, OpenFileDialog1.FileName)
            AxTimelineControl1.SetScale(cboscale.Text)

        End If
    End Sub

    Private Sub Button41_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button41.Click
        OpenFileDialog1.Filter = "PNG Files (*.png)|*.png||"

        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            AxTimelineControl1.ChangeTrackImage(7, OpenFileDialog1.FileName)
            AxTimelineControl1.SetScale(cboscale.Text)

        End If
    End Sub

    Private Sub Button39_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button39.Click
        OpenFileDialog1.Filter = "PNG Files (*.png)|*.png||"

        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            AxTimelineControl1.ChangeTrackImage(5, OpenFileDialog1.FileName)
            AxTimelineControl1.SetScale(cboscale.Text)

        End If
    End Sub

    Private Sub Button40_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button40.Click
        OpenFileDialog1.Filter = "PNG Files (*.png)|*.png||"

        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            AxTimelineControl1.ChangeTrackImage(6, OpenFileDialog1.FileName)
            AxTimelineControl1.SetScale(cboscale.Text)

        End If
    End Sub

    Private Sub Button42_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button42.Click
        OpenFileDialog1.Filter = "PNG Files (*.png)|*.png||"

        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            AxTimelineControl1.ChangeAudioClipImage(OpenFileDialog1.FileName)
            AxTimelineControl1.SetScale(cboscale.Text)

        End If
    End Sub

    Private Sub SelectedGPUCombBox()
        If cboGPU.SelectedIndex = 1 Then
            cbonvidapreset.Enabled = True
            cbopreset.Enabled = False
        Else
            cbonvidapreset.Enabled = False
            cbopreset.Enabled = True
        End If
    End Sub
    Private Sub cboGPU_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboGPU.SelectedIndexChanged
        SelectedGPUCombBox()
    End Sub

    Private Sub Button43_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button43.Click
        cboGPU.SelectedIndex = AxTimelineControl1.MP4DetectGPU()
    End Sub

    Private Sub TabPage4_Click(sender As System.Object, e As System.EventArgs) Handles TabPage4.Click

    End Sub

    Private Sub AxTimelineControl1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AxTimelineControl1.Enter

    End Sub

    Private Sub cbopreviewsize_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbopreviewsize.SelectedIndexChanged
        If cbopreviewsize.SelectedIndex = 0 Then
            AxTimelineControl1.SetPreviewWndSize(0)
        Else
            AxTimelineControl1.SetPreviewWndSize(cbopreviewsize.Text)
        End If

    End Sub

    Private Sub chkpreviewaspectratio_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkpreviewaspectratio.CheckedChanged
        If AxTimelineControl1.IsHandleCreated() Then
            If chkpreviewaspectratio.Checked Then
                AxTimelineControl1.PreviewWndAspectRatio = True
            Else
                AxTimelineControl1.PreviewWndAspectRatio = False

            End If
        End If

    End Sub

    Private Sub hScrollBarScaleTimeline_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles hScrollBarScaleTimeline.Scroll
        Dim iScale As Double
        iScale = hScrollBarScaleTimeline.Value * 0.01
        AxTimelineControl1.SetScale(iScale)
    End Sub

    Private Sub radioDragOverToRight_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radioDragOverToRight.CheckedChanged
        AxTimelineControl1.DragOverMoveClipMode = 0
    End Sub

    Private Sub radioDragOverToLeft_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radioDragOverToLeft.CheckedChanged
        AxTimelineControl1.DragOverMoveClipMode = 1
    End Sub
End Class
