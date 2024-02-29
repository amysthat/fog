using fog;
using fog.Assets;
using fog.Memory;

namespace Editor
{
    public static class EditorApplication
    {
        public static string? ProjectPath { get; set; }
        public static EditorSettings? EditorSettings { get; set; }
        public static ProjectSettings? ProjectSettings { get; set; }

        public static ProjectSelect? ProjectSelectWindow { get; set; }
        public static ProjectView? ProjectViewWindow { get; set; }

        public static string ProjectSettingsPath { get => Path.Combine(ProjectPath!, ".fgproject"); }
        public static string EditorSettingsPath { get => Path.Combine(ProjectPath!, ".fgeditor"); }
        public static string AssetPath { get => Path.Combine(ProjectPath!, "assets"); }

        public static void CreateProject(string path, string projectName)
        {
            ProjectPath = path;

            ProjectSettings = MemoryManager.Allocate<ProjectSettings>();
            ProjectSettings.Title = projectName;
            ProjectSettings.PlayerAssembly = projectName;
            SaveProjectSettings();

            EditorSettings = new()
            {
                ProjectName = projectName,
            };
            SaveEditorSettings();

            CsProject.GenerateCsProject(projectName);
            Directory.CreateDirectory(AssetPath);

            LoadProject(path);
        }

        public static void LoadProject(string path)
        {
            ProjectPath = path;
            AssetDirectory.AssetPath = AssetPath;

            var editorSettingsContent = File.ReadAllText(EditorSettingsPath);
            EditorSettings = AssetPipeline.Serialization.DeserializeContent<EditorSettings>(editorSettingsContent);

            var projectSettingsContent = File.ReadAllText(ProjectSettingsPath);
            ProjectSettings = AssetPipeline.Serialization.DeserializeContent<ProjectSettings>(projectSettingsContent);

            ProjectViewWindow = new();
            ProjectViewWindow.Show();
            ProjectSelectWindow?.Close();
        }

        public static void SaveEditorSettings()
        {
            var editorSettingsContent = AssetPipeline.Serialization.SerializeContent(EditorSettings!);

            File.WriteAllText(EditorSettingsPath, editorSettingsContent);
        }

        public static void SaveProjectSettings()
        {
            var projectSettingsContent = AssetPipeline.Serialization.SerializeContent(ProjectSettings);

            File.WriteAllText(ProjectSettingsPath, projectSettingsContent);
        }
    }
}