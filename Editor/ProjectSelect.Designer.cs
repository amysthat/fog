namespace Editor
{
    partial class ProjectSelect
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            CreateProjectButton = new Button();
            OpenProjectButton = new Button();
            SuspendLayout();
            // 
            // CreateProjectButton
            // 
            CreateProjectButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            CreateProjectButton.Location = new Point(12, 12);
            CreateProjectButton.Name = "CreateProjectButton";
            CreateProjectButton.Size = new Size(222, 66);
            CreateProjectButton.TabIndex = 0;
            CreateProjectButton.Text = "Create a New Project";
            CreateProjectButton.UseVisualStyleBackColor = true;
            CreateProjectButton.Click += CreateProjectButton_Click;
            // 
            // OpenProjectButton
            // 
            OpenProjectButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            OpenProjectButton.Location = new Point(12, 84);
            OpenProjectButton.Name = "OpenProjectButton";
            OpenProjectButton.Size = new Size(222, 66);
            OpenProjectButton.TabIndex = 1;
            OpenProjectButton.Text = "Open a Project";
            OpenProjectButton.UseVisualStyleBackColor = true;
            OpenProjectButton.Click += OpenProjectButton_Click;
            // 
            // ProjectSelect
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(245, 159);
            Controls.Add(OpenProjectButton);
            Controls.Add(CreateProjectButton);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "ProjectSelect";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Project Select";
            Load += ProjectSelect_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button CreateProjectButton;
        private Button OpenProjectButton;
    }
}