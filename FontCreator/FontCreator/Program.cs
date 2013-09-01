using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Xna.Framework.Graphics;

namespace FontCreator
{
    static class Program
    {
        public static GraphicsDevice device;
        private static PresentationParameters pp = new PresentationParameters();

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            using (MainForm form = new MainForm())
            {
                pp.BackBufferFormat = SurfaceFormat.Color;
                pp.BackBufferHeight = 720;
                pp.BackBufferWidth = 480;
                pp.DeviceWindowHandle = form.Handle;
                pp.IsFullScreen = false;
                device = new GraphicsDevice(GraphicsAdapter.DefaultAdapter, GraphicsProfile.Reach, pp);
                form.CreateFontObject();
                Application.Run(form);
            }
        }
    }
}
