using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Game.GameEngine.HelpClasses;
using Game.GameEngine.Persons;

namespace Game.GameEngine.GameStates
{
    //Игровое состояние - "уровень"
    public class LevelState : IGameState
    {
        //Карта
        private readonly TileMap _tileMap;

        //Конструктор класса
        public LevelState()
        {
            //Загрузка карты с файла
            _tileMap = new TileMap("maps//map1.tls");
            //Добавдение персонажей в карту
            Memory.Persons.Add(new Player(new Vector2(0, 32 * 2)));
            //Memory.Persons.Add(new Chuck(new Vector2(32 * 9, 32 * 30)));
            //Установка камеры на игрока
            Camera.SetPerson(Memory.Persons[0]);
        }

        //Обновление состояния уровня
        public void Update(long delta)
        {
            //Удаление исчезнувших пуль
            for (int i = 0; i < Memory.Bullets.Count; i++)
            {
                if (Memory.Bullets[i].Death)
                {
                    Memory.Bullets.Remove(Memory.Bullets[i]);
                    i--;
                }
            }
            //Границы объектов карты
            var items = _tileMap.GetBounds();
            items.AddRange(Memory.Persons.Select(item => item.GetBounds()));
            //Добавление границ для персонажей
            //Обновление состояния персонажей
            foreach (var item in Memory.Persons)
            {
                item.Update(delta, items);
            }
            //Обновления карты
            _tileMap.Update((int)delta);
            //Обновление состояния пуль
            foreach (var item in Memory.Bullets)
            {
                item.Update(items);
            }
            //Обновление состояния памяти
            Memory.Update();
        }

        //Перерисовка уровня
        public void Redraw(SpriteBatch batch)
        {
            //Перерисовка заднего плана карты
            _tileMap.Redraw(batch);
            //Перерисовка персонажей
            foreach (var item in Memory.Persons)
            {
                item.Redraw(batch);
            }
            //Перерисовка пуль
            foreach (var item in Memory.Bullets)
            {
                item.Redraw(batch);
            }
            //Перерисовка переднего плана карты
            _tileMap.RedrawFront(batch);
            //Вывод количества жизней игрока
            var player = Memory.Persons[0] as Player;
            if (player != null)
            {
                var hp = (Texture2D)GraphicFont.hp[player.GetHP()];
                batch.Draw(hp, new Vector2(2, 2), Color.Black);
                batch.Draw(hp, new Vector2(0, 0), Color.White);
            }
        }
    }
}
