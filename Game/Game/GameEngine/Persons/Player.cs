using System.Windows.Forms;
using System.Collections.Generic;
using Game.GameEngine.Bullets;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Game.Properties;
using Game.GameEngine.Sprites;
using Game.GameEngine.HelpClasses;

namespace Game.GameEngine.Persons
{
    //Класс игрока
    public class Player : MovedPerson
    {
        //Текстура состояния спокойствия
        private readonly Texture2D _standTexture;

        //Анимация спокойствия
        private readonly AnimatedSprite _standSprite;

        //Текстура движения
        private readonly Texture2D _walkTexture;

        //Анимация движения
        private readonly AnimatedSprite _walkSprite;

        //Текстура прижка
        private readonly Texture2D _jumpTexture;

        //Анимация прижка
        private readonly AnimatedSprite _jumpSprite;

        //Текстура атаки
        private readonly Texture2D _attackTexture;

        //Анимация атаки
        private readonly AnimatedSprite _attackSprite;

        //Прошедшее время после последней атаки
        private long _ellapsedTime;
        
        //Задержка между выпусками пуль
        private const long AttackTime = 1000 / 4;

        //Возможность аттаковать
        private bool _canAttack = true;

        //Конструктор класса
        public Player(Vector2 position) :  base(position)
        {
            _ellapsedTime = 0;
            //Загрузка анимации простоя
            _standTexture = GraphicsConvert.ToTexture2D(Resources.cstand);
            _standSprite = new AnimatedSprite(_standTexture, 1, new long[] { 200 });
            //Загрузка анимации движения
            _walkTexture = GraphicsConvert.ToTexture2D(Resources.cwalk);
            _walkSprite = new AnimatedSprite(_walkTexture, 3, new long[] { 100 });
            //Загрузка анимации прижка
            _jumpTexture = GraphicsConvert.ToTexture2D(Resources.cjump);
            _jumpSprite = new AnimatedSprite(_jumpTexture, 4, new long[] { 50 });
            //Загрузка анимации атаки
            _attackTexture = GraphicsConvert.ToTexture2D(Resources.cstand);
            _attackSprite = new AnimatedSprite(_attackTexture, 1, new long[] { 200 });
            //Инициализация класса
            Initialize(_standSprite, _walkSprite, _jumpSprite, _attackSprite);
        }

        //Обновление состояния игрока
        public override int Update(long delta, List<HelpClasses.BoundingBox> items)
        {
            if (!_canAttack)
            {
                _ellapsedTime += delta;
                if (_ellapsedTime >= AttackTime)
                {
                    _canAttack = true;
                }
            }
            var ways = Ways.None;
            if (Keyboard.IsKeyDown(Keys.Space))
            {
                ways = ways | Ways.Jump;
            }
            if (Keyboard.IsKeyDown(Keys.Enter))
            {
                ways = ways | Ways.Attack;
                if (_canAttack)
                {
                    float x = position.X;
                    if (!flip) x += GetBounds().Width;
                    var p = new Vector2(x, MainGame.Height - position.Y - 30);
                    int way = (flip) ? -1 : 1;
                    var bullet = new Bullet(p, way, ID);
                    Memory.Bullets.Add(bullet);
                    _canAttack = false;
                    _ellapsedTime = 0;
                }
            }
            if (Keyboard.IsKeyDown(Keys.A))
            {
                ways = ways | Ways.Left;
            }
            if (Keyboard.IsKeyDown(Keys.D))
            {
                ways = ways | Ways.Right;
            }
            SetWays(ways);
            return base.Update(delta, items);
        }

    }
}
