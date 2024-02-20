using System.IO;
using System.Text.Json;

namespace fog.Assets
{
    public static partial class AssetPipeline
    {
        internal static class Serialization
        {
            public static readonly JsonSerializerOptions Options = new JsonSerializerOptions
            {
                WriteIndented = true,
            };

            public static void Serialize(object thing, string fileName)
            {
                var data = SerializeContent(thing);
                File.WriteAllText(Path.Combine("data", fileName), data);
            }

            public static string SerializeContent(object thing) => JsonSerializer.Serialize(thing, Options);

            public static T Deserialize<T>(string path)
            {
                string content = File.ReadAllText(path);
                return DeserializeContent<T>(content);
            }

            public static T DeserializeContent<T>(string content) => JsonSerializer.Deserialize<T>(content, Options);
        }
    }
}