namespace Editor
{
    public partial class PropertyField : UserControl
    {
        public Property? EditingProperty { get; set; }

        public PropertyField()
        {
            InitializeComponent();
        }

        public virtual void RefreshProperty()
        {
            PropertyNameLabel.Text = EditingProperty!.PropertyName;
        }
    }
}
