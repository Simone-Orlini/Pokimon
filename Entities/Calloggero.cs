using OpenTK;
using System;

namespace Pokimon
{
    public class Calloggero : Entity
    {
        public Calloggero(Vector2 startPosition) : base(startPosition)
        {
            Console.WriteLine(startPosition);

            animations["Idle"] = GfxManager.GetAnimation("CalloggeroIdle");
            currentAnimation = "Idle";
        }

        public override void Draw()
        {
            base.Draw();
            animations[currentAnimation].Sprite.DrawWireframe(255, 255, 255);
        }
    }
}
