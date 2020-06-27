using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace vog_maker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        OpenFileDialog import_image = new OpenFileDialog();
        OpenFileDialog import_audio = new OpenFileDialog();
        bool audio_is_playing = false;
        SaveFileDialog export_image = new SaveFileDialog();

        private void button1_Click(object sender, EventArgs e)
        {
            import_image.Filter = "GIF|*.gif|PNG|*.png|JPG|*.jpg";
            if (import_image.ShowDialog() == DialogResult.OK)
            {
                label1.Text = import_image.FileName;

                Bitmap pic = new Bitmap(import_image.FileName);
                pictureBox1.Image = pic;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            import_audio.Filter = "MP3|*.mp3|Wave|*.wav";
            if (import_audio.ShowDialog() == DialogResult.OK)
            {
                label2.Text = import_audio.FileName;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            export_image.Filter = "Voice Over GIF|*.vog";
            if (export_image.ShowDialog() == DialogResult.OK)
            {
                label3.Text = "file saved";
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProcessStartInfo sInfo = new ProcessStartInfo("http://bluepeople.dx.am/");
            Process.Start(sInfo);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("This app is written by Arad HamidSamiee\n23th June 2020 (with love from apocalypse)\nRespect the licence\nGithub link is the tool strip");
        }

        private void gitHubToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProcessStartInfo sInfo = new ProcessStartInfo("https://github.com/AradHamidSamiee");
            Process.Start(sInfo);

        }

        private void newFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 newForm = new Form1();
            newForm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SoundPlayer audio_player;
            if (import_audio.FileName != "")
            {
                audio_player = new SoundPlayer(import_audio.FileName);
                audio_player.Play();
                button4.Text = "Press to Stop";
                audio_is_playing = true;
            }
            if (audio_is_playing == true)
            {
                audio_player = new SoundPlayer(import_audio.FileName);
                audio_player.Stop();
                button4.Text = "Play Imported Audio File";
                audio_is_playing = false;
            }

        }

    }
}