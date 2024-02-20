using fog.BuiltinComponents;
using fog.Nodes;
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
            entity.AddComponent<SpriteComponent>();
            entity.AddComponent<TestComponent>();

            AssetPipeline.Serialization.Serialize(entity, "test.fgentity");
        }

        private class TestComponent : Entities.Component
        {
            public string yesdatahere;
            public string YesMoreDataHere { get; set; }
            public Vector2 test;
        }
    }
}