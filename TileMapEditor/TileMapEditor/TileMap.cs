using System;
using System.Drawing;
using Microsoft.Xna.Framework.Graphics;
using System.IO;
using System.Drawing.Imaging;
using Bitmap = System.Drawing.Bitmap;
using Color = Microsoft.Xna.Framework.Color;
using Graphics = System.Drawing.Graphics;
using Pen = System.Drawing.Pen;
using Size = System.Drawing.Size;
using GDIColor = System.Drawing.Color;
using Point = Microsoft.Xna.Framework.Point;
using Rectangle = Microsoft.Xna.Framework.Rectangle;

namespace TileMapEditor
{
    public class TileMap
    {
        private readonly GraphicsDevice _device;
        private readonly XNACanvas _canvas;

        private const int H = 32;

        private Texture2D _texture;
        private Texture2D _bgImage;
        private Texture2D _layer2;
        private Texture2D _grid;
        private Texture2D _ltGrid;
        private Texture2D _dGrid;
        private Texture2D _tGrid;
        private Texture2D _pass0;
        private Texture2D _pass1;

        private Bitmap _tileset;

        private Point _activeTile1 = new Point(0, 0);
        private Point _activeTile2 = new Point(0, 0);

        private bool _showGrid = true;
        private int _tag;

        private int _layer = 1;

        private Point[,] _backField;
        private Point[,] _frontField;
        private int[,] _passField;

        public TileMap(XNACanvas canvas)
        {
            _canvas = canvas;
            _device = canvas.Device;
            canvas.OnDraw += canvas_OnDraw;
            InitializeMethod();
        }

        private void InitializeMethod()
        {
            _tag = 0;
            _backField = new Point[5, 5];
            _frontField = new Point[5, 5];
            _passField = new int[5, 5];
            for (var i = 0; i < _backField.GetLength(1); i++)
            {
                for (var j = 0; j < _backField.GetLength(0); j++)
                {
                    _backField[j, i] = new Point(-1, -1);
                    _frontField[j, i] = new Point(-1, -1);
                    _passField[j, i] = 0;
                }
            }
            LoadTextures();
        }

        private void LoadTextures()
        {
            var stream = new MemoryStream();
            Properties.Resources.grid.Save(stream, ImageFormat.Png);
            _grid = Texture2D.FromStream(_device, stream);
            stream.Dispose();

            stream = new MemoryStream();
            Properties.Resources.lt_grid.Save(stream, ImageFormat.Png);
            _ltGrid = Texture2D.FromStream(_device, stream);
            stream.Dispose();

            stream = new MemoryStream();
            Properties.Resources.t_grid.Save(stream, ImageFormat.Png);
            _tGrid = Texture2D.FromStream(_device, stream);
            stream.Dispose();

            stream = new MemoryStream();
            Properties.Resources.d_grid.Save(stream, ImageFormat.Png);
            _dGrid = Texture2D.FromStream(_device, stream);
            stream.Dispose();

            stream = new MemoryStream();
            Properties.Resources._0.Save(stream, ImageFormat.Png);
            _pass0 = Texture2D.FromStream(_device, stream);
            stream.Dispose();

            stream = new MemoryStream();
            Properties.Resources._1.Save(stream, ImageFormat.Png);
            _pass1 = Texture2D.FromStream(_device, stream);
            stream.Dispose();

            stream = new MemoryStream();
            Properties.Resources.layer.Save(stream, ImageFormat.Png);
            _layer2 = Texture2D.FromStream(_device, stream);
            stream.Dispose();
        }

        public void SetLayer(int layer)
        {
            _layer = layer;
        }

        public void LoadFromFile(string fileName)
        {
            int tileOffset;
            int tileLenght;
            int bgOffset;
            int bgLenght;
            using (var fs = new FileStream(fileName, FileMode.Open))
            {
                using (var sr = new StreamReader(fs))
                {
                    string file = sr.ReadToEnd();
                    int pos = file.IndexOf("____|____", StringComparison.Ordinal);
                    string mapField = file.Substring(0, pos);
                    ParseMapField(mapField);
                    int start = pos + "____|____".Length;
                    pos = file.IndexOf("____|____", start, StringComparison.Ordinal);
                    string frontField = file.Substring(start, pos - start);
                    ParseFrontField(frontField);
                    start = pos + "____|____".Length;
                    pos = file.IndexOf("____|____", start, StringComparison.Ordinal);
                    string passabilityField = file.Substring(start, pos - start);
                    ParsePassField(passabilityField);

                    _canvas.Width = _backField.GetLength(0) * H;
                    _canvas.Height = _backField.GetLength(1) * H;

                    start = pos + "____|____".Length;
                    pos = file.IndexOf("____|____", start, StringComparison.Ordinal);
                    start = pos + "____|____".Length;
                    pos = file.IndexOf("|", start, StringComparison.Ordinal);
                    string offset = file.Substring(start, pos - start);
                    tileOffset = Int32.Parse(offset);
                    start = pos + "|".Length;
                    pos = file.IndexOf("|", start, StringComparison.Ordinal);
                    string lenght = file.Substring(start, pos - start);
                    tileLenght = Int32.Parse(lenght);

                    pos = file.IndexOf("____|____", start, StringComparison.Ordinal);
                    start = pos + "____|____".Length;
                    pos = file.IndexOf("|", start, StringComparison.Ordinal);
                    offset = file.Substring(start, pos - start);
                    bgOffset = Int32.Parse(offset);
                    start = pos + "|".Length;
                    pos = file.IndexOf("|", start, StringComparison.Ordinal);
                    lenght = file.Substring(start, pos - start);
                    bgLenght = Int32.Parse(lenght);
                }
            }
            using (var fs = new FileStream(fileName, FileMode.Open))
            {
                using (var br = new BinaryReader(fs))
                {
                    br.BaseStream.Seek(tileOffset, SeekOrigin.Begin);
                    byte[] data = br.ReadBytes(tileLenght);
                    ParseTexture(data);
                    br.BaseStream.Seek(bgOffset, SeekOrigin.Begin);
                    byte[] bgData = br.ReadBytes(bgLenght);
                    ParseBgImage(bgData);
                }
            }
        }

        private void ParseTexture(byte[] array)
        {
            var ms = new MemoryStream(array);
            _texture = Texture2D.FromStream(_device, ms);
            ms.Seek(0, SeekOrigin.Begin);
            _tileset = (Bitmap)Image.FromStream(ms);
            ms.Dispose();
        }

        private void ParseBgImage(byte[] array)
        {
            var ms = new MemoryStream(array);
            _bgImage = Texture2D.FromStream(_device, ms);
            ms.Dispose();
        }

        private void ParseMapField(string data)
        {
            var resizeField = false;
            var lines = data.Split('\n');
            for (var i = 0; i < lines.Length; i++)
            {
                var cells = lines[i].Split('|');
                for (var j = 0; j < cells.Length; j++)
                {
                    if (!resizeField)
                    {
                        _backField = new Point[cells.Length, lines.Length];
                        resizeField = true;
                    }
                    var point = cells[j].Split(';');
                    var x = Int32.Parse(point[0]);
                    var y = Int32.Parse(point[1]);
                    _backField[j, i] = new Point(x, y);
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
                        _frontField = new Point[cells.Length, lines.Length];
                        resizeField = true;
                    }
                    string[] point = cells[j].Split(';');
                    int x = Int32.Parse(point[0]);
                    int y = Int32.Parse(point[1]);
                    _frontField[j, i] = new Point(x, y);
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
                        _passField = new int[cells.Length, lines.Length];
                        resizeField = true;
                    }
                    int value = Int32.Parse(cells[j]);
                    _passField[j, i] = value;
                }
            }
        }

        public void SaveToFile(string fileName)
        {
            Point[,] field = _backField;
            using (FileStream fs = File.Create(fileName))
            {
                using (var bw = new StreamWriter(fs))
                {
                    for (int i = 0; i < field.GetLength(1); i++)
                    {
                        string res = "";
                        for (int j = 0; j < field.GetLength(0); j++)
                        {
                            res += field[j, i].X + ";" + field[j, i].Y;
                            if (j != field.GetLength(0) - 1) res += "|";
                        }
                        if (i != _passField.GetLength(1) - 1) res += "\n";
                        bw.Write(res);
                    }
                    bw.Write("____|____");
                    for (int i = 0; i < _frontField.GetLength(1); i++)
                    {
                        string res = "";
                        for (int j = 0; j < _frontField.GetLength(0); j++)
                        {
                            res += _frontField[j, i].X + ";" + _frontField[j, i].Y;
                            if (j != _frontField.GetLength(0) - 1) res += "|";
                        }
                        if (i != _frontField.GetLength(1) - 1) res += "\n";
                        bw.Write(res);
                    }
                    bw.Write("____|____");
                    for (int i = 0; i < _passField.GetLength(1); i++)
                    {
                        string res = "";
                        for (int j = 0; j < _passField.GetLength(0); j++)
                        {
                            res += _passField[j, i];
                            if (j != field.GetLength(0) - 1) res += "|";
                        }
                        if (i != _passField.GetLength(1) - 1) res += "\n";
                        bw.Write(res);
                    }
                    bw.Write("____|____");
                }
            }
            int offset;
            int lenght;
            using (var fs = new FileStream(fileName, FileMode.Append))
            {
                offset = (int)fs.Position;
                _texture.SaveAsPng(fs, _texture.Width, _texture.Height);
                lenght = (int)fs.Position - offset;
            }
            using (var fs = new FileStream(fileName, FileMode.Append))
            {
                using (var sw = new StreamWriter(fs))
                {
                    sw.Write("____|____" + offset + "|" + lenght + "|");
                }
            }
            using (var fs = new FileStream(fileName, FileMode.Append))
            {
                offset = (int)fs.Position;
                _bgImage.SaveAsPng(fs, _bgImage.Width, _bgImage.Height);
                lenght = (int)fs.Position - offset;
            }
            using (var fs = new FileStream(fileName, FileMode.Append))
            {
                using (var sw = new StreamWriter(fs))
                {
                    sw.Write("____|____" + offset + "|" + lenght + "|");
                }
            }
        }

        public void Initialize(string fileName)
        {
            var fs = new FileStream(fileName, FileMode.Open);
            _texture = Texture2D.FromStream(_device, fs);
            fs.Dispose();
            _tileset = (Bitmap)Image.FromFile(fileName);
        }

        public void LoadBgImage(string fileName)
        {
            var fs = new FileStream(fileName, FileMode.Open);
            _bgImage = Texture2D.FromStream(_device, fs);
            fs.Dispose();
        }

        public void Clear()
        {
            for (int i = 0; i < _backField.GetLength(1); i++)
            {
                for (int j = 0; j < _backField.GetLength(0); j++)
                {
                    _backField[j, i] = new Point(-1, -1);
                    _frontField[j, i] = new Point(-1, -1);
                    _passField[j, i] = 0;
                }
            }
        }

        public void SetShowGrid(bool showGrid)
        {
            _showGrid = showGrid;
        }

        public Size GetSize()
        {
            return new Size(_backField.GetLength(0), _backField.GetLength(1));
        }

        public void Resize(int width, int height)
        {
            var tmp = new Point[width, height];
            var frontTmp = new Point[width, height];
            var passTmp = new int[width, height];
            for (int i = 0; i < tmp.GetLength(0); i++)
            {
                for (int j = 0; j < tmp.GetLength(1); j++)
                {
                    if (i < _backField.GetLength(0) && j < _backField.GetLength(1))
                    {
                        tmp[i, tmp.GetLength(1) - j -1] = _backField[i, _backField.GetLength(1) - j - 1];
                        frontTmp[i, tmp.GetLength(1) - j - 1] = _frontField[i, _backField.GetLength(1) - j - 1];
                        passTmp[i, tmp.GetLength(1) - j - 1] = _passField[i, _backField.GetLength(1) - j - 1];
                    }
                    else
                    {
                        tmp[i, tmp.GetLength(1) - j - 1] = new Point(-1, -1);
                        frontTmp[i, tmp.GetLength(1) - j - 1] = new Point(-1, -1);
                        passTmp[i, tmp.GetLength(1) - j - 1] = 0;
                    }
                }
            }
            _backField = tmp;
            _frontField = frontTmp;
            _passField = passTmp;
            _canvas.Width = width * H;
            _canvas.Height = height * H;
        }

        public void FillArea(int x, int y)
        {
            if (_tag == 1) return;
            Point[,] field = _backField;
            if (_layer == 2) field = _frontField;
            Point current = field[x, y];
            Point tmp = _activeTile2;
            _activeTile2 = _activeTile1;
            Fill(x, y, current);
            _activeTile2 = tmp;
        }

        private bool NeedToFill(int x, int y, Point current)
        {
            bool result = false;
            Point[,] field = _backField;
            if (_layer == 2) field = _frontField;
            if (x >= 0 && y >= 0 && x < field.GetLength(0) && y < field.GetLength(1))
            {
                if (field[x, y] == current) result = true;
            }
            return result;
        }

        private void Fill(int x, int y, Point p)
        {
            SetTile(x, y);
            if (NeedToFill(x - 1, y, p)) Fill(x - 1, y, p);
            if (NeedToFill(x + 1, y, p)) Fill(x + 1, y, p);
            if (NeedToFill(x, y - 1, p)) Fill(x, y - 1, p);
            if (NeedToFill(x, y + 1, p)) Fill(x, y + 1, p);
        }

        public void SetTilePoint1(int x, int y)
        {
            _activeTile1.X = x;
            _activeTile1.Y = y;
        }

        public void SetTilePoint2(int x, int y)
        {
            _activeTile2.X = x;
            _activeTile2.Y = y;
        }

        public void SetTile(int x, int y, int value = 0)
        {
            if (_tag == 1)
            {
                SetPassability(x, y, value);
                return;
            }
            Point[,] field = _backField;
            if (_layer == 2) field = _frontField;
            if (x < 0 || y < 0 ||
                x + (_activeTile2.X - _activeTile2.X) >= field.GetLength(0) ||
                y + (_activeTile2.Y - _activeTile2.Y) >= field.GetLength(1)) return;
            for (int i = _activeTile1.X; i <= _activeTile2.X; i++)
            {
                for (int j = _activeTile1.Y; j <= _activeTile2.Y; j++)
                {
                    int dx = _activeTile2.X - i;
                    int dy = _activeTile2.Y - j;
                    var p = new Point(_activeTile1.X + dx, _activeTile1.Y + dy);
                    try
                    {
                        field[x + dx, y + dy] = p;
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine(exception.Message);
                    }
                }
            }    
        }

        public Bitmap GetTilset()
        {
            if (_tileset == null) return null;
            using (var gr = Graphics.FromImage(_tileset))
            {
                for (int i = 0; i <= _tileset.Width; i += H)
                {
                    if (i == _tileset.Width) i--;
                    gr.DrawLine(new Pen(GDIColor.Silver), i, 0, i, _tileset.Height);
                }
                for (int i = 0; i <= _tileset.Height; i += H)
                {
                    if (i == _tileset.Height) i--;
                    gr.DrawLine(new Pen(GDIColor.Silver), 0, i, _tileset.Width, i);
                }
                int x = _activeTile1.X * H;
                int y = _activeTile1.Y * H;
                int w = (_activeTile2.X - _activeTile1.X + 1) * H;
                int h = (_activeTile2.Y - _activeTile1.Y + 1) * H;
                var pen = new Pen(GDIColor.Red);
                gr.DrawRectangle(pen, x, y, w, h);
            }
            return _tileset;
        }

        public void SetPassability(int x, int y, int value)
        {
            if (x < 0 || y < 0 || x >= _passField.GetLength(0) || y >= _passField.GetLength(1)) return;
            _passField[x, y] = value;
        }

        public void SetTag(int tag)
        {
            _tag = tag;
        }

        private void canvas_OnDraw(DrawEventArgs args)
        {
            SpriteBatch batch = args.spriteBatch;
            if (_bgImage != null)
            {
                for (int i = 0; i < _backField.GetLength(0) * H; i += _bgImage.Width)
                {
                    int height = _backField.GetLength(1) * H;
                    var destRect = new Rectangle(i, height - _bgImage.Height, 
                        _bgImage.Width, _bgImage.Height);
                    batch.Draw(_bgImage, destRect, Color.White);
                }
            }
            for (int i = 0; i < _backField.GetLength(1); i++)
            {
                for (int j = 0; j < _backField.GetLength(0); j++)
                {
                    if (_backField[j, i].X != -1 && _backField[j, i].Y != -1 && _texture != null)
                    {
                        var destRect = new Rectangle(j * H, i * H, H, H);
                        var srcRect = new Rectangle(_backField[j, i].X * H, _backField[j, i].Y * H,  H, H);
                        batch.Draw(_texture, destRect, srcRect, Color.White);
                    }                    
                }
            }

            for (int i = 0; i < _frontField.GetLength(1); i++)
            {
                for (int j = 0; j < _frontField.GetLength(0); j++)
                {
                    if (_layer == 2)
                    {
                        var destRect = new Rectangle(j * H, i * H, H, H);
                        var srcRect = new Rectangle(0, 0, H, H);
                        batch.Draw(_layer2, destRect, srcRect, Color.White);
                    }
                    if (_frontField[j, i].X != -1 && _frontField[j, i].Y != -1 && _texture != null)
                    {
                        var destRect = new Rectangle(j * H, i * H, H, H);
                        var srcRect = new Rectangle(_frontField[j, i].X * H, _frontField[j, i].Y * H, H, H);
                        batch.Draw(_texture, destRect, srcRect, Color.White);
                    }
                    if (args.Tag == 1)
                    {
                        var destRect = new Rectangle(j * H, i * H, H, H);
                        var srcRect = new Rectangle(0, 0, H, H);
                        if (_passField[j, i] == 0)
                            batch.Draw(_pass0, destRect, srcRect, Color.White);
                        if (_passField[j, i] == 1)
                            batch.Draw(_pass1, destRect, srcRect, Color.White);
                    }

                }
            }

            for (int i = 0; i < _backField.GetLength(1); i++)
            {
                for (int j = 0; j < _backField.GetLength(0); j++)
                {
                    if (_showGrid)
                    {
                        var destRect = new Rectangle(j * H, i * H, H, H);
                        var srcRect = new Rectangle(0, 0, H, H);
                        if (i == 0 && j == 0) 
                            batch.Draw(_ltGrid, destRect, srcRect, Color.White);
                        else if (i == 0)
                            batch.Draw(_tGrid, destRect, srcRect, Color.White);
                        else if (j == 0)
                            batch.Draw(_dGrid, destRect, srcRect, Color.White);
                        else
                            batch.Draw(_grid, destRect, srcRect, Color.White);
                    }
                }
            }
        }

    }
}
