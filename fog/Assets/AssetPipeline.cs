using fog.Entities;
using fog.Memory;
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
        }

        internal static void LoadProjectSettings()
        {
            var filePath = "data/.fgproject";

            rawData.Add("fgproject", File.ReadAllBytes(filePath));
            parsedData.Add("fgproject", Serialization.Deserialize<ProjectSettings>(filePath));

            Logging.Log("Loaded project settings.");
        }

        internal static void LoadAllContent()
        {
            var fileCount = 0;
            var totalSize = 0;
            var unparsedFileCount = 0;

            foreach (var file in Directory.GetFiles("data"))
            {
                var fileName = Path.GetFileName(file);

                if (fileName == ".fgproject")
                    continue;

                var fileExtension = Path.GetExtension(file);

                if (fileExtension == ".fgmeta")
                    continue;

                var fileNameNoExtension = Path.GetFileNameWithoutExtension(file);
                rawData.Add(fileNameNoExtension, File.ReadAllBytes(file));

                Logging.Log($"Parsing: {fileName}");

                switch (fileExtension)
                {
                    case ".txt":
                        var txtFile = TxtFile.FromBytes(rawData[fileNameNoExtension]);
                        parsedData.Add(fileNameNoExtension, txtFile);
                        break;
                    case ".ttf":
                        var fontSystem = new FontSystem();
                        fontSystem.AddFont(rawData[fileNameNoExtension]);
                        parsedData.Add(fileNameNoExtension, fontSystem);
                        break;
                    case ".dll": // We do not handle .dll's.
                        break;
                    case ".png":
                        Logging.Debug($"file: {file}");

                        if (!HasMetadata(file))
                        {
                            Logging.Warning($"Cannot parse {fileName}, no metadata is associated with it!");
                            continue;
                        }

                        var metadata = GetMetadata<Sprite>(file, rawData[fileNameNoExtension]);
                        parsedData.Add(fileNameNoExtension, metadata);
                        break;
                    case ".fgentity":
                        parsedData.Add(fileNameNoExtension, Serialization.Deserialize<Entity>(file));
                        break;
                    default:
                        Logging.Warning($"Unable to parse \"{fileName}\", unknown file type!");
                        unparsedFileCount++;
                        break;
                }

                totalSize += rawData[fileNameNoExtension].Length;
                fileCount++;
            }

            Logging.Log($"Initialized. (parsed file count: {fileCount - unparsedFileCount}, unparsed file count: {unparsedFileCount}, total size: {totalSize / 1000} kilobyte(s))");
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

        private static MetadataType GetMetadata<MetadataType>(string file, byte[] data) where MetadataType : Asset
        {
            var metadataName = Path.ChangeExtension(file, "fgmeta");
            var metadataInformation = Serialization.Deserialize<MetadataType>(metadataName);
            metadataInformation.Load(data);

            return metadataInformation;
        }
        private static bool HasMetadata(string file)
        {
            var metadataName = Path.ChangeExtension(file, "fgmeta");
            var exists = File.Exists(metadataName);
            Logging.Debug("Testing metadata existence: " + metadataName);
            Logging.Debug("Exists? " + exists);

            return exists;
        }

        internal static string PrependDataPath(string path) => Path.Combine("data", path);
    }
}