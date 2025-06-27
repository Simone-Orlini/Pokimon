using System;
using OpenTK;

namespace Pokimon
{
    public class KeyKeeper : Npc
    {
        protected Key key;

        public Key Key { get { return key; } }

        public KeyKeeper(Vector2 startPosition, Key key) : base(startPosition)
        {
            hasKey = true;
            this.key = key;
        }
    }
}
