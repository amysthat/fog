using fog.Nodes;
using FontStashSharp;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.IO;

namespace fog.Assets
{
    public static partial class AssetPipeline
    {
        private static Dictionary<string, byte[]> rawData = new Dictionary<string, byte[]>();
        private static Dictionary<string, object> parsedData = new Dictionary<string, object>();

        internal static void Initialize()
        {
            rawData.Clear();
            parsedData.Clear();

            var fileCount = 0;
            var totalSize = 0;
            var unparsedFileCount = 0;

            foreach (var file in Directory.GetFiles("data"))
            {
                var fileName = Path.GetFileName(file);

                if (fileName == ".fgproject")
                {
                    rawData.Add(fileName, File.ReadAllBytes(file));
                    parsedData.Add("fgproject", Serialization.Deserialize<ProjectSettings>(file));
                    Logging.Info(nameof(AssetPipeline), "Added .fgproject asset.");
                    continue;
                }

                var fileNameNoExtension = Path.GetFileNameWithoutExtension(file);
                rawData.Add(fileNameNoExtension, File.ReadAllBytes(file));

                Logging.Info(nameof(AssetPipeline), $"Parsing: {fileName}");

                switch (Path.GetExtension(file))
                {
                    case ".txt":
                        var txtFile = TxtFile.FromBytes(rawData[fileNameNoExtension]);
                        parsedData.Add(fileNameNoExtension, txtFile);
                        break;
                    case ".fgnode":
                        var serializedNode = Serialization.Deserialize<SerializedNode>(file);
                        parsedData.Add(fileNameNoExtension, serializedNode);
                        break;
                    case ".ttf":
                        var fontSystem = new FontSystem();
                        fontSystem.AddFont(rawData[fileNameNoExtension]);
                        parsedData.Add(fileNameNoExtension, fontSystem);
                        break;
                    case ".dll": // We do not handle .dll's.
                        break;
                    case ".png":
                        var stream = new MemoryStream(rawData[fileNameNoExtension]);
                        var texture = Texture2D.FromStream(fogEngine.Instance.GraphicsDevice, stream);
                        stream.Dispose();
                        parsedData.Add(fileNameNoExtension, texture);
                        break;
                    default:
                        Logging.Warning(nameof(AssetPipeline), $"Unable to parse \"{fileName}\", unknown file type!");
                        unparsedFileCount++;
                        break;
                }

                totalSize += rawData[fileNameNoExtension].Length;
                fileCount++;
            }

            Logging.Info(nameof(AssetPipeline), $"Initialized. (parsed file count: {fileCount - unparsedFileCount}, unparsed file count: {unparsedFileCount}, total size: {totalSize / 1000} kilobyte(s))");
        }

        public static string GetName(object asset)
        {
            foreach (var pair in parsedData)
            {
                if (pair.Value == asset)
                    return pair.Key;
            }

            return null;
        }

        public static object GetAsset(string name) => parsedData[Path.GetFileNameWithoutExtension(name)];
        public static T GetAsset<T>(string name) => (T)GetAsset(name);
        public static byte[] GetRaw(string name) => rawData[Path.GetFileNameWithoutExtension(name)];

        private static string PrependDataPath(string path) => Path.Combine("data", path);
    }
}