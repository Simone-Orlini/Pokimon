using Aiv.Fast2D;
using OpenTK;
using System.Collections.Generic;

namespace Pokimon
{
    public class Node : IDrawable
    {
        public List<Node> Neighbours;

        Sprite sprite;
        public DrawLayer DrawLayer { get; }

        public int X { get; }
        public int Y { get; }

        public float NodeCenterX { get { return X + (Game.Tileset.TileWidth * 0.5f) / Game.Tileset.TileWidth; } }
        public float NodeCenterY { get { return Y + (Game.Tileset.TileHeight * 0.5f) / Game.Tileset.TileHeight; } }

        public int Cost { get; }

        public Node(int x, int y, int cost)
        {
            Neighbours = new List<Node>();
            X = x;
            Y = y;
            Cost = cost;
            DrawLayer = DrawLayer.Foreground;
            sprite = new Sprite(0.8f, 0.8f);
            sprite.position = new Vector2(X, Y);
            DrawManager.AddItem(this);
        }

        public void AddNeighbour(Node node)
        {
            Neighbours.Add(node);
        }

        public void RemoveNeighbour(Node node)
        {
            Neighbours.Remove(node);
        }

        public void Draw()
        {
            if(Cost < int.MaxValue)
            {
                sprite.DrawColor(0, 255, 0, 70);
            }
            else
            {
                sprite.DrawColor(255, 0, 0, 70);
            }
        }
    }
}
