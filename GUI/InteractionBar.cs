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
            position = new Vector2(Game.CurrentScene.CameraPosition.X - HalfWidth, Game.CurrentScene.CameraPosition.Y + Game.ScreenCenterY);
        }

        public void Deactivate()
        {
            isActive = false;
        }

        public override void Draw()
        {
            if (isActive)
            {
                sprite.position = position;
                sprite.DrawColor(0, 0, 0);
            }
        }
    }
}
