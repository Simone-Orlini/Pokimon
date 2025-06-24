using Aiv.Fast2D;

namespace Pokimon
{
    public struct Tileset
    {
        private int tileWidth;
        private int tileHeight;
        private int cols;
        private Texture texture;
        private Tile[] tiles;

        public int TileWidth { get { return tileWidth; } }
        public int TileHeight { get { return tileHeight; } }
        public int Cols { get { return cols; } }
        public Texture TilesetTexture { get { return texture; } }
        public Tile[] Tiles { get { return tiles; } }

        public Tileset(int tileWidth, int tileHeight, int cols, Texture tilesetTexture)
        {
            this.tileWidth = tileWidth;
            this.tileHeight = tileHeight;
            texture = tilesetTexture;
            this.cols = cols;

            int tileNum = (texture.Width / tileWidth) * (texture.Height / tileHeight);

            tiles = new Tile[tileNum];

            for(int i = 0; i < tiles.Length; i++)
            {
                tiles[i] = new Tile(i, this);
            }
        }
    }
}
