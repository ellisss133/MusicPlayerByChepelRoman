using System;
using System.Windows.Forms;

namespace StatePatternMusicPlayer
{
    public partial class MainForm : Form
    {
        private PlayerContext _context;

        public MainForm()
        {
            InitializeComponent();
            _context = new PlayerContext();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            _context.Play();
            UpdateState();
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            _context.Pause();
            UpdateState();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            _context.Stop();
            UpdateState();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            _context.Next();
            UpdateState();
        }

        private void UpdateState()
        {
            lblState.Text = _context.GetStateName();
            lblTrack.Text = _context.GetCurrentTrack();
        }
    }
}