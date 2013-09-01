using System;
using System.Collections.Generic;

namespace Game.GameEngine.HelpClasses
{
    public enum ObjectType { Person, Bullet, Level };

    public struct BoundingBox
    {
        //Позиция и размер блока
        public float X;
        public float Y;
        public float Width;
        public float Height;
        public ObjectType type;
        public int id;

        //Конструктор с параметрами
        public BoundingBox(float x, float y, float width, float height, ObjectType type, int id)
        {
            this.X = x;
            this.Y = y;
            this.Width = width;
            this.Height = height;
            this.type = type;
            this.id = id;
        }

        //Метод определения столкновений
        public bool Intersects(BoundingBox box)
        {
            bool res = false;
            if (X + Width > box.X && X < box.X + box.Width)
            {
                if (Y + Height > box.Y && Y < box.Y + box.Height)
                {
                    res = true;
                }
            }
            return res;
        }
    }
}
