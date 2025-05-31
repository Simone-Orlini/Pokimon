using Aiv.Fast2D;

namespace Pokimon
{
    public static class Game
    {
        public static Window Window;
        public static float DeltaTime { get { return Window.DeltaTime; } }
        public static float ScreenCenterX { get { return Window.OrthoWidth * 0.5f; } }
        public static float ScreenCenterY { get { return Window.OrthoHeight * 0.5f; } }

        public static void Init()
        {
            Window = new Window(1280, 720, "Pokimon");
            Window.SetDefaultViewportOrthographicSize(15);
        }

        public static void Run()
        {
            Player p = new Player();

            while (Window.IsOpened)
            {
                if (Window.GetKey(KeyCode.Esc)) return;

                p.Input();

                p.Update();

                p.Draw();

                Window.Update();
            }
        }
    }
}
