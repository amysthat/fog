namespace Editor
{
    public partial class StringProperty : PropertyField
    {
        private TextBox editBox;

        public StringProperty()
        {
            InitializeComponent();

            editBox = new TextBox();
            PropertyEditPanel.Controls.Add(editBox);
            editBox.Dock = DockStyle.Fill;
            editBox.TextChanged += EditBox_TextChanged;
            editBox.BringToFront();
        }

        private void EditBox_TextChanged(object? sender, EventArgs e)
        {
            EditingProperty!.SetValue(editBox.Text);
        }

        public override void RefreshProperty()
        {
            base.RefreshProperty();

            editBox.Text = (string)EditingProperty!.GetValue();
        }
    }
}
