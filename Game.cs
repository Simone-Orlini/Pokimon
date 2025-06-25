using Aiv.Fast2D;
using OpenTK;

namespace Pokimon
{
    public static class Game
    {
        public static Window Window;

        #region Props
        public static float DeltaTime { get { return Window.DeltaTime; } }
        public static float ScreenCenterX { get { return Window.OrthoWidth * 0.5f; } }
        public static float ScreenCenterY { get { return Window.OrthoHeight * 0.5f; } }
        public static Vector2 RelativeMousePosition { get { return Window.MousePosition + new Vector2(currentScene.CameraPosition.X - ScreenCenterX, currentScene.CameraPosition.Y - ScreenCenterY); } }
        public static Vector2 AbsoluteMousePosition { get { return Window.MousePosition; } }
        public static Tileset Tileset { get { return tileset; } set { tileset = value; } }
        public static Vector2 PlayerStartPosition { get; set; }
        public static Scene CurrentScene { get { return currentScene; } }
        #endregion

        private static Tileset tileset;

        private static Scene currentScene;

        public static void Init()
        {
            Window = new Window(1280, 720, "Pokimon");
            Window.SetDefaultViewportOrthographicSize(15); // 16 pixels -> 3 unit (720 / 16 = 45, 45 / 3 = 15)

            InitScenes();
        }

        private static void InitScenes()
        {
            OutsideScene outsideScene = new OutsideScene("Map/XML/map.tmx");
            DungeonScene dungeon = new DungeonScene("Map/XML/dungeon.tmx");

            outsideScene.NextScene = dungeon;
            dungeon.NextScene = outsideScene;

            currentScene = outsideScene;
        }

        public static void Run()
        {
            currentScene.Start();

            while (Window.IsOpened)
            {
                Window.SetTitle($"{1 / DeltaTime}");
                
                if (Window.GetKey(KeyCode.Esc)) return;

                if (!currentScene.IsPlaying)
                {
                    Scene nextScene = currentScene.OnExit();

                    if (nextScene != null)
                    {
                        currentScene = nextScene;
                        currentScene.Start();
                    }
                    else
                    {
                        return;
                    }
                }

                currentScene.Input();

                currentScene.Update();

                currentScene.Draw();

                Window.Update();
            }
        }
    }
}
