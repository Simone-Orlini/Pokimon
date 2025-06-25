using System.Collections.Generic;

namespace Pokimon
{
    public static class UpdateManager
    {
        private static List<IUpdatable> items;

        public static void Init()
        {
            items = new List<IUpdatable>();
        }

        public static void AddItem(IUpdatable item)
        {
            items.Add(item);
        }

        public static void RemoveItem(IUpdatable item)
        {
            items.Remove(item);
        }

        public static void Update()
        {
            foreach (IUpdatable item in items)
            {
                item.Update();
            }
        }
    }
}
