namespace Editor
{
    public partial class ProjectSelect : Form
    {
        public ProjectSelect()
        {
            InitializeComponent();
        }

        private void CreateProjectButton_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    EditorApplication.CreateProject(fbd.SelectedPath);
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