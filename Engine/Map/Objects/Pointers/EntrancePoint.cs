using System.Xml;

namespace Pokimon
{
    public class EntrancePoint : PointObject
    {
        public bool Locked { get; set; }

        public EntrancePoint(XmlNode xmlPoint, bool locked = false) : base(xmlPoint)
        {
            Game.CurrentScene.Map.EntrancePoints.Add(this);
            Locked = locked;
        }
    }
}
