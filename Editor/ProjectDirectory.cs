using fog.Assets;
using fog.Entities;
using fog.Memory;
using Object = fog.Memory.Object;

namespace Editor
{
    public static class ProjectDirectory
    {
        private static List<string> validItems = new();
        private static List<string> unhandledItems = new();
        private static List<string> invalidItems = new();

        private static Dictionary<string, Exception> unparsedItems = new();
        private static Dictionary<string, Object> parsedItems = new();

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
                    try
                    {
                        var entity = AssetPipeline.Serialization.Deserialize<Entity>(itemName);
                        parsedItems.Add(itemName, entity);
                        validItems.Add(itemName);
                    }
                    catch (Exception ex)
                    {
                        unparsedItems.Add(itemName, ex);
                        invalidItems.Add(itemName);
                    }
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

        public static Entity GetEntity(string file) => (Entity) parsedItems[file];
        public static Asset GetAsset(string file) => (Asset) parsedItems[file];
        public static Exception GetInvalidException(string file) => unparsedItems[file];
    }
}
