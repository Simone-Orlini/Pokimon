using Aiv.Fast2D;
using OpenTK;
using System;
using System.Xml;

namespace Pokimon
{
    public class Chunk : IDrawable
    {
        private int width;
        private int height;
        private Tile[] tiles;
        private Vector2 position;

        private Sprite sprite;
        private Texture texture;

        private XmlNode xmlChunk;

        public int Width { get { return width; } }
        public int Height { get { return height; } }
        public Vector2 Position { get { return position; } }

        public Chunk(XmlNode xmlChunk)
        {
            width = GetIntAttribute(xmlChunk, "width");
            height = GetIntAttribute(xmlChunk, "height");
            position = new Vector2(GetIntAttribute(xmlChunk, "x"), GetIntAttribute(xmlChunk, "y"));

            texture = new Texture();
            sprite = new Sprite(256, 256);

            tiles = new Tile[width * height];

            for(int i = 0; i <  tiles.Length; i++)
            {
                tiles[i] = new Tile(0, 0, 16, 16);
            }
        }

        private int GetIntAttribute(XmlNode node, string attrName)
        {
            return int.Parse(node.Attributes.GetNamedItem(attrName).Value); // value is string, needs parsing
        }

        public void Draw()
        {
            sprite.DrawTexture(texture);
        }
    }
}
