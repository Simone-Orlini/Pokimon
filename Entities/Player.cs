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

        public Player() : base(DrawLayer.Playground)
        {
            InitAnimations();
            currentAnimation = "Idle";

            agent = new Agent(this);

            speed = 4;
            position = new Vector2(25, 25);
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
            //if (Game.Window.MouseLeft)
            //{
            //    if (!clickedL)
            //    {
            //        mousePos = window.MousePosition;
            //        List<Node> path = map.GetPath(agent.X, agent.Y, (int)mousePos.X, (int)mousePos.Y);
            //        agent.SetPath(path);
            //        clickedL = true;
            //    }
            //}
            //else if (clickedL)
            //{
            //    clickedL = false;
            //}
        }

        public override void Update()
        {
            position += velocity * Game.DeltaTime;

            animations[currentAnimation].Sprite.position = position;
            animations[currentAnimation].Play();
        }
    }
}
