using Aiv.Fast2D;
using System;
using System.Collections.Generic;
using System.Xml;

namespace Pokimon
{
    public class Map : IDrawable
    {
        private Layer[] layers;
        private int mapWidth; // width in tiles
        private int mapHeight; // height in tiles

        private Tileset tileset;

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

            XmlNode xmlTileset = mapNode.SelectSingleNode("tilemap");

            tileset = new Tileset(GetIntAttribute(xmlTileset, "tilewidth"), GetIntAttribute(xmlTileset, "tileheight"));

            // get all the layers in the xml
            XmlNodeList xmlLayers = mapNode.SelectNodes("layer");
            
            // create the layers array
            layers = new Layer[xmlLayers.Count];

            for(int i = 0; i < layers.Length; i++)
            {
                // create a layer class for each layer found in the xml
                layers[i] = new Layer(xmlLayers[i]);
            }

            DrawManager.AddItem(this);
        }

        private int GetIntAttribute(XmlNode node, string attrName)
        {
            return int.Parse(node.Attributes.GetNamedItem(attrName).Value); // value is string, needs parsing
        }

        public void Draw()
        {
            for(int i = 0; i < layers.Length; i++)
            {
                foreach(Chunk chunk in layers[i].Chunks)
                {
                    chunk.Draw();
                }
            }
        }
    }
}
