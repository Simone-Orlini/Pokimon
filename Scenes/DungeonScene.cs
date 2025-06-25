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

        public override void Start()
        {
            base.Start();
            camera.position = new Vector2(Map.Width * 0.5f, Map.Height * 0.5f);
        }
    }
}
