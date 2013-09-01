using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Game.Properties;
using System.Drawing.Imaging;
using System.IO;
using Game.GameEngine.HelpClasses;
using BoundingBox = Game.GameEngine.HelpClasses.BoundingBox;

namespace Game.GameEngine.Bullets
{
    public class Bullet
    {
        private static int _idCounter = 0;

        private int _userId = 0;
        private readonly Texture2D _texture = null;
        private Vector2 _pos = new Vector2();
        private readonly float _speed = 6f;
        private readonly int _id;

        public bool Death = false;

        public Bullet(Vector2 pos, int way, int id)
        {
            rectT.SetData(new[] { Color.White } );
            _userId = id;
            _pos = pos;
            _id = ++_idCounter;
            _speed = _speed * way;
            var ms = new MemoryStream();
            Resources.bullet.Save(ms, ImageFormat.Png);
            _texture = Texture2D.FromStream(MainGame.Device, ms);
        }

        public void Redraw(SpriteBatch batch)
        {
            Vector2 p = new Vector2(_pos.X + Camera.offsetX, _pos.Y + Camera.offsetY);
            batch.Draw(_texture, p, Color.Yellow);
            if (Keyboard.showBorder)
            {
                Rectangle rect = new Rectangle((int)p.X, (int)p.Y, _texture.Width, _texture.Height);
                DrawRectangle(rect, Color.Blue, batch);
            }
        }

        public void Update(List<BoundingBox> items)
        {
            _pos.X += _speed;
            if (_pos.X < 0 || _pos.X > MainGame.LevelWidth)
            {
                Death = true;
            }
            if (IsCollide(items))
            {
                Death = true;
            }
        }

        //Общие столкновения
        private bool IsCollide(List<BoundingBox> items)
        {
            bool res = false;
            BoundingBox self = new BoundingBox(_pos.X, MainGame.Height - _pos.Y, _texture.Width - _texture.Height,
                _texture.Height, ObjectType.Bullet, _id);
            for (int i = 0; i < items.Count; i++)
            {
                if (self.Intersects(items[i]))
                {
                    if (items[i].type == ObjectType.Person)
                    {
                        Memory.PersonsId.Add(items[i].id);
                    }
                    res = true;
                    break;
                }
            }
            return res;
        }

        private Texture2D rectT = new Texture2D(MainGame.Device, 1, 1);

        private void DrawRectangle(Rectangle coords, Color color, SpriteBatch batch)
        {
            batch.Draw(rectT, coords, color);
        }
    }
}
