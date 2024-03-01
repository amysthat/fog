using BlueMystic;
using fog.Assets;
using System.Diagnostics;

namespace Editor
{
    public partial class ItemPropertiesView : Form
    {
        private static Dictionary<Type, Type> FieldLookup = new()
        {
            { typeof(string), typeof(StringProperty) }
        };

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

            foreach (var property in Property.GetAllProperties(EditingAsset))
            {
                if (FieldLookup.TryGetValue(property.PropertyType!, out var fieldType))
                {
                    var accessors = EditingAssetType.GetProperty(property.PropertyName)!.GetAccessors();

                    var shouldBeShown = accessors.Length > 1 && (accessors[0].IsPublic &&
                                                                 accessors[1].IsPublic);

                    if (!shouldBeShown)
                    {
                        MessageBox.Show($"{property.PropertyName} ({property.PropertyType!.Name}) will not be shown.");
                        continue;
                    }

                    var field = (PropertyField) Activator.CreateInstance(fieldType)!;
                    PropertyPanel.Controls.Add(field);
                    field.EditingProperty = property;
                    field.Location = new Point(0, 0);
                    field.RefreshProperty();
                }
                else
                {
                    MessageBox.Show($"Could not find a property field for {property.PropertyName} ({property.PropertyType!.Name})");
                }
            }
        }
    }
}
