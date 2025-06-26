using OpenTK;
using System;
using System.Collections.Generic;
using System.Xml;

namespace Pokimon
{
    public class Map : XmlObject
    {
        private Layer[] layers;
        private ObjectGroup[] objectGroups;
        private int mapWidth; // width in tiles
        private int mapHeight; // height in tiles
        private XmlNode mapNode;

        private Tileset tileset;

        public PathfindingMap PathfindingMap;

        public int Width { get { return mapWidth; } }
        public int Height { get { return mapHeight; } }
        public Tileset Tileset {  get { return tileset; } }
        public Vector2 PlayerStart { get; set; }

        public List<EntrancePoint> EntrancePoints { get; set; }

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

            mapNode = mapDocument.SelectSingleNode("map"); // take root node map

            // take attributes (to create the map)
            mapWidth = GetIntAttribute(mapNode, "width");
            mapHeight = GetIntAttribute(mapNode, "height");

            XmlNode xmlTileset = mapNode.SelectSingleNode("tileset");

            tileset = new Tileset(GetIntAttribute(xmlTileset, "tilewidth"), GetIntAttribute(xmlTileset, "tileheight"), GetIntAttribute(xmlTileset, "columns"), GfxManager.GetTexture("tileset"));

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
                    PathfindingMap = new PathfindingMap(mapWidth, mapHeight, GetCells(xmlLayers[i])); // create the pathfinding map
                }
                else
                {
                    layers[i] = new Layer(tileset, xmlLayers[i]);
                }
            }
        }

        public void CreateObjectGroups()
        {
            EntrancePoints = new List<EntrancePoint>();

            // create object groups
            XmlNodeList xmlObjectGroups = mapNode.SelectNodes("objectgroup");

            objectGroups = new ObjectGroup[xmlObjectGroups.Count];

            for (int i = 0; i < xmlObjectGroups.Count; i++)
            {
                objectGroups[i] = new ObjectGroup(xmlObjectGroups[i]);
            }

        }

        public void ChangeCell(Vector2 cellPosition, int oldId, int newId)
        {
            // terribile lo so ma non sapevo come altro fare (pls risparmiate la mia anima :c)
            foreach(Layer layer in layers)
            {
                if(layer == null) continue;

                foreach(Chunk chunk in layer.Chunks)
                {
                    if (cellPosition.X >= chunk.Position.X && cellPosition.X <= chunk.Position.X + chunk.Width)
                    {
                        if (cellPosition.Y >= chunk.Position.Y && cellPosition.Y <= chunk.Position.Y + chunk.Height)
                        {
                            for(int i = 0; i < chunk.Ids.Length; i++)
                            {
                                if(chunk.Ids[i] == oldId)
                                {
                                    chunk.Ids[i] = newId;
                                    return;
                                }
                            }
                        }
                    }
                }
            }
        }

        private Dictionary<Vector2, int> GetCells(XmlNode xmlLayer)
        {
            // variables
            Dictionary<Vector2, int> cells;
            XmlNode data = xmlLayer.SelectSingleNode("data");
            XmlNodeList xmlChunks;

            xmlChunks = data.SelectNodes("chunk");
            Chunk[] chunks = new Chunk[xmlChunks.Count];
            cells = new Dictionary<Vector2, int>();

            for (int i = 0; i < xmlChunks.Count; i++)
            {
                chunks[i] = new Chunk(xmlChunks[i]);
            }

            for (int i = 0; i < chunks.Length; i++)
            {
                for (int j = 0; j < chunks[i].Ids.Length; j++)
                {
                    Vector2 cellPosition = new Vector2(chunks[i].Position.X + (j % chunks[i].Width), chunks[i].Position.Y + (j / chunks[i].Width));

                    cells[cellPosition] = chunks[i].Ids[j];
                }
            }

            return cells;
        }
    }
}
