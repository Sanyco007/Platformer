using System;
using System.Windows.Forms;
using Game.GameEngine;

namespace Game
{
    static class Program
    {
        public static MainGame Game = null;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
