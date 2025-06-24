using OpenTK;
using System;
using System.Xml;

namespace Pokimon
{
    public class PointObject : Object
    {
        protected Vector2 position;

        public Vector2 Position { get { return position; } }

        public PointObject(XmlNode xmlPoint) : base(xmlPoint)
        {
            position = new Vector2((GetIntAttribute(xmlPoint, "x") / Game.Tileset.TileWidth) + 0.5f, GetIntAttribute(xmlPoint, "y") / Game.Tileset.TileWidth + 0.5f); // to transform from pixels to units and center the position to the center of the tile
        }
    }
}
