using fog.Assets;
using fog.Nodes;
using FontStashSharp;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace fog
{
#pragma warning disable IDE1006 // Naming Styles
    public class fog : Game
#pragma warning restore IDE1006 // Naming Styles
    {
        internal static fog Instance { get; private set; }

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        internal new GraphicsDevice GraphicsDevice => base.GraphicsDevice;
        internal GraphicsDeviceManager GraphicsDeviceManager => _graphics;

        public static float DeltaTime { get; private set; }
        public static float TotalTime { get; private set; }

        public static FontSystem DefaultFont { get; private set; }

        public fog()
        {
            if (Instance is not null)
            {
                Logging.Error("Multiple fog instances!");
                return;
            }

            Instance = this;

            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            AssetPipeline.Initialize();
            ProjectSettings.Initialize();
            Assemblies.LoadPlayerAssembly(AssetPipeline.GetRaw(ProjectSettings.Active.PlayerAssembly));

            DefaultFont = AssetPipeline.GetAsset<FontSystem>(ProjectSettings.Active.DefaultFont);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            RuntimeGraphics.Initialize(_spriteBatch); // This feels off. Initializing in LoadContent() shouldn't be a thing, but spriteBatch is initialized here?

            if (ProjectSettings.Active.StartupNode == "")
                Logging.Error(nameof(fog), "Startup node not set!");
            else
                World.ImportNode(AssetPipeline.GetAsset<SerializedNode>(ProjectSettings.Active.StartupNode));
        }

        protected override void Update(GameTime gameTime)
        {
            DeltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            TotalTime = (float)gameTime.TotalGameTime.TotalSeconds;

            Input.Update();

            World.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(ProjectSettings.Active.ClearColor);

            _spriteBatch.Begin();
            World.Draw();
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}