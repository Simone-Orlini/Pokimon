using Aiv.Fast2D;
using OpenTK;

namespace Pokimon
{
    public abstract class Scene
    {
        public bool IsPlaying;
        public Scene NextScene;
        public Map Map;
        protected Camera camera;

        public Vector2 CameraPosition { get { return GetCameraPosition(); } }
        public Camera Camera { get { return camera; } }

        protected Scene()
        {
            
        }

        public virtual void Start()
        {
            IsPlaying = true;        
        }

        public virtual void LoadAssets()
        {

        }

        public virtual void Input()
        {

        }

        public virtual void Update()
        {
            UpdateManager.Update();
        }

        public virtual void Draw()
        {
            DrawManager.Draw();
        }

        public virtual Scene OnExit()
        {
            IsPlaying = false;

            return NextScene;
        }

        private Vector2 GetCameraPosition()
        {
            return camera.position;
        }
    }
}
