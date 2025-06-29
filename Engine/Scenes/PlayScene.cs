using Aiv.Fast2D;
using OpenTK;
using System.Collections.Generic;

namespace Pokimon
{
    public class PlayScene : Scene
    {
        protected Player player;
        protected string mapPath;
        protected List<Entity> npcs;
        protected PlayerState playerState;

        public List<Entity> Npcs { get { return npcs; } }
        public Vector2 PlayerPosition { get { return player.Position; } }
        public bool FixedCamera { get; protected set; }

        public PlayScene(string xmlFilePath)
        {
            mapPath = xmlFilePath;
        }

        public override void Start()
        {
            DrawManager.Init();
            UpdateManager.Init();

            //create lists
            npcs = new List<Entity>();

           //Create map
            Map = new Map(mapPath);
            
            Map.CreateObjectGroups(); // needs to be done after because some objects need the map to be fully created

            // create player and camera
            if(playerState.Position == Vector2.Zero)
            {
                playerState = new PlayerState(Map.PlayerStart, false);
            }

            cameraLimits = new CameraLimits(Map.Width, 0, Map.Height, 0);

            player = playerState.LoadState(player);

            if (player.HasKey)
            {
                foreach(EntrancePoint entrance in Map.EntrancePoints)
                {
                    if (entrance.Locked)
                    {
                        entrance.Locked = false;
                        OpenDoor(entrance.Position);
                    }
                }
            }

            DialogueManager.Init(this);

            camera = new Camera();
            camera.pivot = new Vector2(Game.ScreenCenterX, Game.ScreenCenterY);

            base.Start();
        }

        public override void Input()
        {
            player.Input();
        }

        public override Scene OnExit()
        {
            AudioManager.StopPlaying();

            DrawManager.ClearAll();
            UpdateManager.ClearAll();
            GfxManager.ClearAllButFonts();
            AudioManager.ClearAll();

            camera = null;

            Game.Window.SetCamera(camera);

            return base.OnExit();
        }

        public override void Update()
        {
            base.Update();

            // check if player is entering a new scene
            for (int i = 0; i < Map.EntrancePoints.Count; i++)
            {
                if (player.Position == Map.EntrancePoints[i].Position && !Map.EntrancePoints[i].Locked)
                {
                    IsPlaying = false;
                }
            }

            // player interaction with npcs
            if (npcs == null || player.IsInteracting) return;

            foreach(Npc npc in npcs)
            {   
                Vector2 interactionPosition = npc.Position + new Vector2(0, 1);
                if (player.Position == interactionPosition && !npc.HasInteracted)
                {
                    if (npc.HasKey)
                    {
                        player.Interact(npc, npc.HasKey);
                        continue;
                    }

                    player.Interact(npc);
                }
            }
        }

        public void AddNpc(Entity npc)
        {
            npcs.Add(npc);
        }

        protected void OpenDoor(Vector2 doorPosition)
        {
            Map.ChangeTile(doorPosition - new Vector2(0.5f, 0.5f), 254, 238);
            Map.PathfindingMap.ChangeNode(doorPosition, 2);
        }
    }
}
