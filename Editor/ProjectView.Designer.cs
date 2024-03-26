namespace Editor
{
    partial class ProjectView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            openİnFileExplorerToolStripMenuItem = new ToolStripMenuItem();
            reloadProjectDLLToolStripMenuItem = new ToolStripMenuItem();
            openProjectSettingsToolStripMenuItem = new ToolStripMenuItem();
            openCProjectToolStripMenuItem = new ToolStripMenuItem();
            runToolStripMenuItem = new ToolStripMenuItem();
            FolderView = new ListView();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { openİnFileExplorerToolStripMenuItem, reloadProjectDLLToolStripMenuItem, openProjectSettingsToolStripMenuItem, openCProjectToolStripMenuItem, runToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(962, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // openİnFileExplorerToolStripMenuItem
            // 
            openİnFileExplorerToolStripMenuItem.Name = "openİnFileExplorerToolStripMenuItem";
            openİnFileExplorerToolStripMenuItem.Size = new Size(128, 20);
            openİnFileExplorerToolStripMenuItem.Text = "Open in File Explorer";
            openİnFileExplorerToolStripMenuItem.Click += openInFileExplorerToolStripMenuItem_Click;
            // 
            // reloadProjectDLLToolStripMenuItem
            // 
            reloadProjectDLLToolStripMenuItem.Name = "reloadProjectDLLToolStripMenuItem";
            reloadProjectDLLToolStripMenuItem.Size = new Size(106, 20);
            reloadProjectDLLToolStripMenuItem.Text = "Reload Directory";
            reloadProjectDLLToolStripMenuItem.Click += reloadProjectDLLToolStripMenuItem_Click;
            // 
            // openProjectSettingsToolStripMenuItem
            // 
            openProjectSettingsToolStripMenuItem.Name = "openProjectSettingsToolStripMenuItem";
            openProjectSettingsToolStripMenuItem.Size = new Size(133, 20);
            openProjectSettingsToolStripMenuItem.Text = "Open Project Settings";
            openProjectSettingsToolStripMenuItem.Click += openProjectSettingsToolStripMenuItem_Click;
            // 
            // openCProjectToolStripMenuItem
            // 
            openCProjectToolStripMenuItem.Name = "openCProjectToolStripMenuItem";
            openCProjectToolStripMenuItem.Size = new Size(106, 20);
            openCProjectToolStripMenuItem.Text = "Open C# Project";
            openCProjectToolStripMenuItem.Click += openCProjectToolStripMenuItem_Click;
            // 
            // runToolStripMenuItem
            // 
            runToolStripMenuItem.Name = "runToolStripMenuItem";
            runToolStripMenuItem.Size = new Size(40, 20);
            runToolStripMenuItem.Text = "Run";
            runToolStripMenuItem.Click += runToolStripMenuItem_Click;
            // 
            // FolderView
            // 
            FolderView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            FolderView.FullRowSelect = true;
            FolderView.Location = new Point(12, 27);
            FolderView.MultiSelect = false;
            FolderView.Name = "FolderView";
            FolderView.Size = new Size(938, 600);
            FolderView.TabIndex = 2;
            FolderView.TileSize = new Size(500, 500);
            FolderView.UseCompatibleStateImageBehavior = false;
            FolderView.View = View.List;
            FolderView.MouseDoubleClick += FolderView_MouseDoubleClick;
            // 
            // ProjectView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(962, 639);
            Controls.Add(FolderView);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "ProjectView";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Project";
            Shown += ProjectView_Shown;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem reloadProjectDLLToolStripMenuItem;
        private ToolStripMenuItem runToolStripMenuItem;
        private ListView FolderView;
        private ToolStripMenuItem openProjectSettingsToolStripMenuItem;
        private ToolStripMenuItem openCProjectToolStripMenuItem;
        private ToolStripMenuItem openİnFileExplorerToolStripMenuItem;
    }
}