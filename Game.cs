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
        public static Vector2 RelativeMousePosition { get { return Window.MousePosition + new Vector2(Camera.position.X - ScreenCenterX, Camera.position.Y - ScreenCenterY); } }
        public static Vector2 AbsoluteMousePosition { get { return Window.MousePosition; } }
        public static Tileset Tileset { get { return tileset; } set { tileset = value; } }
        public static Vector2 PlayerStartPosition { get; set; }

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

            Map = new Map("Map/XML/map3.tmx");

            player = new Player(PlayerStartPosition);
            Camera.position = player.Position;
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
