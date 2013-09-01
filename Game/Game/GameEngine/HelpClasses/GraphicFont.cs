using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Drawing;
using Microsoft.Xna.Framework.Graphics;
using System.IO;
using System.Drawing.Text;

namespace Game.GameEngine.HelpClasses
{
    public class GraphicFont
    {
        private const int MAX = 128;
        private string fontFamily = "Tahoma";
        private int width = 10;
        private Font font = null;
        private int[] size = new int[MAX];
        private Bitmap graphicFont = null;
        private Texture2D texture = null;
        private FontStyle fontStyle = FontStyle.Regular;

        public static Hashtable hp = new Hashtable();

        public static void HashData()
        {
            hp.Clear();
            GraphicFont gf = new GraphicFont();
            for (int i = 0; i <= 100; i++)
            {
                var item = gf.GetTexture2D("HP: " + i);
                hp.Add(i, item);
            }
        }

        public GraphicFont()
        {
            //fontFamily = "A Trip To Hell And Back";
            fontFamily = "A Year Without Rain";
            font = new Font(fontFamily, width, fontStyle);
            Redraw();
        }

        public void SetFont(string fontFamily, int Size, FontStyle fontStyle)
        {
            this.fontFamily = fontFamily;
            this.width = Size;
            this.fontStyle = fontStyle;
            font = new Font(fontFamily, width, fontStyle);
            Redraw();
        }

        private void Redraw()
        {
            Bitmap image = new Bitmap(1, 1);
            int W = 0;
            using (Graphics gr = Graphics.FromImage(image: image))
            {
                int x = 0;
                while (x < MAX)
                {
                    int index = x;
                    size[index] = (int)gr.MeasureString("" + (char)x, font).Width;
                    if ((fontStyle & FontStyle.Italic) == FontStyle.Italic)
                        size[index] += (int)(size[index] * 0.08);
                    W += size[index];
                    x++;
                }
            }
            image = new Bitmap(W, font.Height);
            using (Graphics gr = Graphics.FromImage(image: image))
            {
                gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.Default;
                gr.Clear(Color.WhiteSmoke);
                int x = 0;
                int offset = 0;
                while (x < MAX)
                {
                    int index = x;
                    gr.DrawString("" + (char)x, font, Brushes.White, new Point(offset, 0));
                    offset += size[index];
                    x++;
                }
            }
            graphicFont = image;
            MemoryStream ms = new MemoryStream();
            graphicFont.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            texture = Texture2D.FromStream(MainGame.Device, ms);
            ms.Dispose();
        }

        public Texture2D GetTexture2D(string text)
        {
            Bitmap tmp = GetBitmap(text);
            MemoryStream ms = new MemoryStream();
            tmp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            Texture2D res = Texture2D.FromStream(MainGame.Device, ms);
            ms.Dispose();
            return res;
        }

        private Bitmap GetBitmap(string text)
        {
            if (text.Length == 0) return new Bitmap(1, 1);
            int W = 0;
            for (int i = 0; i < text.Length; i++)
            {
                int index = (int)text[i];
                if (index >= MAX) index = (int)'?';
                W += size[index];
            }
            Bitmap res = new Bitmap(W, font.Height);
            using (Graphics gr = Graphics.FromImage(res))
            {
                gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.Default;
                gr.Clear(Color.WhiteSmoke);
                int offset = 0;
                for (int i = 0; i < text.Length; i++)
                {
                    int index = (int)text[i];
                    if (index >= MAX) index = (int)'?';
                    int gfOffset = 0;
                    for (int j = 0; j < index; j++)
                    {
                        gfOffset += size[j];
                    }
                    gr.DrawImage(graphicFont, new Rectangle(offset, 0, size[index], font.Height),
                        new Rectangle(gfOffset, 0, size[index], res.Height), GraphicsUnit.Pixel);
                    offset += size[index];
                }
            }
            res.MakeTransparent(Color.WhiteSmoke);
            return res;
        }

        public void LoadFromFile(string fileName)
        {
            int start = 0;
            int pos = 0;
            int textureOffset = 0;
            int textureLenght = 0;
            using (FileStream fs = new FileStream(fileName, FileMode.Open))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    string file = sr.ReadToEnd();

                    pos = file.IndexOf("~");
                    string fFamily = file.Substring(start, pos);
                    this.fontFamily = fFamily;
                    start = pos + 1;
                    pos = file.IndexOf("~", start);
                    string fWidth = file.Substring(start, pos - start);
                    this.width = Int32.Parse(fWidth);
                    start = pos + 1;
                    pos = file.IndexOf("~", start);
                    string fStyle = file.Substring(start, pos - start);
                    fontStyle = (FontStyle)Int32.Parse(fStyle);
                    start = pos + 1;

                    pos = file.IndexOf("____|____", start);
                    string sizeStr = file.Substring(start, pos - start);
                    ParseSize(sizeStr);

                    start = pos + "____|____".Length;
                    pos = file.IndexOf("____|____", start);
                    start = pos + "____|____".Length;
                    pos = file.IndexOf("|", start);
                    string offset = file.Substring(start, pos - start);
                    textureOffset = Int32.Parse(offset);
                    start = pos + "|".Length;
                    pos = file.IndexOf("|", start);
                    string lenght = file.Substring(start, pos - start);
                    textureLenght = Int32.Parse(lenght);
                }
            }
            using (FileStream fs = new FileStream(fileName, FileMode.Open))
            {
                using (BinaryReader br = new BinaryReader(fs))
                {
                    br.BaseStream.Seek(textureOffset, SeekOrigin.Begin);
                    byte[] data = br.ReadBytes(textureLenght);
                    ParseTexture(data);
                }
            }
        }

        private void ParseTexture(byte[] array)
        {
            MemoryStream ms = new MemoryStream(array);
            texture = Texture2D.FromStream(MainGame.Device, ms);
            ms.Seek(0, SeekOrigin.Begin);
            graphicFont = (Bitmap)Bitmap.FromStream(ms);
            ms.Dispose();
        }

        private void ParseSize(string data)
        {
            string[] cells = data.Split('|');
            size = new int[cells.Length];
            for (int j = 0; j < cells.Length; j++)
            {
                int value = Int32.Parse(cells[j]);
                size[j] = value;
            }
        }

    }
}
