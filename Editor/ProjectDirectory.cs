using fog.Assets;
using fog.Memory;

namespace Editor
{
    public static class ProjectDirectory
    {
        private static List<string> validItems = new();
        private static List<string> unhandledItems = new();
        private static List<string> invalidItems = new();

        private static Dictionary<string, Exception> unparsedItems = new();
        private static Dictionary<string, Asset> parsedItems = new();

        public static void Refresh()
        {
            foreach (var asset in parsedItems.Values)
            {
                MemoryManager.Remove(asset.GUID);
            }

            validItems.Clear();
            unhandledItems.Clear();
            invalidItems.Clear();
            parsedItems.Clear();
            unparsedItems.Clear();

            foreach (var item in Directory.GetFiles(EditorApplication.AssetPath))
            {
                var extension = Path.GetExtension(item);
                var itemName = Path.GetFileName(item);

                if (extension == ".fgeditor")
                    continue;

                if (extension == ".fgproject")
                    continue;

                if (extension == ".fgmeta")
                    continue;

                if (extension == ".fgentity")
                {
                    unparsedItems.Add(itemName, new NotImplementedException("Entities aren't properly supported."));
                    invalidItems.Add(itemName);
                    continue;
                }

                var hasMetadata = AssetPipeline.HasMetadata(itemName);
                var canBeHandled = AssetPipeline.AssetHandling.CanFileBeHandled(item);

                if (canBeHandled)
                {
                    if (!hasMetadata)
                    {
                        GenerateMetadata(itemName);
                    }

                    try
                    {
                        var asset = AssetPipeline.AssetHandling.ParseFile(item, AssetDirectory.ReadAllBytes(item));

                        parsedItems.Add(itemName, asset);
                        validItems.Add(itemName);
                    }
                    catch (Exception ex)
                    {
                        unparsedItems.Add(itemName, ex);
                        invalidItems.Add(itemName);
                    }
                }
                else
                {
                    unhandledItems.Add(itemName);
                }
            }
        }

        public static void SaveAsset(string item, Asset asset)
        {
            var metadataName = Path.ChangeExtension(item, ".fgmeta");

            var content = AssetPipeline.Serialization.SerializeContent(asset);
            AssetDirectory.WriteAllText(metadataName, content);
        }

        public static void GenerateMetadata(string item)
        {
            var extension = Path.GetExtension(item);
            var metadataName = Path.ChangeExtension(item, ".fgmeta");

            var type = AssetPipeline.AssetHandling.FileTypeLookup[extension];
            var generatedAsset = AssetPipeline.GenerateAsset(type);
            var content = AssetPipeline.Serialization.SerializeContent(generatedAsset);
            AssetDirectory.WriteAllText(metadataName, content);

            MessageBox.Show($"{item} ({type.FullName}) did not have metadata, and a new one was generated.");
        }

        public static IEnumerable<string> GetValidItems() => validItems.AsEnumerable();
        public static IEnumerable<string> GetUnhandledItems() => unhandledItems.AsEnumerable();
        public static IEnumerable<string> GetInvalidItems() => invalidItems.AsEnumerable();

        public static Asset GetAsset(string file) => parsedItems[file];
        public static Exception GetInvalidException(string file) => unparsedItems[file];
    }
}
