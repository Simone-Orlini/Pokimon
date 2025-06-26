using Aiv.Fast2D;
using OpenTK;
using System;

namespace Pokimon
{
    public class Calloggero : Npc
    {
        public Calloggero(Vector2 startPosition) : base(startPosition)
        {
            animations["Idle"] = GfxManager.GetAnimation("CalloggeroIdle");
            currentAnimation = "Idle";
            interactionTime = 3;
            hasKey = true;
        }
    }
}
