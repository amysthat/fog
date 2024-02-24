﻿using fog.Entities;
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

                var fileNameNoExtension = Path.GetFileNameWithoutExtension(file);
                rawData.Add(fileNameNoExtension, File.ReadAllBytes(file));

                Logging.Log($"Parsing: {fileName}");

                switch (Path.GetExtension(file))
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
                        var stream = new MemoryStream(rawData[fileNameNoExtension]);
                        var texture = Texture2D.FromStream(fogEngine.Instance.GraphicsDevice, stream);
                        stream.Dispose();
                        parsedData.Add(fileNameNoExtension, texture);
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

        internal static string PrependDataPath(string path) => Path.Combine("data", path);
    }
}