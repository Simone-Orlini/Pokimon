using OpenTK;
using System;
using System.Collections.Generic;

namespace Pokimon
{
    public class Character : Entity
    {
        protected Dictionary<string, Animation> animations;
        protected string currentAnimation;

        public override float HalfWidth { get { return animations[currentAnimation].Sprite.Width * 0.5f; } }
        public override float HalfHeight { get { return animations[currentAnimation].Sprite.Height * 0.5f; } }

        public Character(Vector2 startPosition) : base(startPosition)
        {
            animations = new Dictionary<string, Animation>();
        }

        protected virtual void InitAnimations()
        {

        }

        public override void Update()
        {
            animations[currentAnimation].Sprite.position = position;
        }

        public override void Draw()
        {
            if (isActive)
            {
                animations[currentAnimation].Draw();
            }
        }
    }
}
