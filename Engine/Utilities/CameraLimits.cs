using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokimon
{
    public struct CameraLimits
    {
        public float MaxX;
        public float MaxY;
        public float MinX;
        public float MinY;

        public CameraLimits(float maxX, float minX, float maxY, float minY)
        {
            MaxX = maxX;
            MinX = minX;
            MaxY = maxY;
            MinY = minY;
        }
    }
}
