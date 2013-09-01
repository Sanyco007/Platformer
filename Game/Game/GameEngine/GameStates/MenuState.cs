using Microsoft.Xna.Framework.Graphics;
using Game.GameEngine.HelpClasses;
using Microsoft.Xna.Framework;
using System.Windows.Forms;

namespace Game.GameEngine.GameStates
{
    public class MenuState : IGameState
    {
        private readonly Texture2D _bg;
        private readonly Texture2D _moved;
        private readonly Texture2D _newGame;
        private readonly Texture2D _exit; 
        private readonly Vector2[,] _field = new Vector2[28, 18];
        private int _active = 1;

        private int _counter;
        private long _ellapsed;
        private const long FrameTime = 1000 / 50;

        public MenuState()
        {
            _ellapsed = 0;
            _counter = 0;
            _bg = GraphicsConvert.ToTexture2D(Properties.Resources.menu_bg);
            _moved = GraphicsConvert.ToTexture2D(Properties.Resources.menu_moved2);
            _newGame = GraphicsConvert.ToTexture2D(Properties.Resources.menu_new_game);
            _exit = GraphicsConvert.ToTexture2D(Properties.Resources.menu_exit);
            for (int i = 0; i < 28; i++)
            {
                for (int j = 0; j < 18; j++)
                {
                    _field[i, j] = new Vector2(i * 30 - 30, j * 30 - 30);
                }
            }
        }

        public void Update(long delta)
        {
            if (Keyboard.IsKeyDown(Keys.W))
            {
                //play click sound
                _active--;
                if (_active < 1) _active = 2;
                Keyboard.KeyUp(Keys.W);
            }
            if (Keyboard.IsKeyDown(Keys.S))
            {
                //play click sound
                _active++;
                if (_active > 2) _active = 1;
                Keyboard.KeyUp(Keys.S);
            }
            if (Keyboard.IsKeyDown(Keys.Enter))
            {
                //play push sound
                if (_active == 1)
                {
                    IGameState screen = new LevelState();
                    Program.Game.ChangeState(screen);
                }
                if (_active == 2)
                {
                    Application.Exit();
                }
            }
            _ellapsed += delta;
            if (_ellapsed >= FrameTime)
            {
                for (int i = 0; i < 28; i++)
                {
                    for (int j = 0; j < 18; j++)
                    {
                        if (_counter == 30)
                        {
                            _field[i, j].X += 30;
                            //field[i, j].Y -= 30;
                        }
                        _field[i, j].X -= 1;
                        //field[i, j].Y += 1f;
                    }
                }
                if (_counter == 30) _counter = 0;
                _counter++;
                _ellapsed = 0;
            }
        }

        public void Redraw(SpriteBatch batch)
        {
            for (int i = 0; i < 28; i++)
            {
                for (int j = 0; j < 18; j++)
                {
                    batch.Draw(_moved, _field[i, j], Color.White);
                }
            }
            batch.Draw(_bg, new Vector2(0, 0), Color.White);
            int x = (MainGame.Width - _newGame.Width) / 2;
            batch.Draw(_newGame, new Vector2(x, 240), (_active == 1) ? Color.Orange : Color.White);
            x = (MainGame.Width - _exit.Width) / 2;
            batch.Draw(_exit, new Vector2(x, 300), (_active == 2) ? Color.Orange : Color.White);
        }
    }
}
