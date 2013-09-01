using System;
using System.Windows.Forms;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Game.Properties;
using Game.GameEngine.Sprites;
using Game.GameEngine.GameStates;
using Game.GameEngine.HelpClasses;
using BBox = Game.GameEngine.HelpClasses.BoundingBox;

namespace Game.GameEngine.Persons
{
    //Перечисление состояний персонажа
    [Flags] 
    public enum State { Stand = 1, Walk = 2, Attack = 4, Jump = 8 };
    //Перечисление направления движения персонажа
    [Flags]
    public enum Ways { Left = 1, Right = 2, Jump = 4, Attack = 8, None = 16};

    //Перемещаемый персонаж
    public class MovedPerson : IGraphicItem
    {
        //Счетчик для задания идентификаторов
        private static int id_counter = 0;

        //Количество жизней
        protected int HP = 100;

        //Состояние игрока
        private State state = State.Stand;

        //Предыдущее состояние игрока
        private State prevState = State.Stand;

        //Направление движения игрока
        private Ways ways = Ways.None;

        //Анимация при простое
        private AnimatedSprite standSprite;

        //Анимация бега
        private AnimatedSprite walkSprite;

        //Анимация прижка
        private AnimatedSprite jumpSprite;

        //Анимация атаки
        private AnimatedSprite attackSprite;

        //Анимация текущего состояния
        private AnimatedSprite currentSprite;

        //Позиция игрока
        protected Vector2 position = new Vector2(0, 32 * 2);

        //Скорость перемещения
        protected float SPEED = 4f;

        //Поворот спрайта влево
        protected bool flip = false;

        //Ширина предыдущего спрайта
        private int prevWidth = 0;
        
        //Гравитация
        private const float GRAVITY = 0.5f;

        //Начальная скорость прижка
        private const float VSPEED = 12f;

        //Текущая скорость прижка (лимитируется)
        private float V = 0;

        //Текущая скорость прижка (не лимитируется)
        private float VHPDown = 0;

        //Идентификатор объекта
        public int ID;

        //Состояние смерти объекта
        private bool death = false;

        //Конструктор класса
        public MovedPerson(Vector2 position)
        {
            ID = ++id_counter;
            this.position = position;
        }

        //Выстрел по объекту с возвратом состояния жизни
        public bool Shoot()
        {
            HP -= 25;
            if (HP <= 0) death = true;
            return death;
        }

        //Инициализация графики
        public void Initialize(AnimatedSprite standSprite, AnimatedSprite walkSprite, 
            AnimatedSprite jumpSprite, AnimatedSprite attackSprite)
        {
            this.standSprite = standSprite;
            this.walkSprite = walkSprite;
            this.jumpSprite = jumpSprite;
            this.attackSprite = attackSprite;
            currentSprite = this.standSprite;
        }

        //Установка состояния движения
        public void SetWays(Ways ways)
        {
            this.ways = ways;
        }
    
        //Обновление состояния персонажа
        public virtual int Update(long delta, List<BBox> items) 
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].id == ID)
                {
                    items.Remove(items[i]);
                }
            }
            //Состояние игрока
            if (state != State.Jump)
            {
                if ((ways & Ways.Jump) == Ways.Jump)
                {
                    if (state != State.Jump)
                    {
                        V = VSPEED;
                        VHPDown = SPEED;
                    }
                    state = State.Jump;
                }
                else if ((ways & Ways.Attack) == Ways.Attack)
                {
                    state = State.Attack;
                }
                else if ((ways & Ways.Left) == Ways.Left || (ways & Ways.Right) == Ways.Right)
                {
                    state = State.Walk;
                }
                else state = State.Stand;
            }
            //Необходимость притянуть игрока к земле
            if (IsFlyUp(items) && state != State.Jump)
            {
                state = State.Jump;
                V = 0;
                VHPDown = 0;
            }
            //Перемещение игрока
            if (state != State.Attack)
            {
                //Прыжок
                if (state == State.Jump)
                {
                    position.Y += V;
                    V -= GRAVITY;
                    VHPDown -= GRAVITY;
                    if (V < -10) V = -10;
                    //Удар головою - начинаем падать
                    if (IsCollideUp(items))
                    {
                        while (IsCollideUp(items))
                        {
                            position.Y -= 0.1f;
                        }
                        V = 0;
                    }
                    //Приземление на поверхность
                    if (IsCollideDown(items))
                    {
                        while (IsCollideDown(items))
                        {
                            position.Y += 0.1f;
                        }
                        state = State.Stand;
                        //Отнимание жизней при падении
                        if (VHPDown < -70)
                        {
                            int count = (int)(Math.Abs(VHPDown) - 70) / 12;
                            for (int i = 0; i < count; i++)
                            {
                                HP -= i;
                            }
                            if (HP <= 0) death = true;
                        }
                    }
                }
                //Движение вправо
                if ((ways & Ways.Right) == Ways.Right)
                {
                    position.X += SPEED;
                    while (IsCollide(items))
                    {
                        position.X -= 0.1f;
                    }
                }
                //Движение влево
                if ((ways & Ways.Left) == Ways.Left)
                {
                    position.X -= SPEED;
                    while (IsCollide(items))
                    {
                        position.X += 0.1f;
                    }
                }
            }
            //Отражение изображения
            if ((ways & Ways.Left) == Ways.Left)
            {
                flip = true;
            }
            else if ((ways & Ways.Right) == Ways.Right)
            {
                flip = false;
            }
            //Изменение текущего спрайта
            if (state == State.Stand)
            {
                currentSprite = standSprite;
            }
            else if (state == State.Walk)
            {
                currentSprite = walkSprite;
            }
            else if (state == State.Jump)
            {
                currentSprite = jumpSprite;
            }
            else if (state == State.Attack)
            {
                currentSprite = attackSprite;
            }
            //Обновление кадров
            int width = 0;
            width = currentSprite.Update(delta, items);
            if (flip && (state == State.Attack || prevState == State.Attack))
                position.X += prevWidth - width;
            prevWidth = width;
            prevState = state;
            return 0;
        }

        //Столкновени верхней грани с обьектами
        private bool IsCollideUp(List<BBox> items)
        {
            bool res = false;
            BBox self = GetBounds();
            self.Y += self.Height;
            self.Height = 1;
            for (int i = 0; i < items.Count; i++)
            {
                if (self.Intersects(items[i]))
                {
                    res = true;
                    break;
                }
            }
            return res;
        }

        //Столкновения нижней грани с обьектами
        private bool IsCollideDown(List<BBox> items)
        {
            bool res = false;
            BBox self = GetBounds();
            self.Height = 1;
            for (int i = 0; i < items.Count; i++)
            {
                if (self.Intersects(items[i]))
                {
                    res = true;
                    break;
                }
            }
            if (position.Y < 0) res = true;
            return res;
        }

        //Воздействие силы тяжести
        private bool IsFlyUp(List<BBox> items)
        {
            bool res = false;
            BBox self = GetBounds();
            self.Height = 1;
            self.Y -= 1;
            for (int i = 0; i < items.Count; i++)
            {
                if (self.Intersects(items[i]))
                {
                    res = true;
                    break;
                }
            }
            if (self.Y < 0) res = true;
            return !res;
        }
    
        //Общие столкновения
        private bool IsCollide(List<BBox> items) 
        {
            bool res = false;
            BBox self = GetBounds();
            for (int i = 0; i < items.Count; i++)
            {
                if (self.Intersects(items[i]))
                {
                    res = true;
                    break;
                }
            }
            if (position.X + GetBounds().Width >= MainGame.LevelWidth) res = true;
            if (position.X < 0 || position.Y < 0) res = true;
            return res;
        }

        //Перерисовка спрайта
        public virtual void Redraw(SpriteBatch batch, bool value = false)
        {
            currentSprite.SetPosition(position.X, position.Y);
            currentSprite.Redraw(batch, flip);
        }

        //Область столкновения
        public BBox GetBounds()
        {
            float x = position.X;
            float y = position.Y;
            float width = (state == State.Attack) 
                ? currentSprite.GetBounds().Width : standSprite.GetBounds().Width;
            float height = currentSprite.GetBounds().Height;
            return new BBox(x, y, width, height, ObjectType.Person, ID);
        }

        //Скорость прижка (падения)
        public float GetVSpeed()
        {
            return Math.Abs(V);
        }

        //Состояние смерти игрока
        public bool IsDeath()
        {
            return death;
        }

        //Скорость движения
        public float GetSpeed()
        {
            return SPEED;
        }

        //Количество жизней
        public int GetHP()
        {
            return HP;
        }
    }
}
