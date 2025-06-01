using Aiv.Fast2D;
using OpenTK;
using System.Collections.Generic;

namespace Pokimon
{
    public abstract class Entity : IDrawable, IUpdatable
    {
        protected Dictionary<string, Animation> animations;
        protected string currentAnimation;

        protected Entity()
        {
            animations = new Dictionary<string, Animation>();
            DrawManager.AddItem(this);
            UpdateManager.AddItem(this);
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
