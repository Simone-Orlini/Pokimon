﻿using Aiv.Fast2D;
using OpenTK;
using System.Xml;

namespace Pokimon
{
    public class Chunk : XmlObject, IDrawable
    {
        protected int width;
        protected int height;
        protected Tileset tileset;
        protected DrawLayer drawLayer;
        protected bool isActive;

        private Sprite sprite;
        private Texture texture;
        private int[] ids;

        public int Width { get { return width; } }
        public int Height { get { return height; } }
        public virtual Vector2 Position { get { return sprite.position; } }
        public DrawLayer DrawLayer { get { return drawLayer; } }
        public int[] Ids { get { return ids; } }
        public Texture Texture { get { return texture; } }

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

            string[] StringIds = data.Split(',');

            ids = new int[StringIds.Length];

            for(int i = 0; i < StringIds.Length; i++)
            {
                ids[i] = int.Parse(StringIds[i]);
            }

            drawLayer = DrawLayer.Background;

            DrawManager.AddItem(this);

            CreateMap();
        }

        public Chunk(XmlNode xmlChunk)
        {
            width = GetIntAttribute(xmlChunk, "width");
            height = GetIntAttribute(xmlChunk, "height");

            string data = xmlChunk.InnerText;

            data = data.Replace("\n\r", "").Replace("\r", "").Replace("\n", "").Replace(" ", "");

            sprite = new Sprite(width, height);

            sprite.position = new Vector2(GetIntAttribute(xmlChunk, "x"), GetIntAttribute(xmlChunk, "y"));

            string[] StringIds = data.Split(',');

            ids = new int[StringIds.Length];

            for (int i = 0; i < StringIds.Length; i++)
            {
                ids[i] = int.Parse(StringIds[i]);
            }
        }

        public void CreateMap()
        {
            //Draw the tiles on the texture
            byte[] newBitmap = new byte[width * height * tileset.TileWidth * tileset.TileHeight * 4];

            // loop all the tiles in the chunk
            for (int i = 0; i < width * height; i++)
            {
                int currentID = ids[i] - 1;
                int startPixel = tileset.Tiles[currentID].TexturePosition;
                int tilePosX = (i % width) * tileset.TileWidth;
                int tilePosY = (i / width) * tileset.TileHeight;

                // loop every pixel on the tile texture and position it on the map
                for (int y = 0; y < tileset.TileHeight; y++)
                {
                    for (int x = 0; x < tileset.TileWidth; x++)
                    {
                        //calculate the index of every pixel in the tile and take it from the tileset to be copied on the chunk texture

                        int pixelOnMapPosition = ((tilePosY + y) * width * tileset.TileHeight + (x + tilePosX)) * 4; // y * width + x, Tile position on the map -> tilePosY + y to get the y coordinate of the pixel (tileY + pixelY), width * tileHeight is beacause otherwise every line of pixels will override each other, * 4 is to get rgba
                        int pixelOnTexturePosition = (startPixel + x + (y * tileset.TilesetTexture.Width)) * 4; // Tile position on the lookup texture (tileset)
                        newBitmap[pixelOnMapPosition] = tileset.TilesetTexture.Bitmap[pixelOnTexturePosition];
                        newBitmap[pixelOnMapPosition + 1] = tileset.TilesetTexture.Bitmap[pixelOnTexturePosition + 1];
                        newBitmap[pixelOnMapPosition + 2] = tileset.TilesetTexture.Bitmap[pixelOnTexturePosition + 2];
                        newBitmap[pixelOnMapPosition + 3] = tileset.TilesetTexture.Bitmap[pixelOnTexturePosition + 3];
                    }
                }
            }

            texture.Update(newBitmap);
        }

        public void Draw()
        {
            bool chunkOutsideViewX = (sprite.position.X < Game.CurrentScene.CameraPosition.X - Game.CurrentScene.Camera.pivot.X && sprite.position.X + width < Game.CurrentScene.CameraPosition.X - Game.CurrentScene.Camera.pivot.X) || (sprite.position.X > Game.CurrentScene.CameraPosition.X + Game.CurrentScene.Camera.pivot.X);
            bool chunkOutsideViewY = (sprite.position.Y < Game.CurrentScene.CameraPosition.Y - Game.CurrentScene.Camera.pivot.Y && sprite.position.Y + height < Game.CurrentScene.CameraPosition.Y - Game.CurrentScene.Camera.pivot.Y) || (sprite.position.Y > Game.CurrentScene.CameraPosition.Y + Game.CurrentScene.Camera.pivot.Y);

            if (chunkOutsideViewY || chunkOutsideViewX)
            {
                isActive = false;
                return;
            }
            else
            {
                isActive = true;
            }

            sprite.DrawTexture(texture);
        }
    }
}
