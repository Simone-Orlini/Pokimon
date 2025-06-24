using System;
using System.Xml;

namespace Pokimon
{
    public class Object : XmlObject
    {
        protected string name;

        public string Name { get { return name; } }

        public Object(XmlNode xmlObject)
        {
            name = xmlObject.Attributes.GetNamedItem("name").Value;
        }
    }
}
