using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokimon
{
    public class DungeonScene : PlayScene
    {
        public DungeonScene(string xmlFilePath) : base(xmlFilePath)
        {
            
        }

        public override void LoadAssets()
        {
            GfxManager.AddTexture("tileset", "Assets/TILESET/PixelPackTOPDOWN8BIT.png");

            // Player animations
            GfxManager.AddAnimation("PlayerIdle", "Assets/SPRITES/HEROS/spritesheets/HEROS8Bit_Adventurer Idle D.png", 1, 1);
            GfxManager.AddAnimation("PlayerInteract", "Assets/SPRITES/HEROS/spritesheets/HEROS8Bit_Adventurer Idle U.png", 1, 1);
            GfxManager.AddAnimation("PlayerWalkU", "Assets/SPRITES/HEROS/spritesheets/HEROS8Bit_Adventurer Walk U.png", 4, 8, 1, 1);
            GfxManager.AddAnimation("PlayerWalkD", "Assets/SPRITES/HEROS/spritesheets/HEROS8Bit_Adventurer Walk D.png", 4, 8, 1, 1);
            GfxManager.AddAnimation("PlayerWalkR", "Assets/SPRITES/HEROS/spritesheets/HEROS8Bit_Adventurer Walk R.png", 4, 8, 1, 1);
            GfxManager.AddAnimation("PlayerWalkL", "Assets/SPRITES/HEROS/spritesheets/HEROS8Bit_Adventurer Walk R.png", 4, 8, 1, 1, true);

            // Princess
            GfxManager.AddAnimation("PrincessIdle", "Assets/SPRITES/HEROS/spritesheets/HEROS8Bit_Princess Idle D.png", 1, 1);

            //Sounds
            GfxManager.AddAudioClip("bgMusic", "Assets/MUSIC/1BITTopDownMusics - Track 02 (1BIT Dark Cave).wav");
            AudioManager.AddAudioSource("bgMusicSource", 0.2f);
        }

        public override void Start()
        {
            LoadAssets();
            base.Start();
            camera.position = new Vector2(Map.Width * 0.5f, Map.Height * 0.5f);
        }

        public override void Update()
        {
            base.Update();
            AudioManager.PlayClip("bgMusicSource", "bgMusic", true);
        }
    }
}
