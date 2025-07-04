﻿using Aiv.Fast2D;
using OpenTK;
using System;

namespace Pokimon
{
    public class Calloggero : Npc
    {

        private Key key;

        public Calloggero(Vector2 startPosition) : base(startPosition, "Calloggero")
        {
            InitAnimations();

            interactionTime = 10;
            hasKey = true;
            key = new Key(Vector2.Zero);
            key.IsActive = false;
        }

        protected override void InitAnimations()
        {
            animations["Idle"] = GfxManager.GetAnimation("CalloggeroIdle");

            currentAnimation = "Idle";
        }

        public override void Interact()
        {
            base.Interact();
            key.Position = position;
            key.IsActive = true;
        }

        public override void StopInteracting()
        {
            base.StopInteracting();
            key.IsActive = false;
            hasKey = false;
        }
    }
}
