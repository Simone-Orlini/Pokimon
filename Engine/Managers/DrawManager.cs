using System.Collections.Generic;
using System.Linq;

namespace Pokimon
{

    public enum DrawLayer { Background, Playground, Foreground, UI, LAST}

    public static class DrawManager
    {
        private static List<IDrawable>[] items;

        public static void Init()
        {
            items = new List<IDrawable>[(int)DrawLayer.LAST];

            for (int i = 0; i < items.Length; i++)
            {
                items[i] = new List<IDrawable>();
            }
        }

        public static void AddItem(IDrawable item)
        {
            items[(int)item.DrawLayer].Add(item);
        }

        public static void RemoveItem(IDrawable item)
        {
            items[(int)item.DrawLayer].Remove(item);
        }

        public static void ClearAll()
        {
            for(int i = 0; i < items.Length; i++)
            {
                items[i].Clear();
            }
        }

        public static bool Contains(IDrawable item, DrawLayer layer)
        {
            for(int i = 0; i < items[(int)layer].Count; i++)
            {
                if (items[(int)layer][i] == item)
                {
                    return true;
                }
            }

            return false;
        }

        public static bool Contains(IDrawable item)
        {
            foreach(List<IDrawable> layer in items)
            {
                for (int i = 0; i < layer.Count; i++)
                {
                    if (items[i] == item)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public static void Draw()
        {
            for(int i = 0; i < (int)DrawLayer.LAST; i++)
            {
                foreach(IDrawable item in items[i])
                {
                    item.Draw();
                }
            }
        }
    }
}
