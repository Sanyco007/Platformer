using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Game.GameEngine
{
    public class Keyboard
    {
        private static ISet<Keys> kbd = new HashSet<Keys>();

        public static bool showBorder = false; 

        public static void KeyDown(Keys key)
        {
            kbd.Add(key);
            if (key == Keys.F10) showBorder = !showBorder;
        }

        public static void KeyUp(Keys key)
        {
            kbd.Remove(key);
        }

        public static bool IsKeyDown(Keys key)
        {
            return kbd.Contains(key);
        }

        public static void ClearState()
        {
            kbd.Clear();
        }
    }
}
