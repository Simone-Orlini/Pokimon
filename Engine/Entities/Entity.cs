using Aiv.Fast2D;
using OpenTK;

namespace Pokimon
{
    public abstract class Entity : IDrawable, IUpdatable
    {
        // Draw stuff
        protected Sprite sprite;
        protected Texture texture;
        protected DrawLayer drawLayer;
        protected float textureOffsetX, textureOffsetY;

        // Physics stuff
        protected Vector2 position;
        protected Vector2 velocity;
        protected bool isActive;

        #region Props
        public DrawLayer DrawLayer { get { return drawLayer; } }
        public Vector2 Position { get { return position; } set { position = value; } }
        public Vector2 Velocity { get { return velocity; } set { velocity = value; } }
        public bool IsActive { get { return isActive; } set { isActive = value; } }
        public virtual float HalfWidth { get { return sprite.Width * 0.5f; } }
        public virtual float HalfHeight { get { return sprite.Height * 0.5f; } }
        public Vector2 Scale { get { return sprite.scale; } }
        #endregion

        protected Entity(Vector2 startPosition, string textureName, float textureOffsetX = 0, float textureOffsetY = 0, float spriteWidth = 0, float spriteHeight = 0, DrawLayer layer = DrawLayer.Playground)
        {
            texture = GfxManager.GetTexture(textureName);

            float spriteW = spriteWidth;
            float spriteH = spriteHeight;

            sprite = new Sprite(spriteW, spriteH);
            sprite.pivot = new Vector2(HalfWidth, HalfHeight);

            this.textureOffsetX = textureOffsetX;
            this.textureOffsetY = textureOffsetY;

            position = startPosition;
            drawLayer = layer;
            DrawManager.AddItem(this);
            UpdateManager.AddItem(this);
            isActive = true;
        }

        protected Entity(Vector2 startPosition, int textureOffsetX = 0, int textureOffsetY = 0, float spriteWidth = 0, float spriteHeight = 0, DrawLayer layer = DrawLayer.Playground)
        {
            float spriteW = spriteWidth;
            float spriteH = spriteHeight;

            sprite = new Sprite(spriteW, spriteH);

            this.textureOffsetX = textureOffsetX;
            this.textureOffsetY = textureOffsetY;

            position = startPosition;
            drawLayer = layer;
            DrawManager.AddItem(this);
            UpdateManager.AddItem(this);
            isActive = true;
        }

        public virtual void Update()
        {
            sprite.position = position;
        }

        public virtual void Draw()
        {
            if (isActive)
            {
                // Conversions from unit to pixels
                float spriteW = sprite.Width * 16;
                float spriteH =  sprite.Height * 16;
                float textureOffX = textureOffsetX * 16;
                float textureOffY = textureOffsetY * 16;

                sprite.DrawTexture(texture, (int)textureOffX, (int)textureOffY, (int)spriteW, (int)spriteH);
                //sprite.DrawWireframe(255, 255, 255);
            }
        }
    }
}
