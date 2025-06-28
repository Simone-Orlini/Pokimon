using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Pokimon
{
    public class TextChar : Entity
    {
        protected Font font;
        protected char character;

        public char Character { get { return character; } set { character = value; ComputeOffset(); } }

        public TextChar(Vector2 spritePosition, char character, Font f) : base(spritePosition, f.TextureName, spriteWidth : f.CharacterWidth, spriteHeight : f.CharacterHeight, layer : DrawLayer.UI)
        {
            sprite.pivot = Vector2.Zero;
            font = f;

            Character = character;

            IsActive = true;

            DrawManager.AddItem(this);
        }

        protected void ComputeOffset()
        {
            Vector2 textureOffset = font.GetOffset(character);

            textureOffsetX = (int)textureOffset.X;
            textureOffsetY = (int)textureOffset.Y;
        }
    }
}
