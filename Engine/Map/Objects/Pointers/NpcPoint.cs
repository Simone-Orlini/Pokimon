using System.Xml;
using OpenTK;

namespace Pokimon
{
    public class NpcPoint : PointObject
    {
        Entity entity;

        public Entity Entity { get { return entity; } }

        public NpcPoint(XmlNode xmlPoint) : base(xmlPoint)
        {
            name = name.Substring(3);

            if(name == "Calloggero")
            {
                entity = new Calloggero(position);
            }
            else if(name == "Princess")
            {
                entity = new Princess(position);
            }
        }
    }
}
