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

        public PlayScene(string xmlFilePath)
        {
            mapPath = xmlFilePath;
        }

        public override void Start()
        {
            Map = new Map(mapPath);
            
            Map.CreateObjectGroups(); // needs to be done after because some objects need the map fully created

            player = new Player(Map.PlayerStart);

            camera = new Camera();
            camera.pivot = new Vector2(Game.ScreenCenterX, Game.ScreenCenterY);
            base.Start();
        }

        public override void Input()
        {
            player.Input();
        }

        public override void Update()
        {
            base.Update();
            if (npcs == null) return;

            for(int i = 0; i < npcs.Count; i++)
            {
                Vector2 interactionPosition = npcs[i].Position + new Vector2(0, 1);
                if(player.Position == interactionPosition)
                {
                    player.Interact();
                }
            }
        }
    }
}
