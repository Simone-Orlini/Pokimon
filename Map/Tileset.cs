using Aiv.Fast2D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokimon
{
    public struct Tileset
    {
        private int tileWidth;
        private int tileHeight;
        private int cols;
        private Texture tilesetTexture;
        private Tile[] tiles;

        public int TileWidth { get { return tileWidth; } }
        public int TileHeight { get { return tileHeight; } }
        public int Cols { get { return cols; } }
        public Texture TilesetTexture { get { return tilesetTexture; } }
        public Tile[] Tiles { get { return tiles; } }

        public Tileset(int tileWidth, int tileHeight, int cols, string tilesetPath)
        {
            this.tileWidth = tileWidth;
            this.tileHeight = tileHeight;
            tilesetTexture = new Texture(tilesetPath);
            this.cols = cols;

            tiles = new Tile[tilesetTexture.Width * tilesetTexture.Height];

            for(int i = 0; i < tiles.Length; i++)
            {
                tiles[i] = new Tile(i, this);
            }
        }
    }
}
