using System.Xml;
using OpenTK;

namespace Pokimon
{
    public class NpcPoint : PointObject
    {
        Entity entity;

        public NpcPoint(XmlNode xmlPoint) : base(xmlPoint)
        {
            string npcName = xmlPoint.Attributes.GetNamedItem("name").Value;

            if(npcName == "Calloggero")
            {
                entity = new Calloggero(position);
            }
            else if(npcName == "Princess")
            {
                
            }
        }
    }
}
