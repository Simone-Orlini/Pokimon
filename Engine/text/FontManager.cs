using System;
using System.Collections.Generic;

namespace Pokimon
{
    public static class FontManager
    {
        private static Dictionary<string, Font> fonts;
        private static Font defaultFont;

        static FontManager()
        {
            fonts = new Dictionary<string, Font>();
        }

        public static Font AddFont(string fontName, string texturePath, int numColumns, int firstCharASCIIvalue, float charWidth, float charHeight)
        {
            Font f;

            if (!fonts.ContainsKey(fontName))
            {
                f = new Font(fontName, texturePath, numColumns, firstCharASCIIvalue, charWidth, charHeight);
                fonts.Add(fontName, f);

                if(defaultFont == null)
                {
                    defaultFont = f;
                }
            }
            else
            {
                f = fonts[fontName];
            }

            return f;
        }

        public static Font GetFont(string fontName = "")
        {
            if(fontName != "" && fonts.ContainsKey(fontName))
            {
                return fonts[fontName];
            }

            return defaultFont;
        }
    }
}
