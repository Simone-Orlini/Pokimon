using System.Xml;

namespace Pokimon
{
    public class Layer
    {
        protected XmlNode xmlLayer;
        protected XmlNodeList xmlChunks;
        protected Chunk[] chunks;

        public Chunk[] Chunks { get { return chunks; } }

        public Layer(Tileset tileset, XmlNode xmlLayer)
        {
            this.xmlLayer = xmlLayer;

            XmlNode data = xmlLayer.SelectSingleNode("data");

            xmlChunks = data.SelectNodes("chunk");

            chunks = new Chunk[xmlChunks.Count];

            for(int i = 0; i <  chunks.Length; i++)
            {
                chunks[i] = new Chunk(tileset, xmlChunks[i]);
            }
        }

        public Layer(XmlNode xmlLayer)
        {
            this.xmlLayer = xmlLayer;

            XmlNode data = xmlLayer.SelectSingleNode("data");

            xmlChunks = data.SelectNodes("chunk");

            chunks = new Chunk[xmlChunks.Count];
        }
    }
}
