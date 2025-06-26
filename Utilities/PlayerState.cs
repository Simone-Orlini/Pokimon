using System;
using OpenTK;

namespace Pokimon
{
    public struct PlayerState
    {
        public Vector2 Position;
        public bool HasKey;

        public PlayerState(Vector2 position, bool hasKey)
        {
            Position = position;
            HasKey = hasKey;
        }

        public void SaveState(Vector2 position, bool hasKey)
        {
            Position = position;
            HasKey = hasKey;
        }
    }
}
