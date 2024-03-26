using fog;
using fog.Entities;

namespace Editor
{
    public partial class EntityForm : Form
    {
        public Entity? EditingEntity { get; set; }

        public EntityForm()
        {
            InitializeComponent();
        }

        private void EntityForm_Shown(object sender, EventArgs e)
        {
            GUIDTextbox.Text = EditingEntity!.GUID.ToString();
            EntityNameTextbox.Text = EditingEntity!.Name;
            PositionTextbox.Text = ConvertPosition(EditingEntity!.Position);

            ComponentsGroup.Text = $"Components ({EditingEntity.Components.Count})";
        }

        private string ConvertPosition(Vector2 position)
        {
            return $"{position.X}; {position.Y}";
        }
    }
}
