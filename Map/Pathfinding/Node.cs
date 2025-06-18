using OpenTK;
using System.Collections.Generic;

namespace Pokimon
{
    public class Node
    {
        public List<Node> Neighbours;

        public int X { get; }
        public int Y { get; }

        public int Cost { get; }

        public Node(int x, int y, int cost)
        {
            Neighbours = new List<Node>();
            X = x;
            Y = y;
            Cost = cost;
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
