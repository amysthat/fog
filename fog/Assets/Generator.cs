using fog.BuiltinComponents;
using fog.Entities;
using Microsoft.Xna.Framework;
using System.IO;

namespace fog.Assets
{
    internal static class Generator
    {
        public static bool ShouldGenerate() => File.Exists("data/.generate");

        public static void Generate()
        {
            var settings = new ProjectSettings();
            AssetPipeline.Serialization.Serialize(settings, ".fgproject");

            var entity = World.Add();
            entity.Get().AddComponent<SpriteComponent>();
            entity.Get().AddComponent<TestComponent>();

            AssetPipeline.Serialization.Serialize(entity, "test.fgentity");
        }

        private class TestComponent : Component
        {
            public string yesdatahere;
            public string YesMoreDataHere { get; set; }
            public Vector2 test;
        }
    }
}