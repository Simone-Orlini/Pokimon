using System;
using Aiv.Fast2D;
using OpenTK;
namespace Pokimon
{
    public class Key : Entity
    {
        public Key(Vector2 startPosition) : base(startPosition)
        {
            animations["key"] = GfxManager.GetAnimation("key");
            currentAnimation = "key";
        }
    }
}
