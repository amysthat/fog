using fog.Assets;

namespace Editor
{
    public static class ProjectDirectory
    {
        private static List<string> validItems = new();
        private static List<string> unhandledItems = new();
        private static List<string> invalidItems = new();

        public static void Refresh()
        {
            validItems.Clear();
            unhandledItems.Clear();
            invalidItems.Clear();

            foreach (var item in Directory.GetFiles(EditorApplication.ProjectPath!))
            {
                var extension = Path.GetExtension(item);

                if (extension == ".fgeditor")
                    continue;

                if (extension == ".fgproject")
                    continue;

                if (extension == ".fgmeta")
                    continue;

                var canBehandled = AssetPipeline.AssetHandling.CanFileBeHandled(item);

                if (canBehandled)
                {
                    validItems.Add(item);
                }
                else
                {
                    unhandledItems.Add(item);
                }
            }
        }

        public static IEnumerable<string> GetValidItems() => validItems.AsEnumerable();
        public static IEnumerable<string> GetUnhandledItems() => unhandledItems.AsEnumerable();
        public static IEnumerable<string> GetInvalidItems() => invalidItems.AsEnumerable();
    }
}
