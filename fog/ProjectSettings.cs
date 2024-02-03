using fog.Assets;
using Microsoft.Xna.Framework;
using YamlDotNet.Core.Tokens;

namespace fog
{
    public class ProjectSettings
    {
        public static ProjectSettings Active { get; private set; }

        public Resolution Resolution
        {
            get => _resolution;
            set
            {
                _resolution = value;
                Apply();
            }
        }
        private Resolution _resolution = new Resolution
        {
            Width = 1280,
            Height = 720,
            Fullscreen = false,
        };

        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                Apply();
            }
        }
        private string _title = "fog Application";

        public Color ClearColor { get; set; } = Color.Black;
        public string StartupNode { get; set; } = "";
        public string DefaultFont { get; set; } = "";
        public Color DefaultTextColor { get; set; } = Color.White;
        public string PlayerAssembly { get; set; } = "Game.dll";

        internal void MarkActive()
        {
            if (Active == this)
            {
                Logging.Warning(nameof(ProjectSettings), "MarkActive() called more than once.");
                return;
            }

            Active = this;
            Apply();
            Logging.Info(nameof(ProjectSettings), "Initialized.");
        }

        public void Apply()
        {
            if (Active != this)
                return;

            // Resolution
            fogEngine.Instance.GraphicsDeviceManager.PreferredBackBufferWidth = Resolution.Width;
            fogEngine.Instance.GraphicsDeviceManager.PreferredBackBufferHeight = Resolution.Height;
            fogEngine.Instance.GraphicsDeviceManager.IsFullScreen = Resolution.Fullscreen;
            fogEngine.Instance.GraphicsDeviceManager.ApplyChanges();

            Logging.Info(nameof(ProjectSettings), $"Resolution set to: {Resolution.Width}x{Resolution.Height}:{Resolution.Fullscreen}, with aspect ratio of: {Resolution.AspectRatio}");

            // Title
            fogEngine.Instance.Window.Title = Title;

            Logging.Info(nameof(ProjectSettings), $"Title set to: {Title}");
        }

        public ProjectSettings() { }

        internal static void Initialize()
        {
            AssetPipeline.GetAsset<ProjectSettings>("fgproject").MarkActive();
        }
    }
}