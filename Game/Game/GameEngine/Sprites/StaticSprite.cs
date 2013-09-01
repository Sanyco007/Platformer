using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Game.GameEngine.HelpClasses;
using BBox = Game.GameEngine.HelpClasses.BoundingBox;

namespace Game.GameEngine.Sprites
{
    //Статический спрайт
    public class StaticSprite : IGraphicItem
    {
        //Позиция спрайта
        private Vector2 pos = new Vector2(0, 0);

        //Текстура спрайта
        private Texture2D texture = null;
        
        //Конструктор класса
        public StaticSprite(Texture2D texture, Vector2 pos)
        {
            this.texture = texture;
            this.pos = pos;
        }

        //Обновление состояния
        public int Update(long delta, List<BBox> items)
        {
            return 0;
        }

        //Рисование спрайта (flip - отражение по горизонтали)
        public void Redraw(SpriteBatch batch, bool flip = false)
        {
            if (texture == null) return;
            //Расчет координат для рисования
            float x = pos.X + Camera.offsetX;
            float y = MainGame.Height - pos.Y + Camera.offsetY - texture.Height;
            //Рисование спрайта в нужной позиции
            Vector2 position = new Vector2(x, y);
            batch.Draw(texture, position, Color.White);
        }

        //Возврат границы текстуры
        public BBox GetBounds()
        {
            BBox box = new BBox(pos.X, pos.Y, texture.Width, texture.Height, ObjectType.Level, 0);
            return box;
        }

        //Скорость движения объекта
        public float GetSpeed()
        {
            return 0f;
        }
    }
}
