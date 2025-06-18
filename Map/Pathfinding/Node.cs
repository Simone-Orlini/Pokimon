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

        public int Cost { get; }

        public Node(int x, int y, int cost)
        {
            Neighbours = new List<Node>();
            X = x + (int)(Game.Tileset.TileWidth * 0.5f);
            Y = y + (int)(Game.Tileset.TileHeight * 0.5f);
            Cost = cost;
            DrawLayer = DrawLayer.UI;
            sprite = new Sprite(0.5f, 0.5f);
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
            sprite.DrawColor(255, 255, 255);
        }
    }
}
