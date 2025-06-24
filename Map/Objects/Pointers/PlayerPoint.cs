using System.Xml;

namespace Pokimon
{
    public class PlayerPoint : PointObject
    {
        public PlayerPoint(XmlNode xmlPoint) : base(xmlPoint)
        {
            Game.CurrentScene.Map.PlayerStart = position;
        }
    }
}
