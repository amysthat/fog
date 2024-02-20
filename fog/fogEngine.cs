using fog.Assets;
using fog.Nodes;
using FontStashSharp;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace fog
{
#pragma warning disable IDE1006 // Naming Styles
    public class fogEngine : Game
#pragma warning restore IDE1006 // Naming Styles
    {
        internal static fogEngine Instance { get; private set; }

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        internal new GraphicsDevice GraphicsDevice => base.GraphicsDevice;
        internal GraphicsDeviceManager GraphicsDeviceManager => _graphics;

        public static float DeltaTime { get; private set; }
        public static float TotalTime { get; private set; }

        public static FontSystem DefaultFont { get; private set; }

        public fogEngine()
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
            if (Generator.ShouldGenerate())
            {
                Generator.Generate();
                Logging.Success("Generated.");
                Exit();
                return;
            }

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
                Logging.Error(nameof(fogEngine), "Startup node not set!");
            //else
            //    World.ImportNode(AssetPipeline.GetAsset<SerializedNode>(ProjectSettings.Active.StartupNode));

            var e = World.Add("Test Entity");
            e.AddComponent<BuiltinComponents.SpriteComponent>();
            e.AddComponent<test_c>();

            Logging.Info(AssetPipeline.Serialization.SerializeContent(e));
        } public class test_c : Entities.Component { }

        protected override void Update(GameTime gameTime)
        {
            DeltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            TotalTime = (float)gameTime.TotalGameTime.TotalSeconds;

            Input.Update();

            //World.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(ProjectSettings.Active.ClearColor);

            _spriteBatch.Begin();
            //World.Draw();
            _spriteBatch.End();

            base.Draw(gameTime);
        }

        protected override void OnExiting(object sender, EventArgs args)
        {
            Logging.Info("fog Engine", "Exit queued.");
            World.DestroyAllEntities();
        }

        public static void Quit()
        {
            Instance.Exit();
        }
    }
}