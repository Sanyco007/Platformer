using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.IO;
using BBox = Game.GameEngine.HelpClasses.BoundingBox;
using Game.GameEngine.Sprites;
using Game.GameEngine.HelpClasses;

namespace Game.GameEngine.GameStates
{
    public class TileMap
    {
        private Texture2D texture = null;
        private Texture2D bgImage = null;
        private Point[,] field = new Point[5, 5];
        private Point[,] frontField = new Point[5, 5];
        private int[,] passField = new int[5, 5];
        private const int H = 32;
        private float SPEED = 1f;
        private float offsetX = 0f;

        public TileMap(string fileName)
        {
            rectT.SetData(new[] { Color.White });
            LoadFromFile(fileName);
        }

        public void Update(int delta)
        {
            offsetX -= 0.5f;
            if (Math.Abs(offsetX) >= bgImage.Width) offsetX = 0;
        }

        public void LoadFromFile(string fileName)
        {
            int start = 0;
            int pos = 0;
            int tileOffset = 0;
            int tileLenght = 0;
            int bgOffset = 0;
            int bgLenght = 0;
            using (FileStream fs = new FileStream(fileName, FileMode.Open))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    string file = sr.ReadToEnd();
                    pos = file.IndexOf("____|____");
                    string mapField = file.Substring(0, pos);
                    ParseMapField(mapField);

                    start = pos + "____|____".Length;
                    pos = file.IndexOf("____|____", start);
                    string frontField = file.Substring(start, pos - start);
                    ParseFrontField(frontField);

                    start = pos + "____|____".Length;
                    pos = file.IndexOf("____|____", start);
                    string passabilityField = file.Substring(start, pos - start);
                    ParsePassField(passabilityField);

                    MainGame.LevelWidth = field.GetLength(0) * H;
                    MainGame.LevelHeight = field.GetLength(1) * H;

                    start = pos + "____|____".Length;
                    pos = file.IndexOf("____|____", start);
                    start = pos + "____|____".Length;
                    pos = file.IndexOf("|", start);
                    string offset = file.Substring(start, pos - start);
                    tileOffset = Int32.Parse(offset);
                    start = pos + "|".Length;
                    pos = file.IndexOf("|", start);
                    string lenght = file.Substring(start, pos - start);
                    tileLenght = Int32.Parse(lenght);

                    pos = file.IndexOf("____|____", start);
                    start = pos + "____|____".Length;
                    pos = file.IndexOf("|", start);
                    offset = file.Substring(start, pos - start);
                    bgOffset = Int32.Parse(offset);
                    start = pos + "|".Length;
                    pos = file.IndexOf("|", start);
                    lenght = file.Substring(start, pos - start);
                    bgLenght = Int32.Parse(lenght);
                }
            }
            using (FileStream fs = new FileStream(fileName, FileMode.Open))
            {
                using (BinaryReader br = new BinaryReader(fs))
                {
                    br.BaseStream.Seek(tileOffset, SeekOrigin.Begin);
                    byte[] data = br.ReadBytes(tileLenght);
                    ParseTexture(data);
                    br.BaseStream.Seek(bgOffset, SeekOrigin.Begin);
                    byte[] bgData = br.ReadBytes(bgLenght);
                    ParseBGImage(bgData);
                }
            }
        }

        private void ParseTexture(byte[] array)
        {
            MemoryStream ms = new MemoryStream(array);
            texture = Texture2D.FromStream(MainGame.Device, ms);
            ms.Seek(0, SeekOrigin.Begin);
            ms.Dispose();
        }

        private void ParseBGImage(byte[] array)
        {
            MemoryStream ms = new MemoryStream(array);
            bgImage = Texture2D.FromStream(MainGame.Device, ms);
            ms.Dispose();
        }

        private void ParseMapField(string data)
        {
            bool resizeField = false;
            string[] lines = data.Split('\n');
            for (int i = 0; i < lines.Length; i++)
            {
                string[] cells = lines[i].Split('|');
                for (int j = 0; j < cells.Length; j++)
                {
                    if (!resizeField)
                    {
                        field = new Point[cells.Length, lines.Length];
                        resizeField = true;
                    }
                    string[] point = cells[j].Split(';');
                    int x = Int32.Parse(point[0]);
                    int y = Int32.Parse(point[1]);
                    field[j, i] = new Point(x, y);
                }
            }
        }

        private void ParseFrontField(string data)
        {
            bool resizeField = false;
            string[] lines = data.Split('\n');
            for (int i = 0; i < lines.Length; i++)
            {
                string[] cells = lines[i].Split('|');
                for (int j = 0; j < cells.Length; j++)
                {
                    if (!resizeField)
                    {
                        frontField = new Point[cells.Length, lines.Length];
                        resizeField = true;
                    }
                    string[] point = cells[j].Split(';');
                    int x = Int32.Parse(point[0]);
                    int y = Int32.Parse(point[1]);
                    frontField[j, i] = new Point(x, y);
                }
            }
        }

        private void ParsePassField(string data)
        {
            bool resizeField = false;
            string[] lines = data.Split('\n');
            for (int i = 0; i < lines.Length; i++)
            {
                string[] cells = lines[i].Split('|');
                for (int j = 0; j < cells.Length; j++)
                {
                    if (!resizeField)
                    {
                        passField = new int[cells.Length, lines.Length];
                        resizeField = true;
                    }
                    int value = Int32.Parse(cells[j]);
                    passField[j, i] = value;
                }
            }
        }

        public List<BBox> GetBounds()
        {
            List<BBox> items = new List<BBox>();
            for (int i = 0; i < passField.GetLength(1); i++)
            {
                for (int j = 0; j < passField.GetLength(0); j++)
                {
                    if (passField[j, i] != 0)
                    {
                        int di = field.GetLength(1) - i - 1;
                        float x = j * H;
                        float y = di * H;
                        BBox box = new BBox(x, y, H, H, ObjectType.Level, 0);
                        items.Add(box);
                    }
                }
            }
            return items;
        }

        public void RedrawFront(SpriteBatch batch)
        {
            for (int i = 0; i < field.GetLength(1); i++)
            {
                for (int j = 0; j < field.GetLength(0); j++)
                {
                    if (frontField[j, i].X != -1 && frontField[j, i].Y != -1 && texture != null)
                    {
                        int di = field.GetLength(1) - i - 1;
                        int x = (int)(j * H + Camera.offsetX);
                        int y = (int)(MainGame.Height - di * H - H + Camera.offsetY);
                        if (x + H < 0 || x > MainGame.Width || y + H < 0 || y > MainGame.Height) continue;
                        Rectangle destRect = new Rectangle(x, y, H, H);
                        Rectangle srcRect = new Rectangle(frontField[j, i].X * H, frontField[j, i].Y * H, H, H);
                        batch.Draw(texture, destRect, srcRect, Color.White);
                        if (Keyboard.showBorder && passField[j, i] > 0)
                        {
                                DrawRectangle(destRect, Color.Yellow, batch);
                        }
                    }
                }
            }
        }

        public void Redraw(SpriteBatch batch)
        {
            if (bgImage != null)
            {
                for (int i = (int)offsetX; i < MainGame.LevelWidth; i += bgImage.Width)
                {
                    int height = MainGame.Height;
                    Rectangle destRect = new Rectangle(i + (int)Camera.offsetX, 
                        (int)(height - bgImage.Height + Camera.offsetY), bgImage.Width, bgImage.Height);
                    batch.Draw(bgImage, destRect, Color.White);
                }
            }
            for (int i = 0; i < field.GetLength(1); i++)
            {
                for (int j = 0; j < field.GetLength(0); j++)
                {
                    if (field[j, i].X != -1 && field[j, i].Y != -1 && texture != null)
                    {
                        int di = field.GetLength(1) - i - 1;
                        int x = (int)(j * H + Camera.offsetX);
                        int y = (int)(MainGame.Height - di * H - H + Camera.offsetY);
                        if (x + H < 0 || x > MainGame.Width || y + H < 0 || y > MainGame.Height) continue;
                        Rectangle destRect = new Rectangle(x, y, H, H);
                        Rectangle srcRect = new Rectangle(field[j, i].X * H, field[j, i].Y * H, H, H);
                        batch.Draw(texture, destRect, srcRect, Color.White);
                        if (Keyboard.showBorder && passField[j, i] > 0)
                        {
                            DrawRectangle(destRect, Color.Yellow, batch);
                        }
                    }
                }
            }
        }

        private Texture2D rectT = new Texture2D(MainGame.Device, 1, 1);

        private void DrawRectangle(Rectangle coords, Color color, SpriteBatch batch)
        {
            batch.Draw(rectT, coords, color);
        }

    }
}
