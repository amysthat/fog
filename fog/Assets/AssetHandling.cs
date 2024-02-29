using fog.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace fog.Assets;

public partial class AssetPipeline
{
    private static void HandleFile(string file)
    {
        var fileExtension = Path.GetExtension(file);
        var assetPipelineFriendlyName = Path.GetFileNameWithoutExtension(file);

        if (file == ".fgproject") // Project Settings are an exception, and are handled by AssetPipeline.
            return;

        if (fileExtension == ".fgmeta") // Meta files are only taken into consideration when their respective file is read.
            return;

        if (fileExtension == ".dll") // .dll files need not be handled.
            return;

        rawData.Add(assetPipelineFriendlyName, AssetDirectory.ReadAllBytes(file));

        Logging.Log($"Parsing: {file}");

        if (fileExtension == ".fgentity")
        {
            parsedData.Add(assetPipelineFriendlyName, Serialization.Deserialize<Entity>(file));
            return;
        }

        if (!HasMetadata(file))
        {
            Logging.Warning($"Cannot parse {file}, no metadata is associated with it!");
            return;
        }

        if (AssetHandling.CanFileBeHandled(file))
        {
            AssetHandling.HandleFile(file);
        }
        else
        {
            Logging.Warning($"Unable to parse \"{file}\", unknown file type!");
        }
    }

    internal static class AssetHandling
    {
        public static Dictionary<string, Func<(string file, string assetPipelineFriendlyName, byte[] data), Asset>> FileHandlingLookup = new()
        {
            { ".txt", HandleTxtFile },
            { ".ttf", HandleFontFile },
            { ".png", HandleSpriteFile },
        };

        public static Dictionary<string, Type> FileTypeLookup = new()
        {
            { ".txt", typeof(TxtFile) },
            { ".ttf", typeof(Font) },
            { ".png", typeof(Sprite) },
        };

        public static Type GetFileType(string file)
        {
            var extension = Path.GetExtension(file);

            return FileTypeLookup[extension];
        }

        public static bool CanFileBeHandled(string file)
        {
            var extension = Path.GetExtension(file);

            if (extension == ".fgentity")
            {
                return true;
            }

            return FileHandlingLookup.Keys.ToList().Contains(extension);
        }

        public static void HandleFile(string file)
        {
            var assetPipelineFriendlyName = Path.GetFileNameWithoutExtension(file);
            var data = rawData[assetPipelineFriendlyName];

            var asset = ParseFile(file, data);

            parsedData.Add(assetPipelineFriendlyName, asset);
        }

        internal static Asset ParseFile(string file, byte[] data)
        {
            var extension = Path.GetExtension(file);

            var assetPipelineFriendlyName = Path.GetFileNameWithoutExtension(file);

            var tuple = (file, assetPipelineFriendlyName, data);

            return FileHandlingLookup[extension](tuple);
        }

        private static Asset HandleTxtFile((string file, string assetPipelineFriendlyName, byte[] data) tuple)
        {
            return GetMetadata<TxtFile>(tuple.file, tuple.data);
        }

        private static Asset HandleFontFile((string file, string assetPipelineFriendlyName, byte[] data) tuple)
        {
            return GetMetadata<Font>(tuple.file, tuple.data);
        }

        private static Asset HandleSpriteFile((string file, string assetPipelineFriendlyName, byte[] data) tuple)
        {
            return GetMetadata<Sprite>(tuple.file, tuple.data);
        }
    }
}
