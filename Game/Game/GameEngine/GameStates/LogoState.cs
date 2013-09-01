using Microsoft.Xna.Framework.Graphics;
using System.IO;
using System.Drawing.Imaging;
using Microsoft.Xna.Framework;
using Size = System.Drawing.Size;

namespace Game.GameEngine.GameStates
{
    public class LogoState : IGameState
    {
        private readonly Texture2D _logo;
        private readonly Vector2 _position;
        private float _opacity = 0.01f, _step = 0.01f;
        private bool _start;

        public LogoState()
        {
            _start = false;
            var ms = new MemoryStream();
            Properties.Resources.logo.Save(ms, ImageFormat.Png);
            _logo = Texture2D.FromStream(MainGame.Device, ms);
            ms.Dispose();
            var screen = new Size(MainGame.Width, MainGame.Height);
            _position = new Vector2(screen.Width / 2 - _logo.Width / 2, 
                screen.Height / 2 - _logo.Height / 2);
            XNACanvas.SetBGColor(Color.Black);
        }

        public void Update(long delta)
        {
            if (!_start)
            {
                //play logo song
                _start = true;
            }
            if (Keyboard.IsKeyDown(System.Windows.Forms.Keys.Space))
            {
                ChangeScreen();
            }
            _opacity += _step;
            if (_opacity >= 1)
            {
                _step = -_step;
            }
            if (_opacity <= 0)
            {
                ChangeScreen();
            }
        }

        private static void ChangeScreen()
        {
            IGameState screen = new MenuState();
            XNACanvas.SetBGColor(Color.White);
            Program.Game.ChangeState(screen);
        }

        public void Redraw(SpriteBatch batch)
        {
            batch.Draw(_logo, _position, Color.White * _opacity);
        }
    }
}
