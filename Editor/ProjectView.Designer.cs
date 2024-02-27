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
            reloadProjectDLLToolStripMenuItem = new ToolStripMenuItem();
            runToolStripMenuItem = new ToolStripMenuItem();
            statusStrip1 = new StatusStrip();
            StatusLabel = new ToolStripStatusLabel();
            FolderView = new ListView();
            openProjectSettingsToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { reloadProjectDLLToolStripMenuItem, openProjectSettingsToolStripMenuItem, runToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(962, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // reloadProjectDLLToolStripMenuItem
            // 
            reloadProjectDLLToolStripMenuItem.Name = "reloadProjectDLLToolStripMenuItem";
            reloadProjectDLLToolStripMenuItem.Size = new Size(106, 20);
            reloadProjectDLLToolStripMenuItem.Text = "Reload Directory";
            reloadProjectDLLToolStripMenuItem.Click += reloadProjectDLLToolStripMenuItem_Click;
            // 
            // runToolStripMenuItem
            // 
            runToolStripMenuItem.Name = "runToolStripMenuItem";
            runToolStripMenuItem.Size = new Size(40, 20);
            runToolStripMenuItem.Text = "Run";
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { StatusLabel });
            statusStrip1.Location = new Point(0, 617);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(962, 22);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // StatusLabel
            // 
            StatusLabel.Name = "StatusLabel";
            StatusLabel.Size = new Size(39, 17);
            StatusLabel.Text = "Ready";
            // 
            // FolderView
            // 
            FolderView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            FolderView.FullRowSelect = true;
            FolderView.Location = new Point(12, 27);
            FolderView.MultiSelect = false;
            FolderView.Name = "FolderView";
            FolderView.Size = new Size(938, 587);
            FolderView.TabIndex = 2;
            FolderView.TileSize = new Size(500, 500);
            FolderView.UseCompatibleStateImageBehavior = false;
            FolderView.View = View.List;
            FolderView.MouseDoubleClick += FolderView_MouseDoubleClick;
            // 
            // openProjectSettingsToolStripMenuItem
            // 
            openProjectSettingsToolStripMenuItem.Name = "openProjectSettingsToolStripMenuItem";
            openProjectSettingsToolStripMenuItem.Size = new Size(133, 20);
            openProjectSettingsToolStripMenuItem.Text = "Open Project Settings";
            openProjectSettingsToolStripMenuItem.Click += openProjectSettingsToolStripMenuItem_Click;
            // 
            // ProjectView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(962, 639);
            Controls.Add(FolderView);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "ProjectView";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Project";
            Shown += ProjectView_Shown;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem reloadProjectDLLToolStripMenuItem;
        private ToolStripMenuItem runToolStripMenuItem;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel StatusLabel;
        private ListView FolderView;
        private ToolStripMenuItem openProjectSettingsToolStripMenuItem;
    }
}