using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using System.Drawing;
using System.IO;

namespace Game.GameEngine.HelpClasses
{
    public class GraphicsConvert
    {
        public static Texture2D ToTexture2D(Bitmap bitmap)
        {
            MemoryStream ms = new MemoryStream();
            bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            var res = Texture2D.FromStream(MainGame.Device, ms);
            ms.Dispose();
            return res;
        }
    }
}
