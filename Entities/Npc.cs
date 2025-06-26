using System;
using OpenTK;

namespace Pokimon
{
    public class Npc : Entity
    {
        protected float interactionTime;
        protected bool hasInteracted;
        protected bool hasKey;

        public float InteractionTime { get { return interactionTime; } }
        public bool HasInteracted {  get { return hasInteracted; } }
        public bool HasKey {  get { return hasKey; } }

        public Npc(Vector2 position) : base(position)
        {
            if (Game.CurrentScene is PlayScene)
            {
                ((PlayScene)Game.CurrentScene).AddNpc(this);
            }

            hasInteracted = false;
            hasKey = false;
        }

        public void Interact()
        {
            hasInteracted = true;
        }

        public void StopInteracting()
        {
            hasInteracted = false;
        }
    }
}
