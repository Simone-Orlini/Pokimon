using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Pokimon
{
    public class TextObject
    {
        protected List<TextChar> sprites;
        protected Font font;
        protected string text;
        protected bool isActive;
        protected int hSpace; // Horizontal space between characters

        protected Vector2 position;

        public string Text { get { return text; } set { SetText(value); } }

        public bool IsActive { get { return isActive; } set { isActive = value; UpdateCharStatus(); } }

        public TextObject(Vector2 position, string textString = "", Font font = null, int horizontalSpacing = 0)
        {
            this.position = position;
            hSpace = horizontalSpacing;

            if(font == null)
            {
                this.font = FontManager.GetFont(""); //default font
            }
            else
            {
                this.font = font;
            }

            sprites = new List<TextChar>();

            if(textString != "")
            {
                SetText(textString);
            }
        }

        public void SetText(string newText)
        {
            if(newText == text) return;

            text = newText;
            int numChars = text.Length;

            int charX = (int)position.X;
            int charY = (int)position.Y;

            for(int i = 0; i <  numChars; i++)
            {
                char c = text[i]; //string as char array

                if(i >= sprites.Count)
                {
                    //i is greater than last char index
                    TextChar tc = new TextChar(new Vector2(charX, charY), c, font);
                    tc.IsActive = isActive;
                    sprites.Add(tc);
                }
                else if(c != sprites[i].Character)
                {
                    //change character
                    sprites[i].Character = c;
                }

                charX += (int)sprites[i].HalfWidth * 2 + hSpace; //compute next TextChar position
            }

            //check for extra TextChar to remove

            if(sprites.Count > numChars)
            {
                int charsToRemove = sprites.Count - numChars;
                int startCut = numChars;

                sprites.RemoveRange(startCut, charsToRemove);
            }
        }

        protected void UpdateCharStatus()
        {
            for (int i = 0; i < sprites.Count; i++)
            {
                sprites[i].IsActive = isActive;
            }
        }
    }
}
