using System;
using OpenTK;

namespace Pokimon
{
    public class Princess : Npc
    {
        public Princess(Vector2 startPosition) : base(startPosition)
        {
            InitAnimations();
            interactionTime = 5;
        }

        protected override void InitAnimations()
        {
            animations["Idle"] = GfxManager.GetAnimation("PrincessIdle");

            currentAnimation = "Idle";
        }
    }
}
