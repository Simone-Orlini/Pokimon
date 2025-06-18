using Aiv.Fast2D;
using OpenTK;

namespace Pokimon
{
    public static class Game
    {
        public static Window Window;
        public static float DeltaTime { get { return Window.DeltaTime; } }
        public static float ScreenCenterX { get { return Window.OrthoWidth * 0.5f; } }
        public static float ScreenCenterY { get { return Window.OrthoHeight * 0.5f; } }
        public static Vector2 MousePosition { get { return Window.MousePosition + new Vector2(Camera.position.X - ScreenCenterX, Camera.position.Y - ScreenCenterY); } }
        public static Tileset Tileset { get { return tileset; } }

        public static Map Map;
        public static Player player;

        public static Camera Camera;

        private static Tileset tileset;

        public static void Init()
        {
            Window = new Window(1280, 720, "Pokimon");
            Window.SetDefaultViewportOrthographicSize(15); // 16 pixels -> 3 unit (720 / 16 = 45, 45 / 3 = 15)

            UpdateManager.Init();
            DrawManager.Init();

            Camera = new Camera();
            Camera.pivot = new Vector2(ScreenCenterX, ScreenCenterY);

            player = new Player();
            Camera.position = player.Position;

            Map = new Map("Map/XML/map3.tmx");
            tileset = Map.Tileset;
        }

        public static void Run()
        {
            while (Window.IsOpened)
            {
                if (Window.GetKey(KeyCode.Esc)) return;

                player.Input();

                player.Update();
                Camera.position = Vector2.Lerp(Camera.position, player.Position, 0.05f);


                DrawManager.Draw();

                Window.Update();
            }
        }
    }
}
