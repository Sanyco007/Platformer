using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Game.GameEngine.HelpClasses;
using BBox = Game.GameEngine.HelpClasses.BoundingBox;

namespace Game.GameEngine.Sprites
{
    //Анимационный спрайт
    public class AnimatedSprite : IGraphicItem
    {
        //Позиция спрайта
        protected Vector2 pos = new Vector2(0, 0);

        //Текстура спрайта
        protected Texture2D texture;

        //Текущий кадр анимации
        protected Rectangle rect;

        //Время показа кадров
        protected long[] speed;

        //Прошедшее время
        protected long ellapsedTime = 0L;

        //Количество кадров и текущий кадр
        protected int count, currentFrame = 0;

        //Ширины кадров
        protected int[] widths;

        //Минимальная ширина кадра
        private int minWidth = 0;

        //Текстура точки
        Texture2D fill_rect = new Texture2D(MainGame.Device, 1, 1);

        //Конструктор класса
        public AnimatedSprite(Texture2D texture, int count, long[] speed, int[] widths = null) 
        {
            fill_rect.SetData(new Color[] { Color.White } );
            this.texture = texture;
            //Расчет ширины всех кадров
            if (widths == null)
            {
                widths = new int[count];
                for (int i = 0; i < count; i++)
                {
                    widths[i] = texture.Width / count;
                }
            }
            this.widths = widths;
            //Выбираем текущий кадр
            this.rect = new Rectangle(0, 0, widths[0], texture.Height);
            //Расчет скоростей изменения кадров
            if (speed.Length < count)
            {
                int start = speed.Length;
                Array.Resize<long>(ref speed, count);
                for (int i = start; i < count; i++)
                {
                    speed[i] = speed[0];
                }
            }
            this.speed = speed;
            //Кадр с минимальной шириной
            minWidth = widths[0];
            for (int i = 0; i < widths.Length; i++)
            {
                if (widths[i] < minWidth) minWidth = widths[0];
            }
            //Количество кадров
            this.count = count;
        }

        //Установка позиции спрайта
        public void SetPosition(float x, float y)
        {
            pos.X = x;
            pos.Y = y;
        }

        //Обновление состояния спрайта
        public int Update(long delta, List<BBox> items)
        {
            ellapsedTime += delta;
            //Необходима смена кадра
            if (ellapsedTime >= speed[currentFrame])
            {
                //Выравнивание времени
                while (ellapsedTime >= speed[currentFrame])
                {
                    ellapsedTime -= speed[currentFrame];
                }
                //Изменение кадра
                currentFrame++;
                if (currentFrame >= count) currentFrame = 0;
                //Расчет координат нового кадра
                int offset = 0;
                for (int i = 0; i < currentFrame; i++)
                {
                    offset += widths[i];
                }
                rect = new Rectangle(offset, 0, widths[currentFrame], texture.Height);
            }
            return rect.Width;
        }

        //Перерисовка графики
        public void Redraw(SpriteBatch batch, bool flip = false) 
        {
            //Расчет позиции для рисования спрайта
            float x = pos.X + Camera.offsetX;
            float y = MainGame.Height - pos.Y + Camera.offsetY - texture.Height;
            Vector2 position = new Vector2(x, y);
            //Рисование границы спрайта при необходимости
            if (Keyboard.showBorder)
            {
                Rectangle brect = new Rectangle((int)position.X, (int)position.Y, minWidth, rect.Height);
                DrawRectangle(brect, Color.Green, batch);
            }
            //Рисование графики спрайта
            else
            {
                //Рисование с учетом отражения по горизонтали
                if (!flip)
                {
                    batch.Draw(texture, position, rect, Color.White);
                }
                else
                {
                    batch.Draw(texture, position, rect, Color.White,
                        0, new Vector2(0, 0), 1, SpriteEffects.FlipHorizontally, 0);
                }
            }
        }

        //Рисование закрашенного прямоугольника
        private void DrawRectangle(Rectangle coords, Color color, SpriteBatch batch)
        {
            batch.Draw(fill_rect, coords, color);
        }

        //Возврат границы спрайта
        public BBox GetBounds() 
        {
            BBox bnd = new BBox(pos.X, pos.Y, minWidth, rect.Height, ObjectType.Person, 0);
            return bnd;
        }

        //Скорость движения спрайта
        public float GetSpeed()
        {
            return 0f;
        }
    }
}
