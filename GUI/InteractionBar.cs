using System;
using Aiv.Fast2D;
using OpenTK;

namespace Pokimon
{
    public class InteractionBar : Entity
    {

        private Sprite sprite;

        public override float HalfWidth => sprite.Width * 0.5f;
        public override float HalfHeight => sprite.Height * 0.5f;

        public InteractionBar() : base(Vector2.Zero, DrawLayer.UI)
        {
            float height = Game.Window.OrthoHeight * 0.3f;
            sprite = new Sprite(Game.Window.OrthoWidth * 1.2f, height);
            sprite.pivot = new Vector2(0, height);
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
                sprite.position = new Vector2(Game.CurrentScene.CameraPosition.X - HalfWidth, Game.CurrentScene.CameraPosition.Y + Game.ScreenCenterY * 0.9f);
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
