using System;
using OpenTK;

namespace Pokimon
{
    public struct PlayerState
    {
        public Vector2 Position;

        public PlayerState(Vector2 position)
        {
            Position = position;
        }
    }
}
