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
            texture = GfxManager.GetFontTexture(f.TextureName);

            sprite.pivot = Vector2.Zero;
            sprite.scale = new Vector2(0.3f, 0.3f);
            font = f;

            Character = character;
        }

        protected void ComputeOffset()
        {
            Vector2 textureOffset = font.GetOffset(character);

            textureOffsetX = textureOffset.X;
            textureOffsetY = textureOffset.Y;
        }
    }
}
