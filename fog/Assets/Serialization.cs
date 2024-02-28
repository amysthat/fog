using fog.Entities;
using System.IO;
using System.Text.Json;

namespace fog.Assets
{
    public static partial class AssetPipeline
    {
        internal static class Serialization
        {
            public static JsonSerializerOptions GetOptions()
            {
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                };
                options.Converters.Add(new ComponentListConverter());

                return options;
            }

            public static void Serialize(object thing, string fileName)
            {
                var data = SerializeContent(thing);
                File.WriteAllText(Path.Combine("data", fileName), data);
            }

            public static string SerializeContent(object thing)
            {
                var content = JsonSerializer.Serialize(thing, GetOptions());

                var document = JsonDocument.Parse(content);

                content = JsonSerializer.Serialize(document.RootElement, GetOptions());

                return content;
            }

            public static T Deserialize<T>(string path)
            {
                string content = AssetDirectory.ReadAllText(path);
                return DeserializeContent<T>(content);
            }

            public static T DeserializeContent<T>(string content) => JsonSerializer.Deserialize<T>(content, GetOptions());
        }
    }
}