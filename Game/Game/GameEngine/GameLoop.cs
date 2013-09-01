using System.Threading;
using System.Diagnostics;

namespace Game.GameEngine
{
    public class GameLoop
    {
        private MainGame game = null;
        private Thread loop = null;
        private bool run = false;
        private const int frameRate = 60;
        private int updateTime = 1000 / frameRate;
        private Stopwatch stopwatch = new Stopwatch();

        public static int FPS = 0;

        public GameLoop(MainGame game)
        {
            this.game = game;
            loop = new Thread(Run);
            loop.IsBackground = true;
        }

        public void Start()
        {
            run = true;
            stopwatch.Start();
            loop.Start();
        }

        public void Stop()
        {
            run = false;
        }

        private void Run()
        {
            long lastTime = stopwatch.ElapsedMilliseconds;
            long ellapsedTime = 0;
            long fpsEllapsed = 0;
            int fps = 0;
            while (run)
            {
                fpsEllapsed += stopwatch.ElapsedMilliseconds - lastTime;
                ellapsedTime += stopwatch.ElapsedMilliseconds - lastTime;
                if (ellapsedTime >= updateTime) 
                {
                    game.Update(updateTime);
                    game.Redraw();
                    fps++;
                    ellapsedTime -= updateTime;
                }
                if (fpsEllapsed >= 1000)
                {
                    FPS = fps;
                    fps = 0;
                    fpsEllapsed = 0;
                }
                lastTime = stopwatch.ElapsedMilliseconds;
                while (stopwatch.ElapsedMilliseconds - lastTime < updateTime)
                {
                    Thread.Yield();
                    Thread.Sleep(1);
                }
            }
        }
    }
}
