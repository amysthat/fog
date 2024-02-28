namespace Editor
{
    partial class CreateProjectView
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
            label1 = new Label();
            ProjectName = new TextBox();
            CreateProjectButton = new Button();
            label2 = new Label();
            ProjectPath = new TextBox();
            ChoosePath = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(180, 15);
            label1.TabIndex = 0;
            label1.Text = "Enter your project's name below.";
            // 
            // ProjectName
            // 
            ProjectName.Location = new Point(12, 27);
            ProjectName.Name = "ProjectName";
            ProjectName.Size = new Size(479, 23);
            ProjectName.TabIndex = 1;
            ProjectName.TextChanged += ProjectName_TextChanged;
            // 
            // CreateProjectButton
            // 
            CreateProjectButton.Location = new Point(382, 123);
            CreateProjectButton.Name = "CreateProjectButton";
            CreateProjectButton.Size = new Size(109, 23);
            CreateProjectButton.TabIndex = 2;
            CreateProjectButton.Text = "Create";
            CreateProjectButton.UseVisualStyleBackColor = true;
            CreateProjectButton.Click += CreateProjectButton_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 53);
            label2.Name = "label2";
            label2.Size = new Size(275, 15);
            label2.TabIndex = 3;
            label2.Text = "Enter the path you want your project to be created:";
            // 
            // ProjectPath
            // 
            ProjectPath.Location = new Point(12, 71);
            ProjectPath.Name = "ProjectPath";
            ProjectPath.Size = new Size(448, 23);
            ProjectPath.TabIndex = 4;
            ProjectPath.TextChanged += ProjectPath_TextChanged;
            // 
            // ChoosePath
            // 
            ChoosePath.Location = new Point(466, 71);
            ChoosePath.Name = "ChoosePath";
            ChoosePath.Size = new Size(25, 23);
            ChoosePath.TabIndex = 5;
            ChoosePath.Text = "...";
            ChoosePath.UseVisualStyleBackColor = true;
            ChoosePath.Click += ChoosePath_Click;
            // 
            // CreateProjectView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(503, 158);
            Controls.Add(ChoosePath);
            Controls.Add(ProjectPath);
            Controls.Add(label2);
            Controls.Add(CreateProjectButton);
            Controls.Add(ProjectName);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CreateProjectView";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Create Project";
            Load += CreateProjectView_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox ProjectName;
        private Button CreateProjectButton;
        private Label label2;
        private TextBox ProjectPath;
        private Button ChoosePath;
    }
}