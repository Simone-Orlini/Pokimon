using Aiv.Audio;
using System.Collections.Generic;

namespace Pokimon
{
    public static class AudioManager
    {
        private static Dictionary<string, AudioSource> items;

        static AudioManager()
        {
            items = new Dictionary<string, AudioSource>();
        }

        public static void AddAudioSource(string name, float volume)
        {
            if (name == null || items.ContainsKey(name)) return;

            items[name] = new AudioSource();
            items[name].Volume = volume;
        }

        public static void ChangeClipVolume(string name, float volume)
        {
            if (name == null || !items.ContainsKey(name)) return;
            
            items[name].Volume = volume;
        }

        public static void PlayClip(string sourceName, string clipName, bool loop = false)
        {
            if (items[sourceName] != null && !items.ContainsKey(sourceName)) return;

            items[sourceName].Stream(GfxManager.GetAudioClip(clipName), Game.DeltaTime, loop);
        }

        public static void StopPlaying()
        {
            foreach(AudioSource audioSource in items.Values)
            {
                audioSource.Stop();
            }
        }

        public static void ClearAll()
        {
            items.Clear();
        }
    }
}
