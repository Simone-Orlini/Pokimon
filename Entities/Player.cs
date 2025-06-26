using Aiv.Fast2D;
using OpenTK;
using System;
using System.Collections.Generic;

namespace Pokimon
{
    public class Player : Entity
    {
        private int speed;

        private Agent agent;

        private bool clickedL = false;
        private bool hasKey = false;

        public bool HasKey { get { return hasKey; } }

        public Player(Vector2 startPosition) : base(startPosition)
        {
            InitAnimations();
            currentAnimation = "Idle";

            agent = new Agent(this);

            speed = 4;
        }

        private void InitAnimations()
        {
            // Idle
            animations["Idle"] = GfxManager.GetAnimation("PlayerIdle");

            //Walk
            animations["WalkU"] = GfxManager.GetAnimation("PlayerWalkU");
            animations["WalkD"] = GfxManager.GetAnimation("PlayerWalkD");
            animations["WalkR"] = GfxManager.GetAnimation("PlayerWalkR");
            animations["WalkL"] = GfxManager.GetAnimation("PlayerWalkL");

            //Interact
            animations["Interact"] = GfxManager.GetAnimation("PlayerInteract");
        }

        public void Input()
        {
            if (Game.Window.MouseLeft && MouseInsideScreen())
            {
                if (!clickedL)
                {
                    List<Node> path = Game.CurrentScene.Map.PathfindingMap.GetPath(agent.X, agent.Y, (int)Game.RelativeMousePosition.X, (int)Game.RelativeMousePosition.Y);
                    agent.SetPath(path);
                    clickedL = true;
                }
            }
            else if (clickedL)
            {
                clickedL = false;
            }
        }

        public void Interact()
        {
            currentAnimation = "Interact";
        }

        public void Interact(bool giveKey)
        {
            currentAnimation = "Interact";
            hasKey = giveKey;
        }

        private void UpdateAnimations(Vector2 direction)
        {
            if(direction.X > 0)
            {
                currentAnimation = "WalkR";
            }
            else if(direction.X < 0)
            {
                currentAnimation = "WalkL";
            }
            else if(direction.Y > 0)
            {
                currentAnimation = "WalkD";
            }
            else if(direction.Y < 0)
            {
                currentAnimation = "WalkU";
            }
            else
            {
                currentAnimation = "Idle";
            }
        }

        private bool MouseInsideScreen()
        {
            return (Game.AbsoluteMousePosition.X > 0 && Game.AbsoluteMousePosition.X < Game.Window.OrthoWidth) && (Game.AbsoluteMousePosition.Y > 0 && Game.AbsoluteMousePosition.Y < Game.Window.OrthoHeight);
        }

        public override void Update()
        {
            agent.Update(speed);

            Vector2 direction = agent.GetDirection();

            UpdateAnimations(direction);

            base.Update();

            animations[currentAnimation].Play();
        }
    }
}
