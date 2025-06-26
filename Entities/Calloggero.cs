using Aiv.Fast2D;
using OpenTK;
using System;

namespace Pokimon
{
    public class Calloggero : Entity
    {
        public Calloggero(Vector2 startPosition) : base(startPosition)
        {
            animations["Idle"] = GfxManager.GetAnimation("CalloggeroIdle");
            currentAnimation = "Idle";
        }
    }
}
