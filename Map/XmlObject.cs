using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Pokimon
{
    public class XmlObject
    {
        public XmlObject()
        {

        }

        protected int GetIntAttribute(XmlNode node, string attrName)
        {
            return int.Parse(node.Attributes.GetNamedItem(attrName).Value); // value is string, needs parsing
        }
    }
}
