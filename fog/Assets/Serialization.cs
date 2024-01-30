using Microsoft.Xna.Framework;
using System.IO;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace fog.Assets
{
    public static partial class AssetPipeline
    {
        internal static class Serialization
        {
            private static ISerializer Serializer = new SerializerBuilder()
                .WithNamingConvention(UnderscoredNamingConvention.Instance)
                .WithTagMapping("!vector2", typeof(Vector2))
                .WithTagMapping("!color", typeof(Color))
                .WithTagMapping("!assetref", typeof(AssetRef))
                .WithTagMapping("!float", typeof(float))
                .WithTagMapping("!bool", typeof(bool))
                .Build();

            private static IDeserializer Deserializer = new DeserializerBuilder()
                .WithNamingConvention(UnderscoredNamingConvention.Instance)
                .WithTagMapping("!vector2", typeof(Vector2))
                .WithTagMapping("!color", typeof(Color))
                .WithTagMapping("!assetref", typeof(AssetRef))
                .WithTagMapping("!float", typeof(float))
                .WithTagMapping("!bool", typeof(bool))
                .Build();

            public static string SerializeContent(object graph) => Serializer.Serialize(graph);

            public static T Deserialize<T>(string path)
            {
                string content = File.ReadAllText(path);
                return Deserializer.Deserialize<T>(content);
            }

            public static T DeserializeContent<T>(string content) => Deserializer.Deserialize<T>(content);
        }
    }
}