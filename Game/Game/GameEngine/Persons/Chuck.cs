using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Game.GameEngine.Sprites;
using System.IO;
using Microsoft.Xna.Framework;

namespace Game.GameEngine.Persons
{
    public class Chuck : MovedPerson
    {
        private Texture2D standTexture;
        private AnimatedSprite standSprite;

        public Chuck(Vector2 position) : base(position)
        {
            standTexture = Texture2D.FromStream(MainGame.Device, 
                new FileStream("D:\\chuck_mega.png", FileMode.Open));
            standSprite = new AnimatedSprite(standTexture, 5, new long[] { 200, 200, 200, 500, 1200 },
                new int[] {47, 39, 39, 38, 36});
            base.Initialize(standSprite, null, null, null);
        }

        public override int Update(long delta, List<HelpClasses.BoundingBox> items)
        {
            if (Memory.Persons[0].GetBounds().X < position.X)
            {
                flip = true;
            }
            else flip = false;
            return base.Update(delta, items);
        }
    }
}
