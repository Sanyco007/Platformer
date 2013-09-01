using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
using System.IO;
using Microsoft.Xna.Framework;

namespace Game.GameEngine.HelpClasses
{
    public class SoundManager
    {
        public static bool SoundOn = true;
        public static float Volume { get; set; }

        public static void PlaySong(SoundEffect song)
        {
            if (!SoundOn) return;
            song.Play(Volume, 0, 0);
        }

    }
}
