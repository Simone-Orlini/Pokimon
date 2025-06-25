using Aiv.Fast2D;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokimon
{
    public class OutsideScene : PlayScene
    {
        public OutsideScene(string xmlFilePath) : base(xmlFilePath)
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

            // Calloggero
            GfxManager.AddAnimation("CalloggeroIdle", "Assets/SPRITES/Enemies/spritesheets/ENEMIES8bit_Sorcerer Hurt R.png", 1, 1);
        }

        public override void Start()
        {
            LoadAssets();

            base.Start();
            camera.position = Map.PlayerStart;
        }

        public override void Update()
        {
            base.Update();
            camera.position = Vector2.Lerp(camera.position, player.Position, 0.05f);
        }
    }
}
