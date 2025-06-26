using Aiv.Fast2D;
using OpenTK;
using System.Collections.Generic;
using System.Linq;

namespace Pokimon
{
    public class PlayScene : Scene
    {
        protected Player player;
        protected string mapPath;
        protected List<Entity> npcs;
        protected PlayerState playerState;

        public PlayScene(string xmlFilePath)
        {
            mapPath = xmlFilePath;
        }

        public override void Start()
        {
            DrawManager.Init();
            UpdateManager.Init();

            //create npcs list
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

            player = new Player(playerState.Position);

            camera = new Camera();
            camera.pivot = new Vector2(Game.ScreenCenterX, Game.ScreenCenterY);

            base.Start();
        }

        public override void Input()
        {
            player.Input();
        }

        public void AddNpc(Entity npc)
        {
            npcs.Add(npc);
        }

        public override Scene OnExit()
        {
            DrawManager.ClearAll();
            UpdateManager.ClearAll();
            GfxManager.ClearAll();

            camera = null;

            Game.Window.SetCamera(camera);

            base.OnExit();

            return NextScene;
        }

        public override void Update()
        {
            base.Update();

            // check if player is entering a new scene
            for (int i = 0; i < Map.EntrancePoints.Count; i++)
            {
                if (player.Position == Map.EntrancePoints[i].Position)
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
    }
}
