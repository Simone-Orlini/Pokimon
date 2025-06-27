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
        public bool IsActive { get { return isActive; } set { isActive = value; } }
        public virtual float HalfWidth { get { return animations[currentAnimation].Sprite.Width * 0.5f; } }
        public virtual float HalfHeight { get { return animations[currentAnimation].Sprite.Height * 0.5f; } }

        protected Entity(Vector2 startPosition, DrawLayer layer = DrawLayer.Playground)
        {
            position = startPosition;
            drawLayer = layer;
            animations = new Dictionary<string, Animation>();
            DrawManager.AddItem(this);
            UpdateManager.AddItem(this);
            isActive = true;
        }

        protected virtual void InitAnimations()
        {

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
