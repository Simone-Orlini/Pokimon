using Aiv.Fast2D;
using OpenTK;
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Xml;

namespace Pokimon
{
    public class Chunk : IDrawable
    {
        private int width;
        private int height;
        private Tileset tileset;

        private Sprite sprite;
        private Texture texture;

        public int Width { get { return width; } }
        public int Height { get { return height; } }
        public Vector2 Position { get { return sprite.position; } }

        public Chunk(Tileset tileset, XmlNode xmlChunk)
        {
            width = GetIntAttribute(xmlChunk, "width");
            height = GetIntAttribute(xmlChunk, "height");
            
            texture = new Texture(width * tileset.TileWidth, height * tileset.TileHeight);
            sprite = new Sprite(width, height);
            
            sprite.position = new Vector2(GetIntAttribute(xmlChunk, "x"), GetIntAttribute(xmlChunk, "y"));

            this.tileset = tileset;

            string data = xmlChunk.InnerText;

            data = data.Replace("\n\r", "").Replace("\r", "").Replace("\n", "").Replace(" ", "");

            string[] ids = data.Split(',');

            CreateMap(ids);
        }

        private void CreateMap(string[] ids)
        {
            //Draw the tiles on the texture
            byte[] newBitmap = new byte[width * height * tileset.TileWidth * tileset.TileHeight * 4];

            // loop all the tiles in the chunk
            for (int i = 0; i < width * height; i++)
            {
                int currentID = int.Parse(ids[i]) - 1;
                int startPixel = tileset.Tiles[currentID].TexturePosition;
                int tilePosX = (i % width) * tileset.TileWidth;
                int tilePosY = (i / width) * tileset.TileHeight;

                // loop every pixel on the tile texture and position it on the map
                for (int y = 0; y < tileset.TileHeight; y++)
                {
                    for (int x = 0; x < tileset.TileWidth; x++)
                    {
                        int index1 = ((y + tilePosY) * width * tileset.TileHeight + (x + tilePosX)) * 4; // y * width + x, Tile position on the map
                        int index2 = startPixel + (y * tileset.TilesetTexture.Width + x) * 4; // Tile position on the lookup texture (tileset)
                        newBitmap[index1] = tileset.TilesetTexture.Bitmap[index2];
                        newBitmap[index1 + 1] = tileset.TilesetTexture.Bitmap[index2 + 1];
                        newBitmap[index1 + 2] = tileset.TilesetTexture.Bitmap[index2 + 2];
                        newBitmap[index1 + 3] = tileset.TilesetTexture.Bitmap[index2 + 3];
                        //texture.Update(newBitmap);
                        //sprite.DrawTexture(texture);
                        //Game.Window.Update();
                    }
                }
            }

            texture.Update(newBitmap);
        }

        private int GetIntAttribute(XmlNode node, string attrName)
        {
            return int.Parse(node.Attributes.GetNamedItem(attrName).Value); // value is string, needs parsing
        }

        public void Draw()
        {
            sprite.DrawTexture(texture);
            //sprite.DrawWireframe(new Vector4(255, 255, 255, 255));
        }
    }
}
