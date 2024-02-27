namespace Editor
{
    public partial class ProjectView : Form
    {
        public ProjectView()
        {
            InitializeComponent();
        }

        public void RefreshList()
        {
            FolderView.SmallImageList = null;
            FolderView.Items.Clear();

            var imageList = new ImageList();

            foreach (var file in Directory.GetFiles(EditorApplication.ProjectPath!))
            {
                if (!ShouldFileBeShown(file))
                    continue;

                var fileName = Path.GetFileName(file);

                imageList.Images.Add(fileName, Properties.Resources.GenericItem);
            }

            FolderView.SmallImageList = imageList;

            foreach (var file in Directory.GetFiles(EditorApplication.ProjectPath!))
            {
                if (!ShouldFileBeShown(file))
                    continue;

                var fileName = Path.GetFileName(file);

                var item = new ListViewItem
                {
                    Text = fileName,
                    ImageKey = fileName,
                };

                FolderView.Items.Add(item);
            }
        }

        private void ProjectView_Shown(object sender, EventArgs e)
        {
            if (EditorApplication.EditorSettings!.GameProjectPath == string.Empty)
            {
                new DllLocator().ShowDialog();
            }

            RefreshList();
        }

        private void reloadProjectDLLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RefreshList();
        }

        private bool ShouldFileBeShown(string fileName)
        {
            var extension = Path.GetExtension(fileName);

            if (extension == ".fgeditor")
                return false;

            if (extension == ".fgproject")
                return false;

            return true;
        }

        private void FolderView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var item = FolderView.GetItemAt(e.X, e.Y);

            if (item is not null)
            {
                EditItem(item.Text);
            }
        }

        private void EditItem(string fileName)
        {

        }

        private void openProjectSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ProjectSettingsView().ShowDialog();
        }
    }
}
