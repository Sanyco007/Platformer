using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Game
{
    public class XNACanvas : Panel
    {
        private GraphicsDevice device;
        private PresentationParameters pp = new PresentationParameters();
        private static Color bgColor = Color.White;
        private SpriteBatch spriteBatch = null;

        public GraphicsDevice Device { get { return device; } }

        public delegate void Draw(DrawEventArgs args);
        public event Draw OnDraw = null;

        public XNACanvas()
        {
            pp.BackBufferFormat = SurfaceFormat.Color;
            pp.BackBufferHeight = 480;
            pp.BackBufferWidth = 720;
            pp.DeviceWindowHandle = this.Handle;
            pp.IsFullScreen = false;
            device = new GraphicsDevice(GraphicsAdapter.DefaultAdapter, GraphicsProfile.Reach, pp);
            this.SetStyle(ControlStyles.Opaque, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            spriteBatch = new SpriteBatch(device);
        }

        protected override void OnResize(EventArgs eventargs)
        {
            //pp.BackBufferHeight = this.Height;
            //pp.BackBufferWidth = this.Width;
            //device.Reset(pp);
            base.OnResize(eventargs);
        }

        public static void SetBGColor(Color color)
        {
            bgColor = color;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            device.Clear(bgColor);
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied);
            if (OnDraw != null)
            {
                this.OnDraw(new DrawEventArgs(spriteBatch));
            }
            spriteBatch.End();
            device.Present();
            base.OnPaint(pe);
        }

        protected override void Dispose(bool disposing)
        {
            device.Dispose();
            device = null;
            base.Dispose(disposing);
        }

    }

    public class DrawEventArgs
    {
        public SpriteBatch spriteBatch { get; private set; }

        public DrawEventArgs(SpriteBatch spriteBatch)
        {
            this.spriteBatch = spriteBatch;
        }
    }
}
