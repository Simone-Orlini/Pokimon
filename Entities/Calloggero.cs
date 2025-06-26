using Aiv.Fast2D;
using OpenTK;
using System;

namespace Pokimon
{
    public class Calloggero : Npc
    {

        private Key key;

        public Calloggero(Vector2 startPosition) : base(startPosition)
        {
            animations["Idle"] = GfxManager.GetAnimation("CalloggeroIdle");
            currentAnimation = "Idle";
            interactionTime = 3;
            hasKey = true;
            key = new Key(Vector2.Zero);
            key.IsActive = false;
        }

        public override void Interact()
        {
            base.Interact();
            key.Position = position;
            key.IsActive = true;
        }

        public override void StopInteracting()
        {
            key.IsActive = false;
        }
    }
}
