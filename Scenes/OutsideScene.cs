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
            camera.position = Map.PlayerStart;
        }

        public override void Update()
        {
            base.Update();
            camera.position = Vector2.Lerp(camera.position, player.Position, 0.05f);
        }
    }
}
