using System.Collections.Generic;

namespace Pokimon
{
    public static class DrawManager
    {
        private static List<IDrawable> items;

        public static void Init()
        {
            items = new List<IDrawable>();
        }

        public static void AddItem(IDrawable item)
        {
            items.Add(item);
        }

        public static void RemoveItem(IDrawable item)
        {
            items.Remove(item);
        }

        public static void Draw()
        {
            foreach(IDrawable item in items)
            {
                item.Draw();
            }
        }
    }
}
