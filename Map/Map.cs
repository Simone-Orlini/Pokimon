using Aiv.Fast2D;
using OpenTK;
using System;
using System.Collections.Generic;
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

            // get all the layers in the xml
            XmlNodeList xmlLayers = mapNode.SelectNodes("layer");
            
            // create the layers array
            layers = new Layer[xmlLayers.Count];

            for(int i = 0; i < layers.Length; i++)
            {
                // create a layer class for each layer found in the xml
                if (xmlLayers[i].Attributes.GetNamedItem("name").Value == "Pathfinding")
                {
                    PathfindingMap = new PathfindingMap(mapWidth, mapHeight, GetCells(xmlLayers[i]));
                }
                else
                {
                    layers[i] = new Layer(tileset, xmlLayers[i]);
                }
            }
        }

        private int[] GetCells(XmlNode xmlLayer)
        {
            // variables
            int[] cells;
            XmlNode data = xmlLayer.SelectSingleNode("data");
            XmlNodeList xmlChunks;
            Chunk[] chunks;
            

            xmlChunks = data.SelectNodes("chunk");
            chunks = new Chunk[xmlChunks.Count];

            for (int i = 0; i < xmlChunks.Count; i++)
            {
                chunks[i] = new Chunk(xmlChunks[i]);
            }

            cells = new int[chunks.Length * chunks[0].Width * chunks[0].Height];

            for (int i = 0; i < chunks.Length; i++)
            {
                cells[i] = chunks[i].Ids[i];
            }

            return cells;
        }

        private int GetIntAttribute(XmlNode node, string attrName)
        {
            return int.Parse(node.Attributes.GetNamedItem(attrName).Value); // value is string, needs parsing
        }
    }
}
