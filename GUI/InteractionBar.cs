using System;
using Aiv.Fast2D;
using OpenTK;

namespace Pokimon
{
    public class InteractionBar : Entity
    {
        public InteractionBar() : base(Vector2.Zero, spriteWidth: (int)(Game.Window.OrthoWidth * 1.2f), spriteHeight : (int)(Game.Window.OrthoHeight * 0.3f), layer : DrawLayer.UI)
        {
            sprite.pivot = new Vector2(0, sprite.Height);
            Deactivate();
        }

        public void Activate()
        {
            isActive = true;
        }

        public void Deactivate()
        {
            isActive = false;
        }

        public override void Update()
        {
            if (isActive)
            {
                sprite.position = new Vector2(Game.CurrentScene.CameraPosition.X - HalfWidth, Game.CurrentScene.CameraPosition.Y + Game.ScreenCenterY);
            }
        }

        public override void Draw()
        {
            if (isActive)
            {
                sprite.DrawColor(0, 0, 0);
            }
        }
    }
}
