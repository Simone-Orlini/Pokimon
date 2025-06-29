using System;
using Aiv.Fast2D;
using OpenTK;
namespace Pokimon
{
    public class Key : Entity
    {
        public Key(Vector2 startPosition) : base(startPosition, "key", spriteWidth : 1, spriteHeight : 1)
        {

        }

        public override void Draw()
        {
            base.Draw();
        }
    }
}
