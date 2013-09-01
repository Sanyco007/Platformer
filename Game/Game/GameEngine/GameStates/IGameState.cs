using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace Game.GameEngine.GameStates
{
    public interface IGameState
    {
        void Update(long delta);
        void Redraw(SpriteBatch batch);
    }
}
