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

        public override void Start()
        {
            base.Start();
            camera = new Camera(player.Position.X, player.Position.Y);
            camera.pivot = new Vector2(Game.ScreenCenterX, Game.ScreenCenterY);
        }
    }
}
