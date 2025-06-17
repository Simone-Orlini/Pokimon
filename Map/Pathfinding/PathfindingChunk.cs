using OpenTK;
using System.Reflection;
using System.Xml;

namespace Pokimon
{
    public class PathfindingChunk : Chunk
    {
        private Node[] nodes;
        private Vector2 position;

        public override Vector2 Position { get { return position; } }

        public PathfindingChunk(XmlNode xmlChunk) : base(xmlChunk)
        {
            position = new Vector2(GetIntAttribute(xmlChunk, "x"), GetIntAttribute(xmlChunk, "y"));

            string data = xmlChunk.InnerText;

            data = data.Replace("\n\r", "").Replace("\r", "").Replace("\n", "").Replace(" ", "");

            string[] ids = data.Split(',');

            Vector2[] nodePositions = new Vector2[ids.Length];

            int nodeCount = 0;

            for (int i = 0; i < ids.Length; i++)
            {
                int id = int.Parse(ids[i]) - 1;

                int x = i % width;
                int y = i / height;

                if (id > 1) continue;

                nodePositions[nodeCount] = new Vector2(x, y);

                nodeCount++;
            }

            nodes = new Node[nodeCount];

            for(int i = 0; i < nodeCount; i++)
            {
                nodes[i] = new Node(nodePositions[i]);
            }
        }
    }
}
