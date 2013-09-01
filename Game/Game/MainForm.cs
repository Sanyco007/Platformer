using System;
using System.Drawing;
using System.Windows.Forms;
using Game.GameEngine;

namespace Game
{
    public partial class MainForm : Form
    {
        private bool _fullScreen;

        public MainForm()
        {
            InitializeComponent();
            _fullScreen = false;
            ClientSize = new Size(720, 480);
            Program.Game = new MainGame(pCanvas);
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            Keyboard.KeyDown(e.KeyData);
            if (Keyboard.IsKeyDown(Keys.F5))
            {
                ChangeMode();
            }
            if (Keyboard.IsKeyDown(Keys.F6))
            {
                MainGame.ShowFps = !MainGame.ShowFps;
            }
            if (Keyboard.IsKeyDown(Keys.Escape))
            {
                Close();
            }
        }

        private void ChangeMode()
        {
            _fullScreen = !_fullScreen;
            if (_fullScreen)
            {
                FormBorderStyle = FormBorderStyle.None;
                WindowState = FormWindowState.Maximized;
                pCanvas.Width = ClientSize.Width;
                pCanvas.Height = 720;
                pCanvas.Top = (ClientSize.Height - pCanvas.Height) / 2;
            }
            else
            {
                FormBorderStyle = FormBorderStyle.FixedSingle;
                WindowState = FormWindowState.Normal;
                pCanvas.Width = 720;
                pCanvas.Height = 480;
                pCanvas.Top = 0;
            }
        }

        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            Keyboard.KeyUp(e.KeyData);
        }

        private void MainForm_Deactivate(object sender, EventArgs e)
        {
            Keyboard.ClearState();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.Game.Stop();
        }
    }
}
