using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Collections.Generic;

namespace Pokimon
{
    public abstract class Entity : IDrawable, IUpdatable
    {
        protected Dictionary<string, Animation> animations;
        protected string currentAnimation;
        protected DrawLayer drawLayer;
        protected Vector2 position;
        protected Vector2 velocity;

        public DrawLayer DrawLayer { get { return drawLayer; } }
        public Vector2 Position { get { return position; } set { position = value; } }

        public Vector2 Velocity { get { return velocity; } set { velocity = value; } }

        protected Entity(DrawLayer layer)
        {
            drawLayer = layer;
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
