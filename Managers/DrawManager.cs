using System.Collections.Generic;

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
