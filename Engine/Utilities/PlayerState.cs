using System;
using OpenTK;

namespace Pokimon
{
    public struct PlayerState
    {
        private Vector2 position;
        private bool HasKey;

        public Vector2 Position { get { return position; } }

        public PlayerState(Vector2 position, bool hasKey)
        {
            this.position = position;
            HasKey = hasKey;
        }

        public void SaveState(Player player, Vector2 position)
        {
            this.position = position;
            HasKey = player.HasKey;
        }

        public Player LoadState(Player player)
        {
            player = new Player(position);
            player.HasKey = HasKey;

            return player;
        }
    }
}
