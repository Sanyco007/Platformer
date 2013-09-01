using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Game.GameEngine.HelpClasses;

namespace Game.GameEngine.Sprites
{
    //Интерфейс графического обьекта
    public interface IGraphicItem
    {
        int Update(long delta, List<BoundingBox> items);
        void Redraw(SpriteBatch batch, bool flip = false);
        BoundingBox GetBounds();
        float GetSpeed();
    }
}
