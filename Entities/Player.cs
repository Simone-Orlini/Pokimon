using Aiv.Fast2D;
using OpenTK;
using System.Collections.Generic;

namespace Pokimon
{
    public class Player : Entity
    {
        private int speed;

        private Agent agent;

        private bool clickedL = false;

        public Player(Vector2 startPosition) : base(DrawLayer.Playground)
        {
            InitAnimations();
            currentAnimation = "Idle";

            agent = new Agent(this);

            speed = 4;
            position = startPosition;
        }

        private void InitAnimations()
        {
            // Idle
            animations["Idle"] = new Animation("Idle", "Assets/SPRITES/HEROS/spritesheets/HEROS8Bit_Adventurer Idle D.png", 1, 1);

            //Walk
            animations["WalkU"] = new Animation("WalkU", "Assets/SPRITES/HEROS/spritesheets/HEROS8Bit_Adventurer Walk U.png", 4, 8, 1, 1);
            animations["WalkD"] = new Animation("WalkD", "Assets/SPRITES/HEROS/spritesheets/HEROS8Bit_Adventurer Walk D.png", 4, 8, 1, 1);
            animations["WalkR"] = new Animation("WalkR", "Assets/SPRITES/HEROS/spritesheets/HEROS8Bit_Adventurer Walk R.png", 4, 8, 1, 1);
            animations["WalkL"] = new Animation("WalkL", "Assets/SPRITES/HEROS/spritesheets/HEROS8Bit_Adventurer Walk R.png", 4, 8, 1, 1);
            animations["WalkL"].Sprite.FlipX = true;
        }

        public void Input()
        {
            if (Game.Window.MouseLeft && MouseInsideScreen())
            {
                if (!clickedL)
                {
                    List<Node> path = Game.Map.PathfindingMap.GetPath(agent.X, agent.Y, (int)Game.RelativeMousePosition.X, (int)Game.RelativeMousePosition.Y);
                    agent.SetPath(path);
                    clickedL = true;
                }
            }
            else if (clickedL)
            {
                clickedL = false;
            }
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

            animations[currentAnimation].Sprite.position = position;
            animations[currentAnimation].Play();
        }
    }
}
