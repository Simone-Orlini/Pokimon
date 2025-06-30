using Aiv.Fast2D;
using OpenTK;
using System.Net;

namespace Pokimon
{
    public class OutsideScene : PlayScene
    {
        public OutsideScene(string xmlFilePath) : base(xmlFilePath)
        {
            
        }

        public override void LoadAssets()
        {
            // Tileset
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

            // Princess
            GfxManager.AddAnimation("PrincessIdle", "Assets/SPRITES/HEROS/spritesheets/HEROS8Bit_Princess Idle D.png", 1, 1);

            // Key
            GfxManager.AddTexture("key", "Assets/SPRITES/ITEMS/item8BIT_key.png");

            // Sounds
            GfxManager.AddAudioClip("pickUp", "Assets/SFX/Pickup01.wav");
            GfxManager.AddAudioClip("bgMusic", "Assets/MUSIC/1BITTopDownMusics - Track 01 (1BIT Adventure).wav");
            AudioManager.AddAudioSource("sfxSource", 0.2f);
            AudioManager.AddAudioSource("bgMusicSource", 0.2f);
        }

        public override void Start()
        {
            LoadAssets();

            base.Start();

            FixedCamera = false;
            camera.position = player.Position;
        }

        public override Scene OnExit()
        {
            playerState.SaveState(player, player.Position + new Vector2(0, 1));
            return base.OnExit();
        }

        public override void Update()
        {
            base.Update();
            camera.position = Vector2.Lerp(camera.position, player.Position, 0.05f);

            // Apply camera limits
            camera.position.X = MathHelper.Clamp(camera.position.X, cameraLimits.MinX + camera.pivot.X, cameraLimits.MaxX - camera.pivot.X);
            camera.position.Y = MathHelper.Clamp(camera.position.Y, cameraLimits.MinY + camera.pivot.Y, cameraLimits.MaxY - camera.pivot.Y);

            if (player.HasKey)
            {
                EntrancePoint lockedEntrance = null;

                for(int i = 0; i < Map.EntrancePoints.Count; i++)
                {
                    if (Map.EntrancePoints[i].Locked)
                    {
                        lockedEntrance = Map.EntrancePoints[i]; // get the locked door
                    }
                }

                if (lockedEntrance != null && player.Position == lockedEntrance.Position + new Vector2(0, 1))
                {
                    OpenDoor(lockedEntrance.Position);

                    lockedEntrance.Locked = false;
                }
            }

            AudioManager.PlayClip("bgMusicSource", "bgMusic", true);
        }
    }
}
