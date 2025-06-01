using Aiv.Fast2D;
using OpenTK;
using System;
using System.Runtime.InteropServices;

namespace Pokimon
{
    public class Player : Entity
    {
        private Vector2 velocity;
        private int speed;
        private Vector2 position;
        private Camera camera;

        public Player()
        {
            InitAnimations();
            currentAnimation = "Idle";

            speed = 4;
            position = Vector2.Zero;

            camera = new Camera();
            camera.pivot = new Vector2(Game.ScreenCenterX, Game.ScreenCenterY);
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
            // temporary, it's gonna use pathfinding
            if (Game.Window.GetKey(KeyCode.W))
            {
                currentAnimation = "WalkU";
                velocity.Y = -1;
            }
            else if (Game.Window.GetKey(KeyCode.S))
            {
                currentAnimation = "WalkD";
                velocity.Y = 1;
            }
            else
            {
                velocity.Y = 0;
            }

            if (Game.Window.GetKey(KeyCode.A))
            {
                currentAnimation = "WalkL";
                velocity.X = -1;
            }
            else if (Game.Window.GetKey(KeyCode.D))
            {
                currentAnimation = "WalkR";
                velocity.X = 1;
            }
            else
            {
                velocity.X = 0;
            }

            if(velocity.LengthSquared == 0)
            {
                currentAnimation = "Idle";
            }
            
            if(velocity.Length > 1)
            {
                velocity.Normalize();
            }

            velocity *= speed;
        }

        public override void Update()
        {
            position += velocity * Game.DeltaTime;
            camera.position = Vector2.Lerp(camera.position, position, 0.05f);

            animations[currentAnimation].Sprite.position = position;
            animations[currentAnimation].Play();
        }
    }
}
