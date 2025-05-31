using Aiv.Fast2D;
using OpenTK;
using System.Collections.Generic;

namespace Pokimon
{
    public abstract class Entity
    {
        protected Dictionary<string, Animation> animations;
        protected string currentAnimation;

        protected Entity()
        {
            animations = new Dictionary<string, Animation>();
        }

        public virtual void Update()
        {
            
        }

        public virtual void Draw()
        {
            animations[currentAnimation].Draw();
        }
    }
}
