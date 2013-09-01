using System;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TileMapEditor
{
    public class XNACanvas : Panel
    {
        private GraphicsDevice device;
        private PresentationParameters pp = new PresentationParameters();
        private Color bgColor = Color.White;
        private SpriteBatch spriteBatch = null;

        public GraphicsDevice Device { get { return device; } }

        public delegate void Draw(DrawEventArgs args);
        public event Draw OnDraw = null;

        public XNACanvas()
        {   
            pp.BackBufferFormat = SurfaceFormat.Color;
            pp.BackBufferHeight = this.Height;
            pp.BackBufferWidth = this.Width;
            pp.DeviceWindowHandle = this.Handle;
            pp.IsFullScreen = false;
            device = new GraphicsDevice(GraphicsAdapter.DefaultAdapter, GraphicsProfile.Reach, pp);
            this.SetStyle(ControlStyles.Opaque, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            spriteBatch = new SpriteBatch(device);
        }

        protected override void OnResize(EventArgs eventargs)
        {
            pp.BackBufferHeight = this.Height;
            pp.BackBufferWidth = this.Width;
            device.Reset(pp);
            base.OnResize(eventargs);
        }

        public void SetBGColor(Color color)
        {
            this.bgColor = color;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            device.Clear(bgColor);
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied);
            if (OnDraw != null)
            {
                int index = 0;
                try
                {
                    index = Int32.Parse(Tag as String);
                }
                catch { Tag = "0"; }
                this.OnDraw(new DrawEventArgs(spriteBatch, index));
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
        public int Tag { get; private set; }

        public DrawEventArgs(SpriteBatch spriteBatch, int tag)
        {
            this.spriteBatch = spriteBatch;
            this.Tag = tag;
        }
    }
}
