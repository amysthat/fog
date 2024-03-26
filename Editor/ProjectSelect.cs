using BlueMystic;

namespace Editor
{
    public partial class ProjectSelect : Form
    {
        public ProjectSelect()
        {
            InitializeComponent();
            new DarkModeCS(this);
        }

        private void CreateProjectButton_Click(object sender, EventArgs e)
        {
            using (var newProjectView = new CreateProjectView())
            {
                DialogResult result = newProjectView.ShowDialog();

                if (result == DialogResult.OK)
                {
                    EditorApplication.CreateProject(newProjectView.ChosenProjectPath!, newProjectView.ChosenProjectName!);
                }
            }
        }

        private void ProjectSelect_Load(object sender, EventArgs e)
        {
            EditorApplication.ProjectSelectWindow = this;
        }

        private void OpenProjectButton_Click(object sender, EventArgs e)
        {
            using (var fileDlg = new OpenFileDialog())
            {
                fileDlg.Filter = "Project Files|.fgeditor";

                DialogResult result = fileDlg.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fileDlg.FileName))
                {
                    var folderPath = Path.GetDirectoryName(fileDlg.FileName)!;
                    EditorApplication.LoadProject(folderPath);
                }
            }
        }
    }
}