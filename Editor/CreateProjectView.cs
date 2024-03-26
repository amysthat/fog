using BlueMystic;

namespace Editor
{
    public partial class CreateProjectView : Form
    {
        public string? ChosenProjectName { get; private set; }
        public string? ChosenProjectPath { get; private set; }

        public CreateProjectView()
        {
            InitializeComponent();
            new DarkModeCS(this);
        }

        private void CreateProjectButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            ChosenProjectName = ProjectName.Text;
            ChosenProjectPath = ProjectPath.Text;
        }

        private void ProjectName_TextChanged(object sender, EventArgs e)
        {
            RevalidateCreateProjectButton();
        }

        private void ChoosePath_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    ProjectPath.Text = fbd.SelectedPath;
                }
            }
        }

        private void ProjectPath_TextChanged(object sender, EventArgs e)
        {
            RevalidateCreateProjectButton();
        }

        private void RevalidateCreateProjectButton()
        {
            CreateProjectButton.Enabled = !string.IsNullOrEmpty(ProjectName.Text) && !string.IsNullOrEmpty(ProjectPath.Text);
        }

        private void CreateProjectView_Load(object sender, EventArgs e)
        {
            RevalidateCreateProjectButton();
        }
    }
}
