namespace Pokimon
{
    public interface IDrawable
    {
        DrawLayer DrawLayer { get; }

        void Draw();
    }
}
