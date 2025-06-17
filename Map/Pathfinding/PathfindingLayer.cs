using System.Xml;

namespace Pokimon
{
    public class PathfindingLayer : Layer
    {
        public PathfindingLayer(XmlNode xmlLayer) : base(xmlLayer)
        {
            for(int i = 0; i < chunks.Length; i++)
            {
                chunks[i] = new PathfindingChunk(xmlChunks[i]);
            }
        }
    }
}
