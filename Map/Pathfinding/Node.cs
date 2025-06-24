using System.Collections.Generic;

namespace Pokimon
{
    public class Node
    {
        public List<Node> Neighbours;

        public DrawLayer DrawLayer { get; }

        public int X { get; }
        public int Y { get; }

        public float XOffset { get { return X + 0.5f; } }
        public float YOffset { get { return Y + 0.5f; } }

        public int Cost { get; }

        public Node(int x, int y, int cost)
        {
            Neighbours = new List<Node>();
            X = x;
            Y = y;
            Cost = cost;
            DrawLayer = DrawLayer.Foreground;
        }

        public void AddNeighbour(Node node)
        {
            Neighbours.Add(node);
        }

        public void RemoveNeighbour(Node node)
        {
            Neighbours.Remove(node);
        }
    }
}
