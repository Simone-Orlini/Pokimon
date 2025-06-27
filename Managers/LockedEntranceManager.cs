using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokimon
{
    public static class LockedEntranceManager
    {
        private static List<EntrancePoint> items;

        public static void Init()
        {
            items = new List<EntrancePoint>();
        }

        public static void AddItem(EntrancePoint item)
        {
            if (item == null) return;
            
            items.Add(item);
        }

        public static EntrancePoint GetItem(EntrancePoint item)
        {
            if (items.Contains(item))
            {
                for(int i = 0; i < items.Count; i++)
                {
                    if(item ==  items[i]) return items[i];
                }
            }

            return null;
        }

        public static void RemoveItem(EntrancePoint item)
        {
            if(item == null) return;

            items.Remove(item);
        }

        public static void ClearAll()
        {
            items.Clear();
        }
    }
}
