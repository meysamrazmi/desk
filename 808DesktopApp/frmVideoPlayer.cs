using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _808DesktopApp
{
    public partial class frmVideoPlayer : Form
    {
        string filePath = string.Empty;
        public frmVideoPlayer(string filePath)
        {
            this.filePath = filePath;
            InitializeComponent();
        }

        private void frmVideoPlayer_Load(object sender, EventArgs e)
        {
            axVLCPlugin21.playlist.add("file:///" + filePath);
            axVLCPlugin21.playlist.play();
            axVLCPlugin21.MediaPlayerTimeChanged += AxVLCPlugin21_MediaPlayerTimeChanged;
        }

        private void AxVLCPlugin21_MediaPlayerTimeChanged(object sender, AxAXVLC.DVLCEvents_MediaPlayerTimeChangedEvent e)
        {
            var time = new  TimeSpan(0,0,0,0,e.time);
            this.Text = time.ToString(@"hh\:mm\:ss");

        }
    }
}
