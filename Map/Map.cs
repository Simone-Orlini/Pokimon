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

        private PathfindingMap pathfindingMap;

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
                    layers[i] = new PathfindingLayer(xmlLayers[i]);
                }
                else
                {
                    layers[i] = new Layer(tileset, xmlLayers[i]);
                }
            }
        }

        private int GetIntAttribute(XmlNode node, string attrName)
        {
            return int.Parse(node.Attributes.GetNamedItem(attrName).Value); // value is string, needs parsing
        }
    }
}
