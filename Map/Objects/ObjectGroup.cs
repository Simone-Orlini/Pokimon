using System;
using System.Xml;

namespace Pokimon
{
    public class ObjectGroup
    {
        private Object[] objects;
        
        public Object[] Objects {  get { return objects; } }

        public ObjectGroup(XmlNode xmlObjectGroup) 
        {
            objects = new Object[xmlObjectGroup.ChildNodes.Count];

            for(int i = 0; i < objects.Length; i++)
            {
                string objectName = xmlObjectGroup.ChildNodes[i].Attributes.GetNamedItem("name").Value;

                if (objectName == "PlayerStart")
                {
                    objects[i] = new PlayerPoint(xmlObjectGroup.ChildNodes[i]);
                }
                else if (objectName.Contains("NPC"))
                {
                    objects[i] = new NpcPoint(xmlObjectGroup.ChildNodes[i]);
                }
                else if(objectName.Contains("Entrance"))
                {
                    if (xmlObjectGroup.ChildNodes[i].Attributes.GetNamedItem("type") != null)
                    {
                        string lockedStr = xmlObjectGroup.ChildNodes[i].Attributes.GetNamedItem("type").Value;
                        bool locked = false;

                        if(lockedStr == "Locked")
                        {
                            locked = true;
                        }

                        objects[i] = new EntrancePoint(xmlObjectGroup.ChildNodes[i], locked);
                        continue;
                    }

                    objects[i] = new EntrancePoint(xmlObjectGroup.ChildNodes[i]);
                }
                else
                {
                    Console.WriteLine("Object not found");
                }
            }
        }
    }
}
