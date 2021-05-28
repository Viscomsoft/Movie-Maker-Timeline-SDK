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
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
              openFileDialog1.Filter = "All Files (*.*)|*.*|mpg (*.mpg*.vob) | *.mpg;*.vob|avi (*.avi) | *.avi|Divx (*.divx) | *.divx|wmv (*.wmv)| *.wmv|QuickTime (*.mov)| *.mov|MP4 (*.mp4) | *.mp4|AVCHD (*.m2ts*.ts*.mts*m2t)|*.m2ts;*.ts;*.mts;*.m2t|wav (*.wav)|*.wav|MP3 (*.mp3)|*.mp3|WMA (*.wma)|*.wma||";

              if (openFileDialog1.ShowDialog() == DialogResult.OK)
              {
                  listBox1.Items.Add(openFileDialog1.FileName);
              }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void listBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (listBox1.Items.Count == 0 || listBox1.SelectedItem == null)
                return;
            string s = listBox1.SelectedItem.ToString();
            DragDropEffects dde1 = DoDragDrop(s, DragDropEffects.All);

            if (dde1 == DragDropEffects.All)
            {
                listBox1.Items.Remove(listBox1.SelectedItem.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            axTimelineControl1.Play();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cboscale.Items.Add("0.01");
            cboscale.Items.Add("0.03");

            cboscale.Items.Add("0.05");
            cboscale.Items.Add("0.1");
            cboscale.Items.Add("0.2");
            cboscale.Items.Add("0.4");
            cboscale.Items.Add("1.0");
            cboscale.Items.Add("2.0");
            cboscale.Items.Add("3.0");
            cboscale.SelectedIndex = 6;
        }

        private void cboscale_SelectedIndexChanged(object sender, EventArgs e)
        {
            axTimelineControl1.SetScale(float.Parse(cboscale.Text));
        }
    }
}
