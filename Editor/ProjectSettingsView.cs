using BlueMystic;
using fog;
using fog.Entities;
using fog.Memory;
using Color = Microsoft.Xna.Framework.Color;
using Font = fog.Assets.Font;

namespace Editor
{
    public partial class ProjectSettingsView : Form
    {
        public ProjectSettingsView()
        {
            InitializeComponent();
            new DarkModeCS(this);
        }

        private void ProjectSettingsView_Load(object sender, EventArgs e)
        {
            var projectSettings = EditorApplication.ProjectSettings!;
            ResolutionX.Value = projectSettings.Resolution.Width;
            ResolutionY.Value = projectSettings.Resolution.Height;
            ResolutionFullscreen.Checked = projectSettings.Resolution.Fullscreen;

            Title.Text = projectSettings.Title;

            ClearColorR.Value = projectSettings.ClearColor.R;
            ClearColorG.Value = projectSettings.ClearColor.G;
            ClearColorB.Value = projectSettings.ClearColor.B;

            StartupEntity.Text = projectSettings.StartupEntity.GUID.ToString();

            DefaultFont.Text = projectSettings.DefaultFont.GUID.ToString();

            DefaultTextColorR.Value = projectSettings.DefaultTextColor.R;
            DefaultTextColorG.Value = projectSettings.DefaultTextColor.G;
            DefaultTextColorB.Value = projectSettings.DefaultTextColor.B;

            PlayerAssembly.Text = projectSettings.PlayerAssembly;

            GUID.Text = projectSettings.GUID.ToString();
        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            EditorApplication.ProjectSettings!.Resolution = new Resolution
            {
                Width = (int)ResolutionX.Value,
                Height = (int)ResolutionY.Value,
                Fullscreen = ResolutionFullscreen.Checked,
            };

            EditorApplication.ProjectSettings.Title = Title.Text;

            var clearColor = new Color
            {
                R = (byte)ClearColorR.Value,
                G = (byte)ClearColorG.Value,
                B = (byte)ClearColorB.Value,
            };
            EditorApplication.ProjectSettings.ClearColor = clearColor;

            EditorApplication.ProjectSettings.StartupEntity = Reference<Entity>.From(Guid.Parse(StartupEntity.Text));

            EditorApplication.ProjectSettings.DefaultFont = Reference<Font>.From(Guid.Parse(DefaultFont.Text));

            var defaultTextColor = new Color
            {
                R = (byte)DefaultTextColorR.Value,
                G = (byte)DefaultTextColorG.Value,
                B = (byte)DefaultTextColorB.Value,
            };
            EditorApplication.ProjectSettings.DefaultTextColor = defaultTextColor;

            EditorApplication.SaveProjectSettings();
        }

        private void ClearColorPickButton_Click(object sender, EventArgs e)
        {
            using (var picker = new ColorDialog())
            {
                if (picker.ShowDialog() == DialogResult.OK)
                {
                    var color = picker.Color;

                    ClearColorR.Value = color.R;
                    ClearColorG.Value = color.G;
                    ClearColorB.Value = color.B;
                }
            }
        }

        private void DefaultFontColorPickButton_Click(object sender, EventArgs e)
        {
            using (var picker = new ColorDialog())
            {
                if (picker.ShowDialog() == DialogResult.OK)
                {
                    var color = picker.Color;

                    DefaultTextColorR.Value = color.R;
                    DefaultTextColorG.Value = color.G;
                    DefaultTextColorB.Value = color.B;
                }
            }
        }
    }
}
