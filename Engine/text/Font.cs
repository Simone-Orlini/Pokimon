using Aiv.Fast2D;
using OpenTK;
using System;

namespace Pokimon
{
    public class Font
    {
        protected int numCol;
        protected int firstVal; //ASCII value of the first char in the spritesheet

        public string TextureName { get; protected set; }
        public Texture Texture { get; protected set; }

        public float CharacterWidth { get; protected set; }
        public float CharacterHeight { get; protected set; }

        public Font(string texureName, string texturePath, int numColumns, int firstCharASCIIvalue, float charWidth, float charHeight)
        {
            TextureName = texureName;
            Texture = GfxManager.AddFontTexture(texureName, texturePath);
            numCol = numColumns;
            firstVal = firstCharASCIIvalue;
            CharacterWidth = charWidth;
            CharacterHeight = charHeight;
        }

        public virtual Vector2 GetOffset(char c) //Return the coordinates of the given char
        {
            int cVal = c; //implicit conversion from char to int
            int delta = cVal - firstVal;

            int y = delta / numCol;
            int x = delta % numCol;

            return new Vector2(x * CharacterWidth, y * CharacterHeight);
        }
    }
}
