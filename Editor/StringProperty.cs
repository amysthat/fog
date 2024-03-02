namespace Editor
{
    public partial class StringProperty : PropertyField
    {
        public StringProperty()
        {
            InitializeComponent();
        }

        private void EditBox_TextChanged(object? sender, EventArgs e)
        {
            EditingProperty!.SetValue(EditBox.Text);
        }

        public override void RefreshProperty()
        {
            base.RefreshProperty();

            EditBox.Text = (string)EditingProperty!.GetValue();
        }
    }
}
