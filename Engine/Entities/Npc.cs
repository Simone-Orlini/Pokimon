using System;
using OpenTK;

namespace Pokimon
{
    public class Npc : Character
    {
        protected float interactionTime;
        protected bool hasInteracted;
        protected bool hasKey;
        protected string name;

        public float InteractionTime { get { return interactionTime; } }
        public bool HasInteracted {  get { return hasInteracted; } }
        public bool HasKey {  get { return hasKey; } }
        public string Name { get { return name; } }

        public Npc(Vector2 position, string name) : base(position)
        {
            if (Game.CurrentScene is PlayScene)
            {
                ((PlayScene)Game.CurrentScene).AddNpc(this);
            }

            this.name = name;

            hasInteracted = false;
            hasKey = false;
        }

        public virtual void Interact()
        {
            DialogueManager.StartDialogue(name);
            hasKey = false;
        }

        public virtual void StopInteracting()
        {
            DialogueManager.EndDialogue();
            hasInteracted = true;
        }
    }
}
