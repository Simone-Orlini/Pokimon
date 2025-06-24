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
                    objects[i] = new PointObject(xmlObjectGroup.ChildNodes[i]);
                }
            }
        }
    }
}
