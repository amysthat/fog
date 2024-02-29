using BlueMystic;
using fog.Assets;
using System.Diagnostics;

namespace Editor
{
    public partial class ItemPropertiesView : Form
    {
        public Asset? EditingAsset { get; set; }
        public string? EditingAssetName { get; set; }

        public Type EditingAssetType => EditingAsset!.GetType();

        public ItemPropertiesView()
        {
            InitializeComponent();
            new DarkModeCS(this);
        }

        private void OpenDefaultApplication_Click(object sender, EventArgs e)
        {
            new Process
            {
                StartInfo = new ProcessStartInfo(Path.Combine(EditorApplication.AssetPath, EditingAssetName!))
                {
                    UseShellExecute = true
                }
            }.Start();
        }

        private void ItemPropertiesView_Shown(object sender, EventArgs e)
        {
            GUIDTextbox.Text = EditingAsset!.GUID.ToString();
            TypeTextbox.Text = EditingAssetType.Name;
        }
    }
}
