using Aiv.Fast2D;
using OpenTK;
using System;

namespace Pokimon
{
    public class Animation
    {
        //Variables
        private Texture texture;
        private Sprite sprite;
        private int frameCount;
        private float speed;
        private float timer;
        private int currentFrame;
        private int[] frames;

        // Properties
        public Texture Texture { get { return texture; } }
        public Sprite Sprite { get { return sprite; } }
        public int FrameCount { get { return frameCount; } }
        public string Name { get; private set; }
        public float Speed { get { return speed; } set { speed = value; } }


        public Animation(string name, string filePath, int frameCount, float animSpeed, int frameW, int frameH)
        {
            texture = new Texture(filePath);
            sprite = new Sprite(frameW, frameH);
            speed = 1 / animSpeed;
            this.frameCount = frameCount;
            currentFrame = 0;
            frames = new int[frameCount];

            for(int i = 0; i < frameCount; i++)
            {
                frames[i] = i * frameW * 16; // change from unit to pixel
            }
            sprite.pivot = new Vector2(frameW * 0.5f, frameH * 0.5f);
        }

        public Animation(string name, string filePath, int width, int height)
        {
            texture = new Texture(filePath);
            sprite = new Sprite(width, height);
            currentFrame = 0;
            frameCount = 1;
            frames = new int[1];
            sprite.pivot = new Vector2(width * 0.5f, height * 0.5f);
        }

        public void Play()
        {
            if (frameCount <= 1) return;
            
            timer += Game.DeltaTime;

            if(timer >= speed)
            {
                currentFrame += 1;
                timer = 0;
            }

            if(currentFrame >= frames.Length)
            {
                currentFrame = 0;
            }
        }

        public void Draw()
        {
            sprite.DrawTexture(texture, frames[currentFrame], 0, (int)sprite.Width * 16, (int)sprite.Height * 16); // converts to pixels (1 unit -> 16 pixels)
        }
    }
}
