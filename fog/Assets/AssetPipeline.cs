using fog.Entities;
using fog.Memory;
using FontStashSharp;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;

namespace fog.Assets
{
    public static partial class AssetPipeline
    {
        private static Dictionary<string, byte[]> rawData = new Dictionary<string, byte[]>();
        private static Dictionary<string, object> parsedData = new Dictionary<string, object>();

        public static ProjectSettings? ProjectSettings { get; private set; }

        internal static void Initialize()
        {
            rawData.Clear();
            parsedData.Clear();
        }

        internal static void LoadProjectSettings()
        {
            var file = ".fgproject";

            rawData.Add("fgproject", AssetDirectory.ReadAllBytes(file));
            ProjectSettings = Serialization.Deserialize<ProjectSettings>(file);

            Logging.Log("Loaded project settings.");
        }

        internal static void LoadAllContent()
        {
            foreach (var file in AssetDirectory.GetFiles())
            {
                HandleFile(file);
            }

            Logging.Log($"Initialized.");
        }
    }
}