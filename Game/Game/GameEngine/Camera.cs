using System;
using System.Collections.Generic;
using Game.GameEngine.Sprites;
using Game.GameEngine.HelpClasses;
using Game.GameEngine.Persons;

namespace Game.GameEngine
{
    //Камера для слежения за игроком
    public class Camera
    {
        //Сдвиг игрового мира для установки в точку слежения
        public static float offsetX = 0f;
        public static float offsetY = 0f;

        private static float RADIUS = 5;
        private static IGraphicItem player;

        //Установка обьекта для наблюдения
        public static void SetPerson(IGraphicItem viewPlayer)
        {
            player = viewPlayer;
        }

        //Обновление позиции камеры
        public static void Update()
        {
            if (player == null) return;
            BoundingBox bounds = player.GetBounds();
            //Обзор камеры
            bounds.X -= RADIUS * 20;
            bounds.Y -= RADIUS * 20;
            bounds.Width += 2 * RADIUS * 20;
            bounds.Height += 2 * RADIUS * 20;
            //Перемещение при выходе обьекта за границы экрана
            if (bounds.X + bounds.Width + offsetX >= MainGame.Width)
            {
                offsetX = -(bounds.X + bounds.Width - MainGame.Width);
                if (offsetX <= -(MainGame.LevelWidth - MainGame.Width))
                {
                    offsetX = -(MainGame.LevelWidth - MainGame.Width);
                }

            }
            if (bounds.Y + bounds.Height - offsetY >= MainGame.Height)
            {
                offsetY = bounds.Y + bounds.Height - MainGame.Height;
                if (offsetY >= MainGame.LevelHeight - MainGame.Height)
                {
                    offsetY = MainGame.LevelHeight - MainGame.Height;
                }
            }
            if (bounds.X + offsetX <= 0)
            {
                offsetX += player.GetSpeed();
                if (offsetX > 0) offsetX = 0;
            }
            if (bounds.Y - offsetY <= 0)
            {
                offsetY -= (player as Player).GetVSpeed();
                if (offsetY < 0) offsetY = 0;
            }
        }
    }
}
