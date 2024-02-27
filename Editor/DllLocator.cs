namespace Editor
{
    public partial class DllLocator : Form
    {
        public DllLocator()
        {
            InitializeComponent();
        }

        private void GetDllButton_Click(object sender, EventArgs e)
        {
            using (var fileDlg = new SaveFileDialog())
            {
                fileDlg.FileName = "fog";
                fileDlg.Filter = "Class Library|.dll";

                DialogResult result = fileDlg.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fileDlg.FileName))
                {
                    using (var dlg = new OpenFileDialog())
                    {
                        dlg.Filter = "fogEngine Dll|*.dll";

                        result = dlg.ShowDialog();

                        if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(dlg.FileName))
                        {
                            byte[] content = File.ReadAllBytes(dlg.FileName);
                            File.WriteAllBytes(fileDlg.FileName, content);

                            ImportProjButton.Enabled = true;
                        }
                    }
                }
            }
        }

        private void ImportProjButton_Click(object sender, EventArgs e)
        {
            using (var fileDlg = new OpenFileDialog())
            {
                fileDlg.Filter = "C# Project|*.csproj";

                DialogResult result = fileDlg.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fileDlg.FileName))
                {
                    ContinueButton.Enabled = true;
                    ImportProjButton.Enabled = false;
                    GetDllButton.Enabled = false;
                    ImportedCheckBox.Checked = true;

                    EditorApplication.EditorSettings!.GameProjectPath = fileDlg.FileName;
                    EditorApplication.SaveEditorSettings();
                }
            }
        }

        private void ContinueButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
