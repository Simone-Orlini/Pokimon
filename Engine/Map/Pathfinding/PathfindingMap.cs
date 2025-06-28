using System;
using System.Collections.Generic;
using OpenTK;

namespace Pokimon
{
    public class PathfindingMap
    {
        //pathfinding
        Dictionary<Node, Node> cameFrom;    // parents
        Dictionary<Node, int> costSoFar;    // distances
        PriorityQueue frontier;             // toVisit

        // Map
        int width, height;
        Dictionary<Vector2, int> cells;

        public Node[] Nodes { get; }

        public PathfindingMap(int width, int height, Dictionary<Vector2, int> cells)
        {
            this.width = width;
            this.height = height;
            this.cells = cells;

            Nodes = new Node[this.cells.Count];

            // build Nodes from cells
            foreach(var cell in this.cells)
            {
                int x = (int)cell.Key.X;
                int y = (int)cell.Key.Y;

                //if (cell.Value > 2)
                //{
                //    Nodes[y * width + x] = new Node(x, y, int.MaxValue);
                //    continue;
                //}

                Nodes[y * width + x] = new Node(x, y, cell.Value);
            }

            foreach(Node node in Nodes)
            {
                AddNeighbours(node, node.X, node.Y);
            }
        }

        private void AddNeighbours(Node node, int x, int y)
        {
            // Check neighbpurs in each direction

            // TOP
            CheckNeighbours(node, x, y - 1);
            // BOTTOM
            CheckNeighbours(node, x, y + 1);
            // LEFT
            CheckNeighbours(node, x - 1, y);
            // RIGHT
            CheckNeighbours(node, x + 1, y);
        }

        private void CheckNeighbours(Node node, int cellX, int cellY)
        {
            // Returns if x is outside the hor boundaries
            if (cellX < 0 || cellX >= width)
            {
                return;
            }
            // Returns if y is outside the ver boundaries
            if (cellY < 0 || cellY >= height)
            {
                return;
            }

            Node neighbour = Nodes[cellY * width + cellX];

            if (neighbour.Cost != int.MaxValue)
            {
                node.AddNeighbour(neighbour);
            }
        }

        public void ChangeNode(Vector2 nodePosition, int newValue)
        {
            for(int i = 0; i < Nodes.Length; i++)
            {
                if (Nodes[i].XOffset == nodePosition.X && Nodes[i].YOffset == nodePosition.Y)
                {
                    Nodes[i].ChangeCost(newValue);

                    for(int j = 0; j < Nodes[i].Neighbours.Count; j++)
                    {
                        if(newValue < int.MaxValue)
                        {
                            Nodes[i].Neighbours[j].AddNeighbour(Nodes[i]);
                        }
                        else
                        {
                            Nodes[i].Neighbours[j].RemoveNeighbour(Nodes[i]);
                        }
                    }
                    break;
                }
            }
        }

        public List<Node> GetPath(int startX, int startY, int endX, int endY)
        {
            List<Node> path = new List<Node>();

            Node start = GetNode(startX, startY);
            Node end = GetNode(endX, endY);

            if (start.Cost == int.MaxValue || end.Cost == int.MaxValue)
            {
                return path;
            }

            AStar(start, end);

            if (!cameFrom.ContainsKey(end))
            {
                return path;
            }

            Node currNode = end;

            while (currNode != cameFrom[currNode])
            {
                path.Add(currNode);
                currNode = cameFrom[currNode];
            }

            path.Reverse();

            return path;
        }

        private Node GetNode(int x, int y)
        {
            if (x < 0 || x >= width)
            {
                return null;
            }

            if (y < 0 || y >= height)
            {
                return null;
            }

            return Nodes[y * width + x];
        }

        private void AStar(Node start, Node end)
        {
            cameFrom = new Dictionary<Node, Node>();
            costSoFar = new Dictionary<Node, int>();
            frontier = new PriorityQueue();

            cameFrom[start] = start;
            costSoFar[start] = 0;
            frontier.Enqueue(start, Heuristic(start, end));

            while (!frontier.IsEmpty)
            {
                Node currNode = frontier.Dequeue();

                if (currNode == end)
                {
                    return;
                }

                foreach (Node nextNode in currNode.Neighbours)
                {
                    int newCost = costSoFar[currNode] + nextNode.Cost;

                    if (!costSoFar.ContainsKey(nextNode) || costSoFar[nextNode] > newCost)
                    {
                        cameFrom[nextNode] = currNode;
                        costSoFar[nextNode] = newCost;
                        int priority = newCost + Heuristic(nextNode, end);
                        frontier.Enqueue(nextNode, priority);
                    }
                }
            }
        }

        // Manhattan Distance
        private int Heuristic(Node start, Node end)
        {
            return Math.Abs(start.X - end.X) + Math.Abs(start.Y - end.Y);
        }
    }
}
