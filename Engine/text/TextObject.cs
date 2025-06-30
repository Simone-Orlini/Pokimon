using OpenTK;
using Aiv.Fast2D;
using System.Collections.Generic;

namespace Pokimon
{
    public class TextObject
    {
        protected List<TextChar> sprites;
        protected Font font;
        protected string text;
        protected bool isActive;
        protected float hSpace; // Horizontal space between characters

        protected Vector2 position;

        public string Text { get { return text; } set { SetText(value); } }

        public bool IsActive { get { return isActive; } set { isActive = value; UpdateCharStatus(); } }

        public Vector2 Position { get { return position; } set {  position = value; } }

        public TextObject(Vector2 position, string textString = "", Font font = null, float horizontalSpacing = 0)
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

            float charX = position.X;
            float charY = position.Y;

            for(int i = 0; i < numChars; i++)
            {
                char c = text[i]; //string as char array

                if (i >= sprites.Count)
                {
                    while (i >= sprites.Count) // When going on a new line needs to get back to the original number of letters
                    {
                        //i is greater than last char index
                        TextChar tc = new TextChar(new Vector2(charX, charY), c, font);
                        tc.IsActive = isActive;
                        sprites.Add(tc);
                    }
                }
                else if (c != sprites[i].Character)
                {
                    //change character
                    sprites[i].Character = c;
                }

                charX += sprites[i].HalfWidth * sprites[i].Scale.X + hSpace; //compute next TextChar position

                if(charX >= Game.CurrentScene.CameraPosition.X + Game.ScreenCenterX) // Go on a new line
                {
                    do
                    {
                        if (text[i] == ' ') // checks to see if the character is space (so it can stop here)
                        {
                            DrawManager.RemoveItem(sprites[i]);
                            sprites.RemoveAt(i);
                            break;
                        }

                        // Remove the letter
                        c = text[i];
                        DrawManager.RemoveItem(sprites[i]);
                        sprites.RemoveAt(i);
                        i--; // decrease i so that the loop can go back to the first letter of the word (when this loop is over) and re-print it on the new line
                    }
                    while (c != ' ');

                    charX = position.X;
                    charY += 1; // Change line
                }
            }

            //check for extra TextChar to remove

            if(sprites.Count > numChars)
            {
                int charsToRemove = sprites.Count - numChars;
                int startCut = numChars;

                sprites.RemoveRange(startCut, charsToRemove);
            }
        }

        public void ClearText()
        {
            sprites.Clear();
            text = "";
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
