using Aiv.Fast2D;
using OpenTK;
using System;
using System.Collections.Generic;
using Aiv.Audio;

namespace Pokimon
{
    public static class GfxManager
    {
        private static Dictionary<string, Texture> textures;
        private static Dictionary<string, Animation> animations;
        private static Dictionary<string, AudioClip> sounds;

        static GfxManager()
        {
            textures = new Dictionary<string, Texture>();
            sounds = new Dictionary<string, AudioClip>();
            animations = new Dictionary<string, Animation>();
        }

        public static Texture AddTexture(string name, string filePath)
        {
            if (textures.ContainsKey(name)) return textures[name];

            Texture texture = new Texture(filePath);

            if (texture != null)
            {
                textures[name] = texture;
            }
            return texture;
        }

        public static Animation AddAnimation(string name, string filePath, int frameCount, float animationSpeed, int frameW, int frameH, bool flipped = false)
        {
            if (animations.ContainsKey(name)) return animations[name];

            animations[name] = new Animation(name, filePath, frameCount, animationSpeed, frameW, frameH);

            if (flipped)
            {
                animations[name].Sprite.FlipX = true;
            }

            return animations[name];
        }

        public static Animation AddAnimation(string name, string filePath, int frameW, int frameH, bool flipped = false)
        {
            if (animations.ContainsKey(name)) return animations[name];

            animations[name] = new Animation(name, filePath, frameW, frameH);

            if (flipped)
            {
                animations[name].Sprite.FlipX = true;
            }

            return animations[name];
        }

        public static AudioClip AddAudioClip(string name, string filePath)
        {
            if (sounds.ContainsKey(name)) return sounds[name];

            AudioClip ac = new AudioClip(filePath);

            if (ac != null)
            {
                sounds[name] = ac;
            }
            return ac;
        }

        public static Texture GetTexture(string name)
        {
            Texture texture = null;

            if (textures.ContainsKey(name))
            {
                texture = textures[name];
            }

            return texture;
        }

        public static Animation GetAnimation(string name)
        {
            if (animations.ContainsKey(name))
            {
                return animations[name];
            }

            return null;
        }

        public static AudioClip GetAudioClip(string name)
        {
            AudioClip ac = null;

            if (sounds.ContainsKey(name))
            {
                ac = sounds[name];
            }

            return ac;
        }

        public static void ClearGfx()
        {
            textures.Clear();
        }

        public static void ClearSfx()
        {
            sounds.Clear();
        }

        public static void ClearAnimations()
        {
            animations.Clear();
        }

        public static void ClearAll()
        {
            textures.Clear();
            sounds.Clear();
            animations.Clear();
        }
    }
}
