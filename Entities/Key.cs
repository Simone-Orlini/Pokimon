using System;
using Aiv.Fast2D;
using OpenTK;
namespace Pokimon
{
    public class Key : Entity
    {
        public Key(Vector2 startPosition) : base(startPosition)
        {
            InitAnimations();
        }

        protected override void InitAnimations()
        {
            animations["key"] = GfxManager.GetAnimation("key");
            currentAnimation = "key";
        }
    }
}
