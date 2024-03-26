using BlueMystic;
using System.Diagnostics;

namespace Editor
{
    public partial class ProjectView : Form
    {
        public ProjectView()
        {
            InitializeComponent();
            new DarkModeCS(this);
        }

        public void RefreshList()
        {
            ProjectDirectory.Refresh();

            FolderView.SmallImageList = null;
            FolderView.Items.Clear();

            var imageList = new ImageList();
            FolderView.SmallImageList = imageList;

            foreach (var file in ProjectDirectory.GetInvalidItems())
            {
                var fileName = Path.GetFileName(file);

                imageList.Images.Add(fileName, Properties.Resources.InvalidItem);

                var item = new ListViewItem
                {
                    Text = fileName,
                    ImageKey = fileName,
                    Tag = ItemStatus.Invalid,
                };

                FolderView.Items.Add(item);
            }

            foreach (var file in ProjectDirectory.GetUnhandledItems())
            {
                var fileName = Path.GetFileName(file);

                imageList.Images.Add(fileName, Properties.Resources.UnhandledItem);

                var item = new ListViewItem
                {
                    Text = fileName,
                    ImageKey = fileName,
                    Tag = ItemStatus.Unhandled,
                };

                FolderView.Items.Add(item);
            }

            foreach (var file in ProjectDirectory.GetValidItems())
            {
                var fileName = Path.GetFileName(file);

                imageList.Images.Add(fileName, Properties.Resources.GenericItem);

                var item = new ListViewItem
                {
                    Text = fileName,
                    ImageKey = fileName,
                    Tag = ItemStatus.Valid,
                };

                FolderView.Items.Add(item);
            }
        }

        private void ProjectView_Shown(object sender, EventArgs e)
        {
            Text = $"fog Project - {EditorApplication.EditorSettings!.ProjectName}";

            RefreshList();
        }

        private void reloadProjectDLLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void FolderView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var item = FolderView.GetItemAt(e.X, e.Y);

            if (item is not null)
            {
                EditItem(item.Text, (ItemStatus)item.Tag);
            }
        }

        private void EditItem(string fileName, ItemStatus itemStatus)
        {
            if (itemStatus == ItemStatus.Unhandled)
            {
                MessageBox.Show("This item will not be added to your project because it is currently not supported.", "Unhandled Item", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (itemStatus == ItemStatus.Invalid)
            {
                MessageBox.Show($"This item is invalid. Please check its and its metadata's content.\n{ProjectDirectory.GetInvalidException(fileName)}", "Invalid Item", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var isEntity = Path.GetExtension(fileName) == ".fgentity";

            if (isEntity)
            {
                var entity = ProjectDirectory.GetEntity(fileName);

                var entityProperties = new EntityForm();
                entityProperties.EditingEntity = entity;
                entityProperties.ShowDialog();
                return;
            }

            var asset = ProjectDirectory.GetAsset(fileName);

            var properties = new ItemPropertiesView();
            properties.EditingAsset = asset;
            properties.EditingAssetName = fileName;
            properties.ShowDialog();

            try
            {
                ProjectDirectory.SaveAsset(fileName, asset);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"There was a problem saving {fileName} ({asset.GetType().Name}).\n{ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void openProjectSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ProjectSettingsView().ShowDialog();
        }

        private void openCProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CsProject.OpenCsProject(EditorApplication.EditorSettings!.ProjectName);
        }

        private void openInFileExplorerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("explorer", EditorApplication.AssetPath);
        }

        private void runToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CsProject.BuildCsProject(EditorApplication.EditorSettings!.ProjectName);
        }
    }
}
