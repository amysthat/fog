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

            var shownPropertyCount = 0;
            var hiddenPropertyCount = 0;
            var properties = Property.GetAllProperties(EditingAsset);

            int currentY = 0;

            foreach (var property in properties)
            {
                if (property.PropertyName == "GUID")
                    continue;

                if (FieldLookup.TryGetValue(property.PropertyType!, out var fieldType))
                {
                    var accessors = EditingAssetType.GetProperty(property.PropertyName)!.GetAccessors();

                    var shouldBeShown = accessors.Length > 1 && (accessors[0].IsPublic &&
                                                                 accessors[1].IsPublic);

                    if (!shouldBeShown)
                    {
                        hiddenPropertyCount++;
                        continue;
                    }

                    var field = (PropertyField)Activator.CreateInstance(fieldType)!;
                    PropertyPanel.Controls.Add(field);
                    field.EditingProperty = property;
                    field.Location = new Point(0, currentY);
                    field.RefreshProperty();

                    currentY += 40;
                    shownPropertyCount++;
                }
                else
                {
                    hiddenPropertyCount++;
                    MessageBox.Show($"Could not find a property field for {property.PropertyName} ({property.PropertyType!.Name})");
                }
            }

            groupBox1.Text = $"Exposed Properties ({shownPropertyCount}:{hiddenPropertyCount})";
        }
    }
}
