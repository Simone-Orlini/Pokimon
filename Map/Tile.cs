using OpenTK;

namespace Pokimon
{
    public class Tile
    {
        private int id;
        private Tileset tileset;

        public int Width { get { return tileset.TileWidth; } }
        public int Height { get { return tileset.TileHeight; } }
        public int TexturePosition { get { return CalculateTextureCoords(); } }
        public int GridPosition { get { return CalculateTextureCoords(); } }
        public int ID {  get { return id; } }
        public Tileset Tileset { get { return tileset; } }

        public Tile(int id, Tileset tileset)
        {
            this.id = id;
            this.tileset = tileset;
        }

        public int CalculateGridPosition()
        {
            return id;
        }

        public int CalculateTextureCoords()
        {
            return id * Width * Height * 4;
        }
    }
}
