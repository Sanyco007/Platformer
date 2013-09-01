using Game.GameEngine.GameStates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Game.GameEngine.HelpClasses;

namespace Game.GameEngine
{
    public class MainGame
    {
        private IGameState _gameState;
        private readonly GameLoop _gameLoop;
        private readonly XNACanvas _canvas;

        public static GraphicsDevice Device = null;
        public static GraphicFont Font = null;
        public static bool ShowFps = true;
        public static int Width = 720;
        public static int Height = 480;
        public static int LevelWidth = 0;
        public static int LevelHeight = 0;

        private delegate void RedrawCanvas();

        public MainGame(XNACanvas canvas)
        {
            _canvas = canvas;
            Device = canvas.Device;
            Font = new GraphicFont();
            canvas.OnDraw += canvas_OnDraw;
            _gameState = new LogoState();
            //SoundManager.Volume = 0.0f;
            GraphicFont.HashData();
            _gameLoop = new GameLoop(this);
            _gameLoop.Start();
        }

        public void ChangeState(IGameState gameState)
        {
            _gameState = gameState;
        }

        private void canvas_OnDraw(DrawEventArgs args)
        {
            var batch = args.spriteBatch;
            _gameState.Redraw(batch);
            if (ShowFps)
            {
                Texture2D fps = Font.GetTexture2D("FPS: " + GameLoop.FPS);
                batch.Draw(fps, new Vector2(2, Height - 20), Color.Black);
            }
        }

        public void Update(long delta)
        {
            Camera.Update();
            FrameworkDispatcher.Update();
            _gameState.Update(delta);
        }

        public void Redraw()
        {
            if (_canvas.InvokeRequired)
            {
                var rc = new RedrawCanvas(Invalidate);
                _canvas.Invoke(rc);
            }
            else Invalidate();
        }

        private void Invalidate()
        {
            _canvas.Invalidate();
        }

        public void Stop()
        {
            _gameLoop.Stop();
        }
    }
}
