using OpenTK;
using System;
using System.IO;
using System.Linq;
using System.Xml;

namespace Pokimon
{
    public class Map
    {
        private Layer[] layers;
        private int mapWidth; // width in tiles
        private int mapHeight; // height in tiles

        private Tileset tileset;

        public PathfindingMap PathfindingMap;

        public Tileset Tileset {  get { return tileset; } }
        public Vector2 PlayerStartPosition { get; set; }

        public Map(string xmlFilePath)
        {
            XmlDocument mapDocument;

            mapDocument = new XmlDocument(); // open the document

            try
            {
                mapDocument.Load(xmlFilePath); // load the document
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            XmlNode mapNode = mapDocument.SelectSingleNode("map"); // take root node map

            // take attributes (to create the map)
            mapWidth = GetIntAttribute(mapNode, "width");
            mapHeight = GetIntAttribute(mapNode, "height");

            XmlNode xmlTileset = mapNode.SelectSingleNode("tileset");

            tileset = new Tileset(GetIntAttribute(xmlTileset, "tilewidth"), GetIntAttribute(xmlTileset, "tileheight"), GetIntAttribute(xmlTileset, "columns"), "Assets/TILESET/PixelPackTOPDOWN8BIT.png");

            Game.Tileset = tileset;

            // get all the layers in the xml
            XmlNodeList xmlLayers = mapNode.SelectNodes("layer");
            
            // create the layers array
            layers = new Layer[xmlLayers.Count];

            for(int i = 0; i < layers.Length; i++)
            {
                // create a layer class for each layer found in the xml
                if (xmlLayers[i].Attributes.GetNamedItem("name").Value == "Pathfinding")
                {
                    PathfindingMap = new PathfindingMap(mapWidth, mapHeight, GetNodes(xmlLayers[i])); // create the pathfinding map
                }
                else
                {
                    layers[i] = new Layer(tileset, xmlLayers[i]);
                }
            }
        }

        private int[] GetNodes(XmlNode xmlLayer)
        {
            // variables
            int[] nodes;
            XmlNode data = xmlLayer.SelectSingleNode("data");
            XmlNodeList xmlChunks;
            Chunk[] chunks;

            // Create the chunks
            xmlChunks = data.SelectNodes("chunk");
            chunks = new Chunk[xmlChunks.Count];

            for (int i = 0; i < xmlChunks.Count; i++)
            {
                chunks[i] = new Chunk(xmlChunks[i]);
            }

            // Create the cell array that will generate all the nodes for the pathfinding
            nodes = new int[mapWidth * mapHeight];
            int chunkIndex = 0;

            // Itarate for every line of each chunk
            for (int i = 0; i < chunks.Length * chunks[chunkIndex].Height; i++)
            {
                chunkIndex = i % chunks.Length; // goes from 0 to the number of chunks
                int lineIndex = i / chunks.Length;

                // Iterate for each ID of the current line
                for (int j = 0; j < chunks[chunkIndex].Width; j++)
                {
                    int nodeIndex = i * chunks[chunkIndex].Width + j; // takes the index of the current node
                    int IdIndex = (lineIndex * chunks[chunkIndex].Width + j); // index that allows to read the same line of every chunk (first line of every chunk, then second, then third, and so on)

                    nodes[nodeIndex] = chunks[chunkIndex].Ids[IdIndex]; // takes the same line of all the chunks
                }
            }

            using(StreamWriter writer = new StreamWriter("TextFile.txt"))
            {
                for (int i = 0; i < nodes.Length; i++)
                {
                    if (i % mapWidth == 0 && i != 0)
                    {
                        writer.WriteLine();
                    }

                    writer.Write($"{nodes[i]}, ");
                }
            }

            return nodes;
        }

        private int GetIntAttribute(XmlNode node, string attrName)
        {
            return int.Parse(node.Attributes.GetNamedItem(attrName).Value); // value is string, needs parsing
        }
    }
}