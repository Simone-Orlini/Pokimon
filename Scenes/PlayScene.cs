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

            Map = new Map(mapPath);
            
            Map.CreateObjectGroups(); // needs to be done after because some objects need the map fully created

            if(playerState.Position == Vector2.Zero)
            {
                playerState = new PlayerState(Map.PlayerStart);
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

        public override Scene OnExit()
        {
            playerState.Position = player.Position + new Vector2(0, 1);

            DrawManager.ClearAll();
            UpdateManager.ClearAll();
            GfxManager.ClearAll();

            camera = null;

            Game.Window.SetCamera(camera);

            System.Console.WriteLine(Game.Window.CurrentCamera);

            base.OnExit();

            return NextScene;
        }

        public override void Update()
        {
            base.Update();
            //if (npcs == null) return;

            //for(int i = 0; i < npcs.Count; i++)
            //{
            //    Vector2 interactionPosition = npcs[i].Position + new Vector2(0, 1);
            //    if(player.Position == interactionPosition)
            //    {
            //        player.Interact();
            //    }
            //}

            for(int i = 0; i < Map.EntrancePoints.Count; i++)
            {
                if(player.Position == Map.EntrancePoints[i].Position)
                {
                    IsPlaying = false;
                }
            }
        }
    }
}
