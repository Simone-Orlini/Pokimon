using Aiv.Fast2D;
using OpenTK;
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
        protected bool isActive;

        public DrawLayer DrawLayer { get { return drawLayer; } }
        public Vector2 Position { get { return position; } set { position = value; } }

        public Vector2 Velocity { get { return velocity; } set { velocity = value; } }

        protected Entity(Vector2 startPosition, DrawLayer layer = DrawLayer.Playground)
        {
            position = startPosition;
            drawLayer = layer;
            animations = new Dictionary<string, Animation>();
            DrawManager.AddItem(this);
            UpdateManager.AddItem(this);
            isActive = true;
        }

        public virtual void Update()
        {
            animations[currentAnimation].Sprite.position = position;
        }

        public virtual void Draw()
        {
            if (isActive)
            {
                animations[currentAnimation].Draw();
            }
        }
    }
}
