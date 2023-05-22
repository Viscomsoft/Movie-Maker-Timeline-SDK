using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        bool _IsChanged=false;
 
        public Form1()
        {
            InitializeComponent();
        }

        private bool CheckSupportMedia(string strMedia, string strAudioStreamFormat)
        {
            bool IsSupport = true;

            if (strMedia == "Matroska")
                IsSupport = false;


            return IsSupport;
        }


        private void Button6_Click(object sender, EventArgs e)
        {

            openFileDialog1.Filter = "All Files (*.*)|*.*|mpg (*.mpg*.vob) | *.mpg;*.vob|avi (*.avi) | *.avi|Divx (*.divx) | *.divx|wmv (*.wmv)| *.wmv|QuickTime (*.mov)| *.mov|MP4 (*.mp4) | *.mp4|WebM (*.webm) | *.webm|FLV (*.flv) | *.flv|MKV (*.mkv) | *.mkv|AVCHD (*.m2ts*.ts*.mts*m2t)|*.m2ts;*.ts;*.mts;*.m2t;...";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                float iduration;
                int iwidth;
                int iheight;
                float iframerate;
                int ivideobitrate;
                int iaudiobitrate;
                int iaudiochannel;
                int iaudiosamplerate;
                int ivideostreamcount;
                int iaudiostreamcouunt;
                string strmediacontainer;
                string strvideostreamformat;
                string straudiostreamformat;

                txtvideo1.Text = openFileDialog1.FileName;

                axTimelineControl1.GetMediaInfo(txtvideo1.Text, out iduration, out iwidth, out iheight, out iframerate, out ivideobitrate, out iaudiobitrate, out iaudiosamplerate, out iaudiochannel, out ivideostreamcount, out iaudiostreamcouunt, out strmediacontainer, out strvideostreamformat, out straudiostreamformat);

                if (iwidth > 1980)
                {
                    MessageBox.Show("Your input video resolution too high,if you add a number of these video into timeline, it will not work, because memory limitation. You should convert this video into 1920x1080 or 1280x720 MP4 file, then reimport to timline");
               
                }
                 double iDur = Math.Round(iduration, 2);
                 txtvideo1mediastart.Text = "0";

                 this.txtvideo1clipstart.Text = "0";
                this.txtvideo1clipstop.Text = iDur.ToString();
                this.TextBoxWidth.Text = iwidth.ToString();
                this.TextBoxHeight.Text = iheight.ToString();
                this.TextBoxFrameRate.Text = iframerate.ToString();
                this.TextBoxVideoBitrate.Text = ivideobitrate.ToString();
                this.TextBoxAudioBitrate.Text = iaudiobitrate.ToString();
                this.TextBoxAudioSample.Text = iaudiosamplerate.ToString();
                this.TextBoxAudioChannel.Text = iaudiochannel.ToString();
                this.TextBoxVideoStreamCount.Text = ivideostreamcount.ToString();
                this.TextBoxAudioStreamCount.Text = iaudiostreamcouunt.ToString();
                this.TextBoxMediaContainer.Text = strmediacontainer;
                this.TextBoxVideoStreamFormat.Text = strvideostreamformat.ToString();
                this.TextBoxAudioStreamFormat.Text = straudiostreamformat.ToString();


             
            }
        }

        private void UpdateTimelineDuration()
        {
            txtTimelineDur.Text = axTimelineControl1.GetTimelineDuration().ToString();
        }
        private void btnaddvideo1_Click(object sender, EventArgs e)
        {
           
         short iResultClipIndex;
         iResultClipIndex = (short)axTimelineControl1.AddVideoClip(int.Parse(txtvideo1trackindex.Text), txtvideo1.Text, float.Parse(txtvideo1clipstart.Text), float.Parse(txtvideo1clipstop.Text), float.Parse(txtvideo1mediastart.Text),(int)cbovideostretchmode.SelectedIndex);
             

          if(iResultClipIndex == -6)
          {
            MessageBox.Show("Does not support this media format");
            return;
          }
          else if(iResultClipIndex == -5)
          {
            MessageBox.Show("Unknow error");
            return;
          }
          else if(iResultClipIndex == -4)   
          {
            MessageBox.Show("track no found");
            return;
          }
        else if(iResultClipIndex == -3)
         {
            MessageBox.Show("clipStartTime >= clipStopTime");
            return;
        }
        else if(iResultClipIndex == -2)
          {
            MessageBox.Show("the path of video file not found");
            return;
        }
        else if(iResultClipIndex == -1)
          {
              MessageBox.Show("the path of video file is empty");
            return;
        }
      
            txtvideo1clipindex.Text = iResultClipIndex.ToString();

            if (TextBoxAudioStreamCount.Text !="0")
                axTimelineControl1.AddAudioClip(int.Parse(txtaudio1trackindex.Text), txtvideo1.Text, float.Parse(txtvideo1clipstart.Text), float.Parse(txtvideo1clipstop.Text), float.Parse(txtvideo1mediastart.Text), float.Parse(txtaudio1volume.Text)).ToString();
   

            if(txtvideo1clipindex.Text == "0")
            {
                txtvideotrackwidth.Text = TextBoxWidth.Text;
                txtvideotrackheight.Text = TextBoxHeight.Text;
                axTimelineControl1.SetVideoTrackResolution(int.Parse(TextBoxWidth.Text), int.Parse(TextBoxHeight.Text));
            }
            _IsChanged = true;


            txtOutputImageWidth.Text = txtvideotrackwidth.Text;
            txtOutputImageHeight.Text = txtvideotrackheight.Text;
            
            textboxPicinPicWidth.Text = txtvideotrackwidth.Text;
            textboxPicinPicHeight.Text = txtvideotrackheight.Text;
            UpdateTimelineDuration(); 
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            hScrollBarScaleTimeline.Maximum = 18;
            hScrollBarScaleTimeline.Minimum = 1;
            hScrollBarScaleTimeline.LargeChange = 1;
            hScrollBarScaleTimeline.SmallChange = 1;

            hScrollBarScaleTimeline.Value = 9;

            radioDragOverToRight.Checked = true;

           cbopreviewsize.Items.Add("Fit To Window");
            cbopreviewsize.Items.Add("150");
            cbopreviewsize.Items.Add("140");
            cbopreviewsize.Items.Add("130");
            cbopreviewsize.Items.Add("120");
            cbopreviewsize.Items.Add("110");
            cbopreviewsize.Items.Add("100");
            cbopreviewsize.Items.Add("90");
            cbopreviewsize.Items.Add("80");
            cbopreviewsize.Items.Add("70");
            cbopreviewsize.Items.Add("60");
            cbopreviewsize.Items.Add("50");
            cbopreviewsize.Items.Add("40");
            cbopreviewsize.Items.Add("30");
            cbopreviewsize.Items.Add("20");

            cbopreviewsize.SelectedIndex = 0;


            TabControl1.SelectedIndex = 1;
            TabOutputType.SelectedIndex = 2;
            
            cboimagestretchmode.Items.Add("Stretched To Fit");
            cboimagestretchmode.Items.Add("No Resize");
            cboimagestretchmode.Items.Add("Keep Aspect Ratio");
            cboimagestretchmode.Items.Add("Resize no letter box");
            cboimagestretchmode.SelectedIndex = 0;


            cbovideostretchmode.Items.Add("Stretched To Fit");
            cbovideostretchmode.Items.Add("No Resize");
            cbovideostretchmode.Items.Add("Keep Aspect Ratio");
            cbovideostretchmode.Items.Add("Resize no letter box");
            cbovideostretchmode.SelectedIndex=0;


            cbovideostretchmode2.Items.Add("Stretched To Fit");
            cbovideostretchmode2.Items.Add("No Resize");
            cbovideostretchmode2.Items.Add("Keep Aspect Ratio");
            cbovideostretchmode2.Items.Add("Resize no letter box");
            cbovideostretchmode2.SelectedIndex = 0;

        cboGPU.Items.Add("None");
        cboGPU.Items.Add("Nvidia");
        cboGPU.Items.Add("AMD");
        cboGPU.Items.Add("Intel");
        cboGPU.SelectedIndex = 0;


        cbonvidapreset.Items.Add("slow");
        cbonvidapreset.Items.Add("medium");
        cbonvidapreset.Items.Add("fast");
        cbonvidapreset.Items.Add("high performance");
        cbonvidapreset.Items.Add("high quality");
        cbonvidapreset.Items.Add("bluray disk");
        cbonvidapreset.Items.Add("low latency");
        cbonvidapreset.Items.Add("low latency high quality");
        cbonvidapreset.Items.Add("low latency high performance");
        cbonvidapreset.Items.Add("lossless");
        cbonvidapreset.Items.Add("lossless high performance");
        cbonvidapreset.SelectedIndex = 3;

            
        cboBgTheme.Items.Add("Panel");
        cboBgTheme.Items.Add("Track");
        cboBgTheme.Items.Add("Track Title");
        cboBgTheme.Items.Add("Content");
        cboBgTheme.Items.Add("Time Scale");
        cboBgTheme.Items.Add("ScrollBar");
        cboBgTheme.Items.Add("ScrollBar Item");
        cboBgTheme.Items.Add("ToolTip");
        cboBgTheme.Items.Add("SeekBar");
        cboBgTheme.SelectedIndex = 0;

        cboFgTheme.Items.Add("Content");
        cboFgTheme.Items.Add("Time Scale");
        cboFgTheme.Items.Add("ScrollBar Item");
        cboFgTheme.Items.Add("ToolTip");
        cboFgTheme.Items.Add("SeekBar");
        cboFgTheme.SelectedIndex = 0;

        cboBorderTheme.Items.Add("Content");
        cboBorderTheme.Items.Add("Time Scale");
        cboBorderTheme.Items.Add("ScrollBar");
        cboBorderTheme.Items.Add("ScrollBar Item");
        cboBorderTheme.Items.Add("SelectionBox");
        cboBorderTheme.Items.Add("ToolTip");
        cboBorderTheme.Items.Add("SeekBar");
        cboBorderTheme.SelectedIndex = 0;

            cboavchdaudiosamplerate.Items.Add("44100");
            cboavchdaudiosamplerate.Items.Add("48000");
            cboavchdaudiosamplerate.SelectedIndex = 0;

            cboavchdvideobitrate.Items.Add("256");
            cboavchdvideobitrate.Items.Add("384");
            cboavchdvideobitrate.Items.Add("512");
            cboavchdvideobitrate.Items.Add("768");
            cboavchdvideobitrate.Items.Add("1024");
            cboavchdvideobitrate.Items.Add("4096");
            cboavchdvideobitrate.SelectedIndex = 0;

            cboavchdaudiobitrate.Items.Add("48");
            cboavchdaudiobitrate.Items.Add("96");
            cboavchdaudiobitrate.Items.Add("128");
            cboavchdaudiobitrate.Items.Add("256");
            cboavchdaudiobitrate.SelectedIndex = 1;


            cboavchdframerate.Items.Add("23.97");
            cboavchdframerate.Items.Add("24");
            cboavchdframerate.Items.Add("25");
            cboavchdframerate.Items.Add("29.97");

            cboavchdframerate.SelectedIndex = 2;


            cboMpegFrameRate.Items.Add("23.976");
            cboMpegFrameRate.Items.Add("24");
            cboMpegFrameRate.Items.Add("25");
            cboMpegFrameRate.Items.Add("29.97");
            cboMpegFrameRate.Items.Add("30");
            cboMpegFrameRate.Items.Add("50");
            cboMpegFrameRate.Items.Add("59.94");
            cboMpegFrameRate.SelectedIndex = 0;

            cboMpegType.Items.Add("VCD PAL");
            cboMpegType.Items.Add("VCD NTSC");
            cboMpegType.Items.Add("SVCD PAL");
            cboMpegType.Items.Add("SVCD NTSC");
            cboMpegType.Items.Add("DVD PAL");
            cboMpegType.Items.Add("DVD NTSC");
            cboMpegType.Items.Add("MPEG1");
            cboMpegType.Items.Add("MPEG2");
            cboMpegType.SelectedIndex = 0;

            cboMpegaudiosamplerate.Items.Add("32000");
            cboMpegaudiosamplerate.Items.Add("44100");
            cboMpegaudiosamplerate.Items.Add("48000");
            cboMpegaudiosamplerate.SelectedIndex = 1;


            cboscale.Items.Add("0.01");
            cboscale.Items.Add("0.03");

            cboscale.Items.Add("0.05");
            cboscale.Items.Add("0.1");
            cboscale.Items.Add("0.2");
            cboscale.Items.Add("0.4");
            cboscale.Items.Add("1.0");
            cboscale.Items.Add("2.0");
            cboscale.Items.Add("3.0");
            cboscale.SelectedIndex = 0;

            cbotrantrack.Items.Add("Video");
            cbotrantrack.Items.Add("Image");
            cbotrantrack.SelectedIndex = 0;

            txtvideo1trackindex.Text = axTimelineControl1.GetVideo1TrackIndex().ToString();
            txtvideo2trackindex.Text = axTimelineControl1.GetVideo2TrackIndex().ToString();
            txtimagetrackindex.Text = axTimelineControl1.GetImageTrackIndex().ToString();
            txtaudio1trackindex.Text = axTimelineControl1.GetAudio1TrackIndex().ToString();
            txtaudio2trackindex.Text = axTimelineControl1.GetAudio2TrackIndex().ToString();

            txteffecttrackindex.Text = axTimelineControl1.GetEffectTrackIndex().ToString();
            txttrantrackindex.Text = axTimelineControl1.GetTransitionTrackIndex().ToString();
            txttexttrackindex.Text = axTimelineControl1.GetTextTrackIndex().ToString();


            int iCount;
            string strEffect;
            string strTransition;
            string strVideoCompressor;
            string strAudioCompressor;
            string strWMVProfile;

            iCount = 0;
            strEffect = "Empty";

            while (strEffect != "")
            {
                strEffect = axTimelineControl1.GetDESEffect(iCount);

                if (strEffect != "")
                {
                    cboeffectname.Items.Add(strEffect);
                    iCount = iCount + 1;

                }
            }

            if (cboeffectname.Items.Count > 0)
                cboeffectname.SelectedIndex = 0;


            iCount = 0;
            strTransition = "Empty";

            while (strTransition != "")
            {
                strTransition = axTimelineControl1.GetDESTransition(iCount);

                if (strTransition != "")
                {
                    cbotranname.Items.Add(strTransition);
                    iCount = iCount + 1;

                }

            }
            if (cbotranname.Items.Count > 0)
                cbotranname.SelectedIndex = 0;



            iCount = 0;
            strVideoCompressor = "Empty";

            while (strVideoCompressor!="")
            {
                  strVideoCompressor = axTimelineControl1.GetVideoEncoder(iCount);

                if(strVideoCompressor!="")
                     cboavivencoder.Items.Add(strVideoCompressor);

                if(strVideoCompressor=="DV Video Encoder")
                {
                    cboavivencoder.SelectedIndex =iCount;
                }
                iCount = iCount +1;

            }

            iCount = 0;
            strAudioCompressor = "Empty";

            while (strAudioCompressor != "")
            {
                strAudioCompressor = axTimelineControl1.GetAudioEncoder(iCount);

                if (strAudioCompressor != "")
                    cboaviaencoder.Items.Add(strAudioCompressor);

                if (strAudioCompressor == "PCM")
                {
                    cboaviaencoder.SelectedIndex = iCount;
                }
                iCount = iCount + 1;

            }



            iCount = 0;
            strWMVProfile = "Empty";
            while(strWMVProfile!="")
            {
                strWMVProfile = axTimelineControl1.GetWMVProfile(iCount);

                if(strWMVProfile !="")
                {
                    cboWMVProfile.Items.Add(strWMVProfile);
                    iCount = iCount+1;
                }
            }

            if(cboWMVProfile.Items.Count >0)
                cboWMVProfile.SelectedIndex=0;

            axTimelineControl1.SetPreviewWnd((int)PictureBox1.Handle);

            cboMP4AspectRadio.Items.Add("4:3");
            cboMP4AspectRadio.Items.Add("16:9");
            cboMP4AspectRadio.SelectedIndex = 0;

            cbopreset.Items.Add("superfast");
            cbopreset.Items.Add("veryfast");
            cbopreset.Items.Add("faster");
            cbopreset.Items.Add("fast");
            cbopreset.Items.Add("medium");
            cbopreset.Items.Add("slow");
            cbopreset.Items.Add("slower");
            cbopreset.Items.Add("veryslow");
            cbopreset.SelectedIndex = 0;
       }

        private void Blacklist_ThirdPartyFilters()
        {

            axTimelineControl1.DecoderFilterClearList();

            if (chkblacklist.Checked)
            {

            axTimelineControl1.DecoderFilterType = 0;
            axTimelineControl1.DecoderFilterAddToList("LAV Splitter");
            axTimelineControl1.DecoderFilterAddToList("LAV Audio Decoder");
            axTimelineControl1.DecoderFilterAddToList("Microsoft DTV-DVD Video Decoder");
            axTimelineControl1.DecoderFilterAddToList("Microsoft DTV-DVD Audio Decoder");
            axTimelineControl1.DecoderFilterAddToList("ffdshow Video Decoder");
            axTimelineControl1.DecoderFilterAddToList("Elecard AVC Video Decoder HD");
            axTimelineControl1.DecoderFilterAddToList("MainConcept AVC/H.264 Video Decoder");
            axTimelineControl1.DecoderFilterAddToList("MainConcept (Adobe2) AVC/H.264 Video Decoder");
            axTimelineControl1.DecoderFilterAddToList("Sonic AVC/H.264 Video Decoder");
            axTimelineControl1.DecoderFilterAddToList("AVObjects H.264/AVC Decoder");
            axTimelineControl1.DecoderFilterAddToList("Sonic Cinemaster® VideoDecoder 4.3 (Game1X)");
            axTimelineControl1.DecoderFilterAddToList("VisioForge YUV2RGB");
            axTimelineControl1.DecoderFilterAddToList("Elecard MP4 Demultiplexer");
            }
        }
        private void btnPlay_Click(object sender, EventArgs e)
        {

            Blacklist_ThirdPartyFilters();


            axTimelineControl1.PreviewWndAspectRatio = chkpreviewaspectratio.Checked;

            if(axTimelineControl1.IsPause && _IsChanged==false)
            {
                axTimelineControl1.Play();
            }
            else
            {
                axTimelineControl1.Stop();

                if (chkusedualdisplay.Checked)
                    axTimelineControl1.UseDualDisplay = true;
                else
                    axTimelineControl1.UseDualDisplay = false;

                    
                axTimelineControl1.SetVideoTrackFrameRate(float.Parse(txtvideotrackFrameRate.Text));
            
                axTimelineControl1.SetVideoTrackResolution(int.Parse(txtvideotrackwidth.Text), int.Parse(txtvideotrackheight.Text));
                axTimelineControl1.Play();

                ListBox1.Items.Clear();

                for(int i = 0; i< axTimelineControl1.DecoderGetCurrentFiltersCount() - 1; i++)
                {
                    ListBox1.Items.Add(axTimelineControl1.DecoderGetCurrentFilterName(i));
                }

                _IsChanged = false;
                UpdateTimelineDuration();
            }
        }

        private void btnchangevideo1_Click(object sender, EventArgs e)
        {
            int iResult;

            iResult=axTimelineControl1.ChangeVideoClip(int.Parse(txtvideo1trackindex.Text),int.Parse(txtvideo1clipindex.Text),txtvideo1.Text,float.Parse(txtvideo1clipstart.Text),float.Parse(txtvideo1clipstop.Text),float.Parse(txtvideo1mediastart.Text));
            _IsChanged = true;

            UpdateTimelineDuration();

        }

        private void btnremovevideo1_Click(object sender, EventArgs e)
        {
              axTimelineControl1.DeleteClip(int.Parse(txtvideo1trackindex.Text), int.Parse(txtvideo1clipindex.Text));
             _IsChanged = true;

             UpdateTimelineDuration();
        }

        private void btnselectaudio1_Click(object sender, EventArgs e)
        {

            openFileDialog1.Filter = "All Files (*.*)|*.*|wav (*.wav)|*.wav|MP3 (*.mp3)|*.mp3|WMA (*.wma)|*.wma|M4a (*.m4a)|*.m4a|Ogg (*.ogg)|*.ogg|AC3 (*.ac3)|*.ac3|Flac (*.flac)|*.flac|MP2 (*.mp2)|*.mp2|mpg (*.mpg*.vob) | *.mpg;*.vob|avi (*.avi) | *.avi|Divx (*.divx) | *.divx|wmv (*.wmv)| *.wmv|QuickTime (*.mov)| *.mov|MP4 (*.mp4) | *.mp4|WebM (*.webm) | *.webm|FLV (*.flv) | *.flv|MKV (*.mkv) | *.mkv|AVCHD (*.m2ts*.ts*.mts*m2t)|*.m2ts;*.ts;*.mts;*.m2t;...";
      
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                float iduration;
                int iwidth;
                int iheight;
                float iframerate;
                int ivideobitrate;
                int iaudiobitrate;
                int iaudiochannel;
                int iaudiosamplerate;
                int ivideostreamcount;
                int iaudiostreamcouunt;
                string strmediacontainer;
                string strvideostreamformat;
                string straudiostreamformat;

                txtaudio1.Text = openFileDialog1.FileName;

                axTimelineControl1.GetMediaInfo(txtaudio1.Text, out iduration, out iwidth, out iheight, out iframerate, out ivideobitrate, out iaudiobitrate, out iaudiosamplerate, out iaudiochannel, out ivideostreamcount, out iaudiostreamcouunt, out strmediacontainer, out strvideostreamformat, out straudiostreamformat);

                double iDur = Math.Round(iduration, 2);

                this.txtaudio1clipstart.Text = "0";

                this.txtaudio1clipstop.Text = iDur.ToString();

                this.TextBoxA1Width.Text = iwidth.ToString();
                this.TextBoxA1Height.Text = iheight.ToString();
                this.TextBoxA1FrameRate.Text = iframerate.ToString();
                this.TextBoxA1VideoBitrate.Text = ivideobitrate.ToString();
                this.TextBoxA1AudioBitrate.Text = iaudiobitrate.ToString();
                this.TextBoxA1AudioSample.Text = iaudiosamplerate.ToString();
                this.TextBoxA1AudioChannel.Text = iaudiochannel.ToString();
                this.TextBoxA1VideoStreamCount.Text = ivideostreamcount.ToString();
                this.TextBoxA1AudioStreamCount.Text = iaudiostreamcouunt.ToString();
                this.TextBoxA1MediaContainer.Text = strmediacontainer;
                this.TextBoxA1VideoStreamFormat.Text = strvideostreamformat.ToString();
                this.TextBoxA1AudioStreamFormat.Text = straudiostreamformat.ToString();


             
            }
        }

        private void btnaddaudio1_Click(object sender, EventArgs e)
        {
            short iResultClipIndex;

            iResultClipIndex = (short)axTimelineControl1.AddAudioClip(int.Parse(txtaudio1trackindex.Text), txtaudio1.Text, float.Parse(txtaudio1clipstart.Text), float.Parse(txtaudio1clipstop.Text), float.Parse(txtaudio1mediastart.Text), float.Parse(txtaudio1volume.Text));


            if (iResultClipIndex == -6)
            {
                MessageBox.Show("Does not support this media format");
                return;
            }
            else if (iResultClipIndex == -5)
            {
                MessageBox.Show("Unknow error");
                return;
            }
            else if (iResultClipIndex == -4)
            {
                MessageBox.Show("track no found");
                return;
            }
            else if (iResultClipIndex == -3)
            {
                MessageBox.Show("clipStartTime >= clipStopTime");
                return;
            }
            else if (iResultClipIndex == -2)
            {
                MessageBox.Show("the path of video/audio file not found");
                return;
            }
            else if (iResultClipIndex == -1)
            {
                MessageBox.Show("the path of video/audio file is empty");
                return;
            }

            txtaudio1clipindex.Text = iResultClipIndex.ToString();
            _IsChanged = true;

            UpdateTimelineDuration();

        }

        private void btnchangeaudio1_Click(object sender, EventArgs e)
        {
            int iResult;

            iResult = axTimelineControl1.ChangeAudioClip(int.Parse(txtaudio1trackindex.Text), int.Parse(txtaudio1clipindex.Text), txtaudio1.Text, float.Parse(txtaudio1clipstart.Text), float.Parse(txtaudio1clipstop.Text), float.Parse(txtaudio1mediastart.Text) ,float.Parse(txtaudio1volume.Text));
            _IsChanged = true;
            UpdateTimelineDuration();
        }

        private void btnremoveaudio1_Click(object sender, EventArgs e)
        {
            axTimelineControl1.DeleteClip(int.Parse(txtaudio1trackindex.Text), int.Parse(txtaudio1clipindex.Text));
            _IsChanged = true;
            UpdateTimelineDuration();
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            axTimelineControl1.Pause();

        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            axTimelineControl1.Stop();

        }

        private void btnselectvideo2_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "All Files (*.*)|*.*|mpg (*.mpg*.vob) | *.mpg;*.vob|avi (*.avi) | *.avi|Divx (*.divx) | *.divx|wmv (*.wmv)| *.wmv|QuickTime (*.mov)| *.mov|MP4 (*.mp4) | *.mp4|WebM (*.webm) | *.webm|FLV (*.flv) | *.flv|MKV (*.mkv) | *.mkv|AVCHD (*.m2ts*.ts*.mts*m2t)|*.m2ts;*.ts;*.mts;*.m2t;...";
      
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                float iduration;
                int iwidth;
                int iheight;
                float iframerate;
                int ivideobitrate;
                int iaudiobitrate;
                int iaudiochannel;
                int iaudiosamplerate;
                int ivideostreamcount;
                int iaudiostreamcouunt;
                string strmediacontainer;
                string strvideostreamformat;
                string straudiostreamformat;

                txtvideo2.Text = openFileDialog1.FileName;

                axTimelineControl1.GetMediaInfo(txtvideo2.Text, out iduration, out iwidth, out iheight, out iframerate, out ivideobitrate, out iaudiobitrate, out iaudiosamplerate, out iaudiochannel, out ivideostreamcount, out iaudiostreamcouunt, out strmediacontainer, out strvideostreamformat, out straudiostreamformat);
                
                if (iwidth > 1980)
                {
                    MessageBox.Show("Your input video resolution too high,if you add a number of these video into timeline, it will not work, because memory limitation. You should convert this video into 1920x1080 or 1280x720 MP4 file, then reimport to timline");

                }
                double iDur = Math.Round(iduration, 2);
                
                txtvideo2mediastart.Text = "0";
                this.txtvideo2clipstart.Text = "0";
                this.txtvideo2clipstop.Text = iDur.ToString();

                this.TextBoxWidth2.Text = iwidth.ToString();
                this.TextBoxHeight2.Text = iheight.ToString();
                this.TextBoxFrameRate2.Text = iframerate.ToString();
                this.TextBoxVideoBitrate2.Text = ivideobitrate.ToString();
                this.TextBoxAudioBitrate2.Text = iaudiobitrate.ToString();
                this.TextBoxAudioSample2.Text = iaudiosamplerate.ToString();
                this.TextBoxAudioChannel2.Text = iaudiochannel.ToString();
                this.TextBoxVideoStreamCount2.Text = ivideostreamcount.ToString();
                this.TextBoxAudioStreamCount2.Text = iaudiostreamcouunt.ToString();
                this.TextBoxMediaContainer2.Text = strmediacontainer;
                this.TextBoxVideoStreamFormat2.Text = strvideostreamformat.ToString();
                this.TextBoxAudioStreamFormat2.Text = straudiostreamformat.ToString();


               
            }
        }

        private void chkVideo1Visible_Click(object sender, EventArgs e)
        {
          if(chkVideo1Visible.Checked)
            axTimelineControl1.SetTrackVisible(int.Parse(txtvideo1trackindex.Text), 1);
          else
            axTimelineControl1.SetTrackVisible(int.Parse(txtvideo1trackindex.Text), 0);
        }

        private void chkVideo2Visible_Click(object sender, EventArgs e)
        {
            if (chkVideo2Visible.Checked)
                axTimelineControl1.SetTrackVisible(int.Parse(txtvideo2trackindex.Text), 1);
            else
                axTimelineControl1.SetTrackVisible(int.Parse(txtvideo2trackindex.Text), 0);
        }

        private void btnaddvideo2_Click(object sender, EventArgs e)
        {
            short iResultClipIndex;
            iResultClipIndex = (short)axTimelineControl1.AddVideoClip(int.Parse(txtvideo2trackindex.Text), txtvideo2.Text, float.Parse(txtvideo2clipstart.Text), float.Parse(txtvideo2clipstop.Text), float.Parse(txtvideo2mediastart.Text),cbovideostretchmode2.SelectedIndex);

            if (iResultClipIndex == -6)
            {
                MessageBox.Show("Does not support this media format");
                return;
            }
            else if (iResultClipIndex == -5)
            {
                MessageBox.Show("Unknow error");
                return;
            }
            else if (iResultClipIndex == -4)
            {
                MessageBox.Show("track no found");
                return;
            }
            else if (iResultClipIndex == -3)
            {
                MessageBox.Show("clipStartTime >= clipStopTime");
                return;
            }
            else if (iResultClipIndex == -2)
            {
                MessageBox.Show("the path of video file not found");
                return;
            }
            else if (iResultClipIndex == -1)
            {
                MessageBox.Show("the path of video file is empty");
                return;
            }

            txtvideo2clipindex.Text = iResultClipIndex.ToString();

            if (TextBoxAudioStreamCount2.Text != "0")
                axTimelineControl1.AddAudioClip(int.Parse(txtaudio2trackindex.Text), txtvideo2.Text, float.Parse(txtvideo2clipstart.Text), float.Parse(txtvideo2clipstop.Text), float.Parse(txtvideo2mediastart.Text), float.Parse(txtaudio2volume.Text)).ToString();
   
            _IsChanged = true;

            UpdateTimelineDuration();
        }

        private void chkAudio1Visible_Click(object sender, EventArgs e)
        {
            if (chkAudio1Visible.Checked)
                axTimelineControl1.SetTrackVisible(int.Parse(txtaudio1trackindex.Text), 1);
            else
                axTimelineControl1.SetTrackVisible(int.Parse(txtaudio1trackindex.Text), 0);
        }

        private void btnselectaudio2_Click(object sender, EventArgs e)
        {

            openFileDialog1.Filter = "All Files (*.*)|*.*|wav (*.wav)|*.wav|MP3 (*.mp3)|*.mp3|WMA (*.wma)|*.wma|M4a (*.m4a)|*.m4a|Ogg (*.ogg)|*.ogg|AC3 (*.ac3)|*.ac3|Flac (*.flac)|*.flac|MP2 (*.mp2)|*.mp2|mpg (*.mpg*.vob) | *.mpg;*.vob|avi (*.avi) | *.avi|Divx (*.divx) | *.divx|wmv (*.wmv)| *.wmv|QuickTime (*.mov)| *.mov|MP4 (*.mp4) | *.mp4|WebM (*.webm) | *.webm|FLV (*.flv) | *.flv|MKV (*.mkv) | *.mkv|AVCHD (*.m2ts*.ts*.mts*m2t)|*.m2ts;*.ts;*.mts;*.m2t;...";
      
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                float iduration;
                int iwidth;
                int iheight;
                float iframerate;
                int ivideobitrate;
                int iaudiobitrate;
                int iaudiochannel;
                int iaudiosamplerate;
                int ivideostreamcount;
                int iaudiostreamcouunt;
                string strmediacontainer;
                string strvideostreamformat;
                string straudiostreamformat;

                txtaudio2.Text = openFileDialog1.FileName;

                axTimelineControl1.GetMediaInfo(txtaudio2.Text, out iduration, out iwidth, out iheight, out iframerate, out ivideobitrate, out iaudiobitrate, out iaudiosamplerate, out iaudiochannel, out ivideostreamcount, out iaudiostreamcouunt, out strmediacontainer, out strvideostreamformat, out straudiostreamformat);

                double iDur = Math.Round(iduration, 2);

                this.txtaudio2clipstart.Text = "0";

                this.txtaudio2clipstop.Text = iDur.ToString();

                this.TextBoxA2Width.Text = iwidth.ToString();
                this.TextBoxA2Height.Text = iheight.ToString();
                this.TextBoxA2FrameRate.Text = iframerate.ToString();
                this.TextBoxA2VideoBitrate.Text = ivideobitrate.ToString();
                this.TextBoxA2AudioBitrate.Text = iaudiobitrate.ToString();
                this.TextBoxA2AudioSample.Text = iaudiosamplerate.ToString();
                this.TextBoxA2AudioChannel.Text = iaudiochannel.ToString();
                this.TextBoxA2VideoStreamCount.Text = ivideostreamcount.ToString();
                this.TextBoxA2AudioStreamCount.Text = iaudiostreamcouunt.ToString();
                this.TextBoxA2MediaContainer.Text = strmediacontainer;
                this.TextBoxA2VideoStreamFormat.Text = strvideostreamformat.ToString();
                this.TextBoxA2AudioStreamFormat.Text = straudiostreamformat.ToString();


            }
        }

        private void btnaddaudio2_Click(object sender, EventArgs e)
        {
            short iResultClipIndex;
            iResultClipIndex = (short)axTimelineControl1.AddAudioClip(int.Parse(txtaudio2trackindex.Text), txtaudio2.Text, float.Parse(txtaudio2clipstart.Text), float.Parse(txtaudio2clipstop.Text), float.Parse(txtaudio2mediastart.Text), float.Parse(txtaudio2volume.Text));


            if (iResultClipIndex == -6)
            {
                MessageBox.Show("Does not support this media format");
                return;
            }
            else if (iResultClipIndex == -5)
            {
                MessageBox.Show("Unknow error");
                return;
            }
            else if (iResultClipIndex == -4)
            {
                MessageBox.Show("track no found");
                return;
            }
            else if (iResultClipIndex == -3)
            {
                MessageBox.Show("clipStartTime >= clipStopTime");
                return;
            }
            else if (iResultClipIndex == -2)
            {
                MessageBox.Show("the path of video/audio file not found");
                return;
            }
            else if (iResultClipIndex == -1)
            {
                MessageBox.Show("the path of video/audio file is empty");
                return;
            }
            txtaudio2clipindex.Text = iResultClipIndex.ToString();
            _IsChanged = true;
            UpdateTimelineDuration();
        }

        private void chkAudio2Visible_Click(object sender, EventArgs e)
        {
            if (chkAudio2Visible.Checked)
                axTimelineControl1.SetTrackVisible(int.Parse(txtaudio2trackindex.Text), 1);
            else
                axTimelineControl1.SetTrackVisible(int.Parse(txtaudio2trackindex.Text), 0);
        }

        private void btnchangeaudio2_Click(object sender, EventArgs e)
        {
            int iResult;

            iResult = axTimelineControl1.ChangeAudioClip(int.Parse(txtaudio2trackindex.Text), int.Parse(txtaudio2clipindex.Text), txtaudio2.Text, float.Parse(txtaudio2clipstart.Text), float.Parse(txtaudio2clipstop.Text), float.Parse(txtaudio2mediastart.Text), float.Parse(txtaudio2volume.Text));
            _IsChanged = true;

            UpdateTimelineDuration();
        }

        private void btnremoveaudio2_Click(object sender, EventArgs e)
        {
            axTimelineControl1.DeleteClip(int.Parse(txtaudio2trackindex.Text), int.Parse(txtaudio2clipindex.Text));
            _IsChanged = true;

            UpdateTimelineDuration();
        }

        private void btnselectimage_Click(object sender, EventArgs e)
        {
            if (chkuseaddimageclip2.Checked)
                openFileDialog1.Filter = "PNG Files (*.png)|*.png|JPEG Files (*.jpg)|*.jpg|BMP Files (*.bmp)|*.bmp|GIF Files (*.gif)|*.gif|TIFF Files (*.tif)|*.tif;...";
            else if (chkuseaddimagecliptran.Checked)
                openFileDialog1.Filter = "PNG Files (*.png)|*.png|JPEG Files (*.jpg)|*.jpg|BMP Files (*.bmp)|*.bmp|GIF Files (*.gif)|*.gif|TIFF Files (*.tif)|*.tif;...";
            else
                openFileDialog1.Filter = "JPEG Files (*.jpg)|*.jpg|BMP Files (*.bmp)|*.bmp;...";


            if(openFileDialog1.ShowDialog() == DialogResult.OK)
                txtimage.Text = openFileDialog1.FileName;

       
        }

        private void btnaddimage_Click(object sender, EventArgs e)
        {
             txtvideo1clipindex.Text = axTimelineControl1.AddImageClip(int.Parse(txtimagetrackindex.Text), txtimage.Text, float.Parse(txtimageclipstart.Text), float.Parse(txtimageclipstop.Text),cboimagestretchmode.SelectedIndex).ToString();
             _IsChanged = true;

             UpdateTimelineDuration();
        }

        private void btnchangeimage_Click(object sender, EventArgs e)
        {
              axTimelineControl1.ChangeImageClip(int.Parse(txtimagetrackindex.Text), int.Parse(txtimageclipindex.Text), txtimage.Text, float.Parse(txtimageclipstart.Text), float.Parse(txtimageclipstop.Text)).ToString();
              _IsChanged = true;
              UpdateTimelineDuration();
        }

        private void btnremoveimage_Click(object sender, EventArgs e)
        {
            axTimelineControl1.DeleteClip(int.Parse(txtimagetrackindex.Text), int.Parse(txtimageclipindex.Text));
            _IsChanged = true;
            UpdateTimelineDuration();
        }

        private void btnselecttextfont_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowDialog();
        }

        private void btnselecttextcolor_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
        }

        public uint Color2Uint32(Color clr)
        {

            int t;
            byte[] a;

            t = ColorTranslator.ToOle(clr);

            a = BitConverter.GetBytes(t);

            return BitConverter.ToUInt32(a, 0);

        }

        private void btnaddtext_Click(object sender, EventArgs e)
        {
           
             axTimelineControl1.SetTextClipQuality(720, 480);

            // video track resolution will affect the text clip quality
            if (Int16.Parse( txtvideotrackwidth.Text) <= 640)
            {
                txtvideotrackwidth.Text = "720";
                txtvideotrackheight.Text = "480";
                axTimelineControl1.SetVideoTrackResolution(int.Parse(txtvideotrackwidth.Text), int.Parse(txtvideotrackheight.Text));
            }

            txttextclipindex.Text = axTimelineControl1.AddTextClip(int.Parse(txttexttrackindex.Text), txtText.Text, float.Parse(txttextclipstart.Text), float.Parse(txttextclipstop.Text), (int)fontDialog1.Font.ToHfont(), int.Parse(txtTextX.Text), int.Parse(txtTextY.Text), Color2Uint32(colorDialog1.Color)).ToString();
            _IsChanged = true;

            UpdateTimelineDuration();



        }

        private void btnchangetext_Click(object sender, EventArgs e)
        {
            axTimelineControl1.ChangeTextClip(int.Parse(txttexttrackindex.Text), int.Parse(txttextclipindex.Text), txtText.Text, float.Parse(txttextclipstart.Text), float.Parse(txttextclipstop.Text), (int)fontDialog1.Font.ToHfont(), int.Parse(txtTextX.Text), int.Parse(txtTextY.Text), Color2Uint32(colorDialog1.Color));
            _IsChanged = true;
            UpdateTimelineDuration();
        }

        private void btnremovetext_Click(object sender, EventArgs e)
        {
            axTimelineControl1.DeleteClip(int.Parse(txttexttrackindex.Text), int.Parse(txttextclipindex.Text));
            _IsChanged = true;
            UpdateTimelineDuration();
        }

        private void chkTextVisible_Click(object sender, EventArgs e)
        {
            if (chkTextVisible.Checked)
                axTimelineControl1.SetTrackVisible(int.Parse(txttexttrackindex.Text), 1);
            else
                axTimelineControl1.SetTrackVisible(int.Parse(txttexttrackindex.Text), 0);
        }

        private void cboeffectname_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboeffectname.Text == "BasicImage")
                txtEffectParam.Text = "GrayScale=1,Invert=0,Mirror=0,Rotation=0,XRay=0";
            else if (cboeffectname.Text == "Blur")
                txtEffectParam.Text = "PixelRadius=10.0";
            else if (cboeffectname.Text == "Emboss")
                txtEffectParam.Text = "Bias=0.7";
            else if (cboeffectname.Text == "Engrave")
                txtEffectParam.Text = "Bias=1.0";
            else if (cboeffectname.Text == "MotionBlur")
                txtEffectParam.Text = "Direction=90,Strength=5";
            else if (cboeffectname.Text == "Pixelate")
                txtEffectParam.Text = "MaxSquare=20,Percent=25";
            else if (cboeffectname.Text == "Wave")
                txtEffectParam.Text = "Freq=3,LightStrength=15,Phase=75,Strength=50";
            else if (cboeffectname.Text == "Microsoft Movie Maker Age Filter")
                txtEffectParam.Text = "Age=50";
            else if (cboeffectname.Text == "Shadow")
                txtEffectParam.Text = "direction=50,color=#0000FF,strength=20";
            else if (cboeffectname.Text == "Chroma")
                txtEffectParam.Text = "color=FFFFFF";
            else
                txtEffectParam.Text = "";
        }

        private void btnaddeffect_Click(object sender, EventArgs e)
        {
            txteffectclipindex.Text = axTimelineControl1.AddEffect(int.Parse(txteffecttrackindex.Text), cboeffectname.Text, float.Parse(txteffectstart.Text), float.Parse(txteffectstop.Text), txtEffectParam.Text).ToString();
             _IsChanged = true;
             UpdateTimelineDuration();
        }

        private void btnchangeeffect_Click(object sender, EventArgs e)
        {
            axTimelineControl1.ChangeEffect(int.Parse(txteffecttrackindex.Text), int.Parse(txteffectclipindex.Text), cboeffectname.Text, float.Parse(txteffectstart.Text), float.Parse(txteffectstop.Text), txtEffectParam.Text).ToString();
            _IsChanged = true;
            UpdateTimelineDuration();
        }

        private void btnremoveeffect_Click(object sender, EventArgs e)
        {
            axTimelineControl1.DeleteEffect(int.Parse(txteffecttrackindex.Text), int.Parse(txteffectclipindex.Text));
           _IsChanged = true;
           UpdateTimelineDuration();
        }

        private void cboscale_SelectedIndexChanged(object sender, EventArgs e)
        {
            axTimelineControl1.SetScale(float.Parse(cboscale.Text));
        }

        private void btnaddtran_Click(object sender, EventArgs e)
        {
           int itrantrack;
           int irevdir;

           if (chkrevdir.Checked)
               irevdir = 1;
           else
               irevdir = 0;
      

        // 2 is video track
        //3 is image track
        
            if(cbotrantrack.SelectedIndex==0)
                itrantrack = 2;
            else
               itrantrack = 3;
            axTimelineControl1.SetPicinPicParam(int.Parse(textboxPicinPicLeft.Text), int.Parse(textboxPicinPicTop.Text), int.Parse(textboxPicinPicWidth.Text), int.Parse(textboxPicinPicHeight.Text));
            txttranclipindex.Text = axTimelineControl1.AddTransition(int.Parse(txttrantrackindex.Text), cbotranname.Text, float.Parse(txttranstart.Text), float.Parse(txttranstop.Text), txtTranParam.Text, itrantrack, irevdir).ToString();
            _IsChanged = true;
            UpdateTimelineDuration();
        }

        private void chkEffectVisible_Click(object sender, EventArgs e)
        {
            if (chkEffectVisible.Checked)
                axTimelineControl1.SetTrackVisible(int.Parse(txteffecttrackindex.Text), 1);
            else
                axTimelineControl1.SetTrackVisible(int.Parse(txteffecttrackindex.Text), 0);
        }

        private void btnchangetran_Click(object sender, EventArgs e)
        {
            int itrantrack;
            int irevdir;

            if (chkrevdir.Checked)
                irevdir = 1;
            else
                irevdir = 0;


            // 2 is video track
            //3 is image track

            if (cbotrantrack.SelectedIndex == 0)
                itrantrack = 2;
            else
                itrantrack = 3;

            axTimelineControl1.ChangeTransition(int.Parse(txttrantrackindex.Text), int.Parse(txttranclipindex.Text), cbotranname.Text, float.Parse(txttranstart.Text), float.Parse(txttranstop.Text), txtTranParam.Text, itrantrack, irevdir);
            _IsChanged = true;
            UpdateTimelineDuration();
        }

        private void btnremovetran_Click(object sender, EventArgs e)
        {
            axTimelineControl1.DeleteTransition(int.Parse(txttrantrackindex.Text), int.Parse(txttranclipindex.Text));
         _IsChanged = true;
         UpdateTimelineDuration();
        }

        private void chkTransitionVisible_Click(object sender, EventArgs e)
        {
            if (chkTransitionVisible.Checked)
                axTimelineControl1.SetTrackVisible(int.Parse(txttrantrackindex.Text), 1);
            else
                axTimelineControl1.SetTrackVisible(int.Parse(txttrantrackindex.Text), 0);
        }

        private void axTimelineControl1_OnClickClip(object sender, AxTimelineAxLib._ITimelineControlEvents_OnClickClipEvent e)
        {
            int iFont;
            string strEffectName;
            string strTransitionName;
            int imediaTrackIndex;
            int ireverseDirection;
          
            if (e.trackIndex == axTimelineControl1.GetVideo1TrackIndex())
            {
                string strvideo="";
                float iclipstart=0;
                float iclipstop=0;
                float imediastart=0;
                int istretchmode=0;
                txtvideo1clipindex.Text = e.clipIndex.ToString();
                axTimelineControl1.GetVideoClip(e.trackIndex, e.clipIndex, ref strvideo, ref iclipstart, ref iclipstop, ref imediastart, ref istretchmode);

                cbovideostretchmode.SelectedIndex = istretchmode;
                txtvideo1.Text = strvideo;
                txtvideo1clipstart.Text = iclipstart.ToString();
                txtvideo1clipstop.Text = iclipstop.ToString();
                txtvideo1mediastart.Text = imediastart.ToString();
                 TabControl1.SelectedIndex = 1;
            }
            else if (e.trackIndex == axTimelineControl1.GetVideo2TrackIndex())
            {

                string strvideo = "";
                float iclipstart = 0;
                float iclipstop = 0;
                float imediastart = 0;
                int istretchmode = 0;
                txtvideo2clipindex.Text = e.clipIndex.ToString();
                axTimelineControl1.GetVideoClip(e.trackIndex, e.clipIndex, ref strvideo, ref iclipstart, ref iclipstop, ref imediastart, ref istretchmode);
             
                cbovideostretchmode2.SelectedIndex = istretchmode;
                txtvideo2.Text = strvideo;
                txtvideo2clipstart.Text = iclipstart.ToString();
                txtvideo2clipstop.Text = iclipstop.ToString();
                txtvideo2mediastart.Text = imediastart.ToString();
                TabControl1.SelectedIndex = 2;

            }
            else if (e.trackIndex == axTimelineControl1.GetAudio1TrackIndex())
            {
                string straudio = "";
                float iclipstart = 0;
                float iclipstop = 0;
                float imediastart = 0;
                float ivolume = 0;
                txtaudio1clipindex.Text = e.clipIndex.ToString();
                axTimelineControl1.GetAudioClip(e.trackIndex, e.clipIndex, ref straudio, ref iclipstart, ref iclipstop, ref imediastart, ref ivolume);

                txtaudio1.Text = straudio;
                txtaudio1clipstart.Text = iclipstart.ToString();
                txtaudio1clipstop.Text = iclipstop.ToString();
                txtaudio1mediastart.Text = imediastart.ToString();
                TabControl1.SelectedIndex = 4;
                txtaudio1volume.Text = ivolume.ToString();
            }
            else if (e.trackIndex == axTimelineControl1.GetAudio2TrackIndex())
            {
                string straudio = "";
                float iclipstart = 0;
                float iclipstop = 0;
                float imediastart = 0;
                float ivolume = 0;
                txtaudio2clipindex.Text = e.clipIndex.ToString();
                axTimelineControl1.GetAudioClip(e.trackIndex, e.clipIndex, ref straudio, ref iclipstart, ref iclipstop, ref imediastart, ref ivolume);

                txtaudio2.Text = straudio;
                txtaudio2clipstart.Text = iclipstart.ToString();
                txtaudio2clipstop.Text = iclipstop.ToString();
                txtaudio2mediastart.Text = imediastart.ToString();
                txtaudio2volume.Text = ivolume.ToString();
                TabControl1.SelectedIndex = 5;
           
            }
            else if (e.trackIndex == axTimelineControl1.GetImageTrackIndex())
            {
                string strimage = "";
                float iclipstart = 0;
                float iclipstop = 0;
                int istretchmode = 0;
                txtimageclipindex.Text = e.clipIndex.ToString();
                axTimelineControl1.GetImageClip(e.trackIndex, e.clipIndex, ref strimage, ref iclipstart, ref iclipstop, ref istretchmode);

                cboimagestretchmode.SelectedIndex = istretchmode;

                    txtimage.Text = strimage;

                txtimageclipstart.Text = iclipstart.ToString();
                txtimageclipstop.Text = iclipstop.ToString();
        
                TabControl1.SelectedIndex = 3;
            }
            else if (e.trackIndex == axTimelineControl1.GetTextTrackIndex())
            {
                string strtext = "";
                float iclipstart = 0;
                float iclipstop = 0;
                int ifont=0;
                int ix=0;
                int iy=0;
                uint ucolor = 0;
                txttextclipindex.Text = e.clipIndex.ToString();
                axTimelineControl1.GetTextClip(e.trackIndex, e.clipIndex, ref strtext, ref iclipstart, ref iclipstop, ref ifont, ref ix, ref iy,ref ucolor);

                Color myTextColor = ColorTranslator.FromOle((int)ucolor);
                colorDialog1.Color = myTextColor;

                txtText.Text = strtext;
                txttextclipstart.Text = iclipstart.ToString();
                txttextclipstop.Text = iclipstop.ToString();
                txtTextX.Text = ix.ToString();
                txtTextY.Text = iy.ToString();
               
                TabControl1.SelectedIndex = 6;
            }
            else if (e.trackIndex == axTimelineControl1.GetEffectTrackIndex())
            {
                string streffect = "";
                float iclipstart = 0;
                float iclipstop = 0;
                string strparam="";
                int iFindIndex = -1;
                
                txteffectclipindex.Text = e.clipIndex.ToString();

                axTimelineControl1.GetEffect(e.trackIndex, e.clipIndex, ref streffect, ref iclipstart, ref iclipstop, ref strparam);

                iFindIndex = cboeffectname.FindString(streffect);
               
                if(iFindIndex!=-1)
                    cboeffectname.SelectedIndex = iFindIndex;

               
                txttextclipstart.Text = iclipstart.ToString();
                txttextclipstop.Text = iclipstop.ToString();
                TabControl1.SelectedIndex = 7;
            }
            else if (e.trackIndex == axTimelineControl1.GetTransitionTrackIndex())
            {
                string strtran = "";
                float iclipstart = 0;
                float iclipstop = 0;
                string strparam = "";
                int iFindIndex = -1;
                int imediatrackIindex=0;
                int ireversedir=0;
                txttranclipindex.Text = e.clipIndex.ToString();

                axTimelineControl1.GetTransition(e.trackIndex, e.clipIndex, ref strtran, ref iclipstart, ref iclipstop, ref strparam, ref imediatrackIindex, ref ireversedir);

                iFindIndex = cbotranname.FindString(strtran);

                if (iFindIndex != -1)
                    cbotranname.SelectedIndex = iFindIndex;


                if (imediatrackIindex == 2)
                    cbotrantrack.SelectedIndex = 0;
                else
                    cbotrantrack.SelectedIndex = 1;

                if (ireversedir == 1)
                    chkrevdir.Checked = true;
                else
                    chkrevdir.Checked = false;
         
                txttextclipstart.Text = iclipstart.ToString();
                txttextclipstop.Text = iclipstop.ToString();
                TabControl1.SelectedIndex = 8;
            }
        }

        private void btnremovevideo2_Click(object sender, EventArgs e)
        {
            axTimelineControl1.DeleteClip(int.Parse(txtvideo2trackindex.Text), int.Parse(txtvideo2clipindex.Text));
            _IsChanged = true;

            UpdateTimelineDuration();
        }

        private void btnload_Click(object sender, EventArgs e)
        {
            int result;

            
             openFileDialog1.Filter = "Project Files (*.xml)|*.xml||";

             if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                 
               result = (int)axTimelineControl1.LoadProject(openFileDialog1.FileName);

                if(result==0)
                    MessageBox.Show("failed");

            }

        }

        private void btnsaveproject_Click(object sender, EventArgs e)
        {
            int result;

            saveFileDialog1.Filter = "Project Files (*.xml)|*.xml||";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {

                result = (int)axTimelineControl1.SaveProject(saveFileDialog1.FileName);


                if (result == 0)
                    MessageBox.Show("failed");

            }

        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            axTimelineControl1.Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Blacklist_ThirdPartyFilters();

            string strFilter="";
            int iresult=0;

            axTimelineControl1.SetVideoTrackFrameRate(float.Parse(txtvideotrackFrameRate.Text));
            axTimelineControl1.SetVideoTrackResolution(int.Parse(txtvideotrackwidth.Text), int.Parse(txtvideotrackheight.Text));


             if(TabOutputType.SelectedIndex==3)
                //'outputtype 3 is vcd pal, 4 is vcd ntsc
                 axTimelineControl1.OutputType = cboMpegType.SelectedIndex + 3;
             else if(TabOutputType.SelectedIndex ==4)
                //'avchd
                 axTimelineControl1.OutputType = 11; 
              else if(TabOutputType.SelectedIndex ==5)
                //'flv
                 axTimelineControl1.OutputType = 12;
              else
                    axTimelineControl1.OutputType =TabOutputType.SelectedIndex;


            if( axTimelineControl1.OutputType ==0)
            {
             
                if(chkUseVideocomp.Checked)
                            axTimelineControl1.AVIVideoCompressor = cboavivencoder.SelectedIndex;
                else 
                    axTimelineControl1.AVIVideoCompressor = -1;
             
                if(chkUseAudiocomp.Checked)
                            axTimelineControl1.AVIAudioCompressor = cboaviaencoder.SelectedIndex;
                else 
                    axTimelineControl1.AVIAudioCompressor = -1;
                
                strFilter = "AVI File (*.avi)|*.avi||";
            }
            else if (axTimelineControl1.OutputType == 1)
            {
                   strFilter = "WMV File (*.wmv)|*.wmv||";
                   axTimelineControl1.WMVProfile = cboWMVProfile.SelectedIndex;
            }
            else if (axTimelineControl1.OutputType == 2)
            {
                axTimelineControl1.MP4AspectRatio = cboMP4AspectRadio.SelectedIndex;
                axTimelineControl1.MP4AudioBitrate = int.Parse(MP4AudioBitrate.Text);
                axTimelineControl1.MP4AudioChannels = int.Parse(MP4AudioChannel.Text);
                axTimelineControl1.MP4AudioSampleRate = int.Parse(MP4AudioSampleRate.Text);
                axTimelineControl1.MP4Framerate = float.Parse( MP4FrameRate.Text);
                axTimelineControl1.MP4H264Preset = cbopreset.SelectedIndex;
                axTimelineControl1.MP4Height =int.Parse(MP4Height.Text);
                axTimelineControl1.MP4Width = int.Parse(MP4Width.Text);
                axTimelineControl1.MP4VideoBitrate = int.Parse(MP4VideoBitrate.Text);
                axTimelineControl1.MP4GPUCodec = (short)cboGPU.SelectedIndex;
                axTimelineControl1.MP4NVIDAPreset = (short)cbonvidapreset.SelectedIndex;

                strFilter = "MP4 File (*.mp4)|*.mp4||";
            }
            else if (axTimelineControl1.OutputType == 11)
            {
                axTimelineControl1.AVCHDAudioBitrate =int.Parse(cboavchdaudiobitrate.Text);
                axTimelineControl1.AVCHDVideoBitrate = int.Parse(cboavchdvideobitrate.Text);
                axTimelineControl1.AVCHDVideoFrameRate = float.Parse(cboavchdframerate.Text);

                axTimelineControl1.AVCHDWidth = int.Parse(txtavchdwidth.Text);
                axTimelineControl1.AVCHDHeight = int.Parse(txtavchdheight.Text);
                
                if(cboavchdaudiosamplerate.SelectedIndex == 0)
                    axTimelineControl1.AVCHDAudioSampleRate=44100;
                else
                    axTimelineControl1.AVCHDAudioSampleRate=48000;
                 
                
                if(chkavchd169.Checked)
                    axTimelineControl1.AVCHDAspectRatio = 1;
                else
                    axTimelineControl1.AVCHDAspectRatio = 0;

                strFilter = "AVCHD File (*.m2ts)|*.m2ts||";
            }
            else if (axTimelineControl1.OutputType == 12)
            {
                axTimelineControl1.FLVVideoBitrate = int.Parse(flvVideoBitrate.Text);
                axTimelineControl1.FLVAudioBitrate = int.Parse(flvAudioBitrate.Text);
                axTimelineControl1.FLVAudioChannels = int.Parse(flvAudioChannel.Text);
                axTimelineControl1.FLVAudioSampleRate = int.Parse(flvAudioSampleRate.Text);
                axTimelineControl1.FLVFrameRate = float.Parse(flvFrameRate.Text);
                axTimelineControl1.FLVWidth = int.Parse(flvWidth.Text);
                axTimelineControl1.FLVHeight = int.Parse(flvHeight.Text);
                strFilter = "FLV File (*.flv)|*.flv||";
            }
            else
            {
                axTimelineControl1.MPEGFrameRate = float.Parse(cboMpegFrameRate.Text);
                axTimelineControl1.MPEGAudioSampleRate = int.Parse(cboMpegaudiosamplerate.Text);
                axTimelineControl1.MPEGAudioBitrate = int.Parse(txtAudioBitRate.Text);
                axTimelineControl1.MPEGAudioChannels = int.Parse(txtMPEGAudioChannel.Text);
                axTimelineControl1.MPEGVideoBitrate = int.Parse(txtVideoBitRate.Text);
                axTimelineControl1.MPEGWidth = int.Parse(txtmpegwidth.Text);
                axTimelineControl1.MPEGHeight = int.Parse(txtmpegheight.Text);

                if(chkmpeg169.Checked)
                    axTimelineControl1.MPEGAspectRatio = 1;
                else
                    axTimelineControl1.MPEGAspectRatio = 0;
                strFilter = "MPEG File (*.mpg)|*.mpg||";

                
         
            }

            saveFileDialog1.Filter = strFilter;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
               iresult = axTimelineControl1.Save(saveFileDialog1.FileName);


               ListBox1.Items.Clear();
                //get current graph filters and add to listbox
               for (int i = 0; i < axTimelineControl1.DecoderGetCurrentFiltersCount() - 1; i++)
               {
                   ListBox1.Items.Add(axTimelineControl1.DecoderGetCurrentFilterName(i));
               }
              
                if (iresult != 1)
                {
                    MessageBox.Show("Save Failed");
                }
            }
        }

        private void axTimelineControl1_OnConvertProgress(object sender, AxTimelineAxLib._ITimelineControlEvents_OnConvertProgressEvent e)
        {
            ProgressBar1.Value = e.progress;
        }

        private void axTimelineControl1_OnConvertCompleted(object sender, EventArgs e)
        {
            MessageBox.Show("Save Completed");
        }

        private void axTimelineControl1_OnPlaying(object sender, AxTimelineAxLib._ITimelineControlEvents_OnPlayingEvent e)
        {

            double cur =Math.Floor((double)e.currentPosition) / 1000;
            txtcurrentpos.Text = cur.ToString(); 
        }

        private void btnStopConversion_Click(object sender, EventArgs e)
        {
            axTimelineControl1.StopConversion();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

        }

        private void chkenableseeking_Click(object sender, EventArgs e)
        {
            if(chkenableseeking.Checked)
                axTimelineControl1.EnableSeeking=true;
            else
                axTimelineControl1.EnableSeeking = false;
        }

        private void TabPage1_Click(object sender, EventArgs e)
        {

        }

        private void btnbgtheme_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
                axTimelineControl1.SetThemeBg(this.cboBgTheme.SelectedIndex, Color2Uint32(colorDialog1.Color));
    
        }

        private void btnfgtheme_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
                axTimelineControl1.SetThemeFg(this.cboFgTheme.SelectedIndex, Color2Uint32(colorDialog1.Color));
  
        }

        private void btnbordertheme_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
                axTimelineControl1.SetThemeBorder(this.cboBorderTheme.SelectedIndex, Color2Uint32(colorDialog1.Color));
   
        }

        private void btntrackicon1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "PNG Files (*.png)|*.png||";

            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                axTimelineControl1.ChangeTrackImage(0, openFileDialog1.FileName);
                axTimelineControl1.SetScale(float.Parse(cboscale.Text));
            }
        }

        private void btntrackicon2_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "PNG Files (*.png)|*.png||";

            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                axTimelineControl1.ChangeTrackImage(1, openFileDialog1.FileName);
                axTimelineControl1.SetScale(float.Parse(cboscale.Text));
            }
        
        }

        private void btntrackicon3_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "PNG Files (*.png)|*.png||";

            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                axTimelineControl1.ChangeTrackImage(2, openFileDialog1.FileName);
                axTimelineControl1.SetScale(float.Parse(cboscale.Text));
            }
        
        }

        private void btntrackicon4_Click(object sender, EventArgs e)
        {
             openFileDialog1.Filter = "PNG Files (*.png)|*.png||";

            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                axTimelineControl1.ChangeTrackImage(3, openFileDialog1.FileName);
                axTimelineControl1.SetScale(float.Parse(cboscale.Text));
            }

        
        }

        private void btntrackicon5_Click(object sender, EventArgs e)
        {
              openFileDialog1.Filter = "PNG Files (*.png)|*.png||";

            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                axTimelineControl1.ChangeTrackImage(4, openFileDialog1.FileName);
                axTimelineControl1.SetScale(float.Parse(cboscale.Text));
            }

       
        }

        private void Button39_Click(object sender, EventArgs e)
        {
              openFileDialog1.Filter = "PNG Files (*.png)|*.png||";

            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                axTimelineControl1.ChangeTrackImage(5, openFileDialog1.FileName);
                axTimelineControl1.SetScale(float.Parse(cboscale.Text));

            }

        }

        private void Button40_Click(object sender, EventArgs e)
        {
             openFileDialog1.Filter = "PNG Files (*.png)|*.png||";

            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                axTimelineControl1.ChangeTrackImage(6, openFileDialog1.FileName);
                axTimelineControl1.SetScale(float.Parse(cboscale.Text));
            }
        
        }

        private void Button41_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "PNG Files (*.png)|*.png||";

            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                axTimelineControl1.ChangeTrackImage(7, openFileDialog1.FileName);
                axTimelineControl1.SetScale(float.Parse(cboscale.Text));
            }
        
        }

        private void Button42_Click(object sender, EventArgs e)
        {
               openFileDialog1.Filter = "PNG Files (*.png)|*.png||";

            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                axTimelineControl1.ChangeAudioClipImage(openFileDialog1.FileName);
                axTimelineControl1.SetScale(float.Parse(cboscale.Text));
            }
        
        }

        private void btnchangevideo2_Click(object sender, EventArgs e)
        {
            int iResult;

            iResult = axTimelineControl1.ChangeVideoClip(int.Parse(txtvideo2trackindex.Text), int.Parse(txtvideo2clipindex.Text), txtvideo2.Text, float.Parse(txtvideo2clipstart.Text), float.Parse(txtvideo2clipstop.Text), float.Parse(txtvideo2mediastart.Text));
            _IsChanged = true;

            UpdateTimelineDuration();
        }
        private void SelectedGPUCombBox()
        {
            if(cboGPU.SelectedIndex == 1)
            {
                cbonvidapreset.Enabled = true;
                cbopreset.Enabled = false;
            }
            else
            {
            cbonvidapreset.Enabled = false;
            cbopreset.Enabled = true;
            }
        }

        private void cboGPU_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedGPUCombBox();
        }

        private void Button43_Click(object sender, EventArgs e)
        {
            cboGPU.SelectedIndex = axTimelineControl1.MP4DetectGPU();
        }

        private void chkpreviewaspectratio_CheckedChanged(object sender, EventArgs e)
        {
             if(axTimelineControl1.IsHandleCreated)
             {
                 if(chkpreviewaspectratio.Checked)
                    axTimelineControl1.PreviewWndAspectRatio = true;
                else
                axTimelineControl1.PreviewWndAspectRatio = false;
             }
            
        }

        private void cbopreviewsize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbopreviewsize.SelectedIndex == 0)
                axTimelineControl1.SetPreviewWndSize(0);
            else
                axTimelineControl1.SetPreviewWndSize(Int16.Parse( cbopreviewsize.Text));
        
        }

        private void hScrollBarScaleTimeline_Scroll(object sender, ScrollEventArgs e)
        {
            int iScrollValue = hScrollBarScaleTimeline.Value;


            if (iScrollValue >= 10) //zoom in
            {

                float scale = (float)(iScrollValue * 0.01);

                axTimelineControl1.SetScale(scale);
            }
            else if (iScrollValue >= 1 || iScrollValue <= 9) //zoom out
            {

                float scale = (float)(iScrollValue * 0.001);
               
                axTimelineControl1.SetScale(scale);

            }
        }

        private void hScrollBarScaleOutTimeline_Scroll(object sender, ScrollEventArgs e)
        {
         
        }

        private void radioDragOverToRight_CheckedChanged(object sender, EventArgs e)
        {
            axTimelineControl1.DragOverMoveClipMode = 0;

        }

        private void radioDragOverToLeft_CheckedChanged(object sender, EventArgs e)
        {
            axTimelineControl1.DragOverMoveClipMode = 1;

        }

        private void btnzoomdefault_Click(object sender, EventArgs e)
        {
            hScrollBarScaleTimeline.Value = 9;
            int iScrollValue = hScrollBarScaleTimeline.Value;
            float scale = (float)(iScrollValue * 0.001);

            axTimelineControl1.SetScale(scale);

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //axTimelineControl1.AddImageClip2(int.Parse(txtimagetrackindex.Text), txtimage.Text, 1024,768, Color2Uint32(Color.Black),30,10,320,240,float.Parse(txtimageclipstart.Text), float.Parse(txtimageclipstop.Text), cboimagestretchmode.SelectedIndex).ToString();
            int iClipIndex;
            if (chkuseaddimagecliptran.Checked)
            {
                int iImageWidth=0;
                int iImageHeight =0;

                if (chkKeepOrgSize.Checked)
                {
                    // set to 0x0 it mean use original size
                    iImageWidth = 0;
                    iImageHeight = 0;
                }
                else
                {
                    iImageWidth = int.Parse(txtimage2width.Text);
                    iImageHeight = int.Parse(txtimage2height.Text);
                }

                iClipIndex = axTimelineControl1.AddImageClipTransparent(int.Parse(txtimagetrackindex.Text), txtimage.Text, int.Parse(txtOutputImageWidth.Text), int.Parse(txtOutputImageHeight.Text), Color2Uint32(colorDialog1.Color), int.Parse(txtimage2left.Text), int.Parse(txtimage2top.Text), iImageWidth, iImageHeight, float.Parse(txtimageclipstart.Text), float.Parse(txtimageclipstop.Text));

            }
            else
                iClipIndex = axTimelineControl1.AddImageClip2(int.Parse(txtimagetrackindex.Text), txtimage.Text, int.Parse(txtOutputImageWidth.Text), int.Parse(txtOutputImageHeight.Text), Color2Uint32(colorDialog1.Color), int.Parse(txtimage2left.Text), int.Parse(txtimage2top.Text), int.Parse(txtimage2width.Text), int.Parse(txtimage2height.Text), float.Parse(txtimageclipstart.Text), float.Parse(txtimageclipstop.Text));
          
            txtimageclipindex.Text = iClipIndex.ToString();
            _IsChanged = true;

            UpdateTimelineDuration();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void chkuseaddimageclip2_CheckedChanged(object sender, EventArgs e)
        {
            if (chkuseaddimageclip2.Checked)
            {
                
                chkuseaddimagecliptran.Checked = false;

                btnAddImageClip2BgColor.Enabled = true;
                btnAddImageClip2.Enabled = true;
                btnaddimage.Enabled = false;


            }
            else
            {
                btnAddImageClip2BgColor.Enabled = false;
                btnAddImageClip2.Enabled = false;
                btnaddimage.Enabled = true;

            }

        }

        private void axTimelineControl1_Enter(object sender, EventArgs e)
        {

        }

        private void TabPage4_Click(object sender, EventArgs e)
        {

        }

        private void btnAddImageClip2BgColor_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
        }

        private void chkuseaddimagecliptran_CheckedChanged(object sender, EventArgs e)
        {
            if (chkuseaddimagecliptran.Checked)
            {
             
                chkuseaddimageclip2.Checked = false;
                btnAddImageClip2BgColor.Enabled = true;

                btnAddImageClip2BgColor.Text = "Transparent Color";

                btnAddImageClip2.Enabled = true;
                btnAddImageClip2.Text = "Add AddImageClipTransparent";
                btnaddimage.Enabled = false;

             
            }
            else
            {
                btnAddImageClip2.Enabled = false;
                btnAddImageClip2.Text = "Add AddImageClip2";
             
                btnAddImageClip2BgColor.Enabled = false;

                btnAddImageClip2BgColor.Text = "Bg Color";
                btnaddimage.Enabled = true;

            }    
        }

        private void chkKeepOrgSize_CheckedChanged(object sender, EventArgs e)
        {
            if (chkKeepOrgSize.Checked)
            {
                txtimage2width.Enabled = false;
                txtimage2height.Enabled = false;
               
            }
            else
            {
                txtimage2width.Enabled = true;
                txtimage2height.Enabled = true;

            }
        }
       
       
        
    }
}
