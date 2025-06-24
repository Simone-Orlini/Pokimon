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

        public PlayScene(string xmlFilePath)
        {
            mapPath = xmlFilePath;
        }

        public override void Start()
        {
            Map = new Map(mapPath);
            
            Map.CreateObjectGroups(); // needs to be done after because some objects need the map fully created

            player = new Player(Map.PlayerStart);

            camera = new Camera(player.Position.X, player.Position.Y);
            camera.pivot = new Vector2(Game.ScreenCenterX, Game.ScreenCenterY);

            base.Start();
        }

        public override void Input()
        {
            player.Input();
        }

        public override void Update()
        {
            player.Update();
            camera.position = Vector2.Lerp(camera.position, player.Position, 0.05f);
        }
    }
}
